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
   public class prc_getbulletinboards : GXProcedure
   {
      public prc_getbulletinboards( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getbulletinboards( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDT_BulletinBoard> aP0_SDT_BulletinBoards )
      {
         this.AV8SDT_BulletinBoards = new GXBaseCollection<SdtSDT_BulletinBoard>( context, "SDT_BulletinBoard", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_SDT_BulletinBoards=this.AV8SDT_BulletinBoards;
      }

      public GXBaseCollection<SdtSDT_BulletinBoard> executeUdp( )
      {
         execute(out aP0_SDT_BulletinBoards);
         return AV8SDT_BulletinBoards ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_BulletinBoard> aP0_SDT_BulletinBoards )
      {
         this.AV8SDT_BulletinBoards = new GXBaseCollection<SdtSDT_BulletinBoard>( context, "SDT_BulletinBoard", "Comforta_version2") ;
         SubmitImpl();
         aP0_SDT_BulletinBoards=this.AV8SDT_BulletinBoards;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00CZ2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A574BulletinBoardId = P00CZ2_A574BulletinBoardId[0];
            A11OrganisationId = P00CZ2_A11OrganisationId[0];
            A29LocationId = P00CZ2_A29LocationId[0];
            A585BulletinBoardBgColorCode = P00CZ2_A585BulletinBoardBgColorCode[0];
            A586BulletinBoardForm = P00CZ2_A586BulletinBoardForm[0];
            AV9SDT_BulletinBoard = new SdtSDT_BulletinBoard(context);
            AV9SDT_BulletinBoard.gxTpr_Bulletinboardid = A574BulletinBoardId;
            AV9SDT_BulletinBoard.gxTpr_Organisationid = A11OrganisationId;
            AV9SDT_BulletinBoard.gxTpr_Locationid = A29LocationId;
            AV9SDT_BulletinBoard.gxTpr_Bulletinboardbgcolorcode = A585BulletinBoardBgColorCode;
            AV9SDT_BulletinBoard.gxTpr_Bulletinboardform = A586BulletinBoardForm;
            AV8SDT_BulletinBoards.Add(AV9SDT_BulletinBoard, 0);
            pr_default.readNext(0);
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
         AV8SDT_BulletinBoards = new GXBaseCollection<SdtSDT_BulletinBoard>( context, "SDT_BulletinBoard", "Comforta_version2");
         P00CZ2_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         P00CZ2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00CZ2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00CZ2_A585BulletinBoardBgColorCode = new string[] {""} ;
         P00CZ2_A586BulletinBoardForm = new string[] {""} ;
         A574BulletinBoardId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A585BulletinBoardBgColorCode = "";
         A586BulletinBoardForm = "";
         AV9SDT_BulletinBoard = new SdtSDT_BulletinBoard(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getbulletinboards__default(),
            new Object[][] {
                new Object[] {
               P00CZ2_A574BulletinBoardId, P00CZ2_A11OrganisationId, P00CZ2_A29LocationId, P00CZ2_A585BulletinBoardBgColorCode, P00CZ2_A586BulletinBoardForm
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A586BulletinBoardForm ;
      private string A585BulletinBoardBgColorCode ;
      private Guid A574BulletinBoardId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_BulletinBoard> AV8SDT_BulletinBoards ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00CZ2_A574BulletinBoardId ;
      private Guid[] P00CZ2_A11OrganisationId ;
      private Guid[] P00CZ2_A29LocationId ;
      private string[] P00CZ2_A585BulletinBoardBgColorCode ;
      private string[] P00CZ2_A586BulletinBoardForm ;
      private SdtSDT_BulletinBoard AV9SDT_BulletinBoard ;
      private GXBaseCollection<SdtSDT_BulletinBoard> aP0_SDT_BulletinBoards ;
   }

   public class prc_getbulletinboards__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00CZ2;
          prmP00CZ2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00CZ2", "SELECT BulletinBoardId, OrganisationId, LocationId, BulletinBoardBgColorCode, BulletinBoardForm FROM Trn_BulletinBoard ORDER BY BulletinBoardId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CZ2,100, GxCacheFrequency.OFF ,false,false )
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
