// Content from classes/Clock.js
class Clock {
    constructor(pageId) {
      this.pageId = pageId;
      this.updateTime();
    }
  
    updateTime() {
      const now = new Date();
      let hours = now.getHours();
      const minutes = now.getMinutes().toString().padStart(2, "0");
      const ampm = hours >= 12 ? "PM" : "AM";
      hours = hours % 12;
      hours = hours ? hours : 12; // Adjust hours for 12-hour format
      const timeString = `${hours}:${minutes} ${ampm}`;
      document.getElementById(this.pageId).textContent = timeString;
    }
  }


// Content from classes/Locale.js
class Locale {
  constructor(language) {
    this.currentLanguage = language;
    this.defaultLanguage = "english";
    this.translations = {};
  }

  async init() {
    await this.loadTranslations();
    return this; // Allow chaining
  }

  async loadTranslations() {
    try {
      const languages = ["english", "dutch"];
      for (const lang of languages) {
        const response = await fetch(
          `${window.location.origin}/Resources/UCGrapes1/src/i18n/${lang}.json`
        );
        if (!response.ok)
          throw new Error(`Failed to load ${lang} translations`);
        const data = await response.json();
        this.translations[lang] = data;
      }
    } catch (error) {
      console.error("Error loading translations:", error);
      throw new Error(`Failed to load translations: ${error.message}`);
    }
  }

  async setLanguage(language) {
    // Wait for translations to be loaded
    if (Object.keys(this.translations).length === 0) {
      await this.loadTranslations();
    }

    const elementsToTranslate = [
      "navbar_title",
      "navbar_tree_label",
      "navbar_publish_label",
      "sidebar_tabs_pages_label",
      "sidebar_tabs_templates_label",
      "sidebar_select_action_label",
      "new_page_submit_label",
      "template_added_success_message",
      "theme_applied_success_message",
      "page_loaded_success_message",
      "no_tile_selected_error_message",
      "error_loading_data_message",
      "failed_to_save_current_page_message",
      "tile_has_bg_image_error_message",
      "error_applying_theme_message",
      "no_icon_selected_error_message",
      "error_save_message",
      "accept_popup",
      "close_popup",
      "sidebar_mapping_title",
      "alert_type_success",
      "alert_type_error",
      "cancel_btn",
      "save_btn",
      "publish_confirm_title",
      "publish_confirm_message",
      "nofity_residents_on_publish",
      "publish_confirm_button",
      "publish_cancel_button",
      "enter_title_place_holder",
    ];

    elementsToTranslate.forEach((elementId) => {
      const element = document.getElementById(elementId);
      if (element) {
        element.innerText = this.getTranslation(elementId);
      } else {
        console.warn(`Element with id '${elementId}' not found`);
      }
    });

  }

  translateTilesTitles(editor){
    
    const tileTitlesToTranslate = [
      "tile-reception", "tile-calendar", "tile-mailbox", "tile-location",
      "tile-my-care", "tile-my-living", "tile-my-services"
    ]

    tileTitlesToTranslate.forEach(elementClass => {
      const components = editor.DomComponents.getWrapper().find(`.${elementClass}`);
      if (components.length) {
        const newHTML = `<span data-gjs-type="text" class="tile-title ${elementClass}">${this.getTranslation(elementClass)}</span>`
        components[0].replaceWith(newHTML);
      } 
    })
  }

  getTranslation(key) {
    if (!this.translations || Object.keys(this.translations).length === 0) {
      console.warn("Translations not yet loaded");
      return key;
    }

    const translation =
      this.translations[this.currentLanguage]?.[key] ||
      this.translations[this.defaultLanguage]?.[key];

    if (!translation) {
      console.warn(`Translation missing for key '${key}'`);
      return key;
    }
    return translation;
  }

  translateUCStrings() {
    document.getElementById("tile-title").placeholder = this.getTranslation(
      "enter_title_place_holder"
    );

    const options = [
      {
        value: "Services",
        label: "icon_category_services",
      },
      {
        value: "General",
        label: "icon_category_general",
        selected: true,
      },
      {
        value: "Health",
        label: "icon_category_health",
      },
      {
        value: "Living",
        label: "icon_category_living",
      },
    ];

    const select = document.querySelector(".tb-custom-category-selection");
    const button = select.querySelector(".category-select-button");
    const selectedValue = button.querySelector(".selected-category-value");

    // Toggle dropdown visibility
    button.addEventListener("click", (e) => {
      e.preventDefault();
      const isOpen = optionsList.classList.contains("show");
      optionsList.classList.toggle("show");
      button.classList.toggle("open");
      button.setAttribute("aria-expanded", !isOpen);
    });

    const optionsList = document.createElement("div");
    optionsList.classList.add("category-options-list");
    optionsList.setAttribute("role", "listbox");
    optionsList.innerHTML = "";

    // Populate themes into the dropdown
    options.forEach((opt, index) => {
      const option = document.createElement("div");
      option.classList.add("category-option");
      option.setAttribute("role", "option");
      option.setAttribute("data-value", opt.value);
      option.textContent = this.getTranslation(opt.label);
      if (opt.selected) {
        selectedValue.textContent = this.getTranslation(opt.label);
        option.classList.add("selected");
      }

      option.addEventListener("click", (e) => {
        selectedValue.textContent = this.getTranslation(opt.label);

        // Mark as selected
        const allOptions = optionsList.querySelectorAll(".category-option");
        allOptions.forEach((opt) => opt.classList.remove("selected"));
        option.classList.add("selected");

        // Close the dropdown
        optionsList.classList.remove("show");
        button.classList.remove("open");
        button.setAttribute("aria-expanded", "false");
      });

      // Append option to the options list
      optionsList.appendChild(option);
    });

    select.appendChild(optionsList);
  }
}


// Content from classes/DataManager.js
const environment = "/Comforta_version2DevelopmentNETPostgreSQL";
const baseURL = window.location.origin + (window.location.origin.startsWith("http://localhost") ? environment : "");

class DataManager {
  constructor(services = [], media = []) {
    this.services = services;
    this.media = media;
    this.pages = [];
    this.selectedTheme = null;    
  }

  // Helper method to handle API calls
  async fetchAPI(endpoint, options = {}) {
    const defaultOptions = {
      headers: {
        'Content-Type': 'application/json',
      },
    };

    try {
      const response = await fetch(`${baseURL}${endpoint}`, {
        ...defaultOptions,
        ...options,
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      return await response.json();
    } catch (error) {
      console.error(`API Error (${endpoint}):`, error);
      throw error;
    }
  }

  // Pages API methods
  async getPages() {
    this.pages = await this.fetchAPI('/api/toolbox/pages/list');
    return this.pages;
  }

  async getSinglePage(pageId) {
    return await this.fetchAPI(`/api/toolbox/singlepage?Pageid=${pageId}`);
  }

  async deletePage(pageId) {
    return await this.fetchAPI(`/api/toolbox/deletepage?Pageid=${pageId}`);
  }

  async getPagesService() {
    return await this.fetchAPI('/api/toolbox/pages/tree');
  }

  async createNewPage(pageName, theme) {
    let pageJsonContent = generateNewPage(theme)
    return await this.fetchAPI('/api/toolbox/create-page', {
      method: 'POST',
      body: JSON.stringify({ PageName: pageName, PageJsonContent: JSON.stringify(pageJsonContent) }),
    });
  }

  async updatePage(data) {
    return await this.fetchAPI('/api/toolbox/update-page', {
      method: 'POST',
      body: JSON.stringify(data),
    });
  }

  async updatePagesBatch(payload) {
    return await this.fetchAPI('/api/toolbox/update-pages-batch', {
      method: 'POST',
      body: JSON.stringify(payload),
    });
  }

  async addPageChild(childPageId, currentPageId) {
    return await this.fetchAPI('/api/toolbox/add-page-children', {
      method: 'POST',
      body: JSON.stringify({
        ParentPageId: currentPageId,
        ChildPageId: childPageId,
      }),
    });
  }

  async createContentPage(pageId) {
    console.log('createContentPage', pageId);
    return await this.fetchAPI('/api/toolbox/create-content-page', {
      method: 'POST',
      body: JSON.stringify({ PageId: pageId }),
    });
  }

  // Theme API methods
  async getLocationTheme() {
    return await this.fetchAPI('/api/toolbox/location-theme');
  }

  async updateLocationTheme() {
    if (!this.selectedTheme?.id) {
      throw new Error('No theme selected');
    }

    return await this.fetchAPI('/api/toolbox/update-location-theme', {
      method: 'POST',
      body: JSON.stringify({ ThemeId: this.selectedTheme.id }),
    });
  }

  // Media API methods
  async getMediaFiles() {
    return await this.fetchAPI('/api/media/');
  }

  async deleteMedia(mediaId) {
    return await this.fetchAPI(`/api/media/delete?MediaId=${mediaId}`);
  }

  async uploadFile(fileData, fileName, fileSize, fileType) {
    if (!fileData) {
      throw new Error('Please select a file!');
    }

    return await this.fetchAPI('/api/media/upload', {
      method: 'POST',
      headers: {
        'Content-Type': 'multipart/form-data',
      },
      body: JSON.stringify({
        MediaName: fileName,
        MediaImageData: fileData,
        MediaSize: fileSize,
        MediaType: fileType,
      }),
    });
  }

  // Content API methods
  async getContentPageData(productServiceId) {
    return await this.fetchAPI(`/api/productservice?Productserviceid=${productServiceId}`);
  }
}


// Content from classes/EditorManager.js
class EditorManager {
  editors = {};
  pages = [];
  theme = [];
  currentEditor = null;
  currentPageId = null;
  selectedTemplateWrapper = null;
  selectedComponent = null;
  container = document.getElementById("child-container");

  constructor(dataManager, currentLanguage) {
    this.dataManager = dataManager;
    this.currentLanguage = currentLanguage;
    this.templateManager = new TemplateManager(this.currentLanguage, this);
    this.editorEventManager = new EditorEventManager(
      this,
      this.templateManager
    );

    this.initializeEditorManager();
  }

  async initializeEditorManager() {
    const theme = await this.dataManager.getLocationTheme();
    if (this.toolsSection.checkIfNotAuthenticated(theme)) return;
    this.theme = theme.SDT_LocationTheme;

    const pagesResponse = await this.dataManager.getPages();
    if (this.toolsSection.checkIfNotAuthenticated(pagesResponse)) return;

    this.pages = pagesResponse.SDT_PageCollection;
    this.initializeHomePage();
  }

  initializeHomePage() {
    const homePage = this.pages.find((page) => page.PageName == "Home");
    if (homePage) {
      this.createChildEditor(homePage);
      this.currentPageId = homePage.PageId;
    } else {
      this.toolsSection.ui.displayAlertMessage(
        `${this.currentLanguage.getTranslation("no_home_page_found")}`,
        "danger"
      );
    }
  }

  getCurrentEditor() {
    return this.currentEditor.editor;
  }

  setCurrentEditor(editorId) {
    const previousEditor = this.editors[editorId];
    // if (previousEditor && previousEditor.editor) {
    //   this.selectedComponent = null;
    //   this.selectedTemplateWrapper = null;
    // }

    this.currentEditor = this.editors[editorId];
    this.activateFrame(editorId + "-frame");
    this.toolsSection.unDoReDo(this.currentEditor.editor);
  }

  activateFrame(activeFrameClass) {
    const activeFrame = document.querySelector(activeFrameClass);
    document.querySelectorAll(".active-editor").forEach((frame) => {
      if (frame !== activeFrame) {
        frame.classList.remove("active-editor");
      }
    });
    activeFrame.classList.add("active-editor");
  }

  createChildEditor(page) {
    const editorDetails = this.setupEditorContainer(page);
    const editor = this.initializeGrapesEditor(editorDetails.editorId);
    this.editorEventManager.addEditorEventListeners(editor, page);
    this.loadEditorContent(editor, page);
    this.setupEditorLayout(editor, page, editorDetails.containerId);
    this.finalizeEditorSetup(editor, page, editorDetails);
  }

  setupEditorContainer(page) {
    const count = this.container.children.length;
    const editorId = `gjs-${count}`;
    const containerId = `${editorId}-frame`;

    const editorContainer = document.createElement("div");
    editorContainer.innerHTML = this.generateEditorHTML(page, editorId);
    this.configureEditorContainer(editorContainer, containerId, page.PageId);

    return { editorId, containerId };
  }

  generateEditorHTML(page, editorId) {
    const appBar = this.shouldShowAppBar(page)
      ? this.createAppBarHTML(page.PageName, page.PageId)
      : "";

    return `
      <div class="header">
          <span id="current-time-${page.PageId}"></span>
          <span class="icons">
              <i class="fas fa-signal"></i>
              <i class="fas fa-wifi"></i>
              <i class="fas fa-battery"></i>
          </span>
      </div>
      ${appBar}
      <div id="${editorId}"></div>
    `;
  }

  configureEditorContainer(container, containerId, pageId) {
    container.id = containerId;
    container.dataset.pageid = pageId;
    container.classList.add("mobile-frame", "adding");
    this.container.appendChild(container);

    requestAnimationFrame(() => {
      container.classList.remove("adding");
    });
  }

  shouldShowAppBar(page) {
    return page.PageIsContentPage || page.PageName !== "Home";
  }

  createAppBarHTML(pageName, pageId) {
    return `
      <div class="app-bar">
          <svg id="back-button-${pageId}" class="content-back-button" xmlns="http://www.w3.org/2000/svg" id="Group_14" data-name="Group 14" width="47" height="47" viewBox="0 0 47 47">
            <g id="Ellipse_6" data-name="Ellipse 6" fill="none" stroke="#262626" stroke-width="1">
              <circle cx="23.5" cy="23.5" r="23.5" stroke="none"/>
              <circle cx="23.5" cy="23.5" r="23" fill="none"/>
            </g>
            <path id="Icon_ionic-ios-arrow-round-up" data-name="Icon ionic-ios-arrow-round-up" d="M13.242,7.334a.919.919,0,0,1-1.294.007L7.667,3.073V19.336a.914.914,0,0,1-1.828,0V3.073L1.557,7.348A.925.925,0,0,1,.263,7.341.91.91,0,0,1,.27,6.054L6.106.26h0A1.026,1.026,0,0,1,6.394.07.872.872,0,0,1,6.746,0a.916.916,0,0,1,.64.26l5.836,5.794A.9.9,0,0,1,13.242,7.334Z" transform="translate(13 30.501) rotate(-90)" fill="#262626"/>
          </svg>
          <h1 class="title" style="text-transform: uppercase">${pageName}</h1>
      </div>
    `;
  }

  initializeGrapesEditor(editorId) {
    return grapesjs.init({
      container: `#${editorId}`,
      fromElement: true,
      height: "100%",
      width: "auto",
      canvas: {
        styles: [
          "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css",
          "https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css",
          "https://fonts.googleapis.com/css2?family=Lora&family=Merriweather&family=Poppins:wght@400;500&family=Roboto:wght@400;500&display=swap",
          "/Resources/UCGrapes1/src/css/toolbox.css",
        ],
      },
      baseCss: " ",
      dragMode: "normal",
      panels: { defaults: [] },
      sidebarManager: false,
      storageManager: false,
      modal: false,
      commands: false,
      hoverable: false,
      highlightable: false,
      selectable: false,
    });
  }

  updatePageJSONContent(editor, page) {
    const PageGJSJson = editor.getProjectData();
    this.dataManager.pages.SDT_PageCollection.map((p) => {
      if (p.PageId == page.PageId) {
        p.PageGJSJson = JSON.stringify(PageGJSJson);
      }
      return p;
    });
  }

  async loadEditorContent(editor, page) {
    if (page.PageGJSJson) {
      await this.loadExistingContent(editor, page);
    } else if (page.PageIsContentPage) {
      await this.loadNewContentPage(editor, page);
    }
    this.updatePageJSONContent(editor, page);
  }

  async loadExistingContent(editor, page) {
    try {
      const pageData = JSON.parse(page.PageGJSJson);

      if (page.PageIsPredefined && page.PageName === "Location") {
        await this.handleLocationPage(editor, pageData);
      } else if (page.PageIsPredefined && page.PageName === "Reception") {
        editor.loadProjectData(pageData);
      } else if (page.PageIsContentPage) {
        editor.loadProjectData(pageData);
        await this.handleContentPage(editor, page);
      } else {
        editor.loadProjectData(pageData);
      }
    } catch (error) {
      console.error("Error loading existing content:", error);
    }
  }

  async handleLocationPage(editor, pageData) {
    pageData.pages[0].frames[0].component.components[0].components[0].components[0].components[0].components[0].components[0].attributes.src =
      this.dataManager.Location.LocationImage_GXI;
    pageData.pages[0].frames[0].component.components[0].components[0].components[0].components[0].components[0].components[1].components[0].content =
      this.dataManager.Location.LocationDescription;
    editor.DomComponents.clear();
    editor.loadProjectData(pageData);
  }

  async handleContentPage(editor, page) {
    try {
      const res = await this.dataManager.getContentPageData(page.PageId);
      if (this.toolsSection.checkIfNotAuthenticated(res)) return;

      const contentPageData = res.SDT_ProductService;
      if (!contentPageData) {
        console.warn("No content page data received");
        return;
      }

      await this.updateContentPageElements(editor, contentPageData);
    } catch (error) {
      console.error("Error loading content page data:", error);
    }
  }

  async updateContentPageElements(editor, contentPageData) {
    const wrapper = editor.DomComponents.getWrapper();
    if (!wrapper) {
      console.error("Wrapper not found in editor");
      return;
    }

    await this.updateImage(wrapper, contentPageData);
    await this.updateDescription(wrapper, contentPageData);
    this.toolsSection.ui.pageContentCtas(contentPageData.CallToActions, editor);
  }

  async updateImage(wrapper, contentPageData) {
    const img = wrapper.find("#product-service-image");
    if (img.length > 0) {
      if (!contentPageData?.ProductServiceImage) {
        img[0].remove();
      } else {
        try {
          img[0].setAttributes({
            src: contentPageData.ProductServiceImage,
            alt: "Product Service Image",
          });
        } catch (err) {
          console.error("Error updating image:", err);
        }
      }
    }
  }

  async updateDescription(wrapper, contentPageData) {
    const p = wrapper.find("#product-service-description");
    if (p.length > 0) {
      if (!contentPageData?.ProductServiceDescription) {
        p[0].remove();
      } else {
        try {
          p[0].components(contentPageData.ProductServiceDescription);
        } catch (err) {
          console.error("Error updating description:", err);
        }
      }
    }
  }

  async loadNewContentPage(editor, page) {
    try {
      const res = await this.dataManager.getContentPageData(page.PageId);
      if (this.toolsSection.checkIfNotAuthenticated(res)) return;

      const contentPageData = res.SDT_ProductService;
      if (contentPageData) {
        const projectData =
          this.templateManager.initialContentPageTemplate(contentPageData);
        editor.addComponents(projectData)[0];
        this.toolsSection.ui.pageContentCtas(
          contentPageData.CallToActions,
          editor
        );
      }
    } catch (error) {
      console.error("Error fetching content page data:", error);
    }
  }

  setupEditorLayout(editor, page, containerId) {
    if (this.shouldShowAppBar(page)) {
      const canvas = editor.Canvas.getElement();
      if (canvas) {
        canvas.style.setProperty("height", "calc(100% - 100px)", "important");
      }
      this.backButtonAction(containerId, page.PageId);
    }
  }

  finalizeEditorSetup(editor, page, editorDetails) {
    const editorData = {
      pageId: page.PageId,
      editor,
    };
    this.editors[`#${editorDetails.editorId}`] = editorData;

    if (page.PageName === "Home") {
      this.setCurrentEditor(`#${editorDetails.editorId}`);
    }

    const wrapper = editor.getWrapper();
    wrapper.set({
      selectable: false,
      droppable: false,
      draggable: false,
      hoverable: false,
    });

    const navigator = this.editorEventManager.activateNavigators();
    navigator.updateButtonVisibility();
    navigator.scrollBy(200);
    new Clock(`current-time-${page.PageId}`);
  }

  getPage(pageId) {
    return this.dataManager.pages.SDT_PageCollection.find(
      (page) => page.PageId == pageId
    );
  }

  backButtonAction(editorContainerId, pageId) {
    const backButton = document.getElementById(`back-button-${pageId}`);
    if (backButton) {
      backButton.addEventListener("click", (e) => {
        e.preventDefault();
        const currentContainer = document.getElementById(editorContainerId);
        if (!currentContainer) return;

        const frameList = currentContainer.parentElement;
        const allFrames = Array.from(frameList.children);

        const currentIndex = allFrames.indexOf(currentContainer);

        allFrames.forEach((frame, index) => {
          if (index >= currentIndex) {
            frame.remove();
          }
        });

        this.editorEventManager.activateNavigators();
      });
    }
  }

  setToolsSection(toolBox) {
    this.toolsSection = toolBox;
  }
}


// Content from classes/EditorEventManager.js
class EditorEventManager {
  constructor(editorManager, templateManager) {
    this.editorManager = editorManager;
    this.templateManager = templateManager;
  }

  addEditorEventListeners(editor, page) {
    this.editorOnLoad(editor);
    this.editorOnDropped(editor);
    this.editorOnSelected(editor);
    this.setupKeyboardBindings(editor);
    this.editorOnUpdate(editor, page)
  }

  setupKeyboardBindings(editor) {
    const { keymaster } = editor.Keymaps;
    keymaster.unbind("backspace");
    keymaster.unbind("delete");
    keymaster.bind("ctrl+z");
    keymaster.bind("ctrl+shift+z");
  }

  editorOnLoad(editor) {
    editor.on("load", () => this.handleEditorLoad(editor));
  }

  handleEditorLoad(editor) {
    this.loadTheme()
    const wrapper = editor.getWrapper();
    this.editorManager.toolsSection.currentLanguage.translateTilesTitles(editor)
    wrapper.view.el.addEventListener("click", (e) =>
      this.handleEditorClick(e, editor)
    );
  }

  loadTheme() {
    this.editorManager.toolsSection.themeManager.setTheme(
      this.editorManager.theme.ThemeName
    );
  }

  handleEditorClick(e, editor) {
    document.querySelector(".cta-button-layout-container").style.display =
      "none";
    const editorId = editor.getConfig().container;
    const editorContainerId = `${editorId}-frame`;

    this.editorManager.setCurrentEditor(editorId);
    this.editorManager.currentPageId = $(editorContainerId).data().pageid;

    this.updateToolsSection();
    this.editorManager.toolsSection.unDoReDo(editor);

    document.querySelector(".cta-button-layout-container").style.display =
      "none";

    const ctaBtnSelected = e.target.closest("[cta-buttons]");
    if (ctaBtnSelected) {
      this.editorManager.toolsSection.ui.activateCtaBtnStyles(
        this.editorManager.selectedComponent
      );
    }

    const tileElement = e.target.closest("[tile-action-object-id]");
    if (tileElement) {
      const customEvent = {
        ...e,
        target: tileElement,
      };
      this.handleTileActionClick(customEvent, editorContainerId);
    }

    const button = e.target.closest(".action-button");
    if (button) {
      this.handleActionButtonClick(button, editor);
    }
  }

  handleTileActionClick(e, editorContainerId) {
    const pageId = e.target.attributes["tile-action-object-id"].value;
    const page = this.editorManager.getPage(pageId);
    $(editorContainerId).nextAll().remove();
    if (page) {
      this.editorManager.createChildEditor(page);
    }
  }

  handleActionButtonClick(button, editor) {
    const templateWrapper = button.closest(".template-wrapper");
    if (!templateWrapper) return;

    const templateComponent = editor.Components.getById(templateWrapper.id);
    if (!templateComponent) return;

    this.templateComponent = templateComponent;

    if (button.classList.contains("delete-button")) {
      this.templateManager.deleteTemplate(this.templateComponent);
    } else if (button.classList.contains("add-button-bottom")) {
      this.templateManager.addTemplateBottom(this.templateComponent, editor);
    } else if (button.classList.contains("add-button-right")) {
      this.templateManager.addTemplateRight(this.templateComponent, editor);
    }
  }

  editorOnSelected(editor) {
    editor.on("component:selected", (component) =>
      this.handleComponentSelected(component)
    );
  }

  editorOnUpdate(editor, page) {
    editor.on('update', () => {
      this.editorManager.updatePageJSONContent(editor, page)
    });
  }

  editorOnDropped(editor) {
    // // let isDragging = false;
    // // editor.on("component:drag:start", (component) => {
    // //   isDragging = true;
    // // });
    // // editor.on("component:drag:end", (component) => {
    // //   const tileComponents = component.target.find(".template-blocks");
    // //   if (tileComponents.length) {
    // //     console.log("Tile Components", tileComponents);
    // //   }
    // //   isDragging = false;
    // //   editor.on("component:mount", (model) => {
    // //     // Only handle components added via drag
    // //     if (isDragging) {
    // //       console.log(model.getName());
    // //         if(model.getName() == "Tile-wrapper"){
    // //           console.log("Tile-wrapper added", model.getClasses());
    // //           model.removeClass("gjs-selected");
    // //         }
    // //     }
    // //   });
    // // });
    // editor.on("component:drag:start", (component) => {
    //   const el = component.parent.getEl();
    //   if (el) {
    //     el.style.cursor = "grab";
    //   }
    // });
  }

  handleComponentSelected(component) {
    this.editorManager.selectedTemplateWrapper = component.getEl();
    this.editorManager.selectedComponent = component;

    const sidebarInputTitle = document.getElementById("tile-title");
    if (this.editorManager.selectedTemplateWrapper) {
      const tileLabel =
        this.editorManager.selectedTemplateWrapper.querySelector(".tile-title");
      if (tileLabel) {
        sidebarInputTitle.value = tileLabel.textContent;
      }

      this.templateManager.removeElementOnClick(
        ".selected-tile-icon",
        ".tile-icon-section"
      );
      this.templateManager.removeElementOnClick(
        ".selected-tile-title",
        ".tile-title-section"
      );
    }

    this.editorManager.toolsSection.ui.updateTileProperties(
      this.editorManager.currentEditor.editor,
      this.editorManager.currentPageId
    );
    const page = this.editorManager.getPage(this.editorManager.currentPageId);
    if (page?.PageIsContentPage) {
      this.editorManager.toolsSection.ui.activateCtaBtnStyles(
        this.editorManager.selectedComponent
      );
    }

    this.editorManager.toolsSection.checkTileBgImage();

    this.activateNavigators();

    this.updateUIState();
  }

  updateUIState() {
    document.querySelector("#templates-button").classList.remove("active");
    document.querySelector("#pages-button").classList.remove("active");
    document.querySelector("#pages-button").classList.add("active");
    document.querySelector("#mapping-section").style.display = "none";
    document.querySelector("#tools-section").style.display = "block";
    document.querySelector("#templates-content").style.display = "none";
    document.querySelector("#pages-content").style.display = "block";
  }

  updateToolsSection() {
    const page = this.editorManager.getPage(this.editorManager.currentPageId);
    if (page) {
      document.querySelector("#content-page-section").style.display =
        page.PageIsContentPage ? "block" : "none";
      document.querySelector("#menu-page-section").style.display =
        page.PageIsContentPage ? "none" : "block";
    }
  }

  activateNavigators() {
    const leftNavigator = document.querySelector(".page-navigator-left");
    const rightNavigator = document.querySelector(".page-navigator-right");
    const scrollContainer = document.getElementById("child-container");
    const prevButton = document.getElementById("scroll-left");
    const nextButton = document.getElementById("scroll-right");
    const frames = document.querySelectorAll(".mobile-frame");

    leftNavigator.style.display = "flex";
    rightNavigator.style.display = "flex";

    const alignment =
      window.innerWidth <= 1440
        ? frames.length > 1
          ? "flex-start"
          : "center"
        : frames.length > 3
        ? "flex-start"
        : "center";

    scrollContainer.style.setProperty("justify-content", alignment);

    const scrollBy = (offset) => {
      scrollContainer.scrollTo({
        left: scrollContainer.scrollLeft + offset,
        behavior: "smooth",
      });
    };

    prevButton.addEventListener("click", () => scrollBy(-200));
    nextButton.addEventListener("click", () => scrollBy(200));

    const updateButtonVisibility = () => {
      const { scrollLeft, scrollWidth, clientWidth } = scrollContainer;
      prevButton.style.display = scrollLeft > 0 ? "flex" : "none";
      nextButton.style.display =
        scrollLeft + clientWidth < scrollWidth ? "flex" : "none";
    };

    updateButtonVisibility();
    scrollContainer.addEventListener("scroll", updateButtonVisibility);

    return { updateButtonVisibility, scrollBy };
  }

  setupUndoRedoButtons() {
    // Assuming you have undo and redo buttons in your UI
    const undoBtn = document.getElementById("undo");
    const redoBtn = document.getElementById("redo");

    if (!this.editorManager.currentEditor) return;

    const undoRedoManager = new UndoRedoManager(this.editorManager.currentEditor.editor);
    
    // Update button states
    if (undoBtn) {
      undoBtn.disabled = !undoRedoManager.canUndo();
      undoBtn.onclick = (e) => {
        e.preventDefault();
        undoRedoManager.undo();
      };
    }

    if (redoBtn) {
      redoBtn.disabled = !undoRedoManager.canRedo();
      redoBtn.onclick = () => undoRedoManager.redo();
    }
  }
}



// Content from classes/TemplateManager.js
class TemplateManager {
  constructor(currentLanguage, editorManager) {
    this.currentLanguage = currentLanguage;
    this.editorManager = editorManager;
    this.defaultConstraints = {
      draggable: false,
      selectable: false,
      editable: false,
      highlightable: false,
      droppable: false,
      hoverable: false,
    };
  }

  createTemplateHTML(isDefault = false) {
    let tileBgColor = this.editorManager.toolsSection.currentTheme.colors.accentColor
    return `
            <div class="template-wrapper ${
              isDefault ? "default-template" : ""
            }"        
                  data-gjs-selectable="false"
                  data-gjs-type="tile-wrapper"
                  data-gjs-editable="false"
                  data-gjs-highlightable="false"
                  data-gjs-droppable="false"
                  data-gjs-resizable="false"
                  data-gjs-hoverable="false">
              <div class="template-block"
                style="background-color:${tileBgColor}"
                tile-bgcolor="${tileBgColor}"
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
                      data-gjs-hoverable="false">${this.currentLanguage.getTranslation(
                        "tile_title"
                      )}</span>
                    </div>
                </div>
              ${
                !isDefault
                  ? `
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
              `
                  : ""
              }
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
          `;
  }

  generateTemplateRow(columns, rowIndex) {
    let tileBgColor = this.editorManager.toolsSection.currentTheme.colors.accentColor
    let columnWidth = 100 / columns;
    if (columns === 1) {
      columnWidth = 100;
    } else if (columns === 2) {
      columnWidth = 49;
    } else if (columns === 3) {
      columnWidth = 32;
    }

    let wrappers = "";

    for (let i = 0; i < columns; i++) {
      // Only exclude delete button for first tile of first row
      const isFirstTileOfFirstRow = rowIndex === 0 && i === 0;
      const deleteButton = isFirstTileOfFirstRow
        ? ""
        : `
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
                    </button>`;

      wrappers += `
                <div class="template-wrapper"
                          style="flex: 0 0 ${columnWidth}%); background: ${tileBgColor}"
                          data-gjs-type="tile-wrapper"
                          data-gjs-selectable="false"
                          data-gjs-droppable="false">

                          <div class="template-block"
                            tile-bgcolor="${tileBgColor}"
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
                                  data-gjs-hoverable="false">${this.currentLanguage.getTranslation(
                                    "tile_title"
                                  )}</span>
                                </div>
                          </div>
                          ${deleteButton}
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
                `;
    }
    return `
                      <div class="container-row"
                          data-gjs-type="template-wrapper"
                          data-gjs-draggable="false"
                          data-gjs-selectable="false"
                          data-gjs-editable="false"
                          data-gjs-highlightable="true"
                          data-gjs-droppable="false"
                          data-gjs-hoverable="true">
                        ${wrappers}
                    </div>
              `;
  }

  addFreshTemplate(template) {
    this.editorManager.currentEditor.editor.DomComponents.clear();
    let fullTemplate = "";

    template.forEach((columns, rowIndex) => {
      const templateRow = this.generateTemplateRow(columns, rowIndex);
      fullTemplate += templateRow;
    });

    this.editorManager.currentEditor.editor.addComponents(`
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
            ${fullTemplate}
        </div>
      </div>
    `);

    const message = this.currentLanguage.getTranslation(
      "template_added_success_message"
    );
    const status = "success";
    this.editorManager.toolsSection.ui.displayAlertMessage(message, status);
  }

  deleteTemplate(templateComponent) {
    if (
      !templateComponent ||
      templateComponent.getClasses().includes("default-template")
    )
      return;

    const containerRow = templateComponent.parent();
    if (!containerRow) return;

    templateComponent.remove();

    const templates = containerRow.components();
    const newWidth = 100 / templates.length;
    templates.forEach((template) => {
      if (template && template.setStyle) {
        template.addStyle({
          width: `${newWidth}%`,
        });
      }
    });

    this.updateRightButtons(containerRow);
  }

  addTemplateRight(templateComponent, editorInstance) {
    const containerRow = templateComponent.parent();
    if (!containerRow || containerRow.components().length >= 3) return;
    const newComponents = editorInstance.addComponents(
      this.createTemplateHTML()
    );
    const newTemplate = newComponents[0];
    if (!newTemplate) return;

    const index = templateComponent.index();
    containerRow.append(newTemplate, {
      at: index + 1,
    });
    const templates = containerRow.components();

    const equalWidth = 100 / templates.length;
    templates.forEach((template) => {
      template.addStyle({
        flex: `0 0 calc(${equalWidth}% - 0.3.5rem)`,
      });
    });

    this.updateRightButtons(containerRow);
  }

  addTemplateBottom(templateComponent, editorInstance) {
    const currentRow = templateComponent.parent();
    const containerColumn = currentRow?.parent();

    if (!containerColumn) return;

    const newRow = editorInstance.addComponents(`
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
            `)[0];

    const index = currentRow.index();
    containerColumn.append(newRow, {
      at: index + 1,
    });
  }

  updateRightButtons(containerRow) {
      if (!containerRow) return;

      const templates = containerRow.components();

      templates.forEach((template) => {
          if (!template || !template.view || !template.view.el) return;

          const rightButton = template.view.el.querySelector(".add-button-right");
          if (!rightButton) return;
          const rightButtonComponent = template.find(".add-button-right")[0];

          if (templates.length >= 3) {
              rightButtonComponent.addStyle({
                  display: "none"
              });
          } else {
              rightButtonComponent.addStyle({
                  display: "flex"
              });
          }
      });
  }

  // updateRightButtons(containerRow) {
  //   if (!containerRow) return;
  
  //   // Force a store update after attribute changes
  //   const editor = this.editorManager.currentEditor.editor;
  
  //   // Check components length once outside the loop
  //   const totalComponents = containerRow.components().length;
  //   const isMaxComponents = totalComponents >= 3;
  
  //   // Update container droppable state first
  //   containerRow.set(
  //     "droppable",
  //     isMaxComponents ? false : "false"
  //   );
  
  //   containerRow.components().forEach((template) => {
  //     if (!template?.view?.el) return;
  
  //     const rightButton = template.view.el.querySelector(".add-button-right");
  //     const rightButtonComponent = template.find(".add-button-right")[0];
  //     if (!rightButton || !rightButtonComponent) return;
  
  //     // Update button visibility
  //     rightButtonComponent.addStyle({
  //       display: isMaxComponents ? "none" : "flex",
  //     });
  //   });
  
  //   // Add visual feedback for droppable state
  //   if (isMaxComponents) {
  //     containerRow.addClass('container-max-components');
  //   } else {
  //     containerRow.removeClass('container-max-components');
  //   }
  
  //   // Trigger updates
  //   editor.trigger("change:component"); 
  //   editor.refresh();
  //   containerRow.view.render(); 
  // }

  initialContentPageTemplate(contentPageData) {
    console.log("initialContentPageTemplate", contentPageData);
    return `
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
                            ${
                              contentPageData.ProductServiceImage
                                ? `
                                <img
                                    class="content-page-block"
                                    id="product-service-image"
                                    data-gjs-draggable="true"
                                    data-gjs-selectable="false"
                                    data-gjs-editable="false"
                                    data-gjs-droppable="false"
                                    data-gjs-highlightable="false"
                                    data-gjs-hoverable="false"
                                    src="${contentPageData.ProductServiceImage}"
                                    data-gjs-type="product-service-image"
                                    alt="Full-width Image"
                                />
                            `
                                : ""
                            }
                            ${
                              contentPageData.ProductServiceDescription
                                ? `
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
                                ${contentPageData.ProductServiceDescription}
                                </p>
                            `
                                : ""
                            }
                        </div>
                    </div>
                </div>
                <div class="cta-button-container" ${defaultConstraints}></div>
            </div>
        </div>
    `;
  }

  removeElementOnClick(targetSelector, sectionSelector) {
    const closeSection =
      this.editorManager.selectedComponent?.find(targetSelector)[0];
    if (closeSection) {
      const closeEl = closeSection.getEl();
      if (closeEl) {
        closeEl.onclick = () => {
          this.editorManager.selectedComponent
            .find(sectionSelector)[0]
            .remove();
          if (sectionSelector = '.tile-title-section') {
            this.editorManager.toolsSection.setAttributeToSelected("TileText", "")
          }
          if (sectionSelector = '.tile-icon-section') {
            this.editorManager.toolsSection.setAttributeToSelected("tile-icon", "")
          }
        };
      }
    }
  }
}


// Content from classes/ToolboxManager.js
class ToolBoxManager {
  constructor(
    editorManager,
    dataManager,
    themes,
    icons,
    templates,
    mapping,
    media,
    locale
  ) {
    this.editorManager = editorManager;
    this.dataManager = dataManager;
    this.themes = themes;
    this.icons = icons;
    this.currentTheme = null;
    this.templates = templates;
    this.mappingsItems = mapping;
    this.selectedFile = null;
    this.media = media;
    this.currentLanguage = locale;
    this.ui = new ToolBoxUI(this);
    this.init(locale.currentLanguage);
  }

  async init(language) {
    try {
      this.currentLanguage = await new Locale(language).init();
      this.themeManager = new ThemeManager(this);
      this.eventListenerManager = new EventListenerManager(this);
      this.popupManager = new PopupManager(this);
      this.pageManager = new PageManager(this);
      console.log("ToolboxManager initialized", this.currentLanguage);

      await this.initializeManagers();
      await this.setupComponents();
      this.setupEventListeners();
    } catch (error) {
      console.error("Failed to initialize toolbox:", error);
    }
  }

  async initializeManagers() {
    
    await this.dataManager.getPages().then((res) => {
      if (this.checkIfNotAuthenticated(res)) {
        return;
      }
      localStorage.clear();
    });

    this.themeManager.loadTheme();
    this.themeManager.listThemesInSelectField();
    this.themeManager.colorPalette();
    this.themeManager.ctaColorPalette();
    this.pageManager.loadPageTemplates();
  }

  setupComponents() {
    this.actionList = new ActionListComponent(
      this.editorManager,
      this.dataManager,
      this.currentLanguage,
      this
    );

    this.mediaComponent = new MediaComponent(
      this.dataManager,
      this.editorManager,
      this.currentLanguage,
      this
    );
  }

  setupEventListeners() {
    this.eventListenerManager.setupTabListeners();
    this.eventListenerManager.setupMappingListeners();
    this.eventListenerManager.setupPublishListeners();
    this.eventListenerManager.setupAlignmentListeners();
    this.eventListenerManager.setupOpacityListener();
    this.eventListenerManager.setupAutoSave();

    const sidebarInputTitle = document.getElementById("tile-title");
    sidebarInputTitle.addEventListener("input", (e) => {
      this.ui.updateTileTitle(e.target.value);
    });
  }

  publishPages(isNotifyResidents) {
    const editors = Object.values(this.editorManager.editors);
    if (editors && editors.length) {
      const pageDataList = this.preparePageDataList(editors);
      if (pageDataList.length) {
        this.sendPageUpdateRequest(pageDataList, isNotifyResidents);
      }
    }
  }

  preparePageDataList(editors) {
    return this.dataManager.pages.SDT_PageCollection.map(page=>{
      let projectData;
      try {
        projectData = JSON.parse(page.PageGJSJson)
      } catch (error) {
        projectData = {}
      }
      const jsonData = page.PageIsContentPage
          ? mapContentToPageData(projectData, page)
          : mapTemplateToPageData(projectData, page);
      return {
        PageId: page.PageId,
        PageName: page.PageName,
        PageJsonContent: JSON.stringify(jsonData),
        PageGJSHtml: page.PageGJSHtml,
        PageGJSJson: page.PageGJSJson,
        SDT_Page: jsonData,
        PageIsPublished: true,
      };
    })
  }

  async sendPageUpdateRequest(pageDataList, isNotifyResidents) {
    const payload = {
      IsNotifyResidents: isNotifyResidents,
      PagesList: pageDataList,
    };

    try {
      const res = await this.dataManager.updatePagesBatch(payload);
      if (this.checkIfNotAuthenticated(res)) {
        return;
      }
      this.ui.displayAlertMessage("All Pages Saved Successfully", "success");
    } catch (error) {
      console.error("Error saving pages:", error);
      this.ui.displayAlertMessage(
        "An error occurred while saving pages.",
        "error"
      );
    }
  }

  autoSavePage(editorData) {
    const pageId = editorData.pageId;
    const editor = editorData.editor;
    const page = this.dataManager.pages.SDT_PageCollection.find(
      (page) => page.PageId == pageId
    );

    if (pageId) {
      const data = {
        PageId: pageId,
        PageName: page.PageName,
        PageGJSHtml: editor.getHtml(),
        PageGJSJson: JSON.stringify(editor.getProjectData()),
      };

      this.dataManager.updatePage(data).then((res) => {
        if (this.checkIfNotAuthenticated(res)) {
          return;
        }

        this.dataManager.getPages().then((pages) => {
          this.editorManager.pages = pages.SDT_PageCollection;
        });

        this.ui.openToastMessage();
      });
    }
  }

  unDoReDo(editorInstance) {
    const um = editorInstance.UndoManager;

    const undoButton = document.getElementById("undo");
    const redoButton = document.getElementById("redo");
    // Update button states
    if (undoButton) {
      undoButton.disabled = !um.hasUndo();
      undoButton.onclick = (e) => {
        e.preventDefault();
        um.undo();
        this.editorManager.currentEditor.editor.refresh();
      };
    }

    if (redoButton) {
      redoButton.disabled = !um.hasRedo();
      redoButton.onclick = (e) => {
        e.preventDefault();
        um.redo();
        this.editorManager.currentEditor.editor.refresh();
      };
    }
  }

  checkIfNotAuthenticated(res) {
    if (res.error.Status === "Error") {
      console.error(
        "Error updating theme. Status:",
        res.error.Status,
        "Message:",
        res.error.Message
      );

      this.ui.displayAlertMessage(
        this.currentLanguage.getTranslation("not_authenticated_message"),
        "error"
      );

      return true;
    }
    return false;
  }

  setAttributeToSelected(attributeName, attributeValue) {
    if (this.editorManager.selectedComponent) {
      this.editorManager.selectedComponent.addAttributes({
        [attributeName]: attributeValue,
      });
    } else {
      this.ui.displayAlertMessage(
        this.currentLanguage.getTranslation("no_tile_selected_error_message"),
        "error"
      );
    }
  }

  checkTileBgImage () {
    if (this.editorManager.selectedTemplateWrapper) {
      const templateBlock =
        this.editorManager.selectedComponent;

      if (templateBlock) {
        const tileImgContainer = document.getElementById("tile-img-container");
        // first check if templateBlock has a background image
        if (templateBlock.getStyle()["background-image"]) {
          const currentBgImage = templateBlock
          .getStyle()
          ["background-image"].match(/url\((.*?)\)/)[1];

          if( currentBgImage) {
            if (tileImgContainer) {
              const tileImg = tileImgContainer.querySelector("img");
              if (tileImg) {
                tileImg.src = currentBgImage;
                tileImgContainer.style.display = "block";

                const tileBtn = tileImgContainer.querySelector("button");
                if (tileBtn) {
                  tileBtn.onclick = (e) => {
                    e.preventDefault();
                    const currentStyles = templateBlock.getStyle() || {};
                    delete currentStyles["background-image"];
                    templateBlock.setStyle(currentStyles);
                    tileImgContainer.style.display = "none";
                    this.setAttributeToSelected(
                      "tile-bg-image-url",
                      "",
                    );
                  }
                }
              }            
            }
          }
        } else {
          tileImgContainer.style.display = "none";
        }       
      }
    }
  }
}



// Content from classes/EventListenerManager.js
class EventListenerManager {
  constructor(toolBoxManager) {
    this.toolBoxManager = toolBoxManager;
  }

  setupTabListeners() {
    const tabButtons = document.querySelectorAll(".tb-tab-button");
    const tabContents = document.querySelectorAll(".tb-tab-content");
    tabButtons.forEach((button) => {
      button.addEventListener("click", (e) => {
        e.preventDefault();
        tabButtons.forEach((btn) => btn.classList.remove("active"));
        tabContents.forEach((content) => (content.style.display = "none"));

        button.classList.add("active");
        document.querySelector(`#${button.dataset.tab}-content`).style.display =
          "block";
      });
    });
  }

  setupMappingListeners() {
    const mappingButton = document.getElementById("open-mapping");
    const publishButton = document.getElementById("publish");
    const mappingSection = document.getElementById("mapping-section");
    const toolsSection = document.getElementById("tools-section");

    this.toolBoxManager.mappingComponent = new MappingComponent(
      this.toolBoxManager.dataManager,
      this.toolBoxManager.editorManager,
      this.toolBoxManager,
      this.toolBoxManager.currentLanguage
    );

    mappingButton.addEventListener("click", (e) => {
      e.preventDefault();

      toolsSection.style.display =
        toolsSection.style.display === "none" ? "block" : "none";

      mappingSection.style.display =
        mappingSection.style.display === "block" ? "none" : "block";

      this.toolBoxManager.mappingComponent.init();
    });
  }

  setupPublishListeners() {
    const publishButton = document.getElementById("publish");

    publishButton.onclick = (e) => {
      e.preventDefault();
      const popup = document.createElement("div");
      popup.className = "popup-modal";
      popup.innerHTML = `
                <div class="popup">
                  <div class="popup-header">
                    <span>${this.toolBoxManager.currentLanguage.getTranslation(
                      "publish_confirm_title"
                    )}</span>
                    <button class="close">
                      <svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 21 21">
                          <path id="Icon_material-close" data-name="Icon material-close" d="M28.5,9.615,26.385,7.5,18,15.885,9.615,7.5,7.5,9.615,15.885,18,7.5,26.385,9.615,28.5,18,20.115,26.385,28.5,28.5,26.385,20.115,18Z" transform="translate(-7.5 -7.5)" fill="#6a747f" opacity="0.54"/>
                      </svg>
                    </button>
                  </div>
                  <hr>
                  <div class="popup-body" id="confirmation_modal_message">
                  ${this.toolBoxManager.currentLanguage.getTranslation(
                    "publish_confirm_message"
                  )}
                    <label for="notify_residents" class="notify_residents">
                        <input type="checkbox" id="notify_residents" name="notify_residents">
                        <span>${this.toolBoxManager.currentLanguage.getTranslation(
                          "nofity_residents_on_publish"
                        )}</span>
                    </label>
                  </div>
                  <div class="popup-footer">
                    <button id="yes_publish" class="tb-btn tb-btn-primary">
                    ${this.toolBoxManager.currentLanguage.getTranslation(
                      "publish_confirm_button"
                    )}
                    </button>
                    <button id="close_popup" class="tb-btn tb-btn-outline">
                    ${this.toolBoxManager.currentLanguage.getTranslation(
                      "publish_cancel_button"
                    )}
                    </button>
                  </div>
                </div>
              `;

      document.body.appendChild(popup);
      popup.style.display = "flex";

      const publishButton = popup.querySelector("#yes_publish");
      const closeButton = popup.querySelector("#close_popup");
      const closePopup = popup.querySelector(".close");

      publishButton.addEventListener("click", () => {
        const isNotifyResidents =
          document.getElementById("notify_residents").checked;
        this.toolBoxManager.publishPages(isNotifyResidents);
        popup.remove();
      });

      closeButton.addEventListener("click", () => {
        popup.remove();
      });

      closePopup.addEventListener("click", () => {
        popup.remove();
      });
    };
  }

  setupAlignmentListeners() {
    const leftAlign = document.getElementById("text-align-left");
    const centerAlign = document.getElementById("text-align-center");
    const rightAlign = document.getElementById("text-align-right");

    leftAlign.addEventListener("click", () => {
      if (this.toolBoxManager.editorManager.selectedTemplateWrapper) {
        const templateBlock =
          this.toolBoxManager.editorManager.selectedComponent.find(
            ".tile-title-section"
          )[0];

        if (templateBlock) {
          templateBlock.setStyle({
            // display: "flex",
            // "align-self": "start",
            "text-align": "left",
          });
          this.toolBoxManager.setAttributeToSelected("tile-text-align", "left");
        }
      } else {
        const message = this.toolBoxManager.currentLanguage.getTranslation(
          "no_tile_selected_error_message"
        );
        this.toolBoxManager.ui.displayAlertMessage(message, "error");
      }
    });

    centerAlign.addEventListener("click", () => {
      if (this.toolBoxManager.editorManager.selectedTemplateWrapper) {
        const templateBlock =
          this.toolBoxManager.editorManager.selectedComponent.find(
            ".tile-title-section"
          )[0];

        if (templateBlock) {
          templateBlock.setStyle({
            // display: "flex",
            // "align-self": "center",
            "text-align": "center",
          });
          this.toolBoxManager.setAttributeToSelected(
            "tile-text-align",
            "center"
          );
        }
      } else {
        const message = this.toolBoxManager.currentLanguage.getTranslation(
          "no_tile_selected_error_message"
        );
        this.toolBoxManager.ui.displayAlertMessage(message, "error");
      }
    });

    rightAlign.addEventListener("click", () => {
      if (this.toolBoxManager.editorManager.selectedTemplateWrapper) {
        const templateBlock =
          this.toolBoxManager.editorManager.selectedComponent.find(
            ".tile-title-section"
          )[0];

        if (templateBlock) {
          templateBlock.setStyle({
            // display: "flex",
            // "align-self": "end",
            "text-align": "right",
          });
          this.toolBoxManager.setAttributeToSelected(
            "tile-text-align",
            "right"
          );
        }
      } else {
        const message = this.toolBoxManager.currentLanguage.getTranslation(
          "no_tile_selected_error_message"
        );
        this.toolBoxManager.ui.displayAlertMessage(message, "error");
      }
    });

    const iconLeftAlign = document.getElementById("icon-align-left");
    const iconCenterAlign = document.getElementById("icon-align-center");
    const iconRightAlign = document.getElementById("icon-align-right");

    iconLeftAlign.addEventListener("click", () => {
      if (this.toolBoxManager.editorManager.selectedTemplateWrapper) {
        const templateBlock =
          this.toolBoxManager.editorManager.selectedComponent.find(
            ".tile-icon-section"
          )[0];
        if (templateBlock) {
          templateBlock.setStyle({
            display: "flex",
            "align-self": "start",
          });
          this.toolBoxManager.setAttributeToSelected("tile-icon-align", "left");
        }
      } else {
        const message = this.toolBoxManager.currentLanguage.getTranslation(
          "no_tile_selected_error_message"
        );
        this.toolBoxManager.ui.displayAlertMessage(message, "error");
      }
    });

    iconCenterAlign.addEventListener("click", () => {
      if (this.toolBoxManager.editorManager.selectedTemplateWrapper) {
        const templateBlock =
          this.toolBoxManager.editorManager.selectedComponent.find(
            ".tile-icon-section"
          )[0];

        if (templateBlock) {
          templateBlock.setStyle({
            display: "flex",
            "align-self": "center",
          });
          this.toolBoxManager.setAttributeToSelected(
            "tile-icon-align",
            "center"
          );
        }
      } else {
        const message = this.toolBoxManager.currentLanguage.getTranslation(
          "no_tile_selected_error_message"
        );
        this.toolBoxManager.ui.displayAlertMessage(message, "error");
      }
    });

    iconRightAlign.addEventListener("click", () => {
      if (this.toolBoxManager.editorManager.selectedTemplateWrapper) {
        const templateBlock =
          this.toolBoxManager.editorManager.selectedComponent.find(
            ".tile-icon-section"
          )[0];

        if (templateBlock) {
          templateBlock.setStyle({
            display: "flex",
            "align-self": "end",
          });
          this.toolBoxManager.setAttributeToSelected(
            "tile-icon-align",
            "right"
          );
        } else {
        }
      } else {
        const message = this.toolBoxManager.currentLanguage.getTranslation(
          "no_tile_selected_error_message"
        );
        this.toolBoxManager.ui.displayAlertMessage(message, "error");
      }
    });
  }

  setupOpacityListener() {
    const imageOpacity = document.getElementById("bg-opacity");

    imageOpacity.addEventListener("input", (event) => {
      const value = event.target.value;

      if (this.toolBoxManager.editorManager.selectedTemplateWrapper) {
        const templateBlock =
          this.toolBoxManager.editorManager.selectedComponent;

        if (templateBlock) {
          const opacity = value / 100;
          const currentBgStyle = templateBlock.getStyle()["background-color"];
          let currentBgColor;

          if (currentBgStyle.startsWith("#")) {
            currentBgColor = hexToRgb(currentBgStyle);
          } else if (currentBgStyle.startsWith("rgb")) {
            currentBgColor = currentBgStyle.match(/\d+, \d+, \d+/)[0]; 
          } else {
            currentBgColor = "255, 255, 255"; 
          }

          console.log("currentBgColor", currentBgColor);

          templateBlock.addStyle({
            "background-color": `rgba(${currentBgColor}, ${opacity})`,
          });
        }
      }
    });
  }

  setupAutoSave() {
    setInterval(() => {
      const editors = Object.values(this.toolBoxManager.editorManager.editors);

      if (!this.toolBoxManager.previousStates) {
        this.toolBoxManager.previousStates = new Map();
      }
      if (editors && editors.length) {
        for (let index = 0; index < editors.length; index++) {
          const editorData = editors[index];
          const editor = editorData.editor;
          const pageId = editorData.pageId;

          if (!this.toolBoxManager.previousStates.has(pageId)) {
            this.toolBoxManager.previousStates.set(pageId, editor.getHtml());
          }

          const currentState = editor.getHtml();

          if (currentState !== this.toolBoxManager.previousStates.get(pageId)) {
            this.toolBoxManager.autoSavePage(editorData);

            this.toolBoxManager.previousStates.set(pageId, currentState);
          }
        }
      }
    }, 10000);
  }
}


// Content from classes/PageManager.js
class PageManager {
    constructor(toolBoxManager) {
      this.toolBoxManager = toolBoxManager;
    }
  
    loadPageTemplates() {
      const pageTemplates = document.getElementById("page-templates");
      this.toolBoxManager.templates.forEach((template, index) => {
        const blockElement = document.createElement("div");
  
        blockElement.className = "page-template-wrapper";
        // Create the number element
        const numberElement = document.createElement("div");
        numberElement.className = "page-template-block-number";
        numberElement.textContent = index + 1; // Set the number
        const templateBlock = document.createElement("div");
        templateBlock.className = "page-template-block";
        templateBlock.title = this.toolBoxManager.currentLanguage.getTranslation(
          "click_to_load_template"
        ); //
        templateBlock.innerHTML = `<div>${template.media}</div>`;
  
        blockElement.addEventListener("click", () => {
          const popup = this.toolBoxManager.popupManager.popupModal();
          document.body.appendChild(popup);
          popup.style.display = "flex";
  
          const closeButton = popup.querySelector(".close");
          closeButton.onclick = () => {
            popup.style.display = "none";
            document.body.removeChild(popup);
          };
  
          const cancelBtn = popup.querySelector("#close_popup");
          cancelBtn.onclick = () => {
            popup.style.display = "none";
            document.body.removeChild(popup);
          };
  
          const acceptBtn = popup.querySelector("#accept_popup");
          acceptBtn.onclick = () => {
            popup.style.display = "none";
            document.body.removeChild(popup);
            this.toolBoxManager.editorManager.templateManager.addFreshTemplate(
              template.content
            );
          };
        });
  
        // Append number and template block to the wrapper
        blockElement.appendChild(numberElement);
        blockElement.appendChild(templateBlock);
        pageTemplates.appendChild(blockElement);
      });
    }
  }


// Content from classes/PopupManager.js
class PopupManager {
    constructor(toolBoxManager) {
      this.toolBoxManager = toolBoxManager;
    }
  
    popupModal() {
      const popup = document.createElement("div");
      popup.className = "popup-modal";
      popup.innerHTML = `
            <div class="popup">
              <div class="popup-header">
                <span>${this.toolBoxManager.currentLanguage.getTranslation(
                  "confirmation_modal_title"
                )}</span>
                <button class="close">
                  <svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 21 21">
                      <path id="Icon_material-close" data-name="Icon material-close" d="M28.5,9.615,26.385,7.5,18,15.885,9.615,7.5,7.5,9.615,15.885,18,7.5,26.385,9.615,28.5,18,20.115,26.385,28.5,28.5,26.385,20.115,18Z" transform="translate(-7.5 -7.5)" fill="#6a747f" opacity="0.54"/>
                  </svg>
                </button>
              </div>
              <hr>
              <div class="popup-body" id="confirmation_modal_message">
                ${this.toolBoxManager.currentLanguage.getTranslation(
                  "confirmation_modal_message"
                )}
              </div>
              <div class="popup-footer">
                <button id="accept_popup" class="tb-btn tb-btn-primary">
                ${this.toolBoxManager.currentLanguage.getTranslation(
                  "accept_popup"
                )}
                </button>
                <button id="close_popup" class="tb-btn tb-btn-outline">
                ${this.toolBoxManager.currentLanguage.getTranslation(
                  "cancel_btn"
                )}
                </button>
              </div>
            </div>
          `;
  
      return popup;
    }
  }

// Content from classes/ThemeManager.js
class ThemeManager {
  constructor(toolBoxManager) {
    this.toolBoxManager = toolBoxManager;
  }

  loadTheme() {
    this.toolBoxManager.dataManager.getLocationTheme().then((theme) => {
      this.toolBoxManager.themeManager.setTheme(
        theme.SDT_LocationTheme.ThemeName
      );
    });
  }

  setTheme(themeName) {
    const theme = this.toolBoxManager.themes.find(
      (theme) => theme.name === themeName
    );
    const select = document.querySelector(".tb-custom-theme-selection");
    select.querySelector(".selected-theme-value").textContent = themeName;
    if (!theme) {
      return false;
    }

    this.toolBoxManager.currentTheme = theme;

    this.applyTheme();

    this.toolBoxManager.icons = theme.icons.map((icon) => {
      return {
        name: icon.IconName,
        svg: icon.IconSVG,
        category: icon.IconCategory,
      };
    });
    this.loadThemeIcons(theme.icons);

    this.themeColorPalette(this.toolBoxManager.currentTheme.colors);
    localStorage.setItem("selectedTheme", themeName);

    this.applyThemeIconsAndColor(themeName);

    return true;
  }

  applyTheme() {
    const root = document.documentElement;
    const iframes = document.querySelectorAll(".mobile-frame iframe");

    if (!iframes.length) return;

    root.style.setProperty(
      "--primary-color",
      this.toolBoxManager.currentTheme.colors.primaryColor
    );
    root.style.setProperty(
      "--secondary-color",
      this.toolBoxManager.currentTheme.colors.secondaryColor
    );
    root.style.setProperty(
      "--background-color",
      this.toolBoxManager.currentTheme.colors.backgroundColor
    );
    root.style.setProperty(
      "--text-color",
      this.toolBoxManager.currentTheme.colors.textColor
    );
    root.style.setProperty(
      "--button-bg-color",
      this.toolBoxManager.currentTheme.colors.buttonBgColor
    );
    root.style.setProperty(
      "--button-text-color",
      this.toolBoxManager.currentTheme.colors.buttonTextColor
    );
    root.style.setProperty(
      "--card-bg-color",
      this.toolBoxManager.currentTheme.colors.cardBgColor
    );
    root.style.setProperty(
      "--card-text-color",
      this.toolBoxManager.currentTheme.colors.cardTextColor
    );
    root.style.setProperty(
      "--accent-color",
      this.toolBoxManager.currentTheme.colors.accentColor
    );
    root.style.setProperty(
      "--font-family",
      this.toolBoxManager.currentTheme.fontFamily
    );

    iframes.forEach((iframe) => {
      const iframeDoc = iframe.contentDocument || iframe.contentWindow.document;

      if (iframeDoc && iframeDoc.body) {
        iframeDoc.body.style.setProperty(
          "--primary-color",
          this.toolBoxManager.currentTheme.colors.primaryColor
        );
        iframeDoc.body.style.setProperty(
          "--secondary-color",
          this.toolBoxManager.currentTheme.colors.secondaryColor
        );
        iframeDoc.body.style.setProperty(
          "--background-color",
          this.toolBoxManager.currentTheme.colors.backgroundColor
        );
        iframeDoc.body.style.setProperty(
          "--text-color",
          this.toolBoxManager.currentTheme.colors.textColor
        );
        iframeDoc.body.style.setProperty(
          "--button-bg-color",
          this.toolBoxManager.currentTheme.colors.buttonBgColor
        );
        iframeDoc.body.style.setProperty(
          "--button-text-color",
          this.toolBoxManager.currentTheme.colors.buttonTextColor
        );
        iframeDoc.body.style.setProperty(
          "--card-bg-color",
          this.toolBoxManager.currentTheme.colors.cardBgColor
        );
        iframeDoc.body.style.setProperty(
          "--card-text-color",
          this.toolBoxManager.currentTheme.colors.cardTextColor
        );
        iframeDoc.body.style.setProperty(
          "--accent-color",
          this.toolBoxManager.currentTheme.colors.accentColor
        );
        iframeDoc.body.style.setProperty(
          "--font-family",
          this.toolBoxManager.currentTheme.fontFamily
        );
      }
    });
  }

  applyThemeIconsAndColor(themeName) {
    const editors = Object.values(this.toolBoxManager.editorManager.editors);

    if (editors && editors.length) {
      for (let index = 0; index < editors.length; index++) {
        const editorData = editors[index];
        if (!editorData || !editorData.editor) {
          console.error(`Invalid editorData at index ${index}:`, editorData);
          return;
        }

        try {
          let editor = editorData.editor;
          // Add additional null checks
          if (!editor || typeof editor.getWrapper !== "function") {
            console.error(`Invalid editor at index ${index}:`, editor);
            continue;
          }

          const wrapper = editor.getWrapper();

          const theme = this.toolBoxManager.themes.find(
            (theme) => theme.name === themeName
          );
          const tiles = wrapper.find(".template-block");

          tiles.forEach((tile) => {
            if (!tile) return;
            // icons change and its color
            const tileIconName = tile.getAttributes()?.["tile-icon"];
            if (tileIconName) {
              const matchingIcon = theme.icons?.find(
                (icon) => icon.IconName === tileIconName
              );

              if (matchingIcon) {
                const tileIconComponent = tile.find(".tile-icon svg")?.[0];

                if (tileIconComponent) {
                  // get current icon color with null checks
                  const currentIconPath = tileIconComponent.find("path")?.[0];
                  let currentIconColor = "#7c8791"; // default color
                  if (currentIconPath && currentIconPath.getAttributes()) {
                    currentIconColor =
                      currentIconPath.getAttributes()["fill"] ||
                      currentIconColor;
                  }

                  let localizedSVG = matchingIcon.IconSVG;
                  if (localizedSVG) {
                    localizedSVG = localizedSVG.replace(
                      /fill="[^"]*"/g,
                      `fill="${currentIconColor}"`
                    );
                    tileIconComponent.replaceWith(localizedSVG);
                  }
                }
              }
            }

            const currentTileBgColorName =
              tile.getAttributes()?.["tile-bgcolor-name"];
            if (currentTileBgColorName && theme.colors) {
              const matchingColorCode = theme.colors[currentTileBgColorName];

              if (matchingColorCode) {
                tile.addAttributes({
                  "tile-bgcolor-name": currentTileBgColorName,
                  "tile-bgcolor": matchingColorCode,
                });

                tile.addStyle({
                  "background-color": matchingColorCode,
                });
              } else {
                console.warn(
                  `No matching color found for: ${currentTileBgColorName}`
                );
              }
            }
          });
        } catch (error) {
          console.error(`Error processing editor at index ${index}:`, error);
        }
      }
    }

    const iframes = document.querySelectorAll(".mobile-frame iframe");

    if (iframes === null) return;

    iframes.forEach((iframe) => {
      const iframeDoc = iframe.contentDocument || iframe.contentWindow.document;
      if (iframeDoc && iframeDoc.body) {
        iframeDoc.body.style.setProperty(
          "--font-family",
          this.toolBoxManager.currentTheme.fontFamily
        );
      }
    });
  }

  themeColorPalette(colors) {
    const colorPaletteContainer = document.getElementById(
      "theme-color-palette"
    );
    colorPaletteContainer.innerHTML = "";
    const colorEntries = Object.entries(colors);

    colorEntries.forEach(([colorName, colorValue], index) => {
      const alignItem = document.createElement("div");
      alignItem.className = "color-item";
      const radioInput = document.createElement("input");
      radioInput.type = "radio";
      radioInput.id = `color-${colorName}`;
      radioInput.name = "theme-color";
      radioInput.value = colorName;

      const colorBox = document.createElement("label");
      colorBox.className = "color-box";
      colorBox.setAttribute("for", `color-${colorName}`);
      colorBox.style.backgroundColor = colorValue;
      colorBox.setAttribute("data-tile-bgcolor", colorValue);

      alignItem.appendChild(radioInput);
      alignItem.appendChild(colorBox);

      colorPaletteContainer.appendChild(alignItem);

      colorBox.onclick = () => {
        if (this.toolBoxManager.editorManager.selectedComponent) {
          this.toolBoxManager.editorManager.selectedComponent.addStyle({
            "background-color": colorValue,
          });
          this.toolBoxManager.setAttributeToSelected(
            "tile-bgcolor",
            colorValue
          );
          this.toolBoxManager.setAttributeToSelected(
            "tile-bgcolor-name",
            colorName
          );
        } else {
          const message = this.toolBoxManager.currentLanguage.getTranslation(
            "no_tile_selected_error_message"
          );
          this.toolBoxManager.ui.displayAlertMessage(message, "error");
        }
      };
    });
  }

  colorPalette() {
    const textColorPaletteContainer =
      document.getElementById("text-color-palette");
    const iconColorPaletteContainer =
      document.getElementById("icon-color-palette");

    // Fixed color values
    const colorValues = {
      color1: "#ffffff",
      color2: "#333333",
    };

    Object.entries(colorValues).forEach(([colorName, colorValue]) => {
      const alignItem = document.createElement("div");
      alignItem.className = "color-item";

      const radioInput = document.createElement("input");
      radioInput.type = "radio";
      radioInput.id = `text-color-${colorName}`;
      radioInput.name = "text-color";
      radioInput.value = colorName;

      const colorBox = document.createElement("label");
      colorBox.className = "color-box";
      colorBox.setAttribute("for", `text-color-${colorName}`);
      colorBox.style.backgroundColor = colorValue;
      colorBox.setAttribute("data-tile-text-color", colorValue);

      alignItem.appendChild(radioInput);
      alignItem.appendChild(colorBox);
      textColorPaletteContainer.appendChild(alignItem);

      radioInput.onclick = () => {
        this.toolBoxManager.editorManager.selectedComponent.addStyle({
          color: colorValue,
        });
        this.toolBoxManager.setAttributeToSelected(
          "tile-text-color",
          colorValue
        );
      };
    });

    // Create options for icon color palette
    Object.entries(colorValues).forEach(([colorName, colorValue]) => {
      const alignItem = document.createElement("div");
      alignItem.className = "color-item";

      const radioInput = document.createElement("input");
      radioInput.type = "radio";
      radioInput.id = `icon-color-${colorName}`;
      radioInput.name = "icon-color";
      radioInput.value = colorName;

      const colorBox = document.createElement("label");
      colorBox.className = "color-box";
      colorBox.setAttribute("for", `icon-color-${colorName}`);
      colorBox.style.backgroundColor = colorValue;
      colorBox.setAttribute("data-tile-icon-color", colorValue);

      alignItem.appendChild(radioInput);
      alignItem.appendChild(colorBox);
      iconColorPaletteContainer.appendChild(alignItem);

      radioInput.onclick = () => {
        const svgIcon =
          this.toolBoxManager.editorManager.selectedComponent.find(
            ".tile-icon path"
          )[0];
        if (svgIcon) {
          svgIcon.removeAttributes("fill");
          svgIcon.addAttributes({
            fill: colorValue,
          });
          this.toolBoxManager.setAttributeToSelected(
            "tile-icon-color",
            colorValue
          );
        } else {
          const message = this.toolBoxManager.currentLanguage.getTranslation(
            "no_icon_selected_error_message"
          );
          this.toolBoxManager.ui.displayAlertMessage(message, "error");
        }
      };
    });
  }

  ctaColorPalette() {
    const ctaColorPaletteContainer =
      document.getElementById("cta-color-palette");
    const colorValues = {
      color1: "#4C9155",
      color2: "#5068A8",
      color3: "#EEA622",
      color4: "#FF6C37",
    };

    Object.entries(colorValues).forEach(([colorName, colorValue]) => {
      const colorItem = document.createElement("div");
      colorItem.className = "color-item";
      const radioInput = document.createElement("input");
      radioInput.type = "radio";
      radioInput.id = `cta-color-${colorName}`;
      radioInput.name = "cta-color";
      radioInput.value = colorName;

      const colorBox = document.createElement("label");
      colorBox.className = "color-box";
      colorBox.setAttribute("for", `cta-color-${colorName}`);
      colorBox.style.backgroundColor = colorValue;
      colorBox.setAttribute("data-cta-color", colorValue);

      colorItem.appendChild(radioInput);
      colorItem.appendChild(colorBox);
      ctaColorPaletteContainer.appendChild(colorItem);

      radioInput.onclick = () => {
        if (this.toolBoxManager.editorManager.selectedComponent) {
          const selectedComponent =
            this.toolBoxManager.editorManager.selectedComponent;

          // Search for components with either class
          const componentsWithClass = [
            ...selectedComponent.find(".cta-main-button"),
            ...selectedComponent.find(".cta-button"),
            ...selectedComponent.find(".img-button"),
            ...selectedComponent.find(".plain-button"),
          ];

          // Get the first matching component
          const button =
            componentsWithClass.length > 0 ? componentsWithClass[0] : null;

          if (button) {
            button.addStyle({
              "background-color": colorValue,
              "border-color": colorValue,
            });
          }
          this.toolBoxManager.setAttributeToSelected(
            "cta-background-color",
            colorValue
          );
        }
      };
    });
  }

  listThemesInSelectField() {
    const select = document.querySelector(".tb-custom-theme-selection");
    const button = select.querySelector(".theme-select-button");
    const selectedValue = button.querySelector(".selected-theme-value");

    // Toggle dropdown visibility
    button.addEventListener("click", (e) => {
      e.preventDefault();
      const isOpen = optionsList.classList.contains("show");
      optionsList.classList.toggle("show");
      button.classList.toggle("open");
      button.setAttribute("aria-expanded", !isOpen);
    });

    const optionsList = document.createElement("div");
    optionsList.classList.add("theme-options-list");
    optionsList.setAttribute("role", "listbox");
    optionsList.innerHTML = "";

    // Populate themes into the dropdown
    this.toolBoxManager.themes.forEach((theme, index) => {
      const option = document.createElement("div");
      option.classList.add("theme-option");
      option.setAttribute("role", "option");
      option.setAttribute("data-value", theme.name);
      option.textContent = theme.name;

      if (
        this.toolBoxManager.currentTheme &&
        theme.name === this.toolBoxManager.currentTheme.name
      ) {
        option.classList.add("selected");
      }

      option.addEventListener("click", (e) => {
        selectedValue.textContent = theme.name;

        // Mark as selected
        const allOptions = optionsList.querySelectorAll(".theme-option");
        allOptions.forEach((opt) => opt.classList.remove("selected"));
        option.classList.add("selected");

        // Close the dropdown
        optionsList.classList.remove("show");
        button.classList.remove("open");
        button.setAttribute("aria-expanded", "false");

        const themeName = theme.name;
        // update location theme
        this.toolBoxManager.dataManager.selectedTheme =
          this.toolBoxManager.themes.find((theme) => theme.name === themeName);

        this.toolBoxManager.dataManager.updateLocationTheme().then((res) => {
          if (this.toolBoxManager.checkIfNotAuthenticated(res)) {
            return;
          }

          if (this.setTheme(themeName)) {
            this.themeColorPalette(this.toolBoxManager.currentTheme.colors);

            localStorage.setItem("selectedTheme", themeName);

            const message = this.toolBoxManager.currentLanguage.getTranslation(
              "theme_applied_success_message"
            );
            const status = "success";
            this.toolBoxManager.ui.displayAlertMessage(message, status);
          } else {
            const message = this.toolBoxManager.currentLanguage.getTranslation(
              "error_applying_theme_message"
            );
            const status = "error";
            this.toolBoxManager.ui.displayAlertMessage(message, status);
          }
        });
      });

      // Append option to the options list
      optionsList.appendChild(option);
    });

    select.appendChild(optionsList);

    document.addEventListener("click", (e) => {
      if (!select.contains(e.target)) {
        optionsList.classList.remove("show");
        button.classList.remove("open");
        button.setAttribute("aria-expanded", "false");
      }
    });
  }

  loadThemeIcons(themeIconsList) {
    const themeIcons = document.getElementById("icons-list");

    let selectedCategory;

    const categoryOptions = document.querySelectorAll(".category-option");
    // selected category is where the category option has a .selected class

    categoryOptions.forEach((option) => {
      if (option.classList.contains("selected")) {
        selectedCategory = option.getAttribute("data-value");
      }
      option.addEventListener("click", () => {
        selectedCategory = option.getAttribute("data-value");
        renderIcons();
      });
    });

    const renderIcons = () => {
      themeIcons.innerHTML = "";
      const filteredIcons = themeIconsList.filter(
        (icon) => icon.IconCategory.trim() === selectedCategory
      );

      if (filteredIcons.length === 0) {
        console.log("No icons found for selected category.");
      }
      // Render filtered icons
      filteredIcons.forEach((icon) => {
        const iconItem = document.createElement("div");
        iconItem.classList.add("icon");
        iconItem.title = icon.IconName;

        const displayName = (() => {
          const maxChars = 7;
          const words = icon.IconName.split(" ");

          if (words.length > 1) {
            const firstWord = words[0];
            if (firstWord.length >= maxChars) {
              return firstWord.slice(0, maxChars) + "...";
            } else {
              return firstWord;
            }
          }

          return icon.IconName.length > maxChars
            ? icon.IconName.slice(0, maxChars) + "..."
            : icon.IconName;
        })();

        iconItem.innerHTML = `
                    ${icon.IconSVG}
                    <span class="icon-title">${displayName}</span>
                `;

        iconItem.onclick = () => {
          if (this.toolBoxManager.editorManager.selectedTemplateWrapper) {
            const iconComponent =
              this.toolBoxManager.editorManager.selectedComponent.find(
                ".tile-icon"
              )[0];

            if (iconComponent) {
              // this.changeIconFillColorToWhite(icon.IconSVG);
              iconComponent.components(this.changeIconFillColorToWhite(icon.IconSVG));
              // console.log(icon.IconSVG)
              this.toolBoxManager.setAttributeToSelected(
                "tile-icon",
                icon.IconName
              );
            }
          } else {
            const message = this.toolBoxManager.currentLanguage.getTranslation(
              "no_tile_selected_error_message"
            );
            const status = "error";
            this.toolBoxManager.ui.displayAlertMessage(message, status);
          }
        };

        themeIcons.appendChild(iconItem);
      });
    };

    renderIcons();
  }

  changeIconFillColorToWhite(iconSVG) {
    const parser = new DOMParser();
    const svgDoc = parser.parseFromString(iconSVG, "image/svg+xml");
    const pathElement = svgDoc.querySelector("path");
    if (pathElement) {
      pathElement.setAttribute("fill", "#FFFFFF");
    }
    const serializer = new XMLSerializer();
    return serializer.serializeToString(svgDoc);
  }
}



// Content from classes/ToolBoxUI.js
class ToolBoxUI {
  constructor(toolBoxManager) {
    this.manager = toolBoxManager;
    this.currentLanguage = toolBoxManager.currentLanguage;
  }

  updateTileTitle(inputTitle) {
    if (this.manager.editorManager.selectedTemplateWrapper) {
      const titleComponent =
        this.manager.editorManager.selectedComponent.find(".tile-title")[0];
      if (titleComponent) {
        titleComponent.components(inputTitle);
        // this.manager.selectedComponent.addAttributes({
        //   "tile-title": inputTitle,
        // });
      }
    }
  }

  displayAlertMessage(message, status) {
    const alertContainer = document.getElementById("alerts-container");
    const alertId = Math.random().toString(10);
    const alertBox = this.alertMessage(message, status, alertId);
    alertBox.style.display = "flex";

    const closeButton = alertBox.querySelector(".alert-close-btn");
    closeButton.addEventListener("click", () => {
      this.closeAlert(alertId);
    });

    setTimeout(() => this.closeAlert(alertId), 5000);
    alertContainer.appendChild(alertBox);
  }

  alertMessage(message, status, alertId) {
    const alertBox = document.createElement("div");
    alertBox.id = alertId;
    alertBox.classList = `alert ${status == "success" ? "success" : "error"}`;
    alertBox.innerHTML = `
        <div class="alert-header">
          <strong>
            ${
              status == "success"
                ? this.currentLanguage.getTranslation("alert_type_success")
                : this.currentLanguage.getTranslation("alert_type_error")
            }
          </strong>
          <span class="alert-close-btn">✖</span>
        </div>
        <p>${message}</p>
      `;
    return alertBox;
  }

  closeAlert(alertId) {
    const alert = document.getElementById(alertId);
    if (alert) {
      alert.style.opacity = 0;
      setTimeout(() => alert.remove(), 500);
    }
  }

  openToastMessage() {
    const toast = document.createElement("div");
    toast.id = "toast";
    toast.textContent = "Your changes are saved";

    document.body.appendChild(toast);

    setTimeout(() => {
      toast.style.opacity = "1";
      toast.style.transform = "translateX(-50%) translateY(0)";
    }, 100);

    setTimeout(() => {
      toast.style.opacity = "0";
      setTimeout(() => {
        document.body.removeChild(toast);
      }, 500);
    }, 3000);
  }

  updateTileProperties(editor, page) {
    if (page && page.PageIsContentPage) {
      this.updateContentPageProperties();
    } else {
      this.updateTemplatePageProperties();
    }
  }

  updateContentPageProperties() {
    const currentCtaBgColor =
      this.manager.editorManager.selectedComponent?.getAttributes()?.[
        "cta-background-color"
      ];
    const CtaRadios = document.querySelectorAll(
      '#cta-color-palette input[type="radio"]'
    );

    CtaRadios.forEach((radio) => {
      const colorBox = radio.nextElementSibling;
      radio.checked =
        colorBox.getAttribute("data-cta-color").toUpperCase() ===
        currentCtaBgColor.toUpperCase();
    });
  }

  updateTemplatePageProperties() {
    this.updateAlignmentProperties();
    this.updateColorProperties();
    this.updateActionProperties();
  }

  updateAlignmentProperties() {
    const alignmentTypes = [
      { type: "text", attribute: "tile-text-align" },
      { type: "icon", attribute: "tile-icon-align" },
    ];

    alignmentTypes.forEach(({ type, attribute }) => {
      const currentAlign =
        this.manager.editorManager.selectedComponent?.getAttributes()?.[
          attribute
        ];
      ["left", "center", "right"].forEach((align) => {
        document.getElementById(`${type}-align-${align}`).checked =
          currentAlign === align;
      });
    });
  }

  updateColorProperties() {
    const currentTextColor =
      this.manager.editorManager.selectedComponent?.getAttributes()?.[
        "tile-text-color"
      ];
    const textColorRadios = document.querySelectorAll(
      '.text-color-palette.text-colors .color-item input[type="radio"]'
    );
    textColorRadios.forEach((radio) => {
      const colorBox = radio.nextElementSibling;
      radio.checked =
        colorBox.getAttribute("data-tile-text-color") === currentTextColor;
    });

    // Update icon color
    const currentIconColor =
      this.manager.editorManager.selectedComponent?.getAttributes()?.[
        "tile-icon-color"
      ];
    const iconColorRadios = document.querySelectorAll(
      '.text-color-palette.icon-colors .color-item input[type="radio"]'
    );
    iconColorRadios.forEach((radio) => {
      const colorBox = radio.nextElementSibling;
      radio.checked =
        colorBox.getAttribute("data-tile-icon-color") === currentIconColor;
    });

    // Update background color
    const currentBgColor =
      this.manager.editorManager.selectedComponent?.getAttributes()?.[
        "tile-bgcolor"
      ];
    const radios = document.querySelectorAll(
      '#theme-color-palette input[type="radio"]'
    );
    radios.forEach((radio) => {
      const colorBox = radio.nextElementSibling;
      radio.checked =
        colorBox.getAttribute("data-tile-bgcolor") === currentBgColor;
    });

    // opacity
    const currentTileOpacity =
      this.manager.editorManager.selectedComponent?.getAttributes()?.[
        "tile-bg-image-opacity"
      ];
    
    const imageOpacity = document.getElementById("bg-opacity");
    imageOpacity.value = currentTileOpacity;
  }

  updateActionProperties() {
    const currentActionName =
      this.manager.editorManager.selectedComponent?.getAttributes()?.[
        "tile-action-object"
      ];
    const currentActionId =
      this.manager.editorManager.selectedComponent?.getAttributes()?.[
        "tile-action-object-id"
      ];
    const propertySection = document.getElementById("selectedOption");
    const selectedOptionElement = document.getElementById(currentActionId);

    const allOptions = document.querySelectorAll(".category-content li");
    allOptions.forEach((option) => {
      option.style.background = "";
    });
    propertySection.textContent = "Select Action"
    if (currentActionName && currentActionId && selectedOptionElement) {
      propertySection.textContent = currentActionName;
      propertySection.innerHTML += ' <i class="fa fa-angle-down"></i>';
      selectedOptionElement.style.background = "#f0f0f0";
    }
  }

  pageContentCtas(callToActions, editorInstance) {
    const contentPageCtas = document.getElementById("call-to-actions");
    this.renderCtas(callToActions, editorInstance, contentPageCtas);
    this.setupButtonLayoutListeners(editorInstance);
    this.setupBadgeClickListener(editorInstance);
  }

  renderCtas(callToActions, editorInstance, contentPageCtas) {
    contentPageCtas.innerHTML = "";
    callToActions.forEach((cta) => {
      const ctaItem = this.createCtaItem(cta);
      this.attachClickHandler(ctaItem, cta, editorInstance);
      contentPageCtas.appendChild(ctaItem);
    });
  }

  createCtaItem(cta) {
    const ctaItem = document.createElement("div");
    ctaItem.classList.add("call-to-action-item");
    ctaItem.title = cta.CallToActionName;

    const ctaType = this.getCtaType(cta.CallToActionType);
    ctaItem.innerHTML = `<i class="${ctaType.icon}"></i>`;

    return ctaItem;
  }

  getCtaType(type) {
    const ctaTypeMap = {
      Phone: {
        icon: "fas fa-phone-alt",
        iconList: ".fas.fa-phone-alt",
      },
      Email: {
        icon: "fas fa-envelope",
        iconList: ".fas.fa-envelope",
      },
      SiteUrl: {
        icon: "fas fa-link",
        iconList: ".fas.fa-link",
      },
      Form: {
        icon: "fas fa-file",
        iconList: ".fas.fa-file",
      },
    };

    return (
      ctaTypeMap[type] || {
        icon: "fas fa-question",
        iconList: ".fas.fa-question",
      }
    );
  }

  generateCtaComponent(cta, backgroundColor = "#5068a8") {
    const ctaType = this.getCtaType(cta.CallToActionType);
    return `
      <div class="cta-container-child cta-child" 
            id="id-${cta.CallToActionId}"
            data-gjs-type="cta-buttons"
            cta-button-id="${cta.CallToActionId}"
            data-gjs-draggable="false"
            data-gjs-editable="false"
            data-gjs-highlightable="false"
            data-gjs-droppable="false"
            data-gjs-resizable="false"
            data-gjs-hoverable="false"
            cta-button-label="${cta.CallToActionName}"
            cta-button-type="${cta.CallToActionType}"
            cta-button-action="${
              cta.CallToActionPhone ||
              cta.CallToActionEmail ||
              cta.CallToActionUrl
            }"
            cta-background-color="#5068a8"
          >
            <div class="cta-button" ${defaultConstraints} style="background-color: #5068a8;">
              <i class="${ctaType.icon}" ${defaultConstraints}></i>
              <div class="cta-badge" ${defaultConstraints}><i class="fa fa-minus" ${defaultConstraints}></i></div>
            </div>
            <div class="cta-label" ${defaultConstraints}>${
          cta.CallToActionName
        }</div>
      </div>
    `;
  }

  handleExistingButton(existingButton, cta, selectedComponent, editorInstance) {
    const existingBackgroundColor =
      existingButton.getAttributes()["cta-background-color"];
    const updatedCtaComponent = this.generateCtaComponent(
      cta,
      existingBackgroundColor
    );

    if (
      selectedComponent.getAttributes()["cta-button-id"] === cta.CallToActionId
    ) {
      editorInstance.once("component:add", (component) => {
        const addedComponent = editorInstance
          .getWrapper()
          .find(`#id-${cta.CallToActionId}`)[0];
        if (addedComponent) {
          editorInstance.select(addedComponent);
        }
      });
      selectedComponent.replaceWith(updatedCtaComponent);
    }
  }

  attachClickHandler(ctaItem, cta, editorInstance) {
    ctaItem.onclick = (e) => {
      e.preventDefault();
      const ctaButton = editorInstance
        .getWrapper()
        .find(".cta-button-container")[0];

      if (!ctaButton) {
        console.error("CTA Button container not found.");
        return;
      }

      const selectedComponent = this.manager.editorManager.selectedComponent;
      // if (!selectedComponent) {
      //   console.error("No selected component found.");
      //   return;
      // }

      const existingButton = ctaButton.find(`#id-${cta.CallToActionId}`)?.[0];

      if (existingButton) {
        this.handleExistingButton(
          existingButton,
          cta,
          selectedComponent,
          editorInstance
        );
        return;
      }

      ctaButton.append(this.generateCtaComponent(cta));
    };
  }

  setupButtonLayoutListeners(editorInstance) {
    this.setupPlainButtonListener(editorInstance);
    this.setupImageButtonListener(editorInstance);
  }

  // Helper method to check if component is a valid CTA
  isValidCtaComponent(attributes) {
    return attributes.hasOwnProperty("cta-button-label") &&
           attributes.hasOwnProperty("cta-button-type") &&
           attributes.hasOwnProperty("cta-button-action");
  }

  // Extract CTA attributes from component
  extractCtaAttributes(component) {
    const attributes = component.getAttributes();
    return {
      ctaId: attributes["cta-button-id"],
      ctaName: attributes["cta-button-label"],
      ctaType: attributes["cta-button-type"],
      ctaAction: attributes["cta-button-action"],
      ctaButtonBgColor: attributes["cta-background-color"]
    };
  }

  // Get icon based on CTA type
  getCtaTypeIcon(ctaType) {
    const iconMap = {
      Phone: "fas fa-phone-alt",
      Email: "fas fa-envelope",
      SiteUrl: "fas fa-link",
      Form: "fas fa-file"
    };
    return iconMap[ctaType] || "fas fa-question";
  }

  // Generate common button attributes
  getCommonButtonAttributes(ctaAttributes) {
    const { ctaId, ctaName, ctaType, ctaAction, ctaButtonBgColor } = ctaAttributes;
    return `
      data-gjs-draggable="false"
      data-gjs-editable="false"
      data-gjs-highlightable="false"
      data-gjs-droppable="false"
      data-gjs-resizable="false"
      data-gjs-hoverable="false"
      data-gjs-type="cta-buttons"
      id="id-${ctaId}"
      cta-button-id="${ctaId}"
      cta-button-label="${ctaName}"
      cta-button-type="${ctaType}"
      cta-button-action="${ctaAction}"
      cta-background-color="${ctaButtonBgColor}"
      cta-full-width="true"
    `;
  }

  // Generate plain button component
  generatePlainButtonComponent(ctaAttributes) {
    const { ctaName, ctaButtonBgColor } = ctaAttributes;
    return `
      <div class="plain-button-container" ${this.getCommonButtonAttributes(ctaAttributes)}>
        <button style="background-color: ${ctaButtonBgColor}; border-color: ${ctaButtonBgColor};" 
                class="plain-button" ${defaultConstraints}>
          <div class="cta-badge" ${defaultConstraints}>
            <i class="fa fa-minus" ${defaultConstraints}></i>
          </div>
          ${ctaName}
        </button>
      </div>
    `;
  }

  // Generate image button component
  generateImageButtonComponent(ctaAttributes) {
    const { ctaName, ctaButtonBgColor, ctaType } = ctaAttributes;
    const icon = this.getCtaTypeIcon(ctaType);
    return `
      <div class="img-button-container" ${this.getCommonButtonAttributes(ctaAttributes)}>
        <div style="background-color: ${ctaButtonBgColor}; border-color: ${ctaButtonBgColor};" 
             class="img-button" ${defaultConstraints}>
          <i class="${icon} img-button-icon" ${defaultConstraints}></i>
          <div class="cta-badge" ${defaultConstraints}>
            <i class="fa fa-minus" ${defaultConstraints}></i>
          </div>
          <span class="img-button-label" ${defaultConstraints}>${ctaName}</span>
          <i class="fa fa-angle-right img-button-arrow" ${defaultConstraints}></i>
        </div>
      </div>
    `;
  }

  // Handle component replacement
  handleComponentReplacement(editorInstance, ctaId, newComponent) {
    editorInstance.once("component:add", () => {
      const addedComponent = editorInstance.getWrapper().find(`#id-${ctaId}`)[0];
      if (addedComponent) {
        editorInstance.select(addedComponent);
      }
    });
    this.manager.editorManager.selectedComponent.replaceWith(newComponent);
  }

  // Handle button click
  handleButtonClick(editorInstance, generateComponent) {
    const ctaContainer = editorInstance.getWrapper().find(".cta-button-container")[0];
    if (!ctaContainer) return;

    const selectedComponent = this.manager.editorManager.selectedComponent;
    if (!selectedComponent) return;

    const attributes = selectedComponent.getAttributes();
    if (!this.isValidCtaComponent(attributes)) {
      const message = this.currentLanguage.getTranslation("please_select_cta_button");
      this.displayAlertMessage(message, "error");
      return;
    }

    const ctaAttributes = this.extractCtaAttributes(selectedComponent);
    const newComponent = generateComponent(ctaAttributes);
    this.handleComponentReplacement(editorInstance, ctaAttributes.ctaId, newComponent);
  }

  // Setup plain button listener
  setupPlainButtonListener(editorInstance) {
    const plainButton = document.getElementById("plain-button-layout");
    plainButton.onclick = (e) => {
      e.preventDefault();
      this.handleButtonClick(editorInstance, 
        (attrs) => this.generatePlainButtonComponent(attrs));
    };
  }

  // Setup image button listener
  setupImageButtonListener(editorInstance) {
    const imgButton = document.getElementById("img-button-layout");
    imgButton.onclick = (e) => {
      e.preventDefault();
      this.handleButtonClick(editorInstance, 
        (attrs) => this.generateImageButtonComponent(attrs));
    };
  }

  setupBadgeClickListener(editorInstance) {
    const wrapper = editorInstance.getWrapper();
    wrapper.view.el.addEventListener("click", (e) => {
      const badge = e.target.closest(".cta-badge");
      if (!badge) return;

      e.stopPropagation();

      const ctaChild = badge.closest(
        ".cta-container-child, .plain-button-container, .img-button-container"
      );
      if (ctaChild)
        if (ctaChild) {
          // Check if this is the last child in the container
          const parentContainer = ctaChild.closest(".cta-button-container");
          const childId = ctaChild.getAttribute("id");
          const component = editorInstance.getWrapper().find(`#${childId}`)[0];

          if (component) {
            component.remove();
          }
        }
    });
  }

  activateCtaBtnStyles(selectedCtaComponent) {
    if (selectedCtaComponent) {
      const isCtaButtonSelected = selectedCtaComponent.findType(".cta-buttons");
      if (isCtaButtonSelected) {
          document.querySelector(".cta-button-layout-container")
            .style.display = "flex";
      }
    }
  }
}



// Content from classes/UndoRedoManager.js
class UndoRedoManager {
    constructor(editor) {
        this.editor = editor;
        this.undoStack = [];
        this.redoStack = [];
        this.currentState = null;
        
        // Capture initial state
        this.captureState();
        
        // Bind event listeners
        this.bindEditorEvents();
    }

    bindEditorEvents() {
        // Capture state on significant changes
        this.editor.on('component:add', () => this.captureState());
        this.editor.on('component:remove', () => this.captureState());
        this.editor.on('component:update', () => this.captureState());
        this.editor.on('style:update', () => this.captureState());
    }

    captureState() {
        console.log('Capturing state...');
        // Get current project data
        const currentState = this.editor.getProjectData();
        console.log('former state: ', this.currentState);
        console.log('current state: ', currentState);
        console.log('Captured project data:', this.editor.getProjectData());

        // Prevent duplicate state captures
        if (this.areStatesEqual(currentState, this.currentState)) return;

        // Clear redo stack when a new action is performed
        this.redoStack = [];

        // Add to undo stack
        this.undoStack.push(currentState);
        
        // Limit undo stack size
        if (this.undoStack.length > 50) {
            this.undoStack.shift();
        }

        // Update current state
        this.currentState = currentState;
    }

    undo() {
        if (this.undoStack.length <= 1) return;

        // Remove current state
        const currentState = this.undoStack.pop();
        
        // Add to redo stack
        this.redoStack.push(currentState);

        // Restore previous state
        const previousState = this.undoStack[this.undoStack.length - 1];
        this.restoreState(previousState);
    }

    redo() {
        if (this.redoStack.length === 0) return;

        // Get state from redo stack
        const stateToRedo = this.redoStack.pop();
        
        // Add to undo stack
        this.undoStack.push(stateToRedo);

        // Restore redo state
        this.restoreState(stateToRedo);
    }

    restoreState(state) {
        // Clear existing components
        this.editor.DomComponents.clear();
        
        // Load project data
        this.editor.loadProjectData(state);
        
        // Update current state
        this.currentState = state;
    }

    areStatesEqual(state1, state2) {
        if (state1 === state2) return true;
        if (!state1 || !state2) return false;
    
        // Recursive deep equality check
        const deepEqual = (obj1, obj2) => {
            // Check for strict equality first
            if (obj1 === obj2) return true;
    
            // Check types and handle null/undefined
            if (obj1 === null || obj2 === null || 
                typeof obj1 !== typeof obj2) {
                return false;
            }
    
            // Handle arrays
            if (Array.isArray(obj1) && Array.isArray(obj2)) {
                if (obj1.length !== obj2.length) return false;
                return obj1.every((item, index) => deepEqual(item, obj2[index]));
            }
    
            // Handle objects
            if (typeof obj1 === 'object') {
                const keys1 = Object.keys(obj1);
                const keys2 = Object.keys(obj2);
    
                if (keys1.length !== keys2.length) return false;
    
                return keys1.every(key => 
                    keys2.includes(key) && deepEqual(obj1[key], obj2[key])
                );
            }
    
            // For primitive values
            return obj1 === obj2;
        };
    
        return deepEqual(state1, state2);
    }
    

    canUndo() {
        // Can undo if more than one state in stack
        return this.undoStack.length > 1;
    }

    canRedo() {
        // Can redo if redo stack is not empty
        return this.redoStack.length > 0;
    }
}

// Content from components/ActionListComponent.js
class ActionListComponent {
  editorManager = null;
  dataManager = null;
  toolBoxManager = null;
  selectedObject = null;
  selectedId = null;
  pageOptions = [];

  constructor(editorManager, dataManager, currentLanguage, toolBoxManager) {
    this.editorManager = editorManager;
    this.dataManager = dataManager;
    this.currentLanguage = currentLanguage;
    this.toolBoxManager = toolBoxManager;

    this.categoryData = [
      {
        name: "Page",
        label: this.currentLanguage.getTranslation("category_page"),
        options: [],
      },
      {
        name: "Service/Product Page",
        label: this.currentLanguage.getTranslation("category_services_or_page"),
        options: [],
      },
      {
        name: "Predefined Page",
        label: this.currentLanguage.getTranslation("category_predefined_page"),
        options: [],
      },
    ];
    this.init();
  }

  init() {
    this.dataManager
      .getPages()
      .then((res) => {
        if (this.toolBoxManager.checkIfNotAuthenticated(res)) {
          return;
        }

        this.pageOptions = res.SDT_PageCollection.filter(
          (page) => !page.PageIsContentPage && !page.PageIsPredefined
        );
        this.predefinedPageOptions = res.SDT_PageCollection.filter(
          (page) => page.PageIsPredefined && page.PageName != "Home"
        );
        this.servicePageOptions = this.dataManager.services.map((service) => {
          return {
            PageId: service.ProductServiceId,
            PageName: service.ProductServiceName,
          };
        });
        this.categoryData.forEach((category) => {
          if (category.name === "Page") {
            category.options = this.pageOptions;
          } else if (category.name == "Service/Product Page") {
            category.options = this.servicePageOptions;
          } else if (category.name == "Predefined Page") {
            category.options = this.predefinedPageOptions;
          }
        });

        this.populateDropdownMenu();
      })
      .catch((error) => {
        console.error("Error fetching pages:", error);
      });
  }

  mapPageNamesToOptions(pages) {
    const pageOptions = pages.map((page) => ({
      PageName: page.Name,
      PageId: page.Id,
    }));
    return pageOptions;
  }

  populateDropdownMenu() {
    const dropdownMenu = document.getElementById("dropdownMenu");
    dropdownMenu.innerHTML = "";
    this.categoryData.forEach((category) => {
      const categoryElement = this.createCategoryElement(category);
      dropdownMenu.appendChild(categoryElement);
    });

    this.setupDropdownHeader();
    this.setupOutsideClickListener();
    this.setupCategoryToggle();
    this.setupItemClickListener();
    this.setupSearchInputListener();
  }

  createCategoryElement(category) {
    const categoryElement = document.createElement("details");
    categoryElement.classList.add("category");
    categoryElement.setAttribute("data-category", category.label);

    const summaryElement = document.createElement("summary");
    summaryElement.innerHTML = `${category.label} <i class="fa fa-angle-right"></i>`;
    categoryElement.appendChild(summaryElement);

    const searchBox = document.createElement("div");
    searchBox.classList.add("search-container");
    searchBox.innerHTML = `<i class="fas fa-search search-icon"></i><input type="text" placeholder="Search" class="search-input" />`;
    categoryElement.appendChild(searchBox);

    const categoryContent = document.createElement("ul");
    categoryContent.classList.add("category-content");

    category.options.forEach((option) => {
      const optionElement = document.createElement("li");
      optionElement.textContent = option.PageName;
      optionElement.id = option.PageId;
      optionElement.dataset.category = category.name
      categoryContent.appendChild(optionElement);
    });

    const noRecordsMessage = document.createElement("li");
    noRecordsMessage.textContent = "No records found";
    noRecordsMessage.classList.add("no-records-message");
    noRecordsMessage.style.display = "none";
    categoryContent.appendChild(noRecordsMessage);

    categoryElement.appendChild(categoryContent);
    return categoryElement;
  }

  setupDropdownHeader() {
    const dropdownHeader = document.getElementById("selectedOption");
    const dropdownMenu = document.getElementById("dropdownMenu");

    if (!this.added) {
      dropdownHeader.removeEventListener("click", (e) => {});
      dropdownHeader.addEventListener("click", (e) => {
        dropdownMenu.style.display =
          dropdownMenu.style.display === "block" ? "none" : "block";
        dropdownHeader.querySelector("i").classList.toggle("fa-angle-up");
        dropdownHeader.querySelector("i").classList.toggle("fa-angle-down");
      });
    }

    this.added = true;
  }

  setupOutsideClickListener() {
    const dropdownHeader = document.getElementById("selectedOption");
    const dropdownMenu = document.getElementById("dropdownMenu");

    document.addEventListener("click", (event) => {
      if (
        !dropdownHeader.contains(event.target) &&
        !dropdownMenu.contains(event.target)
      ) {
        dropdownMenu.style.display = "none";
        dropdownHeader.querySelector("i").classList.remove("fa-angle-up");
        dropdownHeader.querySelector("i").classList.add("fa-angle-down");
      }
    });
  }

  setupCategoryToggle() {
    const categories = document.querySelectorAll(".category");

    categories.forEach((category) => {
      category.addEventListener("toggle", () => {
        this.selectedObject = category.dataset.category;
        const searchBox = category.querySelector(".search-container");
        const icon = category.querySelector("summary i");
        const isOpen = category.open;

        if (isOpen) {
          categories.forEach((otherCategory) => {
        if (otherCategory !== category) {
          otherCategory.open = false;
          otherCategory.querySelector(".search-container").style.display =
            "none";
          otherCategory
            .querySelector("summary i")
            .classList.replace("fa-angle-down", "fa-angle-right");
        }
          });
          searchBox.style.display = "block";
          icon.classList.replace("fa-angle-right", "fa-angle-down");
        } else {
          searchBox.style.display = "none";
          icon.classList.replace("fa-angle-down", "fa-angle-right");
        }
      });
    });
  }

  setupItemClickListener() {
    const dropdownHeader = document.getElementById("selectedOption");
    const dropdownMenu = document.getElementById("dropdownMenu");

    document.querySelectorAll(".category-content li").forEach((item) => {
      item.addEventListener("click", () => {
        this.selectedObject = item.dataset.category
        dropdownHeader.textContent = `${
          item.closest(".category").dataset.category
        }, ${item.textContent}`;
        const category = item.dataset.category
        const editor = this.editorManager.getCurrentEditor();
        const editorId = editor.getConfig().container;
        const editorContainerId = `${editorId}-frame`;
        if (editor.getSelected()) {
          const titleComponent = editor.getSelected().find(".tile-title")[0];
          const currentPageId = localStorage.getItem("pageId");
          const tileTitle = item.textContent.toUpperCase()
          if (currentPageId !== undefined) {
            this.toolBoxManager.setAttributeToSelected(
              "tile-action-object-id",
              item.id
            );
            this.toolBoxManager.setAttributeToSelected(
              "tile-action-object",
              `${category}, ${item.textContent}`
            );

            if (category == "Service/Product Page") {
              this.createContentPage(item.id, editorContainerId);
            }else{
              $(editorContainerId).nextAll().remove();
              this.editorManager.createChildEditor((this.editorManager.getPage(item.id)))
            }
          }

          if (titleComponent) {
            titleComponent.components(tileTitle);

            const sidebarInputTitle = document.getElementById("tile-title");
            if (sidebarInputTitle) {
              sidebarInputTitle.textContent = tileTitle;
            }
          }
        }
        dropdownHeader.innerHTML += ' <i class="fa fa-angle-down"></i>';
        dropdownMenu.style.display = "none";
      });
    });
  }

  setupSearchInputListener() {
    document.querySelectorAll(".search-input").forEach((input) => {
      input.addEventListener("input", function () {
        const filter = this.value.toLowerCase();
        const items = this.closest(".category").querySelectorAll(
          ".category-content li:not(.no-records-message)"
        );
        let hasVisibleItems = false;

        items.forEach((item) => {
          if (item.textContent.toLowerCase().includes(filter)) {
            item.style.display = "block";
            hasVisibleItems = true;
          } else {
            item.style.display = "none";
          }
        });

        const noRecordsMessage = this.closest(".category").querySelector(
          ".no-records-message"
        );
        noRecordsMessage.style.display = hasVisibleItems ? "none" : "block";
      });
    });
  }

  createContentPage(pageId, editorContainerId) {
    this.dataManager.createContentPage(pageId).then((res) => {
      if (this.toolBoxManager.checkIfNotAuthenticated(res)) {
        return;
      }
      this.dataManager.getPages().then(res=>{
        $(editorContainerId).nextAll().remove();
        this.editorManager.createChildEditor(this.editorManager.getPage(pageId))
      })
    });
  }
}


// Content from components/MappingComponent.js
class MappingComponent {
    treeContainer = document.getElementById("tree-container");
    isLoading = false;
  
    constructor(dataManager, editorManager, toolBoxManager, currentLanguage) {
      this.dataManager = dataManager;
      this.editorManager = editorManager;
      this.toolBoxManager = toolBoxManager;
      this.currentLanguage = currentLanguage;
      this.boundCreatePage = this.handleCreatePage.bind(this);
    }
  
    init() {
        this.setupEventListeners();
        //this.loadPageTree();
        this.listPagesListener();
        this.homePage = this.dataManager.pages.SDT_PageCollection.find(page=>page.PageName=="Home")
        if (this.homePage) {
            this.createPageTree(this.homePage.PageId, "tree-container")
        }
    }
  
    listPagesListener() {
      const listAllPages = document.getElementById("list-all-pages");
      listAllPages.addEventListener("click", () => {
        this.handleListAllPages();
      });
    }
  
    handleListAllPages() {
      try {
        this.dataManager.getPages().then((res) => {
          if (this.toolBoxManager.checkIfNotAuthenticated(res)) {
            return;
          }
          this.treeContainer = document.getElementById("tree-container");
          this.clearMappings();
          const newTree = this.createPageList(res.SDT_PageCollection, true);
          this.treeContainer.appendChild(newTree);
          this.hidePagesList();
        });
      } catch (error) {
        this.displayMessage("Error loading pages", "error");
      } finally {
        this.isLoading = false;
      }
    }
  
    hidePagesList() {
        const listAllPages = document.getElementById("list-all-pages");
        listAllPages.style.display = "none";

        const hidePagesList = document.getElementById("hide-pages");
        hidePagesList.style.display = "block";

        hidePagesList.addEventListener("click", () => {
            listAllPages.style.display = "block";
            hidePagesList.style.display = "none";
            this.createPageTree(this.homePage.PageId, "tree-container");
        });
    }
  
    getPage(pageId) {
      return this.dataManager.pages.SDT_PageCollection.find(
        (page) => page.PageId == pageId
      );
    }

    createPageTree(rootPageId, childDivId){
        let homePage = this.getPage(rootPageId)
        let homePageJSON = JSON.parse(homePage.PageGJSJson)
        const pages = homePageJSON.pages;
        const containerRows =
            pages[0].frames[0].component.components[0].components[0].components;

        let childPages = []

        containerRows.forEach(containerRow => {
            let templateWrappers = containerRow.components
            if(templateWrappers) {
                templateWrappers.forEach(templateWrapper => {
                    let templateBlocks = templateWrapper.components
                    templateBlocks.forEach(templateBlock => {
                        if (templateBlock.classes.includes("template-block")) {
                            let pageId = templateBlock.attributes["tile-action-object-id"]
                            let page = this.getPage(pageId)
                            if (page) {
                                childPages.push({Id: pageId, Name:page.PageName, IsContentPage:page.PageIsContentPage})
                            }
                        }
                    })
                })
            }
        })
        const newTree = this.createTree(childPages, true);
        this.treeContainer = document.getElementById(childDivId)
        this.clearMappings();
        this.treeContainer.appendChild(newTree);
    }
  
    setupEventListeners() {
      const createPageButton = document.getElementById("page-submit");
      const pageInput = document.getElementById("page-title");
  
      createPageButton.removeEventListener("click", this.boundCreatePage);
  
      pageInput.addEventListener("input", () => {
        createPageButton.disabled = !pageInput.value.trim() || this.isLoading;
      });
  
      createPageButton.addEventListener("click", this.boundCreatePage);
    }
  
    async loadPageTree() {
      if (this.isLoading) return;
  
      try {
        this.isLoading = true;
        this.dataManager.getPagesService().then((res) => {
          if (this.toolBoxManager.checkIfNotAuthenticated(res)) {
            return;
          }
  
          console.log(res);
          const newTree = this.createTree(res.SDT_PageStructureCollection, true);
          this.clearMappings();
          this.treeContainer.appendChild(newTree);
        });
      } catch (error) {
        this.displayMessage("Error loading pages", "error");
      } finally {
        this.isLoading = false;
      }
    }
  
    async handleCreatePage(e) {
      e.preventDefault();
  
      if (this.isLoading) return;
  
      const pageInput = document.getElementById("page-title");
      const createPageButton = document.getElementById("page-submit");
      const pageTitle = pageInput.value.trim();
  
      if (!pageTitle) return;
  
      try {
        this.isLoading = true;
        createPageButton.disabled = true;
        pageInput.disabled = true; // Disable input during creation
        // Create the page
        await this.dataManager
          .createNewPage(pageTitle, this.toolBoxManager.currentTheme)
          .then((res) => {
            if (this.toolBoxManager.checkIfNotAuthenticated(res)) {
              return;
            }
  
            pageInput.value = "";
  
            this.clearMappings();
  
            this.dataManager.getPages().then((res) => {
              this.handleListAllPages();
              this.toolBoxManager.actionList.init();
  
              this.displayMessage(
                `${this.currentLanguage.getTranslation("page_created")}`,
                "success"
              );
            });
          });
      } catch (error) {
        this.displayMessage(
          `${this.currentLanguage.getTranslation("error_creating_page")}`,
          "error"
        );
      } finally {
        this.isLoading = false;
        createPageButton.disabled = !pageInput.value.trim();
        pageInput.disabled = false; // Re-enable input
      }
    }
  
    clearMappings() {
      while (this.treeContainer.firstChild) {
        this.treeContainer.removeChild(this.treeContainer.firstChild);
      }
    }
  
    createTree(data) {
      console.log("Creating tree with data:", data);
      const buildListItem = (item) => {
        const listItem = document.createElement("li");
        listItem.classList.add("tb-custom-list-item");
        const childDiv = document.createElement("div");
        childDiv.classList.add("child-div");
        childDiv.id = `child-div-${item.Id}`;
        childDiv.style.position = "relative";
        childDiv.style.paddingLeft = "20px";
  
        const menuItem = document.createElement("div");
        menuItem.classList.add("tb-custom-menu-item");
  
            const toggle = document.createElement("span");
            toggle.classList.add("tb-dropdown-toggle");
            toggle.setAttribute("role", "button");
            toggle.setAttribute("aria-expanded", "false");
            const icon = 'fa-caret-right tree-icon'
            toggle.innerHTML = `<i class="fa ${icon}"></i><span>${item.Name}</span>`;
  
        // const deleteIcon = document.createElement("i");
        // deleteIcon.classList.add("fa-regular", "fa-trash-can", "tb-delete-icon");
        // deleteIcon.setAttribute("data-id", item.Id);
  
        // deleteIcon.addEventListener("click", (event) =>
        //   handleDelete(event, item.Id, listItem)
        // );
  
        menuItem.appendChild(toggle);
        listItem.appendChild(menuItem);
        listItem.appendChild(childDiv);
        if (item.Children) {
          const dropdownMenu = document.createElement("ul");
          dropdownMenu.classList.add("tb-tree-dropdown-menu");
  
          item.Children.forEach((child) => {
            const dropdownItem = buildDropdownItem(child, item);
            dropdownMenu.appendChild(dropdownItem);
          });
  
          listItem.appendChild(dropdownMenu);
          listItem.classList.add("tb-dropdown");
  
          listItem.addEventListener("click", (e) =>
            toggleDropdown(e, listItem, menuItem)
          );
        }
  
            listItem.addEventListener("click", (e) => {
                e.stopPropagation();
                this.handlePageSelection(item);
                this.createPageTree(item.Id, `child-div-${item.Id}`)
            });
  
        return listItem;
      };
  
      const buildDropdownItem = (child, parent) => {
        const dropdownItem = document.createElement("li");
        dropdownItem.classList.add("tb-dropdown-item");
        dropdownItem.innerHTML = `<span><i style="margin-right: 10px;" class="fa-regular fa-file tree-icon"></i>${child.Name}</span>`;
  
        dropdownItem.addEventListener("click", (e) => {
          e.stopPropagation();
          this.handlePageSelection(child, true, parent);
        });
  
        return dropdownItem;
      };
  
      const toggleDropdown = (event, listItem, menuItem) => {
        event.stopPropagation();
  
        const isActive = listItem.classList.contains("active");
  
        document.querySelectorAll(".tb-dropdown.active").forEach((dropdown) => {
          dropdown.classList.remove("active");
          dropdown
            .querySelector(".tb-dropdown-toggle")
            .setAttribute("aria-expanded", "false");
          dropdown
            .querySelector(".tb-custom-menu-item")
            .classList.remove("active-tree-item");
        });
  
        if (!isActive) {
          listItem.classList.add("active");
          menuItem.classList.add("active-tree-item");
          listItem
            .querySelector(".tb-dropdown-toggle")
            .setAttribute("aria-expanded", "true");
        } else {
          menuItem.classList.remove("active-tree-item");
          listItem
            .querySelector(".tb-dropdown-toggle")
            .setAttribute("aria-expanded", "false");
        }
      };
  
      const container = document.createElement("ul");
      container.classList.add("tb-custom-list");
  
      const sortedData = JSON.parse(JSON.stringify(data)).sort((a, b) =>
        a.Name === "Home" ? -1 : b.Name === "Home" ? 1 : 0
      );
  
      sortedData.forEach((item) => {
        const listItem = buildListItem(item);
        container.appendChild(listItem);
      });
  
      return container;
    }
  
    createPageList(data) {
      const buildListItem = (item) => {
        const listItem = document.createElement("li");
        listItem.classList.add("tb-custom-list-item");
  
        const menuItem = document.createElement("div");
        menuItem.classList.add("tb-custom-menu-item");
        menuItem.classList.add("page-list-items");
  
        const toggle = document.createElement("span");
        toggle.style.textTransform = "capitalize";
        toggle.classList.add("tb-dropdown-toggle");
        toggle.setAttribute("role", "button");
        toggle.setAttribute("aria-expanded", "false");
        toggle.innerHTML = `<i class="fa-regular fa-file tree-icon"></i><span>&nbsp; ${item.PageName}</span>`;
  
        const deleteIcon = document.createElement("i");
        deleteIcon.classList.add("fa-regular", "fa-trash-can", "tb-delete-icon");
        deleteIcon.setAttribute("data-id", item.Id);
  
        deleteIcon.addEventListener("click", (event) =>
          handleDelete(event, item.PageId, listItem)
        );
  
        menuItem.appendChild(toggle);
        if (item.Name !== "Home") {
          menuItem.appendChild(deleteIcon);
        }
        listItem.appendChild(menuItem);
  
        // listItem.addEventListener("click", (e) => {
        //     e.stopPropagation();
        //     this.handlePageSelection(item);
        // });
  
        return listItem;
      };
  
      const handleDelete = (event, id, elementToRemove) => {
        event.stopPropagation();
        const title = "Delete Page";
        const message = "Are you sure you want to delete this page?";
        const popup = this.popupModal(title, message);
        document.body.appendChild(popup);
        popup.style.display = "flex";
  
        const deleteButton = popup.querySelector("#yes_delete");
        const closeButton = popup.querySelector("#close_popup");
        const closePopup = popup.querySelector(".close");
  
        deleteButton.addEventListener("click", () => {
          if (this.dataManager.deletePage(id)) {
            elementToRemove.remove();
            this.displayMessage(
              `${this.currentLanguage.getTranslation("page_deleted")}`,
              "success"
            );
          } else {
            this.displayMessage(
              `${this.currentLanguage.getTranslation(
                "error_while_deleting_page"
              )}`,
              "error"
            );
          }
          popup.remove();
        });
  
        closeButton.addEventListener("click", () => {
          popup.remove();
        });
  
        closePopup.addEventListener("click", () => {
          popup.remove();
        });
      };
  
      const container = document.createElement("ul");
      container.classList.add("tb-custom-list");
  
      const sortedData = JSON.parse(JSON.stringify(data)).sort((a, b) =>
        a.PageName === "Home" ? -1 : b.PageName === "Home" ? 1 : 0
      );
  
      sortedData.forEach((item) => {
        const listItem = buildListItem(item);
        container.appendChild(listItem);
      });
  
      return container;
    }
  
    popupModal(title, message) {
      const popup = document.createElement("div");
      popup.className = "popup-modal";
      popup.innerHTML = `
            <div class="popup">
              <div class="popup-header">
                <span>${title}</span>
                <button class="close">
                  <svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 21 21">
                      <path id="Icon_material-close" data-name="Icon material-close" d="M28.5,9.615,26.385,7.5,18,15.885,9.615,7.5,7.5,9.615,15.885,18,7.5,26.385,9.615,28.5,18,20.115,26.385,28.5,28.5,26.385,20.115,18Z" transform="translate(-7.5 -7.5)" fill="#6a747f" opacity="0.54"/>
                  </svg>
                </button>
              </div>
              <hr>
              <div class="popup-body" id="confirmation_modal_message">
                ${message}
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
          `;
  
      return popup;
    }
  
    async handlePageSelection(item, isChild = false, parent = null) {
      if (this.isLoading) return;
  
      try {
        this.isLoading = true;
        // Locate the page data
        const page = this.dataManager.pages.SDT_PageCollection.find(
          (page) => page.PageId === item.Id
        );
        if (!page) throw new Error(`Page with ID ${item.Id} not found`);
  
        const editors = Object.values(this.editorManager.editors);
        const mainEditor = editors[0];
  
        if (mainEditor) {
          const editor = mainEditor.editor;
          const editorId = editor.getConfig().container;
          const editorContainerId = `${editorId}-frame`;
  
          if (isChild) {
            if (parent?.Id) {
              const parentEditorId = editors[1].editor.getConfig().container;
              document
                .querySelector(`${parentEditorId}-frame`)
                .nextElementSibling?.remove();
              this.editorManager.createChildEditor(page);
            }
          } else {
            // Remove extra frames
            $(editorContainerId).nextAll().remove();
            this.editorManager.createChildEditor(page);
          }
        }
      } catch (error) {
        this.displayMessage("Error loading page", "error");
      } finally {
        this.isLoading = false;
      }
    }
  
    checkActivePage(id) {
      return localStorage.getItem("pageId") === id;
    }
  
    updateActivePageName() {
      return this.editorManager.getCurrentPageName();
    }
  
    displayMessage(message, status) {
      this.toolBoxManager.ui.displayAlertMessage(message, status);
    }
  }
  

// Content from components/MediaComponent.js
class MediaComponent {
  constructor(dataManager, editorManager, currentLanguage, toolBoxManager) {
    this.dataManager = dataManager;
    this.editorManager = editorManager;
    this.toolBoxManager = toolBoxManager;
    this.currentLanguage = currentLanguage;
    this.selectedFile = null;
    this.init();
  }

  init() {
    this.setupFileManager();
  }

  formatFileSize(bytes) {
    if (bytes < 1024) return `${bytes} B`;
    if (bytes < 1024 * 1024) return `${Math.round(bytes / 1024)} KB`;
    if (bytes < 1024 * 1024 * 1024)
      return `${Math.round(bytes / 1024 / 1024)} MB`;
    return `${Math.round(bytes / 1024 / 1024 / 1024)} GB`;
  }

  createModalHeader() {
    const header = document.createElement("div");
    header.className = "tb-modal-header";
    header.innerHTML = `
          <h2>${this.currentLanguage.getTranslation(
            "file_upload_modal_title"
          )}</h2>
          <span class="close">
            <svg xmlns="http://www.w3.org/2000/svg" width="21" height="21" viewBox="0 0 21 21">
              <path id="Icon_material-close" data-name="Icon material-close" d="M28.5,9.615,26.385,7.5,18,15.885,9.615,7.5,7.5,9.615,15.885,18,7.5,26.385,9.615,28.5,18,20.115,26.385,28.5,28.5,26.385,20.115,18Z" transform="translate(-7.5 -7.5)" fill="#6a747f" opacity="0.54"/>
            </svg>
          </span>
        `;
    return header;
  }

  createUploadArea() {
    const uploadArea = document.createElement("div");
    uploadArea.className = "upload-area";
    uploadArea.id = "uploadArea";
    uploadArea.innerHTML = `
          <svg xmlns="http://www.w3.org/2000/svg" width="40.999" height="28.865" viewBox="0 0 40.999 28.865">
            <path id="Path_1040" data-name="Path 1040" d="M21.924,11.025a3.459,3.459,0,0,0-3.287,3.608,3.459,3.459,0,0,0,3.287,3.608,3.459,3.459,0,0,0,3.287-3.608A3.459,3.459,0,0,0,21.924,11.025ZM36.716,21.849l-11.5,14.432-8.218-9.02L8.044,39.89h41Z" transform="translate(-8.044 -11.025)" fill="#afadad"/>
          </svg>
          <div class="upload-text">
            ${this.currentLanguage.getTranslation("upload_section_text")}
          </div>
        `;

    // Add drag and drop event listeners
    this.setupDragAndDrop(uploadArea);

    return uploadArea;
  }

  setupDragAndDrop(uploadArea) {
    ["dragenter", "dragover", "dragleave", "drop"].forEach((eventName) => {
      uploadArea.addEventListener(eventName, preventDefaults, false);
      document.body.addEventListener(eventName, preventDefaults, false);
    });

    ["dragenter", "dragover"].forEach((eventName) => {
      uploadArea.addEventListener(eventName, () => {
        uploadArea.classList.add("drag-over");
      });
    });

    ["dragleave", "drop"].forEach((eventName) => {
      uploadArea.addEventListener(eventName, () => {
        uploadArea.classList.remove("drag-over");
      });
    });

    uploadArea.addEventListener("drop", (e) => {
      const files = Array.from(e.dataTransfer.files);
      this.handleDroppedFiles(files);
    });

    function preventDefaults(e) {
      e.preventDefault();
      e.stopPropagation();
    }
  }

  handleDroppedFiles(files) {
    const validFiles = files.filter((file) =>
      ["image/jpeg", "image/jpg", "image/png"].includes(file.type)
    );

    if (validFiles.length !== files.length) {
      this.toolBoxManager.ui.displayAlertMessage(
        `${this.currentLanguage.getTranslation("invalid_file_type_message")}`,
        "error"
      );
    }

    const fileList = document.querySelector("#fileList");
    if (!fileList) return;

    validFiles.forEach((file) => {
      const imageName = `${Date.now()}-${file.name}`;
      this.processUploadedFile(file, imageName, fileList);
    });
  }

  createModalActions() {
    const actions = document.createElement("div");
    actions.className = "modal-actions";
    actions.innerHTML = `
          <button class="tb-btn tb-btn-outline" id="cancelBtn">${this.currentLanguage.getTranslation(
            "cancel_btn"
          )}</button>
          <button class="tb-btn tb-btn-primary" id="saveBtn">${this.currentLanguage.getTranslation(
            "save_btn"
          )}</button>
        `;
    return actions;
  }

  openFileUploadModal() {
    const modal = document.createElement("div");
    modal.className = "tb-modal";

    const modalContent = document.createElement("div");
    modalContent.className = "tb-modal-content";

    const fileListHtml = this.createExistingFileListHTML();

    modalContent.appendChild(this.createModalHeader());
    modalContent.appendChild(this.createUploadArea());

    const fileListContainer = document.createElement("div");
    fileListContainer.className = "file-list";
    fileListContainer.id = "fileList";
    fileListContainer.innerHTML = fileListHtml;
    modalContent.appendChild(fileListContainer);

    modalContent.appendChild(this.createModalActions());

    modal.appendChild(modalContent);
    return modal;
  }

  createExistingFileListHTML() {
    const removeBeforeFirstHyphen = (str) => str.split("-").slice(1).join("-");
    return this.dataManager.media
      .map(
        (file) => `
                <div class="file-item valid" 
                    data-MediaId="${file.MediaId}" 
                    data-MediaUrl="${file.MediaUrl}" 
                    data-MediaName="${file.MediaName}">
                  <img src="${file.MediaUrl}" alt="${
          file.MediaName
        }" class="preview-image">
                  <div class="file-info">
                    <div class="file-name">${removeBeforeFirstHyphen(
                      file.MediaName
                    )}</div>
                    <div class="file-size">${this.formatFileSize(
                      file.MediaSize
                    )}</div>
                  </div>
                  <span class="status-icon" style="color: green;"></span>
                  <span title="Delete file" class="delete-media fa-regular fa-trash-can" data-mediaid="${
                    file.MediaId
                  }"></span>
                </div>
              `
      )
      .join("");
  }

  setupFileManager() {
    const openModal = document.getElementById("image-bg");
    const fileInputField = this.createFileInputField();
    const modal = this.openFileUploadModal();

    let allUploadedFiles = [];

    openModal.addEventListener("click", (e) => {
      e.preventDefault();
      this.handleModalOpen(modal, fileInputField, allUploadedFiles);
    });
  }

  createFileInputField() {
    const fileInputField = document.createElement("input");
    fileInputField.type = "file";
    fileInputField.multiple = true;
    fileInputField.accept = "image/jpeg, image/jpg, image/png";
    fileInputField.id = "fileInput";
    fileInputField.style.display = "none";
    return fileInputField;
  }

  handleModalOpen(modal, fileInputField, allUploadedFiles) {
    if (!this.editorManager.selectedComponent) {
      this.toolBoxManager.ui.displayAlertMessage(
        `${this.currentLanguage.getTranslation(
          "no_tile_selected_error_message"
        )}`,
        "error"
      );
      return;
    }

    $(".delete-media").on("click", (e) => {
      e.stopPropagation();
      const mediaId = e.target.dataset.mediaid;
      if (mediaId) {
        this.deleteMedia(mediaId);
      }
    });

    document.body.appendChild(modal);
    document.body.appendChild(fileInputField);

    this.setupModalEventListeners(modal, fileInputField, allUploadedFiles);
  }

  setupModalEventListeners(modal, fileInputField, allUploadedFiles) {
    this.addFileItemClickListeners(modal);
    this.addDeleteMediaListeners(modal);
    this.setupModalInteractions(modal, fileInputField, allUploadedFiles);

    // Add drag and drop styling
    const style = document.createElement("style");
    style.textContent = `
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
        `;
    document.head.appendChild(style);
  }

  addFileItemClickListeners(modal) {
    const fileItems = modal.querySelectorAll(".file-item");
    fileItems.forEach((element) => {
      element.addEventListener("click", () => {
        this.mediaFileClicked(element);
      });
    });
  }

  addDeleteMediaListeners(modal) {
    $(modal)
      .find(".delete-media")
      .on("click", (e) => {
        const mediaId = e.target.dataset.mediaid;
        if (mediaId) {
          const popup = this.popupModal(
            `${this.currentLanguage.getTranslation(
              "delete_media_modal_title"
            )}`,
            `${this.currentLanguage.getTranslation(
              "delete_media_modal_message"
            )}`
          );
          document.body.appendChild(popup);
          popup.style.display = "flex";

          this.setupPopupButtonListeners(popup, mediaId);
        }
      });
  }

  setupPopupButtonListeners(popup, mediaId) {
    const confirmButton = popup.querySelector("#yes_delete");
    confirmButton.onclick = () => {
      this.deleteMedia(mediaId);
      popup.style.display = "none";
    };

    const cancelButton = popup.querySelector("#close_popup");
    cancelButton.onclick = () => {
      popup.style.display = "none";
    };

    const closePopup = popup.querySelector(".close");
    closePopup.addEventListener("click", () => {
      popup.remove();
    });
  }

  setupModalInteractions(modal, fileInputField, allUploadedFiles) {
    const uploadArea = modal.querySelector("#uploadArea");
    const fileList = modal.querySelector("#fileList");
    const closeButton = modal.querySelector(".close");
    const cancelBtn = modal.querySelector("#cancelBtn");
    const saveBtn = modal.querySelector("#saveBtn");

    uploadArea.onclick = () => fileInputField.click();

    fileInputField.onchange = (event) => {
      this.handleFileInputChange(event, allUploadedFiles, fileList);
    };

    closeButton.onclick = cancelBtn.onclick = () => {
      this.closeModal(modal, fileInputField);
    };

    saveBtn.onclick = () => {
      this.saveSelectedFile(modal, fileInputField);
    };

    modal.style.display = "flex";
  }

  handleFileInputChange(event, allUploadedFiles, fileList) {
    const newFiles = Array.from(event.target.files).filter((file) =>
      ["image/jpeg", "image/jpg", "image/png"].includes(file.type)
    );
    allUploadedFiles.push(...newFiles);

    newFiles.forEach((file) => {
      const imageName = `${Date.now()}-${file.name}`;
      this.processUploadedFile(file, imageName, fileList);
    });
  }

  async processUploadedFile(file, imageName, fileList) {
    try {
      const imageCropper = new ImageCropper(532, 250);
      const croppedBlob = await imageCropper.cropImage(file);

      const croppedFile = new File([croppedBlob], file.name, {
        type: file.type,
      });

      const dataUrl = imageCropper.getDataURL();

      const response = await this.dataManager.uploadFile(
        dataUrl,
        imageName,
        croppedFile.size,
        croppedFile.type
      );

      if (this.toolBoxManager.checkIfNotAuthenticated(response)) {
        return;
      }

      if (response.BC_Trn_Media.MediaId) {
        this.dataManager.media.push(response.BC_Trn_Media);
        this.displayMediaFile(fileList, response.BC_Trn_Media);
      }
    } catch (error) {
      console.error('Failed to process image:', error);
    }
  }

  displayMediaFile(fileList, file) {
    const fileItem = document.createElement("div");
    fileItem.className = `file-item ${
      this.validateFile(file) ? "valid" : "invalid"
    }`;
    fileItem.setAttribute("data-mediaid", file.MediaId);

    const removeBeforeFirstHyphen = (str) => str.split("-").slice(1).join("-");

    const isValid = this.validateFile(file);
    fileItem.innerHTML = `
          <img src="${
            file.MediaUrl
          }" alt="File thumbnail" class="preview-image">
          <div class="file-info">
            <div class="file-name">${removeBeforeFirstHyphen(
              file.MediaName
            )}</div>
            <div class="file-size">${this.formatFileSize(file.MediaSize)}</div>
          </div>
          <span class="status-icon" style="color: ${isValid ? "green" : "red"}">
            ${isValid ? "" : "⚠"}
          </span>
          <span class="delete-media fa-regular fa-trash-can" data-mediaid="${
            file.MediaId
          }"></span>
        `;

    fileItem.onclick = () => {
      if (!fileItem.classList.contains("invalid")) {
        this.mediaFileClicked(fileItem);
      }
    };

    $(fileItem)
      .find(".delete-media")
      .on("click", (e) => {
        const mediaId = e.target.dataset.mediaid;
        if (mediaId) {
          const popup = this.popupModal(
            `${this.currentLanguage.getTranslation(
              "delete_media_modal_title"
            )}`,
            `${this.currentLanguage.getTranslation(
              "delete_media_modal_message"
            )}`
          );
          document.body.appendChild(popup);
          popup.style.display = "flex";

          this.setupPopupButtonListeners(popup, mediaId);
        }
      });
    fileList.insertBefore(fileItem, fileList.firstChild);
  }

  validateFile(file) {
    const isValidSize = file.MediaSize <= 2 * 1024 * 1024;
    const isValidType = ["image/jpeg", "image/jpg", "image/png"].includes(
      file.MediaType
    );
    return isValidSize && isValidType;
  }

  closeModal(modal, fileInputField) {
    modal.style.display = "none";
    document.body.removeChild(modal);
    document.body.removeChild(fileInputField);
  }

  saveSelectedFile(modal, fileInputField) {
    if (this.selectedFile) {
      const templateBlock = this.editorManager.selectedComponent;
      console.log(templateBlock)
      templateBlock.addStyle({
        "background-image": `url(${this.selectedFile.MediaUrl})`,
        "background-size": "cover",
        "background-position": "center",
        "background-blend-mode": "overlay",
      });
      this.toolBoxManager.setAttributeToSelected(
        "tile-bg-image-url",
        this.selectedFile.MediaUrl
      );
      this.toolBoxManager.checkTileBgImage();
    }

    this.closeModal(modal, fileInputField);
  }

  mediaFileClicked(fileItem) {
    if (fileItem.classList.contains("invalid")) return;

    document.querySelector(".modal-actions").style.display = "flex";

    // Reset other file items
    document.querySelectorAll(".file-item").forEach((el) => {
      el.classList.remove("selected");
      const icon = el.querySelector(".status-icon");
      if (icon) {
        icon.innerHTML = el.classList.contains("invalid") ? "⚠" : "";
      }
    });

    // Select current file item
    fileItem.classList.add("selected");
    let statusIcon = fileItem.querySelector(".status-icon");
    statusIcon.innerHTML = `
          <svg xmlns="http://www.w3.org/2000/svg" width="18" height="13.423" viewBox="0 0 18 13.423">
            <path id="Icon_awesome-check" d="M6.114,17.736l-5.85-5.85a.9.9,0,0,1,0-1.273L1.536,9.341a.9.9,0,0,1,1.273,0L6.75,13.282l8.441-8.441a.9.9,0,0,1,1.273,0l1.273,1.273a.9.9,0,0,1,0,1.273L7.386,17.736A.9.9,0,0,1,6.114,17.736Z" transform="translate(0 -4.577)" fill="#3a9341"/>
          </svg>
        `;
    statusIcon.style.color = "green";

    // Find and set selected file
    this.selectedFile = this.dataManager.media.find(
      (file) => file.MediaId == fileItem.dataset.mediaid
    );
  }

  deleteMedia(mediaId) {
    this.dataManager
      .deleteMedia(mediaId)
      .then((res) => {
        if (this.toolBoxManager.checkIfNotAuthenticated(res)) {
          return;
        }

        if (res.result === "success") {
          // Remove the media item from the DOM
          const mediaItem = document.querySelector(
            `[data-mediaid="${mediaId}"]`
          );
          if (mediaItem) {
            mediaItem.remove();
          }

          const modalActions = document.querySelector(".modal-actions");
          if (!this.dataManager.media || this.dataManager.media.length === 0) {
            modalActions.style.display = "none";
          }
          // Provide feedback to the user
          this.toolBoxManager.ui.displayAlertMessage(
            `${this.currentLanguage.getTranslation(
              "media_deleted_successfully"
            )}`,
            "success"
          );
          this.checkAndHideModalActions();
        } else {
          this.toolBoxManager.ui.displayAlertMessage(
            `${this.currentLanguage.getTranslation("failed_to_delete_media")}`,
            "error"
          );
        }
      })
      .catch((error) => {
        console.error("Error deleting media file:", error);
        this.toolBoxManager.ui.displayAlertMessage(
          `${this.currentLanguage.getTranslation(
            "error_during_deleting_media"
          )}`,
          "error"
        );
      });
  }

  popupModal(title, message) {
    const popup = document.createElement("div");
    popup.className = "popup-modal";
    popup.innerHTML = `
          <div class="popup">
            <div class="popup-header">
              <span>${title}</span>
              <button class="close">
                <svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 21 21">
                  <path id="Icon_material-close" data-name="Icon material-close" d="M28.5,9.615,26.385,7.5,18,15.885,9.615,7.5,7.5,9.615,15.885,18,7.5,26.385,9.615,28.5,18,20.115,26.385,28.5,28.5,26.385,20.115,18Z" transform="translate(-7.5 -7.5)" fill="#6a747f" opacity="0.54"/>
                </svg>
              </button>
            </div>
            <hr>
            <div class="popup-body" id="confirmation_modal_message">
              ${message}
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
        `;
    return popup;
  }

  checkAndHideModalActions() {
    const fileList = document.querySelector("#fileList");
    const modalActions = document.querySelector(".modal-actions");

    if (fileList && fileList.children.length === 0) {
      modalActions.style.display = "none";
    } else {
      modalActions.style.display = "flex";
    }
  }
}


// Content from classes/ImageCropper.js
class ImageCropper {
    constructor(targetWidth = 532, targetHeight = 250) {
        this.targetWidth = targetWidth;
        this.targetHeight = targetHeight;
        this.canvas = document.createElement('canvas');
        this.ctx = this.canvas.getContext('2d');
    }

    /**
     * Crop image from either File or URL
     * @param {File|string} source - Image file or URL
     * @returns {Promise<Blob>} - Promise resolving to cropped image blob
     */
    async cropImage(source) {
        try {
            let img;
            if (typeof source === 'string') {
                // Handle URL
                img = await this.loadImageFromURL(source);
            } else if (source instanceof File) {
                // Handle File object
                if (!source.type.startsWith('image/')) {
                    throw new Error('File must be an image');
                }
                const imageData = await this.readFileAsDataURL(source);
                img = await this.loadImage(imageData);
            } else {
                throw new Error('Source must be either a File or URL string');
            }

            // Get the original file type or default to 'image/jpeg'
            const fileType = source instanceof File ? source.type : 'image/jpeg';
            return this.cropAndResize(img, fileType);
        } catch (error) {
            throw new Error(`Failed to crop image: ${error.message}`);
        }
    }

    /**
     * Load image from URL
     * @private
     */
    loadImageFromURL(url) {
        return new Promise((resolve, reject) => {
            const img = new Image();
            // Handle CORS issues
            img.crossOrigin = 'anonymous';
            img.onload = () => resolve(img);
            img.onerror = () => reject(new Error('Failed to load image from URL'));
            img.src = url;
        });
    }

    /**
     * Read file as Data URL
     * @private
     */
    readFileAsDataURL(file) {
        return new Promise((resolve, reject) => {
            const reader = new FileReader();
            reader.onload = (e) => resolve(e.target.result);
            reader.onerror = (e) => reject(e);
            reader.readAsDataURL(file);
        });
    }

    /**
     * Load image from Data URL
     * @private
     */
    loadImage(dataUrl) {
        return new Promise((resolve, reject) => {
            const img = new Image();
            img.onload = () => resolve(img);
            img.onerror = () => reject(new Error('Failed to load image'));
            img.src = dataUrl;
        });
    }

    /**
     * Crop and resize image maintaining aspect ratio
     * @private
     */
    cropAndResize(img, fileType) {
        this.canvas.width = this.targetWidth;
        this.canvas.height = this.targetHeight;

        const sourceAspect = img.width / img.height;
        const targetAspect = this.targetWidth / this.targetHeight;
        
        let sw, sh, sx, sy;
        if (sourceAspect > targetAspect) {
            sh = img.height;
            sw = sh * targetAspect;
            sy = 0;
            sx = (img.width - sw) / 2;
        } else {
            sw = img.width;
            sh = sw / targetAspect;
            sx = 0;
            sy = (img.height - sh) / 2;
        }

        this.ctx.drawImage(img, sx, sy, sw, sh, 0, 0, this.targetWidth, this.targetHeight);

        return new Promise((resolve) => {
            this.canvas.toBlob((blob) => resolve(blob), fileType);
        });
    }

    /**
     * Get the cropped image as a Data URL
     */
    getDataURL() {
        return this.canvas.toDataURL();
    }
}

// Content from utils/defaults.js
const iconsData = [
    {
      name: "Broom",
      svg: `
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 32.86 26.791">
            <path id="Path_942" data-name="Path 942" d="M27.756,3.986a1.217,1.217,0,0,0-1.2,1.234v9.736a2.433,2.433,0,0,0-2.434,2.434v1.217H27.57a1.217,1.217,0,0,0,.4,0h3.459V17.39a2.433,2.433,0,0,0-2.434-2.434V5.22a1.217,1.217,0,0,0-1.236-1.234ZM11.953,4a4.049,4.049,0,0,0-3.6,2.579,3.784,3.784,0,0,0-.663-.145,4.278,4.278,0,0,0-4.26,4.26,4.152,4.152,0,0,0,.062.609H3.434a1.217,1.217,0,1,0,0,2.434H3.6l.825,6.19-3,2.629a1.218,1.218,0,0,0,1.6,1.835l1.79-1.566-.385-2.9,6.729-5.89a1.217,1.217,0,0,1,1.6,1.835L4.808,22.826l.777,5.838A2.437,2.437,0,0,0,8,30.777h7.906a2.434,2.434,0,0,0,2.413-2.113l1.992-14.925h.162a1.217,1.217,0,1,0,0-2.434h-.062a4.152,4.152,0,0,0,.062-.609,4.278,4.278,0,0,0-4.26-4.26,3.784,3.784,0,0,0-.663.145A4.049,4.049,0,0,0,11.953,4Zm0,2.434a1.8,1.8,0,0,1,1.8,1.626,1.217,1.217,0,0,0,1.709.975A1.817,1.817,0,0,1,18.038,10.7a1.858,1.858,0,0,1-.107.609H5.975a1.859,1.859,0,0,1-.107-.609A1.817,1.817,0,0,1,8.445,9.037a1.217,1.217,0,0,0,1.709-.975A1.8,1.8,0,0,1,11.953,6.437Zm12.17,14.6a16.837,16.837,0,0,0-2.434,8.519,1.217,1.217,0,0,0,1.217,1.217h9.736a1.216,1.216,0,0,0,1.21-1.348,16.907,16.907,0,0,0-2.427-8.388h-7.3Z" transform="translate(-1 -3.986)" fill="#7c8791"/>
          </svg>
         `,
    },
    {
      name: "Car",
      svg: `
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 33.969 27.499">
            <path id="Path_940" data-name="Path 940" d="M33.625,15.208l-2.689-7.7A5.236,5.236,0,0,0,26,4H11.967A5.233,5.233,0,0,0,7.034,7.507l-2.689,7.7A5.247,5.247,0,0,0,2,19.588V28.88a2.613,2.613,0,1,0,5.226,0V27.228s6.9.342,11.758.342,11.758-.342,11.758-.342V28.88a2.613,2.613,0,1,0,5.226,0V19.588A5.248,5.248,0,0,0,33.625,15.208ZM8,12.659,9.5,8.372a2.614,2.614,0,0,1,2.467-1.753H26a2.614,2.614,0,0,1,2.467,1.753l1.5,4.287a.936.936,0,0,1-1.03,1.24,62.318,62.318,0,0,0-9.952-.733,62.318,62.318,0,0,0-9.952.733A.936.936,0,0,1,8,12.659Zm-.124,9.673a1.964,1.964,0,1,1,1.96-1.964A1.963,1.963,0,0,1,7.879,22.332ZM22.9,21.023H15.065a1.309,1.309,0,0,1,0-2.619H22.9a1.309,1.309,0,0,1,0,2.619Zm7.186,1.309a1.964,1.964,0,1,1,1.96-1.964A1.963,1.963,0,0,1,30.09,22.332Z" transform="translate(-2 -4)" fill="#7c8791"/>
          </svg>
  
         `,
    },
    {
      name: "Heart",
      svg: `
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 31.83 28.479">
            <path id="Path_941" data-name="Path 941" d="M24.689,3.007a9.543,9.543,0,0,0-6.774,3.3,9.543,9.543,0,0,0-6.774-3.3A8.865,8.865,0,0,0,3.768,6.654C-2.379,14.723,9.259,24.162,12,26.7c1.638,1.516,3.659,3.317,4.865,4.384a1.583,1.583,0,0,0,2.106,0c1.206-1.067,3.228-2.868,4.865-4.384,2.738-2.534,14.377-11.973,8.228-20.041A8.86,8.86,0,0,0,24.689,3.007Z" transform="translate(-2 -3.001)" fill="#7c8791"/>
          </svg>
         `,
    },
    {
      name: "Home",
      svg: `
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 28.752 28.752">
            <path id="Path_937" data-name="Path 937" d="M17.376,2a1.2,1.2,0,0,0-.838.342L3.47,13.03l-.044.035-.044.037v0A1.2,1.2,0,0,0,4.2,15.178H5.4V28.356a2.4,2.4,0,0,0,2.4,2.4H26.96a2.4,2.4,0,0,0,2.4-2.4V15.178h1.2a1.2,1.2,0,0,0,.817-2.075l-.019-.014q-.039-.036-.082-.068l-1.914-1.565V6.792a1.2,1.2,0,0,0-1.2-1.2h-1.2a1.2,1.2,0,0,0-1.2,1.2V8.516l-7.574-6.2A1.2,1.2,0,0,0,17.376,2ZM20.97,17.574h4.792v9.584H20.97Z" transform="translate(-3 -2)" fill="#7c8791"/>
          </svg>
         `,
    },
    {
      name: "Health",
      svg: `
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 26.214 27.498">
            <path id="Path_938" data-name="Path 938" d="M26.3,4.75H20.208a4.433,4.433,0,0,0-8.2,0H5.913A2.834,2.834,0,0,0,3,7.5V26.748A2.834,2.834,0,0,0,5.913,29.5H26.3a2.834,2.834,0,0,0,2.913-2.75V7.5A2.834,2.834,0,0,0,26.3,4.75Zm-10.194,0a1.418,1.418,0,0,1,1.456,1.375,1.459,1.459,0,0,1-2.913,0A1.418,1.418,0,0,1,16.107,4.75Zm4.369,15.124H17.564v2.75A1.418,1.418,0,0,1,16.107,24h0a1.418,1.418,0,0,1-1.456-1.375v-2.75H11.738A1.418,1.418,0,0,1,10.282,18.5h0a1.418,1.418,0,0,1,1.456-1.375h2.913v-2.75A1.418,1.418,0,0,1,16.107,13h0a1.418,1.418,0,0,1,1.456,1.375v2.75h2.913A1.418,1.418,0,0,1,21.933,18.5h0A1.418,1.418,0,0,1,20.476,19.874Z" transform="translate(-3 -2)" fill="#7c8791"/>
          </svg>
         `,
    },
    {
      name: "Foods",
      svg: `
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 32.813 27.572">
            <path id="Path_939" data-name="Path 939" d="M22.959,3.986a.656.656,0,0,0-.646.665V5.964q0,.019,0,.038A5.905,5.905,0,0,0,17.1,11.214H15.75a.656.656,0,0,0-.656.656v4.594H11.933a7.534,7.534,0,0,0,.445-1.969h.091a.656.656,0,1,0,0-1.313H11.9a6.673,6.673,0,0,0,.481-1.969h.091a.656.656,0,1,0,0-1.313H11.9a6.673,6.673,0,0,0,.481-1.969h.091a.656.656,0,1,0,0-1.313H2.625a.656.656,0,1,0,0,1.313h.091A6.674,6.674,0,0,0,3.2,9.9H2.625a.656.656,0,1,0,0,1.313h.091A6.674,6.674,0,0,0,3.2,13.183H2.625a.656.656,0,1,0,0,1.313h.091a7.535,7.535,0,0,0,.445,1.969H.656A.656.656,0,0,0,0,17.12v6.563a3.271,3.271,0,0,0,5.906,1.948,3.251,3.251,0,0,0,5.25,0,3.251,3.251,0,0,0,5.25,0,3.251,3.251,0,0,0,5.25,0,3.251,3.251,0,0,0,5.25,0,3.271,3.271,0,0,0,5.906-1.948V17.12a.656.656,0,0,0-.656-.656H30.844V11.87a.656.656,0,0,0-.656-.656H28.837A5.905,5.905,0,0,0,23.624,6q0-.019,0-.038V4.652a.656.656,0,0,0-.666-.665ZM4.029,7.933h7.037A5.272,5.272,0,0,1,10.473,9.9H4.621A5.272,5.272,0,0,1,4.029,7.933Zm0,3.281h7.037a5.272,5.272,0,0,1-.592,1.969H4.621A5.272,5.272,0,0,1,4.029,11.214Zm12.378,1.313H29.531v3.938H16.406ZM4.029,14.5h7.037a5.272,5.272,0,0,1-.592,1.969H4.621A5.272,5.272,0,0,1,4.029,14.5Zm-1.4,13.729V30.9a.656.656,0,0,0,1.313,0V28.23a4.352,4.352,0,0,1-.656.046A3.64,3.64,0,0,1,2.625,28.224Zm27.562,0a3.64,3.64,0,0,1-.656.053,4.352,4.352,0,0,1-.656-.046V30.9a.656.656,0,0,0,1.313,0Z" transform="translate(0 -3.986)" fill="#7c8791"/>
          </svg>
         `,
    },
    {
      name: "Laundry",
      svg: `
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" viewBox="0 0 30.411 28.722">
            <path id="Path_943" data-name="Path 943" d="M13.236,4a2.053,2.053,0,0,0,0,4.1h2.323l-.32.333-.034.033-2.493,2.58a8.153,8.153,0,0,1-1.539-1.907.674.674,0,0,0-1.158,0c-.021.036-1.94,3.543-5.723,3.73l-.98-6.247a.669.669,0,0,0-.638-.584.652.652,0,0,0-.517.238.7.7,0,0,0-.149.564l1.07,6.83s0,.005,0,.008L5.973,32.147s0,.006,0,.009a.7.7,0,0,0,.071.21l.012.02a.679.679,0,0,0,.137.17l.009.007a.657.657,0,0,0,.186.114l.008,0a.641.641,0,0,0,.227.041H27.778A.641.641,0,0,0,28,32.68l.019-.007a.656.656,0,0,0,.186-.114h0l0-.005a.679.679,0,0,0,.136-.168l.009-.017a.7.7,0,0,0,.075-.22l2.9-18.464s0-.005,0-.008l1.07-6.83a.7.7,0,0,0-.222-.662.644.644,0,0,0-.668-.112.681.681,0,0,0-.413.555l-.98,6.252a6.184,6.184,0,0,1-2.519-.672A4.91,4.91,0,0,0,26.423,7.5L24.262,5.265a4.348,4.348,0,0,0-3.184-1.256L13.238,4Zm0,1.368,7.84.009a3.031,3.031,0,0,1,2.251.855l2.161,2.236a3.493,3.493,0,0,1,0,4.832l-6.758,6.9,0,0a.636.636,0,0,1-.935,0,.685.685,0,0,1-.154-.711l2.573-2.662.009-.009q.024-.024.045-.049a.7.7,0,0,0-.016-.908.645.645,0,0,0-.874-.091l-.005.005-.026.021q-.021.018-.041.037l-.008.008-.01.009-.022.023-2.4,2.383-.009.009a2,2,0,0,0-.292.4l-1.508,1.56a.636.636,0,0,1-.935,0,.69.69,0,0,1,0-.967l4.228-4.374a.682.682,0,0,0,.12-.162h0a.7.7,0,0,0-.094-.793.646.646,0,0,0-.756-.16l-.005,0a.659.659,0,0,0-.161.108l-.037.037L13.191,18.29l-.8.825a.636.636,0,0,1-.935,0,.69.69,0,0,1,0-.967l.567-.586,4.185-4.33a.682.682,0,0,0,.12-.163.7.7,0,0,0-.166-.863.644.644,0,0,0-.85.02l-.005.005-.034.033-4.185,4.329a.636.636,0,0,1-.935,0,.688.688,0,0,1,0-.966L16.14,9.436,17.623,7.9a.7.7,0,0,0,.143-.745.661.661,0,0,0-.61-.422H13.236a.684.684,0,0,1,0-1.368Z" transform="translate(-1.998 -4)" fill="#7c8791"/>
          </svg>
         `,
    },
  ];
  
  const defaultTileAttrs = `
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
  `;
  
  const defaultConstraints = `
      data-gjs-draggable="false"
      data-gjs-selectable="false"
      data-gjs-editable="false"
      data-gjs-highlightable="false"
      data-gjs-droppable="false"
      data-gjs-resizable="false"
      data-gjs-hoverable="false"
  `;

let globalVar = null

