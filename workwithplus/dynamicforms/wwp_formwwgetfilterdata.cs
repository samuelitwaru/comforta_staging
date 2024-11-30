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
   public class wwp_formwwgetfilterdata : GXProcedure
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
            return "wwp_formww_Services_Execute" ;
         }

      }

      public wwp_formwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_formwwgetfilterdata( IGxContext context )
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
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV36OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV18MaxItems = 10;
         AV17PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV32SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV15SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? "" : StringUtil.Substring( AV32SearchTxtParms, 3, -1));
         AV16SkipItems = (short)(AV17PageIndex*AV18MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_WWPFORMREFERENCENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPFORMREFERENCENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_WWPFORMTITLE") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPFORMTITLEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV34OptionsJson = AV21Options.ToJSonString(false);
         AV35OptionsDescJson = AV23OptionsDesc.ToJSonString(false);
         AV36OptionIndexesJson = AV24OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get("WorkWithPlus.DynamicForms.WWP_FormWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WorkWithPlus.DynamicForms.WWP_FormWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("WorkWithPlus.DynamicForms.WWP_FormWWGridState"), null, "", "");
         }
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV42GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME") == 0 )
            {
               AV11TFWWPFormReferenceName = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME_SEL") == 0 )
            {
               AV12TFWWPFormReferenceName_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE") == 0 )
            {
               AV13TFWWPFormTitle = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE_SEL") == 0 )
            {
               AV14TFWWPFormTitle_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFWWPFORMDATE") == 0 )
            {
               AV40TFWWPFormDate = context.localUtil.CToT( AV29GridStateFilterValue.gxTpr_Value, 2);
               AV41TFWWPFormDate_To = context.localUtil.CToT( AV29GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMTYPE") == 0 )
            {
               AV38WWPFormType = (short)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMISFORDYNAMICVALIDATIONS") == 0 )
            {
               AV39WWPFormIsForDynamicValidations = BooleanUtil.Val( AV29GridStateFilterValue.gxTpr_Value);
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADWWPFORMREFERENCENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFWWPFormReferenceName = AV15SearchTxt;
         AV12TFWWPFormReferenceName_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV37FilterFullText ,
                                              AV12TFWWPFormReferenceName_Sel ,
                                              AV11TFWWPFormReferenceName ,
                                              AV14TFWWPFormTitle_Sel ,
                                              AV13TFWWPFormTitle ,
                                              AV40TFWWPFormDate ,
                                              AV41TFWWPFormDate_To ,
                                              AV38WWPFormType ,
                                              AV39WWPFormIsForDynamicValidations ,
                                              A208WWPFormReferenceName ,
                                              A209WWPFormTitle ,
                                              A231WWPFormDate ,
                                              A242WWPFormIsForDynamicValidations ,
                                              A40000GXC1 ,
                                              A207WWPFormVersionNumber ,
                                              A219WWPFormLatestVersionNumber ,
                                              A240WWPFormType } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT
                                              }
         });
         lV37FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV37FilterFullText), "%", "");
         lV37FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV37FilterFullText), "%", "");
         lV11TFWWPFormReferenceName = StringUtil.Concat( StringUtil.RTrim( AV11TFWWPFormReferenceName), "%", "");
         lV13TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV13TFWWPFormTitle), "%", "");
         /* Using cursor P00623 */
         pr_default.execute(0, new Object[] {AV38WWPFormType, lV37FilterFullText, lV37FilterFullText, lV11TFWWPFormReferenceName, AV12TFWWPFormReferenceName_Sel, lV13TFWWPFormTitle, AV14TFWWPFormTitle_Sel, AV40TFWWPFormDate, AV41TFWWPFormDate_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK622 = false;
            A240WWPFormType = P00623_A240WWPFormType[0];
            A208WWPFormReferenceName = P00623_A208WWPFormReferenceName[0];
            A242WWPFormIsForDynamicValidations = P00623_A242WWPFormIsForDynamicValidations[0];
            A207WWPFormVersionNumber = P00623_A207WWPFormVersionNumber[0];
            A231WWPFormDate = P00623_A231WWPFormDate[0];
            A209WWPFormTitle = P00623_A209WWPFormTitle[0];
            A40000GXC1 = P00623_A40000GXC1[0];
            n40000GXC1 = P00623_n40000GXC1[0];
            A206WWPFormId = P00623_A206WWPFormId[0];
            A40000GXC1 = P00623_A40000GXC1[0];
            n40000GXC1 = P00623_n40000GXC1[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            if ( A207WWPFormVersionNumber == A219WWPFormLatestVersionNumber )
            {
               AV25count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P00623_A240WWPFormType[0] == A240WWPFormType ) && ( StringUtil.StrCmp(P00623_A208WWPFormReferenceName[0], A208WWPFormReferenceName) == 0 ) )
               {
                  BRK622 = false;
                  A207WWPFormVersionNumber = P00623_A207WWPFormVersionNumber[0];
                  A206WWPFormId = P00623_A206WWPFormId[0];
                  AV25count = (long)(AV25count+1);
                  BRK622 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV16SkipItems) )
               {
                  AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A208WWPFormReferenceName)) ? "<#Empty#>" : A208WWPFormReferenceName);
                  AV21Options.Add(AV20Option, 0);
                  AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV21Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV16SkipItems = (short)(AV16SkipItems-1);
               }
            }
            if ( ! BRK622 )
            {
               BRK622 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADWWPFORMTITLEOPTIONS' Routine */
         returnInSub = false;
         AV13TFWWPFormTitle = AV15SearchTxt;
         AV14TFWWPFormTitle_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV37FilterFullText ,
                                              AV12TFWWPFormReferenceName_Sel ,
                                              AV11TFWWPFormReferenceName ,
                                              AV14TFWWPFormTitle_Sel ,
                                              AV13TFWWPFormTitle ,
                                              AV40TFWWPFormDate ,
                                              AV41TFWWPFormDate_To ,
                                              AV38WWPFormType ,
                                              AV39WWPFormIsForDynamicValidations ,
                                              A208WWPFormReferenceName ,
                                              A209WWPFormTitle ,
                                              A231WWPFormDate ,
                                              A242WWPFormIsForDynamicValidations ,
                                              A40000GXC1 ,
                                              A207WWPFormVersionNumber ,
                                              A219WWPFormLatestVersionNumber ,
                                              A240WWPFormType } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT
                                              }
         });
         lV37FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV37FilterFullText), "%", "");
         lV37FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV37FilterFullText), "%", "");
         lV11TFWWPFormReferenceName = StringUtil.Concat( StringUtil.RTrim( AV11TFWWPFormReferenceName), "%", "");
         lV13TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV13TFWWPFormTitle), "%", "");
         /* Using cursor P00625 */
         pr_default.execute(1, new Object[] {AV38WWPFormType, lV37FilterFullText, lV37FilterFullText, lV11TFWWPFormReferenceName, AV12TFWWPFormReferenceName_Sel, lV13TFWWPFormTitle, AV14TFWWPFormTitle_Sel, AV40TFWWPFormDate, AV41TFWWPFormDate_To});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK624 = false;
            A240WWPFormType = P00625_A240WWPFormType[0];
            A209WWPFormTitle = P00625_A209WWPFormTitle[0];
            A242WWPFormIsForDynamicValidations = P00625_A242WWPFormIsForDynamicValidations[0];
            A207WWPFormVersionNumber = P00625_A207WWPFormVersionNumber[0];
            A231WWPFormDate = P00625_A231WWPFormDate[0];
            A208WWPFormReferenceName = P00625_A208WWPFormReferenceName[0];
            A40000GXC1 = P00625_A40000GXC1[0];
            n40000GXC1 = P00625_n40000GXC1[0];
            A206WWPFormId = P00625_A206WWPFormId[0];
            A40000GXC1 = P00625_A40000GXC1[0];
            n40000GXC1 = P00625_n40000GXC1[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            if ( A207WWPFormVersionNumber == A219WWPFormLatestVersionNumber )
            {
               AV25count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( P00625_A240WWPFormType[0] == A240WWPFormType ) && ( StringUtil.StrCmp(P00625_A209WWPFormTitle[0], A209WWPFormTitle) == 0 ) )
               {
                  BRK624 = false;
                  A207WWPFormVersionNumber = P00625_A207WWPFormVersionNumber[0];
                  A206WWPFormId = P00625_A206WWPFormId[0];
                  AV25count = (long)(AV25count+1);
                  BRK624 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV16SkipItems) )
               {
                  AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A209WWPFormTitle)) ? "<#Empty#>" : A209WWPFormTitle);
                  AV21Options.Add(AV20Option, 0);
                  AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV21Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV16SkipItems = (short)(AV16SkipItems-1);
               }
            }
            if ( ! BRK624 )
            {
               BRK624 = true;
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
         AV34OptionsJson = "";
         AV35OptionsDescJson = "";
         AV36OptionIndexesJson = "";
         AV21Options = new GxSimpleCollection<string>();
         AV23OptionsDesc = new GxSimpleCollection<string>();
         AV24OptionIndexes = new GxSimpleCollection<string>();
         AV15SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV26Session = context.GetSession();
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV37FilterFullText = "";
         AV11TFWWPFormReferenceName = "";
         AV12TFWWPFormReferenceName_Sel = "";
         AV13TFWWPFormTitle = "";
         AV14TFWWPFormTitle_Sel = "";
         AV40TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AV41TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         lV37FilterFullText = "";
         lV11TFWWPFormReferenceName = "";
         lV13TFWWPFormTitle = "";
         A208WWPFormReferenceName = "";
         A209WWPFormTitle = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         P00623_A240WWPFormType = new short[1] ;
         P00623_A208WWPFormReferenceName = new string[] {""} ;
         P00623_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         P00623_A207WWPFormVersionNumber = new short[1] ;
         P00623_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P00623_A209WWPFormTitle = new string[] {""} ;
         P00623_A40000GXC1 = new int[1] ;
         P00623_n40000GXC1 = new bool[] {false} ;
         P00623_A206WWPFormId = new short[1] ;
         AV20Option = "";
         P00625_A240WWPFormType = new short[1] ;
         P00625_A209WWPFormTitle = new string[] {""} ;
         P00625_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         P00625_A207WWPFormVersionNumber = new short[1] ;
         P00625_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P00625_A208WWPFormReferenceName = new string[] {""} ;
         P00625_A40000GXC1 = new int[1] ;
         P00625_n40000GXC1 = new bool[] {false} ;
         P00625_A206WWPFormId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_formwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00623_A240WWPFormType, P00623_A208WWPFormReferenceName, P00623_A242WWPFormIsForDynamicValidations, P00623_A207WWPFormVersionNumber, P00623_A231WWPFormDate, P00623_A209WWPFormTitle, P00623_A40000GXC1, P00623_n40000GXC1, P00623_A206WWPFormId
               }
               , new Object[] {
               P00625_A240WWPFormType, P00625_A209WWPFormTitle, P00625_A242WWPFormIsForDynamicValidations, P00625_A207WWPFormVersionNumber, P00625_A231WWPFormDate, P00625_A208WWPFormReferenceName, P00625_A40000GXC1, P00625_n40000GXC1, P00625_A206WWPFormId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private short AV38WWPFormType ;
      private short A207WWPFormVersionNumber ;
      private short A219WWPFormLatestVersionNumber ;
      private short A240WWPFormType ;
      private short A206WWPFormId ;
      private short GXt_int1 ;
      private int AV42GXV1 ;
      private int A40000GXC1 ;
      private long AV25count ;
      private DateTime AV40TFWWPFormDate ;
      private DateTime AV41TFWWPFormDate_To ;
      private DateTime A231WWPFormDate ;
      private bool returnInSub ;
      private bool AV39WWPFormIsForDynamicValidations ;
      private bool A242WWPFormIsForDynamicValidations ;
      private bool BRK622 ;
      private bool n40000GXC1 ;
      private bool BRK624 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV11TFWWPFormReferenceName ;
      private string AV12TFWWPFormReferenceName_Sel ;
      private string AV13TFWWPFormTitle ;
      private string AV14TFWWPFormTitle_Sel ;
      private string lV37FilterFullText ;
      private string lV11TFWWPFormReferenceName ;
      private string lV13TFWWPFormTitle ;
      private string A208WWPFormReferenceName ;
      private string A209WWPFormTitle ;
      private string AV20Option ;
      private IGxSession AV26Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private short[] P00623_A240WWPFormType ;
      private string[] P00623_A208WWPFormReferenceName ;
      private bool[] P00623_A242WWPFormIsForDynamicValidations ;
      private short[] P00623_A207WWPFormVersionNumber ;
      private DateTime[] P00623_A231WWPFormDate ;
      private string[] P00623_A209WWPFormTitle ;
      private int[] P00623_A40000GXC1 ;
      private bool[] P00623_n40000GXC1 ;
      private short[] P00623_A206WWPFormId ;
      private short[] P00625_A240WWPFormType ;
      private string[] P00625_A209WWPFormTitle ;
      private bool[] P00625_A242WWPFormIsForDynamicValidations ;
      private short[] P00625_A207WWPFormVersionNumber ;
      private DateTime[] P00625_A231WWPFormDate ;
      private string[] P00625_A208WWPFormReferenceName ;
      private int[] P00625_A40000GXC1 ;
      private bool[] P00625_n40000GXC1 ;
      private short[] P00625_A206WWPFormId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wwp_formwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00623( IGxContext context ,
                                             string AV37FilterFullText ,
                                             string AV12TFWWPFormReferenceName_Sel ,
                                             string AV11TFWWPFormReferenceName ,
                                             string AV14TFWWPFormTitle_Sel ,
                                             string AV13TFWWPFormTitle ,
                                             DateTime AV40TFWWPFormDate ,
                                             DateTime AV41TFWWPFormDate_To ,
                                             short AV38WWPFormType ,
                                             bool AV39WWPFormIsForDynamicValidations ,
                                             string A208WWPFormReferenceName ,
                                             string A209WWPFormTitle ,
                                             DateTime A231WWPFormDate ,
                                             bool A242WWPFormIsForDynamicValidations ,
                                             int A40000GXC1 ,
                                             short A207WWPFormVersionNumber ,
                                             short A219WWPFormLatestVersionNumber ,
                                             short A240WWPFormType )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[9];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.WWPFormType, T1.WWPFormReferenceName, T1.WWPFormIsForDynamicValidations, T1.WWPFormVersionNumber, T1.WWPFormDate, T1.WWPFormTitle, COALESCE( T2.GXC1, 0) AS GXC1, T1.WWPFormId FROM (WWP_Form T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, WWPFormId, WWPFormVersionNumber FROM WWP_FormElement WHERE T1.WWPFormId = WWPFormId and T1.WWPFormVersionNumber = WWPFormVersionNumber GROUP BY WWPFormId, WWPFormVersionNumber ) T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T1.WWPFormType = :AV38WWPFormType)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.WWPFormReferenceName like '%' || :lV37FilterFullText) or ( T1.WWPFormTitle like '%' || :lV37FilterFullText))");
         }
         else
         {
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFWWPFormReferenceName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFWWPFormReferenceName)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName like :lV11TFWWPFormReferenceName)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFWWPFormReferenceName_Sel)) && ! ( StringUtil.StrCmp(AV12TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName = ( :AV12TFWWPFormReferenceName_Sel))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormReferenceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFWWPFormTitle)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle like :lV13TFWWPFormTitle)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV14TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle = ( :AV14TFWWPFormTitle_Sel))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormTitle))=0))");
         }
         if ( ! (DateTime.MinValue==AV40TFWWPFormDate) )
         {
            AddWhere(sWhereString, "(T1.WWPFormDate >= :AV40TFWWPFormDate)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV41TFWWPFormDate_To) )
         {
            AddWhere(sWhereString, "(T1.WWPFormDate <= :AV41TFWWPFormDate_To)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ( AV38WWPFormType == 1 ) && AV39WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(T1.WWPFormIsForDynamicValidations)");
         }
         if ( ( AV38WWPFormType == 1 ) && ! AV39WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(COALESCE( T2.GXC1, 0) > 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WWPFormType, T1.WWPFormReferenceName";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00625( IGxContext context ,
                                             string AV37FilterFullText ,
                                             string AV12TFWWPFormReferenceName_Sel ,
                                             string AV11TFWWPFormReferenceName ,
                                             string AV14TFWWPFormTitle_Sel ,
                                             string AV13TFWWPFormTitle ,
                                             DateTime AV40TFWWPFormDate ,
                                             DateTime AV41TFWWPFormDate_To ,
                                             short AV38WWPFormType ,
                                             bool AV39WWPFormIsForDynamicValidations ,
                                             string A208WWPFormReferenceName ,
                                             string A209WWPFormTitle ,
                                             DateTime A231WWPFormDate ,
                                             bool A242WWPFormIsForDynamicValidations ,
                                             int A40000GXC1 ,
                                             short A207WWPFormVersionNumber ,
                                             short A219WWPFormLatestVersionNumber ,
                                             short A240WWPFormType )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[9];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.WWPFormType, T1.WWPFormTitle, T1.WWPFormIsForDynamicValidations, T1.WWPFormVersionNumber, T1.WWPFormDate, T1.WWPFormReferenceName, COALESCE( T2.GXC1, 0) AS GXC1, T1.WWPFormId FROM (WWP_Form T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, WWPFormId, WWPFormVersionNumber FROM WWP_FormElement WHERE T1.WWPFormId = WWPFormId and T1.WWPFormVersionNumber = WWPFormVersionNumber GROUP BY WWPFormId, WWPFormVersionNumber ) T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T1.WWPFormType = :AV38WWPFormType)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.WWPFormReferenceName like '%' || :lV37FilterFullText) or ( T1.WWPFormTitle like '%' || :lV37FilterFullText))");
         }
         else
         {
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFWWPFormReferenceName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFWWPFormReferenceName)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName like :lV11TFWWPFormReferenceName)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFWWPFormReferenceName_Sel)) && ! ( StringUtil.StrCmp(AV12TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName = ( :AV12TFWWPFormReferenceName_Sel))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormReferenceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFWWPFormTitle)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle like :lV13TFWWPFormTitle)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV14TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle = ( :AV14TFWWPFormTitle_Sel))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormTitle))=0))");
         }
         if ( ! (DateTime.MinValue==AV40TFWWPFormDate) )
         {
            AddWhere(sWhereString, "(T1.WWPFormDate >= :AV40TFWWPFormDate)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV41TFWWPFormDate_To) )
         {
            AddWhere(sWhereString, "(T1.WWPFormDate <= :AV41TFWWPFormDate_To)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ( AV38WWPFormType == 1 ) && AV39WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(T1.WWPFormIsForDynamicValidations)");
         }
         if ( ( AV38WWPFormType == 1 ) && ! AV39WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(COALESCE( T2.GXC1, 0) > 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WWPFormType, T1.WWPFormTitle";
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
                     return conditional_P00623(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (bool)dynConstraints[12] , (int)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] );
               case 1 :
                     return conditional_P00625(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (bool)dynConstraints[12] , (int)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] );
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
          Object[] prmP00623;
          prmP00623 = new Object[] {
          new ParDef("AV38WWPFormType",GXType.Int16,1,0) ,
          new ParDef("lV37FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV37FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV11TFWWPFormReferenceName",GXType.VarChar,100,0) ,
          new ParDef("AV12TFWWPFormReferenceName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV13TFWWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("AV14TFWWPFormTitle_Sel",GXType.VarChar,100,0) ,
          new ParDef("AV40TFWWPFormDate",GXType.DateTime,8,5) ,
          new ParDef("AV41TFWWPFormDate_To",GXType.DateTime,8,5)
          };
          Object[] prmP00625;
          prmP00625 = new Object[] {
          new ParDef("AV38WWPFormType",GXType.Int16,1,0) ,
          new ParDef("lV37FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV37FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV11TFWWPFormReferenceName",GXType.VarChar,100,0) ,
          new ParDef("AV12TFWWPFormReferenceName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV13TFWWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("AV14TFWWPFormTitle_Sel",GXType.VarChar,100,0) ,
          new ParDef("AV40TFWWPFormDate",GXType.DateTime,8,5) ,
          new ParDef("AV41TFWWPFormDate_To",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00623", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00623,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00625", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00625,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                return;
       }
    }

 }

}
