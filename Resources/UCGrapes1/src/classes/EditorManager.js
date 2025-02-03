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
