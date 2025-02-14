function UC_AppToolBox($) {
	  
	 this.setSDT_Page = function(value) {
			this.SDT_Page = value;
		}

		this.getSDT_Page = function() {
			return this.SDT_Page;
		} 
	 this.setSDT_Pages = function(value) {
			this.SDT_Pages = value;
		}

		this.getSDT_Pages = function() {
			return this.SDT_Pages;
		} 
	  
	  
	 this.setSDT_ProductServiceCollection = function(value) {
			this.SDT_ProductServiceCollection = value;
		}

		this.getSDT_ProductServiceCollection = function() {
			return this.SDT_ProductServiceCollection;
		} 
	 this.setSDT_DynamicFormsCollection = function(value) {
			this.SDT_DynamicFormsCollection = value;
		}

		this.getSDT_DynamicFormsCollection = function() {
			return this.SDT_DynamicFormsCollection;
		} 
	 this.setBC_Trn_TemplateCollection = function(value) {
			this.BC_Trn_TemplateCollection = value;
		}

		this.getBC_Trn_TemplateCollection = function() {
			return this.BC_Trn_TemplateCollection;
		} 
	 this.setBC_Trn_ThemeCollection = function(value) {
			this.BC_Trn_ThemeCollection = value;
		}

		this.getBC_Trn_ThemeCollection = function() {
			return this.BC_Trn_ThemeCollection;
		} 
	 this.setBC_Trn_MediaCollection = function(value) {
			this.BC_Trn_MediaCollection = value;
		}

		this.getBC_Trn_MediaCollection = function() {
			return this.BC_Trn_MediaCollection;
		} 
	 this.setBC_Trn_Location = function(value) {
			this.BC_Trn_Location = value;
		}

		this.getBC_Trn_Location = function() {
			return this.BC_Trn_Location;
		} 
	  
	  

	var template = '<!--<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css\"/>--><div class=\"preloader\" id=\"preloader\"><div class=\"spinner\"></div></div><div id=\"tb-body\">    <div class=\"tb-navbar\">    <h3 id=\"navbar_title\">    </h3>    <div class=\"navbar-buttons\">      <div class=\"edit-actions\">        <button class=\"btn-transparent\" id=\"undo\" title=\"Undo (ctrl+z)\">          <span class=\"fa fa-undo\">          </span>        </button>        <button class=\"btn-transparent\" id=\"redo\" title=\"Redo (ctrl+shift+z)\">          <span class=\"fa fa-redo\">          </span>        </button>      </div>      <div class=\"tb-custom-theme-selection\">        <!--<select class=\"tb-form-control\" name=\"theme\" id=\"theme-select\"></select>-->        <button class=\"theme-select-button\" aria-haspopup=\"listbox\" aria-expanded=\"false\">          <span class=\"selected-theme-value\">            Select Theme          </span>        </button>      </div>      <button id=\"open-mapping\" class=\"tb-btn tb-btn-outline\">        <svg xmlns=\"http://www.w3.org/2000/svg\" width=\"18.818\" height=\"16\" viewBox=\"0 0 18.818 18\">          <path id=\"Path_993\" data-name=\"Path 993\" d=\"M19.545,5a3.283,3.283,0,0,0-3.273,3.273A3.228,3.228,0,0,0,16.784,10l-2.541,3.177H10.427a3.273,3.273,0,1,0,0,1.636h3.816L16.784,18a3.229,3.229,0,0,0-.511,1.732,3.273,3.273,0,1,0,3.273-3.273,3.207,3.207,0,0,0-1.563.419L15.685,14l2.3-2.873a3.207,3.207,0,0,0,1.563.419,3.273,3.273,0,0,0,0-6.545Zm0,1.636a1.636,1.636,0,1,1-1.636,1.636A1.623,1.623,0,0,1,19.545,6.636ZM7.273,12.364A1.636,1.636,0,1,1,5.636,14,1.623,1.623,0,0,1,7.273,12.364Zm12.273,5.727a1.636,1.636,0,1,1-1.636,1.636A1.623,1.623,0,0,1,19.545,18.091Z\"          transform=\"translate(-4 -5)\" />        </svg>        <span id=\"navbar_tree_label\">        </span>      </button>      <button id=\"publish\" class=\"tb-btn tb-btn-primary\">        <svg xmlns=\"http://www.w3.org/2000/svg\" width=\"13\" height=\"16\" viewBox=\"0 0 13 18\">          <path id=\"Path_958\" data-name=\"Path 958\" d=\"M13.5,3.594l-.519.507L7.925,9.263l1.038,1.06,3.814-3.9V18.644h1.444V6.429l3.814,3.9,1.038-1.06L14.019,4.1ZM7,20.119v1.475H20V20.119Z\"          transform=\"translate(-7 -3.594)\" fill=\"#fff\" />        </svg>        <span id=\"navbar_publish_label\">        </span>      </button>    </div>  </div>  <div class=\"tb-container\">    <div class=\"main-content\">      <div class=\"navigator page-navigator-left\" style=\"display:none\">			<span id=\"scroll-left\"><i class=\"fa fa-arrow-left-long\"></i></span>      </div>      <div class=\"frame-list\" id=\"child-container\">      </div>      <div class=\"navigator page-navigator-right\" style=\"display:none\">        <span id=\"scroll-right\"><i class=\"fa fa-arrow-right-long\"></i></span>      </div>    </div>    <div class=\"sidebar sidebar-right\">      <div id=\"tools-section\">        <div class=\"tb-tabs\">          <button id=\"pages-button\" class=\"tb-tab-button active\" data-tab=\"pages\">            <span id=\"sidebar_tabs_pages_label\">            </span>          </button>          <button id=\"templates-button\" class=\"tb-tab-button\" data-tab=\"templates\">            <span id=\"sidebar_tabs_templates_label\">            </span>          </button>        </div>        <div class=\"tb-tab-content active-tab\" id=\"pages-content\">          <div id=\"menu-page-section\">            <div class=\"sidebar-section theme-section\" style=\"padding-top: 0\">              <div class=\"color-palette\" id=\"theme-color-palette\">              </div>		  <div class=\"tile-img-section\">			<div class=\"bg-section\">			<button class=\"add-image\" id=\"image-bg\">				<span class=\"plus\">				<i class=\"fa fa-plus\">				</i>				</span>				<span class=\"image-icon\">				<i class=\"fa fa-image\">				</i>				</span>			</button>			<div class=\"percentage-wrapper\">				<input type=\"number\" id=\"bg-opacity\" class=\"percentage-input\" value=\"100\"				min=\"0\" max=\"100\" oninput=\"if (this.value > 100) this.value = 100; if (this.value < 0) this.value = 0;\">				<span class=\"percentage-sign\">				%				</span>			</div>			</div>			<div class=\"tile-img-container\" id=\"tile-img-container\">				<img src=\"\" alt=\"Thumbnail\" id=\"tile-img-thumbnail\" class=\"tile-img-thumbnail\" />				<button id=\"tile-img-delete-button\" class=\"tile-img-delete-button\"><i class=\"fa fa-xmark\"></i></button>			</div>		  </div>            </div>            <div class=\"sidebar-section title-section\">              <input type=\"text\" class=\"tb-form-control\" id=\"tile-title\" placeholder=\"Enter title\"              />              <div class=\"title-style\">                <div class=\"text-color-palette text-colors\" id=\"text-color-palette\">                </div>                <div class=\"text-alignment\">                  <div class=\"align-item\">                    <input type=\"radio\" id=\"text-align-left\" name=\"alignment\" value=\"left\"                    />                    <label for=\"text-align-left\" class=\"fas fa-align-left\">                    </label>                  </div>                  <div class=\"align-item\">                    <input type=\"radio\" id=\"text-align-center\" name=\"alignment\" value=\"center\"                    />                    <label for=\"text-align-center\" class=\"fas fa-align-center\">                    </label>                  </div>                  <div class=\"align-item\">                    <input type=\"radio\" id=\"text-align-right\" name=\"alignment\" value=\"right\"                    />                    <label for=\"text-align-right\" class=\"fas fa-align-right\">                    </label>                  </div>                </div>              </div>            </div>            <div class=\"sidebar-section custom-select-container\" id=\"select-container\">              <div class=\"tb-dropdown\">                <div class=\"tb-dropdown-header\" id=\"selectedOption\">                  <span id=\"sidebar_select_action_label\">                  </span>                  <i class=\"fa fa-angle-down\">                  </i>                </div>                <div class=\"tb-dropdown-menu\" id=\"dropdownMenu\">                </div>              </div>			</div>            <div class=\"sidebar-section services-section\">              <div class=\"tb-custom-category-selection\">                <button class=\"category-select-button\" aria-haspopup=\"listbox\" aria-expanded=\"false\">                  <span class=\"selected-category-value\">                    General                  </span>                </button>              </div>              <div id=\"icons-list\" class=\"icons-list\">              </div>              <div class=\"title-style\">                <div class=\"text-color-palette icon-colors\" id=\"icon-color-palette\">                </div>                <div class=\"text-alignment\">                  <div class=\"align-item\">                    <input type=\"radio\" id=\"icon-align-left\" name=\"icon-alignment\" value=\"left\"                    />                    <label for=\"icon-align-left\" class=\"fas fa-align-left\">                    </label>                  </div>                  <div class=\"align-item\">                    <input type=\"radio\" id=\"icon-align-center\" name=\"icon-alignment\" value=\"center\"                    />                    <label for=\"icon-align-center\" class=\"fas fa-align-center\">                    </label>                  </div>                  <div class=\"align-item\">                    <input type=\"radio\" id=\"icon-align-right\" name=\"icon-alignment\" value=\"right\"                    />                    <label for=\"icon-align-right\" class=\"fas fa-align-right\">                    </label>                  </div>                </div>              </div>            </div>          </div>          <div class=\"sidebar-section content-page-section\" id=\"content-page-section\"          style=\"display:none;\">            <div class=\"cta-button-layout-container\" style=\"display: none\">              <button class=\"tb-btn cta-button-layout\" id=\"plain-button-layout\">                Button              </button>              <button class=\"tb-btn cta-button-layout\" id=\"img-button-layout\">                <svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 40.999 28.865\">                  <path id=\"Path_1040\" data-name=\"Path 1040\" d=\"M21.924,11.025a3.459,3.459,0,0,0-3.287,3.608,3.459,3.459,0,0,0,3.287,3.608,3.459,3.459,0,0,0,3.287-3.608A3.459,3.459,0,0,0,21.924,11.025ZM36.716,21.849l-11.5,14.432-8.218-9.02L8.044,39.89h41Z\"                  transform=\"translate(-8.044 -11.025)\" fill=\"#4c5357\" />                </svg>                Button              </button>            </div>            <div id=\"call-to-actions\">            </div>            <div class=\"cta-style\" id=\"cta-style\">              <div class=\"text-color-palette text-colors\" id=\"cta-color-palette\">              </div>              <div class=\"text-alignment\">                <div class=\"align-item\">                  <input type=\"radio\" id=\"cta-align-left\" name=\"alignment\" value=\"left\"                  />                  <label for=\"cta-align-left\" class=\"fas fa-align-left\">                  </label>                </div>                <div class=\"align-item\">                  <input type=\"radio\" id=\"cta-align-center\" name=\"alignment\" value=\"center\"                  />                  <label for=\"cta-align-center\" class=\"fas fa-align-center\">                  </label>                </div>                <div class=\"align-item\">                  <input type=\"radio\" id=\"cta-align-right\" name=\"alignment\" value=\"right\"                  />                  <label for=\"cta-align-right\" class=\"fas fa-align-right\">                  </label>                </div>              </div>            </div>		<p id=\"no-cta-message\"\" style=\"display: none; color: #6b6969; text-align: center; font-style: italic;\">No CTA section found for this service.</p>          </div>        </div>        <div class=\"tb-tab-content\" id=\"templates-content\">          <div class=\"sidebar-section\" id=\"page-templates\">          </div>        </div>      </div>      <div id=\"mapping-section\" style=\"display: none;\">        <div class=\"mapping-header\">          <h3>            <span id=\"sidebar_mapping_title\">            </span>          </h3>        </div>        <div class=\"sidebar-section\">          <div class=\"page-form\" id=\"page-form\">            <input type=\"text\" class=\"add-page-input\" id=\"page-title\" placeholder=\"Page name...\"            />            <button class=\"submit-button add-page-button\" id=\"page-submit\">              Add            </button>          </div>	    <div class=\"mapping-sub-title\">		<h5 id=\"current-page-title\">			HOME		</h5>		<span id=\"list-all-pages\">Show all pages</span>		<span id=\"hide-pages\">Hide pages</span>	    </div>          <div id=\"tree-container\" class=\"tb-list-container\">          </div>        </div>      </div>    </div>    <div class=\"alerts-container\" id=\"alerts-container\">    </div>    <div class=\"context-menu\" id=\"contextMenu\">      <ul>        <li data-card-id=\"1\" id=\"delete-bg-image\">          Delete image        </li>        </ul>    </div>  </div>   <!--<script src=\"/Resources/UCGrapes1/src/classes/Clock.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/classes/LoadingManager.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/classes/Locale.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/classes/DataManager.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/classes/EditorManager.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/classes/EditorEventManager.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/classes/TemplateManager.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/classes/ToolboxManager.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/classes/EventListenerManager.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/classes/PageManager.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/classes/PopupManager.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/classes/ThemeManager.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/classes/ToolBoxUI.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/classes/UndoRedoManager.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/components/ActionListComponent.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/components/MappingComponent.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/components/MediaComponent.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/classes/ImageCropper.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/utils/defaults.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/utils/data-mapper.js\">  </script>  <script src=\"/Resources/UCGrapes1/src/utils/helper.js\">  </script>-->  <!--<script src=\"/Resources/UCGrapes1/src/combined.js\">  </script>--></div>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnaddServiceButtonEvent = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnaddServiceButtonEvent = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='addServiceButtonEvent']")
				.on('addservicebuttonevent', this.onaddServiceButtonEventHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.Start(); 
	}

	this.Scripts = [];

		this.Start = function() {

			   		console.log(this.addServiceButtonEvent)
			   		console.log(this.LocationId, this.OrganisationId)
			      	const mapping = this.SDT_Pages
					const templates = this.BC_Trn_TemplateCollection.map(temp => {
						let res = {
							id: temp.Trn_TemplateId,
							label: temp.Trn_TemplateName, 
							media: temp.Trn_TemplateMedia,
							content: temp.Trn_TemplateContent.split(',').map(i=>parseInt(i))
						}
						return res
					})
			      
			      	const themes = this.BC_Trn_ThemeCollection.map(theme => {
						let res = {
							ThemeId: theme.Trn_ThemeId,
							ThemeName: theme.Trn_ThemeName, 
							ThemeFontFamily: theme.Trn_ThemeFontFamily,
							ThemeColors: {},
							ThemeIcons: theme.Icon
						}
						theme.Color.forEach(color => {
							res.ThemeColors[color.ColorName] = color.ColorCode	
						})
						return res
			      	})
					
			      	const currentLanguage = this.Current_Language.toLowerCase();
			      	let locale;
					(async () => {
						locale = new Locale(currentLanguage);
						await locale.loadTranslations(); 
						locale.setLanguage();
						locale.translateUCStrings();
					})();
				
					const dataManager = new DataManager(this.SDT_ProductServiceCollection, this.SDT_DynamicFormsCollection, this.BC_Trn_MediaCollection);
					dataManager.LocationId = this.LocationId
					dataManager.OrganisationId = this.OrganisationId
					dataManager.Location = this.BC_Trn_Location
					
					const editorManager = new EditorManager(dataManager, locale)
					
					const toolBox = new ToolBoxManager(
						editorManager, 
						dataManager, 
						themes, 
						iconsData, 
						templates, 
						mapping, 
						this.BC_Trn_MediaCollection, 
						locale
					);
					editorManager.setToolsSection(toolBox)
					editorManager.editorManager = editorManager
					toolBox.editorManager = editorManager
					toolBox.newServiceEvent = this.addServiceButtonEvent
					
					const newServiceButton = document.getElementById("new-service-button")
					newServiceButton.onclick = (e) => {
						e.preventDefault()
						this.NewServiceButtonClicked()
					}
					
			   
		}


		this.onaddServiceButtonEventHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 this.SDT_PageCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 this.SDT_PagesCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 this.SDT_ProductServiceCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 this.SDT_DynamicFormsCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 this.BC_Trn_TemplateCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 this.BC_Trn_ThemeCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 this.BC_Trn_MediaCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 this.BC_Trn_LocationCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
			}

			if (this.addServiceButtonEvent) {
				this.addServiceButtonEvent();
			}
		} 

	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}