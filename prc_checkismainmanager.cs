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
   public class prc_checkismainmanager : GXProcedure
   {
      public prc_checkismainmanager( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_checkismainmanager( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out bool aP0_isMainManager )
      {
         this.AV13isMainManager = false ;
         initialize();
         ExecuteImpl();
         aP0_isMainManager=this.AV13isMainManager;
      }

      public bool executeUdp( )
      {
         execute(out aP0_isMainManager);
         return AV13isMainManager ;
      }

      public void executeSubmit( out bool aP0_isMainManager )
      {
         this.AV13isMainManager = false ;
         SubmitImpl();
         aP0_isMainManager=this.AV13isMainManager;
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
            /* Using cursor P007P2 */
            pr_default.execute(0, new Object[] {AV10GAMUser.gxTpr_Email, AV10GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A25ManagerEmail = P007P2_A25ManagerEmail[0];
               A28ManagerGAMGUID = P007P2_A28ManagerGAMGUID[0];
               A360ManagerIsMainManager = P007P2_A360ManagerIsMainManager[0];
               A21ManagerId = P007P2_A21ManagerId[0];
               A11OrganisationId = P007P2_A11OrganisationId[0];
               AV13isMainManager = A360ManagerIsMainManager;
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
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser1 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         P007P2_A25ManagerEmail = new string[] {""} ;
         P007P2_A28ManagerGAMGUID = new string[] {""} ;
         P007P2_A360ManagerIsMainManager = new bool[] {false} ;
         P007P2_A21ManagerId = new Guid[] {Guid.Empty} ;
         P007P2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A25ManagerEmail = "";
         A28ManagerGAMGUID = "";
         A21ManagerId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_checkismainmanager__default(),
            new Object[][] {
                new Object[] {
               P007P2_A25ManagerEmail, P007P2_A28ManagerGAMGUID, P007P2_A360ManagerIsMainManager, P007P2_A21ManagerId, P007P2_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool AV13isMainManager ;
      private bool A360ManagerIsMainManager ;
      private string A25ManagerEmail ;
      private string A28ManagerGAMGUID ;
      private Guid A21ManagerId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser1 ;
      private IDataStoreProvider pr_default ;
      private string[] P007P2_A25ManagerEmail ;
      private string[] P007P2_A28ManagerGAMGUID ;
      private bool[] P007P2_A360ManagerIsMainManager ;
      private Guid[] P007P2_A21ManagerId ;
      private Guid[] P007P2_A11OrganisationId ;
      private bool aP0_isMainManager ;
   }

   public class prc_checkismainmanager__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007P2;
          prmP007P2 = new Object[] {
          new ParDef("AV10GAMUser__Email",GXType.VarChar,100,0) ,
          new ParDef("AV10GAMUser__Guid",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007P2", "SELECT ManagerEmail, ManagerGAMGUID, ManagerIsMainManager, ManagerId, OrganisationId FROM Trn_Manager WHERE (LOWER(ManagerEmail) = ( :AV10GAMUser__Email)) AND (ManagerGAMGUID = ( :AV10GAMUser__Guid)) ORDER BY ManagerId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007P2,100, GxCacheFrequency.OFF ,false,false )
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
       }
    }

 }

}
