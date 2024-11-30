class ChildEditorManager{
    // child editor manager
    editors = {}
    pages = []
    toolsSection = null
    currentEditor = null
    currentPageId = null

    container = document.getElementById('child-container')

    constructor(dataManager) {
        this.dataManager = dataManager
        this.dataManager.getPages().then(pages=>{
            this.pages = pages
            const homePage = this.pages.find(page=>page.PageName=="Home")
            if (homePage) {
                this.createChildEditor(homePage)
                this.currentPageId = homePage.PageId
            }
            else {
                alert("No Home Page Found")
                return
            }
        })
    }

    createChildEditor(page) {
        const pageId = page.PageId
        const count = this.container.children.length
        const editorContainer = document.createElement('div')
        editorContainer.id = `gjs-${count}`
        console.log(editorContainer.dataset)
        editorContainer.dataset.pageid = pageId
        editorContainer.classList.add('mobile-frame')
        this.container.appendChild(editorContainer)
        
        const editor = grapesjs.init({
            container: `#gjs-${count}`,
            fromElement: true,
            height: "100%",
            width: "auto",
            canvas: {
                styles: [
                "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css",
                "https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css",
                "https://fonts.googleapis.com/css2?family=Lora&family=Merriweather&family=Poppins:wght@400;500&family=Roboto:wght@400;500&display=swap",
                "/Resources/UCGrapes1/new-design/css/toolbox.css",
                "/Resources/UCGrapes1/new-design/css/child-editor.css",
                ],
                scripts: [
                    "/Resources/UCGrapes1/new-design/js/child-editor.js",
                ]
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
        });
        this.addEditorEventListners(editor)
        editor.DomComponents.addType('tile', tileComponent)
        // editor.addComponents({type: 'tile'})

        editor.loadProjectData(JSON.parse(page.PageGJSJson))
        const editorData = {
            pageId: pageId,
            editor: editor
        }
        this.editors[`#gjs-${count}`] = editorData
        console.log('>>>>>>>>>>>>', this.editors)
    }

    getPage(pageId){
        return this.dataManager.pages.find(page=>page.PageId==pageId)
    }

    addEditorEventListners(editor) {
        editor.on('load', (model) => {
            const wrapper = editor.getWrapper();
            wrapper.view.el.addEventListener("click", (e) => {
                const editorContainerId = editor.getConfig().container
                $(editorContainerId).nextAll().remove()
                this.currentEditor = this.editors[editorContainerId]
                this.currentPageId = $(editorContainerId).data().pageid
                console.log(this.currentPageId)
                console.log('Current Editor: ', this.currentEditor)

                if (e.target.attributes['tile-action-object-id']) {
                    const page = this.getPage(e.target.attributes['tile-action-object-id'].value)
                    
                    if (page) {
                        this.createChildEditor(page)
                    }
                }
                const button = e.target.closest(".action-button");
                if (!button) return;
                const templateWrapper = button.closest(".template-wrapper");
                if (!templateWrapper) return;
                
                this.templateComponent = editor.Components.getById(
                    templateWrapper.id
                );
                if (!this.templateComponent) return;
    
                if (button.classList.contains("delete-button")) {
                this.deleteTemplate(this.templateComponent);
                } else if (button.classList.contains("add-button-bottom")) {
                this.addTemplateBottom(this.templateComponent, editor);
                } else if (button.classList.contains("add-button-right")) {
                this.addTemplateRight(this.templateComponent, editor);
                }
            })
        });

        editor.on("component:selected", (component) => {
            this.toolsSection.resetPropertySection();
            this.selectedTemplateWrapper = component.getEl();
      
            this.selectedComponent = component;
      
            const sidebarInputTitle = document.getElementById("tile-title");
            if (this.selectedTemplateWrapper) {
              const tileLabel =
                this.selectedTemplateWrapper.querySelector(".tile-title");
              if (tileLabel) {
                sidebarInputTitle.value = tileLabel.textContent;
              }
      
            //   this.removeElementOnClick(".selected-tile-icon", ".tile-icon-section");
            //   this.removeElementOnClick(
            //     ".selected-tile-title",
            //     ".tile-title-section"
            //   );
      
            //   this.updateUIState();
            //   this.activateFrame(`#default-container`);
      
              // clear existing frames first
            //   this.clearEditors();
      
            //   this.handlePageSelection();
            }
      
            this.toolsSection.updateTileProperties(
              this.currentEditor.editor,
              this.currentPageId
            );
            this.hideContextMenu();
      
            this.toolsSection.unDoReDo(this.editor);
        });
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
    
        // Adjust widths of remaining templates
        const templates = containerRow.components();
        const newWidth = 100 / templates.length;
        templates.forEach((template) => {
          if (template && template.setStyle) {
            template.addStyle({ width: `${newWidth}%` });
          }
        });
    
        this.updateRightButtons(containerRow);
    }

    addTemplateRight(templateComponent, editorInstance) {
        const containerRow = templateComponent.parent();
        if (!containerRow || containerRow.components().length >= 3) return;
        const newComponents = editorInstance.addComponents(
          createTemplateHTML()
        );
        const newTemplate = newComponents[0];
        if (!newTemplate) return;
    
        const index = templateComponent.index();
        containerRow.append(newTemplate, { at: index + 1 });
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
            data-gjs-hoverable="false">
            ${createTemplateHTML()}
        </div>
        `)[0];

    const index = currentRow.index();
    containerColumn.append(newRow, { at: index + 1 });
    }

    updateRightButtons(containerRow) {
        if (!containerRow) return;
    
        const templates = containerRow.components();
        let totalWidth = 0;
        templates.forEach((template) => {
          if (!template || !template.view || !template.view.el) return;
    
          const rightButton = template.view.el.querySelector(".add-button-right");
          if (!rightButton) return;
          const rightButtonComponent = template.find(".add-button-right")[0];
    
          if (templates.length >= 3) {
            rightButton.setAttribute("disabled", "true");
            rightButtonComponent.addStyle({ display: "none" });
          } else {
            rightButton.removeAttribute("disabled");
            rightButtonComponent.addStyle({ display: "flex" });
          }
        });
    }

    setToolsSection(toolBox) {
        this.toolsSection = toolBox;
    }

    hideContextMenu() {
        const contextMenu = document.getElementById("contextMenu");
        if (contextMenu) {
          contextMenu.style.display = "none";
        }
    }

}