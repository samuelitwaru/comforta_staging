gx.evt.autoSkip=!1;gx.define("wc_notificationgrouping",!0,function(n){var i,r,t,u;this.ServerClass="wc_notificationgrouping";this.PackageName="GeneXus.Programs";this.ServerFullClass="wc_notificationgrouping.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV60Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV36SDT_NotificationGroup=gx.fn.getControlValue("vSDT_NOTIFICATIONGROUP");this.AV38SDT_NotificationGroupCollection=gx.fn.getControlValue("vSDT_NOTIFICATIONGROUPCOLLECTION");this.AV5NotificationInfo=gx.fn.getControlValue("vNOTIFICATIONINFO")};this.Validv_Gxv7=function(){var n=gx.fn.currentGridRowImpl(12);return this.validCliEvt("Validv_Gxv7",12,function(){try{var n=gx.util.balloon.getNew("SDT_NOTIFICATIONGROUP__NOTIFICATIONLINK");if(this.AnyError=0,!gx.util.regExp.isMatch(this.GXV7,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$"))try{n.setError("Field Notification Link does not match the specified pattern");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.s122_client=function(){return this.executeClientEvent(function(){},arguments)};this.s142_client=function(){return this.executeClientEvent(function(){},arguments)};this.e179y2_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.AV6ActionGroup==1?this.s152_client():this.AV6ActionGroup==2&&this.s162_client();this.AV6ActionGroup=gx.num.trunc(0,0);this.refreshOutputs([{ctrl:"vACTIONGROUP"},{av:"AV6ActionGroup",fld:"vACTIONGROUP",pic:"ZZZ9"}]);this.OnClientEventEnd()},arguments)};this.s152_client=function(){return this.executeClientEvent(function(){},arguments)};this.s162_client=function(){return this.executeClientEvent(function(){},arguments)};this.e189y2_client=function(){this.clearMessages();this.refreshOutputs([]);this.refreshGrid("Grid");this.refreshOutputs([]);this.OnClientEventEnd()};this.e119y2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e129y2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e169y2_client=function(){return this.executeServerEvent("VDETAILWEBCOMPONENT.CLICK",!0,arguments[0],!1,!1)};this.e199y2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e209y2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];i=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,28,29,31,32,33];this.GXLastCtrlId=33;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",12,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wc_notificationgrouping",[],!1,1,!0,!0,0,!1,!1,!1,"CollSDT_NotificationGroup.SDT_NotificationGroupItem",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"AV36SDT_NotificationGroup",!1,[1,1,1,1],!1,0,!0,!1);r=this.GridContainer;r.addSingleLineEdit("GXV2",13,"SDT_NOTIFICATIONGROUP__NOTIFICATIONID","Notification Id","","NotificationId","int",0,"px",5,5,"end",null,[],"GXV2","GXV2",!1,0,!1,!1,"Attribute",0,"WWColumn");r.addSingleLineEdit("Notificationicon",14,"vNOTIFICATIONICON","","","NotificationIcon","svchar",40,"px",200,80,"start",null,[],"Notificationicon","NotificationIcon",!0,0,!1,!1,"Attribute",0,"WWColumn");r.addSingleLineEdit("GXV3",15,"SDT_NOTIFICATIONGROUP__NOTIFICATIONICONCLASS","Notification Icon Class","","NotificationIconClass","svchar",0,"px",40,40,"start",null,[],"GXV3","GXV3",!1,0,!1,!1,"Attribute",0,"WWColumn");r.addSingleLineEdit("GXV4",16,"SDT_NOTIFICATIONGROUP__NOTIFICATIONTITLE","Notification","","NotificationTitle","svchar",0,"px",200,80,"start",null,[],"GXV4","GXV4",!0,0,!1,!1,"Attribute",0,"WWColumn");r.addSingleLineEdit("GXV5",17,"SDT_NOTIFICATIONGROUP__NOTIFICATIONDESCRIPTION","Description","","NotificationDescription","svchar",0,"px",200,80,"start",null,[],"GXV5","GXV5",!0,0,!1,!1,"Attribute",0,"WWColumn");r.addSingleLineEdit("GXV6",18,"SDT_NOTIFICATIONGROUP__NOTIFICATIONDATETIME","Datetime","","NotificationDatetime","dtime",0,"px",17,14,"end",null,[],"GXV6","GXV6",!0,5,!1,!1,"Attribute",0,"WWColumn");r.addSingleLineEdit("GXV7",19,"SDT_NOTIFICATIONGROUP__NOTIFICATIONLINK","Notification Link","","NotificationLink","svchar",570,"px",1e3,80,"start",null,[],"GXV7","GXV7",!1,0,!1,!1,"Attribute",0,"WWColumn");r.addCheckBox("GXV8",20,"SDT_NOTIFICATIONGROUP__ISPARENT","is Parent","","isParent","boolean","true","false",null,!1,!1,0,"px","WWColumn");r.addSingleLineEdit("GXV9",21,"SDT_NOTIFICATIONGROUP__PARENTLINKID","Parent Link Id","","ParentLinkId","svchar",0,"px",40,40,"start",null,[],"GXV9","GXV9",!1,0,!1,!1,"Attribute",0,"WWColumn");r.addSingleLineEdit("GXV10",22,"SDT_NOTIFICATIONGROUP__NUMBEROFCHILDNOTIFICATIONS","Number Of Child Notifications","","NumberOfChildNotifications","int",0,"px",4,4,"end",null,[],"GXV10","GXV10",!1,0,!1,!1,"Attribute",0,"WWColumn");r.addComboBox("Actiongroup",23,"vACTIONGROUP","","ActionGroup","int","e179y2_client",0,!0,!1,0,"px","WWActionGroupColumn hidden-xs hidden-sm hidden-md hidden-lg");r.addSingleLineEdit("Detailwebcomponent",24,"vDETAILWEBCOMPONENT","","","DetailWebComponent","char",0,"px",20,20,"start","e169y2_client",[],"Detailwebcomponent","DetailWebComponent",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn WCD_ActionColumn");this.GridContainer.emptyText="";this.setGrid(r);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,27,13,"DVelop_DVPaginationBar",this.CmpContext+"GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");t=this.GRIDPAGINATIONBARContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Class","Class","PaginationBar","str");t.setProp("ShowFirst","Showfirst",!1,"bool");t.setProp("ShowPrevious","Showprevious",!0,"bool");t.setProp("ShowNext","Shownext",!0,"bool");t.setProp("ShowLast","Showlast",!1,"bool");t.setProp("PagesToShow","Pagestoshow",5,"num");t.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");t.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");t.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");t.setProp("SelectedPage","Selectedpage","","char");t.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");t.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");t.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");t.setProp("First","First","First","str");t.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");t.setProp("Next","Next","WWP_PagingNextCaption","str");t.setProp("Last","Last","Last","str");t.setProp("Caption","Caption","Page <CURRENT_PAGE> of <TOTAL_PAGES>","str");t.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");t.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");t.addV2CFunction("AV16GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");t.addC2VFunction(function(n){n.ParentObject.AV16GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV16GridCurrentPage)});t.addV2CFunction("AV17GridPageCount","vGRIDPAGECOUNT","SetPageCount");t.addC2VFunction(function(n){n.ParentObject.AV17GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV17GridPageCount)});t.setProp("RecordCount","Recordcount","","str");t.setProp("Page","Page","","str");t.addV2CFunction("AV15GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");t.addC2VFunction(function(n){n.ParentObject.AV15GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV15GridAppliedFilters)});t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("ChangePage",this.e119y2_client);t.addEventHandler("ChangeRowsPerPage",this.e129y2_client);this.setUserControl(t);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,34,13,"WWP_GridEmpowerer",this.CmpContext+"GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");u=this.GRID_EMPOWERERContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setDynProp("GridInternalName","Gridinternalname","","char");u.setProp("HasCategories","Hascategories",!1,"bool");u.setProp("InfiniteScrolling","Infinitescrolling","False","str");u.setProp("HasTitleSettings","Hastitlesettings",!1,"bool");u.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");u.setProp("HasRowGroups","Hasrowgroups",!1,"bool");u.setProp("FixedColumns","Fixedcolumns","","str");u.setProp("PopoversInGrid","Popoversingrid","","str");u.setProp("Visible","Visible",!0,"bool");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);i[2]={id:2,fld:"",grid:0};i[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};i[4]={id:4,fld:"",grid:0};i[5]={id:5,fld:"",grid:0};i[6]={id:6,fld:"TABLEMAIN",grid:0};i[7]={id:7,fld:"",grid:0};i[8]={id:8,fld:"",grid:0};i[9]={id:9,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};i[10]={id:10,fld:"",grid:0};i[11]={id:11,fld:"",grid:0};i[13]={id:13,lvl:2,type:"int",len:5,dec:0,sign:!1,pic:"ZZZZ9",ro:0,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SDT_NOTIFICATIONGROUP__NOTIFICATIONID",fmt:0,gxz:"ZV51GXV2",gxold:"OV51GXV2",gxvar:"GXV2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV2=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV51GXV2=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("SDT_NOTIFICATIONGROUP__NOTIFICATIONID",n||gx.fn.currentGridRowImpl(12),gx.O.GXV2,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV2=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("SDT_NOTIFICATIONGROUP__NOTIFICATIONID",n||gx.fn.currentGridRowImpl(12),",")},nac:gx.falseFn};i[14]={id:14,lvl:2,type:"svchar",len:200,dec:0,sign:!1,ro:0,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNOTIFICATIONICON",fmt:0,gxz:"ZV29NotificationIcon",gxold:"OV29NotificationIcon",gxvar:"AV29NotificationIcon",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV29NotificationIcon=n)},v2z:function(n){n!==undefined&&(gx.O.ZV29NotificationIcon=n)},v2c:function(n){gx.fn.setGridControlValue("vNOTIFICATIONICON",n||gx.fn.currentGridRowImpl(12),gx.O.AV29NotificationIcon,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV29NotificationIcon=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNOTIFICATIONICON",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};i[15]={id:15,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SDT_NOTIFICATIONGROUP__NOTIFICATIONICONCLASS",fmt:0,gxz:"ZV52GXV3",gxold:"OV52GXV3",gxvar:"GXV3",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV3=n)},v2z:function(n){n!==undefined&&(gx.O.ZV52GXV3=n)},v2c:function(n){gx.fn.setGridControlValue("SDT_NOTIFICATIONGROUP__NOTIFICATIONICONCLASS",n||gx.fn.currentGridRowImpl(12),gx.O.GXV3,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV3=this.val(n))},val:function(n){return gx.fn.getGridControlValue("SDT_NOTIFICATIONGROUP__NOTIFICATIONICONCLASS",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};i[16]={id:16,lvl:2,type:"svchar",len:200,dec:0,sign:!1,ro:0,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SDT_NOTIFICATIONGROUP__NOTIFICATIONTITLE",fmt:0,gxz:"ZV53GXV4",gxold:"OV53GXV4",gxvar:"GXV4",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV4=n)},v2z:function(n){n!==undefined&&(gx.O.ZV53GXV4=n)},v2c:function(n){gx.fn.setGridControlValue("SDT_NOTIFICATIONGROUP__NOTIFICATIONTITLE",n||gx.fn.currentGridRowImpl(12),gx.O.GXV4,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV4=this.val(n))},val:function(n){return gx.fn.getGridControlValue("SDT_NOTIFICATIONGROUP__NOTIFICATIONTITLE",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};i[17]={id:17,lvl:2,type:"svchar",len:200,dec:0,sign:!1,ro:0,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SDT_NOTIFICATIONGROUP__NOTIFICATIONDESCRIPTION",fmt:0,gxz:"ZV54GXV5",gxold:"OV54GXV5",gxvar:"GXV5",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV5=n)},v2z:function(n){n!==undefined&&(gx.O.ZV54GXV5=n)},v2c:function(n){gx.fn.setGridControlValue("SDT_NOTIFICATIONGROUP__NOTIFICATIONDESCRIPTION",n||gx.fn.currentGridRowImpl(12),gx.O.GXV5,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV5=this.val(n))},val:function(n){return gx.fn.getGridControlValue("SDT_NOTIFICATIONGROUP__NOTIFICATIONDESCRIPTION",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};i[18]={id:18,lvl:2,type:"dtime",len:8,dec:5,sign:!1,ro:0,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SDT_NOTIFICATIONGROUP__NOTIFICATIONDATETIME",fmt:0,gxz:"ZV55GXV6",gxold:"OV55GXV6",gxvar:"GXV6",dp:{f:0,st:!0,wn:!1,mf:!0,pic:"99/99/99 99:99",dec:5},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV6=gx.fn.toDatetimeValue(n,"Y4MD"))},v2z:function(n){n!==undefined&&(gx.O.ZV55GXV6=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("SDT_NOTIFICATIONGROUP__NOTIFICATIONDATETIME",n||gx.fn.currentGridRowImpl(12),gx.O.GXV6,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV6=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("SDT_NOTIFICATIONGROUP__NOTIFICATIONDATETIME",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};i[19]={id:19,lvl:2,type:"svchar",len:1e3,dec:0,sign:!1,ro:0,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:this.Validv_Gxv7,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SDT_NOTIFICATIONGROUP__NOTIFICATIONLINK",fmt:0,gxz:"ZV56GXV7",gxold:"OV56GXV7",gxvar:"GXV7",ucs:[],op:[],ip:[19],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV7=n)},v2z:function(n){n!==undefined&&(gx.O.ZV56GXV7=n)},v2c:function(n){gx.fn.setGridControlValue("SDT_NOTIFICATIONGROUP__NOTIFICATIONLINK",n||gx.fn.currentGridRowImpl(12),gx.O.GXV7,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV7=this.val(n))},val:function(n){return gx.fn.getGridControlValue("SDT_NOTIFICATIONGROUP__NOTIFICATIONLINK",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};i[20]={id:20,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:0,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SDT_NOTIFICATIONGROUP__ISPARENT",fmt:0,gxz:"ZV57GXV8",gxold:"OV57GXV8",gxvar:"GXV8",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV8=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV57GXV8=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("SDT_NOTIFICATIONGROUP__ISPARENT",n||gx.fn.currentGridRowImpl(12),gx.O.GXV8,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV8=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("SDT_NOTIFICATIONGROUP__ISPARENT",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn,values:["true","false"]};i[21]={id:21,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SDT_NOTIFICATIONGROUP__PARENTLINKID",fmt:0,gxz:"ZV58GXV9",gxold:"OV58GXV9",gxvar:"GXV9",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV9=n)},v2z:function(n){n!==undefined&&(gx.O.ZV58GXV9=n)},v2c:function(n){gx.fn.setGridControlValue("SDT_NOTIFICATIONGROUP__PARENTLINKID",n||gx.fn.currentGridRowImpl(12),gx.O.GXV9,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV9=this.val(n))},val:function(n){return gx.fn.getGridControlValue("SDT_NOTIFICATIONGROUP__PARENTLINKID",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};i[22]={id:22,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SDT_NOTIFICATIONGROUP__NUMBEROFCHILDNOTIFICATIONS",fmt:0,gxz:"ZV59GXV10",gxold:"OV59GXV10",gxvar:"GXV10",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV10=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV59GXV10=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("SDT_NOTIFICATIONGROUP__NUMBEROFCHILDNOTIFICATIONS",n||gx.fn.currentGridRowImpl(12),gx.O.GXV10,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV10=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("SDT_NOTIFICATIONGROUP__NUMBEROFCHILDNOTIFICATIONS",n||gx.fn.currentGridRowImpl(12),",")},nac:gx.falseFn};i[23]={id:23,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vACTIONGROUP",fmt:0,gxz:"ZV6ActionGroup",gxold:"OV6ActionGroup",gxvar:"AV6ActionGroup",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV6ActionGroup=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6ActionGroup=gx.num.intval(n))},v2c:function(n){gx.fn.setGridComboBoxValue("vACTIONGROUP",n||gx.fn.currentGridRowImpl(12),gx.O.AV6ActionGroup)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV6ActionGroup=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vACTIONGROUP",n||gx.fn.currentGridRowImpl(12),",")},nac:gx.falseFn,evt:"e179y2_client"};i[24]={id:24,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDETAILWEBCOMPONENT",fmt:1,gxz:"ZV13DetailWebComponent",gxold:"OV13DetailWebComponent",gxvar:"AV13DetailWebComponent",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13DetailWebComponent=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13DetailWebComponent=n)},v2c:function(n){gx.fn.setGridControlValue("vDETAILWEBCOMPONENT",n||gx.fn.currentGridRowImpl(12),gx.O.AV13DetailWebComponent,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13DetailWebComponent=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDETAILWEBCOMPONENT",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn,evt:"e169y2_client"};i[25]={id:25,fld:"",grid:0};i[26]={id:26,fld:"",grid:0};i[28]={id:28,fld:"",grid:0};i[29]={id:29,fld:"CELL_GRID_DWC",grid:0};i[31]={id:31,fld:"",grid:0};i[32]={id:32,fld:"",grid:0};i[33]={id:33,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};this.ZV51GXV2=0;this.OV51GXV2=0;this.ZV29NotificationIcon="";this.OV29NotificationIcon="";this.ZV52GXV3="";this.OV52GXV3="";this.ZV53GXV4="";this.OV53GXV4="";this.ZV54GXV5="";this.OV54GXV5="";this.ZV55GXV6=gx.date.nullDate();this.OV55GXV6=gx.date.nullDate();this.ZV56GXV7="";this.OV56GXV7="";this.ZV57GXV8=!1;this.OV57GXV8=!1;this.ZV58GXV9="";this.OV58GXV9="";this.ZV59GXV10=0;this.OV59GXV10=0;this.ZV6ActionGroup=0;this.OV6ActionGroup=0;this.ZV13DetailWebComponent="";this.OV13DetailWebComponent="";this.AV16GridCurrentPage=0;this.GXV2=0;this.AV29NotificationIcon="";this.GXV3="";this.GXV4="";this.GXV5="";this.GXV6=gx.date.nullDate();this.GXV7="";this.GXV8=!1;this.GXV9="";this.GXV10=0;this.AV6ActionGroup=0;this.AV13DetailWebComponent="";this.AV36SDT_NotificationGroup=[];this.AV60Pgmname="";this.AV38SDT_NotificationGroupCollection=[];this.AV5NotificationInfo={Id:"",Object:"",Message:""};this.addOnMessage("","e189y2_client",[["GeneXusServerNotificationInfo","vNOTIFICATIONINFO","AV5NotificationInfo"]],this.e189y2_client);this.Events={e119y2_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e129y2_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e169y2_client:["VDETAILWEBCOMPONENT.CLICK",!0],e199y2_client:["ENTER",!0],e209y2_client:["CANCEL",!0],e179y2_client:["VACTIONGROUP.CLICK",!1],e189y2_client:["ONMESSAGE_GX1",!1]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"sPrefix"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV60Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV36SDT_NotificationGroup",fld:"vSDT_NOTIFICATIONGROUP",grid:12,hsh:!0},{av:"nGXsfl_12_idx",ctrl:"GRID",prop:"GridCurrRow",grid:12},{av:"nRC_GXsfl_12",ctrl:"GRID",prop:"GridRC",grid:12},{av:"AV38SDT_NotificationGroupCollection",fld:"vSDT_NOTIFICATIONGROUPCOLLECTION",hsh:!0}],[{av:"AV16GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV17GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV15GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS"}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV60Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV36SDT_NotificationGroup",fld:"vSDT_NOTIFICATIONGROUP",grid:12,hsh:!0},{av:"nGXsfl_12_idx",ctrl:"GRID",prop:"GridCurrRow",grid:12},{av:"nRC_GXsfl_12",ctrl:"GRID",prop:"GridRC",grid:12},{av:"AV38SDT_NotificationGroupCollection",fld:"vSDT_NOTIFICATIONGROUPCOLLECTION",hsh:!0},{av:"sPrefix"},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV60Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV36SDT_NotificationGroup",fld:"vSDT_NOTIFICATIONGROUP",grid:12,hsh:!0},{av:"nGXsfl_12_idx",ctrl:"GRID",prop:"GridCurrRow",grid:12},{av:"nRC_GXsfl_12",ctrl:"GRID",prop:"GridRC",grid:12},{av:"AV38SDT_NotificationGroupCollection",fld:"vSDT_NOTIFICATIONGROUPCOLLECTION",hsh:!0},{av:"sPrefix"},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{av:"",ctrl:"GRID",prop:"Rows"}]];this.EvtParms["GRID.LOAD"]=[[{av:"AV36SDT_NotificationGroup",fld:"vSDT_NOTIFICATIONGROUP",grid:12,hsh:!0},{av:"nGXsfl_12_idx",ctrl:"GRID",prop:"GridCurrRow",grid:12},{av:"GRID_nFirstRecordOnPage"},{av:"nRC_GXsfl_12",ctrl:"GRID",prop:"GridRC",grid:12}],[{ctrl:"vACTIONGROUP"},{av:"AV6ActionGroup",fld:"vACTIONGROUP",pic:"ZZZ9"},{av:"AV13DetailWebComponent",fld:"vDETAILWEBCOMPONENT"},{av:"",ctrl:"vNOTIFICATIONICON",prop:"Format"},{av:"AV29NotificationIcon",fld:"vNOTIFICATIONICON"}]];this.EvtParms["VACTIONGROUP.CLICK"]=[[{ctrl:"vACTIONGROUP"},{av:"AV6ActionGroup",fld:"vACTIONGROUP",pic:"ZZZ9"}],[{ctrl:"vACTIONGROUP"},{av:"AV6ActionGroup",fld:"vACTIONGROUP",pic:"ZZZ9"}]];this.EvtParms["VDETAILWEBCOMPONENT.CLICK"]=[[{av:"AV36SDT_NotificationGroup",fld:"vSDT_NOTIFICATIONGROUP",grid:12,hsh:!0},{av:"nGXsfl_12_idx",ctrl:"GRID",prop:"GridCurrRow",grid:12},{av:"GRID_nFirstRecordOnPage"},{av:"nRC_GXsfl_12",ctrl:"GRID",prop:"GridRC",grid:12},{av:"AV38SDT_NotificationGroupCollection",fld:"vSDT_NOTIFICATIONGROUPCOLLECTION",hsh:!0}],[{ctrl:"GRID_DWC"}]];this.EvtParms.ONMESSAGE_GX1=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV60Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV36SDT_NotificationGroup",fld:"vSDT_NOTIFICATIONGROUP",grid:12,hsh:!0},{av:"nGXsfl_12_idx",ctrl:"GRID",prop:"GridCurrRow",grid:12},{av:"nRC_GXsfl_12",ctrl:"GRID",prop:"GridRC",grid:12},{av:"AV38SDT_NotificationGroupCollection",fld:"vSDT_NOTIFICATIONGROUPCOLLECTION",hsh:!0},{av:"sPrefix"},{av:"AV5NotificationInfo",fld:"vNOTIFICATIONINFO"}],[{av:"AV16GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV17GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV15GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALIDV_GXV7=[[{av:"GXV7",fld:"SDT_NOTIFICATIONGROUP__NOTIFICATIONLINK"}],[]];this.setVCMap("AV60Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV36SDT_NotificationGroup","vSDT_NOTIFICATIONGROUP",0,"CollSDT_NotificationGroup.SDT_NotificationGroupItem",0,0);this.setVCMap("AV38SDT_NotificationGroupCollection","vSDT_NOTIFICATIONGROUPCOLLECTION",0,"CollSDT_NotificationGroup.SDT_NotificationGroupItem",0,0);this.setVCMap("AV5NotificationInfo","vNOTIFICATIONINFO",0,"GeneXusServerNotificationInfo",0,0);this.setVCMap("AV60Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV36SDT_NotificationGroup","vSDT_NOTIFICATIONGROUP",0,"CollSDT_NotificationGroup.SDT_NotificationGroupItem",0,0);this.setVCMap("AV5NotificationInfo","vNOTIFICATIONINFO",0,"GeneXusServerNotificationInfo",0,0);this.setVCMap("AV60Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV36SDT_NotificationGroup","vSDT_NOTIFICATIONGROUP",0,"CollSDT_NotificationGroup.SDT_NotificationGroupItem",0,0);r.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});r.addRefreshingVar({rfrVar:"AV60Pgmname"});r.addRefreshingVar({rfrVar:"AV36SDT_NotificationGroup"});r.addRefreshingVar({rfrVar:"AV38SDT_NotificationGroupCollection"});r.addRefreshingParm({rfrVar:"AV60Pgmname"});r.addRefreshingParm({rfrVar:"AV36SDT_NotificationGroup"});r.addRefreshingParm({rfrVar:"AV38SDT_NotificationGroupCollection"});this.addGridBCProperty("Sdt_notificationgroup",["NotificationId"],this.GXValidFnc[13],"AV36SDT_NotificationGroup");this.addGridBCProperty("Sdt_notificationgroup",["NotificationIconClass"],this.GXValidFnc[15],"AV36SDT_NotificationGroup");this.addGridBCProperty("Sdt_notificationgroup",["NotificationTitle"],this.GXValidFnc[16],"AV36SDT_NotificationGroup");this.addGridBCProperty("Sdt_notificationgroup",["NotificationDescription"],this.GXValidFnc[17],"AV36SDT_NotificationGroup");this.addGridBCProperty("Sdt_notificationgroup",["NotificationDatetime"],this.GXValidFnc[18],"AV36SDT_NotificationGroup");this.addGridBCProperty("Sdt_notificationgroup",["NotificationLink"],this.GXValidFnc[19],"AV36SDT_NotificationGroup");this.addGridBCProperty("Sdt_notificationgroup",["isParent"],this.GXValidFnc[20],"AV36SDT_NotificationGroup");this.addGridBCProperty("Sdt_notificationgroup",["ParentLinkId"],this.GXValidFnc[21],"AV36SDT_NotificationGroup");this.addGridBCProperty("Sdt_notificationgroup",["NumberOfChildNotifications"],this.GXValidFnc[22],"AV36SDT_NotificationGroup");this.Initialize();this.setComponent({id:"GRID_DWC",GXClass:null,Prefix:"W0030",lvl:1})})