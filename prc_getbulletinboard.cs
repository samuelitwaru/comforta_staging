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
   public class prc_getbulletinboard : GXProcedure
   {
      public prc_getbulletinboard( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getbulletinboard( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_BulletinBoardId ,
                           out SdtSDT_BulletinBoard aP1_SDT_BulletinBoard )
      {
         this.AV9BulletinBoardId = aP0_BulletinBoardId;
         this.AV8SDT_BulletinBoard = new SdtSDT_BulletinBoard(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_BulletinBoard=this.AV8SDT_BulletinBoard;
      }

      public SdtSDT_BulletinBoard executeUdp( Guid aP0_BulletinBoardId )
      {
         execute(aP0_BulletinBoardId, out aP1_SDT_BulletinBoard);
         return AV8SDT_BulletinBoard ;
      }

      public void executeSubmit( Guid aP0_BulletinBoardId ,
                                 out SdtSDT_BulletinBoard aP1_SDT_BulletinBoard )
      {
         this.AV9BulletinBoardId = aP0_BulletinBoardId;
         this.AV8SDT_BulletinBoard = new SdtSDT_BulletinBoard(context) ;
         SubmitImpl();
         aP1_SDT_BulletinBoard=this.AV8SDT_BulletinBoard;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00D02 */
         pr_default.execute(0, new Object[] {AV9BulletinBoardId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A574BulletinBoardId = P00D02_A574BulletinBoardId[0];
            A11OrganisationId = P00D02_A11OrganisationId[0];
            A29LocationId = P00D02_A29LocationId[0];
            A585BulletinBoardBgColorCode = P00D02_A585BulletinBoardBgColorCode[0];
            A586BulletinBoardForm = P00D02_A586BulletinBoardForm[0];
            AV8SDT_BulletinBoard = new SdtSDT_BulletinBoard(context);
            AV8SDT_BulletinBoard.gxTpr_Bulletinboardid = A574BulletinBoardId;
            AV8SDT_BulletinBoard.gxTpr_Organisationid = A11OrganisationId;
            AV8SDT_BulletinBoard.gxTpr_Locationid = A29LocationId;
            AV8SDT_BulletinBoard.gxTpr_Bulletinboardbgcolorcode = A585BulletinBoardBgColorCode;
            AV8SDT_BulletinBoard.gxTpr_Bulletinboardform = A586BulletinBoardForm;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
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
         AV8SDT_BulletinBoard = new SdtSDT_BulletinBoard(context);
         P00D02_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         P00D02_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00D02_A29LocationId = new Guid[] {Guid.Empty} ;
         P00D02_A585BulletinBoardBgColorCode = new string[] {""} ;
         P00D02_A586BulletinBoardForm = new string[] {""} ;
         A574BulletinBoardId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A585BulletinBoardBgColorCode = "";
         A586BulletinBoardForm = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getbulletinboard__default(),
            new Object[][] {
                new Object[] {
               P00D02_A574BulletinBoardId, P00D02_A11OrganisationId, P00D02_A29LocationId, P00D02_A585BulletinBoardBgColorCode, P00D02_A586BulletinBoardForm
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A586BulletinBoardForm ;
      private string A585BulletinBoardBgColorCode ;
      private Guid AV9BulletinBoardId ;
      private Guid A574BulletinBoardId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_BulletinBoard AV8SDT_BulletinBoard ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00D02_A574BulletinBoardId ;
      private Guid[] P00D02_A11OrganisationId ;
      private Guid[] P00D02_A29LocationId ;
      private string[] P00D02_A585BulletinBoardBgColorCode ;
      private string[] P00D02_A586BulletinBoardForm ;
      private SdtSDT_BulletinBoard aP1_SDT_BulletinBoard ;
   }

   public class prc_getbulletinboard__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00D02;
          prmP00D02 = new Object[] {
          new ParDef("AV9BulletinBoardId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D02", "SELECT BulletinBoardId, OrganisationId, LocationId, BulletinBoardBgColorCode, BulletinBoardForm FROM Trn_BulletinBoard WHERE BulletinBoardId = :AV9BulletinBoardId ORDER BY BulletinBoardId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D02,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                return;
       }
    }

 }

}
