class Clock{constructor(e){this.pageId=e,this.updateTime()}updateTime(){var e=new Date,t=e.getHours(),a=12<=t?"PM":"AM",t=(t=(t%=12)||12)+`:${e.getMinutes().toString().padStart(2,"0")} `+a;document.getElementById(this.pageId).textContent=t}}class Locale{constructor(e){this.currentLanguage=e,this.defaultLanguage="english",this.translations={}}async init(){return await this.loadTranslations(),this}async loadTranslations(){try{var e;for(e of["english","dutch"]){var t=await fetch(`${window.location.origin}/Resources/UCGrapes1/src/i18n/${e}.json`);if(!t.ok)throw new Error(`Failed to load ${e} translations`);var a=await t.json();this.translations[e]=a}}catch(e){throw console.error("Error loading translations:",e),new Error("Failed to load translations: "+e.message)}}async setLanguage(e){0===Object.keys(this.translations).length&&await this.loadTranslations();["navbar_title","navbar_tree_label","navbar_publish_label","sidebar_tabs_pages_label","sidebar_tabs_templates_label","sidebar_select_action_label","new_page_submit_label","template_added_success_message","theme_applied_success_message","page_loaded_success_message","no_tile_selected_error_message","error_loading_data_message","failed_to_save_current_page_message","tile_has_bg_image_error_message","error_applying_theme_message","no_icon_selected_error_message","error_save_message","accept_popup","close_popup","sidebar_mapping_title","alert_type_success","alert_type_error","cancel_btn","save_btn","publish_confirm_title","publish_confirm_message","nofity_residents_on_publish","publish_confirm_button","publish_cancel_button","enter_title_place_holder"].forEach(e=>{var t=document.getElementById(e);t?t.innerText=this.getTranslation(e):console.warn(`Element with id '${e}' not found`)})}translateTilesTitles(a){["tile-reception","tile-calendar","tile-mailbox","tile-location","tile-my-care","tile-my-living","tile-my-services"].forEach(e=>{var t=a.DomComponents.getWrapper().find("."+e);t.length&&(e=`<span data-gjs-type="text" class="tile-title ${e}">${this.getTranslation(e)}</span>`,t[0].replaceWith(e))})}getTranslation(e){return this.translations&&0!==Object.keys(this.translations).length?this.translations[this.currentLanguage]?.[e]||this.translations[this.defaultLanguage]?.[e]||(console.warn(`Translation missing for key '${e}'`),e):(console.warn("Translations not yet loaded"),e)}translateUCStrings(){document.getElementById("tile-title").placeholder=this.getTranslation("enter_title_place_holder");var e=document.querySelector(".tb-custom-category-selection");let s=e.querySelector(".category-select-button"),o=s.querySelector(".selected-category-value"),i=(s.addEventListener("click",e=>{e.preventDefault();e=i.classList.contains("show");i.classList.toggle("show"),s.classList.toggle("open"),s.setAttribute("aria-expanded",!e)}),document.createElement("div"));i.classList.add("category-options-list"),i.setAttribute("role","listbox"),[{value:"Services",label:"icon_category_services"},{value:"General",label:"icon_category_general",selected:!(i.innerHTML="")},{value:"Health",label:"icon_category_health"},{value:"Living",label:"icon_category_living"}].forEach((t,e)=>{let a=document.createElement("div");a.classList.add("category-option"),a.setAttribute("role","option"),a.setAttribute("data-value",t.value),a.textContent=this.getTranslation(t.label),t.selected&&(o.textContent=this.getTranslation(t.label),a.classList.add("selected")),a.addEventListener("click",e=>{o.textContent=this.getTranslation(t.label),i.querySelectorAll(".category-option").forEach(e=>e.classList.remove("selected")),a.classList.add("selected"),i.classList.remove("show"),s.classList.remove("open"),s.setAttribute("aria-expanded","false")}),i.appendChild(a)}),e.appendChild(i)}}class LoadingManager{constructor(e,t=300){this.preloaderElement=e,this._loading=!1,this._startTime=0,this.minDuration=t,this.transitionDuration=200}get loading(){return this._loading}set loading(e){(this._loading=e)?(this._startTime=performance.now(),this.showPreloader()):this.hidePreloader()}showPreloader(){this.preloaderElement.style.display="flex",requestAnimationFrame(()=>{this.preloaderElement.style.transition=`opacity ${this.transitionDuration}ms ease-in-out`,this.preloaderElement.style.opacity="1"})}hidePreloader(){var e=performance.now()-this._startTime;e>=this.minDuration?(this.preloaderElement.style.transition=`opacity ${this.transitionDuration}ms ease-in-out`,this.preloaderElement.style.opacity="0",setTimeout(()=>{this.preloaderElement.style.display="none"},this.transitionDuration)):setTimeout(()=>{this.hidePreloader()},this.minDuration-e)}}let environment="/Comforta_version2DevelopmentNETPostgreSQL",baseURL=window.location.origin+(window.location.origin.startsWith("http://localhost")?environment:"");class DataManager{constructor(e=[],t=[]){this.services=e,this.media=t,this.pages=[],this.selectedTheme=null,this.loadingManager=new LoadingManager(document.getElementById("preloader"))}async fetchAPI(t,e={},a=!1){try{a||(this.loadingManager.loading=!0);var s=await fetch(""+baseURL+t,{headers:{"Content-Type":"application/json"},...e});if(s.ok)return await s.json();throw new Error("HTTP error! status: "+s.status)}catch(e){throw console.error(`API Error (${t}):`,e),e}finally{a||(this.loadingManager.loading=!1)}}async getPages(){return this.pages=await this.fetchAPI("/api/toolbox/pages/list",{},!0),this.pages}async getSinglePage(e){return this.fetchAPI("/api/toolbox/singlepage?Pageid="+e)}async deletePage(e){return this.fetchAPI("/api/toolbox/deletepage?Pageid="+e)}async getPagesService(){return this.fetchAPI("/api/toolbox/pages/tree")}async createNewPage(e,t){t=generateNewPage(t);return this.fetchAPI("/api/toolbox/create-page",{method:"POST",body:JSON.stringify({PageName:e,PageJsonContent:JSON.stringify(t)})})}async updatePage(e){return this.fetchAPI("/api/toolbox/update-page",{method:"POST",body:JSON.stringify(e)},!0)}async updatePagesBatch(e){return this.fetchAPI("/api/toolbox/update-pages-batch",{method:"POST",body:JSON.stringify(e)})}async addPageChild(e,t){return this.fetchAPI("/api/toolbox/add-page-children",{method:"POST",body:JSON.stringify({ParentPageId:t,ChildPageId:e})})}async createContentPage(e){return console.log("createContentPage",e),this.fetchAPI("/api/toolbox/create-content-page",{method:"POST",body:JSON.stringify({PageId:e})})}async getLocationTheme(){return this.fetchAPI("/api/toolbox/location-theme")}async updateLocationTheme(){if(this.selectedTheme?.ThemeId)return this.fetchAPI("/api/toolbox/update-location-theme",{method:"POST",body:JSON.stringify({ThemeId:this.selectedTheme.ThemeId})});throw new Error("No theme selected")}async getMediaFiles(){return this.fetchAPI("/api/media/")}async deleteMedia(e){return this.fetchAPI("/api/media/delete?MediaId="+e)}async uploadFile(e,t,a,s){if(e)return this.fetchAPI("/api/media/upload",{method:"POST",headers:{"Content-Type":"multipart/form-data"},body:JSON.stringify({MediaName:t,MediaImageData:e,MediaSize:a,MediaType:s})},!0);throw new Error("Please select a file!")}async getContentPageData(e){return this.fetchAPI("/api/productservice?Productserviceid="+e)}}class EditorManager{editors={};pages=[];theme=[];currentEditor=null;currentPageId=null;selectedTemplateWrapper=null;selectedComponent=null;container=document.getElementById("child-container");constructor(e,t){this.dataManager=e,this.currentLanguage=t,this.templateManager=new TemplateManager(this.currentLanguage,this),this.editorEventManager=new EditorEventManager(this,this.templateManager),this.initializeEditorManager()}async initializeEditorManager(){var e=await this.dataManager.getLocationTheme();this.toolsSection.checkIfNotAuthenticated(e)||(this.theme=e.SDT_LocationTheme,e=await this.dataManager.getPages(),this.toolsSection.checkIfNotAuthenticated(e))||(this.pages=e.SDT_PageCollection,this.initializeHomePage())}initializeHomePage(){var e=this.pages.find(e=>"Home"==e.PageName);e?(this.createChildEditor(e),this.currentPageId=e.PageId):this.toolsSection.ui.displayAlertMessage(""+this.currentLanguage.getTranslation("no_home_page_found"),"danger")}getCurrentEditor(){return this.currentEditor.editor}setCurrentEditor(e){this.editors[e];this.currentEditor=this.editors[e],this.activateFrame(e+"-frame"),this.toolsSection.unDoReDo(this.currentEditor.editor)}activateFrame(e){let t=document.querySelector(e);document.querySelectorAll(".active-editor").forEach(e=>{e!==t&&e.classList.remove("active-editor")}),t.classList.add("active-editor")}createChildEditor(e){var t=this.setupEditorContainer(e),a=this.initializeGrapesEditor(t.editorId);this.editorEventManager.addEditorEventListeners(a,e),this.loadEditorContent(a,e),this.setupEditorLayout(a,e,t.containerId),this.finalizeEditorSetup(a,e,t)}setupEditorContainer(e){var t="gjs-"+this.container.children.length,a=t+"-frame",s=document.createElement("div");return s.innerHTML=this.generateEditorHTML(e,t),this.configureEditorContainer(s,a,e.PageId),{editorId:t,containerId:a}}generateEditorHTML(e,t){var a=this.shouldShowAppBar(e)?this.createAppBarHTML(e.PageName,e.PageId):"";return`
      <div class="header">
          <span id="current-time-${e.PageId}"></span>
          <span class="icons">
              <i class="fas fa-signal"></i>
              <i class="fas fa-wifi"></i>
              <i class="fas fa-battery"></i>
          </span>
      </div>
      ${a}
      <div id="${t}"></div>
    `}configureEditorContainer(e,t,a){e.id=t,e.dataset.pageid=a,e.classList.add("mobile-frame","adding"),this.container.appendChild(e),requestAnimationFrame(()=>{e.classList.remove("adding")})}shouldShowAppBar(e){return e.PageIsContentPage||"Home"!==e.PageName}createAppBarHTML(e,t){return`
      <div class="app-bar">
          <svg id="back-button-${t}" class="content-back-button" xmlns="http://www.w3.org/2000/svg" id="Group_14" data-name="Group 14" width="47" height="47" viewBox="0 0 47 47">
            <g id="Ellipse_6" data-name="Ellipse 6" fill="none" stroke="#262626" stroke-width="1">
              <circle cx="23.5" cy="23.5" r="23.5" stroke="none"/>
              <circle cx="23.5" cy="23.5" r="23" fill="none"/>
            </g>
            <path id="Icon_ionic-ios-arrow-round-up" data-name="Icon ionic-ios-arrow-round-up" d="M13.242,7.334a.919.919,0,0,1-1.294.007L7.667,3.073V19.336a.914.914,0,0,1-1.828,0V3.073L1.557,7.348A.925.925,0,0,1,.263,7.341.91.91,0,0,1,.27,6.054L6.106.26h0A1.026,1.026,0,0,1,6.394.07.872.872,0,0,1,6.746,0a.916.916,0,0,1,.64.26l5.836,5.794A.9.9,0,0,1,13.242,7.334Z" transform="translate(13 30.501) rotate(-90)" fill="#262626"/>
          </svg>
          <h1 class="title" style="text-transform: uppercase;">${e}</h1>
      </div>
    `}initializeGrapesEditor(e){return grapesjs.init({container:"#"+e,fromElement:!0,height:"100%",width:"auto",canvas:{styles:["https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css","https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css","https://fonts.googleapis.com/css2?family=Inter:wght@400;500&family=Roboto:wght@400;500&display=swap","/Resources/UCGrapes1/src/css/toolbox.css"]},baseCss:" ",dragMode:"normal",panels:{defaults:[]},sidebarManager:!1,storageManager:!1,modal:!1,commands:!1,hoverable:!1,highlightable:!1,selectable:!1})}updatePageJSONContent(e,t){let a=e.getProjectData();this.dataManager.pages.SDT_PageCollection.map(e=>(e.PageId==t.PageId&&(e.PageGJSJson=JSON.stringify(a)),e))}async loadEditorContent(e,t){t.PageGJSJson?await this.loadExistingContent(e,t):t.PageIsContentPage&&await this.loadNewContentPage(e,t),this.updatePageJSONContent(e,t)}async loadExistingContent(e,t){try{var a=JSON.parse(t.PageGJSJson);t.PageIsPredefined&&"Location"===t.PageName?await this.handleLocationPage(e,a):(!t.PageIsPredefined||"Reception"!==t.PageName)&&t.PageIsContentPage?(e.loadProjectData(a),await this.handleContentPage(e,t)):e.loadProjectData(a)}catch(e){console.error("Error loading existing content:",e)}}async handleLocationPage(e,t){t.pages[0].frames[0].component.components[0].components[0].components[0].components[0].components[0].components[0].attributes.src=this.dataManager.Location.LocationImage_GXI,t.pages[0].frames[0].component.components[0].components[0].components[0].components[0].components[0].components[1].components[0].content=this.dataManager.Location.LocationDescription,e.DomComponents.clear(),e.loadProjectData(t)}async handleContentPage(e,t){try{var a,s=await this.dataManager.getContentPageData(t.PageId);this.toolsSection.checkIfNotAuthenticated(s)||((a=s.SDT_ProductService)?(await this.updateContentPageElements(e,a),await this.updateEditorCtaButtons(e,a)):console.warn("No content page data received"))}catch(e){console.error("Error loading content page data:",e)}}async updateContentPageElements(e,t){var a=e.DomComponents.getWrapper();a?(await this.updateImage(a,t),await this.updateDescription(a,t),this.toolsSection.ui.pageContentCtas(t.CallToActions,e)):console.error("Wrapper not found in editor")}async updateImage(e,t){e=e.find("#product-service-image");if(0<e.length)if(t?.ProductServiceImage)try{e[0].setAttributes({src:t.ProductServiceImage,alt:"Product Service Image"})}catch(e){console.error("Error updating image:",e)}else e[0].remove()}async updateDescription(e,t){e=e.find("#product-service-description");if(0<e.length)if(t?.ProductServiceDescription)try{e[0].components(t.ProductServiceDescription)}catch(e){console.error("Error updating description:",e)}else e[0].remove()}async updateEditorCtaButtons(e,a){var e=e.DomComponents.getWrapper().find(".cta-button-container")[0];e&&(console.log("ctaContainer: ",e),0<(e=e.findType("cta-buttons")).length)&&(console.log("contentPageData: ",e),e.forEach(e=>{let t=e.getAttributes()?.["cta-button-id"];a?.CallToActions?.some(e=>e.CallToActionId===t)||e.remove()}))}async loadNewContentPage(e,t){try{var a,s,o=await this.dataManager.getContentPageData(t.PageId);this.toolsSection.checkIfNotAuthenticated(o)||(a=o.SDT_ProductService)&&(s=this.templateManager.initialContentPageTemplate(a),e.addComponents(s)[0],this.toolsSection.ui.pageContentCtas(a.CallToActions,e))}catch(e){console.error("Error fetching content page data:",e)}}setupEditorLayout(e,t,a){this.shouldShowAppBar(t)&&((e=e.Canvas.getElement())&&e.style.setProperty("height","calc(100% - 100px)","important"),this.backButtonAction(a,t.PageId))}finalizeEditorSetup(e,t,a){var s={pageId:t.PageId,editor:e};this.editors["#"+a.editorId]=s,"Home"===t.PageName&&this.setCurrentEditor("#"+a.editorId);e.getWrapper().set({selectable:!1,droppable:!1,draggable:!1,hoverable:!1});s=this.editorEventManager.activateNavigators();s.updateButtonVisibility(),s.scrollBy(200),new Clock("current-time-"+t.PageId)}getPage(t){return this.dataManager.pages.SDT_PageCollection.find(e=>e.PageId==t)}backButtonAction(a,e){e=document.getElementById("back-button-"+e);e&&e.addEventListener("click",e=>{e.preventDefault();e=document.getElementById(a);if(e){var t=e.parentElement,t=Array.from(t.children);let a=t.indexOf(e);t.forEach((e,t)=>{t>=a&&e.remove()}),this.editorEventManager.activateNavigators()}})}setToolsSection(e){this.toolsSection=e}}class EditorEventManager{constructor(e,t){this.editorManager=e,this.templateManager=t}addEditorEventListeners(e,t){this.editorOnLoad(e),this.editorOnSelected(e),this.setupKeyboardBindings(e),this.editorOnUpdate(e,t)}setupKeyboardBindings(e){e=e.Keymaps.keymaster;e.unbind("backspace"),e.unbind("delete"),e.bind("ctrl+z"),e.bind("ctrl+shift+z")}editorOnLoad(e){e.on("load",()=>this.handleEditorLoad(e))}handleEditorLoad(a){this.loadTheme();var e=a.getWrapper();this.editorManager.toolsSection.currentLanguage.translateTilesTitles(a),e.view.el.addEventListener("click",e=>{var t=this.editorManager.currentEditor.editor.getSelected();t&&(this.editorManager.currentEditor.editor.selectRemove(t),this.editorManager.selectedComponent=null,this.editorManager.selectedTemplateWrapper=null),this.handleEditorClick(e,a)})}loadTheme(){this.editorManager.toolsSection.themeManager.setTheme(this.editorManager.theme.ThemeName),this.editorManager.toolsSection.themeManager.listThemesInSelectField()}handleEditorClick(e,t){var a=t.getConfig().container,s=a+"-frame",a=(this.editorManager.setCurrentEditor(a),this.editorManager.currentPageId=$(s).data().pageid,this.updateToolsSection(),this.editorManager.toolsSection.unDoReDo(t),e.target.closest("[cta-buttons]")),a=(a&&this.editorManager.toolsSection.ui.activateCtaBtnStyles(this.editorManager.selectedComponent),e.target.closest("[tile-action-object-id]")),a=(a&&(a={...e,target:a},this.handleTileActionClick(a,s)),e.target.closest(".action-button"));a&&this.handleActionButtonClick(a,t)}handleTileActionClick(e,t){e=e.target.attributes["tile-action-object-id"].value,e=this.editorManager.getPage(e);$(t).nextAll().remove(),e&&this.editorManager.createChildEditor(e)}handleActionButtonClick(e,t){var a=e.closest(".template-wrapper");a&&(a=t.Components.getById(a.id))&&(this.templateComponent=a,e.classList.contains("delete-button")?this.templateManager.deleteTemplate(this.templateComponent):e.classList.contains("add-button-bottom")?this.templateManager.addTemplateBottom(this.templateComponent,t):e.classList.contains("add-button-right")&&this.templateManager.addTemplateRight(this.templateComponent,t))}editorOnSelected(e){e.on("component:selected",e=>this.handleComponentSelected(e))}editorOnUpdate(e,t){e.on("update",()=>{this.editorManager.updatePageJSONContent(e,t)})}handleComponentSelected(e){this.editorManager.selectedTemplateWrapper=e.getEl(),this.editorManager.selectedComponent=e;var t,e=document.getElementById("tile-title"),e=(this.editorManager.selectedTemplateWrapper&&((t=this.editorManager.selectedTemplateWrapper.querySelector(".tile-title"))&&(e.value=t.textContent),this.templateManager.removeElementOnClick(".selected-tile-icon",".tile-icon-section"),this.templateManager.removeElementOnClick(".selected-tile-title",".tile-title-section")),this.editorManager.toolsSection.ui.updateTileProperties(this.editorManager.currentEditor.editor,this.editorManager.currentPageId),this.editorManager.getPage(this.editorManager.currentPageId));e?.PageIsContentPage&&this.editorManager.toolsSection.ui.activateCtaBtnStyles(this.editorManager.selectedComponent),this.editorManager.toolsSection.checkTileBgImage(),this.activateNavigators(),this.updateUIState()}updateUIState(){document.querySelector("#templates-button").classList.remove("active"),document.querySelector("#pages-button").classList.remove("active"),document.querySelector("#pages-button").classList.add("active"),document.querySelector("#mapping-section").style.display="none",document.querySelector("#tools-section").style.display="block",document.querySelector("#templates-content").style.display="none",document.querySelector("#pages-content").style.display="block"}updateToolsSection(){var e=this.editorManager.getPage(this.editorManager.currentPageId);e&&(document.querySelector("#content-page-section").style.display=e.PageIsContentPage?"block":"none",document.querySelector("#menu-page-section").style.display=e.PageIsContentPage?"none":"block")}activateNavigators(){var e=document.querySelector(".page-navigator-left"),t=document.querySelector(".page-navigator-right");let s=document.getElementById("child-container"),o=document.getElementById("scroll-left"),i=document.getElementById("scroll-right");var a=document.querySelectorAll(".mobile-frame"),e=(e.style.display="flex",t.style.display="flex",window.innerWidth<=1440?1<a.length?"flex-start":"center":3<a.length?"flex-start":"center");s.style.setProperty("justify-content",e);let l=e=>{s.scrollTo({left:s.scrollLeft+e,behavior:"smooth"})};o.addEventListener("click",()=>l(-200)),i.addEventListener("click",()=>l(200));t=()=>{var{scrollLeft:e,scrollWidth:t,clientWidth:a}=s;o.style.display=0<e?"flex":"none",i.style.display=e+a<t?"flex":"none"};return t(),s.addEventListener("scroll",t),{updateButtonVisibility:t,scrollBy:l}}setupUndoRedoButtons(){var e=document.getElementById("undo"),a=document.getElementById("redo");if(this.editorManager.currentEditor){let t=new UndoRedoManager(this.editorManager.currentEditor.editor);e&&(e.disabled=!t.canUndo(),e.onclick=e=>{e.preventDefault(),t.undo()}),a&&(a.disabled=!t.canRedo(),a.onclick=()=>t.redo())}}}class TemplateManager{constructor(e,t){this.currentLanguage=e,this.editorManager=t,this.defaultConstraints={draggable:!1,selectable:!1,editable:!1,highlightable:!1,droppable:!1,hoverable:!1}}createTemplateHTML(e=!1){var t=this.editorManager.toolsSection.currentTheme.colors.accentColor;return`
            <div class="template-wrapper ${e?"default-template":""}"        
                  data-gjs-selectable="false"
                  data-gjs-type="tile-wrapper"
                  data-gjs-editable="false"
                  data-gjs-highlightable="false"
                  data-gjs-droppable="false"
                  data-gjs-resizable="false"
                  data-gjs-hoverable="false">
              <div class="template-block"
                style="background-color:${t}"
                tile-bgcolor="${t}"
                tile-bgcolor-name="accentColor"
                ${defaultTileAttrs} 
                 data-gjs-draggable="false"
                 data-gjs-selectable="true"
                 data-gjs-editable="false"
                 data-gjs-highlightable="false"
                 data-gjs-droppable="false"
                 data-gjs-resizable="false"
                 data-gjs-hoverable="false">
                
                 <div class="tile-icon-section"
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-highlightable="false"
                  data-gjs-droppable="false"
                  data-gjs-resizable="false"
                  data-gjs-hoverable="false"
                  >
                    <span class="tile-close-icon top-right selected-tile-icon"
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-highlightable="false"
                      data-gjs-droppable="false"
                      data-gjs-resizable="false"
                      data-gjs-hoverable="false"
                      >&times;</span>
                    <span 
                      class="tile-icon"
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-droppable="false"
                      data-gjs-highlightable="false"
                      data-gjs-hoverable="false">
                    </span>
                </div>
                <div class="tile-title-section"
                  data-gjs-draggable="false"
                  data-gjs-selectable="false"
                  data-gjs-editable="false"
                  data-gjs-highlightable="false"
                  data-gjs-droppable="false"
                  data-gjs-resizable="false"
                  data-gjs-hoverable="false"
                  >
                    <span class="tile-close-icon top-right selected-tile-title"
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-highlightable="false"
                      data-gjs-droppable="false"
                      data-gjs-resizable="false"
                      data-gjs-hoverable="false"
                      >&times;</span>
                    <span 
                      class="tile-title"
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-droppable="false"
                      data-gjs-highlightable="false"
                      data-gjs-hoverable="false">${this.currentLanguage.getTranslation("tile_title")}</span>
                    </div>
                </div>
              ${e?"":`
                <button class="action-button delete-button" title="Delete template"
                          data-gjs-draggable="false"
                          data-gjs-selectable="false"
                          data-gjs-editable="false"
                          data-gjs-droppable="false"
                          data-gjs-highlightable="false"
                          data-gjs-hoverable="false">
                  <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                          data-gjs-draggable="false"
                          data-gjs-selectable="false"
                          data-gjs-editable="false"
                          data-gjs-editable="false"
                          data-gjs-droppable="false"
                          data-gjs-highlightable="false"
                          data-gjs-hoverable="false">
                    <line x1="5" y1="12" x2="19" y2="12" 
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-highlightable="false"
                      data-gjs-droppable="false"
                      data-gjs-hoverable="false"/>
                  </svg>
                </button>
              `}
              <button class="action-button add-button-bottom" title="Add template below"
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-droppable="false"
                      data-gjs-editable="false"
                      data-gjs-highlightable="false"
                      data-gjs-hoverable="false">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-editable="false"
                      data-gjs-droppable="false"
                      data-gjs-highlightable="false"
                      data-gjs-hoverable="false">
                  <line x1="12" y1="5" x2="12" y2="19" 
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-highlightable="false"
                      data-gjs-droppable="false"
                      data-gjs-hoverable="false"/>
                  <line x1="5" y1="12" x2="19" y2="12" 
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-highlightable="false"
                      data-gjs-droppable="false"
                      data-gjs-hoverable="false"/>
                </svg>
              </button>
              <button class="action-button add-button-right" title="Add template right"
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-droppable="false"
                      data-gjs-highlightable="false"
                      data-gjs-hoverable="false">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-editable="false"
                      data-gjs-highlightable="false"
                      data-gjs-droppable="false"
                      data-gjs-hoverable="false">
                  <line x1="12" y1="5" x2="12" y2="19" 
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-highlightable="false"
                      data-gjs-droppable="false"
                      data-gjs-hoverable="false"/>
                  <line x1="5" y1="12" x2="19" y2="12" 
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-highlightable="false"
                      data-gjs-droppable="false"
                      data-gjs-hoverable="false"/>
                </svg>
              </button>
              <div class="resize-handle"
                      data-gjs-draggable="false"
                      data-gjs-selectable="false"
                      data-gjs-editable="false"
                      data-gjs-highlightable="false"
                      data-gjs-droppable="false"
                      data-gjs-hoverable="false">
              </div>
            </div>
          `}generateTemplateRow(t,a){var s=this.editorManager.toolsSection.currentTheme.colors.accentColor;let o=100/t,i=(1===t?o=100:2===t?o=49:3===t&&(o=32),"");for(let e=0;e<t;e++){var l=0===a&&0===e?"":`
                    <button class="action-button delete-button" title="Delete template"
                        data-gjs-draggable="false"
                        data-gjs-selectable="false"
                        data-gjs-editable="false"
                        data-gjs-droppable="false"
                        data-gjs-highlightable="false"
                        data-gjs-hoverable="false">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                            data-gjs-draggable="false"
                            data-gjs-selectable="false"
                            data-gjs-editable="false"
                            data-gjs-editable="false"
                            data-gjs-droppable="false"
                            data-gjs-highlightable="false"
                            data-gjs-hoverable="false">
                            <line x1="5" y1="12" x2="19" y2="12" 
                                data-gjs-draggable="false"
                                data-gjs-selectable="false"
                                data-gjs-editable="false"
                                data-gjs-highlightable="false"
                                data-gjs-droppable="false"
                                data-gjs-hoverable="false"/>
                        </svg>
                    </button>`;i+=`
                <div class="template-wrapper"
                          style="flex: 0 0 ${o}%); background: ${s}"
                          data-gjs-type="tile-wrapper"
                          data-gjs-selectable="false"
                          data-gjs-droppable="false">

                          <div class="template-block"
                            tile-bgcolor="${s}"
                            tile-bgcolor-name="accentColor"
                            ${defaultTileAttrs}
                            data-gjs-draggable="false"
                            data-gjs-selectable="true"
                            data-gjs-editable="false"
                            data-gjs-highlightable="false"
                            data-gjs-droppable="false"
                            data-gjs-resizable="false"
                            data-gjs-hoverable="false">
                            
                            <div class="tile-icon-section"
                              data-gjs-draggable="false"
                              data-gjs-selectable="false"
                              data-gjs-editable="false"
                              data-gjs-highlightable="false"
                              data-gjs-droppable="false"
                              data-gjs-resizable="false"
                              data-gjs-hoverable="false"
                              >
                                <span class="tile-close-icon top-right selected-tile-icon"
                                  data-gjs-draggable="false"
                                  data-gjs-selectable="false"
                                  data-gjs-editable="false"
                                  data-gjs-highlightable="false"
                                  data-gjs-droppable="false"
                                  data-gjs-resizable="false"
                                  data-gjs-hoverable="false"
                                  >&times;</span>
                                <span 
                                  class="tile-icon"
                                  data-gjs-draggable="false"
                                  data-gjs-selectable="false"
                                  data-gjs-editable="false"
                                  data-gjs-droppable="false"
                                  data-gjs-highlightable="false"
                                  data-gjs-hoverable="false">
                                </span>
                            </div>
                            <div class="tile-title-section"
                              data-gjs-draggable="false"
                              data-gjs-selectable="false"
                              data-gjs-editable="false"
                              data-gjs-highlightable="false"
                              data-gjs-droppable="false"
                              data-gjs-resizable="false"
                              data-gjs-hoverable="false"
                              >
                                <span class="tile-close-icon top-right selected-tile-title"
                                  data-gjs-draggable="false"
                                  data-gjs-selectable="false"
                                  data-gjs-editable="false"
                                  data-gjs-highlightable="false"
                                  data-gjs-droppable="false"
                                  data-gjs-resizable="false"
                                  data-gjs-hoverable="false"
                                  >&times;</span>
                                <span 
                                  class="tile-title"
                                  data-gjs-draggable="false"
                                  data-gjs-selectable="false"
                                  data-gjs-editable="false"
                                  data-gjs-droppable="false"
                                  data-gjs-highlightable="false"
                                  data-gjs-hoverable="false">${this.currentLanguage.getTranslation("tile_title")}</span>
                                </div>
                          </div>
                          ${l}
                          <button class="action-button add-button-bottom" title="Add template below"
                                  data-gjs-draggable="false"
                                  data-gjs-selectable="false"
                                  data-gjs-droppable="false"
                                  data-gjs-editable="false"
                                  data-gjs-highlightable="false"
                                  data-gjs-hoverable="false"
                                  >
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                                  data-gjs-draggable="false"
                                  data-gjs-selectable="false"
                                  data-gjs-editable="false"
                                  data-gjs-editable="false"
                                  data-gjs-highlightable="false"
                                  data-gjs-droppable="false"
                                  data-gjs-hoverable="false">
                              <line x1="12" y1="5" x2="12" y2="19" 
                                  data-gjs-draggable="false"
                                  data-gjs-selectable="false"
                                  data-gjs-editable="false"
                                  data-gjs-highlightable="false"
                                  data-gjs-droppable="false"
                                  data-gjs-hoverable="false"/>
                              <line x1="5" y1="12" x2="19" y2="12" 
                                  data-gjs-draggable="false"
                                  data-gjs-selectable="false"
                                  data-gjs-editable="false"
                                  data-gjs-highlightable="false"
                                  data-gjs-droppable="false"
                                  data-gjs-hoverable="false"/>
                            </svg>
                          </button>
                          <button class="action-button add-button-right" title="Add template right"
                                  data-gjs-draggable="false"
                                  data-gjs-selectable="false"
                                  data-gjs-editable="false"
                                  data-gjs-droppable="false"
                                  data-gjs-highlightable="false"
                                  data-gjs-hoverable="false">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                                  data-gjs-draggable="false"
                                  data-gjs-selectable="false"
                                  data-gjs-editable="false"
                                  data-gjs-editable="false"
                                  data-gjs-highlightable="false"
                                  data-gjs-droppable="false"
                                  data-gjs-hoverable="false">
                              <line x1="12" y1="5" x2="12" y2="19" 
                                  data-gjs-draggable="false"
                                  data-gjs-selectable="false"
                                  data-gjs-editable="false"
                                  data-gjs-highlightable="false"
                                  data-gjs-droppable="false"
                                  data-gjs-hoverable="false"/>
                              <line x1="5" y1="12" x2="19" y2="12" 
                                  data-gjs-draggable="false"
                                  data-gjs-selectable="false"
                                  data-gjs-editable="false"
                                  data-gjs-highlightable="false"
                                  data-gjs-droppable="false"
                                  data-gjs-hoverable="false"/>
                            </svg>
                          </button>
                          <div class="resize-handle"
                              data-gjs-draggable="false"
                              data-gjs-selectable="false"
                              data-gjs-editable="false"
                              data-gjs-highlightable="false"
                              data-gjs-droppable="false"
                              data-gjs-hoverable="false">
                          </div>
                      </div>
                `}return`
                      <div class="container-row"
                          data-gjs-type="template-wrapper"
                          data-gjs-draggable="false"
                          data-gjs-selectable="false"
                          data-gjs-editable="false"
                          data-gjs-highlightable="true"
                          data-gjs-droppable="false"
                          data-gjs-hoverable="true">
                        ${i}
                    </div>
              `}addFreshTemplate(t){var s=this.editorManager.currentEditor,e=this.editorManager.getPage(s.pageId);if(console.log(e),e&&(e.PageIsContentPage||"Location"===e.PageName||"Reception"===e.PageName||"Mailbox"===e.PageName||"Calendar"===e.PageName)){let e=this.currentLanguage.getTranslation("templates_only_added_to_menu_pages");void this.editorManager.toolsSection.ui.displayAlertMessage(e,"error")}else{s.editor.DomComponents.clear();let a="",e=(t.forEach((e,t)=>{e=this.generateTemplateRow(e,t);a+=e}),s.editor.addComponents(`
      <div class="frame-container"
            id="frame-container"
            data-gjs-type="template-wrapper"
            data-gjs-draggable="false"
            data-gjs-selectable="false"
            data-gjs-editable="false"
            data-gjs-highlightable="false"
            data-gjs-droppable="false"
            data-gjs-hoverable="false">
        <div class="container-column"
              data-gjs-type="template-wrapper"
              data-gjs-draggable="false"
              data-gjs-selectable="false"
              data-gjs-editable="false"
              data-gjs-highlightable="false"
              data-gjs-droppable="false"
              data-gjs-hoverable="false">
            ${a}
        </div>
      </div>
    `),this.currentLanguage.getTranslation("template_added_success_message"));this.editorManager.toolsSection.ui.displayAlertMessage(e,"success")}}deleteTemplate(e){if(e&&!e.getClasses().includes("default-template")){var a=e.parent();if(a){e.remove();e=a.components();let t=100/e.length;e.forEach(e=>{e&&e.setStyle&&e.addStyle({width:t+"%"})}),this.updateRightButtons(a)}}}addTemplateRight(e,a){var s=e.parent();if(s&&!(3<=s.components().length)){a=a.addComponents(this.createTemplateHTML())[0];if(a){e=e.index(),a=(s.append(a,{at:e+1}),s.components());let t=100/a.length;a.forEach(e=>{e.addStyle({flex:`0 0 calc(${t}% - 0.3.5rem)`})}),this.updateRightButtons(s)}}}addTemplateBottom(e,t){var e=e.parent(),a=e?.parent();a&&(t=t.addComponents(`
            <div class="container-row"
                data-gjs-type="template-wrapper"
                data-gjs-draggable="false"
                data-gjs-selectable="false"
                data-gjs-editable="false"
                data-gjs-highlightable="false"
                data-gjs-droppable="false"
                data-gjs-hoverable="false">
                ${this.createTemplateHTML()}
            </div>
            `)[0],e=e.index(),a.append(t,{at:e+1}))}updateRightButtons(e){if(e){let t=e.components();t.forEach(e=>{e&&e.view&&e.view.el&&e.view.el.querySelector(".add-button-right")&&(e=e.find(".add-button-right")[0],3<=t.length?e.addStyle({display:"none"}):e.addStyle({display:"flex"}))})}}initialContentPageTemplate(e){return console.log("initialContentPageTemplate",e),`
        <div
            class="content-frame-container test"
            id="frame-container"
            data-gjs-draggable="false"
            data-gjs-selectable="false"
            data-gjs-editable="false"
            data-gjs-highlightable="false"
            data-gjs-droppable="false"
            data-gjs-hoverable="false"
        >
            <div
                class="container-column"
                data-gjs-draggable="false"
                data-gjs-selectable="false"
                data-gjs-editable="false"
                data-gjs-highlightable="false"
                data-gjs-droppable="false"
                data-gjs-hoverable="false"
            >
                <div
                    class="container-row"
                    data-gjs-draggable="false"
                    data-gjs-selectable="false"
                    data-gjs-editable="false"
                    data-gjs-droppable="false"
                    data-gjs-highlightable="true"
                    data-gjs-hoverable="true"
                >
                    <div
                        class="template-wrapper"
                        data-gjs-draggable="false"
                        data-gjs-selectable="false"
                        data-gjs-editable="false"
                        data-gjs-droppable="false"
                        data-gjs-highlightable="true"
                        data-gjs-hoverable="true"
                        style="display: flex; width: 100%"
                    >
                        <div
                            data-gjs-draggable="false"
                            data-gjs-selectable="false"
                            data-gjs-editable="false"
                            data-gjs-highlightable="false"
                            data-gjs-droppable="[data-gjs-type='product-service-description'], [data-gjs-type='product-service-image']"
                            data-gjs-resizable="false"
                            data-gjs-hoverable="false"
                            style="flex: 1; padding: 0"
                            class="content-page-wrapper"
                        >
                            ${e.ProductServiceImage?`
                                <img
                                    class="content-page-block"
                                    id="product-service-image"
                                    data-gjs-draggable="true"
                                    data-gjs-selectable="false"
                                    data-gjs-editable="false"
                                    data-gjs-droppable="false"
                                    data-gjs-highlightable="false"
                                    data-gjs-hoverable="false"
                                    src="${e.ProductServiceImage}"
                                    data-gjs-type="product-service-image"
                                    alt="Full-width Image"
                                />
                            `:""}
                            ${e.ProductServiceDescription?`
                                <p
                                    style="flex: 1; padding: 0; margin: 0; height: auto;"
                                    class="content-page-block"
                                    data-gjs-draggable="true"
                                    data-gjs-selectable="false"
                                    data-gjs-editable="false"
                                    data-gjs-droppable="false"
                                    data-gjs-highlightable="false"
                                    data-gjs-hoverable="false"
                                    id="product-service-description"
                                    data-gjs-type="product-service-description"
                                >
                                ${e.ProductServiceDescription}
                                </p>
                            `:""}
                        </div>
                    </div>
                </div>
                <div class="cta-button-container" ${defaultConstraints}></div>
            </div>
        </div>
    `}removeElementOnClick(e,t){var e=this.editorManager.selectedComponent?.find(e)[0];e&&(e=e.getEl())&&(e.onclick=()=>{".tile-title-section"===t?(this.editorManager.selectedComponent.find(".tile-title")[0].components(""),this.editorManager.toolsSection.setAttributeToSelected("TileText",""),$("#tile-title").val("")):".tile-icon-section"===t&&(this.editorManager.selectedComponent.find(".tile-icon")[0].components(""),this.editorManager.toolsSection.setAttributeToSelected("tile-icon",""))})}}class ToolBoxManager{constructor(e,t,a,s,o,i,l,n){this.editorManager=e,this.dataManager=t,this.themes=a,this.icons=s,this.currentTheme=null,this.templates=o,this.mappingsItems=i,this.selectedFile=null,this.media=l,this.currentLanguage=n,this.ui=new ToolBoxUI(this),this.init(n.currentLanguage)}async init(e){try{this.currentLanguage=await new Locale(e).init(),this.themeManager=new ThemeManager(this),this.eventListenerManager=new EventListenerManager(this),this.popupManager=new PopupManager(this),this.pageManager=new PageManager(this),await this.initializeManagers(),await this.setupComponents(),this.setupEventListeners()}catch(e){console.error("Failed to initialize toolbox:",e)}}async initializeManagers(){await this.dataManager.getPages().then(e=>{this.checkIfNotAuthenticated(e)||localStorage.clear()}),this.themeManager.loadTheme(),this.themeManager.colorPalette(),this.themeManager.ctaColorPalette(),this.pageManager.loadPageTemplates()}setupComponents(){this.actionList=new ActionListComponent(this.editorManager,this.dataManager,this.currentLanguage,this),this.mediaComponent=new MediaComponent(this.dataManager,this.editorManager,this.currentLanguage,this)}setupEventListeners(){this.eventListenerManager.setupTabListeners(),this.eventListenerManager.setupMappingListeners(),this.eventListenerManager.setupPublishListeners(),this.eventListenerManager.setupAlignmentListeners(),this.eventListenerManager.setupOpacityListener(),this.eventListenerManager.setupAutoSave(),document.getElementById("tile-title").addEventListener("input",e=>{10<e.target.value.length&&(e.target.value=truncateText(e.target.value,12)),this.ui.updateTileTitle(e.target.value)})}publishPages(e){var t=Object.values(this.editorManager.editors);t&&t.length&&(t=this.preparePageDataList(t)).length&&this.sendPageUpdateRequest(t,e)}preparePageDataList(e){return this.dataManager.pages.SDT_PageCollection.map(e=>{let t;try{t=JSON.parse(e.PageGJSJson)}catch(e){t={}}var a=(e.PageIsContentPage?mapContentToPageData:mapTemplateToPageData)(t,e);return{PageId:e.PageId,PageName:e.PageName,PageJsonContent:JSON.stringify(a),PageGJSHtml:e.PageGJSHtml,PageGJSJson:e.PageGJSJson,SDT_Page:a,PageIsPublished:!0}})}async sendPageUpdateRequest(e,t){t={IsNotifyResidents:t,PagesList:e};try{var a=await this.dataManager.updatePagesBatch(t);this.checkIfNotAuthenticated(a)||this.ui.displayAlertMessage("All Pages Saved Successfully","success")}catch(e){console.error("Error saving pages:",e),this.ui.displayAlertMessage("An error occurred while saving pages.","error")}}autoSavePage(e){let t=e.pageId;var e=e.editor,a=this.dataManager.pages.SDT_PageCollection.find(e=>e.PageId==t);t&&(a={PageId:t,PageName:a.PageName,PageGJSHtml:e.getHtml(),PageGJSJson:JSON.stringify(e.getProjectData())},this.dataManager.updatePage(a).then(e=>{this.checkIfNotAuthenticated(e)||(this.dataManager.getPages().then(e=>{this.editorManager.pages=e.SDT_PageCollection}),this.ui.openToastMessage())}))}unDoReDo(e){let t=e.UndoManager;var e=document.getElementById("undo"),a=document.getElementById("redo");e&&(e.disabled=!t.hasUndo(),e.onclick=e=>{e.preventDefault(),t.undo(),this.editorManager.currentEditor.editor.refresh()}),a&&(a.disabled=!t.hasRedo(),a.onclick=e=>{e.preventDefault(),t.redo(),this.editorManager.currentEditor.editor.refresh()})}checkIfNotAuthenticated(e){return"Error"===e.error.Status&&(console.error("Error updating theme. Status:",e.error.Status,"Message:",e.error.Message),this.ui.displayAlertMessage(this.currentLanguage.getTranslation("not_authenticated_message"),"error"),!0)}setAttributeToSelected(e,t){this.editorManager.selectedComponent?this.editorManager.selectedComponent.addAttributes({[e]:t}):this.ui.displayAlertMessage(this.currentLanguage.getTranslation("no_tile_selected_error_message"),"error")}checkTileBgImage(){if(this.editorManager.selectedTemplateWrapper){let a=this.editorManager.selectedComponent;if(a){let t=document.getElementById("tile-img-container");var e,s;a.getStyle()["background-image"]?(e=a.getStyle()["background-image"].match(/url\((.*?)\)/)[1])&&t&&(s=t.querySelector("img"))&&(s.src=e,t.style.display="block",s=t.querySelector("button"))&&(s.onclick=e=>{e.preventDefault();e=a.getStyle()||{};delete e["background-image"],a.setStyle(e),t.style.display="none",this.setAttributeToSelected("tile-bg-image-url","")}):t.style.display="none"}}}}class EventListenerManager{constructor(e){this.toolBoxManager=e}setupTabListeners(){let a=document.querySelectorAll(".tb-tab-button"),s=document.querySelectorAll(".tb-tab-content");a.forEach(t=>{t.addEventListener("click",e=>{e.preventDefault(),a.forEach(e=>e.classList.remove("active")),s.forEach(e=>e.style.display="none"),t.classList.add("active"),document.querySelector(`#${t.dataset.tab}-content`).style.display="block"})})}setupMappingListeners(){var e=document.getElementById("open-mapping");document.getElementById("publish");let t=document.getElementById("mapping-section"),a=document.getElementById("tools-section");this.toolBoxManager.mappingComponent=new MappingComponent(this.toolBoxManager.dataManager,this.toolBoxManager.editorManager,this.toolBoxManager,this.toolBoxManager.currentLanguage),e.addEventListener("click",e=>{e.preventDefault(),a.style.display="none"===a.style.display?"block":"none",t.style.display="block"===t.style.display?"none":"block",this.toolBoxManager.mappingComponent.init()})}setupPublishListeners(){document.getElementById("publish").onclick=e=>{e.preventDefault();let t=document.createElement("div");t.className="popup-modal",t.innerHTML=`
                <div class="popup">
                  <div class="popup-header">
                    <span>${this.toolBoxManager.currentLanguage.getTranslation("publish_confirm_title")}</span>
                    <button class="close">
                      <svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 21 21">
                          <path id="Icon_material-close" data-name="Icon material-close" d="M28.5,9.615,26.385,7.5,18,15.885,9.615,7.5,7.5,9.615,15.885,18,7.5,26.385,9.615,28.5,18,20.115,26.385,28.5,28.5,26.385,20.115,18Z" transform="translate(-7.5 -7.5)" fill="#6a747f" opacity="0.54"/>
                      </svg>
                    </button>
                  </div>
                  <hr>
                  <div class="popup-body" id="confirmation_modal_message">
                  ${this.toolBoxManager.currentLanguage.getTranslation("publish_confirm_message")}
                    <label for="notify_residents" class="notify_residents">
                        <input type="checkbox" id="notify_residents" name="notify_residents">
                        <span>${this.toolBoxManager.currentLanguage.getTranslation("nofity_residents_on_publish")}</span>
                    </label>
                  </div>
                  <div class="popup-footer">
                    <button id="yes_publish" class="tb-btn tb-btn-primary">
                    ${this.toolBoxManager.currentLanguage.getTranslation("publish_confirm_button")}
                    </button>
                    <button id="close_popup" class="tb-btn tb-btn-outline">
                    ${this.toolBoxManager.currentLanguage.getTranslation("publish_cancel_button")}
                    </button>
                  </div>
                </div>
              `,document.body.appendChild(t),t.style.display="flex";var e=t.querySelector("#yes_publish"),a=t.querySelector("#close_popup"),s=t.querySelector(".close");e.addEventListener("click",()=>{var e=document.getElementById("notify_residents").checked;this.toolBoxManager.publishPages(e),t.remove()}),a.addEventListener("click",()=>{t.remove()}),s.addEventListener("click",()=>{t.remove()})}}setupAlignmentListeners(){var e=document.getElementById("text-align-left"),t=document.getElementById("text-align-center"),a=document.getElementById("text-align-right"),e=(e.addEventListener("click",()=>{var e;this.toolBoxManager.editorManager.selectedTemplateWrapper?(e=this.toolBoxManager.editorManager.selectedComponent.find(".tile-title-section")[0])&&(e.setStyle({"text-align":"left"}),this.toolBoxManager.setAttributeToSelected("tile-text-align","left")):(e=this.toolBoxManager.currentLanguage.getTranslation("no_tile_selected_error_message"),this.toolBoxManager.ui.displayAlertMessage(e,"error"))}),t.addEventListener("click",()=>{var e;this.toolBoxManager.editorManager.selectedTemplateWrapper?(e=this.toolBoxManager.editorManager.selectedComponent.find(".tile-title-section")[0])&&(e.setStyle({"text-align":"center"}),this.toolBoxManager.setAttributeToSelected("tile-text-align","center")):(e=this.toolBoxManager.currentLanguage.getTranslation("no_tile_selected_error_message"),this.toolBoxManager.ui.displayAlertMessage(e,"error"))}),a.addEventListener("click",()=>{var e;this.toolBoxManager.editorManager.selectedTemplateWrapper?(e=this.toolBoxManager.editorManager.selectedComponent.find(".tile-title-section")[0])&&(e.setStyle({"text-align":"right"}),this.toolBoxManager.setAttributeToSelected("tile-text-align","right")):(e=this.toolBoxManager.currentLanguage.getTranslation("no_tile_selected_error_message"),this.toolBoxManager.ui.displayAlertMessage(e,"error"))}),document.getElementById("icon-align-left")),t=document.getElementById("icon-align-center"),a=document.getElementById("icon-align-right");e.addEventListener("click",()=>{var e;this.toolBoxManager.editorManager.selectedTemplateWrapper?(e=this.toolBoxManager.editorManager.selectedComponent.find(".tile-icon-section")[0])&&(e.setStyle({display:"flex","align-self":"start"}),this.toolBoxManager.setAttributeToSelected("tile-icon-align","left")):(e=this.toolBoxManager.currentLanguage.getTranslation("no_tile_selected_error_message"),this.toolBoxManager.ui.displayAlertMessage(e,"error"))}),t.addEventListener("click",()=>{var e;this.toolBoxManager.editorManager.selectedTemplateWrapper?(e=this.toolBoxManager.editorManager.selectedComponent.find(".tile-icon-section")[0])&&(e.setStyle({display:"flex","align-self":"center"}),this.toolBoxManager.setAttributeToSelected("tile-icon-align","center")):(e=this.toolBoxManager.currentLanguage.getTranslation("no_tile_selected_error_message"),this.toolBoxManager.ui.displayAlertMessage(e,"error"))}),a.addEventListener("click",()=>{var e;this.toolBoxManager.editorManager.selectedTemplateWrapper?(e=this.toolBoxManager.editorManager.selectedComponent.find(".tile-icon-section")[0])&&(e.setStyle({display:"flex","align-self":"end"}),this.toolBoxManager.setAttributeToSelected("tile-icon-align","right")):(e=this.toolBoxManager.currentLanguage.getTranslation("no_tile_selected_error_message"),this.toolBoxManager.ui.displayAlertMessage(e,"error"))})}setupOpacityListener(){document.getElementById("bg-opacity").addEventListener("input",t=>{t=t.target.value;if(this.toolBoxManager.editorManager.selectedTemplateWrapper){var a=this.toolBoxManager.editorManager.selectedComponent;if(a){var t=t/100,s=a.getStyle()["background-color"];let e;e=s.startsWith("#")?hexToRgb(s):s.startsWith("rgb")?s.match(/\d+, \d+, \d+/)[0]:"255, 255, 255",console.log("currentBgColor",e),a.addStyle({"background-color":`rgba(${e}, ${t})`})}}})}setupAutoSave(){setInterval(()=>{var t=Object.values(this.toolBoxManager.editorManager.editors);if(this.toolBoxManager.previousStates||(this.toolBoxManager.previousStates=new Map),t&&t.length)for(let e=0;e<t.length;e++){var a=t[e],s=a.editor,o=a.pageId,s=(this.toolBoxManager.previousStates.has(o)||this.toolBoxManager.previousStates.set(o,s.getHtml()),s.getHtml());s!==this.toolBoxManager.previousStates.get(o)&&(this.toolBoxManager.autoSavePage(a),this.toolBoxManager.previousStates.set(o,s))}},1e4)}}class PageManager{constructor(e){this.toolBoxManager=e}loadPageTemplates(){let o=document.getElementById("page-templates");this.toolBoxManager.templates.forEach((t,e)=>{var a=document.createElement("div"),s=(a.className="page-template-wrapper",document.createElement("div")),e=(s.className="page-template-block-number",s.textContent=e+1,document.createElement("div"));e.className="page-template-block",e.title=this.toolBoxManager.currentLanguage.getTranslation("click_to_load_template"),e.innerHTML=`<div>${t.media}</div>`,a.addEventListener("click",()=>{let e=this.toolBoxManager.popupManager.popupModal();document.body.appendChild(e),e.style.display="flex",e.querySelector(".close").onclick=()=>{e.style.display="none",document.body.removeChild(e)},e.querySelector("#close_popup").onclick=()=>{e.style.display="none",document.body.removeChild(e)},e.querySelector("#accept_popup").onclick=()=>{e.style.display="none",document.body.removeChild(e),this.toolBoxManager.editorManager.templateManager.addFreshTemplate(t.content)}}),a.appendChild(s),a.appendChild(e),o.appendChild(a)})}}class PopupManager{constructor(e){this.toolBoxManager=e}popupModal(){var e=document.createElement("div");return e.className="popup-modal",e.innerHTML=`
            <div class="popup">
              <div class="popup-header">
                <span>${this.toolBoxManager.currentLanguage.getTranslation("confirmation_modal_title")}</span>
                <button class="close">
                  <svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 21 21">
                      <path id="Icon_material-close" data-name="Icon material-close" d="M28.5,9.615,26.385,7.5,18,15.885,9.615,7.5,7.5,9.615,15.885,18,7.5,26.385,9.615,28.5,18,20.115,26.385,28.5,28.5,26.385,20.115,18Z" transform="translate(-7.5 -7.5)" fill="#6a747f" opacity="0.54"/>
                  </svg>
                </button>
              </div>
              <hr>
              <div class="popup-body" id="confirmation_modal_message">
                ${this.toolBoxManager.currentLanguage.getTranslation("confirmation_modal_message")}
              </div>
              <div class="popup-footer">
                <button id="accept_popup" class="tb-btn tb-btn-primary">
                ${this.toolBoxManager.currentLanguage.getTranslation("accept_popup")}
                </button>
                <button id="close_popup" class="tb-btn tb-btn-outline">
                ${this.toolBoxManager.currentLanguage.getTranslation("cancel_btn")}
                </button>
              </div>
            </div>
          `,e}}class ThemeManager{constructor(e){this.toolBoxManager=e}loadTheme(){this.toolBoxManager.dataManager.getLocationTheme().then(e=>{this.toolBoxManager.themeManager.setTheme(e.SDT_LocationTheme.ThemeName)})}setTheme(t){var e=this.toolBoxManager.themes.find(e=>e.ThemeName===t);return document.querySelector(".tb-custom-theme-selection").querySelector(".selected-theme-value").textContent=t,!!e&&(this.toolBoxManager.currentTheme=e,this.applyTheme(),this.toolBoxManager.icons=e.ThemeIcons.map(e=>({name:e.IconName,svg:e.IconSVG,category:e.IconCategory})),this.loadThemeIcons(e.ThemeIcons),this.themeColorPalette(this.toolBoxManager.currentTheme.ThemeColors),localStorage.setItem("selectedTheme",t),this.applyThemeIconsAndColor(t),this.listThemesInSelectField(),!0)}applyTheme(){var e=document.querySelectorAll(".mobile-frame iframe");e.length&&e.forEach(e=>{e=e.contentDocument||e.contentWindow.document;this.updateRootStyle(e,"primary-color",this.toolBoxManager.currentTheme.ThemeColors.primaryColor),this.updateRootStyle(e,"secondary-color",this.toolBoxManager.currentTheme.ThemeColors.secondaryColor),this.updateRootStyle(e,"background-color",this.toolBoxManager.currentTheme.ThemeColors.backgroundColor),this.updateRootStyle(e,"text-color",this.toolBoxManager.currentTheme.ThemeColors.textColor),this.updateRootStyle(e,"button-bg-color",this.toolBoxManager.currentTheme.ThemeColors.buttonBgColor),this.updateRootStyle(e,"button-text-color",this.toolBoxManager.currentTheme.ThemeColors.buttonTextColor),this.updateRootStyle(e,"card-bg-color",this.toolBoxManager.currentTheme.ThemeColors.cardBgColor),this.updateRootStyle(e,"card-text-color",this.toolBoxManager.currentTheme.ThemeColors.cardTextColor),this.updateRootStyle(e,"accent-color",this.toolBoxManager.currentTheme.ThemeColors.accentColor),this.updateRootStyle(e,"font-family",this.toolBoxManager.currentTheme.ThemeFontFamily),this.updatePageTitleFontFamily(this.toolBoxManager.currentTheme.ThemeFontFamily)})}updateRootStyle(t,a,s){t=t.body.querySelector("style");if(t){let e=t.innerHTML;var o=new RegExp(`(--${a}:\\s*)([^;]+)(;)`);e=o.test(e)?e.replace(o,`$1${s}$3`):e.replace(/:root\s*{/,`:root {
  --${a}: ${s};`),t.innerHTML=e}else console.log("No style tag found")}applyThemeIconsAndColor(a){var e=Object.values(this.toolBoxManager.editorManager.editors);if(e&&e.length)for(let t=0;t<e.length;t++){var s=e[t];if(!s||!s.editor)return void console.error(`Invalid editorData at index ${t}:`,s);try{var o=s.editor;if(o&&"function"==typeof o.getWrapper){var l=o.getWrapper();let i=this.toolBoxManager.themes.find(e=>e.ThemeName===a);l.find(".template-block").forEach(e=>{if(e){let t=e.getAttributes()?.["tile-icon"];if(t){var a=i.icons?.find(e=>e.IconName===t);if(a){var s=e.find(".tile-icon svg")?.[0];if(s){var o=s.find("path")?.[0];let e="#7c8791",t=(o&&o.getAttributes()&&(e=o.getAttributes().fill||e),a.IconSVG);t&&(t=t.replace(/fill="[^"]*"/g,`fill="${e}"`),s.replaceWith(t))}}}o=e.getAttributes()?.["tile-bgcolor-name"];o&&i.ThemeColors&&((a=i.ThemeColors[o])?(e.addAttributes({"tile-bgcolor-name":o,"tile-bgcolor":a}),e.addStyle({"background-color":a})):console.warn("No matching color found for: "+o))}})}else console.error(`Invalid editor at index ${t}:`,o)}catch(e){console.error(`Error processing editor at index ${t}:`,e)}}var t=document.querySelectorAll(".mobile-frame iframe");null!==t&&t.forEach(e=>{e=e.contentDocument||e.contentWindow.document;e&&e.body&&e.body.style.setProperty("--font-family",this.toolBoxManager.currentTheme.ThemeFontFamily)})}themeColorPalette(e){let l=document.getElementById("theme-color-palette");l.innerHTML="",Object.entries(e).forEach(([t,a],e)=>{var s=document.createElement("div"),o=(s.className="color-item",document.createElement("input")),i=(o.type="radio",o.id="color-"+t,o.name="theme-color",o.value=t,document.createElement("label"));i.className="color-box",i.setAttribute("for","color-"+t),i.style.backgroundColor=a,i.setAttribute("data-tile-bgcolor",a),s.appendChild(o),s.appendChild(i),l.appendChild(s),i.onclick=()=>{var e;this.toolBoxManager.editorManager.selectedComponent?(this.toolBoxManager.editorManager.selectedComponent.addStyle({"background-color":a}),this.toolBoxManager.setAttributeToSelected("tile-bgcolor",a),this.toolBoxManager.setAttributeToSelected("tile-bgcolor-name",t)):(e=this.toolBoxManager.currentLanguage.getTranslation("no_tile_selected_error_message"),this.toolBoxManager.ui.displayAlertMessage(e,"error"))}})}colorPalette(){let i=document.getElementById("text-color-palette"),l=document.getElementById("icon-color-palette");var e={color1:"#ffffff",color2:"#333333"};Object.entries(e).forEach(([e,t])=>{var a=document.createElement("div"),s=(a.className="color-item",document.createElement("input")),o=(s.type="radio",s.id="text-color-"+e,s.name="text-color",s.value=e,document.createElement("label"));o.className="color-box",o.setAttribute("for","text-color-"+e),o.style.backgroundColor=t,o.setAttribute("data-tile-text-color",t),a.appendChild(s),a.appendChild(o),i.appendChild(a),s.onclick=()=>{var e=this.toolBoxManager.editorManager.selectedComponent;e?(e.addStyle({color:t}),this.toolBoxManager.setAttributeToSelected("tile-text-color",t)):(e=this.toolBoxManager.currentLanguage.getTranslation("no_tile_selected_error_message"),this.toolBoxManager.ui.displayAlertMessage(e,"error"))}}),Object.entries(e).forEach(([e,t])=>{var a=document.createElement("div"),s=(a.className="color-item",document.createElement("input")),o=(s.type="radio",s.id="icon-color-"+e,s.name="icon-color",s.value=e,document.createElement("label"));o.className="color-box",o.setAttribute("for","icon-color-"+e),o.style.backgroundColor=t,o.setAttribute("data-tile-icon-color",t),a.appendChild(s),a.appendChild(o),l.appendChild(a),s.onclick=()=>{var e=this.toolBoxManager.editorManager.selectedComponent;e?(e=e.find(".tile-icon path")[0])?(e.removeAttributes("fill"),e.addAttributes({fill:t}),this.toolBoxManager.setAttributeToSelected("tile-icon-color",t)):(e=this.toolBoxManager.currentLanguage.getTranslation("no_icon_selected_error_message"),this.toolBoxManager.ui.displayAlertMessage(e,"error")):(e=this.toolBoxManager.currentLanguage.getTranslation("no_tile_selected_error_message"),this.toolBoxManager.ui.displayAlertMessage(e,"error"))}})}ctaColorPalette(){let i=document.getElementById("cta-color-palette");Object.entries({color1:"#4C9155",color2:"#5068A8",color3:"#EEA622",color4:"#FF6C37"}).forEach(([e,t])=>{var a=document.createElement("div"),s=(a.className="color-item",document.createElement("input")),o=(s.type="radio",s.id="cta-color-"+e,s.name="cta-color",s.value=e,document.createElement("label"));o.className="color-box",o.setAttribute("for","cta-color-"+e),o.style.backgroundColor=t,o.setAttribute("data-cta-color",t),a.appendChild(s),a.appendChild(o),i.appendChild(a),s.onclick=()=>{var e;this.toolBoxManager.editorManager.selectedComponent&&((e=0<(e=[...(e=this.toolBoxManager.editorManager.selectedComponent).find(".cta-main-button"),...e.find(".cta-button"),...e.find(".img-button"),...e.find(".plain-button")]).length?e[0]:null)&&e.addStyle({"background-color":t,"border-color":t}),this.toolBoxManager.setAttributeToSelected("cta-background-color",t))}})}listThemesInSelectField(){var e=document.querySelector(".tb-custom-theme-selection");let a=e.querySelector(".theme-select-button"),s=a.querySelector(".selected-theme-value");var t=e.querySelector(".theme-options-list");t&&t.remove();let o=document.createElement("div");o.classList.add("theme-options-list"),o.setAttribute("role","listbox"),e.appendChild(o),a.addEventListener("click",e=>{e.preventDefault();e=o.classList.contains("show");o.classList.toggle("show"),a.classList.toggle("open"),a.setAttribute("aria-expanded",!e)}),this.toolBoxManager.themes.forEach(t=>{let e=document.createElement("div");e.classList.add("theme-option"),e.setAttribute("role","option"),e.setAttribute("data-value",t.ThemeName),e.textContent=t.ThemeName,this.toolBoxManager.currentTheme&&t.ThemeName===this.toolBoxManager.currentTheme.ThemeName&&(e.classList.add("selected"),s.textContent=t.ThemeName),e.addEventListener("click",()=>{s.textContent=t.ThemeName,o.querySelectorAll(".theme-option").forEach(e=>e.classList.remove("selected")),e.classList.add("selected"),o.classList.remove("show"),a.classList.remove("open"),a.setAttribute("aria-expanded","false"),this.toolBoxManager.dataManager.selectedTheme=this.toolBoxManager.themes.find(e=>e.ThemeName===t.ThemeName),this.toolBoxManager.dataManager.updateLocationTheme().then(e=>{this.toolBoxManager.checkIfNotAuthenticated(e)||(console.log("Theme: ",t),this.setTheme(t.ThemeName)?(this.themeColorPalette(this.toolBoxManager.currentTheme.ThemeColors),localStorage.setItem("selectedTheme",t.ThemeName),this.toolBoxManager.editorManager.theme=t,console.log("Theme applied: ",t.ThemeName),console.log("Editor theme: ",this.toolBoxManager.editorManager.theme),this.updatePageTitleFontFamily(t.ThemeFontFamily),e=this.toolBoxManager.currentLanguage.getTranslation("theme_applied_success_message"),this.toolBoxManager.ui.displayAlertMessage(e,"success")):(e=this.toolBoxManager.currentLanguage.getTranslation("error_applying_theme_message"),this.toolBoxManager.ui.displayAlertMessage(e,"error")))})}),o.appendChild(e)})}updatePageTitleFontFamily(t){document.querySelectorAll(".app-bar").forEach(e=>{e.querySelector("h1").style.fontFamily=t})}loadThemeIcons(t){let s=document.getElementById("icons-list"),a;document.querySelectorAll(".category-option").forEach(e=>{e.classList.contains("selected")&&(a=e.getAttribute("data-value")),e.addEventListener("click",()=>{a=e.getAttribute("data-value"),o()})});let o=()=>{s.innerHTML="";var e=t.filter(e=>e.IconCategory.trim()===a);0===e.length&&console.log("No icons found for selected category."),e.forEach(a=>{var e=document.createElement("div"),t=(e.classList.add("icon"),e.title=a.IconName,1<(t=a.IconName.split(" ")).length?5<=(t=t[0]).length?t.slice(0,5)+"...":t:5<a.IconName.length?a.IconName.slice(0,5)+"...":a.IconName);e.innerHTML=`
                    ${a.IconSVG}
                    <span class="icon-title">${t}</span>
                `,e.onclick=()=>{var e,t;this.toolBoxManager.editorManager.selectedTemplateWrapper?(t=this.toolBoxManager.editorManager.selectedComponent.find(".tile-icon")[0])&&(e=a.IconSVG.replace('fill="#7c8791"','fill="white"'),t.components(e),this.toolBoxManager.setAttributeToSelected("tile-icon",a.IconName),this.toolBoxManager.setAttributeToSelected("tile-icon",a.IconName),this.toolBoxManager.setAttributeToSelected("tile-icon-color","#ffffff")):(t=this.toolBoxManager.currentLanguage.getTranslation("no_tile_selected_error_message"),this.toolBoxManager.ui.displayAlertMessage(t,"error"))},s.appendChild(e)})};o()}}class ToolBoxUI{constructor(e){this.manager=e,this.currentLanguage=e.currentLanguage}updateTileTitle(e){var t;this.manager.editorManager.selectedTemplateWrapper&&(t=this.manager.editorManager.selectedComponent.find(".tile-title")[0])&&t.components(e)}displayAlertMessage(e,t){var a=document.getElementById("alerts-container");let s=Math.random().toString(10);e=this.alertMessage(e,t,s);e.style.display="flex",e.querySelector(".alert-close-btn").addEventListener("click",()=>{this.closeAlert(s)}),setTimeout(()=>this.closeAlert(s),5e3),a.appendChild(e)}alertMessage(e,t,a){var s=document.createElement("div");return s.id=a,s.classList="alert "+("success"==t?"success":"error"),s.innerHTML=`
        <div class="alert-header">
          <strong>
            ${"success"==t?this.currentLanguage.getTranslation("alert_type_success"):this.currentLanguage.getTranslation("alert_type_error")}
          </strong>
          <span class="alert-close-btn">✖</span>
        </div>
        <p>${e}</p>
      `,s}closeAlert(e){let t=document.getElementById(e);t&&(t.style.opacity=0,setTimeout(()=>t.remove(),500))}openToastMessage(){let e=document.createElement("div");e.id="toast",e.textContent="Your changes are saved",document.body.appendChild(e),setTimeout(()=>{e.style.opacity="1",e.style.transform="translateX(-50%) translateY(0)"},100),setTimeout(()=>{e.style.opacity="0",setTimeout(()=>{document.body.removeChild(e)},500)},3e3)}updateTileProperties(e,t){t&&t.PageIsContentPage?this.updateContentPageProperties():this.updateTemplatePageProperties()}updateContentPageProperties(){let a=this.manager.editorManager.selectedComponent?.getAttributes()?.["cta-background-color"];document.querySelectorAll('#cta-color-palette input[type="radio"]').forEach(e=>{var t=e.nextElementSibling;e.checked=t.getAttribute("data-cta-color").toUpperCase()===a.toUpperCase()})}updateTemplatePageProperties(){this.updateAlignmentProperties(),this.updateColorProperties(),this.updateActionProperties()}updateAlignmentProperties(){[{type:"text",attribute:"tile-text-align"},{type:"icon",attribute:"tile-icon-align"}].forEach(({type:t,attribute:e})=>{let a=this.manager.editorManager.selectedComponent?.getAttributes()?.[e];["left","center","right"].forEach(e=>{document.getElementById(t+"-align-"+e).checked=a===e})})}updateColorProperties(){let a=this.manager.editorManager.selectedComponent?.getAttributes()?.["tile-text-color"];document.querySelectorAll('.text-color-palette.text-colors .color-item input[type="radio"]').forEach(e=>{var t=e.nextElementSibling;e.checked=t.getAttribute("data-tile-text-color")===a});let s=this.manager.editorManager.selectedComponent?.getAttributes()?.["tile-icon-color"],o=(document.querySelectorAll('.text-color-palette.icon-colors .color-item input[type="radio"]').forEach(e=>{var t=e.nextElementSibling;e.checked=t.getAttribute("data-tile-icon-color")===s}),this.manager.editorManager.selectedComponent?.getAttributes()?.["tile-bgcolor"]);document.querySelectorAll('#theme-color-palette input[type="radio"]').forEach(e=>{var t=e.nextElementSibling;e.checked=t.getAttribute("data-tile-bgcolor")===o});var e=this.manager.editorManager.selectedComponent?.getAttributes()?.["tile-bg-image-opacity"];document.getElementById("bg-opacity").value=e}updateActionProperties(){var e=this.manager.editorManager.selectedComponent?.getAttributes()?.["tile-action-object"],t=this.manager.editorManager.selectedComponent?.getAttributes()?.["tile-action-object-id"],a=document.getElementById("selectedOption"),s=document.getElementById(t);document.querySelectorAll(".category-content li").forEach(e=>{e.style.background=""}),a.textContent="Select Action",e&&t&&s&&(a.textContent=e,a.innerHTML+=' <i class="fa fa-angle-down"></i>',s.style.background="#f0f0f0")}pageContentCtas(e,t){var a;null==e||e.length<=0?this.noCtaSection():(a=document.getElementById("call-to-actions"),document.getElementById("cta-style").style.display="flex",document.getElementById("no-cta-message").style.display="none",this.renderCtas(e,t,a),this.setupButtonLayoutListeners(t),this.setupBadgeClickListener(t))}renderCtas(e,a,s){s.innerHTML="",e.forEach(e=>{var t=this.createCtaItem(e);this.attachClickHandler(t,e,a),s.appendChild(t)})}createCtaItem(e){var t=document.createElement("div"),e=(t.classList.add("call-to-action-item"),t.title=e.CallToActionName,t.id=e.CallToActionId,t.setAttribute("data-cta-id",e.CallToActionId),this.getCtaType(e.CallToActionType));return t.innerHTML=`<i class="${e.icon}"></i>`,t}getCtaType(e){return{Phone:{icon:"fas fa-phone-alt",iconList:".fas.fa-phone-alt"},Email:{icon:"fas fa-envelope",iconList:".fas.fa-envelope"},SiteUrl:{icon:"fas fa-link",iconList:".fas.fa-link"},Form:{icon:"fas fa-file",iconList:".fas.fa-file"}}[e]||{icon:"fas fa-question",iconList:".fas.fa-question"}}generateCtaComponent(e,t=0){var a=this.getCtaType(e.CallToActionType);return`
      <div class="cta-container-child cta-child" 
            id="id-${e.CallToActionId}"
            data-gjs-type="cta-buttons"
            cta-button-id="${e.CallToActionId}"
            data-gjs-draggable="false"
            data-gjs-editable="false"
            data-gjs-highlightable="false"
            data-gjs-droppable="false"
            data-gjs-resizable="false"
            data-gjs-hoverable="false"
            cta-button-label="${e.CallToActionName}"
            cta-button-type="${e.CallToActionType}"
            cta-button-action="${e.CallToActionPhone||e.CallToActionEmail||e.CallToActionUrl}"
            cta-background-color="#5068a8"
          >
            <div class="cta-button" ${defaultConstraints} style="background-color: #5068a8;">
              <i class="${a.icon}" ${defaultConstraints}></i>
              <div class="cta-badge" ${defaultConstraints}><i class="fa fa-minus" ${defaultConstraints}></i></div>
            </div>
            <div class="cta-label" ${defaultConstraints}>${e.CallToActionName}</div>
      </div>
    `}handleExistingButton(e,a,t,s){e=e.getAttributes()["cta-background-color"],e=this.generateCtaComponent(a,e);t.getAttributes()["cta-button-id"]===a.CallToActionId&&(s.once("component:add",e=>{var t=s.getWrapper().find("#id-"+a.CallToActionId)[0];t&&s.select(t)}),t.replaceWith(e))}attachClickHandler(e,s,o){e.onclick=e=>{e.preventDefault();var t,a,e=o.getWrapper().find(".cta-button-container")[0];e?(t=this.manager.editorManager.selectedComponent,(a=e.find("#id-"+s.CallToActionId)?.[0])?this.handleExistingButton(a,s,t,o):e.append(this.generateCtaComponent(s))):console.error("CTA Button container not found.")}}setupButtonLayoutListeners(e){this.setupPlainButtonListener(e),this.setupImageButtonListener(e)}isValidCtaComponent(e){return e.hasOwnProperty("cta-button-label")&&e.hasOwnProperty("cta-button-type")&&e.hasOwnProperty("cta-button-action")}extractCtaAttributes(e){e=e.getAttributes();return{ctaId:e["cta-button-id"],ctaName:e["cta-button-label"],ctaType:e["cta-button-type"],ctaAction:e["cta-button-action"],ctaButtonBgColor:e["cta-background-color"]}}getCtaTypeIcon(e){return{Phone:"fas fa-phone-alt",Email:"fas fa-envelope",SiteUrl:"fas fa-link",Form:"fas fa-file"}[e]||"fas fa-question"}getCommonButtonAttributes(e){var{ctaId:e,ctaName:t,ctaType:a,ctaAction:s,ctaButtonBgColor:o}=e;return`
      data-gjs-draggable="false"
      data-gjs-editable="false"
      data-gjs-highlightable="false"
      data-gjs-droppable="false"
      data-gjs-resizable="false"
      data-gjs-hoverable="false"
      data-gjs-type="cta-buttons"
      id="id-${e}"
      cta-button-id="${e}"
      cta-button-label="${t}"
      cta-button-type="${a}"
      cta-button-action="${s}"
      cta-background-color="${o}"
      cta-full-width="true"
    `}generatePlainButtonComponent(e){var{ctaName:t,ctaButtonBgColor:a}=e;return`
      <div class="plain-button-container" ${this.getCommonButtonAttributes(e)}>
        <button style="background-color: ${a}; border-color: ${a};" 
                class="plain-button" ${defaultConstraints}>
          <div class="cta-badge" ${defaultConstraints}>
            <i class="fa fa-minus" ${defaultConstraints}></i>
          </div>
          ${t}
        </button>
      </div>
    `}generateImageButtonComponent(e){var{ctaName:t,ctaButtonBgColor:a,ctaType:s}=e,s=this.getCtaTypeIcon(s);return`
      <div class="img-button-container" ${this.getCommonButtonAttributes(e)}>
        <div style="background-color: ${a}; border-color: ${a};" 
             class="img-button" ${defaultConstraints}>
          <i class="${s} img-button-icon" ${defaultConstraints}></i>
          <div class="cta-badge" ${defaultConstraints}>
            <i class="fa fa-minus" ${defaultConstraints}></i>
          </div>
          <span class="img-button-label" ${defaultConstraints}>${t}</span>
          <i class="fa fa-angle-right img-button-arrow" ${defaultConstraints}></i>
        </div>
      </div>
    `}handleComponentReplacement(t,a,e){t.once("component:add",()=>{var e=t.getWrapper().find("#id-"+a)[0];e&&t.select(e)}),this.manager.editorManager.selectedComponent.replaceWith(e)}handleButtonClick(e,t){var a,s;e.getWrapper().find(".cta-button-container")[0]&&(a=this.manager.editorManager.selectedComponent)&&(s=a.getAttributes(),this.isValidCtaComponent(s)?(t=t(s=this.extractCtaAttributes(a)),this.handleComponentReplacement(e,s.ctaId,t)):(a=this.currentLanguage.getTranslation("please_select_cta_button"),this.displayAlertMessage(a,"error")))}setupPlainButtonListener(t){document.getElementById("plain-button-layout").onclick=e=>{e.preventDefault(),this.handleButtonClick(t,e=>this.generatePlainButtonComponent(e))}}setupImageButtonListener(t){document.getElementById("img-button-layout").onclick=e=>{e.preventDefault(),this.handleButtonClick(t,e=>this.generateImageButtonComponent(e))}}setupBadgeClickListener(a){a.getWrapper().view.el.addEventListener("click",e=>{var t=e.target.closest(".cta-badge");t&&(e.stopPropagation(),e=t.closest(".cta-container-child, .plain-button-container, .img-button-container"))&&(e.closest(".cta-button-container"),t=e.getAttribute("id"),e=a.getWrapper().find("#"+t)[0])&&e.remove()})}activateCtaBtnStyles(e){e&&e.findType("cta-buttons")&&(document.querySelector(".cta-button-layout-container").style.display="flex")}noCtaSection(){var e=document.getElementById("cta-style");e&&(e.style.display="none",document.getElementById("call-to-actions").innerHTML="",(e=document.getElementById("no-cta-message"))&&(e.style.display="block"),document.querySelector(".cta-button-layout-container").style.display="none")}}class UndoRedoManager{constructor(e){this.editor=e,this.undoStack=[],this.redoStack=[],this.currentState=null,this.captureState(),this.bindEditorEvents()}bindEditorEvents(){this.editor.on("component:add",()=>this.captureState()),this.editor.on("component:remove",()=>this.captureState()),this.editor.on("component:update",()=>this.captureState()),this.editor.on("style:update",()=>this.captureState())}captureState(){console.log("Capturing state...");var e=this.editor.getProjectData();console.log("former state: ",this.currentState),console.log("current state: ",e),console.log("Captured project data:",this.editor.getProjectData()),this.areStatesEqual(e,this.currentState)||(this.redoStack=[],this.undoStack.push(e),50<this.undoStack.length&&this.undoStack.shift(),this.currentState=e)}undo(){var e;this.undoStack.length<=1||(e=this.undoStack.pop(),this.redoStack.push(e),e=this.undoStack[this.undoStack.length-1],this.restoreState(e))}redo(){var e;0!==this.redoStack.length&&(e=this.redoStack.pop(),this.undoStack.push(e),this.restoreState(e))}restoreState(e){this.editor.DomComponents.clear(),this.editor.loadProjectData(e),this.currentState=e}areStatesEqual(e,t){if(e===t)return!0;if(!e||!t)return!1;let o=(a,s)=>{if(a===s)return!0;if(null===a||null===s||typeof a!=typeof s)return!1;if(Array.isArray(a)&&Array.isArray(s))return a.length===s.length&&a.every((e,t)=>o(e,s[t]));if("object"!=typeof a)return a===s;{var e=Object.keys(a);let t=Object.keys(s);return e.length!==t.length?!1:e.every(e=>t.includes(e)&&o(a[e],s[e]))}};return o(e,t)}canUndo(){return 1<this.undoStack.length}canRedo(){return 0<this.redoStack.length}}class ActionListComponent{editorManager=null;dataManager=null;toolBoxManager=null;selectedObject=null;selectedId=null;pageOptions=[];constructor(e,t,a,s){this.editorManager=e,this.dataManager=t,this.currentLanguage=a,this.toolBoxManager=s,this.categoryData=[{name:"Page",label:this.currentLanguage.getTranslation("category_page"),options:[]},{name:"Service/Product Page",label:this.currentLanguage.getTranslation("category_services_or_page"),options:[]},{name:"Predefined Page",label:this.currentLanguage.getTranslation("category_predefined_page"),options:[]}],this.init()}init(){this.dataManager.getPages().then(e=>{this.toolBoxManager.checkIfNotAuthenticated(e)||(this.pageOptions=e.SDT_PageCollection.filter(e=>!e.PageIsContentPage&&!e.PageIsPredefined),this.predefinedPageOptions=e.SDT_PageCollection.filter(e=>e.PageIsPredefined&&"Home"!=e.PageName),this.servicePageOptions=this.dataManager.services.map(e=>({PageId:e.ProductServiceId,PageName:e.ProductServiceName})),this.categoryData.forEach(e=>{"Page"===e.name?e.options=this.pageOptions:"Service/Product Page"==e.name?e.options=this.servicePageOptions:"Predefined Page"==e.name&&(e.options=this.predefinedPageOptions)}),this.populateDropdownMenu())}).catch(e=>{console.error("Error fetching pages:",e)})}mapPageNamesToOptions(e){return e.map(e=>({PageName:e.Name,PageId:e.Id}))}populateDropdownMenu(){let t=document.getElementById("dropdownMenu");t.innerHTML="",this.categoryData.forEach(e=>{e=this.createCategoryElement(e);t.appendChild(e)}),this.setupDropdownHeader(),this.setupOutsideClickListener(),this.setupCategoryToggle(),this.setupItemClickListener(),this.setupSearchInputListener()}createCategoryElement(a){var e=document.createElement("details"),t=(e.classList.add("category"),e.setAttribute("data-category",a.label),document.createElement("summary")),t=(t.innerHTML=a.label+' <i class="fa fa-angle-right"></i>',e.appendChild(t),document.createElement("div"));t.classList.add("search-container"),t.innerHTML='<i class="fas fa-search search-icon"></i><input type="text" placeholder="Search" class="search-input" />',e.appendChild(t);let s=document.createElement("ul");s.classList.add("category-content"),a.options.forEach(e=>{var t=document.createElement("li");t.textContent=e.PageName,t.id=e.PageId,t.dataset.category=a.name,s.appendChild(t)});t=document.createElement("li");return t.textContent="No records found",t.classList.add("no-records-message"),t.style.display="none",s.appendChild(t),e.appendChild(s),e}setupDropdownHeader(){let t=document.getElementById("selectedOption"),a=document.getElementById("dropdownMenu");this.added||(t.removeEventListener("click",e=>{}),t.addEventListener("click",e=>{a.style.display="block"===a.style.display?"none":"block",t.querySelector("i").classList.toggle("fa-angle-up"),t.querySelector("i").classList.toggle("fa-angle-down")})),this.added=!0}setupOutsideClickListener(){let t=document.getElementById("selectedOption"),a=document.getElementById("dropdownMenu");document.addEventListener("click",e=>{t.contains(e.target)||a.contains(e.target)||(a.style.display="none",t.querySelector("i")?.classList.remove("fa-angle-up"),t.querySelector("i")?.classList.add("fa-angle-down"))})}setupCategoryToggle(){let s=document.querySelectorAll(".category");s.forEach(a=>{a.addEventListener("toggle",()=>{this.selectedObject=a.dataset.category;var e=a.querySelector(".search-container"),t=a.querySelector("summary i");a.open?(s.forEach(e=>{e!==a&&(e.open=!1,e.querySelector(".search-container").style.display="none",e.querySelector("summary i").classList.replace("fa-angle-down","fa-angle-right"))}),e.style.display="block",t.classList.replace("fa-angle-right","fa-angle-down")):(e.style.display="none",t.classList.replace("fa-angle-down","fa-angle-right"))})})}setupItemClickListener(){let l=document.getElementById("selectedOption"),n=document.getElementById("dropdownMenu");document.querySelectorAll(".category-content li").forEach(i=>{i.addEventListener("click",()=>{this.selectedObject=i.dataset.category,l.textContent=i.closest(".category").dataset.category+", "+i.textContent;var e,t,a=i.dataset.category,s=this.editorManager.getCurrentEditor(),o=s.getConfig().container+"-frame";s.getSelected()&&(s=s.getSelected().find(".tile-title")[0],t=localStorage.getItem("pageId"),e=truncateText(i.textContent.toUpperCase(),12),void 0!==t&&(this.toolBoxManager.setAttributeToSelected("tile-action-object-id",i.id),this.toolBoxManager.setAttributeToSelected("tile-action-object",a+", "+i.textContent),"Service/Product Page"==a?this.createContentPage(i.id,o):($(o).nextAll().remove(),this.editorManager.createChildEditor(this.editorManager.getPage(i.id)))),s)&&(s.components(e),t=document.getElementById("tile-title"))&&(t.textContent=e),l.innerHTML+=' <i class="fa fa-angle-down"></i>',n.style.display="none"})})}setupSearchInputListener(){document.querySelectorAll(".search-input").forEach(e=>{e.addEventListener("input",function(){let t=this.value.toLowerCase();var e=this.closest(".category").querySelectorAll(".category-content li:not(.no-records-message)");let a=!1;e.forEach(e=>{e.textContent.toLowerCase().includes(t)?(e.style.display="block",a=!0):e.style.display="none"}),this.closest(".category").querySelector(".no-records-message").style.display=a?"none":"block"})})}createContentPage(t,a){this.dataManager.createContentPage(t).then(e=>{this.toolBoxManager.checkIfNotAuthenticated(e)||this.dataManager.getPages().then(e=>{$(a).nextAll().remove(),this.editorManager.createChildEditor(this.editorManager.getPage(t))})})}}class MappingComponent{treeContainer=document.getElementById("tree-container");isLoading=!1;constructor(e,t,a,s){this.dataManager=e,this.editorManager=t,this.toolBoxManager=a,this.currentLanguage=s,this.boundCreatePage=this.handleCreatePage.bind(this)}init(){this.setupEventListeners(),this.listPagesListener(),this.homePage=this.dataManager.pages.SDT_PageCollection.find(e=>"Home"==e.PageName),this.homePage&&this.createPageTree(this.homePage.PageId,"tree-container")}listPagesListener(){document.getElementById("list-all-pages").addEventListener("click",()=>{this.handleListAllPages()})}handleListAllPages(){try{this.dataManager.getPages().then(e=>{this.toolBoxManager.checkIfNotAuthenticated(e)||(this.treeContainer=document.getElementById("tree-container"),this.clearMappings(),e=this.createPageList(e.SDT_PageCollection,!0),this.treeContainer.appendChild(e),this.hidePagesList())})}catch(e){this.displayMessage("Error loading pages","error")}finally{this.isLoading=!1}}hidePagesList(){let e=document.getElementById("list-all-pages"),t=(e.style.display="none",document.getElementById("hide-pages"));t.style.display="block",t.addEventListener("click",()=>{e.style.display="block",t.style.display="none",this.createPageTree(this.homePage.PageId,"tree-container")})}getPage(t){return this.dataManager.pages.SDT_PageCollection.find(e=>e.PageId==t)}createPageTree(e,t){e=this.getPage(e),e=JSON.parse(e.PageGJSJson).pages[0].frames[0].component.components[0].components[0].components;let a=[];e.forEach(e=>{e=e.components;e&&e.forEach(e=>{e.components.forEach(e=>{var t;e.classes.includes("template-block")&&(e=e.attributes["tile-action-object-id"],t=this.getPage(e))&&a.push({Id:e,Name:t.PageName,IsContentPage:t.PageIsContentPage})})})});e=this.createTree(a,!0);this.treeContainer=document.getElementById(t),this.clearMappings(),this.treeContainer.appendChild(e)}setupEventListeners(){let e=document.getElementById("page-submit"),t=document.getElementById("page-title");e.removeEventListener("click",this.boundCreatePage),t.addEventListener("input",()=>{e.disabled=!t.value.trim()||this.isLoading}),e.addEventListener("click",this.boundCreatePage)}async loadPageTree(){if(!this.isLoading)try{this.isLoading=!0,this.dataManager.getPagesService().then(e=>{this.toolBoxManager.checkIfNotAuthenticated(e)||(console.log(e),e=this.createTree(e.SDT_PageStructureCollection,!0),this.clearMappings(),this.treeContainer.appendChild(e))})}catch(e){this.displayMessage("Error loading pages","error")}finally{this.isLoading=!1}}async handleCreatePage(e){if(e.preventDefault(),!this.isLoading){let t=document.getElementById("page-title");var e=document.getElementById("page-submit"),a=t.value.trim();if(a)try{this.isLoading=!0,e.disabled=!0,t.disabled=!0,await this.dataManager.createNewPage(a,this.toolBoxManager.currentTheme).then(e=>{this.toolBoxManager.checkIfNotAuthenticated(e)||(t.value="",this.clearMappings(),this.dataManager.getPages().then(e=>{this.handleListAllPages(),this.toolBoxManager.actionList.init(),this.displayMessage(""+this.currentLanguage.getTranslation("page_created"),"success")}))})}catch(e){this.displayMessage(""+this.currentLanguage.getTranslation("error_creating_page"),"error")}finally{this.isLoading=!1,e.disabled=!t.value.trim(),t.disabled=!1}}}clearMappings(){for(;this.treeContainer.firstChild;)this.treeContainer.removeChild(this.treeContainer.firstChild)}createTree(e){console.log("Creating tree with data:",e);let t=a=>{let s=document.createElement("li");s.classList.add("tb-custom-list-item");var e=document.createElement("div");e.classList.add("child-div"),e.id="child-div-"+a.Id,e.style.position="relative",e.style.paddingLeft="20px";let o=document.createElement("div");o.classList.add("tb-custom-menu-item");var t=document.createElement("span");t.classList.add("tb-dropdown-toggle"),t.setAttribute("role","button"),t.setAttribute("aria-expanded","false");if(t.innerHTML=`<i class="fa fa-caret-right tree-icon"></i><span>${a.Name}</span>`,o.appendChild(t),s.appendChild(o),s.appendChild(e),a.Children){let t=document.createElement("ul");t.classList.add("tb-tree-dropdown-menu"),a.Children.forEach(e=>{e=i(e,a);t.appendChild(e)}),s.appendChild(t),s.classList.add("tb-dropdown"),s.addEventListener("click",e=>l(e,s,o))}return s.addEventListener("click",e=>{e.stopPropagation(),this.handlePageSelection(a),this.createPageTree(a.Id,"child-div-"+a.Id)}),s},i=(t,a)=>{var e=document.createElement("li");return e.classList.add("tb-dropdown-item"),e.innerHTML=`<span><i style="margin-right: 10px;" class="fa-regular fa-file tree-icon"></i>${t.Name}</span>`,e.addEventListener("click",e=>{e.stopPropagation(),this.handlePageSelection(t,!0,a)}),e},l=(e,t,a)=>{e.stopPropagation();e=t.classList.contains("active");document.querySelectorAll(".tb-dropdown.active").forEach(e=>{e.classList.remove("active"),e.querySelector(".tb-dropdown-toggle").setAttribute("aria-expanded","false"),e.querySelector(".tb-custom-menu-item").classList.remove("active-tree-item")}),e?(a.classList.remove("active-tree-item"),t.querySelector(".tb-dropdown-toggle").setAttribute("aria-expanded","false")):(t.classList.add("active"),a.classList.add("active-tree-item"),t.querySelector(".tb-dropdown-toggle").setAttribute("aria-expanded","true"))},a=document.createElement("ul");return a.classList.add("tb-custom-list"),JSON.parse(JSON.stringify(e)).sort((e,t)=>"Home"===e.Name?-1:"Home"===t.Name?1:0).forEach(e=>{e=t(e);a.appendChild(e)}),a}createPageList(e){let i=(e,t,a)=>{e.stopPropagation();let s=this.popupModal("Delete Page","Are you sure you want to delete this page?");document.body.appendChild(s),s.style.display="flex";var e=s.querySelector("#yes_delete"),o=s.querySelector("#close_popup"),i=s.querySelector(".close");e.addEventListener("click",()=>{this.dataManager.deletePage(t)?(a.remove(),this.displayMessage(""+this.currentLanguage.getTranslation("page_deleted"),"success")):this.displayMessage(""+this.currentLanguage.getTranslation("error_while_deleting_page"),"error"),s.remove()}),o.addEventListener("click",()=>{s.remove()}),i.addEventListener("click",()=>{s.remove()})},t=document.createElement("ul");return t.classList.add("tb-custom-list"),JSON.parse(JSON.stringify(e)).sort((e,t)=>"Home"===e.PageName?-1:"Home"===t.PageName?1:0).forEach(e=>{e=(t=>{let a=document.createElement("li");a.classList.add("tb-custom-list-item");var e=document.createElement("div"),s=(e.classList.add("tb-custom-menu-item"),e.classList.add("page-list-items"),document.createElement("span")),o=(s.style.textTransform="capitalize",s.classList.add("tb-dropdown-toggle"),s.setAttribute("role","button"),s.setAttribute("aria-expanded","false"),s.innerHTML=`<i class="fa-regular fa-file tree-icon"></i><span>&nbsp; ${t.PageName}</span>`,document.createElement("i"));return o.classList.add("fa-regular","fa-trash-can","tb-delete-icon"),o.setAttribute("data-id",t.Id),o.addEventListener("click",e=>i(e,t.PageId,a)),e.appendChild(s),"Home"!==t.Name&&e.appendChild(o),a.appendChild(e),a})(e);t.appendChild(e)}),t}popupModal(e,t){var a=document.createElement("div");return a.className="popup-modal",a.innerHTML=`
            <div class="popup">
              <div class="popup-header">
                <span>${e}</span>
                <button class="close">
                  <svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 21 21">
                      <path id="Icon_material-close" data-name="Icon material-close" d="M28.5,9.615,26.385,7.5,18,15.885,9.615,7.5,7.5,9.615,15.885,18,7.5,26.385,9.615,28.5,18,20.115,26.385,28.5,28.5,26.385,20.115,18Z" transform="translate(-7.5 -7.5)" fill="#6a747f" opacity="0.54"/>
                  </svg>
                </button>
              </div>
              <hr>
              <div class="popup-body" id="confirmation_modal_message">
                ${t}
              </div>
              <div class="popup-footer">
                <button id="yes_delete" class="tb-btn tb-btn-primary">
                  Delete
                </button>
                <button id="close_popup" class="tb-btn tb-btn-outline">
                  Cancel
                </button>
              </div>
            </div>
          `,a}async handlePageSelection(t,e=!1,a=null){if(!this.isLoading)try{this.isLoading=!0;var s=this.dataManager.pages.SDT_PageCollection.find(e=>e.PageId===t.Id);if(!s)throw new Error(`Page with ID ${t.Id} not found`);var o,i,l=Object.values(this.editorManager.editors),n=l[0];n&&(o=n.editor.getConfig().container+"-frame",e?a?.Id&&(i=l[1].editor.getConfig().container,document.querySelector(i+"-frame").nextElementSibling?.remove(),this.editorManager.createChildEditor(s)):($(o).nextAll().remove(),this.editorManager.createChildEditor(s)))}catch(e){this.displayMessage("Error loading page","error")}finally{this.isLoading=!1}}checkActivePage(e){return localStorage.getItem("pageId")===e}updateActivePageName(){return this.editorManager.getCurrentPageName()}displayMessage(e,t){this.toolBoxManager.ui.displayAlertMessage(e,t)}}class MediaComponent{constructor(e,t,a,s){this.dataManager=e,this.editorManager=t,this.toolBoxManager=s,this.currentLanguage=a,this.selectedFile=null,this.init()}init(){this.setupFileManager()}formatFileSize(e){return e<1024?e+" B":e<1048576?Math.round(e/1024)+" KB":e<1073741824?Math.round(e/1024/1024)+" MB":Math.round(e/1024/1024/1024)+" GB"}createModalHeader(){var e=document.createElement("div");return e.className="tb-modal-header",e.innerHTML=`
          <h2>${this.currentLanguage.getTranslation("file_upload_modal_title")}</h2>
          <span class="close">
            <svg xmlns="http://www.w3.org/2000/svg" width="21" height="21" viewBox="0 0 21 21">
              <path id="Icon_material-close" data-name="Icon material-close" d="M28.5,9.615,26.385,7.5,18,15.885,9.615,7.5,7.5,9.615,15.885,18,7.5,26.385,9.615,28.5,18,20.115,26.385,28.5,28.5,26.385,20.115,18Z" transform="translate(-7.5 -7.5)" fill="#6a747f" opacity="0.54"/>
            </svg>
          </span>
        `,e}createUploadArea(){var e=document.createElement("div");return e.className="upload-area",e.id="uploadArea",e.innerHTML=`
          <svg xmlns="http://www.w3.org/2000/svg" width="40.999" height="28.865" viewBox="0 0 40.999 28.865">
            <path id="Path_1040" data-name="Path 1040" d="M21.924,11.025a3.459,3.459,0,0,0-3.287,3.608,3.459,3.459,0,0,0,3.287,3.608,3.459,3.459,0,0,0,3.287-3.608A3.459,3.459,0,0,0,21.924,11.025ZM36.716,21.849l-11.5,14.432-8.218-9.02L8.044,39.89h41Z" transform="translate(-8.044 -11.025)" fill="#afadad"/>
          </svg>
          <div class="upload-text">
            ${this.currentLanguage.getTranslation("upload_section_text")}
          </div>
        `,this.setupDragAndDrop(e),e}setupDragAndDrop(t){function a(e){e.preventDefault(),e.stopPropagation()}["dragenter","dragover","dragleave","drop"].forEach(e=>{t.addEventListener(e,a,!1),document.body.addEventListener(e,a,!1)}),["dragenter","dragover"].forEach(e=>{t.addEventListener(e,()=>{t.classList.add("drag-over")})}),["dragleave","drop"].forEach(e=>{t.addEventListener(e,()=>{t.classList.remove("drag-over")})}),t.addEventListener("drop",e=>{e=Array.from(e.dataTransfer.files);this.handleDroppedFiles(e)})}handleDroppedFiles(e){var t=e.filter(e=>["image/jpeg","image/jpg","image/png"].includes(e.type));t.length!==e.length&&this.toolBoxManager.ui.displayAlertMessage(""+this.currentLanguage.getTranslation("invalid_file_type_message"),"error");let a=document.querySelector("#fileList");a&&t.forEach(e=>{var t=Date.now()+"-"+e.name;this.processUploadedFile(e,t,a)})}createModalActions(){var e=document.createElement("div");return e.className="modal-actions",e.innerHTML=`
          <button class="tb-btn tb-btn-outline" id="cancelBtn">${this.currentLanguage.getTranslation("cancel_btn")}</button>
          <button class="tb-btn tb-btn-primary" id="saveBtn">${this.currentLanguage.getTranslation("save_btn")}</button>
        `,e}openFileUploadModal(){var e=document.createElement("div"),t=(e.className="tb-modal",document.createElement("div")),a=(t.className="tb-modal-content",this.createExistingFileListHTML()),s=(t.appendChild(this.createModalHeader()),t.appendChild(this.createUploadArea()),document.createElement("div"));return s.className="file-list",s.id="fileList",s.innerHTML=a,t.appendChild(s),t.appendChild(this.createModalActions()),e.appendChild(t),e}createExistingFileListHTML(){return this.dataManager.media.map(e=>`
                <div class="file-item valid" 
                    data-MediaId="${e.MediaId}" 
                    data-MediaUrl="${e.MediaUrl}" 
                    data-MediaName="${e.MediaName}">
                  <img src="${e.MediaUrl}" alt="${e.MediaName}" class="preview-image">
                  <div class="file-info">
                    <div class="file-name">${e.MediaName.split("-").slice(1).join("-")}</div>
                    <div class="file-size">${this.formatFileSize(e.MediaSize)}</div>
                  </div>
                  <span class="status-icon" style="color: green;"></span>
                  <span title="Delete file" class="delete-media fa-regular fa-trash-can" data-mediaid="${e.MediaId}"></span>
                </div>
              `).join("")}setupFileManager(){var e=document.getElementById("image-bg");let t=this.createFileInputField(),a=this.openFileUploadModal(),s=[];e.addEventListener("click",e=>{e.preventDefault(),this.handleModalOpen(a,t,s)})}createFileInputField(){var e=document.createElement("input");return e.type="file",e.multiple=!0,e.accept="image/jpeg, image/jpg, image/png",e.id="fileInput",e.style.display="none",e}handleModalOpen(e,t,a){this.editorManager.selectedComponent?($(".delete-media").on("click",e=>{e.stopPropagation();e=e.target.dataset.mediaid;e&&this.deleteMedia(e)}),document.body.appendChild(e),document.body.appendChild(t),this.setupModalEventListeners(e,t,a)):this.toolBoxManager.ui.displayAlertMessage(""+this.currentLanguage.getTranslation("no_tile_selected_error_message"),"error")}setupModalEventListeners(e,t,a){this.addFileItemClickListeners(e),this.addDeleteMediaListeners(e),this.setupModalInteractions(e,t,a);e=document.createElement("style");e.textContent=`
            .upload-area {
                position: relative;
                border: 2px dashed #ccc;
                border-radius: 8px;
                padding: 40px 20px;
                text-align: center;
                transition: all 0.3s ease;
                cursor: pointer;
            }
            
            .upload-area.drag-over {
                background-color: rgba(33, 150, 243, 0.05);
                border-color: #222f54;
            }
            
            .upload-text {
                margin-top: 15px;
                color: #666;
            }            
        `,document.head.appendChild(e)}addFileItemClickListeners(e){e.querySelectorAll(".file-item").forEach(e=>{e.addEventListener("click",()=>{this.mediaFileClicked(e)})})}addDeleteMediaListeners(e){$(e).find(".delete-media").on("click",e=>{var t,e=e.target.dataset.mediaid;e&&(t=this.popupModal(""+this.currentLanguage.getTranslation("delete_media_modal_title"),""+this.currentLanguage.getTranslation("delete_media_modal_message")),document.body.appendChild(t),t.style.display="flex",this.setupPopupButtonListeners(t,e))})}setupPopupButtonListeners(e,t){e.querySelector("#yes_delete").onclick=()=>{this.deleteMedia(t),e.style.display="none"},e.querySelector("#close_popup").onclick=()=>{e.style.display="none"},e.querySelector(".close").addEventListener("click",()=>{e.remove()})}setupModalInteractions(e,t,a){var s=e.querySelector("#uploadArea");let o=e.querySelector("#fileList");var i=e.querySelector(".close"),l=e.querySelector("#cancelBtn"),n=e.querySelector("#saveBtn");s.onclick=()=>t.click(),t.onchange=e=>{this.handleFileInputChange(e,a,o)},i.onclick=l.onclick=()=>{this.closeModal(e,t)},n.onclick=()=>{this.saveSelectedFile(e,t)},e.style.display="flex"}handleFileInputChange(e,t,a){e=Array.from(e.target.files).filter(e=>["image/jpeg","image/jpg","image/png"].includes(e.type));t.push(...e),e.forEach(e=>{var t=Date.now()+"-"+e.name;this.processUploadedFile(e,t,a)})}async processUploadedFile(e,t,s){try{let a=await new ImageCropper(532,250).processImage(e);var o=new File([a],e.name,{type:e.type}),i=await new Promise(t=>{var e=new FileReader;e.onload=e=>t(e.target.result),e.readAsDataURL(a)}),l=t.replace(/'/g,""),n=await this.dataManager.uploadFile(i,l,o.size,o.type);this.toolBoxManager.checkIfNotAuthenticated(n)||n.BC_Trn_Media.MediaId&&(this.dataManager.media.push(n.BC_Trn_Media),this.displayMediaFileProgress(s,n.BC_Trn_Media))}catch(e){console.error("Failed to process image:",e)}}displayMediaFileProgress(e,t){let a=document.createElement("div");a.className="file-item "+(this.validateFile(t)?"valid":"invalid"),a.setAttribute("data-mediaid",t.MediaId);var s=this.validateFile(t);a.innerHTML=`
          <img src="${t.MediaUrl}" alt="File thumbnail" class="preview-image">
          <div class="file-info">
            <div class="file-info-details">
              <div>
                <div class="file-name">${t.MediaName.split("-").slice(1).join("-")}</div>
                <div class="file-size">${this.formatFileSize(t.MediaSize)}</div>
              </div>
              <div class="progress-text">0%</div>
            </div>
            <div class="progress-bar">
                <div class="progress" style="width: 0%"></div>
            </div>
          </div>
          <span class="status-icon" style="color: ${s?"green":"red"}">
            ${s?"":"⚠"}
          </span>
        `,e.insertBefore(a,e.firstChild);let o=0,i=a.querySelector(".progress"),l=a.querySelector(".progress-text"),n=setInterval(()=>{o+=10,i.style.width=o+"%",l.textContent=o+"%",100<=o&&(clearInterval(n),e.removeChild(a),this.displayMediaFile(e,t))},300)}displayMediaFile(e,t){let a=document.createElement("div");a.className="file-item "+(this.validateFile(t)?"valid":"invalid"),a.setAttribute("data-mediaid",t.MediaId);var s=this.validateFile(t);a.innerHTML=`
          <img src="${t.MediaUrl}" alt="File thumbnail" class="preview-image">
          <div class="file-info">
              <div class="file-name">${t.MediaName.split("-").slice(1).join("-")}</div>
              <div class="file-size">${this.formatFileSize(t.MediaSize)}</div>
          </div>
          <span class="status-icon" style="color: ${s?"green":"red"}">
            ${s?"":"⚠"}
          </span>
          <span class="delete-media fa-regular fa-trash-can" data-mediaid="${t.MediaId}"></span>
        `,a.onclick=()=>{a.classList.contains("invalid")||this.mediaFileClicked(a)},$(a).find(".delete-media").on("click",e=>{var t,e=e.target.dataset.mediaid;e&&(t=this.popupModal(""+this.currentLanguage.getTranslation("delete_media_modal_title"),""+this.currentLanguage.getTranslation("delete_media_modal_message")),document.body.appendChild(t),t.style.display="flex",this.setupPopupButtonListeners(t,e))}),e.insertBefore(a,e.firstChild)}validateFile(e){var t=e.MediaSize<=2097152,e=["image/jpeg","image/jpg","image/png"].includes(e.MediaType);return t&&e}closeModal(e,t){e.style.display="none",document.body.removeChild(e),document.body.removeChild(t)}saveSelectedFile(e,t){var a,s;this.selectedFile&&(a=this.editorManager.selectedComponent,this.selectedFile?.MediaUrl?(s=encodeURI(this.selectedFile.MediaUrl),console.log("safeMediaUrl: ",s),a.addStyle({"background-image":`url(${s})`,"background-size":"auto","background-position":"center","background-blend-mode":"overlay"})):console.error("MediaUrl is missing or undefined",this.selectedFile),this.toolBoxManager.setAttributeToSelected("tile-bg-image-url",this.selectedFile.MediaUrl),this.toolBoxManager.checkTileBgImage()),this.closeModal(e,t)}mediaFileClicked(t){var e;t.classList.contains("invalid")||(document.querySelector(".modal-actions").style.display="flex",document.querySelectorAll(".file-item").forEach(e=>{e.classList.remove("selected");var t=e.querySelector(".status-icon");t&&(t.innerHTML=e.classList.contains("invalid")?"⚠":"")}),t.classList.add("selected"),(e=t.querySelector(".status-icon")).innerHTML=`
          <svg xmlns="http://www.w3.org/2000/svg" width="18" height="13.423" viewBox="0 0 18 13.423">
            <path id="Icon_awesome-check" d="M6.114,17.736l-5.85-5.85a.9.9,0,0,1,0-1.273L1.536,9.341a.9.9,0,0,1,1.273,0L6.75,13.282l8.441-8.441a.9.9,0,0,1,1.273,0l1.273,1.273a.9.9,0,0,1,0,1.273L7.386,17.736A.9.9,0,0,1,6.114,17.736Z" transform="translate(0 -4.577)" fill="#3a9341"/>
          </svg>
        `,e.style.color="green",this.selectedFile=this.dataManager.media.find(e=>e.MediaId==t.dataset.mediaid))}deleteMedia(t){this.dataManager.deleteMedia(t).then(e=>{this.toolBoxManager.checkIfNotAuthenticated(e)||("success"===e.result?((e=document.querySelector(`[data-mediaid="${t}"]`))&&e.remove(),e=document.querySelector(".modal-actions"),this.dataManager.media&&0!==this.dataManager.media.length||(e.style.display="none"),this.toolBoxManager.ui.displayAlertMessage(""+this.currentLanguage.getTranslation("media_deleted_successfully"),"success"),this.checkAndHideModalActions()):this.toolBoxManager.ui.displayAlertMessage(""+this.currentLanguage.getTranslation("failed_to_delete_media"),"error"))}).catch(e=>{console.error("Error deleting media file:",e),this.toolBoxManager.ui.displayAlertMessage(""+this.currentLanguage.getTranslation("error_during_deleting_media"),"error")})}popupModal(e,t){var a=document.createElement("div");return a.className="popup-modal",a.innerHTML=`
          <div class="popup">
            <div class="popup-header">
              <span>${e}</span>
              <button class="close">
                <svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 21 21">
                  <path id="Icon_material-close" data-name="Icon material-close" d="M28.5,9.615,26.385,7.5,18,15.885,9.615,7.5,7.5,9.615,15.885,18,7.5,26.385,9.615,28.5,18,20.115,26.385,28.5,28.5,26.385,20.115,18Z" transform="translate(-7.5 -7.5)" fill="#6a747f" opacity="0.54"/>
                </svg>
              </button>
            </div>
            <hr>
            <div class="popup-body" id="confirmation_modal_message">
              ${t}
            </div>
            <div class="popup-footer">
              <button id="yes_delete" class="tb-btn tb-btn-primary">
                ${this.currentLanguage.getTranslation("delete_btn")}
              </button>
              <button id="close_popup" class="tb-btn tb-btn-outline">
                ${this.currentLanguage.getTranslation("cancel_btn")}
              </button>
            </div>
          </div>
        `,a}checkAndHideModalActions(){var e=document.querySelector("#fileList"),t=document.querySelector(".modal-actions");e&&0===e.children.length?t.style.display="none":t.style.display="flex"}}class ImageCropper{constructor(e=532,t=250){this.targetWidth=e,this.targetHeight=t,this.canvas=document.createElement("canvas"),this.ctx=this.canvas.getContext("2d")}async processImage(t){try{let e;if("string"==typeof t)e=await this.loadImageFromURL(t);else{if(!(t instanceof File))throw new Error("Source must be either a File or URL string");if(!t.type.startsWith("image/"))throw new Error("File must be an image");var a=await this.readFileAsDataURL(t);e=await this.loadImage(a)}return e.width<=this.targetWidth&&e.height<=this.targetHeight?t instanceof File?t:this.dataURLToBlob(e.src):this.resizeImage(e,t instanceof File?t.type:"image/jpeg")}catch(e){throw new Error("Failed to process image: "+e.message)}}loadImageFromURL(s){return new Promise((e,t)=>{let a=new Image;a.crossOrigin="anonymous",a.onload=()=>e(a),a.onerror=()=>t(new Error("Failed to load image from URL")),a.src=s})}readFileAsDataURL(s){return new Promise((t,a)=>{var e=new FileReader;e.onload=e=>t(e.target.result),e.onerror=e=>a(e),e.readAsDataURL(s)})}loadImage(s){return new Promise((e,t)=>{let a=new Image;a.onload=()=>e(a),a.onerror=()=>t(new Error("Failed to load image")),a.src=s})}resizeImage(e,a){return this.canvas.width=this.targetWidth,this.canvas.height=this.targetHeight,this.ctx.clearRect(0,0,this.canvas.width,this.canvas.height),this.ctx.drawImage(e,0,0,this.targetWidth,this.targetHeight),new Promise(t=>{this.canvas.toBlob(e=>t(e),a)})}dataURLToBlob(e){var t=atob(e.split(",")[1]),e=e.split(",")[0].split(":")[1].split(";")[0],a=new ArrayBuffer(t.length),s=new Uint8Array(a);for(let e=0;e<t.length;e++)s[e]=t.charCodeAt(e);return new Blob([a],{type:e})}}let iconsData=[{name:"Broom",svg:`
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 32.86 26.791">
            <path id="Path_942" data-name="Path 942" d="M27.756,3.986a1.217,1.217,0,0,0-1.2,1.234v9.736a2.433,2.433,0,0,0-2.434,2.434v1.217H27.57a1.217,1.217,0,0,0,.4,0h3.459V17.39a2.433,2.433,0,0,0-2.434-2.434V5.22a1.217,1.217,0,0,0-1.236-1.234ZM11.953,4a4.049,4.049,0,0,0-3.6,2.579,3.784,3.784,0,0,0-.663-.145,4.278,4.278,0,0,0-4.26,4.26,4.152,4.152,0,0,0,.062.609H3.434a1.217,1.217,0,1,0,0,2.434H3.6l.825,6.19-3,2.629a1.218,1.218,0,0,0,1.6,1.835l1.79-1.566-.385-2.9,6.729-5.89a1.217,1.217,0,0,1,1.6,1.835L4.808,22.826l.777,5.838A2.437,2.437,0,0,0,8,30.777h7.906a2.434,2.434,0,0,0,2.413-2.113l1.992-14.925h.162a1.217,1.217,0,1,0,0-2.434h-.062a4.152,4.152,0,0,0,.062-.609,4.278,4.278,0,0,0-4.26-4.26,3.784,3.784,0,0,0-.663.145A4.049,4.049,0,0,0,11.953,4Zm0,2.434a1.8,1.8,0,0,1,1.8,1.626,1.217,1.217,0,0,0,1.709.975A1.817,1.817,0,0,1,18.038,10.7a1.858,1.858,0,0,1-.107.609H5.975a1.859,1.859,0,0,1-.107-.609A1.817,1.817,0,0,1,8.445,9.037a1.217,1.217,0,0,0,1.709-.975A1.8,1.8,0,0,1,11.953,6.437Zm12.17,14.6a16.837,16.837,0,0,0-2.434,8.519,1.217,1.217,0,0,0,1.217,1.217h9.736a1.216,1.216,0,0,0,1.21-1.348,16.907,16.907,0,0,0-2.427-8.388h-7.3Z" transform="translate(-1 -3.986)" fill="#7c8791"/>
          </svg>
         `},{name:"Car",svg:`
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 33.969 27.499">
            <path id="Path_940" data-name="Path 940" d="M33.625,15.208l-2.689-7.7A5.236,5.236,0,0,0,26,4H11.967A5.233,5.233,0,0,0,7.034,7.507l-2.689,7.7A5.247,5.247,0,0,0,2,19.588V28.88a2.613,2.613,0,1,0,5.226,0V27.228s6.9.342,11.758.342,11.758-.342,11.758-.342V28.88a2.613,2.613,0,1,0,5.226,0V19.588A5.248,5.248,0,0,0,33.625,15.208ZM8,12.659,9.5,8.372a2.614,2.614,0,0,1,2.467-1.753H26a2.614,2.614,0,0,1,2.467,1.753l1.5,4.287a.936.936,0,0,1-1.03,1.24,62.318,62.318,0,0,0-9.952-.733,62.318,62.318,0,0,0-9.952.733A.936.936,0,0,1,8,12.659Zm-.124,9.673a1.964,1.964,0,1,1,1.96-1.964A1.963,1.963,0,0,1,7.879,22.332ZM22.9,21.023H15.065a1.309,1.309,0,0,1,0-2.619H22.9a1.309,1.309,0,0,1,0,2.619Zm7.186,1.309a1.964,1.964,0,1,1,1.96-1.964A1.963,1.963,0,0,1,30.09,22.332Z" transform="translate(-2 -4)" fill="#7c8791"/>
          </svg>
  
         `},{name:"Heart",svg:`
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 31.83 28.479">
            <path id="Path_941" data-name="Path 941" d="M24.689,3.007a9.543,9.543,0,0,0-6.774,3.3,9.543,9.543,0,0,0-6.774-3.3A8.865,8.865,0,0,0,3.768,6.654C-2.379,14.723,9.259,24.162,12,26.7c1.638,1.516,3.659,3.317,4.865,4.384a1.583,1.583,0,0,0,2.106,0c1.206-1.067,3.228-2.868,4.865-4.384,2.738-2.534,14.377-11.973,8.228-20.041A8.86,8.86,0,0,0,24.689,3.007Z" transform="translate(-2 -3.001)" fill="#7c8791"/>
          </svg>
         `},{name:"Home",svg:`
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 28.752 28.752">
            <path id="Path_937" data-name="Path 937" d="M17.376,2a1.2,1.2,0,0,0-.838.342L3.47,13.03l-.044.035-.044.037v0A1.2,1.2,0,0,0,4.2,15.178H5.4V28.356a2.4,2.4,0,0,0,2.4,2.4H26.96a2.4,2.4,0,0,0,2.4-2.4V15.178h1.2a1.2,1.2,0,0,0,.817-2.075l-.019-.014q-.039-.036-.082-.068l-1.914-1.565V6.792a1.2,1.2,0,0,0-1.2-1.2h-1.2a1.2,1.2,0,0,0-1.2,1.2V8.516l-7.574-6.2A1.2,1.2,0,0,0,17.376,2ZM20.97,17.574h4.792v9.584H20.97Z" transform="translate(-3 -2)" fill="#7c8791"/>
          </svg>
         `},{name:"Health",svg:`
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 26.214 27.498">
            <path id="Path_938" data-name="Path 938" d="M26.3,4.75H20.208a4.433,4.433,0,0,0-8.2,0H5.913A2.834,2.834,0,0,0,3,7.5V26.748A2.834,2.834,0,0,0,5.913,29.5H26.3a2.834,2.834,0,0,0,2.913-2.75V7.5A2.834,2.834,0,0,0,26.3,4.75Zm-10.194,0a1.418,1.418,0,0,1,1.456,1.375,1.459,1.459,0,0,1-2.913,0A1.418,1.418,0,0,1,16.107,4.75Zm4.369,15.124H17.564v2.75A1.418,1.418,0,0,1,16.107,24h0a1.418,1.418,0,0,1-1.456-1.375v-2.75H11.738A1.418,1.418,0,0,1,10.282,18.5h0a1.418,1.418,0,0,1,1.456-1.375h2.913v-2.75A1.418,1.418,0,0,1,16.107,13h0a1.418,1.418,0,0,1,1.456,1.375v2.75h2.913A1.418,1.418,0,0,1,21.933,18.5h0A1.418,1.418,0,0,1,20.476,19.874Z" transform="translate(-3 -2)" fill="#7c8791"/>
          </svg>
         `},{name:"Foods",svg:`
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 32.813 27.572">
            <path id="Path_939" data-name="Path 939" d="M22.959,3.986a.656.656,0,0,0-.646.665V5.964q0,.019,0,.038A5.905,5.905,0,0,0,17.1,11.214H15.75a.656.656,0,0,0-.656.656v4.594H11.933a7.534,7.534,0,0,0,.445-1.969h.091a.656.656,0,1,0,0-1.313H11.9a6.673,6.673,0,0,0,.481-1.969h.091a.656.656,0,1,0,0-1.313H11.9a6.673,6.673,0,0,0,.481-1.969h.091a.656.656,0,1,0,0-1.313H2.625a.656.656,0,1,0,0,1.313h.091A6.674,6.674,0,0,0,3.2,9.9H2.625a.656.656,0,1,0,0,1.313h.091A6.674,6.674,0,0,0,3.2,13.183H2.625a.656.656,0,1,0,0,1.313h.091a7.535,7.535,0,0,0,.445,1.969H.656A.656.656,0,0,0,0,17.12v6.563a3.271,3.271,0,0,0,5.906,1.948,3.251,3.251,0,0,0,5.25,0,3.251,3.251,0,0,0,5.25,0,3.251,3.251,0,0,0,5.25,0,3.251,3.251,0,0,0,5.25,0,3.271,3.271,0,0,0,5.906-1.948V17.12a.656.656,0,0,0-.656-.656H30.844V11.87a.656.656,0,0,0-.656-.656H28.837A5.905,5.905,0,0,0,23.624,6q0-.019,0-.038V4.652a.656.656,0,0,0-.666-.665ZM4.029,7.933h7.037A5.272,5.272,0,0,1,10.473,9.9H4.621A5.272,5.272,0,0,1,4.029,7.933Zm0,3.281h7.037a5.272,5.272,0,0,1-.592,1.969H4.621A5.272,5.272,0,0,1,4.029,11.214Zm12.378,1.313H29.531v3.938H16.406ZM4.029,14.5h7.037a5.272,5.272,0,0,1-.592,1.969H4.621A5.272,5.272,0,0,1,4.029,14.5Zm-1.4,13.729V30.9a.656.656,0,0,0,1.313,0V28.23a4.352,4.352,0,0,1-.656.046A3.64,3.64,0,0,1,2.625,28.224Zm27.562,0a3.64,3.64,0,0,1-.656.053,4.352,4.352,0,0,1-.656-.046V30.9a.656.656,0,0,0,1.313,0Z" transform="translate(0 -3.986)" fill="#7c8791"/>
          </svg>
         `},{name:"Laundry",svg:`
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 30.411 28.722">
            <path id="Path_943" data-name="Path 943" d="M13.236,4a2.053,2.053,0,0,0,0,4.1h2.323l-.32.333-.034.033-2.493,2.58a8.153,8.153,0,0,1-1.539-1.907.674.674,0,0,0-1.158,0c-.021.036-1.94,3.543-5.723,3.73l-.98-6.247a.669.669,0,0,0-.638-.584.652.652,0,0,0-.517.238.7.7,0,0,0-.149.564l1.07,6.83s0,.005,0,.008L5.973,32.147s0,.006,0,.009a.7.7,0,0,0,.071.21l.012.02a.679.679,0,0,0,.137.17l.009.007a.657.657,0,0,0,.186.114l.008,0a.641.641,0,0,0,.227.041H27.778A.641.641,0,0,0,28,32.68l.019-.007a.656.656,0,0,0,.186-.114h0l0-.005a.679.679,0,0,0,.136-.168l.009-.017a.7.7,0,0,0,.075-.22l2.9-18.464s0-.005,0-.008l1.07-6.83a.7.7,0,0,0-.222-.662.644.644,0,0,0-.668-.112.681.681,0,0,0-.413.555l-.98,6.252a6.184,6.184,0,0,1-2.519-.672A4.91,4.91,0,0,0,26.423,7.5L24.262,5.265a4.348,4.348,0,0,0-3.184-1.256L13.238,4Zm0,1.368,7.84.009a3.031,3.031,0,0,1,2.251.855l2.161,2.236a3.493,3.493,0,0,1,0,4.832l-6.758,6.9,0,0a.636.636,0,0,1-.935,0,.685.685,0,0,1-.154-.711l2.573-2.662.009-.009q.024-.024.045-.049a.7.7,0,0,0-.016-.908.645.645,0,0,0-.874-.091l-.005.005-.026.021q-.021.018-.041.037l-.008.008-.01.009-.022.023-2.4,2.383-.009.009a2,2,0,0,0-.292.4l-1.508,1.56a.636.636,0,0,1-.935,0,.69.69,0,0,1,0-.967l4.228-4.374a.682.682,0,0,0,.12-.162h0a.7.7,0,0,0-.094-.793.646.646,0,0,0-.756-.16l-.005,0a.659.659,0,0,0-.161.108l-.037.037L13.191,18.29l-.8.825a.636.636,0,0,1-.935,0,.69.69,0,0,1,0-.967l.567-.586,4.185-4.33a.682.682,0,0,0,.12-.163.7.7,0,0,0-.166-.863.644.644,0,0,0-.85.02l-.005.005-.034.033-4.185,4.329a.636.636,0,0,1-.935,0,.688.688,0,0,1,0-.966L16.14,9.436,17.623,7.9a.7.7,0,0,0,.143-.745.661.661,0,0,0-.61-.422H13.236a.684.684,0,0,1,0-1.368Z" transform="translate(-1.998 -4)" fill="#7c8791"/>
          </svg>
         `}],defaultTileAttrs=`
    tile-text="Tile"
    tile-text-color="#000000"
    tile-text-align="left"
  
    tile-icon=""
    tile-icon-color="#000000"
    tile-icon-align="left"
  
    tile-bg-image=""
    tile-bg-image-opacity=100
  
    tile-action-object="Page"
    tile-action-object-id=""
  `,defaultConstraints=`
      data-gjs-draggable="false"
      data-gjs-selectable="false"
      data-gjs-editable="false"
      data-gjs-highlightable="false"
      data-gjs-droppable="false"
      data-gjs-resizable="false"
      data-gjs-hoverable="false"
  `,globalVar=null;function hexToRgb(e){e=e.replace(/^#/,"");let t,a,s;return s=3===e.length?(t=parseInt(e[0]+e[0],16),a=parseInt(e[1]+e[1],16),parseInt(e[2]+e[2],16)):(t=parseInt(e.substring(0,2),16),a=parseInt(e.substring(2,4),16),parseInt(e.substring(4,6),16)),`${t}, ${a}, `+s}function truncateText(e,t){return e.length>t?e.slice(0,t):e}