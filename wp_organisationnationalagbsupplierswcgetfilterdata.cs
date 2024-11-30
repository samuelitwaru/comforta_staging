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
   public class wp_organisationnationalagbsupplierswcgetfilterdata : GXProcedure
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
            return "wp_organisationagbsuppliers_Services_Execute" ;
         }

      }

      public wp_organisationnationalagbsupplierswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_organisationnationalagbsupplierswcgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_SUPPLIERAGBNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERAGBNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_SUPPLIERAGBTYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERAGBTYPENAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_SUPPLIERAGBCONTACTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERAGBCONTACTNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_SUPPLIERAGBPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERAGBPHONEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_SUPPLIERAGBEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERAGBEMAILOPTIONS' */
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
         if ( StringUtil.StrCmp(AV32Session.Get("WP_OrganisationNationalAGBSuppliersWCGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WP_OrganisationNationalAGBSuppliersWCGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("WP_OrganisationNationalAGBSuppliersWCGridState"), null, "", "");
         }
         AV45GXV1 = 1;
         while ( AV45GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV45GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBNAME") == 0 )
            {
               AV11TFSupplierAgbName = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBNAME_SEL") == 0 )
            {
               AV12TFSupplierAgbName_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBTYPENAME") == 0 )
            {
               AV13TFSupplierAgbTypeName = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBTYPENAME_SEL") == 0 )
            {
               AV14TFSupplierAgbTypeName_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBCONTACTNAME") == 0 )
            {
               AV15TFSupplierAgbContactName = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBCONTACTNAME_SEL") == 0 )
            {
               AV16TFSupplierAgbContactName_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBPHONE") == 0 )
            {
               AV17TFSupplierAgbPhone = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBPHONE_SEL") == 0 )
            {
               AV18TFSupplierAgbPhone_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBEMAIL") == 0 )
            {
               AV19TFSupplierAgbEmail = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBEMAIL_SEL") == 0 )
            {
               AV20TFSupplierAgbEmail_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV45GXV1 = (int)(AV45GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSUPPLIERAGBNAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFSupplierAgbName = AV21SearchTxt;
         AV12TFSupplierAgbName_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV43FilterFullText ,
                                              AV12TFSupplierAgbName_Sel ,
                                              AV11TFSupplierAgbName ,
                                              AV14TFSupplierAgbTypeName_Sel ,
                                              AV13TFSupplierAgbTypeName ,
                                              AV16TFSupplierAgbContactName_Sel ,
                                              AV15TFSupplierAgbContactName ,
                                              AV18TFSupplierAgbPhone_Sel ,
                                              AV17TFSupplierAgbPhone ,
                                              AV20TFSupplierAgbEmail_Sel ,
                                              AV19TFSupplierAgbEmail ,
                                              A51SupplierAgbName ,
                                              A291SupplierAgbTypeName ,
                                              A55SupplierAgbContactName ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV11TFSupplierAgbName = StringUtil.Concat( StringUtil.RTrim( AV11TFSupplierAgbName), "%", "");
         lV13TFSupplierAgbTypeName = StringUtil.Concat( StringUtil.RTrim( AV13TFSupplierAgbTypeName), "%", "");
         lV15TFSupplierAgbContactName = StringUtil.Concat( StringUtil.RTrim( AV15TFSupplierAgbContactName), "%", "");
         lV17TFSupplierAgbPhone = StringUtil.PadR( StringUtil.RTrim( AV17TFSupplierAgbPhone), 20, "%");
         lV19TFSupplierAgbEmail = StringUtil.Concat( StringUtil.RTrim( AV19TFSupplierAgbEmail), "%", "");
         /* Using cursor P00862 */
         pr_default.execute(0, new Object[] {lV43FilterFullText, lV43FilterFullText, lV43FilterFullText, lV43FilterFullText, lV43FilterFullText, lV11TFSupplierAgbName, AV12TFSupplierAgbName_Sel, lV13TFSupplierAgbTypeName, AV14TFSupplierAgbTypeName_Sel, lV15TFSupplierAgbContactName, AV16TFSupplierAgbContactName_Sel, lV17TFSupplierAgbPhone, AV18TFSupplierAgbPhone_Sel, lV19TFSupplierAgbEmail, AV20TFSupplierAgbEmail_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK862 = false;
            A283SupplierAgbTypeId = P00862_A283SupplierAgbTypeId[0];
            A51SupplierAgbName = P00862_A51SupplierAgbName[0];
            A11OrganisationId = P00862_A11OrganisationId[0];
            n11OrganisationId = P00862_n11OrganisationId[0];
            A57SupplierAgbEmail = P00862_A57SupplierAgbEmail[0];
            A56SupplierAgbPhone = P00862_A56SupplierAgbPhone[0];
            A55SupplierAgbContactName = P00862_A55SupplierAgbContactName[0];
            A291SupplierAgbTypeName = P00862_A291SupplierAgbTypeName[0];
            A49SupplierAgbId = P00862_A49SupplierAgbId[0];
            A291SupplierAgbTypeName = P00862_A291SupplierAgbTypeName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00862_A51SupplierAgbName[0], A51SupplierAgbName) == 0 ) )
            {
               BRK862 = false;
               A49SupplierAgbId = P00862_A49SupplierAgbId[0];
               AV31count = (long)(AV31count+1);
               BRK862 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A51SupplierAgbName)) ? "<#Empty#>" : A51SupplierAgbName);
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
            if ( ! BRK862 )
            {
               BRK862 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSUPPLIERAGBTYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFSupplierAgbTypeName = AV21SearchTxt;
         AV14TFSupplierAgbTypeName_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV43FilterFullText ,
                                              AV12TFSupplierAgbName_Sel ,
                                              AV11TFSupplierAgbName ,
                                              AV14TFSupplierAgbTypeName_Sel ,
                                              AV13TFSupplierAgbTypeName ,
                                              AV16TFSupplierAgbContactName_Sel ,
                                              AV15TFSupplierAgbContactName ,
                                              AV18TFSupplierAgbPhone_Sel ,
                                              AV17TFSupplierAgbPhone ,
                                              AV20TFSupplierAgbEmail_Sel ,
                                              AV19TFSupplierAgbEmail ,
                                              A51SupplierAgbName ,
                                              A291SupplierAgbTypeName ,
                                              A55SupplierAgbContactName ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV11TFSupplierAgbName = StringUtil.Concat( StringUtil.RTrim( AV11TFSupplierAgbName), "%", "");
         lV13TFSupplierAgbTypeName = StringUtil.Concat( StringUtil.RTrim( AV13TFSupplierAgbTypeName), "%", "");
         lV15TFSupplierAgbContactName = StringUtil.Concat( StringUtil.RTrim( AV15TFSupplierAgbContactName), "%", "");
         lV17TFSupplierAgbPhone = StringUtil.PadR( StringUtil.RTrim( AV17TFSupplierAgbPhone), 20, "%");
         lV19TFSupplierAgbEmail = StringUtil.Concat( StringUtil.RTrim( AV19TFSupplierAgbEmail), "%", "");
         /* Using cursor P00863 */
         pr_default.execute(1, new Object[] {lV43FilterFullText, lV43FilterFullText, lV43FilterFullText, lV43FilterFullText, lV43FilterFullText, lV11TFSupplierAgbName, AV12TFSupplierAgbName_Sel, lV13TFSupplierAgbTypeName, AV14TFSupplierAgbTypeName_Sel, lV15TFSupplierAgbContactName, AV16TFSupplierAgbContactName_Sel, lV17TFSupplierAgbPhone, AV18TFSupplierAgbPhone_Sel, lV19TFSupplierAgbEmail, AV20TFSupplierAgbEmail_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK864 = false;
            A283SupplierAgbTypeId = P00863_A283SupplierAgbTypeId[0];
            A11OrganisationId = P00863_A11OrganisationId[0];
            n11OrganisationId = P00863_n11OrganisationId[0];
            A57SupplierAgbEmail = P00863_A57SupplierAgbEmail[0];
            A56SupplierAgbPhone = P00863_A56SupplierAgbPhone[0];
            A55SupplierAgbContactName = P00863_A55SupplierAgbContactName[0];
            A291SupplierAgbTypeName = P00863_A291SupplierAgbTypeName[0];
            A51SupplierAgbName = P00863_A51SupplierAgbName[0];
            A49SupplierAgbId = P00863_A49SupplierAgbId[0];
            A291SupplierAgbTypeName = P00863_A291SupplierAgbTypeName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00863_A283SupplierAgbTypeId[0] == A283SupplierAgbTypeId ) )
            {
               BRK864 = false;
               A49SupplierAgbId = P00863_A49SupplierAgbId[0];
               AV31count = (long)(AV31count+1);
               BRK864 = true;
               pr_default.readNext(1);
            }
            AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A291SupplierAgbTypeName)) ? "<#Empty#>" : A291SupplierAgbTypeName);
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
            if ( ! BRK864 )
            {
               BRK864 = true;
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
         /* 'LOADSUPPLIERAGBCONTACTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFSupplierAgbContactName = AV21SearchTxt;
         AV16TFSupplierAgbContactName_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV43FilterFullText ,
                                              AV12TFSupplierAgbName_Sel ,
                                              AV11TFSupplierAgbName ,
                                              AV14TFSupplierAgbTypeName_Sel ,
                                              AV13TFSupplierAgbTypeName ,
                                              AV16TFSupplierAgbContactName_Sel ,
                                              AV15TFSupplierAgbContactName ,
                                              AV18TFSupplierAgbPhone_Sel ,
                                              AV17TFSupplierAgbPhone ,
                                              AV20TFSupplierAgbEmail_Sel ,
                                              AV19TFSupplierAgbEmail ,
                                              A51SupplierAgbName ,
                                              A291SupplierAgbTypeName ,
                                              A55SupplierAgbContactName ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV11TFSupplierAgbName = StringUtil.Concat( StringUtil.RTrim( AV11TFSupplierAgbName), "%", "");
         lV13TFSupplierAgbTypeName = StringUtil.Concat( StringUtil.RTrim( AV13TFSupplierAgbTypeName), "%", "");
         lV15TFSupplierAgbContactName = StringUtil.Concat( StringUtil.RTrim( AV15TFSupplierAgbContactName), "%", "");
         lV17TFSupplierAgbPhone = StringUtil.PadR( StringUtil.RTrim( AV17TFSupplierAgbPhone), 20, "%");
         lV19TFSupplierAgbEmail = StringUtil.Concat( StringUtil.RTrim( AV19TFSupplierAgbEmail), "%", "");
         /* Using cursor P00864 */
         pr_default.execute(2, new Object[] {lV43FilterFullText, lV43FilterFullText, lV43FilterFullText, lV43FilterFullText, lV43FilterFullText, lV11TFSupplierAgbName, AV12TFSupplierAgbName_Sel, lV13TFSupplierAgbTypeName, AV14TFSupplierAgbTypeName_Sel, lV15TFSupplierAgbContactName, AV16TFSupplierAgbContactName_Sel, lV17TFSupplierAgbPhone, AV18TFSupplierAgbPhone_Sel, lV19TFSupplierAgbEmail, AV20TFSupplierAgbEmail_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK866 = false;
            A283SupplierAgbTypeId = P00864_A283SupplierAgbTypeId[0];
            A55SupplierAgbContactName = P00864_A55SupplierAgbContactName[0];
            A11OrganisationId = P00864_A11OrganisationId[0];
            n11OrganisationId = P00864_n11OrganisationId[0];
            A57SupplierAgbEmail = P00864_A57SupplierAgbEmail[0];
            A56SupplierAgbPhone = P00864_A56SupplierAgbPhone[0];
            A291SupplierAgbTypeName = P00864_A291SupplierAgbTypeName[0];
            A51SupplierAgbName = P00864_A51SupplierAgbName[0];
            A49SupplierAgbId = P00864_A49SupplierAgbId[0];
            A291SupplierAgbTypeName = P00864_A291SupplierAgbTypeName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00864_A55SupplierAgbContactName[0], A55SupplierAgbContactName) == 0 ) )
            {
               BRK866 = false;
               A49SupplierAgbId = P00864_A49SupplierAgbId[0];
               AV31count = (long)(AV31count+1);
               BRK866 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A55SupplierAgbContactName)) ? "<#Empty#>" : A55SupplierAgbContactName);
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
            if ( ! BRK866 )
            {
               BRK866 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADSUPPLIERAGBPHONEOPTIONS' Routine */
         returnInSub = false;
         AV17TFSupplierAgbPhone = AV21SearchTxt;
         AV18TFSupplierAgbPhone_Sel = "";
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV43FilterFullText ,
                                              AV12TFSupplierAgbName_Sel ,
                                              AV11TFSupplierAgbName ,
                                              AV14TFSupplierAgbTypeName_Sel ,
                                              AV13TFSupplierAgbTypeName ,
                                              AV16TFSupplierAgbContactName_Sel ,
                                              AV15TFSupplierAgbContactName ,
                                              AV18TFSupplierAgbPhone_Sel ,
                                              AV17TFSupplierAgbPhone ,
                                              AV20TFSupplierAgbEmail_Sel ,
                                              AV19TFSupplierAgbEmail ,
                                              A51SupplierAgbName ,
                                              A291SupplierAgbTypeName ,
                                              A55SupplierAgbContactName ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV11TFSupplierAgbName = StringUtil.Concat( StringUtil.RTrim( AV11TFSupplierAgbName), "%", "");
         lV13TFSupplierAgbTypeName = StringUtil.Concat( StringUtil.RTrim( AV13TFSupplierAgbTypeName), "%", "");
         lV15TFSupplierAgbContactName = StringUtil.Concat( StringUtil.RTrim( AV15TFSupplierAgbContactName), "%", "");
         lV17TFSupplierAgbPhone = StringUtil.PadR( StringUtil.RTrim( AV17TFSupplierAgbPhone), 20, "%");
         lV19TFSupplierAgbEmail = StringUtil.Concat( StringUtil.RTrim( AV19TFSupplierAgbEmail), "%", "");
         /* Using cursor P00865 */
         pr_default.execute(3, new Object[] {lV43FilterFullText, lV43FilterFullText, lV43FilterFullText, lV43FilterFullText, lV43FilterFullText, lV11TFSupplierAgbName, AV12TFSupplierAgbName_Sel, lV13TFSupplierAgbTypeName, AV14TFSupplierAgbTypeName_Sel, lV15TFSupplierAgbContactName, AV16TFSupplierAgbContactName_Sel, lV17TFSupplierAgbPhone, AV18TFSupplierAgbPhone_Sel, lV19TFSupplierAgbEmail, AV20TFSupplierAgbEmail_Sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK868 = false;
            A283SupplierAgbTypeId = P00865_A283SupplierAgbTypeId[0];
            A56SupplierAgbPhone = P00865_A56SupplierAgbPhone[0];
            A11OrganisationId = P00865_A11OrganisationId[0];
            n11OrganisationId = P00865_n11OrganisationId[0];
            A57SupplierAgbEmail = P00865_A57SupplierAgbEmail[0];
            A55SupplierAgbContactName = P00865_A55SupplierAgbContactName[0];
            A291SupplierAgbTypeName = P00865_A291SupplierAgbTypeName[0];
            A51SupplierAgbName = P00865_A51SupplierAgbName[0];
            A49SupplierAgbId = P00865_A49SupplierAgbId[0];
            A291SupplierAgbTypeName = P00865_A291SupplierAgbTypeName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00865_A56SupplierAgbPhone[0], A56SupplierAgbPhone) == 0 ) )
            {
               BRK868 = false;
               A49SupplierAgbId = P00865_A49SupplierAgbId[0];
               AV31count = (long)(AV31count+1);
               BRK868 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A56SupplierAgbPhone)) ? "<#Empty#>" : A56SupplierAgbPhone);
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
            if ( ! BRK868 )
            {
               BRK868 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADSUPPLIERAGBEMAILOPTIONS' Routine */
         returnInSub = false;
         AV19TFSupplierAgbEmail = AV21SearchTxt;
         AV20TFSupplierAgbEmail_Sel = "";
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV43FilterFullText ,
                                              AV12TFSupplierAgbName_Sel ,
                                              AV11TFSupplierAgbName ,
                                              AV14TFSupplierAgbTypeName_Sel ,
                                              AV13TFSupplierAgbTypeName ,
                                              AV16TFSupplierAgbContactName_Sel ,
                                              AV15TFSupplierAgbContactName ,
                                              AV18TFSupplierAgbPhone_Sel ,
                                              AV17TFSupplierAgbPhone ,
                                              AV20TFSupplierAgbEmail_Sel ,
                                              AV19TFSupplierAgbEmail ,
                                              A51SupplierAgbName ,
                                              A291SupplierAgbTypeName ,
                                              A55SupplierAgbContactName ,
                                              A56SupplierAgbPhone ,
                                              A57SupplierAgbEmail ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV43FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV43FilterFullText), "%", "");
         lV11TFSupplierAgbName = StringUtil.Concat( StringUtil.RTrim( AV11TFSupplierAgbName), "%", "");
         lV13TFSupplierAgbTypeName = StringUtil.Concat( StringUtil.RTrim( AV13TFSupplierAgbTypeName), "%", "");
         lV15TFSupplierAgbContactName = StringUtil.Concat( StringUtil.RTrim( AV15TFSupplierAgbContactName), "%", "");
         lV17TFSupplierAgbPhone = StringUtil.PadR( StringUtil.RTrim( AV17TFSupplierAgbPhone), 20, "%");
         lV19TFSupplierAgbEmail = StringUtil.Concat( StringUtil.RTrim( AV19TFSupplierAgbEmail), "%", "");
         /* Using cursor P00866 */
         pr_default.execute(4, new Object[] {lV43FilterFullText, lV43FilterFullText, lV43FilterFullText, lV43FilterFullText, lV43FilterFullText, lV11TFSupplierAgbName, AV12TFSupplierAgbName_Sel, lV13TFSupplierAgbTypeName, AV14TFSupplierAgbTypeName_Sel, lV15TFSupplierAgbContactName, AV16TFSupplierAgbContactName_Sel, lV17TFSupplierAgbPhone, AV18TFSupplierAgbPhone_Sel, lV19TFSupplierAgbEmail, AV20TFSupplierAgbEmail_Sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK8610 = false;
            A283SupplierAgbTypeId = P00866_A283SupplierAgbTypeId[0];
            A57SupplierAgbEmail = P00866_A57SupplierAgbEmail[0];
            A11OrganisationId = P00866_A11OrganisationId[0];
            n11OrganisationId = P00866_n11OrganisationId[0];
            A56SupplierAgbPhone = P00866_A56SupplierAgbPhone[0];
            A55SupplierAgbContactName = P00866_A55SupplierAgbContactName[0];
            A291SupplierAgbTypeName = P00866_A291SupplierAgbTypeName[0];
            A51SupplierAgbName = P00866_A51SupplierAgbName[0];
            A49SupplierAgbId = P00866_A49SupplierAgbId[0];
            A291SupplierAgbTypeName = P00866_A291SupplierAgbTypeName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00866_A57SupplierAgbEmail[0], A57SupplierAgbEmail) == 0 ) )
            {
               BRK8610 = false;
               A49SupplierAgbId = P00866_A49SupplierAgbId[0];
               AV31count = (long)(AV31count+1);
               BRK8610 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A57SupplierAgbEmail)) ? "<#Empty#>" : A57SupplierAgbEmail);
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
            if ( ! BRK8610 )
            {
               BRK8610 = true;
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
         AV11TFSupplierAgbName = "";
         AV12TFSupplierAgbName_Sel = "";
         AV13TFSupplierAgbTypeName = "";
         AV14TFSupplierAgbTypeName_Sel = "";
         AV15TFSupplierAgbContactName = "";
         AV16TFSupplierAgbContactName_Sel = "";
         AV17TFSupplierAgbPhone = "";
         AV18TFSupplierAgbPhone_Sel = "";
         AV19TFSupplierAgbEmail = "";
         AV20TFSupplierAgbEmail_Sel = "";
         lV43FilterFullText = "";
         lV11TFSupplierAgbName = "";
         lV13TFSupplierAgbTypeName = "";
         lV15TFSupplierAgbContactName = "";
         lV17TFSupplierAgbPhone = "";
         lV19TFSupplierAgbEmail = "";
         A51SupplierAgbName = "";
         A291SupplierAgbTypeName = "";
         A55SupplierAgbContactName = "";
         A56SupplierAgbPhone = "";
         A57SupplierAgbEmail = "";
         A11OrganisationId = Guid.Empty;
         P00862_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         P00862_A51SupplierAgbName = new string[] {""} ;
         P00862_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00862_n11OrganisationId = new bool[] {false} ;
         P00862_A57SupplierAgbEmail = new string[] {""} ;
         P00862_A56SupplierAgbPhone = new string[] {""} ;
         P00862_A55SupplierAgbContactName = new string[] {""} ;
         P00862_A291SupplierAgbTypeName = new string[] {""} ;
         P00862_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         A283SupplierAgbTypeId = Guid.Empty;
         A49SupplierAgbId = Guid.Empty;
         AV26Option = "";
         P00863_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         P00863_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00863_n11OrganisationId = new bool[] {false} ;
         P00863_A57SupplierAgbEmail = new string[] {""} ;
         P00863_A56SupplierAgbPhone = new string[] {""} ;
         P00863_A55SupplierAgbContactName = new string[] {""} ;
         P00863_A291SupplierAgbTypeName = new string[] {""} ;
         P00863_A51SupplierAgbName = new string[] {""} ;
         P00863_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P00864_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         P00864_A55SupplierAgbContactName = new string[] {""} ;
         P00864_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00864_n11OrganisationId = new bool[] {false} ;
         P00864_A57SupplierAgbEmail = new string[] {""} ;
         P00864_A56SupplierAgbPhone = new string[] {""} ;
         P00864_A291SupplierAgbTypeName = new string[] {""} ;
         P00864_A51SupplierAgbName = new string[] {""} ;
         P00864_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P00865_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         P00865_A56SupplierAgbPhone = new string[] {""} ;
         P00865_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00865_n11OrganisationId = new bool[] {false} ;
         P00865_A57SupplierAgbEmail = new string[] {""} ;
         P00865_A55SupplierAgbContactName = new string[] {""} ;
         P00865_A291SupplierAgbTypeName = new string[] {""} ;
         P00865_A51SupplierAgbName = new string[] {""} ;
         P00865_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P00866_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         P00866_A57SupplierAgbEmail = new string[] {""} ;
         P00866_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00866_n11OrganisationId = new bool[] {false} ;
         P00866_A56SupplierAgbPhone = new string[] {""} ;
         P00866_A55SupplierAgbContactName = new string[] {""} ;
         P00866_A291SupplierAgbTypeName = new string[] {""} ;
         P00866_A51SupplierAgbName = new string[] {""} ;
         P00866_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_organisationnationalagbsupplierswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00862_A283SupplierAgbTypeId, P00862_A51SupplierAgbName, P00862_A11OrganisationId, P00862_n11OrganisationId, P00862_A57SupplierAgbEmail, P00862_A56SupplierAgbPhone, P00862_A55SupplierAgbContactName, P00862_A291SupplierAgbTypeName, P00862_A49SupplierAgbId
               }
               , new Object[] {
               P00863_A283SupplierAgbTypeId, P00863_A11OrganisationId, P00863_n11OrganisationId, P00863_A57SupplierAgbEmail, P00863_A56SupplierAgbPhone, P00863_A55SupplierAgbContactName, P00863_A291SupplierAgbTypeName, P00863_A51SupplierAgbName, P00863_A49SupplierAgbId
               }
               , new Object[] {
               P00864_A283SupplierAgbTypeId, P00864_A55SupplierAgbContactName, P00864_A11OrganisationId, P00864_n11OrganisationId, P00864_A57SupplierAgbEmail, P00864_A56SupplierAgbPhone, P00864_A291SupplierAgbTypeName, P00864_A51SupplierAgbName, P00864_A49SupplierAgbId
               }
               , new Object[] {
               P00865_A283SupplierAgbTypeId, P00865_A56SupplierAgbPhone, P00865_A11OrganisationId, P00865_n11OrganisationId, P00865_A57SupplierAgbEmail, P00865_A55SupplierAgbContactName, P00865_A291SupplierAgbTypeName, P00865_A51SupplierAgbName, P00865_A49SupplierAgbId
               }
               , new Object[] {
               P00866_A283SupplierAgbTypeId, P00866_A57SupplierAgbEmail, P00866_A11OrganisationId, P00866_n11OrganisationId, P00866_A56SupplierAgbPhone, P00866_A55SupplierAgbContactName, P00866_A291SupplierAgbTypeName, P00866_A51SupplierAgbName, P00866_A49SupplierAgbId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24MaxItems ;
      private short AV23PageIndex ;
      private short AV22SkipItems ;
      private int AV45GXV1 ;
      private int AV25InsertIndex ;
      private long AV31count ;
      private string AV17TFSupplierAgbPhone ;
      private string AV18TFSupplierAgbPhone_Sel ;
      private string lV17TFSupplierAgbPhone ;
      private string A56SupplierAgbPhone ;
      private bool returnInSub ;
      private bool BRK862 ;
      private bool n11OrganisationId ;
      private bool BRK864 ;
      private bool BRK866 ;
      private bool BRK868 ;
      private bool BRK8610 ;
      private string AV40OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV42OptionIndexesJson ;
      private string AV37DDOName ;
      private string AV38SearchTxtParms ;
      private string AV39SearchTxtTo ;
      private string AV21SearchTxt ;
      private string AV43FilterFullText ;
      private string AV11TFSupplierAgbName ;
      private string AV12TFSupplierAgbName_Sel ;
      private string AV13TFSupplierAgbTypeName ;
      private string AV14TFSupplierAgbTypeName_Sel ;
      private string AV15TFSupplierAgbContactName ;
      private string AV16TFSupplierAgbContactName_Sel ;
      private string AV19TFSupplierAgbEmail ;
      private string AV20TFSupplierAgbEmail_Sel ;
      private string lV43FilterFullText ;
      private string lV11TFSupplierAgbName ;
      private string lV13TFSupplierAgbTypeName ;
      private string lV15TFSupplierAgbContactName ;
      private string lV19TFSupplierAgbEmail ;
      private string A51SupplierAgbName ;
      private string A291SupplierAgbTypeName ;
      private string A55SupplierAgbContactName ;
      private string A57SupplierAgbEmail ;
      private string AV26Option ;
      private Guid A11OrganisationId ;
      private Guid A283SupplierAgbTypeId ;
      private Guid A49SupplierAgbId ;
      private IGxSession AV32Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV27Options ;
      private GxSimpleCollection<string> AV29OptionsDesc ;
      private GxSimpleCollection<string> AV30OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00862_A283SupplierAgbTypeId ;
      private string[] P00862_A51SupplierAgbName ;
      private Guid[] P00862_A11OrganisationId ;
      private bool[] P00862_n11OrganisationId ;
      private string[] P00862_A57SupplierAgbEmail ;
      private string[] P00862_A56SupplierAgbPhone ;
      private string[] P00862_A55SupplierAgbContactName ;
      private string[] P00862_A291SupplierAgbTypeName ;
      private Guid[] P00862_A49SupplierAgbId ;
      private Guid[] P00863_A283SupplierAgbTypeId ;
      private Guid[] P00863_A11OrganisationId ;
      private bool[] P00863_n11OrganisationId ;
      private string[] P00863_A57SupplierAgbEmail ;
      private string[] P00863_A56SupplierAgbPhone ;
      private string[] P00863_A55SupplierAgbContactName ;
      private string[] P00863_A291SupplierAgbTypeName ;
      private string[] P00863_A51SupplierAgbName ;
      private Guid[] P00863_A49SupplierAgbId ;
      private Guid[] P00864_A283SupplierAgbTypeId ;
      private string[] P00864_A55SupplierAgbContactName ;
      private Guid[] P00864_A11OrganisationId ;
      private bool[] P00864_n11OrganisationId ;
      private string[] P00864_A57SupplierAgbEmail ;
      private string[] P00864_A56SupplierAgbPhone ;
      private string[] P00864_A291SupplierAgbTypeName ;
      private string[] P00864_A51SupplierAgbName ;
      private Guid[] P00864_A49SupplierAgbId ;
      private Guid[] P00865_A283SupplierAgbTypeId ;
      private string[] P00865_A56SupplierAgbPhone ;
      private Guid[] P00865_A11OrganisationId ;
      private bool[] P00865_n11OrganisationId ;
      private string[] P00865_A57SupplierAgbEmail ;
      private string[] P00865_A55SupplierAgbContactName ;
      private string[] P00865_A291SupplierAgbTypeName ;
      private string[] P00865_A51SupplierAgbName ;
      private Guid[] P00865_A49SupplierAgbId ;
      private Guid[] P00866_A283SupplierAgbTypeId ;
      private string[] P00866_A57SupplierAgbEmail ;
      private Guid[] P00866_A11OrganisationId ;
      private bool[] P00866_n11OrganisationId ;
      private string[] P00866_A56SupplierAgbPhone ;
      private string[] P00866_A55SupplierAgbContactName ;
      private string[] P00866_A291SupplierAgbTypeName ;
      private string[] P00866_A51SupplierAgbName ;
      private Guid[] P00866_A49SupplierAgbId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wp_organisationnationalagbsupplierswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00862( IGxContext context ,
                                             string AV43FilterFullText ,
                                             string AV12TFSupplierAgbName_Sel ,
                                             string AV11TFSupplierAgbName ,
                                             string AV14TFSupplierAgbTypeName_Sel ,
                                             string AV13TFSupplierAgbTypeName ,
                                             string AV16TFSupplierAgbContactName_Sel ,
                                             string AV15TFSupplierAgbContactName ,
                                             string AV18TFSupplierAgbPhone_Sel ,
                                             string AV17TFSupplierAgbPhone ,
                                             string AV20TFSupplierAgbEmail_Sel ,
                                             string AV19TFSupplierAgbEmail ,
                                             string A51SupplierAgbName ,
                                             string A291SupplierAgbTypeName ,
                                             string A55SupplierAgbContactName ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[15];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SupplierAgbTypeId, T1.SupplierAgbName, T1.OrganisationId, T1.SupplierAgbEmail, T1.SupplierAgbPhone, T1.SupplierAgbContactName, T2.SupplierAgbTypeName, T1.SupplierAgbId FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierAgbName like '%' || :lV43FilterFullText) or ( T2.SupplierAgbTypeName like '%' || :lV43FilterFullText) or ( T1.SupplierAgbContactName like '%' || :lV43FilterFullText) or ( T1.SupplierAgbPhone like '%' || :lV43FilterFullText) or ( T1.SupplierAgbEmail like '%' || :lV43FilterFullText))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierAgbName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSupplierAgbName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName like :lV11TFSupplierAgbName)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierAgbName_Sel)) && ! ( StringUtil.StrCmp(AV12TFSupplierAgbName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV12TFSupplierAgbName_Sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFSupplierAgbName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierAgbTypeName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSupplierAgbTypeName)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV13TFSupplierAgbTypeName)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierAgbTypeName_Sel)) && ! ( StringUtil.StrCmp(AV14TFSupplierAgbTypeName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV14TFSupplierAgbTypeName_Sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFSupplierAgbTypeName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierAgbContactName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSupplierAgbContactName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV15TFSupplierAgbContactName)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierAgbContactName_Sel)) && ! ( StringUtil.StrCmp(AV16TFSupplierAgbContactName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV16TFSupplierAgbContactName_Sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFSupplierAgbContactName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierAgbPhone_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFSupplierAgbPhone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV17TFSupplierAgbPhone)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierAgbPhone_Sel)) && ! ( StringUtil.StrCmp(AV18TFSupplierAgbPhone_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV18TFSupplierAgbPhone_Sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFSupplierAgbPhone_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFSupplierAgbEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFSupplierAgbEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV19TFSupplierAgbEmail)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFSupplierAgbEmail_Sel)) && ! ( StringUtil.StrCmp(AV20TFSupplierAgbEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV20TFSupplierAgbEmail_Sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFSupplierAgbEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierAgbName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00863( IGxContext context ,
                                             string AV43FilterFullText ,
                                             string AV12TFSupplierAgbName_Sel ,
                                             string AV11TFSupplierAgbName ,
                                             string AV14TFSupplierAgbTypeName_Sel ,
                                             string AV13TFSupplierAgbTypeName ,
                                             string AV16TFSupplierAgbContactName_Sel ,
                                             string AV15TFSupplierAgbContactName ,
                                             string AV18TFSupplierAgbPhone_Sel ,
                                             string AV17TFSupplierAgbPhone ,
                                             string AV20TFSupplierAgbEmail_Sel ,
                                             string AV19TFSupplierAgbEmail ,
                                             string A51SupplierAgbName ,
                                             string A291SupplierAgbTypeName ,
                                             string A55SupplierAgbContactName ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[15];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SupplierAgbTypeId, T1.OrganisationId, T1.SupplierAgbEmail, T1.SupplierAgbPhone, T1.SupplierAgbContactName, T2.SupplierAgbTypeName, T1.SupplierAgbName, T1.SupplierAgbId FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierAgbName like '%' || :lV43FilterFullText) or ( T2.SupplierAgbTypeName like '%' || :lV43FilterFullText) or ( T1.SupplierAgbContactName like '%' || :lV43FilterFullText) or ( T1.SupplierAgbPhone like '%' || :lV43FilterFullText) or ( T1.SupplierAgbEmail like '%' || :lV43FilterFullText))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierAgbName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSupplierAgbName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName like :lV11TFSupplierAgbName)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierAgbName_Sel)) && ! ( StringUtil.StrCmp(AV12TFSupplierAgbName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV12TFSupplierAgbName_Sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFSupplierAgbName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierAgbTypeName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSupplierAgbTypeName)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV13TFSupplierAgbTypeName)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierAgbTypeName_Sel)) && ! ( StringUtil.StrCmp(AV14TFSupplierAgbTypeName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV14TFSupplierAgbTypeName_Sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFSupplierAgbTypeName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierAgbContactName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSupplierAgbContactName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV15TFSupplierAgbContactName)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierAgbContactName_Sel)) && ! ( StringUtil.StrCmp(AV16TFSupplierAgbContactName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV16TFSupplierAgbContactName_Sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFSupplierAgbContactName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierAgbPhone_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFSupplierAgbPhone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV17TFSupplierAgbPhone)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierAgbPhone_Sel)) && ! ( StringUtil.StrCmp(AV18TFSupplierAgbPhone_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV18TFSupplierAgbPhone_Sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFSupplierAgbPhone_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFSupplierAgbEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFSupplierAgbEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV19TFSupplierAgbEmail)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFSupplierAgbEmail_Sel)) && ! ( StringUtil.StrCmp(AV20TFSupplierAgbEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV20TFSupplierAgbEmail_Sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFSupplierAgbEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierAgbTypeId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00864( IGxContext context ,
                                             string AV43FilterFullText ,
                                             string AV12TFSupplierAgbName_Sel ,
                                             string AV11TFSupplierAgbName ,
                                             string AV14TFSupplierAgbTypeName_Sel ,
                                             string AV13TFSupplierAgbTypeName ,
                                             string AV16TFSupplierAgbContactName_Sel ,
                                             string AV15TFSupplierAgbContactName ,
                                             string AV18TFSupplierAgbPhone_Sel ,
                                             string AV17TFSupplierAgbPhone ,
                                             string AV20TFSupplierAgbEmail_Sel ,
                                             string AV19TFSupplierAgbEmail ,
                                             string A51SupplierAgbName ,
                                             string A291SupplierAgbTypeName ,
                                             string A55SupplierAgbContactName ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[15];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.SupplierAgbTypeId, T1.SupplierAgbContactName, T1.OrganisationId, T1.SupplierAgbEmail, T1.SupplierAgbPhone, T2.SupplierAgbTypeName, T1.SupplierAgbName, T1.SupplierAgbId FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierAgbName like '%' || :lV43FilterFullText) or ( T2.SupplierAgbTypeName like '%' || :lV43FilterFullText) or ( T1.SupplierAgbContactName like '%' || :lV43FilterFullText) or ( T1.SupplierAgbPhone like '%' || :lV43FilterFullText) or ( T1.SupplierAgbEmail like '%' || :lV43FilterFullText))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierAgbName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSupplierAgbName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName like :lV11TFSupplierAgbName)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierAgbName_Sel)) && ! ( StringUtil.StrCmp(AV12TFSupplierAgbName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV12TFSupplierAgbName_Sel))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFSupplierAgbName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierAgbTypeName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSupplierAgbTypeName)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV13TFSupplierAgbTypeName)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierAgbTypeName_Sel)) && ! ( StringUtil.StrCmp(AV14TFSupplierAgbTypeName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV14TFSupplierAgbTypeName_Sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFSupplierAgbTypeName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierAgbContactName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSupplierAgbContactName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV15TFSupplierAgbContactName)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierAgbContactName_Sel)) && ! ( StringUtil.StrCmp(AV16TFSupplierAgbContactName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV16TFSupplierAgbContactName_Sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFSupplierAgbContactName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierAgbPhone_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFSupplierAgbPhone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV17TFSupplierAgbPhone)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierAgbPhone_Sel)) && ! ( StringUtil.StrCmp(AV18TFSupplierAgbPhone_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV18TFSupplierAgbPhone_Sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFSupplierAgbPhone_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFSupplierAgbEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFSupplierAgbEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV19TFSupplierAgbEmail)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFSupplierAgbEmail_Sel)) && ! ( StringUtil.StrCmp(AV20TFSupplierAgbEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV20TFSupplierAgbEmail_Sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFSupplierAgbEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierAgbContactName";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00865( IGxContext context ,
                                             string AV43FilterFullText ,
                                             string AV12TFSupplierAgbName_Sel ,
                                             string AV11TFSupplierAgbName ,
                                             string AV14TFSupplierAgbTypeName_Sel ,
                                             string AV13TFSupplierAgbTypeName ,
                                             string AV16TFSupplierAgbContactName_Sel ,
                                             string AV15TFSupplierAgbContactName ,
                                             string AV18TFSupplierAgbPhone_Sel ,
                                             string AV17TFSupplierAgbPhone ,
                                             string AV20TFSupplierAgbEmail_Sel ,
                                             string AV19TFSupplierAgbEmail ,
                                             string A51SupplierAgbName ,
                                             string A291SupplierAgbTypeName ,
                                             string A55SupplierAgbContactName ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[15];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.SupplierAgbTypeId, T1.SupplierAgbPhone, T1.OrganisationId, T1.SupplierAgbEmail, T1.SupplierAgbContactName, T2.SupplierAgbTypeName, T1.SupplierAgbName, T1.SupplierAgbId FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierAgbName like '%' || :lV43FilterFullText) or ( T2.SupplierAgbTypeName like '%' || :lV43FilterFullText) or ( T1.SupplierAgbContactName like '%' || :lV43FilterFullText) or ( T1.SupplierAgbPhone like '%' || :lV43FilterFullText) or ( T1.SupplierAgbEmail like '%' || :lV43FilterFullText))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierAgbName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSupplierAgbName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName like :lV11TFSupplierAgbName)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierAgbName_Sel)) && ! ( StringUtil.StrCmp(AV12TFSupplierAgbName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV12TFSupplierAgbName_Sel))");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFSupplierAgbName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierAgbTypeName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSupplierAgbTypeName)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV13TFSupplierAgbTypeName)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierAgbTypeName_Sel)) && ! ( StringUtil.StrCmp(AV14TFSupplierAgbTypeName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV14TFSupplierAgbTypeName_Sel))");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFSupplierAgbTypeName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierAgbContactName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSupplierAgbContactName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV15TFSupplierAgbContactName)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierAgbContactName_Sel)) && ! ( StringUtil.StrCmp(AV16TFSupplierAgbContactName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV16TFSupplierAgbContactName_Sel))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFSupplierAgbContactName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierAgbPhone_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFSupplierAgbPhone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV17TFSupplierAgbPhone)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierAgbPhone_Sel)) && ! ( StringUtil.StrCmp(AV18TFSupplierAgbPhone_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV18TFSupplierAgbPhone_Sel))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFSupplierAgbPhone_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFSupplierAgbEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFSupplierAgbEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV19TFSupplierAgbEmail)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFSupplierAgbEmail_Sel)) && ! ( StringUtil.StrCmp(AV20TFSupplierAgbEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV20TFSupplierAgbEmail_Sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFSupplierAgbEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierAgbPhone";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00866( IGxContext context ,
                                             string AV43FilterFullText ,
                                             string AV12TFSupplierAgbName_Sel ,
                                             string AV11TFSupplierAgbName ,
                                             string AV14TFSupplierAgbTypeName_Sel ,
                                             string AV13TFSupplierAgbTypeName ,
                                             string AV16TFSupplierAgbContactName_Sel ,
                                             string AV15TFSupplierAgbContactName ,
                                             string AV18TFSupplierAgbPhone_Sel ,
                                             string AV17TFSupplierAgbPhone ,
                                             string AV20TFSupplierAgbEmail_Sel ,
                                             string AV19TFSupplierAgbEmail ,
                                             string A51SupplierAgbName ,
                                             string A291SupplierAgbTypeName ,
                                             string A55SupplierAgbContactName ,
                                             string A56SupplierAgbPhone ,
                                             string A57SupplierAgbEmail ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[15];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.SupplierAgbTypeId, T1.SupplierAgbEmail, T1.OrganisationId, T1.SupplierAgbPhone, T1.SupplierAgbContactName, T2.SupplierAgbTypeName, T1.SupplierAgbName, T1.SupplierAgbId FROM (Trn_SupplierAGB T1 INNER JOIN Trn_SupplierAgbType T2 ON T2.SupplierAgbTypeId = T1.SupplierAgbTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierAgbName like '%' || :lV43FilterFullText) or ( T2.SupplierAgbTypeName like '%' || :lV43FilterFullText) or ( T1.SupplierAgbContactName like '%' || :lV43FilterFullText) or ( T1.SupplierAgbPhone like '%' || :lV43FilterFullText) or ( T1.SupplierAgbEmail like '%' || :lV43FilterFullText))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierAgbName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSupplierAgbName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName like :lV11TFSupplierAgbName)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFSupplierAgbName_Sel)) && ! ( StringUtil.StrCmp(AV12TFSupplierAgbName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbName = ( :AV12TFSupplierAgbName_Sel))");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFSupplierAgbName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierAgbTypeName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSupplierAgbTypeName)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName like :lV13TFSupplierAgbTypeName)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSupplierAgbTypeName_Sel)) && ! ( StringUtil.StrCmp(AV14TFSupplierAgbTypeName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbTypeName = ( :AV14TFSupplierAgbTypeName_Sel))");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFSupplierAgbTypeName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierAgbTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierAgbContactName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSupplierAgbContactName)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName like :lV15TFSupplierAgbContactName)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSupplierAgbContactName_Sel)) && ! ( StringUtil.StrCmp(AV16TFSupplierAgbContactName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbContactName = ( :AV16TFSupplierAgbContactName_Sel))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFSupplierAgbContactName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierAgbPhone_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFSupplierAgbPhone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone like :lV17TFSupplierAgbPhone)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSupplierAgbPhone_Sel)) && ! ( StringUtil.StrCmp(AV18TFSupplierAgbPhone_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbPhone = ( :AV18TFSupplierAgbPhone_Sel))");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFSupplierAgbPhone_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFSupplierAgbEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFSupplierAgbEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail like :lV19TFSupplierAgbEmail)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFSupplierAgbEmail_Sel)) && ! ( StringUtil.StrCmp(AV20TFSupplierAgbEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierAgbEmail = ( :AV20TFSupplierAgbEmail_Sel))");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFSupplierAgbEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierAgbEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierAgbEmail";
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
                     return conditional_P00862(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] );
               case 1 :
                     return conditional_P00863(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] );
               case 2 :
                     return conditional_P00864(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] );
               case 3 :
                     return conditional_P00865(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] );
               case 4 :
                     return conditional_P00866(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] );
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
          Object[] prmP00862;
          prmP00862 = new Object[] {
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV11TFSupplierAgbName",GXType.VarChar,100,0) ,
          new ParDef("AV12TFSupplierAgbName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV13TFSupplierAgbTypeName",GXType.VarChar,100,0) ,
          new ParDef("AV14TFSupplierAgbTypeName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV15TFSupplierAgbContactName",GXType.VarChar,100,0) ,
          new ParDef("AV16TFSupplierAgbContactName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV17TFSupplierAgbPhone",GXType.Char,20,0) ,
          new ParDef("AV18TFSupplierAgbPhone_Sel",GXType.Char,20,0) ,
          new ParDef("lV19TFSupplierAgbEmail",GXType.VarChar,100,0) ,
          new ParDef("AV20TFSupplierAgbEmail_Sel",GXType.VarChar,100,0)
          };
          Object[] prmP00863;
          prmP00863 = new Object[] {
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV11TFSupplierAgbName",GXType.VarChar,100,0) ,
          new ParDef("AV12TFSupplierAgbName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV13TFSupplierAgbTypeName",GXType.VarChar,100,0) ,
          new ParDef("AV14TFSupplierAgbTypeName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV15TFSupplierAgbContactName",GXType.VarChar,100,0) ,
          new ParDef("AV16TFSupplierAgbContactName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV17TFSupplierAgbPhone",GXType.Char,20,0) ,
          new ParDef("AV18TFSupplierAgbPhone_Sel",GXType.Char,20,0) ,
          new ParDef("lV19TFSupplierAgbEmail",GXType.VarChar,100,0) ,
          new ParDef("AV20TFSupplierAgbEmail_Sel",GXType.VarChar,100,0)
          };
          Object[] prmP00864;
          prmP00864 = new Object[] {
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV11TFSupplierAgbName",GXType.VarChar,100,0) ,
          new ParDef("AV12TFSupplierAgbName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV13TFSupplierAgbTypeName",GXType.VarChar,100,0) ,
          new ParDef("AV14TFSupplierAgbTypeName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV15TFSupplierAgbContactName",GXType.VarChar,100,0) ,
          new ParDef("AV16TFSupplierAgbContactName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV17TFSupplierAgbPhone",GXType.Char,20,0) ,
          new ParDef("AV18TFSupplierAgbPhone_Sel",GXType.Char,20,0) ,
          new ParDef("lV19TFSupplierAgbEmail",GXType.VarChar,100,0) ,
          new ParDef("AV20TFSupplierAgbEmail_Sel",GXType.VarChar,100,0)
          };
          Object[] prmP00865;
          prmP00865 = new Object[] {
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV11TFSupplierAgbName",GXType.VarChar,100,0) ,
          new ParDef("AV12TFSupplierAgbName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV13TFSupplierAgbTypeName",GXType.VarChar,100,0) ,
          new ParDef("AV14TFSupplierAgbTypeName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV15TFSupplierAgbContactName",GXType.VarChar,100,0) ,
          new ParDef("AV16TFSupplierAgbContactName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV17TFSupplierAgbPhone",GXType.Char,20,0) ,
          new ParDef("AV18TFSupplierAgbPhone_Sel",GXType.Char,20,0) ,
          new ParDef("lV19TFSupplierAgbEmail",GXType.VarChar,100,0) ,
          new ParDef("AV20TFSupplierAgbEmail_Sel",GXType.VarChar,100,0)
          };
          Object[] prmP00866;
          prmP00866 = new Object[] {
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV43FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV11TFSupplierAgbName",GXType.VarChar,100,0) ,
          new ParDef("AV12TFSupplierAgbName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV13TFSupplierAgbTypeName",GXType.VarChar,100,0) ,
          new ParDef("AV14TFSupplierAgbTypeName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV15TFSupplierAgbContactName",GXType.VarChar,100,0) ,
          new ParDef("AV16TFSupplierAgbContactName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV17TFSupplierAgbPhone",GXType.Char,20,0) ,
          new ParDef("AV18TFSupplierAgbPhone_Sel",GXType.Char,20,0) ,
          new ParDef("lV19TFSupplierAgbEmail",GXType.VarChar,100,0) ,
          new ParDef("AV20TFSupplierAgbEmail_Sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00862", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00862,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00863", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00863,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00864", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00864,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00865", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00865,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00866", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00866,100, GxCacheFrequency.OFF ,true,false )
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
