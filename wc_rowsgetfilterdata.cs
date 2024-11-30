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
   public class wc_rowsgetfilterdata : GXProcedure
   {
      public wc_rowsgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wc_rowsgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_TRN_ROWNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADTRN_ROWNAMEOPTIONS' */
            S121 ();
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
         if ( StringUtil.StrCmp(AV24Session.Get("WC_RowsGridState"), "") == 0 )
         {
            AV26GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WC_RowsGridState"), null, "", "");
         }
         else
         {
            AV26GridState.FromXml(AV24Session.Get("WC_RowsGridState"), null, "", "");
         }
         AV35GXV1 = 1;
         while ( AV35GXV1 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV35GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_ROWNAME") == 0 )
            {
               AV11TFTrn_RowName = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_ROWNAME_SEL") == 0 )
            {
               AV12TFTrn_RowName_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            AV35GXV1 = (int)(AV35GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTRN_ROWNAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFTrn_RowName = AV13SearchTxt;
         AV12TFTrn_RowName_Sel = "";
         AV37Wc_rowsds_1_tftrn_rowname = AV11TFTrn_RowName;
         AV38Wc_rowsds_2_tftrn_rowname_sel = AV12TFTrn_RowName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV38Wc_rowsds_2_tftrn_rowname_sel ,
                                              AV37Wc_rowsds_1_tftrn_rowname ,
                                              A320Trn_RowName } ,
                                              new int[]{
                                              }
         });
         lV37Wc_rowsds_1_tftrn_rowname = StringUtil.Concat( StringUtil.RTrim( AV37Wc_rowsds_1_tftrn_rowname), "%", "");
         /* Using cursor P006Z2 */
         pr_default.execute(0, new Object[] {lV37Wc_rowsds_1_tftrn_rowname, AV38Wc_rowsds_2_tftrn_rowname_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6Z2 = false;
            A320Trn_RowName = P006Z2_A320Trn_RowName[0];
            A319Trn_RowId = P006Z2_A319Trn_RowId[0];
            AV23count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006Z2_A320Trn_RowName[0], A320Trn_RowName) == 0 ) )
            {
               BRK6Z2 = false;
               A319Trn_RowId = P006Z2_A319Trn_RowId[0];
               AV23count = (long)(AV23count+1);
               BRK6Z2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV14SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A320Trn_RowName)) ? "<#Empty#>" : A320Trn_RowName);
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
            if ( ! BRK6Z2 )
            {
               BRK6Z2 = true;
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
         AV11TFTrn_RowName = "";
         AV12TFTrn_RowName_Sel = "";
         AV37Wc_rowsds_1_tftrn_rowname = "";
         AV38Wc_rowsds_2_tftrn_rowname_sel = "";
         lV37Wc_rowsds_1_tftrn_rowname = "";
         A320Trn_RowName = "";
         P006Z2_A320Trn_RowName = new string[] {""} ;
         P006Z2_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         A319Trn_RowId = Guid.Empty;
         AV18Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wc_rowsgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006Z2_A320Trn_RowName, P006Z2_A319Trn_RowId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MaxItems ;
      private short AV15PageIndex ;
      private short AV14SkipItems ;
      private int AV35GXV1 ;
      private long AV23count ;
      private bool returnInSub ;
      private bool BRK6Z2 ;
      private string AV32OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string AV29DDOName ;
      private string AV30SearchTxtParms ;
      private string AV31SearchTxtTo ;
      private string AV13SearchTxt ;
      private string AV11TFTrn_RowName ;
      private string AV12TFTrn_RowName_Sel ;
      private string AV37Wc_rowsds_1_tftrn_rowname ;
      private string AV38Wc_rowsds_2_tftrn_rowname_sel ;
      private string lV37Wc_rowsds_1_tftrn_rowname ;
      private string A320Trn_RowName ;
      private string AV18Option ;
      private Guid A319Trn_RowId ;
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
      private string[] P006Z2_A320Trn_RowName ;
      private Guid[] P006Z2_A319Trn_RowId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wc_rowsgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006Z2( IGxContext context ,
                                             string AV38Wc_rowsds_2_tftrn_rowname_sel ,
                                             string AV37Wc_rowsds_1_tftrn_rowname ,
                                             string A320Trn_RowName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT Trn_RowName, Trn_RowId FROM Trn_Row";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38Wc_rowsds_2_tftrn_rowname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37Wc_rowsds_1_tftrn_rowname)) ) )
         {
            AddWhere(sWhereString, "(Trn_RowName like :lV37Wc_rowsds_1_tftrn_rowname)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38Wc_rowsds_2_tftrn_rowname_sel)) && ! ( StringUtil.StrCmp(AV38Wc_rowsds_2_tftrn_rowname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_RowName = ( :AV38Wc_rowsds_2_tftrn_rowname_sel))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( StringUtil.StrCmp(AV38Wc_rowsds_2_tftrn_rowname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_RowName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Trn_RowName";
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
                     return conditional_P006Z2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] );
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
          Object[] prmP006Z2;
          prmP006Z2 = new Object[] {
          new ParDef("lV37Wc_rowsds_1_tftrn_rowname",GXType.VarChar,100,0) ,
          new ParDef("AV38Wc_rowsds_2_tftrn_rowname_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Z2,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
       }
    }

 }

}
