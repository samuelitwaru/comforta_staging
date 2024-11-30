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
   public class wp_organisationgeneralsuppliersgetfilterdata : GXProcedure
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
            return "wp_organisationgeneralsuppliers_Services_Execute" ;
         }

      }

      public wp_organisationgeneralsuppliersgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_organisationgeneralsuppliersgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_SUPPLIERGENCOMPANYNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERGENCOMPANYNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_SUPPLIERGENTYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERGENTYPENAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_SUPPLIERGENCONTACTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERGENCONTACTNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_SUPPLIERGENCONTACTPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERGENCONTACTPHONEOPTIONS' */
            S151 ();
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
         if ( StringUtil.StrCmp(AV30Session.Get("WP_OrganisationGeneralSuppliersGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WP_OrganisationGeneralSuppliersGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("WP_OrganisationGeneralSuppliersGridState"), null, "", "");
         }
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV43GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCOMPANYNAME") == 0 )
            {
               AV42TFSupplierGenCompanyNameOperator = AV33GridStateFilterValue.gxTpr_Operator;
               if ( AV42TFSupplierGenCompanyNameOperator == 0 )
               {
                  AV11TFSupplierGenCompanyName = AV33GridStateFilterValue.gxTpr_Value;
               }
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCOMPANYNAME_SEL") == 0 )
            {
               AV12TFSupplierGenCompanyName_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENTYPENAME") == 0 )
            {
               AV13TFSupplierGenTypeName = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENTYPENAME_SEL") == 0 )
            {
               AV14TFSupplierGenTypeName_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCONTACTNAME") == 0 )
            {
               AV15TFSupplierGenContactName = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCONTACTNAME_SEL") == 0 )
            {
               AV16TFSupplierGenContactName_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCONTACTPHONE") == 0 )
            {
               AV17TFSupplierGenContactPhone = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCONTACTPHONE_SEL") == 0 )
            {
               AV18TFSupplierGenContactPhone_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV43GXV1 = (int)(AV43GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSUPPLIERGENCOMPANYNAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFSupplierGenCompanyName = AV19SearchTxt;
         AV42TFSupplierGenCompanyNameOperator = 0;
         AV12TFSupplierGenCompanyName_Sel = "";
         AV45Wp_organisationgeneralsuppliersds_1_filterfulltext = AV41FilterFullText;
         AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = AV11TFSupplierGenCompanyName;
         AV47Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator = AV42TFSupplierGenCompanyNameOperator;
         AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel = AV12TFSupplierGenCompanyName_Sel;
         AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = AV13TFSupplierGenTypeName;
         AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel = AV14TFSupplierGenTypeName_Sel;
         AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = AV15TFSupplierGenContactName;
         AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel = AV16TFSupplierGenContactName_Sel;
         AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = AV17TFSupplierGenContactPhone;
         AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel = AV18TFSupplierGenContactPhone_Sel;
         AV56Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV45Wp_organisationgeneralsuppliersds_1_filterfulltext ,
                                              AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel ,
                                              AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname ,
                                              AV47Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator ,
                                              AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel ,
                                              AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename ,
                                              AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel ,
                                              AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname ,
                                              AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel ,
                                              AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone ,
                                              A44SupplierGenCompanyName ,
                                              A290SupplierGenTypeName ,
                                              A47SupplierGenContactName ,
                                              A48SupplierGenContactPhone ,
                                              AV55Isselected ,
                                              A11OrganisationId ,
                                              AV56Udparg11 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN
                                              }
         });
         lV45Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV45Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV45Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV45Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname), "%", "");
         lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = StringUtil.Concat( StringUtil.RTrim( AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename), "%", "");
         lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = StringUtil.Concat( StringUtil.RTrim( AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname), "%", "");
         lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = StringUtil.PadR( StringUtil.RTrim( AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone), 20, "%");
         /* Using cursor P008N2 */
         pr_default.execute(0, new Object[] {AV56Udparg11, lV45Wp_organisationgeneralsuppliersds_1_filterfulltext, lV45Wp_organisationgeneralsuppliersds_1_filterfulltext, lV45Wp_organisationgeneralsuppliersds_1_filterfulltext, lV45Wp_organisationgeneralsuppliersds_1_filterfulltext, lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname, AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, AV55Isselected, lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename, AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname, AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone, AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK8N2 = false;
            A282SupplierGenTypeId = P008N2_A282SupplierGenTypeId[0];
            A11OrganisationId = P008N2_A11OrganisationId[0];
            n11OrganisationId = P008N2_n11OrganisationId[0];
            A44SupplierGenCompanyName = P008N2_A44SupplierGenCompanyName[0];
            A48SupplierGenContactPhone = P008N2_A48SupplierGenContactPhone[0];
            A47SupplierGenContactName = P008N2_A47SupplierGenContactName[0];
            A290SupplierGenTypeName = P008N2_A290SupplierGenTypeName[0];
            A42SupplierGenId = P008N2_A42SupplierGenId[0];
            A290SupplierGenTypeName = P008N2_A290SupplierGenTypeName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P008N2_A44SupplierGenCompanyName[0], A44SupplierGenCompanyName) == 0 ) )
            {
               BRK8N2 = false;
               A42SupplierGenId = P008N2_A42SupplierGenId[0];
               AV29count = (long)(AV29count+1);
               BRK8N2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A44SupplierGenCompanyName)) ? "<#Empty#>" : A44SupplierGenCompanyName);
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
            if ( ! BRK8N2 )
            {
               BRK8N2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSUPPLIERGENTYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFSupplierGenTypeName = AV19SearchTxt;
         AV14TFSupplierGenTypeName_Sel = "";
         AV45Wp_organisationgeneralsuppliersds_1_filterfulltext = AV41FilterFullText;
         AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = AV11TFSupplierGenCompanyName;
         AV47Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator = AV42TFSupplierGenCompanyNameOperator;
         AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel = AV12TFSupplierGenCompanyName_Sel;
         AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = AV13TFSupplierGenTypeName;
         AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel = AV14TFSupplierGenTypeName_Sel;
         AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = AV15TFSupplierGenContactName;
         AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel = AV16TFSupplierGenContactName_Sel;
         AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = AV17TFSupplierGenContactPhone;
         AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel = AV18TFSupplierGenContactPhone_Sel;
         AV56Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV45Wp_organisationgeneralsuppliersds_1_filterfulltext ,
                                              AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel ,
                                              AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname ,
                                              AV47Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator ,
                                              AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel ,
                                              AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename ,
                                              AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel ,
                                              AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname ,
                                              AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel ,
                                              AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone ,
                                              A44SupplierGenCompanyName ,
                                              A290SupplierGenTypeName ,
                                              A47SupplierGenContactName ,
                                              A48SupplierGenContactPhone ,
                                              AV55Isselected ,
                                              A11OrganisationId ,
                                              AV56Udparg11 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN
                                              }
         });
         lV45Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV45Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV45Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV45Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname), "%", "");
         lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = StringUtil.Concat( StringUtil.RTrim( AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename), "%", "");
         lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = StringUtil.Concat( StringUtil.RTrim( AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname), "%", "");
         lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = StringUtil.PadR( StringUtil.RTrim( AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone), 20, "%");
         /* Using cursor P008N3 */
         pr_default.execute(1, new Object[] {AV56Udparg11, lV45Wp_organisationgeneralsuppliersds_1_filterfulltext, lV45Wp_organisationgeneralsuppliersds_1_filterfulltext, lV45Wp_organisationgeneralsuppliersds_1_filterfulltext, lV45Wp_organisationgeneralsuppliersds_1_filterfulltext, lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname, AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, AV55Isselected, lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename, AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname, AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone, AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK8N4 = false;
            A282SupplierGenTypeId = P008N3_A282SupplierGenTypeId[0];
            A11OrganisationId = P008N3_A11OrganisationId[0];
            n11OrganisationId = P008N3_n11OrganisationId[0];
            A48SupplierGenContactPhone = P008N3_A48SupplierGenContactPhone[0];
            A47SupplierGenContactName = P008N3_A47SupplierGenContactName[0];
            A290SupplierGenTypeName = P008N3_A290SupplierGenTypeName[0];
            A44SupplierGenCompanyName = P008N3_A44SupplierGenCompanyName[0];
            A42SupplierGenId = P008N3_A42SupplierGenId[0];
            A290SupplierGenTypeName = P008N3_A290SupplierGenTypeName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P008N3_A282SupplierGenTypeId[0] == A282SupplierGenTypeId ) )
            {
               BRK8N4 = false;
               A42SupplierGenId = P008N3_A42SupplierGenId[0];
               AV29count = (long)(AV29count+1);
               BRK8N4 = true;
               pr_default.readNext(1);
            }
            AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A290SupplierGenTypeName)) ? "<#Empty#>" : A290SupplierGenTypeName);
            AV23InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV24Option, "<#Empty#>") != 0 ) && ( AV23InsertIndex <= AV25Options.Count ) && ( ( StringUtil.StrCmp(((string)AV25Options.Item(AV23InsertIndex)), AV24Option) < 0 ) || ( StringUtil.StrCmp(((string)AV25Options.Item(AV23InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV23InsertIndex = (int)(AV23InsertIndex+1);
            }
            AV25Options.Add(AV24Option, AV23InsertIndex);
            AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), AV23InsertIndex);
            if ( AV25Options.Count == AV20SkipItems + 11 )
            {
               AV25Options.RemoveItem(AV25Options.Count);
               AV28OptionIndexes.RemoveItem(AV28OptionIndexes.Count);
            }
            if ( ! BRK8N4 )
            {
               BRK8N4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV20SkipItems > 0 )
         {
            AV25Options.RemoveItem(1);
            AV28OptionIndexes.RemoveItem(1);
            AV20SkipItems = (short)(AV20SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADSUPPLIERGENCONTACTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFSupplierGenContactName = AV19SearchTxt;
         AV16TFSupplierGenContactName_Sel = "";
         AV45Wp_organisationgeneralsuppliersds_1_filterfulltext = AV41FilterFullText;
         AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = AV11TFSupplierGenCompanyName;
         AV47Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator = AV42TFSupplierGenCompanyNameOperator;
         AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel = AV12TFSupplierGenCompanyName_Sel;
         AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = AV13TFSupplierGenTypeName;
         AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel = AV14TFSupplierGenTypeName_Sel;
         AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = AV15TFSupplierGenContactName;
         AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel = AV16TFSupplierGenContactName_Sel;
         AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = AV17TFSupplierGenContactPhone;
         AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel = AV18TFSupplierGenContactPhone_Sel;
         AV56Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV45Wp_organisationgeneralsuppliersds_1_filterfulltext ,
                                              AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel ,
                                              AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname ,
                                              AV47Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator ,
                                              AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel ,
                                              AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename ,
                                              AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel ,
                                              AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname ,
                                              AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel ,
                                              AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone ,
                                              A44SupplierGenCompanyName ,
                                              A290SupplierGenTypeName ,
                                              A47SupplierGenContactName ,
                                              A48SupplierGenContactPhone ,
                                              AV55Isselected ,
                                              A11OrganisationId ,
                                              AV56Udparg11 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN
                                              }
         });
         lV45Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV45Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV45Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV45Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname), "%", "");
         lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = StringUtil.Concat( StringUtil.RTrim( AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename), "%", "");
         lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = StringUtil.Concat( StringUtil.RTrim( AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname), "%", "");
         lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = StringUtil.PadR( StringUtil.RTrim( AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone), 20, "%");
         /* Using cursor P008N4 */
         pr_default.execute(2, new Object[] {AV56Udparg11, lV45Wp_organisationgeneralsuppliersds_1_filterfulltext, lV45Wp_organisationgeneralsuppliersds_1_filterfulltext, lV45Wp_organisationgeneralsuppliersds_1_filterfulltext, lV45Wp_organisationgeneralsuppliersds_1_filterfulltext, lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname, AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, AV55Isselected, lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename, AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname, AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone, AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK8N6 = false;
            A282SupplierGenTypeId = P008N4_A282SupplierGenTypeId[0];
            A11OrganisationId = P008N4_A11OrganisationId[0];
            n11OrganisationId = P008N4_n11OrganisationId[0];
            A47SupplierGenContactName = P008N4_A47SupplierGenContactName[0];
            A48SupplierGenContactPhone = P008N4_A48SupplierGenContactPhone[0];
            A290SupplierGenTypeName = P008N4_A290SupplierGenTypeName[0];
            A44SupplierGenCompanyName = P008N4_A44SupplierGenCompanyName[0];
            A42SupplierGenId = P008N4_A42SupplierGenId[0];
            A290SupplierGenTypeName = P008N4_A290SupplierGenTypeName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P008N4_A47SupplierGenContactName[0], A47SupplierGenContactName) == 0 ) )
            {
               BRK8N6 = false;
               A42SupplierGenId = P008N4_A42SupplierGenId[0];
               AV29count = (long)(AV29count+1);
               BRK8N6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A47SupplierGenContactName)) ? "<#Empty#>" : A47SupplierGenContactName);
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
            if ( ! BRK8N6 )
            {
               BRK8N6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADSUPPLIERGENCONTACTPHONEOPTIONS' Routine */
         returnInSub = false;
         AV17TFSupplierGenContactPhone = AV19SearchTxt;
         AV18TFSupplierGenContactPhone_Sel = "";
         AV45Wp_organisationgeneralsuppliersds_1_filterfulltext = AV41FilterFullText;
         AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = AV11TFSupplierGenCompanyName;
         AV47Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator = AV42TFSupplierGenCompanyNameOperator;
         AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel = AV12TFSupplierGenCompanyName_Sel;
         AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = AV13TFSupplierGenTypeName;
         AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel = AV14TFSupplierGenTypeName_Sel;
         AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = AV15TFSupplierGenContactName;
         AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel = AV16TFSupplierGenContactName_Sel;
         AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = AV17TFSupplierGenContactPhone;
         AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel = AV18TFSupplierGenContactPhone_Sel;
         AV56Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV45Wp_organisationgeneralsuppliersds_1_filterfulltext ,
                                              AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel ,
                                              AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname ,
                                              AV47Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator ,
                                              AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel ,
                                              AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename ,
                                              AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel ,
                                              AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname ,
                                              AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel ,
                                              AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone ,
                                              A44SupplierGenCompanyName ,
                                              A290SupplierGenTypeName ,
                                              A47SupplierGenContactName ,
                                              A48SupplierGenContactPhone ,
                                              AV55Isselected ,
                                              A11OrganisationId ,
                                              AV56Udparg11 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN
                                              }
         });
         lV45Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV45Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV45Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV45Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname), "%", "");
         lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = StringUtil.Concat( StringUtil.RTrim( AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename), "%", "");
         lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = StringUtil.Concat( StringUtil.RTrim( AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname), "%", "");
         lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = StringUtil.PadR( StringUtil.RTrim( AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone), 20, "%");
         /* Using cursor P008N5 */
         pr_default.execute(3, new Object[] {AV56Udparg11, lV45Wp_organisationgeneralsuppliersds_1_filterfulltext, lV45Wp_organisationgeneralsuppliersds_1_filterfulltext, lV45Wp_organisationgeneralsuppliersds_1_filterfulltext, lV45Wp_organisationgeneralsuppliersds_1_filterfulltext, lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname, AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, AV55Isselected, lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename, AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname, AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone, AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK8N8 = false;
            A282SupplierGenTypeId = P008N5_A282SupplierGenTypeId[0];
            A11OrganisationId = P008N5_A11OrganisationId[0];
            n11OrganisationId = P008N5_n11OrganisationId[0];
            A48SupplierGenContactPhone = P008N5_A48SupplierGenContactPhone[0];
            A47SupplierGenContactName = P008N5_A47SupplierGenContactName[0];
            A290SupplierGenTypeName = P008N5_A290SupplierGenTypeName[0];
            A44SupplierGenCompanyName = P008N5_A44SupplierGenCompanyName[0];
            A42SupplierGenId = P008N5_A42SupplierGenId[0];
            A290SupplierGenTypeName = P008N5_A290SupplierGenTypeName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P008N5_A48SupplierGenContactPhone[0], A48SupplierGenContactPhone) == 0 ) )
            {
               BRK8N8 = false;
               A42SupplierGenId = P008N5_A42SupplierGenId[0];
               AV29count = (long)(AV29count+1);
               BRK8N8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A48SupplierGenContactPhone)) ? "<#Empty#>" : A48SupplierGenContactPhone);
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
            if ( ! BRK8N8 )
            {
               BRK8N8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
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
         AV11TFSupplierGenCompanyName = "";
         AV12TFSupplierGenCompanyName_Sel = "";
         AV13TFSupplierGenTypeName = "";
         AV14TFSupplierGenTypeName_Sel = "";
         AV15TFSupplierGenContactName = "";
         AV16TFSupplierGenContactName_Sel = "";
         AV17TFSupplierGenContactPhone = "";
         AV18TFSupplierGenContactPhone_Sel = "";
         AV45Wp_organisationgeneralsuppliersds_1_filterfulltext = "";
         AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = "";
         AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel = "";
         AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = "";
         AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel = "";
         AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = "";
         AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel = "";
         AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = "";
         AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel = "";
         AV56Udparg11 = Guid.Empty;
         lV45Wp_organisationgeneralsuppliersds_1_filterfulltext = "";
         lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = "";
         lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = "";
         lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = "";
         lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = "";
         A44SupplierGenCompanyName = "";
         A290SupplierGenTypeName = "";
         A47SupplierGenContactName = "";
         A48SupplierGenContactPhone = "";
         A11OrganisationId = Guid.Empty;
         P008N2_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         P008N2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008N2_n11OrganisationId = new bool[] {false} ;
         P008N2_A44SupplierGenCompanyName = new string[] {""} ;
         P008N2_A48SupplierGenContactPhone = new string[] {""} ;
         P008N2_A47SupplierGenContactName = new string[] {""} ;
         P008N2_A290SupplierGenTypeName = new string[] {""} ;
         P008N2_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         A282SupplierGenTypeId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         AV24Option = "";
         P008N3_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         P008N3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008N3_n11OrganisationId = new bool[] {false} ;
         P008N3_A48SupplierGenContactPhone = new string[] {""} ;
         P008N3_A47SupplierGenContactName = new string[] {""} ;
         P008N3_A290SupplierGenTypeName = new string[] {""} ;
         P008N3_A44SupplierGenCompanyName = new string[] {""} ;
         P008N3_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P008N4_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         P008N4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008N4_n11OrganisationId = new bool[] {false} ;
         P008N4_A47SupplierGenContactName = new string[] {""} ;
         P008N4_A48SupplierGenContactPhone = new string[] {""} ;
         P008N4_A290SupplierGenTypeName = new string[] {""} ;
         P008N4_A44SupplierGenCompanyName = new string[] {""} ;
         P008N4_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P008N5_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         P008N5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008N5_n11OrganisationId = new bool[] {false} ;
         P008N5_A48SupplierGenContactPhone = new string[] {""} ;
         P008N5_A47SupplierGenContactName = new string[] {""} ;
         P008N5_A290SupplierGenTypeName = new string[] {""} ;
         P008N5_A44SupplierGenCompanyName = new string[] {""} ;
         P008N5_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_organisationgeneralsuppliersgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P008N2_A282SupplierGenTypeId, P008N2_A11OrganisationId, P008N2_n11OrganisationId, P008N2_A44SupplierGenCompanyName, P008N2_A48SupplierGenContactPhone, P008N2_A47SupplierGenContactName, P008N2_A290SupplierGenTypeName, P008N2_A42SupplierGenId
               }
               , new Object[] {
               P008N3_A282SupplierGenTypeId, P008N3_A11OrganisationId, P008N3_n11OrganisationId, P008N3_A48SupplierGenContactPhone, P008N3_A47SupplierGenContactName, P008N3_A290SupplierGenTypeName, P008N3_A44SupplierGenCompanyName, P008N3_A42SupplierGenId
               }
               , new Object[] {
               P008N4_A282SupplierGenTypeId, P008N4_A11OrganisationId, P008N4_n11OrganisationId, P008N4_A47SupplierGenContactName, P008N4_A48SupplierGenContactPhone, P008N4_A290SupplierGenTypeName, P008N4_A44SupplierGenCompanyName, P008N4_A42SupplierGenId
               }
               , new Object[] {
               P008N5_A282SupplierGenTypeId, P008N5_A11OrganisationId, P008N5_n11OrganisationId, P008N5_A48SupplierGenContactPhone, P008N5_A47SupplierGenContactName, P008N5_A290SupplierGenTypeName, P008N5_A44SupplierGenCompanyName, P008N5_A42SupplierGenId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private short AV42TFSupplierGenCompanyNameOperator ;
      private short AV47Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator ;
      private int AV43GXV1 ;
      private int AV23InsertIndex ;
      private long AV29count ;
      private decimal AV55Isselected ;
      private string AV17TFSupplierGenContactPhone ;
      private string AV18TFSupplierGenContactPhone_Sel ;
      private string AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone ;
      private string AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel ;
      private string lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone ;
      private string A48SupplierGenContactPhone ;
      private bool returnInSub ;
      private bool BRK8N2 ;
      private bool n11OrganisationId ;
      private bool BRK8N4 ;
      private bool BRK8N6 ;
      private bool BRK8N8 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV11TFSupplierGenCompanyName ;
      private string AV12TFSupplierGenCompanyName_Sel ;
      private string AV13TFSupplierGenTypeName ;
      private string AV14TFSupplierGenTypeName_Sel ;
      private string AV15TFSupplierGenContactName ;
      private string AV16TFSupplierGenContactName_Sel ;
      private string AV45Wp_organisationgeneralsuppliersds_1_filterfulltext ;
      private string AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname ;
      private string AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel ;
      private string AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename ;
      private string AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel ;
      private string AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname ;
      private string AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel ;
      private string lV45Wp_organisationgeneralsuppliersds_1_filterfulltext ;
      private string lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname ;
      private string lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename ;
      private string lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname ;
      private string A44SupplierGenCompanyName ;
      private string A290SupplierGenTypeName ;
      private string A47SupplierGenContactName ;
      private string AV24Option ;
      private Guid AV56Udparg11 ;
      private Guid A11OrganisationId ;
      private Guid A282SupplierGenTypeId ;
      private Guid A42SupplierGenId ;
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
      private Guid[] P008N2_A282SupplierGenTypeId ;
      private Guid[] P008N2_A11OrganisationId ;
      private bool[] P008N2_n11OrganisationId ;
      private string[] P008N2_A44SupplierGenCompanyName ;
      private string[] P008N2_A48SupplierGenContactPhone ;
      private string[] P008N2_A47SupplierGenContactName ;
      private string[] P008N2_A290SupplierGenTypeName ;
      private Guid[] P008N2_A42SupplierGenId ;
      private Guid[] P008N3_A282SupplierGenTypeId ;
      private Guid[] P008N3_A11OrganisationId ;
      private bool[] P008N3_n11OrganisationId ;
      private string[] P008N3_A48SupplierGenContactPhone ;
      private string[] P008N3_A47SupplierGenContactName ;
      private string[] P008N3_A290SupplierGenTypeName ;
      private string[] P008N3_A44SupplierGenCompanyName ;
      private Guid[] P008N3_A42SupplierGenId ;
      private Guid[] P008N4_A282SupplierGenTypeId ;
      private Guid[] P008N4_A11OrganisationId ;
      private bool[] P008N4_n11OrganisationId ;
      private string[] P008N4_A47SupplierGenContactName ;
      private string[] P008N4_A48SupplierGenContactPhone ;
      private string[] P008N4_A290SupplierGenTypeName ;
      private string[] P008N4_A44SupplierGenCompanyName ;
      private Guid[] P008N4_A42SupplierGenId ;
      private Guid[] P008N5_A282SupplierGenTypeId ;
      private Guid[] P008N5_A11OrganisationId ;
      private bool[] P008N5_n11OrganisationId ;
      private string[] P008N5_A48SupplierGenContactPhone ;
      private string[] P008N5_A47SupplierGenContactName ;
      private string[] P008N5_A290SupplierGenTypeName ;
      private string[] P008N5_A44SupplierGenCompanyName ;
      private Guid[] P008N5_A42SupplierGenId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wp_organisationgeneralsuppliersgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008N2( IGxContext context ,
                                             string AV45Wp_organisationgeneralsuppliersds_1_filterfulltext ,
                                             string AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel ,
                                             string AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname ,
                                             short AV47Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator ,
                                             string AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel ,
                                             string AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename ,
                                             string AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel ,
                                             string AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname ,
                                             string AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel ,
                                             string AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone ,
                                             string A44SupplierGenCompanyName ,
                                             string A290SupplierGenTypeName ,
                                             string A47SupplierGenContactName ,
                                             string A48SupplierGenContactPhone ,
                                             decimal AV55Isselected ,
                                             Guid A11OrganisationId ,
                                             Guid AV56Udparg11 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SupplierGenTypeId, T1.OrganisationId, T1.SupplierGenCompanyName, T1.SupplierGenContactPhone, T1.SupplierGenContactName, T2.SupplierGenTypeName, T1.SupplierGenId FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId = :AV56Udparg11)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierGenCompanyName like '%' || :lV45Wp_organisationgeneralsuppliersds_1_filterfulltext) or ( T2.SupplierGenTypeName like '%' || :lV45Wp_organisationgeneralsuppliersds_1_filterfulltext) or ( T1.SupplierGenContactName like '%' || :lV45Wp_organisationgeneralsuppliersds_1_filterfulltext) or ( T1.SupplierGenContactPhone like '%' || :lV45Wp_organisationgeneralsuppliersds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName like :lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanynam)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName = ( :AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanynam))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenCompanyName))=0))");
         }
         if ( AV47Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator == 1 )
         {
            AddWhere(sWhereString, "(:AV55Isselected = (TRUE= 1))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName like :lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel)) && ! ( StringUtil.StrCmp(AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName = ( :AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_s))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName like :lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactnam)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel)) && ! ( StringUtil.StrCmp(AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName = ( :AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactnam))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone like :lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactpho)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel)) && ! ( StringUtil.StrCmp(AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone = ( :AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactph))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactPhone))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierGenCompanyName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008N3( IGxContext context ,
                                             string AV45Wp_organisationgeneralsuppliersds_1_filterfulltext ,
                                             string AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel ,
                                             string AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname ,
                                             short AV47Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator ,
                                             string AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel ,
                                             string AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename ,
                                             string AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel ,
                                             string AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname ,
                                             string AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel ,
                                             string AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone ,
                                             string A44SupplierGenCompanyName ,
                                             string A290SupplierGenTypeName ,
                                             string A47SupplierGenContactName ,
                                             string A48SupplierGenContactPhone ,
                                             decimal AV55Isselected ,
                                             Guid A11OrganisationId ,
                                             Guid AV56Udparg11 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SupplierGenTypeId, T1.OrganisationId, T1.SupplierGenContactPhone, T1.SupplierGenContactName, T2.SupplierGenTypeName, T1.SupplierGenCompanyName, T1.SupplierGenId FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId = :AV56Udparg11)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierGenCompanyName like '%' || :lV45Wp_organisationgeneralsuppliersds_1_filterfulltext) or ( T2.SupplierGenTypeName like '%' || :lV45Wp_organisationgeneralsuppliersds_1_filterfulltext) or ( T1.SupplierGenContactName like '%' || :lV45Wp_organisationgeneralsuppliersds_1_filterfulltext) or ( T1.SupplierGenContactPhone like '%' || :lV45Wp_organisationgeneralsuppliersds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName like :lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanynam)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName = ( :AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanynam))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenCompanyName))=0))");
         }
         if ( AV47Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator == 1 )
         {
            AddWhere(sWhereString, "(:AV55Isselected = (TRUE= 1))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName like :lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel)) && ! ( StringUtil.StrCmp(AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName = ( :AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_s))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName like :lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactnam)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel)) && ! ( StringUtil.StrCmp(AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName = ( :AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactnam))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone like :lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactpho)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel)) && ! ( StringUtil.StrCmp(AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone = ( :AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactph))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactPhone))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierGenTypeId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P008N4( IGxContext context ,
                                             string AV45Wp_organisationgeneralsuppliersds_1_filterfulltext ,
                                             string AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel ,
                                             string AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname ,
                                             short AV47Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator ,
                                             string AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel ,
                                             string AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename ,
                                             string AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel ,
                                             string AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname ,
                                             string AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel ,
                                             string AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone ,
                                             string A44SupplierGenCompanyName ,
                                             string A290SupplierGenTypeName ,
                                             string A47SupplierGenContactName ,
                                             string A48SupplierGenContactPhone ,
                                             decimal AV55Isselected ,
                                             Guid A11OrganisationId ,
                                             Guid AV56Udparg11 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[14];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.SupplierGenTypeId, T1.OrganisationId, T1.SupplierGenContactName, T1.SupplierGenContactPhone, T2.SupplierGenTypeName, T1.SupplierGenCompanyName, T1.SupplierGenId FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId = :AV56Udparg11)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierGenCompanyName like '%' || :lV45Wp_organisationgeneralsuppliersds_1_filterfulltext) or ( T2.SupplierGenTypeName like '%' || :lV45Wp_organisationgeneralsuppliersds_1_filterfulltext) or ( T1.SupplierGenContactName like '%' || :lV45Wp_organisationgeneralsuppliersds_1_filterfulltext) or ( T1.SupplierGenContactPhone like '%' || :lV45Wp_organisationgeneralsuppliersds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName like :lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanynam)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName = ( :AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanynam))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenCompanyName))=0))");
         }
         if ( AV47Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator == 1 )
         {
            AddWhere(sWhereString, "(:AV55Isselected = (TRUE= 1))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName like :lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel)) && ! ( StringUtil.StrCmp(AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName = ( :AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_s))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName like :lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactnam)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel)) && ! ( StringUtil.StrCmp(AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName = ( :AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactnam))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone like :lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactpho)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel)) && ! ( StringUtil.StrCmp(AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone = ( :AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactph))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactPhone))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierGenContactName";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P008N5( IGxContext context ,
                                             string AV45Wp_organisationgeneralsuppliersds_1_filterfulltext ,
                                             string AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel ,
                                             string AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname ,
                                             short AV47Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator ,
                                             string AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel ,
                                             string AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename ,
                                             string AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel ,
                                             string AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname ,
                                             string AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel ,
                                             string AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone ,
                                             string A44SupplierGenCompanyName ,
                                             string A290SupplierGenTypeName ,
                                             string A47SupplierGenContactName ,
                                             string A48SupplierGenContactPhone ,
                                             decimal AV55Isselected ,
                                             Guid A11OrganisationId ,
                                             Guid AV56Udparg11 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[14];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.SupplierGenTypeId, T1.OrganisationId, T1.SupplierGenContactPhone, T1.SupplierGenContactName, T2.SupplierGenTypeName, T1.SupplierGenCompanyName, T1.SupplierGenId FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId = :AV56Udparg11)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Wp_organisationgeneralsuppliersds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierGenCompanyName like '%' || :lV45Wp_organisationgeneralsuppliersds_1_filterfulltext) or ( T2.SupplierGenTypeName like '%' || :lV45Wp_organisationgeneralsuppliersds_1_filterfulltext) or ( T1.SupplierGenContactName like '%' || :lV45Wp_organisationgeneralsuppliersds_1_filterfulltext) or ( T1.SupplierGenContactPhone like '%' || :lV45Wp_organisationgeneralsuppliersds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName like :lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanynam)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName = ( :AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanynam))");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( StringUtil.StrCmp(AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenCompanyName))=0))");
         }
         if ( AV47Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator == 1 )
         {
            AddWhere(sWhereString, "(:AV55Isselected = (TRUE= 1))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName like :lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel)) && ! ( StringUtil.StrCmp(AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName = ( :AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_s))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName like :lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactnam)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel)) && ! ( StringUtil.StrCmp(AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName = ( :AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactnam))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone like :lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactpho)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel)) && ! ( StringUtil.StrCmp(AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone = ( :AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactph))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactPhone))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierGenContactPhone";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P008N2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (Guid)dynConstraints[15] , (Guid)dynConstraints[16] );
               case 1 :
                     return conditional_P008N3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (Guid)dynConstraints[15] , (Guid)dynConstraints[16] );
               case 2 :
                     return conditional_P008N4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (Guid)dynConstraints[15] , (Guid)dynConstraints[16] );
               case 3 :
                     return conditional_P008N5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (Guid)dynConstraints[15] , (Guid)dynConstraints[16] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008N2;
          prmP008N2 = new Object[] {
          new ParDef("AV56Udparg11",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV45Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanynam",GXType.VarChar,100,0) ,
          new ParDef("AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanynam",GXType.VarChar,100,0) ,
          new ParDef("AV55Isselected",GXType.Number,10,2) ,
          new ParDef("lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename",GXType.VarChar,100,0) ,
          new ParDef("AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_s",GXType.VarChar,100,0) ,
          new ParDef("lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactnam",GXType.VarChar,100,0) ,
          new ParDef("AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactnam",GXType.VarChar,100,0) ,
          new ParDef("lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactpho",GXType.Char,20,0) ,
          new ParDef("AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactph",GXType.Char,20,0)
          };
          Object[] prmP008N3;
          prmP008N3 = new Object[] {
          new ParDef("AV56Udparg11",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV45Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanynam",GXType.VarChar,100,0) ,
          new ParDef("AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanynam",GXType.VarChar,100,0) ,
          new ParDef("AV55Isselected",GXType.Number,10,2) ,
          new ParDef("lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename",GXType.VarChar,100,0) ,
          new ParDef("AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_s",GXType.VarChar,100,0) ,
          new ParDef("lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactnam",GXType.VarChar,100,0) ,
          new ParDef("AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactnam",GXType.VarChar,100,0) ,
          new ParDef("lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactpho",GXType.Char,20,0) ,
          new ParDef("AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactph",GXType.Char,20,0)
          };
          Object[] prmP008N4;
          prmP008N4 = new Object[] {
          new ParDef("AV56Udparg11",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV45Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanynam",GXType.VarChar,100,0) ,
          new ParDef("AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanynam",GXType.VarChar,100,0) ,
          new ParDef("AV55Isselected",GXType.Number,10,2) ,
          new ParDef("lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename",GXType.VarChar,100,0) ,
          new ParDef("AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_s",GXType.VarChar,100,0) ,
          new ParDef("lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactnam",GXType.VarChar,100,0) ,
          new ParDef("AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactnam",GXType.VarChar,100,0) ,
          new ParDef("lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactpho",GXType.Char,20,0) ,
          new ParDef("AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactph",GXType.Char,20,0)
          };
          Object[] prmP008N5;
          prmP008N5 = new Object[] {
          new ParDef("AV56Udparg11",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV45Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanynam",GXType.VarChar,100,0) ,
          new ParDef("AV48Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanynam",GXType.VarChar,100,0) ,
          new ParDef("AV55Isselected",GXType.Number,10,2) ,
          new ParDef("lV49Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename",GXType.VarChar,100,0) ,
          new ParDef("AV50Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_s",GXType.VarChar,100,0) ,
          new ParDef("lV51Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactnam",GXType.VarChar,100,0) ,
          new ParDef("AV52Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactnam",GXType.VarChar,100,0) ,
          new ParDef("lV53Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactpho",GXType.Char,20,0) ,
          new ParDef("AV54Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactph",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008N2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008N3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008N3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008N4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008N4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008N5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008N5,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[7])[0] = rslt.getGuid(7);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[7])[0] = rslt.getGuid(7);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[7])[0] = rslt.getGuid(7);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[7])[0] = rslt.getGuid(7);
                return;
       }
    }

 }

}
