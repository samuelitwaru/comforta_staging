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
   public class trn_pageloaddvcombo : GXProcedure
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
            return "trn_page_Services_Execute" ;
         }

      }

      public trn_pageloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_pageloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           Guid aP3_Trn_PageId ,
                           string aP4_Trn_PageName ,
                           Guid aP5_LocationId ,
                           Guid aP6_Cond_OrganisationId ,
                           Guid aP7_Cond_LocationId ,
                           string aP8_SearchTxtParms ,
                           out string aP9_SelectedValue ,
                           out string aP10_SelectedText ,
                           out string aP11_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20Trn_PageId = aP3_Trn_PageId;
         this.AV21Trn_PageName = aP4_Trn_PageName;
         this.AV22LocationId = aP5_LocationId;
         this.AV32Cond_OrganisationId = aP6_Cond_OrganisationId;
         this.AV33Cond_LocationId = aP7_Cond_LocationId;
         this.AV23SearchTxtParms = aP8_SearchTxtParms;
         this.AV24SelectedValue = "" ;
         this.AV25SelectedText = "" ;
         this.AV26Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP9_SelectedValue=this.AV24SelectedValue;
         aP10_SelectedText=this.AV25SelectedText;
         aP11_Combo_DataJson=this.AV26Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                Guid aP3_Trn_PageId ,
                                string aP4_Trn_PageName ,
                                Guid aP5_LocationId ,
                                Guid aP6_Cond_OrganisationId ,
                                Guid aP7_Cond_LocationId ,
                                string aP8_SearchTxtParms ,
                                out string aP9_SelectedValue ,
                                out string aP10_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_Trn_PageId, aP4_Trn_PageName, aP5_LocationId, aP6_Cond_OrganisationId, aP7_Cond_LocationId, aP8_SearchTxtParms, out aP9_SelectedValue, out aP10_SelectedText, out aP11_Combo_DataJson);
         return AV26Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_Trn_PageId ,
                                 string aP4_Trn_PageName ,
                                 Guid aP5_LocationId ,
                                 Guid aP6_Cond_OrganisationId ,
                                 Guid aP7_Cond_LocationId ,
                                 string aP8_SearchTxtParms ,
                                 out string aP9_SelectedValue ,
                                 out string aP10_SelectedText ,
                                 out string aP11_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20Trn_PageId = aP3_Trn_PageId;
         this.AV21Trn_PageName = aP4_Trn_PageName;
         this.AV22LocationId = aP5_LocationId;
         this.AV32Cond_OrganisationId = aP6_Cond_OrganisationId;
         this.AV33Cond_LocationId = aP7_Cond_LocationId;
         this.AV23SearchTxtParms = aP8_SearchTxtParms;
         this.AV24SelectedValue = "" ;
         this.AV25SelectedText = "" ;
         this.AV26Combo_DataJson = "" ;
         SubmitImpl();
         aP9_SelectedValue=this.AV24SelectedValue;
         aP10_SelectedText=this.AV25SelectedText;
         aP11_Combo_DataJson=this.AV26Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11MaxItems = 10;
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV23SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV23SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV23SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? AV23SearchTxtParms : StringUtil.Substring( AV23SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV17ComboName, "LocationId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_LOCATIONID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "ProductServiceId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PRODUCTSERVICEID' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "OrganisationId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_ORGANISATIONID' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_LOCATIONID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom2 = AV12SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A31LocationName ,
                                                 A11OrganisationId ,
                                                 AV32Cond_OrganisationId } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P009Q2 */
            pr_default.execute(0, new Object[] {AV32Cond_OrganisationId, lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A11OrganisationId = P009Q2_A11OrganisationId[0];
               A31LocationName = P009Q2_A31LocationName[0];
               A29LocationId = P009Q2_A29LocationId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A29LocationId.ToString());
               AV16Combo_DataItem.gxTpr_Title = A31LocationName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV26Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               /* Using cursor P009Q3 */
               pr_default.execute(1, new Object[] {AV20Trn_PageId, AV21Trn_PageName, AV22LocationId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A11OrganisationId = P009Q3_A11OrganisationId[0];
                  A29LocationId = P009Q3_A29LocationId[0];
                  A318Trn_PageName = P009Q3_A318Trn_PageName[0];
                  A310Trn_PageId = P009Q3_A310Trn_PageId[0];
                  A31LocationName = P009Q3_A31LocationName[0];
                  A31LocationName = P009Q3_A31LocationName[0];
                  AV24SelectedValue = ((Guid.Empty==A29LocationId) ? "" : StringUtil.Trim( A29LocationId.ToString()));
                  AV25SelectedText = A31LocationName;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
            }
            else
            {
               if ( ! (Guid.Empty==AV22LocationId) )
               {
                  AV24SelectedValue = StringUtil.Trim( AV22LocationId.ToString());
                  /* Using cursor P009Q4 */
                  pr_default.execute(2, new Object[] {AV22LocationId, AV32Cond_OrganisationId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A11OrganisationId = P009Q4_A11OrganisationId[0];
                     A29LocationId = P009Q4_A29LocationId[0];
                     A31LocationName = P009Q4_A31LocationName[0];
                     AV25SelectedText = A31LocationName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_PRODUCTSERVICEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom5 = AV12SkipItems;
            GXPagingTo5 = AV11MaxItems;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A59ProductServiceName ,
                                                 A29LocationId ,
                                                 AV33Cond_LocationId ,
                                                 A11OrganisationId ,
                                                 AV32Cond_OrganisationId } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P009Q5 */
            pr_default.execute(3, new Object[] {AV33Cond_LocationId, AV32Cond_OrganisationId, lV14SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A29LocationId = P009Q5_A29LocationId[0];
               A11OrganisationId = P009Q5_A11OrganisationId[0];
               A59ProductServiceName = P009Q5_A59ProductServiceName[0];
               A58ProductServiceId = P009Q5_A58ProductServiceId[0];
               n58ProductServiceId = P009Q5_n58ProductServiceId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A58ProductServiceId.ToString());
               AV16Combo_DataItem.gxTpr_Title = A59ProductServiceName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV26Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P009Q6 */
                  pr_default.execute(4, new Object[] {AV20Trn_PageId, AV21Trn_PageName, AV22LocationId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A11OrganisationId = P009Q6_A11OrganisationId[0];
                     A29LocationId = P009Q6_A29LocationId[0];
                     A318Trn_PageName = P009Q6_A318Trn_PageName[0];
                     A310Trn_PageId = P009Q6_A310Trn_PageId[0];
                     A58ProductServiceId = P009Q6_A58ProductServiceId[0];
                     n58ProductServiceId = P009Q6_n58ProductServiceId[0];
                     A59ProductServiceName = P009Q6_A59ProductServiceName[0];
                     A59ProductServiceName = P009Q6_A59ProductServiceName[0];
                     AV24SelectedValue = ((Guid.Empty==A58ProductServiceId) ? "" : StringUtil.Trim( A58ProductServiceId.ToString()));
                     AV25SelectedText = A59ProductServiceName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV30ProductServiceId = StringUtil.StrToGuid( AV14SearchTxt);
                  /* Using cursor P009Q7 */
                  pr_default.execute(5, new Object[] {AV30ProductServiceId, AV33Cond_LocationId, AV32Cond_OrganisationId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A11OrganisationId = P009Q7_A11OrganisationId[0];
                     A29LocationId = P009Q7_A29LocationId[0];
                     A58ProductServiceId = P009Q7_A58ProductServiceId[0];
                     n58ProductServiceId = P009Q7_n58ProductServiceId[0];
                     A59ProductServiceName = P009Q7_A59ProductServiceName[0];
                     AV25SelectedText = A59ProductServiceName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(5);
               }
            }
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_ORGANISATIONID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom8 = AV12SkipItems;
            GXPagingTo8 = AV11MaxItems;
            pr_default.dynParam(6, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A13OrganisationName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P009Q8 */
            pr_default.execute(6, new Object[] {lV14SearchTxt, GXPagingFrom8, GXPagingTo8, GXPagingTo8});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A13OrganisationName = P009Q8_A13OrganisationName[0];
               A11OrganisationId = P009Q8_A11OrganisationId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A11OrganisationId.ToString());
               AV16Combo_DataItem.gxTpr_Title = A13OrganisationName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(6);
            }
            pr_default.close(6);
            AV26Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P009Q9 */
                  pr_default.execute(7, new Object[] {AV20Trn_PageId, AV21Trn_PageName, AV22LocationId});
                  while ( (pr_default.getStatus(7) != 101) )
                  {
                     A29LocationId = P009Q9_A29LocationId[0];
                     A318Trn_PageName = P009Q9_A318Trn_PageName[0];
                     A310Trn_PageId = P009Q9_A310Trn_PageId[0];
                     A11OrganisationId = P009Q9_A11OrganisationId[0];
                     A13OrganisationName = P009Q9_A13OrganisationName[0];
                     A13OrganisationName = P009Q9_A13OrganisationName[0];
                     AV24SelectedValue = ((Guid.Empty==A11OrganisationId) ? "" : StringUtil.Trim( A11OrganisationId.ToString()));
                     AV25SelectedText = A13OrganisationName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(7);
               }
               else
               {
                  AV31OrganisationId = StringUtil.StrToGuid( AV14SearchTxt);
                  /* Using cursor P009Q10 */
                  pr_default.execute(8, new Object[] {AV31OrganisationId});
                  while ( (pr_default.getStatus(8) != 101) )
                  {
                     A11OrganisationId = P009Q10_A11OrganisationId[0];
                     A13OrganisationName = P009Q10_A13OrganisationName[0];
                     AV25SelectedText = A13OrganisationName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(8);
               }
            }
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
         AV24SelectedValue = "";
         AV25SelectedText = "";
         AV26Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         lV14SearchTxt = "";
         A31LocationName = "";
         A11OrganisationId = Guid.Empty;
         P009Q2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009Q2_A31LocationName = new string[] {""} ;
         P009Q2_A29LocationId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P009Q3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009Q3_A29LocationId = new Guid[] {Guid.Empty} ;
         P009Q3_A318Trn_PageName = new string[] {""} ;
         P009Q3_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P009Q3_A31LocationName = new string[] {""} ;
         A318Trn_PageName = "";
         A310Trn_PageId = Guid.Empty;
         P009Q4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009Q4_A29LocationId = new Guid[] {Guid.Empty} ;
         P009Q4_A31LocationName = new string[] {""} ;
         A59ProductServiceName = "";
         P009Q5_A29LocationId = new Guid[] {Guid.Empty} ;
         P009Q5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009Q5_A59ProductServiceName = new string[] {""} ;
         P009Q5_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P009Q5_n58ProductServiceId = new bool[] {false} ;
         A58ProductServiceId = Guid.Empty;
         P009Q6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009Q6_A29LocationId = new Guid[] {Guid.Empty} ;
         P009Q6_A318Trn_PageName = new string[] {""} ;
         P009Q6_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P009Q6_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P009Q6_n58ProductServiceId = new bool[] {false} ;
         P009Q6_A59ProductServiceName = new string[] {""} ;
         AV30ProductServiceId = Guid.Empty;
         P009Q7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009Q7_A29LocationId = new Guid[] {Guid.Empty} ;
         P009Q7_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P009Q7_n58ProductServiceId = new bool[] {false} ;
         P009Q7_A59ProductServiceName = new string[] {""} ;
         A13OrganisationName = "";
         P009Q8_A13OrganisationName = new string[] {""} ;
         P009Q8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009Q9_A29LocationId = new Guid[] {Guid.Empty} ;
         P009Q9_A318Trn_PageName = new string[] {""} ;
         P009Q9_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P009Q9_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009Q9_A13OrganisationName = new string[] {""} ;
         AV31OrganisationId = Guid.Empty;
         P009Q10_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009Q10_A13OrganisationName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_pageloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P009Q2_A11OrganisationId, P009Q2_A31LocationName, P009Q2_A29LocationId
               }
               , new Object[] {
               P009Q3_A11OrganisationId, P009Q3_A29LocationId, P009Q3_A318Trn_PageName, P009Q3_A310Trn_PageId, P009Q3_A31LocationName
               }
               , new Object[] {
               P009Q4_A11OrganisationId, P009Q4_A29LocationId, P009Q4_A31LocationName
               }
               , new Object[] {
               P009Q5_A29LocationId, P009Q5_A11OrganisationId, P009Q5_A59ProductServiceName, P009Q5_A58ProductServiceId
               }
               , new Object[] {
               P009Q6_A11OrganisationId, P009Q6_A29LocationId, P009Q6_A318Trn_PageName, P009Q6_A310Trn_PageId, P009Q6_A58ProductServiceId, P009Q6_n58ProductServiceId, P009Q6_A59ProductServiceName
               }
               , new Object[] {
               P009Q7_A11OrganisationId, P009Q7_A29LocationId, P009Q7_A58ProductServiceId, P009Q7_A59ProductServiceName
               }
               , new Object[] {
               P009Q8_A13OrganisationName, P009Q8_A11OrganisationId
               }
               , new Object[] {
               P009Q9_A29LocationId, P009Q9_A318Trn_PageName, P009Q9_A310Trn_PageId, P009Q9_A11OrganisationId, P009Q9_A13OrganisationName
               }
               , new Object[] {
               P009Q10_A11OrganisationId, P009Q10_A13OrganisationName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private int GXPagingFrom8 ;
      private int GXPagingTo8 ;
      private string AV18TrnMode ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private bool n58ProductServiceId ;
      private string AV26Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21Trn_PageName ;
      private string AV23SearchTxtParms ;
      private string AV24SelectedValue ;
      private string AV25SelectedText ;
      private string AV14SearchTxt ;
      private string lV14SearchTxt ;
      private string A31LocationName ;
      private string A318Trn_PageName ;
      private string A59ProductServiceName ;
      private string A13OrganisationName ;
      private Guid AV20Trn_PageId ;
      private Guid AV22LocationId ;
      private Guid AV32Cond_OrganisationId ;
      private Guid AV33Cond_LocationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A310Trn_PageId ;
      private Guid A58ProductServiceId ;
      private Guid AV30ProductServiceId ;
      private Guid AV31OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] P009Q2_A11OrganisationId ;
      private string[] P009Q2_A31LocationName ;
      private Guid[] P009Q2_A29LocationId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private Guid[] P009Q3_A11OrganisationId ;
      private Guid[] P009Q3_A29LocationId ;
      private string[] P009Q3_A318Trn_PageName ;
      private Guid[] P009Q3_A310Trn_PageId ;
      private string[] P009Q3_A31LocationName ;
      private Guid[] P009Q4_A11OrganisationId ;
      private Guid[] P009Q4_A29LocationId ;
      private string[] P009Q4_A31LocationName ;
      private Guid[] P009Q5_A29LocationId ;
      private Guid[] P009Q5_A11OrganisationId ;
      private string[] P009Q5_A59ProductServiceName ;
      private Guid[] P009Q5_A58ProductServiceId ;
      private bool[] P009Q5_n58ProductServiceId ;
      private Guid[] P009Q6_A11OrganisationId ;
      private Guid[] P009Q6_A29LocationId ;
      private string[] P009Q6_A318Trn_PageName ;
      private Guid[] P009Q6_A310Trn_PageId ;
      private Guid[] P009Q6_A58ProductServiceId ;
      private bool[] P009Q6_n58ProductServiceId ;
      private string[] P009Q6_A59ProductServiceName ;
      private Guid[] P009Q7_A11OrganisationId ;
      private Guid[] P009Q7_A29LocationId ;
      private Guid[] P009Q7_A58ProductServiceId ;
      private bool[] P009Q7_n58ProductServiceId ;
      private string[] P009Q7_A59ProductServiceName ;
      private string[] P009Q8_A13OrganisationName ;
      private Guid[] P009Q8_A11OrganisationId ;
      private Guid[] P009Q9_A29LocationId ;
      private string[] P009Q9_A318Trn_PageName ;
      private Guid[] P009Q9_A310Trn_PageId ;
      private Guid[] P009Q9_A11OrganisationId ;
      private string[] P009Q9_A13OrganisationName ;
      private Guid[] P009Q10_A11OrganisationId ;
      private string[] P009Q10_A13OrganisationName ;
      private string aP9_SelectedValue ;
      private string aP10_SelectedText ;
      private string aP11_Combo_DataJson ;
   }

   public class trn_pageloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009Q2( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A31LocationName ,
                                             Guid A11OrganisationId ,
                                             Guid AV32Cond_OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " OrganisationId, LocationName, LocationId";
         sFromString = " FROM Trn_Location";
         sOrderString = "";
         AddWhere(sWhereString, "(OrganisationId = :AV32Cond_OrganisationId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(LocationName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         sOrderString += " ORDER BY LocationName, LocationId, OrganisationId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P009Q5( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A59ProductServiceName ,
                                             Guid A29LocationId ,
                                             Guid AV33Cond_LocationId ,
                                             Guid A11OrganisationId ,
                                             Guid AV32Cond_OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " LocationId, OrganisationId, ProductServiceName, ProductServiceId";
         sFromString = " FROM Trn_ProductService";
         sOrderString = "";
         AddWhere(sWhereString, "(LocationId = :AV33Cond_LocationId)");
         AddWhere(sWhereString, "(OrganisationId = :AV32Cond_OrganisationId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(ProductServiceName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         sOrderString += " ORDER BY ProductServiceName, ProductServiceId, LocationId, OrganisationId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom5" + " LIMIT CASE WHEN " + ":GXPagingTo5" + " > 0 THEN " + ":GXPagingTo5" + " ELSE 1e9 END";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P009Q8( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A13OrganisationName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[4];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " OrganisationName, OrganisationId";
         sFromString = " FROM Trn_Organisation";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(OrganisationName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         sOrderString += " ORDER BY OrganisationName, OrganisationId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom8" + " LIMIT CASE WHEN " + ":GXPagingTo8" + " > 0 THEN " + ":GXPagingTo8" + " ELSE 1e9 END";
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
                     return conditional_P009Q2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
               case 3 :
                     return conditional_P009Q5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] , (Guid)dynConstraints[4] , (Guid)dynConstraints[5] );
               case 6 :
                     return conditional_P009Q8(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009Q3;
          prmP009Q3 = new Object[] {
          new ParDef("AV20Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21Trn_PageName",GXType.VarChar,100,0) ,
          new ParDef("AV22LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP009Q4;
          prmP009Q4 = new Object[] {
          new ParDef("AV22LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV32Cond_OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP009Q6;
          prmP009Q6 = new Object[] {
          new ParDef("AV20Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21Trn_PageName",GXType.VarChar,100,0) ,
          new ParDef("AV22LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP009Q7;
          prmP009Q7 = new Object[] {
          new ParDef("AV30ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV33Cond_LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV32Cond_OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP009Q9;
          prmP009Q9 = new Object[] {
          new ParDef("AV20Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21Trn_PageName",GXType.VarChar,100,0) ,
          new ParDef("AV22LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP009Q10;
          prmP009Q10 = new Object[] {
          new ParDef("AV31OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP009Q2;
          prmP009Q2 = new Object[] {
          new ParDef("AV32Cond_OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP009Q5;
          prmP009Q5 = new Object[] {
          new ParDef("AV33Cond_LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV32Cond_OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          Object[] prmP009Q8;
          prmP009Q8 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom8",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo8",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo8",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Q2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009Q3", "SELECT T1.OrganisationId, T1.LocationId, T1.Trn_PageName, T1.Trn_PageId, T2.LocationName FROM (Trn_Page T1 INNER JOIN Trn_Location T2 ON T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) WHERE T1.Trn_PageId = :AV20Trn_PageId and T1.Trn_PageName = ( :AV21Trn_PageName) and T1.LocationId = :AV22LocationId ORDER BY T1.Trn_PageId, T1.Trn_PageName, T1.LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Q3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009Q4", "SELECT OrganisationId, LocationId, LocationName FROM Trn_Location WHERE LocationId = :AV22LocationId and OrganisationId = :AV32Cond_OrganisationId ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Q4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009Q5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Q5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009Q6", "SELECT T1.OrganisationId, T1.LocationId, T1.Trn_PageName, T1.Trn_PageId, T1.ProductServiceId, T2.ProductServiceName FROM (Trn_Page T1 LEFT JOIN Trn_ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId AND T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) WHERE T1.Trn_PageId = :AV20Trn_PageId and T1.Trn_PageName = ( :AV21Trn_PageName) and T1.LocationId = :AV22LocationId ORDER BY T1.Trn_PageId, T1.Trn_PageName, T1.LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Q6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009Q7", "SELECT OrganisationId, LocationId, ProductServiceId, ProductServiceName FROM Trn_ProductService WHERE ProductServiceId = :AV30ProductServiceId and LocationId = :AV33Cond_LocationId and OrganisationId = :AV32Cond_OrganisationId ORDER BY ProductServiceId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Q7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009Q8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Q8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009Q9", "SELECT T1.LocationId, T1.Trn_PageName, T1.Trn_PageId, T1.OrganisationId, T2.OrganisationName FROM (Trn_Page T1 INNER JOIN Trn_Organisation T2 ON T2.OrganisationId = T1.OrganisationId) WHERE T1.Trn_PageId = :AV20Trn_PageId and T1.Trn_PageName = ( :AV21Trn_PageName) and T1.LocationId = :AV22LocationId ORDER BY T1.Trn_PageId, T1.Trn_PageName, T1.LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Q9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009Q10", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation WHERE OrganisationId = :AV31OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Q10,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 7 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 8 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
