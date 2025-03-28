class ToolBoxManager {
  constructor(
    editorManager,
    dataManager,
    themes,
    icons,
    templates,
    mapping,
    media,
    locale,
    newServiceEvent
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
    this.newServiceEvent = newServiceEvent;
  }

  async init(language) {
    try {
      this.currentLanguage = await new Locale(language).init();
      this.themeManager = new ThemeManager(this);
      this.eventListenerManager = new EventListenerManager(this);
      this.popupManager = new PopupManager(this);
      this.pageManager = new PageManager(this);

      await this.initializeManagers();
      await this.setupComponents();
      this.setupEventListeners();
      console.log("Toolbox initialized successfully", this.themes);
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
    // this.themeManager.listThemesInSelectField();
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
      let inputValue = e.target.value;

      if (inputValue.length > 35) {
        inputValue = truncateText(inputValue, 35);
        e.target.value = inputValue; 
      }

      if (inputValue.trim() === "") {
        const titleComponent =
        this.editorManager.selectedComponent.find(".tile-title")[0];
        if (titleComponent) {
          titleComponent.getEl().innerHTML = "";
        }
      }

      this.ui.updateTileTitle(inputValue);
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
    // first update the JSON content of each page
    editors.forEach(editorInfo => {
      const page = this.dataManager.pages.SDT_PageCollection.find(
        (page) => page.PageId == editorInfo.pageId);
      this.editorManager.updatePageJSONContent(editorInfo.editor, page);
    });

    let skipPages = ["Mailbox", "Calendar", "My Activity"];
    return this.dataManager.pages.SDT_PageCollection.filter(
      (page) => !skipPages.includes(page.PageName)
    ).map((page) => {
      let projectData;
      try {
        projectData = JSON.parse(page.PageGJSJson);
      } catch (error) {
        projectData = {};
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
    });
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

        console.log('>>', res)

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
        // const stack = um.getStack();
        // stack.each(item => {
        //   if (item.getClasses().includes("high-priority-template")) {
        //     console.l
        //   }
        // });
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

  updateContentPageInformationOnEdit() {

  }

  checkIfNotAuthenticated(res) {
    if (res.error.Status === "Error") {
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
 
  checkTileBgImage() {
    if (this.editorManager.selectedTemplateWrapper) {
      const templateBlock = this.editorManager.selectedComponent;

      if (templateBlock) {
        const tileImgContainer = document.getElementById("tile-img-container");
        // first check if templateBlock has a background image
        if (templateBlock.getStyle()["background-image"]) {
          const currentBgImage = templateBlock
            .getStyle()
            ["background-image"].match(/url\((.*?)\)/)[1];

          if (currentBgImage) {
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
                    currentStyles["background-color"] = templateBlock.getAttributes()?.["tile-bgcolor"];
                    templateBlock.setStyle(currentStyles);
                    tileImgContainer.style.display = "none";
                    this.setAttributeToSelected("tile-bg-image-url", "");
                    this.setAttributeToSelected("tile-bg-image-opacity", 0);
                    this.ui.updateTileOpacityProperties(templateBlock);
                    this.editorManager.editorEventManager.activateOpacitySlider(templateBlock);
                  };
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

  setServiceToSelectedTile(serviceId) {
    const categoryName = "Service/Product Page";
    this.dataManager.getServices().then((services) => {
      const service = services.find(
        (service) => service.ProductServiceId == serviceId
      );

      if (service) {
        this.editorManager.selectedComponent.addAttributes({
          "tile-action-object-id": service.ProductServiceId,
          "tile-action-object": `${categoryName}, ${service.ProductServiceName}`,
        });

        this.setAttributeToSelected("tile-action-object-id", serviceId);

        this.setAttributeToSelected(
          "tile-action-object",
          `${categoryName}, ${service.ProductServiceName}`
        );

        const editor = this.editorManager.getCurrentEditor();
        const titleComponent = editor.getSelected().find(".tile-title")[0];
        if (titleComponent) {
          titleComponent.components(service.ProductServiceTileName);
          titleComponent.addStyle({ display: "block" });
        }
        const editorId = editor.getConfig().container;
        const editorContainerId = `${editorId}-frame`;
        this.actionList.createContentPage(
          service.ProductServiceId,
          editorContainerId
        );
      }
    });
  }

  openFileManager(type) {
    const fileInputField = this.mediaComponent.createFileInputField();
    const modal = this.mediaComponent.openFileUploadModal();

    let allUploadedFiles = [];

    const isTile = false;

    console.log("type:---------------->", type);

    this.mediaComponent.handleModalOpen(
      modal,
      fileInputField,
      allUploadedFiles,
      isTile,
      type
    );
  }
}
