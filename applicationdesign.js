gx.evt.autoSkip=!1;gx.define("applicationdesign",!1,function(){var t,n;this.ServerClass="applicationdesign";this.PackageName="GeneXus.Programs";this.ServerFullClass="applicationdesign.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV16Trn_PageId=gx.fn.getControlValue("vTRN_PAGEID")};this.e13472_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14472_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14];this.GXLastCtrlId=14;this.APPTOOLBOX1Container=gx.uc.getNew(this,15,0,"UC_AppToolBox","APPTOOLBOX1Container","Apptoolbox1","APPTOOLBOX1");n=this.APPTOOLBOX1Container;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setDynProp("Current_Language","Current_language","english","str");n.setProp("SDT_Page","Sdt_page","","str");n.addV2CFunction("AV31SDT_Pages","vSDT_PAGES","setSDT_Pages");n.addC2VFunction(function(n){n.ParentObject.AV31SDT_Pages=n.getSDT_Pages();gx.fn.setControlValue("vSDT_PAGES",n.ParentObject.AV31SDT_Pages)});n.setDynProp("LocationId","Locationid","","str");n.setDynProp("OrganisationId","Organisationid","","str");n.addV2CFunction("AV37SDT_ProductServiceCollection","vSDT_PRODUCTSERVICECOLLECTION","setSDT_ProductServiceCollection");n.addC2VFunction(function(n){n.ParentObject.AV37SDT_ProductServiceCollection=n.getSDT_ProductServiceCollection();gx.fn.setControlValue("vSDT_PRODUCTSERVICECOLLECTION",n.ParentObject.AV37SDT_ProductServiceCollection)});n.addV2CFunction("AV10BC_Trn_TemplateCollection","vBC_TRN_TEMPLATECOLLECTION","setBC_Trn_TemplateCollection");n.addC2VFunction(function(n){n.ParentObject.AV10BC_Trn_TemplateCollection=n.getBC_Trn_TemplateCollection();gx.fn.setControlValue("vBC_TRN_TEMPLATECOLLECTION",n.ParentObject.AV10BC_Trn_TemplateCollection)});n.addV2CFunction("AV13BC_Trn_ThemeCollection","vBC_TRN_THEMECOLLECTION","setBC_Trn_ThemeCollection");n.addC2VFunction(function(n){n.ParentObject.AV13BC_Trn_ThemeCollection=n.getBC_Trn_ThemeCollection();gx.fn.setControlValue("vBC_TRN_THEMECOLLECTION",n.ParentObject.AV13BC_Trn_ThemeCollection)});n.addV2CFunction("AV21BC_Trn_MediaCollection","vBC_TRN_MEDIACOLLECTION","setBC_Trn_MediaCollection");n.addC2VFunction(function(n){n.ParentObject.AV21BC_Trn_MediaCollection=n.getBC_Trn_MediaCollection();gx.fn.setControlValue("vBC_TRN_MEDIACOLLECTION",n.ParentObject.AV21BC_Trn_MediaCollection)});n.addV2CFunction("AV44BC_Trn_Location","vBC_TRN_LOCATION","setBC_Trn_Location");n.addC2VFunction(function(n){n.ParentObject.AV44BC_Trn_Location=n.getBC_Trn_Location();gx.fn.setControlValue("vBC_TRN_LOCATION",n.ParentObject.AV44BC_Trn_Location)});n.setProp("Current_Theme","Current_theme","","str");n.setProp("Layout","Layout","","str");n.setProp("Visible","Visible",!0,"bool");n.setProp("Gx Control Type","Gxcontroltype","","int");n.setC2ShowFunction(function(n){n.show()});this.setUserControl(n);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"TABLECONTENT",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};this.AV31SDT_Pages=[];this.AV16Trn_PageId="00000000-0000-0000-0000-000000000000";this.A310Trn_PageId="00000000-0000-0000-0000-000000000000";this.A318Trn_PageName="";this.A437PageChildren="";this.A248Trn_ThemeName="";this.A247Trn_ThemeId="00000000-0000-0000-0000-000000000000";this.A29LocationId="00000000-0000-0000-0000-000000000000";this.A409MediaId="00000000-0000-0000-0000-000000000000";this.A40000ProductServiceImage_GXI="";this.A11OrganisationId="00000000-0000-0000-0000-000000000000";this.A58ProductServiceId="00000000-0000-0000-0000-000000000000";this.A59ProductServiceName="";this.A61ProductServiceImage="";this.A278Trn_TemplateId="00000000-0000-0000-0000-000000000000";this.Events={e13472_client:["ENTER",!0],e14472_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV16Trn_PageId","vTRN_PAGEID",0,"guid",4,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.applicationdesign)})