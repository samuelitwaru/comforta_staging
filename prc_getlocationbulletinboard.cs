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
   public class prc_getlocationbulletinboard : GXProcedure
   {
      public prc_getlocationbulletinboard( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getlocationbulletinboard( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           out SdtSDT_BulletinBoard aP1_SDT_BulletinBoard )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV9SDT_BulletinBoard = new SdtSDT_BulletinBoard(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_BulletinBoard=this.AV9SDT_BulletinBoard;
      }

      public SdtSDT_BulletinBoard executeUdp( Guid aP0_LocationId )
      {
         execute(aP0_LocationId, out aP1_SDT_BulletinBoard);
         return AV9SDT_BulletinBoard ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 out SdtSDT_BulletinBoard aP1_SDT_BulletinBoard )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV9SDT_BulletinBoard = new SdtSDT_BulletinBoard(context) ;
         SubmitImpl();
         aP1_SDT_BulletinBoard=this.AV9SDT_BulletinBoard;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00D62 */
         pr_default.execute(0, new Object[] {AV8LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P00D62_A29LocationId[0];
            A574BulletinBoardId = P00D62_A574BulletinBoardId[0];
            A11OrganisationId = P00D62_A11OrganisationId[0];
            A585BulletinBoardBgColorCode = P00D62_A585BulletinBoardBgColorCode[0];
            A586BulletinBoardForm = P00D62_A586BulletinBoardForm[0];
            AV9SDT_BulletinBoard = new SdtSDT_BulletinBoard(context);
            AV9SDT_BulletinBoard.gxTpr_Bulletinboardid = A574BulletinBoardId;
            AV9SDT_BulletinBoard.gxTpr_Organisationid = A11OrganisationId;
            AV9SDT_BulletinBoard.gxTpr_Locationid = A29LocationId;
            AV9SDT_BulletinBoard.gxTpr_Bulletinboardbgcolorcode = A585BulletinBoardBgColorCode;
            AV9SDT_BulletinBoard.gxTpr_Bulletinboardform = A586BulletinBoardForm;
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
         AV9SDT_BulletinBoard = new SdtSDT_BulletinBoard(context);
         P00D62_A29LocationId = new Guid[] {Guid.Empty} ;
         P00D62_A574BulletinBoardId = new Guid[] {Guid.Empty} ;
         P00D62_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00D62_A585BulletinBoardBgColorCode = new string[] {""} ;
         P00D62_A586BulletinBoardForm = new string[] {""} ;
         A29LocationId = Guid.Empty;
         A574BulletinBoardId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A585BulletinBoardBgColorCode = "";
         A586BulletinBoardForm = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getlocationbulletinboard__default(),
            new Object[][] {
                new Object[] {
               P00D62_A29LocationId, P00D62_A574BulletinBoardId, P00D62_A11OrganisationId, P00D62_A585BulletinBoardBgColorCode, P00D62_A586BulletinBoardForm
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A586BulletinBoardForm ;
      private string A585BulletinBoardBgColorCode ;
      private Guid AV8LocationId ;
      private Guid A29LocationId ;
      private Guid A574BulletinBoardId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_BulletinBoard AV9SDT_BulletinBoard ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00D62_A29LocationId ;
      private Guid[] P00D62_A574BulletinBoardId ;
      private Guid[] P00D62_A11OrganisationId ;
      private string[] P00D62_A585BulletinBoardBgColorCode ;
      private string[] P00D62_A586BulletinBoardForm ;
      private SdtSDT_BulletinBoard aP1_SDT_BulletinBoard ;
   }

   public class prc_getlocationbulletinboard__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00D62;
          prmP00D62 = new Object[] {
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D62", "SELECT LocationId, BulletinBoardId, OrganisationId, BulletinBoardBgColorCode, BulletinBoardForm FROM Trn_BulletinBoard WHERE LocationId = :AV8LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D62,100, GxCacheFrequency.OFF ,false,false )
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
