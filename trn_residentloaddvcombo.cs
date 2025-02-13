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
                           Guid aP2_ResidentId ,
                           Guid aP3_LocationId ,
                           Guid aP4_OrganisationId ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP7_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20ResidentId = aP2_ResidentId;
         this.AV21LocationId = aP3_LocationId;
         this.AV22OrganisationId = aP4_OrganisationId;
         this.AV24SelectedValue = "" ;
         this.AV25SelectedText = "" ;
         this.AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecuteImpl();
         aP5_SelectedValue=this.AV24SelectedValue;
         aP6_SelectedText=this.AV25SelectedText;
         aP7_Combo_Data=this.AV15Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    Guid aP2_ResidentId ,
                                                                                                    Guid aP3_LocationId ,
                                                                                                    Guid aP4_OrganisationId ,
                                                                                                    out string aP5_SelectedValue ,
                                                                                                    out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_ResidentId, aP3_LocationId, aP4_OrganisationId, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_Data);
         return AV15Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 Guid aP2_ResidentId ,
                                 Guid aP3_LocationId ,
                                 Guid aP4_OrganisationId ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP7_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20ResidentId = aP2_ResidentId;
         this.AV21LocationId = aP3_LocationId;
         this.AV22OrganisationId = aP4_OrganisationId;
         this.AV24SelectedValue = "" ;
         this.AV25SelectedText = "" ;
         this.AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         SubmitImpl();
         aP5_SelectedValue=this.AV24SelectedValue;
         aP6_SelectedText=this.AV25SelectedText;
         aP7_Combo_Data=this.AV15Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
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
         /* Using cursor P007A3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A96ResidentTypeId = P007A3_A96ResidentTypeId[0];
            n96ResidentTypeId = P007A3_n96ResidentTypeId[0];
            A97ResidentTypeName = P007A3_A97ResidentTypeName[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A96ResidentTypeId.ToString());
            AV16Combo_DataItem.gxTpr_Title = A97ResidentTypeName;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 ) && ( StringUtil.StrCmp(AV18TrnMode, "NEW") != 0 ) )
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
               AV24SelectedValue = ((Guid.Empty==A96ResidentTypeId) ? "" : StringUtil.Trim( A96ResidentTypeId.ToString()));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_RESIDENTHOMEPHONECODE' Routine */
         returnInSub = false;
         AV50GXV5 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV49GXV4;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV49GXV4 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV50GXV5 <= AV49GXV4.Count )
         {
            AV41ResidentHomePhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV49GXV4.Item(AV50GXV5));
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV41ResidentHomePhoneCode_DPItem.gxTpr_Countrydialcode;
            AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV38ComboTitles.Add(AV41ResidentHomePhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV38ComboTitles.Add(AV41ResidentHomePhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV38ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV50GXV5 = (int)(AV50GXV5+1);
         }
         AV15Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P007A5 */
            pr_default.execute(3, new Object[] {AV20ResidentId, AV21LocationId, AV22OrganisationId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A11OrganisationId = P007A5_A11OrganisationId[0];
               A29LocationId = P007A5_A29LocationId[0];
               A62ResidentId = P007A5_A62ResidentId[0];
               A445ResidentHomePhoneCode = P007A5_A445ResidentHomePhoneCode[0];
               AV24SelectedValue = A445ResidentHomePhoneCode;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV52GXV6 = 1;
               while ( AV52GXV6 <= AV15Combo_Data.Count )
               {
                  AV16Combo_DataItem = ((GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item)AV15Combo_Data.Item(AV52GXV6));
                  if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV24SelectedValue) == 0 )
                  {
                     AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV38ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV25SelectedText = ((string)AV38ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV52GXV6 = (int)(AV52GXV6+1);
               }
            }
         }
      }

      protected void S141( )
      {
         /* 'LOADCOMBOITEMS_RESIDENTPHONECODE' Routine */
         returnInSub = false;
         AV54GXV8 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV53GXV7;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV53GXV7 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV54GXV8 <= AV53GXV7.Count )
         {
            AV40ResidentPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV53GXV7.Item(AV54GXV8));
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV40ResidentPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV38ComboTitles.Add(AV40ResidentPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV38ComboTitles.Add(AV40ResidentPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV38ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV54GXV8 = (int)(AV54GXV8+1);
         }
         AV15Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P007A6 */
            pr_default.execute(4, new Object[] {AV20ResidentId, AV21LocationId, AV22OrganisationId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A11OrganisationId = P007A6_A11OrganisationId[0];
               A29LocationId = P007A6_A29LocationId[0];
               A62ResidentId = P007A6_A62ResidentId[0];
               A375ResidentPhoneCode = P007A6_A375ResidentPhoneCode[0];
               AV24SelectedValue = A375ResidentPhoneCode;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV56GXV9 = 1;
               while ( AV56GXV9 <= AV15Combo_Data.Count )
               {
                  AV16Combo_DataItem = ((GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item)AV15Combo_Data.Item(AV56GXV9));
                  if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV24SelectedValue) == 0 )
                  {
                     AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV38ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV25SelectedText = ((string)AV38ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV56GXV9 = (int)(AV56GXV9+1);
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
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV43GXV1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV39ResidentCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV38ComboTitles = new GxSimpleCollection<string>();
         P007A2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007A2_A29LocationId = new Guid[] {Guid.Empty} ;
         P007A2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007A2_A354ResidentCountry = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A354ResidentCountry = "";
         P007A3_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007A3_n96ResidentTypeId = new bool[] {false} ;
         P007A3_A97ResidentTypeName = new string[] {""} ;
         A96ResidentTypeId = Guid.Empty;
         A97ResidentTypeName = "";
         P007A4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007A4_A29LocationId = new Guid[] {Guid.Empty} ;
         P007A4_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007A4_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007A4_n96ResidentTypeId = new bool[] {false} ;
         AV49GXV4 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV41ResidentHomePhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         P007A5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007A5_A29LocationId = new Guid[] {Guid.Empty} ;
         P007A5_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007A5_A445ResidentHomePhoneCode = new string[] {""} ;
         A445ResidentHomePhoneCode = "";
         AV53GXV7 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV40ResidentPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         P007A6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007A6_A29LocationId = new Guid[] {Guid.Empty} ;
         P007A6_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007A6_A375ResidentPhoneCode = new string[] {""} ;
         A375ResidentPhoneCode = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P007A2_A11OrganisationId, P007A2_A29LocationId, P007A2_A62ResidentId, P007A2_A354ResidentCountry
               }
               , new Object[] {
               P007A3_A96ResidentTypeId, P007A3_A97ResidentTypeName
               }
               , new Object[] {
               P007A4_A11OrganisationId, P007A4_A29LocationId, P007A4_A62ResidentId, P007A4_A96ResidentTypeId, P007A4_n96ResidentTypeId
               }
               , new Object[] {
               P007A5_A11OrganisationId, P007A5_A29LocationId, P007A5_A62ResidentId, P007A5_A445ResidentHomePhoneCode
               }
               , new Object[] {
               P007A6_A11OrganisationId, P007A6_A29LocationId, P007A6_A62ResidentId, P007A6_A375ResidentPhoneCode
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV44GXV2 ;
      private int AV46GXV3 ;
      private int AV50GXV5 ;
      private int AV52GXV6 ;
      private int AV54GXV8 ;
      private int AV56GXV9 ;
      private string AV18TrnMode ;
      private bool returnInSub ;
      private bool n96ResidentTypeId ;
      private string AV17ComboName ;
      private string AV24SelectedValue ;
      private string AV25SelectedText ;
      private string A354ResidentCountry ;
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
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV43GXV1 ;
      private SdtSDT_Country_SDT_CountryItem AV39ResidentCountry_DPItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GxSimpleCollection<string> AV38ComboTitles ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007A2_A11OrganisationId ;
      private Guid[] P007A2_A29LocationId ;
      private Guid[] P007A2_A62ResidentId ;
      private string[] P007A2_A354ResidentCountry ;
      private Guid[] P007A3_A96ResidentTypeId ;
      private bool[] P007A3_n96ResidentTypeId ;
      private string[] P007A3_A97ResidentTypeName ;
      private Guid[] P007A4_A11OrganisationId ;
      private Guid[] P007A4_A29LocationId ;
      private Guid[] P007A4_A62ResidentId ;
      private Guid[] P007A4_A96ResidentTypeId ;
      private bool[] P007A4_n96ResidentTypeId ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV49GXV4 ;
      private SdtSDT_Country_SDT_CountryItem AV41ResidentHomePhoneCode_DPItem ;
      private Guid[] P007A5_A11OrganisationId ;
      private Guid[] P007A5_A29LocationId ;
      private Guid[] P007A5_A62ResidentId ;
      private string[] P007A5_A445ResidentHomePhoneCode ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV53GXV7 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem1 ;
      private SdtSDT_Country_SDT_CountryItem AV40ResidentPhoneCode_DPItem ;
      private Guid[] P007A6_A11OrganisationId ;
      private Guid[] P007A6_A29LocationId ;
      private Guid[] P007A6_A62ResidentId ;
      private string[] P007A6_A375ResidentPhoneCode ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP7_Combo_Data ;
   }

   public class trn_residentloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP007A2;
          prmP007A2 = new Object[] {
          new ParDef("AV20ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007A3;
          prmP007A3 = new Object[] {
          };
          Object[] prmP007A4;
          prmP007A4 = new Object[] {
          new ParDef("AV20ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007A5;
          prmP007A5 = new Object[] {
          new ParDef("AV20ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007A6;
          prmP007A6 = new Object[] {
          new ParDef("AV20ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007A2", "SELECT OrganisationId, LocationId, ResidentId, ResidentCountry FROM Trn_Resident WHERE ResidentId = :AV20ResidentId and LocationId = :AV21LocationId and OrganisationId = :AV22OrganisationId ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007A3", "SELECT ResidentTypeId, ResidentTypeName FROM Trn_ResidentType ORDER BY ResidentTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007A4", "SELECT OrganisationId, LocationId, ResidentId, ResidentTypeId FROM Trn_Resident WHERE ResidentId = :AV20ResidentId and LocationId = :AV21LocationId and OrganisationId = :AV22OrganisationId ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007A5", "SELECT OrganisationId, LocationId, ResidentId, ResidentHomePhoneCode FROM Trn_Resident WHERE ResidentId = :AV20ResidentId and LocationId = :AV21LocationId and OrganisationId = :AV22OrganisationId ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007A6", "SELECT OrganisationId, LocationId, ResidentId, ResidentPhoneCode FROM Trn_Resident WHERE ResidentId = :AV20ResidentId and LocationId = :AV21LocationId and OrganisationId = :AV22OrganisationId ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A6,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
