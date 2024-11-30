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
   public class trn_amenitywwgetfilterdata : GXProcedure
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
            return "trn_amenityww_Services_Execute" ;
         }

      }

      public trn_amenitywwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_amenitywwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_AMENITYNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADAMENITYNAMEOPTIONS' */
            S121 ();
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
         if ( StringUtil.StrCmp(AV26Session.Get("Trn_AmenityWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Trn_AmenityWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Trn_AmenityWWGridState"), null, "", "");
         }
         AV38GXV1 = 1;
         while ( AV38GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV38GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFAMENITYNAME") == 0 )
            {
               AV11TFAmenityName = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFAMENITYNAME_SEL") == 0 )
            {
               AV12TFAmenityName_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV38GXV1 = (int)(AV38GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADAMENITYNAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFAmenityName = AV15SearchTxt;
         AV12TFAmenityName_Sel = "";
         AV40Trn_amenitywwds_1_filterfulltext = AV37FilterFullText;
         AV41Trn_amenitywwds_2_tfamenityname = AV11TFAmenityName;
         AV42Trn_amenitywwds_3_tfamenityname_sel = AV12TFAmenityName_Sel;
         AV43Udparg4 = new prc_getuserlocationid(context).executeUdp( );
         AV43Udparg4 = new prc_getuserlocationid(context).executeUdp( );
         AV43Udparg4 = new prc_getuserlocationid(context).executeUdp( );
         AV43Udparg4 = new prc_getuserlocationid(context).executeUdp( );
         AV43Udparg4 = new prc_getuserlocationid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV40Trn_amenitywwds_1_filterfulltext ,
                                              AV42Trn_amenitywwds_3_tfamenityname_sel ,
                                              AV41Trn_amenitywwds_2_tfamenityname ,
                                              A40AmenityName ,
                                              A29LocationId ,
                                              AV43Udparg4 } ,
                                              new int[]{
                                              }
         });
         lV40Trn_amenitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Trn_amenitywwds_1_filterfulltext), "%", "");
         lV41Trn_amenitywwds_2_tfamenityname = StringUtil.Concat( StringUtil.RTrim( AV41Trn_amenitywwds_2_tfamenityname), "%", "");
         /* Using cursor P006H2 */
         pr_default.execute(0, new Object[] {AV43Udparg4, lV40Trn_amenitywwds_1_filterfulltext, lV41Trn_amenitywwds_2_tfamenityname, AV42Trn_amenitywwds_3_tfamenityname_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6H2 = false;
            A29LocationId = P006H2_A29LocationId[0];
            A40AmenityName = P006H2_A40AmenityName[0];
            A39AmenityId = P006H2_A39AmenityId[0];
            A11OrganisationId = P006H2_A11OrganisationId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006H2_A40AmenityName[0], A40AmenityName) == 0 ) )
            {
               BRK6H2 = false;
               A29LocationId = P006H2_A29LocationId[0];
               A39AmenityId = P006H2_A39AmenityId[0];
               A11OrganisationId = P006H2_A11OrganisationId[0];
               AV25count = (long)(AV25count+1);
               BRK6H2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A40AmenityName)) ? "<#Empty#>" : A40AmenityName);
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
            if ( ! BRK6H2 )
            {
               BRK6H2 = true;
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
         AV11TFAmenityName = "";
         AV12TFAmenityName_Sel = "";
         AV40Trn_amenitywwds_1_filterfulltext = "";
         AV41Trn_amenitywwds_2_tfamenityname = "";
         AV42Trn_amenitywwds_3_tfamenityname_sel = "";
         AV43Udparg4 = Guid.Empty;
         lV40Trn_amenitywwds_1_filterfulltext = "";
         lV41Trn_amenitywwds_2_tfamenityname = "";
         A40AmenityName = "";
         A29LocationId = Guid.Empty;
         P006H2_A29LocationId = new Guid[] {Guid.Empty} ;
         P006H2_A40AmenityName = new string[] {""} ;
         P006H2_A39AmenityId = new Guid[] {Guid.Empty} ;
         P006H2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A39AmenityId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV20Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_amenitywwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006H2_A29LocationId, P006H2_A40AmenityName, P006H2_A39AmenityId, P006H2_A11OrganisationId
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
      private bool returnInSub ;
      private bool BRK6H2 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV11TFAmenityName ;
      private string AV12TFAmenityName_Sel ;
      private string AV40Trn_amenitywwds_1_filterfulltext ;
      private string AV41Trn_amenitywwds_2_tfamenityname ;
      private string AV42Trn_amenitywwds_3_tfamenityname_sel ;
      private string lV40Trn_amenitywwds_1_filterfulltext ;
      private string lV41Trn_amenitywwds_2_tfamenityname ;
      private string A40AmenityName ;
      private string AV20Option ;
      private Guid AV43Udparg4 ;
      private Guid A29LocationId ;
      private Guid A39AmenityId ;
      private Guid A11OrganisationId ;
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
      private Guid[] P006H2_A29LocationId ;
      private string[] P006H2_A40AmenityName ;
      private Guid[] P006H2_A39AmenityId ;
      private Guid[] P006H2_A11OrganisationId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_amenitywwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006H2( IGxContext context ,
                                             string AV40Trn_amenitywwds_1_filterfulltext ,
                                             string AV42Trn_amenitywwds_3_tfamenityname_sel ,
                                             string AV41Trn_amenitywwds_2_tfamenityname ,
                                             string A40AmenityName ,
                                             Guid A29LocationId ,
                                             Guid AV43Udparg4 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT LocationId, AmenityName, AmenityId, OrganisationId FROM Trn_Amenity";
         AddWhere(sWhereString, "(LocationId = :AV43Udparg4)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Trn_amenitywwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( AmenityName like '%' || :lV40Trn_amenitywwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_amenitywwds_3_tfamenityname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Trn_amenitywwds_2_tfamenityname)) ) )
         {
            AddWhere(sWhereString, "(AmenityName like :lV41Trn_amenitywwds_2_tfamenityname)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_amenitywwds_3_tfamenityname_sel)) && ! ( StringUtil.StrCmp(AV42Trn_amenitywwds_3_tfamenityname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(AmenityName = ( :AV42Trn_amenitywwds_3_tfamenityname_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV42Trn_amenitywwds_3_tfamenityname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AmenityName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AmenityName";
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
                     return conditional_P006H2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (Guid)dynConstraints[4] , (Guid)dynConstraints[5] );
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
          Object[] prmP006H2;
          prmP006H2 = new Object[] {
          new ParDef("AV43Udparg4",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV40Trn_amenitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Trn_amenitywwds_2_tfamenityname",GXType.VarChar,100,0) ,
          new ParDef("AV42Trn_amenitywwds_3_tfamenityname_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006H2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
