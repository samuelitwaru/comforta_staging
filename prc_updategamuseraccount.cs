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
   public class prc_updategamuseraccount : GXProcedure
   {
      public prc_updategamuseraccount( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updategamuseraccount( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserGAMGUID ,
                           string aP1_GivenName ,
                           string aP2_LastName ,
                           string aP3_Role ,
                           out string aP4_GAMErrorResponse )
      {
         this.AV12UserGAMGUID = aP0_UserGAMGUID;
         this.AV10GivenName = aP1_GivenName;
         this.AV11LastName = aP2_LastName;
         this.AV15Role = aP3_Role;
         this.AV8GAMErrorResponse = "" ;
         initialize();
         ExecuteImpl();
         aP4_GAMErrorResponse=this.AV8GAMErrorResponse;
      }

      public string executeUdp( string aP0_UserGAMGUID ,
                                string aP1_GivenName ,
                                string aP2_LastName ,
                                string aP3_Role )
      {
         execute(aP0_UserGAMGUID, aP1_GivenName, aP2_LastName, aP3_Role, out aP4_GAMErrorResponse);
         return AV8GAMErrorResponse ;
      }

      public void executeSubmit( string aP0_UserGAMGUID ,
                                 string aP1_GivenName ,
                                 string aP2_LastName ,
                                 string aP3_Role ,
                                 out string aP4_GAMErrorResponse )
      {
         this.AV12UserGAMGUID = aP0_UserGAMGUID;
         this.AV10GivenName = aP1_GivenName;
         this.AV11LastName = aP2_LastName;
         this.AV15Role = aP3_Role;
         this.AV8GAMErrorResponse = "" ;
         SubmitImpl();
         aP4_GAMErrorResponse=this.AV8GAMErrorResponse;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9GAMUser.load( AV12UserGAMGUID);
         AV9GAMUser.gxTpr_Firstname = AV10GivenName;
         AV9GAMUser.gxTpr_Lastname = AV11LastName;
         if ( StringUtil.StrCmp(AV15Role, "Organisation Manager") == 0 )
         {
            new prc_logtofile(context ).execute(  context.GetMessage( "Manager is role", "")) ;
            /* Using cursor P006B2 */
            pr_default.execute(0, new Object[] {AV9GAMUser.gxTpr_Email, AV9GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A25ManagerEmail = P006B2_A25ManagerEmail[0];
               A28ManagerGAMGUID = P006B2_A28ManagerGAMGUID[0];
               A394ManagerIsActive = P006B2_A394ManagerIsActive[0];
               A21ManagerId = P006B2_A21ManagerId[0];
               A11OrganisationId = P006B2_A11OrganisationId[0];
               AV14IsActive = A394ManagerIsActive;
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         if ( StringUtil.StrCmp(AV15Role, "Receptionist") == 0 )
         {
            new prc_logtofile(context ).execute(  context.GetMessage( "Receptionist is role", "")) ;
            /* Using cursor P006B3 */
            pr_default.execute(1, new Object[] {AV9GAMUser.gxTpr_Email, AV9GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A93ReceptionistEmail = P006B3_A93ReceptionistEmail[0];
               A95ReceptionistGAMGUID = P006B3_A95ReceptionistGAMGUID[0];
               A398ReceptionistIsActive = P006B3_A398ReceptionistIsActive[0];
               A89ReceptionistId = P006B3_A89ReceptionistId[0];
               A11OrganisationId = P006B3_A11OrganisationId[0];
               A29LocationId = P006B3_A29LocationId[0];
               AV14IsActive = A398ReceptionistIsActive;
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         if ( StringUtil.StrCmp(AV15Role, "Resident") == 0 )
         {
            new prc_logtofile(context ).execute(  context.GetMessage( "Resident is role", "")) ;
            /* Using cursor P006B4 */
            pr_default.execute(2, new Object[] {AV9GAMUser.gxTpr_Email, AV9GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A67ResidentEmail = P006B4_A67ResidentEmail[0];
               A71ResidentGUID = P006B4_A71ResidentGUID[0];
               A62ResidentId = P006B4_A62ResidentId[0];
               A29LocationId = P006B4_A29LocationId[0];
               A11OrganisationId = P006B4_A11OrganisationId[0];
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         if ( ( AV14IsActive ) && ( AV9GAMUser.gxTpr_Isblocked ) )
         {
            AV9GAMUser.unblockaccess(out  AV13GAMErrorCollection);
         }
         if ( ! AV14IsActive && ! AV9GAMUser.gxTpr_Isblocked )
         {
            AV9GAMUser.blockaccess( false,  false, out  AV13GAMErrorCollection);
         }
         AV9GAMUser.save();
         if ( AV9GAMUser.success() )
         {
            context.CommitDataStores("prc_updategamuseraccount",pr_default);
         }
         else
         {
            AV8GAMErrorResponse = AV9GAMUser.geterrors().ToJSonString(false);
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
         AV8GAMErrorResponse = "";
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         P006B2_A25ManagerEmail = new string[] {""} ;
         P006B2_A28ManagerGAMGUID = new string[] {""} ;
         P006B2_A394ManagerIsActive = new bool[] {false} ;
         P006B2_A21ManagerId = new Guid[] {Guid.Empty} ;
         P006B2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A25ManagerEmail = "";
         A28ManagerGAMGUID = "";
         A21ManagerId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         P006B3_A93ReceptionistEmail = new string[] {""} ;
         P006B3_A95ReceptionistGAMGUID = new string[] {""} ;
         P006B3_A398ReceptionistIsActive = new bool[] {false} ;
         P006B3_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P006B3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006B3_A29LocationId = new Guid[] {Guid.Empty} ;
         A93ReceptionistEmail = "";
         A95ReceptionistGAMGUID = "";
         A89ReceptionistId = Guid.Empty;
         A29LocationId = Guid.Empty;
         P006B4_A67ResidentEmail = new string[] {""} ;
         P006B4_A71ResidentGUID = new string[] {""} ;
         P006B4_A62ResidentId = new Guid[] {Guid.Empty} ;
         P006B4_A29LocationId = new Guid[] {Guid.Empty} ;
         P006B4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A67ResidentEmail = "";
         A71ResidentGUID = "";
         A62ResidentId = Guid.Empty;
         AV13GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updategamuseraccount__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updategamuseraccount__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updategamuseraccount__default(),
            new Object[][] {
                new Object[] {
               P006B2_A25ManagerEmail, P006B2_A28ManagerGAMGUID, P006B2_A394ManagerIsActive, P006B2_A21ManagerId, P006B2_A11OrganisationId
               }
               , new Object[] {
               P006B3_A93ReceptionistEmail, P006B3_A95ReceptionistGAMGUID, P006B3_A398ReceptionistIsActive, P006B3_A89ReceptionistId, P006B3_A11OrganisationId, P006B3_A29LocationId
               }
               , new Object[] {
               P006B4_A67ResidentEmail, P006B4_A71ResidentGUID, P006B4_A62ResidentId, P006B4_A29LocationId, P006B4_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV15Role ;
      private bool A394ManagerIsActive ;
      private bool AV14IsActive ;
      private bool A398ReceptionistIsActive ;
      private string AV8GAMErrorResponse ;
      private string AV12UserGAMGUID ;
      private string AV10GivenName ;
      private string AV11LastName ;
      private string A25ManagerEmail ;
      private string A28ManagerGAMGUID ;
      private string A93ReceptionistEmail ;
      private string A95ReceptionistGAMGUID ;
      private string A67ResidentEmail ;
      private string A71ResidentGUID ;
      private Guid A21ManagerId ;
      private Guid A11OrganisationId ;
      private Guid A89ReceptionistId ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private IDataStoreProvider pr_default ;
      private string[] P006B2_A25ManagerEmail ;
      private string[] P006B2_A28ManagerGAMGUID ;
      private bool[] P006B2_A394ManagerIsActive ;
      private Guid[] P006B2_A21ManagerId ;
      private Guid[] P006B2_A11OrganisationId ;
      private string[] P006B3_A93ReceptionistEmail ;
      private string[] P006B3_A95ReceptionistGAMGUID ;
      private bool[] P006B3_A398ReceptionistIsActive ;
      private Guid[] P006B3_A89ReceptionistId ;
      private Guid[] P006B3_A11OrganisationId ;
      private Guid[] P006B3_A29LocationId ;
      private string[] P006B4_A67ResidentEmail ;
      private string[] P006B4_A71ResidentGUID ;
      private Guid[] P006B4_A62ResidentId ;
      private Guid[] P006B4_A29LocationId ;
      private Guid[] P006B4_A11OrganisationId ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV13GAMErrorCollection ;
      private string aP4_GAMErrorResponse ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updategamuseraccount__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updategamuseraccount__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updategamuseraccount__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP006B2;
       prmP006B2 = new Object[] {
       new ParDef("AV9GAMUser__Email",GXType.VarChar,100,0) ,
       new ParDef("AV9GAMUser__Guid",GXType.Char,40,0)
       };
       Object[] prmP006B3;
       prmP006B3 = new Object[] {
       new ParDef("AV9GAMUser__Email",GXType.VarChar,100,0) ,
       new ParDef("AV9GAMUser__Guid",GXType.Char,40,0)
       };
       Object[] prmP006B4;
       prmP006B4 = new Object[] {
       new ParDef("AV9GAMUser__Email",GXType.VarChar,100,0) ,
       new ParDef("AV9GAMUser__Guid",GXType.Char,40,0)
       };
       def= new CursorDef[] {
           new CursorDef("P006B2", "SELECT ManagerEmail, ManagerGAMGUID, ManagerIsActive, ManagerId, OrganisationId FROM Trn_Manager WHERE (LOWER(ManagerEmail) = ( :AV9GAMUser__Email)) AND (ManagerGAMGUID = ( :AV9GAMUser__Guid)) ORDER BY ManagerId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B2,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("P006B3", "SELECT ReceptionistEmail, ReceptionistGAMGUID, ReceptionistIsActive, ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist WHERE (LOWER(ReceptionistEmail) = ( :AV9GAMUser__Email)) AND (ReceptionistGAMGUID = ( :AV9GAMUser__Guid)) ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B3,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("P006B4", "SELECT ResidentEmail, ResidentGUID, ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE (LOWER(ResidentEmail) = ( :AV9GAMUser__Email)) AND (ResidentGUID = ( :AV9GAMUser__Guid)) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B4,100, GxCacheFrequency.OFF ,false,false )
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
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             return;
          case 2 :
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
