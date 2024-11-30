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
   public class trn_receptionistwwgetfilterdata : GXProcedure
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
            return "trn_receptionistww_Services_Execute" ;
         }

      }

      public trn_receptionistwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_receptionistwwgetfilterdata( IGxContext context )
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
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV44OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV29Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26MaxItems = 10;
         AV25PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV40SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV23SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? "" : StringUtil.Substring( AV40SearchTxtParms, 3, -1));
         AV24SkipItems = (short)(AV25PageIndex*AV26MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_RECEPTIONISTGIVENNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRECEPTIONISTGIVENNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_RECEPTIONISTLASTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRECEPTIONISTLASTNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_RECEPTIONISTEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADRECEPTIONISTEMAILOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_RECEPTIONISTPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADRECEPTIONISTPHONEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV42OptionsJson = AV29Options.ToJSonString(false);
         AV43OptionsDescJson = AV31OptionsDesc.ToJSonString(false);
         AV44OptionIndexesJson = AV32OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34Session.Get("Trn_ReceptionistWWGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Trn_ReceptionistWWGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("Trn_ReceptionistWWGridState"), null, "", "");
         }
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV52GXV1));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV45FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTGIVENNAME") == 0 )
            {
               AV11TFReceptionistGivenName = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTGIVENNAME_SEL") == 0 )
            {
               AV12TFReceptionistGivenName_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTLASTNAME") == 0 )
            {
               AV13TFReceptionistLastName = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTLASTNAME_SEL") == 0 )
            {
               AV14TFReceptionistLastName_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTEMAIL") == 0 )
            {
               AV17TFReceptionistEmail = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTEMAIL_SEL") == 0 )
            {
               AV18TFReceptionistEmail_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTPHONE") == 0 )
            {
               AV19TFReceptionistPhone = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTPHONE_SEL") == 0 )
            {
               AV20TFReceptionistPhone_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTISACTIVE_SEL") == 0 )
            {
               AV51TFReceptionistIsActive_Sel = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADRECEPTIONISTGIVENNAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFReceptionistGivenName = AV23SearchTxt;
         AV12TFReceptionistGivenName_Sel = "";
         AV54Trn_receptionistwwds_1_filterfulltext = AV45FilterFullText;
         AV55Trn_receptionistwwds_2_tfreceptionistgivenname = AV11TFReceptionistGivenName;
         AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel = AV12TFReceptionistGivenName_Sel;
         AV57Trn_receptionistwwds_4_tfreceptionistlastname = AV13TFReceptionistLastName;
         AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel = AV14TFReceptionistLastName_Sel;
         AV59Trn_receptionistwwds_6_tfreceptionistemail = AV17TFReceptionistEmail;
         AV60Trn_receptionistwwds_7_tfreceptionistemail_sel = AV18TFReceptionistEmail_Sel;
         AV61Trn_receptionistwwds_8_tfreceptionistphone = AV19TFReceptionistPhone;
         AV62Trn_receptionistwwds_9_tfreceptionistphone_sel = AV20TFReceptionistPhone_Sel;
         AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel = AV51TFReceptionistIsActive_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV54Trn_receptionistwwds_1_filterfulltext ,
                                              AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                              AV55Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                              AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                              AV57Trn_receptionistwwds_4_tfreceptionistlastname ,
                                              AV60Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                              AV59Trn_receptionistwwds_6_tfreceptionistemail ,
                                              AV62Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                              AV61Trn_receptionistwwds_8_tfreceptionistphone ,
                                              AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                              A90ReceptionistGivenName ,
                                              A91ReceptionistLastName ,
                                              A93ReceptionistEmail ,
                                              A94ReceptionistPhone ,
                                              A398ReceptionistIsActive } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV54Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV54Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV54Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV55Trn_receptionistwwds_2_tfreceptionistgivenname = StringUtil.Concat( StringUtil.RTrim( AV55Trn_receptionistwwds_2_tfreceptionistgivenname), "%", "");
         lV57Trn_receptionistwwds_4_tfreceptionistlastname = StringUtil.Concat( StringUtil.RTrim( AV57Trn_receptionistwwds_4_tfreceptionistlastname), "%", "");
         lV59Trn_receptionistwwds_6_tfreceptionistemail = StringUtil.Concat( StringUtil.RTrim( AV59Trn_receptionistwwds_6_tfreceptionistemail), "%", "");
         lV61Trn_receptionistwwds_8_tfreceptionistphone = StringUtil.PadR( StringUtil.RTrim( AV61Trn_receptionistwwds_8_tfreceptionistphone), 20, "%");
         /* Using cursor P006M2 */
         pr_default.execute(0, new Object[] {lV54Trn_receptionistwwds_1_filterfulltext, lV54Trn_receptionistwwds_1_filterfulltext, lV54Trn_receptionistwwds_1_filterfulltext, lV54Trn_receptionistwwds_1_filterfulltext, lV55Trn_receptionistwwds_2_tfreceptionistgivenname, AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel, lV57Trn_receptionistwwds_4_tfreceptionistlastname, AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel, lV59Trn_receptionistwwds_6_tfreceptionistemail, AV60Trn_receptionistwwds_7_tfreceptionistemail_sel, lV61Trn_receptionistwwds_8_tfreceptionistphone, AV62Trn_receptionistwwds_9_tfreceptionistphone_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6M2 = false;
            A90ReceptionistGivenName = P006M2_A90ReceptionistGivenName[0];
            A398ReceptionistIsActive = P006M2_A398ReceptionistIsActive[0];
            A94ReceptionistPhone = P006M2_A94ReceptionistPhone[0];
            A93ReceptionistEmail = P006M2_A93ReceptionistEmail[0];
            A91ReceptionistLastName = P006M2_A91ReceptionistLastName[0];
            A89ReceptionistId = P006M2_A89ReceptionistId[0];
            A11OrganisationId = P006M2_A11OrganisationId[0];
            A29LocationId = P006M2_A29LocationId[0];
            AV33count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006M2_A90ReceptionistGivenName[0], A90ReceptionistGivenName) == 0 ) )
            {
               BRK6M2 = false;
               A89ReceptionistId = P006M2_A89ReceptionistId[0];
               A11OrganisationId = P006M2_A11OrganisationId[0];
               A29LocationId = P006M2_A29LocationId[0];
               AV33count = (long)(AV33count+1);
               BRK6M2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A90ReceptionistGivenName)) ? "<#Empty#>" : A90ReceptionistGivenName);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRK6M2 )
            {
               BRK6M2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADRECEPTIONISTLASTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFReceptionistLastName = AV23SearchTxt;
         AV14TFReceptionistLastName_Sel = "";
         AV54Trn_receptionistwwds_1_filterfulltext = AV45FilterFullText;
         AV55Trn_receptionistwwds_2_tfreceptionistgivenname = AV11TFReceptionistGivenName;
         AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel = AV12TFReceptionistGivenName_Sel;
         AV57Trn_receptionistwwds_4_tfreceptionistlastname = AV13TFReceptionistLastName;
         AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel = AV14TFReceptionistLastName_Sel;
         AV59Trn_receptionistwwds_6_tfreceptionistemail = AV17TFReceptionistEmail;
         AV60Trn_receptionistwwds_7_tfreceptionistemail_sel = AV18TFReceptionistEmail_Sel;
         AV61Trn_receptionistwwds_8_tfreceptionistphone = AV19TFReceptionistPhone;
         AV62Trn_receptionistwwds_9_tfreceptionistphone_sel = AV20TFReceptionistPhone_Sel;
         AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel = AV51TFReceptionistIsActive_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV54Trn_receptionistwwds_1_filterfulltext ,
                                              AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                              AV55Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                              AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                              AV57Trn_receptionistwwds_4_tfreceptionistlastname ,
                                              AV60Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                              AV59Trn_receptionistwwds_6_tfreceptionistemail ,
                                              AV62Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                              AV61Trn_receptionistwwds_8_tfreceptionistphone ,
                                              AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                              A90ReceptionistGivenName ,
                                              A91ReceptionistLastName ,
                                              A93ReceptionistEmail ,
                                              A94ReceptionistPhone ,
                                              A398ReceptionistIsActive } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV54Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV54Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV54Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV55Trn_receptionistwwds_2_tfreceptionistgivenname = StringUtil.Concat( StringUtil.RTrim( AV55Trn_receptionistwwds_2_tfreceptionistgivenname), "%", "");
         lV57Trn_receptionistwwds_4_tfreceptionistlastname = StringUtil.Concat( StringUtil.RTrim( AV57Trn_receptionistwwds_4_tfreceptionistlastname), "%", "");
         lV59Trn_receptionistwwds_6_tfreceptionistemail = StringUtil.Concat( StringUtil.RTrim( AV59Trn_receptionistwwds_6_tfreceptionistemail), "%", "");
         lV61Trn_receptionistwwds_8_tfreceptionistphone = StringUtil.PadR( StringUtil.RTrim( AV61Trn_receptionistwwds_8_tfreceptionistphone), 20, "%");
         /* Using cursor P006M3 */
         pr_default.execute(1, new Object[] {lV54Trn_receptionistwwds_1_filterfulltext, lV54Trn_receptionistwwds_1_filterfulltext, lV54Trn_receptionistwwds_1_filterfulltext, lV54Trn_receptionistwwds_1_filterfulltext, lV55Trn_receptionistwwds_2_tfreceptionistgivenname, AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel, lV57Trn_receptionistwwds_4_tfreceptionistlastname, AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel, lV59Trn_receptionistwwds_6_tfreceptionistemail, AV60Trn_receptionistwwds_7_tfreceptionistemail_sel, lV61Trn_receptionistwwds_8_tfreceptionistphone, AV62Trn_receptionistwwds_9_tfreceptionistphone_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6M4 = false;
            A91ReceptionistLastName = P006M3_A91ReceptionistLastName[0];
            A398ReceptionistIsActive = P006M3_A398ReceptionistIsActive[0];
            A94ReceptionistPhone = P006M3_A94ReceptionistPhone[0];
            A93ReceptionistEmail = P006M3_A93ReceptionistEmail[0];
            A90ReceptionistGivenName = P006M3_A90ReceptionistGivenName[0];
            A89ReceptionistId = P006M3_A89ReceptionistId[0];
            A11OrganisationId = P006M3_A11OrganisationId[0];
            A29LocationId = P006M3_A29LocationId[0];
            AV33count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006M3_A91ReceptionistLastName[0], A91ReceptionistLastName) == 0 ) )
            {
               BRK6M4 = false;
               A89ReceptionistId = P006M3_A89ReceptionistId[0];
               A11OrganisationId = P006M3_A11OrganisationId[0];
               A29LocationId = P006M3_A29LocationId[0];
               AV33count = (long)(AV33count+1);
               BRK6M4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A91ReceptionistLastName)) ? "<#Empty#>" : A91ReceptionistLastName);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRK6M4 )
            {
               BRK6M4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADRECEPTIONISTEMAILOPTIONS' Routine */
         returnInSub = false;
         AV17TFReceptionistEmail = AV23SearchTxt;
         AV18TFReceptionistEmail_Sel = "";
         AV54Trn_receptionistwwds_1_filterfulltext = AV45FilterFullText;
         AV55Trn_receptionistwwds_2_tfreceptionistgivenname = AV11TFReceptionistGivenName;
         AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel = AV12TFReceptionistGivenName_Sel;
         AV57Trn_receptionistwwds_4_tfreceptionistlastname = AV13TFReceptionistLastName;
         AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel = AV14TFReceptionistLastName_Sel;
         AV59Trn_receptionistwwds_6_tfreceptionistemail = AV17TFReceptionistEmail;
         AV60Trn_receptionistwwds_7_tfreceptionistemail_sel = AV18TFReceptionistEmail_Sel;
         AV61Trn_receptionistwwds_8_tfreceptionistphone = AV19TFReceptionistPhone;
         AV62Trn_receptionistwwds_9_tfreceptionistphone_sel = AV20TFReceptionistPhone_Sel;
         AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel = AV51TFReceptionistIsActive_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV54Trn_receptionistwwds_1_filterfulltext ,
                                              AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                              AV55Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                              AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                              AV57Trn_receptionistwwds_4_tfreceptionistlastname ,
                                              AV60Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                              AV59Trn_receptionistwwds_6_tfreceptionistemail ,
                                              AV62Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                              AV61Trn_receptionistwwds_8_tfreceptionistphone ,
                                              AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                              A90ReceptionistGivenName ,
                                              A91ReceptionistLastName ,
                                              A93ReceptionistEmail ,
                                              A94ReceptionistPhone ,
                                              A398ReceptionistIsActive } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV54Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV54Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV54Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV55Trn_receptionistwwds_2_tfreceptionistgivenname = StringUtil.Concat( StringUtil.RTrim( AV55Trn_receptionistwwds_2_tfreceptionistgivenname), "%", "");
         lV57Trn_receptionistwwds_4_tfreceptionistlastname = StringUtil.Concat( StringUtil.RTrim( AV57Trn_receptionistwwds_4_tfreceptionistlastname), "%", "");
         lV59Trn_receptionistwwds_6_tfreceptionistemail = StringUtil.Concat( StringUtil.RTrim( AV59Trn_receptionistwwds_6_tfreceptionistemail), "%", "");
         lV61Trn_receptionistwwds_8_tfreceptionistphone = StringUtil.PadR( StringUtil.RTrim( AV61Trn_receptionistwwds_8_tfreceptionistphone), 20, "%");
         /* Using cursor P006M4 */
         pr_default.execute(2, new Object[] {lV54Trn_receptionistwwds_1_filterfulltext, lV54Trn_receptionistwwds_1_filterfulltext, lV54Trn_receptionistwwds_1_filterfulltext, lV54Trn_receptionistwwds_1_filterfulltext, lV55Trn_receptionistwwds_2_tfreceptionistgivenname, AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel, lV57Trn_receptionistwwds_4_tfreceptionistlastname, AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel, lV59Trn_receptionistwwds_6_tfreceptionistemail, AV60Trn_receptionistwwds_7_tfreceptionistemail_sel, lV61Trn_receptionistwwds_8_tfreceptionistphone, AV62Trn_receptionistwwds_9_tfreceptionistphone_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6M6 = false;
            A93ReceptionistEmail = P006M4_A93ReceptionistEmail[0];
            A398ReceptionistIsActive = P006M4_A398ReceptionistIsActive[0];
            A94ReceptionistPhone = P006M4_A94ReceptionistPhone[0];
            A91ReceptionistLastName = P006M4_A91ReceptionistLastName[0];
            A90ReceptionistGivenName = P006M4_A90ReceptionistGivenName[0];
            A89ReceptionistId = P006M4_A89ReceptionistId[0];
            A11OrganisationId = P006M4_A11OrganisationId[0];
            A29LocationId = P006M4_A29LocationId[0];
            AV33count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006M4_A93ReceptionistEmail[0], A93ReceptionistEmail) == 0 ) )
            {
               BRK6M6 = false;
               A89ReceptionistId = P006M4_A89ReceptionistId[0];
               A11OrganisationId = P006M4_A11OrganisationId[0];
               A29LocationId = P006M4_A29LocationId[0];
               AV33count = (long)(AV33count+1);
               BRK6M6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A93ReceptionistEmail)) ? "<#Empty#>" : A93ReceptionistEmail);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRK6M6 )
            {
               BRK6M6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADRECEPTIONISTPHONEOPTIONS' Routine */
         returnInSub = false;
         AV19TFReceptionistPhone = AV23SearchTxt;
         AV20TFReceptionistPhone_Sel = "";
         AV54Trn_receptionistwwds_1_filterfulltext = AV45FilterFullText;
         AV55Trn_receptionistwwds_2_tfreceptionistgivenname = AV11TFReceptionistGivenName;
         AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel = AV12TFReceptionistGivenName_Sel;
         AV57Trn_receptionistwwds_4_tfreceptionistlastname = AV13TFReceptionistLastName;
         AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel = AV14TFReceptionistLastName_Sel;
         AV59Trn_receptionistwwds_6_tfreceptionistemail = AV17TFReceptionistEmail;
         AV60Trn_receptionistwwds_7_tfreceptionistemail_sel = AV18TFReceptionistEmail_Sel;
         AV61Trn_receptionistwwds_8_tfreceptionistphone = AV19TFReceptionistPhone;
         AV62Trn_receptionistwwds_9_tfreceptionistphone_sel = AV20TFReceptionistPhone_Sel;
         AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel = AV51TFReceptionistIsActive_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV54Trn_receptionistwwds_1_filterfulltext ,
                                              AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                              AV55Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                              AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                              AV57Trn_receptionistwwds_4_tfreceptionistlastname ,
                                              AV60Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                              AV59Trn_receptionistwwds_6_tfreceptionistemail ,
                                              AV62Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                              AV61Trn_receptionistwwds_8_tfreceptionistphone ,
                                              AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                              A90ReceptionistGivenName ,
                                              A91ReceptionistLastName ,
                                              A93ReceptionistEmail ,
                                              A94ReceptionistPhone ,
                                              A398ReceptionistIsActive } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV54Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV54Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV54Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV55Trn_receptionistwwds_2_tfreceptionistgivenname = StringUtil.Concat( StringUtil.RTrim( AV55Trn_receptionistwwds_2_tfreceptionistgivenname), "%", "");
         lV57Trn_receptionistwwds_4_tfreceptionistlastname = StringUtil.Concat( StringUtil.RTrim( AV57Trn_receptionistwwds_4_tfreceptionistlastname), "%", "");
         lV59Trn_receptionistwwds_6_tfreceptionistemail = StringUtil.Concat( StringUtil.RTrim( AV59Trn_receptionistwwds_6_tfreceptionistemail), "%", "");
         lV61Trn_receptionistwwds_8_tfreceptionistphone = StringUtil.PadR( StringUtil.RTrim( AV61Trn_receptionistwwds_8_tfreceptionistphone), 20, "%");
         /* Using cursor P006M5 */
         pr_default.execute(3, new Object[] {lV54Trn_receptionistwwds_1_filterfulltext, lV54Trn_receptionistwwds_1_filterfulltext, lV54Trn_receptionistwwds_1_filterfulltext, lV54Trn_receptionistwwds_1_filterfulltext, lV55Trn_receptionistwwds_2_tfreceptionistgivenname, AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel, lV57Trn_receptionistwwds_4_tfreceptionistlastname, AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel, lV59Trn_receptionistwwds_6_tfreceptionistemail, AV60Trn_receptionistwwds_7_tfreceptionistemail_sel, lV61Trn_receptionistwwds_8_tfreceptionistphone, AV62Trn_receptionistwwds_9_tfreceptionistphone_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK6M8 = false;
            A94ReceptionistPhone = P006M5_A94ReceptionistPhone[0];
            A398ReceptionistIsActive = P006M5_A398ReceptionistIsActive[0];
            A93ReceptionistEmail = P006M5_A93ReceptionistEmail[0];
            A91ReceptionistLastName = P006M5_A91ReceptionistLastName[0];
            A90ReceptionistGivenName = P006M5_A90ReceptionistGivenName[0];
            A89ReceptionistId = P006M5_A89ReceptionistId[0];
            A11OrganisationId = P006M5_A11OrganisationId[0];
            A29LocationId = P006M5_A29LocationId[0];
            AV33count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P006M5_A94ReceptionistPhone[0], A94ReceptionistPhone) == 0 ) )
            {
               BRK6M8 = false;
               A89ReceptionistId = P006M5_A89ReceptionistId[0];
               A11OrganisationId = P006M5_A11OrganisationId[0];
               A29LocationId = P006M5_A29LocationId[0];
               AV33count = (long)(AV33count+1);
               BRK6M8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A94ReceptionistPhone)) ? "<#Empty#>" : A94ReceptionistPhone);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRK6M8 )
            {
               BRK6M8 = true;
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
         AV42OptionsJson = "";
         AV43OptionsDescJson = "";
         AV44OptionIndexesJson = "";
         AV29Options = new GxSimpleCollection<string>();
         AV31OptionsDesc = new GxSimpleCollection<string>();
         AV32OptionIndexes = new GxSimpleCollection<string>();
         AV23SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV34Session = context.GetSession();
         AV36GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45FilterFullText = "";
         AV11TFReceptionistGivenName = "";
         AV12TFReceptionistGivenName_Sel = "";
         AV13TFReceptionistLastName = "";
         AV14TFReceptionistLastName_Sel = "";
         AV17TFReceptionistEmail = "";
         AV18TFReceptionistEmail_Sel = "";
         AV19TFReceptionistPhone = "";
         AV20TFReceptionistPhone_Sel = "";
         AV54Trn_receptionistwwds_1_filterfulltext = "";
         AV55Trn_receptionistwwds_2_tfreceptionistgivenname = "";
         AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel = "";
         AV57Trn_receptionistwwds_4_tfreceptionistlastname = "";
         AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel = "";
         AV59Trn_receptionistwwds_6_tfreceptionistemail = "";
         AV60Trn_receptionistwwds_7_tfreceptionistemail_sel = "";
         AV61Trn_receptionistwwds_8_tfreceptionistphone = "";
         AV62Trn_receptionistwwds_9_tfreceptionistphone_sel = "";
         lV54Trn_receptionistwwds_1_filterfulltext = "";
         lV55Trn_receptionistwwds_2_tfreceptionistgivenname = "";
         lV57Trn_receptionistwwds_4_tfreceptionistlastname = "";
         lV59Trn_receptionistwwds_6_tfreceptionistemail = "";
         lV61Trn_receptionistwwds_8_tfreceptionistphone = "";
         A90ReceptionistGivenName = "";
         A91ReceptionistLastName = "";
         A93ReceptionistEmail = "";
         A94ReceptionistPhone = "";
         P006M2_A90ReceptionistGivenName = new string[] {""} ;
         P006M2_A398ReceptionistIsActive = new bool[] {false} ;
         P006M2_A94ReceptionistPhone = new string[] {""} ;
         P006M2_A93ReceptionistEmail = new string[] {""} ;
         P006M2_A91ReceptionistLastName = new string[] {""} ;
         P006M2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P006M2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006M2_A29LocationId = new Guid[] {Guid.Empty} ;
         A89ReceptionistId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         AV28Option = "";
         P006M3_A91ReceptionistLastName = new string[] {""} ;
         P006M3_A398ReceptionistIsActive = new bool[] {false} ;
         P006M3_A94ReceptionistPhone = new string[] {""} ;
         P006M3_A93ReceptionistEmail = new string[] {""} ;
         P006M3_A90ReceptionistGivenName = new string[] {""} ;
         P006M3_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P006M3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006M3_A29LocationId = new Guid[] {Guid.Empty} ;
         P006M4_A93ReceptionistEmail = new string[] {""} ;
         P006M4_A398ReceptionistIsActive = new bool[] {false} ;
         P006M4_A94ReceptionistPhone = new string[] {""} ;
         P006M4_A91ReceptionistLastName = new string[] {""} ;
         P006M4_A90ReceptionistGivenName = new string[] {""} ;
         P006M4_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P006M4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006M4_A29LocationId = new Guid[] {Guid.Empty} ;
         P006M5_A94ReceptionistPhone = new string[] {""} ;
         P006M5_A398ReceptionistIsActive = new bool[] {false} ;
         P006M5_A93ReceptionistEmail = new string[] {""} ;
         P006M5_A91ReceptionistLastName = new string[] {""} ;
         P006M5_A90ReceptionistGivenName = new string[] {""} ;
         P006M5_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P006M5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006M5_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_receptionistwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006M2_A90ReceptionistGivenName, P006M2_A398ReceptionistIsActive, P006M2_A94ReceptionistPhone, P006M2_A93ReceptionistEmail, P006M2_A91ReceptionistLastName, P006M2_A89ReceptionistId, P006M2_A11OrganisationId, P006M2_A29LocationId
               }
               , new Object[] {
               P006M3_A91ReceptionistLastName, P006M3_A398ReceptionistIsActive, P006M3_A94ReceptionistPhone, P006M3_A93ReceptionistEmail, P006M3_A90ReceptionistGivenName, P006M3_A89ReceptionistId, P006M3_A11OrganisationId, P006M3_A29LocationId
               }
               , new Object[] {
               P006M4_A93ReceptionistEmail, P006M4_A398ReceptionistIsActive, P006M4_A94ReceptionistPhone, P006M4_A91ReceptionistLastName, P006M4_A90ReceptionistGivenName, P006M4_A89ReceptionistId, P006M4_A11OrganisationId, P006M4_A29LocationId
               }
               , new Object[] {
               P006M5_A94ReceptionistPhone, P006M5_A398ReceptionistIsActive, P006M5_A93ReceptionistEmail, P006M5_A91ReceptionistLastName, P006M5_A90ReceptionistGivenName, P006M5_A89ReceptionistId, P006M5_A11OrganisationId, P006M5_A29LocationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV26MaxItems ;
      private short AV25PageIndex ;
      private short AV24SkipItems ;
      private short AV51TFReceptionistIsActive_Sel ;
      private short AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel ;
      private int AV52GXV1 ;
      private long AV33count ;
      private string AV19TFReceptionistPhone ;
      private string AV20TFReceptionistPhone_Sel ;
      private string AV61Trn_receptionistwwds_8_tfreceptionistphone ;
      private string AV62Trn_receptionistwwds_9_tfreceptionistphone_sel ;
      private string lV61Trn_receptionistwwds_8_tfreceptionistphone ;
      private string A94ReceptionistPhone ;
      private bool returnInSub ;
      private bool A398ReceptionistIsActive ;
      private bool BRK6M2 ;
      private bool BRK6M4 ;
      private bool BRK6M6 ;
      private bool BRK6M8 ;
      private string AV42OptionsJson ;
      private string AV43OptionsDescJson ;
      private string AV44OptionIndexesJson ;
      private string AV39DDOName ;
      private string AV40SearchTxtParms ;
      private string AV41SearchTxtTo ;
      private string AV23SearchTxt ;
      private string AV45FilterFullText ;
      private string AV11TFReceptionistGivenName ;
      private string AV12TFReceptionistGivenName_Sel ;
      private string AV13TFReceptionistLastName ;
      private string AV14TFReceptionistLastName_Sel ;
      private string AV17TFReceptionistEmail ;
      private string AV18TFReceptionistEmail_Sel ;
      private string AV54Trn_receptionistwwds_1_filterfulltext ;
      private string AV55Trn_receptionistwwds_2_tfreceptionistgivenname ;
      private string AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel ;
      private string AV57Trn_receptionistwwds_4_tfreceptionistlastname ;
      private string AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel ;
      private string AV59Trn_receptionistwwds_6_tfreceptionistemail ;
      private string AV60Trn_receptionistwwds_7_tfreceptionistemail_sel ;
      private string lV54Trn_receptionistwwds_1_filterfulltext ;
      private string lV55Trn_receptionistwwds_2_tfreceptionistgivenname ;
      private string lV57Trn_receptionistwwds_4_tfreceptionistlastname ;
      private string lV59Trn_receptionistwwds_6_tfreceptionistemail ;
      private string A90ReceptionistGivenName ;
      private string A91ReceptionistLastName ;
      private string A93ReceptionistEmail ;
      private string AV28Option ;
      private Guid A89ReceptionistId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV29Options ;
      private GxSimpleCollection<string> AV31OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P006M2_A90ReceptionistGivenName ;
      private bool[] P006M2_A398ReceptionistIsActive ;
      private string[] P006M2_A94ReceptionistPhone ;
      private string[] P006M2_A93ReceptionistEmail ;
      private string[] P006M2_A91ReceptionistLastName ;
      private Guid[] P006M2_A89ReceptionistId ;
      private Guid[] P006M2_A11OrganisationId ;
      private Guid[] P006M2_A29LocationId ;
      private string[] P006M3_A91ReceptionistLastName ;
      private bool[] P006M3_A398ReceptionistIsActive ;
      private string[] P006M3_A94ReceptionistPhone ;
      private string[] P006M3_A93ReceptionistEmail ;
      private string[] P006M3_A90ReceptionistGivenName ;
      private Guid[] P006M3_A89ReceptionistId ;
      private Guid[] P006M3_A11OrganisationId ;
      private Guid[] P006M3_A29LocationId ;
      private string[] P006M4_A93ReceptionistEmail ;
      private bool[] P006M4_A398ReceptionistIsActive ;
      private string[] P006M4_A94ReceptionistPhone ;
      private string[] P006M4_A91ReceptionistLastName ;
      private string[] P006M4_A90ReceptionistGivenName ;
      private Guid[] P006M4_A89ReceptionistId ;
      private Guid[] P006M4_A11OrganisationId ;
      private Guid[] P006M4_A29LocationId ;
      private string[] P006M5_A94ReceptionistPhone ;
      private bool[] P006M5_A398ReceptionistIsActive ;
      private string[] P006M5_A93ReceptionistEmail ;
      private string[] P006M5_A91ReceptionistLastName ;
      private string[] P006M5_A90ReceptionistGivenName ;
      private Guid[] P006M5_A89ReceptionistId ;
      private Guid[] P006M5_A11OrganisationId ;
      private Guid[] P006M5_A29LocationId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_receptionistwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006M2( IGxContext context ,
                                             string AV54Trn_receptionistwwds_1_filterfulltext ,
                                             string AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                             string AV55Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                             string AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                             string AV57Trn_receptionistwwds_4_tfreceptionistlastname ,
                                             string AV60Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                             string AV59Trn_receptionistwwds_6_tfreceptionistemail ,
                                             string AV62Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                             string AV61Trn_receptionistwwds_8_tfreceptionistphone ,
                                             short AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                             string A90ReceptionistGivenName ,
                                             string A91ReceptionistLastName ,
                                             string A93ReceptionistEmail ,
                                             string A94ReceptionistPhone ,
                                             bool A398ReceptionistIsActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT ReceptionistGivenName, ReceptionistIsActive, ReceptionistPhone, ReceptionistEmail, ReceptionistLastName, ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ReceptionistGivenName like '%' || :lV54Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistLastName like '%' || :lV54Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistEmail like '%' || :lV54Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistPhone like '%' || :lV54Trn_receptionistwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_receptionistwwds_2_tfreceptionistgivenname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName like :lV55Trn_receptionistwwds_2_tfreceptionistgivenname)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ! ( StringUtil.StrCmp(AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName = ( :AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_receptionistwwds_4_tfreceptionistlastname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName like :lV57Trn_receptionistwwds_4_tfreceptionistlastname)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ! ( StringUtil.StrCmp(AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName = ( :AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_receptionistwwds_6_tfreceptionistemail)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail like :lV59Trn_receptionistwwds_6_tfreceptionistemail)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ! ( StringUtil.StrCmp(AV60Trn_receptionistwwds_7_tfreceptionistemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail = ( :AV60Trn_receptionistwwds_7_tfreceptionistemail_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_receptionistwwds_7_tfreceptionistemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_receptionistwwds_8_tfreceptionistphone)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone like :lV61Trn_receptionistwwds_8_tfreceptionistphone)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ! ( StringUtil.StrCmp(AV62Trn_receptionistwwds_9_tfreceptionistphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone = ( :AV62Trn_receptionistwwds_9_tfreceptionistphone_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_receptionistwwds_9_tfreceptionistphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistPhone))=0))");
         }
         if ( AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = TRUE)");
         }
         if ( AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ReceptionistGivenName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006M3( IGxContext context ,
                                             string AV54Trn_receptionistwwds_1_filterfulltext ,
                                             string AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                             string AV55Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                             string AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                             string AV57Trn_receptionistwwds_4_tfreceptionistlastname ,
                                             string AV60Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                             string AV59Trn_receptionistwwds_6_tfreceptionistemail ,
                                             string AV62Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                             string AV61Trn_receptionistwwds_8_tfreceptionistphone ,
                                             short AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                             string A90ReceptionistGivenName ,
                                             string A91ReceptionistLastName ,
                                             string A93ReceptionistEmail ,
                                             string A94ReceptionistPhone ,
                                             bool A398ReceptionistIsActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT ReceptionistLastName, ReceptionistIsActive, ReceptionistPhone, ReceptionistEmail, ReceptionistGivenName, ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ReceptionistGivenName like '%' || :lV54Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistLastName like '%' || :lV54Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistEmail like '%' || :lV54Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistPhone like '%' || :lV54Trn_receptionistwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_receptionistwwds_2_tfreceptionistgivenname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName like :lV55Trn_receptionistwwds_2_tfreceptionistgivenname)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ! ( StringUtil.StrCmp(AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName = ( :AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_receptionistwwds_4_tfreceptionistlastname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName like :lV57Trn_receptionistwwds_4_tfreceptionistlastname)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ! ( StringUtil.StrCmp(AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName = ( :AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_receptionistwwds_6_tfreceptionistemail)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail like :lV59Trn_receptionistwwds_6_tfreceptionistemail)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ! ( StringUtil.StrCmp(AV60Trn_receptionistwwds_7_tfreceptionistemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail = ( :AV60Trn_receptionistwwds_7_tfreceptionistemail_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_receptionistwwds_7_tfreceptionistemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_receptionistwwds_8_tfreceptionistphone)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone like :lV61Trn_receptionistwwds_8_tfreceptionistphone)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ! ( StringUtil.StrCmp(AV62Trn_receptionistwwds_9_tfreceptionistphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone = ( :AV62Trn_receptionistwwds_9_tfreceptionistphone_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_receptionistwwds_9_tfreceptionistphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistPhone))=0))");
         }
         if ( AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = TRUE)");
         }
         if ( AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ReceptionistLastName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006M4( IGxContext context ,
                                             string AV54Trn_receptionistwwds_1_filterfulltext ,
                                             string AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                             string AV55Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                             string AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                             string AV57Trn_receptionistwwds_4_tfreceptionistlastname ,
                                             string AV60Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                             string AV59Trn_receptionistwwds_6_tfreceptionistemail ,
                                             string AV62Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                             string AV61Trn_receptionistwwds_8_tfreceptionistphone ,
                                             short AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                             string A90ReceptionistGivenName ,
                                             string A91ReceptionistLastName ,
                                             string A93ReceptionistEmail ,
                                             string A94ReceptionistPhone ,
                                             bool A398ReceptionistIsActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[12];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT ReceptionistEmail, ReceptionistIsActive, ReceptionistPhone, ReceptionistLastName, ReceptionistGivenName, ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ReceptionistGivenName like '%' || :lV54Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistLastName like '%' || :lV54Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistEmail like '%' || :lV54Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistPhone like '%' || :lV54Trn_receptionistwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_receptionistwwds_2_tfreceptionistgivenname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName like :lV55Trn_receptionistwwds_2_tfreceptionistgivenname)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ! ( StringUtil.StrCmp(AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName = ( :AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_receptionistwwds_4_tfreceptionistlastname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName like :lV57Trn_receptionistwwds_4_tfreceptionistlastname)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ! ( StringUtil.StrCmp(AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName = ( :AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_receptionistwwds_6_tfreceptionistemail)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail like :lV59Trn_receptionistwwds_6_tfreceptionistemail)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ! ( StringUtil.StrCmp(AV60Trn_receptionistwwds_7_tfreceptionistemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail = ( :AV60Trn_receptionistwwds_7_tfreceptionistemail_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_receptionistwwds_7_tfreceptionistemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_receptionistwwds_8_tfreceptionistphone)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone like :lV61Trn_receptionistwwds_8_tfreceptionistphone)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ! ( StringUtil.StrCmp(AV62Trn_receptionistwwds_9_tfreceptionistphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone = ( :AV62Trn_receptionistwwds_9_tfreceptionistphone_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_receptionistwwds_9_tfreceptionistphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistPhone))=0))");
         }
         if ( AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = TRUE)");
         }
         if ( AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ReceptionistEmail";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P006M5( IGxContext context ,
                                             string AV54Trn_receptionistwwds_1_filterfulltext ,
                                             string AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                             string AV55Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                             string AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                             string AV57Trn_receptionistwwds_4_tfreceptionistlastname ,
                                             string AV60Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                             string AV59Trn_receptionistwwds_6_tfreceptionistemail ,
                                             string AV62Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                             string AV61Trn_receptionistwwds_8_tfreceptionistphone ,
                                             short AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                             string A90ReceptionistGivenName ,
                                             string A91ReceptionistLastName ,
                                             string A93ReceptionistEmail ,
                                             string A94ReceptionistPhone ,
                                             bool A398ReceptionistIsActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[12];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT ReceptionistPhone, ReceptionistIsActive, ReceptionistEmail, ReceptionistLastName, ReceptionistGivenName, ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_receptionistwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ReceptionistGivenName like '%' || :lV54Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistLastName like '%' || :lV54Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistEmail like '%' || :lV54Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistPhone like '%' || :lV54Trn_receptionistwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_receptionistwwds_2_tfreceptionistgivenname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName like :lV55Trn_receptionistwwds_2_tfreceptionistgivenname)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ! ( StringUtil.StrCmp(AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName = ( :AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_receptionistwwds_4_tfreceptionistlastname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName like :lV57Trn_receptionistwwds_4_tfreceptionistlastname)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ! ( StringUtil.StrCmp(AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName = ( :AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_receptionistwwds_6_tfreceptionistemail)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail like :lV59Trn_receptionistwwds_6_tfreceptionistemail)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ! ( StringUtil.StrCmp(AV60Trn_receptionistwwds_7_tfreceptionistemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail = ( :AV60Trn_receptionistwwds_7_tfreceptionistemail_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_receptionistwwds_7_tfreceptionistemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_receptionistwwds_8_tfreceptionistphone)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone like :lV61Trn_receptionistwwds_8_tfreceptionistphone)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ! ( StringUtil.StrCmp(AV62Trn_receptionistwwds_9_tfreceptionistphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone = ( :AV62Trn_receptionistwwds_9_tfreceptionistphone_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_receptionistwwds_9_tfreceptionistphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistPhone))=0))");
         }
         if ( AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = TRUE)");
         }
         if ( AV63Trn_receptionistwwds_10_tfreceptionistisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ReceptionistPhone";
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
                     return conditional_P006M2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] );
               case 1 :
                     return conditional_P006M3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] );
               case 2 :
                     return conditional_P006M4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] );
               case 3 :
                     return conditional_P006M5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmP006M2;
          prmP006M2 = new Object[] {
          new ParDef("lV54Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Trn_receptionistwwds_2_tfreceptionistgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_receptionistwwds_4_tfreceptionistlastname",GXType.VarChar,100,0) ,
          new ParDef("AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Trn_receptionistwwds_6_tfreceptionistemail",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_receptionistwwds_7_tfreceptionistemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_receptionistwwds_8_tfreceptionistphone",GXType.Char,20,0) ,
          new ParDef("AV62Trn_receptionistwwds_9_tfreceptionistphone_sel",GXType.Char,20,0)
          };
          Object[] prmP006M3;
          prmP006M3 = new Object[] {
          new ParDef("lV54Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Trn_receptionistwwds_2_tfreceptionistgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_receptionistwwds_4_tfreceptionistlastname",GXType.VarChar,100,0) ,
          new ParDef("AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Trn_receptionistwwds_6_tfreceptionistemail",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_receptionistwwds_7_tfreceptionistemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_receptionistwwds_8_tfreceptionistphone",GXType.Char,20,0) ,
          new ParDef("AV62Trn_receptionistwwds_9_tfreceptionistphone_sel",GXType.Char,20,0)
          };
          Object[] prmP006M4;
          prmP006M4 = new Object[] {
          new ParDef("lV54Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Trn_receptionistwwds_2_tfreceptionistgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_receptionistwwds_4_tfreceptionistlastname",GXType.VarChar,100,0) ,
          new ParDef("AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Trn_receptionistwwds_6_tfreceptionistemail",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_receptionistwwds_7_tfreceptionistemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_receptionistwwds_8_tfreceptionistphone",GXType.Char,20,0) ,
          new ParDef("AV62Trn_receptionistwwds_9_tfreceptionistphone_sel",GXType.Char,20,0)
          };
          Object[] prmP006M5;
          prmP006M5 = new Object[] {
          new ParDef("lV54Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Trn_receptionistwwds_2_tfreceptionistgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV56Trn_receptionistwwds_3_tfreceptionistgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_receptionistwwds_4_tfreceptionistlastname",GXType.VarChar,100,0) ,
          new ParDef("AV58Trn_receptionistwwds_5_tfreceptionistlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Trn_receptionistwwds_6_tfreceptionistemail",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_receptionistwwds_7_tfreceptionistemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_receptionistwwds_8_tfreceptionistphone",GXType.Char,20,0) ,
          new ParDef("AV62Trn_receptionistwwds_9_tfreceptionistphone_sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006M2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006M3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006M3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006M4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006M4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006M5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006M5,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                ((Guid[]) buf[7])[0] = rslt.getGuid(8);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                ((Guid[]) buf[7])[0] = rslt.getGuid(8);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                ((Guid[]) buf[7])[0] = rslt.getGuid(8);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                ((Guid[]) buf[7])[0] = rslt.getGuid(8);
                return;
       }
    }

 }

}
