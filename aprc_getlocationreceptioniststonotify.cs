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
   public class aprc_getlocationreceptioniststonotify : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_getlocationreceptioniststonotify().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
         return GX.GXRuntime.ExitCode ;
      }

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

      public aprc_getlocationreceptioniststonotify( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_getlocationreceptioniststonotify( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPUserExtendedId ,
                           out GxSimpleCollection<string> aP1_LocationReceptionistsGUIDCollection )
      {
         this.AV10WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV13LocationReceptionistsGUIDCollection = new GxSimpleCollection<string>() ;
         initialize();
         ExecuteImpl();
         aP1_LocationReceptionistsGUIDCollection=this.AV13LocationReceptionistsGUIDCollection;
      }

      public GxSimpleCollection<string> executeUdp( string aP0_WWPUserExtendedId )
      {
         execute(aP0_WWPUserExtendedId, out aP1_LocationReceptionistsGUIDCollection);
         return AV13LocationReceptionistsGUIDCollection ;
      }

      public void executeSubmit( string aP0_WWPUserExtendedId ,
                                 out GxSimpleCollection<string> aP1_LocationReceptionistsGUIDCollection )
      {
         this.AV10WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV13LocationReceptionistsGUIDCollection = new GxSimpleCollection<string>() ;
         SubmitImpl();
         aP1_LocationReceptionistsGUIDCollection=this.AV13LocationReceptionistsGUIDCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV15GXLvl2 = 0;
         /* Using cursor P009U2 */
         pr_default.execute(0, new Object[] {AV10WWPUserExtendedId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A95ReceptionistGAMGUID = P009U2_A95ReceptionistGAMGUID[0];
            A29LocationId = P009U2_A29LocationId[0];
            A89ReceptionistId = P009U2_A89ReceptionistId[0];
            A11OrganisationId = P009U2_A11OrganisationId[0];
            AV15GXLvl2 = 1;
            AV12LocationId = A29LocationId;
            AV14isRecordFound = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV15GXLvl2 == 0 )
         {
            AV14isRecordFound = false;
         }
         if ( ! AV14isRecordFound )
         {
            /* Using cursor P009U3 */
            pr_default.execute(1, new Object[] {AV10WWPUserExtendedId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A71ResidentGUID = P009U3_A71ResidentGUID[0];
               A29LocationId = P009U3_A29LocationId[0];
               A62ResidentId = P009U3_A62ResidentId[0];
               A11OrganisationId = P009U3_A11OrganisationId[0];
               AV12LocationId = A29LocationId;
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         AV17GXLvl20 = 0;
         /* Using cursor P009U4 */
         pr_default.execute(2, new Object[] {AV12LocationId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A29LocationId = P009U4_A29LocationId[0];
            A95ReceptionistGAMGUID = P009U4_A95ReceptionistGAMGUID[0];
            A89ReceptionistId = P009U4_A89ReceptionistId[0];
            A11OrganisationId = P009U4_A11OrganisationId[0];
            AV17GXLvl20 = 1;
            AV13LocationReceptionistsGUIDCollection.Add(A95ReceptionistGAMGUID, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( AV17GXLvl20 == 0 )
         {
            AV13LocationReceptionistsGUIDCollection.Clear();
         }
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
         AV13LocationReceptionistsGUIDCollection = new GxSimpleCollection<string>();
         P009U2_A95ReceptionistGAMGUID = new string[] {""} ;
         P009U2_A29LocationId = new Guid[] {Guid.Empty} ;
         P009U2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P009U2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A95ReceptionistGAMGUID = "";
         A29LocationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV12LocationId = Guid.Empty;
         P009U3_A71ResidentGUID = new string[] {""} ;
         P009U3_A29LocationId = new Guid[] {Guid.Empty} ;
         P009U3_A62ResidentId = new Guid[] {Guid.Empty} ;
         P009U3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A71ResidentGUID = "";
         A62ResidentId = Guid.Empty;
         P009U4_A29LocationId = new Guid[] {Guid.Empty} ;
         P009U4_A95ReceptionistGAMGUID = new string[] {""} ;
         P009U4_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P009U4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_getlocationreceptioniststonotify__default(),
            new Object[][] {
                new Object[] {
               P009U2_A95ReceptionistGAMGUID, P009U2_A29LocationId, P009U2_A89ReceptionistId, P009U2_A11OrganisationId
               }
               , new Object[] {
               P009U3_A71ResidentGUID, P009U3_A29LocationId, P009U3_A62ResidentId, P009U3_A11OrganisationId
               }
               , new Object[] {
               P009U4_A29LocationId, P009U4_A95ReceptionistGAMGUID, P009U4_A89ReceptionistId, P009U4_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV15GXLvl2 ;
      private short AV17GXLvl20 ;
      private string AV10WWPUserExtendedId ;
      private bool AV14isRecordFound ;
      private string A95ReceptionistGAMGUID ;
      private string A71ResidentGUID ;
      private Guid A29LocationId ;
      private Guid A89ReceptionistId ;
      private Guid A11OrganisationId ;
      private Guid AV12LocationId ;
      private Guid A62ResidentId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV13LocationReceptionistsGUIDCollection ;
      private IDataStoreProvider pr_default ;
      private string[] P009U2_A95ReceptionistGAMGUID ;
      private Guid[] P009U2_A29LocationId ;
      private Guid[] P009U2_A89ReceptionistId ;
      private Guid[] P009U2_A11OrganisationId ;
      private string[] P009U3_A71ResidentGUID ;
      private Guid[] P009U3_A29LocationId ;
      private Guid[] P009U3_A62ResidentId ;
      private Guid[] P009U3_A11OrganisationId ;
      private Guid[] P009U4_A29LocationId ;
      private string[] P009U4_A95ReceptionistGAMGUID ;
      private Guid[] P009U4_A89ReceptionistId ;
      private Guid[] P009U4_A11OrganisationId ;
      private GxSimpleCollection<string> aP1_LocationReceptionistsGUIDCollection ;
   }

   public class aprc_getlocationreceptioniststonotify__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009U2;
          prmP009U2 = new Object[] {
          new ParDef("AV10WWPUserExtendedId",GXType.Char,40,0)
          };
          Object[] prmP009U3;
          prmP009U3 = new Object[] {
          new ParDef("AV10WWPUserExtendedId",GXType.Char,40,0)
          };
          Object[] prmP009U4;
          prmP009U4 = new Object[] {
          new ParDef("AV12LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009U2", "SELECT ReceptionistGAMGUID, LocationId, ReceptionistId, OrganisationId FROM Trn_Receptionist WHERE ReceptionistGAMGUID = ( :AV10WWPUserExtendedId) ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009U2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009U3", "SELECT ResidentGUID, LocationId, ResidentId, OrganisationId FROM Trn_Resident WHERE ResidentGUID = ( :AV10WWPUserExtendedId) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009U3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009U4", "SELECT LocationId, ReceptionistGAMGUID, ReceptionistId, OrganisationId FROM Trn_Receptionist WHERE LocationId = :AV12LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009U4,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
