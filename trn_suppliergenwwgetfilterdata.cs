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
   public class trn_suppliergenwwgetfilterdata : GXProcedure
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
            return "trn_suppliergenww_Services_Execute" ;
         }

      }

      public trn_suppliergenwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_suppliergenwwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_SUPPLIERGENCOMPANYNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERGENCOMPANYNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_SUPPLIERGENTYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERGENTYPENAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_SUPPLIERGENCONTACTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERGENCONTACTNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_SUPPLIERGENCONTACTPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERGENCONTACTPHONEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_SUPPLIERGENWEBSITE") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERGENWEBSITEOPTIONS' */
            S161 ();
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
         if ( StringUtil.StrCmp(AV32Session.Get("Trn_SupplierGenWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Trn_SupplierGenWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("Trn_SupplierGenWWGridState"), null, "", "");
         }
         AV61GXV1 = 1;
         while ( AV61GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV61GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCOMPANYNAME") == 0 )
            {
               AV15TFSupplierGenCompanyName = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCOMPANYNAME_SEL") == 0 )
            {
               AV16TFSupplierGenCompanyName_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENTYPENAME") == 0 )
            {
               AV13TFSupplierGenTypeName = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENTYPENAME_SEL") == 0 )
            {
               AV14TFSupplierGenTypeName_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCONTACTNAME") == 0 )
            {
               AV17TFSupplierGenContactName = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCONTACTNAME_SEL") == 0 )
            {
               AV18TFSupplierGenContactName_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCONTACTPHONE") == 0 )
            {
               AV19TFSupplierGenContactPhone = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCONTACTPHONE_SEL") == 0 )
            {
               AV20TFSupplierGenContactPhone_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENWEBSITE") == 0 )
            {
               AV57TFSupplierGenWebsite = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENWEBSITE_SEL") == 0 )
            {
               AV58TFSupplierGenWebsite_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV61GXV1 = (int)(AV61GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSUPPLIERGENCOMPANYNAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFSupplierGenCompanyName = AV21SearchTxt;
         AV16TFSupplierGenCompanyName_Sel = "";
         AV63Trn_suppliergenwwds_1_filterfulltext = AV43FilterFullText;
         AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname = AV15TFSupplierGenCompanyName;
         AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel = AV16TFSupplierGenCompanyName_Sel;
         AV66Trn_suppliergenwwds_4_tfsuppliergentypename = AV13TFSupplierGenTypeName;
         AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel = AV14TFSupplierGenTypeName_Sel;
         AV68Trn_suppliergenwwds_6_tfsuppliergencontactname = AV17TFSupplierGenContactName;
         AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel = AV18TFSupplierGenContactName_Sel;
         AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone = AV19TFSupplierGenContactPhone;
         AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel = AV20TFSupplierGenContactPhone_Sel;
         AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite = AV57TFSupplierGenWebsite;
         AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel = AV58TFSupplierGenWebsite_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV63Trn_suppliergenwwds_1_filterfulltext ,
                                              AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel ,
                                              AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname ,
                                              AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel ,
                                              AV66Trn_suppliergenwwds_4_tfsuppliergentypename ,
                                              AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel ,
                                              AV68Trn_suppliergenwwds_6_tfsuppliergencontactname ,
                                              AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel ,
                                              AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone ,
                                              AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel ,
                                              AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite ,
                                              A44SupplierGenCompanyName ,
                                              A290SupplierGenTypeName ,
                                              A47SupplierGenContactName ,
                                              A48SupplierGenContactPhone ,
                                              A441SupplierGenWebsite ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname), "%", "");
         lV66Trn_suppliergenwwds_4_tfsuppliergentypename = StringUtil.Concat( StringUtil.RTrim( AV66Trn_suppliergenwwds_4_tfsuppliergentypename), "%", "");
         lV68Trn_suppliergenwwds_6_tfsuppliergencontactname = StringUtil.Concat( StringUtil.RTrim( AV68Trn_suppliergenwwds_6_tfsuppliergencontactname), "%", "");
         lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone = StringUtil.PadR( StringUtil.RTrim( AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone), 20, "%");
         lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite = StringUtil.Concat( StringUtil.RTrim( AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite), "%", "");
         /* Using cursor P006I2 */
         pr_default.execute(0, new Object[] {lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname, AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, lV66Trn_suppliergenwwds_4_tfsuppliergentypename, AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel, lV68Trn_suppliergenwwds_6_tfsuppliergencontactname, AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone, AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite, AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6I2 = false;
            A282SupplierGenTypeId = P006I2_A282SupplierGenTypeId[0];
            A44SupplierGenCompanyName = P006I2_A44SupplierGenCompanyName[0];
            A11OrganisationId = P006I2_A11OrganisationId[0];
            n11OrganisationId = P006I2_n11OrganisationId[0];
            A441SupplierGenWebsite = P006I2_A441SupplierGenWebsite[0];
            A48SupplierGenContactPhone = P006I2_A48SupplierGenContactPhone[0];
            A47SupplierGenContactName = P006I2_A47SupplierGenContactName[0];
            A290SupplierGenTypeName = P006I2_A290SupplierGenTypeName[0];
            A42SupplierGenId = P006I2_A42SupplierGenId[0];
            A290SupplierGenTypeName = P006I2_A290SupplierGenTypeName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006I2_A44SupplierGenCompanyName[0], A44SupplierGenCompanyName) == 0 ) )
            {
               BRK6I2 = false;
               A42SupplierGenId = P006I2_A42SupplierGenId[0];
               AV31count = (long)(AV31count+1);
               BRK6I2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A44SupplierGenCompanyName)) ? "<#Empty#>" : A44SupplierGenCompanyName);
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
            if ( ! BRK6I2 )
            {
               BRK6I2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSUPPLIERGENTYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFSupplierGenTypeName = AV21SearchTxt;
         AV14TFSupplierGenTypeName_Sel = "";
         AV63Trn_suppliergenwwds_1_filterfulltext = AV43FilterFullText;
         AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname = AV15TFSupplierGenCompanyName;
         AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel = AV16TFSupplierGenCompanyName_Sel;
         AV66Trn_suppliergenwwds_4_tfsuppliergentypename = AV13TFSupplierGenTypeName;
         AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel = AV14TFSupplierGenTypeName_Sel;
         AV68Trn_suppliergenwwds_6_tfsuppliergencontactname = AV17TFSupplierGenContactName;
         AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel = AV18TFSupplierGenContactName_Sel;
         AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone = AV19TFSupplierGenContactPhone;
         AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel = AV20TFSupplierGenContactPhone_Sel;
         AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite = AV57TFSupplierGenWebsite;
         AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel = AV58TFSupplierGenWebsite_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV63Trn_suppliergenwwds_1_filterfulltext ,
                                              AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel ,
                                              AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname ,
                                              AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel ,
                                              AV66Trn_suppliergenwwds_4_tfsuppliergentypename ,
                                              AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel ,
                                              AV68Trn_suppliergenwwds_6_tfsuppliergencontactname ,
                                              AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel ,
                                              AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone ,
                                              AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel ,
                                              AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite ,
                                              A44SupplierGenCompanyName ,
                                              A290SupplierGenTypeName ,
                                              A47SupplierGenContactName ,
                                              A48SupplierGenContactPhone ,
                                              A441SupplierGenWebsite ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname), "%", "");
         lV66Trn_suppliergenwwds_4_tfsuppliergentypename = StringUtil.Concat( StringUtil.RTrim( AV66Trn_suppliergenwwds_4_tfsuppliergentypename), "%", "");
         lV68Trn_suppliergenwwds_6_tfsuppliergencontactname = StringUtil.Concat( StringUtil.RTrim( AV68Trn_suppliergenwwds_6_tfsuppliergencontactname), "%", "");
         lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone = StringUtil.PadR( StringUtil.RTrim( AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone), 20, "%");
         lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite = StringUtil.Concat( StringUtil.RTrim( AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite), "%", "");
         /* Using cursor P006I3 */
         pr_default.execute(1, new Object[] {lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname, AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, lV66Trn_suppliergenwwds_4_tfsuppliergentypename, AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel, lV68Trn_suppliergenwwds_6_tfsuppliergencontactname, AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone, AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite, AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6I4 = false;
            A282SupplierGenTypeId = P006I3_A282SupplierGenTypeId[0];
            A11OrganisationId = P006I3_A11OrganisationId[0];
            n11OrganisationId = P006I3_n11OrganisationId[0];
            A441SupplierGenWebsite = P006I3_A441SupplierGenWebsite[0];
            A48SupplierGenContactPhone = P006I3_A48SupplierGenContactPhone[0];
            A47SupplierGenContactName = P006I3_A47SupplierGenContactName[0];
            A290SupplierGenTypeName = P006I3_A290SupplierGenTypeName[0];
            A44SupplierGenCompanyName = P006I3_A44SupplierGenCompanyName[0];
            A42SupplierGenId = P006I3_A42SupplierGenId[0];
            A290SupplierGenTypeName = P006I3_A290SupplierGenTypeName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P006I3_A282SupplierGenTypeId[0] == A282SupplierGenTypeId ) )
            {
               BRK6I4 = false;
               A42SupplierGenId = P006I3_A42SupplierGenId[0];
               AV31count = (long)(AV31count+1);
               BRK6I4 = true;
               pr_default.readNext(1);
            }
            AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A290SupplierGenTypeName)) ? "<#Empty#>" : A290SupplierGenTypeName);
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
            if ( ! BRK6I4 )
            {
               BRK6I4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV22SkipItems > 0 )
         {
            AV27Options.RemoveItem(1);
            AV30OptionIndexes.RemoveItem(1);
            AV22SkipItems = (short)(AV22SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADSUPPLIERGENCONTACTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV17TFSupplierGenContactName = AV21SearchTxt;
         AV18TFSupplierGenContactName_Sel = "";
         AV63Trn_suppliergenwwds_1_filterfulltext = AV43FilterFullText;
         AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname = AV15TFSupplierGenCompanyName;
         AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel = AV16TFSupplierGenCompanyName_Sel;
         AV66Trn_suppliergenwwds_4_tfsuppliergentypename = AV13TFSupplierGenTypeName;
         AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel = AV14TFSupplierGenTypeName_Sel;
         AV68Trn_suppliergenwwds_6_tfsuppliergencontactname = AV17TFSupplierGenContactName;
         AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel = AV18TFSupplierGenContactName_Sel;
         AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone = AV19TFSupplierGenContactPhone;
         AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel = AV20TFSupplierGenContactPhone_Sel;
         AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite = AV57TFSupplierGenWebsite;
         AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel = AV58TFSupplierGenWebsite_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV63Trn_suppliergenwwds_1_filterfulltext ,
                                              AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel ,
                                              AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname ,
                                              AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel ,
                                              AV66Trn_suppliergenwwds_4_tfsuppliergentypename ,
                                              AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel ,
                                              AV68Trn_suppliergenwwds_6_tfsuppliergencontactname ,
                                              AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel ,
                                              AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone ,
                                              AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel ,
                                              AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite ,
                                              A44SupplierGenCompanyName ,
                                              A290SupplierGenTypeName ,
                                              A47SupplierGenContactName ,
                                              A48SupplierGenContactPhone ,
                                              A441SupplierGenWebsite ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname), "%", "");
         lV66Trn_suppliergenwwds_4_tfsuppliergentypename = StringUtil.Concat( StringUtil.RTrim( AV66Trn_suppliergenwwds_4_tfsuppliergentypename), "%", "");
         lV68Trn_suppliergenwwds_6_tfsuppliergencontactname = StringUtil.Concat( StringUtil.RTrim( AV68Trn_suppliergenwwds_6_tfsuppliergencontactname), "%", "");
         lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone = StringUtil.PadR( StringUtil.RTrim( AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone), 20, "%");
         lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite = StringUtil.Concat( StringUtil.RTrim( AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite), "%", "");
         /* Using cursor P006I4 */
         pr_default.execute(2, new Object[] {lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname, AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, lV66Trn_suppliergenwwds_4_tfsuppliergentypename, AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel, lV68Trn_suppliergenwwds_6_tfsuppliergencontactname, AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone, AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite, AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6I6 = false;
            A282SupplierGenTypeId = P006I4_A282SupplierGenTypeId[0];
            A47SupplierGenContactName = P006I4_A47SupplierGenContactName[0];
            A11OrganisationId = P006I4_A11OrganisationId[0];
            n11OrganisationId = P006I4_n11OrganisationId[0];
            A441SupplierGenWebsite = P006I4_A441SupplierGenWebsite[0];
            A48SupplierGenContactPhone = P006I4_A48SupplierGenContactPhone[0];
            A290SupplierGenTypeName = P006I4_A290SupplierGenTypeName[0];
            A44SupplierGenCompanyName = P006I4_A44SupplierGenCompanyName[0];
            A42SupplierGenId = P006I4_A42SupplierGenId[0];
            A290SupplierGenTypeName = P006I4_A290SupplierGenTypeName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006I4_A47SupplierGenContactName[0], A47SupplierGenContactName) == 0 ) )
            {
               BRK6I6 = false;
               A42SupplierGenId = P006I4_A42SupplierGenId[0];
               AV31count = (long)(AV31count+1);
               BRK6I6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A47SupplierGenContactName)) ? "<#Empty#>" : A47SupplierGenContactName);
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
            if ( ! BRK6I6 )
            {
               BRK6I6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADSUPPLIERGENCONTACTPHONEOPTIONS' Routine */
         returnInSub = false;
         AV19TFSupplierGenContactPhone = AV21SearchTxt;
         AV20TFSupplierGenContactPhone_Sel = "";
         AV63Trn_suppliergenwwds_1_filterfulltext = AV43FilterFullText;
         AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname = AV15TFSupplierGenCompanyName;
         AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel = AV16TFSupplierGenCompanyName_Sel;
         AV66Trn_suppliergenwwds_4_tfsuppliergentypename = AV13TFSupplierGenTypeName;
         AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel = AV14TFSupplierGenTypeName_Sel;
         AV68Trn_suppliergenwwds_6_tfsuppliergencontactname = AV17TFSupplierGenContactName;
         AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel = AV18TFSupplierGenContactName_Sel;
         AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone = AV19TFSupplierGenContactPhone;
         AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel = AV20TFSupplierGenContactPhone_Sel;
         AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite = AV57TFSupplierGenWebsite;
         AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel = AV58TFSupplierGenWebsite_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV63Trn_suppliergenwwds_1_filterfulltext ,
                                              AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel ,
                                              AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname ,
                                              AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel ,
                                              AV66Trn_suppliergenwwds_4_tfsuppliergentypename ,
                                              AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel ,
                                              AV68Trn_suppliergenwwds_6_tfsuppliergencontactname ,
                                              AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel ,
                                              AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone ,
                                              AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel ,
                                              AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite ,
                                              A44SupplierGenCompanyName ,
                                              A290SupplierGenTypeName ,
                                              A47SupplierGenContactName ,
                                              A48SupplierGenContactPhone ,
                                              A441SupplierGenWebsite ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname), "%", "");
         lV66Trn_suppliergenwwds_4_tfsuppliergentypename = StringUtil.Concat( StringUtil.RTrim( AV66Trn_suppliergenwwds_4_tfsuppliergentypename), "%", "");
         lV68Trn_suppliergenwwds_6_tfsuppliergencontactname = StringUtil.Concat( StringUtil.RTrim( AV68Trn_suppliergenwwds_6_tfsuppliergencontactname), "%", "");
         lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone = StringUtil.PadR( StringUtil.RTrim( AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone), 20, "%");
         lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite = StringUtil.Concat( StringUtil.RTrim( AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite), "%", "");
         /* Using cursor P006I5 */
         pr_default.execute(3, new Object[] {lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname, AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, lV66Trn_suppliergenwwds_4_tfsuppliergentypename, AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel, lV68Trn_suppliergenwwds_6_tfsuppliergencontactname, AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone, AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite, AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK6I8 = false;
            A282SupplierGenTypeId = P006I5_A282SupplierGenTypeId[0];
            A48SupplierGenContactPhone = P006I5_A48SupplierGenContactPhone[0];
            A11OrganisationId = P006I5_A11OrganisationId[0];
            n11OrganisationId = P006I5_n11OrganisationId[0];
            A441SupplierGenWebsite = P006I5_A441SupplierGenWebsite[0];
            A47SupplierGenContactName = P006I5_A47SupplierGenContactName[0];
            A290SupplierGenTypeName = P006I5_A290SupplierGenTypeName[0];
            A44SupplierGenCompanyName = P006I5_A44SupplierGenCompanyName[0];
            A42SupplierGenId = P006I5_A42SupplierGenId[0];
            A290SupplierGenTypeName = P006I5_A290SupplierGenTypeName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P006I5_A48SupplierGenContactPhone[0], A48SupplierGenContactPhone) == 0 ) )
            {
               BRK6I8 = false;
               A42SupplierGenId = P006I5_A42SupplierGenId[0];
               AV31count = (long)(AV31count+1);
               BRK6I8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A48SupplierGenContactPhone)) ? "<#Empty#>" : A48SupplierGenContactPhone);
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
            if ( ! BRK6I8 )
            {
               BRK6I8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADSUPPLIERGENWEBSITEOPTIONS' Routine */
         returnInSub = false;
         AV57TFSupplierGenWebsite = AV21SearchTxt;
         AV58TFSupplierGenWebsite_Sel = "";
         AV63Trn_suppliergenwwds_1_filterfulltext = AV43FilterFullText;
         AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname = AV15TFSupplierGenCompanyName;
         AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel = AV16TFSupplierGenCompanyName_Sel;
         AV66Trn_suppliergenwwds_4_tfsuppliergentypename = AV13TFSupplierGenTypeName;
         AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel = AV14TFSupplierGenTypeName_Sel;
         AV68Trn_suppliergenwwds_6_tfsuppliergencontactname = AV17TFSupplierGenContactName;
         AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel = AV18TFSupplierGenContactName_Sel;
         AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone = AV19TFSupplierGenContactPhone;
         AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel = AV20TFSupplierGenContactPhone_Sel;
         AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite = AV57TFSupplierGenWebsite;
         AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel = AV58TFSupplierGenWebsite_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV63Trn_suppliergenwwds_1_filterfulltext ,
                                              AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel ,
                                              AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname ,
                                              AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel ,
                                              AV66Trn_suppliergenwwds_4_tfsuppliergentypename ,
                                              AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel ,
                                              AV68Trn_suppliergenwwds_6_tfsuppliergencontactname ,
                                              AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel ,
                                              AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone ,
                                              AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel ,
                                              AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite ,
                                              A44SupplierGenCompanyName ,
                                              A290SupplierGenTypeName ,
                                              A47SupplierGenContactName ,
                                              A48SupplierGenContactPhone ,
                                              A441SupplierGenWebsite ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV63Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname), "%", "");
         lV66Trn_suppliergenwwds_4_tfsuppliergentypename = StringUtil.Concat( StringUtil.RTrim( AV66Trn_suppliergenwwds_4_tfsuppliergentypename), "%", "");
         lV68Trn_suppliergenwwds_6_tfsuppliergencontactname = StringUtil.Concat( StringUtil.RTrim( AV68Trn_suppliergenwwds_6_tfsuppliergencontactname), "%", "");
         lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone = StringUtil.PadR( StringUtil.RTrim( AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone), 20, "%");
         lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite = StringUtil.Concat( StringUtil.RTrim( AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite), "%", "");
         /* Using cursor P006I6 */
         pr_default.execute(4, new Object[] {lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV63Trn_suppliergenwwds_1_filterfulltext, lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname, AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, lV66Trn_suppliergenwwds_4_tfsuppliergentypename, AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel, lV68Trn_suppliergenwwds_6_tfsuppliergencontactname, AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone, AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite, AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK6I10 = false;
            A282SupplierGenTypeId = P006I6_A282SupplierGenTypeId[0];
            A441SupplierGenWebsite = P006I6_A441SupplierGenWebsite[0];
            A11OrganisationId = P006I6_A11OrganisationId[0];
            n11OrganisationId = P006I6_n11OrganisationId[0];
            A48SupplierGenContactPhone = P006I6_A48SupplierGenContactPhone[0];
            A47SupplierGenContactName = P006I6_A47SupplierGenContactName[0];
            A290SupplierGenTypeName = P006I6_A290SupplierGenTypeName[0];
            A44SupplierGenCompanyName = P006I6_A44SupplierGenCompanyName[0];
            A42SupplierGenId = P006I6_A42SupplierGenId[0];
            A290SupplierGenTypeName = P006I6_A290SupplierGenTypeName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P006I6_A441SupplierGenWebsite[0], A441SupplierGenWebsite) == 0 ) )
            {
               BRK6I10 = false;
               A42SupplierGenId = P006I6_A42SupplierGenId[0];
               AV31count = (long)(AV31count+1);
               BRK6I10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A441SupplierGenWebsite)) ? "<#Empty#>" : A441SupplierGenWebsite);
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
            if ( ! BRK6I10 )
            {
               BRK6I10 = true;
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
         AV15TFSupplierGenCompanyName = "";
         AV16TFSupplierGenCompanyName_Sel = "";
         AV13TFSupplierGenTypeName = "";
         AV14TFSupplierGenTypeName_Sel = "";
         AV17TFSupplierGenContactName = "";
         AV18TFSupplierGenContactName_Sel = "";
         AV19TFSupplierGenContactPhone = "";
         AV20TFSupplierGenContactPhone_Sel = "";
         AV57TFSupplierGenWebsite = "";
         AV58TFSupplierGenWebsite_Sel = "";
         AV63Trn_suppliergenwwds_1_filterfulltext = "";
         AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname = "";
         AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel = "";
         AV66Trn_suppliergenwwds_4_tfsuppliergentypename = "";
         AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel = "";
         AV68Trn_suppliergenwwds_6_tfsuppliergencontactname = "";
         AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel = "";
         AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone = "";
         AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel = "";
         AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite = "";
         AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel = "";
         lV63Trn_suppliergenwwds_1_filterfulltext = "";
         lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname = "";
         lV66Trn_suppliergenwwds_4_tfsuppliergentypename = "";
         lV68Trn_suppliergenwwds_6_tfsuppliergencontactname = "";
         lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone = "";
         lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite = "";
         A44SupplierGenCompanyName = "";
         A290SupplierGenTypeName = "";
         A47SupplierGenContactName = "";
         A48SupplierGenContactPhone = "";
         A441SupplierGenWebsite = "";
         A11OrganisationId = Guid.Empty;
         P006I2_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         P006I2_A44SupplierGenCompanyName = new string[] {""} ;
         P006I2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006I2_n11OrganisationId = new bool[] {false} ;
         P006I2_A441SupplierGenWebsite = new string[] {""} ;
         P006I2_A48SupplierGenContactPhone = new string[] {""} ;
         P006I2_A47SupplierGenContactName = new string[] {""} ;
         P006I2_A290SupplierGenTypeName = new string[] {""} ;
         P006I2_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         A282SupplierGenTypeId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         AV26Option = "";
         P006I3_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         P006I3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006I3_n11OrganisationId = new bool[] {false} ;
         P006I3_A441SupplierGenWebsite = new string[] {""} ;
         P006I3_A48SupplierGenContactPhone = new string[] {""} ;
         P006I3_A47SupplierGenContactName = new string[] {""} ;
         P006I3_A290SupplierGenTypeName = new string[] {""} ;
         P006I3_A44SupplierGenCompanyName = new string[] {""} ;
         P006I3_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P006I4_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         P006I4_A47SupplierGenContactName = new string[] {""} ;
         P006I4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006I4_n11OrganisationId = new bool[] {false} ;
         P006I4_A441SupplierGenWebsite = new string[] {""} ;
         P006I4_A48SupplierGenContactPhone = new string[] {""} ;
         P006I4_A290SupplierGenTypeName = new string[] {""} ;
         P006I4_A44SupplierGenCompanyName = new string[] {""} ;
         P006I4_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P006I5_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         P006I5_A48SupplierGenContactPhone = new string[] {""} ;
         P006I5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006I5_n11OrganisationId = new bool[] {false} ;
         P006I5_A441SupplierGenWebsite = new string[] {""} ;
         P006I5_A47SupplierGenContactName = new string[] {""} ;
         P006I5_A290SupplierGenTypeName = new string[] {""} ;
         P006I5_A44SupplierGenCompanyName = new string[] {""} ;
         P006I5_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P006I6_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         P006I6_A441SupplierGenWebsite = new string[] {""} ;
         P006I6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006I6_n11OrganisationId = new bool[] {false} ;
         P006I6_A48SupplierGenContactPhone = new string[] {""} ;
         P006I6_A47SupplierGenContactName = new string[] {""} ;
         P006I6_A290SupplierGenTypeName = new string[] {""} ;
         P006I6_A44SupplierGenCompanyName = new string[] {""} ;
         P006I6_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergenwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006I2_A282SupplierGenTypeId, P006I2_A44SupplierGenCompanyName, P006I2_A11OrganisationId, P006I2_n11OrganisationId, P006I2_A441SupplierGenWebsite, P006I2_A48SupplierGenContactPhone, P006I2_A47SupplierGenContactName, P006I2_A290SupplierGenTypeName, P006I2_A42SupplierGenId
               }
               , new Object[] {
               P006I3_A282SupplierGenTypeId, P006I3_A11OrganisationId, P006I3_n11OrganisationId, P006I3_A441SupplierGenWebsite, P006I3_A48SupplierGenContactPhone, P006I3_A47SupplierGenContactName, P006I3_A290SupplierGenTypeName, P006I3_A44SupplierGenCompanyName, P006I3_A42SupplierGenId
               }
               , new Object[] {
               P006I4_A282SupplierGenTypeId, P006I4_A47SupplierGenContactName, P006I4_A11OrganisationId, P006I4_n11OrganisationId, P006I4_A441SupplierGenWebsite, P006I4_A48SupplierGenContactPhone, P006I4_A290SupplierGenTypeName, P006I4_A44SupplierGenCompanyName, P006I4_A42SupplierGenId
               }
               , new Object[] {
               P006I5_A282SupplierGenTypeId, P006I5_A48SupplierGenContactPhone, P006I5_A11OrganisationId, P006I5_n11OrganisationId, P006I5_A441SupplierGenWebsite, P006I5_A47SupplierGenContactName, P006I5_A290SupplierGenTypeName, P006I5_A44SupplierGenCompanyName, P006I5_A42SupplierGenId
               }
               , new Object[] {
               P006I6_A282SupplierGenTypeId, P006I6_A441SupplierGenWebsite, P006I6_A11OrganisationId, P006I6_n11OrganisationId, P006I6_A48SupplierGenContactPhone, P006I6_A47SupplierGenContactName, P006I6_A290SupplierGenTypeName, P006I6_A44SupplierGenCompanyName, P006I6_A42SupplierGenId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24MaxItems ;
      private short AV23PageIndex ;
      private short AV22SkipItems ;
      private int AV61GXV1 ;
      private int AV25InsertIndex ;
      private long AV31count ;
      private string AV19TFSupplierGenContactPhone ;
      private string AV20TFSupplierGenContactPhone_Sel ;
      private string AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone ;
      private string AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel ;
      private string lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone ;
      private string A48SupplierGenContactPhone ;
      private bool returnInSub ;
      private bool BRK6I2 ;
      private bool n11OrganisationId ;
      private bool BRK6I4 ;
      private bool BRK6I6 ;
      private bool BRK6I8 ;
      private bool BRK6I10 ;
      private string AV40OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV42OptionIndexesJson ;
      private string AV37DDOName ;
      private string AV38SearchTxtParms ;
      private string AV39SearchTxtTo ;
      private string AV21SearchTxt ;
      private string AV43FilterFullText ;
      private string AV15TFSupplierGenCompanyName ;
      private string AV16TFSupplierGenCompanyName_Sel ;
      private string AV13TFSupplierGenTypeName ;
      private string AV14TFSupplierGenTypeName_Sel ;
      private string AV17TFSupplierGenContactName ;
      private string AV18TFSupplierGenContactName_Sel ;
      private string AV57TFSupplierGenWebsite ;
      private string AV58TFSupplierGenWebsite_Sel ;
      private string AV63Trn_suppliergenwwds_1_filterfulltext ;
      private string AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname ;
      private string AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel ;
      private string AV66Trn_suppliergenwwds_4_tfsuppliergentypename ;
      private string AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel ;
      private string AV68Trn_suppliergenwwds_6_tfsuppliergencontactname ;
      private string AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel ;
      private string AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite ;
      private string AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel ;
      private string lV63Trn_suppliergenwwds_1_filterfulltext ;
      private string lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname ;
      private string lV66Trn_suppliergenwwds_4_tfsuppliergentypename ;
      private string lV68Trn_suppliergenwwds_6_tfsuppliergencontactname ;
      private string lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite ;
      private string A44SupplierGenCompanyName ;
      private string A290SupplierGenTypeName ;
      private string A47SupplierGenContactName ;
      private string A441SupplierGenWebsite ;
      private string AV26Option ;
      private Guid A11OrganisationId ;
      private Guid A282SupplierGenTypeId ;
      private Guid A42SupplierGenId ;
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
      private Guid[] P006I2_A282SupplierGenTypeId ;
      private string[] P006I2_A44SupplierGenCompanyName ;
      private Guid[] P006I2_A11OrganisationId ;
      private bool[] P006I2_n11OrganisationId ;
      private string[] P006I2_A441SupplierGenWebsite ;
      private string[] P006I2_A48SupplierGenContactPhone ;
      private string[] P006I2_A47SupplierGenContactName ;
      private string[] P006I2_A290SupplierGenTypeName ;
      private Guid[] P006I2_A42SupplierGenId ;
      private Guid[] P006I3_A282SupplierGenTypeId ;
      private Guid[] P006I3_A11OrganisationId ;
      private bool[] P006I3_n11OrganisationId ;
      private string[] P006I3_A441SupplierGenWebsite ;
      private string[] P006I3_A48SupplierGenContactPhone ;
      private string[] P006I3_A47SupplierGenContactName ;
      private string[] P006I3_A290SupplierGenTypeName ;
      private string[] P006I3_A44SupplierGenCompanyName ;
      private Guid[] P006I3_A42SupplierGenId ;
      private Guid[] P006I4_A282SupplierGenTypeId ;
      private string[] P006I4_A47SupplierGenContactName ;
      private Guid[] P006I4_A11OrganisationId ;
      private bool[] P006I4_n11OrganisationId ;
      private string[] P006I4_A441SupplierGenWebsite ;
      private string[] P006I4_A48SupplierGenContactPhone ;
      private string[] P006I4_A290SupplierGenTypeName ;
      private string[] P006I4_A44SupplierGenCompanyName ;
      private Guid[] P006I4_A42SupplierGenId ;
      private Guid[] P006I5_A282SupplierGenTypeId ;
      private string[] P006I5_A48SupplierGenContactPhone ;
      private Guid[] P006I5_A11OrganisationId ;
      private bool[] P006I5_n11OrganisationId ;
      private string[] P006I5_A441SupplierGenWebsite ;
      private string[] P006I5_A47SupplierGenContactName ;
      private string[] P006I5_A290SupplierGenTypeName ;
      private string[] P006I5_A44SupplierGenCompanyName ;
      private Guid[] P006I5_A42SupplierGenId ;
      private Guid[] P006I6_A282SupplierGenTypeId ;
      private string[] P006I6_A441SupplierGenWebsite ;
      private Guid[] P006I6_A11OrganisationId ;
      private bool[] P006I6_n11OrganisationId ;
      private string[] P006I6_A48SupplierGenContactPhone ;
      private string[] P006I6_A47SupplierGenContactName ;
      private string[] P006I6_A290SupplierGenTypeName ;
      private string[] P006I6_A44SupplierGenCompanyName ;
      private Guid[] P006I6_A42SupplierGenId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_suppliergenwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006I2( IGxContext context ,
                                             string AV63Trn_suppliergenwwds_1_filterfulltext ,
                                             string AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel ,
                                             string AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname ,
                                             string AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel ,
                                             string AV66Trn_suppliergenwwds_4_tfsuppliergentypename ,
                                             string AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel ,
                                             string AV68Trn_suppliergenwwds_6_tfsuppliergencontactname ,
                                             string AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel ,
                                             string AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone ,
                                             string AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel ,
                                             string AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite ,
                                             string A44SupplierGenCompanyName ,
                                             string A290SupplierGenTypeName ,
                                             string A47SupplierGenContactName ,
                                             string A48SupplierGenContactPhone ,
                                             string A441SupplierGenWebsite ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[15];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SupplierGenTypeId, T1.SupplierGenCompanyName, T1.OrganisationId, T1.SupplierGenWebsite, T1.SupplierGenContactPhone, T1.SupplierGenContactName, T2.SupplierGenTypeName, T1.SupplierGenId FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierGenCompanyName like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T2.SupplierGenTypeName like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenContactName like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenContactPhone like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenWebsite like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName like :lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName = ( :AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_suppliergenwwds_4_tfsuppliergentypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName like :lV66Trn_suppliergenwwds_4_tfsuppliergentypename)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel)) && ! ( StringUtil.StrCmp(AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName = ( :AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_suppliergenwwds_6_tfsuppliergencontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName like :lV68Trn_suppliergenwwds_6_tfsuppliergencontactname)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel)) && ! ( StringUtil.StrCmp(AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName = ( :AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone like :lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel)) && ! ( StringUtil.StrCmp(AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone = ( :AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenWebsite like :lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel)) && ! ( StringUtil.StrCmp(AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenWebsite = ( :AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenWebsite))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierGenCompanyName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006I3( IGxContext context ,
                                             string AV63Trn_suppliergenwwds_1_filterfulltext ,
                                             string AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel ,
                                             string AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname ,
                                             string AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel ,
                                             string AV66Trn_suppliergenwwds_4_tfsuppliergentypename ,
                                             string AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel ,
                                             string AV68Trn_suppliergenwwds_6_tfsuppliergencontactname ,
                                             string AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel ,
                                             string AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone ,
                                             string AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel ,
                                             string AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite ,
                                             string A44SupplierGenCompanyName ,
                                             string A290SupplierGenTypeName ,
                                             string A47SupplierGenContactName ,
                                             string A48SupplierGenContactPhone ,
                                             string A441SupplierGenWebsite ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[15];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SupplierGenTypeId, T1.OrganisationId, T1.SupplierGenWebsite, T1.SupplierGenContactPhone, T1.SupplierGenContactName, T2.SupplierGenTypeName, T1.SupplierGenCompanyName, T1.SupplierGenId FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierGenCompanyName like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T2.SupplierGenTypeName like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenContactName like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenContactPhone like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenWebsite like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName like :lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName = ( :AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_suppliergenwwds_4_tfsuppliergentypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName like :lV66Trn_suppliergenwwds_4_tfsuppliergentypename)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel)) && ! ( StringUtil.StrCmp(AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName = ( :AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_suppliergenwwds_6_tfsuppliergencontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName like :lV68Trn_suppliergenwwds_6_tfsuppliergencontactname)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel)) && ! ( StringUtil.StrCmp(AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName = ( :AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone like :lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel)) && ! ( StringUtil.StrCmp(AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone = ( :AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenWebsite like :lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel)) && ! ( StringUtil.StrCmp(AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenWebsite = ( :AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenWebsite))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierGenTypeId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006I4( IGxContext context ,
                                             string AV63Trn_suppliergenwwds_1_filterfulltext ,
                                             string AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel ,
                                             string AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname ,
                                             string AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel ,
                                             string AV66Trn_suppliergenwwds_4_tfsuppliergentypename ,
                                             string AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel ,
                                             string AV68Trn_suppliergenwwds_6_tfsuppliergencontactname ,
                                             string AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel ,
                                             string AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone ,
                                             string AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel ,
                                             string AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite ,
                                             string A44SupplierGenCompanyName ,
                                             string A290SupplierGenTypeName ,
                                             string A47SupplierGenContactName ,
                                             string A48SupplierGenContactPhone ,
                                             string A441SupplierGenWebsite ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[15];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.SupplierGenTypeId, T1.SupplierGenContactName, T1.OrganisationId, T1.SupplierGenWebsite, T1.SupplierGenContactPhone, T2.SupplierGenTypeName, T1.SupplierGenCompanyName, T1.SupplierGenId FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierGenCompanyName like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T2.SupplierGenTypeName like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenContactName like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenContactPhone like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenWebsite like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName like :lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName = ( :AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_suppliergenwwds_4_tfsuppliergentypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName like :lV66Trn_suppliergenwwds_4_tfsuppliergentypename)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel)) && ! ( StringUtil.StrCmp(AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName = ( :AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_suppliergenwwds_6_tfsuppliergencontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName like :lV68Trn_suppliergenwwds_6_tfsuppliergencontactname)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel)) && ! ( StringUtil.StrCmp(AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName = ( :AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone like :lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel)) && ! ( StringUtil.StrCmp(AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone = ( :AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenWebsite like :lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel)) && ! ( StringUtil.StrCmp(AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenWebsite = ( :AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenWebsite))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierGenContactName";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P006I5( IGxContext context ,
                                             string AV63Trn_suppliergenwwds_1_filterfulltext ,
                                             string AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel ,
                                             string AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname ,
                                             string AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel ,
                                             string AV66Trn_suppliergenwwds_4_tfsuppliergentypename ,
                                             string AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel ,
                                             string AV68Trn_suppliergenwwds_6_tfsuppliergencontactname ,
                                             string AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel ,
                                             string AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone ,
                                             string AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel ,
                                             string AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite ,
                                             string A44SupplierGenCompanyName ,
                                             string A290SupplierGenTypeName ,
                                             string A47SupplierGenContactName ,
                                             string A48SupplierGenContactPhone ,
                                             string A441SupplierGenWebsite ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[15];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.SupplierGenTypeId, T1.SupplierGenContactPhone, T1.OrganisationId, T1.SupplierGenWebsite, T1.SupplierGenContactName, T2.SupplierGenTypeName, T1.SupplierGenCompanyName, T1.SupplierGenId FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierGenCompanyName like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T2.SupplierGenTypeName like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenContactName like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenContactPhone like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenWebsite like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName like :lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName = ( :AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel))");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_suppliergenwwds_4_tfsuppliergentypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName like :lV66Trn_suppliergenwwds_4_tfsuppliergentypename)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel)) && ! ( StringUtil.StrCmp(AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName = ( :AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel))");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_suppliergenwwds_6_tfsuppliergencontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName like :lV68Trn_suppliergenwwds_6_tfsuppliergencontactname)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel)) && ! ( StringUtil.StrCmp(AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName = ( :AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone like :lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel)) && ! ( StringUtil.StrCmp(AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone = ( :AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( StringUtil.StrCmp(AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenWebsite like :lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel)) && ! ( StringUtil.StrCmp(AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenWebsite = ( :AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenWebsite))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierGenContactPhone";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P006I6( IGxContext context ,
                                             string AV63Trn_suppliergenwwds_1_filterfulltext ,
                                             string AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel ,
                                             string AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname ,
                                             string AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel ,
                                             string AV66Trn_suppliergenwwds_4_tfsuppliergentypename ,
                                             string AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel ,
                                             string AV68Trn_suppliergenwwds_6_tfsuppliergencontactname ,
                                             string AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel ,
                                             string AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone ,
                                             string AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel ,
                                             string AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite ,
                                             string A44SupplierGenCompanyName ,
                                             string A290SupplierGenTypeName ,
                                             string A47SupplierGenContactName ,
                                             string A48SupplierGenContactPhone ,
                                             string A441SupplierGenWebsite ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[15];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.SupplierGenTypeId, T1.SupplierGenWebsite, T1.OrganisationId, T1.SupplierGenContactPhone, T1.SupplierGenContactName, T2.SupplierGenTypeName, T1.SupplierGenCompanyName, T1.SupplierGenId FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_suppliergenwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierGenCompanyName like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T2.SupplierGenTypeName like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenContactName like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenContactPhone like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenWebsite like '%' || :lV63Trn_suppliergenwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_suppliergenwwds_2_tfsuppliergencompanyname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName like :lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName = ( :AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel))");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_suppliergenwwds_4_tfsuppliergentypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName like :lV66Trn_suppliergenwwds_4_tfsuppliergentypename)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel)) && ! ( StringUtil.StrCmp(AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName = ( :AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel))");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_suppliergenwwds_6_tfsuppliergencontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName like :lV68Trn_suppliergenwwds_6_tfsuppliergencontactname)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel)) && ! ( StringUtil.StrCmp(AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName = ( :AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_suppliergenwwds_8_tfsuppliergencontactphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone like :lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel)) && ! ( StringUtil.StrCmp(AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone = ( :AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel))");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( StringUtil.StrCmp(AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_suppliergenwwds_10_tfsuppliergenwebsite)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenWebsite like :lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel)) && ! ( StringUtil.StrCmp(AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenWebsite = ( :AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel))");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( StringUtil.StrCmp(AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenWebsite))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierGenWebsite";
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
                     return conditional_P006I2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] );
               case 1 :
                     return conditional_P006I3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] );
               case 2 :
                     return conditional_P006I4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] );
               case 3 :
                     return conditional_P006I5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] );
               case 4 :
                     return conditional_P006I6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] );
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
          Object[] prmP006I2;
          prmP006I2 = new Object[] {
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Trn_suppliergenwwds_4_tfsuppliergentypename",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_suppliergenwwds_6_tfsuppliergencontactname",GXType.VarChar,100,0) ,
          new ParDef("AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone",GXType.Char,20,0) ,
          new ParDef("AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel",GXType.Char,20,0) ,
          new ParDef("lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite",GXType.VarChar,50,0) ,
          new ParDef("AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel",GXType.VarChar,50,0)
          };
          Object[] prmP006I3;
          prmP006I3 = new Object[] {
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Trn_suppliergenwwds_4_tfsuppliergentypename",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_suppliergenwwds_6_tfsuppliergencontactname",GXType.VarChar,100,0) ,
          new ParDef("AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone",GXType.Char,20,0) ,
          new ParDef("AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel",GXType.Char,20,0) ,
          new ParDef("lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite",GXType.VarChar,50,0) ,
          new ParDef("AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel",GXType.VarChar,50,0)
          };
          Object[] prmP006I4;
          prmP006I4 = new Object[] {
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Trn_suppliergenwwds_4_tfsuppliergentypename",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_suppliergenwwds_6_tfsuppliergencontactname",GXType.VarChar,100,0) ,
          new ParDef("AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone",GXType.Char,20,0) ,
          new ParDef("AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel",GXType.Char,20,0) ,
          new ParDef("lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite",GXType.VarChar,50,0) ,
          new ParDef("AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel",GXType.VarChar,50,0)
          };
          Object[] prmP006I5;
          prmP006I5 = new Object[] {
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Trn_suppliergenwwds_4_tfsuppliergentypename",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_suppliergenwwds_6_tfsuppliergencontactname",GXType.VarChar,100,0) ,
          new ParDef("AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone",GXType.Char,20,0) ,
          new ParDef("AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel",GXType.Char,20,0) ,
          new ParDef("lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite",GXType.VarChar,50,0) ,
          new ParDef("AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel",GXType.VarChar,50,0)
          };
          Object[] prmP006I6;
          prmP006I6 = new Object[] {
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Trn_suppliergenwwds_2_tfsuppliergencompanyname",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Trn_suppliergenwwds_4_tfsuppliergentypename",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_suppliergenwwds_5_tfsuppliergentypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_suppliergenwwds_6_tfsuppliergencontactname",GXType.VarChar,100,0) ,
          new ParDef("AV69Trn_suppliergenwwds_7_tfsuppliergencontactname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV70Trn_suppliergenwwds_8_tfsuppliergencontactphone",GXType.Char,20,0) ,
          new ParDef("AV71Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel",GXType.Char,20,0) ,
          new ParDef("lV72Trn_suppliergenwwds_10_tfsuppliergenwebsite",GXType.VarChar,50,0) ,
          new ParDef("AV73Trn_suppliergenwwds_11_tfsuppliergenwebsite_sel",GXType.VarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006I2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006I3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006I3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006I4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006I4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006I5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006I5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006I6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006I6,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((Guid[]) buf[8])[0] = rslt.getGuid(8);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((Guid[]) buf[8])[0] = rslt.getGuid(8);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((Guid[]) buf[8])[0] = rslt.getGuid(8);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((Guid[]) buf[8])[0] = rslt.getGuid(8);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((Guid[]) buf[8])[0] = rslt.getGuid(8);
                return;
       }
    }

 }

}
