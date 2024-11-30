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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action41") == 0 )
         {
            A67ResidentEmail = GetPar( "ResidentEmail");
            AssignAttri("", false, "A67ResidentEmail", A67ResidentEmail);
            A64ResidentGivenName = GetPar( "ResidentGivenName");
            AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = GetPar( "ResidentLastName");
            AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
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
            XC_41_0916( A67ResidentEmail, A64ResidentGivenName, A65ResidentLastName, Gx_mode, A71ResidentGUID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action42") == 0 )
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
            XC_42_0916( A64ResidentGivenName, A65ResidentLastName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action43") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A71ResidentGUID = GetPar( "ResidentGUID");
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
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
            XC_43_0916( Gx_mode, A71ResidentGUID, A64ResidentGivenName, A65ResidentLastName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action44") == 0 )
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
            XC_44_0916( Gx_mode, A71ResidentGUID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel13"+"_"+"LOCATIONID") == 0 )
         {
            AV8LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
            AssignAttri("", false, "AV8LocationId", AV8LocationId.ToString());
            GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV8LocationId, context));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX13ASALOCATIONID0916( AV8LocationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel15"+"_"+"ORGANISATIONID") == 0 )
         {
            AV9OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "AV9OrganisationId", AV9OrganisationId.ToString());
            GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV9OrganisationId, context));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX15ASAORGANISATIONID0916( AV9OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel27"+"_"+"RESIDENTPHONE") == 0 )
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
            GX27ASARESIDENTPHONE0916( A375ResidentPhoneCode, A376ResidentPhoneNumber) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_51") == 0 )
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
            gxLoad_51( A29LocationId, A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_52") == 0 )
         {
            A96ResidentTypeId = StringUtil.StrToGuid( GetPar( "ResidentTypeId"));
            AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_52( A96ResidentTypeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_53") == 0 )
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
            gxLoad_53( A98MedicalIndicationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_55") == 0 )
         {
            A74NetworkIndividualId = StringUtil.StrToGuid( GetPar( "NetworkIndividualId"));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_55( A74NetworkIndividualId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_57") == 0 )
         {
            A82NetworkCompanyId = StringUtil.StrToGuid( GetPar( "NetworkCompanyId"));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_57( A82NetworkCompanyId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_networkindividual") == 0 )
         {
            gxnrGridlevel_networkindividual_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_networkcompany") == 0 )
         {
            gxnrGridlevel_networkcompany_newrow_invoke( ) ;
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
            GX_FocusControl = edtResidentBsnNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_networkindividual_newrow_invoke( )
      {
         nRC_GXsfl_150 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_150"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_150_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_150_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_150_idx = GetPar( "sGXsfl_150_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_networkindividual_newrow( ) ;
         /* End function gxnrGridlevel_networkindividual_newrow_invoke */
      }

      protected void gxnrGridlevel_networkcompany_newrow_invoke( )
      {
         nRC_GXsfl_167 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_167"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_167_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_167_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_167_idx = GetPar( "sGXsfl_167_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_networkcompany_newrow( ) ;
         /* End function gxnrGridlevel_networkcompany_newrow_invoke */
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
         cmbNetworkIndividualGender = new GXCombobox();
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentBsnNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentBsnNumber_Internalname, context.GetMessage( "BSN Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentBsnNumber_Internalname, A63ResidentBsnNumber, StringUtil.RTrim( context.localUtil.Format( A63ResidentBsnNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentBsnNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentBsnNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "BsnNumber", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbResidentSalutation, cmbResidentSalutation_Internalname, StringUtil.RTrim( A72ResidentSalutation), 1, cmbResidentSalutation_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbResidentSalutation.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "", true, 0, "HLP_Trn_Resident.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentGivenName_Internalname, A64ResidentGivenName, StringUtil.RTrim( context.localUtil.Format( A64ResidentGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentGivenName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentGivenName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Resident.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentLastName_Internalname, A65ResidentLastName, StringUtil.RTrim( context.localUtil.Format( A65ResidentLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentLastName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentLastName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Resident.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbResidentGender, cmbResidentGender_Internalname, StringUtil.RTrim( A68ResidentGender), 1, cmbResidentGender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbResidentGender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_Trn_Resident.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtResidentBirthDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtResidentBirthDate_Internalname, context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"), context.localUtil.Format( A73ResidentBirthDate, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentBirthDate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtResidentBirthDate_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Resident.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentEmail_Internalname, A67ResidentEmail, StringUtil.RTrim( context.localUtil.Format( A67ResidentEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A67ResidentEmail, "", "", "", edtResidentEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentEmail_Enabled, 1, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedresidentphonecode_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockresidentphonecode_Internalname, context.GetMessage( "Mobile Phone", ""), "", "", lblTextblockresidentphonecode_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTablemergedresidentphonecode_Internalname, tblTablemergedresidentphonecode_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='MergeDataCell'>") ;
         /* User Defined Control */
         ucCombo_residentphonecode.SetProperty("Caption", Combo_residentphonecode_Caption);
         ucCombo_residentphonecode.SetProperty("Cls", Combo_residentphonecode_Cls);
         ucCombo_residentphonecode.SetProperty("EmptyItem", Combo_residentphonecode_Emptyitem);
         ucCombo_residentphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_residentphonecode.SetProperty("DropDownOptionsData", AV41ResidentPhoneCode_Data);
         ucCombo_residentphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residentphonecode_Internalname, "COMBO_RESIDENTPHONECODEContainer");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='Invisible'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentPhoneCode_Internalname, context.GetMessage( "Resident Phone Code", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentPhoneCode_Internalname, A375ResidentPhoneCode, StringUtil.RTrim( context.localUtil.Format( A375ResidentPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentPhoneCode_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentPhoneCode_Visible, edtResidentPhoneCode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='DataContentCell'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentPhoneNumber_Internalname, context.GetMessage( "Resident Phone Number", ""), "gx-form-item AttributePhoneNumberLabel", 0, true, "width: 25%;");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentPhoneNumber_Internalname, A376ResidentPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A376ResidentPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentPhoneNumber_Jsonclick, 0, "AttributePhoneNumber", "", "", "", "", 1, edtResidentPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedresidenthomephonecode_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockresidenthomephonecode_Internalname, context.GetMessage( "Home Phone", ""), "", "", lblTextblockresidenthomephonecode_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTablemergedresidenthomephonecode_Internalname, tblTablemergedresidenthomephonecode_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='MergeDataCell'>") ;
         /* User Defined Control */
         ucCombo_residenthomephonecode.SetProperty("Caption", Combo_residenthomephonecode_Caption);
         ucCombo_residenthomephonecode.SetProperty("Cls", Combo_residenthomephonecode_Cls);
         ucCombo_residenthomephonecode.SetProperty("EmptyItem", Combo_residenthomephonecode_Emptyitem);
         ucCombo_residenthomephonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_residenthomephonecode.SetProperty("DropDownOptionsData", AV43ResidentHomePhoneCode_Data);
         ucCombo_residenthomephonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residenthomephonecode_Internalname, "COMBO_RESIDENTHOMEPHONECODEContainer");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='Invisible'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentHomePhoneCode_Internalname, context.GetMessage( "Resident Home Phone Code", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentHomePhoneCode_Internalname, A445ResidentHomePhoneCode, StringUtil.RTrim( context.localUtil.Format( A445ResidentHomePhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentHomePhoneCode_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentHomePhoneCode_Visible, edtResidentHomePhoneCode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='DataContentCell'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentHomePhoneNumber_Internalname, context.GetMessage( "Resident Home Phone Number", ""), "gx-form-item AttributePhoneNumberLabel", 0, true, "width: 25%;");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentHomePhoneNumber_Internalname, A446ResidentHomePhoneNumber, StringUtil.RTrim( context.localUtil.Format( A446ResidentHomePhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentHomePhoneNumber_Jsonclick, 0, "AttributePhoneNumber", "", "", "", "", 1, edtResidentHomePhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedresidenttypeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockresidenttypeid_Internalname, context.GetMessage( "Resident Type", ""), "", "", lblTextblockresidenttypeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_residenttypeid.SetProperty("Caption", Combo_residenttypeid_Caption);
         ucCombo_residenttypeid.SetProperty("Cls", Combo_residenttypeid_Cls);
         ucCombo_residenttypeid.SetProperty("DataListProc", Combo_residenttypeid_Datalistproc);
         ucCombo_residenttypeid.SetProperty("DataListProcParametersPrefix", Combo_residenttypeid_Datalistprocparametersprefix);
         ucCombo_residenttypeid.SetProperty("EmptyItem", Combo_residenttypeid_Emptyitem);
         ucCombo_residenttypeid.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_residenttypeid.SetProperty("DropDownOptionsData", AV31ResidentTypeId_Data);
         ucCombo_residenttypeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residenttypeid_Internalname, "COMBO_RESIDENTTYPEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentTypeId_Internalname, context.GetMessage( "Resident Type Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentTypeId_Internalname, A96ResidentTypeId.ToString(), A96ResidentTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentTypeId_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentTypeId_Visible, edtResidentTypeId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedmedicalindicationid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockmedicalindicationid_Internalname, context.GetMessage( "Medical Indication", ""), "", "", lblTextblockmedicalindicationid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_medicalindicationid.SetProperty("Caption", Combo_medicalindicationid_Caption);
         ucCombo_medicalindicationid.SetProperty("Cls", Combo_medicalindicationid_Cls);
         ucCombo_medicalindicationid.SetProperty("DataListProc", Combo_medicalindicationid_Datalistproc);
         ucCombo_medicalindicationid.SetProperty("DataListProcParametersPrefix", Combo_medicalindicationid_Datalistprocparametersprefix);
         ucCombo_medicalindicationid.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_medicalindicationid.SetProperty("DropDownOptionsData", AV33MedicalIndicationId_Data);
         ucCombo_medicalindicationid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_medicalindicationid_Internalname, "COMBO_MEDICALINDICATIONIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMedicalIndicationId_Internalname, context.GetMessage( "Medical Indication Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMedicalIndicationId_Internalname, A98MedicalIndicationId.ToString(), A98MedicalIndicationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedicalIndicationId_Jsonclick, 0, "Attribute", "", "", "", "", edtMedicalIndicationId_Visible, edtMedicalIndicationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentAddressLine1_Internalname, A357ResidentAddressLine1, StringUtil.RTrim( context.localUtil.Format( A357ResidentAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentAddressLine2_Internalname, A358ResidentAddressLine2, StringUtil.RTrim( context.localUtil.Format( A358ResidentAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentZipCode_Internalname, A356ResidentZipCode, StringUtil.RTrim( context.localUtil.Format( A356ResidentZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "1234 AB", ""), edtResidentZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentCity_Internalname, A355ResidentCity, StringUtil.RTrim( context.localUtil.Format( A355ResidentCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,133);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentCountry_Internalname, A354ResidentCountry, StringUtil.RTrim( context.localUtil.Format( A354ResidentCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentCountry_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentCountry_Visible, edtResidentCountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_networkindividual_Internalname, divTableleaflevel_networkindividual_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_networkindividual( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_networkcompany_Internalname, divTableleaflevel_networkcompany_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_networkcompany( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 183,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 185,'',false,'',0)\"";
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 190,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboresidentphonecode_Internalname, AV39ComboResidentPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV39ComboResidentPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,190);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboresidentphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboresidentphonecode_Visible, edtavComboresidentphonecode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_residenthomephonecode_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 192,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboresidenthomephonecode_Internalname, AV44ComboResidentHomePhoneCode, StringUtil.RTrim( context.localUtil.Format( AV44ComboResidentHomePhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,192);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboresidenthomephonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboresidenthomephonecode_Visible, edtavComboresidenthomephonecode_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_residenttypeid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboresidenttypeid_Internalname, AV32ComboResidentTypeId.ToString(), AV32ComboResidentTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,194);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboresidenttypeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboresidenttypeid_Visible, edtavComboresidenttypeid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_medicalindicationid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombomedicalindicationid_Internalname, AV34ComboMedicalIndicationId.ToString(), AV34ComboMedicalIndicationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,196);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombomedicalindicationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombomedicalindicationid_Visible, edtavCombomedicalindicationid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_residentcountry_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 198,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboresidentcountry_Internalname, AV38ComboResidentCountry, StringUtil.RTrim( context.localUtil.Format( AV38ComboResidentCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,198);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboresidentcountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboresidentcountry_Visible, edtavComboresidentcountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* User Defined Control */
         ucCombo_networkindividualid.SetProperty("Caption", Combo_networkindividualid_Caption);
         ucCombo_networkindividualid.SetProperty("Cls", Combo_networkindividualid_Cls);
         ucCombo_networkindividualid.SetProperty("IsGridItem", Combo_networkindividualid_Isgriditem);
         ucCombo_networkindividualid.SetProperty("HasDescription", Combo_networkindividualid_Hasdescription);
         ucCombo_networkindividualid.SetProperty("DataListProc", Combo_networkindividualid_Datalistproc);
         ucCombo_networkindividualid.SetProperty("DataListProcParametersPrefix", Combo_networkindividualid_Datalistprocparametersprefix);
         ucCombo_networkindividualid.SetProperty("EmptyItem", Combo_networkindividualid_Emptyitem);
         ucCombo_networkindividualid.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_networkindividualid.SetProperty("DropDownOptionsData", AV25NetworkIndividualId_Data);
         ucCombo_networkindividualid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_networkindividualid_Internalname, "COMBO_NETWORKINDIVIDUALIDContainer");
         /* User Defined Control */
         ucCombo_networkcompanyid.SetProperty("Caption", Combo_networkcompanyid_Caption);
         ucCombo_networkcompanyid.SetProperty("Cls", Combo_networkcompanyid_Cls);
         ucCombo_networkcompanyid.SetProperty("IsGridItem", Combo_networkcompanyid_Isgriditem);
         ucCombo_networkcompanyid.SetProperty("HasDescription", Combo_networkcompanyid_Hasdescription);
         ucCombo_networkcompanyid.SetProperty("DataListProc", Combo_networkcompanyid_Datalistproc);
         ucCombo_networkcompanyid.SetProperty("DataListProcParametersPrefix", Combo_networkcompanyid_Datalistprocparametersprefix);
         ucCombo_networkcompanyid.SetProperty("EmptyItem", Combo_networkcompanyid_Emptyitem);
         ucCombo_networkcompanyid.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_networkcompanyid.SetProperty("DropDownOptionsData", AV18NetworkCompanyId_Data);
         ucCombo_networkcompanyid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_networkcompanyid_Internalname, "COMBO_NETWORKCOMPANYIDContainer");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 201,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentId_Internalname, A62ResidentId.ToString(), A62ResidentId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,201);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentId_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentId_Visible, edtResidentId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Resident.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 202,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,202);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationId_Visible, edtLocationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Resident.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 203,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,203);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, edtOrganisationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Resident.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 204,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentInitials_Internalname, StringUtil.RTrim( A66ResidentInitials), StringUtil.RTrim( context.localUtil.Format( A66ResidentInitials, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,204);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentInitials_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentInitials_Visible, edtResidentInitials_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Resident.htm");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A70ResidentPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 205,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentPhone_Internalname, StringUtil.RTrim( A70ResidentPhone), StringUtil.RTrim( context.localUtil.Format( A70ResidentPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,205);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtResidentPhone_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentPhone_Visible, edtResidentPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_Resident.htm");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A444ResidentHomePhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 206,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentHomePhone_Internalname, StringUtil.RTrim( A444ResidentHomePhone), StringUtil.RTrim( context.localUtil.Format( A444ResidentHomePhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,206);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtResidentHomePhone_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentHomePhone_Visible, edtResidentHomePhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_Resident.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 207,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentGUID_Internalname, A71ResidentGUID, StringUtil.RTrim( context.localUtil.Format( A71ResidentGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,207);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentGUID_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentGUID_Visible, edtResidentGUID_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_Trn_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_networkindividual( )
      {
         /*  Grid Control  */
         StartGridControl150( ) ;
         nGXsfl_150_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount23 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_23 = 1;
               ScanStart0923( ) ;
               while ( RcdFound23 != 0 )
               {
                  init_level_properties23( ) ;
                  getByPrimaryKey0923( ) ;
                  AddRow0923( ) ;
                  ScanNext0923( ) ;
               }
               ScanEnd0923( ) ;
               nBlankRcdCount23 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0923( ) ;
            standaloneModal0923( ) ;
            sMode23 = Gx_mode;
            while ( nGXsfl_150_idx < nRC_GXsfl_150 )
            {
               bGXsfl_150_Refreshing = true;
               ReadRow0923( ) ;
               edtNetworkIndividualId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALID_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkIndividualId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualId_Enabled), 5, 0), !bGXsfl_150_Refreshing);
               edtNetworkIndividualGivenName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALGIVENNAME_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkIndividualGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualGivenName_Enabled), 5, 0), !bGXsfl_150_Refreshing);
               edtNetworkIndividualLastName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALLASTNAME_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkIndividualLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualLastName_Enabled), 5, 0), !bGXsfl_150_Refreshing);
               edtNetworkIndividualEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALEMAIL_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkIndividualEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualEmail_Enabled), 5, 0), !bGXsfl_150_Refreshing);
               edtNetworkIndividualPhone_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALPHONE_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkIndividualPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualPhone_Enabled), 5, 0), !bGXsfl_150_Refreshing);
               cmbNetworkIndividualGender.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALGENDER_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbNetworkIndividualGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNetworkIndividualGender.Enabled), 5, 0), !bGXsfl_150_Refreshing);
               edtNetworkIndividualCountry_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALCOUNTRY_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkIndividualCountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualCountry_Enabled), 5, 0), !bGXsfl_150_Refreshing);
               edtNetworkIndividualCity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALCITY_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkIndividualCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualCity_Enabled), 5, 0), !bGXsfl_150_Refreshing);
               edtNetworkIndividualZipCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALZIPCODE_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkIndividualZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualZipCode_Enabled), 5, 0), !bGXsfl_150_Refreshing);
               edtNetworkIndividualAddressLine1_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALADDRESSLINE1_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkIndividualAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualAddressLine1_Enabled), 5, 0), !bGXsfl_150_Refreshing);
               edtNetworkIndividualAddressLine2_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALADDRESSLINE2_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkIndividualAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualAddressLine2_Enabled), 5, 0), !bGXsfl_150_Refreshing);
               if ( ( nRcdExists_23 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0923( ) ;
               }
               SendRow0923( ) ;
               bGXsfl_150_Refreshing = false;
            }
            Gx_mode = sMode23;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount23 = 5;
            nRcdExists_23 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0923( ) ;
               while ( RcdFound23 != 0 )
               {
                  sGXsfl_150_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_150_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_15023( ) ;
                  init_level_properties23( ) ;
                  standaloneNotModal0923( ) ;
                  getByPrimaryKey0923( ) ;
                  standaloneModal0923( ) ;
                  AddRow0923( ) ;
                  ScanNext0923( ) ;
               }
               ScanEnd0923( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode23 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_150_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_150_idx+1), 4, 0), 4, "0");
            SubsflControlProps_15023( ) ;
            InitAll0923( ) ;
            init_level_properties23( ) ;
            nRcdExists_23 = 0;
            nIsMod_23 = 0;
            nRcdDeleted_23 = 0;
            nBlankRcdCount23 = (short)(nBlankRcdUsr23+nBlankRcdCount23);
            fRowAdded = 0;
            while ( nBlankRcdCount23 > 0 )
            {
               standaloneNotModal0923( ) ;
               standaloneModal0923( ) ;
               AddRow0923( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtNetworkIndividualId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount23 = (short)(nBlankRcdCount23-1);
            }
            Gx_mode = sMode23;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_networkindividualContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_networkindividual", Gridlevel_networkindividualContainer, subGridlevel_networkindividual_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_networkindividualContainerData", Gridlevel_networkindividualContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_networkindividualContainerData"+"V", Gridlevel_networkindividualContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_networkindividualContainerData"+"V"+"\" value='"+Gridlevel_networkindividualContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void gxdraw_Gridlevel_networkcompany( )
      {
         /*  Grid Control  */
         StartGridControl167( ) ;
         nGXsfl_167_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount20 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_20 = 1;
               ScanStart0920( ) ;
               while ( RcdFound20 != 0 )
               {
                  init_level_properties20( ) ;
                  getByPrimaryKey0920( ) ;
                  AddRow0920( ) ;
                  ScanNext0920( ) ;
               }
               ScanEnd0920( ) ;
               nBlankRcdCount20 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0920( ) ;
            standaloneModal0920( ) ;
            sMode20 = Gx_mode;
            while ( nGXsfl_167_idx < nRC_GXsfl_167 )
            {
               bGXsfl_167_Refreshing = true;
               ReadRow0920( ) ;
               edtNetworkCompanyId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYID_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyId_Enabled), 5, 0), !bGXsfl_167_Refreshing);
               edtNetworkCompanyKvkNumber_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYKVKNUMBER_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkCompanyKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyKvkNumber_Enabled), 5, 0), !bGXsfl_167_Refreshing);
               edtNetworkCompanyEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYEMAIL_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkCompanyEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyEmail_Enabled), 5, 0), !bGXsfl_167_Refreshing);
               edtNetworkCompanyPhone_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYPHONE_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkCompanyPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyPhone_Enabled), 5, 0), !bGXsfl_167_Refreshing);
               edtNetworkCompanyCountry_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYCOUNTRY_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkCompanyCountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyCountry_Enabled), 5, 0), !bGXsfl_167_Refreshing);
               edtNetworkCompanyCity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYCITY_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkCompanyCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyCity_Enabled), 5, 0), !bGXsfl_167_Refreshing);
               edtNetworkCompanyZipCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYZIPCODE_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkCompanyZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyZipCode_Enabled), 5, 0), !bGXsfl_167_Refreshing);
               edtNetworkCompanyAddressLine1_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYADDRESSLINE1_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkCompanyAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyAddressLine1_Enabled), 5, 0), !bGXsfl_167_Refreshing);
               edtNetworkCompanyAddressLine2_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYADDRESSLINE2_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNetworkCompanyAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyAddressLine2_Enabled), 5, 0), !bGXsfl_167_Refreshing);
               if ( ( nRcdExists_20 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0920( ) ;
               }
               SendRow0920( ) ;
               bGXsfl_167_Refreshing = false;
            }
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount20 = 5;
            nRcdExists_20 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0920( ) ;
               while ( RcdFound20 != 0 )
               {
                  sGXsfl_167_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_167_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_16720( ) ;
                  init_level_properties20( ) ;
                  standaloneNotModal0920( ) ;
                  getByPrimaryKey0920( ) ;
                  standaloneModal0920( ) ;
                  AddRow0920( ) ;
                  ScanNext0920( ) ;
               }
               ScanEnd0920( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode20 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_167_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_167_idx+1), 4, 0), 4, "0");
            SubsflControlProps_16720( ) ;
            InitAll0920( ) ;
            init_level_properties20( ) ;
            nRcdExists_20 = 0;
            nIsMod_20 = 0;
            nRcdDeleted_20 = 0;
            nBlankRcdCount20 = (short)(nBlankRcdUsr20+nBlankRcdCount20);
            fRowAdded = 0;
            while ( nBlankRcdCount20 > 0 )
            {
               standaloneNotModal0920( ) ;
               standaloneModal0920( ) ;
               AddRow0920( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtNetworkCompanyId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount20 = (short)(nBlankRcdCount20-1);
            }
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_networkcompanyContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_networkcompany", Gridlevel_networkcompanyContainer, subGridlevel_networkcompany_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_networkcompanyContainerData", Gridlevel_networkcompanyContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_networkcompanyContainerData"+"V", Gridlevel_networkcompanyContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_networkcompanyContainerData"+"V"+"\" value='"+Gridlevel_networkcompanyContainer.GridValuesHidden()+"'/>") ;
         }
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
               ajax_req_read_hidden_sdt(cgiGet( "vRESIDENTTYPEID_DATA"), AV31ResidentTypeId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vMEDICALINDICATIONID_DATA"), AV33MedicalIndicationId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vRESIDENTCOUNTRY_DATA"), AV37ResidentCountry_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vNETWORKINDIVIDUALID_DATA"), AV25NetworkIndividualId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vNETWORKCOMPANYID_DATA"), AV18NetworkCompanyId_Data);
               /* Read saved values. */
               Z62ResidentId = StringUtil.StrToGuid( cgiGet( "Z62ResidentId"));
               Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               Z354ResidentCountry = cgiGet( "Z354ResidentCountry");
               Z375ResidentPhoneCode = cgiGet( "Z375ResidentPhoneCode");
               Z445ResidentHomePhoneCode = cgiGet( "Z445ResidentHomePhoneCode");
               Z71ResidentGUID = cgiGet( "Z71ResidentGUID");
               Z66ResidentInitials = cgiGet( "Z66ResidentInitials");
               Z70ResidentPhone = cgiGet( "Z70ResidentPhone");
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
               Z444ResidentHomePhone = cgiGet( "Z444ResidentHomePhone");
               Z73ResidentBirthDate = context.localUtil.CToD( cgiGet( "Z73ResidentBirthDate"), 0);
               Z376ResidentPhoneNumber = cgiGet( "Z376ResidentPhoneNumber");
               Z446ResidentHomePhoneNumber = cgiGet( "Z446ResidentHomePhoneNumber");
               Z96ResidentTypeId = StringUtil.StrToGuid( cgiGet( "Z96ResidentTypeId"));
               Z98MedicalIndicationId = StringUtil.StrToGuid( cgiGet( "Z98MedicalIndicationId"));
               n98MedicalIndicationId = ((Guid.Empty==A98MedicalIndicationId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_150 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_150"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               nRC_GXsfl_167 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_167"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N96ResidentTypeId = StringUtil.StrToGuid( cgiGet( "N96ResidentTypeId"));
               N98MedicalIndicationId = StringUtil.StrToGuid( cgiGet( "N98MedicalIndicationId"));
               n98MedicalIndicationId = ((Guid.Empty==A98MedicalIndicationId) ? true : false);
               AV7ResidentId = StringUtil.StrToGuid( cgiGet( "vRESIDENTID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV8LocationId = StringUtil.StrToGuid( cgiGet( "vLOCATIONID"));
               AV9OrganisationId = StringUtil.StrToGuid( cgiGet( "vORGANISATIONID"));
               AV15Insert_ResidentTypeId = StringUtil.StrToGuid( cgiGet( "vINSERT_RESIDENTTYPEID"));
               AV16Insert_MedicalIndicationId = StringUtil.StrToGuid( cgiGet( "vINSERT_MEDICALINDICATIONID"));
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV42AuditingObject);
               AV36GAMErrorResponse = cgiGet( "vGAMERRORRESPONSE");
               A97ResidentTypeName = cgiGet( "RESIDENTTYPENAME");
               A99MedicalIndicationName = cgiGet( "MEDICALINDICATIONNAME");
               AV45Pgmname = cgiGet( "vPGMNAME");
               A75NetworkIndividualBsnNumber = cgiGet( "NETWORKINDIVIDUALBSNNUMBER");
               A388NetworkIndividualPhoneNumber = cgiGet( "NETWORKINDIVIDUALPHONENUMBER");
               A387NetworkIndividualPhoneCode = cgiGet( "NETWORKINDIVIDUALPHONECODE");
               A84NetworkCompanyName = cgiGet( "NETWORKCOMPANYNAME");
               A392NetworkCompanyPhoneNumber = cgiGet( "NETWORKCOMPANYPHONENUMBER");
               A391NetworkCompanyPhoneCode = cgiGet( "NETWORKCOMPANYPHONECODE");
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
               Combo_residenttypeid_Objectcall = cgiGet( "COMBO_RESIDENTTYPEID_Objectcall");
               Combo_residenttypeid_Class = cgiGet( "COMBO_RESIDENTTYPEID_Class");
               Combo_residenttypeid_Icontype = cgiGet( "COMBO_RESIDENTTYPEID_Icontype");
               Combo_residenttypeid_Icon = cgiGet( "COMBO_RESIDENTTYPEID_Icon");
               Combo_residenttypeid_Caption = cgiGet( "COMBO_RESIDENTTYPEID_Caption");
               Combo_residenttypeid_Tooltip = cgiGet( "COMBO_RESIDENTTYPEID_Tooltip");
               Combo_residenttypeid_Cls = cgiGet( "COMBO_RESIDENTTYPEID_Cls");
               Combo_residenttypeid_Selectedvalue_set = cgiGet( "COMBO_RESIDENTTYPEID_Selectedvalue_set");
               Combo_residenttypeid_Selectedvalue_get = cgiGet( "COMBO_RESIDENTTYPEID_Selectedvalue_get");
               Combo_residenttypeid_Selectedtext_set = cgiGet( "COMBO_RESIDENTTYPEID_Selectedtext_set");
               Combo_residenttypeid_Selectedtext_get = cgiGet( "COMBO_RESIDENTTYPEID_Selectedtext_get");
               Combo_residenttypeid_Gamoauthtoken = cgiGet( "COMBO_RESIDENTTYPEID_Gamoauthtoken");
               Combo_residenttypeid_Ddointernalname = cgiGet( "COMBO_RESIDENTTYPEID_Ddointernalname");
               Combo_residenttypeid_Titlecontrolalign = cgiGet( "COMBO_RESIDENTTYPEID_Titlecontrolalign");
               Combo_residenttypeid_Dropdownoptionstype = cgiGet( "COMBO_RESIDENTTYPEID_Dropdownoptionstype");
               Combo_residenttypeid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Enabled"));
               Combo_residenttypeid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Visible"));
               Combo_residenttypeid_Titlecontrolidtoreplace = cgiGet( "COMBO_RESIDENTTYPEID_Titlecontrolidtoreplace");
               Combo_residenttypeid_Datalisttype = cgiGet( "COMBO_RESIDENTTYPEID_Datalisttype");
               Combo_residenttypeid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Allowmultipleselection"));
               Combo_residenttypeid_Datalistfixedvalues = cgiGet( "COMBO_RESIDENTTYPEID_Datalistfixedvalues");
               Combo_residenttypeid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Isgriditem"));
               Combo_residenttypeid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Hasdescription"));
               Combo_residenttypeid_Datalistproc = cgiGet( "COMBO_RESIDENTTYPEID_Datalistproc");
               Combo_residenttypeid_Datalistprocparametersprefix = cgiGet( "COMBO_RESIDENTTYPEID_Datalistprocparametersprefix");
               Combo_residenttypeid_Remoteservicesparameters = cgiGet( "COMBO_RESIDENTTYPEID_Remoteservicesparameters");
               Combo_residenttypeid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_RESIDENTTYPEID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_residenttypeid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Includeonlyselectedoption"));
               Combo_residenttypeid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Includeselectalloption"));
               Combo_residenttypeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Emptyitem"));
               Combo_residenttypeid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Includeaddnewoption"));
               Combo_residenttypeid_Htmltemplate = cgiGet( "COMBO_RESIDENTTYPEID_Htmltemplate");
               Combo_residenttypeid_Multiplevaluestype = cgiGet( "COMBO_RESIDENTTYPEID_Multiplevaluestype");
               Combo_residenttypeid_Loadingdata = cgiGet( "COMBO_RESIDENTTYPEID_Loadingdata");
               Combo_residenttypeid_Noresultsfound = cgiGet( "COMBO_RESIDENTTYPEID_Noresultsfound");
               Combo_residenttypeid_Emptyitemtext = cgiGet( "COMBO_RESIDENTTYPEID_Emptyitemtext");
               Combo_residenttypeid_Onlyselectedvalues = cgiGet( "COMBO_RESIDENTTYPEID_Onlyselectedvalues");
               Combo_residenttypeid_Selectalltext = cgiGet( "COMBO_RESIDENTTYPEID_Selectalltext");
               Combo_residenttypeid_Multiplevaluesseparator = cgiGet( "COMBO_RESIDENTTYPEID_Multiplevaluesseparator");
               Combo_residenttypeid_Addnewoptiontext = cgiGet( "COMBO_RESIDENTTYPEID_Addnewoptiontext");
               Combo_residenttypeid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_RESIDENTTYPEID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_medicalindicationid_Objectcall = cgiGet( "COMBO_MEDICALINDICATIONID_Objectcall");
               Combo_medicalindicationid_Class = cgiGet( "COMBO_MEDICALINDICATIONID_Class");
               Combo_medicalindicationid_Icontype = cgiGet( "COMBO_MEDICALINDICATIONID_Icontype");
               Combo_medicalindicationid_Icon = cgiGet( "COMBO_MEDICALINDICATIONID_Icon");
               Combo_medicalindicationid_Caption = cgiGet( "COMBO_MEDICALINDICATIONID_Caption");
               Combo_medicalindicationid_Tooltip = cgiGet( "COMBO_MEDICALINDICATIONID_Tooltip");
               Combo_medicalindicationid_Cls = cgiGet( "COMBO_MEDICALINDICATIONID_Cls");
               Combo_medicalindicationid_Selectedvalue_set = cgiGet( "COMBO_MEDICALINDICATIONID_Selectedvalue_set");
               Combo_medicalindicationid_Selectedvalue_get = cgiGet( "COMBO_MEDICALINDICATIONID_Selectedvalue_get");
               Combo_medicalindicationid_Selectedtext_set = cgiGet( "COMBO_MEDICALINDICATIONID_Selectedtext_set");
               Combo_medicalindicationid_Selectedtext_get = cgiGet( "COMBO_MEDICALINDICATIONID_Selectedtext_get");
               Combo_medicalindicationid_Gamoauthtoken = cgiGet( "COMBO_MEDICALINDICATIONID_Gamoauthtoken");
               Combo_medicalindicationid_Ddointernalname = cgiGet( "COMBO_MEDICALINDICATIONID_Ddointernalname");
               Combo_medicalindicationid_Titlecontrolalign = cgiGet( "COMBO_MEDICALINDICATIONID_Titlecontrolalign");
               Combo_medicalindicationid_Dropdownoptionstype = cgiGet( "COMBO_MEDICALINDICATIONID_Dropdownoptionstype");
               Combo_medicalindicationid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_MEDICALINDICATIONID_Enabled"));
               Combo_medicalindicationid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_MEDICALINDICATIONID_Visible"));
               Combo_medicalindicationid_Titlecontrolidtoreplace = cgiGet( "COMBO_MEDICALINDICATIONID_Titlecontrolidtoreplace");
               Combo_medicalindicationid_Datalisttype = cgiGet( "COMBO_MEDICALINDICATIONID_Datalisttype");
               Combo_medicalindicationid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_MEDICALINDICATIONID_Allowmultipleselection"));
               Combo_medicalindicationid_Datalistfixedvalues = cgiGet( "COMBO_MEDICALINDICATIONID_Datalistfixedvalues");
               Combo_medicalindicationid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_MEDICALINDICATIONID_Isgriditem"));
               Combo_medicalindicationid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_MEDICALINDICATIONID_Hasdescription"));
               Combo_medicalindicationid_Datalistproc = cgiGet( "COMBO_MEDICALINDICATIONID_Datalistproc");
               Combo_medicalindicationid_Datalistprocparametersprefix = cgiGet( "COMBO_MEDICALINDICATIONID_Datalistprocparametersprefix");
               Combo_medicalindicationid_Remoteservicesparameters = cgiGet( "COMBO_MEDICALINDICATIONID_Remoteservicesparameters");
               Combo_medicalindicationid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_MEDICALINDICATIONID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_medicalindicationid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_MEDICALINDICATIONID_Includeonlyselectedoption"));
               Combo_medicalindicationid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_MEDICALINDICATIONID_Includeselectalloption"));
               Combo_medicalindicationid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_MEDICALINDICATIONID_Emptyitem"));
               Combo_medicalindicationid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_MEDICALINDICATIONID_Includeaddnewoption"));
               Combo_medicalindicationid_Htmltemplate = cgiGet( "COMBO_MEDICALINDICATIONID_Htmltemplate");
               Combo_medicalindicationid_Multiplevaluestype = cgiGet( "COMBO_MEDICALINDICATIONID_Multiplevaluestype");
               Combo_medicalindicationid_Loadingdata = cgiGet( "COMBO_MEDICALINDICATIONID_Loadingdata");
               Combo_medicalindicationid_Noresultsfound = cgiGet( "COMBO_MEDICALINDICATIONID_Noresultsfound");
               Combo_medicalindicationid_Emptyitemtext = cgiGet( "COMBO_MEDICALINDICATIONID_Emptyitemtext");
               Combo_medicalindicationid_Onlyselectedvalues = cgiGet( "COMBO_MEDICALINDICATIONID_Onlyselectedvalues");
               Combo_medicalindicationid_Selectalltext = cgiGet( "COMBO_MEDICALINDICATIONID_Selectalltext");
               Combo_medicalindicationid_Multiplevaluesseparator = cgiGet( "COMBO_MEDICALINDICATIONID_Multiplevaluesseparator");
               Combo_medicalindicationid_Addnewoptiontext = cgiGet( "COMBO_MEDICALINDICATIONID_Addnewoptiontext");
               Combo_medicalindicationid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_MEDICALINDICATIONID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
               Combo_networkindividualid_Objectcall = cgiGet( "COMBO_NETWORKINDIVIDUALID_Objectcall");
               Combo_networkindividualid_Class = cgiGet( "COMBO_NETWORKINDIVIDUALID_Class");
               Combo_networkindividualid_Icontype = cgiGet( "COMBO_NETWORKINDIVIDUALID_Icontype");
               Combo_networkindividualid_Icon = cgiGet( "COMBO_NETWORKINDIVIDUALID_Icon");
               Combo_networkindividualid_Caption = cgiGet( "COMBO_NETWORKINDIVIDUALID_Caption");
               Combo_networkindividualid_Tooltip = cgiGet( "COMBO_NETWORKINDIVIDUALID_Tooltip");
               Combo_networkindividualid_Cls = cgiGet( "COMBO_NETWORKINDIVIDUALID_Cls");
               Combo_networkindividualid_Selectedvalue_set = cgiGet( "COMBO_NETWORKINDIVIDUALID_Selectedvalue_set");
               Combo_networkindividualid_Selectedvalue_get = cgiGet( "COMBO_NETWORKINDIVIDUALID_Selectedvalue_get");
               Combo_networkindividualid_Selectedtext_set = cgiGet( "COMBO_NETWORKINDIVIDUALID_Selectedtext_set");
               Combo_networkindividualid_Selectedtext_get = cgiGet( "COMBO_NETWORKINDIVIDUALID_Selectedtext_get");
               Combo_networkindividualid_Gamoauthtoken = cgiGet( "COMBO_NETWORKINDIVIDUALID_Gamoauthtoken");
               Combo_networkindividualid_Ddointernalname = cgiGet( "COMBO_NETWORKINDIVIDUALID_Ddointernalname");
               Combo_networkindividualid_Titlecontrolalign = cgiGet( "COMBO_NETWORKINDIVIDUALID_Titlecontrolalign");
               Combo_networkindividualid_Dropdownoptionstype = cgiGet( "COMBO_NETWORKINDIVIDUALID_Dropdownoptionstype");
               Combo_networkindividualid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKINDIVIDUALID_Enabled"));
               Combo_networkindividualid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKINDIVIDUALID_Visible"));
               Combo_networkindividualid_Titlecontrolidtoreplace = cgiGet( "COMBO_NETWORKINDIVIDUALID_Titlecontrolidtoreplace");
               Combo_networkindividualid_Datalisttype = cgiGet( "COMBO_NETWORKINDIVIDUALID_Datalisttype");
               Combo_networkindividualid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKINDIVIDUALID_Allowmultipleselection"));
               Combo_networkindividualid_Datalistfixedvalues = cgiGet( "COMBO_NETWORKINDIVIDUALID_Datalistfixedvalues");
               Combo_networkindividualid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKINDIVIDUALID_Isgriditem"));
               Combo_networkindividualid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKINDIVIDUALID_Hasdescription"));
               Combo_networkindividualid_Datalistproc = cgiGet( "COMBO_NETWORKINDIVIDUALID_Datalistproc");
               Combo_networkindividualid_Datalistprocparametersprefix = cgiGet( "COMBO_NETWORKINDIVIDUALID_Datalistprocparametersprefix");
               Combo_networkindividualid_Remoteservicesparameters = cgiGet( "COMBO_NETWORKINDIVIDUALID_Remoteservicesparameters");
               Combo_networkindividualid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NETWORKINDIVIDUALID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_networkindividualid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKINDIVIDUALID_Includeonlyselectedoption"));
               Combo_networkindividualid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKINDIVIDUALID_Includeselectalloption"));
               Combo_networkindividualid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKINDIVIDUALID_Emptyitem"));
               Combo_networkindividualid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKINDIVIDUALID_Includeaddnewoption"));
               Combo_networkindividualid_Htmltemplate = cgiGet( "COMBO_NETWORKINDIVIDUALID_Htmltemplate");
               Combo_networkindividualid_Multiplevaluestype = cgiGet( "COMBO_NETWORKINDIVIDUALID_Multiplevaluestype");
               Combo_networkindividualid_Loadingdata = cgiGet( "COMBO_NETWORKINDIVIDUALID_Loadingdata");
               Combo_networkindividualid_Noresultsfound = cgiGet( "COMBO_NETWORKINDIVIDUALID_Noresultsfound");
               Combo_networkindividualid_Emptyitemtext = cgiGet( "COMBO_NETWORKINDIVIDUALID_Emptyitemtext");
               Combo_networkindividualid_Onlyselectedvalues = cgiGet( "COMBO_NETWORKINDIVIDUALID_Onlyselectedvalues");
               Combo_networkindividualid_Selectalltext = cgiGet( "COMBO_NETWORKINDIVIDUALID_Selectalltext");
               Combo_networkindividualid_Multiplevaluesseparator = cgiGet( "COMBO_NETWORKINDIVIDUALID_Multiplevaluesseparator");
               Combo_networkindividualid_Addnewoptiontext = cgiGet( "COMBO_NETWORKINDIVIDUALID_Addnewoptiontext");
               Combo_networkindividualid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NETWORKINDIVIDUALID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_networkcompanyid_Objectcall = cgiGet( "COMBO_NETWORKCOMPANYID_Objectcall");
               Combo_networkcompanyid_Class = cgiGet( "COMBO_NETWORKCOMPANYID_Class");
               Combo_networkcompanyid_Icontype = cgiGet( "COMBO_NETWORKCOMPANYID_Icontype");
               Combo_networkcompanyid_Icon = cgiGet( "COMBO_NETWORKCOMPANYID_Icon");
               Combo_networkcompanyid_Caption = cgiGet( "COMBO_NETWORKCOMPANYID_Caption");
               Combo_networkcompanyid_Tooltip = cgiGet( "COMBO_NETWORKCOMPANYID_Tooltip");
               Combo_networkcompanyid_Cls = cgiGet( "COMBO_NETWORKCOMPANYID_Cls");
               Combo_networkcompanyid_Selectedvalue_set = cgiGet( "COMBO_NETWORKCOMPANYID_Selectedvalue_set");
               Combo_networkcompanyid_Selectedvalue_get = cgiGet( "COMBO_NETWORKCOMPANYID_Selectedvalue_get");
               Combo_networkcompanyid_Selectedtext_set = cgiGet( "COMBO_NETWORKCOMPANYID_Selectedtext_set");
               Combo_networkcompanyid_Selectedtext_get = cgiGet( "COMBO_NETWORKCOMPANYID_Selectedtext_get");
               Combo_networkcompanyid_Gamoauthtoken = cgiGet( "COMBO_NETWORKCOMPANYID_Gamoauthtoken");
               Combo_networkcompanyid_Ddointernalname = cgiGet( "COMBO_NETWORKCOMPANYID_Ddointernalname");
               Combo_networkcompanyid_Titlecontrolalign = cgiGet( "COMBO_NETWORKCOMPANYID_Titlecontrolalign");
               Combo_networkcompanyid_Dropdownoptionstype = cgiGet( "COMBO_NETWORKCOMPANYID_Dropdownoptionstype");
               Combo_networkcompanyid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKCOMPANYID_Enabled"));
               Combo_networkcompanyid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKCOMPANYID_Visible"));
               Combo_networkcompanyid_Titlecontrolidtoreplace = cgiGet( "COMBO_NETWORKCOMPANYID_Titlecontrolidtoreplace");
               Combo_networkcompanyid_Datalisttype = cgiGet( "COMBO_NETWORKCOMPANYID_Datalisttype");
               Combo_networkcompanyid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKCOMPANYID_Allowmultipleselection"));
               Combo_networkcompanyid_Datalistfixedvalues = cgiGet( "COMBO_NETWORKCOMPANYID_Datalistfixedvalues");
               Combo_networkcompanyid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKCOMPANYID_Isgriditem"));
               Combo_networkcompanyid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKCOMPANYID_Hasdescription"));
               Combo_networkcompanyid_Datalistproc = cgiGet( "COMBO_NETWORKCOMPANYID_Datalistproc");
               Combo_networkcompanyid_Datalistprocparametersprefix = cgiGet( "COMBO_NETWORKCOMPANYID_Datalistprocparametersprefix");
               Combo_networkcompanyid_Remoteservicesparameters = cgiGet( "COMBO_NETWORKCOMPANYID_Remoteservicesparameters");
               Combo_networkcompanyid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NETWORKCOMPANYID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_networkcompanyid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKCOMPANYID_Includeonlyselectedoption"));
               Combo_networkcompanyid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKCOMPANYID_Includeselectalloption"));
               Combo_networkcompanyid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKCOMPANYID_Emptyitem"));
               Combo_networkcompanyid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_NETWORKCOMPANYID_Includeaddnewoption"));
               Combo_networkcompanyid_Htmltemplate = cgiGet( "COMBO_NETWORKCOMPANYID_Htmltemplate");
               Combo_networkcompanyid_Multiplevaluestype = cgiGet( "COMBO_NETWORKCOMPANYID_Multiplevaluestype");
               Combo_networkcompanyid_Loadingdata = cgiGet( "COMBO_NETWORKCOMPANYID_Loadingdata");
               Combo_networkcompanyid_Noresultsfound = cgiGet( "COMBO_NETWORKCOMPANYID_Noresultsfound");
               Combo_networkcompanyid_Emptyitemtext = cgiGet( "COMBO_NETWORKCOMPANYID_Emptyitemtext");
               Combo_networkcompanyid_Onlyselectedvalues = cgiGet( "COMBO_NETWORKCOMPANYID_Onlyselectedvalues");
               Combo_networkcompanyid_Selectalltext = cgiGet( "COMBO_NETWORKCOMPANYID_Selectalltext");
               Combo_networkcompanyid_Multiplevaluesseparator = cgiGet( "COMBO_NETWORKCOMPANYID_Multiplevaluesseparator");
               Combo_networkcompanyid_Addnewoptiontext = cgiGet( "COMBO_NETWORKCOMPANYID_Addnewoptiontext");
               Combo_networkcompanyid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NETWORKCOMPANYID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A63ResidentBsnNumber = cgiGet( edtResidentBsnNumber_Internalname);
               AssignAttri("", false, "A63ResidentBsnNumber", A63ResidentBsnNumber);
               cmbResidentSalutation.Name = cmbResidentSalutation_Internalname;
               cmbResidentSalutation.CurrentValue = cgiGet( cmbResidentSalutation_Internalname);
               A72ResidentSalutation = cgiGet( cmbResidentSalutation_Internalname);
               AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
               A64ResidentGivenName = cgiGet( edtResidentGivenName_Internalname);
               AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
               A65ResidentLastName = cgiGet( edtResidentLastName_Internalname);
               AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
               cmbResidentGender.Name = cmbResidentGender_Internalname;
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
               if ( StringUtil.StrCmp(cgiGet( edtResidentTypeId_Internalname), "") == 0 )
               {
                  A96ResidentTypeId = Guid.Empty;
                  AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
               }
               else
               {
                  try
                  {
                     A96ResidentTypeId = StringUtil.StrToGuid( cgiGet( edtResidentTypeId_Internalname));
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
               AV32ComboResidentTypeId = StringUtil.StrToGuid( cgiGet( edtavComboresidenttypeid_Internalname));
               AssignAttri("", false, "AV32ComboResidentTypeId", AV32ComboResidentTypeId.ToString());
               AV34ComboMedicalIndicationId = StringUtil.StrToGuid( cgiGet( edtavCombomedicalindicationid_Internalname));
               AssignAttri("", false, "AV34ComboMedicalIndicationId", AV34ComboMedicalIndicationId.ToString());
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
               A70ResidentPhone = cgiGet( edtResidentPhone_Internalname);
               AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
               A444ResidentHomePhone = cgiGet( edtResidentHomePhone_Internalname);
               AssignAttri("", false, "A444ResidentHomePhone", A444ResidentHomePhone);
               A71ResidentGUID = cgiGet( edtResidentGUID_Internalname);
               AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Resident");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV45Pgmname, "")));
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
               /* Check if conditions changed and reset current page numbers */
               /* Check if conditions changed and reset current page numbers */
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_RESIDENTTYPEID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_residenttypeid.Onoptionclicked */
                           E12092 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "COMBO_MEDICALINDICATIONID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_medicalindicationid.Onoptionclicked */
                           E13092 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
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
                           E14092 ();
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E14092 ();
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
         AssignProp("", false, edtavComboresidenttypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboresidenttypeid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombomedicalindicationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomedicalindicationid_Enabled), 5, 0), true);
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
            /* Save parent mode. */
            sMode16 = Gx_mode;
            CONFIRM_0923( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_0920( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode16;
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  IsConfirmed = 1;
                  AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0920( )
      {
         nGXsfl_167_idx = 0;
         while ( nGXsfl_167_idx < nRC_GXsfl_167 )
         {
            ReadRow0920( ) ;
            if ( ( nRcdExists_20 != 0 ) || ( nIsMod_20 != 0 ) )
            {
               GetKey0920( ) ;
               if ( ( nRcdExists_20 == 0 ) && ( nRcdDeleted_20 == 0 ) )
               {
                  if ( RcdFound20 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0920( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0920( ) ;
                        CloseExtendedTableCursors0920( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "NETWORKCOMPANYID_" + sGXsfl_167_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtNetworkCompanyId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound20 != 0 )
                  {
                     if ( nRcdDeleted_20 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0920( ) ;
                        Load0920( ) ;
                        BeforeValidate0920( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0920( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_20 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0920( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0920( ) ;
                              CloseExtendedTableCursors0920( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_20 == 0 )
                     {
                        GXCCtl = "NETWORKCOMPANYID_" + sGXsfl_167_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtNetworkCompanyId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtNetworkCompanyId_Internalname, A82NetworkCompanyId.ToString()) ;
            ChangePostValue( edtNetworkCompanyKvkNumber_Internalname, A83NetworkCompanyKvkNumber) ;
            ChangePostValue( edtNetworkCompanyEmail_Internalname, A85NetworkCompanyEmail) ;
            ChangePostValue( edtNetworkCompanyPhone_Internalname, StringUtil.RTrim( A86NetworkCompanyPhone)) ;
            ChangePostValue( edtNetworkCompanyCountry_Internalname, A349NetworkCompanyCountry) ;
            ChangePostValue( edtNetworkCompanyCity_Internalname, A350NetworkCompanyCity) ;
            ChangePostValue( edtNetworkCompanyZipCode_Internalname, A351NetworkCompanyZipCode) ;
            ChangePostValue( edtNetworkCompanyAddressLine1_Internalname, A352NetworkCompanyAddressLine1) ;
            ChangePostValue( edtNetworkCompanyAddressLine2_Internalname, A353NetworkCompanyAddressLine2) ;
            ChangePostValue( "ZT_"+"Z82NetworkCompanyId_"+sGXsfl_167_idx, Z82NetworkCompanyId.ToString()) ;
            ChangePostValue( "nRcdDeleted_20_"+sGXsfl_167_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_20), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_20_"+sGXsfl_167_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_20), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_20_"+sGXsfl_167_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_20), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_20 != 0 )
            {
               ChangePostValue( "NETWORKCOMPANYID_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKCOMPANYKVKNUMBER_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyKvkNumber_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKCOMPANYEMAIL_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKCOMPANYPHONE_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyPhone_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKCOMPANYCOUNTRY_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyCountry_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKCOMPANYCITY_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyCity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKCOMPANYZIPCODE_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyZipCode_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKCOMPANYADDRESSLINE1_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyAddressLine1_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKCOMPANYADDRESSLINE2_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyAddressLine2_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0923( )
      {
         nGXsfl_150_idx = 0;
         while ( nGXsfl_150_idx < nRC_GXsfl_150 )
         {
            ReadRow0923( ) ;
            if ( ( nRcdExists_23 != 0 ) || ( nIsMod_23 != 0 ) )
            {
               GetKey0923( ) ;
               if ( ( nRcdExists_23 == 0 ) && ( nRcdDeleted_23 == 0 ) )
               {
                  if ( RcdFound23 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0923( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0923( ) ;
                        CloseExtendedTableCursors0923( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "NETWORKINDIVIDUALID_" + sGXsfl_150_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtNetworkIndividualId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound23 != 0 )
                  {
                     if ( nRcdDeleted_23 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0923( ) ;
                        Load0923( ) ;
                        BeforeValidate0923( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0923( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_23 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0923( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0923( ) ;
                              CloseExtendedTableCursors0923( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_23 == 0 )
                     {
                        GXCCtl = "NETWORKINDIVIDUALID_" + sGXsfl_150_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtNetworkIndividualId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtNetworkIndividualId_Internalname, A74NetworkIndividualId.ToString()) ;
            ChangePostValue( edtNetworkIndividualGivenName_Internalname, A76NetworkIndividualGivenName) ;
            ChangePostValue( edtNetworkIndividualLastName_Internalname, A77NetworkIndividualLastName) ;
            ChangePostValue( edtNetworkIndividualEmail_Internalname, A78NetworkIndividualEmail) ;
            ChangePostValue( edtNetworkIndividualPhone_Internalname, StringUtil.RTrim( A79NetworkIndividualPhone)) ;
            ChangePostValue( cmbNetworkIndividualGender_Internalname, A81NetworkIndividualGender) ;
            ChangePostValue( edtNetworkIndividualCountry_Internalname, A344NetworkIndividualCountry) ;
            ChangePostValue( edtNetworkIndividualCity_Internalname, A345NetworkIndividualCity) ;
            ChangePostValue( edtNetworkIndividualZipCode_Internalname, A346NetworkIndividualZipCode) ;
            ChangePostValue( edtNetworkIndividualAddressLine1_Internalname, A347NetworkIndividualAddressLine1) ;
            ChangePostValue( edtNetworkIndividualAddressLine2_Internalname, A348NetworkIndividualAddressLine2) ;
            ChangePostValue( "ZT_"+"Z74NetworkIndividualId_"+sGXsfl_150_idx, Z74NetworkIndividualId.ToString()) ;
            ChangePostValue( "nRcdDeleted_23_"+sGXsfl_150_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_23), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_23_"+sGXsfl_150_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_23), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_23_"+sGXsfl_150_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_23), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_23 != 0 )
            {
               ChangePostValue( "NETWORKINDIVIDUALID_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALGIVENNAME_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualGivenName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALLASTNAME_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualLastName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALEMAIL_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALPHONE_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualPhone_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALGENDER_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbNetworkIndividualGender.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALCOUNTRY_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualCountry_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALCITY_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualCity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALZIPCODE_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualZipCode_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALADDRESSLINE1_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualAddressLine1_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALADDRESSLINE2_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualAddressLine2_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
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
         AV23GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV24GAMErrors);
         Combo_networkcompanyid_Gamoauthtoken = AV23GAMSession.gxTpr_Token;
         ucCombo_networkcompanyid.SendProperty(context, "", false, Combo_networkcompanyid_Internalname, "GAMOAuthToken", Combo_networkcompanyid_Gamoauthtoken);
         Combo_networkcompanyid_Titlecontrolidtoreplace = edtNetworkCompanyId_Internalname;
         ucCombo_networkcompanyid.SendProperty(context, "", false, Combo_networkcompanyid_Internalname, "TitleControlIdToReplace", Combo_networkcompanyid_Titlecontrolidtoreplace);
         Combo_networkindividualid_Gamoauthtoken = AV23GAMSession.gxTpr_Token;
         ucCombo_networkindividualid.SendProperty(context, "", false, Combo_networkindividualid_Internalname, "GAMOAuthToken", Combo_networkindividualid_Gamoauthtoken);
         Combo_networkindividualid_Titlecontrolidtoreplace = edtNetworkIndividualId_Internalname;
         ucCombo_networkindividualid.SendProperty(context, "", false, Combo_networkindividualid_Internalname, "TitleControlIdToReplace", Combo_networkindividualid_Titlecontrolidtoreplace);
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
         Combo_medicalindicationid_Gamoauthtoken = AV23GAMSession.gxTpr_Token;
         ucCombo_medicalindicationid.SendProperty(context, "", false, Combo_medicalindicationid_Internalname, "GAMOAuthToken", Combo_medicalindicationid_Gamoauthtoken);
         edtMedicalIndicationId_Visible = 0;
         AssignProp("", false, edtMedicalIndicationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMedicalIndicationId_Visible), 5, 0), true);
         AV34ComboMedicalIndicationId = Guid.Empty;
         AssignAttri("", false, "AV34ComboMedicalIndicationId", AV34ComboMedicalIndicationId.ToString());
         edtavCombomedicalindicationid_Visible = 0;
         AssignProp("", false, edtavCombomedicalindicationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombomedicalindicationid_Visible), 5, 0), true);
         Combo_residenttypeid_Gamoauthtoken = AV23GAMSession.gxTpr_Token;
         ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "GAMOAuthToken", Combo_residenttypeid_Gamoauthtoken);
         edtResidentTypeId_Visible = 0;
         AssignProp("", false, edtResidentTypeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentTypeId_Visible), 5, 0), true);
         AV32ComboResidentTypeId = Guid.Empty;
         AssignAttri("", false, "AV32ComboResidentTypeId", AV32ComboResidentTypeId.ToString());
         edtavComboresidenttypeid_Visible = 0;
         AssignProp("", false, edtavComboresidenttypeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboresidenttypeid_Visible), 5, 0), true);
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
         /* Execute user subroutine: 'LOADCOMBORESIDENTTYPEID' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOMEDICALINDICATIONID' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBORESIDENTCOUNTRY' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV13TrnContext.FromXml(AV14WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV13TrnContext.gxTpr_Transactionname, AV45Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV46GXV1 = 1;
            AssignAttri("", false, "AV46GXV1", StringUtil.LTrimStr( (decimal)(AV46GXV1), 8, 0));
            while ( AV46GXV1 <= AV13TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV13TrnContext.gxTpr_Attributes.Item(AV46GXV1));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "ResidentTypeId") == 0 )
               {
                  AV15Insert_ResidentTypeId = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV15Insert_ResidentTypeId", AV15Insert_ResidentTypeId.ToString());
                  if ( ! (Guid.Empty==AV15Insert_ResidentTypeId) )
                  {
                     AV32ComboResidentTypeId = AV15Insert_ResidentTypeId;
                     AssignAttri("", false, "AV32ComboResidentTypeId", AV32ComboResidentTypeId.ToString());
                     Combo_residenttypeid_Selectedvalue_set = StringUtil.Trim( AV32ComboResidentTypeId.ToString());
                     ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "SelectedValue_set", Combo_residenttypeid_Selectedvalue_set);
                     GXt_char2 = AV22Combo_DataJson;
                     new trn_residentloaddvcombo(context ).execute(  "ResidentTypeId",  "GET",  false,  AV7ResidentId,  AV8LocationId,  AV9OrganisationId,  AV17TrnContextAtt.gxTpr_Attributevalue, out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
                     AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
                     AV22Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
                     Combo_residenttypeid_Selectedtext_set = AV21ComboSelectedText;
                     ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "SelectedText_set", Combo_residenttypeid_Selectedtext_set);
                     Combo_residenttypeid_Enabled = false;
                     ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_residenttypeid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "MedicalIndicationId") == 0 )
               {
                  AV16Insert_MedicalIndicationId = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV16Insert_MedicalIndicationId", AV16Insert_MedicalIndicationId.ToString());
                  if ( ! (Guid.Empty==AV16Insert_MedicalIndicationId) )
                  {
                     AV34ComboMedicalIndicationId = AV16Insert_MedicalIndicationId;
                     AssignAttri("", false, "AV34ComboMedicalIndicationId", AV34ComboMedicalIndicationId.ToString());
                     Combo_medicalindicationid_Selectedvalue_set = StringUtil.Trim( AV34ComboMedicalIndicationId.ToString());
                     ucCombo_medicalindicationid.SendProperty(context, "", false, Combo_medicalindicationid_Internalname, "SelectedValue_set", Combo_medicalindicationid_Selectedvalue_set);
                     GXt_char2 = AV22Combo_DataJson;
                     new trn_residentloaddvcombo(context ).execute(  "MedicalIndicationId",  "GET",  false,  AV7ResidentId,  AV8LocationId,  AV9OrganisationId,  AV17TrnContextAtt.gxTpr_Attributevalue, out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
                     AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
                     AV22Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
                     Combo_medicalindicationid_Selectedtext_set = AV21ComboSelectedText;
                     ucCombo_medicalindicationid.SendProperty(context, "", false, Combo_medicalindicationid_Internalname, "SelectedText_set", Combo_medicalindicationid_Selectedtext_set);
                     Combo_medicalindicationid_Enabled = false;
                     ucCombo_medicalindicationid.SendProperty(context, "", false, Combo_medicalindicationid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_medicalindicationid_Enabled));
                  }
               }
               AV46GXV1 = (int)(AV46GXV1+1);
               AssignAttri("", false, "AV46GXV1", StringUtil.LTrimStr( (decimal)(AV46GXV1), 8, 0));
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
         edtResidentPhone_Visible = 0;
         AssignProp("", false, edtResidentPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentPhone_Visible), 5, 0), true);
         edtResidentHomePhone_Visible = 0;
         AssignProp("", false, edtResidentHomePhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentHomePhone_Visible), 5, 0), true);
         edtResidentGUID_Visible = 0;
         AssignProp("", false, edtResidentGUID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentGUID_Visible), 5, 0), true);
      }

      protected void E14092( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV42AuditingObject,  AV45Pgmname) ;
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

      protected void S162( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void E13092( )
      {
         /* Combo_medicalindicationid_Onoptionclicked Routine */
         returnInSub = false;
         AV34ComboMedicalIndicationId = StringUtil.StrToGuid( Combo_medicalindicationid_Selectedvalue_get);
         AssignAttri("", false, "AV34ComboMedicalIndicationId", AV34ComboMedicalIndicationId.ToString());
         /*  Sending Event outputs  */
      }

      protected void E12092( )
      {
         /* Combo_residenttypeid_Onoptionclicked Routine */
         returnInSub = false;
         AV32ComboResidentTypeId = StringUtil.StrToGuid( Combo_residenttypeid_Selectedvalue_get);
         AssignAttri("", false, "AV32ComboResidentTypeId", AV32ComboResidentTypeId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'LOADCOMBORESIDENTCOUNTRY' Routine */
         returnInSub = false;
         GXt_char2 = AV22Combo_DataJson;
         new trn_residentloaddvcombo(context ).execute(  "ResidentCountry",  Gx_mode,  false,  AV7ResidentId,  AV8LocationId,  AV9OrganisationId,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         AV37ResidentCountry_Data.FromJSonString(AV22Combo_DataJson, null);
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

      protected void S142( )
      {
         /* 'LOADCOMBOMEDICALINDICATIONID' Routine */
         returnInSub = false;
         GXt_char2 = AV22Combo_DataJson;
         new trn_residentloaddvcombo(context ).execute(  "MedicalIndicationId",  Gx_mode,  false,  AV7ResidentId,  AV8LocationId,  AV9OrganisationId,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         Combo_medicalindicationid_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_medicalindicationid.SendProperty(context, "", false, Combo_medicalindicationid_Internalname, "SelectedValue_set", Combo_medicalindicationid_Selectedvalue_set);
         Combo_medicalindicationid_Selectedtext_set = AV21ComboSelectedText;
         ucCombo_medicalindicationid.SendProperty(context, "", false, Combo_medicalindicationid_Internalname, "SelectedText_set", Combo_medicalindicationid_Selectedtext_set);
         AV34ComboMedicalIndicationId = StringUtil.StrToGuid( AV20ComboSelectedValue);
         AssignAttri("", false, "AV34ComboMedicalIndicationId", AV34ComboMedicalIndicationId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_medicalindicationid_Enabled = false;
            ucCombo_medicalindicationid.SendProperty(context, "", false, Combo_medicalindicationid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_medicalindicationid_Enabled));
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBORESIDENTTYPEID' Routine */
         returnInSub = false;
         GXt_char2 = AV22Combo_DataJson;
         new trn_residentloaddvcombo(context ).execute(  "ResidentTypeId",  Gx_mode,  false,  AV7ResidentId,  AV8LocationId,  AV9OrganisationId,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         Combo_residenttypeid_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "SelectedValue_set", Combo_residenttypeid_Selectedvalue_set);
         Combo_residenttypeid_Selectedtext_set = AV21ComboSelectedText;
         ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "SelectedText_set", Combo_residenttypeid_Selectedtext_set);
         AV32ComboResidentTypeId = StringUtil.StrToGuid( AV20ComboSelectedValue);
         AssignAttri("", false, "AV32ComboResidentTypeId", AV32ComboResidentTypeId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_residenttypeid_Enabled = false;
            ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_residenttypeid_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBORESIDENTHOMEPHONECODE' Routine */
         returnInSub = false;
         GXt_char2 = AV22Combo_DataJson;
         new trn_residentloaddvcombo(context ).execute(  "ResidentHomePhoneCode",  Gx_mode,  false,  AV7ResidentId,  AV8LocationId,  AV9OrganisationId,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         AV43ResidentHomePhoneCode_Data.FromJSonString(AV22Combo_DataJson, null);
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
         GXt_char2 = AV22Combo_DataJson;
         new trn_residentloaddvcombo(context ).execute(  "ResidentPhoneCode",  Gx_mode,  false,  AV7ResidentId,  AV8LocationId,  AV9OrganisationId,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         AV41ResidentPhoneCode_Data.FromJSonString(AV22Combo_DataJson, null);
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
         if ( ( GX_JID == 50 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z354ResidentCountry = T00099_A354ResidentCountry[0];
               Z375ResidentPhoneCode = T00099_A375ResidentPhoneCode[0];
               Z445ResidentHomePhoneCode = T00099_A445ResidentHomePhoneCode[0];
               Z71ResidentGUID = T00099_A71ResidentGUID[0];
               Z66ResidentInitials = T00099_A66ResidentInitials[0];
               Z70ResidentPhone = T00099_A70ResidentPhone[0];
               Z72ResidentSalutation = T00099_A72ResidentSalutation[0];
               Z63ResidentBsnNumber = T00099_A63ResidentBsnNumber[0];
               Z64ResidentGivenName = T00099_A64ResidentGivenName[0];
               Z65ResidentLastName = T00099_A65ResidentLastName[0];
               Z67ResidentEmail = T00099_A67ResidentEmail[0];
               Z68ResidentGender = T00099_A68ResidentGender[0];
               Z355ResidentCity = T00099_A355ResidentCity[0];
               Z356ResidentZipCode = T00099_A356ResidentZipCode[0];
               Z357ResidentAddressLine1 = T00099_A357ResidentAddressLine1[0];
               Z358ResidentAddressLine2 = T00099_A358ResidentAddressLine2[0];
               Z444ResidentHomePhone = T00099_A444ResidentHomePhone[0];
               Z73ResidentBirthDate = T00099_A73ResidentBirthDate[0];
               Z376ResidentPhoneNumber = T00099_A376ResidentPhoneNumber[0];
               Z446ResidentHomePhoneNumber = T00099_A446ResidentHomePhoneNumber[0];
               Z96ResidentTypeId = T00099_A96ResidentTypeId[0];
               Z98MedicalIndicationId = T00099_A98MedicalIndicationId[0];
            }
            else
            {
               Z354ResidentCountry = A354ResidentCountry;
               Z375ResidentPhoneCode = A375ResidentPhoneCode;
               Z445ResidentHomePhoneCode = A445ResidentHomePhoneCode;
               Z71ResidentGUID = A71ResidentGUID;
               Z66ResidentInitials = A66ResidentInitials;
               Z70ResidentPhone = A70ResidentPhone;
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
               Z444ResidentHomePhone = A444ResidentHomePhone;
               Z73ResidentBirthDate = A73ResidentBirthDate;
               Z376ResidentPhoneNumber = A376ResidentPhoneNumber;
               Z446ResidentHomePhoneNumber = A446ResidentHomePhoneNumber;
               Z96ResidentTypeId = A96ResidentTypeId;
               Z98MedicalIndicationId = A98MedicalIndicationId;
            }
         }
         if ( GX_JID == -50 )
         {
            Z62ResidentId = A62ResidentId;
            Z354ResidentCountry = A354ResidentCountry;
            Z375ResidentPhoneCode = A375ResidentPhoneCode;
            Z445ResidentHomePhoneCode = A445ResidentHomePhoneCode;
            Z71ResidentGUID = A71ResidentGUID;
            Z66ResidentInitials = A66ResidentInitials;
            Z70ResidentPhone = A70ResidentPhone;
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
            Z444ResidentHomePhone = A444ResidentHomePhone;
            Z73ResidentBirthDate = A73ResidentBirthDate;
            Z376ResidentPhoneNumber = A376ResidentPhoneNumber;
            Z446ResidentHomePhoneNumber = A446ResidentHomePhoneNumber;
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
         divTableleaflevel_networkindividual_Visible = (((1==0)) ? 1 : 0);
         AssignProp("", false, divTableleaflevel_networkindividual_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableleaflevel_networkindividual_Visible), 5, 0), true);
         divTableleaflevel_networkcompany_Visible = (((1==0)) ? 1 : 0);
         AssignProp("", false, divTableleaflevel_networkcompany_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableleaflevel_networkcompany_Visible), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV45Pgmname = "Trn_Resident";
         AssignAttri("", false, "AV45Pgmname", AV45Pgmname);
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
         else
         {
            GXt_guid3 = A29LocationId;
            new prc_getuserlocationid(context ).execute( out  GXt_guid3) ;
            A29LocationId = GXt_guid3;
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
         else
         {
            GXt_guid3 = A11OrganisationId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid3) ;
            A11OrganisationId = GXt_guid3;
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
         A375ResidentPhoneCode = AV39ComboResidentPhoneCode;
         AssignAttri("", false, "A375ResidentPhoneCode", A375ResidentPhoneCode);
         A445ResidentHomePhoneCode = AV44ComboResidentHomePhoneCode;
         AssignAttri("", false, "A445ResidentHomePhoneCode", A445ResidentHomePhoneCode);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV15Insert_ResidentTypeId) )
         {
            A96ResidentTypeId = AV15Insert_ResidentTypeId;
            AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
         }
         else
         {
            A96ResidentTypeId = AV32ComboResidentTypeId;
            AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV16Insert_MedicalIndicationId) )
         {
            A98MedicalIndicationId = AV16Insert_MedicalIndicationId;
            n98MedicalIndicationId = false;
            AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
         }
         else
         {
            if ( (Guid.Empty==AV34ComboMedicalIndicationId) )
            {
               A98MedicalIndicationId = Guid.Empty;
               n98MedicalIndicationId = false;
               AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
               n98MedicalIndicationId = true;
               AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
            }
            else
            {
               if ( ! (Guid.Empty==AV34ComboMedicalIndicationId) )
               {
                  A98MedicalIndicationId = AV34ComboMedicalIndicationId;
                  n98MedicalIndicationId = false;
                  AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
               }
            }
         }
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
            /* Using cursor T000911 */
            pr_default.execute(9, new Object[] {A96ResidentTypeId});
            A97ResidentTypeName = T000911_A97ResidentTypeName[0];
            pr_default.close(9);
            /* Using cursor T000912 */
            pr_default.execute(10, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
            A99MedicalIndicationName = T000912_A99MedicalIndicationName[0];
            pr_default.close(10);
         }
      }

      protected void Load0916( )
      {
         /* Using cursor T000913 */
         pr_default.execute(11, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound16 = 1;
            A354ResidentCountry = T000913_A354ResidentCountry[0];
            AssignAttri("", false, "A354ResidentCountry", A354ResidentCountry);
            A375ResidentPhoneCode = T000913_A375ResidentPhoneCode[0];
            AssignAttri("", false, "A375ResidentPhoneCode", A375ResidentPhoneCode);
            A445ResidentHomePhoneCode = T000913_A445ResidentHomePhoneCode[0];
            AssignAttri("", false, "A445ResidentHomePhoneCode", A445ResidentHomePhoneCode);
            A71ResidentGUID = T000913_A71ResidentGUID[0];
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
            A66ResidentInitials = T000913_A66ResidentInitials[0];
            AssignAttri("", false, "A66ResidentInitials", A66ResidentInitials);
            A70ResidentPhone = T000913_A70ResidentPhone[0];
            AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
            A72ResidentSalutation = T000913_A72ResidentSalutation[0];
            AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
            A63ResidentBsnNumber = T000913_A63ResidentBsnNumber[0];
            AssignAttri("", false, "A63ResidentBsnNumber", A63ResidentBsnNumber);
            A64ResidentGivenName = T000913_A64ResidentGivenName[0];
            AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = T000913_A65ResidentLastName[0];
            AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
            A67ResidentEmail = T000913_A67ResidentEmail[0];
            AssignAttri("", false, "A67ResidentEmail", A67ResidentEmail);
            A68ResidentGender = T000913_A68ResidentGender[0];
            AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
            A355ResidentCity = T000913_A355ResidentCity[0];
            AssignAttri("", false, "A355ResidentCity", A355ResidentCity);
            A356ResidentZipCode = T000913_A356ResidentZipCode[0];
            AssignAttri("", false, "A356ResidentZipCode", A356ResidentZipCode);
            A357ResidentAddressLine1 = T000913_A357ResidentAddressLine1[0];
            AssignAttri("", false, "A357ResidentAddressLine1", A357ResidentAddressLine1);
            A358ResidentAddressLine2 = T000913_A358ResidentAddressLine2[0];
            AssignAttri("", false, "A358ResidentAddressLine2", A358ResidentAddressLine2);
            A444ResidentHomePhone = T000913_A444ResidentHomePhone[0];
            AssignAttri("", false, "A444ResidentHomePhone", A444ResidentHomePhone);
            A73ResidentBirthDate = T000913_A73ResidentBirthDate[0];
            AssignAttri("", false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
            A97ResidentTypeName = T000913_A97ResidentTypeName[0];
            A99MedicalIndicationName = T000913_A99MedicalIndicationName[0];
            A376ResidentPhoneNumber = T000913_A376ResidentPhoneNumber[0];
            AssignAttri("", false, "A376ResidentPhoneNumber", A376ResidentPhoneNumber);
            A446ResidentHomePhoneNumber = T000913_A446ResidentHomePhoneNumber[0];
            AssignAttri("", false, "A446ResidentHomePhoneNumber", A446ResidentHomePhoneNumber);
            A96ResidentTypeId = T000913_A96ResidentTypeId[0];
            AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
            A98MedicalIndicationId = T000913_A98MedicalIndicationId[0];
            n98MedicalIndicationId = T000913_n98MedicalIndicationId[0];
            AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
            ZM0916( -50) ;
         }
         pr_default.close(11);
         OnLoadActions0916( ) ;
      }

      protected void OnLoadActions0916( )
      {
         GXt_char2 = A70ResidentPhone;
         new prc_concatenateintlphone(context ).execute(  A375ResidentPhoneCode,  A376ResidentPhoneNumber, out  GXt_char2) ;
         A70ResidentPhone = GXt_char2;
         AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
      }

      protected void CheckExtendedTable0916( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000910 */
         pr_default.execute(8, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(8);
         if ( ! ( ( StringUtil.StrCmp(A72ResidentSalutation, "Mr") == 0 ) || ( StringUtil.StrCmp(A72ResidentSalutation, "Mrs") == 0 ) || ( StringUtil.StrCmp(A72ResidentSalutation, "Dr") == 0 ) || ( StringUtil.StrCmp(A72ResidentSalutation, "Miss") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Resident Salutation", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "RESIDENTSALUTATION");
            AnyError = 1;
            GX_FocusControl = cmbResidentSalutation_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( StringUtil.Len( A63ResidentBsnNumber) != 9 )
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
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Resident Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "RESIDENTEMAIL");
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
         /* Using cursor T000911 */
         pr_default.execute(9, new Object[] {A96ResidentTypeId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
            AnyError = 1;
            GX_FocusControl = edtResidentTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A97ResidentTypeName = T000911_A97ResidentTypeName[0];
         pr_default.close(9);
         /* Using cursor T000912 */
         pr_default.execute(10, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Medical Indication", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
               AnyError = 1;
               GX_FocusControl = edtMedicalIndicationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A99MedicalIndicationName = T000912_A99MedicalIndicationName[0];
         pr_default.close(10);
         GXt_char2 = A70ResidentPhone;
         new prc_concatenateintlphone(context ).execute(  A375ResidentPhoneCode,  A376ResidentPhoneNumber, out  GXt_char2) ;
         A70ResidentPhone = GXt_char2;
         AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A376ResidentPhoneNumber)) && ! GxRegex.IsMatch(A376ResidentPhoneNumber,context.GetMessage( "\\b\\d{9}\\b", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "RESIDENTPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtResidentPhoneNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A446ResidentHomePhoneNumber)) && ! GxRegex.IsMatch(A446ResidentHomePhoneNumber,context.GetMessage( "\\b\\d{9}\\b", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "RESIDENTHOMEPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtResidentHomePhoneNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0916( )
      {
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(10);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_51( Guid A29LocationId ,
                                Guid A11OrganisationId )
      {
         /* Using cursor T000914 */
         pr_default.execute(12, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_52( Guid A96ResidentTypeId )
      {
         /* Using cursor T000915 */
         pr_default.execute(13, new Object[] {A96ResidentTypeId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
            AnyError = 1;
            GX_FocusControl = edtResidentTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A97ResidentTypeName = T000915_A97ResidentTypeName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A97ResidentTypeName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_53( Guid A98MedicalIndicationId )
      {
         /* Using cursor T000916 */
         pr_default.execute(14, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Medical Indication", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
               AnyError = 1;
               GX_FocusControl = edtMedicalIndicationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A99MedicalIndicationName = T000916_A99MedicalIndicationName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A99MedicalIndicationName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey0916( )
      {
         /* Using cursor T000917 */
         pr_default.execute(15, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00099 */
         pr_default.execute(7, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            ZM0916( 50) ;
            RcdFound16 = 1;
            A62ResidentId = T00099_A62ResidentId[0];
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
            A354ResidentCountry = T00099_A354ResidentCountry[0];
            AssignAttri("", false, "A354ResidentCountry", A354ResidentCountry);
            A375ResidentPhoneCode = T00099_A375ResidentPhoneCode[0];
            AssignAttri("", false, "A375ResidentPhoneCode", A375ResidentPhoneCode);
            A445ResidentHomePhoneCode = T00099_A445ResidentHomePhoneCode[0];
            AssignAttri("", false, "A445ResidentHomePhoneCode", A445ResidentHomePhoneCode);
            A71ResidentGUID = T00099_A71ResidentGUID[0];
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
            A66ResidentInitials = T00099_A66ResidentInitials[0];
            AssignAttri("", false, "A66ResidentInitials", A66ResidentInitials);
            A70ResidentPhone = T00099_A70ResidentPhone[0];
            AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
            A72ResidentSalutation = T00099_A72ResidentSalutation[0];
            AssignAttri("", false, "A72ResidentSalutation", A72ResidentSalutation);
            A63ResidentBsnNumber = T00099_A63ResidentBsnNumber[0];
            AssignAttri("", false, "A63ResidentBsnNumber", A63ResidentBsnNumber);
            A64ResidentGivenName = T00099_A64ResidentGivenName[0];
            AssignAttri("", false, "A64ResidentGivenName", A64ResidentGivenName);
            A65ResidentLastName = T00099_A65ResidentLastName[0];
            AssignAttri("", false, "A65ResidentLastName", A65ResidentLastName);
            A67ResidentEmail = T00099_A67ResidentEmail[0];
            AssignAttri("", false, "A67ResidentEmail", A67ResidentEmail);
            A68ResidentGender = T00099_A68ResidentGender[0];
            AssignAttri("", false, "A68ResidentGender", A68ResidentGender);
            A355ResidentCity = T00099_A355ResidentCity[0];
            AssignAttri("", false, "A355ResidentCity", A355ResidentCity);
            A356ResidentZipCode = T00099_A356ResidentZipCode[0];
            AssignAttri("", false, "A356ResidentZipCode", A356ResidentZipCode);
            A357ResidentAddressLine1 = T00099_A357ResidentAddressLine1[0];
            AssignAttri("", false, "A357ResidentAddressLine1", A357ResidentAddressLine1);
            A358ResidentAddressLine2 = T00099_A358ResidentAddressLine2[0];
            AssignAttri("", false, "A358ResidentAddressLine2", A358ResidentAddressLine2);
            A444ResidentHomePhone = T00099_A444ResidentHomePhone[0];
            AssignAttri("", false, "A444ResidentHomePhone", A444ResidentHomePhone);
            A73ResidentBirthDate = T00099_A73ResidentBirthDate[0];
            AssignAttri("", false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
            A376ResidentPhoneNumber = T00099_A376ResidentPhoneNumber[0];
            AssignAttri("", false, "A376ResidentPhoneNumber", A376ResidentPhoneNumber);
            A446ResidentHomePhoneNumber = T00099_A446ResidentHomePhoneNumber[0];
            AssignAttri("", false, "A446ResidentHomePhoneNumber", A446ResidentHomePhoneNumber);
            A29LocationId = T00099_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T00099_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A96ResidentTypeId = T00099_A96ResidentTypeId[0];
            AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
            A98MedicalIndicationId = T00099_A98MedicalIndicationId[0];
            n98MedicalIndicationId = T00099_n98MedicalIndicationId[0];
            AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
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
         pr_default.close(7);
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
         /* Using cursor T000918 */
         pr_default.execute(16, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( GuidUtil.Compare(T000918_A62ResidentId[0], A62ResidentId, 0) < 0 ) || ( T000918_A62ResidentId[0] == A62ResidentId ) && ( GuidUtil.Compare(T000918_A29LocationId[0], A29LocationId, 0) < 0 ) || ( T000918_A29LocationId[0] == A29LocationId ) && ( T000918_A62ResidentId[0] == A62ResidentId ) && ( GuidUtil.Compare(T000918_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( GuidUtil.Compare(T000918_A62ResidentId[0], A62ResidentId, 0) > 0 ) || ( T000918_A62ResidentId[0] == A62ResidentId ) && ( GuidUtil.Compare(T000918_A29LocationId[0], A29LocationId, 0) > 0 ) || ( T000918_A29LocationId[0] == A29LocationId ) && ( T000918_A62ResidentId[0] == A62ResidentId ) && ( GuidUtil.Compare(T000918_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) ) )
            {
               A62ResidentId = T000918_A62ResidentId[0];
               AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
               A29LocationId = T000918_A29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               A11OrganisationId = T000918_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               RcdFound16 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void move_previous( )
      {
         RcdFound16 = 0;
         /* Using cursor T000919 */
         pr_default.execute(17, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( GuidUtil.Compare(T000919_A62ResidentId[0], A62ResidentId, 0) > 0 ) || ( T000919_A62ResidentId[0] == A62ResidentId ) && ( GuidUtil.Compare(T000919_A29LocationId[0], A29LocationId, 0) > 0 ) || ( T000919_A29LocationId[0] == A29LocationId ) && ( T000919_A62ResidentId[0] == A62ResidentId ) && ( GuidUtil.Compare(T000919_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( GuidUtil.Compare(T000919_A62ResidentId[0], A62ResidentId, 0) < 0 ) || ( T000919_A62ResidentId[0] == A62ResidentId ) && ( GuidUtil.Compare(T000919_A29LocationId[0], A29LocationId, 0) < 0 ) || ( T000919_A29LocationId[0] == A29LocationId ) && ( T000919_A62ResidentId[0] == A62ResidentId ) && ( GuidUtil.Compare(T000919_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) ) )
            {
               A62ResidentId = T000919_A62ResidentId[0];
               AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
               A29LocationId = T000919_A29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               A11OrganisationId = T000919_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               RcdFound16 = 1;
            }
         }
         pr_default.close(17);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0916( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtResidentBsnNumber_Internalname;
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
                  GX_FocusControl = edtResidentBsnNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0916( ) ;
                  GX_FocusControl = edtResidentBsnNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A62ResidentId != Z62ResidentId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtResidentBsnNumber_Internalname;
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
                     GX_FocusControl = edtResidentBsnNumber_Internalname;
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
            GX_FocusControl = edtResidentBsnNumber_Internalname;
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
            /* Using cursor T00098 */
            pr_default.execute(6, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(6) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Resident"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(6) == 101) || ( StringUtil.StrCmp(Z354ResidentCountry, T00098_A354ResidentCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z375ResidentPhoneCode, T00098_A375ResidentPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z445ResidentHomePhoneCode, T00098_A445ResidentHomePhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z71ResidentGUID, T00098_A71ResidentGUID[0]) != 0 ) || ( StringUtil.StrCmp(Z66ResidentInitials, T00098_A66ResidentInitials[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z70ResidentPhone, T00098_A70ResidentPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z72ResidentSalutation, T00098_A72ResidentSalutation[0]) != 0 ) || ( StringUtil.StrCmp(Z63ResidentBsnNumber, T00098_A63ResidentBsnNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z64ResidentGivenName, T00098_A64ResidentGivenName[0]) != 0 ) || ( StringUtil.StrCmp(Z65ResidentLastName, T00098_A65ResidentLastName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z67ResidentEmail, T00098_A67ResidentEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z68ResidentGender, T00098_A68ResidentGender[0]) != 0 ) || ( StringUtil.StrCmp(Z355ResidentCity, T00098_A355ResidentCity[0]) != 0 ) || ( StringUtil.StrCmp(Z356ResidentZipCode, T00098_A356ResidentZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z357ResidentAddressLine1, T00098_A357ResidentAddressLine1[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z358ResidentAddressLine2, T00098_A358ResidentAddressLine2[0]) != 0 ) || ( StringUtil.StrCmp(Z444ResidentHomePhone, T00098_A444ResidentHomePhone[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z73ResidentBirthDate ) != DateTimeUtil.ResetTime ( T00098_A73ResidentBirthDate[0] ) ) || ( StringUtil.StrCmp(Z376ResidentPhoneNumber, T00098_A376ResidentPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z446ResidentHomePhoneNumber, T00098_A446ResidentHomePhoneNumber[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z96ResidentTypeId != T00098_A96ResidentTypeId[0] ) || ( Z98MedicalIndicationId != T00098_A98MedicalIndicationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z354ResidentCountry, T00098_A354ResidentCountry[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentCountry");
                  GXUtil.WriteLogRaw("Old: ",Z354ResidentCountry);
                  GXUtil.WriteLogRaw("Current: ",T00098_A354ResidentCountry[0]);
               }
               if ( StringUtil.StrCmp(Z375ResidentPhoneCode, T00098_A375ResidentPhoneCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentPhoneCode");
                  GXUtil.WriteLogRaw("Old: ",Z375ResidentPhoneCode);
                  GXUtil.WriteLogRaw("Current: ",T00098_A375ResidentPhoneCode[0]);
               }
               if ( StringUtil.StrCmp(Z445ResidentHomePhoneCode, T00098_A445ResidentHomePhoneCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentHomePhoneCode");
                  GXUtil.WriteLogRaw("Old: ",Z445ResidentHomePhoneCode);
                  GXUtil.WriteLogRaw("Current: ",T00098_A445ResidentHomePhoneCode[0]);
               }
               if ( StringUtil.StrCmp(Z71ResidentGUID, T00098_A71ResidentGUID[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentGUID");
                  GXUtil.WriteLogRaw("Old: ",Z71ResidentGUID);
                  GXUtil.WriteLogRaw("Current: ",T00098_A71ResidentGUID[0]);
               }
               if ( StringUtil.StrCmp(Z66ResidentInitials, T00098_A66ResidentInitials[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentInitials");
                  GXUtil.WriteLogRaw("Old: ",Z66ResidentInitials);
                  GXUtil.WriteLogRaw("Current: ",T00098_A66ResidentInitials[0]);
               }
               if ( StringUtil.StrCmp(Z70ResidentPhone, T00098_A70ResidentPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentPhone");
                  GXUtil.WriteLogRaw("Old: ",Z70ResidentPhone);
                  GXUtil.WriteLogRaw("Current: ",T00098_A70ResidentPhone[0]);
               }
               if ( StringUtil.StrCmp(Z72ResidentSalutation, T00098_A72ResidentSalutation[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentSalutation");
                  GXUtil.WriteLogRaw("Old: ",Z72ResidentSalutation);
                  GXUtil.WriteLogRaw("Current: ",T00098_A72ResidentSalutation[0]);
               }
               if ( StringUtil.StrCmp(Z63ResidentBsnNumber, T00098_A63ResidentBsnNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentBsnNumber");
                  GXUtil.WriteLogRaw("Old: ",Z63ResidentBsnNumber);
                  GXUtil.WriteLogRaw("Current: ",T00098_A63ResidentBsnNumber[0]);
               }
               if ( StringUtil.StrCmp(Z64ResidentGivenName, T00098_A64ResidentGivenName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentGivenName");
                  GXUtil.WriteLogRaw("Old: ",Z64ResidentGivenName);
                  GXUtil.WriteLogRaw("Current: ",T00098_A64ResidentGivenName[0]);
               }
               if ( StringUtil.StrCmp(Z65ResidentLastName, T00098_A65ResidentLastName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentLastName");
                  GXUtil.WriteLogRaw("Old: ",Z65ResidentLastName);
                  GXUtil.WriteLogRaw("Current: ",T00098_A65ResidentLastName[0]);
               }
               if ( StringUtil.StrCmp(Z67ResidentEmail, T00098_A67ResidentEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentEmail");
                  GXUtil.WriteLogRaw("Old: ",Z67ResidentEmail);
                  GXUtil.WriteLogRaw("Current: ",T00098_A67ResidentEmail[0]);
               }
               if ( StringUtil.StrCmp(Z68ResidentGender, T00098_A68ResidentGender[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentGender");
                  GXUtil.WriteLogRaw("Old: ",Z68ResidentGender);
                  GXUtil.WriteLogRaw("Current: ",T00098_A68ResidentGender[0]);
               }
               if ( StringUtil.StrCmp(Z355ResidentCity, T00098_A355ResidentCity[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentCity");
                  GXUtil.WriteLogRaw("Old: ",Z355ResidentCity);
                  GXUtil.WriteLogRaw("Current: ",T00098_A355ResidentCity[0]);
               }
               if ( StringUtil.StrCmp(Z356ResidentZipCode, T00098_A356ResidentZipCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentZipCode");
                  GXUtil.WriteLogRaw("Old: ",Z356ResidentZipCode);
                  GXUtil.WriteLogRaw("Current: ",T00098_A356ResidentZipCode[0]);
               }
               if ( StringUtil.StrCmp(Z357ResidentAddressLine1, T00098_A357ResidentAddressLine1[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentAddressLine1");
                  GXUtil.WriteLogRaw("Old: ",Z357ResidentAddressLine1);
                  GXUtil.WriteLogRaw("Current: ",T00098_A357ResidentAddressLine1[0]);
               }
               if ( StringUtil.StrCmp(Z358ResidentAddressLine2, T00098_A358ResidentAddressLine2[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentAddressLine2");
                  GXUtil.WriteLogRaw("Old: ",Z358ResidentAddressLine2);
                  GXUtil.WriteLogRaw("Current: ",T00098_A358ResidentAddressLine2[0]);
               }
               if ( StringUtil.StrCmp(Z444ResidentHomePhone, T00098_A444ResidentHomePhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentHomePhone");
                  GXUtil.WriteLogRaw("Old: ",Z444ResidentHomePhone);
                  GXUtil.WriteLogRaw("Current: ",T00098_A444ResidentHomePhone[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z73ResidentBirthDate ) != DateTimeUtil.ResetTime ( T00098_A73ResidentBirthDate[0] ) )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentBirthDate");
                  GXUtil.WriteLogRaw("Old: ",Z73ResidentBirthDate);
                  GXUtil.WriteLogRaw("Current: ",T00098_A73ResidentBirthDate[0]);
               }
               if ( StringUtil.StrCmp(Z376ResidentPhoneNumber, T00098_A376ResidentPhoneNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentPhoneNumber");
                  GXUtil.WriteLogRaw("Old: ",Z376ResidentPhoneNumber);
                  GXUtil.WriteLogRaw("Current: ",T00098_A376ResidentPhoneNumber[0]);
               }
               if ( StringUtil.StrCmp(Z446ResidentHomePhoneNumber, T00098_A446ResidentHomePhoneNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentHomePhoneNumber");
                  GXUtil.WriteLogRaw("Old: ",Z446ResidentHomePhoneNumber);
                  GXUtil.WriteLogRaw("Current: ",T00098_A446ResidentHomePhoneNumber[0]);
               }
               if ( Z96ResidentTypeId != T00098_A96ResidentTypeId[0] )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"ResidentTypeId");
                  GXUtil.WriteLogRaw("Old: ",Z96ResidentTypeId);
                  GXUtil.WriteLogRaw("Current: ",T00098_A96ResidentTypeId[0]);
               }
               if ( Z98MedicalIndicationId != T00098_A98MedicalIndicationId[0] )
               {
                  GXUtil.WriteLog("trn_resident:[seudo value changed for attri]"+"MedicalIndicationId");
                  GXUtil.WriteLogRaw("Old: ",Z98MedicalIndicationId);
                  GXUtil.WriteLogRaw("Current: ",T00098_A98MedicalIndicationId[0]);
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
                     /* Using cursor T000920 */
                     pr_default.execute(18, new Object[] {A62ResidentId, A354ResidentCountry, A375ResidentPhoneCode, A445ResidentHomePhoneCode, A71ResidentGUID, A66ResidentInitials, A70ResidentPhone, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A67ResidentEmail, A68ResidentGender, A355ResidentCity, A356ResidentZipCode, A357ResidentAddressLine1, A358ResidentAddressLine2, A444ResidentHomePhone, A73ResidentBirthDate, A376ResidentPhoneNumber, A446ResidentHomePhoneNumber, A29LocationId, A11OrganisationId, A96ResidentTypeId, n98MedicalIndicationId, A98MedicalIndicationId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
                     if ( (pr_default.getStatus(18) == 1) )
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
                           ProcessLevel0916( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption090( ) ;
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
                     /* Using cursor T000921 */
                     pr_default.execute(19, new Object[] {A354ResidentCountry, A375ResidentPhoneCode, A445ResidentHomePhoneCode, A71ResidentGUID, A66ResidentInitials, A70ResidentPhone, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A67ResidentEmail, A68ResidentGender, A355ResidentCity, A356ResidentZipCode, A357ResidentAddressLine1, A358ResidentAddressLine2, A444ResidentHomePhone, A73ResidentBirthDate, A376ResidentPhoneNumber, A446ResidentHomePhoneNumber, A96ResidentTypeId, n98MedicalIndicationId, A98MedicalIndicationId, A62ResidentId, A29LocationId, A11OrganisationId});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
                     if ( (pr_default.getStatus(19) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Resident"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0916( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        if ( IsUpd( )  )
                        {
                           new prc_updategamuseraccount(context ).execute(  A71ResidentGUID,  A64ResidentGivenName,  A65ResidentLastName,  "Resident", out  AV36GAMErrorResponse) ;
                           AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
                        }
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0916( ) ;
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
                  ScanStart0923( ) ;
                  while ( RcdFound23 != 0 )
                  {
                     getByPrimaryKey0923( ) ;
                     Delete0923( ) ;
                     ScanNext0923( ) ;
                  }
                  ScanEnd0923( ) ;
                  ScanStart0920( ) ;
                  while ( RcdFound20 != 0 )
                  {
                     getByPrimaryKey0920( ) ;
                     Delete0920( ) ;
                     ScanNext0920( ) ;
                  }
                  ScanEnd0920( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000922 */
                     pr_default.execute(20, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        if ( IsDlt( )  )
                        {
                           new prc_deletegamuseraccount(context ).execute(  A71ResidentGUID, out  AV36GAMErrorResponse) ;
                           AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
                        }
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
            /* Using cursor T000923 */
            pr_default.execute(21, new Object[] {A96ResidentTypeId});
            A97ResidentTypeName = T000923_A97ResidentTypeName[0];
            pr_default.close(21);
            /* Using cursor T000924 */
            pr_default.execute(22, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
            A99MedicalIndicationName = T000924_A99MedicalIndicationName[0];
            pr_default.close(22);
         }
      }

      protected void ProcessNestedLevel0923( )
      {
         nGXsfl_150_idx = 0;
         while ( nGXsfl_150_idx < nRC_GXsfl_150 )
         {
            ReadRow0923( ) ;
            if ( ( nRcdExists_23 != 0 ) || ( nIsMod_23 != 0 ) )
            {
               standaloneNotModal0923( ) ;
               GetKey0923( ) ;
               if ( ( nRcdExists_23 == 0 ) && ( nRcdDeleted_23 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0923( ) ;
               }
               else
               {
                  if ( RcdFound23 != 0 )
                  {
                     if ( ( nRcdDeleted_23 != 0 ) && ( nRcdExists_23 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0923( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_23 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0923( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_23 == 0 )
                     {
                        GXCCtl = "NETWORKINDIVIDUALID_" + sGXsfl_150_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtNetworkIndividualId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtNetworkIndividualId_Internalname, A74NetworkIndividualId.ToString()) ;
            ChangePostValue( edtNetworkIndividualGivenName_Internalname, A76NetworkIndividualGivenName) ;
            ChangePostValue( edtNetworkIndividualLastName_Internalname, A77NetworkIndividualLastName) ;
            ChangePostValue( edtNetworkIndividualEmail_Internalname, A78NetworkIndividualEmail) ;
            ChangePostValue( edtNetworkIndividualPhone_Internalname, StringUtil.RTrim( A79NetworkIndividualPhone)) ;
            ChangePostValue( cmbNetworkIndividualGender_Internalname, A81NetworkIndividualGender) ;
            ChangePostValue( edtNetworkIndividualCountry_Internalname, A344NetworkIndividualCountry) ;
            ChangePostValue( edtNetworkIndividualCity_Internalname, A345NetworkIndividualCity) ;
            ChangePostValue( edtNetworkIndividualZipCode_Internalname, A346NetworkIndividualZipCode) ;
            ChangePostValue( edtNetworkIndividualAddressLine1_Internalname, A347NetworkIndividualAddressLine1) ;
            ChangePostValue( edtNetworkIndividualAddressLine2_Internalname, A348NetworkIndividualAddressLine2) ;
            ChangePostValue( "ZT_"+"Z74NetworkIndividualId_"+sGXsfl_150_idx, Z74NetworkIndividualId.ToString()) ;
            ChangePostValue( "nRcdDeleted_23_"+sGXsfl_150_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_23), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_23_"+sGXsfl_150_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_23), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_23_"+sGXsfl_150_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_23), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_23 != 0 )
            {
               ChangePostValue( "NETWORKINDIVIDUALID_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALGIVENNAME_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualGivenName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALLASTNAME_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualLastName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALEMAIL_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALPHONE_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualPhone_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALGENDER_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbNetworkIndividualGender.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALCOUNTRY_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualCountry_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALCITY_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualCity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALZIPCODE_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualZipCode_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALADDRESSLINE1_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualAddressLine1_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKINDIVIDUALADDRESSLINE2_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualAddressLine2_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0923( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_23 = 0;
         nIsMod_23 = 0;
         nRcdDeleted_23 = 0;
      }

      protected void ProcessNestedLevel0920( )
      {
         nGXsfl_167_idx = 0;
         while ( nGXsfl_167_idx < nRC_GXsfl_167 )
         {
            ReadRow0920( ) ;
            if ( ( nRcdExists_20 != 0 ) || ( nIsMod_20 != 0 ) )
            {
               standaloneNotModal0920( ) ;
               GetKey0920( ) ;
               if ( ( nRcdExists_20 == 0 ) && ( nRcdDeleted_20 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0920( ) ;
               }
               else
               {
                  if ( RcdFound20 != 0 )
                  {
                     if ( ( nRcdDeleted_20 != 0 ) && ( nRcdExists_20 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0920( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_20 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0920( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_20 == 0 )
                     {
                        GXCCtl = "NETWORKCOMPANYID_" + sGXsfl_167_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtNetworkCompanyId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtNetworkCompanyId_Internalname, A82NetworkCompanyId.ToString()) ;
            ChangePostValue( edtNetworkCompanyKvkNumber_Internalname, A83NetworkCompanyKvkNumber) ;
            ChangePostValue( edtNetworkCompanyEmail_Internalname, A85NetworkCompanyEmail) ;
            ChangePostValue( edtNetworkCompanyPhone_Internalname, StringUtil.RTrim( A86NetworkCompanyPhone)) ;
            ChangePostValue( edtNetworkCompanyCountry_Internalname, A349NetworkCompanyCountry) ;
            ChangePostValue( edtNetworkCompanyCity_Internalname, A350NetworkCompanyCity) ;
            ChangePostValue( edtNetworkCompanyZipCode_Internalname, A351NetworkCompanyZipCode) ;
            ChangePostValue( edtNetworkCompanyAddressLine1_Internalname, A352NetworkCompanyAddressLine1) ;
            ChangePostValue( edtNetworkCompanyAddressLine2_Internalname, A353NetworkCompanyAddressLine2) ;
            ChangePostValue( "ZT_"+"Z82NetworkCompanyId_"+sGXsfl_167_idx, Z82NetworkCompanyId.ToString()) ;
            ChangePostValue( "nRcdDeleted_20_"+sGXsfl_167_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_20), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_20_"+sGXsfl_167_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_20), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_20_"+sGXsfl_167_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_20), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_20 != 0 )
            {
               ChangePostValue( "NETWORKCOMPANYID_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKCOMPANYKVKNUMBER_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyKvkNumber_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKCOMPANYEMAIL_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKCOMPANYPHONE_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyPhone_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKCOMPANYCOUNTRY_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyCountry_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKCOMPANYCITY_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyCity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKCOMPANYZIPCODE_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyZipCode_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKCOMPANYADDRESSLINE1_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyAddressLine1_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NETWORKCOMPANYADDRESSLINE2_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyAddressLine2_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0920( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_20 = 0;
         nIsMod_20 = 0;
         nRcdDeleted_20 = 0;
      }

      protected void ProcessLevel0916( )
      {
         /* Save parent mode. */
         sMode16 = Gx_mode;
         ProcessNestedLevel0923( ) ;
         ProcessNestedLevel0920( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode16;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0916( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(6);
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
         /* Using cursor T000925 */
         pr_default.execute(23);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound16 = 1;
            A62ResidentId = T000925_A62ResidentId[0];
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
            A29LocationId = T000925_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T000925_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0916( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound16 = 1;
            A62ResidentId = T000925_A62ResidentId[0];
            AssignAttri("", false, "A62ResidentId", A62ResidentId.ToString());
            A29LocationId = T000925_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T000925_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
      }

      protected void ScanEnd0916( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm0916( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0916( )
      {
         /* Before Insert Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "INS", "")) == 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( A71ResidentGUID)) )
         {
            new prc_creategamuseraccount(context ).execute(  A67ResidentEmail,  A64ResidentGivenName,  A65ResidentLastName,  "Resident", out  A71ResidentGUID) ;
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
         }
      }

      protected void BeforeUpdate0916( )
      {
         /* Before Update Rules */
         new loadaudittrn_resident(context ).execute(  "Y", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
      }

      protected void BeforeDelete0916( )
      {
         /* Before Delete Rules */
         new loadaudittrn_resident(context ).execute(  "Y", ref  AV42AuditingObject,  A62ResidentId,  A29LocationId,  A11OrganisationId,  Gx_mode) ;
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
         edtResidentBsnNumber_Enabled = 0;
         AssignProp("", false, edtResidentBsnNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentBsnNumber_Enabled), 5, 0), true);
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
         edtResidentTypeId_Enabled = 0;
         AssignProp("", false, edtResidentTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentTypeId_Enabled), 5, 0), true);
         edtMedicalIndicationId_Enabled = 0;
         AssignProp("", false, edtMedicalIndicationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedicalIndicationId_Enabled), 5, 0), true);
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
         edtavComboresidenttypeid_Enabled = 0;
         AssignProp("", false, edtavComboresidenttypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboresidenttypeid_Enabled), 5, 0), true);
         edtavCombomedicalindicationid_Enabled = 0;
         AssignProp("", false, edtavCombomedicalindicationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomedicalindicationid_Enabled), 5, 0), true);
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
         edtResidentPhone_Enabled = 0;
         AssignProp("", false, edtResidentPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPhone_Enabled), 5, 0), true);
         edtResidentHomePhone_Enabled = 0;
         AssignProp("", false, edtResidentHomePhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentHomePhone_Enabled), 5, 0), true);
         edtResidentGUID_Enabled = 0;
         AssignProp("", false, edtResidentGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGUID_Enabled), 5, 0), true);
      }

      protected void ZM0923( short GX_JID )
      {
         if ( ( GX_JID == 54 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -54 )
         {
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z74NetworkIndividualId = A74NetworkIndividualId;
            Z75NetworkIndividualBsnNumber = A75NetworkIndividualBsnNumber;
            Z76NetworkIndividualGivenName = A76NetworkIndividualGivenName;
            Z77NetworkIndividualLastName = A77NetworkIndividualLastName;
            Z78NetworkIndividualEmail = A78NetworkIndividualEmail;
            Z79NetworkIndividualPhone = A79NetworkIndividualPhone;
            Z388NetworkIndividualPhoneNumber = A388NetworkIndividualPhoneNumber;
            Z387NetworkIndividualPhoneCode = A387NetworkIndividualPhoneCode;
            Z81NetworkIndividualGender = A81NetworkIndividualGender;
            Z344NetworkIndividualCountry = A344NetworkIndividualCountry;
            Z345NetworkIndividualCity = A345NetworkIndividualCity;
            Z346NetworkIndividualZipCode = A346NetworkIndividualZipCode;
            Z347NetworkIndividualAddressLine1 = A347NetworkIndividualAddressLine1;
            Z348NetworkIndividualAddressLine2 = A348NetworkIndividualAddressLine2;
         }
      }

      protected void standaloneNotModal0923( )
      {
      }

      protected void standaloneModal0923( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtNetworkIndividualId_Enabled = 0;
            AssignProp("", false, edtNetworkIndividualId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualId_Enabled), 5, 0), !bGXsfl_150_Refreshing);
         }
         else
         {
            edtNetworkIndividualId_Enabled = 1;
            AssignProp("", false, edtNetworkIndividualId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualId_Enabled), 5, 0), !bGXsfl_150_Refreshing);
         }
      }

      protected void Load0923( )
      {
         /* Using cursor T000926 */
         pr_default.execute(24, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId, A74NetworkIndividualId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound23 = 1;
            A75NetworkIndividualBsnNumber = T000926_A75NetworkIndividualBsnNumber[0];
            A76NetworkIndividualGivenName = T000926_A76NetworkIndividualGivenName[0];
            A77NetworkIndividualLastName = T000926_A77NetworkIndividualLastName[0];
            A78NetworkIndividualEmail = T000926_A78NetworkIndividualEmail[0];
            A79NetworkIndividualPhone = T000926_A79NetworkIndividualPhone[0];
            A388NetworkIndividualPhoneNumber = T000926_A388NetworkIndividualPhoneNumber[0];
            A387NetworkIndividualPhoneCode = T000926_A387NetworkIndividualPhoneCode[0];
            A81NetworkIndividualGender = T000926_A81NetworkIndividualGender[0];
            A344NetworkIndividualCountry = T000926_A344NetworkIndividualCountry[0];
            A345NetworkIndividualCity = T000926_A345NetworkIndividualCity[0];
            A346NetworkIndividualZipCode = T000926_A346NetworkIndividualZipCode[0];
            A347NetworkIndividualAddressLine1 = T000926_A347NetworkIndividualAddressLine1[0];
            A348NetworkIndividualAddressLine2 = T000926_A348NetworkIndividualAddressLine2[0];
            ZM0923( -54) ;
         }
         pr_default.close(24);
         OnLoadActions0923( ) ;
      }

      protected void OnLoadActions0923( )
      {
      }

      protected void CheckExtendedTable0923( )
      {
         nIsDirty_23 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0923( ) ;
         /* Using cursor T00097 */
         pr_default.execute(5, new Object[] {A74NetworkIndividualId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GXCCtl = "NETWORKINDIVIDUALID_" + sGXsfl_150_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_NetworkIndividual", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtNetworkIndividualId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A75NetworkIndividualBsnNumber = T00097_A75NetworkIndividualBsnNumber[0];
         A76NetworkIndividualGivenName = T00097_A76NetworkIndividualGivenName[0];
         A77NetworkIndividualLastName = T00097_A77NetworkIndividualLastName[0];
         A78NetworkIndividualEmail = T00097_A78NetworkIndividualEmail[0];
         A79NetworkIndividualPhone = T00097_A79NetworkIndividualPhone[0];
         A388NetworkIndividualPhoneNumber = T00097_A388NetworkIndividualPhoneNumber[0];
         A387NetworkIndividualPhoneCode = T00097_A387NetworkIndividualPhoneCode[0];
         A81NetworkIndividualGender = T00097_A81NetworkIndividualGender[0];
         A344NetworkIndividualCountry = T00097_A344NetworkIndividualCountry[0];
         A345NetworkIndividualCity = T00097_A345NetworkIndividualCity[0];
         A346NetworkIndividualZipCode = T00097_A346NetworkIndividualZipCode[0];
         A347NetworkIndividualAddressLine1 = T00097_A347NetworkIndividualAddressLine1[0];
         A348NetworkIndividualAddressLine2 = T00097_A348NetworkIndividualAddressLine2[0];
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors0923( )
      {
         pr_default.close(5);
      }

      protected void enableDisable0923( )
      {
      }

      protected void gxLoad_55( Guid A74NetworkIndividualId )
      {
         /* Using cursor T000927 */
         pr_default.execute(25, new Object[] {A74NetworkIndividualId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GXCCtl = "NETWORKINDIVIDUALID_" + sGXsfl_150_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_NetworkIndividual", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtNetworkIndividualId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A75NetworkIndividualBsnNumber = T000927_A75NetworkIndividualBsnNumber[0];
         A76NetworkIndividualGivenName = T000927_A76NetworkIndividualGivenName[0];
         A77NetworkIndividualLastName = T000927_A77NetworkIndividualLastName[0];
         A78NetworkIndividualEmail = T000927_A78NetworkIndividualEmail[0];
         A79NetworkIndividualPhone = T000927_A79NetworkIndividualPhone[0];
         A388NetworkIndividualPhoneNumber = T000927_A388NetworkIndividualPhoneNumber[0];
         A387NetworkIndividualPhoneCode = T000927_A387NetworkIndividualPhoneCode[0];
         A81NetworkIndividualGender = T000927_A81NetworkIndividualGender[0];
         A344NetworkIndividualCountry = T000927_A344NetworkIndividualCountry[0];
         A345NetworkIndividualCity = T000927_A345NetworkIndividualCity[0];
         A346NetworkIndividualZipCode = T000927_A346NetworkIndividualZipCode[0];
         A347NetworkIndividualAddressLine1 = T000927_A347NetworkIndividualAddressLine1[0];
         A348NetworkIndividualAddressLine2 = T000927_A348NetworkIndividualAddressLine2[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A75NetworkIndividualBsnNumber)+"\""+","+"\""+GXUtil.EncodeJSConstant( A76NetworkIndividualGivenName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A77NetworkIndividualLastName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A78NetworkIndividualEmail)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A79NetworkIndividualPhone))+"\""+","+"\""+GXUtil.EncodeJSConstant( A388NetworkIndividualPhoneNumber)+"\""+","+"\""+GXUtil.EncodeJSConstant( A387NetworkIndividualPhoneCode)+"\""+","+"\""+GXUtil.EncodeJSConstant( A81NetworkIndividualGender)+"\""+","+"\""+GXUtil.EncodeJSConstant( A344NetworkIndividualCountry)+"\""+","+"\""+GXUtil.EncodeJSConstant( A345NetworkIndividualCity)+"\""+","+"\""+GXUtil.EncodeJSConstant( A346NetworkIndividualZipCode)+"\""+","+"\""+GXUtil.EncodeJSConstant( A347NetworkIndividualAddressLine1)+"\""+","+"\""+GXUtil.EncodeJSConstant( A348NetworkIndividualAddressLine2)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(25) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(25);
      }

      protected void GetKey0923( )
      {
         /* Using cursor T000928 */
         pr_default.execute(26, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId, A74NetworkIndividualId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound23 = 1;
         }
         else
         {
            RcdFound23 = 0;
         }
         pr_default.close(26);
      }

      protected void getByPrimaryKey0923( )
      {
         /* Using cursor T00096 */
         pr_default.execute(4, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId, A74NetworkIndividualId});
         if ( (pr_default.getStatus(4) != 101) && ( T00096_A62ResidentId[0] == A62ResidentId ) && ( T00096_A29LocationId[0] == A29LocationId ) && ( T00096_A11OrganisationId[0] == A11OrganisationId ) )
         {
            ZM0923( 54) ;
            RcdFound23 = 1;
            InitializeNonKey0923( ) ;
            A74NetworkIndividualId = T00096_A74NetworkIndividualId[0];
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z74NetworkIndividualId = A74NetworkIndividualId;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0923( ) ;
            Gx_mode = sMode23;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound23 = 0;
            InitializeNonKey0923( ) ;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0923( ) ;
            Gx_mode = sMode23;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0923( ) ;
         }
         pr_default.close(4);
      }

      protected void CheckOptimisticConcurrency0923( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00095 */
            pr_default.execute(3, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId, A74NetworkIndividualId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentNetworkIndividual"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ResidentNetworkIndividual"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0923( )
      {
         if ( ! IsAuthorized("trn_resident_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0923( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0923( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0923( 0) ;
            CheckOptimisticConcurrency0923( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0923( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0923( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000929 */
                     pr_default.execute(27, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId, A74NetworkIndividualId});
                     pr_default.close(27);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentNetworkIndividual");
                     if ( (pr_default.getStatus(27) == 1) )
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
               Load0923( ) ;
            }
            EndLevel0923( ) ;
         }
         CloseExtendedTableCursors0923( ) ;
      }

      protected void Update0923( )
      {
         if ( ! IsAuthorized("trn_resident_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0923( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0923( ) ;
         }
         if ( ( nIsMod_23 != 0 ) || ( nIsDirty_23 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0923( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0923( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0923( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table Trn_ResidentNetworkIndividual */
                        DeferredUpdate0923( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0923( ) ;
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
               EndLevel0923( ) ;
            }
         }
         CloseExtendedTableCursors0923( ) ;
      }

      protected void DeferredUpdate0923( )
      {
      }

      protected void Delete0923( )
      {
         if ( ! IsAuthorized("trn_resident_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0923( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0923( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0923( ) ;
            AfterConfirm0923( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0923( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000930 */
                  pr_default.execute(28, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId, A74NetworkIndividualId});
                  pr_default.close(28);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentNetworkIndividual");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode23 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0923( ) ;
         Gx_mode = sMode23;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0923( )
      {
         standaloneModal0923( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000931 */
            pr_default.execute(29, new Object[] {A74NetworkIndividualId});
            A75NetworkIndividualBsnNumber = T000931_A75NetworkIndividualBsnNumber[0];
            A76NetworkIndividualGivenName = T000931_A76NetworkIndividualGivenName[0];
            A77NetworkIndividualLastName = T000931_A77NetworkIndividualLastName[0];
            A78NetworkIndividualEmail = T000931_A78NetworkIndividualEmail[0];
            A79NetworkIndividualPhone = T000931_A79NetworkIndividualPhone[0];
            A388NetworkIndividualPhoneNumber = T000931_A388NetworkIndividualPhoneNumber[0];
            A387NetworkIndividualPhoneCode = T000931_A387NetworkIndividualPhoneCode[0];
            A81NetworkIndividualGender = T000931_A81NetworkIndividualGender[0];
            A344NetworkIndividualCountry = T000931_A344NetworkIndividualCountry[0];
            A345NetworkIndividualCity = T000931_A345NetworkIndividualCity[0];
            A346NetworkIndividualZipCode = T000931_A346NetworkIndividualZipCode[0];
            A347NetworkIndividualAddressLine1 = T000931_A347NetworkIndividualAddressLine1[0];
            A348NetworkIndividualAddressLine2 = T000931_A348NetworkIndividualAddressLine2[0];
            pr_default.close(29);
         }
      }

      protected void EndLevel0923( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0923( )
      {
         /* Scan By routine */
         /* Using cursor T000932 */
         pr_default.execute(30, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         RcdFound23 = 0;
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound23 = 1;
            A74NetworkIndividualId = T000932_A74NetworkIndividualId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0923( )
      {
         /* Scan next routine */
         pr_default.readNext(30);
         RcdFound23 = 0;
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound23 = 1;
            A74NetworkIndividualId = T000932_A74NetworkIndividualId[0];
         }
      }

      protected void ScanEnd0923( )
      {
         pr_default.close(30);
      }

      protected void AfterConfirm0923( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0923( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0923( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0923( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0923( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0923( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0923( )
      {
         edtNetworkIndividualId_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualId_Enabled), 5, 0), !bGXsfl_150_Refreshing);
         edtNetworkIndividualGivenName_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualGivenName_Enabled), 5, 0), !bGXsfl_150_Refreshing);
         edtNetworkIndividualLastName_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualLastName_Enabled), 5, 0), !bGXsfl_150_Refreshing);
         edtNetworkIndividualEmail_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualEmail_Enabled), 5, 0), !bGXsfl_150_Refreshing);
         edtNetworkIndividualPhone_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualPhone_Enabled), 5, 0), !bGXsfl_150_Refreshing);
         cmbNetworkIndividualGender.Enabled = 0;
         AssignProp("", false, cmbNetworkIndividualGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNetworkIndividualGender.Enabled), 5, 0), !bGXsfl_150_Refreshing);
         edtNetworkIndividualCountry_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualCountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualCountry_Enabled), 5, 0), !bGXsfl_150_Refreshing);
         edtNetworkIndividualCity_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualCity_Enabled), 5, 0), !bGXsfl_150_Refreshing);
         edtNetworkIndividualZipCode_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualZipCode_Enabled), 5, 0), !bGXsfl_150_Refreshing);
         edtNetworkIndividualAddressLine1_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualAddressLine1_Enabled), 5, 0), !bGXsfl_150_Refreshing);
         edtNetworkIndividualAddressLine2_Enabled = 0;
         AssignProp("", false, edtNetworkIndividualAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualAddressLine2_Enabled), 5, 0), !bGXsfl_150_Refreshing);
      }

      protected void send_integrity_lvl_hashes0923( )
      {
      }

      protected void ZM0920( short GX_JID )
      {
         if ( ( GX_JID == 56 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -56 )
         {
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z82NetworkCompanyId = A82NetworkCompanyId;
            Z83NetworkCompanyKvkNumber = A83NetworkCompanyKvkNumber;
            Z84NetworkCompanyName = A84NetworkCompanyName;
            Z85NetworkCompanyEmail = A85NetworkCompanyEmail;
            Z86NetworkCompanyPhone = A86NetworkCompanyPhone;
            Z392NetworkCompanyPhoneNumber = A392NetworkCompanyPhoneNumber;
            Z391NetworkCompanyPhoneCode = A391NetworkCompanyPhoneCode;
            Z349NetworkCompanyCountry = A349NetworkCompanyCountry;
            Z350NetworkCompanyCity = A350NetworkCompanyCity;
            Z351NetworkCompanyZipCode = A351NetworkCompanyZipCode;
            Z352NetworkCompanyAddressLine1 = A352NetworkCompanyAddressLine1;
            Z353NetworkCompanyAddressLine2 = A353NetworkCompanyAddressLine2;
         }
      }

      protected void standaloneNotModal0920( )
      {
      }

      protected void standaloneModal0920( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtNetworkCompanyId_Enabled = 0;
            AssignProp("", false, edtNetworkCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyId_Enabled), 5, 0), !bGXsfl_167_Refreshing);
         }
         else
         {
            edtNetworkCompanyId_Enabled = 1;
            AssignProp("", false, edtNetworkCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyId_Enabled), 5, 0), !bGXsfl_167_Refreshing);
         }
      }

      protected void Load0920( )
      {
         /* Using cursor T000933 */
         pr_default.execute(31, new Object[] {A82NetworkCompanyId, A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound20 = 1;
            A83NetworkCompanyKvkNumber = T000933_A83NetworkCompanyKvkNumber[0];
            A84NetworkCompanyName = T000933_A84NetworkCompanyName[0];
            A85NetworkCompanyEmail = T000933_A85NetworkCompanyEmail[0];
            A86NetworkCompanyPhone = T000933_A86NetworkCompanyPhone[0];
            A392NetworkCompanyPhoneNumber = T000933_A392NetworkCompanyPhoneNumber[0];
            A391NetworkCompanyPhoneCode = T000933_A391NetworkCompanyPhoneCode[0];
            A349NetworkCompanyCountry = T000933_A349NetworkCompanyCountry[0];
            A350NetworkCompanyCity = T000933_A350NetworkCompanyCity[0];
            A351NetworkCompanyZipCode = T000933_A351NetworkCompanyZipCode[0];
            A352NetworkCompanyAddressLine1 = T000933_A352NetworkCompanyAddressLine1[0];
            A353NetworkCompanyAddressLine2 = T000933_A353NetworkCompanyAddressLine2[0];
            ZM0920( -56) ;
         }
         pr_default.close(31);
         OnLoadActions0920( ) ;
      }

      protected void OnLoadActions0920( )
      {
      }

      protected void CheckExtendedTable0920( )
      {
         nIsDirty_20 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0920( ) ;
         /* Using cursor T00094 */
         pr_default.execute(2, new Object[] {A82NetworkCompanyId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "NETWORKCOMPANYID_" + sGXsfl_167_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_NetworkCompany", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtNetworkCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A83NetworkCompanyKvkNumber = T00094_A83NetworkCompanyKvkNumber[0];
         A84NetworkCompanyName = T00094_A84NetworkCompanyName[0];
         A85NetworkCompanyEmail = T00094_A85NetworkCompanyEmail[0];
         A86NetworkCompanyPhone = T00094_A86NetworkCompanyPhone[0];
         A392NetworkCompanyPhoneNumber = T00094_A392NetworkCompanyPhoneNumber[0];
         A391NetworkCompanyPhoneCode = T00094_A391NetworkCompanyPhoneCode[0];
         A349NetworkCompanyCountry = T00094_A349NetworkCompanyCountry[0];
         A350NetworkCompanyCity = T00094_A350NetworkCompanyCity[0];
         A351NetworkCompanyZipCode = T00094_A351NetworkCompanyZipCode[0];
         A352NetworkCompanyAddressLine1 = T00094_A352NetworkCompanyAddressLine1[0];
         A353NetworkCompanyAddressLine2 = T00094_A353NetworkCompanyAddressLine2[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0920( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0920( )
      {
      }

      protected void gxLoad_57( Guid A82NetworkCompanyId )
      {
         /* Using cursor T000934 */
         pr_default.execute(32, new Object[] {A82NetworkCompanyId});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GXCCtl = "NETWORKCOMPANYID_" + sGXsfl_167_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_NetworkCompany", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtNetworkCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A83NetworkCompanyKvkNumber = T000934_A83NetworkCompanyKvkNumber[0];
         A84NetworkCompanyName = T000934_A84NetworkCompanyName[0];
         A85NetworkCompanyEmail = T000934_A85NetworkCompanyEmail[0];
         A86NetworkCompanyPhone = T000934_A86NetworkCompanyPhone[0];
         A392NetworkCompanyPhoneNumber = T000934_A392NetworkCompanyPhoneNumber[0];
         A391NetworkCompanyPhoneCode = T000934_A391NetworkCompanyPhoneCode[0];
         A349NetworkCompanyCountry = T000934_A349NetworkCompanyCountry[0];
         A350NetworkCompanyCity = T000934_A350NetworkCompanyCity[0];
         A351NetworkCompanyZipCode = T000934_A351NetworkCompanyZipCode[0];
         A352NetworkCompanyAddressLine1 = T000934_A352NetworkCompanyAddressLine1[0];
         A353NetworkCompanyAddressLine2 = T000934_A353NetworkCompanyAddressLine2[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A83NetworkCompanyKvkNumber)+"\""+","+"\""+GXUtil.EncodeJSConstant( A84NetworkCompanyName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A85NetworkCompanyEmail)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A86NetworkCompanyPhone))+"\""+","+"\""+GXUtil.EncodeJSConstant( A392NetworkCompanyPhoneNumber)+"\""+","+"\""+GXUtil.EncodeJSConstant( A391NetworkCompanyPhoneCode)+"\""+","+"\""+GXUtil.EncodeJSConstant( A349NetworkCompanyCountry)+"\""+","+"\""+GXUtil.EncodeJSConstant( A350NetworkCompanyCity)+"\""+","+"\""+GXUtil.EncodeJSConstant( A351NetworkCompanyZipCode)+"\""+","+"\""+GXUtil.EncodeJSConstant( A352NetworkCompanyAddressLine1)+"\""+","+"\""+GXUtil.EncodeJSConstant( A353NetworkCompanyAddressLine2)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(32) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(32);
      }

      protected void GetKey0920( )
      {
         /* Using cursor T000935 */
         pr_default.execute(33, new Object[] {A82NetworkCompanyId, A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(33);
      }

      protected void getByPrimaryKey0920( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {A82NetworkCompanyId, A62ResidentId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) && ( T00093_A62ResidentId[0] == A62ResidentId ) && ( T00093_A29LocationId[0] == A29LocationId ) && ( T00093_A11OrganisationId[0] == A11OrganisationId ) )
         {
            ZM0920( 56) ;
            RcdFound20 = 1;
            InitializeNonKey0920( ) ;
            A82NetworkCompanyId = T00093_A82NetworkCompanyId[0];
            Z82NetworkCompanyId = A82NetworkCompanyId;
            Z62ResidentId = A62ResidentId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0920( ) ;
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0920( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0920( ) ;
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0920( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0920( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00092 */
            pr_default.execute(0, new Object[] {A82NetworkCompanyId, A62ResidentId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentNetworkCompany"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ResidentNetworkCompany"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0920( )
      {
         if ( ! IsAuthorized("trn_resident_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0920( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0920( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0920( 0) ;
            CheckOptimisticConcurrency0920( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0920( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0920( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000936 */
                     pr_default.execute(34, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId, A82NetworkCompanyId});
                     pr_default.close(34);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentNetworkCompany");
                     if ( (pr_default.getStatus(34) == 1) )
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
               Load0920( ) ;
            }
            EndLevel0920( ) ;
         }
         CloseExtendedTableCursors0920( ) ;
      }

      protected void Update0920( )
      {
         if ( ! IsAuthorized("trn_resident_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0920( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0920( ) ;
         }
         if ( ( nIsMod_20 != 0 ) || ( nIsDirty_20 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0920( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0920( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0920( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table Trn_ResidentNetworkCompany */
                        DeferredUpdate0920( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0920( ) ;
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
               EndLevel0920( ) ;
            }
         }
         CloseExtendedTableCursors0920( ) ;
      }

      protected void DeferredUpdate0920( )
      {
      }

      protected void Delete0920( )
      {
         if ( ! IsAuthorized("trn_resident_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0920( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0920( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0920( ) ;
            AfterConfirm0920( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0920( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000937 */
                  pr_default.execute(35, new Object[] {A82NetworkCompanyId, A62ResidentId, A29LocationId, A11OrganisationId});
                  pr_default.close(35);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentNetworkCompany");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0920( ) ;
         Gx_mode = sMode20;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0920( )
      {
         standaloneModal0920( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000938 */
            pr_default.execute(36, new Object[] {A82NetworkCompanyId});
            A83NetworkCompanyKvkNumber = T000938_A83NetworkCompanyKvkNumber[0];
            A84NetworkCompanyName = T000938_A84NetworkCompanyName[0];
            A85NetworkCompanyEmail = T000938_A85NetworkCompanyEmail[0];
            A86NetworkCompanyPhone = T000938_A86NetworkCompanyPhone[0];
            A392NetworkCompanyPhoneNumber = T000938_A392NetworkCompanyPhoneNumber[0];
            A391NetworkCompanyPhoneCode = T000938_A391NetworkCompanyPhoneCode[0];
            A349NetworkCompanyCountry = T000938_A349NetworkCompanyCountry[0];
            A350NetworkCompanyCity = T000938_A350NetworkCompanyCity[0];
            A351NetworkCompanyZipCode = T000938_A351NetworkCompanyZipCode[0];
            A352NetworkCompanyAddressLine1 = T000938_A352NetworkCompanyAddressLine1[0];
            A353NetworkCompanyAddressLine2 = T000938_A353NetworkCompanyAddressLine2[0];
            pr_default.close(36);
         }
      }

      protected void EndLevel0920( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0920( )
      {
         /* Scan By routine */
         /* Using cursor T000939 */
         pr_default.execute(37, new Object[] {A62ResidentId, A29LocationId, A11OrganisationId});
         RcdFound20 = 0;
         if ( (pr_default.getStatus(37) != 101) )
         {
            RcdFound20 = 1;
            A82NetworkCompanyId = T000939_A82NetworkCompanyId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0920( )
      {
         /* Scan next routine */
         pr_default.readNext(37);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(37) != 101) )
         {
            RcdFound20 = 1;
            A82NetworkCompanyId = T000939_A82NetworkCompanyId[0];
         }
      }

      protected void ScanEnd0920( )
      {
         pr_default.close(37);
      }

      protected void AfterConfirm0920( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0920( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0920( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0920( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0920( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0920( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0920( )
      {
         edtNetworkCompanyId_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyId_Enabled), 5, 0), !bGXsfl_167_Refreshing);
         edtNetworkCompanyKvkNumber_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyKvkNumber_Enabled), 5, 0), !bGXsfl_167_Refreshing);
         edtNetworkCompanyEmail_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyEmail_Enabled), 5, 0), !bGXsfl_167_Refreshing);
         edtNetworkCompanyPhone_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyPhone_Enabled), 5, 0), !bGXsfl_167_Refreshing);
         edtNetworkCompanyCountry_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyCountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyCountry_Enabled), 5, 0), !bGXsfl_167_Refreshing);
         edtNetworkCompanyCity_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyCity_Enabled), 5, 0), !bGXsfl_167_Refreshing);
         edtNetworkCompanyZipCode_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyZipCode_Enabled), 5, 0), !bGXsfl_167_Refreshing);
         edtNetworkCompanyAddressLine1_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyAddressLine1_Enabled), 5, 0), !bGXsfl_167_Refreshing);
         edtNetworkCompanyAddressLine2_Enabled = 0;
         AssignProp("", false, edtNetworkCompanyAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyAddressLine2_Enabled), 5, 0), !bGXsfl_167_Refreshing);
      }

      protected void send_integrity_lvl_hashes0920( )
      {
      }

      protected void send_integrity_lvl_hashes0916( )
      {
      }

      protected void SubsflControlProps_15023( )
      {
         edtNetworkIndividualId_Internalname = "NETWORKINDIVIDUALID_"+sGXsfl_150_idx;
         edtNetworkIndividualGivenName_Internalname = "NETWORKINDIVIDUALGIVENNAME_"+sGXsfl_150_idx;
         edtNetworkIndividualLastName_Internalname = "NETWORKINDIVIDUALLASTNAME_"+sGXsfl_150_idx;
         edtNetworkIndividualEmail_Internalname = "NETWORKINDIVIDUALEMAIL_"+sGXsfl_150_idx;
         edtNetworkIndividualPhone_Internalname = "NETWORKINDIVIDUALPHONE_"+sGXsfl_150_idx;
         cmbNetworkIndividualGender_Internalname = "NETWORKINDIVIDUALGENDER_"+sGXsfl_150_idx;
         edtNetworkIndividualCountry_Internalname = "NETWORKINDIVIDUALCOUNTRY_"+sGXsfl_150_idx;
         edtNetworkIndividualCity_Internalname = "NETWORKINDIVIDUALCITY_"+sGXsfl_150_idx;
         edtNetworkIndividualZipCode_Internalname = "NETWORKINDIVIDUALZIPCODE_"+sGXsfl_150_idx;
         edtNetworkIndividualAddressLine1_Internalname = "NETWORKINDIVIDUALADDRESSLINE1_"+sGXsfl_150_idx;
         edtNetworkIndividualAddressLine2_Internalname = "NETWORKINDIVIDUALADDRESSLINE2_"+sGXsfl_150_idx;
      }

      protected void SubsflControlProps_fel_15023( )
      {
         edtNetworkIndividualId_Internalname = "NETWORKINDIVIDUALID_"+sGXsfl_150_fel_idx;
         edtNetworkIndividualGivenName_Internalname = "NETWORKINDIVIDUALGIVENNAME_"+sGXsfl_150_fel_idx;
         edtNetworkIndividualLastName_Internalname = "NETWORKINDIVIDUALLASTNAME_"+sGXsfl_150_fel_idx;
         edtNetworkIndividualEmail_Internalname = "NETWORKINDIVIDUALEMAIL_"+sGXsfl_150_fel_idx;
         edtNetworkIndividualPhone_Internalname = "NETWORKINDIVIDUALPHONE_"+sGXsfl_150_fel_idx;
         cmbNetworkIndividualGender_Internalname = "NETWORKINDIVIDUALGENDER_"+sGXsfl_150_fel_idx;
         edtNetworkIndividualCountry_Internalname = "NETWORKINDIVIDUALCOUNTRY_"+sGXsfl_150_fel_idx;
         edtNetworkIndividualCity_Internalname = "NETWORKINDIVIDUALCITY_"+sGXsfl_150_fel_idx;
         edtNetworkIndividualZipCode_Internalname = "NETWORKINDIVIDUALZIPCODE_"+sGXsfl_150_fel_idx;
         edtNetworkIndividualAddressLine1_Internalname = "NETWORKINDIVIDUALADDRESSLINE1_"+sGXsfl_150_fel_idx;
         edtNetworkIndividualAddressLine2_Internalname = "NETWORKINDIVIDUALADDRESSLINE2_"+sGXsfl_150_fel_idx;
      }

      protected void AddRow0923( )
      {
         nGXsfl_150_idx = (int)(nGXsfl_150_idx+1);
         sGXsfl_150_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_150_idx), 4, 0), 4, "0");
         SubsflControlProps_15023( ) ;
         SendRow0923( ) ;
      }

      protected void SendRow0923( )
      {
         Gridlevel_networkindividualRow = GXWebRow.GetNew(context);
         if ( subGridlevel_networkindividual_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_networkindividual_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_networkindividual_Class, "") != 0 )
            {
               subGridlevel_networkindividual_Linesclass = subGridlevel_networkindividual_Class+"Odd";
            }
         }
         else if ( subGridlevel_networkindividual_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_networkindividual_Backstyle = 0;
            subGridlevel_networkindividual_Backcolor = subGridlevel_networkindividual_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_networkindividual_Class, "") != 0 )
            {
               subGridlevel_networkindividual_Linesclass = subGridlevel_networkindividual_Class+"Uniform";
            }
         }
         else if ( subGridlevel_networkindividual_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_networkindividual_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_networkindividual_Class, "") != 0 )
            {
               subGridlevel_networkindividual_Linesclass = subGridlevel_networkindividual_Class+"Odd";
            }
            subGridlevel_networkindividual_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_networkindividual_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_networkindividual_Backstyle = 1;
            if ( ((int)((nGXsfl_150_idx) % (2))) == 0 )
            {
               subGridlevel_networkindividual_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_networkindividual_Class, "") != 0 )
               {
                  subGridlevel_networkindividual_Linesclass = subGridlevel_networkindividual_Class+"Even";
               }
            }
            else
            {
               subGridlevel_networkindividual_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_networkindividual_Class, "") != 0 )
               {
                  subGridlevel_networkindividual_Linesclass = subGridlevel_networkindividual_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_23_" + sGXsfl_150_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 151,'',false,'" + sGXsfl_150_idx + "',150)\"";
         ROClassString = "Attribute";
         Gridlevel_networkindividualRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkIndividualId_Internalname,A74NetworkIndividualId.ToString(),A74NetworkIndividualId.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNetworkIndividualId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkIndividualId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)150,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_23_" + sGXsfl_150_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 152,'',false,'" + sGXsfl_150_idx + "',150)\"";
         ROClassString = "Attribute";
         Gridlevel_networkindividualRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkIndividualGivenName_Internalname,(string)A76NetworkIndividualGivenName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,152);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNetworkIndividualGivenName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkIndividualGivenName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)150,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_23_" + sGXsfl_150_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 153,'',false,'" + sGXsfl_150_idx + "',150)\"";
         ROClassString = "Attribute";
         Gridlevel_networkindividualRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkIndividualLastName_Internalname,(string)A77NetworkIndividualLastName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,153);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNetworkIndividualLastName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkIndividualLastName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)150,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_23_" + sGXsfl_150_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 154,'',false,'" + sGXsfl_150_idx + "',150)\"";
         ROClassString = "Attribute";
         Gridlevel_networkindividualRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkIndividualEmail_Internalname,(string)A78NetworkIndividualEmail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,154);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A78NetworkIndividualEmail,(string)"",(string)"",(string)"",(string)edtNetworkIndividualEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkIndividualEmail_Enabled,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)150,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A79NetworkIndividualPhone);
         }
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_23_" + sGXsfl_150_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 155,'',false,'" + sGXsfl_150_idx + "',150)\"";
         ROClassString = "Attribute";
         Gridlevel_networkindividualRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkIndividualPhone_Internalname,StringUtil.RTrim( A79NetworkIndividualPhone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,155);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtNetworkIndividualPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkIndividualPhone_Enabled,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)150,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_23_" + sGXsfl_150_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 156,'',false,'" + sGXsfl_150_idx + "',150)\"";
         GXCCtl = "NETWORKINDIVIDUALGENDER_" + sGXsfl_150_idx;
         cmbNetworkIndividualGender.Name = GXCCtl;
         cmbNetworkIndividualGender.WebTags = "";
         cmbNetworkIndividualGender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbNetworkIndividualGender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbNetworkIndividualGender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbNetworkIndividualGender.ItemCount > 0 )
         {
            A81NetworkIndividualGender = cmbNetworkIndividualGender.getValidValue(A81NetworkIndividualGender);
         }
         /* ComboBox */
         Gridlevel_networkindividualRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbNetworkIndividualGender,(string)cmbNetworkIndividualGender_Internalname,StringUtil.RTrim( A81NetworkIndividualGender),(short)1,(string)cmbNetworkIndividualGender_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbNetworkIndividualGender.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,156);\"",(string)"",(bool)true,(short)0});
         cmbNetworkIndividualGender.CurrentValue = StringUtil.RTrim( A81NetworkIndividualGender);
         AssignProp("", false, cmbNetworkIndividualGender_Internalname, "Values", (string)(cmbNetworkIndividualGender.ToJavascriptSource()), !bGXsfl_150_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_23_" + sGXsfl_150_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 157,'',false,'" + sGXsfl_150_idx + "',150)\"";
         ROClassString = "Attribute";
         Gridlevel_networkindividualRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkIndividualCountry_Internalname,(string)A344NetworkIndividualCountry,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,157);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNetworkIndividualCountry_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkIndividualCountry_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)150,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_23_" + sGXsfl_150_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 158,'',false,'" + sGXsfl_150_idx + "',150)\"";
         ROClassString = "Attribute";
         Gridlevel_networkindividualRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkIndividualCity_Internalname,(string)A345NetworkIndividualCity,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,158);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNetworkIndividualCity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkIndividualCity_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)150,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_23_" + sGXsfl_150_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 159,'',false,'" + sGXsfl_150_idx + "',150)\"";
         ROClassString = "Attribute";
         Gridlevel_networkindividualRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkIndividualZipCode_Internalname,(string)A346NetworkIndividualZipCode,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNetworkIndividualZipCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkIndividualZipCode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)150,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_23_" + sGXsfl_150_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 160,'',false,'" + sGXsfl_150_idx + "',150)\"";
         ROClassString = "Attribute";
         Gridlevel_networkindividualRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkIndividualAddressLine1_Internalname,(string)A347NetworkIndividualAddressLine1,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,160);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNetworkIndividualAddressLine1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkIndividualAddressLine1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)150,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_23_" + sGXsfl_150_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 161,'',false,'" + sGXsfl_150_idx + "',150)\"";
         ROClassString = "Attribute";
         Gridlevel_networkindividualRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkIndividualAddressLine2_Internalname,(string)A348NetworkIndividualAddressLine2,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,161);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNetworkIndividualAddressLine2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkIndividualAddressLine2_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)150,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_networkindividualRow);
         send_integrity_lvl_hashes0923( ) ;
         GXCCtl = "Z74NetworkIndividualId_" + sGXsfl_150_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z74NetworkIndividualId.ToString());
         GXCCtl = "nRcdDeleted_23_" + sGXsfl_150_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_23), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_23_" + sGXsfl_150_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_23), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_23_" + sGXsfl_150_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_23), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vAUDITINGOBJECT_" + sGXsfl_150_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV42AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV42AuditingObject);
         }
         GXCCtl = "vPGMNAME_" + sGXsfl_150_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( AV45Pgmname));
         GXCCtl = "vMODE_" + sGXsfl_150_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_150_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV13TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV13TrnContext);
         }
         GXCCtl = "vRESIDENTID_" + sGXsfl_150_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV7ResidentId.ToString());
         GXCCtl = "vLOCATIONID_" + sGXsfl_150_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV8LocationId.ToString());
         GXCCtl = "vORGANISATIONID_" + sGXsfl_150_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV9OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "NETWORKINDIVIDUALID_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKINDIVIDUALGIVENNAME_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualGivenName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKINDIVIDUALLASTNAME_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualLastName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKINDIVIDUALEMAIL_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualEmail_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKINDIVIDUALPHONE_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualPhone_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKINDIVIDUALGENDER_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbNetworkIndividualGender.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKINDIVIDUALCOUNTRY_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualCountry_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKINDIVIDUALCITY_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualCity_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKINDIVIDUALZIPCODE_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualZipCode_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKINDIVIDUALADDRESSLINE1_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualAddressLine1_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKINDIVIDUALADDRESSLINE2_"+sGXsfl_150_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualAddressLine2_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_networkindividualContainer.AddRow(Gridlevel_networkindividualRow);
      }

      protected void ReadRow0923( )
      {
         nGXsfl_150_idx = (int)(nGXsfl_150_idx+1);
         sGXsfl_150_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_150_idx), 4, 0), 4, "0");
         SubsflControlProps_15023( ) ;
         edtNetworkIndividualId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALID_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtNetworkIndividualGivenName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALGIVENNAME_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtNetworkIndividualLastName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALLASTNAME_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtNetworkIndividualEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALEMAIL_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtNetworkIndividualPhone_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALPHONE_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbNetworkIndividualGender.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALGENDER_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtNetworkIndividualCountry_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALCOUNTRY_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtNetworkIndividualCity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALCITY_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtNetworkIndividualZipCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALZIPCODE_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtNetworkIndividualAddressLine1_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALADDRESSLINE1_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtNetworkIndividualAddressLine2_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKINDIVIDUALADDRESSLINE2_"+sGXsfl_150_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( StringUtil.StrCmp(cgiGet( edtNetworkIndividualId_Internalname), "") == 0 )
         {
            A74NetworkIndividualId = Guid.Empty;
         }
         else
         {
            try
            {
               A74NetworkIndividualId = StringUtil.StrToGuid( cgiGet( edtNetworkIndividualId_Internalname));
            }
            catch ( Exception  )
            {
               GXCCtl = "NETWORKINDIVIDUALID_" + sGXsfl_150_idx;
               GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtNetworkIndividualId_Internalname;
               wbErr = true;
            }
         }
         A76NetworkIndividualGivenName = cgiGet( edtNetworkIndividualGivenName_Internalname);
         A77NetworkIndividualLastName = cgiGet( edtNetworkIndividualLastName_Internalname);
         A78NetworkIndividualEmail = cgiGet( edtNetworkIndividualEmail_Internalname);
         A79NetworkIndividualPhone = cgiGet( edtNetworkIndividualPhone_Internalname);
         cmbNetworkIndividualGender.Name = cmbNetworkIndividualGender_Internalname;
         cmbNetworkIndividualGender.CurrentValue = cgiGet( cmbNetworkIndividualGender_Internalname);
         A81NetworkIndividualGender = cgiGet( cmbNetworkIndividualGender_Internalname);
         A344NetworkIndividualCountry = cgiGet( edtNetworkIndividualCountry_Internalname);
         A345NetworkIndividualCity = cgiGet( edtNetworkIndividualCity_Internalname);
         A346NetworkIndividualZipCode = cgiGet( edtNetworkIndividualZipCode_Internalname);
         A347NetworkIndividualAddressLine1 = cgiGet( edtNetworkIndividualAddressLine1_Internalname);
         A348NetworkIndividualAddressLine2 = cgiGet( edtNetworkIndividualAddressLine2_Internalname);
         GXCCtl = "Z74NetworkIndividualId_" + sGXsfl_150_idx;
         Z74NetworkIndividualId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "nRcdDeleted_23_" + sGXsfl_150_idx;
         nRcdDeleted_23 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_23_" + sGXsfl_150_idx;
         nRcdExists_23 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_23_" + sGXsfl_150_idx;
         nIsMod_23 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_16720( )
      {
         edtNetworkCompanyId_Internalname = "NETWORKCOMPANYID_"+sGXsfl_167_idx;
         edtNetworkCompanyKvkNumber_Internalname = "NETWORKCOMPANYKVKNUMBER_"+sGXsfl_167_idx;
         edtNetworkCompanyEmail_Internalname = "NETWORKCOMPANYEMAIL_"+sGXsfl_167_idx;
         edtNetworkCompanyPhone_Internalname = "NETWORKCOMPANYPHONE_"+sGXsfl_167_idx;
         edtNetworkCompanyCountry_Internalname = "NETWORKCOMPANYCOUNTRY_"+sGXsfl_167_idx;
         edtNetworkCompanyCity_Internalname = "NETWORKCOMPANYCITY_"+sGXsfl_167_idx;
         edtNetworkCompanyZipCode_Internalname = "NETWORKCOMPANYZIPCODE_"+sGXsfl_167_idx;
         edtNetworkCompanyAddressLine1_Internalname = "NETWORKCOMPANYADDRESSLINE1_"+sGXsfl_167_idx;
         edtNetworkCompanyAddressLine2_Internalname = "NETWORKCOMPANYADDRESSLINE2_"+sGXsfl_167_idx;
      }

      protected void SubsflControlProps_fel_16720( )
      {
         edtNetworkCompanyId_Internalname = "NETWORKCOMPANYID_"+sGXsfl_167_fel_idx;
         edtNetworkCompanyKvkNumber_Internalname = "NETWORKCOMPANYKVKNUMBER_"+sGXsfl_167_fel_idx;
         edtNetworkCompanyEmail_Internalname = "NETWORKCOMPANYEMAIL_"+sGXsfl_167_fel_idx;
         edtNetworkCompanyPhone_Internalname = "NETWORKCOMPANYPHONE_"+sGXsfl_167_fel_idx;
         edtNetworkCompanyCountry_Internalname = "NETWORKCOMPANYCOUNTRY_"+sGXsfl_167_fel_idx;
         edtNetworkCompanyCity_Internalname = "NETWORKCOMPANYCITY_"+sGXsfl_167_fel_idx;
         edtNetworkCompanyZipCode_Internalname = "NETWORKCOMPANYZIPCODE_"+sGXsfl_167_fel_idx;
         edtNetworkCompanyAddressLine1_Internalname = "NETWORKCOMPANYADDRESSLINE1_"+sGXsfl_167_fel_idx;
         edtNetworkCompanyAddressLine2_Internalname = "NETWORKCOMPANYADDRESSLINE2_"+sGXsfl_167_fel_idx;
      }

      protected void AddRow0920( )
      {
         nGXsfl_167_idx = (int)(nGXsfl_167_idx+1);
         sGXsfl_167_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_167_idx), 4, 0), 4, "0");
         SubsflControlProps_16720( ) ;
         SendRow0920( ) ;
      }

      protected void SendRow0920( )
      {
         Gridlevel_networkcompanyRow = GXWebRow.GetNew(context);
         if ( subGridlevel_networkcompany_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_networkcompany_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_networkcompany_Class, "") != 0 )
            {
               subGridlevel_networkcompany_Linesclass = subGridlevel_networkcompany_Class+"Odd";
            }
         }
         else if ( subGridlevel_networkcompany_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_networkcompany_Backstyle = 0;
            subGridlevel_networkcompany_Backcolor = subGridlevel_networkcompany_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_networkcompany_Class, "") != 0 )
            {
               subGridlevel_networkcompany_Linesclass = subGridlevel_networkcompany_Class+"Uniform";
            }
         }
         else if ( subGridlevel_networkcompany_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_networkcompany_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_networkcompany_Class, "") != 0 )
            {
               subGridlevel_networkcompany_Linesclass = subGridlevel_networkcompany_Class+"Odd";
            }
            subGridlevel_networkcompany_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_networkcompany_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_networkcompany_Backstyle = 1;
            if ( ((int)((nGXsfl_167_idx) % (2))) == 0 )
            {
               subGridlevel_networkcompany_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_networkcompany_Class, "") != 0 )
               {
                  subGridlevel_networkcompany_Linesclass = subGridlevel_networkcompany_Class+"Even";
               }
            }
            else
            {
               subGridlevel_networkcompany_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_networkcompany_Class, "") != 0 )
               {
                  subGridlevel_networkcompany_Linesclass = subGridlevel_networkcompany_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_20_" + sGXsfl_167_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 168,'',false,'" + sGXsfl_167_idx + "',167)\"";
         ROClassString = "Attribute";
         Gridlevel_networkcompanyRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkCompanyId_Internalname,A82NetworkCompanyId.ToString(),A82NetworkCompanyId.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,168);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNetworkCompanyId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkCompanyId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)167,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_20_" + sGXsfl_167_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 169,'',false,'" + sGXsfl_167_idx + "',167)\"";
         ROClassString = "Attribute";
         Gridlevel_networkcompanyRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkCompanyKvkNumber_Internalname,(string)A83NetworkCompanyKvkNumber,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNetworkCompanyKvkNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkCompanyKvkNumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)167,(short)0,(short)-1,(short)-1,(bool)true,(string)"KvkNumber",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_20_" + sGXsfl_167_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 170,'',false,'" + sGXsfl_167_idx + "',167)\"";
         ROClassString = "Attribute";
         Gridlevel_networkcompanyRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkCompanyEmail_Internalname,(string)A85NetworkCompanyEmail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,170);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A85NetworkCompanyEmail,(string)"",(string)"",(string)"",(string)edtNetworkCompanyEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkCompanyEmail_Enabled,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)167,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A86NetworkCompanyPhone);
         }
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_20_" + sGXsfl_167_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 171,'',false,'" + sGXsfl_167_idx + "',167)\"";
         ROClassString = "Attribute";
         Gridlevel_networkcompanyRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkCompanyPhone_Internalname,StringUtil.RTrim( A86NetworkCompanyPhone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,171);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtNetworkCompanyPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkCompanyPhone_Enabled,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)167,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_20_" + sGXsfl_167_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 172,'',false,'" + sGXsfl_167_idx + "',167)\"";
         ROClassString = "Attribute";
         Gridlevel_networkcompanyRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkCompanyCountry_Internalname,(string)A349NetworkCompanyCountry,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,172);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNetworkCompanyCountry_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkCompanyCountry_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)167,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_20_" + sGXsfl_167_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 173,'',false,'" + sGXsfl_167_idx + "',167)\"";
         ROClassString = "Attribute";
         Gridlevel_networkcompanyRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkCompanyCity_Internalname,(string)A350NetworkCompanyCity,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,173);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNetworkCompanyCity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkCompanyCity_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)167,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_20_" + sGXsfl_167_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 174,'',false,'" + sGXsfl_167_idx + "',167)\"";
         ROClassString = "Attribute";
         Gridlevel_networkcompanyRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkCompanyZipCode_Internalname,(string)A351NetworkCompanyZipCode,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,174);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNetworkCompanyZipCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkCompanyZipCode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)167,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_20_" + sGXsfl_167_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 175,'',false,'" + sGXsfl_167_idx + "',167)\"";
         ROClassString = "Attribute";
         Gridlevel_networkcompanyRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkCompanyAddressLine1_Internalname,(string)A352NetworkCompanyAddressLine1,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,175);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNetworkCompanyAddressLine1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkCompanyAddressLine1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)167,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_20_" + sGXsfl_167_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 176,'',false,'" + sGXsfl_167_idx + "',167)\"";
         ROClassString = "Attribute";
         Gridlevel_networkcompanyRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNetworkCompanyAddressLine2_Internalname,(string)A353NetworkCompanyAddressLine2,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,176);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNetworkCompanyAddressLine2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNetworkCompanyAddressLine2_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)167,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_networkcompanyRow);
         send_integrity_lvl_hashes0920( ) ;
         GXCCtl = "Z82NetworkCompanyId_" + sGXsfl_167_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z82NetworkCompanyId.ToString());
         GXCCtl = "nRcdDeleted_20_" + sGXsfl_167_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_20), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_20_" + sGXsfl_167_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_20), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_20_" + sGXsfl_167_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_20), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vAUDITINGOBJECT_" + sGXsfl_167_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV42AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV42AuditingObject);
         }
         GXCCtl = "vPGMNAME_" + sGXsfl_167_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( AV45Pgmname));
         GXCCtl = "vMODE_" + sGXsfl_167_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_167_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV13TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV13TrnContext);
         }
         GXCCtl = "vRESIDENTID_" + sGXsfl_167_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV7ResidentId.ToString());
         GXCCtl = "vLOCATIONID_" + sGXsfl_167_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV8LocationId.ToString());
         GXCCtl = "vORGANISATIONID_" + sGXsfl_167_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV9OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "NETWORKCOMPANYID_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKCOMPANYKVKNUMBER_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyKvkNumber_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKCOMPANYEMAIL_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyEmail_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKCOMPANYPHONE_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyPhone_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKCOMPANYCOUNTRY_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyCountry_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKCOMPANYCITY_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyCity_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKCOMPANYZIPCODE_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyZipCode_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKCOMPANYADDRESSLINE1_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyAddressLine1_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NETWORKCOMPANYADDRESSLINE2_"+sGXsfl_167_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyAddressLine2_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_networkcompanyContainer.AddRow(Gridlevel_networkcompanyRow);
      }

      protected void ReadRow0920( )
      {
         nGXsfl_167_idx = (int)(nGXsfl_167_idx+1);
         sGXsfl_167_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_167_idx), 4, 0), 4, "0");
         SubsflControlProps_16720( ) ;
         edtNetworkCompanyId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYID_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtNetworkCompanyKvkNumber_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYKVKNUMBER_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtNetworkCompanyEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYEMAIL_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtNetworkCompanyPhone_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYPHONE_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtNetworkCompanyCountry_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYCOUNTRY_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtNetworkCompanyCity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYCITY_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtNetworkCompanyZipCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYZIPCODE_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtNetworkCompanyAddressLine1_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYADDRESSLINE1_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtNetworkCompanyAddressLine2_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NETWORKCOMPANYADDRESSLINE2_"+sGXsfl_167_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( StringUtil.StrCmp(cgiGet( edtNetworkCompanyId_Internalname), "") == 0 )
         {
            A82NetworkCompanyId = Guid.Empty;
         }
         else
         {
            try
            {
               A82NetworkCompanyId = StringUtil.StrToGuid( cgiGet( edtNetworkCompanyId_Internalname));
            }
            catch ( Exception  )
            {
               GXCCtl = "NETWORKCOMPANYID_" + sGXsfl_167_idx;
               GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtNetworkCompanyId_Internalname;
               wbErr = true;
            }
         }
         A83NetworkCompanyKvkNumber = cgiGet( edtNetworkCompanyKvkNumber_Internalname);
         A85NetworkCompanyEmail = cgiGet( edtNetworkCompanyEmail_Internalname);
         A86NetworkCompanyPhone = cgiGet( edtNetworkCompanyPhone_Internalname);
         A349NetworkCompanyCountry = cgiGet( edtNetworkCompanyCountry_Internalname);
         A350NetworkCompanyCity = cgiGet( edtNetworkCompanyCity_Internalname);
         A351NetworkCompanyZipCode = cgiGet( edtNetworkCompanyZipCode_Internalname);
         A352NetworkCompanyAddressLine1 = cgiGet( edtNetworkCompanyAddressLine1_Internalname);
         A353NetworkCompanyAddressLine2 = cgiGet( edtNetworkCompanyAddressLine2_Internalname);
         GXCCtl = "Z82NetworkCompanyId_" + sGXsfl_167_idx;
         Z82NetworkCompanyId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "nRcdDeleted_20_" + sGXsfl_167_idx;
         nRcdDeleted_20 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_20_" + sGXsfl_167_idx;
         nRcdExists_20 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_20_" + sGXsfl_167_idx;
         nIsMod_20 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtNetworkCompanyId_Enabled = edtNetworkCompanyId_Enabled;
         defedtNetworkIndividualId_Enabled = edtNetworkIndividualId_Enabled;
      }

      protected void ConfirmValues090( )
      {
         nGXsfl_150_idx = 0;
         sGXsfl_150_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_150_idx), 4, 0), 4, "0");
         SubsflControlProps_15023( ) ;
         while ( nGXsfl_150_idx < nRC_GXsfl_150 )
         {
            nGXsfl_150_idx = (int)(nGXsfl_150_idx+1);
            sGXsfl_150_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_150_idx), 4, 0), 4, "0");
            SubsflControlProps_15023( ) ;
            ChangePostValue( "Z74NetworkIndividualId_"+sGXsfl_150_idx, cgiGet( "ZT_"+"Z74NetworkIndividualId_"+sGXsfl_150_idx)) ;
            DeletePostValue( "ZT_"+"Z74NetworkIndividualId_"+sGXsfl_150_idx) ;
         }
         nGXsfl_167_idx = 0;
         sGXsfl_167_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_167_idx), 4, 0), 4, "0");
         SubsflControlProps_16720( ) ;
         while ( nGXsfl_167_idx < nRC_GXsfl_167 )
         {
            nGXsfl_167_idx = (int)(nGXsfl_167_idx+1);
            sGXsfl_167_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_167_idx), 4, 0), 4, "0");
            SubsflControlProps_16720( ) ;
            ChangePostValue( "Z82NetworkCompanyId_"+sGXsfl_167_idx, cgiGet( "ZT_"+"Z82NetworkCompanyId_"+sGXsfl_167_idx)) ;
            DeletePostValue( "ZT_"+"Z82NetworkCompanyId_"+sGXsfl_167_idx) ;
         }
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_resident.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(AV7ResidentId.ToString()),UrlEncode(AV8LocationId.ToString()),UrlEncode(AV9OrganisationId.ToString())}, new string[] {"Gx_mode","ResidentId","LocationId","OrganisationId"}) +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Resident");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV45Pgmname, "")));
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
         GxWebStd.gx_hidden_field( context, "Z375ResidentPhoneCode", Z375ResidentPhoneCode);
         GxWebStd.gx_hidden_field( context, "Z445ResidentHomePhoneCode", Z445ResidentHomePhoneCode);
         GxWebStd.gx_hidden_field( context, "Z71ResidentGUID", Z71ResidentGUID);
         GxWebStd.gx_hidden_field( context, "Z66ResidentInitials", StringUtil.RTrim( Z66ResidentInitials));
         GxWebStd.gx_hidden_field( context, "Z70ResidentPhone", StringUtil.RTrim( Z70ResidentPhone));
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
         GxWebStd.gx_hidden_field( context, "Z444ResidentHomePhone", StringUtil.RTrim( Z444ResidentHomePhone));
         GxWebStd.gx_hidden_field( context, "Z73ResidentBirthDate", context.localUtil.DToC( Z73ResidentBirthDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z376ResidentPhoneNumber", Z376ResidentPhoneNumber);
         GxWebStd.gx_hidden_field( context, "Z446ResidentHomePhoneNumber", Z446ResidentHomePhoneNumber);
         GxWebStd.gx_hidden_field( context, "Z96ResidentTypeId", Z96ResidentTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "Z98MedicalIndicationId", Z98MedicalIndicationId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_150", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_150_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_167", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_167_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRESIDENTTYPEID_DATA", AV31ResidentTypeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRESIDENTTYPEID_DATA", AV31ResidentTypeId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMEDICALINDICATIONID_DATA", AV33MedicalIndicationId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMEDICALINDICATIONID_DATA", AV33MedicalIndicationId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRESIDENTCOUNTRY_DATA", AV37ResidentCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRESIDENTCOUNTRY_DATA", AV37ResidentCountry_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNETWORKINDIVIDUALID_DATA", AV25NetworkIndividualId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNETWORKINDIVIDUALID_DATA", AV25NetworkIndividualId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNETWORKCOMPANYID_DATA", AV18NetworkCompanyId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNETWORKCOMPANYID_DATA", AV18NetworkCompanyId_Data);
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV42AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV42AuditingObject);
         }
         GxWebStd.gx_hidden_field( context, "vGAMERRORRESPONSE", AV36GAMErrorResponse);
         GxWebStd.gx_hidden_field( context, "RESIDENTTYPENAME", A97ResidentTypeName);
         GxWebStd.gx_hidden_field( context, "MEDICALINDICATIONNAME", A99MedicalIndicationName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV45Pgmname));
         GxWebStd.gx_hidden_field( context, "NETWORKINDIVIDUALBSNNUMBER", A75NetworkIndividualBsnNumber);
         GxWebStd.gx_hidden_field( context, "NETWORKINDIVIDUALPHONENUMBER", A388NetworkIndividualPhoneNumber);
         GxWebStd.gx_hidden_field( context, "NETWORKINDIVIDUALPHONECODE", A387NetworkIndividualPhoneCode);
         GxWebStd.gx_hidden_field( context, "NETWORKCOMPANYNAME", A84NetworkCompanyName);
         GxWebStd.gx_hidden_field( context, "NETWORKCOMPANYPHONENUMBER", A392NetworkCompanyPhoneNumber);
         GxWebStd.gx_hidden_field( context, "NETWORKCOMPANYPHONECODE", A391NetworkCompanyPhoneCode);
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Objectcall", StringUtil.RTrim( Combo_residentphonecode_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Cls", StringUtil.RTrim( Combo_residentphonecode_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Selectedvalue_set", StringUtil.RTrim( Combo_residentphonecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Enabled", StringUtil.BoolToStr( Combo_residentphonecode_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Emptyitem", StringUtil.BoolToStr( Combo_residentphonecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTPHONECODE_Htmltemplate", StringUtil.RTrim( Combo_residentphonecode_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Objectcall", StringUtil.RTrim( Combo_residenthomephonecode_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Cls", StringUtil.RTrim( Combo_residenthomephonecode_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Selectedvalue_set", StringUtil.RTrim( Combo_residenthomephonecode_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Enabled", StringUtil.BoolToStr( Combo_residenthomephonecode_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Emptyitem", StringUtil.BoolToStr( Combo_residenthomephonecode_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTHOMEPHONECODE_Htmltemplate", StringUtil.RTrim( Combo_residenthomephonecode_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Objectcall", StringUtil.RTrim( Combo_residenttypeid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Cls", StringUtil.RTrim( Combo_residenttypeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Selectedvalue_set", StringUtil.RTrim( Combo_residenttypeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Selectedtext_set", StringUtil.RTrim( Combo_residenttypeid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Gamoauthtoken", StringUtil.RTrim( Combo_residenttypeid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Enabled", StringUtil.BoolToStr( Combo_residenttypeid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Datalistproc", StringUtil.RTrim( Combo_residenttypeid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_residenttypeid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Emptyitem", StringUtil.BoolToStr( Combo_residenttypeid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_MEDICALINDICATIONID_Objectcall", StringUtil.RTrim( Combo_medicalindicationid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_MEDICALINDICATIONID_Cls", StringUtil.RTrim( Combo_medicalindicationid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MEDICALINDICATIONID_Selectedvalue_set", StringUtil.RTrim( Combo_medicalindicationid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MEDICALINDICATIONID_Selectedtext_set", StringUtil.RTrim( Combo_medicalindicationid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MEDICALINDICATIONID_Gamoauthtoken", StringUtil.RTrim( Combo_medicalindicationid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_MEDICALINDICATIONID_Enabled", StringUtil.BoolToStr( Combo_medicalindicationid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_MEDICALINDICATIONID_Datalistproc", StringUtil.RTrim( Combo_medicalindicationid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_MEDICALINDICATIONID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_medicalindicationid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Objectcall", StringUtil.RTrim( Combo_residentcountry_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Cls", StringUtil.RTrim( Combo_residentcountry_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Selectedvalue_set", StringUtil.RTrim( Combo_residentcountry_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Enabled", StringUtil.BoolToStr( Combo_residentcountry_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Emptyitem", StringUtil.BoolToStr( Combo_residentcountry_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTCOUNTRY_Htmltemplate", StringUtil.RTrim( Combo_residentcountry_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALID_Objectcall", StringUtil.RTrim( Combo_networkindividualid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALID_Cls", StringUtil.RTrim( Combo_networkindividualid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALID_Gamoauthtoken", StringUtil.RTrim( Combo_networkindividualid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALID_Enabled", StringUtil.BoolToStr( Combo_networkindividualid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALID_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_networkindividualid_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALID_Isgriditem", StringUtil.BoolToStr( Combo_networkindividualid_Isgriditem));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALID_Hasdescription", StringUtil.BoolToStr( Combo_networkindividualid_Hasdescription));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALID_Datalistproc", StringUtil.RTrim( Combo_networkindividualid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_networkindividualid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKINDIVIDUALID_Emptyitem", StringUtil.BoolToStr( Combo_networkindividualid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKCOMPANYID_Objectcall", StringUtil.RTrim( Combo_networkcompanyid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKCOMPANYID_Cls", StringUtil.RTrim( Combo_networkcompanyid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKCOMPANYID_Gamoauthtoken", StringUtil.RTrim( Combo_networkcompanyid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKCOMPANYID_Enabled", StringUtil.BoolToStr( Combo_networkcompanyid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKCOMPANYID_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_networkcompanyid_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKCOMPANYID_Isgriditem", StringUtil.BoolToStr( Combo_networkcompanyid_Isgriditem));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKCOMPANYID_Hasdescription", StringUtil.BoolToStr( Combo_networkcompanyid_Hasdescription));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKCOMPANYID_Datalistproc", StringUtil.RTrim( Combo_networkcompanyid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKCOMPANYID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_networkcompanyid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_NETWORKCOMPANYID_Emptyitem", StringUtil.BoolToStr( Combo_networkcompanyid_Emptyitem));
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
         return formatLink("trn_resident.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(AV7ResidentId.ToString()),UrlEncode(AV8LocationId.ToString()),UrlEncode(AV9OrganisationId.ToString())}, new string[] {"Gx_mode","ResidentId","LocationId","OrganisationId"})  ;
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
         AssignAttri("", false, "A96ResidentTypeId", A96ResidentTypeId.ToString());
         A98MedicalIndicationId = Guid.Empty;
         n98MedicalIndicationId = false;
         AssignAttri("", false, "A98MedicalIndicationId", A98MedicalIndicationId.ToString());
         n98MedicalIndicationId = ((Guid.Empty==A98MedicalIndicationId) ? true : false);
         A354ResidentCountry = "";
         AssignAttri("", false, "A354ResidentCountry", A354ResidentCountry);
         A375ResidentPhoneCode = "";
         AssignAttri("", false, "A375ResidentPhoneCode", A375ResidentPhoneCode);
         A445ResidentHomePhoneCode = "";
         AssignAttri("", false, "A445ResidentHomePhoneCode", A445ResidentHomePhoneCode);
         AV42AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A71ResidentGUID = "";
         AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
         A66ResidentInitials = "";
         AssignAttri("", false, "A66ResidentInitials", A66ResidentInitials);
         AV36GAMErrorResponse = "";
         AssignAttri("", false, "AV36GAMErrorResponse", AV36GAMErrorResponse);
         A70ResidentPhone = "";
         AssignAttri("", false, "A70ResidentPhone", A70ResidentPhone);
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
         A444ResidentHomePhone = "";
         AssignAttri("", false, "A444ResidentHomePhone", A444ResidentHomePhone);
         A73ResidentBirthDate = DateTime.MinValue;
         AssignAttri("", false, "A73ResidentBirthDate", context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"));
         A97ResidentTypeName = "";
         AssignAttri("", false, "A97ResidentTypeName", A97ResidentTypeName);
         A99MedicalIndicationName = "";
         AssignAttri("", false, "A99MedicalIndicationName", A99MedicalIndicationName);
         A376ResidentPhoneNumber = "";
         AssignAttri("", false, "A376ResidentPhoneNumber", A376ResidentPhoneNumber);
         A446ResidentHomePhoneNumber = "";
         AssignAttri("", false, "A446ResidentHomePhoneNumber", A446ResidentHomePhoneNumber);
         Z354ResidentCountry = "";
         Z375ResidentPhoneCode = "";
         Z445ResidentHomePhoneCode = "";
         Z71ResidentGUID = "";
         Z66ResidentInitials = "";
         Z70ResidentPhone = "";
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
         Z444ResidentHomePhone = "";
         Z73ResidentBirthDate = DateTime.MinValue;
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

      protected void InitializeNonKey0923( )
      {
         A75NetworkIndividualBsnNumber = "";
         AssignAttri("", false, "A75NetworkIndividualBsnNumber", A75NetworkIndividualBsnNumber);
         A76NetworkIndividualGivenName = "";
         A77NetworkIndividualLastName = "";
         A78NetworkIndividualEmail = "";
         A79NetworkIndividualPhone = "";
         A388NetworkIndividualPhoneNumber = "";
         AssignAttri("", false, "A388NetworkIndividualPhoneNumber", A388NetworkIndividualPhoneNumber);
         A387NetworkIndividualPhoneCode = "";
         AssignAttri("", false, "A387NetworkIndividualPhoneCode", A387NetworkIndividualPhoneCode);
         A81NetworkIndividualGender = "";
         A344NetworkIndividualCountry = "";
         A345NetworkIndividualCity = "";
         A346NetworkIndividualZipCode = "";
         A347NetworkIndividualAddressLine1 = "";
         A348NetworkIndividualAddressLine2 = "";
      }

      protected void InitAll0923( )
      {
         A74NetworkIndividualId = Guid.Empty;
         InitializeNonKey0923( ) ;
      }

      protected void StandaloneModalInsert0923( )
      {
      }

      protected void InitializeNonKey0920( )
      {
         A83NetworkCompanyKvkNumber = "";
         A84NetworkCompanyName = "";
         AssignAttri("", false, "A84NetworkCompanyName", A84NetworkCompanyName);
         A85NetworkCompanyEmail = "";
         A86NetworkCompanyPhone = "";
         A392NetworkCompanyPhoneNumber = "";
         AssignAttri("", false, "A392NetworkCompanyPhoneNumber", A392NetworkCompanyPhoneNumber);
         A391NetworkCompanyPhoneCode = "";
         AssignAttri("", false, "A391NetworkCompanyPhoneCode", A391NetworkCompanyPhoneCode);
         A349NetworkCompanyCountry = "";
         A350NetworkCompanyCity = "";
         A351NetworkCompanyZipCode = "";
         A352NetworkCompanyAddressLine1 = "";
         A353NetworkCompanyAddressLine2 = "";
      }

      protected void InitAll0920( )
      {
         A82NetworkCompanyId = Guid.Empty;
         InitializeNonKey0920( ) ;
      }

      protected void StandaloneModalInsert0920( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024112914292825", true, true);
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
         context.AddJavascriptSource("trn_resident.js", "?2024112914292829", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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

      protected void init_level_properties23( )
      {
         edtNetworkIndividualId_Enabled = defedtNetworkIndividualId_Enabled;
         AssignProp("", false, edtNetworkIndividualId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkIndividualId_Enabled), 5, 0), !bGXsfl_150_Refreshing);
      }

      protected void init_level_properties20( )
      {
         edtNetworkCompanyId_Enabled = defedtNetworkCompanyId_Enabled;
         AssignProp("", false, edtNetworkCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNetworkCompanyId_Enabled), 5, 0), !bGXsfl_167_Refreshing);
      }

      protected void StartGridControl150( )
      {
         Gridlevel_networkindividualContainer.AddObjectProperty("GridName", "Gridlevel_networkindividual");
         Gridlevel_networkindividualContainer.AddObjectProperty("Header", subGridlevel_networkindividual_Header);
         Gridlevel_networkindividualContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_networkindividualContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_networkindividual_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_networkindividualContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_networkindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A74NetworkIndividualId.ToString()));
         Gridlevel_networkindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualId_Enabled), 5, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddColumnProperties(Gridlevel_networkindividualColumn);
         Gridlevel_networkindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A76NetworkIndividualGivenName));
         Gridlevel_networkindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualGivenName_Enabled), 5, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddColumnProperties(Gridlevel_networkindividualColumn);
         Gridlevel_networkindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A77NetworkIndividualLastName));
         Gridlevel_networkindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualLastName_Enabled), 5, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddColumnProperties(Gridlevel_networkindividualColumn);
         Gridlevel_networkindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A78NetworkIndividualEmail));
         Gridlevel_networkindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualEmail_Enabled), 5, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddColumnProperties(Gridlevel_networkindividualColumn);
         Gridlevel_networkindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A79NetworkIndividualPhone)));
         Gridlevel_networkindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualPhone_Enabled), 5, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddColumnProperties(Gridlevel_networkindividualColumn);
         Gridlevel_networkindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A81NetworkIndividualGender));
         Gridlevel_networkindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbNetworkIndividualGender.Enabled), 5, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddColumnProperties(Gridlevel_networkindividualColumn);
         Gridlevel_networkindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A344NetworkIndividualCountry));
         Gridlevel_networkindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualCountry_Enabled), 5, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddColumnProperties(Gridlevel_networkindividualColumn);
         Gridlevel_networkindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A345NetworkIndividualCity));
         Gridlevel_networkindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualCity_Enabled), 5, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddColumnProperties(Gridlevel_networkindividualColumn);
         Gridlevel_networkindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A346NetworkIndividualZipCode));
         Gridlevel_networkindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualZipCode_Enabled), 5, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddColumnProperties(Gridlevel_networkindividualColumn);
         Gridlevel_networkindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A347NetworkIndividualAddressLine1));
         Gridlevel_networkindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualAddressLine1_Enabled), 5, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddColumnProperties(Gridlevel_networkindividualColumn);
         Gridlevel_networkindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A348NetworkIndividualAddressLine2));
         Gridlevel_networkindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkIndividualAddressLine2_Enabled), 5, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddColumnProperties(Gridlevel_networkindividualColumn);
         Gridlevel_networkindividualContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_networkindividual_Selectedindex), 4, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_networkindividual_Allowselection), 1, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_networkindividual_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_networkindividual_Allowhovering), 1, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_networkindividual_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_networkindividual_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_networkindividualContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_networkindividual_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl167( )
      {
         Gridlevel_networkcompanyContainer.AddObjectProperty("GridName", "Gridlevel_networkcompany");
         Gridlevel_networkcompanyContainer.AddObjectProperty("Header", subGridlevel_networkcompany_Header);
         Gridlevel_networkcompanyContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_networkcompanyContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_networkcompany_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_networkcompanyContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_networkcompanyColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A82NetworkCompanyId.ToString()));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyId_Enabled), 5, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddColumnProperties(Gridlevel_networkcompanyColumn);
         Gridlevel_networkcompanyColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A83NetworkCompanyKvkNumber));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyKvkNumber_Enabled), 5, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddColumnProperties(Gridlevel_networkcompanyColumn);
         Gridlevel_networkcompanyColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A85NetworkCompanyEmail));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyEmail_Enabled), 5, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddColumnProperties(Gridlevel_networkcompanyColumn);
         Gridlevel_networkcompanyColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A86NetworkCompanyPhone)));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyPhone_Enabled), 5, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddColumnProperties(Gridlevel_networkcompanyColumn);
         Gridlevel_networkcompanyColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A349NetworkCompanyCountry));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyCountry_Enabled), 5, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddColumnProperties(Gridlevel_networkcompanyColumn);
         Gridlevel_networkcompanyColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A350NetworkCompanyCity));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyCity_Enabled), 5, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddColumnProperties(Gridlevel_networkcompanyColumn);
         Gridlevel_networkcompanyColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A351NetworkCompanyZipCode));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyZipCode_Enabled), 5, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddColumnProperties(Gridlevel_networkcompanyColumn);
         Gridlevel_networkcompanyColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A352NetworkCompanyAddressLine1));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyAddressLine1_Enabled), 5, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddColumnProperties(Gridlevel_networkcompanyColumn);
         Gridlevel_networkcompanyColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A353NetworkCompanyAddressLine2));
         Gridlevel_networkcompanyColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNetworkCompanyAddressLine2_Enabled), 5, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddColumnProperties(Gridlevel_networkcompanyColumn);
         Gridlevel_networkcompanyContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_networkcompany_Selectedindex), 4, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_networkcompany_Allowselection), 1, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_networkcompany_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_networkcompany_Allowhovering), 1, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_networkcompany_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_networkcompany_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_networkcompanyContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_networkcompany_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtResidentBsnNumber_Internalname = "RESIDENTBSNNUMBER";
         cmbResidentSalutation_Internalname = "RESIDENTSALUTATION";
         edtResidentGivenName_Internalname = "RESIDENTGIVENNAME";
         edtResidentLastName_Internalname = "RESIDENTLASTNAME";
         cmbResidentGender_Internalname = "RESIDENTGENDER";
         edtResidentBirthDate_Internalname = "RESIDENTBIRTHDATE";
         edtResidentEmail_Internalname = "RESIDENTEMAIL";
         lblTextblockresidentphonecode_Internalname = "TEXTBLOCKRESIDENTPHONECODE";
         Combo_residentphonecode_Internalname = "COMBO_RESIDENTPHONECODE";
         edtResidentPhoneCode_Internalname = "RESIDENTPHONECODE";
         edtResidentPhoneNumber_Internalname = "RESIDENTPHONENUMBER";
         tblTablemergedresidentphonecode_Internalname = "TABLEMERGEDRESIDENTPHONECODE";
         divTablesplittedresidentphonecode_Internalname = "TABLESPLITTEDRESIDENTPHONECODE";
         lblTextblockresidenthomephonecode_Internalname = "TEXTBLOCKRESIDENTHOMEPHONECODE";
         Combo_residenthomephonecode_Internalname = "COMBO_RESIDENTHOMEPHONECODE";
         edtResidentHomePhoneCode_Internalname = "RESIDENTHOMEPHONECODE";
         edtResidentHomePhoneNumber_Internalname = "RESIDENTHOMEPHONENUMBER";
         tblTablemergedresidenthomephonecode_Internalname = "TABLEMERGEDRESIDENTHOMEPHONECODE";
         divTablesplittedresidenthomephonecode_Internalname = "TABLESPLITTEDRESIDENTHOMEPHONECODE";
         lblTextblockresidenttypeid_Internalname = "TEXTBLOCKRESIDENTTYPEID";
         Combo_residenttypeid_Internalname = "COMBO_RESIDENTTYPEID";
         edtResidentTypeId_Internalname = "RESIDENTTYPEID";
         divTablesplittedresidenttypeid_Internalname = "TABLESPLITTEDRESIDENTTYPEID";
         lblTextblockmedicalindicationid_Internalname = "TEXTBLOCKMEDICALINDICATIONID";
         Combo_medicalindicationid_Internalname = "COMBO_MEDICALINDICATIONID";
         edtMedicalIndicationId_Internalname = "MEDICALINDICATIONID";
         divTablesplittedmedicalindicationid_Internalname = "TABLESPLITTEDMEDICALINDICATIONID";
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
         edtNetworkIndividualId_Internalname = "NETWORKINDIVIDUALID";
         edtNetworkIndividualGivenName_Internalname = "NETWORKINDIVIDUALGIVENNAME";
         edtNetworkIndividualLastName_Internalname = "NETWORKINDIVIDUALLASTNAME";
         edtNetworkIndividualEmail_Internalname = "NETWORKINDIVIDUALEMAIL";
         edtNetworkIndividualPhone_Internalname = "NETWORKINDIVIDUALPHONE";
         cmbNetworkIndividualGender_Internalname = "NETWORKINDIVIDUALGENDER";
         edtNetworkIndividualCountry_Internalname = "NETWORKINDIVIDUALCOUNTRY";
         edtNetworkIndividualCity_Internalname = "NETWORKINDIVIDUALCITY";
         edtNetworkIndividualZipCode_Internalname = "NETWORKINDIVIDUALZIPCODE";
         edtNetworkIndividualAddressLine1_Internalname = "NETWORKINDIVIDUALADDRESSLINE1";
         edtNetworkIndividualAddressLine2_Internalname = "NETWORKINDIVIDUALADDRESSLINE2";
         divTableleaflevel_networkindividual_Internalname = "TABLELEAFLEVEL_NETWORKINDIVIDUAL";
         edtNetworkCompanyId_Internalname = "NETWORKCOMPANYID";
         edtNetworkCompanyKvkNumber_Internalname = "NETWORKCOMPANYKVKNUMBER";
         edtNetworkCompanyEmail_Internalname = "NETWORKCOMPANYEMAIL";
         edtNetworkCompanyPhone_Internalname = "NETWORKCOMPANYPHONE";
         edtNetworkCompanyCountry_Internalname = "NETWORKCOMPANYCOUNTRY";
         edtNetworkCompanyCity_Internalname = "NETWORKCOMPANYCITY";
         edtNetworkCompanyZipCode_Internalname = "NETWORKCOMPANYZIPCODE";
         edtNetworkCompanyAddressLine1_Internalname = "NETWORKCOMPANYADDRESSLINE1";
         edtNetworkCompanyAddressLine2_Internalname = "NETWORKCOMPANYADDRESSLINE2";
         divTableleaflevel_networkcompany_Internalname = "TABLELEAFLEVEL_NETWORKCOMPANY";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboresidentphonecode_Internalname = "vCOMBORESIDENTPHONECODE";
         divSectionattribute_residentphonecode_Internalname = "SECTIONATTRIBUTE_RESIDENTPHONECODE";
         edtavComboresidenthomephonecode_Internalname = "vCOMBORESIDENTHOMEPHONECODE";
         divSectionattribute_residenthomephonecode_Internalname = "SECTIONATTRIBUTE_RESIDENTHOMEPHONECODE";
         edtavComboresidenttypeid_Internalname = "vCOMBORESIDENTTYPEID";
         divSectionattribute_residenttypeid_Internalname = "SECTIONATTRIBUTE_RESIDENTTYPEID";
         edtavCombomedicalindicationid_Internalname = "vCOMBOMEDICALINDICATIONID";
         divSectionattribute_medicalindicationid_Internalname = "SECTIONATTRIBUTE_MEDICALINDICATIONID";
         edtavComboresidentcountry_Internalname = "vCOMBORESIDENTCOUNTRY";
         divSectionattribute_residentcountry_Internalname = "SECTIONATTRIBUTE_RESIDENTCOUNTRY";
         Combo_networkindividualid_Internalname = "COMBO_NETWORKINDIVIDUALID";
         Combo_networkcompanyid_Internalname = "COMBO_NETWORKCOMPANYID";
         edtResidentId_Internalname = "RESIDENTID";
         edtLocationId_Internalname = "LOCATIONID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtResidentInitials_Internalname = "RESIDENTINITIALS";
         edtResidentPhone_Internalname = "RESIDENTPHONE";
         edtResidentHomePhone_Internalname = "RESIDENTHOMEPHONE";
         edtResidentGUID_Internalname = "RESIDENTGUID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_networkindividual_Internalname = "GRIDLEVEL_NETWORKINDIVIDUAL";
         subGridlevel_networkcompany_Internalname = "GRIDLEVEL_NETWORKCOMPANY";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_networkcompany_Allowcollapsing = 0;
         subGridlevel_networkcompany_Allowselection = 0;
         subGridlevel_networkcompany_Header = "";
         subGridlevel_networkindividual_Allowcollapsing = 0;
         subGridlevel_networkindividual_Allowselection = 0;
         subGridlevel_networkindividual_Header = "";
         Combo_networkcompanyid_Enabled = Convert.ToBoolean( -1);
         Combo_networkindividualid_Enabled = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Residents", "");
         edtNetworkCompanyAddressLine2_Jsonclick = "";
         edtNetworkCompanyAddressLine1_Jsonclick = "";
         edtNetworkCompanyZipCode_Jsonclick = "";
         edtNetworkCompanyCity_Jsonclick = "";
         edtNetworkCompanyCountry_Jsonclick = "";
         edtNetworkCompanyPhone_Jsonclick = "";
         edtNetworkCompanyEmail_Jsonclick = "";
         edtNetworkCompanyKvkNumber_Jsonclick = "";
         edtNetworkCompanyId_Jsonclick = "";
         subGridlevel_networkcompany_Class = "WorkWith";
         subGridlevel_networkcompany_Backcolorstyle = 0;
         edtNetworkIndividualAddressLine2_Jsonclick = "";
         edtNetworkIndividualAddressLine1_Jsonclick = "";
         edtNetworkIndividualZipCode_Jsonclick = "";
         edtNetworkIndividualCity_Jsonclick = "";
         edtNetworkIndividualCountry_Jsonclick = "";
         cmbNetworkIndividualGender_Jsonclick = "";
         edtNetworkIndividualPhone_Jsonclick = "";
         edtNetworkIndividualEmail_Jsonclick = "";
         edtNetworkIndividualLastName_Jsonclick = "";
         edtNetworkIndividualGivenName_Jsonclick = "";
         edtNetworkIndividualId_Jsonclick = "";
         subGridlevel_networkindividual_Class = "WorkWith";
         subGridlevel_networkindividual_Backcolorstyle = 0;
         Combo_residentphonecode_Htmltemplate = "";
         Combo_residenthomephonecode_Htmltemplate = "";
         Combo_residentcountry_Htmltemplate = "";
         Combo_networkindividualid_Titlecontrolidtoreplace = "";
         Combo_networkcompanyid_Titlecontrolidtoreplace = "";
         edtNetworkCompanyAddressLine2_Enabled = 0;
         edtNetworkCompanyAddressLine1_Enabled = 0;
         edtNetworkCompanyZipCode_Enabled = 0;
         edtNetworkCompanyCity_Enabled = 0;
         edtNetworkCompanyCountry_Enabled = 0;
         edtNetworkCompanyPhone_Enabled = 0;
         edtNetworkCompanyEmail_Enabled = 0;
         edtNetworkCompanyKvkNumber_Enabled = 0;
         edtNetworkCompanyId_Enabled = 1;
         edtNetworkIndividualAddressLine2_Enabled = 0;
         edtNetworkIndividualAddressLine1_Enabled = 0;
         edtNetworkIndividualZipCode_Enabled = 0;
         edtNetworkIndividualCity_Enabled = 0;
         edtNetworkIndividualCountry_Enabled = 0;
         cmbNetworkIndividualGender.Enabled = 0;
         edtNetworkIndividualPhone_Enabled = 0;
         edtNetworkIndividualEmail_Enabled = 0;
         edtNetworkIndividualLastName_Enabled = 0;
         edtNetworkIndividualGivenName_Enabled = 0;
         edtNetworkIndividualId_Enabled = 1;
         edtResidentGUID_Jsonclick = "";
         edtResidentGUID_Enabled = 1;
         edtResidentGUID_Visible = 1;
         edtResidentHomePhone_Jsonclick = "";
         edtResidentHomePhone_Enabled = 1;
         edtResidentHomePhone_Visible = 1;
         edtResidentPhone_Jsonclick = "";
         edtResidentPhone_Enabled = 1;
         edtResidentPhone_Visible = 1;
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
         Combo_networkcompanyid_Emptyitem = Convert.ToBoolean( 0);
         Combo_networkcompanyid_Datalistprocparametersprefix = " \"ComboName\": \"NetworkCompanyId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ResidentId\": \"00000000-0000-0000-0000-000000000000\", \"LocationId\": \"00000000-0000-0000-0000-000000000000\", \"OrganisationId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_networkcompanyid_Datalistproc = "Trn_ResidentLoadDVCombo";
         Combo_networkcompanyid_Hasdescription = Convert.ToBoolean( -1);
         Combo_networkcompanyid_Isgriditem = Convert.ToBoolean( -1);
         Combo_networkcompanyid_Cls = "ExtendedCombo";
         Combo_networkcompanyid_Caption = "";
         Combo_networkindividualid_Emptyitem = Convert.ToBoolean( 0);
         Combo_networkindividualid_Datalistprocparametersprefix = " \"ComboName\": \"NetworkIndividualId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ResidentId\": \"00000000-0000-0000-0000-000000000000\", \"LocationId\": \"00000000-0000-0000-0000-000000000000\", \"OrganisationId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_networkindividualid_Datalistproc = "Trn_ResidentLoadDVCombo";
         Combo_networkindividualid_Hasdescription = Convert.ToBoolean( -1);
         Combo_networkindividualid_Isgriditem = Convert.ToBoolean( -1);
         Combo_networkindividualid_Cls = "ExtendedCombo";
         Combo_networkindividualid_Caption = "";
         edtavComboresidentcountry_Jsonclick = "";
         edtavComboresidentcountry_Enabled = 0;
         edtavComboresidentcountry_Visible = 1;
         edtavCombomedicalindicationid_Jsonclick = "";
         edtavCombomedicalindicationid_Enabled = 0;
         edtavCombomedicalindicationid_Visible = 1;
         edtavComboresidenttypeid_Jsonclick = "";
         edtavComboresidenttypeid_Enabled = 0;
         edtavComboresidenttypeid_Visible = 1;
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
         divTableleaflevel_networkcompany_Visible = 1;
         divTableleaflevel_networkindividual_Visible = 1;
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
         edtMedicalIndicationId_Jsonclick = "";
         edtMedicalIndicationId_Enabled = 1;
         edtMedicalIndicationId_Visible = 1;
         Combo_medicalindicationid_Datalistprocparametersprefix = " \"ComboName\": \"MedicalIndicationId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ResidentId\": \"00000000-0000-0000-0000-000000000000\", \"LocationId\": \"00000000-0000-0000-0000-000000000000\", \"OrganisationId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_medicalindicationid_Datalistproc = "Trn_ResidentLoadDVCombo";
         Combo_medicalindicationid_Cls = "ExtendedCombo Attribute";
         Combo_medicalindicationid_Caption = "";
         Combo_medicalindicationid_Enabled = Convert.ToBoolean( -1);
         edtResidentTypeId_Jsonclick = "";
         edtResidentTypeId_Enabled = 1;
         edtResidentTypeId_Visible = 1;
         Combo_residenttypeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_residenttypeid_Datalistprocparametersprefix = " \"ComboName\": \"ResidentTypeId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ResidentId\": \"00000000-0000-0000-0000-000000000000\", \"LocationId\": \"00000000-0000-0000-0000-000000000000\", \"OrganisationId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_residenttypeid_Datalistproc = "Trn_ResidentLoadDVCombo";
         Combo_residenttypeid_Cls = "ExtendedCombo Attribute";
         Combo_residenttypeid_Caption = "";
         Combo_residenttypeid_Enabled = Convert.ToBoolean( -1);
         edtResidentHomePhoneNumber_Jsonclick = "";
         edtResidentHomePhoneNumber_Enabled = 1;
         edtResidentHomePhoneCode_Jsonclick = "";
         edtResidentHomePhoneCode_Enabled = 1;
         edtResidentHomePhoneCode_Visible = 1;
         Combo_residenthomephonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_residenthomephonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_residenthomephonecode_Caption = "";
         Combo_residenthomephonecode_Enabled = Convert.ToBoolean( -1);
         edtResidentPhoneNumber_Jsonclick = "";
         edtResidentPhoneNumber_Enabled = 1;
         edtResidentPhoneCode_Jsonclick = "";
         edtResidentPhoneCode_Enabled = 1;
         edtResidentPhoneCode_Visible = 1;
         Combo_residentphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_residentphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_residentphonecode_Caption = "";
         Combo_residentphonecode_Enabled = Convert.ToBoolean( -1);
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
         edtResidentBsnNumber_Jsonclick = "";
         edtResidentBsnNumber_Enabled = 1;
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

      protected void GX13ASALOCATIONID0916( Guid AV8LocationId )
      {
         if ( ! (Guid.Empty==AV8LocationId) )
         {
            A29LocationId = AV8LocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         else
         {
            GXt_guid3 = A29LocationId;
            new prc_getuserlocationid(context ).execute( out  GXt_guid3) ;
            A29LocationId = GXt_guid3;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A29LocationId.ToString())+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX15ASAORGANISATIONID0916( Guid AV9OrganisationId )
      {
         if ( ! (Guid.Empty==AV9OrganisationId) )
         {
            A11OrganisationId = AV9OrganisationId;
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

      protected void GX27ASARESIDENTPHONE0916( string A375ResidentPhoneCode ,
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

      protected void XC_36_0916( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV42AuditingObject ,
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

      protected void XC_37_0916( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV42AuditingObject ,
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

      protected void XC_38_0916( string Gx_mode ,
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

      protected void XC_39_0916( string Gx_mode ,
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

      protected void XC_41_0916( string A67ResidentEmail ,
                                 string A64ResidentGivenName ,
                                 string A65ResidentLastName ,
                                 string Gx_mode ,
                                 string A71ResidentGUID )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "INS", "")) == 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( A71ResidentGUID)) )
         {
            new prc_creategamuseraccount(context ).execute(  A67ResidentEmail,  A64ResidentGivenName,  A65ResidentLastName,  "Resident", out  A71ResidentGUID) ;
            AssignAttri("", false, "A71ResidentGUID", A71ResidentGUID);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A71ResidentGUID)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_42_0916( string A64ResidentGivenName ,
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

      protected void XC_43_0916( string Gx_mode ,
                                 string A71ResidentGUID ,
                                 string A64ResidentGivenName ,
                                 string A65ResidentLastName )
      {
         if ( IsUpd( )  )
         {
            new prc_updategamuseraccount(context ).execute(  A71ResidentGUID,  A64ResidentGivenName,  A65ResidentLastName,  "Resident", out  AV36GAMErrorResponse) ;
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

      protected void XC_44_0916( string Gx_mode ,
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

      protected void gxnrGridlevel_networkindividual_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_15023( ) ;
         while ( nGXsfl_150_idx <= nRC_GXsfl_150 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0923( ) ;
            standaloneModal0923( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0923( ) ;
            nGXsfl_150_idx = (int)(nGXsfl_150_idx+1);
            sGXsfl_150_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_150_idx), 4, 0), 4, "0");
            SubsflControlProps_15023( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_networkindividualContainer)) ;
         /* End function gxnrGridlevel_networkindividual_newrow */
      }

      protected void gxnrGridlevel_networkcompany_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_16720( ) ;
         while ( nGXsfl_167_idx <= nRC_GXsfl_167 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0920( ) ;
            standaloneModal0920( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0920( ) ;
            nGXsfl_167_idx = (int)(nGXsfl_167_idx+1);
            sGXsfl_167_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_167_idx), 4, 0), 4, "0");
            SubsflControlProps_16720( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_networkcompanyContainer)) ;
         /* End function gxnrGridlevel_networkcompany_newrow */
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
         GXCCtl = "NETWORKINDIVIDUALGENDER_" + sGXsfl_150_idx;
         cmbNetworkIndividualGender.Name = GXCCtl;
         cmbNetworkIndividualGender.WebTags = "";
         cmbNetworkIndividualGender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbNetworkIndividualGender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbNetworkIndividualGender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbNetworkIndividualGender.ItemCount > 0 )
         {
            A81NetworkIndividualGender = cmbNetworkIndividualGender.getValidValue(A81NetworkIndividualGender);
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
         /* Using cursor T000940 */
         pr_default.execute(38, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(38) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
         }
         pr_default.close(38);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A376ResidentPhoneNumber)) && ! GxRegex.IsMatch(A376ResidentPhoneNumber,context.GetMessage( "\\b\\d{9}\\b", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "RESIDENTPHONENUMBER");
            AnyError = 1;
            GX_FocusControl = edtResidentPhoneNumber_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A70ResidentPhone", StringUtil.RTrim( A70ResidentPhone));
      }

      public void Valid_Residenttypeid( )
      {
         /* Using cursor T000923 */
         pr_default.execute(21, new Object[] {A96ResidentTypeId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
            AnyError = 1;
            GX_FocusControl = edtResidentTypeId_Internalname;
         }
         A97ResidentTypeName = T000923_A97ResidentTypeName[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A97ResidentTypeName", A97ResidentTypeName);
      }

      public void Valid_Medicalindicationid( )
      {
         n98MedicalIndicationId = false;
         /* Using cursor T000924 */
         pr_default.execute(22, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            if ( ! ( (Guid.Empty==A98MedicalIndicationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Medical Indication", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDICALINDICATIONID");
               AnyError = 1;
               GX_FocusControl = edtMedicalIndicationId_Internalname;
            }
         }
         A99MedicalIndicationName = T000924_A99MedicalIndicationName[0];
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A99MedicalIndicationName", A99MedicalIndicationName);
      }

      public void Valid_Networkindividualid( )
      {
         A81NetworkIndividualGender = cmbNetworkIndividualGender.CurrentValue;
         cmbNetworkIndividualGender.CurrentValue = A81NetworkIndividualGender;
         /* Using cursor T000931 */
         pr_default.execute(29, new Object[] {A74NetworkIndividualId});
         if ( (pr_default.getStatus(29) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_NetworkIndividual", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "NETWORKINDIVIDUALID");
            AnyError = 1;
            GX_FocusControl = edtNetworkIndividualId_Internalname;
         }
         A75NetworkIndividualBsnNumber = T000931_A75NetworkIndividualBsnNumber[0];
         A76NetworkIndividualGivenName = T000931_A76NetworkIndividualGivenName[0];
         A77NetworkIndividualLastName = T000931_A77NetworkIndividualLastName[0];
         A78NetworkIndividualEmail = T000931_A78NetworkIndividualEmail[0];
         A79NetworkIndividualPhone = T000931_A79NetworkIndividualPhone[0];
         A388NetworkIndividualPhoneNumber = T000931_A388NetworkIndividualPhoneNumber[0];
         A387NetworkIndividualPhoneCode = T000931_A387NetworkIndividualPhoneCode[0];
         A81NetworkIndividualGender = T000931_A81NetworkIndividualGender[0];
         cmbNetworkIndividualGender.CurrentValue = A81NetworkIndividualGender;
         A344NetworkIndividualCountry = T000931_A344NetworkIndividualCountry[0];
         A345NetworkIndividualCity = T000931_A345NetworkIndividualCity[0];
         A346NetworkIndividualZipCode = T000931_A346NetworkIndividualZipCode[0];
         A347NetworkIndividualAddressLine1 = T000931_A347NetworkIndividualAddressLine1[0];
         A348NetworkIndividualAddressLine2 = T000931_A348NetworkIndividualAddressLine2[0];
         pr_default.close(29);
         dynload_actions( ) ;
         if ( cmbNetworkIndividualGender.ItemCount > 0 )
         {
            A81NetworkIndividualGender = cmbNetworkIndividualGender.getValidValue(A81NetworkIndividualGender);
            cmbNetworkIndividualGender.CurrentValue = A81NetworkIndividualGender;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNetworkIndividualGender.CurrentValue = StringUtil.RTrim( A81NetworkIndividualGender);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A75NetworkIndividualBsnNumber", A75NetworkIndividualBsnNumber);
         AssignAttri("", false, "A76NetworkIndividualGivenName", A76NetworkIndividualGivenName);
         AssignAttri("", false, "A77NetworkIndividualLastName", A77NetworkIndividualLastName);
         AssignAttri("", false, "A78NetworkIndividualEmail", A78NetworkIndividualEmail);
         AssignAttri("", false, "A79NetworkIndividualPhone", StringUtil.RTrim( A79NetworkIndividualPhone));
         AssignAttri("", false, "A388NetworkIndividualPhoneNumber", A388NetworkIndividualPhoneNumber);
         AssignAttri("", false, "A387NetworkIndividualPhoneCode", A387NetworkIndividualPhoneCode);
         AssignAttri("", false, "A81NetworkIndividualGender", A81NetworkIndividualGender);
         cmbNetworkIndividualGender.CurrentValue = StringUtil.RTrim( A81NetworkIndividualGender);
         AssignProp("", false, cmbNetworkIndividualGender_Internalname, "Values", cmbNetworkIndividualGender.ToJavascriptSource(), true);
         AssignAttri("", false, "A344NetworkIndividualCountry", A344NetworkIndividualCountry);
         AssignAttri("", false, "A345NetworkIndividualCity", A345NetworkIndividualCity);
         AssignAttri("", false, "A346NetworkIndividualZipCode", A346NetworkIndividualZipCode);
         AssignAttri("", false, "A347NetworkIndividualAddressLine1", A347NetworkIndividualAddressLine1);
         AssignAttri("", false, "A348NetworkIndividualAddressLine2", A348NetworkIndividualAddressLine2);
      }

      public void Valid_Networkcompanyid( )
      {
         /* Using cursor T000938 */
         pr_default.execute(36, new Object[] {A82NetworkCompanyId});
         if ( (pr_default.getStatus(36) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_NetworkCompany", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "NETWORKCOMPANYID");
            AnyError = 1;
            GX_FocusControl = edtNetworkCompanyId_Internalname;
         }
         A83NetworkCompanyKvkNumber = T000938_A83NetworkCompanyKvkNumber[0];
         A84NetworkCompanyName = T000938_A84NetworkCompanyName[0];
         A85NetworkCompanyEmail = T000938_A85NetworkCompanyEmail[0];
         A86NetworkCompanyPhone = T000938_A86NetworkCompanyPhone[0];
         A392NetworkCompanyPhoneNumber = T000938_A392NetworkCompanyPhoneNumber[0];
         A391NetworkCompanyPhoneCode = T000938_A391NetworkCompanyPhoneCode[0];
         A349NetworkCompanyCountry = T000938_A349NetworkCompanyCountry[0];
         A350NetworkCompanyCity = T000938_A350NetworkCompanyCity[0];
         A351NetworkCompanyZipCode = T000938_A351NetworkCompanyZipCode[0];
         A352NetworkCompanyAddressLine1 = T000938_A352NetworkCompanyAddressLine1[0];
         A353NetworkCompanyAddressLine2 = T000938_A353NetworkCompanyAddressLine2[0];
         pr_default.close(36);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A83NetworkCompanyKvkNumber", A83NetworkCompanyKvkNumber);
         AssignAttri("", false, "A84NetworkCompanyName", A84NetworkCompanyName);
         AssignAttri("", false, "A85NetworkCompanyEmail", A85NetworkCompanyEmail);
         AssignAttri("", false, "A86NetworkCompanyPhone", StringUtil.RTrim( A86NetworkCompanyPhone));
         AssignAttri("", false, "A392NetworkCompanyPhoneNumber", A392NetworkCompanyPhoneNumber);
         AssignAttri("", false, "A391NetworkCompanyPhoneCode", A391NetworkCompanyPhoneCode);
         AssignAttri("", false, "A349NetworkCompanyCountry", A349NetworkCompanyCountry);
         AssignAttri("", false, "A350NetworkCompanyCity", A350NetworkCompanyCity);
         AssignAttri("", false, "A351NetworkCompanyZipCode", A351NetworkCompanyZipCode);
         AssignAttri("", false, "A352NetworkCompanyAddressLine1", A352NetworkCompanyAddressLine1);
         AssignAttri("", false, "A353NetworkCompanyAddressLine2", A353NetworkCompanyAddressLine2);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7ResidentId","fld":"vRESIDENTID","hsh":true},{"av":"AV8LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV9OrganisationId","fld":"vORGANISATIONID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV13TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7ResidentId","fld":"vRESIDENTID","hsh":true},{"av":"AV8LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV9OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV45Pgmname","fld":"vPGMNAME"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E14092","iparms":[{"av":"AV42AuditingObject","fld":"vAUDITINGOBJECT"},{"av":"AV45Pgmname","fld":"vPGMNAME"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV13TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("COMBO_MEDICALINDICATIONID.ONOPTIONCLICKED","""{"handler":"E13092","iparms":[{"av":"Combo_medicalindicationid_Selectedvalue_get","ctrl":"COMBO_MEDICALINDICATIONID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_MEDICALINDICATIONID.ONOPTIONCLICKED",""","oparms":[{"av":"AV34ComboMedicalIndicationId","fld":"vCOMBOMEDICALINDICATIONID"}]}""");
         setEventMetadata("COMBO_RESIDENTTYPEID.ONOPTIONCLICKED","""{"handler":"E12092","iparms":[{"av":"Combo_residenttypeid_Selectedvalue_get","ctrl":"COMBO_RESIDENTTYPEID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_RESIDENTTYPEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV32ComboResidentTypeId","fld":"vCOMBORESIDENTTYPEID"}]}""");
         setEventMetadata("VALID_RESIDENTBSNNUMBER","""{"handler":"Valid_Residentbsnnumber","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTSALUTATION","""{"handler":"Valid_Residentsalutation","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTGIVENNAME","""{"handler":"Valid_Residentgivenname","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTLASTNAME","""{"handler":"Valid_Residentlastname","iparms":[{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"}]""");
         setEventMetadata("VALID_RESIDENTLASTNAME",""","oparms":[{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"}]}""");
         setEventMetadata("VALID_RESIDENTGENDER","""{"handler":"Valid_Residentgender","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTEMAIL","""{"handler":"Valid_Residentemail","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTPHONECODE","""{"handler":"Valid_Residentphonecode","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTPHONENUMBER","""{"handler":"Valid_Residentphonenumber","iparms":[{"av":"A375ResidentPhoneCode","fld":"RESIDENTPHONECODE"},{"av":"A376ResidentPhoneNumber","fld":"RESIDENTPHONENUMBER"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"}]""");
         setEventMetadata("VALID_RESIDENTPHONENUMBER",""","oparms":[{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"}]}""");
         setEventMetadata("VALID_RESIDENTHOMEPHONENUMBER","""{"handler":"Valid_Residenthomephonenumber","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTTYPEID","""{"handler":"Valid_Residenttypeid","iparms":[{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"}]""");
         setEventMetadata("VALID_RESIDENTTYPEID",""","oparms":[{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"}]}""");
         setEventMetadata("VALID_MEDICALINDICATIONID","""{"handler":"Valid_Medicalindicationid","iparms":[{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"}]""");
         setEventMetadata("VALID_MEDICALINDICATIONID",""","oparms":[{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"}]}""");
         setEventMetadata("VALIDV_COMBORESIDENTPHONECODE","""{"handler":"Validv_Comboresidentphonecode","iparms":[]}""");
         setEventMetadata("VALIDV_COMBORESIDENTHOMEPHONECODE","""{"handler":"Validv_Comboresidenthomephonecode","iparms":[]}""");
         setEventMetadata("VALIDV_COMBORESIDENTTYPEID","""{"handler":"Validv_Comboresidenttypeid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOMEDICALINDICATIONID","""{"handler":"Validv_Combomedicalindicationid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBORESIDENTCOUNTRY","""{"handler":"Validv_Comboresidentcountry","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTID","""{"handler":"Valid_Residentid","iparms":[]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"}]}""");
         setEventMetadata("VALID_RESIDENTGUID","""{"handler":"Valid_Residentguid","iparms":[]}""");
         setEventMetadata("VALID_NETWORKINDIVIDUALID","""{"handler":"Valid_Networkindividualid","iparms":[{"av":"A74NetworkIndividualId","fld":"NETWORKINDIVIDUALID"},{"av":"A75NetworkIndividualBsnNumber","fld":"NETWORKINDIVIDUALBSNNUMBER"},{"av":"A76NetworkIndividualGivenName","fld":"NETWORKINDIVIDUALGIVENNAME"},{"av":"A77NetworkIndividualLastName","fld":"NETWORKINDIVIDUALLASTNAME"},{"av":"A78NetworkIndividualEmail","fld":"NETWORKINDIVIDUALEMAIL"},{"av":"A79NetworkIndividualPhone","fld":"NETWORKINDIVIDUALPHONE"},{"av":"A388NetworkIndividualPhoneNumber","fld":"NETWORKINDIVIDUALPHONENUMBER"},{"av":"A387NetworkIndividualPhoneCode","fld":"NETWORKINDIVIDUALPHONECODE"},{"av":"cmbNetworkIndividualGender"},{"av":"A81NetworkIndividualGender","fld":"NETWORKINDIVIDUALGENDER"},{"av":"A344NetworkIndividualCountry","fld":"NETWORKINDIVIDUALCOUNTRY"},{"av":"A345NetworkIndividualCity","fld":"NETWORKINDIVIDUALCITY"},{"av":"A346NetworkIndividualZipCode","fld":"NETWORKINDIVIDUALZIPCODE"},{"av":"A347NetworkIndividualAddressLine1","fld":"NETWORKINDIVIDUALADDRESSLINE1"},{"av":"A348NetworkIndividualAddressLine2","fld":"NETWORKINDIVIDUALADDRESSLINE2"}]""");
         setEventMetadata("VALID_NETWORKINDIVIDUALID",""","oparms":[{"av":"A75NetworkIndividualBsnNumber","fld":"NETWORKINDIVIDUALBSNNUMBER"},{"av":"A76NetworkIndividualGivenName","fld":"NETWORKINDIVIDUALGIVENNAME"},{"av":"A77NetworkIndividualLastName","fld":"NETWORKINDIVIDUALLASTNAME"},{"av":"A78NetworkIndividualEmail","fld":"NETWORKINDIVIDUALEMAIL"},{"av":"A79NetworkIndividualPhone","fld":"NETWORKINDIVIDUALPHONE"},{"av":"A388NetworkIndividualPhoneNumber","fld":"NETWORKINDIVIDUALPHONENUMBER"},{"av":"A387NetworkIndividualPhoneCode","fld":"NETWORKINDIVIDUALPHONECODE"},{"av":"cmbNetworkIndividualGender"},{"av":"A81NetworkIndividualGender","fld":"NETWORKINDIVIDUALGENDER"},{"av":"A344NetworkIndividualCountry","fld":"NETWORKINDIVIDUALCOUNTRY"},{"av":"A345NetworkIndividualCity","fld":"NETWORKINDIVIDUALCITY"},{"av":"A346NetworkIndividualZipCode","fld":"NETWORKINDIVIDUALZIPCODE"},{"av":"A347NetworkIndividualAddressLine1","fld":"NETWORKINDIVIDUALADDRESSLINE1"},{"av":"A348NetworkIndividualAddressLine2","fld":"NETWORKINDIVIDUALADDRESSLINE2"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Networkindividualaddressline2","iparms":[]}""");
         setEventMetadata("VALID_NETWORKCOMPANYID","""{"handler":"Valid_Networkcompanyid","iparms":[{"av":"A82NetworkCompanyId","fld":"NETWORKCOMPANYID"},{"av":"A83NetworkCompanyKvkNumber","fld":"NETWORKCOMPANYKVKNUMBER"},{"av":"A84NetworkCompanyName","fld":"NETWORKCOMPANYNAME"},{"av":"A85NetworkCompanyEmail","fld":"NETWORKCOMPANYEMAIL"},{"av":"A86NetworkCompanyPhone","fld":"NETWORKCOMPANYPHONE"},{"av":"A392NetworkCompanyPhoneNumber","fld":"NETWORKCOMPANYPHONENUMBER"},{"av":"A391NetworkCompanyPhoneCode","fld":"NETWORKCOMPANYPHONECODE"},{"av":"A349NetworkCompanyCountry","fld":"NETWORKCOMPANYCOUNTRY"},{"av":"A350NetworkCompanyCity","fld":"NETWORKCOMPANYCITY"},{"av":"A351NetworkCompanyZipCode","fld":"NETWORKCOMPANYZIPCODE"},{"av":"A352NetworkCompanyAddressLine1","fld":"NETWORKCOMPANYADDRESSLINE1"},{"av":"A353NetworkCompanyAddressLine2","fld":"NETWORKCOMPANYADDRESSLINE2"}]""");
         setEventMetadata("VALID_NETWORKCOMPANYID",""","oparms":[{"av":"A83NetworkCompanyKvkNumber","fld":"NETWORKCOMPANYKVKNUMBER"},{"av":"A84NetworkCompanyName","fld":"NETWORKCOMPANYNAME"},{"av":"A85NetworkCompanyEmail","fld":"NETWORKCOMPANYEMAIL"},{"av":"A86NetworkCompanyPhone","fld":"NETWORKCOMPANYPHONE"},{"av":"A392NetworkCompanyPhoneNumber","fld":"NETWORKCOMPANYPHONENUMBER"},{"av":"A391NetworkCompanyPhoneCode","fld":"NETWORKCOMPANYPHONECODE"},{"av":"A349NetworkCompanyCountry","fld":"NETWORKCOMPANYCOUNTRY"},{"av":"A350NetworkCompanyCity","fld":"NETWORKCOMPANYCITY"},{"av":"A351NetworkCompanyZipCode","fld":"NETWORKCOMPANYZIPCODE"},{"av":"A352NetworkCompanyAddressLine1","fld":"NETWORKCOMPANYADDRESSLINE1"},{"av":"A353NetworkCompanyAddressLine2","fld":"NETWORKCOMPANYADDRESSLINE2"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Networkcompanyaddressline2","iparms":[]}""");
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
         pr_default.close(36);
         pr_default.close(4);
         pr_default.close(29);
         pr_default.close(7);
         pr_default.close(38);
         pr_default.close(21);
         pr_default.close(22);
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
         Z375ResidentPhoneCode = "";
         Z445ResidentHomePhoneCode = "";
         Z71ResidentGUID = "";
         Z66ResidentInitials = "";
         Z70ResidentPhone = "";
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
         Z444ResidentHomePhone = "";
         Z73ResidentBirthDate = DateTime.MinValue;
         Z376ResidentPhoneNumber = "";
         Z446ResidentHomePhoneNumber = "";
         Z96ResidentTypeId = Guid.Empty;
         Z98MedicalIndicationId = Guid.Empty;
         N96ResidentTypeId = Guid.Empty;
         N98MedicalIndicationId = Guid.Empty;
         Combo_residentcountry_Selectedvalue_get = "";
         Combo_medicalindicationid_Selectedvalue_get = "";
         Combo_residenttypeid_Selectedvalue_get = "";
         Combo_residenthomephonecode_Selectedvalue_get = "";
         Combo_residentphonecode_Selectedvalue_get = "";
         Z74NetworkIndividualId = Guid.Empty;
         Z82NetworkCompanyId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A67ResidentEmail = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A71ResidentGUID = "";
         A375ResidentPhoneCode = "";
         A376ResidentPhoneNumber = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A96ResidentTypeId = Guid.Empty;
         A98MedicalIndicationId = Guid.Empty;
         A74NetworkIndividualId = Guid.Empty;
         A82NetworkCompanyId = Guid.Empty;
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A72ResidentSalutation = "";
         A68ResidentGender = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A63ResidentBsnNumber = "";
         A73ResidentBirthDate = DateTime.MinValue;
         lblTextblockresidentphonecode_Jsonclick = "";
         sStyleString = "";
         ucCombo_residentphonecode = new GXUserControl();
         AV19DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV41ResidentPhoneCode_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockresidenthomephonecode_Jsonclick = "";
         ucCombo_residenthomephonecode = new GXUserControl();
         AV43ResidentHomePhoneCode_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A445ResidentHomePhoneCode = "";
         A446ResidentHomePhoneNumber = "";
         lblTextblockresidenttypeid_Jsonclick = "";
         ucCombo_residenttypeid = new GXUserControl();
         AV31ResidentTypeId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockmedicalindicationid_Jsonclick = "";
         ucCombo_medicalindicationid = new GXUserControl();
         AV33MedicalIndicationId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
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
         AV32ComboResidentTypeId = Guid.Empty;
         AV34ComboMedicalIndicationId = Guid.Empty;
         AV38ComboResidentCountry = "";
         ucCombo_networkindividualid = new GXUserControl();
         AV25NetworkIndividualId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         ucCombo_networkcompanyid = new GXUserControl();
         AV18NetworkCompanyId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A62ResidentId = Guid.Empty;
         A66ResidentInitials = "";
         gxphoneLink = "";
         A70ResidentPhone = "";
         A444ResidentHomePhone = "";
         Gridlevel_networkindividualContainer = new GXWebGrid( context);
         sMode23 = "";
         Gridlevel_networkcompanyContainer = new GXWebGrid( context);
         sMode20 = "";
         AV15Insert_ResidentTypeId = Guid.Empty;
         AV16Insert_MedicalIndicationId = Guid.Empty;
         AV42AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV36GAMErrorResponse = "";
         A97ResidentTypeName = "";
         A99MedicalIndicationName = "";
         AV45Pgmname = "";
         A75NetworkIndividualBsnNumber = "";
         A388NetworkIndividualPhoneNumber = "";
         A387NetworkIndividualPhoneCode = "";
         A84NetworkCompanyName = "";
         A392NetworkCompanyPhoneNumber = "";
         A391NetworkCompanyPhoneCode = "";
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
         Combo_residenttypeid_Objectcall = "";
         Combo_residenttypeid_Class = "";
         Combo_residenttypeid_Icontype = "";
         Combo_residenttypeid_Icon = "";
         Combo_residenttypeid_Tooltip = "";
         Combo_residenttypeid_Selectedvalue_set = "";
         Combo_residenttypeid_Selectedtext_set = "";
         Combo_residenttypeid_Selectedtext_get = "";
         Combo_residenttypeid_Gamoauthtoken = "";
         Combo_residenttypeid_Ddointernalname = "";
         Combo_residenttypeid_Titlecontrolalign = "";
         Combo_residenttypeid_Dropdownoptionstype = "";
         Combo_residenttypeid_Titlecontrolidtoreplace = "";
         Combo_residenttypeid_Datalisttype = "";
         Combo_residenttypeid_Datalistfixedvalues = "";
         Combo_residenttypeid_Remoteservicesparameters = "";
         Combo_residenttypeid_Htmltemplate = "";
         Combo_residenttypeid_Multiplevaluestype = "";
         Combo_residenttypeid_Loadingdata = "";
         Combo_residenttypeid_Noresultsfound = "";
         Combo_residenttypeid_Emptyitemtext = "";
         Combo_residenttypeid_Onlyselectedvalues = "";
         Combo_residenttypeid_Selectalltext = "";
         Combo_residenttypeid_Multiplevaluesseparator = "";
         Combo_residenttypeid_Addnewoptiontext = "";
         Combo_medicalindicationid_Objectcall = "";
         Combo_medicalindicationid_Class = "";
         Combo_medicalindicationid_Icontype = "";
         Combo_medicalindicationid_Icon = "";
         Combo_medicalindicationid_Tooltip = "";
         Combo_medicalindicationid_Selectedvalue_set = "";
         Combo_medicalindicationid_Selectedtext_set = "";
         Combo_medicalindicationid_Selectedtext_get = "";
         Combo_medicalindicationid_Gamoauthtoken = "";
         Combo_medicalindicationid_Ddointernalname = "";
         Combo_medicalindicationid_Titlecontrolalign = "";
         Combo_medicalindicationid_Dropdownoptionstype = "";
         Combo_medicalindicationid_Titlecontrolidtoreplace = "";
         Combo_medicalindicationid_Datalisttype = "";
         Combo_medicalindicationid_Datalistfixedvalues = "";
         Combo_medicalindicationid_Remoteservicesparameters = "";
         Combo_medicalindicationid_Htmltemplate = "";
         Combo_medicalindicationid_Multiplevaluestype = "";
         Combo_medicalindicationid_Loadingdata = "";
         Combo_medicalindicationid_Noresultsfound = "";
         Combo_medicalindicationid_Emptyitemtext = "";
         Combo_medicalindicationid_Onlyselectedvalues = "";
         Combo_medicalindicationid_Selectalltext = "";
         Combo_medicalindicationid_Multiplevaluesseparator = "";
         Combo_medicalindicationid_Addnewoptiontext = "";
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
         Combo_networkindividualid_Objectcall = "";
         Combo_networkindividualid_Class = "";
         Combo_networkindividualid_Icontype = "";
         Combo_networkindividualid_Icon = "";
         Combo_networkindividualid_Tooltip = "";
         Combo_networkindividualid_Selectedvalue_set = "";
         Combo_networkindividualid_Selectedvalue_get = "";
         Combo_networkindividualid_Selectedtext_set = "";
         Combo_networkindividualid_Selectedtext_get = "";
         Combo_networkindividualid_Gamoauthtoken = "";
         Combo_networkindividualid_Ddointernalname = "";
         Combo_networkindividualid_Titlecontrolalign = "";
         Combo_networkindividualid_Dropdownoptionstype = "";
         Combo_networkindividualid_Datalisttype = "";
         Combo_networkindividualid_Datalistfixedvalues = "";
         Combo_networkindividualid_Remoteservicesparameters = "";
         Combo_networkindividualid_Htmltemplate = "";
         Combo_networkindividualid_Multiplevaluestype = "";
         Combo_networkindividualid_Loadingdata = "";
         Combo_networkindividualid_Noresultsfound = "";
         Combo_networkindividualid_Emptyitemtext = "";
         Combo_networkindividualid_Onlyselectedvalues = "";
         Combo_networkindividualid_Selectalltext = "";
         Combo_networkindividualid_Multiplevaluesseparator = "";
         Combo_networkindividualid_Addnewoptiontext = "";
         Combo_networkcompanyid_Objectcall = "";
         Combo_networkcompanyid_Class = "";
         Combo_networkcompanyid_Icontype = "";
         Combo_networkcompanyid_Icon = "";
         Combo_networkcompanyid_Tooltip = "";
         Combo_networkcompanyid_Selectedvalue_set = "";
         Combo_networkcompanyid_Selectedvalue_get = "";
         Combo_networkcompanyid_Selectedtext_set = "";
         Combo_networkcompanyid_Selectedtext_get = "";
         Combo_networkcompanyid_Gamoauthtoken = "";
         Combo_networkcompanyid_Ddointernalname = "";
         Combo_networkcompanyid_Titlecontrolalign = "";
         Combo_networkcompanyid_Dropdownoptionstype = "";
         Combo_networkcompanyid_Datalisttype = "";
         Combo_networkcompanyid_Datalistfixedvalues = "";
         Combo_networkcompanyid_Remoteservicesparameters = "";
         Combo_networkcompanyid_Htmltemplate = "";
         Combo_networkcompanyid_Multiplevaluestype = "";
         Combo_networkcompanyid_Loadingdata = "";
         Combo_networkcompanyid_Noresultsfound = "";
         Combo_networkcompanyid_Emptyitemtext = "";
         Combo_networkcompanyid_Onlyselectedvalues = "";
         Combo_networkcompanyid_Selectalltext = "";
         Combo_networkcompanyid_Multiplevaluesseparator = "";
         Combo_networkcompanyid_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode16 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A83NetworkCompanyKvkNumber = "";
         A85NetworkCompanyEmail = "";
         A86NetworkCompanyPhone = "";
         A349NetworkCompanyCountry = "";
         A350NetworkCompanyCity = "";
         A351NetworkCompanyZipCode = "";
         A352NetworkCompanyAddressLine1 = "";
         A353NetworkCompanyAddressLine2 = "";
         A76NetworkIndividualGivenName = "";
         A77NetworkIndividualLastName = "";
         A78NetworkIndividualEmail = "";
         A79NetworkIndividualPhone = "";
         A81NetworkIndividualGender = "";
         A344NetworkIndividualCountry = "";
         A345NetworkIndividualCity = "";
         A346NetworkIndividualZipCode = "";
         A347NetworkIndividualAddressLine1 = "";
         A348NetworkIndividualAddressLine2 = "";
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV23GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV24GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV13TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV14WebSession = context.GetSession();
         AV17TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV22Combo_DataJson = "";
         AV20ComboSelectedValue = "";
         AV21ComboSelectedText = "";
         Z97ResidentTypeName = "";
         Z99MedicalIndicationName = "";
         T000911_A97ResidentTypeName = new string[] {""} ;
         T000912_A99MedicalIndicationName = new string[] {""} ;
         T000913_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000913_A354ResidentCountry = new string[] {""} ;
         T000913_A375ResidentPhoneCode = new string[] {""} ;
         T000913_A445ResidentHomePhoneCode = new string[] {""} ;
         T000913_A71ResidentGUID = new string[] {""} ;
         T000913_A66ResidentInitials = new string[] {""} ;
         T000913_A70ResidentPhone = new string[] {""} ;
         T000913_A72ResidentSalutation = new string[] {""} ;
         T000913_A63ResidentBsnNumber = new string[] {""} ;
         T000913_A64ResidentGivenName = new string[] {""} ;
         T000913_A65ResidentLastName = new string[] {""} ;
         T000913_A67ResidentEmail = new string[] {""} ;
         T000913_A68ResidentGender = new string[] {""} ;
         T000913_A355ResidentCity = new string[] {""} ;
         T000913_A356ResidentZipCode = new string[] {""} ;
         T000913_A357ResidentAddressLine1 = new string[] {""} ;
         T000913_A358ResidentAddressLine2 = new string[] {""} ;
         T000913_A444ResidentHomePhone = new string[] {""} ;
         T000913_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         T000913_A97ResidentTypeName = new string[] {""} ;
         T000913_A99MedicalIndicationName = new string[] {""} ;
         T000913_A376ResidentPhoneNumber = new string[] {""} ;
         T000913_A446ResidentHomePhoneNumber = new string[] {""} ;
         T000913_A29LocationId = new Guid[] {Guid.Empty} ;
         T000913_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000913_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         T000913_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         T000913_n98MedicalIndicationId = new bool[] {false} ;
         T000910_A29LocationId = new Guid[] {Guid.Empty} ;
         T000914_A29LocationId = new Guid[] {Guid.Empty} ;
         T000915_A97ResidentTypeName = new string[] {""} ;
         T000916_A99MedicalIndicationName = new string[] {""} ;
         T000917_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000917_A29LocationId = new Guid[] {Guid.Empty} ;
         T000917_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00099_A62ResidentId = new Guid[] {Guid.Empty} ;
         T00099_A354ResidentCountry = new string[] {""} ;
         T00099_A375ResidentPhoneCode = new string[] {""} ;
         T00099_A445ResidentHomePhoneCode = new string[] {""} ;
         T00099_A71ResidentGUID = new string[] {""} ;
         T00099_A66ResidentInitials = new string[] {""} ;
         T00099_A70ResidentPhone = new string[] {""} ;
         T00099_A72ResidentSalutation = new string[] {""} ;
         T00099_A63ResidentBsnNumber = new string[] {""} ;
         T00099_A64ResidentGivenName = new string[] {""} ;
         T00099_A65ResidentLastName = new string[] {""} ;
         T00099_A67ResidentEmail = new string[] {""} ;
         T00099_A68ResidentGender = new string[] {""} ;
         T00099_A355ResidentCity = new string[] {""} ;
         T00099_A356ResidentZipCode = new string[] {""} ;
         T00099_A357ResidentAddressLine1 = new string[] {""} ;
         T00099_A358ResidentAddressLine2 = new string[] {""} ;
         T00099_A444ResidentHomePhone = new string[] {""} ;
         T00099_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         T00099_A376ResidentPhoneNumber = new string[] {""} ;
         T00099_A446ResidentHomePhoneNumber = new string[] {""} ;
         T00099_A29LocationId = new Guid[] {Guid.Empty} ;
         T00099_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00099_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         T00099_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         T00099_n98MedicalIndicationId = new bool[] {false} ;
         T000918_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000918_A29LocationId = new Guid[] {Guid.Empty} ;
         T000918_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000919_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000919_A29LocationId = new Guid[] {Guid.Empty} ;
         T000919_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00098_A62ResidentId = new Guid[] {Guid.Empty} ;
         T00098_A354ResidentCountry = new string[] {""} ;
         T00098_A375ResidentPhoneCode = new string[] {""} ;
         T00098_A445ResidentHomePhoneCode = new string[] {""} ;
         T00098_A71ResidentGUID = new string[] {""} ;
         T00098_A66ResidentInitials = new string[] {""} ;
         T00098_A70ResidentPhone = new string[] {""} ;
         T00098_A72ResidentSalutation = new string[] {""} ;
         T00098_A63ResidentBsnNumber = new string[] {""} ;
         T00098_A64ResidentGivenName = new string[] {""} ;
         T00098_A65ResidentLastName = new string[] {""} ;
         T00098_A67ResidentEmail = new string[] {""} ;
         T00098_A68ResidentGender = new string[] {""} ;
         T00098_A355ResidentCity = new string[] {""} ;
         T00098_A356ResidentZipCode = new string[] {""} ;
         T00098_A357ResidentAddressLine1 = new string[] {""} ;
         T00098_A358ResidentAddressLine2 = new string[] {""} ;
         T00098_A444ResidentHomePhone = new string[] {""} ;
         T00098_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         T00098_A376ResidentPhoneNumber = new string[] {""} ;
         T00098_A446ResidentHomePhoneNumber = new string[] {""} ;
         T00098_A29LocationId = new Guid[] {Guid.Empty} ;
         T00098_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00098_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         T00098_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         T00098_n98MedicalIndicationId = new bool[] {false} ;
         T000923_A97ResidentTypeName = new string[] {""} ;
         T000924_A99MedicalIndicationName = new string[] {""} ;
         T000925_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000925_A29LocationId = new Guid[] {Guid.Empty} ;
         T000925_A11OrganisationId = new Guid[] {Guid.Empty} ;
         Z75NetworkIndividualBsnNumber = "";
         Z76NetworkIndividualGivenName = "";
         Z77NetworkIndividualLastName = "";
         Z78NetworkIndividualEmail = "";
         Z79NetworkIndividualPhone = "";
         Z388NetworkIndividualPhoneNumber = "";
         Z387NetworkIndividualPhoneCode = "";
         Z81NetworkIndividualGender = "";
         Z344NetworkIndividualCountry = "";
         Z345NetworkIndividualCity = "";
         Z346NetworkIndividualZipCode = "";
         Z347NetworkIndividualAddressLine1 = "";
         Z348NetworkIndividualAddressLine2 = "";
         T000926_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000926_A29LocationId = new Guid[] {Guid.Empty} ;
         T000926_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000926_A75NetworkIndividualBsnNumber = new string[] {""} ;
         T000926_A76NetworkIndividualGivenName = new string[] {""} ;
         T000926_A77NetworkIndividualLastName = new string[] {""} ;
         T000926_A78NetworkIndividualEmail = new string[] {""} ;
         T000926_A79NetworkIndividualPhone = new string[] {""} ;
         T000926_A388NetworkIndividualPhoneNumber = new string[] {""} ;
         T000926_A387NetworkIndividualPhoneCode = new string[] {""} ;
         T000926_A81NetworkIndividualGender = new string[] {""} ;
         T000926_A344NetworkIndividualCountry = new string[] {""} ;
         T000926_A345NetworkIndividualCity = new string[] {""} ;
         T000926_A346NetworkIndividualZipCode = new string[] {""} ;
         T000926_A347NetworkIndividualAddressLine1 = new string[] {""} ;
         T000926_A348NetworkIndividualAddressLine2 = new string[] {""} ;
         T000926_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         T00097_A75NetworkIndividualBsnNumber = new string[] {""} ;
         T00097_A76NetworkIndividualGivenName = new string[] {""} ;
         T00097_A77NetworkIndividualLastName = new string[] {""} ;
         T00097_A78NetworkIndividualEmail = new string[] {""} ;
         T00097_A79NetworkIndividualPhone = new string[] {""} ;
         T00097_A388NetworkIndividualPhoneNumber = new string[] {""} ;
         T00097_A387NetworkIndividualPhoneCode = new string[] {""} ;
         T00097_A81NetworkIndividualGender = new string[] {""} ;
         T00097_A344NetworkIndividualCountry = new string[] {""} ;
         T00097_A345NetworkIndividualCity = new string[] {""} ;
         T00097_A346NetworkIndividualZipCode = new string[] {""} ;
         T00097_A347NetworkIndividualAddressLine1 = new string[] {""} ;
         T00097_A348NetworkIndividualAddressLine2 = new string[] {""} ;
         T000927_A75NetworkIndividualBsnNumber = new string[] {""} ;
         T000927_A76NetworkIndividualGivenName = new string[] {""} ;
         T000927_A77NetworkIndividualLastName = new string[] {""} ;
         T000927_A78NetworkIndividualEmail = new string[] {""} ;
         T000927_A79NetworkIndividualPhone = new string[] {""} ;
         T000927_A388NetworkIndividualPhoneNumber = new string[] {""} ;
         T000927_A387NetworkIndividualPhoneCode = new string[] {""} ;
         T000927_A81NetworkIndividualGender = new string[] {""} ;
         T000927_A344NetworkIndividualCountry = new string[] {""} ;
         T000927_A345NetworkIndividualCity = new string[] {""} ;
         T000927_A346NetworkIndividualZipCode = new string[] {""} ;
         T000927_A347NetworkIndividualAddressLine1 = new string[] {""} ;
         T000927_A348NetworkIndividualAddressLine2 = new string[] {""} ;
         T000928_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000928_A29LocationId = new Guid[] {Guid.Empty} ;
         T000928_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000928_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         T00096_A62ResidentId = new Guid[] {Guid.Empty} ;
         T00096_A29LocationId = new Guid[] {Guid.Empty} ;
         T00096_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00096_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         T00095_A62ResidentId = new Guid[] {Guid.Empty} ;
         T00095_A29LocationId = new Guid[] {Guid.Empty} ;
         T00095_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00095_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         T000931_A75NetworkIndividualBsnNumber = new string[] {""} ;
         T000931_A76NetworkIndividualGivenName = new string[] {""} ;
         T000931_A77NetworkIndividualLastName = new string[] {""} ;
         T000931_A78NetworkIndividualEmail = new string[] {""} ;
         T000931_A79NetworkIndividualPhone = new string[] {""} ;
         T000931_A388NetworkIndividualPhoneNumber = new string[] {""} ;
         T000931_A387NetworkIndividualPhoneCode = new string[] {""} ;
         T000931_A81NetworkIndividualGender = new string[] {""} ;
         T000931_A344NetworkIndividualCountry = new string[] {""} ;
         T000931_A345NetworkIndividualCity = new string[] {""} ;
         T000931_A346NetworkIndividualZipCode = new string[] {""} ;
         T000931_A347NetworkIndividualAddressLine1 = new string[] {""} ;
         T000931_A348NetworkIndividualAddressLine2 = new string[] {""} ;
         T000932_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000932_A29LocationId = new Guid[] {Guid.Empty} ;
         T000932_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000932_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         Z83NetworkCompanyKvkNumber = "";
         Z84NetworkCompanyName = "";
         Z85NetworkCompanyEmail = "";
         Z86NetworkCompanyPhone = "";
         Z392NetworkCompanyPhoneNumber = "";
         Z391NetworkCompanyPhoneCode = "";
         Z349NetworkCompanyCountry = "";
         Z350NetworkCompanyCity = "";
         Z351NetworkCompanyZipCode = "";
         Z352NetworkCompanyAddressLine1 = "";
         Z353NetworkCompanyAddressLine2 = "";
         T000933_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000933_A29LocationId = new Guid[] {Guid.Empty} ;
         T000933_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000933_A83NetworkCompanyKvkNumber = new string[] {""} ;
         T000933_A84NetworkCompanyName = new string[] {""} ;
         T000933_A85NetworkCompanyEmail = new string[] {""} ;
         T000933_A86NetworkCompanyPhone = new string[] {""} ;
         T000933_A392NetworkCompanyPhoneNumber = new string[] {""} ;
         T000933_A391NetworkCompanyPhoneCode = new string[] {""} ;
         T000933_A349NetworkCompanyCountry = new string[] {""} ;
         T000933_A350NetworkCompanyCity = new string[] {""} ;
         T000933_A351NetworkCompanyZipCode = new string[] {""} ;
         T000933_A352NetworkCompanyAddressLine1 = new string[] {""} ;
         T000933_A353NetworkCompanyAddressLine2 = new string[] {""} ;
         T000933_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         T00094_A83NetworkCompanyKvkNumber = new string[] {""} ;
         T00094_A84NetworkCompanyName = new string[] {""} ;
         T00094_A85NetworkCompanyEmail = new string[] {""} ;
         T00094_A86NetworkCompanyPhone = new string[] {""} ;
         T00094_A392NetworkCompanyPhoneNumber = new string[] {""} ;
         T00094_A391NetworkCompanyPhoneCode = new string[] {""} ;
         T00094_A349NetworkCompanyCountry = new string[] {""} ;
         T00094_A350NetworkCompanyCity = new string[] {""} ;
         T00094_A351NetworkCompanyZipCode = new string[] {""} ;
         T00094_A352NetworkCompanyAddressLine1 = new string[] {""} ;
         T00094_A353NetworkCompanyAddressLine2 = new string[] {""} ;
         T000934_A83NetworkCompanyKvkNumber = new string[] {""} ;
         T000934_A84NetworkCompanyName = new string[] {""} ;
         T000934_A85NetworkCompanyEmail = new string[] {""} ;
         T000934_A86NetworkCompanyPhone = new string[] {""} ;
         T000934_A392NetworkCompanyPhoneNumber = new string[] {""} ;
         T000934_A391NetworkCompanyPhoneCode = new string[] {""} ;
         T000934_A349NetworkCompanyCountry = new string[] {""} ;
         T000934_A350NetworkCompanyCity = new string[] {""} ;
         T000934_A351NetworkCompanyZipCode = new string[] {""} ;
         T000934_A352NetworkCompanyAddressLine1 = new string[] {""} ;
         T000934_A353NetworkCompanyAddressLine2 = new string[] {""} ;
         T000935_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         T000935_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000935_A29LocationId = new Guid[] {Guid.Empty} ;
         T000935_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00093_A62ResidentId = new Guid[] {Guid.Empty} ;
         T00093_A29LocationId = new Guid[] {Guid.Empty} ;
         T00093_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00093_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         T00092_A62ResidentId = new Guid[] {Guid.Empty} ;
         T00092_A29LocationId = new Guid[] {Guid.Empty} ;
         T00092_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00092_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         T000938_A83NetworkCompanyKvkNumber = new string[] {""} ;
         T000938_A84NetworkCompanyName = new string[] {""} ;
         T000938_A85NetworkCompanyEmail = new string[] {""} ;
         T000938_A86NetworkCompanyPhone = new string[] {""} ;
         T000938_A392NetworkCompanyPhoneNumber = new string[] {""} ;
         T000938_A391NetworkCompanyPhoneCode = new string[] {""} ;
         T000938_A349NetworkCompanyCountry = new string[] {""} ;
         T000938_A350NetworkCompanyCity = new string[] {""} ;
         T000938_A351NetworkCompanyZipCode = new string[] {""} ;
         T000938_A352NetworkCompanyAddressLine1 = new string[] {""} ;
         T000938_A353NetworkCompanyAddressLine2 = new string[] {""} ;
         T000939_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         T000939_A62ResidentId = new Guid[] {Guid.Empty} ;
         T000939_A29LocationId = new Guid[] {Guid.Empty} ;
         T000939_A11OrganisationId = new Guid[] {Guid.Empty} ;
         Gridlevel_networkindividualRow = new GXWebRow();
         subGridlevel_networkindividual_Linesclass = "";
         ROClassString = "";
         Gridlevel_networkcompanyRow = new GXWebRow();
         subGridlevel_networkcompany_Linesclass = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_networkindividualColumn = new GXWebColumn();
         Gridlevel_networkcompanyColumn = new GXWebColumn();
         GXt_guid3 = Guid.Empty;
         T000940_A29LocationId = new Guid[] {Guid.Empty} ;
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
               T00092_A62ResidentId, T00092_A29LocationId, T00092_A11OrganisationId, T00092_A82NetworkCompanyId
               }
               , new Object[] {
               T00093_A62ResidentId, T00093_A29LocationId, T00093_A11OrganisationId, T00093_A82NetworkCompanyId
               }
               , new Object[] {
               T00094_A83NetworkCompanyKvkNumber, T00094_A84NetworkCompanyName, T00094_A85NetworkCompanyEmail, T00094_A86NetworkCompanyPhone, T00094_A392NetworkCompanyPhoneNumber, T00094_A391NetworkCompanyPhoneCode, T00094_A349NetworkCompanyCountry, T00094_A350NetworkCompanyCity, T00094_A351NetworkCompanyZipCode, T00094_A352NetworkCompanyAddressLine1,
               T00094_A353NetworkCompanyAddressLine2
               }
               , new Object[] {
               T00095_A62ResidentId, T00095_A29LocationId, T00095_A11OrganisationId, T00095_A74NetworkIndividualId
               }
               , new Object[] {
               T00096_A62ResidentId, T00096_A29LocationId, T00096_A11OrganisationId, T00096_A74NetworkIndividualId
               }
               , new Object[] {
               T00097_A75NetworkIndividualBsnNumber, T00097_A76NetworkIndividualGivenName, T00097_A77NetworkIndividualLastName, T00097_A78NetworkIndividualEmail, T00097_A79NetworkIndividualPhone, T00097_A388NetworkIndividualPhoneNumber, T00097_A387NetworkIndividualPhoneCode, T00097_A81NetworkIndividualGender, T00097_A344NetworkIndividualCountry, T00097_A345NetworkIndividualCity,
               T00097_A346NetworkIndividualZipCode, T00097_A347NetworkIndividualAddressLine1, T00097_A348NetworkIndividualAddressLine2
               }
               , new Object[] {
               T00098_A62ResidentId, T00098_A354ResidentCountry, T00098_A375ResidentPhoneCode, T00098_A445ResidentHomePhoneCode, T00098_A71ResidentGUID, T00098_A66ResidentInitials, T00098_A70ResidentPhone, T00098_A72ResidentSalutation, T00098_A63ResidentBsnNumber, T00098_A64ResidentGivenName,
               T00098_A65ResidentLastName, T00098_A67ResidentEmail, T00098_A68ResidentGender, T00098_A355ResidentCity, T00098_A356ResidentZipCode, T00098_A357ResidentAddressLine1, T00098_A358ResidentAddressLine2, T00098_A444ResidentHomePhone, T00098_A73ResidentBirthDate, T00098_A376ResidentPhoneNumber,
               T00098_A446ResidentHomePhoneNumber, T00098_A29LocationId, T00098_A11OrganisationId, T00098_A96ResidentTypeId, T00098_A98MedicalIndicationId, T00098_n98MedicalIndicationId
               }
               , new Object[] {
               T00099_A62ResidentId, T00099_A354ResidentCountry, T00099_A375ResidentPhoneCode, T00099_A445ResidentHomePhoneCode, T00099_A71ResidentGUID, T00099_A66ResidentInitials, T00099_A70ResidentPhone, T00099_A72ResidentSalutation, T00099_A63ResidentBsnNumber, T00099_A64ResidentGivenName,
               T00099_A65ResidentLastName, T00099_A67ResidentEmail, T00099_A68ResidentGender, T00099_A355ResidentCity, T00099_A356ResidentZipCode, T00099_A357ResidentAddressLine1, T00099_A358ResidentAddressLine2, T00099_A444ResidentHomePhone, T00099_A73ResidentBirthDate, T00099_A376ResidentPhoneNumber,
               T00099_A446ResidentHomePhoneNumber, T00099_A29LocationId, T00099_A11OrganisationId, T00099_A96ResidentTypeId, T00099_A98MedicalIndicationId, T00099_n98MedicalIndicationId
               }
               , new Object[] {
               T000910_A29LocationId
               }
               , new Object[] {
               T000911_A97ResidentTypeName
               }
               , new Object[] {
               T000912_A99MedicalIndicationName
               }
               , new Object[] {
               T000913_A62ResidentId, T000913_A354ResidentCountry, T000913_A375ResidentPhoneCode, T000913_A445ResidentHomePhoneCode, T000913_A71ResidentGUID, T000913_A66ResidentInitials, T000913_A70ResidentPhone, T000913_A72ResidentSalutation, T000913_A63ResidentBsnNumber, T000913_A64ResidentGivenName,
               T000913_A65ResidentLastName, T000913_A67ResidentEmail, T000913_A68ResidentGender, T000913_A355ResidentCity, T000913_A356ResidentZipCode, T000913_A357ResidentAddressLine1, T000913_A358ResidentAddressLine2, T000913_A444ResidentHomePhone, T000913_A73ResidentBirthDate, T000913_A97ResidentTypeName,
               T000913_A99MedicalIndicationName, T000913_A376ResidentPhoneNumber, T000913_A446ResidentHomePhoneNumber, T000913_A29LocationId, T000913_A11OrganisationId, T000913_A96ResidentTypeId, T000913_A98MedicalIndicationId, T000913_n98MedicalIndicationId
               }
               , new Object[] {
               T000914_A29LocationId
               }
               , new Object[] {
               T000915_A97ResidentTypeName
               }
               , new Object[] {
               T000916_A99MedicalIndicationName
               }
               , new Object[] {
               T000917_A62ResidentId, T000917_A29LocationId, T000917_A11OrganisationId
               }
               , new Object[] {
               T000918_A62ResidentId, T000918_A29LocationId, T000918_A11OrganisationId
               }
               , new Object[] {
               T000919_A62ResidentId, T000919_A29LocationId, T000919_A11OrganisationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000923_A97ResidentTypeName
               }
               , new Object[] {
               T000924_A99MedicalIndicationName
               }
               , new Object[] {
               T000925_A62ResidentId, T000925_A29LocationId, T000925_A11OrganisationId
               }
               , new Object[] {
               T000926_A62ResidentId, T000926_A29LocationId, T000926_A11OrganisationId, T000926_A75NetworkIndividualBsnNumber, T000926_A76NetworkIndividualGivenName, T000926_A77NetworkIndividualLastName, T000926_A78NetworkIndividualEmail, T000926_A79NetworkIndividualPhone, T000926_A388NetworkIndividualPhoneNumber, T000926_A387NetworkIndividualPhoneCode,
               T000926_A81NetworkIndividualGender, T000926_A344NetworkIndividualCountry, T000926_A345NetworkIndividualCity, T000926_A346NetworkIndividualZipCode, T000926_A347NetworkIndividualAddressLine1, T000926_A348NetworkIndividualAddressLine2, T000926_A74NetworkIndividualId
               }
               , new Object[] {
               T000927_A75NetworkIndividualBsnNumber, T000927_A76NetworkIndividualGivenName, T000927_A77NetworkIndividualLastName, T000927_A78NetworkIndividualEmail, T000927_A79NetworkIndividualPhone, T000927_A388NetworkIndividualPhoneNumber, T000927_A387NetworkIndividualPhoneCode, T000927_A81NetworkIndividualGender, T000927_A344NetworkIndividualCountry, T000927_A345NetworkIndividualCity,
               T000927_A346NetworkIndividualZipCode, T000927_A347NetworkIndividualAddressLine1, T000927_A348NetworkIndividualAddressLine2
               }
               , new Object[] {
               T000928_A62ResidentId, T000928_A29LocationId, T000928_A11OrganisationId, T000928_A74NetworkIndividualId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000931_A75NetworkIndividualBsnNumber, T000931_A76NetworkIndividualGivenName, T000931_A77NetworkIndividualLastName, T000931_A78NetworkIndividualEmail, T000931_A79NetworkIndividualPhone, T000931_A388NetworkIndividualPhoneNumber, T000931_A387NetworkIndividualPhoneCode, T000931_A81NetworkIndividualGender, T000931_A344NetworkIndividualCountry, T000931_A345NetworkIndividualCity,
               T000931_A346NetworkIndividualZipCode, T000931_A347NetworkIndividualAddressLine1, T000931_A348NetworkIndividualAddressLine2
               }
               , new Object[] {
               T000932_A62ResidentId, T000932_A29LocationId, T000932_A11OrganisationId, T000932_A74NetworkIndividualId
               }
               , new Object[] {
               T000933_A62ResidentId, T000933_A29LocationId, T000933_A11OrganisationId, T000933_A83NetworkCompanyKvkNumber, T000933_A84NetworkCompanyName, T000933_A85NetworkCompanyEmail, T000933_A86NetworkCompanyPhone, T000933_A392NetworkCompanyPhoneNumber, T000933_A391NetworkCompanyPhoneCode, T000933_A349NetworkCompanyCountry,
               T000933_A350NetworkCompanyCity, T000933_A351NetworkCompanyZipCode, T000933_A352NetworkCompanyAddressLine1, T000933_A353NetworkCompanyAddressLine2, T000933_A82NetworkCompanyId
               }
               , new Object[] {
               T000934_A83NetworkCompanyKvkNumber, T000934_A84NetworkCompanyName, T000934_A85NetworkCompanyEmail, T000934_A86NetworkCompanyPhone, T000934_A392NetworkCompanyPhoneNumber, T000934_A391NetworkCompanyPhoneCode, T000934_A349NetworkCompanyCountry, T000934_A350NetworkCompanyCity, T000934_A351NetworkCompanyZipCode, T000934_A352NetworkCompanyAddressLine1,
               T000934_A353NetworkCompanyAddressLine2
               }
               , new Object[] {
               T000935_A82NetworkCompanyId, T000935_A62ResidentId, T000935_A29LocationId, T000935_A11OrganisationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000938_A83NetworkCompanyKvkNumber, T000938_A84NetworkCompanyName, T000938_A85NetworkCompanyEmail, T000938_A86NetworkCompanyPhone, T000938_A392NetworkCompanyPhoneNumber, T000938_A391NetworkCompanyPhoneCode, T000938_A349NetworkCompanyCountry, T000938_A350NetworkCompanyCity, T000938_A351NetworkCompanyZipCode, T000938_A352NetworkCompanyAddressLine1,
               T000938_A353NetworkCompanyAddressLine2
               }
               , new Object[] {
               T000939_A82NetworkCompanyId, T000939_A62ResidentId, T000939_A29LocationId, T000939_A11OrganisationId
               }
               , new Object[] {
               T000940_A29LocationId
               }
            }
         );
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z62ResidentId = Guid.NewGuid( );
         A62ResidentId = Guid.NewGuid( );
         Z62ResidentId = Guid.NewGuid( );
         A62ResidentId = Guid.NewGuid( );
         AV45Pgmname = "Trn_Resident";
      }

      private short nRcdDeleted_23 ;
      private short nRcdExists_23 ;
      private short nIsMod_23 ;
      private short nRcdDeleted_20 ;
      private short nRcdExists_20 ;
      private short nIsMod_20 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount23 ;
      private short RcdFound23 ;
      private short nBlankRcdUsr23 ;
      private short nBlankRcdCount20 ;
      private short RcdFound20 ;
      private short nBlankRcdUsr20 ;
      private short Gx_BScreen ;
      private short RcdFound16 ;
      private short nIsDirty_23 ;
      private short nIsDirty_20 ;
      private short subGridlevel_networkindividual_Backcolorstyle ;
      private short subGridlevel_networkindividual_Backstyle ;
      private short subGridlevel_networkcompany_Backcolorstyle ;
      private short subGridlevel_networkcompany_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_networkindividual_Allowselection ;
      private short subGridlevel_networkindividual_Allowhovering ;
      private short subGridlevel_networkindividual_Allowcollapsing ;
      private short subGridlevel_networkindividual_Collapsed ;
      private short subGridlevel_networkcompany_Allowselection ;
      private short subGridlevel_networkcompany_Allowhovering ;
      private short subGridlevel_networkcompany_Allowcollapsing ;
      private short subGridlevel_networkcompany_Collapsed ;
      private int nRC_GXsfl_150 ;
      private int nGXsfl_150_idx=1 ;
      private int nRC_GXsfl_167 ;
      private int nGXsfl_167_idx=1 ;
      private int trnEnded ;
      private int edtResidentBsnNumber_Enabled ;
      private int edtResidentGivenName_Enabled ;
      private int edtResidentLastName_Enabled ;
      private int edtResidentBirthDate_Enabled ;
      private int edtResidentEmail_Enabled ;
      private int edtResidentPhoneCode_Visible ;
      private int edtResidentPhoneCode_Enabled ;
      private int edtResidentPhoneNumber_Enabled ;
      private int edtResidentHomePhoneCode_Visible ;
      private int edtResidentHomePhoneCode_Enabled ;
      private int edtResidentHomePhoneNumber_Enabled ;
      private int edtResidentTypeId_Visible ;
      private int edtResidentTypeId_Enabled ;
      private int edtMedicalIndicationId_Visible ;
      private int edtMedicalIndicationId_Enabled ;
      private int edtResidentAddressLine1_Enabled ;
      private int edtResidentAddressLine2_Enabled ;
      private int edtResidentZipCode_Enabled ;
      private int edtResidentCity_Enabled ;
      private int edtResidentCountry_Visible ;
      private int edtResidentCountry_Enabled ;
      private int divTableleaflevel_networkindividual_Visible ;
      private int divTableleaflevel_networkcompany_Visible ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboresidentphonecode_Visible ;
      private int edtavComboresidentphonecode_Enabled ;
      private int edtavComboresidenthomephonecode_Visible ;
      private int edtavComboresidenthomephonecode_Enabled ;
      private int edtavComboresidenttypeid_Visible ;
      private int edtavComboresidenttypeid_Enabled ;
      private int edtavCombomedicalindicationid_Visible ;
      private int edtavCombomedicalindicationid_Enabled ;
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
      private int edtResidentPhone_Visible ;
      private int edtResidentPhone_Enabled ;
      private int edtResidentHomePhone_Visible ;
      private int edtResidentHomePhone_Enabled ;
      private int edtResidentGUID_Visible ;
      private int edtResidentGUID_Enabled ;
      private int edtNetworkIndividualId_Enabled ;
      private int edtNetworkIndividualGivenName_Enabled ;
      private int edtNetworkIndividualLastName_Enabled ;
      private int edtNetworkIndividualEmail_Enabled ;
      private int edtNetworkIndividualPhone_Enabled ;
      private int edtNetworkIndividualCountry_Enabled ;
      private int edtNetworkIndividualCity_Enabled ;
      private int edtNetworkIndividualZipCode_Enabled ;
      private int edtNetworkIndividualAddressLine1_Enabled ;
      private int edtNetworkIndividualAddressLine2_Enabled ;
      private int fRowAdded ;
      private int edtNetworkCompanyId_Enabled ;
      private int edtNetworkCompanyKvkNumber_Enabled ;
      private int edtNetworkCompanyEmail_Enabled ;
      private int edtNetworkCompanyPhone_Enabled ;
      private int edtNetworkCompanyCountry_Enabled ;
      private int edtNetworkCompanyCity_Enabled ;
      private int edtNetworkCompanyZipCode_Enabled ;
      private int edtNetworkCompanyAddressLine1_Enabled ;
      private int edtNetworkCompanyAddressLine2_Enabled ;
      private int Combo_residentphonecode_Datalistupdateminimumcharacters ;
      private int Combo_residentphonecode_Gxcontroltype ;
      private int Combo_residenthomephonecode_Datalistupdateminimumcharacters ;
      private int Combo_residenthomephonecode_Gxcontroltype ;
      private int Combo_residenttypeid_Datalistupdateminimumcharacters ;
      private int Combo_residenttypeid_Gxcontroltype ;
      private int Combo_medicalindicationid_Datalistupdateminimumcharacters ;
      private int Combo_medicalindicationid_Gxcontroltype ;
      private int Combo_residentcountry_Datalistupdateminimumcharacters ;
      private int Combo_residentcountry_Gxcontroltype ;
      private int Combo_networkindividualid_Datalistupdateminimumcharacters ;
      private int Combo_networkindividualid_Gxcontroltype ;
      private int Combo_networkcompanyid_Datalistupdateminimumcharacters ;
      private int Combo_networkcompanyid_Gxcontroltype ;
      private int AV46GXV1 ;
      private int subGridlevel_networkindividual_Backcolor ;
      private int subGridlevel_networkindividual_Allbackcolor ;
      private int subGridlevel_networkcompany_Backcolor ;
      private int subGridlevel_networkcompany_Allbackcolor ;
      private int defedtNetworkCompanyId_Enabled ;
      private int defedtNetworkIndividualId_Enabled ;
      private int idxLst ;
      private int subGridlevel_networkindividual_Selectedindex ;
      private int subGridlevel_networkindividual_Selectioncolor ;
      private int subGridlevel_networkindividual_Hoveringcolor ;
      private int subGridlevel_networkcompany_Selectedindex ;
      private int subGridlevel_networkcompany_Selectioncolor ;
      private int subGridlevel_networkcompany_Hoveringcolor ;
      private long GRIDLEVEL_NETWORKINDIVIDUAL_nFirstRecordOnPage ;
      private long GRIDLEVEL_NETWORKCOMPANY_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z66ResidentInitials ;
      private string Z70ResidentPhone ;
      private string Z72ResidentSalutation ;
      private string Z444ResidentHomePhone ;
      private string Combo_residentcountry_Selectedvalue_get ;
      private string Combo_medicalindicationid_Selectedvalue_get ;
      private string Combo_residenttypeid_Selectedvalue_get ;
      private string Combo_residenthomephonecode_Selectedvalue_get ;
      private string Combo_residentphonecode_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtResidentBsnNumber_Internalname ;
      private string sGXsfl_150_idx="0001" ;
      private string sGXsfl_167_idx="0001" ;
      private string A72ResidentSalutation ;
      private string cmbResidentSalutation_Internalname ;
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
      private string edtResidentBsnNumber_Jsonclick ;
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
      private string divTablesplittedresidentphonecode_Internalname ;
      private string lblTextblockresidentphonecode_Internalname ;
      private string lblTextblockresidentphonecode_Jsonclick ;
      private string sStyleString ;
      private string tblTablemergedresidentphonecode_Internalname ;
      private string Combo_residentphonecode_Caption ;
      private string Combo_residentphonecode_Cls ;
      private string Combo_residentphonecode_Internalname ;
      private string edtResidentPhoneCode_Internalname ;
      private string edtResidentPhoneCode_Jsonclick ;
      private string edtResidentPhoneNumber_Internalname ;
      private string edtResidentPhoneNumber_Jsonclick ;
      private string divTablesplittedresidenthomephonecode_Internalname ;
      private string lblTextblockresidenthomephonecode_Internalname ;
      private string lblTextblockresidenthomephonecode_Jsonclick ;
      private string tblTablemergedresidenthomephonecode_Internalname ;
      private string Combo_residenthomephonecode_Caption ;
      private string Combo_residenthomephonecode_Cls ;
      private string Combo_residenthomephonecode_Internalname ;
      private string edtResidentHomePhoneCode_Internalname ;
      private string edtResidentHomePhoneCode_Jsonclick ;
      private string edtResidentHomePhoneNumber_Internalname ;
      private string edtResidentHomePhoneNumber_Jsonclick ;
      private string divTablesplittedresidenttypeid_Internalname ;
      private string lblTextblockresidenttypeid_Internalname ;
      private string lblTextblockresidenttypeid_Jsonclick ;
      private string Combo_residenttypeid_Caption ;
      private string Combo_residenttypeid_Cls ;
      private string Combo_residenttypeid_Datalistproc ;
      private string Combo_residenttypeid_Datalistprocparametersprefix ;
      private string Combo_residenttypeid_Internalname ;
      private string edtResidentTypeId_Internalname ;
      private string edtResidentTypeId_Jsonclick ;
      private string divTablesplittedmedicalindicationid_Internalname ;
      private string lblTextblockmedicalindicationid_Internalname ;
      private string lblTextblockmedicalindicationid_Jsonclick ;
      private string Combo_medicalindicationid_Caption ;
      private string Combo_medicalindicationid_Cls ;
      private string Combo_medicalindicationid_Datalistproc ;
      private string Combo_medicalindicationid_Datalistprocparametersprefix ;
      private string Combo_medicalindicationid_Internalname ;
      private string edtMedicalIndicationId_Internalname ;
      private string edtMedicalIndicationId_Jsonclick ;
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
      private string divTableleaflevel_networkindividual_Internalname ;
      private string divTableleaflevel_networkcompany_Internalname ;
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
      private string divSectionattribute_residenttypeid_Internalname ;
      private string edtavComboresidenttypeid_Internalname ;
      private string edtavComboresidenttypeid_Jsonclick ;
      private string divSectionattribute_medicalindicationid_Internalname ;
      private string edtavCombomedicalindicationid_Internalname ;
      private string edtavCombomedicalindicationid_Jsonclick ;
      private string divSectionattribute_residentcountry_Internalname ;
      private string edtavComboresidentcountry_Internalname ;
      private string edtavComboresidentcountry_Jsonclick ;
      private string Combo_networkindividualid_Caption ;
      private string Combo_networkindividualid_Cls ;
      private string Combo_networkindividualid_Datalistproc ;
      private string Combo_networkindividualid_Datalistprocparametersprefix ;
      private string Combo_networkindividualid_Internalname ;
      private string Combo_networkcompanyid_Caption ;
      private string Combo_networkcompanyid_Cls ;
      private string Combo_networkcompanyid_Datalistproc ;
      private string Combo_networkcompanyid_Datalistprocparametersprefix ;
      private string Combo_networkcompanyid_Internalname ;
      private string edtResidentId_Internalname ;
      private string edtResidentId_Jsonclick ;
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string edtResidentInitials_Internalname ;
      private string A66ResidentInitials ;
      private string edtResidentInitials_Jsonclick ;
      private string gxphoneLink ;
      private string A70ResidentPhone ;
      private string edtResidentPhone_Internalname ;
      private string edtResidentPhone_Jsonclick ;
      private string A444ResidentHomePhone ;
      private string edtResidentHomePhone_Internalname ;
      private string edtResidentHomePhone_Jsonclick ;
      private string edtResidentGUID_Internalname ;
      private string edtResidentGUID_Jsonclick ;
      private string sMode23 ;
      private string edtNetworkIndividualId_Internalname ;
      private string edtNetworkIndividualGivenName_Internalname ;
      private string edtNetworkIndividualLastName_Internalname ;
      private string edtNetworkIndividualEmail_Internalname ;
      private string edtNetworkIndividualPhone_Internalname ;
      private string cmbNetworkIndividualGender_Internalname ;
      private string edtNetworkIndividualCountry_Internalname ;
      private string edtNetworkIndividualCity_Internalname ;
      private string edtNetworkIndividualZipCode_Internalname ;
      private string edtNetworkIndividualAddressLine1_Internalname ;
      private string edtNetworkIndividualAddressLine2_Internalname ;
      private string subGridlevel_networkindividual_Internalname ;
      private string sMode20 ;
      private string edtNetworkCompanyId_Internalname ;
      private string edtNetworkCompanyKvkNumber_Internalname ;
      private string edtNetworkCompanyEmail_Internalname ;
      private string edtNetworkCompanyPhone_Internalname ;
      private string edtNetworkCompanyCountry_Internalname ;
      private string edtNetworkCompanyCity_Internalname ;
      private string edtNetworkCompanyZipCode_Internalname ;
      private string edtNetworkCompanyAddressLine1_Internalname ;
      private string edtNetworkCompanyAddressLine2_Internalname ;
      private string subGridlevel_networkcompany_Internalname ;
      private string AV45Pgmname ;
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
      private string Combo_residenttypeid_Objectcall ;
      private string Combo_residenttypeid_Class ;
      private string Combo_residenttypeid_Icontype ;
      private string Combo_residenttypeid_Icon ;
      private string Combo_residenttypeid_Tooltip ;
      private string Combo_residenttypeid_Selectedvalue_set ;
      private string Combo_residenttypeid_Selectedtext_set ;
      private string Combo_residenttypeid_Selectedtext_get ;
      private string Combo_residenttypeid_Gamoauthtoken ;
      private string Combo_residenttypeid_Ddointernalname ;
      private string Combo_residenttypeid_Titlecontrolalign ;
      private string Combo_residenttypeid_Dropdownoptionstype ;
      private string Combo_residenttypeid_Titlecontrolidtoreplace ;
      private string Combo_residenttypeid_Datalisttype ;
      private string Combo_residenttypeid_Datalistfixedvalues ;
      private string Combo_residenttypeid_Remoteservicesparameters ;
      private string Combo_residenttypeid_Htmltemplate ;
      private string Combo_residenttypeid_Multiplevaluestype ;
      private string Combo_residenttypeid_Loadingdata ;
      private string Combo_residenttypeid_Noresultsfound ;
      private string Combo_residenttypeid_Emptyitemtext ;
      private string Combo_residenttypeid_Onlyselectedvalues ;
      private string Combo_residenttypeid_Selectalltext ;
      private string Combo_residenttypeid_Multiplevaluesseparator ;
      private string Combo_residenttypeid_Addnewoptiontext ;
      private string Combo_medicalindicationid_Objectcall ;
      private string Combo_medicalindicationid_Class ;
      private string Combo_medicalindicationid_Icontype ;
      private string Combo_medicalindicationid_Icon ;
      private string Combo_medicalindicationid_Tooltip ;
      private string Combo_medicalindicationid_Selectedvalue_set ;
      private string Combo_medicalindicationid_Selectedtext_set ;
      private string Combo_medicalindicationid_Selectedtext_get ;
      private string Combo_medicalindicationid_Gamoauthtoken ;
      private string Combo_medicalindicationid_Ddointernalname ;
      private string Combo_medicalindicationid_Titlecontrolalign ;
      private string Combo_medicalindicationid_Dropdownoptionstype ;
      private string Combo_medicalindicationid_Titlecontrolidtoreplace ;
      private string Combo_medicalindicationid_Datalisttype ;
      private string Combo_medicalindicationid_Datalistfixedvalues ;
      private string Combo_medicalindicationid_Remoteservicesparameters ;
      private string Combo_medicalindicationid_Htmltemplate ;
      private string Combo_medicalindicationid_Multiplevaluestype ;
      private string Combo_medicalindicationid_Loadingdata ;
      private string Combo_medicalindicationid_Noresultsfound ;
      private string Combo_medicalindicationid_Emptyitemtext ;
      private string Combo_medicalindicationid_Onlyselectedvalues ;
      private string Combo_medicalindicationid_Selectalltext ;
      private string Combo_medicalindicationid_Multiplevaluesseparator ;
      private string Combo_medicalindicationid_Addnewoptiontext ;
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
      private string Combo_networkindividualid_Objectcall ;
      private string Combo_networkindividualid_Class ;
      private string Combo_networkindividualid_Icontype ;
      private string Combo_networkindividualid_Icon ;
      private string Combo_networkindividualid_Tooltip ;
      private string Combo_networkindividualid_Selectedvalue_set ;
      private string Combo_networkindividualid_Selectedvalue_get ;
      private string Combo_networkindividualid_Selectedtext_set ;
      private string Combo_networkindividualid_Selectedtext_get ;
      private string Combo_networkindividualid_Gamoauthtoken ;
      private string Combo_networkindividualid_Ddointernalname ;
      private string Combo_networkindividualid_Titlecontrolalign ;
      private string Combo_networkindividualid_Dropdownoptionstype ;
      private string Combo_networkindividualid_Titlecontrolidtoreplace ;
      private string Combo_networkindividualid_Datalisttype ;
      private string Combo_networkindividualid_Datalistfixedvalues ;
      private string Combo_networkindividualid_Remoteservicesparameters ;
      private string Combo_networkindividualid_Htmltemplate ;
      private string Combo_networkindividualid_Multiplevaluestype ;
      private string Combo_networkindividualid_Loadingdata ;
      private string Combo_networkindividualid_Noresultsfound ;
      private string Combo_networkindividualid_Emptyitemtext ;
      private string Combo_networkindividualid_Onlyselectedvalues ;
      private string Combo_networkindividualid_Selectalltext ;
      private string Combo_networkindividualid_Multiplevaluesseparator ;
      private string Combo_networkindividualid_Addnewoptiontext ;
      private string Combo_networkcompanyid_Objectcall ;
      private string Combo_networkcompanyid_Class ;
      private string Combo_networkcompanyid_Icontype ;
      private string Combo_networkcompanyid_Icon ;
      private string Combo_networkcompanyid_Tooltip ;
      private string Combo_networkcompanyid_Selectedvalue_set ;
      private string Combo_networkcompanyid_Selectedvalue_get ;
      private string Combo_networkcompanyid_Selectedtext_set ;
      private string Combo_networkcompanyid_Selectedtext_get ;
      private string Combo_networkcompanyid_Gamoauthtoken ;
      private string Combo_networkcompanyid_Ddointernalname ;
      private string Combo_networkcompanyid_Titlecontrolalign ;
      private string Combo_networkcompanyid_Dropdownoptionstype ;
      private string Combo_networkcompanyid_Titlecontrolidtoreplace ;
      private string Combo_networkcompanyid_Datalisttype ;
      private string Combo_networkcompanyid_Datalistfixedvalues ;
      private string Combo_networkcompanyid_Remoteservicesparameters ;
      private string Combo_networkcompanyid_Htmltemplate ;
      private string Combo_networkcompanyid_Multiplevaluestype ;
      private string Combo_networkcompanyid_Loadingdata ;
      private string Combo_networkcompanyid_Noresultsfound ;
      private string Combo_networkcompanyid_Emptyitemtext ;
      private string Combo_networkcompanyid_Onlyselectedvalues ;
      private string Combo_networkcompanyid_Selectalltext ;
      private string Combo_networkcompanyid_Multiplevaluesseparator ;
      private string Combo_networkcompanyid_Addnewoptiontext ;
      private string hsh ;
      private string sMode16 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A86NetworkCompanyPhone ;
      private string A79NetworkIndividualPhone ;
      private string Z79NetworkIndividualPhone ;
      private string Z86NetworkCompanyPhone ;
      private string sGXsfl_150_fel_idx="0001" ;
      private string subGridlevel_networkindividual_Class ;
      private string subGridlevel_networkindividual_Linesclass ;
      private string ROClassString ;
      private string edtNetworkIndividualId_Jsonclick ;
      private string edtNetworkIndividualGivenName_Jsonclick ;
      private string edtNetworkIndividualLastName_Jsonclick ;
      private string edtNetworkIndividualEmail_Jsonclick ;
      private string edtNetworkIndividualPhone_Jsonclick ;
      private string cmbNetworkIndividualGender_Jsonclick ;
      private string edtNetworkIndividualCountry_Jsonclick ;
      private string edtNetworkIndividualCity_Jsonclick ;
      private string edtNetworkIndividualZipCode_Jsonclick ;
      private string edtNetworkIndividualAddressLine1_Jsonclick ;
      private string edtNetworkIndividualAddressLine2_Jsonclick ;
      private string sGXsfl_167_fel_idx="0001" ;
      private string subGridlevel_networkcompany_Class ;
      private string subGridlevel_networkcompany_Linesclass ;
      private string edtNetworkCompanyId_Jsonclick ;
      private string edtNetworkCompanyKvkNumber_Jsonclick ;
      private string edtNetworkCompanyEmail_Jsonclick ;
      private string edtNetworkCompanyPhone_Jsonclick ;
      private string edtNetworkCompanyCountry_Jsonclick ;
      private string edtNetworkCompanyCity_Jsonclick ;
      private string edtNetworkCompanyZipCode_Jsonclick ;
      private string edtNetworkCompanyAddressLine1_Jsonclick ;
      private string edtNetworkCompanyAddressLine2_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_networkindividual_Header ;
      private string subGridlevel_networkcompany_Header ;
      private string GXt_char2 ;
      private DateTime Z73ResidentBirthDate ;
      private DateTime A73ResidentBirthDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n98MedicalIndicationId ;
      private bool wbErr ;
      private bool Combo_residentphonecode_Emptyitem ;
      private bool Combo_residenthomephonecode_Emptyitem ;
      private bool Combo_residenttypeid_Emptyitem ;
      private bool Combo_residentcountry_Emptyitem ;
      private bool Combo_networkindividualid_Isgriditem ;
      private bool Combo_networkindividualid_Hasdescription ;
      private bool Combo_networkindividualid_Emptyitem ;
      private bool Combo_networkcompanyid_Isgriditem ;
      private bool Combo_networkcompanyid_Hasdescription ;
      private bool Combo_networkcompanyid_Emptyitem ;
      private bool bGXsfl_150_Refreshing=false ;
      private bool bGXsfl_167_Refreshing=false ;
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
      private bool Combo_residenttypeid_Enabled ;
      private bool Combo_residenttypeid_Visible ;
      private bool Combo_residenttypeid_Allowmultipleselection ;
      private bool Combo_residenttypeid_Isgriditem ;
      private bool Combo_residenttypeid_Hasdescription ;
      private bool Combo_residenttypeid_Includeonlyselectedoption ;
      private bool Combo_residenttypeid_Includeselectalloption ;
      private bool Combo_residenttypeid_Includeaddnewoption ;
      private bool Combo_medicalindicationid_Enabled ;
      private bool Combo_medicalindicationid_Visible ;
      private bool Combo_medicalindicationid_Allowmultipleselection ;
      private bool Combo_medicalindicationid_Isgriditem ;
      private bool Combo_medicalindicationid_Hasdescription ;
      private bool Combo_medicalindicationid_Includeonlyselectedoption ;
      private bool Combo_medicalindicationid_Includeselectalloption ;
      private bool Combo_medicalindicationid_Emptyitem ;
      private bool Combo_medicalindicationid_Includeaddnewoption ;
      private bool Combo_residentcountry_Enabled ;
      private bool Combo_residentcountry_Visible ;
      private bool Combo_residentcountry_Allowmultipleselection ;
      private bool Combo_residentcountry_Isgriditem ;
      private bool Combo_residentcountry_Hasdescription ;
      private bool Combo_residentcountry_Includeonlyselectedoption ;
      private bool Combo_residentcountry_Includeselectalloption ;
      private bool Combo_residentcountry_Includeaddnewoption ;
      private bool Combo_networkindividualid_Enabled ;
      private bool Combo_networkindividualid_Visible ;
      private bool Combo_networkindividualid_Allowmultipleselection ;
      private bool Combo_networkindividualid_Includeonlyselectedoption ;
      private bool Combo_networkindividualid_Includeselectalloption ;
      private bool Combo_networkindividualid_Includeaddnewoption ;
      private bool Combo_networkcompanyid_Enabled ;
      private bool Combo_networkcompanyid_Visible ;
      private bool Combo_networkcompanyid_Allowmultipleselection ;
      private bool Combo_networkcompanyid_Includeonlyselectedoption ;
      private bool Combo_networkcompanyid_Includeselectalloption ;
      private bool Combo_networkcompanyid_Includeaddnewoption ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV36GAMErrorResponse ;
      private string AV22Combo_DataJson ;
      private string Z354ResidentCountry ;
      private string Z375ResidentPhoneCode ;
      private string Z445ResidentHomePhoneCode ;
      private string Z71ResidentGUID ;
      private string Z63ResidentBsnNumber ;
      private string Z64ResidentGivenName ;
      private string Z65ResidentLastName ;
      private string Z67ResidentEmail ;
      private string Z68ResidentGender ;
      private string Z355ResidentCity ;
      private string Z356ResidentZipCode ;
      private string Z357ResidentAddressLine1 ;
      private string Z358ResidentAddressLine2 ;
      private string Z376ResidentPhoneNumber ;
      private string Z446ResidentHomePhoneNumber ;
      private string A67ResidentEmail ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A71ResidentGUID ;
      private string A375ResidentPhoneCode ;
      private string A376ResidentPhoneNumber ;
      private string A68ResidentGender ;
      private string A63ResidentBsnNumber ;
      private string A445ResidentHomePhoneCode ;
      private string A446ResidentHomePhoneNumber ;
      private string A357ResidentAddressLine1 ;
      private string A358ResidentAddressLine2 ;
      private string A356ResidentZipCode ;
      private string A355ResidentCity ;
      private string A354ResidentCountry ;
      private string AV39ComboResidentPhoneCode ;
      private string AV44ComboResidentHomePhoneCode ;
      private string AV38ComboResidentCountry ;
      private string A97ResidentTypeName ;
      private string A99MedicalIndicationName ;
      private string A75NetworkIndividualBsnNumber ;
      private string A388NetworkIndividualPhoneNumber ;
      private string A387NetworkIndividualPhoneCode ;
      private string A84NetworkCompanyName ;
      private string A392NetworkCompanyPhoneNumber ;
      private string A391NetworkCompanyPhoneCode ;
      private string A83NetworkCompanyKvkNumber ;
      private string A85NetworkCompanyEmail ;
      private string A349NetworkCompanyCountry ;
      private string A350NetworkCompanyCity ;
      private string A351NetworkCompanyZipCode ;
      private string A352NetworkCompanyAddressLine1 ;
      private string A353NetworkCompanyAddressLine2 ;
      private string A76NetworkIndividualGivenName ;
      private string A77NetworkIndividualLastName ;
      private string A78NetworkIndividualEmail ;
      private string A81NetworkIndividualGender ;
      private string A344NetworkIndividualCountry ;
      private string A345NetworkIndividualCity ;
      private string A346NetworkIndividualZipCode ;
      private string A347NetworkIndividualAddressLine1 ;
      private string A348NetworkIndividualAddressLine2 ;
      private string AV20ComboSelectedValue ;
      private string AV21ComboSelectedText ;
      private string Z97ResidentTypeName ;
      private string Z99MedicalIndicationName ;
      private string Z75NetworkIndividualBsnNumber ;
      private string Z76NetworkIndividualGivenName ;
      private string Z77NetworkIndividualLastName ;
      private string Z78NetworkIndividualEmail ;
      private string Z388NetworkIndividualPhoneNumber ;
      private string Z387NetworkIndividualPhoneCode ;
      private string Z81NetworkIndividualGender ;
      private string Z344NetworkIndividualCountry ;
      private string Z345NetworkIndividualCity ;
      private string Z346NetworkIndividualZipCode ;
      private string Z347NetworkIndividualAddressLine1 ;
      private string Z348NetworkIndividualAddressLine2 ;
      private string Z83NetworkCompanyKvkNumber ;
      private string Z84NetworkCompanyName ;
      private string Z85NetworkCompanyEmail ;
      private string Z392NetworkCompanyPhoneNumber ;
      private string Z391NetworkCompanyPhoneCode ;
      private string Z349NetworkCompanyCountry ;
      private string Z350NetworkCompanyCity ;
      private string Z351NetworkCompanyZipCode ;
      private string Z352NetworkCompanyAddressLine1 ;
      private string Z353NetworkCompanyAddressLine2 ;
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
      private Guid Z74NetworkIndividualId ;
      private Guid Z82NetworkCompanyId ;
      private Guid AV8LocationId ;
      private Guid AV9OrganisationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A96ResidentTypeId ;
      private Guid A98MedicalIndicationId ;
      private Guid A74NetworkIndividualId ;
      private Guid A82NetworkCompanyId ;
      private Guid AV7ResidentId ;
      private Guid AV32ComboResidentTypeId ;
      private Guid AV34ComboMedicalIndicationId ;
      private Guid A62ResidentId ;
      private Guid AV15Insert_ResidentTypeId ;
      private Guid AV16Insert_MedicalIndicationId ;
      private Guid GXt_guid3 ;
      private IGxSession AV14WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_networkindividualContainer ;
      private GXWebGrid Gridlevel_networkcompanyContainer ;
      private GXWebRow Gridlevel_networkindividualRow ;
      private GXWebRow Gridlevel_networkcompanyRow ;
      private GXWebColumn Gridlevel_networkindividualColumn ;
      private GXWebColumn Gridlevel_networkcompanyColumn ;
      private GXUserControl ucCombo_residentphonecode ;
      private GXUserControl ucCombo_residenthomephonecode ;
      private GXUserControl ucCombo_residenttypeid ;
      private GXUserControl ucCombo_medicalindicationid ;
      private GXUserControl ucCombo_residentcountry ;
      private GXUserControl ucCombo_networkindividualid ;
      private GXUserControl ucCombo_networkcompanyid ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbResidentSalutation ;
      private GXCombobox cmbResidentGender ;
      private GXCombobox cmbNetworkIndividualGender ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV19DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV41ResidentPhoneCode_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV43ResidentHomePhoneCode_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV31ResidentTypeId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV33MedicalIndicationId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV37ResidentCountry_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV25NetworkIndividualId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV18NetworkCompanyId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV42AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV23GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV24GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV13TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T000911_A97ResidentTypeName ;
      private string[] T000912_A99MedicalIndicationName ;
      private Guid[] T000913_A62ResidentId ;
      private string[] T000913_A354ResidentCountry ;
      private string[] T000913_A375ResidentPhoneCode ;
      private string[] T000913_A445ResidentHomePhoneCode ;
      private string[] T000913_A71ResidentGUID ;
      private string[] T000913_A66ResidentInitials ;
      private string[] T000913_A70ResidentPhone ;
      private string[] T000913_A72ResidentSalutation ;
      private string[] T000913_A63ResidentBsnNumber ;
      private string[] T000913_A64ResidentGivenName ;
      private string[] T000913_A65ResidentLastName ;
      private string[] T000913_A67ResidentEmail ;
      private string[] T000913_A68ResidentGender ;
      private string[] T000913_A355ResidentCity ;
      private string[] T000913_A356ResidentZipCode ;
      private string[] T000913_A357ResidentAddressLine1 ;
      private string[] T000913_A358ResidentAddressLine2 ;
      private string[] T000913_A444ResidentHomePhone ;
      private DateTime[] T000913_A73ResidentBirthDate ;
      private string[] T000913_A97ResidentTypeName ;
      private string[] T000913_A99MedicalIndicationName ;
      private string[] T000913_A376ResidentPhoneNumber ;
      private string[] T000913_A446ResidentHomePhoneNumber ;
      private Guid[] T000913_A29LocationId ;
      private Guid[] T000913_A11OrganisationId ;
      private Guid[] T000913_A96ResidentTypeId ;
      private Guid[] T000913_A98MedicalIndicationId ;
      private bool[] T000913_n98MedicalIndicationId ;
      private Guid[] T000910_A29LocationId ;
      private Guid[] T000914_A29LocationId ;
      private string[] T000915_A97ResidentTypeName ;
      private string[] T000916_A99MedicalIndicationName ;
      private Guid[] T000917_A62ResidentId ;
      private Guid[] T000917_A29LocationId ;
      private Guid[] T000917_A11OrganisationId ;
      private Guid[] T00099_A62ResidentId ;
      private string[] T00099_A354ResidentCountry ;
      private string[] T00099_A375ResidentPhoneCode ;
      private string[] T00099_A445ResidentHomePhoneCode ;
      private string[] T00099_A71ResidentGUID ;
      private string[] T00099_A66ResidentInitials ;
      private string[] T00099_A70ResidentPhone ;
      private string[] T00099_A72ResidentSalutation ;
      private string[] T00099_A63ResidentBsnNumber ;
      private string[] T00099_A64ResidentGivenName ;
      private string[] T00099_A65ResidentLastName ;
      private string[] T00099_A67ResidentEmail ;
      private string[] T00099_A68ResidentGender ;
      private string[] T00099_A355ResidentCity ;
      private string[] T00099_A356ResidentZipCode ;
      private string[] T00099_A357ResidentAddressLine1 ;
      private string[] T00099_A358ResidentAddressLine2 ;
      private string[] T00099_A444ResidentHomePhone ;
      private DateTime[] T00099_A73ResidentBirthDate ;
      private string[] T00099_A376ResidentPhoneNumber ;
      private string[] T00099_A446ResidentHomePhoneNumber ;
      private Guid[] T00099_A29LocationId ;
      private Guid[] T00099_A11OrganisationId ;
      private Guid[] T00099_A96ResidentTypeId ;
      private Guid[] T00099_A98MedicalIndicationId ;
      private bool[] T00099_n98MedicalIndicationId ;
      private Guid[] T000918_A62ResidentId ;
      private Guid[] T000918_A29LocationId ;
      private Guid[] T000918_A11OrganisationId ;
      private Guid[] T000919_A62ResidentId ;
      private Guid[] T000919_A29LocationId ;
      private Guid[] T000919_A11OrganisationId ;
      private Guid[] T00098_A62ResidentId ;
      private string[] T00098_A354ResidentCountry ;
      private string[] T00098_A375ResidentPhoneCode ;
      private string[] T00098_A445ResidentHomePhoneCode ;
      private string[] T00098_A71ResidentGUID ;
      private string[] T00098_A66ResidentInitials ;
      private string[] T00098_A70ResidentPhone ;
      private string[] T00098_A72ResidentSalutation ;
      private string[] T00098_A63ResidentBsnNumber ;
      private string[] T00098_A64ResidentGivenName ;
      private string[] T00098_A65ResidentLastName ;
      private string[] T00098_A67ResidentEmail ;
      private string[] T00098_A68ResidentGender ;
      private string[] T00098_A355ResidentCity ;
      private string[] T00098_A356ResidentZipCode ;
      private string[] T00098_A357ResidentAddressLine1 ;
      private string[] T00098_A358ResidentAddressLine2 ;
      private string[] T00098_A444ResidentHomePhone ;
      private DateTime[] T00098_A73ResidentBirthDate ;
      private string[] T00098_A376ResidentPhoneNumber ;
      private string[] T00098_A446ResidentHomePhoneNumber ;
      private Guid[] T00098_A29LocationId ;
      private Guid[] T00098_A11OrganisationId ;
      private Guid[] T00098_A96ResidentTypeId ;
      private Guid[] T00098_A98MedicalIndicationId ;
      private bool[] T00098_n98MedicalIndicationId ;
      private string[] T000923_A97ResidentTypeName ;
      private string[] T000924_A99MedicalIndicationName ;
      private Guid[] T000925_A62ResidentId ;
      private Guid[] T000925_A29LocationId ;
      private Guid[] T000925_A11OrganisationId ;
      private Guid[] T000926_A62ResidentId ;
      private Guid[] T000926_A29LocationId ;
      private Guid[] T000926_A11OrganisationId ;
      private string[] T000926_A75NetworkIndividualBsnNumber ;
      private string[] T000926_A76NetworkIndividualGivenName ;
      private string[] T000926_A77NetworkIndividualLastName ;
      private string[] T000926_A78NetworkIndividualEmail ;
      private string[] T000926_A79NetworkIndividualPhone ;
      private string[] T000926_A388NetworkIndividualPhoneNumber ;
      private string[] T000926_A387NetworkIndividualPhoneCode ;
      private string[] T000926_A81NetworkIndividualGender ;
      private string[] T000926_A344NetworkIndividualCountry ;
      private string[] T000926_A345NetworkIndividualCity ;
      private string[] T000926_A346NetworkIndividualZipCode ;
      private string[] T000926_A347NetworkIndividualAddressLine1 ;
      private string[] T000926_A348NetworkIndividualAddressLine2 ;
      private Guid[] T000926_A74NetworkIndividualId ;
      private string[] T00097_A75NetworkIndividualBsnNumber ;
      private string[] T00097_A76NetworkIndividualGivenName ;
      private string[] T00097_A77NetworkIndividualLastName ;
      private string[] T00097_A78NetworkIndividualEmail ;
      private string[] T00097_A79NetworkIndividualPhone ;
      private string[] T00097_A388NetworkIndividualPhoneNumber ;
      private string[] T00097_A387NetworkIndividualPhoneCode ;
      private string[] T00097_A81NetworkIndividualGender ;
      private string[] T00097_A344NetworkIndividualCountry ;
      private string[] T00097_A345NetworkIndividualCity ;
      private string[] T00097_A346NetworkIndividualZipCode ;
      private string[] T00097_A347NetworkIndividualAddressLine1 ;
      private string[] T00097_A348NetworkIndividualAddressLine2 ;
      private string[] T000927_A75NetworkIndividualBsnNumber ;
      private string[] T000927_A76NetworkIndividualGivenName ;
      private string[] T000927_A77NetworkIndividualLastName ;
      private string[] T000927_A78NetworkIndividualEmail ;
      private string[] T000927_A79NetworkIndividualPhone ;
      private string[] T000927_A388NetworkIndividualPhoneNumber ;
      private string[] T000927_A387NetworkIndividualPhoneCode ;
      private string[] T000927_A81NetworkIndividualGender ;
      private string[] T000927_A344NetworkIndividualCountry ;
      private string[] T000927_A345NetworkIndividualCity ;
      private string[] T000927_A346NetworkIndividualZipCode ;
      private string[] T000927_A347NetworkIndividualAddressLine1 ;
      private string[] T000927_A348NetworkIndividualAddressLine2 ;
      private Guid[] T000928_A62ResidentId ;
      private Guid[] T000928_A29LocationId ;
      private Guid[] T000928_A11OrganisationId ;
      private Guid[] T000928_A74NetworkIndividualId ;
      private Guid[] T00096_A62ResidentId ;
      private Guid[] T00096_A29LocationId ;
      private Guid[] T00096_A11OrganisationId ;
      private Guid[] T00096_A74NetworkIndividualId ;
      private Guid[] T00095_A62ResidentId ;
      private Guid[] T00095_A29LocationId ;
      private Guid[] T00095_A11OrganisationId ;
      private Guid[] T00095_A74NetworkIndividualId ;
      private string[] T000931_A75NetworkIndividualBsnNumber ;
      private string[] T000931_A76NetworkIndividualGivenName ;
      private string[] T000931_A77NetworkIndividualLastName ;
      private string[] T000931_A78NetworkIndividualEmail ;
      private string[] T000931_A79NetworkIndividualPhone ;
      private string[] T000931_A388NetworkIndividualPhoneNumber ;
      private string[] T000931_A387NetworkIndividualPhoneCode ;
      private string[] T000931_A81NetworkIndividualGender ;
      private string[] T000931_A344NetworkIndividualCountry ;
      private string[] T000931_A345NetworkIndividualCity ;
      private string[] T000931_A346NetworkIndividualZipCode ;
      private string[] T000931_A347NetworkIndividualAddressLine1 ;
      private string[] T000931_A348NetworkIndividualAddressLine2 ;
      private Guid[] T000932_A62ResidentId ;
      private Guid[] T000932_A29LocationId ;
      private Guid[] T000932_A11OrganisationId ;
      private Guid[] T000932_A74NetworkIndividualId ;
      private Guid[] T000933_A62ResidentId ;
      private Guid[] T000933_A29LocationId ;
      private Guid[] T000933_A11OrganisationId ;
      private string[] T000933_A83NetworkCompanyKvkNumber ;
      private string[] T000933_A84NetworkCompanyName ;
      private string[] T000933_A85NetworkCompanyEmail ;
      private string[] T000933_A86NetworkCompanyPhone ;
      private string[] T000933_A392NetworkCompanyPhoneNumber ;
      private string[] T000933_A391NetworkCompanyPhoneCode ;
      private string[] T000933_A349NetworkCompanyCountry ;
      private string[] T000933_A350NetworkCompanyCity ;
      private string[] T000933_A351NetworkCompanyZipCode ;
      private string[] T000933_A352NetworkCompanyAddressLine1 ;
      private string[] T000933_A353NetworkCompanyAddressLine2 ;
      private Guid[] T000933_A82NetworkCompanyId ;
      private string[] T00094_A83NetworkCompanyKvkNumber ;
      private string[] T00094_A84NetworkCompanyName ;
      private string[] T00094_A85NetworkCompanyEmail ;
      private string[] T00094_A86NetworkCompanyPhone ;
      private string[] T00094_A392NetworkCompanyPhoneNumber ;
      private string[] T00094_A391NetworkCompanyPhoneCode ;
      private string[] T00094_A349NetworkCompanyCountry ;
      private string[] T00094_A350NetworkCompanyCity ;
      private string[] T00094_A351NetworkCompanyZipCode ;
      private string[] T00094_A352NetworkCompanyAddressLine1 ;
      private string[] T00094_A353NetworkCompanyAddressLine2 ;
      private string[] T000934_A83NetworkCompanyKvkNumber ;
      private string[] T000934_A84NetworkCompanyName ;
      private string[] T000934_A85NetworkCompanyEmail ;
      private string[] T000934_A86NetworkCompanyPhone ;
      private string[] T000934_A392NetworkCompanyPhoneNumber ;
      private string[] T000934_A391NetworkCompanyPhoneCode ;
      private string[] T000934_A349NetworkCompanyCountry ;
      private string[] T000934_A350NetworkCompanyCity ;
      private string[] T000934_A351NetworkCompanyZipCode ;
      private string[] T000934_A352NetworkCompanyAddressLine1 ;
      private string[] T000934_A353NetworkCompanyAddressLine2 ;
      private Guid[] T000935_A82NetworkCompanyId ;
      private Guid[] T000935_A62ResidentId ;
      private Guid[] T000935_A29LocationId ;
      private Guid[] T000935_A11OrganisationId ;
      private Guid[] T00093_A62ResidentId ;
      private Guid[] T00093_A29LocationId ;
      private Guid[] T00093_A11OrganisationId ;
      private Guid[] T00093_A82NetworkCompanyId ;
      private Guid[] T00092_A62ResidentId ;
      private Guid[] T00092_A29LocationId ;
      private Guid[] T00092_A11OrganisationId ;
      private Guid[] T00092_A82NetworkCompanyId ;
      private string[] T000938_A83NetworkCompanyKvkNumber ;
      private string[] T000938_A84NetworkCompanyName ;
      private string[] T000938_A85NetworkCompanyEmail ;
      private string[] T000938_A86NetworkCompanyPhone ;
      private string[] T000938_A392NetworkCompanyPhoneNumber ;
      private string[] T000938_A391NetworkCompanyPhoneCode ;
      private string[] T000938_A349NetworkCompanyCountry ;
      private string[] T000938_A350NetworkCompanyCity ;
      private string[] T000938_A351NetworkCompanyZipCode ;
      private string[] T000938_A352NetworkCompanyAddressLine1 ;
      private string[] T000938_A353NetworkCompanyAddressLine2 ;
      private Guid[] T000939_A82NetworkCompanyId ;
      private Guid[] T000939_A62ResidentId ;
      private Guid[] T000939_A29LocationId ;
      private Guid[] T000939_A11OrganisationId ;
      private Guid[] T000940_A29LocationId ;
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
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new UpdateCursor(def[18])
      ,new UpdateCursor(def[19])
      ,new UpdateCursor(def[20])
      ,new ForEachCursor(def[21])
      ,new ForEachCursor(def[22])
      ,new ForEachCursor(def[23])
      ,new ForEachCursor(def[24])
      ,new ForEachCursor(def[25])
      ,new ForEachCursor(def[26])
      ,new UpdateCursor(def[27])
      ,new UpdateCursor(def[28])
      ,new ForEachCursor(def[29])
      ,new ForEachCursor(def[30])
      ,new ForEachCursor(def[31])
      ,new ForEachCursor(def[32])
      ,new ForEachCursor(def[33])
      ,new UpdateCursor(def[34])
      ,new UpdateCursor(def[35])
      ,new ForEachCursor(def[36])
      ,new ForEachCursor(def[37])
      ,new ForEachCursor(def[38])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT00092;
       prmT00092 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00093;
       prmT00093 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00094;
       prmT00094 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00095;
       prmT00095 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00096;
       prmT00096 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00097;
       prmT00097 = new Object[] {
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00098;
       prmT00098 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT00099;
       prmT00099 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000910;
       prmT000910 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000911;
       prmT000911 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000912;
       prmT000912 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000913;
       prmT000913 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000914;
       prmT000914 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000915;
       prmT000915 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000916;
       prmT000916 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000917;
       prmT000917 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000918;
       prmT000918 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000919;
       prmT000919 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000920;
       prmT000920 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentCountry",GXType.VarChar,100,0) ,
       new ParDef("ResidentPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ResidentHomePhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ResidentGUID",GXType.VarChar,100,60) ,
       new ParDef("ResidentInitials",GXType.Char,20,0) ,
       new ParDef("ResidentPhone",GXType.Char,20,0) ,
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
       new ParDef("ResidentHomePhone",GXType.Char,20,0) ,
       new ParDef("ResidentBirthDate",GXType.Date,8,0) ,
       new ParDef("ResidentPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentHomePhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000921;
       prmT000921 = new Object[] {
       new ParDef("ResidentCountry",GXType.VarChar,100,0) ,
       new ParDef("ResidentPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ResidentHomePhoneCode",GXType.VarChar,40,0) ,
       new ParDef("ResidentGUID",GXType.VarChar,100,60) ,
       new ParDef("ResidentInitials",GXType.Char,20,0) ,
       new ParDef("ResidentPhone",GXType.Char,20,0) ,
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
       new ParDef("ResidentHomePhone",GXType.Char,20,0) ,
       new ParDef("ResidentBirthDate",GXType.Date,8,0) ,
       new ParDef("ResidentPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentHomePhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000922;
       prmT000922 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000923;
       prmT000923 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000924;
       prmT000924 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT000925;
       prmT000925 = new Object[] {
       };
       Object[] prmT000926;
       prmT000926 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000927;
       prmT000927 = new Object[] {
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000928;
       prmT000928 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000929;
       prmT000929 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000930;
       prmT000930 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000931;
       prmT000931 = new Object[] {
       new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000932;
       prmT000932 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000933;
       prmT000933 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000934;
       prmT000934 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000935;
       prmT000935 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000936;
       prmT000936 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000937;
       prmT000937 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000938;
       prmT000938 = new Object[] {
       new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000939;
       prmT000939 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT000940;
       prmT000940 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("T00092", "SELECT ResidentId, LocationId, OrganisationId, NetworkCompanyId FROM Trn_ResidentNetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId AND ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_ResidentNetworkCompany NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00093", "SELECT ResidentId, LocationId, OrganisationId, NetworkCompanyId FROM Trn_ResidentNetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId AND ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00094", "SELECT NetworkCompanyKvkNumber, NetworkCompanyName, NetworkCompanyEmail, NetworkCompanyPhone, NetworkCompanyPhoneNumber, NetworkCompanyPhoneCode, NetworkCompanyCountry, NetworkCompanyCity, NetworkCompanyZipCode, NetworkCompanyAddressLine1, NetworkCompanyAddressLine2 FROM Trn_NetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00095", "SELECT ResidentId, LocationId, OrganisationId, NetworkIndividualId FROM Trn_ResidentNetworkIndividual WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId AND NetworkIndividualId = :NetworkIndividualId  FOR UPDATE OF Trn_ResidentNetworkIndividual NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00096", "SELECT ResidentId, LocationId, OrganisationId, NetworkIndividualId FROM Trn_ResidentNetworkIndividual WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId AND NetworkIndividualId = :NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00097", "SELECT NetworkIndividualBsnNumber, NetworkIndividualGivenName, NetworkIndividualLastName, NetworkIndividualEmail, NetworkIndividualPhone, NetworkIndividualPhoneNumber, NetworkIndividualPhoneCode, NetworkIndividualGender, NetworkIndividualCountry, NetworkIndividualCity, NetworkIndividualZipCode, NetworkIndividualAddressLine1, NetworkIndividualAddressLine2 FROM Trn_NetworkIndividual WHERE NetworkIndividualId = :NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00098", "SELECT ResidentId, ResidentCountry, ResidentPhoneCode, ResidentHomePhoneCode, ResidentGUID, ResidentInitials, ResidentPhone, ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentCity, ResidentZipCode, ResidentAddressLine1, ResidentAddressLine2, ResidentHomePhone, ResidentBirthDate, ResidentPhoneNumber, ResidentHomePhoneNumber, LocationId, OrganisationId, ResidentTypeId, MedicalIndicationId FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_Resident NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00098,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00099", "SELECT ResidentId, ResidentCountry, ResidentPhoneCode, ResidentHomePhoneCode, ResidentGUID, ResidentInitials, ResidentPhone, ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentCity, ResidentZipCode, ResidentAddressLine1, ResidentAddressLine2, ResidentHomePhone, ResidentBirthDate, ResidentPhoneNumber, ResidentHomePhoneNumber, LocationId, OrganisationId, ResidentTypeId, MedicalIndicationId FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00099,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000910", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000910,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000911", "SELECT ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000911,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000912", "SELECT MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000912,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000913", "SELECT TM1.ResidentId, TM1.ResidentCountry, TM1.ResidentPhoneCode, TM1.ResidentHomePhoneCode, TM1.ResidentGUID, TM1.ResidentInitials, TM1.ResidentPhone, TM1.ResidentSalutation, TM1.ResidentBsnNumber, TM1.ResidentGivenName, TM1.ResidentLastName, TM1.ResidentEmail, TM1.ResidentGender, TM1.ResidentCity, TM1.ResidentZipCode, TM1.ResidentAddressLine1, TM1.ResidentAddressLine2, TM1.ResidentHomePhone, TM1.ResidentBirthDate, T2.ResidentTypeName, T3.MedicalIndicationName, TM1.ResidentPhoneNumber, TM1.ResidentHomePhoneNumber, TM1.LocationId, TM1.OrganisationId, TM1.ResidentTypeId, TM1.MedicalIndicationId FROM ((Trn_Resident TM1 INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = TM1.ResidentTypeId) LEFT JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = TM1.MedicalIndicationId) WHERE TM1.ResidentId = :ResidentId and TM1.LocationId = :LocationId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.ResidentId, TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000913,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000914", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000914,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000915", "SELECT ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000915,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000916", "SELECT MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000916,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000917", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000917,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000918", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ( ResidentId > :ResidentId or ResidentId = :ResidentId and LocationId > :LocationId or LocationId = :LocationId and ResidentId = :ResidentId and OrganisationId > :OrganisationId) ORDER BY ResidentId, LocationId, OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000918,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000919", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ( ResidentId < :ResidentId or ResidentId = :ResidentId and LocationId < :LocationId or LocationId = :LocationId and ResidentId = :ResidentId and OrganisationId < :OrganisationId) ORDER BY ResidentId DESC, LocationId DESC, OrganisationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000919,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000920", "SAVEPOINT gxupdate;INSERT INTO Trn_Resident(ResidentId, ResidentCountry, ResidentPhoneCode, ResidentHomePhoneCode, ResidentGUID, ResidentInitials, ResidentPhone, ResidentSalutation, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentCity, ResidentZipCode, ResidentAddressLine1, ResidentAddressLine2, ResidentHomePhone, ResidentBirthDate, ResidentPhoneNumber, ResidentHomePhoneNumber, LocationId, OrganisationId, ResidentTypeId, MedicalIndicationId) VALUES(:ResidentId, :ResidentCountry, :ResidentPhoneCode, :ResidentHomePhoneCode, :ResidentGUID, :ResidentInitials, :ResidentPhone, :ResidentSalutation, :ResidentBsnNumber, :ResidentGivenName, :ResidentLastName, :ResidentEmail, :ResidentGender, :ResidentCity, :ResidentZipCode, :ResidentAddressLine1, :ResidentAddressLine2, :ResidentHomePhone, :ResidentBirthDate, :ResidentPhoneNumber, :ResidentHomePhoneNumber, :LocationId, :OrganisationId, :ResidentTypeId, :MedicalIndicationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000920)
          ,new CursorDef("T000921", "SAVEPOINT gxupdate;UPDATE Trn_Resident SET ResidentCountry=:ResidentCountry, ResidentPhoneCode=:ResidentPhoneCode, ResidentHomePhoneCode=:ResidentHomePhoneCode, ResidentGUID=:ResidentGUID, ResidentInitials=:ResidentInitials, ResidentPhone=:ResidentPhone, ResidentSalutation=:ResidentSalutation, ResidentBsnNumber=:ResidentBsnNumber, ResidentGivenName=:ResidentGivenName, ResidentLastName=:ResidentLastName, ResidentEmail=:ResidentEmail, ResidentGender=:ResidentGender, ResidentCity=:ResidentCity, ResidentZipCode=:ResidentZipCode, ResidentAddressLine1=:ResidentAddressLine1, ResidentAddressLine2=:ResidentAddressLine2, ResidentHomePhone=:ResidentHomePhone, ResidentBirthDate=:ResidentBirthDate, ResidentPhoneNumber=:ResidentPhoneNumber, ResidentHomePhoneNumber=:ResidentHomePhoneNumber, ResidentTypeId=:ResidentTypeId, MedicalIndicationId=:MedicalIndicationId  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000921)
          ,new CursorDef("T000922", "SAVEPOINT gxupdate;DELETE FROM Trn_Resident  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000922)
          ,new CursorDef("T000923", "SELECT ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000923,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000924", "SELECT MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000924,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000925", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident ORDER BY ResidentId, LocationId, OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000925,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000926", "SELECT T1.ResidentId, T1.LocationId, T1.OrganisationId, T2.NetworkIndividualBsnNumber, T2.NetworkIndividualGivenName, T2.NetworkIndividualLastName, T2.NetworkIndividualEmail, T2.NetworkIndividualPhone, T2.NetworkIndividualPhoneNumber, T2.NetworkIndividualPhoneCode, T2.NetworkIndividualGender, T2.NetworkIndividualCountry, T2.NetworkIndividualCity, T2.NetworkIndividualZipCode, T2.NetworkIndividualAddressLine1, T2.NetworkIndividualAddressLine2, T1.NetworkIndividualId FROM (Trn_ResidentNetworkIndividual T1 INNER JOIN Trn_NetworkIndividual T2 ON T2.NetworkIndividualId = T1.NetworkIndividualId) WHERE T1.ResidentId = :ResidentId and T1.LocationId = :LocationId and T1.OrganisationId = :OrganisationId and T1.NetworkIndividualId = :NetworkIndividualId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId, T1.NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000926,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000927", "SELECT NetworkIndividualBsnNumber, NetworkIndividualGivenName, NetworkIndividualLastName, NetworkIndividualEmail, NetworkIndividualPhone, NetworkIndividualPhoneNumber, NetworkIndividualPhoneCode, NetworkIndividualGender, NetworkIndividualCountry, NetworkIndividualCity, NetworkIndividualZipCode, NetworkIndividualAddressLine1, NetworkIndividualAddressLine2 FROM Trn_NetworkIndividual WHERE NetworkIndividualId = :NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000927,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000928", "SELECT ResidentId, LocationId, OrganisationId, NetworkIndividualId FROM Trn_ResidentNetworkIndividual WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId AND NetworkIndividualId = :NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000928,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000929", "SAVEPOINT gxupdate;INSERT INTO Trn_ResidentNetworkIndividual(ResidentId, LocationId, OrganisationId, NetworkIndividualId) VALUES(:ResidentId, :LocationId, :OrganisationId, :NetworkIndividualId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000929)
          ,new CursorDef("T000930", "SAVEPOINT gxupdate;DELETE FROM Trn_ResidentNetworkIndividual  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId AND NetworkIndividualId = :NetworkIndividualId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000930)
          ,new CursorDef("T000931", "SELECT NetworkIndividualBsnNumber, NetworkIndividualGivenName, NetworkIndividualLastName, NetworkIndividualEmail, NetworkIndividualPhone, NetworkIndividualPhoneNumber, NetworkIndividualPhoneCode, NetworkIndividualGender, NetworkIndividualCountry, NetworkIndividualCity, NetworkIndividualZipCode, NetworkIndividualAddressLine1, NetworkIndividualAddressLine2 FROM Trn_NetworkIndividual WHERE NetworkIndividualId = :NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000931,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000932", "SELECT ResidentId, LocationId, OrganisationId, NetworkIndividualId FROM Trn_ResidentNetworkIndividual WHERE ResidentId = :ResidentId and LocationId = :LocationId and OrganisationId = :OrganisationId ORDER BY ResidentId, LocationId, OrganisationId, NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000932,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000933", "SELECT T1.ResidentId, T1.LocationId, T1.OrganisationId, T2.NetworkCompanyKvkNumber, T2.NetworkCompanyName, T2.NetworkCompanyEmail, T2.NetworkCompanyPhone, T2.NetworkCompanyPhoneNumber, T2.NetworkCompanyPhoneCode, T2.NetworkCompanyCountry, T2.NetworkCompanyCity, T2.NetworkCompanyZipCode, T2.NetworkCompanyAddressLine1, T2.NetworkCompanyAddressLine2, T1.NetworkCompanyId FROM (Trn_ResidentNetworkCompany T1 INNER JOIN Trn_NetworkCompany T2 ON T2.NetworkCompanyId = T1.NetworkCompanyId) WHERE T1.NetworkCompanyId = :NetworkCompanyId and T1.ResidentId = :ResidentId and T1.LocationId = :LocationId and T1.OrganisationId = :OrganisationId ORDER BY T1.NetworkCompanyId, T1.ResidentId, T1.LocationId, T1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000933,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000934", "SELECT NetworkCompanyKvkNumber, NetworkCompanyName, NetworkCompanyEmail, NetworkCompanyPhone, NetworkCompanyPhoneNumber, NetworkCompanyPhoneCode, NetworkCompanyCountry, NetworkCompanyCity, NetworkCompanyZipCode, NetworkCompanyAddressLine1, NetworkCompanyAddressLine2 FROM Trn_NetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000934,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000935", "SELECT NetworkCompanyId, ResidentId, LocationId, OrganisationId FROM Trn_ResidentNetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId AND ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000935,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000936", "SAVEPOINT gxupdate;INSERT INTO Trn_ResidentNetworkCompany(ResidentId, LocationId, OrganisationId, NetworkCompanyId) VALUES(:ResidentId, :LocationId, :OrganisationId, :NetworkCompanyId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000936)
          ,new CursorDef("T000937", "SAVEPOINT gxupdate;DELETE FROM Trn_ResidentNetworkCompany  WHERE NetworkCompanyId = :NetworkCompanyId AND ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000937)
          ,new CursorDef("T000938", "SELECT NetworkCompanyKvkNumber, NetworkCompanyName, NetworkCompanyEmail, NetworkCompanyPhone, NetworkCompanyPhoneNumber, NetworkCompanyPhoneCode, NetworkCompanyCountry, NetworkCompanyCity, NetworkCompanyZipCode, NetworkCompanyAddressLine1, NetworkCompanyAddressLine2 FROM Trn_NetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000938,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000939", "SELECT NetworkCompanyId, ResidentId, LocationId, OrganisationId FROM Trn_ResidentNetworkCompany WHERE ResidentId = :ResidentId and LocationId = :LocationId and OrganisationId = :OrganisationId ORDER BY NetworkCompanyId, ResidentId, LocationId, OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000939,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000940", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000940,1, GxCacheFrequency.OFF ,true,false )
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
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 5 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
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
             ((string[]) buf[17])[0] = rslt.getString(18, 20);
             ((DateTime[]) buf[18])[0] = rslt.getGXDate(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((string[]) buf[20])[0] = rslt.getVarchar(21);
             ((Guid[]) buf[21])[0] = rslt.getGuid(22);
             ((Guid[]) buf[22])[0] = rslt.getGuid(23);
             ((Guid[]) buf[23])[0] = rslt.getGuid(24);
             ((Guid[]) buf[24])[0] = rslt.getGuid(25);
             ((bool[]) buf[25])[0] = rslt.wasNull(25);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
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
             ((string[]) buf[17])[0] = rslt.getString(18, 20);
             ((DateTime[]) buf[18])[0] = rslt.getGXDate(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((string[]) buf[20])[0] = rslt.getVarchar(21);
             ((Guid[]) buf[21])[0] = rslt.getGuid(22);
             ((Guid[]) buf[22])[0] = rslt.getGuid(23);
             ((Guid[]) buf[23])[0] = rslt.getGuid(24);
             ((Guid[]) buf[24])[0] = rslt.getGuid(25);
             ((bool[]) buf[25])[0] = rslt.wasNull(25);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 10 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
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
             ((string[]) buf[17])[0] = rslt.getString(18, 20);
             ((DateTime[]) buf[18])[0] = rslt.getGXDate(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((string[]) buf[20])[0] = rslt.getVarchar(21);
             ((string[]) buf[21])[0] = rslt.getVarchar(22);
             ((string[]) buf[22])[0] = rslt.getVarchar(23);
             ((Guid[]) buf[23])[0] = rslt.getGuid(24);
             ((Guid[]) buf[24])[0] = rslt.getGuid(25);
             ((Guid[]) buf[25])[0] = rslt.getGuid(26);
             ((Guid[]) buf[26])[0] = rslt.getGuid(27);
             ((bool[]) buf[27])[0] = rslt.wasNull(27);
             return;
          case 12 :
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
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 16 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 17 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 21 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 22 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 23 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 24 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getString(8, 20);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((string[]) buf[14])[0] = rslt.getVarchar(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((Guid[]) buf[16])[0] = rslt.getGuid(17);
             return;
          case 25 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             return;
          case 26 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 29 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             return;
    }
    getresults30( cursor, rslt, buf) ;
 }

 public void getresults30( int cursor ,
                           IFieldGetter rslt ,
                           Object[] buf )
 {
    switch ( cursor )
    {
          case 30 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 31 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getString(7, 20);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((Guid[]) buf[14])[0] = rslt.getGuid(15);
             return;
          case 32 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             return;
          case 33 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 36 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             return;
          case 37 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 38 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
