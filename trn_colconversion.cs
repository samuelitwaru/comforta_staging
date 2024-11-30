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
   public class trn_colconversion : GXProcedure
   {
      public trn_colconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_colconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
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
         /* Using cursor TRN_COLCON2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A329SG_ToPageId = TRN_COLCON2_A329SG_ToPageId[0];
            A271Trn_TileBGImageUrl = TRN_COLCON2_A271Trn_TileBGImageUrl[0];
            A270Trn_TileColor = TRN_COLCON2_A270Trn_TileColor[0];
            A268Trn_TileWidth = TRN_COLCON2_A268Trn_TileWidth[0];
            A265Trn_TileName = TRN_COLCON2_A265Trn_TileName[0];
            A58ProductServiceId = TRN_COLCON2_A58ProductServiceId[0];
            n58ProductServiceId = TRN_COLCON2_n58ProductServiceId[0];
            A264Trn_TileId = TRN_COLCON2_A264Trn_TileId[0];
            /*
               INSERT RECORD ON TABLE GXA0071

            */
            AV2Trn_TileId = A264Trn_TileId;
            if ( TRN_COLCON2_n58ProductServiceId[0] )
            {
               AV3ProductServiceId = Guid.Empty;
            }
            else
            {
               AV3ProductServiceId = A58ProductServiceId;
            }
            AV4Trn_TileName = A265Trn_TileName;
            AV5Trn_TileWidth = A268Trn_TileWidth;
            AV6Trn_TileColor = A270Trn_TileColor;
            AV7Trn_TileBGImageUrl = A271Trn_TileBGImageUrl;
            AV8SG_ToPageId = A329SG_ToPageId;
            /* Using cursor TRN_COLCON3 */
            pr_default.execute(1, new Object[] {AV2Trn_TileId, AV3ProductServiceId, AV4Trn_TileName, AV5Trn_TileWidth, AV6Trn_TileColor, AV7Trn_TileBGImageUrl, AV8SG_ToPageId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0071");
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
         TRN_COLCON2_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         TRN_COLCON2_A271Trn_TileBGImageUrl = new string[] {""} ;
         TRN_COLCON2_A270Trn_TileColor = new string[] {""} ;
         TRN_COLCON2_A268Trn_TileWidth = new short[1] ;
         TRN_COLCON2_A265Trn_TileName = new string[] {""} ;
         TRN_COLCON2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         TRN_COLCON2_n58ProductServiceId = new bool[] {false} ;
         TRN_COLCON2_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         A329SG_ToPageId = Guid.Empty;
         A271Trn_TileBGImageUrl = "";
         A270Trn_TileColor = "";
         A265Trn_TileName = "";
         A58ProductServiceId = Guid.Empty;
         A264Trn_TileId = Guid.Empty;
         AV2Trn_TileId = Guid.Empty;
         AV3ProductServiceId = Guid.Empty;
         AV4Trn_TileName = "";
         AV6Trn_TileColor = "";
         AV7Trn_TileBGImageUrl = "";
         AV8SG_ToPageId = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_colconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_COLCON2_A329SG_ToPageId, TRN_COLCON2_A271Trn_TileBGImageUrl, TRN_COLCON2_A270Trn_TileColor, TRN_COLCON2_A268Trn_TileWidth, TRN_COLCON2_A265Trn_TileName, TRN_COLCON2_A58ProductServiceId, TRN_COLCON2_n58ProductServiceId, TRN_COLCON2_A264Trn_TileId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A268Trn_TileWidth ;
      private short AV5Trn_TileWidth ;
      private int GIGXA0071 ;
      private string A270Trn_TileColor ;
      private string AV6Trn_TileColor ;
      private string Gx_emsg ;
      private bool n58ProductServiceId ;
      private string A271Trn_TileBGImageUrl ;
      private string A265Trn_TileName ;
      private string AV4Trn_TileName ;
      private string AV7Trn_TileBGImageUrl ;
      private Guid A329SG_ToPageId ;
      private Guid A58ProductServiceId ;
      private Guid A264Trn_TileId ;
      private Guid AV2Trn_TileId ;
      private Guid AV3ProductServiceId ;
      private Guid AV8SG_ToPageId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TRN_COLCON2_A329SG_ToPageId ;
      private string[] TRN_COLCON2_A271Trn_TileBGImageUrl ;
      private string[] TRN_COLCON2_A270Trn_TileColor ;
      private short[] TRN_COLCON2_A268Trn_TileWidth ;
      private string[] TRN_COLCON2_A265Trn_TileName ;
      private Guid[] TRN_COLCON2_A58ProductServiceId ;
      private bool[] TRN_COLCON2_n58ProductServiceId ;
      private Guid[] TRN_COLCON2_A264Trn_TileId ;
   }

   public class trn_colconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTRN_COLCON2;
          prmTRN_COLCON2 = new Object[] {
          };
          Object[] prmTRN_COLCON3;
          prmTRN_COLCON3 = new Object[] {
          new ParDef("AV2Trn_TileId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV4Trn_TileName",GXType.VarChar,100,0) ,
          new ParDef("AV5Trn_TileWidth",GXType.Int16,4,0) ,
          new ParDef("AV6Trn_TileColor",GXType.Char,20,0) ,
          new ParDef("AV7Trn_TileBGImageUrl",GXType.VarChar,1000,0) ,
          new ParDef("AV8SG_ToPageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TRN_COLCON2", "SELECT SG_ToPageId, Trn_TileBGImageUrl, Trn_TileColor, Trn_TileWidth, Trn_TileName, ProductServiceId, Trn_TileId FROM Trn_Tile ORDER BY Trn_TileId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_COLCON2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_COLCON3", "INSERT INTO GXA0071(Trn_TileId, ProductServiceId, Trn_TileName, Trn_TileWidth, Trn_TileColor, Trn_TileBGImageUrl, SG_ToPageId) VALUES(:AV2Trn_TileId, :AV3ProductServiceId, :AV4Trn_TileName, :AV5Trn_TileWidth, :AV6Trn_TileColor, :AV7Trn_TileBGImageUrl, :AV8SG_ToPageId)", GxErrorMask.GX_NOMASK,prmTRN_COLCON3)
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((Guid[]) buf[7])[0] = rslt.getGuid(7);
                return;
       }
    }

 }

}
