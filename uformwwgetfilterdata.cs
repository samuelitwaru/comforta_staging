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
   public class uformwwgetfilterdata : GXProcedure
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
            return "uformww_Services_Execute" ;
         }

      }

      public uformwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public uformwwgetfilterdata( IGxContext context )
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
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV40OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV25Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22MaxItems = 10;
         AV21PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV36SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV19SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? "" : StringUtil.Substring( AV36SearchTxtParms, 3, -1));
         AV20SkipItems = (short)(AV21PageIndex*AV22MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_WWPFORMREFERENCENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPFORMREFERENCENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_WWPFORMTITLE") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPFORMTITLEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV38OptionsJson = AV25Options.ToJSonString(false);
         AV39OptionsDescJson = AV27OptionsDesc.ToJSonString(false);
         AV40OptionIndexesJson = AV28OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get("UFormWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "UFormWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("UFormWWGridState"), null, "", "");
         }
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV42GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME") == 0 )
            {
               AV11TFWWPFormReferenceName = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME_SEL") == 0 )
            {
               AV12TFWWPFormReferenceName_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE") == 0 )
            {
               AV13TFWWPFormTitle = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE_SEL") == 0 )
            {
               AV14TFWWPFormTitle_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFWWPFORMDATE") == 0 )
            {
               AV15TFWWPFormDate = context.localUtil.CToT( AV33GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV16TFWWPFormDate_To = context.localUtil.CToT( AV33GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFWWPFORMLATESTVERSIONNUMBER") == 0 )
            {
               AV17TFWWPFormLatestVersionNumber = (short)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV18TFWWPFormLatestVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADWWPFORMREFERENCENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFWWPFormReferenceName = AV19SearchTxt;
         AV12TFWWPFormReferenceName_Sel = "";
         AV44Uformwwds_1_filterfulltext = AV41FilterFullText;
         AV45Uformwwds_2_tfwwpformreferencename = AV11TFWWPFormReferenceName;
         AV46Uformwwds_3_tfwwpformreferencename_sel = AV12TFWWPFormReferenceName_Sel;
         AV47Uformwwds_4_tfwwpformtitle = AV13TFWWPFormTitle;
         AV48Uformwwds_5_tfwwpformtitle_sel = AV14TFWWPFormTitle_Sel;
         AV49Uformwwds_6_tfwwpformdate = AV15TFWWPFormDate;
         AV50Uformwwds_7_tfwwpformdate_to = AV16TFWWPFormDate_To;
         AV51Uformwwds_8_tfwwpformlatestversionnumber = AV17TFWWPFormLatestVersionNumber;
         AV52Uformwwds_9_tfwwpformlatestversionnumber_to = AV18TFWWPFormLatestVersionNumber_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV46Uformwwds_3_tfwwpformreferencename_sel ,
                                              AV45Uformwwds_2_tfwwpformreferencename ,
                                              AV48Uformwwds_5_tfwwpformtitle_sel ,
                                              AV47Uformwwds_4_tfwwpformtitle ,
                                              AV49Uformwwds_6_tfwwpformdate ,
                                              AV50Uformwwds_7_tfwwpformdate_to ,
                                              A208WWPFormReferenceName ,
                                              A209WWPFormTitle ,
                                              A231WWPFormDate ,
                                              AV44Uformwwds_1_filterfulltext ,
                                              A219WWPFormLatestVersionNumber ,
                                              AV51Uformwwds_8_tfwwpformlatestversionnumber ,
                                              AV52Uformwwds_9_tfwwpformlatestversionnumber_to } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV45Uformwwds_2_tfwwpformreferencename = StringUtil.Concat( StringUtil.RTrim( AV45Uformwwds_2_tfwwpformreferencename), "%", "");
         lV47Uformwwds_4_tfwwpformtitle = StringUtil.Concat( StringUtil.RTrim( AV47Uformwwds_4_tfwwpformtitle), "%", "");
         /* Using cursor P00AF2 */
         pr_default.execute(0, new Object[] {lV45Uformwwds_2_tfwwpformreferencename, AV46Uformwwds_3_tfwwpformreferencename_sel, lV47Uformwwds_4_tfwwpformtitle, AV48Uformwwds_5_tfwwpformtitle_sel, AV49Uformwwds_6_tfwwpformdate, AV50Uformwwds_7_tfwwpformdate_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAF2 = false;
            A208WWPFormReferenceName = P00AF2_A208WWPFormReferenceName[0];
            A231WWPFormDate = P00AF2_A231WWPFormDate[0];
            A209WWPFormTitle = P00AF2_A209WWPFormTitle[0];
            A206WWPFormId = P00AF2_A206WWPFormId[0];
            A207WWPFormVersionNumber = P00AF2_A207WWPFormVersionNumber[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Uformwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A208WWPFormReferenceName) , StringUtil.PadR( "%" + StringUtil.Lower( AV44Uformwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A209WWPFormTitle) , StringUtil.PadR( "%" + StringUtil.Lower( AV44Uformwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A219WWPFormLatestVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV44Uformwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
            {
               if ( (0==AV51Uformwwds_8_tfwwpformlatestversionnumber) || ( ( A219WWPFormLatestVersionNumber >= AV51Uformwwds_8_tfwwpformlatestversionnumber ) ) )
               {
                  if ( (0==AV52Uformwwds_9_tfwwpformlatestversionnumber_to) || ( ( A219WWPFormLatestVersionNumber <= AV52Uformwwds_9_tfwwpformlatestversionnumber_to ) ) )
                  {
                     AV29count = 0;
                     while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AF2_A208WWPFormReferenceName[0], A208WWPFormReferenceName) == 0 ) )
                     {
                        BRKAF2 = false;
                        A206WWPFormId = P00AF2_A206WWPFormId[0];
                        A207WWPFormVersionNumber = P00AF2_A207WWPFormVersionNumber[0];
                        AV29count = (long)(AV29count+1);
                        BRKAF2 = true;
                        pr_default.readNext(0);
                     }
                     if ( (0==AV20SkipItems) )
                     {
                        AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A208WWPFormReferenceName)) ? "<#Empty#>" : A208WWPFormReferenceName);
                        AV25Options.Add(AV24Option, 0);
                        AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                        if ( AV25Options.Count == 10 )
                        {
                           /* Exit For each command. Update data (if necessary), close cursors & exit. */
                           if (true) break;
                        }
                     }
                     else
                     {
                        AV20SkipItems = (short)(AV20SkipItems-1);
                     }
                  }
               }
            }
            if ( ! BRKAF2 )
            {
               BRKAF2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADWWPFORMTITLEOPTIONS' Routine */
         returnInSub = false;
         AV13TFWWPFormTitle = AV19SearchTxt;
         AV14TFWWPFormTitle_Sel = "";
         AV44Uformwwds_1_filterfulltext = AV41FilterFullText;
         AV45Uformwwds_2_tfwwpformreferencename = AV11TFWWPFormReferenceName;
         AV46Uformwwds_3_tfwwpformreferencename_sel = AV12TFWWPFormReferenceName_Sel;
         AV47Uformwwds_4_tfwwpformtitle = AV13TFWWPFormTitle;
         AV48Uformwwds_5_tfwwpformtitle_sel = AV14TFWWPFormTitle_Sel;
         AV49Uformwwds_6_tfwwpformdate = AV15TFWWPFormDate;
         AV50Uformwwds_7_tfwwpformdate_to = AV16TFWWPFormDate_To;
         AV51Uformwwds_8_tfwwpformlatestversionnumber = AV17TFWWPFormLatestVersionNumber;
         AV52Uformwwds_9_tfwwpformlatestversionnumber_to = AV18TFWWPFormLatestVersionNumber_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV46Uformwwds_3_tfwwpformreferencename_sel ,
                                              AV45Uformwwds_2_tfwwpformreferencename ,
                                              AV48Uformwwds_5_tfwwpformtitle_sel ,
                                              AV47Uformwwds_4_tfwwpformtitle ,
                                              AV49Uformwwds_6_tfwwpformdate ,
                                              AV50Uformwwds_7_tfwwpformdate_to ,
                                              A208WWPFormReferenceName ,
                                              A209WWPFormTitle ,
                                              A231WWPFormDate ,
                                              AV44Uformwwds_1_filterfulltext ,
                                              A219WWPFormLatestVersionNumber ,
                                              AV51Uformwwds_8_tfwwpformlatestversionnumber ,
                                              AV52Uformwwds_9_tfwwpformlatestversionnumber_to } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV45Uformwwds_2_tfwwpformreferencename = StringUtil.Concat( StringUtil.RTrim( AV45Uformwwds_2_tfwwpformreferencename), "%", "");
         lV47Uformwwds_4_tfwwpformtitle = StringUtil.Concat( StringUtil.RTrim( AV47Uformwwds_4_tfwwpformtitle), "%", "");
         /* Using cursor P00AF3 */
         pr_default.execute(1, new Object[] {lV45Uformwwds_2_tfwwpformreferencename, AV46Uformwwds_3_tfwwpformreferencename_sel, lV47Uformwwds_4_tfwwpformtitle, AV48Uformwwds_5_tfwwpformtitle_sel, AV49Uformwwds_6_tfwwpformdate, AV50Uformwwds_7_tfwwpformdate_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKAF4 = false;
            A209WWPFormTitle = P00AF3_A209WWPFormTitle[0];
            A231WWPFormDate = P00AF3_A231WWPFormDate[0];
            A208WWPFormReferenceName = P00AF3_A208WWPFormReferenceName[0];
            A206WWPFormId = P00AF3_A206WWPFormId[0];
            A207WWPFormVersionNumber = P00AF3_A207WWPFormVersionNumber[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Uformwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A208WWPFormReferenceName) , StringUtil.PadR( "%" + StringUtil.Lower( AV44Uformwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A209WWPFormTitle) , StringUtil.PadR( "%" + StringUtil.Lower( AV44Uformwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A219WWPFormLatestVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV44Uformwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
            {
               if ( (0==AV51Uformwwds_8_tfwwpformlatestversionnumber) || ( ( A219WWPFormLatestVersionNumber >= AV51Uformwwds_8_tfwwpformlatestversionnumber ) ) )
               {
                  if ( (0==AV52Uformwwds_9_tfwwpformlatestversionnumber_to) || ( ( A219WWPFormLatestVersionNumber <= AV52Uformwwds_9_tfwwpformlatestversionnumber_to ) ) )
                  {
                     AV29count = 0;
                     while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00AF3_A209WWPFormTitle[0], A209WWPFormTitle) == 0 ) )
                     {
                        BRKAF4 = false;
                        A206WWPFormId = P00AF3_A206WWPFormId[0];
                        A207WWPFormVersionNumber = P00AF3_A207WWPFormVersionNumber[0];
                        AV29count = (long)(AV29count+1);
                        BRKAF4 = true;
                        pr_default.readNext(1);
                     }
                     if ( (0==AV20SkipItems) )
                     {
                        AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A209WWPFormTitle)) ? "<#Empty#>" : A209WWPFormTitle);
                        AV25Options.Add(AV24Option, 0);
                        AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                        if ( AV25Options.Count == 10 )
                        {
                           /* Exit For each command. Update data (if necessary), close cursors & exit. */
                           if (true) break;
                        }
                     }
                     else
                     {
                        AV20SkipItems = (short)(AV20SkipItems-1);
                     }
                  }
               }
            }
            if ( ! BRKAF4 )
            {
               BRKAF4 = true;
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
         AV38OptionsJson = "";
         AV39OptionsDescJson = "";
         AV40OptionIndexesJson = "";
         AV25Options = new GxSimpleCollection<string>();
         AV27OptionsDesc = new GxSimpleCollection<string>();
         AV28OptionIndexes = new GxSimpleCollection<string>();
         AV19SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV30Session = context.GetSession();
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV41FilterFullText = "";
         AV11TFWWPFormReferenceName = "";
         AV12TFWWPFormReferenceName_Sel = "";
         AV13TFWWPFormTitle = "";
         AV14TFWWPFormTitle_Sel = "";
         AV15TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AV16TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         AV44Uformwwds_1_filterfulltext = "";
         AV45Uformwwds_2_tfwwpformreferencename = "";
         AV46Uformwwds_3_tfwwpformreferencename_sel = "";
         AV47Uformwwds_4_tfwwpformtitle = "";
         AV48Uformwwds_5_tfwwpformtitle_sel = "";
         AV49Uformwwds_6_tfwwpformdate = (DateTime)(DateTime.MinValue);
         AV50Uformwwds_7_tfwwpformdate_to = (DateTime)(DateTime.MinValue);
         lV45Uformwwds_2_tfwwpformreferencename = "";
         lV47Uformwwds_4_tfwwpformtitle = "";
         A208WWPFormReferenceName = "";
         A209WWPFormTitle = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         P00AF2_A208WWPFormReferenceName = new string[] {""} ;
         P00AF2_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P00AF2_A209WWPFormTitle = new string[] {""} ;
         P00AF2_A206WWPFormId = new short[1] ;
         P00AF2_A207WWPFormVersionNumber = new short[1] ;
         AV24Option = "";
         P00AF3_A209WWPFormTitle = new string[] {""} ;
         P00AF3_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P00AF3_A208WWPFormReferenceName = new string[] {""} ;
         P00AF3_A206WWPFormId = new short[1] ;
         P00AF3_A207WWPFormVersionNumber = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.uformwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00AF2_A208WWPFormReferenceName, P00AF2_A231WWPFormDate, P00AF2_A209WWPFormTitle, P00AF2_A206WWPFormId, P00AF2_A207WWPFormVersionNumber
               }
               , new Object[] {
               P00AF3_A209WWPFormTitle, P00AF3_A231WWPFormDate, P00AF3_A208WWPFormReferenceName, P00AF3_A206WWPFormId, P00AF3_A207WWPFormVersionNumber
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private short AV17TFWWPFormLatestVersionNumber ;
      private short AV18TFWWPFormLatestVersionNumber_To ;
      private short AV51Uformwwds_8_tfwwpformlatestversionnumber ;
      private short AV52Uformwwds_9_tfwwpformlatestversionnumber_to ;
      private short A219WWPFormLatestVersionNumber ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short GXt_int1 ;
      private int AV42GXV1 ;
      private long AV29count ;
      private DateTime AV15TFWWPFormDate ;
      private DateTime AV16TFWWPFormDate_To ;
      private DateTime AV49Uformwwds_6_tfwwpformdate ;
      private DateTime AV50Uformwwds_7_tfwwpformdate_to ;
      private DateTime A231WWPFormDate ;
      private bool returnInSub ;
      private bool BRKAF2 ;
      private bool BRKAF4 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV11TFWWPFormReferenceName ;
      private string AV12TFWWPFormReferenceName_Sel ;
      private string AV13TFWWPFormTitle ;
      private string AV14TFWWPFormTitle_Sel ;
      private string AV44Uformwwds_1_filterfulltext ;
      private string AV45Uformwwds_2_tfwwpformreferencename ;
      private string AV46Uformwwds_3_tfwwpformreferencename_sel ;
      private string AV47Uformwwds_4_tfwwpformtitle ;
      private string AV48Uformwwds_5_tfwwpformtitle_sel ;
      private string lV45Uformwwds_2_tfwwpformreferencename ;
      private string lV47Uformwwds_4_tfwwpformtitle ;
      private string A208WWPFormReferenceName ;
      private string A209WWPFormTitle ;
      private string AV24Option ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV27OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00AF2_A208WWPFormReferenceName ;
      private DateTime[] P00AF2_A231WWPFormDate ;
      private string[] P00AF2_A209WWPFormTitle ;
      private short[] P00AF2_A206WWPFormId ;
      private short[] P00AF2_A207WWPFormVersionNumber ;
      private string[] P00AF3_A209WWPFormTitle ;
      private DateTime[] P00AF3_A231WWPFormDate ;
      private string[] P00AF3_A208WWPFormReferenceName ;
      private short[] P00AF3_A206WWPFormId ;
      private short[] P00AF3_A207WWPFormVersionNumber ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class uformwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AF2( IGxContext context ,
                                             string AV46Uformwwds_3_tfwwpformreferencename_sel ,
                                             string AV45Uformwwds_2_tfwwpformreferencename ,
                                             string AV48Uformwwds_5_tfwwpformtitle_sel ,
                                             string AV47Uformwwds_4_tfwwpformtitle ,
                                             DateTime AV49Uformwwds_6_tfwwpformdate ,
                                             DateTime AV50Uformwwds_7_tfwwpformdate_to ,
                                             string A208WWPFormReferenceName ,
                                             string A209WWPFormTitle ,
                                             DateTime A231WWPFormDate ,
                                             string AV44Uformwwds_1_filterfulltext ,
                                             short A219WWPFormLatestVersionNumber ,
                                             short AV51Uformwwds_8_tfwwpformlatestversionnumber ,
                                             short AV52Uformwwds_9_tfwwpformlatestversionnumber_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT WWPFormReferenceName, WWPFormDate, WWPFormTitle, WWPFormId, WWPFormVersionNumber FROM WWP_Form";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Uformwwds_3_tfwwpformreferencename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Uformwwds_2_tfwwpformreferencename)) ) )
         {
            AddWhere(sWhereString, "(WWPFormReferenceName like :lV45Uformwwds_2_tfwwpformreferencename)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Uformwwds_3_tfwwpformreferencename_sel)) && ! ( StringUtil.StrCmp(AV46Uformwwds_3_tfwwpformreferencename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(WWPFormReferenceName = ( :AV46Uformwwds_3_tfwwpformreferencename_sel))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( StringUtil.StrCmp(AV46Uformwwds_3_tfwwpformreferencename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPFormReferenceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Uformwwds_5_tfwwpformtitle_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Uformwwds_4_tfwwpformtitle)) ) )
         {
            AddWhere(sWhereString, "(WWPFormTitle like :lV47Uformwwds_4_tfwwpformtitle)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Uformwwds_5_tfwwpformtitle_sel)) && ! ( StringUtil.StrCmp(AV48Uformwwds_5_tfwwpformtitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(WWPFormTitle = ( :AV48Uformwwds_5_tfwwpformtitle_sel))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( StringUtil.StrCmp(AV48Uformwwds_5_tfwwpformtitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPFormTitle))=0))");
         }
         if ( ! (DateTime.MinValue==AV49Uformwwds_6_tfwwpformdate) )
         {
            AddWhere(sWhereString, "(WWPFormDate >= :AV49Uformwwds_6_tfwwpformdate)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV50Uformwwds_7_tfwwpformdate_to) )
         {
            AddWhere(sWhereString, "(WWPFormDate <= :AV50Uformwwds_7_tfwwpformdate_to)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPFormReferenceName";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00AF3( IGxContext context ,
                                             string AV46Uformwwds_3_tfwwpformreferencename_sel ,
                                             string AV45Uformwwds_2_tfwwpformreferencename ,
                                             string AV48Uformwwds_5_tfwwpformtitle_sel ,
                                             string AV47Uformwwds_4_tfwwpformtitle ,
                                             DateTime AV49Uformwwds_6_tfwwpformdate ,
                                             DateTime AV50Uformwwds_7_tfwwpformdate_to ,
                                             string A208WWPFormReferenceName ,
                                             string A209WWPFormTitle ,
                                             DateTime A231WWPFormDate ,
                                             string AV44Uformwwds_1_filterfulltext ,
                                             short A219WWPFormLatestVersionNumber ,
                                             short AV51Uformwwds_8_tfwwpformlatestversionnumber ,
                                             short AV52Uformwwds_9_tfwwpformlatestversionnumber_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT WWPFormTitle, WWPFormDate, WWPFormReferenceName, WWPFormId, WWPFormVersionNumber FROM WWP_Form";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Uformwwds_3_tfwwpformreferencename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Uformwwds_2_tfwwpformreferencename)) ) )
         {
            AddWhere(sWhereString, "(WWPFormReferenceName like :lV45Uformwwds_2_tfwwpformreferencename)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Uformwwds_3_tfwwpformreferencename_sel)) && ! ( StringUtil.StrCmp(AV46Uformwwds_3_tfwwpformreferencename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(WWPFormReferenceName = ( :AV46Uformwwds_3_tfwwpformreferencename_sel))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( StringUtil.StrCmp(AV46Uformwwds_3_tfwwpformreferencename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPFormReferenceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Uformwwds_5_tfwwpformtitle_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Uformwwds_4_tfwwpformtitle)) ) )
         {
            AddWhere(sWhereString, "(WWPFormTitle like :lV47Uformwwds_4_tfwwpformtitle)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Uformwwds_5_tfwwpformtitle_sel)) && ! ( StringUtil.StrCmp(AV48Uformwwds_5_tfwwpformtitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(WWPFormTitle = ( :AV48Uformwwds_5_tfwwpformtitle_sel))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV48Uformwwds_5_tfwwpformtitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPFormTitle))=0))");
         }
         if ( ! (DateTime.MinValue==AV49Uformwwds_6_tfwwpformdate) )
         {
            AddWhere(sWhereString, "(WWPFormDate >= :AV49Uformwwds_6_tfwwpformdate)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV50Uformwwds_7_tfwwpformdate_to) )
         {
            AddWhere(sWhereString, "(WWPFormDate <= :AV50Uformwwds_7_tfwwpformdate_to)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPFormTitle";
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
                     return conditional_P00AF2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
               case 1 :
                     return conditional_P00AF3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
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
          Object[] prmP00AF2;
          prmP00AF2 = new Object[] {
          new ParDef("lV45Uformwwds_2_tfwwpformreferencename",GXType.VarChar,100,0) ,
          new ParDef("AV46Uformwwds_3_tfwwpformreferencename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV47Uformwwds_4_tfwwpformtitle",GXType.VarChar,100,0) ,
          new ParDef("AV48Uformwwds_5_tfwwpformtitle_sel",GXType.VarChar,100,0) ,
          new ParDef("AV49Uformwwds_6_tfwwpformdate",GXType.DateTime,8,5) ,
          new ParDef("AV50Uformwwds_7_tfwwpformdate_to",GXType.DateTime,8,5)
          };
          Object[] prmP00AF3;
          prmP00AF3 = new Object[] {
          new ParDef("lV45Uformwwds_2_tfwwpformreferencename",GXType.VarChar,100,0) ,
          new ParDef("AV46Uformwwds_3_tfwwpformreferencename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV47Uformwwds_4_tfwwpformtitle",GXType.VarChar,100,0) ,
          new ParDef("AV48Uformwwds_5_tfwwpformtitle_sel",GXType.VarChar,100,0) ,
          new ParDef("AV49Uformwwds_6_tfwwpformdate",GXType.DateTime,8,5) ,
          new ParDef("AV50Uformwwds_7_tfwwpformdate_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00AF2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AF2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AF3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AF3,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
