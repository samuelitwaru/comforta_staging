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
   public class prc_getuserlocationname : GXProcedure
   {
      public prc_getuserlocationname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getuserlocationname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_LocationName )
      {
         this.AV10LocationName = "" ;
         initialize();
         ExecuteImpl();
         aP0_LocationName=this.AV10LocationName;
      }

      public string executeUdp( )
      {
         execute(out aP0_LocationName);
         return AV10LocationName ;
      }

      public void executeSubmit( out string aP0_LocationName )
      {
         this.AV10LocationName = "" ;
         SubmitImpl();
         aP0_LocationName=this.AV10LocationName;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtGAMUser1 = AV9GAMUser;
         new prc_getloggedinuser(context ).execute( out  GXt_SdtGAMUser1) ;
         AV9GAMUser = GXt_SdtGAMUser1;
         if ( AV9GAMUser.checkrole("Receptionist") )
         {
            /* Using cursor P00AC2 */
            pr_default.execute(0, new Object[] {AV9GAMUser.gxTpr_Email, AV9GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A29LocationId = P00AC2_A29LocationId[0];
               A11OrganisationId = P00AC2_A11OrganisationId[0];
               A93ReceptionistEmail = P00AC2_A93ReceptionistEmail[0];
               A95ReceptionistGAMGUID = P00AC2_A95ReceptionistGAMGUID[0];
               A31LocationName = P00AC2_A31LocationName[0];
               A89ReceptionistId = P00AC2_A89ReceptionistId[0];
               A31LocationName = P00AC2_A31LocationName[0];
               AV10LocationName = A31LocationName;
               pr_default.readNext(0);
            }
            pr_default.close(0);
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
         AV10LocationName = "";
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser1 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         P00AC2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00AC2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00AC2_A93ReceptionistEmail = new string[] {""} ;
         P00AC2_A95ReceptionistGAMGUID = new string[] {""} ;
         P00AC2_A31LocationName = new string[] {""} ;
         P00AC2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A93ReceptionistEmail = "";
         A95ReceptionistGAMGUID = "";
         A31LocationName = "";
         A89ReceptionistId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getuserlocationname__default(),
            new Object[][] {
                new Object[] {
               P00AC2_A29LocationId, P00AC2_A11OrganisationId, P00AC2_A93ReceptionistEmail, P00AC2_A95ReceptionistGAMGUID, P00AC2_A31LocationName, P00AC2_A89ReceptionistId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV10LocationName ;
      private string A93ReceptionistEmail ;
      private string A95ReceptionistGAMGUID ;
      private string A31LocationName ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A89ReceptionistId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser1 ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00AC2_A29LocationId ;
      private Guid[] P00AC2_A11OrganisationId ;
      private string[] P00AC2_A93ReceptionistEmail ;
      private string[] P00AC2_A95ReceptionistGAMGUID ;
      private string[] P00AC2_A31LocationName ;
      private Guid[] P00AC2_A89ReceptionistId ;
      private string aP0_LocationName ;
   }

   public class prc_getuserlocationname__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AC2;
          prmP00AC2 = new Object[] {
          new ParDef("AV9GAMUser__Email",GXType.VarChar,100,0) ,
          new ParDef("AV9GAMUser__Guid",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AC2", "SELECT T1.LocationId, T1.OrganisationId, T1.ReceptionistEmail, T1.ReceptionistGAMGUID, T2.LocationName, T1.ReceptionistId FROM (Trn_Receptionist T1 INNER JOIN Trn_Location T2 ON T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) WHERE (LOWER(T1.ReceptionistEmail) = ( :AV9GAMUser__Email)) AND (T1.ReceptionistGAMGUID = ( :AV9GAMUser__Guid)) ORDER BY T1.ReceptionistId, T1.OrganisationId, T1.LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AC2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                return;
       }
    }

 }

}
