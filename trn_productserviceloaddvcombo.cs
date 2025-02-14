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
   public class trn_productserviceloaddvcombo : GXProcedure
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
            return "trn_productservice_Services_Execute" ;
         }

      }

      public trn_productserviceloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_productserviceloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           Guid aP2_ProductServiceId ,
                           Guid aP3_LocationId ,
                           Guid aP4_OrganisationId ,
                           out string aP5_SelectedValue ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP6_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20ProductServiceId = aP2_ProductServiceId;
         this.AV31LocationId = aP3_LocationId;
         this.AV30OrganisationId = aP4_OrganisationId;
         this.AV22SelectedValue = "" ;
         this.AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecuteImpl();
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_Combo_Data=this.AV15Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    Guid aP2_ProductServiceId ,
                                                                                                    Guid aP3_LocationId ,
                                                                                                    Guid aP4_OrganisationId ,
                                                                                                    out string aP5_SelectedValue )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_ProductServiceId, aP3_LocationId, aP4_OrganisationId, out aP5_SelectedValue, out aP6_Combo_Data);
         return AV15Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 Guid aP2_ProductServiceId ,
                                 Guid aP3_LocationId ,
                                 Guid aP4_OrganisationId ,
                                 out string aP5_SelectedValue ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP6_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20ProductServiceId = aP2_ProductServiceId;
         this.AV31LocationId = aP3_LocationId;
         this.AV30OrganisationId = aP4_OrganisationId;
         this.AV22SelectedValue = "" ;
         this.AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         SubmitImpl();
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_Combo_Data=this.AV15Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_objcol_guid1 = AV33PreferredAgbSuppliers;
         new prc_getpreferredagbsuppliers(context ).execute( ref  GXt_objcol_guid1) ;
         AV33PreferredAgbSuppliers = GXt_objcol_guid1;
         GXt_objcol_guid1 = AV34PreferredGenSuppliers;
         new prc_getpreferredgensuppliers(context ).execute( ref  GXt_objcol_guid1) ;
         AV34PreferredGenSuppliers = GXt_objcol_guid1;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         if ( StringUtil.StrCmp(AV17ComboName, "SupplierAgb_Id") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERAGB_ID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "SupplierAgbId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERAGBID' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "SupplierGen_Id") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERGEN_ID' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "SupplierGenId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERGENID' */
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
         /* 'LOADCOMBOITEMS_SUPPLIERAGB_ID' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A49SupplierAgbId ,
                                              AV33PreferredAgbSuppliers } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00782 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A49SupplierAgbId = P00782_A49SupplierAgbId[0];
            n49SupplierAgbId = P00782_n49SupplierAgbId[0];
            A51SupplierAgbName = P00782_A51SupplierAgbName[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A49SupplierAgbId.ToString());
            AV16Combo_DataItem.gxTpr_Title = A51SupplierAgbName;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_SUPPLIERAGBID' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A49SupplierAgbId ,
                                              AV33PreferredAgbSuppliers ,
                                              A11OrganisationId ,
                                              AV30OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00783 */
         pr_default.execute(1, new Object[] {AV30OrganisationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A11OrganisationId = P00783_A11OrganisationId[0];
            n11OrganisationId = P00783_n11OrganisationId[0];
            A49SupplierAgbId = P00783_A49SupplierAgbId[0];
            n49SupplierAgbId = P00783_n49SupplierAgbId[0];
            A51SupplierAgbName = P00783_A51SupplierAgbName[0];
            A58ProductServiceId = P00783_A58ProductServiceId[0];
            A29LocationId = P00783_A29LocationId[0];
            A51SupplierAgbName = P00783_A51SupplierAgbName[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A49SupplierAgbId.ToString());
            AV16Combo_DataItem.gxTpr_Title = A51SupplierAgbName;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P00784 */
            pr_default.execute(2, new Object[] {AV20ProductServiceId, AV31LocationId, AV30OrganisationId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A11OrganisationId = P00784_A11OrganisationId[0];
               n11OrganisationId = P00784_n11OrganisationId[0];
               A29LocationId = P00784_A29LocationId[0];
               A58ProductServiceId = P00784_A58ProductServiceId[0];
               A49SupplierAgbId = P00784_A49SupplierAgbId[0];
               n49SupplierAgbId = P00784_n49SupplierAgbId[0];
               AV22SelectedValue = ((Guid.Empty==A49SupplierAgbId) ? "" : StringUtil.Trim( A49SupplierAgbId.ToString()));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_SUPPLIERGEN_ID' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A42SupplierGenId ,
                                              AV34PreferredGenSuppliers } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00785 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A42SupplierGenId = P00785_A42SupplierGenId[0];
            n42SupplierGenId = P00785_n42SupplierGenId[0];
            A44SupplierGenCompanyName = P00785_A44SupplierGenCompanyName[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A42SupplierGenId.ToString());
            AV16Combo_DataItem.gxTpr_Title = A44SupplierGenCompanyName;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S141( )
      {
         /* 'LOADCOMBOITEMS_SUPPLIERGENID' Routine */
         returnInSub = false;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A42SupplierGenId ,
                                              AV34PreferredGenSuppliers ,
                                              A11OrganisationId ,
                                              AV30OrganisationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00786 */
         pr_default.execute(4, new Object[] {AV30OrganisationId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A42SupplierGenId = P00786_A42SupplierGenId[0];
            n42SupplierGenId = P00786_n42SupplierGenId[0];
            A11OrganisationId = P00786_A11OrganisationId[0];
            n11OrganisationId = P00786_n11OrganisationId[0];
            A44SupplierGenCompanyName = P00786_A44SupplierGenCompanyName[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A42SupplierGenId.ToString());
            AV16Combo_DataItem.gxTpr_Title = A44SupplierGenCompanyName;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P00787 */
            pr_default.execute(5, new Object[] {AV20ProductServiceId, AV31LocationId, AV30OrganisationId});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A11OrganisationId = P00787_A11OrganisationId[0];
               n11OrganisationId = P00787_n11OrganisationId[0];
               A29LocationId = P00787_A29LocationId[0];
               A58ProductServiceId = P00787_A58ProductServiceId[0];
               A42SupplierGenId = P00787_A42SupplierGenId[0];
               n42SupplierGenId = P00787_n42SupplierGenId[0];
               AV22SelectedValue = ((Guid.Empty==A42SupplierGenId) ? "" : StringUtil.Trim( A42SupplierGenId.ToString()));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(5);
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
         AV22SelectedValue = "";
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV33PreferredAgbSuppliers = new GxSimpleCollection<Guid>();
         AV34PreferredGenSuppliers = new GxSimpleCollection<Guid>();
         GXt_objcol_guid1 = new GxSimpleCollection<Guid>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         A49SupplierAgbId = Guid.Empty;
         P00782_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P00782_n49SupplierAgbId = new bool[] {false} ;
         P00782_A51SupplierAgbName = new string[] {""} ;
         A51SupplierAgbName = "";
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         A11OrganisationId = Guid.Empty;
         P00783_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00783_n11OrganisationId = new bool[] {false} ;
         P00783_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P00783_n49SupplierAgbId = new bool[] {false} ;
         P00783_A51SupplierAgbName = new string[] {""} ;
         P00783_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00783_A29LocationId = new Guid[] {Guid.Empty} ;
         A58ProductServiceId = Guid.Empty;
         A29LocationId = Guid.Empty;
         P00784_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00784_n11OrganisationId = new bool[] {false} ;
         P00784_A29LocationId = new Guid[] {Guid.Empty} ;
         P00784_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00784_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P00784_n49SupplierAgbId = new bool[] {false} ;
         A42SupplierGenId = Guid.Empty;
         P00785_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00785_n42SupplierGenId = new bool[] {false} ;
         P00785_A44SupplierGenCompanyName = new string[] {""} ;
         A44SupplierGenCompanyName = "";
         P00786_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00786_n42SupplierGenId = new bool[] {false} ;
         P00786_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00786_n11OrganisationId = new bool[] {false} ;
         P00786_A44SupplierGenCompanyName = new string[] {""} ;
         P00787_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00787_n11OrganisationId = new bool[] {false} ;
         P00787_A29LocationId = new Guid[] {Guid.Empty} ;
         P00787_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00787_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00787_n42SupplierGenId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_productserviceloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00782_A49SupplierAgbId, P00782_A51SupplierAgbName
               }
               , new Object[] {
               P00783_A11OrganisationId, P00783_A49SupplierAgbId, P00783_n49SupplierAgbId, P00783_A51SupplierAgbName, P00783_A58ProductServiceId, P00783_A29LocationId
               }
               , new Object[] {
               P00784_A11OrganisationId, P00784_A29LocationId, P00784_A58ProductServiceId, P00784_A49SupplierAgbId, P00784_n49SupplierAgbId
               }
               , new Object[] {
               P00785_A42SupplierGenId, P00785_A44SupplierGenCompanyName
               }
               , new Object[] {
               P00786_A42SupplierGenId, P00786_A11OrganisationId, P00786_n11OrganisationId, P00786_A44SupplierGenCompanyName
               }
               , new Object[] {
               P00787_A11OrganisationId, P00787_A29LocationId, P00787_A58ProductServiceId, P00787_A42SupplierGenId, P00787_n42SupplierGenId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV18TrnMode ;
      private bool returnInSub ;
      private bool n49SupplierAgbId ;
      private bool n11OrganisationId ;
      private bool n42SupplierGenId ;
      private string AV17ComboName ;
      private string AV22SelectedValue ;
      private string A51SupplierAgbName ;
      private string A44SupplierGenCompanyName ;
      private Guid AV20ProductServiceId ;
      private Guid AV31LocationId ;
      private Guid AV30OrganisationId ;
      private Guid A49SupplierAgbId ;
      private Guid A11OrganisationId ;
      private Guid A58ProductServiceId ;
      private Guid A29LocationId ;
      private Guid A42SupplierGenId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GxSimpleCollection<Guid> AV33PreferredAgbSuppliers ;
      private GxSimpleCollection<Guid> AV34PreferredGenSuppliers ;
      private GxSimpleCollection<Guid> GXt_objcol_guid1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00782_A49SupplierAgbId ;
      private bool[] P00782_n49SupplierAgbId ;
      private string[] P00782_A51SupplierAgbName ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private Guid[] P00783_A11OrganisationId ;
      private bool[] P00783_n11OrganisationId ;
      private Guid[] P00783_A49SupplierAgbId ;
      private bool[] P00783_n49SupplierAgbId ;
      private string[] P00783_A51SupplierAgbName ;
      private Guid[] P00783_A58ProductServiceId ;
      private Guid[] P00783_A29LocationId ;
      private Guid[] P00784_A11OrganisationId ;
      private bool[] P00784_n11OrganisationId ;
      private Guid[] P00784_A29LocationId ;
      private Guid[] P00784_A58ProductServiceId ;
      private Guid[] P00784_A49SupplierAgbId ;
      private bool[] P00784_n49SupplierAgbId ;
      private Guid[] P00785_A42SupplierGenId ;
      private bool[] P00785_n42SupplierGenId ;
      private string[] P00785_A44SupplierGenCompanyName ;
      private Guid[] P00786_A42SupplierGenId ;
      private bool[] P00786_n42SupplierGenId ;
      private Guid[] P00786_A11OrganisationId ;
      private bool[] P00786_n11OrganisationId ;
      private string[] P00786_A44SupplierGenCompanyName ;
      private Guid[] P00787_A11OrganisationId ;
      private bool[] P00787_n11OrganisationId ;
      private Guid[] P00787_A29LocationId ;
      private Guid[] P00787_A58ProductServiceId ;
      private Guid[] P00787_A42SupplierGenId ;
      private bool[] P00787_n42SupplierGenId ;
      private string aP5_SelectedValue ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP6_Combo_Data ;
   }

   public class trn_productserviceloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00782( IGxContext context ,
                                             Guid A49SupplierAgbId ,
                                             GxSimpleCollection<Guid> AV33PreferredAgbSuppliers )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT SupplierAgbId, SupplierAgbName FROM Trn_SupplierAGB";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV33PreferredAgbSuppliers, "SupplierAgbId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierAgbName";
         GXv_Object2[0] = scmdbuf;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00783( IGxContext context ,
                                             Guid A49SupplierAgbId ,
                                             GxSimpleCollection<Guid> AV33PreferredAgbSuppliers ,
                                             Guid A11OrganisationId ,
                                             Guid AV30OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[1];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.OrganisationId, T1.SupplierAgbId, T2.SupplierAgbName, T1.ProductServiceId, T1.LocationId FROM (Trn_ProductService T1 LEFT JOIN Trn_SupplierAGB T2 ON T2.SupplierAgbId = T1.SupplierAgbId)";
         AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV33PreferredAgbSuppliers, "T1.SupplierAgbId IN (", ")")+")");
         AddWhere(sWhereString, "(T1.OrganisationId = :AV30OrganisationId)");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.SupplierAgbName";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00785( IGxContext context ,
                                             Guid A42SupplierGenId ,
                                             GxSimpleCollection<Guid> AV34PreferredGenSuppliers )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT SupplierGenId, SupplierGenCompanyName FROM Trn_SupplierGen";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV34PreferredGenSuppliers, "SupplierGenId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierGenCompanyName";
         GXv_Object6[0] = scmdbuf;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00786( IGxContext context ,
                                             Guid A42SupplierGenId ,
                                             GxSimpleCollection<Guid> AV34PreferredGenSuppliers ,
                                             Guid A11OrganisationId ,
                                             Guid AV30OrganisationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[1];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT SupplierGenId, OrganisationId, SupplierGenCompanyName FROM Trn_SupplierGen";
         AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV34PreferredGenSuppliers, "SupplierGenId IN (", ")")+")");
         AddWhere(sWhereString, "(OrganisationId = :AV30OrganisationId)");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierGenCompanyName";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00782(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
               case 1 :
                     return conditional_P00783(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
               case 3 :
                     return conditional_P00785(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
               case 4 :
                     return conditional_P00786(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
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
          Object[] prmP00784;
          prmP00784 = new Object[] {
          new ParDef("AV20ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV31LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV30OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00787;
          prmP00787 = new Object[] {
          new ParDef("AV20ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV31LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV30OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00782;
          prmP00782 = new Object[] {
          };
          Object[] prmP00783;
          prmP00783 = new Object[] {
          new ParDef("AV30OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00785;
          prmP00785 = new Object[] {
          };
          Object[] prmP00786;
          prmP00786 = new Object[] {
          new ParDef("AV30OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00782", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00782,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00783", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00783,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00784", "SELECT OrganisationId, LocationId, ProductServiceId, SupplierAgbId FROM Trn_ProductService WHERE ProductServiceId = :AV20ProductServiceId and LocationId = :AV31LocationId and OrganisationId = :AV30OrganisationId ORDER BY ProductServiceId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00784,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00785", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00785,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00786", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00786,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00787", "SELECT OrganisationId, LocationId, ProductServiceId, SupplierGenId FROM Trn_ProductService WHERE ProductServiceId = :AV20ProductServiceId and LocationId = :AV31LocationId and OrganisationId = :AV30OrganisationId ORDER BY ProductServiceId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00787,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                ((Guid[]) buf[5])[0] = rslt.getGuid(5);
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
