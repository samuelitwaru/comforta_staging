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
   public class prc_getuserorganisationname : GXProcedure
   {
      public prc_getuserorganisationname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getuserorganisationname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_OrganisationName )
      {
         this.AV13OrganisationName = "" ;
         initialize();
         ExecuteImpl();
         aP0_OrganisationName=this.AV13OrganisationName;
      }

      public string executeUdp( )
      {
         execute(out aP0_OrganisationName);
         return AV13OrganisationName ;
      }

      public void executeSubmit( out string aP0_OrganisationName )
      {
         this.AV13OrganisationName = "" ;
         SubmitImpl();
         aP0_OrganisationName=this.AV13OrganisationName;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtGAMUser1 = AV10GAMUser;
         new prc_getloggedinuser(context ).execute( out  GXt_SdtGAMUser1) ;
         AV10GAMUser = GXt_SdtGAMUser1;
         if ( AV10GAMUser.checkrole("Organisation Manager") )
         {
            /* Using cursor P00AB2 */
            pr_default.execute(0, new Object[] {AV10GAMUser.gxTpr_Email, AV10GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A11OrganisationId = P00AB2_A11OrganisationId[0];
               A25ManagerEmail = P00AB2_A25ManagerEmail[0];
               A28ManagerGAMGUID = P00AB2_A28ManagerGAMGUID[0];
               A13OrganisationName = P00AB2_A13OrganisationName[0];
               A21ManagerId = P00AB2_A21ManagerId[0];
               A13OrganisationName = P00AB2_A13OrganisationName[0];
               AV13OrganisationName = A13OrganisationName;
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         if ( AV10GAMUser.checkrole("Receptionist") )
         {
            /* Using cursor P00AB3 */
            pr_default.execute(1, new Object[] {AV10GAMUser.gxTpr_Email, AV10GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A11OrganisationId = P00AB3_A11OrganisationId[0];
               A13OrganisationName = P00AB3_A13OrganisationName[0];
               A93ReceptionistEmail = P00AB3_A93ReceptionistEmail[0];
               A95ReceptionistGAMGUID = P00AB3_A95ReceptionistGAMGUID[0];
               A29LocationId = P00AB3_A29LocationId[0];
               A89ReceptionistId = P00AB3_A89ReceptionistId[0];
               A13OrganisationName = P00AB3_A13OrganisationName[0];
               AV12LocationId = A29LocationId;
               /* Using cursor P00AB4 */
               pr_default.execute(2, new Object[] {AV12LocationId, A11OrganisationId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A29LocationId = P00AB4_A29LocationId[0];
                  AV13OrganisationName = A13OrganisationName;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
               pr_default.readNext(1);
            }
            pr_default.close(1);
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
         AV13OrganisationName = "";
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser1 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         P00AB2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00AB2_A25ManagerEmail = new string[] {""} ;
         P00AB2_A28ManagerGAMGUID = new string[] {""} ;
         P00AB2_A13OrganisationName = new string[] {""} ;
         P00AB2_A21ManagerId = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A25ManagerEmail = "";
         A28ManagerGAMGUID = "";
         A13OrganisationName = "";
         A21ManagerId = Guid.Empty;
         P00AB3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00AB3_A13OrganisationName = new string[] {""} ;
         P00AB3_A93ReceptionistEmail = new string[] {""} ;
         P00AB3_A95ReceptionistGAMGUID = new string[] {""} ;
         P00AB3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00AB3_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         A93ReceptionistEmail = "";
         A95ReceptionistGAMGUID = "";
         A29LocationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         AV12LocationId = Guid.Empty;
         P00AB4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00AB4_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getuserorganisationname__default(),
            new Object[][] {
                new Object[] {
               P00AB2_A11OrganisationId, P00AB2_A25ManagerEmail, P00AB2_A28ManagerGAMGUID, P00AB2_A13OrganisationName, P00AB2_A21ManagerId
               }
               , new Object[] {
               P00AB3_A11OrganisationId, P00AB3_A13OrganisationName, P00AB3_A93ReceptionistEmail, P00AB3_A95ReceptionistGAMGUID, P00AB3_A29LocationId, P00AB3_A89ReceptionistId
               }
               , new Object[] {
               P00AB4_A11OrganisationId, P00AB4_A29LocationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV13OrganisationName ;
      private string A25ManagerEmail ;
      private string A28ManagerGAMGUID ;
      private string A13OrganisationName ;
      private string A93ReceptionistEmail ;
      private string A95ReceptionistGAMGUID ;
      private Guid A11OrganisationId ;
      private Guid A21ManagerId ;
      private Guid A29LocationId ;
      private Guid A89ReceptionistId ;
      private Guid AV12LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser1 ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00AB2_A11OrganisationId ;
      private string[] P00AB2_A25ManagerEmail ;
      private string[] P00AB2_A28ManagerGAMGUID ;
      private string[] P00AB2_A13OrganisationName ;
      private Guid[] P00AB2_A21ManagerId ;
      private Guid[] P00AB3_A11OrganisationId ;
      private string[] P00AB3_A13OrganisationName ;
      private string[] P00AB3_A93ReceptionistEmail ;
      private string[] P00AB3_A95ReceptionistGAMGUID ;
      private Guid[] P00AB3_A29LocationId ;
      private Guid[] P00AB3_A89ReceptionistId ;
      private Guid[] P00AB4_A11OrganisationId ;
      private Guid[] P00AB4_A29LocationId ;
      private string aP0_OrganisationName ;
   }

   public class prc_getuserorganisationname__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AB2;
          prmP00AB2 = new Object[] {
          new ParDef("AV10GAMUser__Email",GXType.VarChar,100,0) ,
          new ParDef("AV10GAMUser__Guid",GXType.Char,40,0)
          };
          Object[] prmP00AB3;
          prmP00AB3 = new Object[] {
          new ParDef("AV10GAMUser__Email",GXType.VarChar,100,0) ,
          new ParDef("AV10GAMUser__Guid",GXType.Char,40,0)
          };
          Object[] prmP00AB4;
          prmP00AB4 = new Object[] {
          new ParDef("AV12LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AB2", "SELECT T1.OrganisationId, T1.ManagerEmail, T1.ManagerGAMGUID, T2.OrganisationName, T1.ManagerId FROM (Trn_Manager T1 INNER JOIN Trn_Organisation T2 ON T2.OrganisationId = T1.OrganisationId) WHERE (LOWER(T1.ManagerEmail) = ( :AV10GAMUser__Email)) AND (T1.ManagerGAMGUID = ( :AV10GAMUser__Guid)) ORDER BY T1.ManagerId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AB2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AB3", "SELECT T1.OrganisationId, T2.OrganisationName, T1.ReceptionistEmail, T1.ReceptionistGAMGUID, T1.LocationId, T1.ReceptionistId FROM (Trn_Receptionist T1 INNER JOIN Trn_Organisation T2 ON T2.OrganisationId = T1.OrganisationId) WHERE (LOWER(T1.ReceptionistEmail) = ( :AV10GAMUser__Email)) AND (T1.ReceptionistGAMGUID = ( :AV10GAMUser__Guid)) ORDER BY T1.ReceptionistId, T1.OrganisationId, T1.LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AB3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AB4", "SELECT OrganisationId, LocationId FROM Trn_Location WHERE LocationId = :AV12LocationId and OrganisationId = :OrganisationId ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AB4,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
       }
    }

 }

}
