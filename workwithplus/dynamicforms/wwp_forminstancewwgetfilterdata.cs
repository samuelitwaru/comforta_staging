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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_forminstancewwgetfilterdata : GXProcedure
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
            return "wwp_forminstanceww_Services_Execute" ;
         }

      }

      public wwp_forminstancewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_forminstancewwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_WWPUSEREXTENDEDFULLNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPUSEREXTENDEDFULLNAMEOPTIONS' */
            S121 ();
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
         if ( StringUtil.StrCmp(AV30Session.Get("WorkWithPlus.DynamicForms.WWP_FormInstanceWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WorkWithPlus.DynamicForms.WWP_FormInstanceWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("WorkWithPlus.DynamicForms.WWP_FormInstanceWWGridState"), null, "", "");
         }
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV44GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFWWPFORMINSTANCEID") == 0 )
            {
               AV11TFWWPFormInstanceId = (int)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFWWPFormInstanceId_To = (int)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFWWPFORMINSTANCEDATE") == 0 )
            {
               AV13TFWWPFormInstanceDate = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV14TFWWPFormInstanceDate_To = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFWWPFORMVERSIONNUMBER") == 0 )
            {
               AV15TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV16TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFWWPUSEREXTENDEDFULLNAME") == 0 )
            {
               AV17TFWWPUserExtendedFullName = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFWWPUSEREXTENDEDFULLNAME_SEL") == 0 )
            {
               AV18TFWWPUserExtendedFullName_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMID") == 0 )
            {
               AV42WWPFormId = (short)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMTITLE") == 0 )
            {
               AV43WWPFormTitle = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV44GXV1 = (int)(AV44GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADWWPUSEREXTENDEDFULLNAMEOPTIONS' Routine */
         returnInSub = false;
         AV17TFWWPUserExtendedFullName = AV19SearchTxt;
         AV18TFWWPUserExtendedFullName_Sel = "";
         AV46Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid = AV42WWPFormId;
         AV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = AV41FilterFullText;
         AV48Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid = AV11TFWWPFormInstanceId;
         AV49Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to = AV12TFWWPFormInstanceId_To;
         AV50Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate = AV13TFWWPFormInstanceDate;
         AV51Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to = AV14TFWWPFormInstanceDate_To;
         AV52Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber = AV15TFWWPFormVersionNumber;
         AV53Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to = AV16TFWWPFormVersionNumber_To;
         AV54Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname = AV17TFWWPUserExtendedFullName;
         AV55Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel = AV18TFWWPUserExtendedFullName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext ,
                                              AV48Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid ,
                                              AV49Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to ,
                                              AV50Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate ,
                                              AV51Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to ,
                                              AV52Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber ,
                                              AV53Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to ,
                                              AV55Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel ,
                                              AV54Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname ,
                                              A214WWPFormInstanceId ,
                                              A207WWPFormVersionNumber ,
                                              A113WWPUserExtendedFullName ,
                                              A239WWPFormInstanceDate ,
                                              AV46Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid ,
                                              A206WWPFormId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT,
                                              TypeConstants.SHORT
                                              }
         });
         lV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext), "%", "");
         lV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext), "%", "");
         lV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext), "%", "");
         lV54Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname = StringUtil.Concat( StringUtil.RTrim( AV54Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname), "%", "");
         /* Using cursor P00632 */
         pr_default.execute(0, new Object[] {AV46Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid, lV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext, lV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext, lV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext, AV48Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid, AV49Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to, AV50Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate, AV51Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to, AV52Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber, AV53Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to, lV54Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname, AV55Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK632 = false;
            A112WWPUserExtendedId = P00632_A112WWPUserExtendedId[0];
            A206WWPFormId = P00632_A206WWPFormId[0];
            A113WWPUserExtendedFullName = P00632_A113WWPUserExtendedFullName[0];
            A207WWPFormVersionNumber = P00632_A207WWPFormVersionNumber[0];
            A239WWPFormInstanceDate = P00632_A239WWPFormInstanceDate[0];
            A214WWPFormInstanceId = P00632_A214WWPFormInstanceId[0];
            A113WWPUserExtendedFullName = P00632_A113WWPUserExtendedFullName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00632_A206WWPFormId[0] == A206WWPFormId ) && ( StringUtil.StrCmp(P00632_A113WWPUserExtendedFullName[0], A113WWPUserExtendedFullName) == 0 ) )
            {
               BRK632 = false;
               A112WWPUserExtendedId = P00632_A112WWPUserExtendedId[0];
               A214WWPFormInstanceId = P00632_A214WWPFormInstanceId[0];
               AV29count = (long)(AV29count+1);
               BRK632 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A113WWPUserExtendedFullName)) ? "<#Empty#>" : A113WWPUserExtendedFullName);
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
            if ( ! BRK632 )
            {
               BRK632 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV13TFWWPFormInstanceDate = DateTime.MinValue;
         AV14TFWWPFormInstanceDate_To = DateTime.MinValue;
         AV17TFWWPUserExtendedFullName = "";
         AV18TFWWPUserExtendedFullName_Sel = "";
         AV43WWPFormTitle = "";
         AV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = "";
         AV50Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate = DateTime.MinValue;
         AV51Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to = DateTime.MinValue;
         AV54Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname = "";
         AV55Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel = "";
         lV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = "";
         lV54Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname = "";
         A113WWPUserExtendedFullName = "";
         A239WWPFormInstanceDate = DateTime.MinValue;
         P00632_A112WWPUserExtendedId = new string[] {""} ;
         P00632_A206WWPFormId = new short[1] ;
         P00632_A113WWPUserExtendedFullName = new string[] {""} ;
         P00632_A207WWPFormVersionNumber = new short[1] ;
         P00632_A239WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         P00632_A214WWPFormInstanceId = new int[1] ;
         A112WWPUserExtendedId = "";
         AV24Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_forminstancewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00632_A112WWPUserExtendedId, P00632_A206WWPFormId, P00632_A113WWPUserExtendedFullName, P00632_A207WWPFormVersionNumber, P00632_A239WWPFormInstanceDate, P00632_A214WWPFormInstanceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private short AV15TFWWPFormVersionNumber ;
      private short AV16TFWWPFormVersionNumber_To ;
      private short AV42WWPFormId ;
      private short AV46Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid ;
      private short AV52Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber ;
      private short AV53Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to ;
      private short A207WWPFormVersionNumber ;
      private short A206WWPFormId ;
      private int AV44GXV1 ;
      private int AV11TFWWPFormInstanceId ;
      private int AV12TFWWPFormInstanceId_To ;
      private int AV48Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid ;
      private int AV49Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to ;
      private int A214WWPFormInstanceId ;
      private long AV29count ;
      private string A112WWPUserExtendedId ;
      private DateTime AV13TFWWPFormInstanceDate ;
      private DateTime AV14TFWWPFormInstanceDate_To ;
      private DateTime AV50Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate ;
      private DateTime AV51Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to ;
      private DateTime A239WWPFormInstanceDate ;
      private bool returnInSub ;
      private bool BRK632 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV17TFWWPUserExtendedFullName ;
      private string AV18TFWWPUserExtendedFullName_Sel ;
      private string AV43WWPFormTitle ;
      private string AV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext ;
      private string AV54Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname ;
      private string AV55Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel ;
      private string lV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext ;
      private string lV54Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname ;
      private string A113WWPUserExtendedFullName ;
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
      private string[] P00632_A112WWPUserExtendedId ;
      private short[] P00632_A206WWPFormId ;
      private string[] P00632_A113WWPUserExtendedFullName ;
      private short[] P00632_A207WWPFormVersionNumber ;
      private DateTime[] P00632_A239WWPFormInstanceDate ;
      private int[] P00632_A214WWPFormInstanceId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wwp_forminstancewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00632( IGxContext context ,
                                             string AV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext ,
                                             int AV48Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid ,
                                             int AV49Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to ,
                                             DateTime AV50Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate ,
                                             DateTime AV51Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to ,
                                             short AV52Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber ,
                                             short AV53Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to ,
                                             string AV55Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel ,
                                             string AV54Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname ,
                                             int A214WWPFormInstanceId ,
                                             short A207WWPFormVersionNumber ,
                                             string A113WWPUserExtendedFullName ,
                                             DateTime A239WWPFormInstanceDate ,
                                             short AV46Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid ,
                                             short A206WWPFormId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.WWPUserExtendedId, T1.WWPFormId, T2.WWPUserExtendedFullName, T1.WWPFormVersionNumber, T1.WWPFormInstanceDate, T1.WWPFormInstanceId FROM (WWP_FormInstance T1 INNER JOIN WWP_UserExtended T2 ON T2.WWPUserExtendedId = T1.WWPUserExtendedId)";
         AddWhere(sWhereString, "(T1.WWPFormId = :AV46Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.WWPFormInstanceId,'999999'), 2) like '%' || :lV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull) or ( SUBSTR(TO_CHAR(T1.WWPFormVersionNumber,'9999'), 2) like '%' || :lV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull) or ( T2.WWPUserExtendedFullName like '%' || :lV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV48Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid) )
         {
            AddWhere(sWhereString, "(T1.WWPFormInstanceId >= :AV48Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpformi)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV49Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to) )
         {
            AddWhere(sWhereString, "(T1.WWPFormInstanceId <= :AV49Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpformi)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV50Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate) )
         {
            AddWhere(sWhereString, "(T1.WWPFormInstanceDate >= :AV50Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpformi)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV51Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to) )
         {
            AddWhere(sWhereString, "(T1.WWPFormInstanceDate <= :AV51Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpformi)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV52Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber >= :AV52Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformv)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV53Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber <= :AV53Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformv)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname)) ) )
         {
            AddWhere(sWhereString, "(T2.WWPUserExtendedFullName like :lV54Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpusere)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel)) && ! ( StringUtil.StrCmp(AV55Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.WWPUserExtendedFullName = ( :AV55Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuser))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV55Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.WWPUserExtendedFullName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WWPFormId, T2.WWPUserExtendedFullName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00632(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00632;
          prmP00632 = new Object[] {
          new ParDef("AV46Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid",GXType.Int16,4,0) ,
          new ParDef("lV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull",GXType.VarChar,100,0) ,
          new ParDef("lV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull",GXType.VarChar,100,0) ,
          new ParDef("lV47Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull",GXType.VarChar,100,0) ,
          new ParDef("AV48Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpformi",GXType.Int32,6,0) ,
          new ParDef("AV49Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpformi",GXType.Int32,6,0) ,
          new ParDef("AV50Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpformi",GXType.Date,8,0) ,
          new ParDef("AV51Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpformi",GXType.Date,8,0) ,
          new ParDef("AV52Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformv",GXType.Int16,4,0) ,
          new ParDef("AV53Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformv",GXType.Int16,4,0) ,
          new ParDef("lV54Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpusere",GXType.VarChar,100,0) ,
          new ParDef("AV55Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuser",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00632", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00632,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 40);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
