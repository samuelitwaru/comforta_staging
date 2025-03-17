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
   public class prc_activateappversion : GXProcedure
   {
      public prc_activateappversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_activateappversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           out SdtSDT_AppVersion aP1_SDT_AppVersion ,
                           out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV10AppVersionId = aP0_AppVersionId;
         this.AV8SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_AppVersion=this.AV8SDT_AppVersion;
         aP2_SDT_Error=this.AV9SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      out SdtSDT_AppVersion aP1_SDT_AppVersion )
      {
         execute(aP0_AppVersionId, out aP1_SDT_AppVersion, out aP2_SDT_Error);
         return AV9SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 out SdtSDT_AppVersion aP1_SDT_AppVersion ,
                                 out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV10AppVersionId = aP0_AppVersionId;
         this.AV8SDT_AppVersion = new SdtSDT_AppVersion(context) ;
         this.AV9SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_SDT_AppVersion=this.AV8SDT_AppVersion;
         aP2_SDT_Error=this.AV9SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV9SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV9SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         GXt_guid1 = AV12LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV12LocationId = GXt_guid1;
         /* Using cursor P00CL2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTCL2 = 0;
            A561IsActive = P00CL2_A561IsActive[0];
            A29LocationId = P00CL2_A29LocationId[0];
            n29LocationId = P00CL2_n29LocationId[0];
            A543AppVersionId = P00CL2_A543AppVersionId[0];
            A561IsActive = false;
            if ( ( ( A543AppVersionId == AV10AppVersionId ) ) && ( ( A29LocationId == AV12LocationId ) ) )
            {
               A561IsActive = true;
               AV13BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
               AV13BC_Trn_AppVersion.Load(A543AppVersionId);
               new prc_loadappversionsdt(context ).execute(  AV13BC_Trn_AppVersion, out  AV8SDT_AppVersion) ;
            }
            GXTCL2 = 1;
            /* Using cursor P00CL3 */
            pr_default.execute(1, new Object[] {A561IsActive, A543AppVersionId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
            if ( GXTCL2 == 1 )
            {
               context.CommitDataStores("prc_activateappversion",pr_default);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_activateappversion",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV8SDT_AppVersion = new SdtSDT_AppVersion(context);
         AV9SDT_Error = new SdtSDT_Error(context);
         AV12LocationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         P00CL2_A561IsActive = new bool[] {false} ;
         P00CL2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00CL2_n29LocationId = new bool[] {false} ;
         P00CL2_A543AppVersionId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A543AppVersionId = Guid.Empty;
         AV13BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_activateappversion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_activateappversion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_activateappversion__default(),
            new Object[][] {
                new Object[] {
               P00CL2_A561IsActive, P00CL2_A29LocationId, P00CL2_n29LocationId, P00CL2_A543AppVersionId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTCL2 ;
      private bool A561IsActive ;
      private bool n29LocationId ;
      private Guid AV10AppVersionId ;
      private Guid AV12LocationId ;
      private Guid GXt_guid1 ;
      private Guid A29LocationId ;
      private Guid A543AppVersionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppVersion AV8SDT_AppVersion ;
      private SdtSDT_Error AV9SDT_Error ;
      private IDataStoreProvider pr_default ;
      private bool[] P00CL2_A561IsActive ;
      private Guid[] P00CL2_A29LocationId ;
      private bool[] P00CL2_n29LocationId ;
      private Guid[] P00CL2_A543AppVersionId ;
      private SdtTrn_AppVersion AV13BC_Trn_AppVersion ;
      private SdtSDT_AppVersion aP1_SDT_AppVersion ;
      private SdtSDT_Error aP2_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_activateappversion__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class prc_activateappversion__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class prc_activateappversion__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new UpdateCursor(def[1])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00CL2;
       prmP00CL2 = new Object[] {
       };
       Object[] prmP00CL3;
       prmP00CL3 = new Object[] {
       new ParDef("IsActive",GXType.Boolean,4,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00CL2", "SELECT IsActive, LocationId, AppVersionId FROM Trn_AppVersion ORDER BY AppVersionId  FOR UPDATE OF Trn_AppVersion",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CL2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00CL3", "SAVEPOINT gxupdate;UPDATE Trn_AppVersion SET IsActive=:IsActive  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CL3)
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
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             return;
    }
 }

}

}
