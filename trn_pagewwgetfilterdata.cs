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
   public class trn_pagewwgetfilterdata : GXProcedure
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
            return "trn_pageww_Services_Execute" ;
         }

      }

      public trn_pagewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_pagewwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
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
         this.AV29DDOName = aP0_DDOName;
         this.AV30SearchTxtParms = aP1_SearchTxtParms;
         this.AV31SearchTxtTo = aP2_SearchTxtTo;
         this.AV32OptionsJson = "" ;
         this.AV33OptionsDescJson = "" ;
         this.AV34OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV34OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV34OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV29DDOName = aP0_DDOName;
         this.AV30SearchTxtParms = aP1_SearchTxtParms;
         this.AV31SearchTxtTo = aP2_SearchTxtTo;
         this.AV32OptionsJson = "" ;
         this.AV33OptionsDescJson = "" ;
         this.AV34OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV34OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV21OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV16MaxItems = 10;
         AV15PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV30SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV30SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV13SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV30SearchTxtParms)) ? "" : StringUtil.Substring( AV30SearchTxtParms, 3, -1));
         AV14SkipItems = (short)(AV15PageIndex*AV16MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_TRN_PAGENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADTRN_PAGENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_PAGEJSONCONTENT") == 0 )
         {
            /* Execute user subroutine: 'LOADPAGEJSONCONTENTOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_PAGEGJSHTML") == 0 )
         {
            /* Execute user subroutine: 'LOADPAGEGJSHTMLOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_PAGEGJSJSON") == 0 )
         {
            /* Execute user subroutine: 'LOADPAGEGJSJSONOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_PAGECHILDREN") == 0 )
         {
            /* Execute user subroutine: 'LOADPAGECHILDRENOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV32OptionsJson = AV19Options.ToJSonString(false);
         AV33OptionsDescJson = AV21OptionsDesc.ToJSonString(false);
         AV34OptionIndexesJson = AV22OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV24Session.Get("Trn_PageWWGridState"), "") == 0 )
         {
            AV26GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Trn_PageWWGridState"), null, "", "");
         }
         else
         {
            AV26GridState.FromXml(AV24Session.Get("Trn_PageWWGridState"), null, "", "");
         }
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV46GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV35FilterFullText = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_PAGENAME") == 0 )
            {
               AV11TFTrn_PageName = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_PAGENAME_SEL") == 0 )
            {
               AV12TFTrn_PageName_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGEJSONCONTENT") == 0 )
            {
               AV36TFPageJsonContent = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGEJSONCONTENT_SEL") == 0 )
            {
               AV37TFPageJsonContent_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGEGJSHTML") == 0 )
            {
               AV38TFPageGJSHtml = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGEGJSHTML_SEL") == 0 )
            {
               AV39TFPageGJSHtml_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGEGJSJSON") == 0 )
            {
               AV40TFPageGJSJson = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGEGJSJSON_SEL") == 0 )
            {
               AV41TFPageGJSJson_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGEISPUBLISHED_SEL") == 0 )
            {
               AV43TFPageIsPublished_Sel = (short)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGEISCONTENTPAGE_SEL") == 0 )
            {
               AV42TFPageIsContentPage_Sel = (short)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGECHILDREN") == 0 )
            {
               AV44TFPageChildren = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGECHILDREN_SEL") == 0 )
            {
               AV45TFPageChildren_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTRN_PAGENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFTrn_PageName = AV13SearchTxt;
         AV12TFTrn_PageName_Sel = "";
         AV48Trn_pagewwds_1_filterfulltext = AV35FilterFullText;
         AV49Trn_pagewwds_2_tftrn_pagename = AV11TFTrn_PageName;
         AV50Trn_pagewwds_3_tftrn_pagename_sel = AV12TFTrn_PageName_Sel;
         AV51Trn_pagewwds_4_tfpagejsoncontent = AV36TFPageJsonContent;
         AV52Trn_pagewwds_5_tfpagejsoncontent_sel = AV37TFPageJsonContent_Sel;
         AV53Trn_pagewwds_6_tfpagegjshtml = AV38TFPageGJSHtml;
         AV54Trn_pagewwds_7_tfpagegjshtml_sel = AV39TFPageGJSHtml_Sel;
         AV55Trn_pagewwds_8_tfpagegjsjson = AV40TFPageGJSJson;
         AV56Trn_pagewwds_9_tfpagegjsjson_sel = AV41TFPageGJSJson_Sel;
         AV57Trn_pagewwds_10_tfpageispublished_sel = AV43TFPageIsPublished_Sel;
         AV58Trn_pagewwds_11_tfpageiscontentpage_sel = AV42TFPageIsContentPage_Sel;
         AV59Trn_pagewwds_12_tfpagechildren = AV44TFPageChildren;
         AV60Trn_pagewwds_13_tfpagechildren_sel = AV45TFPageChildren_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                              AV49Trn_pagewwds_2_tftrn_pagename ,
                                              AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                              AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                              AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                              AV53Trn_pagewwds_6_tfpagegjshtml ,
                                              AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                              AV55Trn_pagewwds_8_tfpagegjsjson ,
                                              AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                              AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                              AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                              AV59Trn_pagewwds_12_tfpagechildren ,
                                              A318Trn_PageName ,
                                              A431PageJsonContent ,
                                              A432PageGJSHtml ,
                                              A433PageGJSJson ,
                                              A434PageIsPublished ,
                                              A439PageIsContentPage ,
                                              A437PageChildren ,
                                              AV48Trn_pagewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV49Trn_pagewwds_2_tftrn_pagename = StringUtil.Concat( StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename), "%", "");
         lV51Trn_pagewwds_4_tfpagejsoncontent = StringUtil.Concat( StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent), "%", "");
         lV53Trn_pagewwds_6_tfpagegjshtml = StringUtil.Concat( StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml), "%", "");
         lV55Trn_pagewwds_8_tfpagegjsjson = StringUtil.Concat( StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson), "%", "");
         lV59Trn_pagewwds_12_tfpagechildren = StringUtil.Concat( StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren), "%", "");
         /* Using cursor P006Y2 */
         pr_default.execute(0, new Object[] {lV49Trn_pagewwds_2_tftrn_pagename, AV50Trn_pagewwds_3_tftrn_pagename_sel, lV51Trn_pagewwds_4_tfpagejsoncontent, AV52Trn_pagewwds_5_tfpagejsoncontent_sel, lV53Trn_pagewwds_6_tfpagegjshtml, AV54Trn_pagewwds_7_tfpagegjshtml_sel, lV55Trn_pagewwds_8_tfpagegjsjson, AV56Trn_pagewwds_9_tfpagegjsjson_sel, lV59Trn_pagewwds_12_tfpagechildren, AV60Trn_pagewwds_13_tfpagechildren_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6Y2 = false;
            A318Trn_PageName = P006Y2_A318Trn_PageName[0];
            A434PageIsPublished = P006Y2_A434PageIsPublished[0];
            n434PageIsPublished = P006Y2_n434PageIsPublished[0];
            A437PageChildren = P006Y2_A437PageChildren[0];
            n437PageChildren = P006Y2_n437PageChildren[0];
            A439PageIsContentPage = P006Y2_A439PageIsContentPage[0];
            n439PageIsContentPage = P006Y2_n439PageIsContentPage[0];
            A433PageGJSJson = P006Y2_A433PageGJSJson[0];
            n433PageGJSJson = P006Y2_n433PageGJSJson[0];
            A432PageGJSHtml = P006Y2_A432PageGJSHtml[0];
            n432PageGJSHtml = P006Y2_n432PageGJSHtml[0];
            A431PageJsonContent = P006Y2_A431PageJsonContent[0];
            n431PageJsonContent = P006Y2_n431PageJsonContent[0];
            A310Trn_PageId = P006Y2_A310Trn_PageId[0];
            A29LocationId = P006Y2_A29LocationId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_pagewwds_1_filterfulltext)) || ( ( StringUtil.Like( A318Trn_PageName , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A431PageJsonContent , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( A432PageGJSHtml , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( A433PageGJSJson , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "true", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A439PageIsContentPage ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "false", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A439PageIsContentPage ) || ( StringUtil.Like( A437PageChildren , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) ) )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006Y2_A318Trn_PageName[0], A318Trn_PageName) == 0 ) )
               {
                  BRK6Y2 = false;
                  A310Trn_PageId = P006Y2_A310Trn_PageId[0];
                  A29LocationId = P006Y2_A29LocationId[0];
                  AV23count = (long)(AV23count+1);
                  BRK6Y2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV14SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A318Trn_PageName)) ? "<#Empty#>" : A318Trn_PageName);
                  AV19Options.Add(AV18Option, 0);
                  AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV19Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV14SkipItems = (short)(AV14SkipItems-1);
               }
            }
            if ( ! BRK6Y2 )
            {
               BRK6Y2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPAGEJSONCONTENTOPTIONS' Routine */
         returnInSub = false;
         AV36TFPageJsonContent = AV13SearchTxt;
         AV37TFPageJsonContent_Sel = "";
         AV48Trn_pagewwds_1_filterfulltext = AV35FilterFullText;
         AV49Trn_pagewwds_2_tftrn_pagename = AV11TFTrn_PageName;
         AV50Trn_pagewwds_3_tftrn_pagename_sel = AV12TFTrn_PageName_Sel;
         AV51Trn_pagewwds_4_tfpagejsoncontent = AV36TFPageJsonContent;
         AV52Trn_pagewwds_5_tfpagejsoncontent_sel = AV37TFPageJsonContent_Sel;
         AV53Trn_pagewwds_6_tfpagegjshtml = AV38TFPageGJSHtml;
         AV54Trn_pagewwds_7_tfpagegjshtml_sel = AV39TFPageGJSHtml_Sel;
         AV55Trn_pagewwds_8_tfpagegjsjson = AV40TFPageGJSJson;
         AV56Trn_pagewwds_9_tfpagegjsjson_sel = AV41TFPageGJSJson_Sel;
         AV57Trn_pagewwds_10_tfpageispublished_sel = AV43TFPageIsPublished_Sel;
         AV58Trn_pagewwds_11_tfpageiscontentpage_sel = AV42TFPageIsContentPage_Sel;
         AV59Trn_pagewwds_12_tfpagechildren = AV44TFPageChildren;
         AV60Trn_pagewwds_13_tfpagechildren_sel = AV45TFPageChildren_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                              AV49Trn_pagewwds_2_tftrn_pagename ,
                                              AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                              AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                              AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                              AV53Trn_pagewwds_6_tfpagegjshtml ,
                                              AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                              AV55Trn_pagewwds_8_tfpagegjsjson ,
                                              AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                              AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                              AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                              AV59Trn_pagewwds_12_tfpagechildren ,
                                              A318Trn_PageName ,
                                              A431PageJsonContent ,
                                              A432PageGJSHtml ,
                                              A433PageGJSJson ,
                                              A434PageIsPublished ,
                                              A439PageIsContentPage ,
                                              A437PageChildren ,
                                              AV48Trn_pagewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV49Trn_pagewwds_2_tftrn_pagename = StringUtil.Concat( StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename), "%", "");
         lV51Trn_pagewwds_4_tfpagejsoncontent = StringUtil.Concat( StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent), "%", "");
         lV53Trn_pagewwds_6_tfpagegjshtml = StringUtil.Concat( StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml), "%", "");
         lV55Trn_pagewwds_8_tfpagegjsjson = StringUtil.Concat( StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson), "%", "");
         lV59Trn_pagewwds_12_tfpagechildren = StringUtil.Concat( StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren), "%", "");
         /* Using cursor P006Y3 */
         pr_default.execute(1, new Object[] {lV49Trn_pagewwds_2_tftrn_pagename, AV50Trn_pagewwds_3_tftrn_pagename_sel, lV51Trn_pagewwds_4_tfpagejsoncontent, AV52Trn_pagewwds_5_tfpagejsoncontent_sel, lV53Trn_pagewwds_6_tfpagegjshtml, AV54Trn_pagewwds_7_tfpagegjshtml_sel, lV55Trn_pagewwds_8_tfpagegjsjson, AV56Trn_pagewwds_9_tfpagegjsjson_sel, lV59Trn_pagewwds_12_tfpagechildren, AV60Trn_pagewwds_13_tfpagechildren_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6Y4 = false;
            A431PageJsonContent = P006Y3_A431PageJsonContent[0];
            n431PageJsonContent = P006Y3_n431PageJsonContent[0];
            A434PageIsPublished = P006Y3_A434PageIsPublished[0];
            n434PageIsPublished = P006Y3_n434PageIsPublished[0];
            A437PageChildren = P006Y3_A437PageChildren[0];
            n437PageChildren = P006Y3_n437PageChildren[0];
            A439PageIsContentPage = P006Y3_A439PageIsContentPage[0];
            n439PageIsContentPage = P006Y3_n439PageIsContentPage[0];
            A433PageGJSJson = P006Y3_A433PageGJSJson[0];
            n433PageGJSJson = P006Y3_n433PageGJSJson[0];
            A432PageGJSHtml = P006Y3_A432PageGJSHtml[0];
            n432PageGJSHtml = P006Y3_n432PageGJSHtml[0];
            A318Trn_PageName = P006Y3_A318Trn_PageName[0];
            A310Trn_PageId = P006Y3_A310Trn_PageId[0];
            A29LocationId = P006Y3_A29LocationId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_pagewwds_1_filterfulltext)) || ( ( StringUtil.Like( A318Trn_PageName , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A431PageJsonContent , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( A432PageGJSHtml , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( A433PageGJSJson , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "true", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A439PageIsContentPage ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "false", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A439PageIsContentPage ) || ( StringUtil.Like( A437PageChildren , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) ) )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006Y3_A431PageJsonContent[0], A431PageJsonContent) == 0 ) )
               {
                  BRK6Y4 = false;
                  A318Trn_PageName = P006Y3_A318Trn_PageName[0];
                  A310Trn_PageId = P006Y3_A310Trn_PageId[0];
                  A29LocationId = P006Y3_A29LocationId[0];
                  AV23count = (long)(AV23count+1);
                  BRK6Y4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV14SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A431PageJsonContent)) ? "<#Empty#>" : A431PageJsonContent);
                  AV19Options.Add(AV18Option, 0);
                  AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV19Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV14SkipItems = (short)(AV14SkipItems-1);
               }
            }
            if ( ! BRK6Y4 )
            {
               BRK6Y4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPAGEGJSHTMLOPTIONS' Routine */
         returnInSub = false;
         AV38TFPageGJSHtml = AV13SearchTxt;
         AV39TFPageGJSHtml_Sel = "";
         AV48Trn_pagewwds_1_filterfulltext = AV35FilterFullText;
         AV49Trn_pagewwds_2_tftrn_pagename = AV11TFTrn_PageName;
         AV50Trn_pagewwds_3_tftrn_pagename_sel = AV12TFTrn_PageName_Sel;
         AV51Trn_pagewwds_4_tfpagejsoncontent = AV36TFPageJsonContent;
         AV52Trn_pagewwds_5_tfpagejsoncontent_sel = AV37TFPageJsonContent_Sel;
         AV53Trn_pagewwds_6_tfpagegjshtml = AV38TFPageGJSHtml;
         AV54Trn_pagewwds_7_tfpagegjshtml_sel = AV39TFPageGJSHtml_Sel;
         AV55Trn_pagewwds_8_tfpagegjsjson = AV40TFPageGJSJson;
         AV56Trn_pagewwds_9_tfpagegjsjson_sel = AV41TFPageGJSJson_Sel;
         AV57Trn_pagewwds_10_tfpageispublished_sel = AV43TFPageIsPublished_Sel;
         AV58Trn_pagewwds_11_tfpageiscontentpage_sel = AV42TFPageIsContentPage_Sel;
         AV59Trn_pagewwds_12_tfpagechildren = AV44TFPageChildren;
         AV60Trn_pagewwds_13_tfpagechildren_sel = AV45TFPageChildren_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                              AV49Trn_pagewwds_2_tftrn_pagename ,
                                              AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                              AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                              AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                              AV53Trn_pagewwds_6_tfpagegjshtml ,
                                              AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                              AV55Trn_pagewwds_8_tfpagegjsjson ,
                                              AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                              AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                              AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                              AV59Trn_pagewwds_12_tfpagechildren ,
                                              A318Trn_PageName ,
                                              A431PageJsonContent ,
                                              A432PageGJSHtml ,
                                              A433PageGJSJson ,
                                              A434PageIsPublished ,
                                              A439PageIsContentPage ,
                                              A437PageChildren ,
                                              AV48Trn_pagewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV49Trn_pagewwds_2_tftrn_pagename = StringUtil.Concat( StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename), "%", "");
         lV51Trn_pagewwds_4_tfpagejsoncontent = StringUtil.Concat( StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent), "%", "");
         lV53Trn_pagewwds_6_tfpagegjshtml = StringUtil.Concat( StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml), "%", "");
         lV55Trn_pagewwds_8_tfpagegjsjson = StringUtil.Concat( StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson), "%", "");
         lV59Trn_pagewwds_12_tfpagechildren = StringUtil.Concat( StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren), "%", "");
         /* Using cursor P006Y4 */
         pr_default.execute(2, new Object[] {lV49Trn_pagewwds_2_tftrn_pagename, AV50Trn_pagewwds_3_tftrn_pagename_sel, lV51Trn_pagewwds_4_tfpagejsoncontent, AV52Trn_pagewwds_5_tfpagejsoncontent_sel, lV53Trn_pagewwds_6_tfpagegjshtml, AV54Trn_pagewwds_7_tfpagegjshtml_sel, lV55Trn_pagewwds_8_tfpagegjsjson, AV56Trn_pagewwds_9_tfpagegjsjson_sel, lV59Trn_pagewwds_12_tfpagechildren, AV60Trn_pagewwds_13_tfpagechildren_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6Y6 = false;
            A432PageGJSHtml = P006Y4_A432PageGJSHtml[0];
            n432PageGJSHtml = P006Y4_n432PageGJSHtml[0];
            A434PageIsPublished = P006Y4_A434PageIsPublished[0];
            n434PageIsPublished = P006Y4_n434PageIsPublished[0];
            A437PageChildren = P006Y4_A437PageChildren[0];
            n437PageChildren = P006Y4_n437PageChildren[0];
            A439PageIsContentPage = P006Y4_A439PageIsContentPage[0];
            n439PageIsContentPage = P006Y4_n439PageIsContentPage[0];
            A433PageGJSJson = P006Y4_A433PageGJSJson[0];
            n433PageGJSJson = P006Y4_n433PageGJSJson[0];
            A431PageJsonContent = P006Y4_A431PageJsonContent[0];
            n431PageJsonContent = P006Y4_n431PageJsonContent[0];
            A318Trn_PageName = P006Y4_A318Trn_PageName[0];
            A310Trn_PageId = P006Y4_A310Trn_PageId[0];
            A29LocationId = P006Y4_A29LocationId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_pagewwds_1_filterfulltext)) || ( ( StringUtil.Like( A318Trn_PageName , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A431PageJsonContent , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( A432PageGJSHtml , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( A433PageGJSJson , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "true", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A439PageIsContentPage ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "false", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A439PageIsContentPage ) || ( StringUtil.Like( A437PageChildren , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) ) )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006Y4_A432PageGJSHtml[0], A432PageGJSHtml) == 0 ) )
               {
                  BRK6Y6 = false;
                  A318Trn_PageName = P006Y4_A318Trn_PageName[0];
                  A310Trn_PageId = P006Y4_A310Trn_PageId[0];
                  A29LocationId = P006Y4_A29LocationId[0];
                  AV23count = (long)(AV23count+1);
                  BRK6Y6 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV14SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A432PageGJSHtml)) ? "<#Empty#>" : A432PageGJSHtml);
                  AV19Options.Add(AV18Option, 0);
                  AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV19Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV14SkipItems = (short)(AV14SkipItems-1);
               }
            }
            if ( ! BRK6Y6 )
            {
               BRK6Y6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADPAGEGJSJSONOPTIONS' Routine */
         returnInSub = false;
         AV40TFPageGJSJson = AV13SearchTxt;
         AV41TFPageGJSJson_Sel = "";
         AV48Trn_pagewwds_1_filterfulltext = AV35FilterFullText;
         AV49Trn_pagewwds_2_tftrn_pagename = AV11TFTrn_PageName;
         AV50Trn_pagewwds_3_tftrn_pagename_sel = AV12TFTrn_PageName_Sel;
         AV51Trn_pagewwds_4_tfpagejsoncontent = AV36TFPageJsonContent;
         AV52Trn_pagewwds_5_tfpagejsoncontent_sel = AV37TFPageJsonContent_Sel;
         AV53Trn_pagewwds_6_tfpagegjshtml = AV38TFPageGJSHtml;
         AV54Trn_pagewwds_7_tfpagegjshtml_sel = AV39TFPageGJSHtml_Sel;
         AV55Trn_pagewwds_8_tfpagegjsjson = AV40TFPageGJSJson;
         AV56Trn_pagewwds_9_tfpagegjsjson_sel = AV41TFPageGJSJson_Sel;
         AV57Trn_pagewwds_10_tfpageispublished_sel = AV43TFPageIsPublished_Sel;
         AV58Trn_pagewwds_11_tfpageiscontentpage_sel = AV42TFPageIsContentPage_Sel;
         AV59Trn_pagewwds_12_tfpagechildren = AV44TFPageChildren;
         AV60Trn_pagewwds_13_tfpagechildren_sel = AV45TFPageChildren_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                              AV49Trn_pagewwds_2_tftrn_pagename ,
                                              AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                              AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                              AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                              AV53Trn_pagewwds_6_tfpagegjshtml ,
                                              AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                              AV55Trn_pagewwds_8_tfpagegjsjson ,
                                              AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                              AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                              AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                              AV59Trn_pagewwds_12_tfpagechildren ,
                                              A318Trn_PageName ,
                                              A431PageJsonContent ,
                                              A432PageGJSHtml ,
                                              A433PageGJSJson ,
                                              A434PageIsPublished ,
                                              A439PageIsContentPage ,
                                              A437PageChildren ,
                                              AV48Trn_pagewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV49Trn_pagewwds_2_tftrn_pagename = StringUtil.Concat( StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename), "%", "");
         lV51Trn_pagewwds_4_tfpagejsoncontent = StringUtil.Concat( StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent), "%", "");
         lV53Trn_pagewwds_6_tfpagegjshtml = StringUtil.Concat( StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml), "%", "");
         lV55Trn_pagewwds_8_tfpagegjsjson = StringUtil.Concat( StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson), "%", "");
         lV59Trn_pagewwds_12_tfpagechildren = StringUtil.Concat( StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren), "%", "");
         /* Using cursor P006Y5 */
         pr_default.execute(3, new Object[] {lV49Trn_pagewwds_2_tftrn_pagename, AV50Trn_pagewwds_3_tftrn_pagename_sel, lV51Trn_pagewwds_4_tfpagejsoncontent, AV52Trn_pagewwds_5_tfpagejsoncontent_sel, lV53Trn_pagewwds_6_tfpagegjshtml, AV54Trn_pagewwds_7_tfpagegjshtml_sel, lV55Trn_pagewwds_8_tfpagegjsjson, AV56Trn_pagewwds_9_tfpagegjsjson_sel, lV59Trn_pagewwds_12_tfpagechildren, AV60Trn_pagewwds_13_tfpagechildren_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK6Y8 = false;
            A433PageGJSJson = P006Y5_A433PageGJSJson[0];
            n433PageGJSJson = P006Y5_n433PageGJSJson[0];
            A434PageIsPublished = P006Y5_A434PageIsPublished[0];
            n434PageIsPublished = P006Y5_n434PageIsPublished[0];
            A437PageChildren = P006Y5_A437PageChildren[0];
            n437PageChildren = P006Y5_n437PageChildren[0];
            A439PageIsContentPage = P006Y5_A439PageIsContentPage[0];
            n439PageIsContentPage = P006Y5_n439PageIsContentPage[0];
            A432PageGJSHtml = P006Y5_A432PageGJSHtml[0];
            n432PageGJSHtml = P006Y5_n432PageGJSHtml[0];
            A431PageJsonContent = P006Y5_A431PageJsonContent[0];
            n431PageJsonContent = P006Y5_n431PageJsonContent[0];
            A318Trn_PageName = P006Y5_A318Trn_PageName[0];
            A310Trn_PageId = P006Y5_A310Trn_PageId[0];
            A29LocationId = P006Y5_A29LocationId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_pagewwds_1_filterfulltext)) || ( ( StringUtil.Like( A318Trn_PageName , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A431PageJsonContent , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( A432PageGJSHtml , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( A433PageGJSJson , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "true", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A439PageIsContentPage ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "false", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A439PageIsContentPage ) || ( StringUtil.Like( A437PageChildren , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) ) )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P006Y5_A433PageGJSJson[0], A433PageGJSJson) == 0 ) )
               {
                  BRK6Y8 = false;
                  A318Trn_PageName = P006Y5_A318Trn_PageName[0];
                  A310Trn_PageId = P006Y5_A310Trn_PageId[0];
                  A29LocationId = P006Y5_A29LocationId[0];
                  AV23count = (long)(AV23count+1);
                  BRK6Y8 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV14SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A433PageGJSJson)) ? "<#Empty#>" : A433PageGJSJson);
                  AV19Options.Add(AV18Option, 0);
                  AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV19Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV14SkipItems = (short)(AV14SkipItems-1);
               }
            }
            if ( ! BRK6Y8 )
            {
               BRK6Y8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADPAGECHILDRENOPTIONS' Routine */
         returnInSub = false;
         AV44TFPageChildren = AV13SearchTxt;
         AV45TFPageChildren_Sel = "";
         AV48Trn_pagewwds_1_filterfulltext = AV35FilterFullText;
         AV49Trn_pagewwds_2_tftrn_pagename = AV11TFTrn_PageName;
         AV50Trn_pagewwds_3_tftrn_pagename_sel = AV12TFTrn_PageName_Sel;
         AV51Trn_pagewwds_4_tfpagejsoncontent = AV36TFPageJsonContent;
         AV52Trn_pagewwds_5_tfpagejsoncontent_sel = AV37TFPageJsonContent_Sel;
         AV53Trn_pagewwds_6_tfpagegjshtml = AV38TFPageGJSHtml;
         AV54Trn_pagewwds_7_tfpagegjshtml_sel = AV39TFPageGJSHtml_Sel;
         AV55Trn_pagewwds_8_tfpagegjsjson = AV40TFPageGJSJson;
         AV56Trn_pagewwds_9_tfpagegjsjson_sel = AV41TFPageGJSJson_Sel;
         AV57Trn_pagewwds_10_tfpageispublished_sel = AV43TFPageIsPublished_Sel;
         AV58Trn_pagewwds_11_tfpageiscontentpage_sel = AV42TFPageIsContentPage_Sel;
         AV59Trn_pagewwds_12_tfpagechildren = AV44TFPageChildren;
         AV60Trn_pagewwds_13_tfpagechildren_sel = AV45TFPageChildren_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                              AV49Trn_pagewwds_2_tftrn_pagename ,
                                              AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                              AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                              AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                              AV53Trn_pagewwds_6_tfpagegjshtml ,
                                              AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                              AV55Trn_pagewwds_8_tfpagegjsjson ,
                                              AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                              AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                              AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                              AV59Trn_pagewwds_12_tfpagechildren ,
                                              A318Trn_PageName ,
                                              A431PageJsonContent ,
                                              A432PageGJSHtml ,
                                              A433PageGJSJson ,
                                              A434PageIsPublished ,
                                              A439PageIsContentPage ,
                                              A437PageChildren ,
                                              AV48Trn_pagewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV49Trn_pagewwds_2_tftrn_pagename = StringUtil.Concat( StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename), "%", "");
         lV51Trn_pagewwds_4_tfpagejsoncontent = StringUtil.Concat( StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent), "%", "");
         lV53Trn_pagewwds_6_tfpagegjshtml = StringUtil.Concat( StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml), "%", "");
         lV55Trn_pagewwds_8_tfpagegjsjson = StringUtil.Concat( StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson), "%", "");
         lV59Trn_pagewwds_12_tfpagechildren = StringUtil.Concat( StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren), "%", "");
         /* Using cursor P006Y6 */
         pr_default.execute(4, new Object[] {lV49Trn_pagewwds_2_tftrn_pagename, AV50Trn_pagewwds_3_tftrn_pagename_sel, lV51Trn_pagewwds_4_tfpagejsoncontent, AV52Trn_pagewwds_5_tfpagejsoncontent_sel, lV53Trn_pagewwds_6_tfpagegjshtml, AV54Trn_pagewwds_7_tfpagegjshtml_sel, lV55Trn_pagewwds_8_tfpagegjsjson, AV56Trn_pagewwds_9_tfpagegjsjson_sel, lV59Trn_pagewwds_12_tfpagechildren, AV60Trn_pagewwds_13_tfpagechildren_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK6Y10 = false;
            A437PageChildren = P006Y6_A437PageChildren[0];
            n437PageChildren = P006Y6_n437PageChildren[0];
            A434PageIsPublished = P006Y6_A434PageIsPublished[0];
            n434PageIsPublished = P006Y6_n434PageIsPublished[0];
            A439PageIsContentPage = P006Y6_A439PageIsContentPage[0];
            n439PageIsContentPage = P006Y6_n439PageIsContentPage[0];
            A433PageGJSJson = P006Y6_A433PageGJSJson[0];
            n433PageGJSJson = P006Y6_n433PageGJSJson[0];
            A432PageGJSHtml = P006Y6_A432PageGJSHtml[0];
            n432PageGJSHtml = P006Y6_n432PageGJSHtml[0];
            A431PageJsonContent = P006Y6_A431PageJsonContent[0];
            n431PageJsonContent = P006Y6_n431PageJsonContent[0];
            A318Trn_PageName = P006Y6_A318Trn_PageName[0];
            A310Trn_PageId = P006Y6_A310Trn_PageId[0];
            A29LocationId = P006Y6_A29LocationId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_pagewwds_1_filterfulltext)) || ( ( StringUtil.Like( A318Trn_PageName , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A431PageJsonContent , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( A432PageGJSHtml , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( A433PageGJSJson , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "true", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A439PageIsContentPage ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "false", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A439PageIsContentPage ) || ( StringUtil.Like( A437PageChildren , StringUtil.PadR( "%" + AV48Trn_pagewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) ) )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P006Y6_A437PageChildren[0], A437PageChildren) == 0 ) )
               {
                  BRK6Y10 = false;
                  A318Trn_PageName = P006Y6_A318Trn_PageName[0];
                  A310Trn_PageId = P006Y6_A310Trn_PageId[0];
                  A29LocationId = P006Y6_A29LocationId[0];
                  AV23count = (long)(AV23count+1);
                  BRK6Y10 = true;
                  pr_default.readNext(4);
               }
               if ( (0==AV14SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A437PageChildren)) ? "<#Empty#>" : A437PageChildren);
                  AV19Options.Add(AV18Option, 0);
                  AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV19Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV14SkipItems = (short)(AV14SkipItems-1);
               }
            }
            if ( ! BRK6Y10 )
            {
               BRK6Y10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
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
         AV32OptionsJson = "";
         AV33OptionsDescJson = "";
         AV34OptionIndexesJson = "";
         AV19Options = new GxSimpleCollection<string>();
         AV21OptionsDesc = new GxSimpleCollection<string>();
         AV22OptionIndexes = new GxSimpleCollection<string>();
         AV13SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV24Session = context.GetSession();
         AV26GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV35FilterFullText = "";
         AV11TFTrn_PageName = "";
         AV12TFTrn_PageName_Sel = "";
         AV36TFPageJsonContent = "";
         AV37TFPageJsonContent_Sel = "";
         AV38TFPageGJSHtml = "";
         AV39TFPageGJSHtml_Sel = "";
         AV40TFPageGJSJson = "";
         AV41TFPageGJSJson_Sel = "";
         AV44TFPageChildren = "";
         AV45TFPageChildren_Sel = "";
         AV48Trn_pagewwds_1_filterfulltext = "";
         AV49Trn_pagewwds_2_tftrn_pagename = "";
         AV50Trn_pagewwds_3_tftrn_pagename_sel = "";
         AV51Trn_pagewwds_4_tfpagejsoncontent = "";
         AV52Trn_pagewwds_5_tfpagejsoncontent_sel = "";
         AV53Trn_pagewwds_6_tfpagegjshtml = "";
         AV54Trn_pagewwds_7_tfpagegjshtml_sel = "";
         AV55Trn_pagewwds_8_tfpagegjsjson = "";
         AV56Trn_pagewwds_9_tfpagegjsjson_sel = "";
         AV59Trn_pagewwds_12_tfpagechildren = "";
         AV60Trn_pagewwds_13_tfpagechildren_sel = "";
         lV48Trn_pagewwds_1_filterfulltext = "";
         lV49Trn_pagewwds_2_tftrn_pagename = "";
         lV51Trn_pagewwds_4_tfpagejsoncontent = "";
         lV53Trn_pagewwds_6_tfpagegjshtml = "";
         lV55Trn_pagewwds_8_tfpagegjsjson = "";
         lV59Trn_pagewwds_12_tfpagechildren = "";
         A318Trn_PageName = "";
         A431PageJsonContent = "";
         A432PageGJSHtml = "";
         A433PageGJSJson = "";
         A437PageChildren = "";
         P006Y2_A318Trn_PageName = new string[] {""} ;
         P006Y2_A434PageIsPublished = new bool[] {false} ;
         P006Y2_n434PageIsPublished = new bool[] {false} ;
         P006Y2_A437PageChildren = new string[] {""} ;
         P006Y2_n437PageChildren = new bool[] {false} ;
         P006Y2_A439PageIsContentPage = new bool[] {false} ;
         P006Y2_n439PageIsContentPage = new bool[] {false} ;
         P006Y2_A433PageGJSJson = new string[] {""} ;
         P006Y2_n433PageGJSJson = new bool[] {false} ;
         P006Y2_A432PageGJSHtml = new string[] {""} ;
         P006Y2_n432PageGJSHtml = new bool[] {false} ;
         P006Y2_A431PageJsonContent = new string[] {""} ;
         P006Y2_n431PageJsonContent = new bool[] {false} ;
         P006Y2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P006Y2_A29LocationId = new Guid[] {Guid.Empty} ;
         A310Trn_PageId = Guid.Empty;
         A29LocationId = Guid.Empty;
         AV18Option = "";
         P006Y3_A431PageJsonContent = new string[] {""} ;
         P006Y3_n431PageJsonContent = new bool[] {false} ;
         P006Y3_A434PageIsPublished = new bool[] {false} ;
         P006Y3_n434PageIsPublished = new bool[] {false} ;
         P006Y3_A437PageChildren = new string[] {""} ;
         P006Y3_n437PageChildren = new bool[] {false} ;
         P006Y3_A439PageIsContentPage = new bool[] {false} ;
         P006Y3_n439PageIsContentPage = new bool[] {false} ;
         P006Y3_A433PageGJSJson = new string[] {""} ;
         P006Y3_n433PageGJSJson = new bool[] {false} ;
         P006Y3_A432PageGJSHtml = new string[] {""} ;
         P006Y3_n432PageGJSHtml = new bool[] {false} ;
         P006Y3_A318Trn_PageName = new string[] {""} ;
         P006Y3_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P006Y3_A29LocationId = new Guid[] {Guid.Empty} ;
         P006Y4_A432PageGJSHtml = new string[] {""} ;
         P006Y4_n432PageGJSHtml = new bool[] {false} ;
         P006Y4_A434PageIsPublished = new bool[] {false} ;
         P006Y4_n434PageIsPublished = new bool[] {false} ;
         P006Y4_A437PageChildren = new string[] {""} ;
         P006Y4_n437PageChildren = new bool[] {false} ;
         P006Y4_A439PageIsContentPage = new bool[] {false} ;
         P006Y4_n439PageIsContentPage = new bool[] {false} ;
         P006Y4_A433PageGJSJson = new string[] {""} ;
         P006Y4_n433PageGJSJson = new bool[] {false} ;
         P006Y4_A431PageJsonContent = new string[] {""} ;
         P006Y4_n431PageJsonContent = new bool[] {false} ;
         P006Y4_A318Trn_PageName = new string[] {""} ;
         P006Y4_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P006Y4_A29LocationId = new Guid[] {Guid.Empty} ;
         P006Y5_A433PageGJSJson = new string[] {""} ;
         P006Y5_n433PageGJSJson = new bool[] {false} ;
         P006Y5_A434PageIsPublished = new bool[] {false} ;
         P006Y5_n434PageIsPublished = new bool[] {false} ;
         P006Y5_A437PageChildren = new string[] {""} ;
         P006Y5_n437PageChildren = new bool[] {false} ;
         P006Y5_A439PageIsContentPage = new bool[] {false} ;
         P006Y5_n439PageIsContentPage = new bool[] {false} ;
         P006Y5_A432PageGJSHtml = new string[] {""} ;
         P006Y5_n432PageGJSHtml = new bool[] {false} ;
         P006Y5_A431PageJsonContent = new string[] {""} ;
         P006Y5_n431PageJsonContent = new bool[] {false} ;
         P006Y5_A318Trn_PageName = new string[] {""} ;
         P006Y5_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P006Y5_A29LocationId = new Guid[] {Guid.Empty} ;
         P006Y6_A437PageChildren = new string[] {""} ;
         P006Y6_n437PageChildren = new bool[] {false} ;
         P006Y6_A434PageIsPublished = new bool[] {false} ;
         P006Y6_n434PageIsPublished = new bool[] {false} ;
         P006Y6_A439PageIsContentPage = new bool[] {false} ;
         P006Y6_n439PageIsContentPage = new bool[] {false} ;
         P006Y6_A433PageGJSJson = new string[] {""} ;
         P006Y6_n433PageGJSJson = new bool[] {false} ;
         P006Y6_A432PageGJSHtml = new string[] {""} ;
         P006Y6_n432PageGJSHtml = new bool[] {false} ;
         P006Y6_A431PageJsonContent = new string[] {""} ;
         P006Y6_n431PageJsonContent = new bool[] {false} ;
         P006Y6_A318Trn_PageName = new string[] {""} ;
         P006Y6_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P006Y6_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_pagewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006Y2_A318Trn_PageName, P006Y2_A434PageIsPublished, P006Y2_n434PageIsPublished, P006Y2_A437PageChildren, P006Y2_n437PageChildren, P006Y2_A439PageIsContentPage, P006Y2_n439PageIsContentPage, P006Y2_A433PageGJSJson, P006Y2_n433PageGJSJson, P006Y2_A432PageGJSHtml,
               P006Y2_n432PageGJSHtml, P006Y2_A431PageJsonContent, P006Y2_n431PageJsonContent, P006Y2_A310Trn_PageId, P006Y2_A29LocationId
               }
               , new Object[] {
               P006Y3_A431PageJsonContent, P006Y3_n431PageJsonContent, P006Y3_A434PageIsPublished, P006Y3_n434PageIsPublished, P006Y3_A437PageChildren, P006Y3_n437PageChildren, P006Y3_A439PageIsContentPage, P006Y3_n439PageIsContentPage, P006Y3_A433PageGJSJson, P006Y3_n433PageGJSJson,
               P006Y3_A432PageGJSHtml, P006Y3_n432PageGJSHtml, P006Y3_A318Trn_PageName, P006Y3_A310Trn_PageId, P006Y3_A29LocationId
               }
               , new Object[] {
               P006Y4_A432PageGJSHtml, P006Y4_n432PageGJSHtml, P006Y4_A434PageIsPublished, P006Y4_n434PageIsPublished, P006Y4_A437PageChildren, P006Y4_n437PageChildren, P006Y4_A439PageIsContentPage, P006Y4_n439PageIsContentPage, P006Y4_A433PageGJSJson, P006Y4_n433PageGJSJson,
               P006Y4_A431PageJsonContent, P006Y4_n431PageJsonContent, P006Y4_A318Trn_PageName, P006Y4_A310Trn_PageId, P006Y4_A29LocationId
               }
               , new Object[] {
               P006Y5_A433PageGJSJson, P006Y5_n433PageGJSJson, P006Y5_A434PageIsPublished, P006Y5_n434PageIsPublished, P006Y5_A437PageChildren, P006Y5_n437PageChildren, P006Y5_A439PageIsContentPage, P006Y5_n439PageIsContentPage, P006Y5_A432PageGJSHtml, P006Y5_n432PageGJSHtml,
               P006Y5_A431PageJsonContent, P006Y5_n431PageJsonContent, P006Y5_A318Trn_PageName, P006Y5_A310Trn_PageId, P006Y5_A29LocationId
               }
               , new Object[] {
               P006Y6_A437PageChildren, P006Y6_n437PageChildren, P006Y6_A434PageIsPublished, P006Y6_n434PageIsPublished, P006Y6_A439PageIsContentPage, P006Y6_n439PageIsContentPage, P006Y6_A433PageGJSJson, P006Y6_n433PageGJSJson, P006Y6_A432PageGJSHtml, P006Y6_n432PageGJSHtml,
               P006Y6_A431PageJsonContent, P006Y6_n431PageJsonContent, P006Y6_A318Trn_PageName, P006Y6_A310Trn_PageId, P006Y6_A29LocationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MaxItems ;
      private short AV15PageIndex ;
      private short AV14SkipItems ;
      private short AV43TFPageIsPublished_Sel ;
      private short AV42TFPageIsContentPage_Sel ;
      private short AV57Trn_pagewwds_10_tfpageispublished_sel ;
      private short AV58Trn_pagewwds_11_tfpageiscontentpage_sel ;
      private int AV46GXV1 ;
      private long AV23count ;
      private bool returnInSub ;
      private bool A434PageIsPublished ;
      private bool A439PageIsContentPage ;
      private bool BRK6Y2 ;
      private bool n434PageIsPublished ;
      private bool n437PageChildren ;
      private bool n439PageIsContentPage ;
      private bool n433PageGJSJson ;
      private bool n432PageGJSHtml ;
      private bool n431PageJsonContent ;
      private bool BRK6Y4 ;
      private bool BRK6Y6 ;
      private bool BRK6Y8 ;
      private bool BRK6Y10 ;
      private string AV32OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string A431PageJsonContent ;
      private string A432PageGJSHtml ;
      private string A433PageGJSJson ;
      private string A437PageChildren ;
      private string AV29DDOName ;
      private string AV30SearchTxtParms ;
      private string AV31SearchTxtTo ;
      private string AV13SearchTxt ;
      private string AV35FilterFullText ;
      private string AV11TFTrn_PageName ;
      private string AV12TFTrn_PageName_Sel ;
      private string AV36TFPageJsonContent ;
      private string AV37TFPageJsonContent_Sel ;
      private string AV38TFPageGJSHtml ;
      private string AV39TFPageGJSHtml_Sel ;
      private string AV40TFPageGJSJson ;
      private string AV41TFPageGJSJson_Sel ;
      private string AV44TFPageChildren ;
      private string AV45TFPageChildren_Sel ;
      private string AV48Trn_pagewwds_1_filterfulltext ;
      private string AV49Trn_pagewwds_2_tftrn_pagename ;
      private string AV50Trn_pagewwds_3_tftrn_pagename_sel ;
      private string AV51Trn_pagewwds_4_tfpagejsoncontent ;
      private string AV52Trn_pagewwds_5_tfpagejsoncontent_sel ;
      private string AV53Trn_pagewwds_6_tfpagegjshtml ;
      private string AV54Trn_pagewwds_7_tfpagegjshtml_sel ;
      private string AV55Trn_pagewwds_8_tfpagegjsjson ;
      private string AV56Trn_pagewwds_9_tfpagegjsjson_sel ;
      private string AV59Trn_pagewwds_12_tfpagechildren ;
      private string AV60Trn_pagewwds_13_tfpagechildren_sel ;
      private string lV48Trn_pagewwds_1_filterfulltext ;
      private string lV49Trn_pagewwds_2_tftrn_pagename ;
      private string lV51Trn_pagewwds_4_tfpagejsoncontent ;
      private string lV53Trn_pagewwds_6_tfpagegjshtml ;
      private string lV55Trn_pagewwds_8_tfpagegjsjson ;
      private string lV59Trn_pagewwds_12_tfpagechildren ;
      private string A318Trn_PageName ;
      private string AV18Option ;
      private Guid A310Trn_PageId ;
      private Guid A29LocationId ;
      private IGxSession AV24Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV19Options ;
      private GxSimpleCollection<string> AV21OptionsDesc ;
      private GxSimpleCollection<string> AV22OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV26GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV27GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P006Y2_A318Trn_PageName ;
      private bool[] P006Y2_A434PageIsPublished ;
      private bool[] P006Y2_n434PageIsPublished ;
      private string[] P006Y2_A437PageChildren ;
      private bool[] P006Y2_n437PageChildren ;
      private bool[] P006Y2_A439PageIsContentPage ;
      private bool[] P006Y2_n439PageIsContentPage ;
      private string[] P006Y2_A433PageGJSJson ;
      private bool[] P006Y2_n433PageGJSJson ;
      private string[] P006Y2_A432PageGJSHtml ;
      private bool[] P006Y2_n432PageGJSHtml ;
      private string[] P006Y2_A431PageJsonContent ;
      private bool[] P006Y2_n431PageJsonContent ;
      private Guid[] P006Y2_A310Trn_PageId ;
      private Guid[] P006Y2_A29LocationId ;
      private string[] P006Y3_A431PageJsonContent ;
      private bool[] P006Y3_n431PageJsonContent ;
      private bool[] P006Y3_A434PageIsPublished ;
      private bool[] P006Y3_n434PageIsPublished ;
      private string[] P006Y3_A437PageChildren ;
      private bool[] P006Y3_n437PageChildren ;
      private bool[] P006Y3_A439PageIsContentPage ;
      private bool[] P006Y3_n439PageIsContentPage ;
      private string[] P006Y3_A433PageGJSJson ;
      private bool[] P006Y3_n433PageGJSJson ;
      private string[] P006Y3_A432PageGJSHtml ;
      private bool[] P006Y3_n432PageGJSHtml ;
      private string[] P006Y3_A318Trn_PageName ;
      private Guid[] P006Y3_A310Trn_PageId ;
      private Guid[] P006Y3_A29LocationId ;
      private string[] P006Y4_A432PageGJSHtml ;
      private bool[] P006Y4_n432PageGJSHtml ;
      private bool[] P006Y4_A434PageIsPublished ;
      private bool[] P006Y4_n434PageIsPublished ;
      private string[] P006Y4_A437PageChildren ;
      private bool[] P006Y4_n437PageChildren ;
      private bool[] P006Y4_A439PageIsContentPage ;
      private bool[] P006Y4_n439PageIsContentPage ;
      private string[] P006Y4_A433PageGJSJson ;
      private bool[] P006Y4_n433PageGJSJson ;
      private string[] P006Y4_A431PageJsonContent ;
      private bool[] P006Y4_n431PageJsonContent ;
      private string[] P006Y4_A318Trn_PageName ;
      private Guid[] P006Y4_A310Trn_PageId ;
      private Guid[] P006Y4_A29LocationId ;
      private string[] P006Y5_A433PageGJSJson ;
      private bool[] P006Y5_n433PageGJSJson ;
      private bool[] P006Y5_A434PageIsPublished ;
      private bool[] P006Y5_n434PageIsPublished ;
      private string[] P006Y5_A437PageChildren ;
      private bool[] P006Y5_n437PageChildren ;
      private bool[] P006Y5_A439PageIsContentPage ;
      private bool[] P006Y5_n439PageIsContentPage ;
      private string[] P006Y5_A432PageGJSHtml ;
      private bool[] P006Y5_n432PageGJSHtml ;
      private string[] P006Y5_A431PageJsonContent ;
      private bool[] P006Y5_n431PageJsonContent ;
      private string[] P006Y5_A318Trn_PageName ;
      private Guid[] P006Y5_A310Trn_PageId ;
      private Guid[] P006Y5_A29LocationId ;
      private string[] P006Y6_A437PageChildren ;
      private bool[] P006Y6_n437PageChildren ;
      private bool[] P006Y6_A434PageIsPublished ;
      private bool[] P006Y6_n434PageIsPublished ;
      private bool[] P006Y6_A439PageIsContentPage ;
      private bool[] P006Y6_n439PageIsContentPage ;
      private string[] P006Y6_A433PageGJSJson ;
      private bool[] P006Y6_n433PageGJSJson ;
      private string[] P006Y6_A432PageGJSHtml ;
      private bool[] P006Y6_n432PageGJSHtml ;
      private string[] P006Y6_A431PageJsonContent ;
      private bool[] P006Y6_n431PageJsonContent ;
      private string[] P006Y6_A318Trn_PageName ;
      private Guid[] P006Y6_A310Trn_PageId ;
      private Guid[] P006Y6_A29LocationId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_pagewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006Y2( IGxContext context ,
                                             string AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                             string AV49Trn_pagewwds_2_tftrn_pagename ,
                                             string AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                             string AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                             string AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                             string AV53Trn_pagewwds_6_tfpagegjshtml ,
                                             string AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                             string AV55Trn_pagewwds_8_tfpagegjsjson ,
                                             short AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                             short AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                             string AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                             string AV59Trn_pagewwds_12_tfpagechildren ,
                                             string A318Trn_PageName ,
                                             string A431PageJsonContent ,
                                             string A432PageGJSHtml ,
                                             string A433PageGJSJson ,
                                             bool A434PageIsPublished ,
                                             bool A439PageIsContentPage ,
                                             string A437PageChildren ,
                                             string AV48Trn_pagewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT Trn_PageName, PageIsPublished, PageChildren, PageIsContentPage, PageGJSJson, PageGJSHtml, PageJsonContent, Trn_PageId, LocationId FROM Trn_Page";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename)) ) )
         {
            AddWhere(sWhereString, "(Trn_PageName like :lV49Trn_pagewwds_2_tftrn_pagename)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ! ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_PageName = ( :AV50Trn_pagewwds_3_tftrn_pagename_sel))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_PageName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent)) ) )
         {
            AddWhere(sWhereString, "(PageJsonContent like :lV51Trn_pagewwds_4_tfpagejsoncontent)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ! ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageJsonContent = ( :AV52Trn_pagewwds_5_tfpagejsoncontent_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageJsonContent IS NULL or (char_length(trim(trailing ' ' from PageJsonContent))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml)) ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml like :lV53Trn_pagewwds_6_tfpagegjshtml)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ! ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml = ( :AV54Trn_pagewwds_7_tfpagegjshtml_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSHtml IS NULL or (char_length(trim(trailing ' ' from PageGJSHtml))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson)) ) )
         {
            AddWhere(sWhereString, "(PageGJSJson like :lV55Trn_pagewwds_8_tfpagegjsjson)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ! ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSJson = ( :AV56Trn_pagewwds_9_tfpagegjsjson_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSJson IS NULL or (char_length(trim(trailing ' ' from PageGJSJson))=0))");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsPublished = TRUE)");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsPublished = FALSE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = TRUE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren)) ) )
         {
            AddWhere(sWhereString, "(PageChildren like :lV59Trn_pagewwds_12_tfpagechildren)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ! ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageChildren = ( :AV60Trn_pagewwds_13_tfpagechildren_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageChildren IS NULL or (char_length(trim(trailing ' ' from PageChildren))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Trn_PageName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006Y3( IGxContext context ,
                                             string AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                             string AV49Trn_pagewwds_2_tftrn_pagename ,
                                             string AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                             string AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                             string AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                             string AV53Trn_pagewwds_6_tfpagegjshtml ,
                                             string AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                             string AV55Trn_pagewwds_8_tfpagegjsjson ,
                                             short AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                             short AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                             string AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                             string AV59Trn_pagewwds_12_tfpagechildren ,
                                             string A318Trn_PageName ,
                                             string A431PageJsonContent ,
                                             string A432PageGJSHtml ,
                                             string A433PageGJSJson ,
                                             bool A434PageIsPublished ,
                                             bool A439PageIsContentPage ,
                                             string A437PageChildren ,
                                             string AV48Trn_pagewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT PageJsonContent, PageIsPublished, PageChildren, PageIsContentPage, PageGJSJson, PageGJSHtml, Trn_PageName, Trn_PageId, LocationId FROM Trn_Page";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename)) ) )
         {
            AddWhere(sWhereString, "(Trn_PageName like :lV49Trn_pagewwds_2_tftrn_pagename)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ! ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_PageName = ( :AV50Trn_pagewwds_3_tftrn_pagename_sel))");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_PageName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent)) ) )
         {
            AddWhere(sWhereString, "(PageJsonContent like :lV51Trn_pagewwds_4_tfpagejsoncontent)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ! ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageJsonContent = ( :AV52Trn_pagewwds_5_tfpagejsoncontent_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageJsonContent IS NULL or (char_length(trim(trailing ' ' from PageJsonContent))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml)) ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml like :lV53Trn_pagewwds_6_tfpagegjshtml)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ! ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml = ( :AV54Trn_pagewwds_7_tfpagegjshtml_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSHtml IS NULL or (char_length(trim(trailing ' ' from PageGJSHtml))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson)) ) )
         {
            AddWhere(sWhereString, "(PageGJSJson like :lV55Trn_pagewwds_8_tfpagegjsjson)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ! ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSJson = ( :AV56Trn_pagewwds_9_tfpagegjsjson_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSJson IS NULL or (char_length(trim(trailing ' ' from PageGJSJson))=0))");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsPublished = TRUE)");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsPublished = FALSE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = TRUE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren)) ) )
         {
            AddWhere(sWhereString, "(PageChildren like :lV59Trn_pagewwds_12_tfpagechildren)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ! ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageChildren = ( :AV60Trn_pagewwds_13_tfpagechildren_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageChildren IS NULL or (char_length(trim(trailing ' ' from PageChildren))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY PageJsonContent";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006Y4( IGxContext context ,
                                             string AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                             string AV49Trn_pagewwds_2_tftrn_pagename ,
                                             string AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                             string AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                             string AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                             string AV53Trn_pagewwds_6_tfpagegjshtml ,
                                             string AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                             string AV55Trn_pagewwds_8_tfpagegjsjson ,
                                             short AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                             short AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                             string AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                             string AV59Trn_pagewwds_12_tfpagechildren ,
                                             string A318Trn_PageName ,
                                             string A431PageJsonContent ,
                                             string A432PageGJSHtml ,
                                             string A433PageGJSJson ,
                                             bool A434PageIsPublished ,
                                             bool A439PageIsContentPage ,
                                             string A437PageChildren ,
                                             string AV48Trn_pagewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[10];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT PageGJSHtml, PageIsPublished, PageChildren, PageIsContentPage, PageGJSJson, PageJsonContent, Trn_PageName, Trn_PageId, LocationId FROM Trn_Page";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename)) ) )
         {
            AddWhere(sWhereString, "(Trn_PageName like :lV49Trn_pagewwds_2_tftrn_pagename)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ! ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_PageName = ( :AV50Trn_pagewwds_3_tftrn_pagename_sel))");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_PageName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent)) ) )
         {
            AddWhere(sWhereString, "(PageJsonContent like :lV51Trn_pagewwds_4_tfpagejsoncontent)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ! ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageJsonContent = ( :AV52Trn_pagewwds_5_tfpagejsoncontent_sel))");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageJsonContent IS NULL or (char_length(trim(trailing ' ' from PageJsonContent))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml)) ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml like :lV53Trn_pagewwds_6_tfpagegjshtml)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ! ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml = ( :AV54Trn_pagewwds_7_tfpagegjshtml_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSHtml IS NULL or (char_length(trim(trailing ' ' from PageGJSHtml))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson)) ) )
         {
            AddWhere(sWhereString, "(PageGJSJson like :lV55Trn_pagewwds_8_tfpagegjsjson)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ! ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSJson = ( :AV56Trn_pagewwds_9_tfpagegjsjson_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSJson IS NULL or (char_length(trim(trailing ' ' from PageGJSJson))=0))");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsPublished = TRUE)");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsPublished = FALSE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = TRUE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren)) ) )
         {
            AddWhere(sWhereString, "(PageChildren like :lV59Trn_pagewwds_12_tfpagechildren)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ! ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageChildren = ( :AV60Trn_pagewwds_13_tfpagechildren_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageChildren IS NULL or (char_length(trim(trailing ' ' from PageChildren))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY PageGJSHtml";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P006Y5( IGxContext context ,
                                             string AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                             string AV49Trn_pagewwds_2_tftrn_pagename ,
                                             string AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                             string AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                             string AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                             string AV53Trn_pagewwds_6_tfpagegjshtml ,
                                             string AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                             string AV55Trn_pagewwds_8_tfpagegjsjson ,
                                             short AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                             short AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                             string AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                             string AV59Trn_pagewwds_12_tfpagechildren ,
                                             string A318Trn_PageName ,
                                             string A431PageJsonContent ,
                                             string A432PageGJSHtml ,
                                             string A433PageGJSJson ,
                                             bool A434PageIsPublished ,
                                             bool A439PageIsContentPage ,
                                             string A437PageChildren ,
                                             string AV48Trn_pagewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[10];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT PageGJSJson, PageIsPublished, PageChildren, PageIsContentPage, PageGJSHtml, PageJsonContent, Trn_PageName, Trn_PageId, LocationId FROM Trn_Page";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename)) ) )
         {
            AddWhere(sWhereString, "(Trn_PageName like :lV49Trn_pagewwds_2_tftrn_pagename)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ! ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_PageName = ( :AV50Trn_pagewwds_3_tftrn_pagename_sel))");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_PageName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent)) ) )
         {
            AddWhere(sWhereString, "(PageJsonContent like :lV51Trn_pagewwds_4_tfpagejsoncontent)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ! ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageJsonContent = ( :AV52Trn_pagewwds_5_tfpagejsoncontent_sel))");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageJsonContent IS NULL or (char_length(trim(trailing ' ' from PageJsonContent))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml)) ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml like :lV53Trn_pagewwds_6_tfpagegjshtml)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ! ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml = ( :AV54Trn_pagewwds_7_tfpagegjshtml_sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSHtml IS NULL or (char_length(trim(trailing ' ' from PageGJSHtml))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson)) ) )
         {
            AddWhere(sWhereString, "(PageGJSJson like :lV55Trn_pagewwds_8_tfpagegjsjson)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ! ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSJson = ( :AV56Trn_pagewwds_9_tfpagegjsjson_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSJson IS NULL or (char_length(trim(trailing ' ' from PageGJSJson))=0))");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsPublished = TRUE)");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsPublished = FALSE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = TRUE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren)) ) )
         {
            AddWhere(sWhereString, "(PageChildren like :lV59Trn_pagewwds_12_tfpagechildren)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ! ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageChildren = ( :AV60Trn_pagewwds_13_tfpagechildren_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageChildren IS NULL or (char_length(trim(trailing ' ' from PageChildren))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY PageGJSJson";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P006Y6( IGxContext context ,
                                             string AV50Trn_pagewwds_3_tftrn_pagename_sel ,
                                             string AV49Trn_pagewwds_2_tftrn_pagename ,
                                             string AV52Trn_pagewwds_5_tfpagejsoncontent_sel ,
                                             string AV51Trn_pagewwds_4_tfpagejsoncontent ,
                                             string AV54Trn_pagewwds_7_tfpagegjshtml_sel ,
                                             string AV53Trn_pagewwds_6_tfpagegjshtml ,
                                             string AV56Trn_pagewwds_9_tfpagegjsjson_sel ,
                                             string AV55Trn_pagewwds_8_tfpagegjsjson ,
                                             short AV57Trn_pagewwds_10_tfpageispublished_sel ,
                                             short AV58Trn_pagewwds_11_tfpageiscontentpage_sel ,
                                             string AV60Trn_pagewwds_13_tfpagechildren_sel ,
                                             string AV59Trn_pagewwds_12_tfpagechildren ,
                                             string A318Trn_PageName ,
                                             string A431PageJsonContent ,
                                             string A432PageGJSHtml ,
                                             string A433PageGJSJson ,
                                             bool A434PageIsPublished ,
                                             bool A439PageIsContentPage ,
                                             string A437PageChildren ,
                                             string AV48Trn_pagewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[10];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT PageChildren, PageIsPublished, PageIsContentPage, PageGJSJson, PageGJSHtml, PageJsonContent, Trn_PageName, Trn_PageId, LocationId FROM Trn_Page";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_pagewwds_2_tftrn_pagename)) ) )
         {
            AddWhere(sWhereString, "(Trn_PageName like :lV49Trn_pagewwds_2_tftrn_pagename)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_pagewwds_3_tftrn_pagename_sel)) && ! ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_PageName = ( :AV50Trn_pagewwds_3_tftrn_pagename_sel))");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_PageName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_pagewwds_4_tfpagejsoncontent)) ) )
         {
            AddWhere(sWhereString, "(PageJsonContent like :lV51Trn_pagewwds_4_tfpagejsoncontent)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_pagewwds_5_tfpagejsoncontent_sel)) && ! ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageJsonContent = ( :AV52Trn_pagewwds_5_tfpagejsoncontent_sel))");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_pagewwds_5_tfpagejsoncontent_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageJsonContent IS NULL or (char_length(trim(trailing ' ' from PageJsonContent))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_pagewwds_6_tfpagegjshtml)) ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml like :lV53Trn_pagewwds_6_tfpagegjshtml)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_pagewwds_7_tfpagegjshtml_sel)) && ! ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSHtml = ( :AV54Trn_pagewwds_7_tfpagegjshtml_sel))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_pagewwds_7_tfpagegjshtml_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSHtml IS NULL or (char_length(trim(trailing ' ' from PageGJSHtml))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_pagewwds_8_tfpagegjsjson)) ) )
         {
            AddWhere(sWhereString, "(PageGJSJson like :lV55Trn_pagewwds_8_tfpagegjsjson)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_pagewwds_9_tfpagegjsjson_sel)) && ! ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageGJSJson = ( :AV56Trn_pagewwds_9_tfpagegjsjson_sel))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_pagewwds_9_tfpagegjsjson_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageGJSJson IS NULL or (char_length(trim(trailing ' ' from PageGJSJson))=0))");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsPublished = TRUE)");
         }
         if ( AV57Trn_pagewwds_10_tfpageispublished_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsPublished = FALSE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = TRUE)");
         }
         if ( AV58Trn_pagewwds_11_tfpageiscontentpage_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = FALSE)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_pagewwds_12_tfpagechildren)) ) )
         {
            AddWhere(sWhereString, "(PageChildren like :lV59Trn_pagewwds_12_tfpagechildren)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_pagewwds_13_tfpagechildren_sel)) && ! ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageChildren = ( :AV60Trn_pagewwds_13_tfpagechildren_sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_pagewwds_13_tfpagechildren_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(PageChildren IS NULL or (char_length(trim(trailing ' ' from PageChildren))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY PageChildren";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006Y2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
               case 1 :
                     return conditional_P006Y3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
               case 2 :
                     return conditional_P006Y4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
               case 3 :
                     return conditional_P006Y5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
               case 4 :
                     return conditional_P006Y6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006Y2;
          prmP006Y2 = new Object[] {
          new ParDef("lV49Trn_pagewwds_2_tftrn_pagename",GXType.VarChar,100,0) ,
          new ParDef("AV50Trn_pagewwds_3_tftrn_pagename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_pagewwds_4_tfpagejsoncontent",GXType.VarChar,200,0) ,
          new ParDef("AV52Trn_pagewwds_5_tfpagejsoncontent_sel",GXType.VarChar,200,0) ,
          new ParDef("lV53Trn_pagewwds_6_tfpagegjshtml",GXType.VarChar,200,0) ,
          new ParDef("AV54Trn_pagewwds_7_tfpagegjshtml_sel",GXType.VarChar,200,0) ,
          new ParDef("lV55Trn_pagewwds_8_tfpagegjsjson",GXType.VarChar,200,0) ,
          new ParDef("AV56Trn_pagewwds_9_tfpagegjsjson_sel",GXType.VarChar,200,0) ,
          new ParDef("lV59Trn_pagewwds_12_tfpagechildren",GXType.VarChar,200,0) ,
          new ParDef("AV60Trn_pagewwds_13_tfpagechildren_sel",GXType.VarChar,200,0)
          };
          Object[] prmP006Y3;
          prmP006Y3 = new Object[] {
          new ParDef("lV49Trn_pagewwds_2_tftrn_pagename",GXType.VarChar,100,0) ,
          new ParDef("AV50Trn_pagewwds_3_tftrn_pagename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_pagewwds_4_tfpagejsoncontent",GXType.VarChar,200,0) ,
          new ParDef("AV52Trn_pagewwds_5_tfpagejsoncontent_sel",GXType.VarChar,200,0) ,
          new ParDef("lV53Trn_pagewwds_6_tfpagegjshtml",GXType.VarChar,200,0) ,
          new ParDef("AV54Trn_pagewwds_7_tfpagegjshtml_sel",GXType.VarChar,200,0) ,
          new ParDef("lV55Trn_pagewwds_8_tfpagegjsjson",GXType.VarChar,200,0) ,
          new ParDef("AV56Trn_pagewwds_9_tfpagegjsjson_sel",GXType.VarChar,200,0) ,
          new ParDef("lV59Trn_pagewwds_12_tfpagechildren",GXType.VarChar,200,0) ,
          new ParDef("AV60Trn_pagewwds_13_tfpagechildren_sel",GXType.VarChar,200,0)
          };
          Object[] prmP006Y4;
          prmP006Y4 = new Object[] {
          new ParDef("lV49Trn_pagewwds_2_tftrn_pagename",GXType.VarChar,100,0) ,
          new ParDef("AV50Trn_pagewwds_3_tftrn_pagename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_pagewwds_4_tfpagejsoncontent",GXType.VarChar,200,0) ,
          new ParDef("AV52Trn_pagewwds_5_tfpagejsoncontent_sel",GXType.VarChar,200,0) ,
          new ParDef("lV53Trn_pagewwds_6_tfpagegjshtml",GXType.VarChar,200,0) ,
          new ParDef("AV54Trn_pagewwds_7_tfpagegjshtml_sel",GXType.VarChar,200,0) ,
          new ParDef("lV55Trn_pagewwds_8_tfpagegjsjson",GXType.VarChar,200,0) ,
          new ParDef("AV56Trn_pagewwds_9_tfpagegjsjson_sel",GXType.VarChar,200,0) ,
          new ParDef("lV59Trn_pagewwds_12_tfpagechildren",GXType.VarChar,200,0) ,
          new ParDef("AV60Trn_pagewwds_13_tfpagechildren_sel",GXType.VarChar,200,0)
          };
          Object[] prmP006Y5;
          prmP006Y5 = new Object[] {
          new ParDef("lV49Trn_pagewwds_2_tftrn_pagename",GXType.VarChar,100,0) ,
          new ParDef("AV50Trn_pagewwds_3_tftrn_pagename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_pagewwds_4_tfpagejsoncontent",GXType.VarChar,200,0) ,
          new ParDef("AV52Trn_pagewwds_5_tfpagejsoncontent_sel",GXType.VarChar,200,0) ,
          new ParDef("lV53Trn_pagewwds_6_tfpagegjshtml",GXType.VarChar,200,0) ,
          new ParDef("AV54Trn_pagewwds_7_tfpagegjshtml_sel",GXType.VarChar,200,0) ,
          new ParDef("lV55Trn_pagewwds_8_tfpagegjsjson",GXType.VarChar,200,0) ,
          new ParDef("AV56Trn_pagewwds_9_tfpagegjsjson_sel",GXType.VarChar,200,0) ,
          new ParDef("lV59Trn_pagewwds_12_tfpagechildren",GXType.VarChar,200,0) ,
          new ParDef("AV60Trn_pagewwds_13_tfpagechildren_sel",GXType.VarChar,200,0)
          };
          Object[] prmP006Y6;
          prmP006Y6 = new Object[] {
          new ParDef("lV49Trn_pagewwds_2_tftrn_pagename",GXType.VarChar,100,0) ,
          new ParDef("AV50Trn_pagewwds_3_tftrn_pagename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_pagewwds_4_tfpagejsoncontent",GXType.VarChar,200,0) ,
          new ParDef("AV52Trn_pagewwds_5_tfpagejsoncontent_sel",GXType.VarChar,200,0) ,
          new ParDef("lV53Trn_pagewwds_6_tfpagegjshtml",GXType.VarChar,200,0) ,
          new ParDef("AV54Trn_pagewwds_7_tfpagegjshtml_sel",GXType.VarChar,200,0) ,
          new ParDef("lV55Trn_pagewwds_8_tfpagegjsjson",GXType.VarChar,200,0) ,
          new ParDef("AV56Trn_pagewwds_9_tfpagegjsjson_sel",GXType.VarChar,200,0) ,
          new ParDef("lV59Trn_pagewwds_12_tfpagechildren",GXType.VarChar,200,0) ,
          new ParDef("AV60Trn_pagewwds_13_tfpagechildren_sel",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Y2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Y3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006Y4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Y4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006Y5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Y5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006Y6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Y6,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((Guid[]) buf[13])[0] = rslt.getGuid(8);
                ((Guid[]) buf[14])[0] = rslt.getGuid(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((Guid[]) buf[13])[0] = rslt.getGuid(8);
                ((Guid[]) buf[14])[0] = rslt.getGuid(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((Guid[]) buf[13])[0] = rslt.getGuid(8);
                ((Guid[]) buf[14])[0] = rslt.getGuid(9);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((Guid[]) buf[13])[0] = rslt.getGuid(8);
                ((Guid[]) buf[14])[0] = rslt.getGuid(9);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((Guid[]) buf[13])[0] = rslt.getGuid(8);
                ((Guid[]) buf[14])[0] = rslt.getGuid(9);
                return;
       }
    }

 }

}
