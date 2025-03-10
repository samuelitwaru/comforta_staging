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
   public class dp_residentprovisioning : GXProcedure
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

      public dp_residentprovisioning( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dp_residentprovisioning( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationId ,
                           out GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem> aP1_Gxm2rootcol )
      {
         this.AV5OrganisationId = aP0_OrganisationId;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem>( context, "SDT_ResidentProvisioningItem", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem> executeUdp( Guid aP0_OrganisationId )
      {
         execute(aP0_OrganisationId, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( Guid aP0_OrganisationId ,
                                 out GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem> aP1_Gxm2rootcol )
      {
         this.AV5OrganisationId = aP0_OrganisationId;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem>( context, "SDT_ResidentProvisioningItem", "Comforta_version2") ;
         SubmitImpl();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P000T2 */
         pr_default.execute(0, new Object[] {AV5OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A546OrganisationHasMyCare = P000T2_A546OrganisationHasMyCare[0];
            A11OrganisationId = P000T2_A11OrganisationId[0];
            A100OrganisationSettingid = P000T2_A100OrganisationSettingid[0];
            Gxm1sdt_residentprovisioning = new SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem(context);
            Gxm2rootcol.Add(Gxm1sdt_residentprovisioning, 0);
            Gxm1sdt_residentprovisioning.gxTpr_Organisationprovisiondescription = context.GetMessage( "My Care", "");
            Gxm1sdt_residentprovisioning.gxTpr_Organisationprovisionvalue = "My Care";
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P000T3 */
         pr_default.execute(1, new Object[] {AV5OrganisationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A547OrganisationHasMyLiving = P000T3_A547OrganisationHasMyLiving[0];
            A11OrganisationId = P000T3_A11OrganisationId[0];
            A100OrganisationSettingid = P000T3_A100OrganisationSettingid[0];
            Gxm1sdt_residentprovisioning = new SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem(context);
            Gxm2rootcol.Add(Gxm1sdt_residentprovisioning, 0);
            Gxm1sdt_residentprovisioning.gxTpr_Organisationprovisiondescription = context.GetMessage( "My Living", "");
            Gxm1sdt_residentprovisioning.gxTpr_Organisationprovisionvalue = "My Living";
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P000T4 */
         pr_default.execute(2, new Object[] {AV5OrganisationId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A548OrganisationHasMyServices = P000T4_A548OrganisationHasMyServices[0];
            A11OrganisationId = P000T4_A11OrganisationId[0];
            A100OrganisationSettingid = P000T4_A100OrganisationSettingid[0];
            Gxm1sdt_residentprovisioning = new SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem(context);
            Gxm2rootcol.Add(Gxm1sdt_residentprovisioning, 0);
            Gxm1sdt_residentprovisioning.gxTpr_Organisationprovisiondescription = context.GetMessage( "My Services", "");
            Gxm1sdt_residentprovisioning.gxTpr_Organisationprovisionvalue = "My Services";
            pr_default.readNext(2);
         }
         pr_default.close(2);
         cleanup();
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
         P000T2_A546OrganisationHasMyCare = new bool[] {false} ;
         P000T2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P000T2_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A100OrganisationSettingid = Guid.Empty;
         Gxm1sdt_residentprovisioning = new SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem(context);
         P000T3_A547OrganisationHasMyLiving = new bool[] {false} ;
         P000T3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P000T3_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         P000T4_A548OrganisationHasMyServices = new bool[] {false} ;
         P000T4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P000T4_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dp_residentprovisioning__default(),
            new Object[][] {
                new Object[] {
               P000T2_A546OrganisationHasMyCare, P000T2_A11OrganisationId, P000T2_A100OrganisationSettingid
               }
               , new Object[] {
               P000T3_A547OrganisationHasMyLiving, P000T3_A11OrganisationId, P000T3_A100OrganisationSettingid
               }
               , new Object[] {
               P000T4_A548OrganisationHasMyServices, P000T4_A11OrganisationId, P000T4_A100OrganisationSettingid
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool A546OrganisationHasMyCare ;
      private bool A547OrganisationHasMyLiving ;
      private bool A548OrganisationHasMyServices ;
      private Guid AV5OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A100OrganisationSettingid ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private bool[] P000T2_A546OrganisationHasMyCare ;
      private Guid[] P000T2_A11OrganisationId ;
      private Guid[] P000T2_A100OrganisationSettingid ;
      private SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem Gxm1sdt_residentprovisioning ;
      private bool[] P000T3_A547OrganisationHasMyLiving ;
      private Guid[] P000T3_A11OrganisationId ;
      private Guid[] P000T3_A100OrganisationSettingid ;
      private bool[] P000T4_A548OrganisationHasMyServices ;
      private Guid[] P000T4_A11OrganisationId ;
      private Guid[] P000T4_A100OrganisationSettingid ;
      private GXBaseCollection<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem> aP1_Gxm2rootcol ;
   }

   public class dp_residentprovisioning__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP000T2;
          prmP000T2 = new Object[] {
          new ParDef("AV5OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP000T3;
          prmP000T3 = new Object[] {
          new ParDef("AV5OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP000T4;
          prmP000T4 = new Object[] {
          new ParDef("AV5OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000T2", "SELECT OrganisationHasMyCare, OrganisationId, OrganisationSettingid FROM Trn_OrganisationSetting WHERE (OrganisationId = :AV5OrganisationId) AND (OrganisationHasMyCare = TRUE) ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000T2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P000T3", "SELECT OrganisationHasMyLiving, OrganisationId, OrganisationSettingid FROM Trn_OrganisationSetting WHERE (OrganisationId = :AV5OrganisationId) AND (OrganisationHasMyLiving = TRUE) ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000T3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P000T4", "SELECT OrganisationHasMyServices, OrganisationId, OrganisationSettingid FROM Trn_OrganisationSetting WHERE (OrganisationId = :AV5OrganisationId) AND (OrganisationHasMyServices = TRUE) ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000T4,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 2 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
