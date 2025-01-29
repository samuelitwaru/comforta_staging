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
