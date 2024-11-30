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
   public class wp_organisationnationalgensupplierswcgetfilterdata : GXProcedure
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

      public wp_organisationnationalgensupplierswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_organisationnationalgensupplierswcgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(AV30Session.Get("WP_OrganisationNationalGenSuppliersWCGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WP_OrganisationNationalGenSuppliersWCGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("WP_OrganisationNationalGenSuppliersWCGridState"), null, "", "");
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
               AV11TFSupplierGenCompanyName = AV33GridStateFilterValue.gxTpr_Value;
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
         AV12TFSupplierGenCompanyName_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV41FilterFullText ,
                                              AV12TFSupplierGenCompanyName_Sel ,
                                              AV11TFSupplierGenCompanyName ,
                                              AV14TFSupplierGenTypeName_Sel ,
                                              AV13TFSupplierGenTypeName ,
                                              AV16TFSupplierGenContactName_Sel ,
                                              AV15TFSupplierGenContactName ,
                                              AV18TFSupplierGenContactPhone_Sel ,
                                              AV17TFSupplierGenContactPhone ,
                                              A44SupplierGenCompanyName ,
                                              A290SupplierGenTypeName ,
                                              A47SupplierGenContactName ,
                                              A48SupplierGenContactPhone ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV11TFSupplierGenCompanyName = StringUtil.Concat( StringUtil.RTrim( AV11TFSupplierGenCompanyName), "%", "");
         lV13TFSupplierGenTypeName = StringUtil.Concat( StringUtil.RTrim( AV13TFSupplierGenTypeName), "%", "");
         lV15TFSupplierGenContactName = StringUtil.Concat( StringUtil.RTrim( AV15TFSupplierGenContactName), "%", "");
         lV17TFSupplierGenContactPhone = StringUtil.PadR( StringUtil.RTrim( AV17TFSupplierGenContactPhone), 20, "%");
         /* Using cursor P00842 */
         pr_default.execute(0, new Object[] {lV41FilterFullText, lV41FilterFullText, lV41FilterFullText, lV41FilterFullText, lV11TFSupplierGenCompanyName, AV12TFSupplierGenCompanyName_Sel, lV13TFSupplierGenTypeName, AV14TFSupplierGenTypeName_Sel, lV15TFSupplierGenContactName, AV16TFSupplierGenContactName_Sel, lV17TFSupplierGenContactPhone, AV18TFSupplierGenContactPhone_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK842 = false;
            A282SupplierGenTypeId = P00842_A282SupplierGenTypeId[0];
            A44SupplierGenCompanyName = P00842_A44SupplierGenCompanyName[0];
            A11OrganisationId = P00842_A11OrganisationId[0];
            n11OrganisationId = P00842_n11OrganisationId[0];
            A48SupplierGenContactPhone = P00842_A48SupplierGenContactPhone[0];
            A47SupplierGenContactName = P00842_A47SupplierGenContactName[0];
            A290SupplierGenTypeName = P00842_A290SupplierGenTypeName[0];
            A42SupplierGenId = P00842_A42SupplierGenId[0];
            A290SupplierGenTypeName = P00842_A290SupplierGenTypeName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00842_A44SupplierGenCompanyName[0], A44SupplierGenCompanyName) == 0 ) )
            {
               BRK842 = false;
               A42SupplierGenId = P00842_A42SupplierGenId[0];
               AV29count = (long)(AV29count+1);
               BRK842 = true;
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
            if ( ! BRK842 )
            {
               BRK842 = true;
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV41FilterFullText ,
                                              AV12TFSupplierGenCompanyName_Sel ,
                                              AV11TFSupplierGenCompanyName ,
                                              AV14TFSupplierGenTypeName_Sel ,
                                              AV13TFSupplierGenTypeName ,
                                              AV16TFSupplierGenContactName_Sel ,
                                              AV15TFSupplierGenContactName ,
                                              AV18TFSupplierGenContactPhone_Sel ,
                                              AV17TFSupplierGenContactPhone ,
                                              A44SupplierGenCompanyName ,
                                              A290SupplierGenTypeName ,
                                              A47SupplierGenContactName ,
                                              A48SupplierGenContactPhone ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV11TFSupplierGenCompanyName = StringUtil.Concat( StringUtil.RTrim( AV11TFSupplierGenCompanyName), "%", "");
         lV13TFSupplierGenTypeName = StringUtil.Concat( StringUtil.RTrim( AV13TFSupplierGenTypeName), "%", "");
         lV15TFSupplierGenContactName = StringUtil.Concat( StringUtil.RTrim( AV15TFSupplierGenContactName), "%", "");
         lV17TFSupplierGenContactPhone = StringUtil.PadR( StringUtil.RTrim( AV17TFSupplierGenContactPhone), 20, "%");
         /* Using cursor P00843 */
         pr_default.execute(1, new Object[] {lV41FilterFullText, lV41FilterFullText, lV41FilterFullText, lV41FilterFullText, lV11TFSupplierGenCompanyName, AV12TFSupplierGenCompanyName_Sel, lV13TFSupplierGenTypeName, AV14TFSupplierGenTypeName_Sel, lV15TFSupplierGenContactName, AV16TFSupplierGenContactName_Sel, lV17TFSupplierGenContactPhone, AV18TFSupplierGenContactPhone_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK844 = false;
            A282SupplierGenTypeId = P00843_A282SupplierGenTypeId[0];
            A11OrganisationId = P00843_A11OrganisationId[0];
            n11OrganisationId = P00843_n11OrganisationId[0];
            A48SupplierGenContactPhone = P00843_A48SupplierGenContactPhone[0];
            A47SupplierGenContactName = P00843_A47SupplierGenContactName[0];
            A290SupplierGenTypeName = P00843_A290SupplierGenTypeName[0];
            A44SupplierGenCompanyName = P00843_A44SupplierGenCompanyName[0];
            A42SupplierGenId = P00843_A42SupplierGenId[0];
            A290SupplierGenTypeName = P00843_A290SupplierGenTypeName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00843_A282SupplierGenTypeId[0] == A282SupplierGenTypeId ) )
            {
               BRK844 = false;
               A42SupplierGenId = P00843_A42SupplierGenId[0];
               AV29count = (long)(AV29count+1);
               BRK844 = true;
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
            if ( ! BRK844 )
            {
               BRK844 = true;
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
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV41FilterFullText ,
                                              AV12TFSupplierGenCompanyName_Sel ,
                                              AV11TFSupplierGenCompanyName ,
                                              AV14TFSupplierGenTypeName_Sel ,
                                              AV13TFSupplierGenTypeName ,
                                              AV16TFSupplierGenContactName_Sel ,
                                              AV15TFSupplierGenContactName ,
                                              AV18TFSupplierGenContactPhone_Sel ,
                                              AV17TFSupplierGenContactPhone ,
                                              A44SupplierGenCompanyName ,
                                              A290SupplierGenTypeName ,
                                              A47SupplierGenContactName ,
                                              A48SupplierGenContactPhone ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV11TFSupplierGenCompanyName = StringUtil.Concat( StringUtil.RTrim( AV11TFSupplierGenCompanyName), "%", "");
         lV13TFSupplierGenTypeName = StringUtil.Concat( StringUtil.RTrim( AV13TFSupplierGenTypeName), "%", "");
         lV15TFSupplierGenContactName = StringUtil.Concat( StringUtil.RTrim( AV15TFSupplierGenContactName), "%", "");
         lV17TFSupplierGenContactPhone = StringUtil.PadR( StringUtil.RTrim( AV17TFSupplierGenContactPhone), 20, "%");
         /* Using cursor P00844 */
         pr_default.execute(2, new Object[] {lV41FilterFullText, lV41FilterFullText, lV41FilterFullText, lV41FilterFullText, lV11TFSupplierGenCompanyName, AV12TFSupplierGenCompanyName_Sel, lV13TFSupplierGenTypeName, AV14TFSupplierGenTypeName_Sel, lV15TFSupplierGenContactName, AV16TFSupplierGenContactName_Sel, lV17TFSupplierGenContactPhone, AV18TFSupplierGenContactPhone_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK846 = false;
            A282SupplierGenTypeId = P00844_A282SupplierGenTypeId[0];
            A47SupplierGenContactName = P00844_A47SupplierGenContactName[0];
            A11OrganisationId = P00844_A11OrganisationId[0];
            n11OrganisationId = P00844_n11OrganisationId[0];
            A48SupplierGenContactPhone = P00844_A48SupplierGenContactPhone[0];
            A290SupplierGenTypeName = P00844_A290SupplierGenTypeName[0];
            A44SupplierGenCompanyName = P00844_A44SupplierGenCompanyName[0];
            A42SupplierGenId = P00844_A42SupplierGenId[0];
            A290SupplierGenTypeName = P00844_A290SupplierGenTypeName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00844_A47SupplierGenContactName[0], A47SupplierGenContactName) == 0 ) )
            {
               BRK846 = false;
               A42SupplierGenId = P00844_A42SupplierGenId[0];
               AV29count = (long)(AV29count+1);
               BRK846 = true;
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
            if ( ! BRK846 )
            {
               BRK846 = true;
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
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV41FilterFullText ,
                                              AV12TFSupplierGenCompanyName_Sel ,
                                              AV11TFSupplierGenCompanyName ,
                                              AV14TFSupplierGenTypeName_Sel ,
                                              AV13TFSupplierGenTypeName ,
                                              AV16TFSupplierGenContactName_Sel ,
                                              AV15TFSupplierGenContactName ,
                                              AV18TFSupplierGenContactPhone_Sel ,
                                              AV17TFSupplierGenContactPhone ,
                                              A44SupplierGenCompanyName ,
                                              A290SupplierGenTypeName ,
                                              A47SupplierGenContactName ,
                                              A48SupplierGenContactPhone ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV11TFSupplierGenCompanyName = StringUtil.Concat( StringUtil.RTrim( AV11TFSupplierGenCompanyName), "%", "");
         lV13TFSupplierGenTypeName = StringUtil.Concat( StringUtil.RTrim( AV13TFSupplierGenTypeName), "%", "");
         lV15TFSupplierGenContactName = StringUtil.Concat( StringUtil.RTrim( AV15TFSupplierGenContactName), "%", "");
         lV17TFSupplierGenContactPhone = StringUtil.PadR( StringUtil.RTrim( AV17TFSupplierGenContactPhone), 20, "%");
         /* Using cursor P00845 */
         pr_default.execute(3, new Object[] {lV41FilterFullText, lV41FilterFullText, lV41FilterFullText, lV41FilterFullText, lV11TFSupplierGenCompanyName, AV12TFSupplierGenCompanyName_Sel, lV13TFSupplierGenTypeName, AV14TFSupplierGenTypeName_Sel, lV15TFSupplierGenContactName, AV16TFSupplierGenContactName_Sel, lV17TFSupplierGenContactPhone, AV18TFSupplierGenContactPhone_Sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK848 = false;
            A282SupplierGenTypeId = P00845_A282SupplierGenTypeId[0];
            A48SupplierGenContactPhone = P00845_A48SupplierGenContactPhone[0];
            A11OrganisationId = P00845_A11OrganisationId[0];
            n11OrganisationId = P00845_n11OrganisationId[0];
            A47SupplierGenContactName = P00845_A47SupplierGenContactName[0];
            A290SupplierGenTypeName = P00845_A290SupplierGenTypeName[0];
            A44SupplierGenCompanyName = P00845_A44SupplierGenCompanyName[0];
            A42SupplierGenId = P00845_A42SupplierGenId[0];
            A290SupplierGenTypeName = P00845_A290SupplierGenTypeName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00845_A48SupplierGenContactPhone[0], A48SupplierGenContactPhone) == 0 ) )
            {
               BRK848 = false;
               A42SupplierGenId = P00845_A42SupplierGenId[0];
               AV29count = (long)(AV29count+1);
               BRK848 = true;
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
            if ( ! BRK848 )
            {
               BRK848 = true;
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
         lV41FilterFullText = "";
         lV11TFSupplierGenCompanyName = "";
         lV13TFSupplierGenTypeName = "";
         lV15TFSupplierGenContactName = "";
         lV17TFSupplierGenContactPhone = "";
         A44SupplierGenCompanyName = "";
         A290SupplierGenTypeName = "";
         A47SupplierGenContactName = "";
         A48SupplierGenContactPhone = "";
         A11OrganisationId = Guid.Empty;
         P00842_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         P00842_A44SupplierGenCompanyName = new string[] {""} ;
         P00842_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00842_n11OrganisationId = new bool[] {false} ;
         P00842_A48SupplierGenContactPhone = new string[] {""} ;
         P00842_A47SupplierGenContactName = new string[] {""} ;
         P00842_A290SupplierGenTypeName = new string[] {""} ;
         P00842_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         A282SupplierGenTypeId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         AV24Option = "";
         P00843_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         P00843_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00843_n11OrganisationId = new bool[] {false} ;
         P00843_A48SupplierGenContactPhone = new string[] {""} ;
         P00843_A47SupplierGenContactName = new string[] {""} ;
         P00843_A290SupplierGenTypeName = new string[] {""} ;
         P00843_A44SupplierGenCompanyName = new string[] {""} ;
         P00843_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00844_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         P00844_A47SupplierGenContactName = new string[] {""} ;
         P00844_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00844_n11OrganisationId = new bool[] {false} ;
         P00844_A48SupplierGenContactPhone = new string[] {""} ;
         P00844_A290SupplierGenTypeName = new string[] {""} ;
         P00844_A44SupplierGenCompanyName = new string[] {""} ;
         P00844_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00845_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         P00845_A48SupplierGenContactPhone = new string[] {""} ;
         P00845_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00845_n11OrganisationId = new bool[] {false} ;
         P00845_A47SupplierGenContactName = new string[] {""} ;
         P00845_A290SupplierGenTypeName = new string[] {""} ;
         P00845_A44SupplierGenCompanyName = new string[] {""} ;
         P00845_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_organisationnationalgensupplierswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00842_A282SupplierGenTypeId, P00842_A44SupplierGenCompanyName, P00842_A11OrganisationId, P00842_n11OrganisationId, P00842_A48SupplierGenContactPhone, P00842_A47SupplierGenContactName, P00842_A290SupplierGenTypeName, P00842_A42SupplierGenId
               }
               , new Object[] {
               P00843_A282SupplierGenTypeId, P00843_A11OrganisationId, P00843_n11OrganisationId, P00843_A48SupplierGenContactPhone, P00843_A47SupplierGenContactName, P00843_A290SupplierGenTypeName, P00843_A44SupplierGenCompanyName, P00843_A42SupplierGenId
               }
               , new Object[] {
               P00844_A282SupplierGenTypeId, P00844_A47SupplierGenContactName, P00844_A11OrganisationId, P00844_n11OrganisationId, P00844_A48SupplierGenContactPhone, P00844_A290SupplierGenTypeName, P00844_A44SupplierGenCompanyName, P00844_A42SupplierGenId
               }
               , new Object[] {
               P00845_A282SupplierGenTypeId, P00845_A48SupplierGenContactPhone, P00845_A11OrganisationId, P00845_n11OrganisationId, P00845_A47SupplierGenContactName, P00845_A290SupplierGenTypeName, P00845_A44SupplierGenCompanyName, P00845_A42SupplierGenId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private int AV43GXV1 ;
      private int AV23InsertIndex ;
      private long AV29count ;
      private string AV17TFSupplierGenContactPhone ;
      private string AV18TFSupplierGenContactPhone_Sel ;
      private string lV17TFSupplierGenContactPhone ;
      private string A48SupplierGenContactPhone ;
      private bool returnInSub ;
      private bool BRK842 ;
      private bool n11OrganisationId ;
      private bool BRK844 ;
      private bool BRK846 ;
      private bool BRK848 ;
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
      private string lV41FilterFullText ;
      private string lV11TFSupplierGenCompanyName ;
      private string lV13TFSupplierGenTypeName ;
      private string lV15TFSupplierGenContactName ;
      private string A44SupplierGenCompanyName ;
      private string A290SupplierGenTypeName ;
      private string A47SupplierGenContactName ;
      private string AV24Option ;
      private Guid A11OrganisationId ;
      private Guid A282SupplierGenTypeId ;
      private Guid A42SupplierGenId ;
      private IGxSession AV30Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV27OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00842_A282SupplierGenTypeId ;
      private string[] P00842_A44SupplierGenCompanyName ;
      private Guid[] P00842_A11OrganisationId ;
      private bool[] P00842_n11OrganisationId ;
      private string[] P00842_A48SupplierGenContactPhone ;
      private string[] P00842_A47SupplierGenContactName ;
      private string[] P00842_A290SupplierGenTypeName ;
      private Guid[] P00842_A42SupplierGenId ;
      private Guid[] P00843_A282SupplierGenTypeId ;
      private Guid[] P00843_A11OrganisationId ;
      private bool[] P00843_n11OrganisationId ;
      private string[] P00843_A48SupplierGenContactPhone ;
      private string[] P00843_A47SupplierGenContactName ;
      private string[] P00843_A290SupplierGenTypeName ;
      private string[] P00843_A44SupplierGenCompanyName ;
      private Guid[] P00843_A42SupplierGenId ;
      private Guid[] P00844_A282SupplierGenTypeId ;
      private string[] P00844_A47SupplierGenContactName ;
      private Guid[] P00844_A11OrganisationId ;
      private bool[] P00844_n11OrganisationId ;
      private string[] P00844_A48SupplierGenContactPhone ;
      private string[] P00844_A290SupplierGenTypeName ;
      private string[] P00844_A44SupplierGenCompanyName ;
      private Guid[] P00844_A42SupplierGenId ;
      private Guid[] P00845_A282SupplierGenTypeId ;
      private string[] P00845_A48SupplierGenContactPhone ;
      private Guid[] P00845_A11OrganisationId ;
      private bool[] P00845_n11OrganisationId ;
      private string[] P00845_A47SupplierGenContactName ;
      private string[] P00845_A290SupplierGenTypeName ;
      private string[] P00845_A44SupplierGenCompanyName ;
      private Guid[] P00845_A42SupplierGenId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wp_organisationnationalgensupplierswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00842( IGxContext context ,
                                             string AV41FilterFullText ,
                                             string AV12TFSupplierGenCompanyName_Sel ,
                                             string AV11TFSupplierGenCompanyName ,
                                             string AV14TFSupplierGenTypeName_Sel ,
                                             string AV13TFSupplierGenTypeName ,
                                             string AV16TFSupplierGenContactName_Sel ,
                                             string AV15TFSupplierGenContactName ,
                                             string AV18TFSupplierGenContactPhone_Sel ,
                                             string AV17TFSupplierGenContactPhone ,
                                             string A44SupplierGenCompanyName ,
                                             string A290SupplierGenTypeName ,
                                             string A47SupplierGenContactName ,
                                             string A48SupplierGenContactPhone ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SupplierGenTypeId, T1.SupplierGenCompanyName, T1.OrganisationId, T1.SupplierGenContactPhone, T1.SupplierGenContactName, T2.SupplierGenTypeName, T1.SupplierGenId FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierGenCompanyName like '%' || :lV41FilterFullText) or ( T2.SupplierGenTypeName like '%' || :lV41FilterFullText) or ( T1.SupplierGenContactName like '%' || :lV41FilterFullText) or ( T1.SupplierGenContactPhone like '%' || :lV41FilterFullText))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierGenCompanyName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSupplierGenCompanyName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName like :lV11TFSupplierGenCompanyName)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierGenCompanyName_Sel)) && ! ( StringUtil.StrCmp(AV12TFSupplierGenCompanyName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName = ( :AV12TFSupplierGenCompanyName_Sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFSupplierGenCompanyName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierGenTypeName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSupplierGenTypeName)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName like :lV13TFSupplierGenTypeName)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierGenTypeName_Sel)) && ! ( StringUtil.StrCmp(AV14TFSupplierGenTypeName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName = ( :AV14TFSupplierGenTypeName_Sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFSupplierGenTypeName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierGenContactName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSupplierGenContactName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName like :lV15TFSupplierGenContactName)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierGenContactName_Sel)) && ! ( StringUtil.StrCmp(AV16TFSupplierGenContactName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName = ( :AV16TFSupplierGenContactName_Sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFSupplierGenContactName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierGenContactPhone_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFSupplierGenContactPhone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone like :lV17TFSupplierGenContactPhone)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierGenContactPhone_Sel)) && ! ( StringUtil.StrCmp(AV18TFSupplierGenContactPhone_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone = ( :AV18TFSupplierGenContactPhone_Sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFSupplierGenContactPhone_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactPhone))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierGenCompanyName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00843( IGxContext context ,
                                             string AV41FilterFullText ,
                                             string AV12TFSupplierGenCompanyName_Sel ,
                                             string AV11TFSupplierGenCompanyName ,
                                             string AV14TFSupplierGenTypeName_Sel ,
                                             string AV13TFSupplierGenTypeName ,
                                             string AV16TFSupplierGenContactName_Sel ,
                                             string AV15TFSupplierGenContactName ,
                                             string AV18TFSupplierGenContactPhone_Sel ,
                                             string AV17TFSupplierGenContactPhone ,
                                             string A44SupplierGenCompanyName ,
                                             string A290SupplierGenTypeName ,
                                             string A47SupplierGenContactName ,
                                             string A48SupplierGenContactPhone ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SupplierGenTypeId, T1.OrganisationId, T1.SupplierGenContactPhone, T1.SupplierGenContactName, T2.SupplierGenTypeName, T1.SupplierGenCompanyName, T1.SupplierGenId FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierGenCompanyName like '%' || :lV41FilterFullText) or ( T2.SupplierGenTypeName like '%' || :lV41FilterFullText) or ( T1.SupplierGenContactName like '%' || :lV41FilterFullText) or ( T1.SupplierGenContactPhone like '%' || :lV41FilterFullText))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierGenCompanyName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSupplierGenCompanyName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName like :lV11TFSupplierGenCompanyName)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierGenCompanyName_Sel)) && ! ( StringUtil.StrCmp(AV12TFSupplierGenCompanyName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName = ( :AV12TFSupplierGenCompanyName_Sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFSupplierGenCompanyName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierGenTypeName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSupplierGenTypeName)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName like :lV13TFSupplierGenTypeName)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierGenTypeName_Sel)) && ! ( StringUtil.StrCmp(AV14TFSupplierGenTypeName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName = ( :AV14TFSupplierGenTypeName_Sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFSupplierGenTypeName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierGenContactName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSupplierGenContactName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName like :lV15TFSupplierGenContactName)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierGenContactName_Sel)) && ! ( StringUtil.StrCmp(AV16TFSupplierGenContactName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName = ( :AV16TFSupplierGenContactName_Sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFSupplierGenContactName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierGenContactPhone_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFSupplierGenContactPhone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone like :lV17TFSupplierGenContactPhone)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierGenContactPhone_Sel)) && ! ( StringUtil.StrCmp(AV18TFSupplierGenContactPhone_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone = ( :AV18TFSupplierGenContactPhone_Sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFSupplierGenContactPhone_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactPhone))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierGenTypeId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00844( IGxContext context ,
                                             string AV41FilterFullText ,
                                             string AV12TFSupplierGenCompanyName_Sel ,
                                             string AV11TFSupplierGenCompanyName ,
                                             string AV14TFSupplierGenTypeName_Sel ,
                                             string AV13TFSupplierGenTypeName ,
                                             string AV16TFSupplierGenContactName_Sel ,
                                             string AV15TFSupplierGenContactName ,
                                             string AV18TFSupplierGenContactPhone_Sel ,
                                             string AV17TFSupplierGenContactPhone ,
                                             string A44SupplierGenCompanyName ,
                                             string A290SupplierGenTypeName ,
                                             string A47SupplierGenContactName ,
                                             string A48SupplierGenContactPhone ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[12];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.SupplierGenTypeId, T1.SupplierGenContactName, T1.OrganisationId, T1.SupplierGenContactPhone, T2.SupplierGenTypeName, T1.SupplierGenCompanyName, T1.SupplierGenId FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierGenCompanyName like '%' || :lV41FilterFullText) or ( T2.SupplierGenTypeName like '%' || :lV41FilterFullText) or ( T1.SupplierGenContactName like '%' || :lV41FilterFullText) or ( T1.SupplierGenContactPhone like '%' || :lV41FilterFullText))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierGenCompanyName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSupplierGenCompanyName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName like :lV11TFSupplierGenCompanyName)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierGenCompanyName_Sel)) && ! ( StringUtil.StrCmp(AV12TFSupplierGenCompanyName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName = ( :AV12TFSupplierGenCompanyName_Sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFSupplierGenCompanyName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierGenTypeName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSupplierGenTypeName)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName like :lV13TFSupplierGenTypeName)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierGenTypeName_Sel)) && ! ( StringUtil.StrCmp(AV14TFSupplierGenTypeName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName = ( :AV14TFSupplierGenTypeName_Sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFSupplierGenTypeName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierGenContactName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSupplierGenContactName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName like :lV15TFSupplierGenContactName)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierGenContactName_Sel)) && ! ( StringUtil.StrCmp(AV16TFSupplierGenContactName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName = ( :AV16TFSupplierGenContactName_Sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFSupplierGenContactName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierGenContactPhone_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFSupplierGenContactPhone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone like :lV17TFSupplierGenContactPhone)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierGenContactPhone_Sel)) && ! ( StringUtil.StrCmp(AV18TFSupplierGenContactPhone_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone = ( :AV18TFSupplierGenContactPhone_Sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFSupplierGenContactPhone_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactPhone))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierGenContactName";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00845( IGxContext context ,
                                             string AV41FilterFullText ,
                                             string AV12TFSupplierGenCompanyName_Sel ,
                                             string AV11TFSupplierGenCompanyName ,
                                             string AV14TFSupplierGenTypeName_Sel ,
                                             string AV13TFSupplierGenTypeName ,
                                             string AV16TFSupplierGenContactName_Sel ,
                                             string AV15TFSupplierGenContactName ,
                                             string AV18TFSupplierGenContactPhone_Sel ,
                                             string AV17TFSupplierGenContactPhone ,
                                             string A44SupplierGenCompanyName ,
                                             string A290SupplierGenTypeName ,
                                             string A47SupplierGenContactName ,
                                             string A48SupplierGenContactPhone ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[12];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.SupplierGenTypeId, T1.SupplierGenContactPhone, T1.OrganisationId, T1.SupplierGenContactName, T2.SupplierGenTypeName, T1.SupplierGenCompanyName, T1.SupplierGenId FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierGenCompanyName like '%' || :lV41FilterFullText) or ( T2.SupplierGenTypeName like '%' || :lV41FilterFullText) or ( T1.SupplierGenContactName like '%' || :lV41FilterFullText) or ( T1.SupplierGenContactPhone like '%' || :lV41FilterFullText))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierGenCompanyName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSupplierGenCompanyName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName like :lV11TFSupplierGenCompanyName)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierGenCompanyName_Sel)) && ! ( StringUtil.StrCmp(AV12TFSupplierGenCompanyName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName = ( :AV12TFSupplierGenCompanyName_Sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFSupplierGenCompanyName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierGenTypeName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSupplierGenTypeName)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName like :lV13TFSupplierGenTypeName)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierGenTypeName_Sel)) && ! ( StringUtil.StrCmp(AV14TFSupplierGenTypeName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName = ( :AV14TFSupplierGenTypeName_Sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFSupplierGenTypeName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierGenContactName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSupplierGenContactName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName like :lV15TFSupplierGenContactName)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierGenContactName_Sel)) && ! ( StringUtil.StrCmp(AV16TFSupplierGenContactName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName = ( :AV16TFSupplierGenContactName_Sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFSupplierGenContactName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierGenContactPhone_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFSupplierGenContactPhone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone like :lV17TFSupplierGenContactPhone)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierGenContactPhone_Sel)) && ! ( StringUtil.StrCmp(AV18TFSupplierGenContactPhone_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone = ( :AV18TFSupplierGenContactPhone_Sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFSupplierGenContactPhone_Sel, "<#Empty#>") == 0 )
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
                     return conditional_P00842(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (Guid)dynConstraints[13] );
               case 1 :
                     return conditional_P00843(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (Guid)dynConstraints[13] );
               case 2 :
                     return conditional_P00844(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (Guid)dynConstraints[13] );
               case 3 :
                     return conditional_P00845(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (Guid)dynConstraints[13] );
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
          Object[] prmP00842;
          prmP00842 = new Object[] {
          new ParDef("lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV11TFSupplierGenCompanyName",GXType.VarChar,100,0) ,
          new ParDef("AV12TFSupplierGenCompanyName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV13TFSupplierGenTypeName",GXType.VarChar,100,0) ,
          new ParDef("AV14TFSupplierGenTypeName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV15TFSupplierGenContactName",GXType.VarChar,100,0) ,
          new ParDef("AV16TFSupplierGenContactName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV17TFSupplierGenContactPhone",GXType.Char,20,0) ,
          new ParDef("AV18TFSupplierGenContactPhone_Sel",GXType.Char,20,0)
          };
          Object[] prmP00843;
          prmP00843 = new Object[] {
          new ParDef("lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV11TFSupplierGenCompanyName",GXType.VarChar,100,0) ,
          new ParDef("AV12TFSupplierGenCompanyName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV13TFSupplierGenTypeName",GXType.VarChar,100,0) ,
          new ParDef("AV14TFSupplierGenTypeName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV15TFSupplierGenContactName",GXType.VarChar,100,0) ,
          new ParDef("AV16TFSupplierGenContactName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV17TFSupplierGenContactPhone",GXType.Char,20,0) ,
          new ParDef("AV18TFSupplierGenContactPhone_Sel",GXType.Char,20,0)
          };
          Object[] prmP00844;
          prmP00844 = new Object[] {
          new ParDef("lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV11TFSupplierGenCompanyName",GXType.VarChar,100,0) ,
          new ParDef("AV12TFSupplierGenCompanyName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV13TFSupplierGenTypeName",GXType.VarChar,100,0) ,
          new ParDef("AV14TFSupplierGenTypeName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV15TFSupplierGenContactName",GXType.VarChar,100,0) ,
          new ParDef("AV16TFSupplierGenContactName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV17TFSupplierGenContactPhone",GXType.Char,20,0) ,
          new ParDef("AV18TFSupplierGenContactPhone_Sel",GXType.Char,20,0)
          };
          Object[] prmP00845;
          prmP00845 = new Object[] {
          new ParDef("lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV11TFSupplierGenCompanyName",GXType.VarChar,100,0) ,
          new ParDef("AV12TFSupplierGenCompanyName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV13TFSupplierGenTypeName",GXType.VarChar,100,0) ,
          new ParDef("AV14TFSupplierGenTypeName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV15TFSupplierGenContactName",GXType.VarChar,100,0) ,
          new ParDef("AV16TFSupplierGenContactName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV17TFSupplierGenContactPhone",GXType.Char,20,0) ,
          new ParDef("AV18TFSupplierGenContactPhone_Sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00842", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00842,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00843", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00843,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00844", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00844,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00845", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00845,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[7])[0] = rslt.getGuid(7);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[7])[0] = rslt.getGuid(7);
                return;
       }
    }

 }

}
