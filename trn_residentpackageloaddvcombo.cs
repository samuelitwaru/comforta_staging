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
   public class trn_residentpackageloaddvcombo : GXProcedure
   {
      public trn_residentpackageloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_residentpackageloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           Guid aP2_ResidentPackageId ,
                           out string aP3_SelectedValue ,
                           out string aP4_SelectedText ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP5_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15ResidentPackageId = aP2_ResidentPackageId;
         this.AV16SelectedValue = "" ;
         this.AV17SelectedText = "" ;
         this.AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecuteImpl();
         aP3_SelectedValue=this.AV16SelectedValue;
         aP4_SelectedText=this.AV17SelectedText;
         aP5_Combo_Data=this.AV11Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    Guid aP2_ResidentPackageId ,
                                                                                                    out string aP3_SelectedValue ,
                                                                                                    out string aP4_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_ResidentPackageId, out aP3_SelectedValue, out aP4_SelectedText, out aP5_Combo_Data);
         return AV11Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 Guid aP2_ResidentPackageId ,
                                 out string aP3_SelectedValue ,
                                 out string aP4_SelectedText ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP5_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15ResidentPackageId = aP2_ResidentPackageId;
         this.AV16SelectedValue = "" ;
         this.AV17SelectedText = "" ;
         this.AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         SubmitImpl();
         aP3_SelectedValue=this.AV16SelectedValue;
         aP4_SelectedText=this.AV17SelectedText;
         aP5_Combo_Data=this.AV11Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         if ( StringUtil.StrCmp(AV13ComboName, "ResidentPackageModules") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RESIDENTPACKAGEMODULES' */
            S111 ();
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
         /* 'LOADCOMBOITEMS_RESIDENTPACKAGEMODULES' Routine */
         returnInSub = false;
         AV22GXV2 = 1;
         GXt_objcol_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem1 = AV21GXV1;
         new dp_residentprovisioning(context ).execute( out  GXt_objcol_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem1) ;
         AV21GXV1 = GXt_objcol_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem1;
         while ( AV22GXV2 <= AV21GXV1.Count )
         {
            AV20ResidentPackageModules_DPItem = ((SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem)AV21GXV1.Item(AV22GXV2));
            AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = AV20ResidentPackageModules_DPItem.gxTpr_Organisationprovisionvalue;
            AV12Combo_DataItem.gxTpr_Title = AV20ResidentPackageModules_DPItem.gxTpr_Organisationprovisiondescription;
            AV11Combo_Data.Add(AV12Combo_DataItem, 0);
            AV22GXV2 = (int)(AV22GXV2+1);
         }
         AV11Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV14TrnMode, "INS") != 0 )
         {
            /* Using cursor P00BP2 */
            pr_default.execute(0, new Object[] {AV15ResidentPackageId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A554ResidentPackageId = P00BP2_A554ResidentPackageId[0];
               A558ResidentPackageModules = P00BP2_A558ResidentPackageModules[0];
               AV16SelectedValue = A558ResidentPackageModules;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( StringUtil.StrCmp(AV14TrnMode, "GET_DSC") == 0 )
            {
               AV24GXV3 = 1;
               while ( AV24GXV3 <= AV11Combo_Data.Count )
               {
                  AV12Combo_DataItem = ((GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item)AV11Combo_Data.Item(AV24GXV3));
                  if ( StringUtil.StrCmp(AV12Combo_DataItem.gxTpr_Id, AV16SelectedValue) == 0 )
                  {
                     AV17SelectedText = AV12Combo_DataItem.gxTpr_Title;
                     if (true) break;
                  }
                  AV24GXV3 = (int)(AV24GXV3+1);
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
         AV16SelectedValue = "";
         AV17SelectedText = "";
         AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV21GXV1 = new GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem>( context, "SDT_ResidentProvisioningItem", "Comforta_version2");
         GXt_objcol_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem1 = new GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem>( context, "SDT_ResidentProvisioningItem", "Comforta_version2");
         AV20ResidentPackageModules_DPItem = new SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem(context);
         AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         P00BP2_A554ResidentPackageId = new Guid[] {Guid.Empty} ;
         P00BP2_A558ResidentPackageModules = new string[] {""} ;
         A554ResidentPackageId = Guid.Empty;
         A558ResidentPackageModules = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentpackageloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00BP2_A554ResidentPackageId, P00BP2_A558ResidentPackageModules
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV22GXV2 ;
      private int AV24GXV3 ;
      private string AV14TrnMode ;
      private bool returnInSub ;
      private string A558ResidentPackageModules ;
      private string AV13ComboName ;
      private string AV16SelectedValue ;
      private string AV17SelectedText ;
      private Guid AV15ResidentPackageId ;
      private Guid A554ResidentPackageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV11Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem> AV21GXV1 ;
      private GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem> GXt_objcol_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem1 ;
      private SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem AV20ResidentPackageModules_DPItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV12Combo_DataItem ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BP2_A554ResidentPackageId ;
      private string[] P00BP2_A558ResidentPackageModules ;
      private string aP3_SelectedValue ;
      private string aP4_SelectedText ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP5_Combo_Data ;
   }

   public class trn_residentpackageloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BP2;
          prmP00BP2 = new Object[] {
          new ParDef("AV15ResidentPackageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BP2", "SELECT ResidentPackageId, ResidentPackageModules FROM Trn_ResidentPackage WHERE ResidentPackageId = :AV15ResidentPackageId ORDER BY ResidentPackageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BP2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                return;
       }
    }

 }

}
