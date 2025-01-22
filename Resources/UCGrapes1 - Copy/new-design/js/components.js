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
  
        this.categoryData = [{
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
                ).map(page=>{
                    page.TileName = page.PageName
                    return page
                });
                this.predefinedPageOptions = res.SDT_PageCollection.filter(
                    (page) => page.PageIsPredefined && page.PageName != "Home"
                ).map(page=>{
                    page.TileName = page.PageName
                    return page
                });
                this.servicePageOptions = this.dataManager.services.map((service) => {
                    return {
                        PageId: service.ProductServiceId,
                        PageName: service.ProductServiceName,
                        TileName: service.ProductServiceTileName || service.ProductServiceName
                    };
                });
                console.log(this.pageOptions)
                console.log(this.predefinedPageOptions)
                console.log(this.servicePageOptions)

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
        let self = this;
        const dropdownMenu = document.getElementById("dropdownMenu");
        dropdownMenu.innerHTML = "";
        this.categoryData.forEach((category) => {
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
                optionElement.dataset.tileName = option.TileName;
                categoryContent.appendChild(optionElement);
            });
  
            categoryElement.appendChild(categoryContent);
  
            const noRecordsMessage = document.createElement("li");
            noRecordsMessage.textContent = "No records found";
            noRecordsMessage.classList.add("no-records-message");
            noRecordsMessage.style.display = "none";
            categoryContent.appendChild(noRecordsMessage);
  
            dropdownMenu.appendChild(categoryElement);
        });
  
        const dropdownHeader = document.getElementById("selectedOption");
        const categories = document.querySelectorAll(".category");
  
        // Toggle dropdown menu visibility
  
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
  
        // Close dropdown when clicking outside
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
  
        // Toggle display of the search box based on category open state and handle icons
        categories.forEach((category) => {
            category.addEventListener("toggle", function() {
                self.selectedObject = category.dataset.category;
                const searchBox = this.querySelector(".search-container");
                const icon = this.querySelector("summary i");
                const isOpen = this.open;
  
                if (isOpen) {
                    categories.forEach((otherCategory) => {
                        if (otherCategory !== this) {
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
  
        document.querySelectorAll(".category-content li").forEach((item) => {
            item.addEventListener("click", function() {
                console.log(item)
                dropdownHeader.textContent = `${
                  this.closest(".category").dataset.category
                }, ${this.textContent}`;
  
                const editor = self.editorManager.getCurrentEditor();
                if (editor.getSelected()) {
                    const titleComponent = editor.getSelected().find(".tile-title")[0];
  
                    // add apage to a selected tile
                    const currentPageId = localStorage.getItem("pageId");
  
                    if (currentPageId !== undefined) {
                        self.toolBoxManager.setAttributeToSelected(
                            "tile-action-object-id",
                            this.id
                        );
                        self.toolBoxManager.setAttributeToSelected(
                            "tile-action-object",
                            `${this.closest(".category").dataset.category}, ${
                              this.textContent
                            }`
                        );
                        if (self.selectedObject == "Service/Product Page") {
                            self.createContentPage(this.id);
                        }
                    }
  
                    if (titleComponent) {
                        titleComponent.components(item.dataset.tileName);
  
                        const sidebarInputTitle = document.getElementById("tile-title");
                        if (sidebarInputTitle) {
                            sidebarInputTitle.textContent = this.textContent;
                        }
                    }
                }
                dropdownHeader.innerHTML += ' <i class="fa fa-angle-down"></i>';
                dropdownMenu.style.display = "none"; 
            });
        });
  
        document.querySelectorAll(".search-input").forEach((input) => {
            input.addEventListener("input", function() {
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
  
    createContentPage(pageId) {
        let self = this;
        this.dataManager.createContentPage(pageId).then((res) => {
            if (this.toolBoxManager.checkIfNotAuthenticated(res)) {
                return;
            }
  
            this.dataManager.getPagesService().then((res) => {
                const newTree = self.toolBoxManager.mappingComponent.createTree(
                    res.SDT_PageStructureCollection,
                    true
                );
                self.toolBoxManager.mappingComponent.clearMappings();
                self.toolBoxManager.mappingComponent.treeContainer.appendChild(newTree);
            });
        });
    }
  }
  
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

    getPage(pageId) {
        return this.dataManager.pages.SDT_PageCollection.find((page) => page.PageId == pageId);
    }

    createPageTree(rootPageId, childDivId){
        let homePage = this.getPage(rootPageId)
        let homePageJSON = JSON.parse(homePage.PageGJSJson)
        const pages = homePageJSON.pages;
        const containerRows =
            pages[0].frames[0].component.components[0].components[0].components;
        console.log(containerRows)

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
                                childPages.push({Id: pageId, Name:page.PageName})
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
  
    init() {
        this.setupEventListeners();
        //this.loadPageTree();
        this.createPageTree('34f798f2-7b6c-4a8f-bdea-d14273b5a678', "tree-container");
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
                console.log(res)
                if (this.toolBoxManager.checkIfNotAuthenticated(res)) {
                    return;
                }
  
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
            await this.dataManager.createNewPage(pageTitle, this.toolBoxManager.currentTheme).then((res) => {
                if (this.toolBoxManager.checkIfNotAuthenticated(res)) {
                    return;
                }
  
                pageInput.value = "";
  
                this.clearMappings();
                this.toolBoxManager.actionList.init();
                this.init()
                // this.dataManager.getPages().then(res=>{
                //     this.init()
                // })
                // this.dataManager.getPagesService().then((res) => {
  
                //     let treePages = res.SDT_PageStructureCollection.map((page) => {
                //         return {
                //             Id: page.Id,
                //             Name: page.Name
                //         };
                //     });
  
                //     const newTree = this.createTree(treePages, true);
                //     this.treeContainer.appendChild(newTree);
                //     this.toolBoxManager.actionList.init();
                // });
            });
  
        } catch (error) {
            console.error(error)
            this.displayMessage(`${this.currentLanguage.getTranslation("error_creating_page")}`, "error");
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
        const buildListItem = (item) => {
            const listItem = document.createElement("li");
            listItem.classList.add("tb-custom-list-item");
            const childDiv = document.createElement("div")
            childDiv.classList.add("child-div")
            childDiv.id = `child-div-${item.Id}`
            childDiv.style.position = 'relative'
            childDiv.style.paddingLeft = '20px'

  
            const menuItem = document.createElement("div");
            menuItem.classList.add("tb-custom-menu-item");
  
            const toggle = document.createElement("span");
            toggle.classList.add("tb-dropdown-toggle");
            toggle.setAttribute("role", "button");
            toggle.setAttribute("aria-expanded", "false");
            toggle.innerHTML = `<i class="fa fa-caret-right tree-icon"></i><span>${item.Name}</span>`;
  
            const deleteIcon = document.createElement("i");
            deleteIcon.classList.add("fa-regular", "fa-trash-can", "tb-delete-icon");
            deleteIcon.setAttribute("data-id", item.Id);
  
            deleteIcon.addEventListener("click", (event) =>
                handleDelete(event, item.Id, listItem)
            );
  
            menuItem.appendChild(toggle);
            if (item.Name !== "Home") {
                menuItem.appendChild(deleteIcon);
            }
            listItem.appendChild(menuItem);
            listItem.appendChild(childDiv)
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
                return
                // Close all dropdowns if this item has no children
                if (!item.Children) {
                    document
                        .querySelectorAll(".tb-dropdown.active")
                        .forEach((dropdown) => {
                            dropdown.classList.remove("active");
                            dropdown
                                .querySelector(".tb-dropdown-toggle")
                                .setAttribute("aria-expanded", "false");
                            dropdown
                                .querySelector(".tb-custom-menu-item")
                                .classList.remove("active-tree-item");
                        });
                }
            });
  
            return listItem;
        };
  
        const buildDropdownItem = (child, parent) => {
            const dropdownItem = document.createElement("li");
            dropdownItem.classList.add("tb-dropdown-item");
            dropdownItem.innerHTML = `<span><i style="margin-right: 10px;" class="fa-regular fa-file tree-icon"></i>${child.Name}</span><i data-id="${child.Id}" class="fa-regular fa-trash-can tb-delete-icon"></i>`;
  
            const childDeleteIcon = dropdownItem.querySelector(".tb-delete-icon");
            childDeleteIcon.addEventListener("click", (event) =>
                handleDelete(event, child.Id, dropdownItem)
            );
  
            dropdownItem.addEventListener("click", (e) => {
                e.stopPropagation();
                this.handlePageSelection(child, true, parent);
            });
  
            return dropdownItem;
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
  
    setActivePageOnTre(pageId) {}
  
    updateActivePageName() {
        return this.editorManager.getCurrentPageName();
    }
  
    displayMessage(message, status) {
        this.toolBoxManager.displayAlertMessage(message, status);
    }
  }
  
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
          <h2>${this.currentLanguage.getTranslation("file_upload_modal_title")}</h2>
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
        ['dragenter', 'dragover', 'dragleave', 'drop'].forEach(eventName => {
            uploadArea.addEventListener(eventName, preventDefaults, false);
            document.body.addEventListener(eventName, preventDefaults, false);
        });

        ['dragenter', 'dragover'].forEach(eventName => {
            uploadArea.addEventListener(eventName, () => {
                uploadArea.classList.add('drag-over');
            });
        });

        ['dragleave', 'drop'].forEach(eventName => {
            uploadArea.addEventListener(eventName, () => {
                uploadArea.classList.remove('drag-over');
            });
        });

        uploadArea.addEventListener('drop', (e) => {
            const files = Array.from(e.dataTransfer.files);
            this.handleDroppedFiles(files);
        });

        function preventDefaults(e) {
            e.preventDefault();
            e.stopPropagation();
        }
    }

    handleDroppedFiles(files) {
        const validFiles = files.filter(file => 
            ['image/jpeg', 'image/jpg', 'image/png'].includes(file.type)
        );

        if (validFiles.length !== files.length) {
            this.toolBoxManager.displayAlertMessage(
                `${this.currentLanguage.getTranslation("invalid_file_type_message")}`,
                "error"
            );
        }

        const fileList = document.querySelector('#fileList');
        if (!fileList) return;

        validFiles.forEach(file => {
            const imageName = `${Date.now()}-${file.name}`;
            this.processUploadedFile(file, imageName, fileList);
        });
    }
  
    createModalActions() {
        const actions = document.createElement("div");
        actions.className = "modal-actions";
        actions.innerHTML = `
          <button class="tb-btn tb-btn-outline" id="cancelBtn">${this.currentLanguage.getTranslation(
            "save_btn"
          )}</button>
          <button class="tb-btn tb-btn-primary" id="saveBtn">${this.currentLanguage.getTranslation(
            "cancel_btn"
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
                    <div class="file-size">${this.formatFileSize(file.MediaSize)}</div>
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
            this.toolBoxManager.displayAlertMessage(
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
        const style = document.createElement('style');
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
        const newFiles = Array.from(event.target.files).filter((file) => ["image/jpeg", "image/jpg", "image/png"].includes(file.type));
        allUploadedFiles.push(...newFiles);
  
        newFiles.forEach((file) => {
            const imageName = `${Date.now()}-${file.name}`;
            this.processUploadedFile(file, imageName, fileList);
        });
    }
  
    processUploadedFile(file, imageName, fileList) {
        const reader = new FileReader();
        reader.onload = (e) => {
            this.dataManager
                .uploadFile(e.target.result, imageName, file.size, file.type)
                .then((response) => {
                    if (this.toolBoxManager.checkIfNotAuthenticated(response)) {
                        return;
                    }
  
                    if (response.BC_Trn_Media.MediaId) {
                        this.dataManager.media.push(response.BC_Trn_Media);
                        this.displayMediaFile(fileList, response.BC_Trn_Media);
                    }
                });
        };
        reader.readAsDataURL(file);
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
          <img src="${file.MediaUrl}" alt="File thumbnail" class="preview-image">
          <div class="file-info">
            <div class="file-name">${removeBeforeFirstHyphen(file.MediaName)}</div>
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
            templateBlock.addStyle({
                "background-image": `url(${this.selectedFile.MediaUrl})`,
                "background-size": "cover",
                "background-position": "center",
            });
  
            this.toolBoxManager.setAttributeToSelected(
                "tile-bg-image-url",
                this.selectedFile.MediaUrl
            );
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
                    this.toolBoxManager.displayAlertMessage(
                        `${this.currentLanguage.getTranslation(
                          "media_deleted_successfully"
                        )}`,
                        "success"
                    );
                    this.checkAndHideModalActions();
                } else {
                    this.toolBoxManager.displayAlertMessage(
                        `${this.currentLanguage.getTranslation(
                          "failed_to_delete_media"
                        )}`,
                        "error"
                    );
                }
            })
            .catch((error) => {
                console.error("Error deleting media file:", error);
                this.toolBoxManager.displayAlertMessage(
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