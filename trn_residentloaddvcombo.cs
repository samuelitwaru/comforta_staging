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
   public class trn_residentloaddvcombo : GXProcedure
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
            return "trn_resident_Services_Execute" ;
         }

      }

      public trn_residentloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_residentloaddvcombo( IGxContext context )
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
                           Guid aP3_ResidentId ,
                           Guid aP4_LocationId ,
                           Guid aP5_OrganisationId ,
                           string aP6_SearchTxtParms ,
                           out string aP7_SelectedValue ,
                           out string aP8_SelectedText ,
                           out string aP9_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20ResidentId = aP3_ResidentId;
         this.AV21LocationId = aP4_LocationId;
         this.AV22OrganisationId = aP5_OrganisationId;
         this.AV23SearchTxtParms = aP6_SearchTxtParms;
         this.AV24SelectedValue = "" ;
         this.AV25SelectedText = "" ;
         this.AV26Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP7_SelectedValue=this.AV24SelectedValue;
         aP8_SelectedText=this.AV25SelectedText;
         aP9_Combo_DataJson=this.AV26Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                Guid aP3_ResidentId ,
                                Guid aP4_LocationId ,
                                Guid aP5_OrganisationId ,
                                string aP6_SearchTxtParms ,
                                out string aP7_SelectedValue ,
                                out string aP8_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_ResidentId, aP4_LocationId, aP5_OrganisationId, aP6_SearchTxtParms, out aP7_SelectedValue, out aP8_SelectedText, out aP9_Combo_DataJson);
         return AV26Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_ResidentId ,
                                 Guid aP4_LocationId ,
                                 Guid aP5_OrganisationId ,
                                 string aP6_SearchTxtParms ,
                                 out string aP7_SelectedValue ,
                                 out string aP8_SelectedText ,
                                 out string aP9_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20ResidentId = aP3_ResidentId;
         this.AV21LocationId = aP4_LocationId;
         this.AV22OrganisationId = aP5_OrganisationId;
         this.AV23SearchTxtParms = aP6_SearchTxtParms;
         this.AV24SelectedValue = "" ;
         this.AV25SelectedText = "" ;
         this.AV26Combo_DataJson = "" ;
         SubmitImpl();
         aP7_SelectedValue=this.AV24SelectedValue;
         aP8_SelectedText=this.AV25SelectedText;
         aP9_Combo_DataJson=this.AV26Combo_DataJson;
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
         if ( StringUtil.StrCmp(AV17ComboName, "ResidentCountry") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RESIDENTCOUNTRY' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "ResidentTypeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RESIDENTTYPEID' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "ResidentHomePhoneCode") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RESIDENTHOMEPHONECODE' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "ResidentPhoneCode") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RESIDENTPHONECODE' */
            S141 ();
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
         /* 'LOADCOMBOITEMS_RESIDENTCOUNTRY' Routine */
         returnInSub = false;
         AV44GXV2 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV43GXV1;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV43GXV1 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV44GXV2 <= AV43GXV1.Count )
         {
            AV39ResidentCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV43GXV1.Item(AV44GXV2));
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV39ResidentCountry_DPItem.gxTpr_Countryname;
            AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV38ComboTitles.Add(AV39ResidentCountry_DPItem.gxTpr_Countryname, 0);
            AV38ComboTitles.Add(AV39ResidentCountry_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV38ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV44GXV2 = (int)(AV44GXV2+1);
         }
         AV15Combo_Data.Sort("Title");
         AV26Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P007A2 */
            pr_default.execute(0, new Object[] {AV20ResidentId, AV21LocationId, AV22OrganisationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A11OrganisationId = P007A2_A11OrganisationId[0];
               A29LocationId = P007A2_A29LocationId[0];
               A62ResidentId = P007A2_A62ResidentId[0];
               A354ResidentCountry = P007A2_A354ResidentCountry[0];
               AV24SelectedValue = A354ResidentCountry;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV46GXV3 = 1;
               while ( AV46GXV3 <= AV15Combo_Data.Count )
               {
                  AV16Combo_DataItem = ((GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item)AV15Combo_Data.Item(AV46GXV3));
                  if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV24SelectedValue) == 0 )
                  {
                     AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV38ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV25SelectedText = ((string)AV38ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV46GXV3 = (int)(AV46GXV3+1);
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_RESIDENTTYPEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom3 = AV12SkipItems;
            GXPagingTo3 = AV11MaxItems;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A97ResidentTypeName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P007A3 */
            pr_default.execute(1, new Object[] {lV14SearchTxt, GXPagingFrom3, GXPagingTo3, GXPagingTo3});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A97ResidentTypeName = P007A3_A97ResidentTypeName[0];
               A96ResidentTypeId = P007A3_A96ResidentTypeId[0];
               n96ResidentTypeId = P007A3_n96ResidentTypeId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A96ResidentTypeId.ToString());
               AV16Combo_DataItem.gxTpr_Title = A97ResidentTypeName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV26Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P007A4 */
                  pr_default.execute(2, new Object[] {AV20ResidentId, AV21LocationId, AV22OrganisationId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A11OrganisationId = P007A4_A11OrganisationId[0];
                     A29LocationId = P007A4_A29LocationId[0];
                     A62ResidentId = P007A4_A62ResidentId[0];
                     A96ResidentTypeId = P007A4_A96ResidentTypeId[0];
                     n96ResidentTypeId = P007A4_n96ResidentTypeId[0];
                     A97ResidentTypeName = P007A4_A97ResidentTypeName[0];
                     A97ResidentTypeName = P007A4_A97ResidentTypeName[0];
                     AV24SelectedValue = ((Guid.Empty==A96ResidentTypeId) ? "" : StringUtil.Trim( A96ResidentTypeId.ToString()));
                     AV25SelectedText = A97ResidentTypeName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
               }
               else
               {
                  AV30ResidentTypeId = StringUtil.StrToGuid( AV14SearchTxt);
                  /* Using cursor P007A5 */
                  pr_default.execute(3, new Object[] {AV30ResidentTypeId});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A96ResidentTypeId = P007A5_A96ResidentTypeId[0];
                     n96ResidentTypeId = P007A5_n96ResidentTypeId[0];
                     A97ResidentTypeName = P007A5_A97ResidentTypeName[0];
                     AV25SelectedText = A97ResidentTypeName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
               }
            }
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_RESIDENTHOMEPHONECODE' Routine */
         returnInSub = false;
         AV51GXV5 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV50GXV4;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV50GXV4 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV51GXV5 <= AV50GXV4.Count )
         {
            AV41ResidentHomePhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV50GXV4.Item(AV51GXV5));
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV41ResidentHomePhoneCode_DPItem.gxTpr_Countrydialcode;
            AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV38ComboTitles.Add(AV41ResidentHomePhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV38ComboTitles.Add(AV41ResidentHomePhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV38ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV51GXV5 = (int)(AV51GXV5+1);
         }
         AV15Combo_Data.Sort("Title");
         AV26Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P007A6 */
            pr_default.execute(4, new Object[] {AV20ResidentId, AV21LocationId, AV22OrganisationId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A11OrganisationId = P007A6_A11OrganisationId[0];
               A29LocationId = P007A6_A29LocationId[0];
               A62ResidentId = P007A6_A62ResidentId[0];
               A445ResidentHomePhoneCode = P007A6_A445ResidentHomePhoneCode[0];
               AV24SelectedValue = A445ResidentHomePhoneCode;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV53GXV6 = 1;
               while ( AV53GXV6 <= AV15Combo_Data.Count )
               {
                  AV16Combo_DataItem = ((GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item)AV15Combo_Data.Item(AV53GXV6));
                  if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV24SelectedValue) == 0 )
                  {
                     AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV38ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV25SelectedText = ((string)AV38ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV53GXV6 = (int)(AV53GXV6+1);
               }
            }
         }
      }

      protected void S141( )
      {
         /* 'LOADCOMBOITEMS_RESIDENTPHONECODE' Routine */
         returnInSub = false;
         AV55GXV8 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV54GXV7;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV54GXV7 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV55GXV8 <= AV54GXV7.Count )
         {
            AV40ResidentPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV54GXV7.Item(AV55GXV8));
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV40ResidentPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV38ComboTitles.Add(AV40ResidentPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV38ComboTitles.Add(AV40ResidentPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV38ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV55GXV8 = (int)(AV55GXV8+1);
         }
         AV15Combo_Data.Sort("Title");
         AV26Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P007A7 */
            pr_default.execute(5, new Object[] {AV20ResidentId, AV21LocationId, AV22OrganisationId});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A11OrganisationId = P007A7_A11OrganisationId[0];
               A29LocationId = P007A7_A29LocationId[0];
               A62ResidentId = P007A7_A62ResidentId[0];
               A375ResidentPhoneCode = P007A7_A375ResidentPhoneCode[0];
               AV24SelectedValue = A375ResidentPhoneCode;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(5);
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV57GXV9 = 1;
               while ( AV57GXV9 <= AV15Combo_Data.Count )
               {
                  AV16Combo_DataItem = ((GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item)AV15Combo_Data.Item(AV57GXV9));
                  if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV24SelectedValue) == 0 )
                  {
                     AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV38ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV25SelectedText = ((string)AV38ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV57GXV9 = (int)(AV57GXV9+1);
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
         AV43GXV1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV39ResidentCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV38ComboTitles = new GxSimpleCollection<string>();
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P007A2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007A2_A29LocationId = new Guid[] {Guid.Empty} ;
         P007A2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007A2_A354ResidentCountry = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A354ResidentCountry = "";
         lV14SearchTxt = "";
         A97ResidentTypeName = "";
         P007A3_A97ResidentTypeName = new string[] {""} ;
         P007A3_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007A3_n96ResidentTypeId = new bool[] {false} ;
         A96ResidentTypeId = Guid.Empty;
         P007A4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007A4_A29LocationId = new Guid[] {Guid.Empty} ;
         P007A4_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007A4_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007A4_n96ResidentTypeId = new bool[] {false} ;
         P007A4_A97ResidentTypeName = new string[] {""} ;
         AV30ResidentTypeId = Guid.Empty;
         P007A5_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007A5_n96ResidentTypeId = new bool[] {false} ;
         P007A5_A97ResidentTypeName = new string[] {""} ;
         AV50GXV4 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV41ResidentHomePhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         P007A6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007A6_A29LocationId = new Guid[] {Guid.Empty} ;
         P007A6_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007A6_A445ResidentHomePhoneCode = new string[] {""} ;
         A445ResidentHomePhoneCode = "";
         AV54GXV7 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV40ResidentPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         P007A7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007A7_A29LocationId = new Guid[] {Guid.Empty} ;
         P007A7_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007A7_A375ResidentPhoneCode = new string[] {""} ;
         A375ResidentPhoneCode = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P007A2_A11OrganisationId, P007A2_A29LocationId, P007A2_A62ResidentId, P007A2_A354ResidentCountry
               }
               , new Object[] {
               P007A3_A97ResidentTypeName, P007A3_A96ResidentTypeId
               }
               , new Object[] {
               P007A4_A11OrganisationId, P007A4_A29LocationId, P007A4_A62ResidentId, P007A4_A96ResidentTypeId, P007A4_n96ResidentTypeId, P007A4_A97ResidentTypeName
               }
               , new Object[] {
               P007A5_A96ResidentTypeId, P007A5_A97ResidentTypeName
               }
               , new Object[] {
               P007A6_A11OrganisationId, P007A6_A29LocationId, P007A6_A62ResidentId, P007A6_A445ResidentHomePhoneCode
               }
               , new Object[] {
               P007A7_A11OrganisationId, P007A7_A29LocationId, P007A7_A62ResidentId, P007A7_A375ResidentPhoneCode
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private int AV11MaxItems ;
      private int AV44GXV2 ;
      private int AV46GXV3 ;
      private int GXPagingFrom3 ;
      private int GXPagingTo3 ;
      private int AV51GXV5 ;
      private int AV53GXV6 ;
      private int AV55GXV8 ;
      private int AV57GXV9 ;
      private string AV18TrnMode ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private bool n96ResidentTypeId ;
      private string AV26Combo_DataJson ;
      private string AV17ComboName ;
      private string AV23SearchTxtParms ;
      private string AV24SelectedValue ;
      private string AV25SelectedText ;
      private string AV14SearchTxt ;
      private string A354ResidentCountry ;
      private string lV14SearchTxt ;
      private string A97ResidentTypeName ;
      private string A445ResidentHomePhoneCode ;
      private string A375ResidentPhoneCode ;
      private Guid AV20ResidentId ;
      private Guid AV21LocationId ;
      private Guid AV22OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private Guid A96ResidentTypeId ;
      private Guid AV30ResidentTypeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV43GXV1 ;
      private SdtSDT_Country_SDT_CountryItem AV39ResidentCountry_DPItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GxSimpleCollection<string> AV38ComboTitles ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007A2_A11OrganisationId ;
      private Guid[] P007A2_A29LocationId ;
      private Guid[] P007A2_A62ResidentId ;
      private string[] P007A2_A354ResidentCountry ;
      private string[] P007A3_A97ResidentTypeName ;
      private Guid[] P007A3_A96ResidentTypeId ;
      private bool[] P007A3_n96ResidentTypeId ;
      private Guid[] P007A4_A11OrganisationId ;
      private Guid[] P007A4_A29LocationId ;
      private Guid[] P007A4_A62ResidentId ;
      private Guid[] P007A4_A96ResidentTypeId ;
      private bool[] P007A4_n96ResidentTypeId ;
      private string[] P007A4_A97ResidentTypeName ;
      private Guid[] P007A5_A96ResidentTypeId ;
      private bool[] P007A5_n96ResidentTypeId ;
      private string[] P007A5_A97ResidentTypeName ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV50GXV4 ;
      private SdtSDT_Country_SDT_CountryItem AV41ResidentHomePhoneCode_DPItem ;
      private Guid[] P007A6_A11OrganisationId ;
      private Guid[] P007A6_A29LocationId ;
      private Guid[] P007A6_A62ResidentId ;
      private string[] P007A6_A445ResidentHomePhoneCode ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV54GXV7 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem1 ;
      private SdtSDT_Country_SDT_CountryItem AV40ResidentPhoneCode_DPItem ;
      private Guid[] P007A7_A11OrganisationId ;
      private Guid[] P007A7_A29LocationId ;
      private Guid[] P007A7_A62ResidentId ;
      private string[] P007A7_A375ResidentPhoneCode ;
      private string aP7_SelectedValue ;
      private string aP8_SelectedText ;
      private string aP9_Combo_DataJson ;
   }

   public class trn_residentloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007A3( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A97ResidentTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ResidentTypeName, ResidentTypeId";
         sFromString = " FROM Trn_ResidentType";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(ResidentTypeName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         sOrderString += " ORDER BY ResidentTypeName, ResidentTypeId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom3" + " LIMIT CASE WHEN " + ":GXPagingTo3" + " > 0 THEN " + ":GXPagingTo3" + " ELSE 1e9 END";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P007A3(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007A2;
          prmP007A2 = new Object[] {
          new ParDef("AV20ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007A4;
          prmP007A4 = new Object[] {
          new ParDef("AV20ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007A5;
          prmP007A5 = new Object[] {
          new ParDef("AV30ResidentTypeId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007A6;
          prmP007A6 = new Object[] {
          new ParDef("AV20ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007A7;
          prmP007A7 = new Object[] {
          new ParDef("AV20ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007A3;
          prmP007A3 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007A2", "SELECT OrganisationId, LocationId, ResidentId, ResidentCountry FROM Trn_Resident WHERE ResidentId = :AV20ResidentId and LocationId = :AV21LocationId and OrganisationId = :AV22OrganisationId ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007A4", "SELECT T1.OrganisationId, T1.LocationId, T1.ResidentId, T1.ResidentTypeId, T2.ResidentTypeName FROM (Trn_Resident T1 LEFT JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) WHERE T1.ResidentId = :AV20ResidentId and T1.LocationId = :AV21LocationId and T1.OrganisationId = :AV22OrganisationId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007A5", "SELECT ResidentTypeId, ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :AV30ResidentTypeId ORDER BY ResidentTypeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007A6", "SELECT OrganisationId, LocationId, ResidentId, ResidentHomePhoneCode FROM Trn_Resident WHERE ResidentId = :AV20ResidentId and LocationId = :AV21LocationId and OrganisationId = :AV22OrganisationId ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007A7", "SELECT OrganisationId, LocationId, ResidentId, ResidentPhoneCode FROM Trn_Resident WHERE ResidentId = :AV20ResidentId and LocationId = :AV21LocationId and OrganisationId = :AV22OrganisationId ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A7,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
