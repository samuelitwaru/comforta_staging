class ChildEditorManager{
    // child editor manager
    editors = {}

    currentEditor = null

    container = document.getElementById('child-container')

    constructor(dataManager) {
        this.dataManager = dataManager
        // this.container.innerHTML = ""

    }

    createChildEditor(page) {
        const pageId = page.PageId
        const count = this.container.children.length
        const editorContainer = document.createElement('div')
        editorContainer.id = `gjs-${count}`
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
                    "/Resources/UCGrapes11/new-design/js/child-editor.js",
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
        this.editors[`gjs-${count}`] = editor
        console.log(editor.id)
        console.log('>>>>>>>>>>>>', this.editors)
    }

    getPage(pageId){
        return this.dataManager.pages.find(page=>page.PageId==pageId)
    }

    addEditorEventListners(editor) {
        editor.on('load', (model) => {
            console.log(model)
            const wrapper = editor.getWrapper();
            const component = wrapper.find('.action-button')[0];
            
            wrapper.view.el.addEventListener("click", (e) => {
                const editorContainerId = editor.getConfig().container
                $(editorContainerId).nextAll().remove()
                alert(editorContainerId)
                this.currentEditor = this.editors[editorContainerId]

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
            {type: 'tile'}
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
    }
    
    addTemplateBottom(templateComponent, editorInstance) {
        const currentRow = templateComponent.parent();
        const containerColumn = currentRow?.parent();

        if (!containerColumn) return;

        const newRow = editorInstance.addComponents({type: 'tile'})[0];

        const index = currentRow.index();
        containerColumn.append(newRow, { at: index + 1 });
    }

}