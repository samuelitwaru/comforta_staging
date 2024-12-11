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
   public class trn_mediaconversion : GXProcedure
   {
      public trn_mediaconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_mediaconversion( IGxContext context )
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
         /* Using cursor TRN_MEDIAC2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A414MediaType = TRN_MEDIAC2_A414MediaType[0];
            A413MediaSize = TRN_MEDIAC2_A413MediaSize[0];
            A412MediaUrl = TRN_MEDIAC2_A412MediaUrl[0];
            A410MediaName = TRN_MEDIAC2_A410MediaName[0];
            A409MediaId = TRN_MEDIAC2_A409MediaId[0];
            A40000MediaImage_GXI = TRN_MEDIAC2_A40000MediaImage_GXI[0];
            n40000MediaImage_GXI = TRN_MEDIAC2_n40000MediaImage_GXI[0];
            A411MediaImage = TRN_MEDIAC2_A411MediaImage[0];
            n411MediaImage = TRN_MEDIAC2_n411MediaImage[0];
            /*
               INSERT RECORD ON TABLE GXA0083

            */
            AV2MediaId = A409MediaId;
            AV3MediaName = A410MediaName;
            if ( TRN_MEDIAC2_n411MediaImage[0] )
            {
               AV4MediaImage = "";
               nV4MediaImage = false;
               nV4MediaImage = true;
            }
            else
            {
               AV4MediaImage = A411MediaImage;
               nV4MediaImage = false;
               AV5MediaImage_GXI = A40000MediaImage_GXI;
               nV5MediaImage_GXI = false;
            }
            if ( TRN_MEDIAC2_n40000MediaImage_GXI[0] )
            {
               AV5MediaImage_GXI = "";
               nV5MediaImage_GXI = false;
               nV5MediaImage_GXI = true;
            }
            else
            {
               AV5MediaImage_GXI = A40000MediaImage_GXI;
               nV5MediaImage_GXI = false;
            }
            AV6MediaUrl = A412MediaUrl;
            AV7MediaSize = A413MediaSize;
            AV8MediaType = A414MediaType;
            AV9LocationId = Guid.Empty;
            /* Using cursor TRN_MEDIAC3 */
            pr_default.execute(1, new Object[] {AV2MediaId, AV3MediaName, nV4MediaImage, AV4MediaImage, nV5MediaImage_GXI, AV5MediaImage_GXI, AV6MediaUrl, AV7MediaSize, AV8MediaType, AV9LocationId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0083");
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
         TRN_MEDIAC2_A414MediaType = new string[] {""} ;
         TRN_MEDIAC2_A413MediaSize = new int[1] ;
         TRN_MEDIAC2_A412MediaUrl = new string[] {""} ;
         TRN_MEDIAC2_A410MediaName = new string[] {""} ;
         TRN_MEDIAC2_A409MediaId = new Guid[] {Guid.Empty} ;
         TRN_MEDIAC2_A40000MediaImage_GXI = new string[] {""} ;
         TRN_MEDIAC2_n40000MediaImage_GXI = new bool[] {false} ;
         TRN_MEDIAC2_A411MediaImage = new string[] {""} ;
         TRN_MEDIAC2_n411MediaImage = new bool[] {false} ;
         A414MediaType = "";
         A412MediaUrl = "";
         A410MediaName = "";
         A409MediaId = Guid.Empty;
         A40000MediaImage_GXI = "";
         A411MediaImage = "";
         AV2MediaId = Guid.Empty;
         AV3MediaName = "";
         AV4MediaImage = "";
         AV5MediaImage_GXI = "";
         AV6MediaUrl = "";
         AV8MediaType = "";
         AV9LocationId = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_mediaconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_MEDIAC2_A414MediaType, TRN_MEDIAC2_A413MediaSize, TRN_MEDIAC2_A412MediaUrl, TRN_MEDIAC2_A410MediaName, TRN_MEDIAC2_A409MediaId, TRN_MEDIAC2_A40000MediaImage_GXI, TRN_MEDIAC2_n40000MediaImage_GXI, TRN_MEDIAC2_A411MediaImage, TRN_MEDIAC2_n411MediaImage
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A413MediaSize ;
      private int GIGXA0083 ;
      private int AV7MediaSize ;
      private string A414MediaType ;
      private string AV8MediaType ;
      private string Gx_emsg ;
      private bool n40000MediaImage_GXI ;
      private bool n411MediaImage ;
      private bool nV4MediaImage ;
      private bool nV5MediaImage_GXI ;
      private string A412MediaUrl ;
      private string A410MediaName ;
      private string A40000MediaImage_GXI ;
      private string AV3MediaName ;
      private string AV5MediaImage_GXI ;
      private string AV6MediaUrl ;
      private string A411MediaImage ;
      private string AV4MediaImage ;
      private Guid A409MediaId ;
      private Guid AV2MediaId ;
      private Guid AV9LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] TRN_MEDIAC2_A414MediaType ;
      private int[] TRN_MEDIAC2_A413MediaSize ;
      private string[] TRN_MEDIAC2_A412MediaUrl ;
      private string[] TRN_MEDIAC2_A410MediaName ;
      private Guid[] TRN_MEDIAC2_A409MediaId ;
      private string[] TRN_MEDIAC2_A40000MediaImage_GXI ;
      private bool[] TRN_MEDIAC2_n40000MediaImage_GXI ;
      private string[] TRN_MEDIAC2_A411MediaImage ;
      private bool[] TRN_MEDIAC2_n411MediaImage ;
   }

   public class trn_mediaconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTRN_MEDIAC2;
          prmTRN_MEDIAC2 = new Object[] {
          };
          Object[] prmTRN_MEDIAC3;
          prmTRN_MEDIAC3 = new Object[] {
          new ParDef("AV2MediaId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3MediaName",GXType.VarChar,100,0) ,
          new ParDef("AV4MediaImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
          new ParDef("AV5MediaImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=2, Tbl="GXA0083", Fld="MediaImage"} ,
          new ParDef("AV6MediaUrl",GXType.VarChar,1000,0) ,
          new ParDef("AV7MediaSize",GXType.Int32,8,0) ,
          new ParDef("AV8MediaType",GXType.Char,20,0) ,
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TRN_MEDIAC2", "SELECT MediaType, MediaSize, MediaUrl, MediaName, MediaId, MediaImage_GXI, MediaImage FROM Trn_Media ORDER BY MediaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_MEDIAC2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_MEDIAC3", "INSERT INTO GXA0083(MediaId, MediaName, MediaImage, MediaImage_GXI, MediaUrl, MediaSize, MediaType, LocationId) VALUES(:AV2MediaId, :AV3MediaName, :AV4MediaImage, :AV5MediaImage_GXI, :AV6MediaUrl, :AV7MediaSize, :AV8MediaType, :AV9LocationId)", GxErrorMask.GX_NOMASK,prmTRN_MEDIAC3)
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(6));
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
