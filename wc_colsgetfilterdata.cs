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
   public class wc_colsgetfilterdata : GXProcedure
   {
      public wc_colsgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wc_colsgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_TRN_COLNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADTRN_COLNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_TILENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADTILENAMEOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV24Session.Get("WC_ColsGridState"), "") == 0 )
         {
            AV26GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WC_ColsGridState"), null, "", "");
         }
         else
         {
            AV26GridState.FromXml(AV24Session.Get("WC_ColsGridState"), null, "", "");
         }
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV40GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_COLNAME") == 0 )
            {
               AV11TFTrn_ColName = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_COLNAME_SEL") == 0 )
            {
               AV12TFTrn_ColName_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTILENAME") == 0 )
            {
               AV38TFTileName = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTILENAME_SEL") == 0 )
            {
               AV39TFTileName_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "PARM_&TRN_ROWID") == 0 )
            {
               AV35Trn_RowId = StringUtil.StrToGuid( AV27GridStateFilterValue.gxTpr_Value);
            }
            AV40GXV1 = (int)(AV40GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTRN_COLNAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFTrn_ColName = AV13SearchTxt;
         AV12TFTrn_ColName_Sel = "";
         AV42Wc_colsds_1_trn_rowid = AV35Trn_RowId;
         AV43Wc_colsds_2_tftrn_colname = AV11TFTrn_ColName;
         AV44Wc_colsds_3_tftrn_colname_sel = AV12TFTrn_ColName_Sel;
         AV45Wc_colsds_4_tftilename = AV38TFTileName;
         AV46Wc_colsds_5_tftilename_sel = AV39TFTileName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV44Wc_colsds_3_tftrn_colname_sel ,
                                              AV43Wc_colsds_2_tftrn_colname ,
                                              AV46Wc_colsds_5_tftilename_sel ,
                                              AV45Wc_colsds_4_tftilename ,
                                              A327Trn_ColName ,
                                              A400TileName ,
                                              A319Trn_RowId ,
                                              AV35Trn_RowId ,
                                              AV42Wc_colsds_1_trn_rowid } ,
                                              new int[]{
                                              }
         });
         lV43Wc_colsds_2_tftrn_colname = StringUtil.Concat( StringUtil.RTrim( AV43Wc_colsds_2_tftrn_colname), "%", "");
         lV45Wc_colsds_4_tftilename = StringUtil.Concat( StringUtil.RTrim( AV45Wc_colsds_4_tftilename), "%", "");
         /* Using cursor P00702 */
         pr_default.execute(0, new Object[] {AV42Wc_colsds_1_trn_rowid, AV35Trn_RowId, lV43Wc_colsds_2_tftrn_colname, AV44Wc_colsds_3_tftrn_colname_sel, lV45Wc_colsds_4_tftilename, AV46Wc_colsds_5_tftilename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK702 = false;
            A407TileId = P00702_A407TileId[0];
            A319Trn_RowId = P00702_A319Trn_RowId[0];
            A327Trn_ColName = P00702_A327Trn_ColName[0];
            A400TileName = P00702_A400TileName[0];
            A328Trn_ColId = P00702_A328Trn_ColId[0];
            A400TileName = P00702_A400TileName[0];
            AV23count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00702_A319Trn_RowId[0] == A319Trn_RowId ) && ( StringUtil.StrCmp(P00702_A327Trn_ColName[0], A327Trn_ColName) == 0 ) )
            {
               BRK702 = false;
               A328Trn_ColId = P00702_A328Trn_ColId[0];
               AV23count = (long)(AV23count+1);
               BRK702 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV14SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A327Trn_ColName)) ? "<#Empty#>" : A327Trn_ColName);
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
            if ( ! BRK702 )
            {
               BRK702 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTILENAMEOPTIONS' Routine */
         returnInSub = false;
         AV38TFTileName = AV13SearchTxt;
         AV39TFTileName_Sel = "";
         AV42Wc_colsds_1_trn_rowid = AV35Trn_RowId;
         AV43Wc_colsds_2_tftrn_colname = AV11TFTrn_ColName;
         AV44Wc_colsds_3_tftrn_colname_sel = AV12TFTrn_ColName_Sel;
         AV45Wc_colsds_4_tftilename = AV38TFTileName;
         AV46Wc_colsds_5_tftilename_sel = AV39TFTileName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV44Wc_colsds_3_tftrn_colname_sel ,
                                              AV43Wc_colsds_2_tftrn_colname ,
                                              AV46Wc_colsds_5_tftilename_sel ,
                                              AV45Wc_colsds_4_tftilename ,
                                              A327Trn_ColName ,
                                              A400TileName ,
                                              A319Trn_RowId ,
                                              AV35Trn_RowId ,
                                              AV42Wc_colsds_1_trn_rowid } ,
                                              new int[]{
                                              }
         });
         lV43Wc_colsds_2_tftrn_colname = StringUtil.Concat( StringUtil.RTrim( AV43Wc_colsds_2_tftrn_colname), "%", "");
         lV45Wc_colsds_4_tftilename = StringUtil.Concat( StringUtil.RTrim( AV45Wc_colsds_4_tftilename), "%", "");
         /* Using cursor P00703 */
         pr_default.execute(1, new Object[] {AV42Wc_colsds_1_trn_rowid, AV35Trn_RowId, lV43Wc_colsds_2_tftrn_colname, AV44Wc_colsds_3_tftrn_colname_sel, lV45Wc_colsds_4_tftilename, AV46Wc_colsds_5_tftilename_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK704 = false;
            A407TileId = P00703_A407TileId[0];
            A319Trn_RowId = P00703_A319Trn_RowId[0];
            A400TileName = P00703_A400TileName[0];
            A327Trn_ColName = P00703_A327Trn_ColName[0];
            A328Trn_ColId = P00703_A328Trn_ColId[0];
            A400TileName = P00703_A400TileName[0];
            AV23count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00703_A319Trn_RowId[0] == A319Trn_RowId ) && ( StringUtil.StrCmp(P00703_A400TileName[0], A400TileName) == 0 ) )
            {
               BRK704 = false;
               A407TileId = P00703_A407TileId[0];
               A328Trn_ColId = P00703_A328Trn_ColId[0];
               AV23count = (long)(AV23count+1);
               BRK704 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV14SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A400TileName)) ? "<#Empty#>" : A400TileName);
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
            if ( ! BRK704 )
            {
               BRK704 = true;
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
         AV11TFTrn_ColName = "";
         AV12TFTrn_ColName_Sel = "";
         AV38TFTileName = "";
         AV39TFTileName_Sel = "";
         AV35Trn_RowId = Guid.Empty;
         AV42Wc_colsds_1_trn_rowid = Guid.Empty;
         AV43Wc_colsds_2_tftrn_colname = "";
         AV44Wc_colsds_3_tftrn_colname_sel = "";
         AV45Wc_colsds_4_tftilename = "";
         AV46Wc_colsds_5_tftilename_sel = "";
         lV43Wc_colsds_2_tftrn_colname = "";
         lV45Wc_colsds_4_tftilename = "";
         A327Trn_ColName = "";
         A400TileName = "";
         A319Trn_RowId = Guid.Empty;
         P00702_A407TileId = new Guid[] {Guid.Empty} ;
         P00702_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         P00702_A327Trn_ColName = new string[] {""} ;
         P00702_A400TileName = new string[] {""} ;
         P00702_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         A407TileId = Guid.Empty;
         A328Trn_ColId = Guid.Empty;
         AV18Option = "";
         P00703_A407TileId = new Guid[] {Guid.Empty} ;
         P00703_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         P00703_A400TileName = new string[] {""} ;
         P00703_A327Trn_ColName = new string[] {""} ;
         P00703_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wc_colsgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00702_A407TileId, P00702_A319Trn_RowId, P00702_A327Trn_ColName, P00702_A400TileName, P00702_A328Trn_ColId
               }
               , new Object[] {
               P00703_A407TileId, P00703_A319Trn_RowId, P00703_A400TileName, P00703_A327Trn_ColName, P00703_A328Trn_ColId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MaxItems ;
      private short AV15PageIndex ;
      private short AV14SkipItems ;
      private int AV40GXV1 ;
      private long AV23count ;
      private bool returnInSub ;
      private bool BRK702 ;
      private bool BRK704 ;
      private string AV32OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string AV29DDOName ;
      private string AV30SearchTxtParms ;
      private string AV31SearchTxtTo ;
      private string AV13SearchTxt ;
      private string AV11TFTrn_ColName ;
      private string AV12TFTrn_ColName_Sel ;
      private string AV38TFTileName ;
      private string AV39TFTileName_Sel ;
      private string AV43Wc_colsds_2_tftrn_colname ;
      private string AV44Wc_colsds_3_tftrn_colname_sel ;
      private string AV45Wc_colsds_4_tftilename ;
      private string AV46Wc_colsds_5_tftilename_sel ;
      private string lV43Wc_colsds_2_tftrn_colname ;
      private string lV45Wc_colsds_4_tftilename ;
      private string A327Trn_ColName ;
      private string A400TileName ;
      private string AV18Option ;
      private Guid AV35Trn_RowId ;
      private Guid AV42Wc_colsds_1_trn_rowid ;
      private Guid A319Trn_RowId ;
      private Guid A407TileId ;
      private Guid A328Trn_ColId ;
      private IGxSession AV24Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV19Options ;
      private GxSimpleCollection<string> AV21OptionsDesc ;
      private GxSimpleCollection<string> AV22OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV26GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV27GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00702_A407TileId ;
      private Guid[] P00702_A319Trn_RowId ;
      private string[] P00702_A327Trn_ColName ;
      private string[] P00702_A400TileName ;
      private Guid[] P00702_A328Trn_ColId ;
      private Guid[] P00703_A407TileId ;
      private Guid[] P00703_A319Trn_RowId ;
      private string[] P00703_A400TileName ;
      private string[] P00703_A327Trn_ColName ;
      private Guid[] P00703_A328Trn_ColId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wc_colsgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00702( IGxContext context ,
                                             string AV44Wc_colsds_3_tftrn_colname_sel ,
                                             string AV43Wc_colsds_2_tftrn_colname ,
                                             string AV46Wc_colsds_5_tftilename_sel ,
                                             string AV45Wc_colsds_4_tftilename ,
                                             string A327Trn_ColName ,
                                             string A400TileName ,
                                             Guid A319Trn_RowId ,
                                             Guid AV35Trn_RowId ,
                                             Guid AV42Wc_colsds_1_trn_rowid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.TileId, T1.Trn_RowId, T1.Trn_ColName, T2.TileName, T1.Trn_ColId FROM (Trn_Col T1 INNER JOIN Trn_Tile T2 ON T2.TileId = T1.TileId)";
         AddWhere(sWhereString, "(T1.Trn_RowId = :AV42Wc_colsds_1_trn_rowid)");
         AddWhere(sWhereString, "(T1.Trn_RowId = :AV35Trn_RowId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Wc_colsds_3_tftrn_colname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Wc_colsds_2_tftrn_colname)) ) )
         {
            AddWhere(sWhereString, "(T1.Trn_ColName like :lV43Wc_colsds_2_tftrn_colname)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Wc_colsds_3_tftrn_colname_sel)) && ! ( StringUtil.StrCmp(AV44Wc_colsds_3_tftrn_colname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.Trn_ColName = ( :AV44Wc_colsds_3_tftrn_colname_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV44Wc_colsds_3_tftrn_colname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.Trn_ColName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Wc_colsds_5_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Wc_colsds_4_tftilename)) ) )
         {
            AddWhere(sWhereString, "(T2.TileName like :lV45Wc_colsds_4_tftilename)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Wc_colsds_5_tftilename_sel)) && ! ( StringUtil.StrCmp(AV46Wc_colsds_5_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.TileName = ( :AV46Wc_colsds_5_tftilename_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV46Wc_colsds_5_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.TileName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.Trn_RowId, T1.Trn_ColName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00703( IGxContext context ,
                                             string AV44Wc_colsds_3_tftrn_colname_sel ,
                                             string AV43Wc_colsds_2_tftrn_colname ,
                                             string AV46Wc_colsds_5_tftilename_sel ,
                                             string AV45Wc_colsds_4_tftilename ,
                                             string A327Trn_ColName ,
                                             string A400TileName ,
                                             Guid A319Trn_RowId ,
                                             Guid AV35Trn_RowId ,
                                             Guid AV42Wc_colsds_1_trn_rowid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.TileId, T1.Trn_RowId, T2.TileName, T1.Trn_ColName, T1.Trn_ColId FROM (Trn_Col T1 INNER JOIN Trn_Tile T2 ON T2.TileId = T1.TileId)";
         AddWhere(sWhereString, "(T1.Trn_RowId = :AV42Wc_colsds_1_trn_rowid)");
         AddWhere(sWhereString, "(T1.Trn_RowId = :AV35Trn_RowId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Wc_colsds_3_tftrn_colname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Wc_colsds_2_tftrn_colname)) ) )
         {
            AddWhere(sWhereString, "(T1.Trn_ColName like :lV43Wc_colsds_2_tftrn_colname)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Wc_colsds_3_tftrn_colname_sel)) && ! ( StringUtil.StrCmp(AV44Wc_colsds_3_tftrn_colname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.Trn_ColName = ( :AV44Wc_colsds_3_tftrn_colname_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV44Wc_colsds_3_tftrn_colname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.Trn_ColName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Wc_colsds_5_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Wc_colsds_4_tftilename)) ) )
         {
            AddWhere(sWhereString, "(T2.TileName like :lV45Wc_colsds_4_tftilename)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Wc_colsds_5_tftilename_sel)) && ! ( StringUtil.StrCmp(AV46Wc_colsds_5_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.TileName = ( :AV46Wc_colsds_5_tftilename_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV46Wc_colsds_5_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.TileName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.Trn_RowId, T2.TileName";
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
                     return conditional_P00702(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (Guid)dynConstraints[6] , (Guid)dynConstraints[7] , (Guid)dynConstraints[8] );
               case 1 :
                     return conditional_P00703(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (Guid)dynConstraints[6] , (Guid)dynConstraints[7] , (Guid)dynConstraints[8] );
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
          Object[] prmP00702;
          prmP00702 = new Object[] {
          new ParDef("AV42Wc_colsds_1_trn_rowid",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV35Trn_RowId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV43Wc_colsds_2_tftrn_colname",GXType.VarChar,100,0) ,
          new ParDef("AV44Wc_colsds_3_tftrn_colname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV45Wc_colsds_4_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV46Wc_colsds_5_tftilename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00703;
          prmP00703 = new Object[] {
          new ParDef("AV42Wc_colsds_1_trn_rowid",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV35Trn_RowId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV43Wc_colsds_2_tftrn_colname",GXType.VarChar,100,0) ,
          new ParDef("AV44Wc_colsds_3_tftrn_colname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV45Wc_colsds_4_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV46Wc_colsds_5_tftilename_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00702", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00702,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00703", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00703,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
