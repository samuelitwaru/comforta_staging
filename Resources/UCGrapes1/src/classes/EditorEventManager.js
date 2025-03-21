class EditorEventManager {
  constructor(editorManager, templateManager) {
    this.editorManager = editorManager;
    this.templateManager = templateManager;
  }

  addEditorEventListeners(editor, page) {
    this.editorOnLoad(editor);
    this.editorOnDragDrop(editor);
    this.editorOnSelected(editor);
    this.setupKeyboardBindings(editor);
  }

  setupKeyboardBindings(editor) {
    const { keymaster } = editor.Keymaps;
    keymaster.unbind("backspace");
    keymaster.unbind("delete");
    keymaster.bind("ctrl+z");
    keymaster.bind("ctrl+shift+z");
  }

  editorOnLoad(editor) {
    editor.on("load", () => {
      this.handleEditorLoad(editor);
      this.updateEditorAfterLoad(editor);
    });
  }

  handleEditorLoad(editor) {
    this.loadTheme();
    const wrapper = editor.getWrapper();
    this.editorManager.toolsSection.currentLanguage.translateTilesTitles(
      editor
    );

    wrapper.view.el.addEventListener("click", (e) => {
      const previousSelected =
        this.editorManager.currentEditor.editor.getSelected();
      if (previousSelected) {
        // this.editorManager.currentEditor.editor.selectRemove(previousSelected);
        // this.editorManager.selectedComponent = null;
        // this.editorManager.selectedTemplateWrapper = null;
      }

      this.handleEditorClick(e, editor);
      new ContentEditorManager(e, editor, this.editorManager);
    });
  }

  updateEditorAfterLoad(editor) {
    const titles = editor.DomComponents.getWrapper().find(".tile-title");
    titles.forEach((title) => {
      if (!title.getAttributes()?.["title"]) {
        title.addAttributes({ title: title.getEl().textContent });
      }

      const displayStyle = title.getStyle()?.["display"];
      if (displayStyle === "none") {
        title.addAttributes({ "is-hidden": "true" });
      } else {
        title.addAttributes({ "is-hidden": "false" });
      }
    });

    const tileIcons = editor.DomComponents.getWrapper().find(".tile-icon");
    tileIcons.forEach((icon) => {
      const displayStyle = icon.getStyle()?.["display"];
      if (displayStyle === "none") {
        icon.addAttributes({ "is-hidden": "true" });
      } else {
        icon.addAttributes({ "is-hidden": "false" });
      }
    });

    const templateBlocks =
      editor.DomComponents.getWrapper().find(".template-block");

    templateBlocks.forEach((block) => {
      const isPriority = block.getClasses()?.includes("high-priority-template");
      const screenWidth = window.innerWidth;

      const parent = block.closest(".container-row");

      const siblingBlocks = parent.find(".template-block").length;
      const isAloneInParent = siblingBlocks === 1;

      const blockHeight =
        screenWidth <= 1440
          ? isPriority && isAloneInParent
            ? "6.0rem"
            : "4.5em"
          : isPriority && isAloneInParent
          ? "7rem"
          : "5rem";

      const currentStyles = block.getStyle();

      if (currentStyles["height"]) {
        delete currentStyles["height"];
      }
      
      delete currentStyles["textTransform"];

      block.setStyle({
        ...currentStyles,
        height: blockHeight+" !important",
      });
    });
  }

  loadTheme() {
    this.editorManager.toolsSection.themeManager.setTheme(
      this.editorManager.theme.ThemeName
    );

    this.editorManager.toolsSection.themeManager.listThemesInSelectField();
  }

  handleEditorClick(e, editor) {
    const editorId = editor.getConfig().container;
    const editorContainerId = `${editorId}-frame`;

    this.editorManager.setCurrentEditor(editorId);
    this.editorManager.currentPageId = $(editorContainerId).data().pageid;

    this.updateToolsSection();
    this.editorManager.toolsSection.unDoReDo(editor);

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

    document.getElementById("cta-selected-actions").style.display = "none";
  }

  handleTileActionClick(e, editorContainerId) {
    const pageId = e.target.attributes["tile-action-object-id"]?.value;
    const pageUrl = e.target.attributes["tile-action-object-url"]?.value;
    const pageLinkLabel = e.target.attributes["tile-action-object"]?.value;

    let linkLabel = "";
    if (pageLinkLabel) {
      linkLabel = pageLinkLabel
        .replace("Web Link, ", "")
        .replace("Dynamic Forms, ", "");
    }

    let page = this.editorManager.getPage(pageId);
    $(editorContainerId).nextAll().remove();
    console.log('page',page);
    if (page) {
      this.editorManager.createChildEditor(page, pageUrl, linkLabel);
    }else{
      // show new button component
      const container = document.getElementById("child-container");
      this.newPageButton = new NewPageButton(this.editorManager);
      container.appendChild(this.newPageButton.render());

      // page = {
      //   "PageId": null,
      //   "PageName": "New Page",
      //   "PageGJSJson": "",
      //   "PageGJSHtml": "",
      //   "PageJsonContent": ""
      // }
      // this.editorManager.createChildEditor(page, pageUrl, linkLabel);
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
    editor.on("component:selected", (component) => {
      this.handleComponentSelected(component)
    }
    );
    this.editorOnComponentAdd(editor);
  }

  editorOnComponentAdd(editor) {
    editor.on("component:mount", (model) => {
      if (model.get("type") === "svg") {
        model.set({ selectable: false });
      }
      if (model.get("type") === "tile-wrapper") {
        model.addStyle({ background: "#00000000" });
        if (model.find('.template-block').length) {
          const tileComponent = model.find('.template-block')[0];
          const tileBGUrl = tileComponent.getAttributes()["tile-bg-image-url"];
          if (tileBGUrl) {
            this.editorManager.dataManager.checkImage(tileBGUrl).then(res=>{
              console.log(res)
              if (!res) {
                tileComponent.addAttributes({ "tile-bg-image-url": "" });
                tileComponent.addStyle({"background-image": ""});
              }
            })
          }
        }
      }
    });
  }

  editorOnDragDrop(editor) {
    let startDragComponent;
    editor.on("component:drag:start", (model) => {
      startDragComponent = model.parent;
    });

    editor.on("component:drag:end", (model) => {
      const parentEl = model.parent.getEl();
      if (!parentEl || !parentEl.classList.contains("container-row")) return;

      const tileWrappers = model.parent.components().filter((comp) => {
        const type = comp.get("type");
        return type === "tile-wrapper";
      });
      if (tileWrappers.length > 3) {
        model.target.remove();

        editor.UndoManager.undo();
      }
      this.templateManager.templateUpdate.updateRightButtons(model.parent);
      this.templateManager.templateUpdate.updateRightButtons(
        startDragComponent
      );
    });
  }

  handleComponentSelected(component) {
    this.editorManager.selectedTemplateWrapper = component.getEl();
    this.editorManager.selectedComponent = component;

    const sidebarInputTitle = document.getElementById("tile-title");
    if (this.editorManager.selectedTemplateWrapper) {
      const tileLabel =
        this.editorManager.selectedTemplateWrapper.querySelector(".tile-title");
      if (tileLabel) {
        sidebarInputTitle.value = tileLabel.title;
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

    const page = this.editorManager.getPage(this.editorManager.currentPageId);
    if (page?.PageIsContentPage) {
      this.editorManager.toolsSection.ui.activateCtaBtnStyles(
        this.editorManager.selectedComponent
      );
    }
    

    this.editorManager.toolsSection.ui.updateTileProperties(
      this.editorManager.selectedComponent,
      page
    );

    this.editorManager.toolsSection.checkTileBgImage();

    this.activateNavigators();

    this.updateUIState();

    this.activateOpacitySlider(this.editorManager.selectedComponent);
  }

  activateOpacitySlider(selectedComponent) {
    const attributes = selectedComponent.getAttributes();
    const opacityEl = document.getElementById("slider-wrapper");
    if (attributes?.["tile-bg-image-url"]) {
      opacityEl.style.display = "flex";
      const opacityInput = opacityEl.querySelector("#bg-opacity");
      opacityInput.disabled = false;
      this.editorManager.toolsSection.ui.updateTileOpacityProperties(
        selectedComponent
      );
    } else {
      opacityEl.style.display = "none";
    }
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
        (page.PageIsContentPage && !page.PageIsPredefined) ? "block" : "none";
      document.querySelector("#menu-page-section").style.display =
        (page.PageIsContentPage && !page.PageIsPredefined) ? "none" : "block";
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

    const undoRedoManager = new UndoRedoManager(
      this.editorManager.currentEditor.editor
    );

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

  // setupAppBarEvents() {
  //   const buttonConfigs = [
  //     { id: "appbar-add-logo", type: "logo" },
  //     { id: "appbar-add-profile", type: "profile-image" },
  //     { id: "appbar-edit-logo", type: "logo" },
  //     { id: "appbar-edit-profile", type: "profile-image" },
  //   ];

  //   const toolboxManager = this.editorManager.toolsSection;

  //   buttonConfigs.forEach(({ id, type }) => {
  //     const element = document.getElementById(id);
  //     if (element) {
  //       element.addEventListener("click", (e) => {
  //         e.preventDefault();
  //         toolboxManager.openFileManager(type);
  //       });
  //     }
  //   });
  // }
}
