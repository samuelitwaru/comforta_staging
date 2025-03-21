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
   public class trn_organisationtrn_locationwcgetfilterdata : GXProcedure
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
            return "trn_organisationview_Services_Execute" ;
         }

      }

      public trn_organisationtrn_locationwcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_organisationtrn_locationwcgetfilterdata( IGxContext context )
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
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV38OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV23Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV20MaxItems = 10;
         AV19PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV34SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV17SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? "" : StringUtil.Substring( AV34SearchTxtParms, 3, -1));
         AV18SkipItems = (short)(AV19PageIndex*AV20MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_LOCATIONNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADLOCATIONNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_LOCATIONEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADLOCATIONEMAILOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_LOCATIONPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADLOCATIONPHONEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV36OptionsJson = AV23Options.ToJSonString(false);
         AV37OptionsDescJson = AV25OptionsDesc.ToJSonString(false);
         AV38OptionIndexesJson = AV26OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("Trn_OrganisationTrn_LocationWCGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Trn_OrganisationTrn_LocationWCGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("Trn_OrganisationTrn_LocationWCGridState"), null, "", "");
         }
         AV41GXV1 = 1;
         while ( AV41GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV41GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLOCATIONNAME") == 0 )
            {
               AV11TFLocationName = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLOCATIONNAME_SEL") == 0 )
            {
               AV12TFLocationName_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLOCATIONEMAIL") == 0 )
            {
               AV15TFLocationEmail = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLOCATIONEMAIL_SEL") == 0 )
            {
               AV16TFLocationEmail_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLOCATIONPHONE") == 0 )
            {
               AV13TFLocationPhone = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLOCATIONPHONE_SEL") == 0 )
            {
               AV14TFLocationPhone_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "PARM_&ORGANISATIONID") == 0 )
            {
               AV40OrganisationId = StringUtil.StrToGuid( AV31GridStateFilterValue.gxTpr_Value);
            }
            AV41GXV1 = (int)(AV41GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADLOCATIONNAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFLocationName = AV17SearchTxt;
         AV12TFLocationName_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV39FilterFullText ,
                                              AV12TFLocationName_Sel ,
                                              AV11TFLocationName ,
                                              AV16TFLocationEmail_Sel ,
                                              AV15TFLocationEmail ,
                                              AV14TFLocationPhone_Sel ,
                                              AV13TFLocationPhone ,
                                              A31LocationName ,
                                              A34LocationEmail ,
                                              A35LocationPhone ,
                                              AV40OrganisationId ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              }
         });
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV11TFLocationName = StringUtil.Concat( StringUtil.RTrim( AV11TFLocationName), "%", "");
         lV15TFLocationEmail = StringUtil.Concat( StringUtil.RTrim( AV15TFLocationEmail), "%", "");
         lV13TFLocationPhone = StringUtil.PadR( StringUtil.RTrim( AV13TFLocationPhone), 20, "%");
         /* Using cursor P00DG2 */
         pr_default.execute(0, new Object[] {AV40OrganisationId, lV39FilterFullText, lV39FilterFullText, lV39FilterFullText, lV11TFLocationName, AV12TFLocationName_Sel, lV15TFLocationEmail, AV16TFLocationEmail_Sel, lV13TFLocationPhone, AV14TFLocationPhone_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKDG2 = false;
            A11OrganisationId = P00DG2_A11OrganisationId[0];
            A31LocationName = P00DG2_A31LocationName[0];
            A35LocationPhone = P00DG2_A35LocationPhone[0];
            A34LocationEmail = P00DG2_A34LocationEmail[0];
            A29LocationId = P00DG2_A29LocationId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00DG2_A11OrganisationId[0] == A11OrganisationId ) && ( StringUtil.StrCmp(P00DG2_A31LocationName[0], A31LocationName) == 0 ) )
            {
               BRKDG2 = false;
               A29LocationId = P00DG2_A29LocationId[0];
               AV27count = (long)(AV27count+1);
               BRKDG2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A31LocationName)) ? "<#Empty#>" : A31LocationName);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRKDG2 )
            {
               BRKDG2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADLOCATIONEMAILOPTIONS' Routine */
         returnInSub = false;
         AV15TFLocationEmail = AV17SearchTxt;
         AV16TFLocationEmail_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV39FilterFullText ,
                                              AV12TFLocationName_Sel ,
                                              AV11TFLocationName ,
                                              AV16TFLocationEmail_Sel ,
                                              AV15TFLocationEmail ,
                                              AV14TFLocationPhone_Sel ,
                                              AV13TFLocationPhone ,
                                              A31LocationName ,
                                              A34LocationEmail ,
                                              A35LocationPhone ,
                                              AV40OrganisationId ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              }
         });
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV11TFLocationName = StringUtil.Concat( StringUtil.RTrim( AV11TFLocationName), "%", "");
         lV15TFLocationEmail = StringUtil.Concat( StringUtil.RTrim( AV15TFLocationEmail), "%", "");
         lV13TFLocationPhone = StringUtil.PadR( StringUtil.RTrim( AV13TFLocationPhone), 20, "%");
         /* Using cursor P00DG3 */
         pr_default.execute(1, new Object[] {AV40OrganisationId, lV39FilterFullText, lV39FilterFullText, lV39FilterFullText, lV11TFLocationName, AV12TFLocationName_Sel, lV15TFLocationEmail, AV16TFLocationEmail_Sel, lV13TFLocationPhone, AV14TFLocationPhone_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKDG4 = false;
            A11OrganisationId = P00DG3_A11OrganisationId[0];
            A34LocationEmail = P00DG3_A34LocationEmail[0];
            A35LocationPhone = P00DG3_A35LocationPhone[0];
            A31LocationName = P00DG3_A31LocationName[0];
            A29LocationId = P00DG3_A29LocationId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00DG3_A11OrganisationId[0] == A11OrganisationId ) && ( StringUtil.StrCmp(P00DG3_A34LocationEmail[0], A34LocationEmail) == 0 ) )
            {
               BRKDG4 = false;
               A29LocationId = P00DG3_A29LocationId[0];
               AV27count = (long)(AV27count+1);
               BRKDG4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A34LocationEmail)) ? "<#Empty#>" : A34LocationEmail);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRKDG4 )
            {
               BRKDG4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADLOCATIONPHONEOPTIONS' Routine */
         returnInSub = false;
         AV13TFLocationPhone = AV17SearchTxt;
         AV14TFLocationPhone_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV39FilterFullText ,
                                              AV12TFLocationName_Sel ,
                                              AV11TFLocationName ,
                                              AV16TFLocationEmail_Sel ,
                                              AV15TFLocationEmail ,
                                              AV14TFLocationPhone_Sel ,
                                              AV13TFLocationPhone ,
                                              A31LocationName ,
                                              A34LocationEmail ,
                                              A35LocationPhone ,
                                              AV40OrganisationId ,
                                              A11OrganisationId } ,
                                              new int[]{
                                              }
         });
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV11TFLocationName = StringUtil.Concat( StringUtil.RTrim( AV11TFLocationName), "%", "");
         lV15TFLocationEmail = StringUtil.Concat( StringUtil.RTrim( AV15TFLocationEmail), "%", "");
         lV13TFLocationPhone = StringUtil.PadR( StringUtil.RTrim( AV13TFLocationPhone), 20, "%");
         /* Using cursor P00DG4 */
         pr_default.execute(2, new Object[] {AV40OrganisationId, lV39FilterFullText, lV39FilterFullText, lV39FilterFullText, lV11TFLocationName, AV12TFLocationName_Sel, lV15TFLocationEmail, AV16TFLocationEmail_Sel, lV13TFLocationPhone, AV14TFLocationPhone_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKDG6 = false;
            A11OrganisationId = P00DG4_A11OrganisationId[0];
            A35LocationPhone = P00DG4_A35LocationPhone[0];
            A34LocationEmail = P00DG4_A34LocationEmail[0];
            A31LocationName = P00DG4_A31LocationName[0];
            A29LocationId = P00DG4_A29LocationId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00DG4_A11OrganisationId[0] == A11OrganisationId ) && ( StringUtil.StrCmp(P00DG4_A35LocationPhone[0], A35LocationPhone) == 0 ) )
            {
               BRKDG6 = false;
               A29LocationId = P00DG4_A29LocationId[0];
               AV27count = (long)(AV27count+1);
               BRKDG6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A35LocationPhone)) ? "<#Empty#>" : A35LocationPhone);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRKDG6 )
            {
               BRKDG6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV36OptionsJson = "";
         AV37OptionsDescJson = "";
         AV38OptionIndexesJson = "";
         AV23Options = new GxSimpleCollection<string>();
         AV25OptionsDesc = new GxSimpleCollection<string>();
         AV26OptionIndexes = new GxSimpleCollection<string>();
         AV17SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV28Session = context.GetSession();
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV39FilterFullText = "";
         AV11TFLocationName = "";
         AV12TFLocationName_Sel = "";
         AV15TFLocationEmail = "";
         AV16TFLocationEmail_Sel = "";
         AV13TFLocationPhone = "";
         AV14TFLocationPhone_Sel = "";
         AV40OrganisationId = Guid.Empty;
         lV39FilterFullText = "";
         lV11TFLocationName = "";
         lV15TFLocationEmail = "";
         lV13TFLocationPhone = "";
         A31LocationName = "";
         A34LocationEmail = "";
         A35LocationPhone = "";
         A11OrganisationId = Guid.Empty;
         P00DG2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DG2_A31LocationName = new string[] {""} ;
         P00DG2_A35LocationPhone = new string[] {""} ;
         P00DG2_A34LocationEmail = new string[] {""} ;
         P00DG2_A29LocationId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         AV22Option = "";
         P00DG3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DG3_A34LocationEmail = new string[] {""} ;
         P00DG3_A35LocationPhone = new string[] {""} ;
         P00DG3_A31LocationName = new string[] {""} ;
         P00DG3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DG4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DG4_A35LocationPhone = new string[] {""} ;
         P00DG4_A34LocationEmail = new string[] {""} ;
         P00DG4_A31LocationName = new string[] {""} ;
         P00DG4_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationtrn_locationwcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00DG2_A11OrganisationId, P00DG2_A31LocationName, P00DG2_A35LocationPhone, P00DG2_A34LocationEmail, P00DG2_A29LocationId
               }
               , new Object[] {
               P00DG3_A11OrganisationId, P00DG3_A34LocationEmail, P00DG3_A35LocationPhone, P00DG3_A31LocationName, P00DG3_A29LocationId
               }
               , new Object[] {
               P00DG4_A11OrganisationId, P00DG4_A35LocationPhone, P00DG4_A34LocationEmail, P00DG4_A31LocationName, P00DG4_A29LocationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private int AV41GXV1 ;
      private long AV27count ;
      private string AV13TFLocationPhone ;
      private string AV14TFLocationPhone_Sel ;
      private string lV13TFLocationPhone ;
      private string A35LocationPhone ;
      private bool returnInSub ;
      private bool BRKDG2 ;
      private bool BRKDG4 ;
      private bool BRKDG6 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV11TFLocationName ;
      private string AV12TFLocationName_Sel ;
      private string AV15TFLocationEmail ;
      private string AV16TFLocationEmail_Sel ;
      private string lV39FilterFullText ;
      private string lV11TFLocationName ;
      private string lV15TFLocationEmail ;
      private string A31LocationName ;
      private string A34LocationEmail ;
      private string AV22Option ;
      private Guid AV40OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV25OptionsDesc ;
      private GxSimpleCollection<string> AV26OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DG2_A11OrganisationId ;
      private string[] P00DG2_A31LocationName ;
      private string[] P00DG2_A35LocationPhone ;
      private string[] P00DG2_A34LocationEmail ;
      private Guid[] P00DG2_A29LocationId ;
      private Guid[] P00DG3_A11OrganisationId ;
      private string[] P00DG3_A34LocationEmail ;
      private string[] P00DG3_A35LocationPhone ;
      private string[] P00DG3_A31LocationName ;
      private Guid[] P00DG3_A29LocationId ;
      private Guid[] P00DG4_A11OrganisationId ;
      private string[] P00DG4_A35LocationPhone ;
      private string[] P00DG4_A34LocationEmail ;
      private string[] P00DG4_A31LocationName ;
      private Guid[] P00DG4_A29LocationId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_organisationtrn_locationwcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DG2( IGxContext context ,
                                             string AV39FilterFullText ,
                                             string AV12TFLocationName_Sel ,
                                             string AV11TFLocationName ,
                                             string AV16TFLocationEmail_Sel ,
                                             string AV15TFLocationEmail ,
                                             string AV14TFLocationPhone_Sel ,
                                             string AV13TFLocationPhone ,
                                             string A31LocationName ,
                                             string A34LocationEmail ,
                                             string A35LocationPhone ,
                                             Guid AV40OrganisationId ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT OrganisationId, LocationName, LocationPhone, LocationEmail, LocationId FROM Trn_Location";
         AddWhere(sWhereString, "(OrganisationId = :AV40OrganisationId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39FilterFullText)) )
         {
            AddWhere(sWhereString, "(( LOWER(LocationName) like '%' || LOWER(:lV39FilterFullText)) or ( LOWER(LocationEmail) like '%' || LOWER(:lV39FilterFullText)) or ( LOWER(LocationPhone) like '%' || LOWER(:lV39FilterFullText)))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFLocationName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFLocationName)) ) )
         {
            AddWhere(sWhereString, "(LocationName like :lV11TFLocationName)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFLocationName_Sel)) && ! ( StringUtil.StrCmp(AV12TFLocationName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LocationName = ( :AV12TFLocationName_Sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFLocationName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFLocationEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFLocationEmail)) ) )
         {
            AddWhere(sWhereString, "(LocationEmail like :lV15TFLocationEmail)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFLocationEmail_Sel)) && ! ( StringUtil.StrCmp(AV16TFLocationEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LocationEmail = ( :AV16TFLocationEmail_Sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFLocationEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFLocationPhone_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFLocationPhone)) ) )
         {
            AddWhere(sWhereString, "(LocationPhone like :lV13TFLocationPhone)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFLocationPhone_Sel)) && ! ( StringUtil.StrCmp(AV14TFLocationPhone_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LocationPhone = ( :AV14TFLocationPhone_Sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFLocationPhone_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationPhone))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY OrganisationId, LocationName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00DG3( IGxContext context ,
                                             string AV39FilterFullText ,
                                             string AV12TFLocationName_Sel ,
                                             string AV11TFLocationName ,
                                             string AV16TFLocationEmail_Sel ,
                                             string AV15TFLocationEmail ,
                                             string AV14TFLocationPhone_Sel ,
                                             string AV13TFLocationPhone ,
                                             string A31LocationName ,
                                             string A34LocationEmail ,
                                             string A35LocationPhone ,
                                             Guid AV40OrganisationId ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT OrganisationId, LocationEmail, LocationPhone, LocationName, LocationId FROM Trn_Location";
         AddWhere(sWhereString, "(OrganisationId = :AV40OrganisationId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39FilterFullText)) )
         {
            AddWhere(sWhereString, "(( LOWER(LocationName) like '%' || LOWER(:lV39FilterFullText)) or ( LOWER(LocationEmail) like '%' || LOWER(:lV39FilterFullText)) or ( LOWER(LocationPhone) like '%' || LOWER(:lV39FilterFullText)))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFLocationName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFLocationName)) ) )
         {
            AddWhere(sWhereString, "(LocationName like :lV11TFLocationName)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFLocationName_Sel)) && ! ( StringUtil.StrCmp(AV12TFLocationName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LocationName = ( :AV12TFLocationName_Sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFLocationName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFLocationEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFLocationEmail)) ) )
         {
            AddWhere(sWhereString, "(LocationEmail like :lV15TFLocationEmail)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFLocationEmail_Sel)) && ! ( StringUtil.StrCmp(AV16TFLocationEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LocationEmail = ( :AV16TFLocationEmail_Sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFLocationEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFLocationPhone_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFLocationPhone)) ) )
         {
            AddWhere(sWhereString, "(LocationPhone like :lV13TFLocationPhone)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFLocationPhone_Sel)) && ! ( StringUtil.StrCmp(AV14TFLocationPhone_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LocationPhone = ( :AV14TFLocationPhone_Sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFLocationPhone_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationPhone))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY OrganisationId, LocationEmail";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00DG4( IGxContext context ,
                                             string AV39FilterFullText ,
                                             string AV12TFLocationName_Sel ,
                                             string AV11TFLocationName ,
                                             string AV16TFLocationEmail_Sel ,
                                             string AV15TFLocationEmail ,
                                             string AV14TFLocationPhone_Sel ,
                                             string AV13TFLocationPhone ,
                                             string A31LocationName ,
                                             string A34LocationEmail ,
                                             string A35LocationPhone ,
                                             Guid AV40OrganisationId ,
                                             Guid A11OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[10];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT OrganisationId, LocationPhone, LocationEmail, LocationName, LocationId FROM Trn_Location";
         AddWhere(sWhereString, "(OrganisationId = :AV40OrganisationId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39FilterFullText)) )
         {
            AddWhere(sWhereString, "(( LOWER(LocationName) like '%' || LOWER(:lV39FilterFullText)) or ( LOWER(LocationEmail) like '%' || LOWER(:lV39FilterFullText)) or ( LOWER(LocationPhone) like '%' || LOWER(:lV39FilterFullText)))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFLocationName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFLocationName)) ) )
         {
            AddWhere(sWhereString, "(LocationName like :lV11TFLocationName)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFLocationName_Sel)) && ! ( StringUtil.StrCmp(AV12TFLocationName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LocationName = ( :AV12TFLocationName_Sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFLocationName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFLocationEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFLocationEmail)) ) )
         {
            AddWhere(sWhereString, "(LocationEmail like :lV15TFLocationEmail)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFLocationEmail_Sel)) && ! ( StringUtil.StrCmp(AV16TFLocationEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LocationEmail = ( :AV16TFLocationEmail_Sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFLocationEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFLocationPhone_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFLocationPhone)) ) )
         {
            AddWhere(sWhereString, "(LocationPhone like :lV13TFLocationPhone)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFLocationPhone_Sel)) && ! ( StringUtil.StrCmp(AV14TFLocationPhone_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LocationPhone = ( :AV14TFLocationPhone_Sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFLocationPhone_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LocationPhone))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY OrganisationId, LocationPhone";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00DG2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (Guid)dynConstraints[10] , (Guid)dynConstraints[11] );
               case 1 :
                     return conditional_P00DG3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (Guid)dynConstraints[10] , (Guid)dynConstraints[11] );
               case 2 :
                     return conditional_P00DG4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (Guid)dynConstraints[10] , (Guid)dynConstraints[11] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DG2;
          prmP00DG2 = new Object[] {
          new ParDef("AV40OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV11TFLocationName",GXType.VarChar,100,0) ,
          new ParDef("AV12TFLocationName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV15TFLocationEmail",GXType.VarChar,100,0) ,
          new ParDef("AV16TFLocationEmail_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV13TFLocationPhone",GXType.Char,20,0) ,
          new ParDef("AV14TFLocationPhone_Sel",GXType.Char,20,0)
          };
          Object[] prmP00DG3;
          prmP00DG3 = new Object[] {
          new ParDef("AV40OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV11TFLocationName",GXType.VarChar,100,0) ,
          new ParDef("AV12TFLocationName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV15TFLocationEmail",GXType.VarChar,100,0) ,
          new ParDef("AV16TFLocationEmail_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV13TFLocationPhone",GXType.Char,20,0) ,
          new ParDef("AV14TFLocationPhone_Sel",GXType.Char,20,0)
          };
          Object[] prmP00DG4;
          prmP00DG4 = new Object[] {
          new ParDef("AV40OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV11TFLocationName",GXType.VarChar,100,0) ,
          new ParDef("AV12TFLocationName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV15TFLocationEmail",GXType.VarChar,100,0) ,
          new ParDef("AV16TFLocationEmail_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV13TFLocationPhone",GXType.Char,20,0) ,
          new ParDef("AV14TFLocationPhone_Sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DG2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DG2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DG3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DG3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DG4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DG4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
