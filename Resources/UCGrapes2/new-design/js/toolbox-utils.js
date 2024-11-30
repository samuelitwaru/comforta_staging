function mapTemplateToPageData(templateData) {
  // Helper function to generate UUID
  function generateUUID() {
    return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(
      /[xy]/g,
      function (c) {
        const r = (Math.random() * 16) | 0;
        const v = c === "x" ? r : (r & 0x3) | 0x8;
        return v.toString(16);
      }
    );
  }

  // Create the base page structure
  const pageData = {
    PageId: localStorage.getItem("pageId"),
    PageName: localStorage.getItem("pageName"),
    Row: [],
  };

  // Find container-column in template data
  const containerColumn = (() => {
    const pages = templateData.pages || [];
    for (const page of pages) {
      for (const frame of page.frames || []) {
        const container =
          frame.component?.components?.[0]?.components?.[0];
        if (container?.classes?.includes("container-column")) {
          return container;
        }
      }
    }
    return null;
  })();

  if (!containerColumn) return pageData;

  // Find and map container rows
  const containerRows =
    containerColumn.components?.filter((comp) =>
      comp.classes?.includes("container-row")
    ) || [];


  // Map rows to final structure
  pageData.Row = containerRows.map((rowComponent) => {
    const row = {
      RowId: generateUUID(),
      RowName: generateUUID(),
      Col: [],
    };

    // Find and map templates to columns
    const templates =
      rowComponent.components?.filter(
        (comp) =>
          comp.type === "template-wrapper" &&
          !comp.classes?.includes("container-row")
      ) || [];

    row.Col = templates.map((templateComponent) => {
      // Map column
      const col = {
        ColId: generateUUID(),
        ColName: generateUUID(),
        Tile: null,
      };

      // Map tile
      let attributes = {};
      if (templateComponent.components){
        attributes = templateComponent.components[0].attributes || {}
      }

      console.log(attributes)

      // Find tile title
      const templateBlock = templateComponent.components?.find((comp) =>
        comp.classes?.includes("template-block")
      );
      const titleSection = templateBlock?.components?.find((comp) =>
        comp.classes?.includes("tile-title-section")
      );
      const titleSpan = titleSection?.components?.find((comp) =>
        comp.classes?.includes("tile-title")
      );
      const titleText = titleSpan?.components?.[0]?.content || "";

      // Create tile object

      let tileActionObjectId = attributes["tile-action-object-id"]
      col.Tile = {
        TileId: generateUUID(),
        TileName: titleText,
        TileText: titleText,
        TileTextColor: attributes["tile-text-color"], // Not present in source data
        TileTextAlignment: attributes["tile-text-align"] || "center",

        TileIcon: attributes["tile-icon"] || "",
        TileIconColor: attributes["tile-icon-color"] || "",
        TileIconAlignment: attributes["tile-icon-align"] || "center",

        TileBGColor: attributes["tile-bgcolor"] || "",
        TileBGImageUrl: attributes["tile-bg-image-url"] || "",
        TileBGImageOpacity: attributes["tile-bg-image-opacity"] || "",

        ProductServiceId: "00000000-0000-0000-0000-000000000000",
        ProductServiceName: "",
        ProductServiceDescription: "",
        ProductServiceImage: "",
        TileAction: {
          ObjectType: attributes['tile-action-object'],
          ObjectId: (tileActionObjectId == "") ? "00000000-0000-0000-0000-000000000000" : tileActionObjectId
        }
      };

      return col;
    });

    return row;
  });

  return pageData;
}

function mapContentToPageData(templateData) {
  const page = templateData.pages[0];
  const components =
    page.frames[0].component.components[0].components[0].components;

  const output = {
    PageId: localStorage.getItem("pageId"),
    PageName: localStorage.getItem("pageName"),
    Content: [],
    Cta: [],
  };

  // Find image and text content
  components.forEach((component) => {
    // Image content
    const imageComponent =
      component.components?.[0]?.components?.[0]?.components?.[0];
    if (imageComponent?.type === "image") {
      console.log('imageComponent?.attributes.src', imageComponent?.attributes.src)
      output.Content.push({
        ContentType: "Image",
        ContentValue: baseURL + '/' + imageComponent?.attributes.src,
      });
    }

    // Text content
    const textComponent =
      component.components?.[0]?.components?.[0]?.components?.[0];
    if (textComponent?.tagName === "p") {
      const textContent = textComponent.components?.[0]?.content?.trim();
      if (textContent) {
        output.Content.push({
          ContentType: "Description",
          ContentValue: textContent,
        });
      }
    }

    // CTA buttons
    if (component.classes?.includes("cta-button-container")) {
      const ctaChildren = component.components;
      
      ctaChildren.forEach((ctaChild) => {
      const attributes = ctaChild.attributes || {};
        if (ctaChild.classes?.includes("cta-container-child")) {
          output.Cta.push({
              CtaId: attributes["cta-button-id"],
              CtaType: attributes["cta-button-type"],
              CtaLabel: attributes["cta-button-label"] || "Email Us",
              CtaAction: attributes["cta-button-action"],
              CtaBGColor: attributes["cta-background-color"] || "#EEA622",
          });
        }
      });
    }

    // Website CTA
    const websiteButton =
      component.components?.[0]?.components?.[0]?.components?.[0];
      const websiteAttributes = websiteButton.attributes || {};
    if (websiteButton?.classes?.includes("cta-url-button")) {
      output.Cta.push({
          CtaType: websiteAttributes["cta-button-type"],
          CtaLabel: websiteAttributes["cta-button-label"] || "Email Us",
          CtaAction: websiteAttributes["cta-button-action"],
          CtaBGColor: websiteAttributes["cta-background-color"] || "#EEA622",
      });
    }

    // Form CTA
    const formButton =
      component.components?.[0]?.components?.[0]?.components?.[0];
      const formAttributes = websiteButton.attributes || {};
    if (websiteButton?.classes?.includes("cta-form-button")) {
      output.Cta.push({
          CtaType: formAttributes["cta-button-type"],
          CtaLabel: formAttributes["cta-button-label"] || "Fill Form",
          CtaAction: formAttributes["cta-button-action"],
          CtaBGColor: formAttributes["cta-background-color"] || "#EEA622",
      });
    }
  });

  return output;
}
