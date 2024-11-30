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
   public class prc_updateuseraccountstatus : GXProcedure
   {
      public prc_updateuseraccountstatus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updateuseraccountstatus( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserGUID )
      {
         this.AV14UserGUID = aP0_UserGUID;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_UserGUID )
      {
         this.AV14UserGUID = aP0_UserGUID;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8GAMUser.load( AV14UserGUID);
         if ( AV8GAMUser.checkrole("Organisation Manager") )
         {
            /* Using cursor P007Z2 */
            pr_default.execute(0, new Object[] {AV8GAMUser.gxTpr_Email, AV8GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A25ManagerEmail = P007Z2_A25ManagerEmail[0];
               A28ManagerGAMGUID = P007Z2_A28ManagerGAMGUID[0];
               A11OrganisationId = P007Z2_A11OrganisationId[0];
               A21ManagerId = P007Z2_A21ManagerId[0];
               AV13Trn_Manager.Load(A21ManagerId, A11OrganisationId);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV13Trn_Manager.gxTpr_Managerisactive = true;
            AV13Trn_Manager.Save();
         }
         else
         {
            if ( AV8GAMUser.checkrole("Receptionist") )
            {
               /* Using cursor P007Z3 */
               pr_default.execute(1, new Object[] {AV8GAMUser.gxTpr_Email, AV8GAMUser.gxTpr_Guid});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A93ReceptionistEmail = P007Z3_A93ReceptionistEmail[0];
                  A95ReceptionistGAMGUID = P007Z3_A95ReceptionistGAMGUID[0];
                  A29LocationId = P007Z3_A29LocationId[0];
                  A11OrganisationId = P007Z3_A11OrganisationId[0];
                  A89ReceptionistId = P007Z3_A89ReceptionistId[0];
                  AV9Trn_Receptionist.Load(A89ReceptionistId, A11OrganisationId, A29LocationId);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV9Trn_Receptionist.gxTpr_Receptionistisactive = true;
               AV9Trn_Receptionist.Save();
            }
         }
         if ( AV13Trn_Manager.Success() || AV9Trn_Receptionist.Success() )
         {
            context.CommitDataStores("prc_updateuseraccountstatus",pr_default);
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
         AV8GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         P007Z2_A25ManagerEmail = new string[] {""} ;
         P007Z2_A28ManagerGAMGUID = new string[] {""} ;
         P007Z2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007Z2_A21ManagerId = new Guid[] {Guid.Empty} ;
         A25ManagerEmail = "";
         A28ManagerGAMGUID = "";
         A11OrganisationId = Guid.Empty;
         A21ManagerId = Guid.Empty;
         AV13Trn_Manager = new SdtTrn_Manager(context);
         P007Z3_A93ReceptionistEmail = new string[] {""} ;
         P007Z3_A95ReceptionistGAMGUID = new string[] {""} ;
         P007Z3_A29LocationId = new Guid[] {Guid.Empty} ;
         P007Z3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007Z3_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         A93ReceptionistEmail = "";
         A95ReceptionistGAMGUID = "";
         A29LocationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         AV9Trn_Receptionist = new SdtTrn_Receptionist(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updateuseraccountstatus__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updateuseraccountstatus__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updateuseraccountstatus__default(),
            new Object[][] {
                new Object[] {
               P007Z2_A25ManagerEmail, P007Z2_A28ManagerGAMGUID, P007Z2_A11OrganisationId, P007Z2_A21ManagerId
               }
               , new Object[] {
               P007Z3_A93ReceptionistEmail, P007Z3_A95ReceptionistGAMGUID, P007Z3_A29LocationId, P007Z3_A11OrganisationId, P007Z3_A89ReceptionistId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV14UserGUID ;
      private string A25ManagerEmail ;
      private string A28ManagerGAMGUID ;
      private string A93ReceptionistEmail ;
      private string A95ReceptionistGAMGUID ;
      private Guid A11OrganisationId ;
      private Guid A21ManagerId ;
      private Guid A29LocationId ;
      private Guid A89ReceptionistId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV8GAMUser ;
      private IDataStoreProvider pr_default ;
      private string[] P007Z2_A25ManagerEmail ;
      private string[] P007Z2_A28ManagerGAMGUID ;
      private Guid[] P007Z2_A11OrganisationId ;
      private Guid[] P007Z2_A21ManagerId ;
      private SdtTrn_Manager AV13Trn_Manager ;
      private string[] P007Z3_A93ReceptionistEmail ;
      private string[] P007Z3_A95ReceptionistGAMGUID ;
      private Guid[] P007Z3_A29LocationId ;
      private Guid[] P007Z3_A11OrganisationId ;
      private Guid[] P007Z3_A89ReceptionistId ;
      private SdtTrn_Receptionist AV9Trn_Receptionist ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updateuseraccountstatus__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updateuseraccountstatus__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updateuseraccountstatus__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP007Z2;
       prmP007Z2 = new Object[] {
       new ParDef("AV8GAMUser__Email",GXType.VarChar,100,0) ,
       new ParDef("AV8GAMUser__Guid",GXType.Char,40,0)
       };
       Object[] prmP007Z3;
       prmP007Z3 = new Object[] {
       new ParDef("AV8GAMUser__Email",GXType.VarChar,100,0) ,
       new ParDef("AV8GAMUser__Guid",GXType.Char,40,0)
       };
       def= new CursorDef[] {
           new CursorDef("P007Z2", "SELECT ManagerEmail, ManagerGAMGUID, OrganisationId, ManagerId FROM Trn_Manager WHERE (LOWER(ManagerEmail) = ( :AV8GAMUser__Email)) AND (ManagerGAMGUID = ( :AV8GAMUser__Guid)) ORDER BY ManagerId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Z2,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P007Z3", "SELECT ReceptionistEmail, ReceptionistGAMGUID, LocationId, OrganisationId, ReceptionistId FROM Trn_Receptionist WHERE (LOWER(ReceptionistEmail) = ( :AV8GAMUser__Email)) AND (ReceptionistGAMGUID = ( :AV8GAMUser__Guid)) ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Z3,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
    }
 }

}

}
