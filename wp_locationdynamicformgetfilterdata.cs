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
   public class wp_locationdynamicformgetfilterdata : GXProcedure
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
            return "wp_locationdynamicform_Services_Execute" ;
         }

      }

      public wp_locationdynamicformgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_locationdynamicformgetfilterdata( IGxContext context )
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
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV42OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV27Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24MaxItems = 10;
         AV23PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV38SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV21SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? "" : StringUtil.Substring( AV38SearchTxtParms, 3, -1));
         AV22SkipItems = (short)(AV23PageIndex*AV24MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_WWPFORMREFERENCENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPFORMREFERENCENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_WWPFORMTITLE") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPFORMTITLEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV40OptionsJson = AV27Options.ToJSonString(false);
         AV41OptionsDescJson = AV29OptionsDesc.ToJSonString(false);
         AV42OptionIndexesJson = AV30OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("WP_LocationDynamicFormGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WP_LocationDynamicFormGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("WP_LocationDynamicFormGridState"), null, "", "");
         }
         AV45GXV1 = 1;
         while ( AV45GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV45GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME") == 0 )
            {
               AV11TFWWPFormReferenceName = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME_SEL") == 0 )
            {
               AV12TFWWPFormReferenceName_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE") == 0 )
            {
               AV13TFWWPFormTitle = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE_SEL") == 0 )
            {
               AV14TFWWPFormTitle_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMDATE") == 0 )
            {
               AV15TFWWPFormDate = context.localUtil.CToT( AV35GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV16TFWWPFormDate_To = context.localUtil.CToT( AV35GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMVERSIONNUMBER") == 0 )
            {
               AV17TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV18TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMLATESTVERSIONNUMBER") == 0 )
            {
               AV19TFWWPFormLatestVersionNumber = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV20TFWWPFormLatestVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV45GXV1 = (int)(AV45GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADWWPFORMREFERENCENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFWWPFormReferenceName = AV21SearchTxt;
         AV12TFWWPFormReferenceName_Sel = "";
         AV47Wp_locationdynamicformds_1_filterfulltext = AV43FilterFullText;
         AV48Wp_locationdynamicformds_2_tfwwpformreferencename = AV11TFWWPFormReferenceName;
         AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel = AV12TFWWPFormReferenceName_Sel;
         AV50Wp_locationdynamicformds_4_tfwwpformtitle = AV13TFWWPFormTitle;
         AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel = AV14TFWWPFormTitle_Sel;
         AV52Wp_locationdynamicformds_6_tfwwpformdate = AV15TFWWPFormDate;
         AV53Wp_locationdynamicformds_7_tfwwpformdate_to = AV16TFWWPFormDate_To;
         AV54Wp_locationdynamicformds_8_tfwwpformversionnumber = AV17TFWWPFormVersionNumber;
         AV55Wp_locationdynamicformds_9_tfwwpformversionnumber_to = AV18TFWWPFormVersionNumber_To;
         AV56Wp_locationdynamicformds_10_tfwwpformlatestversionnumber = AV19TFWWPFormLatestVersionNumber;
         AV57Wp_locationdynamicformds_11_tfwwpformlatestversionnumber_to = AV20TFWWPFormLatestVersionNumber_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel ,
                                              AV48Wp_locationdynamicformds_2_tfwwpformreferencename ,
                                              AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel ,
                                              AV50Wp_locationdynamicformds_4_tfwwpformtitle ,
                                              AV52Wp_locationdynamicformds_6_tfwwpformdate ,
                                              AV53Wp_locationdynamicformds_7_tfwwpformdate_to ,
                                              AV54Wp_locationdynamicformds_8_tfwwpformversionnumber ,
                                              AV55Wp_locationdynamicformds_9_tfwwpformversionnumber_to ,
                                              A208WWPFormReferenceName ,
                                              A209WWPFormTitle ,
                                              A231WWPFormDate ,
                                              A207WWPFormVersionNumber ,
                                              AV47Wp_locationdynamicformds_1_filterfulltext ,
                                              A219WWPFormLatestVersionNumber ,
                                              AV56Wp_locationdynamicformds_10_tfwwpformlatestversionnumber ,
                                              AV57Wp_locationdynamicformds_11_tfwwpformlatestversionnumber_to ,
                                              A29LocationId ,
                                              AV44LocationId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV48Wp_locationdynamicformds_2_tfwwpformreferencename = StringUtil.Concat( StringUtil.RTrim( AV48Wp_locationdynamicformds_2_tfwwpformreferencename), "%", "");
         lV50Wp_locationdynamicformds_4_tfwwpformtitle = StringUtil.Concat( StringUtil.RTrim( AV50Wp_locationdynamicformds_4_tfwwpformtitle), "%", "");
         /* Using cursor P007Y2 */
         pr_default.execute(0, new Object[] {AV44LocationId, lV48Wp_locationdynamicformds_2_tfwwpformreferencename, AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel, lV50Wp_locationdynamicformds_4_tfwwpformtitle, AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel, AV52Wp_locationdynamicformds_6_tfwwpformdate, AV53Wp_locationdynamicformds_7_tfwwpformdate_to, AV54Wp_locationdynamicformds_8_tfwwpformversionnumber, AV55Wp_locationdynamicformds_9_tfwwpformversionnumber_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7Y2 = false;
            A207WWPFormVersionNumber = P007Y2_A207WWPFormVersionNumber[0];
            A29LocationId = P007Y2_A29LocationId[0];
            A231WWPFormDate = P007Y2_A231WWPFormDate[0];
            A209WWPFormTitle = P007Y2_A209WWPFormTitle[0];
            A208WWPFormReferenceName = P007Y2_A208WWPFormReferenceName[0];
            A206WWPFormId = P007Y2_A206WWPFormId[0];
            A395LocationDynamicFormId = P007Y2_A395LocationDynamicFormId[0];
            A11OrganisationId = P007Y2_A11OrganisationId[0];
            A231WWPFormDate = P007Y2_A231WWPFormDate[0];
            A209WWPFormTitle = P007Y2_A209WWPFormTitle[0];
            A208WWPFormReferenceName = P007Y2_A208WWPFormReferenceName[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Wp_locationdynamicformds_1_filterfulltext)) || ( ( StringUtil.Like( A208WWPFormReferenceName , StringUtil.PadR( "%" + AV47Wp_locationdynamicformds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A209WWPFormTitle , StringUtil.PadR( "%" + AV47Wp_locationdynamicformds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A207WWPFormVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV47Wp_locationdynamicformds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A219WWPFormLatestVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV47Wp_locationdynamicformds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
            {
               if ( (0==AV56Wp_locationdynamicformds_10_tfwwpformlatestversionnumber) || ( ( A219WWPFormLatestVersionNumber >= AV56Wp_locationdynamicformds_10_tfwwpformlatestversionnumber ) ) )
               {
                  if ( (0==AV57Wp_locationdynamicformds_11_tfwwpformlatestversionnumber_to) || ( ( A219WWPFormLatestVersionNumber <= AV57Wp_locationdynamicformds_11_tfwwpformlatestversionnumber_to ) ) )
                  {
                     AV31count = 0;
                     while ( (pr_default.getStatus(0) != 101) && ( P007Y2_A206WWPFormId[0] == A206WWPFormId ) && ( P007Y2_A207WWPFormVersionNumber[0] == A207WWPFormVersionNumber ) )
                     {
                        BRK7Y2 = false;
                        A29LocationId = P007Y2_A29LocationId[0];
                        A395LocationDynamicFormId = P007Y2_A395LocationDynamicFormId[0];
                        A11OrganisationId = P007Y2_A11OrganisationId[0];
                        AV31count = (long)(AV31count+1);
                        BRK7Y2 = true;
                        pr_default.readNext(0);
                     }
                     AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A208WWPFormReferenceName)) ? "<#Empty#>" : A208WWPFormReferenceName);
                     AV25InsertIndex = 1;
                     while ( ( StringUtil.StrCmp(AV26Option, "<#Empty#>") != 0 ) && ( AV25InsertIndex <= AV27Options.Count ) && ( ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), AV26Option) < 0 ) || ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), "<#Empty#>") == 0 ) ) )
                     {
                        AV25InsertIndex = (int)(AV25InsertIndex+1);
                     }
                     AV27Options.Add(AV26Option, AV25InsertIndex);
                     AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), AV25InsertIndex);
                     if ( AV27Options.Count == AV22SkipItems + 11 )
                     {
                        AV27Options.RemoveItem(AV27Options.Count);
                        AV30OptionIndexes.RemoveItem(AV30OptionIndexes.Count);
                     }
                  }
               }
            }
            if ( ! BRK7Y2 )
            {
               BRK7Y2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV22SkipItems > 0 )
         {
            AV27Options.RemoveItem(1);
            AV30OptionIndexes.RemoveItem(1);
            AV22SkipItems = (short)(AV22SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADWWPFORMTITLEOPTIONS' Routine */
         returnInSub = false;
         AV13TFWWPFormTitle = AV21SearchTxt;
         AV14TFWWPFormTitle_Sel = "";
         AV47Wp_locationdynamicformds_1_filterfulltext = AV43FilterFullText;
         AV48Wp_locationdynamicformds_2_tfwwpformreferencename = AV11TFWWPFormReferenceName;
         AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel = AV12TFWWPFormReferenceName_Sel;
         AV50Wp_locationdynamicformds_4_tfwwpformtitle = AV13TFWWPFormTitle;
         AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel = AV14TFWWPFormTitle_Sel;
         AV52Wp_locationdynamicformds_6_tfwwpformdate = AV15TFWWPFormDate;
         AV53Wp_locationdynamicformds_7_tfwwpformdate_to = AV16TFWWPFormDate_To;
         AV54Wp_locationdynamicformds_8_tfwwpformversionnumber = AV17TFWWPFormVersionNumber;
         AV55Wp_locationdynamicformds_9_tfwwpformversionnumber_to = AV18TFWWPFormVersionNumber_To;
         AV56Wp_locationdynamicformds_10_tfwwpformlatestversionnumber = AV19TFWWPFormLatestVersionNumber;
         AV57Wp_locationdynamicformds_11_tfwwpformlatestversionnumber_to = AV20TFWWPFormLatestVersionNumber_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel ,
                                              AV48Wp_locationdynamicformds_2_tfwwpformreferencename ,
                                              AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel ,
                                              AV50Wp_locationdynamicformds_4_tfwwpformtitle ,
                                              AV52Wp_locationdynamicformds_6_tfwwpformdate ,
                                              AV53Wp_locationdynamicformds_7_tfwwpformdate_to ,
                                              AV54Wp_locationdynamicformds_8_tfwwpformversionnumber ,
                                              AV55Wp_locationdynamicformds_9_tfwwpformversionnumber_to ,
                                              A208WWPFormReferenceName ,
                                              A209WWPFormTitle ,
                                              A231WWPFormDate ,
                                              A207WWPFormVersionNumber ,
                                              AV47Wp_locationdynamicformds_1_filterfulltext ,
                                              A219WWPFormLatestVersionNumber ,
                                              AV56Wp_locationdynamicformds_10_tfwwpformlatestversionnumber ,
                                              AV57Wp_locationdynamicformds_11_tfwwpformlatestversionnumber_to ,
                                              A29LocationId ,
                                              AV44LocationId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV48Wp_locationdynamicformds_2_tfwwpformreferencename = StringUtil.Concat( StringUtil.RTrim( AV48Wp_locationdynamicformds_2_tfwwpformreferencename), "%", "");
         lV50Wp_locationdynamicformds_4_tfwwpformtitle = StringUtil.Concat( StringUtil.RTrim( AV50Wp_locationdynamicformds_4_tfwwpformtitle), "%", "");
         /* Using cursor P007Y3 */
         pr_default.execute(1, new Object[] {AV44LocationId, lV48Wp_locationdynamicformds_2_tfwwpformreferencename, AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel, lV50Wp_locationdynamicformds_4_tfwwpformtitle, AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel, AV52Wp_locationdynamicformds_6_tfwwpformdate, AV53Wp_locationdynamicformds_7_tfwwpformdate_to, AV54Wp_locationdynamicformds_8_tfwwpformversionnumber, AV55Wp_locationdynamicformds_9_tfwwpformversionnumber_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7Y4 = false;
            A29LocationId = P007Y3_A29LocationId[0];
            A209WWPFormTitle = P007Y3_A209WWPFormTitle[0];
            A207WWPFormVersionNumber = P007Y3_A207WWPFormVersionNumber[0];
            A231WWPFormDate = P007Y3_A231WWPFormDate[0];
            A208WWPFormReferenceName = P007Y3_A208WWPFormReferenceName[0];
            A206WWPFormId = P007Y3_A206WWPFormId[0];
            A395LocationDynamicFormId = P007Y3_A395LocationDynamicFormId[0];
            A11OrganisationId = P007Y3_A11OrganisationId[0];
            A209WWPFormTitle = P007Y3_A209WWPFormTitle[0];
            A231WWPFormDate = P007Y3_A231WWPFormDate[0];
            A208WWPFormReferenceName = P007Y3_A208WWPFormReferenceName[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Wp_locationdynamicformds_1_filterfulltext)) || ( ( StringUtil.Like( A208WWPFormReferenceName , StringUtil.PadR( "%" + AV47Wp_locationdynamicformds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A209WWPFormTitle , StringUtil.PadR( "%" + AV47Wp_locationdynamicformds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A207WWPFormVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV47Wp_locationdynamicformds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A219WWPFormLatestVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV47Wp_locationdynamicformds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
            {
               if ( (0==AV56Wp_locationdynamicformds_10_tfwwpformlatestversionnumber) || ( ( A219WWPFormLatestVersionNumber >= AV56Wp_locationdynamicformds_10_tfwwpformlatestversionnumber ) ) )
               {
                  if ( (0==AV57Wp_locationdynamicformds_11_tfwwpformlatestversionnumber_to) || ( ( A219WWPFormLatestVersionNumber <= AV57Wp_locationdynamicformds_11_tfwwpformlatestversionnumber_to ) ) )
                  {
                     AV31count = 0;
                     while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007Y3_A209WWPFormTitle[0], A209WWPFormTitle) == 0 ) )
                     {
                        BRK7Y4 = false;
                        A29LocationId = P007Y3_A29LocationId[0];
                        A207WWPFormVersionNumber = P007Y3_A207WWPFormVersionNumber[0];
                        A206WWPFormId = P007Y3_A206WWPFormId[0];
                        A395LocationDynamicFormId = P007Y3_A395LocationDynamicFormId[0];
                        A11OrganisationId = P007Y3_A11OrganisationId[0];
                        AV31count = (long)(AV31count+1);
                        BRK7Y4 = true;
                        pr_default.readNext(1);
                     }
                     if ( (0==AV22SkipItems) )
                     {
                        AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A209WWPFormTitle)) ? "<#Empty#>" : A209WWPFormTitle);
                        AV27Options.Add(AV26Option, 0);
                        AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                        if ( AV27Options.Count == 10 )
                        {
                           /* Exit For each command. Update data (if necessary), close cursors & exit. */
                           if (true) break;
                        }
                     }
                     else
                     {
                        AV22SkipItems = (short)(AV22SkipItems-1);
                     }
                  }
               }
            }
            if ( ! BRK7Y4 )
            {
               BRK7Y4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV40OptionsJson = "";
         AV41OptionsDescJson = "";
         AV42OptionIndexesJson = "";
         AV27Options = new GxSimpleCollection<string>();
         AV29OptionsDesc = new GxSimpleCollection<string>();
         AV30OptionIndexes = new GxSimpleCollection<string>();
         AV21SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV32Session = context.GetSession();
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV43FilterFullText = "";
         AV11TFWWPFormReferenceName = "";
         AV12TFWWPFormReferenceName_Sel = "";
         AV13TFWWPFormTitle = "";
         AV14TFWWPFormTitle_Sel = "";
         AV15TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AV16TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         AV47Wp_locationdynamicformds_1_filterfulltext = "";
         AV48Wp_locationdynamicformds_2_tfwwpformreferencename = "";
         AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel = "";
         AV50Wp_locationdynamicformds_4_tfwwpformtitle = "";
         AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel = "";
         AV52Wp_locationdynamicformds_6_tfwwpformdate = (DateTime)(DateTime.MinValue);
         AV53Wp_locationdynamicformds_7_tfwwpformdate_to = (DateTime)(DateTime.MinValue);
         lV48Wp_locationdynamicformds_2_tfwwpformreferencename = "";
         lV50Wp_locationdynamicformds_4_tfwwpformtitle = "";
         A208WWPFormReferenceName = "";
         A209WWPFormTitle = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         A29LocationId = Guid.Empty;
         AV44LocationId = Guid.Empty;
         P007Y2_A207WWPFormVersionNumber = new short[1] ;
         P007Y2_A29LocationId = new Guid[] {Guid.Empty} ;
         P007Y2_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P007Y2_A209WWPFormTitle = new string[] {""} ;
         P007Y2_A208WWPFormReferenceName = new string[] {""} ;
         P007Y2_A206WWPFormId = new short[1] ;
         P007Y2_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         P007Y2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A395LocationDynamicFormId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV26Option = "";
         P007Y3_A29LocationId = new Guid[] {Guid.Empty} ;
         P007Y3_A209WWPFormTitle = new string[] {""} ;
         P007Y3_A207WWPFormVersionNumber = new short[1] ;
         P007Y3_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P007Y3_A208WWPFormReferenceName = new string[] {""} ;
         P007Y3_A206WWPFormId = new short[1] ;
         P007Y3_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         P007Y3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_locationdynamicformgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007Y2_A207WWPFormVersionNumber, P007Y2_A29LocationId, P007Y2_A231WWPFormDate, P007Y2_A209WWPFormTitle, P007Y2_A208WWPFormReferenceName, P007Y2_A206WWPFormId, P007Y2_A395LocationDynamicFormId, P007Y2_A11OrganisationId
               }
               , new Object[] {
               P007Y3_A29LocationId, P007Y3_A209WWPFormTitle, P007Y3_A207WWPFormVersionNumber, P007Y3_A231WWPFormDate, P007Y3_A208WWPFormReferenceName, P007Y3_A206WWPFormId, P007Y3_A395LocationDynamicFormId, P007Y3_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24MaxItems ;
      private short AV23PageIndex ;
      private short AV22SkipItems ;
      private short AV17TFWWPFormVersionNumber ;
      private short AV18TFWWPFormVersionNumber_To ;
      private short AV19TFWWPFormLatestVersionNumber ;
      private short AV20TFWWPFormLatestVersionNumber_To ;
      private short AV54Wp_locationdynamicformds_8_tfwwpformversionnumber ;
      private short AV55Wp_locationdynamicformds_9_tfwwpformversionnumber_to ;
      private short AV56Wp_locationdynamicformds_10_tfwwpformlatestversionnumber ;
      private short AV57Wp_locationdynamicformds_11_tfwwpformlatestversionnumber_to ;
      private short A207WWPFormVersionNumber ;
      private short A219WWPFormLatestVersionNumber ;
      private short A206WWPFormId ;
      private short GXt_int1 ;
      private int AV45GXV1 ;
      private int AV25InsertIndex ;
      private long AV31count ;
      private DateTime AV15TFWWPFormDate ;
      private DateTime AV16TFWWPFormDate_To ;
      private DateTime AV52Wp_locationdynamicformds_6_tfwwpformdate ;
      private DateTime AV53Wp_locationdynamicformds_7_tfwwpformdate_to ;
      private DateTime A231WWPFormDate ;
      private bool returnInSub ;
      private bool BRK7Y2 ;
      private bool BRK7Y4 ;
      private string AV40OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV42OptionIndexesJson ;
      private string AV37DDOName ;
      private string AV38SearchTxtParms ;
      private string AV39SearchTxtTo ;
      private string AV21SearchTxt ;
      private string AV43FilterFullText ;
      private string AV11TFWWPFormReferenceName ;
      private string AV12TFWWPFormReferenceName_Sel ;
      private string AV13TFWWPFormTitle ;
      private string AV14TFWWPFormTitle_Sel ;
      private string AV47Wp_locationdynamicformds_1_filterfulltext ;
      private string AV48Wp_locationdynamicformds_2_tfwwpformreferencename ;
      private string AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel ;
      private string AV50Wp_locationdynamicformds_4_tfwwpformtitle ;
      private string AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel ;
      private string lV48Wp_locationdynamicformds_2_tfwwpformreferencename ;
      private string lV50Wp_locationdynamicformds_4_tfwwpformtitle ;
      private string A208WWPFormReferenceName ;
      private string A209WWPFormTitle ;
      private string AV26Option ;
      private Guid A29LocationId ;
      private Guid AV44LocationId ;
      private Guid A395LocationDynamicFormId ;
      private Guid A11OrganisationId ;
      private IGxSession AV32Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV27Options ;
      private GxSimpleCollection<string> AV29OptionsDesc ;
      private GxSimpleCollection<string> AV30OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private short[] P007Y2_A207WWPFormVersionNumber ;
      private Guid[] P007Y2_A29LocationId ;
      private DateTime[] P007Y2_A231WWPFormDate ;
      private string[] P007Y2_A209WWPFormTitle ;
      private string[] P007Y2_A208WWPFormReferenceName ;
      private short[] P007Y2_A206WWPFormId ;
      private Guid[] P007Y2_A395LocationDynamicFormId ;
      private Guid[] P007Y2_A11OrganisationId ;
      private Guid[] P007Y3_A29LocationId ;
      private string[] P007Y3_A209WWPFormTitle ;
      private short[] P007Y3_A207WWPFormVersionNumber ;
      private DateTime[] P007Y3_A231WWPFormDate ;
      private string[] P007Y3_A208WWPFormReferenceName ;
      private short[] P007Y3_A206WWPFormId ;
      private Guid[] P007Y3_A395LocationDynamicFormId ;
      private Guid[] P007Y3_A11OrganisationId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wp_locationdynamicformgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007Y2( IGxContext context ,
                                             string AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel ,
                                             string AV48Wp_locationdynamicformds_2_tfwwpformreferencename ,
                                             string AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel ,
                                             string AV50Wp_locationdynamicformds_4_tfwwpformtitle ,
                                             DateTime AV52Wp_locationdynamicformds_6_tfwwpformdate ,
                                             DateTime AV53Wp_locationdynamicformds_7_tfwwpformdate_to ,
                                             short AV54Wp_locationdynamicformds_8_tfwwpformversionnumber ,
                                             short AV55Wp_locationdynamicformds_9_tfwwpformversionnumber_to ,
                                             string A208WWPFormReferenceName ,
                                             string A209WWPFormTitle ,
                                             DateTime A231WWPFormDate ,
                                             short A207WWPFormVersionNumber ,
                                             string AV47Wp_locationdynamicformds_1_filterfulltext ,
                                             short A219WWPFormLatestVersionNumber ,
                                             short AV56Wp_locationdynamicformds_10_tfwwpformlatestversionnumber ,
                                             short AV57Wp_locationdynamicformds_11_tfwwpformlatestversionnumber_to ,
                                             Guid A29LocationId ,
                                             Guid AV44LocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[9];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.WWPFormVersionNumber, T1.LocationId, T2.WWPFormDate, T2.WWPFormTitle, T2.WWPFormReferenceName, T1.WWPFormId, T1.LocationDynamicFormId, T1.OrganisationId FROM (Trn_LocationDynamicForm T1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T1.LocationId = :AV44LocationId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wp_locationdynamicformds_2_tfwwpformreferencename)) ) )
         {
            AddWhere(sWhereString, "(T2.WWPFormReferenceName like :lV48Wp_locationdynamicformds_2_tfwwpformreferencename)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel)) && ! ( StringUtil.StrCmp(AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.WWPFormReferenceName = ( :AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( StringUtil.StrCmp(AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.WWPFormReferenceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wp_locationdynamicformds_4_tfwwpformtitle)) ) )
         {
            AddWhere(sWhereString, "(T2.WWPFormTitle like :lV50Wp_locationdynamicformds_4_tfwwpformtitle)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel)) && ! ( StringUtil.StrCmp(AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.WWPFormTitle = ( :AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.WWPFormTitle))=0))");
         }
         if ( ! (DateTime.MinValue==AV52Wp_locationdynamicformds_6_tfwwpformdate) )
         {
            AddWhere(sWhereString, "(T2.WWPFormDate >= :AV52Wp_locationdynamicformds_6_tfwwpformdate)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV53Wp_locationdynamicformds_7_tfwwpformdate_to) )
         {
            AddWhere(sWhereString, "(T2.WWPFormDate <= :AV53Wp_locationdynamicformds_7_tfwwpformdate_to)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV54Wp_locationdynamicformds_8_tfwwpformversionnumber) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber >= :AV54Wp_locationdynamicformds_8_tfwwpformversionnumber)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (0==AV55Wp_locationdynamicformds_9_tfwwpformversionnumber_to) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber <= :AV55Wp_locationdynamicformds_9_tfwwpformversionnumber_to)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WWPFormId, T1.WWPFormVersionNumber";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P007Y3( IGxContext context ,
                                             string AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel ,
                                             string AV48Wp_locationdynamicformds_2_tfwwpformreferencename ,
                                             string AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel ,
                                             string AV50Wp_locationdynamicformds_4_tfwwpformtitle ,
                                             DateTime AV52Wp_locationdynamicformds_6_tfwwpformdate ,
                                             DateTime AV53Wp_locationdynamicformds_7_tfwwpformdate_to ,
                                             short AV54Wp_locationdynamicformds_8_tfwwpformversionnumber ,
                                             short AV55Wp_locationdynamicformds_9_tfwwpformversionnumber_to ,
                                             string A208WWPFormReferenceName ,
                                             string A209WWPFormTitle ,
                                             DateTime A231WWPFormDate ,
                                             short A207WWPFormVersionNumber ,
                                             string AV47Wp_locationdynamicformds_1_filterfulltext ,
                                             short A219WWPFormLatestVersionNumber ,
                                             short AV56Wp_locationdynamicformds_10_tfwwpformlatestversionnumber ,
                                             short AV57Wp_locationdynamicformds_11_tfwwpformlatestversionnumber_to ,
                                             Guid A29LocationId ,
                                             Guid AV44LocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[9];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.LocationId, T2.WWPFormTitle, T1.WWPFormVersionNumber, T2.WWPFormDate, T2.WWPFormReferenceName, T1.WWPFormId, T1.LocationDynamicFormId, T1.OrganisationId FROM (Trn_LocationDynamicForm T1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T1.LocationId = :AV44LocationId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wp_locationdynamicformds_2_tfwwpformreferencename)) ) )
         {
            AddWhere(sWhereString, "(T2.WWPFormReferenceName like :lV48Wp_locationdynamicformds_2_tfwwpformreferencename)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel)) && ! ( StringUtil.StrCmp(AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.WWPFormReferenceName = ( :AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( StringUtil.StrCmp(AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.WWPFormReferenceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wp_locationdynamicformds_4_tfwwpformtitle)) ) )
         {
            AddWhere(sWhereString, "(T2.WWPFormTitle like :lV50Wp_locationdynamicformds_4_tfwwpformtitle)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel)) && ! ( StringUtil.StrCmp(AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.WWPFormTitle = ( :AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.WWPFormTitle))=0))");
         }
         if ( ! (DateTime.MinValue==AV52Wp_locationdynamicformds_6_tfwwpformdate) )
         {
            AddWhere(sWhereString, "(T2.WWPFormDate >= :AV52Wp_locationdynamicformds_6_tfwwpformdate)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV53Wp_locationdynamicformds_7_tfwwpformdate_to) )
         {
            AddWhere(sWhereString, "(T2.WWPFormDate <= :AV53Wp_locationdynamicformds_7_tfwwpformdate_to)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV54Wp_locationdynamicformds_8_tfwwpformversionnumber) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber >= :AV54Wp_locationdynamicformds_8_tfwwpformversionnumber)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV55Wp_locationdynamicformds_9_tfwwpformversionnumber_to) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber <= :AV55Wp_locationdynamicformds_9_tfwwpformversionnumber_to)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.WWPFormTitle";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P007Y2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] );
               case 1 :
                     return conditional_P007Y3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007Y2;
          prmP007Y2 = new Object[] {
          new ParDef("AV44LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV48Wp_locationdynamicformds_2_tfwwpformreferencename",GXType.VarChar,100,0) ,
          new ParDef("AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV50Wp_locationdynamicformds_4_tfwwpformtitle",GXType.VarChar,100,0) ,
          new ParDef("AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel",GXType.VarChar,100,0) ,
          new ParDef("AV52Wp_locationdynamicformds_6_tfwwpformdate",GXType.DateTime,8,5) ,
          new ParDef("AV53Wp_locationdynamicformds_7_tfwwpformdate_to",GXType.DateTime,8,5) ,
          new ParDef("AV54Wp_locationdynamicformds_8_tfwwpformversionnumber",GXType.Int16,4,0) ,
          new ParDef("AV55Wp_locationdynamicformds_9_tfwwpformversionnumber_to",GXType.Int16,4,0)
          };
          Object[] prmP007Y3;
          prmP007Y3 = new Object[] {
          new ParDef("AV44LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV48Wp_locationdynamicformds_2_tfwwpformreferencename",GXType.VarChar,100,0) ,
          new ParDef("AV49Wp_locationdynamicformds_3_tfwwpformreferencename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV50Wp_locationdynamicformds_4_tfwwpformtitle",GXType.VarChar,100,0) ,
          new ParDef("AV51Wp_locationdynamicformds_5_tfwwpformtitle_sel",GXType.VarChar,100,0) ,
          new ParDef("AV52Wp_locationdynamicformds_6_tfwwpformdate",GXType.DateTime,8,5) ,
          new ParDef("AV53Wp_locationdynamicformds_7_tfwwpformdate_to",GXType.DateTime,8,5) ,
          new ParDef("AV54Wp_locationdynamicformds_8_tfwwpformversionnumber",GXType.Int16,4,0) ,
          new ParDef("AV55Wp_locationdynamicformds_9_tfwwpformversionnumber_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Y2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Y3,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                ((Guid[]) buf[7])[0] = rslt.getGuid(8);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                ((Guid[]) buf[7])[0] = rslt.getGuid(8);
                return;
       }
    }

 }

}
