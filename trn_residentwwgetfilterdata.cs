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
   public class trn_residentwwgetfilterdata : GXProcedure
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
            return "trn_residentww_Services_Execute" ;
         }

      }

      public trn_residentwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_residentwwgetfilterdata( IGxContext context )
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
         this.AV47DDOName = aP0_DDOName;
         this.AV48SearchTxtParms = aP1_SearchTxtParms;
         this.AV49SearchTxtTo = aP2_SearchTxtTo;
         this.AV50OptionsJson = "" ;
         this.AV51OptionsDescJson = "" ;
         this.AV52OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV52OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV47DDOName = aP0_DDOName;
         this.AV48SearchTxtParms = aP1_SearchTxtParms;
         this.AV49SearchTxtTo = aP2_SearchTxtTo;
         this.AV50OptionsJson = "" ;
         this.AV51OptionsDescJson = "" ;
         this.AV52OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV37Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV39OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34MaxItems = 10;
         AV33PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV48SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV31SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? "" : StringUtil.Substring( AV48SearchTxtParms, 3, -1));
         AV32SkipItems = (short)(AV33PageIndex*AV34MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTGIVENNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTGIVENNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTLASTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTLASTNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTEMAILOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTPHONEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTTYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTTYPENAMEOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV50OptionsJson = AV37Options.ToJSonString(false);
         AV51OptionsDescJson = AV39OptionsDesc.ToJSonString(false);
         AV52OptionIndexesJson = AV40OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV42Session.Get("Trn_ResidentWWGridState"), "") == 0 )
         {
            AV44GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Trn_ResidentWWGridState"), null, "", "");
         }
         else
         {
            AV44GridState.FromXml(AV42Session.Get("Trn_ResidentWWGridState"), null, "", "");
         }
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV44GridState.gxTpr_Filtervalues.Count )
         {
            AV45GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV44GridState.gxTpr_Filtervalues.Item(AV60GXV1));
            if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV53FilterFullText = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTSALUTATION_SEL") == 0 )
            {
               AV11TFResidentSalutation_SelsJson = AV45GridStateFilterValue.gxTpr_Value;
               AV12TFResidentSalutation_Sels.FromJSonString(AV11TFResidentSalutation_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTGIVENNAME") == 0 )
            {
               AV13TFResidentGivenName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTGIVENNAME_SEL") == 0 )
            {
               AV14TFResidentGivenName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTLASTNAME") == 0 )
            {
               AV15TFResidentLastName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTLASTNAME_SEL") == 0 )
            {
               AV16TFResidentLastName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTGENDER_SEL") == 0 )
            {
               AV21TFResidentGender_SelsJson = AV45GridStateFilterValue.gxTpr_Value;
               AV22TFResidentGender_Sels.FromJSonString(AV21TFResidentGender_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTEMAIL") == 0 )
            {
               AV19TFResidentEmail = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTEMAIL_SEL") == 0 )
            {
               AV20TFResidentEmail_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTPHONE") == 0 )
            {
               AV23TFResidentPhone = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTPHONE_SEL") == 0 )
            {
               AV24TFResidentPhone_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTTYPENAME") == 0 )
            {
               AV27TFResidentTypeName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTTYPENAME_SEL") == 0 )
            {
               AV28TFResidentTypeName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            AV60GXV1 = (int)(AV60GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADRESIDENTGIVENNAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFResidentGivenName = AV31SearchTxt;
         AV14TFResidentGivenName_Sel = "";
         AV62Trn_residentwwds_1_filterfulltext = AV53FilterFullText;
         AV63Trn_residentwwds_2_tfresidentsalutation_sels = AV12TFResidentSalutation_Sels;
         AV64Trn_residentwwds_3_tfresidentgivenname = AV13TFResidentGivenName;
         AV65Trn_residentwwds_4_tfresidentgivenname_sel = AV14TFResidentGivenName_Sel;
         AV66Trn_residentwwds_5_tfresidentlastname = AV15TFResidentLastName;
         AV67Trn_residentwwds_6_tfresidentlastname_sel = AV16TFResidentLastName_Sel;
         AV68Trn_residentwwds_7_tfresidentgender_sels = AV22TFResidentGender_Sels;
         AV69Trn_residentwwds_8_tfresidentemail = AV19TFResidentEmail;
         AV70Trn_residentwwds_9_tfresidentemail_sel = AV20TFResidentEmail_Sel;
         AV71Trn_residentwwds_10_tfresidentphone = AV23TFResidentPhone;
         AV72Trn_residentwwds_11_tfresidentphone_sel = AV24TFResidentPhone_Sel;
         AV73Trn_residentwwds_12_tfresidenttypename = AV27TFResidentTypeName;
         AV74Trn_residentwwds_13_tfresidenttypename_sel = AV28TFResidentTypeName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV63Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV68Trn_residentwwds_7_tfresidentgender_sels ,
                                              AV63Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV65Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV64Trn_residentwwds_3_tfresidentgivenname ,
                                              AV67Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV66Trn_residentwwds_5_tfresidentlastname ,
                                              AV68Trn_residentwwds_7_tfresidentgender_sels.Count ,
                                              AV70Trn_residentwwds_9_tfresidentemail_sel ,
                                              AV69Trn_residentwwds_8_tfresidentemail ,
                                              AV72Trn_residentwwds_11_tfresidentphone_sel ,
                                              AV71Trn_residentwwds_10_tfresidentphone ,
                                              AV74Trn_residentwwds_13_tfresidenttypename_sel ,
                                              AV73Trn_residentwwds_12_tfresidenttypename ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              AV62Trn_residentwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV64Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV64Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV66Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV66Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV69Trn_residentwwds_8_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV69Trn_residentwwds_8_tfresidentemail), "%", "");
         lV71Trn_residentwwds_10_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV71Trn_residentwwds_10_tfresidentphone), 20, "%");
         lV73Trn_residentwwds_12_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV73Trn_residentwwds_12_tfresidenttypename), "%", "");
         /* Using cursor P007B2 */
         pr_default.execute(0, new Object[] {lV64Trn_residentwwds_3_tfresidentgivenname, AV65Trn_residentwwds_4_tfresidentgivenname_sel, lV66Trn_residentwwds_5_tfresidentlastname, AV67Trn_residentwwds_6_tfresidentlastname_sel, lV69Trn_residentwwds_8_tfresidentemail, AV70Trn_residentwwds_9_tfresidentemail_sel, lV71Trn_residentwwds_10_tfresidentphone, AV72Trn_residentwwds_11_tfresidentphone_sel, lV73Trn_residentwwds_12_tfresidenttypename, AV74Trn_residentwwds_13_tfresidenttypename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7B2 = false;
            A96ResidentTypeId = P007B2_A96ResidentTypeId[0];
            A64ResidentGivenName = P007B2_A64ResidentGivenName[0];
            A97ResidentTypeName = P007B2_A97ResidentTypeName[0];
            A70ResidentPhone = P007B2_A70ResidentPhone[0];
            A67ResidentEmail = P007B2_A67ResidentEmail[0];
            A68ResidentGender = P007B2_A68ResidentGender[0];
            A65ResidentLastName = P007B2_A65ResidentLastName[0];
            A72ResidentSalutation = P007B2_A72ResidentSalutation[0];
            A62ResidentId = P007B2_A62ResidentId[0];
            A29LocationId = P007B2_A29LocationId[0];
            A11OrganisationId = P007B2_A11OrganisationId[0];
            A97ResidentTypeName = P007B2_A97ResidentTypeName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext)) || ( ( StringUtil.Like( context.GetMessage( context.GetMessage( "mr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "mrs", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mrs", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "dr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Dr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "miss", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Miss", "")) == 0 ) ) || ( StringUtil.Like( A64ResidentGivenName , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A65ResidentLastName , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "male", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Male", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "female", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Female", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "other", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Other", "")) == 0 ) ) || ( StringUtil.Like( A67ResidentEmail , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A70ResidentPhone , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A97ResidentTypeName , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV41count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P007B2_A64ResidentGivenName[0], A64ResidentGivenName) == 0 ) )
               {
                  BRK7B2 = false;
                  A62ResidentId = P007B2_A62ResidentId[0];
                  A29LocationId = P007B2_A29LocationId[0];
                  A11OrganisationId = P007B2_A11OrganisationId[0];
                  AV41count = (long)(AV41count+1);
                  BRK7B2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV32SkipItems) )
               {
                  AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A64ResidentGivenName)) ? "<#Empty#>" : A64ResidentGivenName);
                  AV37Options.Add(AV36Option, 0);
                  AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV37Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV32SkipItems = (short)(AV32SkipItems-1);
               }
            }
            if ( ! BRK7B2 )
            {
               BRK7B2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADRESIDENTLASTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFResidentLastName = AV31SearchTxt;
         AV16TFResidentLastName_Sel = "";
         AV62Trn_residentwwds_1_filterfulltext = AV53FilterFullText;
         AV63Trn_residentwwds_2_tfresidentsalutation_sels = AV12TFResidentSalutation_Sels;
         AV64Trn_residentwwds_3_tfresidentgivenname = AV13TFResidentGivenName;
         AV65Trn_residentwwds_4_tfresidentgivenname_sel = AV14TFResidentGivenName_Sel;
         AV66Trn_residentwwds_5_tfresidentlastname = AV15TFResidentLastName;
         AV67Trn_residentwwds_6_tfresidentlastname_sel = AV16TFResidentLastName_Sel;
         AV68Trn_residentwwds_7_tfresidentgender_sels = AV22TFResidentGender_Sels;
         AV69Trn_residentwwds_8_tfresidentemail = AV19TFResidentEmail;
         AV70Trn_residentwwds_9_tfresidentemail_sel = AV20TFResidentEmail_Sel;
         AV71Trn_residentwwds_10_tfresidentphone = AV23TFResidentPhone;
         AV72Trn_residentwwds_11_tfresidentphone_sel = AV24TFResidentPhone_Sel;
         AV73Trn_residentwwds_12_tfresidenttypename = AV27TFResidentTypeName;
         AV74Trn_residentwwds_13_tfresidenttypename_sel = AV28TFResidentTypeName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV63Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV68Trn_residentwwds_7_tfresidentgender_sels ,
                                              AV63Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV65Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV64Trn_residentwwds_3_tfresidentgivenname ,
                                              AV67Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV66Trn_residentwwds_5_tfresidentlastname ,
                                              AV68Trn_residentwwds_7_tfresidentgender_sels.Count ,
                                              AV70Trn_residentwwds_9_tfresidentemail_sel ,
                                              AV69Trn_residentwwds_8_tfresidentemail ,
                                              AV72Trn_residentwwds_11_tfresidentphone_sel ,
                                              AV71Trn_residentwwds_10_tfresidentphone ,
                                              AV74Trn_residentwwds_13_tfresidenttypename_sel ,
                                              AV73Trn_residentwwds_12_tfresidenttypename ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              AV62Trn_residentwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV64Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV64Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV66Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV66Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV69Trn_residentwwds_8_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV69Trn_residentwwds_8_tfresidentemail), "%", "");
         lV71Trn_residentwwds_10_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV71Trn_residentwwds_10_tfresidentphone), 20, "%");
         lV73Trn_residentwwds_12_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV73Trn_residentwwds_12_tfresidenttypename), "%", "");
         /* Using cursor P007B3 */
         pr_default.execute(1, new Object[] {lV64Trn_residentwwds_3_tfresidentgivenname, AV65Trn_residentwwds_4_tfresidentgivenname_sel, lV66Trn_residentwwds_5_tfresidentlastname, AV67Trn_residentwwds_6_tfresidentlastname_sel, lV69Trn_residentwwds_8_tfresidentemail, AV70Trn_residentwwds_9_tfresidentemail_sel, lV71Trn_residentwwds_10_tfresidentphone, AV72Trn_residentwwds_11_tfresidentphone_sel, lV73Trn_residentwwds_12_tfresidenttypename, AV74Trn_residentwwds_13_tfresidenttypename_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7B4 = false;
            A96ResidentTypeId = P007B3_A96ResidentTypeId[0];
            A65ResidentLastName = P007B3_A65ResidentLastName[0];
            A97ResidentTypeName = P007B3_A97ResidentTypeName[0];
            A70ResidentPhone = P007B3_A70ResidentPhone[0];
            A67ResidentEmail = P007B3_A67ResidentEmail[0];
            A68ResidentGender = P007B3_A68ResidentGender[0];
            A64ResidentGivenName = P007B3_A64ResidentGivenName[0];
            A72ResidentSalutation = P007B3_A72ResidentSalutation[0];
            A62ResidentId = P007B3_A62ResidentId[0];
            A29LocationId = P007B3_A29LocationId[0];
            A11OrganisationId = P007B3_A11OrganisationId[0];
            A97ResidentTypeName = P007B3_A97ResidentTypeName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext)) || ( ( StringUtil.Like( context.GetMessage( context.GetMessage( "mr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "mrs", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mrs", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "dr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Dr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "miss", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Miss", "")) == 0 ) ) || ( StringUtil.Like( A64ResidentGivenName , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A65ResidentLastName , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "male", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Male", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "female", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Female", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "other", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Other", "")) == 0 ) ) || ( StringUtil.Like( A67ResidentEmail , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A70ResidentPhone , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A97ResidentTypeName , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV41count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007B3_A65ResidentLastName[0], A65ResidentLastName) == 0 ) )
               {
                  BRK7B4 = false;
                  A62ResidentId = P007B3_A62ResidentId[0];
                  A29LocationId = P007B3_A29LocationId[0];
                  A11OrganisationId = P007B3_A11OrganisationId[0];
                  AV41count = (long)(AV41count+1);
                  BRK7B4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV32SkipItems) )
               {
                  AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A65ResidentLastName)) ? "<#Empty#>" : A65ResidentLastName);
                  AV37Options.Add(AV36Option, 0);
                  AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV37Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV32SkipItems = (short)(AV32SkipItems-1);
               }
            }
            if ( ! BRK7B4 )
            {
               BRK7B4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADRESIDENTEMAILOPTIONS' Routine */
         returnInSub = false;
         AV19TFResidentEmail = AV31SearchTxt;
         AV20TFResidentEmail_Sel = "";
         AV62Trn_residentwwds_1_filterfulltext = AV53FilterFullText;
         AV63Trn_residentwwds_2_tfresidentsalutation_sels = AV12TFResidentSalutation_Sels;
         AV64Trn_residentwwds_3_tfresidentgivenname = AV13TFResidentGivenName;
         AV65Trn_residentwwds_4_tfresidentgivenname_sel = AV14TFResidentGivenName_Sel;
         AV66Trn_residentwwds_5_tfresidentlastname = AV15TFResidentLastName;
         AV67Trn_residentwwds_6_tfresidentlastname_sel = AV16TFResidentLastName_Sel;
         AV68Trn_residentwwds_7_tfresidentgender_sels = AV22TFResidentGender_Sels;
         AV69Trn_residentwwds_8_tfresidentemail = AV19TFResidentEmail;
         AV70Trn_residentwwds_9_tfresidentemail_sel = AV20TFResidentEmail_Sel;
         AV71Trn_residentwwds_10_tfresidentphone = AV23TFResidentPhone;
         AV72Trn_residentwwds_11_tfresidentphone_sel = AV24TFResidentPhone_Sel;
         AV73Trn_residentwwds_12_tfresidenttypename = AV27TFResidentTypeName;
         AV74Trn_residentwwds_13_tfresidenttypename_sel = AV28TFResidentTypeName_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV63Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV68Trn_residentwwds_7_tfresidentgender_sels ,
                                              AV63Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV65Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV64Trn_residentwwds_3_tfresidentgivenname ,
                                              AV67Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV66Trn_residentwwds_5_tfresidentlastname ,
                                              AV68Trn_residentwwds_7_tfresidentgender_sels.Count ,
                                              AV70Trn_residentwwds_9_tfresidentemail_sel ,
                                              AV69Trn_residentwwds_8_tfresidentemail ,
                                              AV72Trn_residentwwds_11_tfresidentphone_sel ,
                                              AV71Trn_residentwwds_10_tfresidentphone ,
                                              AV74Trn_residentwwds_13_tfresidenttypename_sel ,
                                              AV73Trn_residentwwds_12_tfresidenttypename ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              AV62Trn_residentwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV64Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV64Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV66Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV66Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV69Trn_residentwwds_8_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV69Trn_residentwwds_8_tfresidentemail), "%", "");
         lV71Trn_residentwwds_10_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV71Trn_residentwwds_10_tfresidentphone), 20, "%");
         lV73Trn_residentwwds_12_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV73Trn_residentwwds_12_tfresidenttypename), "%", "");
         /* Using cursor P007B4 */
         pr_default.execute(2, new Object[] {lV64Trn_residentwwds_3_tfresidentgivenname, AV65Trn_residentwwds_4_tfresidentgivenname_sel, lV66Trn_residentwwds_5_tfresidentlastname, AV67Trn_residentwwds_6_tfresidentlastname_sel, lV69Trn_residentwwds_8_tfresidentemail, AV70Trn_residentwwds_9_tfresidentemail_sel, lV71Trn_residentwwds_10_tfresidentphone, AV72Trn_residentwwds_11_tfresidentphone_sel, lV73Trn_residentwwds_12_tfresidenttypename, AV74Trn_residentwwds_13_tfresidenttypename_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK7B6 = false;
            A96ResidentTypeId = P007B4_A96ResidentTypeId[0];
            A67ResidentEmail = P007B4_A67ResidentEmail[0];
            A97ResidentTypeName = P007B4_A97ResidentTypeName[0];
            A70ResidentPhone = P007B4_A70ResidentPhone[0];
            A68ResidentGender = P007B4_A68ResidentGender[0];
            A65ResidentLastName = P007B4_A65ResidentLastName[0];
            A64ResidentGivenName = P007B4_A64ResidentGivenName[0];
            A72ResidentSalutation = P007B4_A72ResidentSalutation[0];
            A62ResidentId = P007B4_A62ResidentId[0];
            A29LocationId = P007B4_A29LocationId[0];
            A11OrganisationId = P007B4_A11OrganisationId[0];
            A97ResidentTypeName = P007B4_A97ResidentTypeName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext)) || ( ( StringUtil.Like( context.GetMessage( context.GetMessage( "mr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "mrs", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mrs", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "dr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Dr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "miss", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Miss", "")) == 0 ) ) || ( StringUtil.Like( A64ResidentGivenName , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A65ResidentLastName , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "male", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Male", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "female", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Female", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "other", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Other", "")) == 0 ) ) || ( StringUtil.Like( A67ResidentEmail , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A70ResidentPhone , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A97ResidentTypeName , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV41count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P007B4_A67ResidentEmail[0], A67ResidentEmail) == 0 ) )
               {
                  BRK7B6 = false;
                  A62ResidentId = P007B4_A62ResidentId[0];
                  A29LocationId = P007B4_A29LocationId[0];
                  A11OrganisationId = P007B4_A11OrganisationId[0];
                  AV41count = (long)(AV41count+1);
                  BRK7B6 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV32SkipItems) )
               {
                  AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A67ResidentEmail)) ? "<#Empty#>" : A67ResidentEmail);
                  AV37Options.Add(AV36Option, 0);
                  AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV37Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV32SkipItems = (short)(AV32SkipItems-1);
               }
            }
            if ( ! BRK7B6 )
            {
               BRK7B6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADRESIDENTPHONEOPTIONS' Routine */
         returnInSub = false;
         AV23TFResidentPhone = AV31SearchTxt;
         AV24TFResidentPhone_Sel = "";
         AV62Trn_residentwwds_1_filterfulltext = AV53FilterFullText;
         AV63Trn_residentwwds_2_tfresidentsalutation_sels = AV12TFResidentSalutation_Sels;
         AV64Trn_residentwwds_3_tfresidentgivenname = AV13TFResidentGivenName;
         AV65Trn_residentwwds_4_tfresidentgivenname_sel = AV14TFResidentGivenName_Sel;
         AV66Trn_residentwwds_5_tfresidentlastname = AV15TFResidentLastName;
         AV67Trn_residentwwds_6_tfresidentlastname_sel = AV16TFResidentLastName_Sel;
         AV68Trn_residentwwds_7_tfresidentgender_sels = AV22TFResidentGender_Sels;
         AV69Trn_residentwwds_8_tfresidentemail = AV19TFResidentEmail;
         AV70Trn_residentwwds_9_tfresidentemail_sel = AV20TFResidentEmail_Sel;
         AV71Trn_residentwwds_10_tfresidentphone = AV23TFResidentPhone;
         AV72Trn_residentwwds_11_tfresidentphone_sel = AV24TFResidentPhone_Sel;
         AV73Trn_residentwwds_12_tfresidenttypename = AV27TFResidentTypeName;
         AV74Trn_residentwwds_13_tfresidenttypename_sel = AV28TFResidentTypeName_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV63Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV68Trn_residentwwds_7_tfresidentgender_sels ,
                                              AV63Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV65Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV64Trn_residentwwds_3_tfresidentgivenname ,
                                              AV67Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV66Trn_residentwwds_5_tfresidentlastname ,
                                              AV68Trn_residentwwds_7_tfresidentgender_sels.Count ,
                                              AV70Trn_residentwwds_9_tfresidentemail_sel ,
                                              AV69Trn_residentwwds_8_tfresidentemail ,
                                              AV72Trn_residentwwds_11_tfresidentphone_sel ,
                                              AV71Trn_residentwwds_10_tfresidentphone ,
                                              AV74Trn_residentwwds_13_tfresidenttypename_sel ,
                                              AV73Trn_residentwwds_12_tfresidenttypename ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              AV62Trn_residentwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV64Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV64Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV66Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV66Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV69Trn_residentwwds_8_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV69Trn_residentwwds_8_tfresidentemail), "%", "");
         lV71Trn_residentwwds_10_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV71Trn_residentwwds_10_tfresidentphone), 20, "%");
         lV73Trn_residentwwds_12_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV73Trn_residentwwds_12_tfresidenttypename), "%", "");
         /* Using cursor P007B5 */
         pr_default.execute(3, new Object[] {lV64Trn_residentwwds_3_tfresidentgivenname, AV65Trn_residentwwds_4_tfresidentgivenname_sel, lV66Trn_residentwwds_5_tfresidentlastname, AV67Trn_residentwwds_6_tfresidentlastname_sel, lV69Trn_residentwwds_8_tfresidentemail, AV70Trn_residentwwds_9_tfresidentemail_sel, lV71Trn_residentwwds_10_tfresidentphone, AV72Trn_residentwwds_11_tfresidentphone_sel, lV73Trn_residentwwds_12_tfresidenttypename, AV74Trn_residentwwds_13_tfresidenttypename_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK7B8 = false;
            A96ResidentTypeId = P007B5_A96ResidentTypeId[0];
            A70ResidentPhone = P007B5_A70ResidentPhone[0];
            A97ResidentTypeName = P007B5_A97ResidentTypeName[0];
            A67ResidentEmail = P007B5_A67ResidentEmail[0];
            A68ResidentGender = P007B5_A68ResidentGender[0];
            A65ResidentLastName = P007B5_A65ResidentLastName[0];
            A64ResidentGivenName = P007B5_A64ResidentGivenName[0];
            A72ResidentSalutation = P007B5_A72ResidentSalutation[0];
            A62ResidentId = P007B5_A62ResidentId[0];
            A29LocationId = P007B5_A29LocationId[0];
            A11OrganisationId = P007B5_A11OrganisationId[0];
            A97ResidentTypeName = P007B5_A97ResidentTypeName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext)) || ( ( StringUtil.Like( context.GetMessage( context.GetMessage( "mr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "mrs", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mrs", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "dr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Dr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "miss", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Miss", "")) == 0 ) ) || ( StringUtil.Like( A64ResidentGivenName , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A65ResidentLastName , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "male", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Male", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "female", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Female", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "other", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Other", "")) == 0 ) ) || ( StringUtil.Like( A67ResidentEmail , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A70ResidentPhone , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A97ResidentTypeName , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV41count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P007B5_A70ResidentPhone[0], A70ResidentPhone) == 0 ) )
               {
                  BRK7B8 = false;
                  A62ResidentId = P007B5_A62ResidentId[0];
                  A29LocationId = P007B5_A29LocationId[0];
                  A11OrganisationId = P007B5_A11OrganisationId[0];
                  AV41count = (long)(AV41count+1);
                  BRK7B8 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV32SkipItems) )
               {
                  AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A70ResidentPhone)) ? "<#Empty#>" : A70ResidentPhone);
                  AV37Options.Add(AV36Option, 0);
                  AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV37Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV32SkipItems = (short)(AV32SkipItems-1);
               }
            }
            if ( ! BRK7B8 )
            {
               BRK7B8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADRESIDENTTYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV27TFResidentTypeName = AV31SearchTxt;
         AV28TFResidentTypeName_Sel = "";
         AV62Trn_residentwwds_1_filterfulltext = AV53FilterFullText;
         AV63Trn_residentwwds_2_tfresidentsalutation_sels = AV12TFResidentSalutation_Sels;
         AV64Trn_residentwwds_3_tfresidentgivenname = AV13TFResidentGivenName;
         AV65Trn_residentwwds_4_tfresidentgivenname_sel = AV14TFResidentGivenName_Sel;
         AV66Trn_residentwwds_5_tfresidentlastname = AV15TFResidentLastName;
         AV67Trn_residentwwds_6_tfresidentlastname_sel = AV16TFResidentLastName_Sel;
         AV68Trn_residentwwds_7_tfresidentgender_sels = AV22TFResidentGender_Sels;
         AV69Trn_residentwwds_8_tfresidentemail = AV19TFResidentEmail;
         AV70Trn_residentwwds_9_tfresidentemail_sel = AV20TFResidentEmail_Sel;
         AV71Trn_residentwwds_10_tfresidentphone = AV23TFResidentPhone;
         AV72Trn_residentwwds_11_tfresidentphone_sel = AV24TFResidentPhone_Sel;
         AV73Trn_residentwwds_12_tfresidenttypename = AV27TFResidentTypeName;
         AV74Trn_residentwwds_13_tfresidenttypename_sel = AV28TFResidentTypeName_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV63Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV68Trn_residentwwds_7_tfresidentgender_sels ,
                                              AV63Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV65Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV64Trn_residentwwds_3_tfresidentgivenname ,
                                              AV67Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV66Trn_residentwwds_5_tfresidentlastname ,
                                              AV68Trn_residentwwds_7_tfresidentgender_sels.Count ,
                                              AV70Trn_residentwwds_9_tfresidentemail_sel ,
                                              AV69Trn_residentwwds_8_tfresidentemail ,
                                              AV72Trn_residentwwds_11_tfresidentphone_sel ,
                                              AV71Trn_residentwwds_10_tfresidentphone ,
                                              AV74Trn_residentwwds_13_tfresidenttypename_sel ,
                                              AV73Trn_residentwwds_12_tfresidenttypename ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              AV62Trn_residentwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV64Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV64Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV66Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV66Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV69Trn_residentwwds_8_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV69Trn_residentwwds_8_tfresidentemail), "%", "");
         lV71Trn_residentwwds_10_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV71Trn_residentwwds_10_tfresidentphone), 20, "%");
         lV73Trn_residentwwds_12_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV73Trn_residentwwds_12_tfresidenttypename), "%", "");
         /* Using cursor P007B6 */
         pr_default.execute(4, new Object[] {lV64Trn_residentwwds_3_tfresidentgivenname, AV65Trn_residentwwds_4_tfresidentgivenname_sel, lV66Trn_residentwwds_5_tfresidentlastname, AV67Trn_residentwwds_6_tfresidentlastname_sel, lV69Trn_residentwwds_8_tfresidentemail, AV70Trn_residentwwds_9_tfresidentemail_sel, lV71Trn_residentwwds_10_tfresidentphone, AV72Trn_residentwwds_11_tfresidentphone_sel, lV73Trn_residentwwds_12_tfresidenttypename, AV74Trn_residentwwds_13_tfresidenttypename_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK7B10 = false;
            A96ResidentTypeId = P007B6_A96ResidentTypeId[0];
            A97ResidentTypeName = P007B6_A97ResidentTypeName[0];
            A70ResidentPhone = P007B6_A70ResidentPhone[0];
            A67ResidentEmail = P007B6_A67ResidentEmail[0];
            A68ResidentGender = P007B6_A68ResidentGender[0];
            A65ResidentLastName = P007B6_A65ResidentLastName[0];
            A64ResidentGivenName = P007B6_A64ResidentGivenName[0];
            A72ResidentSalutation = P007B6_A72ResidentSalutation[0];
            A62ResidentId = P007B6_A62ResidentId[0];
            A29LocationId = P007B6_A29LocationId[0];
            A11OrganisationId = P007B6_A11OrganisationId[0];
            A97ResidentTypeName = P007B6_A97ResidentTypeName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext)) || ( ( StringUtil.Like( context.GetMessage( context.GetMessage( "mr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "mrs", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Mrs", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "dr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Dr", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "miss", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A72ResidentSalutation, context.GetMessage( "Miss", "")) == 0 ) ) || ( StringUtil.Like( A64ResidentGivenName , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A65ResidentLastName , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "male", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Male", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "female", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Female", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "other", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Trn_residentwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A68ResidentGender, context.GetMessage( "Other", "")) == 0 ) ) || ( StringUtil.Like( A67ResidentEmail , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A70ResidentPhone , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A97ResidentTypeName , StringUtil.PadR( "%" + AV62Trn_residentwwds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV41count = 0;
               while ( (pr_default.getStatus(4) != 101) && ( P007B6_A96ResidentTypeId[0] == A96ResidentTypeId ) )
               {
                  BRK7B10 = false;
                  A62ResidentId = P007B6_A62ResidentId[0];
                  A29LocationId = P007B6_A29LocationId[0];
                  A11OrganisationId = P007B6_A11OrganisationId[0];
                  AV41count = (long)(AV41count+1);
                  BRK7B10 = true;
                  pr_default.readNext(4);
               }
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A97ResidentTypeName)) ? "<#Empty#>" : A97ResidentTypeName);
               AV35InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV36Option, "<#Empty#>") != 0 ) && ( AV35InsertIndex <= AV37Options.Count ) && ( ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), AV36Option) < 0 ) || ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV35InsertIndex = (int)(AV35InsertIndex+1);
               }
               AV37Options.Add(AV36Option, AV35InsertIndex);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), AV35InsertIndex);
               if ( AV37Options.Count == AV32SkipItems + 11 )
               {
                  AV37Options.RemoveItem(AV37Options.Count);
                  AV40OptionIndexes.RemoveItem(AV40OptionIndexes.Count);
               }
            }
            if ( ! BRK7B10 )
            {
               BRK7B10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
         while ( AV32SkipItems > 0 )
         {
            AV37Options.RemoveItem(1);
            AV40OptionIndexes.RemoveItem(1);
            AV32SkipItems = (short)(AV32SkipItems-1);
         }
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
         AV50OptionsJson = "";
         AV51OptionsDescJson = "";
         AV52OptionIndexesJson = "";
         AV37Options = new GxSimpleCollection<string>();
         AV39OptionsDesc = new GxSimpleCollection<string>();
         AV40OptionIndexes = new GxSimpleCollection<string>();
         AV31SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV42Session = context.GetSession();
         AV44GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV45GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV53FilterFullText = "";
         AV11TFResidentSalutation_SelsJson = "";
         AV12TFResidentSalutation_Sels = new GxSimpleCollection<string>();
         AV13TFResidentGivenName = "";
         AV14TFResidentGivenName_Sel = "";
         AV15TFResidentLastName = "";
         AV16TFResidentLastName_Sel = "";
         AV21TFResidentGender_SelsJson = "";
         AV22TFResidentGender_Sels = new GxSimpleCollection<string>();
         AV19TFResidentEmail = "";
         AV20TFResidentEmail_Sel = "";
         AV23TFResidentPhone = "";
         AV24TFResidentPhone_Sel = "";
         AV27TFResidentTypeName = "";
         AV28TFResidentTypeName_Sel = "";
         AV62Trn_residentwwds_1_filterfulltext = "";
         AV63Trn_residentwwds_2_tfresidentsalutation_sels = new GxSimpleCollection<string>();
         AV64Trn_residentwwds_3_tfresidentgivenname = "";
         AV65Trn_residentwwds_4_tfresidentgivenname_sel = "";
         AV66Trn_residentwwds_5_tfresidentlastname = "";
         AV67Trn_residentwwds_6_tfresidentlastname_sel = "";
         AV68Trn_residentwwds_7_tfresidentgender_sels = new GxSimpleCollection<string>();
         AV69Trn_residentwwds_8_tfresidentemail = "";
         AV70Trn_residentwwds_9_tfresidentemail_sel = "";
         AV71Trn_residentwwds_10_tfresidentphone = "";
         AV72Trn_residentwwds_11_tfresidentphone_sel = "";
         AV73Trn_residentwwds_12_tfresidenttypename = "";
         AV74Trn_residentwwds_13_tfresidenttypename_sel = "";
         lV62Trn_residentwwds_1_filterfulltext = "";
         lV64Trn_residentwwds_3_tfresidentgivenname = "";
         lV66Trn_residentwwds_5_tfresidentlastname = "";
         lV69Trn_residentwwds_8_tfresidentemail = "";
         lV71Trn_residentwwds_10_tfresidentphone = "";
         lV73Trn_residentwwds_12_tfresidenttypename = "";
         A72ResidentSalutation = "";
         A68ResidentGender = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A67ResidentEmail = "";
         A70ResidentPhone = "";
         A97ResidentTypeName = "";
         P007B2_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007B2_A64ResidentGivenName = new string[] {""} ;
         P007B2_A97ResidentTypeName = new string[] {""} ;
         P007B2_A70ResidentPhone = new string[] {""} ;
         P007B2_A67ResidentEmail = new string[] {""} ;
         P007B2_A68ResidentGender = new string[] {""} ;
         P007B2_A65ResidentLastName = new string[] {""} ;
         P007B2_A72ResidentSalutation = new string[] {""} ;
         P007B2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007B2_A29LocationId = new Guid[] {Guid.Empty} ;
         P007B2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A96ResidentTypeId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV36Option = "";
         P007B3_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007B3_A65ResidentLastName = new string[] {""} ;
         P007B3_A97ResidentTypeName = new string[] {""} ;
         P007B3_A70ResidentPhone = new string[] {""} ;
         P007B3_A67ResidentEmail = new string[] {""} ;
         P007B3_A68ResidentGender = new string[] {""} ;
         P007B3_A64ResidentGivenName = new string[] {""} ;
         P007B3_A72ResidentSalutation = new string[] {""} ;
         P007B3_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007B3_A29LocationId = new Guid[] {Guid.Empty} ;
         P007B3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007B4_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007B4_A67ResidentEmail = new string[] {""} ;
         P007B4_A97ResidentTypeName = new string[] {""} ;
         P007B4_A70ResidentPhone = new string[] {""} ;
         P007B4_A68ResidentGender = new string[] {""} ;
         P007B4_A65ResidentLastName = new string[] {""} ;
         P007B4_A64ResidentGivenName = new string[] {""} ;
         P007B4_A72ResidentSalutation = new string[] {""} ;
         P007B4_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007B4_A29LocationId = new Guid[] {Guid.Empty} ;
         P007B4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007B5_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007B5_A70ResidentPhone = new string[] {""} ;
         P007B5_A97ResidentTypeName = new string[] {""} ;
         P007B5_A67ResidentEmail = new string[] {""} ;
         P007B5_A68ResidentGender = new string[] {""} ;
         P007B5_A65ResidentLastName = new string[] {""} ;
         P007B5_A64ResidentGivenName = new string[] {""} ;
         P007B5_A72ResidentSalutation = new string[] {""} ;
         P007B5_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007B5_A29LocationId = new Guid[] {Guid.Empty} ;
         P007B5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007B6_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007B6_A97ResidentTypeName = new string[] {""} ;
         P007B6_A70ResidentPhone = new string[] {""} ;
         P007B6_A67ResidentEmail = new string[] {""} ;
         P007B6_A68ResidentGender = new string[] {""} ;
         P007B6_A65ResidentLastName = new string[] {""} ;
         P007B6_A64ResidentGivenName = new string[] {""} ;
         P007B6_A72ResidentSalutation = new string[] {""} ;
         P007B6_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007B6_A29LocationId = new Guid[] {Guid.Empty} ;
         P007B6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007B2_A96ResidentTypeId, P007B2_A64ResidentGivenName, P007B2_A97ResidentTypeName, P007B2_A70ResidentPhone, P007B2_A67ResidentEmail, P007B2_A68ResidentGender, P007B2_A65ResidentLastName, P007B2_A72ResidentSalutation, P007B2_A62ResidentId, P007B2_A29LocationId,
               P007B2_A11OrganisationId
               }
               , new Object[] {
               P007B3_A96ResidentTypeId, P007B3_A65ResidentLastName, P007B3_A97ResidentTypeName, P007B3_A70ResidentPhone, P007B3_A67ResidentEmail, P007B3_A68ResidentGender, P007B3_A64ResidentGivenName, P007B3_A72ResidentSalutation, P007B3_A62ResidentId, P007B3_A29LocationId,
               P007B3_A11OrganisationId
               }
               , new Object[] {
               P007B4_A96ResidentTypeId, P007B4_A67ResidentEmail, P007B4_A97ResidentTypeName, P007B4_A70ResidentPhone, P007B4_A68ResidentGender, P007B4_A65ResidentLastName, P007B4_A64ResidentGivenName, P007B4_A72ResidentSalutation, P007B4_A62ResidentId, P007B4_A29LocationId,
               P007B4_A11OrganisationId
               }
               , new Object[] {
               P007B5_A96ResidentTypeId, P007B5_A70ResidentPhone, P007B5_A97ResidentTypeName, P007B5_A67ResidentEmail, P007B5_A68ResidentGender, P007B5_A65ResidentLastName, P007B5_A64ResidentGivenName, P007B5_A72ResidentSalutation, P007B5_A62ResidentId, P007B5_A29LocationId,
               P007B5_A11OrganisationId
               }
               , new Object[] {
               P007B6_A96ResidentTypeId, P007B6_A97ResidentTypeName, P007B6_A70ResidentPhone, P007B6_A67ResidentEmail, P007B6_A68ResidentGender, P007B6_A65ResidentLastName, P007B6_A64ResidentGivenName, P007B6_A72ResidentSalutation, P007B6_A62ResidentId, P007B6_A29LocationId,
               P007B6_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV34MaxItems ;
      private short AV33PageIndex ;
      private short AV32SkipItems ;
      private int AV60GXV1 ;
      private int AV63Trn_residentwwds_2_tfresidentsalutation_sels_Count ;
      private int AV68Trn_residentwwds_7_tfresidentgender_sels_Count ;
      private int AV35InsertIndex ;
      private long AV41count ;
      private string AV23TFResidentPhone ;
      private string AV24TFResidentPhone_Sel ;
      private string AV71Trn_residentwwds_10_tfresidentphone ;
      private string AV72Trn_residentwwds_11_tfresidentphone_sel ;
      private string lV71Trn_residentwwds_10_tfresidentphone ;
      private string A72ResidentSalutation ;
      private string A70ResidentPhone ;
      private bool returnInSub ;
      private bool BRK7B2 ;
      private bool BRK7B4 ;
      private bool BRK7B6 ;
      private bool BRK7B8 ;
      private bool BRK7B10 ;
      private string AV50OptionsJson ;
      private string AV51OptionsDescJson ;
      private string AV52OptionIndexesJson ;
      private string AV11TFResidentSalutation_SelsJson ;
      private string AV21TFResidentGender_SelsJson ;
      private string AV47DDOName ;
      private string AV48SearchTxtParms ;
      private string AV49SearchTxtTo ;
      private string AV31SearchTxt ;
      private string AV53FilterFullText ;
      private string AV13TFResidentGivenName ;
      private string AV14TFResidentGivenName_Sel ;
      private string AV15TFResidentLastName ;
      private string AV16TFResidentLastName_Sel ;
      private string AV19TFResidentEmail ;
      private string AV20TFResidentEmail_Sel ;
      private string AV27TFResidentTypeName ;
      private string AV28TFResidentTypeName_Sel ;
      private string AV62Trn_residentwwds_1_filterfulltext ;
      private string AV64Trn_residentwwds_3_tfresidentgivenname ;
      private string AV65Trn_residentwwds_4_tfresidentgivenname_sel ;
      private string AV66Trn_residentwwds_5_tfresidentlastname ;
      private string AV67Trn_residentwwds_6_tfresidentlastname_sel ;
      private string AV69Trn_residentwwds_8_tfresidentemail ;
      private string AV70Trn_residentwwds_9_tfresidentemail_sel ;
      private string AV73Trn_residentwwds_12_tfresidenttypename ;
      private string AV74Trn_residentwwds_13_tfresidenttypename_sel ;
      private string lV62Trn_residentwwds_1_filterfulltext ;
      private string lV64Trn_residentwwds_3_tfresidentgivenname ;
      private string lV66Trn_residentwwds_5_tfresidentlastname ;
      private string lV69Trn_residentwwds_8_tfresidentemail ;
      private string lV73Trn_residentwwds_12_tfresidenttypename ;
      private string A68ResidentGender ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A67ResidentEmail ;
      private string A97ResidentTypeName ;
      private string AV36Option ;
      private Guid A96ResidentTypeId ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxSession AV42Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV37Options ;
      private GxSimpleCollection<string> AV39OptionsDesc ;
      private GxSimpleCollection<string> AV40OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV44GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV45GridStateFilterValue ;
      private GxSimpleCollection<string> AV12TFResidentSalutation_Sels ;
      private GxSimpleCollection<string> AV22TFResidentGender_Sels ;
      private GxSimpleCollection<string> AV63Trn_residentwwds_2_tfresidentsalutation_sels ;
      private GxSimpleCollection<string> AV68Trn_residentwwds_7_tfresidentgender_sels ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007B2_A96ResidentTypeId ;
      private string[] P007B2_A64ResidentGivenName ;
      private string[] P007B2_A97ResidentTypeName ;
      private string[] P007B2_A70ResidentPhone ;
      private string[] P007B2_A67ResidentEmail ;
      private string[] P007B2_A68ResidentGender ;
      private string[] P007B2_A65ResidentLastName ;
      private string[] P007B2_A72ResidentSalutation ;
      private Guid[] P007B2_A62ResidentId ;
      private Guid[] P007B2_A29LocationId ;
      private Guid[] P007B2_A11OrganisationId ;
      private Guid[] P007B3_A96ResidentTypeId ;
      private string[] P007B3_A65ResidentLastName ;
      private string[] P007B3_A97ResidentTypeName ;
      private string[] P007B3_A70ResidentPhone ;
      private string[] P007B3_A67ResidentEmail ;
      private string[] P007B3_A68ResidentGender ;
      private string[] P007B3_A64ResidentGivenName ;
      private string[] P007B3_A72ResidentSalutation ;
      private Guid[] P007B3_A62ResidentId ;
      private Guid[] P007B3_A29LocationId ;
      private Guid[] P007B3_A11OrganisationId ;
      private Guid[] P007B4_A96ResidentTypeId ;
      private string[] P007B4_A67ResidentEmail ;
      private string[] P007B4_A97ResidentTypeName ;
      private string[] P007B4_A70ResidentPhone ;
      private string[] P007B4_A68ResidentGender ;
      private string[] P007B4_A65ResidentLastName ;
      private string[] P007B4_A64ResidentGivenName ;
      private string[] P007B4_A72ResidentSalutation ;
      private Guid[] P007B4_A62ResidentId ;
      private Guid[] P007B4_A29LocationId ;
      private Guid[] P007B4_A11OrganisationId ;
      private Guid[] P007B5_A96ResidentTypeId ;
      private string[] P007B5_A70ResidentPhone ;
      private string[] P007B5_A97ResidentTypeName ;
      private string[] P007B5_A67ResidentEmail ;
      private string[] P007B5_A68ResidentGender ;
      private string[] P007B5_A65ResidentLastName ;
      private string[] P007B5_A64ResidentGivenName ;
      private string[] P007B5_A72ResidentSalutation ;
      private Guid[] P007B5_A62ResidentId ;
      private Guid[] P007B5_A29LocationId ;
      private Guid[] P007B5_A11OrganisationId ;
      private Guid[] P007B6_A96ResidentTypeId ;
      private string[] P007B6_A97ResidentTypeName ;
      private string[] P007B6_A70ResidentPhone ;
      private string[] P007B6_A67ResidentEmail ;
      private string[] P007B6_A68ResidentGender ;
      private string[] P007B6_A65ResidentLastName ;
      private string[] P007B6_A64ResidentGivenName ;
      private string[] P007B6_A72ResidentSalutation ;
      private Guid[] P007B6_A62ResidentId ;
      private Guid[] P007B6_A29LocationId ;
      private Guid[] P007B6_A11OrganisationId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_residentwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007B2( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV63Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV68Trn_residentwwds_7_tfresidentgender_sels ,
                                             int AV63Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV65Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV64Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV67Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV66Trn_residentwwds_5_tfresidentlastname ,
                                             int AV68Trn_residentwwds_7_tfresidentgender_sels_Count ,
                                             string AV70Trn_residentwwds_9_tfresidentemail_sel ,
                                             string AV69Trn_residentwwds_8_tfresidentemail ,
                                             string AV72Trn_residentwwds_11_tfresidentphone_sel ,
                                             string AV71Trn_residentwwds_10_tfresidentphone ,
                                             string AV74Trn_residentwwds_13_tfresidenttypename_sel ,
                                             string AV73Trn_residentwwds_12_tfresidenttypename ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string AV62Trn_residentwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.ResidentGivenName, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentEmail, T1.ResidentGender, T1.ResidentLastName, T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM (Trn_Resident T1 INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         if ( AV63Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV64Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV65Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV65Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV66Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV67Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV67Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( AV68Trn_residentwwds_7_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV68Trn_residentwwds_7_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_residentwwds_9_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_8_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV69Trn_residentwwds_8_tfresidentemail)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_residentwwds_9_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV70Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV70Trn_residentwwds_9_tfresidentemail_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_11_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_10_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV71Trn_residentwwds_10_tfresidentphone)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_11_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV72Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV72Trn_residentwwds_11_tfresidentphone_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_13_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_12_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV73Trn_residentwwds_12_tfresidenttypename)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_13_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV74Trn_residentwwds_13_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentGivenName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007B3( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV63Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV68Trn_residentwwds_7_tfresidentgender_sels ,
                                             int AV63Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV65Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV64Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV67Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV66Trn_residentwwds_5_tfresidentlastname ,
                                             int AV68Trn_residentwwds_7_tfresidentgender_sels_Count ,
                                             string AV70Trn_residentwwds_9_tfresidentemail_sel ,
                                             string AV69Trn_residentwwds_8_tfresidentemail ,
                                             string AV72Trn_residentwwds_11_tfresidentphone_sel ,
                                             string AV71Trn_residentwwds_10_tfresidentphone ,
                                             string AV74Trn_residentwwds_13_tfresidenttypename_sel ,
                                             string AV73Trn_residentwwds_12_tfresidenttypename ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string AV62Trn_residentwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.ResidentLastName, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentEmail, T1.ResidentGender, T1.ResidentGivenName, T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM (Trn_Resident T1 INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         if ( AV63Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV64Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV65Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV65Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV66Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV67Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV67Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( AV68Trn_residentwwds_7_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV68Trn_residentwwds_7_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_residentwwds_9_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_8_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV69Trn_residentwwds_8_tfresidentemail)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_residentwwds_9_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV70Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV70Trn_residentwwds_9_tfresidentemail_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_11_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_10_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV71Trn_residentwwds_10_tfresidentphone)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_11_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV72Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV72Trn_residentwwds_11_tfresidentphone_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_13_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_12_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV73Trn_residentwwds_12_tfresidenttypename)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_13_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV74Trn_residentwwds_13_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentLastName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P007B4( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV63Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV68Trn_residentwwds_7_tfresidentgender_sels ,
                                             int AV63Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV65Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV64Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV67Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV66Trn_residentwwds_5_tfresidentlastname ,
                                             int AV68Trn_residentwwds_7_tfresidentgender_sels_Count ,
                                             string AV70Trn_residentwwds_9_tfresidentemail_sel ,
                                             string AV69Trn_residentwwds_8_tfresidentemail ,
                                             string AV72Trn_residentwwds_11_tfresidentphone_sel ,
                                             string AV71Trn_residentwwds_10_tfresidentphone ,
                                             string AV74Trn_residentwwds_13_tfresidenttypename_sel ,
                                             string AV73Trn_residentwwds_12_tfresidenttypename ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string AV62Trn_residentwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[10];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.ResidentEmail, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentGender, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM (Trn_Resident T1 INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         if ( AV63Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV64Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV65Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV65Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV66Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV67Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV67Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( AV68Trn_residentwwds_7_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV68Trn_residentwwds_7_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_residentwwds_9_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_8_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV69Trn_residentwwds_8_tfresidentemail)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_residentwwds_9_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV70Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV70Trn_residentwwds_9_tfresidentemail_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_11_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_10_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV71Trn_residentwwds_10_tfresidentphone)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_11_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV72Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV72Trn_residentwwds_11_tfresidentphone_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_13_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_12_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV73Trn_residentwwds_12_tfresidenttypename)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_13_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV74Trn_residentwwds_13_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentEmail";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P007B5( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV63Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV68Trn_residentwwds_7_tfresidentgender_sels ,
                                             int AV63Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV65Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV64Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV67Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV66Trn_residentwwds_5_tfresidentlastname ,
                                             int AV68Trn_residentwwds_7_tfresidentgender_sels_Count ,
                                             string AV70Trn_residentwwds_9_tfresidentemail_sel ,
                                             string AV69Trn_residentwwds_8_tfresidentemail ,
                                             string AV72Trn_residentwwds_11_tfresidentphone_sel ,
                                             string AV71Trn_residentwwds_10_tfresidentphone ,
                                             string AV74Trn_residentwwds_13_tfresidenttypename_sel ,
                                             string AV73Trn_residentwwds_12_tfresidenttypename ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string AV62Trn_residentwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[10];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.ResidentPhone, T2.ResidentTypeName, T1.ResidentEmail, T1.ResidentGender, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM (Trn_Resident T1 INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         if ( AV63Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV64Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV65Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV65Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV66Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV67Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV67Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( AV68Trn_residentwwds_7_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV68Trn_residentwwds_7_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_residentwwds_9_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_8_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV69Trn_residentwwds_8_tfresidentemail)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_residentwwds_9_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV70Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV70Trn_residentwwds_9_tfresidentemail_sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_11_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_10_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV71Trn_residentwwds_10_tfresidentphone)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_11_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV72Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV72Trn_residentwwds_11_tfresidentphone_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_13_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_12_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV73Trn_residentwwds_12_tfresidenttypename)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_13_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV74Trn_residentwwds_13_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentPhone";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P007B6( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV63Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV68Trn_residentwwds_7_tfresidentgender_sels ,
                                             int AV63Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV65Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV64Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV67Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV66Trn_residentwwds_5_tfresidentlastname ,
                                             int AV68Trn_residentwwds_7_tfresidentgender_sels_Count ,
                                             string AV70Trn_residentwwds_9_tfresidentemail_sel ,
                                             string AV69Trn_residentwwds_8_tfresidentemail ,
                                             string AV72Trn_residentwwds_11_tfresidentphone_sel ,
                                             string AV71Trn_residentwwds_10_tfresidentphone ,
                                             string AV74Trn_residentwwds_13_tfresidenttypename_sel ,
                                             string AV73Trn_residentwwds_12_tfresidenttypename ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string AV62Trn_residentwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[10];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentEmail, T1.ResidentGender, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM (Trn_Resident T1 INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         if ( AV63Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV64Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV65Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV65Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_residentwwds_4_tfresidentgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV66Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV67Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV67Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_residentwwds_6_tfresidentlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( AV68Trn_residentwwds_7_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV68Trn_residentwwds_7_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_residentwwds_9_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_8_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV69Trn_residentwwds_8_tfresidentemail)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_residentwwds_9_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV70Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV70Trn_residentwwds_9_tfresidentemail_sel))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_residentwwds_9_tfresidentemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_11_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_10_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV71Trn_residentwwds_10_tfresidentphone)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_11_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV72Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV72Trn_residentwwds_11_tfresidentphone_sel))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_residentwwds_11_tfresidentphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_13_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_12_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV73Trn_residentwwds_12_tfresidenttypename)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_13_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV74Trn_residentwwds_13_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_13_tfresidenttypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentTypeId";
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
                     return conditional_P007B2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
               case 1 :
                     return conditional_P007B3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
               case 2 :
                     return conditional_P007B4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
               case 3 :
                     return conditional_P007B5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
               case 4 :
                     return conditional_P007B6(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
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
          Object[] prmP007B2;
          prmP007B2 = new Object[] {
          new ParDef("lV64Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Trn_residentwwds_8_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV70Trn_residentwwds_9_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_residentwwds_10_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV72Trn_residentwwds_11_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV73Trn_residentwwds_12_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_residentwwds_13_tfresidenttypename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP007B3;
          prmP007B3 = new Object[] {
          new ParDef("lV64Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Trn_residentwwds_8_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV70Trn_residentwwds_9_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_residentwwds_10_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV72Trn_residentwwds_11_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV73Trn_residentwwds_12_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_residentwwds_13_tfresidenttypename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP007B4;
          prmP007B4 = new Object[] {
          new ParDef("lV64Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Trn_residentwwds_8_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV70Trn_residentwwds_9_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_residentwwds_10_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV72Trn_residentwwds_11_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV73Trn_residentwwds_12_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_residentwwds_13_tfresidenttypename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP007B5;
          prmP007B5 = new Object[] {
          new ParDef("lV64Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Trn_residentwwds_8_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV70Trn_residentwwds_9_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_residentwwds_10_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV72Trn_residentwwds_11_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV73Trn_residentwwds_12_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_residentwwds_13_tfresidenttypename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP007B6;
          prmP007B6 = new Object[] {
          new ParDef("lV64Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Trn_residentwwds_8_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV70Trn_residentwwds_9_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_residentwwds_10_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV72Trn_residentwwds_11_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV73Trn_residentwwds_12_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_residentwwds_13_tfresidenttypename_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007B4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007B5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007B6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((Guid[]) buf[8])[0] = rslt.getGuid(9);
                ((Guid[]) buf[9])[0] = rslt.getGuid(10);
                ((Guid[]) buf[10])[0] = rslt.getGuid(11);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((Guid[]) buf[8])[0] = rslt.getGuid(9);
                ((Guid[]) buf[9])[0] = rslt.getGuid(10);
                ((Guid[]) buf[10])[0] = rslt.getGuid(11);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((Guid[]) buf[8])[0] = rslt.getGuid(9);
                ((Guid[]) buf[9])[0] = rslt.getGuid(10);
                ((Guid[]) buf[10])[0] = rslt.getGuid(11);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((Guid[]) buf[8])[0] = rslt.getGuid(9);
                ((Guid[]) buf[9])[0] = rslt.getGuid(10);
                ((Guid[]) buf[10])[0] = rslt.getGuid(11);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((Guid[]) buf[8])[0] = rslt.getGuid(9);
                ((Guid[]) buf[9])[0] = rslt.getGuid(10);
                ((Guid[]) buf[10])[0] = rslt.getGuid(11);
                return;
       }
    }

 }

}
