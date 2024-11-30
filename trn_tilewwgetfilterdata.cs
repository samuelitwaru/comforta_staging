using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trn_tilewwgetfilterdata : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "trn_tileww_Services_Execute" ;
         }

      }

      public trn_tilewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_tilewwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV45DDOName = aP0_DDOName;
         this.AV46SearchTxtParms = aP1_SearchTxtParms;
         this.AV47SearchTxtTo = aP2_SearchTxtTo;
         this.AV48OptionsJson = "" ;
         this.AV49OptionsDescJson = "" ;
         this.AV50OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV50OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV45DDOName = aP0_DDOName;
         this.AV46SearchTxtParms = aP1_SearchTxtParms;
         this.AV47SearchTxtTo = aP2_SearchTxtTo;
         this.AV48OptionsJson = "" ;
         this.AV49OptionsDescJson = "" ;
         this.AV50OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV35Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV37OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV38OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32MaxItems = 10;
         AV31PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV46SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV29SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? "" : StringUtil.Substring( AV46SearchTxtParms, 3, -1));
         AV30SkipItems = (short)(AV31PageIndex*AV32MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_TILENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADTILENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_TILEBGCOLOR") == 0 )
         {
            /* Execute user subroutine: 'LOADTILEBGCOLOROPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_TILEBGIMAGEURL") == 0 )
         {
            /* Execute user subroutine: 'LOADTILEBGIMAGEURLOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_TILETEXTCOLOR") == 0 )
         {
            /* Execute user subroutine: 'LOADTILETEXTCOLOROPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_TILEICON") == 0 )
         {
            /* Execute user subroutine: 'LOADTILEICONOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_TILEICONCOLOR") == 0 )
         {
            /* Execute user subroutine: 'LOADTILEICONCOLOROPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_TILEACTION") == 0 )
         {
            /* Execute user subroutine: 'LOADTILEACTIONOPTIONS' */
            S181 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV48OptionsJson = AV35Options.ToJSonString(false);
         AV49OptionsDescJson = AV37OptionsDesc.ToJSonString(false);
         AV50OptionIndexesJson = AV38OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get("Trn_TileWWGridState"), "") == 0 )
         {
            AV42GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Trn_TileWWGridState"), null, "", "");
         }
         else
         {
            AV42GridState.FromXml(AV40Session.Get("Trn_TileWWGridState"), null, "", "");
         }
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV42GridState.gxTpr_Filtervalues.Count )
         {
            AV43GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV42GridState.gxTpr_Filtervalues.Item(AV52GXV1));
            if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV51FilterFullText = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFTILENAME") == 0 )
            {
               AV11TFTileName = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFTILENAME_SEL") == 0 )
            {
               AV12TFTileName_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFTILEBGCOLOR") == 0 )
            {
               AV13TFTileBGColor = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFTILEBGCOLOR_SEL") == 0 )
            {
               AV14TFTileBGColor_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFTILEBGIMAGEURL") == 0 )
            {
               AV15TFTileBGImageUrl = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFTILEBGIMAGEURL_SEL") == 0 )
            {
               AV16TFTileBGImageUrl_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFTILETEXTCOLOR") == 0 )
            {
               AV17TFTileTextColor = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFTILETEXTCOLOR_SEL") == 0 )
            {
               AV18TFTileTextColor_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFTILETEXTALIGNMENT_SEL") == 0 )
            {
               AV19TFTileTextAlignment_SelsJson = AV43GridStateFilterValue.gxTpr_Value;
               AV20TFTileTextAlignment_Sels.FromJSonString(AV19TFTileTextAlignment_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFTILEICON") == 0 )
            {
               AV21TFTileIcon = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFTILEICON_SEL") == 0 )
            {
               AV22TFTileIcon_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFTILEICONALIGNMENT_SEL") == 0 )
            {
               AV23TFTileIconAlignment_SelsJson = AV43GridStateFilterValue.gxTpr_Value;
               AV24TFTileIconAlignment_Sels.FromJSonString(AV23TFTileIconAlignment_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFTILEICONCOLOR") == 0 )
            {
               AV25TFTileIconColor = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFTILEICONCOLOR_SEL") == 0 )
            {
               AV26TFTileIconColor_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFTILEACTION") == 0 )
            {
               AV27TFTileAction = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFTILEACTION_SEL") == 0 )
            {
               AV28TFTileAction_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTILENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFTileName = AV29SearchTxt;
         AV12TFTileName_Sel = "";
         AV54Trn_tilewwds_1_filterfulltext = AV51FilterFullText;
         AV55Trn_tilewwds_2_tftilename = AV11TFTileName;
         AV56Trn_tilewwds_3_tftilename_sel = AV12TFTileName_Sel;
         AV57Trn_tilewwds_4_tftilebgcolor = AV13TFTileBGColor;
         AV58Trn_tilewwds_5_tftilebgcolor_sel = AV14TFTileBGColor_Sel;
         AV59Trn_tilewwds_6_tftilebgimageurl = AV15TFTileBGImageUrl;
         AV60Trn_tilewwds_7_tftilebgimageurl_sel = AV16TFTileBGImageUrl_Sel;
         AV61Trn_tilewwds_8_tftiletextcolor = AV17TFTileTextColor;
         AV62Trn_tilewwds_9_tftiletextcolor_sel = AV18TFTileTextColor_Sel;
         AV63Trn_tilewwds_10_tftiletextalignment_sels = AV20TFTileTextAlignment_Sels;
         AV64Trn_tilewwds_11_tftileicon = AV21TFTileIcon;
         AV65Trn_tilewwds_12_tftileicon_sel = AV22TFTileIcon_Sel;
         AV66Trn_tilewwds_13_tftileiconalignment_sels = AV24TFTileIconAlignment_Sels;
         AV67Trn_tilewwds_14_tftileiconcolor = AV25TFTileIconColor;
         AV68Trn_tilewwds_15_tftileiconcolor_sel = AV26TFTileIconColor_Sel;
         AV69Trn_tilewwds_16_tftileaction = AV27TFTileAction;
         AV70Trn_tilewwds_17_tftileaction_sel = AV28TFTileAction_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A405TileTextAlignment ,
                                              AV63Trn_tilewwds_10_tftiletextalignment_sels ,
                                              A406TileIconAlignment ,
                                              AV66Trn_tilewwds_13_tftileiconalignment_sels ,
                                              AV56Trn_tilewwds_3_tftilename_sel ,
                                              AV55Trn_tilewwds_2_tftilename ,
                                              AV58Trn_tilewwds_5_tftilebgcolor_sel ,
                                              AV57Trn_tilewwds_4_tftilebgcolor ,
                                              AV60Trn_tilewwds_7_tftilebgimageurl_sel ,
                                              AV59Trn_tilewwds_6_tftilebgimageurl ,
                                              AV62Trn_tilewwds_9_tftiletextcolor_sel ,
                                              AV61Trn_tilewwds_8_tftiletextcolor ,
                                              AV63Trn_tilewwds_10_tftiletextalignment_sels.Count ,
                                              AV65Trn_tilewwds_12_tftileicon_sel ,
                                              AV64Trn_tilewwds_11_tftileicon ,
                                              AV66Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                              AV68Trn_tilewwds_15_tftileiconcolor_sel ,
                                              AV67Trn_tilewwds_14_tftileiconcolor ,
                                              AV70Trn_tilewwds_17_tftileaction_sel ,
                                              AV69Trn_tilewwds_16_tftileaction ,
                                              A400TileName ,
                                              A402TileBGColor ,
                                              A403TileBGImageUrl ,
                                              A404TileTextColor ,
                                              A401TileIcon ,
                                              A438TileIconColor ,
                                              A436TileAction ,
                                              AV54Trn_tilewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV55Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV55Trn_tilewwds_2_tftilename), "%", "");
         lV57Trn_tilewwds_4_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV57Trn_tilewwds_4_tftilebgcolor), 20, "%");
         lV59Trn_tilewwds_6_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV59Trn_tilewwds_6_tftilebgimageurl), "%", "");
         lV61Trn_tilewwds_8_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV61Trn_tilewwds_8_tftiletextcolor), 20, "%");
         lV64Trn_tilewwds_11_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV64Trn_tilewwds_11_tftileicon), 20, "%");
         lV67Trn_tilewwds_14_tftileiconcolor = StringUtil.PadR( StringUtil.RTrim( AV67Trn_tilewwds_14_tftileiconcolor), 20, "%");
         lV69Trn_tilewwds_16_tftileaction = StringUtil.Concat( StringUtil.RTrim( AV69Trn_tilewwds_16_tftileaction), "%", "");
         /* Using cursor P00922 */
         pr_default.execute(0, new Object[] {lV55Trn_tilewwds_2_tftilename, AV56Trn_tilewwds_3_tftilename_sel, lV57Trn_tilewwds_4_tftilebgcolor, AV58Trn_tilewwds_5_tftilebgcolor_sel, lV59Trn_tilewwds_6_tftilebgimageurl, AV60Trn_tilewwds_7_tftilebgimageurl_sel, lV61Trn_tilewwds_8_tftiletextcolor, AV62Trn_tilewwds_9_tftiletextcolor_sel, lV64Trn_tilewwds_11_tftileicon, AV65Trn_tilewwds_12_tftileicon_sel, lV67Trn_tilewwds_14_tftileiconcolor, AV68Trn_tilewwds_15_tftileiconcolor_sel, lV69Trn_tilewwds_16_tftileaction, AV70Trn_tilewwds_17_tftileaction_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK922 = false;
            A400TileName = P00922_A400TileName[0];
            A436TileAction = P00922_A436TileAction[0];
            A438TileIconColor = P00922_A438TileIconColor[0];
            A406TileIconAlignment = P00922_A406TileIconAlignment[0];
            A401TileIcon = P00922_A401TileIcon[0];
            n401TileIcon = P00922_n401TileIcon[0];
            A405TileTextAlignment = P00922_A405TileTextAlignment[0];
            A404TileTextColor = P00922_A404TileTextColor[0];
            A403TileBGImageUrl = P00922_A403TileBGImageUrl[0];
            n403TileBGImageUrl = P00922_n403TileBGImageUrl[0];
            A402TileBGColor = P00922_A402TileBGColor[0];
            n402TileBGColor = P00922_n402TileBGColor[0];
            A407TileId = P00922_A407TileId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A438TileIconColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A436TileAction , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) )
            )
            {
               AV39count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00922_A400TileName[0], A400TileName) == 0 ) )
               {
                  BRK922 = false;
                  A407TileId = P00922_A407TileId[0];
                  AV39count = (long)(AV39count+1);
                  BRK922 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV30SkipItems) )
               {
                  AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A400TileName)) ? "<#Empty#>" : A400TileName);
                  AV35Options.Add(AV34Option, 0);
                  AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV35Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV30SkipItems = (short)(AV30SkipItems-1);
               }
            }
            if ( ! BRK922 )
            {
               BRK922 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTILEBGCOLOROPTIONS' Routine */
         returnInSub = false;
         AV13TFTileBGColor = AV29SearchTxt;
         AV14TFTileBGColor_Sel = "";
         AV54Trn_tilewwds_1_filterfulltext = AV51FilterFullText;
         AV55Trn_tilewwds_2_tftilename = AV11TFTileName;
         AV56Trn_tilewwds_3_tftilename_sel = AV12TFTileName_Sel;
         AV57Trn_tilewwds_4_tftilebgcolor = AV13TFTileBGColor;
         AV58Trn_tilewwds_5_tftilebgcolor_sel = AV14TFTileBGColor_Sel;
         AV59Trn_tilewwds_6_tftilebgimageurl = AV15TFTileBGImageUrl;
         AV60Trn_tilewwds_7_tftilebgimageurl_sel = AV16TFTileBGImageUrl_Sel;
         AV61Trn_tilewwds_8_tftiletextcolor = AV17TFTileTextColor;
         AV62Trn_tilewwds_9_tftiletextcolor_sel = AV18TFTileTextColor_Sel;
         AV63Trn_tilewwds_10_tftiletextalignment_sels = AV20TFTileTextAlignment_Sels;
         AV64Trn_tilewwds_11_tftileicon = AV21TFTileIcon;
         AV65Trn_tilewwds_12_tftileicon_sel = AV22TFTileIcon_Sel;
         AV66Trn_tilewwds_13_tftileiconalignment_sels = AV24TFTileIconAlignment_Sels;
         AV67Trn_tilewwds_14_tftileiconcolor = AV25TFTileIconColor;
         AV68Trn_tilewwds_15_tftileiconcolor_sel = AV26TFTileIconColor_Sel;
         AV69Trn_tilewwds_16_tftileaction = AV27TFTileAction;
         AV70Trn_tilewwds_17_tftileaction_sel = AV28TFTileAction_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A405TileTextAlignment ,
                                              AV63Trn_tilewwds_10_tftiletextalignment_sels ,
                                              A406TileIconAlignment ,
                                              AV66Trn_tilewwds_13_tftileiconalignment_sels ,
                                              AV56Trn_tilewwds_3_tftilename_sel ,
                                              AV55Trn_tilewwds_2_tftilename ,
                                              AV58Trn_tilewwds_5_tftilebgcolor_sel ,
                                              AV57Trn_tilewwds_4_tftilebgcolor ,
                                              AV60Trn_tilewwds_7_tftilebgimageurl_sel ,
                                              AV59Trn_tilewwds_6_tftilebgimageurl ,
                                              AV62Trn_tilewwds_9_tftiletextcolor_sel ,
                                              AV61Trn_tilewwds_8_tftiletextcolor ,
                                              AV63Trn_tilewwds_10_tftiletextalignment_sels.Count ,
                                              AV65Trn_tilewwds_12_tftileicon_sel ,
                                              AV64Trn_tilewwds_11_tftileicon ,
                                              AV66Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                              AV68Trn_tilewwds_15_tftileiconcolor_sel ,
                                              AV67Trn_tilewwds_14_tftileiconcolor ,
                                              AV70Trn_tilewwds_17_tftileaction_sel ,
                                              AV69Trn_tilewwds_16_tftileaction ,
                                              A400TileName ,
                                              A402TileBGColor ,
                                              A403TileBGImageUrl ,
                                              A404TileTextColor ,
                                              A401TileIcon ,
                                              A438TileIconColor ,
                                              A436TileAction ,
                                              AV54Trn_tilewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV55Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV55Trn_tilewwds_2_tftilename), "%", "");
         lV57Trn_tilewwds_4_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV57Trn_tilewwds_4_tftilebgcolor), 20, "%");
         lV59Trn_tilewwds_6_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV59Trn_tilewwds_6_tftilebgimageurl), "%", "");
         lV61Trn_tilewwds_8_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV61Trn_tilewwds_8_tftiletextcolor), 20, "%");
         lV64Trn_tilewwds_11_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV64Trn_tilewwds_11_tftileicon), 20, "%");
         lV67Trn_tilewwds_14_tftileiconcolor = StringUtil.PadR( StringUtil.RTrim( AV67Trn_tilewwds_14_tftileiconcolor), 20, "%");
         lV69Trn_tilewwds_16_tftileaction = StringUtil.Concat( StringUtil.RTrim( AV69Trn_tilewwds_16_tftileaction), "%", "");
         /* Using cursor P00923 */
         pr_default.execute(1, new Object[] {lV55Trn_tilewwds_2_tftilename, AV56Trn_tilewwds_3_tftilename_sel, lV57Trn_tilewwds_4_tftilebgcolor, AV58Trn_tilewwds_5_tftilebgcolor_sel, lV59Trn_tilewwds_6_tftilebgimageurl, AV60Trn_tilewwds_7_tftilebgimageurl_sel, lV61Trn_tilewwds_8_tftiletextcolor, AV62Trn_tilewwds_9_tftiletextcolor_sel, lV64Trn_tilewwds_11_tftileicon, AV65Trn_tilewwds_12_tftileicon_sel, lV67Trn_tilewwds_14_tftileiconcolor, AV68Trn_tilewwds_15_tftileiconcolor_sel, lV69Trn_tilewwds_16_tftileaction, AV70Trn_tilewwds_17_tftileaction_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK924 = false;
            A402TileBGColor = P00923_A402TileBGColor[0];
            n402TileBGColor = P00923_n402TileBGColor[0];
            A436TileAction = P00923_A436TileAction[0];
            A438TileIconColor = P00923_A438TileIconColor[0];
            A406TileIconAlignment = P00923_A406TileIconAlignment[0];
            A401TileIcon = P00923_A401TileIcon[0];
            n401TileIcon = P00923_n401TileIcon[0];
            A405TileTextAlignment = P00923_A405TileTextAlignment[0];
            A404TileTextColor = P00923_A404TileTextColor[0];
            A403TileBGImageUrl = P00923_A403TileBGImageUrl[0];
            n403TileBGImageUrl = P00923_n403TileBGImageUrl[0];
            A400TileName = P00923_A400TileName[0];
            A407TileId = P00923_A407TileId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A438TileIconColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A436TileAction , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) )
            )
            {
               AV39count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00923_A402TileBGColor[0], A402TileBGColor) == 0 ) )
               {
                  BRK924 = false;
                  A407TileId = P00923_A407TileId[0];
                  AV39count = (long)(AV39count+1);
                  BRK924 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV30SkipItems) )
               {
                  AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A402TileBGColor)) ? "<#Empty#>" : A402TileBGColor);
                  AV35Options.Add(AV34Option, 0);
                  AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV35Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV30SkipItems = (short)(AV30SkipItems-1);
               }
            }
            if ( ! BRK924 )
            {
               BRK924 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADTILEBGIMAGEURLOPTIONS' Routine */
         returnInSub = false;
         AV15TFTileBGImageUrl = AV29SearchTxt;
         AV16TFTileBGImageUrl_Sel = "";
         AV54Trn_tilewwds_1_filterfulltext = AV51FilterFullText;
         AV55Trn_tilewwds_2_tftilename = AV11TFTileName;
         AV56Trn_tilewwds_3_tftilename_sel = AV12TFTileName_Sel;
         AV57Trn_tilewwds_4_tftilebgcolor = AV13TFTileBGColor;
         AV58Trn_tilewwds_5_tftilebgcolor_sel = AV14TFTileBGColor_Sel;
         AV59Trn_tilewwds_6_tftilebgimageurl = AV15TFTileBGImageUrl;
         AV60Trn_tilewwds_7_tftilebgimageurl_sel = AV16TFTileBGImageUrl_Sel;
         AV61Trn_tilewwds_8_tftiletextcolor = AV17TFTileTextColor;
         AV62Trn_tilewwds_9_tftiletextcolor_sel = AV18TFTileTextColor_Sel;
         AV63Trn_tilewwds_10_tftiletextalignment_sels = AV20TFTileTextAlignment_Sels;
         AV64Trn_tilewwds_11_tftileicon = AV21TFTileIcon;
         AV65Trn_tilewwds_12_tftileicon_sel = AV22TFTileIcon_Sel;
         AV66Trn_tilewwds_13_tftileiconalignment_sels = AV24TFTileIconAlignment_Sels;
         AV67Trn_tilewwds_14_tftileiconcolor = AV25TFTileIconColor;
         AV68Trn_tilewwds_15_tftileiconcolor_sel = AV26TFTileIconColor_Sel;
         AV69Trn_tilewwds_16_tftileaction = AV27TFTileAction;
         AV70Trn_tilewwds_17_tftileaction_sel = AV28TFTileAction_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A405TileTextAlignment ,
                                              AV63Trn_tilewwds_10_tftiletextalignment_sels ,
                                              A406TileIconAlignment ,
                                              AV66Trn_tilewwds_13_tftileiconalignment_sels ,
                                              AV56Trn_tilewwds_3_tftilename_sel ,
                                              AV55Trn_tilewwds_2_tftilename ,
                                              AV58Trn_tilewwds_5_tftilebgcolor_sel ,
                                              AV57Trn_tilewwds_4_tftilebgcolor ,
                                              AV60Trn_tilewwds_7_tftilebgimageurl_sel ,
                                              AV59Trn_tilewwds_6_tftilebgimageurl ,
                                              AV62Trn_tilewwds_9_tftiletextcolor_sel ,
                                              AV61Trn_tilewwds_8_tftiletextcolor ,
                                              AV63Trn_tilewwds_10_tftiletextalignment_sels.Count ,
                                              AV65Trn_tilewwds_12_tftileicon_sel ,
                                              AV64Trn_tilewwds_11_tftileicon ,
                                              AV66Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                              AV68Trn_tilewwds_15_tftileiconcolor_sel ,
                                              AV67Trn_tilewwds_14_tftileiconcolor ,
                                              AV70Trn_tilewwds_17_tftileaction_sel ,
                                              AV69Trn_tilewwds_16_tftileaction ,
                                              A400TileName ,
                                              A402TileBGColor ,
                                              A403TileBGImageUrl ,
                                              A404TileTextColor ,
                                              A401TileIcon ,
                                              A438TileIconColor ,
                                              A436TileAction ,
                                              AV54Trn_tilewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV55Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV55Trn_tilewwds_2_tftilename), "%", "");
         lV57Trn_tilewwds_4_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV57Trn_tilewwds_4_tftilebgcolor), 20, "%");
         lV59Trn_tilewwds_6_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV59Trn_tilewwds_6_tftilebgimageurl), "%", "");
         lV61Trn_tilewwds_8_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV61Trn_tilewwds_8_tftiletextcolor), 20, "%");
         lV64Trn_tilewwds_11_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV64Trn_tilewwds_11_tftileicon), 20, "%");
         lV67Trn_tilewwds_14_tftileiconcolor = StringUtil.PadR( StringUtil.RTrim( AV67Trn_tilewwds_14_tftileiconcolor), 20, "%");
         lV69Trn_tilewwds_16_tftileaction = StringUtil.Concat( StringUtil.RTrim( AV69Trn_tilewwds_16_tftileaction), "%", "");
         /* Using cursor P00924 */
         pr_default.execute(2, new Object[] {lV55Trn_tilewwds_2_tftilename, AV56Trn_tilewwds_3_tftilename_sel, lV57Trn_tilewwds_4_tftilebgcolor, AV58Trn_tilewwds_5_tftilebgcolor_sel, lV59Trn_tilewwds_6_tftilebgimageurl, AV60Trn_tilewwds_7_tftilebgimageurl_sel, lV61Trn_tilewwds_8_tftiletextcolor, AV62Trn_tilewwds_9_tftiletextcolor_sel, lV64Trn_tilewwds_11_tftileicon, AV65Trn_tilewwds_12_tftileicon_sel, lV67Trn_tilewwds_14_tftileiconcolor, AV68Trn_tilewwds_15_tftileiconcolor_sel, lV69Trn_tilewwds_16_tftileaction, AV70Trn_tilewwds_17_tftileaction_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK926 = false;
            A403TileBGImageUrl = P00924_A403TileBGImageUrl[0];
            n403TileBGImageUrl = P00924_n403TileBGImageUrl[0];
            A436TileAction = P00924_A436TileAction[0];
            A438TileIconColor = P00924_A438TileIconColor[0];
            A406TileIconAlignment = P00924_A406TileIconAlignment[0];
            A401TileIcon = P00924_A401TileIcon[0];
            n401TileIcon = P00924_n401TileIcon[0];
            A405TileTextAlignment = P00924_A405TileTextAlignment[0];
            A404TileTextColor = P00924_A404TileTextColor[0];
            A402TileBGColor = P00924_A402TileBGColor[0];
            n402TileBGColor = P00924_n402TileBGColor[0];
            A400TileName = P00924_A400TileName[0];
            A407TileId = P00924_A407TileId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A438TileIconColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A436TileAction , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) )
            )
            {
               AV39count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00924_A403TileBGImageUrl[0], A403TileBGImageUrl) == 0 ) )
               {
                  BRK926 = false;
                  A407TileId = P00924_A407TileId[0];
                  AV39count = (long)(AV39count+1);
                  BRK926 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV30SkipItems) )
               {
                  AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A403TileBGImageUrl)) ? "<#Empty#>" : A403TileBGImageUrl);
                  AV35Options.Add(AV34Option, 0);
                  AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV35Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV30SkipItems = (short)(AV30SkipItems-1);
               }
            }
            if ( ! BRK926 )
            {
               BRK926 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADTILETEXTCOLOROPTIONS' Routine */
         returnInSub = false;
         AV17TFTileTextColor = AV29SearchTxt;
         AV18TFTileTextColor_Sel = "";
         AV54Trn_tilewwds_1_filterfulltext = AV51FilterFullText;
         AV55Trn_tilewwds_2_tftilename = AV11TFTileName;
         AV56Trn_tilewwds_3_tftilename_sel = AV12TFTileName_Sel;
         AV57Trn_tilewwds_4_tftilebgcolor = AV13TFTileBGColor;
         AV58Trn_tilewwds_5_tftilebgcolor_sel = AV14TFTileBGColor_Sel;
         AV59Trn_tilewwds_6_tftilebgimageurl = AV15TFTileBGImageUrl;
         AV60Trn_tilewwds_7_tftilebgimageurl_sel = AV16TFTileBGImageUrl_Sel;
         AV61Trn_tilewwds_8_tftiletextcolor = AV17TFTileTextColor;
         AV62Trn_tilewwds_9_tftiletextcolor_sel = AV18TFTileTextColor_Sel;
         AV63Trn_tilewwds_10_tftiletextalignment_sels = AV20TFTileTextAlignment_Sels;
         AV64Trn_tilewwds_11_tftileicon = AV21TFTileIcon;
         AV65Trn_tilewwds_12_tftileicon_sel = AV22TFTileIcon_Sel;
         AV66Trn_tilewwds_13_tftileiconalignment_sels = AV24TFTileIconAlignment_Sels;
         AV67Trn_tilewwds_14_tftileiconcolor = AV25TFTileIconColor;
         AV68Trn_tilewwds_15_tftileiconcolor_sel = AV26TFTileIconColor_Sel;
         AV69Trn_tilewwds_16_tftileaction = AV27TFTileAction;
         AV70Trn_tilewwds_17_tftileaction_sel = AV28TFTileAction_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A405TileTextAlignment ,
                                              AV63Trn_tilewwds_10_tftiletextalignment_sels ,
                                              A406TileIconAlignment ,
                                              AV66Trn_tilewwds_13_tftileiconalignment_sels ,
                                              AV56Trn_tilewwds_3_tftilename_sel ,
                                              AV55Trn_tilewwds_2_tftilename ,
                                              AV58Trn_tilewwds_5_tftilebgcolor_sel ,
                                              AV57Trn_tilewwds_4_tftilebgcolor ,
                                              AV60Trn_tilewwds_7_tftilebgimageurl_sel ,
                                              AV59Trn_tilewwds_6_tftilebgimageurl ,
                                              AV62Trn_tilewwds_9_tftiletextcolor_sel ,
                                              AV61Trn_tilewwds_8_tftiletextcolor ,
                                              AV63Trn_tilewwds_10_tftiletextalignment_sels.Count ,
                                              AV65Trn_tilewwds_12_tftileicon_sel ,
                                              AV64Trn_tilewwds_11_tftileicon ,
                                              AV66Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                              AV68Trn_tilewwds_15_tftileiconcolor_sel ,
                                              AV67Trn_tilewwds_14_tftileiconcolor ,
                                              AV70Trn_tilewwds_17_tftileaction_sel ,
                                              AV69Trn_tilewwds_16_tftileaction ,
                                              A400TileName ,
                                              A402TileBGColor ,
                                              A403TileBGImageUrl ,
                                              A404TileTextColor ,
                                              A401TileIcon ,
                                              A438TileIconColor ,
                                              A436TileAction ,
                                              AV54Trn_tilewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV55Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV55Trn_tilewwds_2_tftilename), "%", "");
         lV57Trn_tilewwds_4_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV57Trn_tilewwds_4_tftilebgcolor), 20, "%");
         lV59Trn_tilewwds_6_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV59Trn_tilewwds_6_tftilebgimageurl), "%", "");
         lV61Trn_tilewwds_8_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV61Trn_tilewwds_8_tftiletextcolor), 20, "%");
         lV64Trn_tilewwds_11_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV64Trn_tilewwds_11_tftileicon), 20, "%");
         lV67Trn_tilewwds_14_tftileiconcolor = StringUtil.PadR( StringUtil.RTrim( AV67Trn_tilewwds_14_tftileiconcolor), 20, "%");
         lV69Trn_tilewwds_16_tftileaction = StringUtil.Concat( StringUtil.RTrim( AV69Trn_tilewwds_16_tftileaction), "%", "");
         /* Using cursor P00925 */
         pr_default.execute(3, new Object[] {lV55Trn_tilewwds_2_tftilename, AV56Trn_tilewwds_3_tftilename_sel, lV57Trn_tilewwds_4_tftilebgcolor, AV58Trn_tilewwds_5_tftilebgcolor_sel, lV59Trn_tilewwds_6_tftilebgimageurl, AV60Trn_tilewwds_7_tftilebgimageurl_sel, lV61Trn_tilewwds_8_tftiletextcolor, AV62Trn_tilewwds_9_tftiletextcolor_sel, lV64Trn_tilewwds_11_tftileicon, AV65Trn_tilewwds_12_tftileicon_sel, lV67Trn_tilewwds_14_tftileiconcolor, AV68Trn_tilewwds_15_tftileiconcolor_sel, lV69Trn_tilewwds_16_tftileaction, AV70Trn_tilewwds_17_tftileaction_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK928 = false;
            A404TileTextColor = P00925_A404TileTextColor[0];
            A436TileAction = P00925_A436TileAction[0];
            A438TileIconColor = P00925_A438TileIconColor[0];
            A406TileIconAlignment = P00925_A406TileIconAlignment[0];
            A401TileIcon = P00925_A401TileIcon[0];
            n401TileIcon = P00925_n401TileIcon[0];
            A405TileTextAlignment = P00925_A405TileTextAlignment[0];
            A403TileBGImageUrl = P00925_A403TileBGImageUrl[0];
            n403TileBGImageUrl = P00925_n403TileBGImageUrl[0];
            A402TileBGColor = P00925_A402TileBGColor[0];
            n402TileBGColor = P00925_n402TileBGColor[0];
            A400TileName = P00925_A400TileName[0];
            A407TileId = P00925_A407TileId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A438TileIconColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A436TileAction , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) )
            )
            {
               AV39count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00925_A404TileTextColor[0], A404TileTextColor) == 0 ) )
               {
                  BRK928 = false;
                  A407TileId = P00925_A407TileId[0];
                  AV39count = (long)(AV39count+1);
                  BRK928 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV30SkipItems) )
               {
                  AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A404TileTextColor)) ? "<#Empty#>" : A404TileTextColor);
                  AV35Options.Add(AV34Option, 0);
                  AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV35Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV30SkipItems = (short)(AV30SkipItems-1);
               }
            }
            if ( ! BRK928 )
            {
               BRK928 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADTILEICONOPTIONS' Routine */
         returnInSub = false;
         AV21TFTileIcon = AV29SearchTxt;
         AV22TFTileIcon_Sel = "";
         AV54Trn_tilewwds_1_filterfulltext = AV51FilterFullText;
         AV55Trn_tilewwds_2_tftilename = AV11TFTileName;
         AV56Trn_tilewwds_3_tftilename_sel = AV12TFTileName_Sel;
         AV57Trn_tilewwds_4_tftilebgcolor = AV13TFTileBGColor;
         AV58Trn_tilewwds_5_tftilebgcolor_sel = AV14TFTileBGColor_Sel;
         AV59Trn_tilewwds_6_tftilebgimageurl = AV15TFTileBGImageUrl;
         AV60Trn_tilewwds_7_tftilebgimageurl_sel = AV16TFTileBGImageUrl_Sel;
         AV61Trn_tilewwds_8_tftiletextcolor = AV17TFTileTextColor;
         AV62Trn_tilewwds_9_tftiletextcolor_sel = AV18TFTileTextColor_Sel;
         AV63Trn_tilewwds_10_tftiletextalignment_sels = AV20TFTileTextAlignment_Sels;
         AV64Trn_tilewwds_11_tftileicon = AV21TFTileIcon;
         AV65Trn_tilewwds_12_tftileicon_sel = AV22TFTileIcon_Sel;
         AV66Trn_tilewwds_13_tftileiconalignment_sels = AV24TFTileIconAlignment_Sels;
         AV67Trn_tilewwds_14_tftileiconcolor = AV25TFTileIconColor;
         AV68Trn_tilewwds_15_tftileiconcolor_sel = AV26TFTileIconColor_Sel;
         AV69Trn_tilewwds_16_tftileaction = AV27TFTileAction;
         AV70Trn_tilewwds_17_tftileaction_sel = AV28TFTileAction_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A405TileTextAlignment ,
                                              AV63Trn_tilewwds_10_tftiletextalignment_sels ,
                                              A406TileIconAlignment ,
                                              AV66Trn_tilewwds_13_tftileiconalignment_sels ,
                                              AV56Trn_tilewwds_3_tftilename_sel ,
                                              AV55Trn_tilewwds_2_tftilename ,
                                              AV58Trn_tilewwds_5_tftilebgcolor_sel ,
                                              AV57Trn_tilewwds_4_tftilebgcolor ,
                                              AV60Trn_tilewwds_7_tftilebgimageurl_sel ,
                                              AV59Trn_tilewwds_6_tftilebgimageurl ,
                                              AV62Trn_tilewwds_9_tftiletextcolor_sel ,
                                              AV61Trn_tilewwds_8_tftiletextcolor ,
                                              AV63Trn_tilewwds_10_tftiletextalignment_sels.Count ,
                                              AV65Trn_tilewwds_12_tftileicon_sel ,
                                              AV64Trn_tilewwds_11_tftileicon ,
                                              AV66Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                              AV68Trn_tilewwds_15_tftileiconcolor_sel ,
                                              AV67Trn_tilewwds_14_tftileiconcolor ,
                                              AV70Trn_tilewwds_17_tftileaction_sel ,
                                              AV69Trn_tilewwds_16_tftileaction ,
                                              A400TileName ,
                                              A402TileBGColor ,
                                              A403TileBGImageUrl ,
                                              A404TileTextColor ,
                                              A401TileIcon ,
                                              A438TileIconColor ,
                                              A436TileAction ,
                                              AV54Trn_tilewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV55Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV55Trn_tilewwds_2_tftilename), "%", "");
         lV57Trn_tilewwds_4_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV57Trn_tilewwds_4_tftilebgcolor), 20, "%");
         lV59Trn_tilewwds_6_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV59Trn_tilewwds_6_tftilebgimageurl), "%", "");
         lV61Trn_tilewwds_8_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV61Trn_tilewwds_8_tftiletextcolor), 20, "%");
         lV64Trn_tilewwds_11_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV64Trn_tilewwds_11_tftileicon), 20, "%");
         lV67Trn_tilewwds_14_tftileiconcolor = StringUtil.PadR( StringUtil.RTrim( AV67Trn_tilewwds_14_tftileiconcolor), 20, "%");
         lV69Trn_tilewwds_16_tftileaction = StringUtil.Concat( StringUtil.RTrim( AV69Trn_tilewwds_16_tftileaction), "%", "");
         /* Using cursor P00926 */
         pr_default.execute(4, new Object[] {lV55Trn_tilewwds_2_tftilename, AV56Trn_tilewwds_3_tftilename_sel, lV57Trn_tilewwds_4_tftilebgcolor, AV58Trn_tilewwds_5_tftilebgcolor_sel, lV59Trn_tilewwds_6_tftilebgimageurl, AV60Trn_tilewwds_7_tftilebgimageurl_sel, lV61Trn_tilewwds_8_tftiletextcolor, AV62Trn_tilewwds_9_tftiletextcolor_sel, lV64Trn_tilewwds_11_tftileicon, AV65Trn_tilewwds_12_tftileicon_sel, lV67Trn_tilewwds_14_tftileiconcolor, AV68Trn_tilewwds_15_tftileiconcolor_sel, lV69Trn_tilewwds_16_tftileaction, AV70Trn_tilewwds_17_tftileaction_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK9210 = false;
            A401TileIcon = P00926_A401TileIcon[0];
            n401TileIcon = P00926_n401TileIcon[0];
            A436TileAction = P00926_A436TileAction[0];
            A438TileIconColor = P00926_A438TileIconColor[0];
            A406TileIconAlignment = P00926_A406TileIconAlignment[0];
            A405TileTextAlignment = P00926_A405TileTextAlignment[0];
            A404TileTextColor = P00926_A404TileTextColor[0];
            A403TileBGImageUrl = P00926_A403TileBGImageUrl[0];
            n403TileBGImageUrl = P00926_n403TileBGImageUrl[0];
            A402TileBGColor = P00926_A402TileBGColor[0];
            n402TileBGColor = P00926_n402TileBGColor[0];
            A400TileName = P00926_A400TileName[0];
            A407TileId = P00926_A407TileId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A438TileIconColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A436TileAction , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) )
            )
            {
               AV39count = 0;
               while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00926_A401TileIcon[0], A401TileIcon) == 0 ) )
               {
                  BRK9210 = false;
                  A407TileId = P00926_A407TileId[0];
                  AV39count = (long)(AV39count+1);
                  BRK9210 = true;
                  pr_default.readNext(4);
               }
               if ( (0==AV30SkipItems) )
               {
                  AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A401TileIcon)) ? "<#Empty#>" : A401TileIcon);
                  AV35Options.Add(AV34Option, 0);
                  AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV35Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV30SkipItems = (short)(AV30SkipItems-1);
               }
            }
            if ( ! BRK9210 )
            {
               BRK9210 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADTILEICONCOLOROPTIONS' Routine */
         returnInSub = false;
         AV25TFTileIconColor = AV29SearchTxt;
         AV26TFTileIconColor_Sel = "";
         AV54Trn_tilewwds_1_filterfulltext = AV51FilterFullText;
         AV55Trn_tilewwds_2_tftilename = AV11TFTileName;
         AV56Trn_tilewwds_3_tftilename_sel = AV12TFTileName_Sel;
         AV57Trn_tilewwds_4_tftilebgcolor = AV13TFTileBGColor;
         AV58Trn_tilewwds_5_tftilebgcolor_sel = AV14TFTileBGColor_Sel;
         AV59Trn_tilewwds_6_tftilebgimageurl = AV15TFTileBGImageUrl;
         AV60Trn_tilewwds_7_tftilebgimageurl_sel = AV16TFTileBGImageUrl_Sel;
         AV61Trn_tilewwds_8_tftiletextcolor = AV17TFTileTextColor;
         AV62Trn_tilewwds_9_tftiletextcolor_sel = AV18TFTileTextColor_Sel;
         AV63Trn_tilewwds_10_tftiletextalignment_sels = AV20TFTileTextAlignment_Sels;
         AV64Trn_tilewwds_11_tftileicon = AV21TFTileIcon;
         AV65Trn_tilewwds_12_tftileicon_sel = AV22TFTileIcon_Sel;
         AV66Trn_tilewwds_13_tftileiconalignment_sels = AV24TFTileIconAlignment_Sels;
         AV67Trn_tilewwds_14_tftileiconcolor = AV25TFTileIconColor;
         AV68Trn_tilewwds_15_tftileiconcolor_sel = AV26TFTileIconColor_Sel;
         AV69Trn_tilewwds_16_tftileaction = AV27TFTileAction;
         AV70Trn_tilewwds_17_tftileaction_sel = AV28TFTileAction_Sel;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              A405TileTextAlignment ,
                                              AV63Trn_tilewwds_10_tftiletextalignment_sels ,
                                              A406TileIconAlignment ,
                                              AV66Trn_tilewwds_13_tftileiconalignment_sels ,
                                              AV56Trn_tilewwds_3_tftilename_sel ,
                                              AV55Trn_tilewwds_2_tftilename ,
                                              AV58Trn_tilewwds_5_tftilebgcolor_sel ,
                                              AV57Trn_tilewwds_4_tftilebgcolor ,
                                              AV60Trn_tilewwds_7_tftilebgimageurl_sel ,
                                              AV59Trn_tilewwds_6_tftilebgimageurl ,
                                              AV62Trn_tilewwds_9_tftiletextcolor_sel ,
                                              AV61Trn_tilewwds_8_tftiletextcolor ,
                                              AV63Trn_tilewwds_10_tftiletextalignment_sels.Count ,
                                              AV65Trn_tilewwds_12_tftileicon_sel ,
                                              AV64Trn_tilewwds_11_tftileicon ,
                                              AV66Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                              AV68Trn_tilewwds_15_tftileiconcolor_sel ,
                                              AV67Trn_tilewwds_14_tftileiconcolor ,
                                              AV70Trn_tilewwds_17_tftileaction_sel ,
                                              AV69Trn_tilewwds_16_tftileaction ,
                                              A400TileName ,
                                              A402TileBGColor ,
                                              A403TileBGImageUrl ,
                                              A404TileTextColor ,
                                              A401TileIcon ,
                                              A438TileIconColor ,
                                              A436TileAction ,
                                              AV54Trn_tilewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV55Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV55Trn_tilewwds_2_tftilename), "%", "");
         lV57Trn_tilewwds_4_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV57Trn_tilewwds_4_tftilebgcolor), 20, "%");
         lV59Trn_tilewwds_6_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV59Trn_tilewwds_6_tftilebgimageurl), "%", "");
         lV61Trn_tilewwds_8_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV61Trn_tilewwds_8_tftiletextcolor), 20, "%");
         lV64Trn_tilewwds_11_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV64Trn_tilewwds_11_tftileicon), 20, "%");
         lV67Trn_tilewwds_14_tftileiconcolor = StringUtil.PadR( StringUtil.RTrim( AV67Trn_tilewwds_14_tftileiconcolor), 20, "%");
         lV69Trn_tilewwds_16_tftileaction = StringUtil.Concat( StringUtil.RTrim( AV69Trn_tilewwds_16_tftileaction), "%", "");
         /* Using cursor P00927 */
         pr_default.execute(5, new Object[] {lV55Trn_tilewwds_2_tftilename, AV56Trn_tilewwds_3_tftilename_sel, lV57Trn_tilewwds_4_tftilebgcolor, AV58Trn_tilewwds_5_tftilebgcolor_sel, lV59Trn_tilewwds_6_tftilebgimageurl, AV60Trn_tilewwds_7_tftilebgimageurl_sel, lV61Trn_tilewwds_8_tftiletextcolor, AV62Trn_tilewwds_9_tftiletextcolor_sel, lV64Trn_tilewwds_11_tftileicon, AV65Trn_tilewwds_12_tftileicon_sel, lV67Trn_tilewwds_14_tftileiconcolor, AV68Trn_tilewwds_15_tftileiconcolor_sel, lV69Trn_tilewwds_16_tftileaction, AV70Trn_tilewwds_17_tftileaction_sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK9212 = false;
            A438TileIconColor = P00927_A438TileIconColor[0];
            A436TileAction = P00927_A436TileAction[0];
            A406TileIconAlignment = P00927_A406TileIconAlignment[0];
            A401TileIcon = P00927_A401TileIcon[0];
            n401TileIcon = P00927_n401TileIcon[0];
            A405TileTextAlignment = P00927_A405TileTextAlignment[0];
            A404TileTextColor = P00927_A404TileTextColor[0];
            A403TileBGImageUrl = P00927_A403TileBGImageUrl[0];
            n403TileBGImageUrl = P00927_n403TileBGImageUrl[0];
            A402TileBGColor = P00927_A402TileBGColor[0];
            n402TileBGColor = P00927_n402TileBGColor[0];
            A400TileName = P00927_A400TileName[0];
            A407TileId = P00927_A407TileId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A438TileIconColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A436TileAction , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) )
            )
            {
               AV39count = 0;
               while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P00927_A438TileIconColor[0], A438TileIconColor) == 0 ) )
               {
                  BRK9212 = false;
                  A407TileId = P00927_A407TileId[0];
                  AV39count = (long)(AV39count+1);
                  BRK9212 = true;
                  pr_default.readNext(5);
               }
               if ( (0==AV30SkipItems) )
               {
                  AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A438TileIconColor)) ? "<#Empty#>" : A438TileIconColor);
                  AV35Options.Add(AV34Option, 0);
                  AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV35Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV30SkipItems = (short)(AV30SkipItems-1);
               }
            }
            if ( ! BRK9212 )
            {
               BRK9212 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S181( )
      {
         /* 'LOADTILEACTIONOPTIONS' Routine */
         returnInSub = false;
         AV27TFTileAction = AV29SearchTxt;
         AV28TFTileAction_Sel = "";
         AV54Trn_tilewwds_1_filterfulltext = AV51FilterFullText;
         AV55Trn_tilewwds_2_tftilename = AV11TFTileName;
         AV56Trn_tilewwds_3_tftilename_sel = AV12TFTileName_Sel;
         AV57Trn_tilewwds_4_tftilebgcolor = AV13TFTileBGColor;
         AV58Trn_tilewwds_5_tftilebgcolor_sel = AV14TFTileBGColor_Sel;
         AV59Trn_tilewwds_6_tftilebgimageurl = AV15TFTileBGImageUrl;
         AV60Trn_tilewwds_7_tftilebgimageurl_sel = AV16TFTileBGImageUrl_Sel;
         AV61Trn_tilewwds_8_tftiletextcolor = AV17TFTileTextColor;
         AV62Trn_tilewwds_9_tftiletextcolor_sel = AV18TFTileTextColor_Sel;
         AV63Trn_tilewwds_10_tftiletextalignment_sels = AV20TFTileTextAlignment_Sels;
         AV64Trn_tilewwds_11_tftileicon = AV21TFTileIcon;
         AV65Trn_tilewwds_12_tftileicon_sel = AV22TFTileIcon_Sel;
         AV66Trn_tilewwds_13_tftileiconalignment_sels = AV24TFTileIconAlignment_Sels;
         AV67Trn_tilewwds_14_tftileiconcolor = AV25TFTileIconColor;
         AV68Trn_tilewwds_15_tftileiconcolor_sel = AV26TFTileIconColor_Sel;
         AV69Trn_tilewwds_16_tftileaction = AV27TFTileAction;
         AV70Trn_tilewwds_17_tftileaction_sel = AV28TFTileAction_Sel;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              A405TileTextAlignment ,
                                              AV63Trn_tilewwds_10_tftiletextalignment_sels ,
                                              A406TileIconAlignment ,
                                              AV66Trn_tilewwds_13_tftileiconalignment_sels ,
                                              AV56Trn_tilewwds_3_tftilename_sel ,
                                              AV55Trn_tilewwds_2_tftilename ,
                                              AV58Trn_tilewwds_5_tftilebgcolor_sel ,
                                              AV57Trn_tilewwds_4_tftilebgcolor ,
                                              AV60Trn_tilewwds_7_tftilebgimageurl_sel ,
                                              AV59Trn_tilewwds_6_tftilebgimageurl ,
                                              AV62Trn_tilewwds_9_tftiletextcolor_sel ,
                                              AV61Trn_tilewwds_8_tftiletextcolor ,
                                              AV63Trn_tilewwds_10_tftiletextalignment_sels.Count ,
                                              AV65Trn_tilewwds_12_tftileicon_sel ,
                                              AV64Trn_tilewwds_11_tftileicon ,
                                              AV66Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                              AV68Trn_tilewwds_15_tftileiconcolor_sel ,
                                              AV67Trn_tilewwds_14_tftileiconcolor ,
                                              AV70Trn_tilewwds_17_tftileaction_sel ,
                                              AV69Trn_tilewwds_16_tftileaction ,
                                              A400TileName ,
                                              A402TileBGColor ,
                                              A403TileBGImageUrl ,
                                              A404TileTextColor ,
                                              A401TileIcon ,
                                              A438TileIconColor ,
                                              A436TileAction ,
                                              AV54Trn_tilewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV55Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV55Trn_tilewwds_2_tftilename), "%", "");
         lV57Trn_tilewwds_4_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV57Trn_tilewwds_4_tftilebgcolor), 20, "%");
         lV59Trn_tilewwds_6_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV59Trn_tilewwds_6_tftilebgimageurl), "%", "");
         lV61Trn_tilewwds_8_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV61Trn_tilewwds_8_tftiletextcolor), 20, "%");
         lV64Trn_tilewwds_11_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV64Trn_tilewwds_11_tftileicon), 20, "%");
         lV67Trn_tilewwds_14_tftileiconcolor = StringUtil.PadR( StringUtil.RTrim( AV67Trn_tilewwds_14_tftileiconcolor), 20, "%");
         lV69Trn_tilewwds_16_tftileaction = StringUtil.Concat( StringUtil.RTrim( AV69Trn_tilewwds_16_tftileaction), "%", "");
         /* Using cursor P00928 */
         pr_default.execute(6, new Object[] {lV55Trn_tilewwds_2_tftilename, AV56Trn_tilewwds_3_tftilename_sel, lV57Trn_tilewwds_4_tftilebgcolor, AV58Trn_tilewwds_5_tftilebgcolor_sel, lV59Trn_tilewwds_6_tftilebgimageurl, AV60Trn_tilewwds_7_tftilebgimageurl_sel, lV61Trn_tilewwds_8_tftiletextcolor, AV62Trn_tilewwds_9_tftiletextcolor_sel, lV64Trn_tilewwds_11_tftileicon, AV65Trn_tilewwds_12_tftileicon_sel, lV67Trn_tilewwds_14_tftileiconcolor, AV68Trn_tilewwds_15_tftileiconcolor_sel, lV69Trn_tilewwds_16_tftileaction, AV70Trn_tilewwds_17_tftileaction_sel});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRK9214 = false;
            A436TileAction = P00928_A436TileAction[0];
            A438TileIconColor = P00928_A438TileIconColor[0];
            A406TileIconAlignment = P00928_A406TileIconAlignment[0];
            A401TileIcon = P00928_A401TileIcon[0];
            n401TileIcon = P00928_n401TileIcon[0];
            A405TileTextAlignment = P00928_A405TileTextAlignment[0];
            A404TileTextColor = P00928_A404TileTextColor[0];
            A403TileBGImageUrl = P00928_A403TileBGImageUrl[0];
            n403TileBGImageUrl = P00928_n403TileBGImageUrl[0];
            A402TileBGColor = P00928_A402TileBGColor[0];
            n402TileBGColor = P00928_n402TileBGColor[0];
            A400TileName = P00928_A400TileName[0];
            A407TileId = P00928_A407TileId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A438TileIconColor , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A436TileAction , StringUtil.PadR( "%" + AV54Trn_tilewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) )
            )
            {
               AV39count = 0;
               while ( (pr_default.getStatus(6) != 101) && ( StringUtil.StrCmp(P00928_A436TileAction[0], A436TileAction) == 0 ) )
               {
                  BRK9214 = false;
                  A407TileId = P00928_A407TileId[0];
                  AV39count = (long)(AV39count+1);
                  BRK9214 = true;
                  pr_default.readNext(6);
               }
               if ( (0==AV30SkipItems) )
               {
                  AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A436TileAction)) ? "<#Empty#>" : A436TileAction);
                  AV35Options.Add(AV34Option, 0);
                  AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV35Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV30SkipItems = (short)(AV30SkipItems-1);
               }
            }
            if ( ! BRK9214 )
            {
               BRK9214 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV48OptionsJson = "";
         AV49OptionsDescJson = "";
         AV50OptionIndexesJson = "";
         AV35Options = new GxSimpleCollection<string>();
         AV37OptionsDesc = new GxSimpleCollection<string>();
         AV38OptionIndexes = new GxSimpleCollection<string>();
         AV29SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV42GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV43GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV51FilterFullText = "";
         AV11TFTileName = "";
         AV12TFTileName_Sel = "";
         AV13TFTileBGColor = "";
         AV14TFTileBGColor_Sel = "";
         AV15TFTileBGImageUrl = "";
         AV16TFTileBGImageUrl_Sel = "";
         AV17TFTileTextColor = "";
         AV18TFTileTextColor_Sel = "";
         AV19TFTileTextAlignment_SelsJson = "";
         AV20TFTileTextAlignment_Sels = new GxSimpleCollection<string>();
         AV21TFTileIcon = "";
         AV22TFTileIcon_Sel = "";
         AV23TFTileIconAlignment_SelsJson = "";
         AV24TFTileIconAlignment_Sels = new GxSimpleCollection<string>();
         AV25TFTileIconColor = "";
         AV26TFTileIconColor_Sel = "";
         AV27TFTileAction = "";
         AV28TFTileAction_Sel = "";
         AV54Trn_tilewwds_1_filterfulltext = "";
         AV55Trn_tilewwds_2_tftilename = "";
         AV56Trn_tilewwds_3_tftilename_sel = "";
         AV57Trn_tilewwds_4_tftilebgcolor = "";
         AV58Trn_tilewwds_5_tftilebgcolor_sel = "";
         AV59Trn_tilewwds_6_tftilebgimageurl = "";
         AV60Trn_tilewwds_7_tftilebgimageurl_sel = "";
         AV61Trn_tilewwds_8_tftiletextcolor = "";
         AV62Trn_tilewwds_9_tftiletextcolor_sel = "";
         AV63Trn_tilewwds_10_tftiletextalignment_sels = new GxSimpleCollection<string>();
         AV64Trn_tilewwds_11_tftileicon = "";
         AV65Trn_tilewwds_12_tftileicon_sel = "";
         AV66Trn_tilewwds_13_tftileiconalignment_sels = new GxSimpleCollection<string>();
         AV67Trn_tilewwds_14_tftileiconcolor = "";
         AV68Trn_tilewwds_15_tftileiconcolor_sel = "";
         AV69Trn_tilewwds_16_tftileaction = "";
         AV70Trn_tilewwds_17_tftileaction_sel = "";
         lV54Trn_tilewwds_1_filterfulltext = "";
         lV55Trn_tilewwds_2_tftilename = "";
         lV57Trn_tilewwds_4_tftilebgcolor = "";
         lV59Trn_tilewwds_6_tftilebgimageurl = "";
         lV61Trn_tilewwds_8_tftiletextcolor = "";
         lV64Trn_tilewwds_11_tftileicon = "";
         lV67Trn_tilewwds_14_tftileiconcolor = "";
         lV69Trn_tilewwds_16_tftileaction = "";
         A405TileTextAlignment = "";
         A406TileIconAlignment = "";
         A400TileName = "";
         A402TileBGColor = "";
         A403TileBGImageUrl = "";
         A404TileTextColor = "";
         A401TileIcon = "";
         A438TileIconColor = "";
         A436TileAction = "";
         P00922_A400TileName = new string[] {""} ;
         P00922_A436TileAction = new string[] {""} ;
         P00922_A438TileIconColor = new string[] {""} ;
         P00922_A406TileIconAlignment = new string[] {""} ;
         P00922_A401TileIcon = new string[] {""} ;
         P00922_n401TileIcon = new bool[] {false} ;
         P00922_A405TileTextAlignment = new string[] {""} ;
         P00922_A404TileTextColor = new string[] {""} ;
         P00922_A403TileBGImageUrl = new string[] {""} ;
         P00922_n403TileBGImageUrl = new bool[] {false} ;
         P00922_A402TileBGColor = new string[] {""} ;
         P00922_n402TileBGColor = new bool[] {false} ;
         P00922_A407TileId = new Guid[] {Guid.Empty} ;
         A407TileId = Guid.Empty;
         AV34Option = "";
         P00923_A402TileBGColor = new string[] {""} ;
         P00923_n402TileBGColor = new bool[] {false} ;
         P00923_A436TileAction = new string[] {""} ;
         P00923_A438TileIconColor = new string[] {""} ;
         P00923_A406TileIconAlignment = new string[] {""} ;
         P00923_A401TileIcon = new string[] {""} ;
         P00923_n401TileIcon = new bool[] {false} ;
         P00923_A405TileTextAlignment = new string[] {""} ;
         P00923_A404TileTextColor = new string[] {""} ;
         P00923_A403TileBGImageUrl = new string[] {""} ;
         P00923_n403TileBGImageUrl = new bool[] {false} ;
         P00923_A400TileName = new string[] {""} ;
         P00923_A407TileId = new Guid[] {Guid.Empty} ;
         P00924_A403TileBGImageUrl = new string[] {""} ;
         P00924_n403TileBGImageUrl = new bool[] {false} ;
         P00924_A436TileAction = new string[] {""} ;
         P00924_A438TileIconColor = new string[] {""} ;
         P00924_A406TileIconAlignment = new string[] {""} ;
         P00924_A401TileIcon = new string[] {""} ;
         P00924_n401TileIcon = new bool[] {false} ;
         P00924_A405TileTextAlignment = new string[] {""} ;
         P00924_A404TileTextColor = new string[] {""} ;
         P00924_A402TileBGColor = new string[] {""} ;
         P00924_n402TileBGColor = new bool[] {false} ;
         P00924_A400TileName = new string[] {""} ;
         P00924_A407TileId = new Guid[] {Guid.Empty} ;
         P00925_A404TileTextColor = new string[] {""} ;
         P00925_A436TileAction = new string[] {""} ;
         P00925_A438TileIconColor = new string[] {""} ;
         P00925_A406TileIconAlignment = new string[] {""} ;
         P00925_A401TileIcon = new string[] {""} ;
         P00925_n401TileIcon = new bool[] {false} ;
         P00925_A405TileTextAlignment = new string[] {""} ;
         P00925_A403TileBGImageUrl = new string[] {""} ;
         P00925_n403TileBGImageUrl = new bool[] {false} ;
         P00925_A402TileBGColor = new string[] {""} ;
         P00925_n402TileBGColor = new bool[] {false} ;
         P00925_A400TileName = new string[] {""} ;
         P00925_A407TileId = new Guid[] {Guid.Empty} ;
         P00926_A401TileIcon = new string[] {""} ;
         P00926_n401TileIcon = new bool[] {false} ;
         P00926_A436TileAction = new string[] {""} ;
         P00926_A438TileIconColor = new string[] {""} ;
         P00926_A406TileIconAlignment = new string[] {""} ;
         P00926_A405TileTextAlignment = new string[] {""} ;
         P00926_A404TileTextColor = new string[] {""} ;
         P00926_A403TileBGImageUrl = new string[] {""} ;
         P00926_n403TileBGImageUrl = new bool[] {false} ;
         P00926_A402TileBGColor = new string[] {""} ;
         P00926_n402TileBGColor = new bool[] {false} ;
         P00926_A400TileName = new string[] {""} ;
         P00926_A407TileId = new Guid[] {Guid.Empty} ;
         P00927_A438TileIconColor = new string[] {""} ;
         P00927_A436TileAction = new string[] {""} ;
         P00927_A406TileIconAlignment = new string[] {""} ;
         P00927_A401TileIcon = new string[] {""} ;
         P00927_n401TileIcon = new bool[] {false} ;
         P00927_A405TileTextAlignment = new string[] {""} ;
         P00927_A404TileTextColor = new string[] {""} ;
         P00927_A403TileBGImageUrl = new string[] {""} ;
         P00927_n403TileBGImageUrl = new bool[] {false} ;
         P00927_A402TileBGColor = new string[] {""} ;
         P00927_n402TileBGColor = new bool[] {false} ;
         P00927_A400TileName = new string[] {""} ;
         P00927_A407TileId = new Guid[] {Guid.Empty} ;
         P00928_A436TileAction = new string[] {""} ;
         P00928_A438TileIconColor = new string[] {""} ;
         P00928_A406TileIconAlignment = new string[] {""} ;
         P00928_A401TileIcon = new string[] {""} ;
         P00928_n401TileIcon = new bool[] {false} ;
         P00928_A405TileTextAlignment = new string[] {""} ;
         P00928_A404TileTextColor = new string[] {""} ;
         P00928_A403TileBGImageUrl = new string[] {""} ;
         P00928_n403TileBGImageUrl = new bool[] {false} ;
         P00928_A402TileBGColor = new string[] {""} ;
         P00928_n402TileBGColor = new bool[] {false} ;
         P00928_A400TileName = new string[] {""} ;
         P00928_A407TileId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_tilewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00922_A400TileName, P00922_A436TileAction, P00922_A438TileIconColor, P00922_A406TileIconAlignment, P00922_A401TileIcon, P00922_n401TileIcon, P00922_A405TileTextAlignment, P00922_A404TileTextColor, P00922_A403TileBGImageUrl, P00922_n403TileBGImageUrl,
               P00922_A402TileBGColor, P00922_n402TileBGColor, P00922_A407TileId
               }
               , new Object[] {
               P00923_A402TileBGColor, P00923_n402TileBGColor, P00923_A436TileAction, P00923_A438TileIconColor, P00923_A406TileIconAlignment, P00923_A401TileIcon, P00923_n401TileIcon, P00923_A405TileTextAlignment, P00923_A404TileTextColor, P00923_A403TileBGImageUrl,
               P00923_n403TileBGImageUrl, P00923_A400TileName, P00923_A407TileId
               }
               , new Object[] {
               P00924_A403TileBGImageUrl, P00924_n403TileBGImageUrl, P00924_A436TileAction, P00924_A438TileIconColor, P00924_A406TileIconAlignment, P00924_A401TileIcon, P00924_n401TileIcon, P00924_A405TileTextAlignment, P00924_A404TileTextColor, P00924_A402TileBGColor,
               P00924_n402TileBGColor, P00924_A400TileName, P00924_A407TileId
               }
               , new Object[] {
               P00925_A404TileTextColor, P00925_A436TileAction, P00925_A438TileIconColor, P00925_A406TileIconAlignment, P00925_A401TileIcon, P00925_n401TileIcon, P00925_A405TileTextAlignment, P00925_A403TileBGImageUrl, P00925_n403TileBGImageUrl, P00925_A402TileBGColor,
               P00925_n402TileBGColor, P00925_A400TileName, P00925_A407TileId
               }
               , new Object[] {
               P00926_A401TileIcon, P00926_n401TileIcon, P00926_A436TileAction, P00926_A438TileIconColor, P00926_A406TileIconAlignment, P00926_A405TileTextAlignment, P00926_A404TileTextColor, P00926_A403TileBGImageUrl, P00926_n403TileBGImageUrl, P00926_A402TileBGColor,
               P00926_n402TileBGColor, P00926_A400TileName, P00926_A407TileId
               }
               , new Object[] {
               P00927_A438TileIconColor, P00927_A436TileAction, P00927_A406TileIconAlignment, P00927_A401TileIcon, P00927_n401TileIcon, P00927_A405TileTextAlignment, P00927_A404TileTextColor, P00927_A403TileBGImageUrl, P00927_n403TileBGImageUrl, P00927_A402TileBGColor,
               P00927_n402TileBGColor, P00927_A400TileName, P00927_A407TileId
               }
               , new Object[] {
               P00928_A436TileAction, P00928_A438TileIconColor, P00928_A406TileIconAlignment, P00928_A401TileIcon, P00928_n401TileIcon, P00928_A405TileTextAlignment, P00928_A404TileTextColor, P00928_A403TileBGImageUrl, P00928_n403TileBGImageUrl, P00928_A402TileBGColor,
               P00928_n402TileBGColor, P00928_A400TileName, P00928_A407TileId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV32MaxItems ;
      private short AV31PageIndex ;
      private short AV30SkipItems ;
      private int AV52GXV1 ;
      private int AV63Trn_tilewwds_10_tftiletextalignment_sels_Count ;
      private int AV66Trn_tilewwds_13_tftileiconalignment_sels_Count ;
      private long AV39count ;
      private string AV13TFTileBGColor ;
      private string AV14TFTileBGColor_Sel ;
      private string AV17TFTileTextColor ;
      private string AV18TFTileTextColor_Sel ;
      private string AV21TFTileIcon ;
      private string AV22TFTileIcon_Sel ;
      private string AV25TFTileIconColor ;
      private string AV26TFTileIconColor_Sel ;
      private string AV57Trn_tilewwds_4_tftilebgcolor ;
      private string AV58Trn_tilewwds_5_tftilebgcolor_sel ;
      private string AV61Trn_tilewwds_8_tftiletextcolor ;
      private string AV62Trn_tilewwds_9_tftiletextcolor_sel ;
      private string AV64Trn_tilewwds_11_tftileicon ;
      private string AV65Trn_tilewwds_12_tftileicon_sel ;
      private string AV67Trn_tilewwds_14_tftileiconcolor ;
      private string AV68Trn_tilewwds_15_tftileiconcolor_sel ;
      private string lV57Trn_tilewwds_4_tftilebgcolor ;
      private string lV61Trn_tilewwds_8_tftiletextcolor ;
      private string lV64Trn_tilewwds_11_tftileicon ;
      private string lV67Trn_tilewwds_14_tftileiconcolor ;
      private string A405TileTextAlignment ;
      private string A406TileIconAlignment ;
      private string A402TileBGColor ;
      private string A404TileTextColor ;
      private string A401TileIcon ;
      private string A438TileIconColor ;
      private bool returnInSub ;
      private bool BRK922 ;
      private bool n401TileIcon ;
      private bool n403TileBGImageUrl ;
      private bool n402TileBGColor ;
      private bool BRK924 ;
      private bool BRK926 ;
      private bool BRK928 ;
      private bool BRK9210 ;
      private bool BRK9212 ;
      private bool BRK9214 ;
      private string AV48OptionsJson ;
      private string AV49OptionsDescJson ;
      private string AV50OptionIndexesJson ;
      private string AV19TFTileTextAlignment_SelsJson ;
      private string AV23TFTileIconAlignment_SelsJson ;
      private string A436TileAction ;
      private string AV45DDOName ;
      private string AV46SearchTxtParms ;
      private string AV47SearchTxtTo ;
      private string AV29SearchTxt ;
      private string AV51FilterFullText ;
      private string AV11TFTileName ;
      private string AV12TFTileName_Sel ;
      private string AV15TFTileBGImageUrl ;
      private string AV16TFTileBGImageUrl_Sel ;
      private string AV27TFTileAction ;
      private string AV28TFTileAction_Sel ;
      private string AV54Trn_tilewwds_1_filterfulltext ;
      private string AV55Trn_tilewwds_2_tftilename ;
      private string AV56Trn_tilewwds_3_tftilename_sel ;
      private string AV59Trn_tilewwds_6_tftilebgimageurl ;
      private string AV60Trn_tilewwds_7_tftilebgimageurl_sel ;
      private string AV69Trn_tilewwds_16_tftileaction ;
      private string AV70Trn_tilewwds_17_tftileaction_sel ;
      private string lV54Trn_tilewwds_1_filterfulltext ;
      private string lV55Trn_tilewwds_2_tftilename ;
      private string lV59Trn_tilewwds_6_tftilebgimageurl ;
      private string lV69Trn_tilewwds_16_tftileaction ;
      private string A400TileName ;
      private string A403TileBGImageUrl ;
      private string AV34Option ;
      private Guid A407TileId ;
      private IGxSession AV40Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV35Options ;
      private GxSimpleCollection<string> AV37OptionsDesc ;
      private GxSimpleCollection<string> AV38OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV42GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV43GridStateFilterValue ;
      private GxSimpleCollection<string> AV20TFTileTextAlignment_Sels ;
      private GxSimpleCollection<string> AV24TFTileIconAlignment_Sels ;
      private GxSimpleCollection<string> AV63Trn_tilewwds_10_tftiletextalignment_sels ;
      private GxSimpleCollection<string> AV66Trn_tilewwds_13_tftileiconalignment_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00922_A400TileName ;
      private string[] P00922_A436TileAction ;
      private string[] P00922_A438TileIconColor ;
      private string[] P00922_A406TileIconAlignment ;
      private string[] P00922_A401TileIcon ;
      private bool[] P00922_n401TileIcon ;
      private string[] P00922_A405TileTextAlignment ;
      private string[] P00922_A404TileTextColor ;
      private string[] P00922_A403TileBGImageUrl ;
      private bool[] P00922_n403TileBGImageUrl ;
      private string[] P00922_A402TileBGColor ;
      private bool[] P00922_n402TileBGColor ;
      private Guid[] P00922_A407TileId ;
      private string[] P00923_A402TileBGColor ;
      private bool[] P00923_n402TileBGColor ;
      private string[] P00923_A436TileAction ;
      private string[] P00923_A438TileIconColor ;
      private string[] P00923_A406TileIconAlignment ;
      private string[] P00923_A401TileIcon ;
      private bool[] P00923_n401TileIcon ;
      private string[] P00923_A405TileTextAlignment ;
      private string[] P00923_A404TileTextColor ;
      private string[] P00923_A403TileBGImageUrl ;
      private bool[] P00923_n403TileBGImageUrl ;
      private string[] P00923_A400TileName ;
      private Guid[] P00923_A407TileId ;
      private string[] P00924_A403TileBGImageUrl ;
      private bool[] P00924_n403TileBGImageUrl ;
      private string[] P00924_A436TileAction ;
      private string[] P00924_A438TileIconColor ;
      private string[] P00924_A406TileIconAlignment ;
      private string[] P00924_A401TileIcon ;
      private bool[] P00924_n401TileIcon ;
      private string[] P00924_A405TileTextAlignment ;
      private string[] P00924_A404TileTextColor ;
      private string[] P00924_A402TileBGColor ;
      private bool[] P00924_n402TileBGColor ;
      private string[] P00924_A400TileName ;
      private Guid[] P00924_A407TileId ;
      private string[] P00925_A404TileTextColor ;
      private string[] P00925_A436TileAction ;
      private string[] P00925_A438TileIconColor ;
      private string[] P00925_A406TileIconAlignment ;
      private string[] P00925_A401TileIcon ;
      private bool[] P00925_n401TileIcon ;
      private string[] P00925_A405TileTextAlignment ;
      private string[] P00925_A403TileBGImageUrl ;
      private bool[] P00925_n403TileBGImageUrl ;
      private string[] P00925_A402TileBGColor ;
      private bool[] P00925_n402TileBGColor ;
      private string[] P00925_A400TileName ;
      private Guid[] P00925_A407TileId ;
      private string[] P00926_A401TileIcon ;
      private bool[] P00926_n401TileIcon ;
      private string[] P00926_A436TileAction ;
      private string[] P00926_A438TileIconColor ;
      private string[] P00926_A406TileIconAlignment ;
      private string[] P00926_A405TileTextAlignment ;
      private string[] P00926_A404TileTextColor ;
      private string[] P00926_A403TileBGImageUrl ;
      private bool[] P00926_n403TileBGImageUrl ;
      private string[] P00926_A402TileBGColor ;
      private bool[] P00926_n402TileBGColor ;
      private string[] P00926_A400TileName ;
      private Guid[] P00926_A407TileId ;
      private string[] P00927_A438TileIconColor ;
      private string[] P00927_A436TileAction ;
      private string[] P00927_A406TileIconAlignment ;
      private string[] P00927_A401TileIcon ;
      private bool[] P00927_n401TileIcon ;
      private string[] P00927_A405TileTextAlignment ;
      private string[] P00927_A404TileTextColor ;
      private string[] P00927_A403TileBGImageUrl ;
      private bool[] P00927_n403TileBGImageUrl ;
      private string[] P00927_A402TileBGColor ;
      private bool[] P00927_n402TileBGColor ;
      private string[] P00927_A400TileName ;
      private Guid[] P00927_A407TileId ;
      private string[] P00928_A436TileAction ;
      private string[] P00928_A438TileIconColor ;
      private string[] P00928_A406TileIconAlignment ;
      private string[] P00928_A401TileIcon ;
      private bool[] P00928_n401TileIcon ;
      private string[] P00928_A405TileTextAlignment ;
      private string[] P00928_A404TileTextColor ;
      private string[] P00928_A403TileBGImageUrl ;
      private bool[] P00928_n403TileBGImageUrl ;
      private string[] P00928_A402TileBGColor ;
      private bool[] P00928_n402TileBGColor ;
      private string[] P00928_A400TileName ;
      private Guid[] P00928_A407TileId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_tilewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00922( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV63Trn_tilewwds_10_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV66Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV56Trn_tilewwds_3_tftilename_sel ,
                                             string AV55Trn_tilewwds_2_tftilename ,
                                             string AV58Trn_tilewwds_5_tftilebgcolor_sel ,
                                             string AV57Trn_tilewwds_4_tftilebgcolor ,
                                             string AV60Trn_tilewwds_7_tftilebgimageurl_sel ,
                                             string AV59Trn_tilewwds_6_tftilebgimageurl ,
                                             string AV62Trn_tilewwds_9_tftiletextcolor_sel ,
                                             string AV61Trn_tilewwds_8_tftiletextcolor ,
                                             int AV63Trn_tilewwds_10_tftiletextalignment_sels_Count ,
                                             string AV65Trn_tilewwds_12_tftileicon_sel ,
                                             string AV64Trn_tilewwds_11_tftileicon ,
                                             int AV66Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV68Trn_tilewwds_15_tftileiconcolor_sel ,
                                             string AV67Trn_tilewwds_14_tftileiconcolor ,
                                             string AV70Trn_tilewwds_17_tftileaction_sel ,
                                             string AV69Trn_tilewwds_16_tftileaction ,
                                             string A400TileName ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A401TileIcon ,
                                             string A438TileIconColor ,
                                             string A436TileAction ,
                                             string AV54Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT TileName, TileAction, TileIconColor, TileIconAlignment, TileIcon, TileTextAlignment, TileTextColor, TileBGImageUrl, TileBGColor, TileId FROM Trn_Tile";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(TileName like :lV55Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV56Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileName = ( :AV56Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_5_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_tilewwds_4_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(TileBGColor like :lV57Trn_tilewwds_4_tftilebgcolor)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_5_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV58Trn_tilewwds_5_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGColor = ( :AV58Trn_tilewwds_5_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_tilewwds_5_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileBGColor IS NULL or (char_length(trim(trailing ' ' from TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_7_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_tilewwds_6_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl like :lV59Trn_tilewwds_6_tftilebgimageurl)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_7_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV60Trn_tilewwds_7_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl = ( :AV60Trn_tilewwds_7_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_tilewwds_7_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_9_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_tilewwds_8_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(TileTextColor like :lV61Trn_tilewwds_8_tftiletextcolor)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_9_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV62Trn_tilewwds_9_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileTextColor = ( :AV62Trn_tilewwds_9_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_tilewwds_9_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileTextColor))=0))");
         }
         if ( AV63Trn_tilewwds_10_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Trn_tilewwds_10_tftiletextalignment_sels, "TileTextAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_tilewwds_12_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_tilewwds_11_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(TileIcon like :lV64Trn_tilewwds_11_tftileicon)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_tilewwds_12_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV65Trn_tilewwds_12_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileIcon = ( :AV65Trn_tilewwds_12_tftileicon_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_tilewwds_12_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileIcon IS NULL or (char_length(trim(trailing ' ' from TileIcon))=0))");
         }
         if ( AV66Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV66Trn_tilewwds_13_tftileiconalignment_sels, "TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_15_tftileiconcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_14_tftileiconcolor)) ) )
         {
            AddWhere(sWhereString, "(TileIconColor like :lV67Trn_tilewwds_14_tftileiconcolor)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_15_tftileiconcolor_sel)) && ! ( StringUtil.StrCmp(AV68Trn_tilewwds_15_tftileiconcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileIconColor = ( :AV68Trn_tilewwds_15_tftileiconcolor_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_tilewwds_15_tftileiconcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileIconColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_17_tftileaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_16_tftileaction)) ) )
         {
            AddWhere(sWhereString, "(TileAction like :lV69Trn_tilewwds_16_tftileaction)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_17_tftileaction_sel)) && ! ( StringUtil.StrCmp(AV70Trn_tilewwds_17_tftileaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileAction = ( :AV70Trn_tilewwds_17_tftileaction_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_tilewwds_17_tftileaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileAction))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY TileName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00923( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV63Trn_tilewwds_10_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV66Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV56Trn_tilewwds_3_tftilename_sel ,
                                             string AV55Trn_tilewwds_2_tftilename ,
                                             string AV58Trn_tilewwds_5_tftilebgcolor_sel ,
                                             string AV57Trn_tilewwds_4_tftilebgcolor ,
                                             string AV60Trn_tilewwds_7_tftilebgimageurl_sel ,
                                             string AV59Trn_tilewwds_6_tftilebgimageurl ,
                                             string AV62Trn_tilewwds_9_tftiletextcolor_sel ,
                                             string AV61Trn_tilewwds_8_tftiletextcolor ,
                                             int AV63Trn_tilewwds_10_tftiletextalignment_sels_Count ,
                                             string AV65Trn_tilewwds_12_tftileicon_sel ,
                                             string AV64Trn_tilewwds_11_tftileicon ,
                                             int AV66Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV68Trn_tilewwds_15_tftileiconcolor_sel ,
                                             string AV67Trn_tilewwds_14_tftileiconcolor ,
                                             string AV70Trn_tilewwds_17_tftileaction_sel ,
                                             string AV69Trn_tilewwds_16_tftileaction ,
                                             string A400TileName ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A401TileIcon ,
                                             string A438TileIconColor ,
                                             string A436TileAction ,
                                             string AV54Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT TileBGColor, TileAction, TileIconColor, TileIconAlignment, TileIcon, TileTextAlignment, TileTextColor, TileBGImageUrl, TileName, TileId FROM Trn_Tile";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(TileName like :lV55Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV56Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileName = ( :AV56Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_5_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_tilewwds_4_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(TileBGColor like :lV57Trn_tilewwds_4_tftilebgcolor)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_5_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV58Trn_tilewwds_5_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGColor = ( :AV58Trn_tilewwds_5_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_tilewwds_5_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileBGColor IS NULL or (char_length(trim(trailing ' ' from TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_7_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_tilewwds_6_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl like :lV59Trn_tilewwds_6_tftilebgimageurl)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_7_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV60Trn_tilewwds_7_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl = ( :AV60Trn_tilewwds_7_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_tilewwds_7_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_9_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_tilewwds_8_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(TileTextColor like :lV61Trn_tilewwds_8_tftiletextcolor)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_9_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV62Trn_tilewwds_9_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileTextColor = ( :AV62Trn_tilewwds_9_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_tilewwds_9_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileTextColor))=0))");
         }
         if ( AV63Trn_tilewwds_10_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Trn_tilewwds_10_tftiletextalignment_sels, "TileTextAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_tilewwds_12_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_tilewwds_11_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(TileIcon like :lV64Trn_tilewwds_11_tftileicon)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_tilewwds_12_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV65Trn_tilewwds_12_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileIcon = ( :AV65Trn_tilewwds_12_tftileicon_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_tilewwds_12_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileIcon IS NULL or (char_length(trim(trailing ' ' from TileIcon))=0))");
         }
         if ( AV66Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV66Trn_tilewwds_13_tftileiconalignment_sels, "TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_15_tftileiconcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_14_tftileiconcolor)) ) )
         {
            AddWhere(sWhereString, "(TileIconColor like :lV67Trn_tilewwds_14_tftileiconcolor)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_15_tftileiconcolor_sel)) && ! ( StringUtil.StrCmp(AV68Trn_tilewwds_15_tftileiconcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileIconColor = ( :AV68Trn_tilewwds_15_tftileiconcolor_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_tilewwds_15_tftileiconcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileIconColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_17_tftileaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_16_tftileaction)) ) )
         {
            AddWhere(sWhereString, "(TileAction like :lV69Trn_tilewwds_16_tftileaction)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_17_tftileaction_sel)) && ! ( StringUtil.StrCmp(AV70Trn_tilewwds_17_tftileaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileAction = ( :AV70Trn_tilewwds_17_tftileaction_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_tilewwds_17_tftileaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileAction))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY TileBGColor";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00924( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV63Trn_tilewwds_10_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV66Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV56Trn_tilewwds_3_tftilename_sel ,
                                             string AV55Trn_tilewwds_2_tftilename ,
                                             string AV58Trn_tilewwds_5_tftilebgcolor_sel ,
                                             string AV57Trn_tilewwds_4_tftilebgcolor ,
                                             string AV60Trn_tilewwds_7_tftilebgimageurl_sel ,
                                             string AV59Trn_tilewwds_6_tftilebgimageurl ,
                                             string AV62Trn_tilewwds_9_tftiletextcolor_sel ,
                                             string AV61Trn_tilewwds_8_tftiletextcolor ,
                                             int AV63Trn_tilewwds_10_tftiletextalignment_sels_Count ,
                                             string AV65Trn_tilewwds_12_tftileicon_sel ,
                                             string AV64Trn_tilewwds_11_tftileicon ,
                                             int AV66Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV68Trn_tilewwds_15_tftileiconcolor_sel ,
                                             string AV67Trn_tilewwds_14_tftileiconcolor ,
                                             string AV70Trn_tilewwds_17_tftileaction_sel ,
                                             string AV69Trn_tilewwds_16_tftileaction ,
                                             string A400TileName ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A401TileIcon ,
                                             string A438TileIconColor ,
                                             string A436TileAction ,
                                             string AV54Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[14];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT TileBGImageUrl, TileAction, TileIconColor, TileIconAlignment, TileIcon, TileTextAlignment, TileTextColor, TileBGColor, TileName, TileId FROM Trn_Tile";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(TileName like :lV55Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV56Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileName = ( :AV56Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_5_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_tilewwds_4_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(TileBGColor like :lV57Trn_tilewwds_4_tftilebgcolor)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_5_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV58Trn_tilewwds_5_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGColor = ( :AV58Trn_tilewwds_5_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_tilewwds_5_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileBGColor IS NULL or (char_length(trim(trailing ' ' from TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_7_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_tilewwds_6_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl like :lV59Trn_tilewwds_6_tftilebgimageurl)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_7_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV60Trn_tilewwds_7_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl = ( :AV60Trn_tilewwds_7_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_tilewwds_7_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_9_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_tilewwds_8_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(TileTextColor like :lV61Trn_tilewwds_8_tftiletextcolor)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_9_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV62Trn_tilewwds_9_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileTextColor = ( :AV62Trn_tilewwds_9_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_tilewwds_9_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileTextColor))=0))");
         }
         if ( AV63Trn_tilewwds_10_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Trn_tilewwds_10_tftiletextalignment_sels, "TileTextAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_tilewwds_12_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_tilewwds_11_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(TileIcon like :lV64Trn_tilewwds_11_tftileicon)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_tilewwds_12_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV65Trn_tilewwds_12_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileIcon = ( :AV65Trn_tilewwds_12_tftileicon_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_tilewwds_12_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileIcon IS NULL or (char_length(trim(trailing ' ' from TileIcon))=0))");
         }
         if ( AV66Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV66Trn_tilewwds_13_tftileiconalignment_sels, "TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_15_tftileiconcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_14_tftileiconcolor)) ) )
         {
            AddWhere(sWhereString, "(TileIconColor like :lV67Trn_tilewwds_14_tftileiconcolor)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_15_tftileiconcolor_sel)) && ! ( StringUtil.StrCmp(AV68Trn_tilewwds_15_tftileiconcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileIconColor = ( :AV68Trn_tilewwds_15_tftileiconcolor_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_tilewwds_15_tftileiconcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileIconColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_17_tftileaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_16_tftileaction)) ) )
         {
            AddWhere(sWhereString, "(TileAction like :lV69Trn_tilewwds_16_tftileaction)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_17_tftileaction_sel)) && ! ( StringUtil.StrCmp(AV70Trn_tilewwds_17_tftileaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileAction = ( :AV70Trn_tilewwds_17_tftileaction_sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_tilewwds_17_tftileaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileAction))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY TileBGImageUrl";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00925( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV63Trn_tilewwds_10_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV66Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV56Trn_tilewwds_3_tftilename_sel ,
                                             string AV55Trn_tilewwds_2_tftilename ,
                                             string AV58Trn_tilewwds_5_tftilebgcolor_sel ,
                                             string AV57Trn_tilewwds_4_tftilebgcolor ,
                                             string AV60Trn_tilewwds_7_tftilebgimageurl_sel ,
                                             string AV59Trn_tilewwds_6_tftilebgimageurl ,
                                             string AV62Trn_tilewwds_9_tftiletextcolor_sel ,
                                             string AV61Trn_tilewwds_8_tftiletextcolor ,
                                             int AV63Trn_tilewwds_10_tftiletextalignment_sels_Count ,
                                             string AV65Trn_tilewwds_12_tftileicon_sel ,
                                             string AV64Trn_tilewwds_11_tftileicon ,
                                             int AV66Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV68Trn_tilewwds_15_tftileiconcolor_sel ,
                                             string AV67Trn_tilewwds_14_tftileiconcolor ,
                                             string AV70Trn_tilewwds_17_tftileaction_sel ,
                                             string AV69Trn_tilewwds_16_tftileaction ,
                                             string A400TileName ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A401TileIcon ,
                                             string A438TileIconColor ,
                                             string A436TileAction ,
                                             string AV54Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[14];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT TileTextColor, TileAction, TileIconColor, TileIconAlignment, TileIcon, TileTextAlignment, TileBGImageUrl, TileBGColor, TileName, TileId FROM Trn_Tile";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(TileName like :lV55Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV56Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileName = ( :AV56Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_5_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_tilewwds_4_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(TileBGColor like :lV57Trn_tilewwds_4_tftilebgcolor)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_5_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV58Trn_tilewwds_5_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGColor = ( :AV58Trn_tilewwds_5_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_tilewwds_5_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileBGColor IS NULL or (char_length(trim(trailing ' ' from TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_7_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_tilewwds_6_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl like :lV59Trn_tilewwds_6_tftilebgimageurl)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_7_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV60Trn_tilewwds_7_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl = ( :AV60Trn_tilewwds_7_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_tilewwds_7_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_9_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_tilewwds_8_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(TileTextColor like :lV61Trn_tilewwds_8_tftiletextcolor)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_9_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV62Trn_tilewwds_9_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileTextColor = ( :AV62Trn_tilewwds_9_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_tilewwds_9_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileTextColor))=0))");
         }
         if ( AV63Trn_tilewwds_10_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Trn_tilewwds_10_tftiletextalignment_sels, "TileTextAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_tilewwds_12_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_tilewwds_11_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(TileIcon like :lV64Trn_tilewwds_11_tftileicon)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_tilewwds_12_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV65Trn_tilewwds_12_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileIcon = ( :AV65Trn_tilewwds_12_tftileicon_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_tilewwds_12_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileIcon IS NULL or (char_length(trim(trailing ' ' from TileIcon))=0))");
         }
         if ( AV66Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV66Trn_tilewwds_13_tftileiconalignment_sels, "TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_15_tftileiconcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_14_tftileiconcolor)) ) )
         {
            AddWhere(sWhereString, "(TileIconColor like :lV67Trn_tilewwds_14_tftileiconcolor)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_15_tftileiconcolor_sel)) && ! ( StringUtil.StrCmp(AV68Trn_tilewwds_15_tftileiconcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileIconColor = ( :AV68Trn_tilewwds_15_tftileiconcolor_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_tilewwds_15_tftileiconcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileIconColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_17_tftileaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_16_tftileaction)) ) )
         {
            AddWhere(sWhereString, "(TileAction like :lV69Trn_tilewwds_16_tftileaction)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_17_tftileaction_sel)) && ! ( StringUtil.StrCmp(AV70Trn_tilewwds_17_tftileaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileAction = ( :AV70Trn_tilewwds_17_tftileaction_sel))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_tilewwds_17_tftileaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileAction))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY TileTextColor";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00926( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV63Trn_tilewwds_10_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV66Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV56Trn_tilewwds_3_tftilename_sel ,
                                             string AV55Trn_tilewwds_2_tftilename ,
                                             string AV58Trn_tilewwds_5_tftilebgcolor_sel ,
                                             string AV57Trn_tilewwds_4_tftilebgcolor ,
                                             string AV60Trn_tilewwds_7_tftilebgimageurl_sel ,
                                             string AV59Trn_tilewwds_6_tftilebgimageurl ,
                                             string AV62Trn_tilewwds_9_tftiletextcolor_sel ,
                                             string AV61Trn_tilewwds_8_tftiletextcolor ,
                                             int AV63Trn_tilewwds_10_tftiletextalignment_sels_Count ,
                                             string AV65Trn_tilewwds_12_tftileicon_sel ,
                                             string AV64Trn_tilewwds_11_tftileicon ,
                                             int AV66Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV68Trn_tilewwds_15_tftileiconcolor_sel ,
                                             string AV67Trn_tilewwds_14_tftileiconcolor ,
                                             string AV70Trn_tilewwds_17_tftileaction_sel ,
                                             string AV69Trn_tilewwds_16_tftileaction ,
                                             string A400TileName ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A401TileIcon ,
                                             string A438TileIconColor ,
                                             string A436TileAction ,
                                             string AV54Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[14];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT TileIcon, TileAction, TileIconColor, TileIconAlignment, TileTextAlignment, TileTextColor, TileBGImageUrl, TileBGColor, TileName, TileId FROM Trn_Tile";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(TileName like :lV55Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV56Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileName = ( :AV56Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_5_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_tilewwds_4_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(TileBGColor like :lV57Trn_tilewwds_4_tftilebgcolor)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_5_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV58Trn_tilewwds_5_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGColor = ( :AV58Trn_tilewwds_5_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_tilewwds_5_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileBGColor IS NULL or (char_length(trim(trailing ' ' from TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_7_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_tilewwds_6_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl like :lV59Trn_tilewwds_6_tftilebgimageurl)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_7_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV60Trn_tilewwds_7_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl = ( :AV60Trn_tilewwds_7_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_tilewwds_7_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_9_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_tilewwds_8_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(TileTextColor like :lV61Trn_tilewwds_8_tftiletextcolor)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_9_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV62Trn_tilewwds_9_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileTextColor = ( :AV62Trn_tilewwds_9_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_tilewwds_9_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileTextColor))=0))");
         }
         if ( AV63Trn_tilewwds_10_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Trn_tilewwds_10_tftiletextalignment_sels, "TileTextAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_tilewwds_12_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_tilewwds_11_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(TileIcon like :lV64Trn_tilewwds_11_tftileicon)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_tilewwds_12_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV65Trn_tilewwds_12_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileIcon = ( :AV65Trn_tilewwds_12_tftileicon_sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_tilewwds_12_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileIcon IS NULL or (char_length(trim(trailing ' ' from TileIcon))=0))");
         }
         if ( AV66Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV66Trn_tilewwds_13_tftileiconalignment_sels, "TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_15_tftileiconcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_14_tftileiconcolor)) ) )
         {
            AddWhere(sWhereString, "(TileIconColor like :lV67Trn_tilewwds_14_tftileiconcolor)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_15_tftileiconcolor_sel)) && ! ( StringUtil.StrCmp(AV68Trn_tilewwds_15_tftileiconcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileIconColor = ( :AV68Trn_tilewwds_15_tftileiconcolor_sel))");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_tilewwds_15_tftileiconcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileIconColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_17_tftileaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_16_tftileaction)) ) )
         {
            AddWhere(sWhereString, "(TileAction like :lV69Trn_tilewwds_16_tftileaction)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_17_tftileaction_sel)) && ! ( StringUtil.StrCmp(AV70Trn_tilewwds_17_tftileaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileAction = ( :AV70Trn_tilewwds_17_tftileaction_sel))");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_tilewwds_17_tftileaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileAction))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY TileIcon";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P00927( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV63Trn_tilewwds_10_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV66Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV56Trn_tilewwds_3_tftilename_sel ,
                                             string AV55Trn_tilewwds_2_tftilename ,
                                             string AV58Trn_tilewwds_5_tftilebgcolor_sel ,
                                             string AV57Trn_tilewwds_4_tftilebgcolor ,
                                             string AV60Trn_tilewwds_7_tftilebgimageurl_sel ,
                                             string AV59Trn_tilewwds_6_tftilebgimageurl ,
                                             string AV62Trn_tilewwds_9_tftiletextcolor_sel ,
                                             string AV61Trn_tilewwds_8_tftiletextcolor ,
                                             int AV63Trn_tilewwds_10_tftiletextalignment_sels_Count ,
                                             string AV65Trn_tilewwds_12_tftileicon_sel ,
                                             string AV64Trn_tilewwds_11_tftileicon ,
                                             int AV66Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV68Trn_tilewwds_15_tftileiconcolor_sel ,
                                             string AV67Trn_tilewwds_14_tftileiconcolor ,
                                             string AV70Trn_tilewwds_17_tftileaction_sel ,
                                             string AV69Trn_tilewwds_16_tftileaction ,
                                             string A400TileName ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A401TileIcon ,
                                             string A438TileIconColor ,
                                             string A436TileAction ,
                                             string AV54Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[14];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT TileIconColor, TileAction, TileIconAlignment, TileIcon, TileTextAlignment, TileTextColor, TileBGImageUrl, TileBGColor, TileName, TileId FROM Trn_Tile";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(TileName like :lV55Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int11[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV56Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileName = ( :AV56Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_5_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_tilewwds_4_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(TileBGColor like :lV57Trn_tilewwds_4_tftilebgcolor)");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_5_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV58Trn_tilewwds_5_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGColor = ( :AV58Trn_tilewwds_5_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_tilewwds_5_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileBGColor IS NULL or (char_length(trim(trailing ' ' from TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_7_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_tilewwds_6_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl like :lV59Trn_tilewwds_6_tftilebgimageurl)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_7_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV60Trn_tilewwds_7_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl = ( :AV60Trn_tilewwds_7_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_tilewwds_7_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_9_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_tilewwds_8_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(TileTextColor like :lV61Trn_tilewwds_8_tftiletextcolor)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_9_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV62Trn_tilewwds_9_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileTextColor = ( :AV62Trn_tilewwds_9_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_tilewwds_9_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileTextColor))=0))");
         }
         if ( AV63Trn_tilewwds_10_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Trn_tilewwds_10_tftiletextalignment_sels, "TileTextAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_tilewwds_12_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_tilewwds_11_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(TileIcon like :lV64Trn_tilewwds_11_tftileicon)");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_tilewwds_12_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV65Trn_tilewwds_12_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileIcon = ( :AV65Trn_tilewwds_12_tftileicon_sel))");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_tilewwds_12_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileIcon IS NULL or (char_length(trim(trailing ' ' from TileIcon))=0))");
         }
         if ( AV66Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV66Trn_tilewwds_13_tftileiconalignment_sels, "TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_15_tftileiconcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_14_tftileiconcolor)) ) )
         {
            AddWhere(sWhereString, "(TileIconColor like :lV67Trn_tilewwds_14_tftileiconcolor)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_15_tftileiconcolor_sel)) && ! ( StringUtil.StrCmp(AV68Trn_tilewwds_15_tftileiconcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileIconColor = ( :AV68Trn_tilewwds_15_tftileiconcolor_sel))");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_tilewwds_15_tftileiconcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileIconColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_17_tftileaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_16_tftileaction)) ) )
         {
            AddWhere(sWhereString, "(TileAction like :lV69Trn_tilewwds_16_tftileaction)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_17_tftileaction_sel)) && ! ( StringUtil.StrCmp(AV70Trn_tilewwds_17_tftileaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileAction = ( :AV70Trn_tilewwds_17_tftileaction_sel))");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_tilewwds_17_tftileaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileAction))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY TileIconColor";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_P00928( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV63Trn_tilewwds_10_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV66Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV56Trn_tilewwds_3_tftilename_sel ,
                                             string AV55Trn_tilewwds_2_tftilename ,
                                             string AV58Trn_tilewwds_5_tftilebgcolor_sel ,
                                             string AV57Trn_tilewwds_4_tftilebgcolor ,
                                             string AV60Trn_tilewwds_7_tftilebgimageurl_sel ,
                                             string AV59Trn_tilewwds_6_tftilebgimageurl ,
                                             string AV62Trn_tilewwds_9_tftiletextcolor_sel ,
                                             string AV61Trn_tilewwds_8_tftiletextcolor ,
                                             int AV63Trn_tilewwds_10_tftiletextalignment_sels_Count ,
                                             string AV65Trn_tilewwds_12_tftileicon_sel ,
                                             string AV64Trn_tilewwds_11_tftileicon ,
                                             int AV66Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV68Trn_tilewwds_15_tftileiconcolor_sel ,
                                             string AV67Trn_tilewwds_14_tftileiconcolor ,
                                             string AV70Trn_tilewwds_17_tftileaction_sel ,
                                             string AV69Trn_tilewwds_16_tftileaction ,
                                             string A400TileName ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A401TileIcon ,
                                             string A438TileIconColor ,
                                             string A436TileAction ,
                                             string AV54Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[14];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT TileAction, TileIconColor, TileIconAlignment, TileIcon, TileTextAlignment, TileTextColor, TileBGImageUrl, TileBGColor, TileName, TileId FROM Trn_Tile";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(TileName like :lV55Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int13[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV56Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileName = ( :AV56Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int13[1] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_5_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_tilewwds_4_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(TileBGColor like :lV57Trn_tilewwds_4_tftilebgcolor)");
         }
         else
         {
            GXv_int13[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_5_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV58Trn_tilewwds_5_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGColor = ( :AV58Trn_tilewwds_5_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int13[3] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_tilewwds_5_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileBGColor IS NULL or (char_length(trim(trailing ' ' from TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_7_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_tilewwds_6_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl like :lV59Trn_tilewwds_6_tftilebgimageurl)");
         }
         else
         {
            GXv_int13[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_7_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV60Trn_tilewwds_7_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileBGImageUrl = ( :AV60Trn_tilewwds_7_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int13[5] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_tilewwds_7_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_9_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_tilewwds_8_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(TileTextColor like :lV61Trn_tilewwds_8_tftiletextcolor)");
         }
         else
         {
            GXv_int13[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_9_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV62Trn_tilewwds_9_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileTextColor = ( :AV62Trn_tilewwds_9_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int13[7] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_tilewwds_9_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileTextColor))=0))");
         }
         if ( AV63Trn_tilewwds_10_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Trn_tilewwds_10_tftiletextalignment_sels, "TileTextAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_tilewwds_12_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_tilewwds_11_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(TileIcon like :lV64Trn_tilewwds_11_tftileicon)");
         }
         else
         {
            GXv_int13[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_tilewwds_12_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV65Trn_tilewwds_12_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileIcon = ( :AV65Trn_tilewwds_12_tftileicon_sel))");
         }
         else
         {
            GXv_int13[9] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_tilewwds_12_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(TileIcon IS NULL or (char_length(trim(trailing ' ' from TileIcon))=0))");
         }
         if ( AV66Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV66Trn_tilewwds_13_tftileiconalignment_sels, "TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_15_tftileiconcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_14_tftileiconcolor)) ) )
         {
            AddWhere(sWhereString, "(TileIconColor like :lV67Trn_tilewwds_14_tftileiconcolor)");
         }
         else
         {
            GXv_int13[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_15_tftileiconcolor_sel)) && ! ( StringUtil.StrCmp(AV68Trn_tilewwds_15_tftileiconcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileIconColor = ( :AV68Trn_tilewwds_15_tftileiconcolor_sel))");
         }
         else
         {
            GXv_int13[11] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_tilewwds_15_tftileiconcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileIconColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_17_tftileaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_16_tftileaction)) ) )
         {
            AddWhere(sWhereString, "(TileAction like :lV69Trn_tilewwds_16_tftileaction)");
         }
         else
         {
            GXv_int13[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_17_tftileaction_sel)) && ! ( StringUtil.StrCmp(AV70Trn_tilewwds_17_tftileaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(TileAction = ( :AV70Trn_tilewwds_17_tftileaction_sel))");
         }
         else
         {
            GXv_int13[13] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_tilewwds_17_tftileaction_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TileAction))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY TileAction";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00922(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 1 :
                     return conditional_P00923(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 2 :
                     return conditional_P00924(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 3 :
                     return conditional_P00925(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 4 :
                     return conditional_P00926(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 5 :
                     return conditional_P00927(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 6 :
                     return conditional_P00928(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00922;
          prmP00922 = new Object[] {
          new ParDef("lV55Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV56Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_tilewwds_4_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV58Trn_tilewwds_5_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV59Trn_tilewwds_6_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV60Trn_tilewwds_7_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV61Trn_tilewwds_8_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV62Trn_tilewwds_9_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV64Trn_tilewwds_11_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV65Trn_tilewwds_12_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV67Trn_tilewwds_14_tftileiconcolor",GXType.Char,20,0) ,
          new ParDef("AV68Trn_tilewwds_15_tftileiconcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV69Trn_tilewwds_16_tftileaction",GXType.VarChar,200,0) ,
          new ParDef("AV70Trn_tilewwds_17_tftileaction_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00923;
          prmP00923 = new Object[] {
          new ParDef("lV55Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV56Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_tilewwds_4_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV58Trn_tilewwds_5_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV59Trn_tilewwds_6_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV60Trn_tilewwds_7_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV61Trn_tilewwds_8_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV62Trn_tilewwds_9_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV64Trn_tilewwds_11_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV65Trn_tilewwds_12_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV67Trn_tilewwds_14_tftileiconcolor",GXType.Char,20,0) ,
          new ParDef("AV68Trn_tilewwds_15_tftileiconcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV69Trn_tilewwds_16_tftileaction",GXType.VarChar,200,0) ,
          new ParDef("AV70Trn_tilewwds_17_tftileaction_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00924;
          prmP00924 = new Object[] {
          new ParDef("lV55Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV56Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_tilewwds_4_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV58Trn_tilewwds_5_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV59Trn_tilewwds_6_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV60Trn_tilewwds_7_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV61Trn_tilewwds_8_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV62Trn_tilewwds_9_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV64Trn_tilewwds_11_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV65Trn_tilewwds_12_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV67Trn_tilewwds_14_tftileiconcolor",GXType.Char,20,0) ,
          new ParDef("AV68Trn_tilewwds_15_tftileiconcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV69Trn_tilewwds_16_tftileaction",GXType.VarChar,200,0) ,
          new ParDef("AV70Trn_tilewwds_17_tftileaction_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00925;
          prmP00925 = new Object[] {
          new ParDef("lV55Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV56Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_tilewwds_4_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV58Trn_tilewwds_5_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV59Trn_tilewwds_6_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV60Trn_tilewwds_7_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV61Trn_tilewwds_8_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV62Trn_tilewwds_9_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV64Trn_tilewwds_11_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV65Trn_tilewwds_12_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV67Trn_tilewwds_14_tftileiconcolor",GXType.Char,20,0) ,
          new ParDef("AV68Trn_tilewwds_15_tftileiconcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV69Trn_tilewwds_16_tftileaction",GXType.VarChar,200,0) ,
          new ParDef("AV70Trn_tilewwds_17_tftileaction_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00926;
          prmP00926 = new Object[] {
          new ParDef("lV55Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV56Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_tilewwds_4_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV58Trn_tilewwds_5_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV59Trn_tilewwds_6_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV60Trn_tilewwds_7_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV61Trn_tilewwds_8_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV62Trn_tilewwds_9_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV64Trn_tilewwds_11_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV65Trn_tilewwds_12_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV67Trn_tilewwds_14_tftileiconcolor",GXType.Char,20,0) ,
          new ParDef("AV68Trn_tilewwds_15_tftileiconcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV69Trn_tilewwds_16_tftileaction",GXType.VarChar,200,0) ,
          new ParDef("AV70Trn_tilewwds_17_tftileaction_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00927;
          prmP00927 = new Object[] {
          new ParDef("lV55Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV56Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_tilewwds_4_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV58Trn_tilewwds_5_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV59Trn_tilewwds_6_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV60Trn_tilewwds_7_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV61Trn_tilewwds_8_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV62Trn_tilewwds_9_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV64Trn_tilewwds_11_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV65Trn_tilewwds_12_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV67Trn_tilewwds_14_tftileiconcolor",GXType.Char,20,0) ,
          new ParDef("AV68Trn_tilewwds_15_tftileiconcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV69Trn_tilewwds_16_tftileaction",GXType.VarChar,200,0) ,
          new ParDef("AV70Trn_tilewwds_17_tftileaction_sel",GXType.VarChar,200,0)
          };
          Object[] prmP00928;
          prmP00928 = new Object[] {
          new ParDef("lV55Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV56Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_tilewwds_4_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV58Trn_tilewwds_5_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV59Trn_tilewwds_6_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV60Trn_tilewwds_7_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV61Trn_tilewwds_8_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV62Trn_tilewwds_9_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV64Trn_tilewwds_11_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV65Trn_tilewwds_12_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV67Trn_tilewwds_14_tftileiconcolor",GXType.Char,20,0) ,
          new ParDef("AV68Trn_tilewwds_15_tftileiconcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV69Trn_tilewwds_16_tftileaction",GXType.VarChar,200,0) ,
          new ParDef("AV70Trn_tilewwds_17_tftileaction_sel",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00922", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00922,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00923", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00923,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00924", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00924,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00925", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00925,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00926", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00926,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00927", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00927,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00928", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00928,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 20);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((Guid[]) buf[12])[0] = rslt.getGuid(10);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 20);
                ((string[]) buf[8])[0] = rslt.getString(7, 20);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((Guid[]) buf[12])[0] = rslt.getGuid(10);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 20);
                ((string[]) buf[8])[0] = rslt.getString(7, 20);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((Guid[]) buf[12])[0] = rslt.getGuid(10);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((Guid[]) buf[12])[0] = rslt.getGuid(10);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((Guid[]) buf[12])[0] = rslt.getGuid(10);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((Guid[]) buf[12])[0] = rslt.getGuid(10);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((Guid[]) buf[12])[0] = rslt.getGuid(10);
                return;
       }
    }

 }

}
