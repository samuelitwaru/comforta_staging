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
   public class trn_bulletinboardwwgetfilterdata : GXProcedure
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
            return "trn_bulletinboardww_Services_Execute" ;
         }

      }

      public trn_bulletinboardwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_bulletinboardwwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_BULLETINBOARDBGCOLORCODE") == 0 )
         {
            /* Execute user subroutine: 'LOADBULLETINBOARDBGCOLORCODEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_BULLETINBOARDFORM") == 0 )
         {
            /* Execute user subroutine: 'LOADBULLETINBOARDFORMOPTIONS' */
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
         if ( StringUtil.StrCmp(AV26Session.Get("Trn_BulletinBoardWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Trn_BulletinBoardWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Trn_BulletinBoardWWGridState"), null, "", "");
         }
         AV38GXV1 = 1;
         while ( AV38GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV38GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFBULLETINBOARDBGCOLORCODE") == 0 )
            {
               AV11TFBulletinBoardBgColorCode = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFBULLETINBOARDBGCOLORCODE_SEL") == 0 )
            {
               AV12TFBulletinBoardBgColorCode_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFBULLETINBOARDFORM") == 0 )
            {
               AV13TFBulletinBoardForm = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFBULLETINBOARDFORM_SEL") == 0 )
            {
               AV14TFBulletinBoardForm_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV38GXV1 = (int)(AV38GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADBULLETINBOARDBGCOLORCODEOPTIONS' Routine */
         returnInSub = false;
         AV11TFBulletinBoardBgColorCode = AV15SearchTxt;
         AV12TFBulletinBoardBgColorCode_Sel = "";
         AV40Trn_bulletinboardwwds_1_filterfulltext = AV37FilterFullText;
         AV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode = AV11TFBulletinBoardBgColorCode;
         AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel = AV12TFBulletinBoardBgColorCode_Sel;
         AV43Trn_bulletinboardwwds_4_tfbulletinboardform = AV13TFBulletinBoardForm;
         AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel = AV14TFBulletinBoardForm_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV40Trn_bulletinboardwwds_1_filterfulltext ,
                                              AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel ,
                                              AV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode ,
                                              AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel ,
                                              AV43Trn_bulletinboardwwds_4_tfbulletinboardform ,
                                              A585BulletinBoardBgColorCode ,
                                              A586BulletinBoardForm } ,
                                              new int[]{
                                              }
         });
         lV40Trn_bulletinboardwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Trn_bulletinboardwwds_1_filterfulltext), "%", "");
         lV40Trn_bulletinboardwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Trn_bulletinboardwwds_1_filterfulltext), "%", "");
         lV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode = StringUtil.Concat( StringUtil.RTrim( AV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode), "%", "");
         lV43Trn_bulletinboardwwds_4_tfbulletinboardform = StringUtil.PadR( StringUtil.RTrim( AV43Trn_bulletinboardwwds_4_tfbulletinboardform), 20, "%");
         /* Using cursor P00CT2 */
         pr_default.execute(0, new Object[] {lV40Trn_bulletinboardwwds_1_filterfulltext, lV40Trn_bulletinboardwwds_1_filterfulltext, lV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode, AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel, lV43Trn_bulletinboardwwds_4_tfbulletinboardform, AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKCT2 = false;
            A585BulletinBoardBgColorCode = P00CT2_A585BulletinBoardBgColorCode[0];
            A586BulletinBoardForm = P00CT2_A586BulletinBoardForm[0];
            A574BulletinBoardId = P00CT2_A574BulletinBoardId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00CT2_A585BulletinBoardBgColorCode[0], A585BulletinBoardBgColorCode) == 0 ) )
            {
               BRKCT2 = false;
               A574BulletinBoardId = P00CT2_A574BulletinBoardId[0];
               AV25count = (long)(AV25count+1);
               BRKCT2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A585BulletinBoardBgColorCode)) ? "<#Empty#>" : A585BulletinBoardBgColorCode);
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
            if ( ! BRKCT2 )
            {
               BRKCT2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADBULLETINBOARDFORMOPTIONS' Routine */
         returnInSub = false;
         AV13TFBulletinBoardForm = AV15SearchTxt;
         AV14TFBulletinBoardForm_Sel = "";
         AV40Trn_bulletinboardwwds_1_filterfulltext = AV37FilterFullText;
         AV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode = AV11TFBulletinBoardBgColorCode;
         AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel = AV12TFBulletinBoardBgColorCode_Sel;
         AV43Trn_bulletinboardwwds_4_tfbulletinboardform = AV13TFBulletinBoardForm;
         AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel = AV14TFBulletinBoardForm_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV40Trn_bulletinboardwwds_1_filterfulltext ,
                                              AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel ,
                                              AV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode ,
                                              AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel ,
                                              AV43Trn_bulletinboardwwds_4_tfbulletinboardform ,
                                              A585BulletinBoardBgColorCode ,
                                              A586BulletinBoardForm } ,
                                              new int[]{
                                              }
         });
         lV40Trn_bulletinboardwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Trn_bulletinboardwwds_1_filterfulltext), "%", "");
         lV40Trn_bulletinboardwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Trn_bulletinboardwwds_1_filterfulltext), "%", "");
         lV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode = StringUtil.Concat( StringUtil.RTrim( AV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode), "%", "");
         lV43Trn_bulletinboardwwds_4_tfbulletinboardform = StringUtil.PadR( StringUtil.RTrim( AV43Trn_bulletinboardwwds_4_tfbulletinboardform), 20, "%");
         /* Using cursor P00CT3 */
         pr_default.execute(1, new Object[] {lV40Trn_bulletinboardwwds_1_filterfulltext, lV40Trn_bulletinboardwwds_1_filterfulltext, lV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode, AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel, lV43Trn_bulletinboardwwds_4_tfbulletinboardform, AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKCT4 = false;
            A586BulletinBoardForm = P00CT3_A586BulletinBoardForm[0];
            A585BulletinBoardBgColorCode = P00CT3_A585BulletinBoardBgColorCode[0];
            A574BulletinBoardId = P00CT3_A574BulletinBoardId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00CT3_A586BulletinBoardForm[0], A586BulletinBoardForm) == 0 ) )
            {
               BRKCT4 = false;
               A574BulletinBoardId = P00CT3_A574BulletinBoardId[0];
               AV25count = (long)(AV25count+1);
               BRKCT4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A586BulletinBoardForm)) ? "<#Empty#>" : A586BulletinBoardForm);
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
            if ( ! BRKCT4 )
            {
               BRKCT4 = true;
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
         AV11TFBulletinBoardBgColorCode = "";
         AV12TFBulletinBoardBgColorCode_Sel = "";
         AV13TFBulletinBoardForm = "";
         AV14TFBulletinBoardForm_Sel = "";
         AV40Trn_bulletinboardwwds_1_filterfulltext = "";
         AV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode = "";
         AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel = "";
         AV43Trn_bulletinboardwwds_4_tfbulletinboardform = "";
         AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel = "";
         lV40Trn_bulletinboardwwds_1_filterfulltext = "";
         lV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode = "";
         lV43Trn_bulletinboardwwds_4_tfbulletinboardform = "";
         A585BulletinBoardBgColorCode = "";
         A586BulletinBoardForm = "";
         P00CT2_A585BulletinBoardBgColorCode = new string[] {""} ;
         P00CT2_A586BulletinBoardForm = new string[] {""} ;
         P00CT2_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         A574BulletinBoardId = Guid.Empty;
         AV20Option = "";
         P00CT3_A586BulletinBoardForm = new string[] {""} ;
         P00CT3_A585BulletinBoardBgColorCode = new string[] {""} ;
         P00CT3_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_bulletinboardwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00CT2_A585BulletinBoardBgColorCode, P00CT2_A586BulletinBoardForm, P00CT2_A574BulletinBoardId
               }
               , new Object[] {
               P00CT3_A586BulletinBoardForm, P00CT3_A585BulletinBoardBgColorCode, P00CT3_A574BulletinBoardId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private int AV38GXV1 ;
      private long AV25count ;
      private string AV13TFBulletinBoardForm ;
      private string AV14TFBulletinBoardForm_Sel ;
      private string AV43Trn_bulletinboardwwds_4_tfbulletinboardform ;
      private string AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel ;
      private string lV43Trn_bulletinboardwwds_4_tfbulletinboardform ;
      private string A586BulletinBoardForm ;
      private bool returnInSub ;
      private bool BRKCT2 ;
      private bool BRKCT4 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV11TFBulletinBoardBgColorCode ;
      private string AV12TFBulletinBoardBgColorCode_Sel ;
      private string AV40Trn_bulletinboardwwds_1_filterfulltext ;
      private string AV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode ;
      private string AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel ;
      private string lV40Trn_bulletinboardwwds_1_filterfulltext ;
      private string lV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode ;
      private string A585BulletinBoardBgColorCode ;
      private string AV20Option ;
      private Guid A574BulletinBoardId ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00CT2_A585BulletinBoardBgColorCode ;
      private string[] P00CT2_A586BulletinBoardForm ;
      private Guid[] P00CT2_A574BulletinBoardId ;
      private string[] P00CT3_A586BulletinBoardForm ;
      private string[] P00CT3_A585BulletinBoardBgColorCode ;
      private Guid[] P00CT3_A574BulletinBoardId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_bulletinboardwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CT2( IGxContext context ,
                                             string AV40Trn_bulletinboardwwds_1_filterfulltext ,
                                             string AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel ,
                                             string AV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode ,
                                             string AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel ,
                                             string AV43Trn_bulletinboardwwds_4_tfbulletinboardform ,
                                             string A585BulletinBoardBgColorCode ,
                                             string A586BulletinBoardForm )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT BulletinBoardBgColorCode, BulletinBoardForm, BulletinBoardId FROM Trn_BulletinBoard";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Trn_bulletinboardwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(BulletinBoardBgColorCode) like '%' || LOWER(:lV40Trn_bulletinboardwwds_1_filterfulltext)) or ( LOWER(BulletinBoardForm) like '%' || LOWER(:lV40Trn_bulletinboardwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode)) ) )
         {
            AddWhere(sWhereString, "(BulletinBoardBgColorCode like :lV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel)) && ! ( StringUtil.StrCmp(AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(BulletinBoardBgColorCode = ( :AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from BulletinBoardBgColorCode))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_bulletinboardwwds_4_tfbulletinboardform)) ) )
         {
            AddWhere(sWhereString, "(BulletinBoardForm like :lV43Trn_bulletinboardwwds_4_tfbulletinboardform)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel)) && ! ( StringUtil.StrCmp(AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(BulletinBoardForm = ( :AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from BulletinBoardForm))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY BulletinBoardBgColorCode";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00CT3( IGxContext context ,
                                             string AV40Trn_bulletinboardwwds_1_filterfulltext ,
                                             string AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel ,
                                             string AV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode ,
                                             string AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel ,
                                             string AV43Trn_bulletinboardwwds_4_tfbulletinboardform ,
                                             string A585BulletinBoardBgColorCode ,
                                             string A586BulletinBoardForm )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT BulletinBoardForm, BulletinBoardBgColorCode, BulletinBoardId FROM Trn_BulletinBoard";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Trn_bulletinboardwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(BulletinBoardBgColorCode) like '%' || LOWER(:lV40Trn_bulletinboardwwds_1_filterfulltext)) or ( LOWER(BulletinBoardForm) like '%' || LOWER(:lV40Trn_bulletinboardwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode)) ) )
         {
            AddWhere(sWhereString, "(BulletinBoardBgColorCode like :lV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel)) && ! ( StringUtil.StrCmp(AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(BulletinBoardBgColorCode = ( :AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from BulletinBoardBgColorCode))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_bulletinboardwwds_4_tfbulletinboardform)) ) )
         {
            AddWhere(sWhereString, "(BulletinBoardForm like :lV43Trn_bulletinboardwwds_4_tfbulletinboardform)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel)) && ! ( StringUtil.StrCmp(AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(BulletinBoardForm = ( :AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from BulletinBoardForm))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY BulletinBoardForm";
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
                     return conditional_P00CT2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
               case 1 :
                     return conditional_P00CT3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
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
          Object[] prmP00CT2;
          prmP00CT2 = new Object[] {
          new ParDef("lV40Trn_bulletinboardwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Trn_bulletinboardwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode",GXType.VarChar,100,0) ,
          new ParDef("AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel",GXType.VarChar,100,0) ,
          new ParDef("lV43Trn_bulletinboardwwds_4_tfbulletinboardform",GXType.Char,20,0) ,
          new ParDef("AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel",GXType.Char,20,0)
          };
          Object[] prmP00CT3;
          prmP00CT3 = new Object[] {
          new ParDef("lV40Trn_bulletinboardwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Trn_bulletinboardwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Trn_bulletinboardwwds_2_tfbulletinboardbgcolorcode",GXType.VarChar,100,0) ,
          new ParDef("AV42Trn_bulletinboardwwds_3_tfbulletinboardbgcolorcode_sel",GXType.VarChar,100,0) ,
          new ParDef("lV43Trn_bulletinboardwwds_4_tfbulletinboardform",GXType.Char,20,0) ,
          new ParDef("AV44Trn_bulletinboardwwds_5_tfbulletinboardform_sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CT2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CT2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CT3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CT3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
