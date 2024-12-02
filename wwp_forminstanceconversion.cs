using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class wwp_forminstanceconversion : GXProcedure
   {
      public wwp_forminstanceconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public wwp_forminstanceconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor WWP_FORMIN2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A243WWPFormInstanceRecordKey = WWP_FORMIN2_A243WWPFormInstanceRecordKey[0];
            n243WWPFormInstanceRecordKey = WWP_FORMIN2_n243WWPFormInstanceRecordKey[0];
            A112WWPUserExtendedId = WWP_FORMIN2_A112WWPUserExtendedId[0];
            A207WWPFormVersionNumber = WWP_FORMIN2_A207WWPFormVersionNumber[0];
            A206WWPFormId = WWP_FORMIN2_A206WWPFormId[0];
            A214WWPFormInstanceId = WWP_FORMIN2_A214WWPFormInstanceId[0];
            A239WWPFormInstanceDate = WWP_FORMIN2_A239WWPFormInstanceDate[0];
            A40001GXC2 = ( A239WWPFormInstanceDate);
            /*
               INSERT RECORD ON TABLE GXA0042

            */
            AV2WWPFormInstanceId = A214WWPFormInstanceId;
            AV3WWPFormInstanceDate = A40001GXC2;
            AV4WWPFormId = A206WWPFormId;
            AV5WWPFormVersionNumber = A207WWPFormVersionNumber;
            AV6WWPUserExtendedId = A112WWPUserExtendedId;
            if ( WWP_FORMIN2_n243WWPFormInstanceRecordKey[0] )
            {
               AV7WWPFormInstanceRecordKey = "";
               nV7WWPFormInstanceRecordKey = false;
               nV7WWPFormInstanceRecordKey = true;
            }
            else
            {
               AV7WWPFormInstanceRecordKey = A243WWPFormInstanceRecordKey;
               nV7WWPFormInstanceRecordKey = false;
            }
            /* Using cursor WWP_FORMIN3 */
            pr_default.execute(1, new Object[] {AV2WWPFormInstanceId, AV3WWPFormInstanceDate, AV4WWPFormId, AV5WWPFormVersionNumber, AV6WWPUserExtendedId, nV7WWPFormInstanceRecordKey, AV7WWPFormInstanceRecordKey});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0042");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
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
         WWP_FORMIN2_A243WWPFormInstanceRecordKey = new string[] {""} ;
         WWP_FORMIN2_n243WWPFormInstanceRecordKey = new bool[] {false} ;
         WWP_FORMIN2_A112WWPUserExtendedId = new string[] {""} ;
         WWP_FORMIN2_A207WWPFormVersionNumber = new short[1] ;
         WWP_FORMIN2_A206WWPFormId = new short[1] ;
         WWP_FORMIN2_A214WWPFormInstanceId = new int[1] ;
         WWP_FORMIN2_A239WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         A243WWPFormInstanceRecordKey = "";
         A112WWPUserExtendedId = "";
         A239WWPFormInstanceDate = DateTime.MinValue;
         A40001GXC2 = (DateTime)(DateTime.MinValue);
         AV3WWPFormInstanceDate = (DateTime)(DateTime.MinValue);
         AV6WWPUserExtendedId = "";
         AV7WWPFormInstanceRecordKey = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwp_forminstanceconversion__default(),
            new Object[][] {
                new Object[] {
               WWP_FORMIN2_A243WWPFormInstanceRecordKey, WWP_FORMIN2_n243WWPFormInstanceRecordKey, WWP_FORMIN2_A112WWPUserExtendedId, WWP_FORMIN2_A207WWPFormVersionNumber, WWP_FORMIN2_A206WWPFormId, WWP_FORMIN2_A214WWPFormInstanceId, WWP_FORMIN2_A239WWPFormInstanceDate
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A207WWPFormVersionNumber ;
      private short A206WWPFormId ;
      private short AV4WWPFormId ;
      private short AV5WWPFormVersionNumber ;
      private int A214WWPFormInstanceId ;
      private int GIGXA0042 ;
      private int AV2WWPFormInstanceId ;
      private string A112WWPUserExtendedId ;
      private string AV6WWPUserExtendedId ;
      private string Gx_emsg ;
      private DateTime A40001GXC2 ;
      private DateTime AV3WWPFormInstanceDate ;
      private DateTime A239WWPFormInstanceDate ;
      private bool n243WWPFormInstanceRecordKey ;
      private bool nV7WWPFormInstanceRecordKey ;
      private string A243WWPFormInstanceRecordKey ;
      private string AV7WWPFormInstanceRecordKey ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] WWP_FORMIN2_A243WWPFormInstanceRecordKey ;
      private bool[] WWP_FORMIN2_n243WWPFormInstanceRecordKey ;
      private string[] WWP_FORMIN2_A112WWPUserExtendedId ;
      private short[] WWP_FORMIN2_A207WWPFormVersionNumber ;
      private short[] WWP_FORMIN2_A206WWPFormId ;
      private int[] WWP_FORMIN2_A214WWPFormInstanceId ;
      private DateTime[] WWP_FORMIN2_A239WWPFormInstanceDate ;
   }

   public class wwp_forminstanceconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmWWP_FORMIN2;
          prmWWP_FORMIN2 = new Object[] {
          };
          Object[] prmWWP_FORMIN3;
          prmWWP_FORMIN3 = new Object[] {
          new ParDef("AV2WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("AV3WWPFormInstanceDate",GXType.DateTime,8,5) ,
          new ParDef("AV4WWPFormId",GXType.Int16,4,0) ,
          new ParDef("AV5WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("AV6WWPUserExtendedId",GXType.Char,40,0) ,
          new ParDef("AV7WWPFormInstanceRecordKey",GXType.LongVarChar,2097152,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("WWP_FORMIN2", "SELECT WWPFormInstanceRecordKey, WWPUserExtendedId, WWPFormVersionNumber, WWPFormId, WWPFormInstanceId, WWPFormInstanceDate FROM WWP_FormInstance ORDER BY WWPFormInstanceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmWWP_FORMIN2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("WWP_FORMIN3", "INSERT INTO GXA0042(WWPFormInstanceId, WWPFormInstanceDate, WWPFormId, WWPFormVersionNumber, WWPUserExtendedId, WWPFormInstanceRecordKey) VALUES(:AV2WWPFormInstanceId, :AV3WWPFormInstanceDate, :AV4WWPFormId, :AV5WWPFormVersionNumber, :AV6WWPUserExtendedId, :AV7WWPFormInstanceRecordKey)", GxErrorMask.GX_NOMASK,prmWWP_FORMIN3)
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
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 40);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                return;
       }
    }

 }

}
