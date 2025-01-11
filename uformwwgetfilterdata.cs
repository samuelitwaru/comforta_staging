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
         this.AV52DDOName = aP0_DDOName;
         this.AV53SearchTxtParms = aP1_SearchTxtParms;
         this.AV54SearchTxtTo = aP2_SearchTxtTo;
         this.AV55OptionsJson = "" ;
         this.AV56OptionsDescJson = "" ;
         this.AV57OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV55OptionsJson;
         aP4_OptionsDescJson=this.AV56OptionsDescJson;
         aP5_OptionIndexesJson=this.AV57OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV57OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV52DDOName = aP0_DDOName;
         this.AV53SearchTxtParms = aP1_SearchTxtParms;
         this.AV54SearchTxtTo = aP2_SearchTxtTo;
         this.AV55OptionsJson = "" ;
         this.AV56OptionsDescJson = "" ;
         this.AV57OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV55OptionsJson;
         aP4_OptionsDescJson=this.AV56OptionsDescJson;
         aP5_OptionIndexesJson=this.AV57OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV42Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV44OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV45OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV39MaxItems = 10;
         AV38PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV53SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV53SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV36SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV53SearchTxtParms)) ? "" : StringUtil.Substring( AV53SearchTxtParms, 3, -1));
         AV37SkipItems = (short)(AV38PageIndex*AV39MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV52DDOName), "DDO_WWPFORMREFERENCENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPFORMREFERENCENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV52DDOName), "DDO_WWPFORMTITLE") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPFORMTITLEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV55OptionsJson = AV42Options.ToJSonString(false);
         AV56OptionsDescJson = AV44OptionsDesc.ToJSonString(false);
         AV57OptionIndexesJson = AV45OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV47Session.Get("UFormWWGridState"), "") == 0 )
         {
            AV49GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "UFormWWGridState"), null, "", "");
         }
         else
         {
            AV49GridState.FromXml(AV47Session.Get("UFormWWGridState"), null, "", "");
         }
         AV61GXV1 = 1;
         while ( AV61GXV1 <= AV49GridState.gxTpr_Filtervalues.Count )
         {
            AV50GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV49GridState.gxTpr_Filtervalues.Item(AV61GXV1));
            if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV58FilterFullText = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME") == 0 )
            {
               AV15TFWWPFormReferenceName = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME_SEL") == 0 )
            {
               AV16TFWWPFormReferenceName_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE") == 0 )
            {
               AV17TFWWPFormTitle = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE_SEL") == 0 )
            {
               AV18TFWWPFormTitle_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFWWPFORMDATE") == 0 )
            {
               AV19TFWWPFormDate = context.localUtil.CToT( AV50GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV20TFWWPFormDate_To = context.localUtil.CToT( AV50GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMTYPE") == 0 )
            {
               AV59WWPFormType = (short)(Math.Round(NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMISFORDYNAMICVALIDATIONS") == 0 )
            {
               AV60WWPFormIsForDynamicValidations = BooleanUtil.Val( AV50GridStateFilterValue.gxTpr_Value);
            }
            AV61GXV1 = (int)(AV61GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADWWPFORMREFERENCENAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFWWPFormReferenceName = AV36SearchTxt;
         AV16TFWWPFormReferenceName_Sel = "";
         AV63Uformwwds_1_wwpformtype = AV59WWPFormType;
         AV64Uformwwds_2_filterfulltext = AV58FilterFullText;
         AV65Uformwwds_3_tfwwpformreferencename = AV15TFWWPFormReferenceName;
         AV66Uformwwds_4_tfwwpformreferencename_sel = AV16TFWWPFormReferenceName_Sel;
         AV67Uformwwds_5_tfwwpformtitle = AV17TFWWPFormTitle;
         AV68Uformwwds_6_tfwwpformtitle_sel = AV18TFWWPFormTitle_Sel;
         AV69Uformwwds_7_tfwwpformdate = AV19TFWWPFormDate;
         AV70Uformwwds_8_tfwwpformdate_to = AV20TFWWPFormDate_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV64Uformwwds_2_filterfulltext ,
                                              AV66Uformwwds_4_tfwwpformreferencename_sel ,
                                              AV65Uformwwds_3_tfwwpformreferencename ,
                                              AV68Uformwwds_6_tfwwpformtitle_sel ,
                                              AV67Uformwwds_5_tfwwpformtitle ,
                                              AV69Uformwwds_7_tfwwpformdate ,
                                              AV70Uformwwds_8_tfwwpformdate_to ,
                                              A208WWPFormReferenceName ,
                                              A209WWPFormTitle ,
                                              A231WWPFormDate ,
                                              AV63Uformwwds_1_wwpformtype ,
                                              A240WWPFormType } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV64Uformwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Uformwwds_2_filterfulltext), "%", "");
         lV64Uformwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Uformwwds_2_filterfulltext), "%", "");
         lV65Uformwwds_3_tfwwpformreferencename = StringUtil.Concat( StringUtil.RTrim( AV65Uformwwds_3_tfwwpformreferencename), "%", "");
         lV67Uformwwds_5_tfwwpformtitle = StringUtil.Concat( StringUtil.RTrim( AV67Uformwwds_5_tfwwpformtitle), "%", "");
         /* Using cursor P00AK2 */
         pr_default.execute(0, new Object[] {AV63Uformwwds_1_wwpformtype, lV64Uformwwds_2_filterfulltext, lV64Uformwwds_2_filterfulltext, lV65Uformwwds_3_tfwwpformreferencename, AV66Uformwwds_4_tfwwpformreferencename_sel, lV67Uformwwds_5_tfwwpformtitle, AV68Uformwwds_6_tfwwpformtitle_sel, AV69Uformwwds_7_tfwwpformdate, AV70Uformwwds_8_tfwwpformdate_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAK2 = false;
            A240WWPFormType = P00AK2_A240WWPFormType[0];
            A208WWPFormReferenceName = P00AK2_A208WWPFormReferenceName[0];
            A231WWPFormDate = P00AK2_A231WWPFormDate[0];
            A209WWPFormTitle = P00AK2_A209WWPFormTitle[0];
            A206WWPFormId = P00AK2_A206WWPFormId[0];
            A207WWPFormVersionNumber = P00AK2_A207WWPFormVersionNumber[0];
            AV46count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00AK2_A240WWPFormType[0] == A240WWPFormType ) && ( StringUtil.StrCmp(P00AK2_A208WWPFormReferenceName[0], A208WWPFormReferenceName) == 0 ) )
            {
               BRKAK2 = false;
               A206WWPFormId = P00AK2_A206WWPFormId[0];
               A207WWPFormVersionNumber = P00AK2_A207WWPFormVersionNumber[0];
               AV46count = (long)(AV46count+1);
               BRKAK2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV37SkipItems) )
            {
               AV41Option = (String.IsNullOrEmpty(StringUtil.RTrim( A208WWPFormReferenceName)) ? "<#Empty#>" : A208WWPFormReferenceName);
               AV42Options.Add(AV41Option, 0);
               AV45OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV46count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV42Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV37SkipItems = (short)(AV37SkipItems-1);
            }
            if ( ! BRKAK2 )
            {
               BRKAK2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADWWPFORMTITLEOPTIONS' Routine */
         returnInSub = false;
         AV17TFWWPFormTitle = AV36SearchTxt;
         AV18TFWWPFormTitle_Sel = "";
         AV63Uformwwds_1_wwpformtype = AV59WWPFormType;
         AV64Uformwwds_2_filterfulltext = AV58FilterFullText;
         AV65Uformwwds_3_tfwwpformreferencename = AV15TFWWPFormReferenceName;
         AV66Uformwwds_4_tfwwpformreferencename_sel = AV16TFWWPFormReferenceName_Sel;
         AV67Uformwwds_5_tfwwpformtitle = AV17TFWWPFormTitle;
         AV68Uformwwds_6_tfwwpformtitle_sel = AV18TFWWPFormTitle_Sel;
         AV69Uformwwds_7_tfwwpformdate = AV19TFWWPFormDate;
         AV70Uformwwds_8_tfwwpformdate_to = AV20TFWWPFormDate_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV64Uformwwds_2_filterfulltext ,
                                              AV66Uformwwds_4_tfwwpformreferencename_sel ,
                                              AV65Uformwwds_3_tfwwpformreferencename ,
                                              AV68Uformwwds_6_tfwwpformtitle_sel ,
                                              AV67Uformwwds_5_tfwwpformtitle ,
                                              AV69Uformwwds_7_tfwwpformdate ,
                                              AV70Uformwwds_8_tfwwpformdate_to ,
                                              A208WWPFormReferenceName ,
                                              A209WWPFormTitle ,
                                              A231WWPFormDate ,
                                              AV63Uformwwds_1_wwpformtype ,
                                              A240WWPFormType } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV64Uformwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Uformwwds_2_filterfulltext), "%", "");
         lV64Uformwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Uformwwds_2_filterfulltext), "%", "");
         lV65Uformwwds_3_tfwwpformreferencename = StringUtil.Concat( StringUtil.RTrim( AV65Uformwwds_3_tfwwpformreferencename), "%", "");
         lV67Uformwwds_5_tfwwpformtitle = StringUtil.Concat( StringUtil.RTrim( AV67Uformwwds_5_tfwwpformtitle), "%", "");
         /* Using cursor P00AK3 */
         pr_default.execute(1, new Object[] {AV63Uformwwds_1_wwpformtype, lV64Uformwwds_2_filterfulltext, lV64Uformwwds_2_filterfulltext, lV65Uformwwds_3_tfwwpformreferencename, AV66Uformwwds_4_tfwwpformreferencename_sel, lV67Uformwwds_5_tfwwpformtitle, AV68Uformwwds_6_tfwwpformtitle_sel, AV69Uformwwds_7_tfwwpformdate, AV70Uformwwds_8_tfwwpformdate_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKAK4 = false;
            A240WWPFormType = P00AK3_A240WWPFormType[0];
            A209WWPFormTitle = P00AK3_A209WWPFormTitle[0];
            A231WWPFormDate = P00AK3_A231WWPFormDate[0];
            A208WWPFormReferenceName = P00AK3_A208WWPFormReferenceName[0];
            A206WWPFormId = P00AK3_A206WWPFormId[0];
            A207WWPFormVersionNumber = P00AK3_A207WWPFormVersionNumber[0];
            AV46count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00AK3_A240WWPFormType[0] == A240WWPFormType ) && ( StringUtil.StrCmp(P00AK3_A209WWPFormTitle[0], A209WWPFormTitle) == 0 ) )
            {
               BRKAK4 = false;
               A206WWPFormId = P00AK3_A206WWPFormId[0];
               A207WWPFormVersionNumber = P00AK3_A207WWPFormVersionNumber[0];
               AV46count = (long)(AV46count+1);
               BRKAK4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV37SkipItems) )
            {
               AV41Option = (String.IsNullOrEmpty(StringUtil.RTrim( A209WWPFormTitle)) ? "<#Empty#>" : A209WWPFormTitle);
               AV42Options.Add(AV41Option, 0);
               AV45OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV46count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV42Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV37SkipItems = (short)(AV37SkipItems-1);
            }
            if ( ! BRKAK4 )
            {
               BRKAK4 = true;
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
         AV55OptionsJson = "";
         AV56OptionsDescJson = "";
         AV57OptionIndexesJson = "";
         AV42Options = new GxSimpleCollection<string>();
         AV44OptionsDesc = new GxSimpleCollection<string>();
         AV45OptionIndexes = new GxSimpleCollection<string>();
         AV36SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV47Session = context.GetSession();
         AV49GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV50GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV58FilterFullText = "";
         AV15TFWWPFormReferenceName = "";
         AV16TFWWPFormReferenceName_Sel = "";
         AV17TFWWPFormTitle = "";
         AV18TFWWPFormTitle_Sel = "";
         AV19TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AV20TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         AV64Uformwwds_2_filterfulltext = "";
         AV65Uformwwds_3_tfwwpformreferencename = "";
         AV66Uformwwds_4_tfwwpformreferencename_sel = "";
         AV67Uformwwds_5_tfwwpformtitle = "";
         AV68Uformwwds_6_tfwwpformtitle_sel = "";
         AV69Uformwwds_7_tfwwpformdate = (DateTime)(DateTime.MinValue);
         AV70Uformwwds_8_tfwwpformdate_to = (DateTime)(DateTime.MinValue);
         lV64Uformwwds_2_filterfulltext = "";
         lV65Uformwwds_3_tfwwpformreferencename = "";
         lV67Uformwwds_5_tfwwpformtitle = "";
         A208WWPFormReferenceName = "";
         A209WWPFormTitle = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         P00AK2_A240WWPFormType = new short[1] ;
         P00AK2_A208WWPFormReferenceName = new string[] {""} ;
         P00AK2_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P00AK2_A209WWPFormTitle = new string[] {""} ;
         P00AK2_A206WWPFormId = new short[1] ;
         P00AK2_A207WWPFormVersionNumber = new short[1] ;
         AV41Option = "";
         P00AK3_A240WWPFormType = new short[1] ;
         P00AK3_A209WWPFormTitle = new string[] {""} ;
         P00AK3_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P00AK3_A208WWPFormReferenceName = new string[] {""} ;
         P00AK3_A206WWPFormId = new short[1] ;
         P00AK3_A207WWPFormVersionNumber = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.uformwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00AK2_A240WWPFormType, P00AK2_A208WWPFormReferenceName, P00AK2_A231WWPFormDate, P00AK2_A209WWPFormTitle, P00AK2_A206WWPFormId, P00AK2_A207WWPFormVersionNumber
               }
               , new Object[] {
               P00AK3_A240WWPFormType, P00AK3_A209WWPFormTitle, P00AK3_A231WWPFormDate, P00AK3_A208WWPFormReferenceName, P00AK3_A206WWPFormId, P00AK3_A207WWPFormVersionNumber
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV39MaxItems ;
      private short AV38PageIndex ;
      private short AV37SkipItems ;
      private short AV59WWPFormType ;
      private short AV63Uformwwds_1_wwpformtype ;
      private short A240WWPFormType ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private int AV61GXV1 ;
      private long AV46count ;
      private DateTime AV19TFWWPFormDate ;
      private DateTime AV20TFWWPFormDate_To ;
      private DateTime AV69Uformwwds_7_tfwwpformdate ;
      private DateTime AV70Uformwwds_8_tfwwpformdate_to ;
      private DateTime A231WWPFormDate ;
      private bool returnInSub ;
      private bool AV60WWPFormIsForDynamicValidations ;
      private bool BRKAK2 ;
      private bool BRKAK4 ;
      private string AV55OptionsJson ;
      private string AV56OptionsDescJson ;
      private string AV57OptionIndexesJson ;
      private string AV52DDOName ;
      private string AV53SearchTxtParms ;
      private string AV54SearchTxtTo ;
      private string AV36SearchTxt ;
      private string AV58FilterFullText ;
      private string AV15TFWWPFormReferenceName ;
      private string AV16TFWWPFormReferenceName_Sel ;
      private string AV17TFWWPFormTitle ;
      private string AV18TFWWPFormTitle_Sel ;
      private string AV64Uformwwds_2_filterfulltext ;
      private string AV65Uformwwds_3_tfwwpformreferencename ;
      private string AV66Uformwwds_4_tfwwpformreferencename_sel ;
      private string AV67Uformwwds_5_tfwwpformtitle ;
      private string AV68Uformwwds_6_tfwwpformtitle_sel ;
      private string lV64Uformwwds_2_filterfulltext ;
      private string lV65Uformwwds_3_tfwwpformreferencename ;
      private string lV67Uformwwds_5_tfwwpformtitle ;
      private string A208WWPFormReferenceName ;
      private string A209WWPFormTitle ;
      private string AV41Option ;
      private IGxSession AV47Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV42Options ;
      private GxSimpleCollection<string> AV44OptionsDesc ;
      private GxSimpleCollection<string> AV45OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV49GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV50GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private short[] P00AK2_A240WWPFormType ;
      private string[] P00AK2_A208WWPFormReferenceName ;
      private DateTime[] P00AK2_A231WWPFormDate ;
      private string[] P00AK2_A209WWPFormTitle ;
      private short[] P00AK2_A206WWPFormId ;
      private short[] P00AK2_A207WWPFormVersionNumber ;
      private short[] P00AK3_A240WWPFormType ;
      private string[] P00AK3_A209WWPFormTitle ;
      private DateTime[] P00AK3_A231WWPFormDate ;
      private string[] P00AK3_A208WWPFormReferenceName ;
      private short[] P00AK3_A206WWPFormId ;
      private short[] P00AK3_A207WWPFormVersionNumber ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class uformwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AK2( IGxContext context ,
                                             string AV64Uformwwds_2_filterfulltext ,
                                             string AV66Uformwwds_4_tfwwpformreferencename_sel ,
                                             string AV65Uformwwds_3_tfwwpformreferencename ,
                                             string AV68Uformwwds_6_tfwwpformtitle_sel ,
                                             string AV67Uformwwds_5_tfwwpformtitle ,
                                             DateTime AV69Uformwwds_7_tfwwpformdate ,
                                             DateTime AV70Uformwwds_8_tfwwpformdate_to ,
                                             string A208WWPFormReferenceName ,
                                             string A209WWPFormTitle ,
                                             DateTime A231WWPFormDate ,
                                             short AV63Uformwwds_1_wwpformtype ,
                                             short A240WWPFormType )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT WWPFormType, WWPFormReferenceName, WWPFormDate, WWPFormTitle, WWPFormId, WWPFormVersionNumber FROM WWP_Form";
         AddWhere(sWhereString, "(WWPFormType = :AV63Uformwwds_1_wwpformtype)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Uformwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(WWPFormReferenceName) like '%' || LOWER(:lV64Uformwwds_2_filterfulltext)) or ( LOWER(WWPFormTitle) like '%' || LOWER(:lV64Uformwwds_2_filterfulltext)))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Uformwwds_4_tfwwpformreferencename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Uformwwds_3_tfwwpformreferencename)) ) )
         {
            AddWhere(sWhereString, "(WWPFormReferenceName like :lV65Uformwwds_3_tfwwpformreferencename)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Uformwwds_4_tfwwpformreferencename_sel)) && ! ( StringUtil.StrCmp(AV66Uformwwds_4_tfwwpformreferencename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(WWPFormReferenceName = ( :AV66Uformwwds_4_tfwwpformreferencename_sel))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV66Uformwwds_4_tfwwpformreferencename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPFormReferenceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Uformwwds_6_tfwwpformtitle_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Uformwwds_5_tfwwpformtitle)) ) )
         {
            AddWhere(sWhereString, "(WWPFormTitle like :lV67Uformwwds_5_tfwwpformtitle)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Uformwwds_6_tfwwpformtitle_sel)) && ! ( StringUtil.StrCmp(AV68Uformwwds_6_tfwwpformtitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(WWPFormTitle = ( :AV68Uformwwds_6_tfwwpformtitle_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV68Uformwwds_6_tfwwpformtitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPFormTitle))=0))");
         }
         if ( ! (DateTime.MinValue==AV69Uformwwds_7_tfwwpformdate) )
         {
            AddWhere(sWhereString, "(WWPFormDate >= :AV69Uformwwds_7_tfwwpformdate)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Uformwwds_8_tfwwpformdate_to) )
         {
            AddWhere(sWhereString, "(WWPFormDate <= :AV70Uformwwds_8_tfwwpformdate_to)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPFormType, WWPFormReferenceName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00AK3( IGxContext context ,
                                             string AV64Uformwwds_2_filterfulltext ,
                                             string AV66Uformwwds_4_tfwwpformreferencename_sel ,
                                             string AV65Uformwwds_3_tfwwpformreferencename ,
                                             string AV68Uformwwds_6_tfwwpformtitle_sel ,
                                             string AV67Uformwwds_5_tfwwpformtitle ,
                                             DateTime AV69Uformwwds_7_tfwwpformdate ,
                                             DateTime AV70Uformwwds_8_tfwwpformdate_to ,
                                             string A208WWPFormReferenceName ,
                                             string A209WWPFormTitle ,
                                             DateTime A231WWPFormDate ,
                                             short AV63Uformwwds_1_wwpformtype ,
                                             short A240WWPFormType )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[9];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT WWPFormType, WWPFormTitle, WWPFormDate, WWPFormReferenceName, WWPFormId, WWPFormVersionNumber FROM WWP_Form";
         AddWhere(sWhereString, "(WWPFormType = :AV63Uformwwds_1_wwpformtype)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Uformwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(WWPFormReferenceName) like '%' || LOWER(:lV64Uformwwds_2_filterfulltext)) or ( LOWER(WWPFormTitle) like '%' || LOWER(:lV64Uformwwds_2_filterfulltext)))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Uformwwds_4_tfwwpformreferencename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Uformwwds_3_tfwwpformreferencename)) ) )
         {
            AddWhere(sWhereString, "(WWPFormReferenceName like :lV65Uformwwds_3_tfwwpformreferencename)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Uformwwds_4_tfwwpformreferencename_sel)) && ! ( StringUtil.StrCmp(AV66Uformwwds_4_tfwwpformreferencename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(WWPFormReferenceName = ( :AV66Uformwwds_4_tfwwpformreferencename_sel))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV66Uformwwds_4_tfwwpformreferencename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPFormReferenceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Uformwwds_6_tfwwpformtitle_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Uformwwds_5_tfwwpformtitle)) ) )
         {
            AddWhere(sWhereString, "(WWPFormTitle like :lV67Uformwwds_5_tfwwpformtitle)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Uformwwds_6_tfwwpformtitle_sel)) && ! ( StringUtil.StrCmp(AV68Uformwwds_6_tfwwpformtitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(WWPFormTitle = ( :AV68Uformwwds_6_tfwwpformtitle_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV68Uformwwds_6_tfwwpformtitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPFormTitle))=0))");
         }
         if ( ! (DateTime.MinValue==AV69Uformwwds_7_tfwwpformdate) )
         {
            AddWhere(sWhereString, "(WWPFormDate >= :AV69Uformwwds_7_tfwwpformdate)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Uformwwds_8_tfwwpformdate_to) )
         {
            AddWhere(sWhereString, "(WWPFormDate <= :AV70Uformwwds_8_tfwwpformdate_to)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPFormType, WWPFormTitle";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00AK2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
               case 1 :
                     return conditional_P00AK3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
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
          Object[] prmP00AK2;
          prmP00AK2 = new Object[] {
          new ParDef("AV63Uformwwds_1_wwpformtype",GXType.Int16,1,0) ,
          new ParDef("lV64Uformwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Uformwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Uformwwds_3_tfwwpformreferencename",GXType.VarChar,100,0) ,
          new ParDef("AV66Uformwwds_4_tfwwpformreferencename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV67Uformwwds_5_tfwwpformtitle",GXType.VarChar,100,0) ,
          new ParDef("AV68Uformwwds_6_tfwwpformtitle_sel",GXType.VarChar,100,0) ,
          new ParDef("AV69Uformwwds_7_tfwwpformdate",GXType.DateTime,8,5) ,
          new ParDef("AV70Uformwwds_8_tfwwpformdate_to",GXType.DateTime,8,5)
          };
          Object[] prmP00AK3;
          prmP00AK3 = new Object[] {
          new ParDef("AV63Uformwwds_1_wwpformtype",GXType.Int16,1,0) ,
          new ParDef("lV64Uformwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Uformwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Uformwwds_3_tfwwpformreferencename",GXType.VarChar,100,0) ,
          new ParDef("AV66Uformwwds_4_tfwwpformreferencename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV67Uformwwds_5_tfwwpformtitle",GXType.VarChar,100,0) ,
          new ParDef("AV68Uformwwds_6_tfwwpformtitle_sel",GXType.VarChar,100,0) ,
          new ParDef("AV69Uformwwds_7_tfwwpformdate",GXType.DateTime,8,5) ,
          new ParDef("AV70Uformwwds_8_tfwwpformdate_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00AK2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AK2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AK3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AK3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
