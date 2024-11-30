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
   public class trn_tileconversion : GXProcedure
   {
      public trn_tileconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_tileconversion( IGxContext context )
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
         /* Using cursor TRN_TILECO2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = TRN_TILECO2_A29LocationId[0];
            A11OrganisationId = TRN_TILECO2_A11OrganisationId[0];
            A438TileIconColor = TRN_TILECO2_A438TileIconColor[0];
            A436TileAction = TRN_TILECO2_A436TileAction[0];
            A330SG_ToPageName = TRN_TILECO2_A330SG_ToPageName[0];
            A329SG_ToPageId = TRN_TILECO2_A329SG_ToPageId[0];
            n329SG_ToPageId = TRN_TILECO2_n329SG_ToPageId[0];
            A406TileIconAlignment = TRN_TILECO2_A406TileIconAlignment[0];
            A405TileTextAlignment = TRN_TILECO2_A405TileTextAlignment[0];
            A404TileTextColor = TRN_TILECO2_A404TileTextColor[0];
            A403TileBGImageUrl = TRN_TILECO2_A403TileBGImageUrl[0];
            n403TileBGImageUrl = TRN_TILECO2_n403TileBGImageUrl[0];
            A402TileBGColor = TRN_TILECO2_A402TileBGColor[0];
            n402TileBGColor = TRN_TILECO2_n402TileBGColor[0];
            A401TileIcon = TRN_TILECO2_A401TileIcon[0];
            n401TileIcon = TRN_TILECO2_n401TileIcon[0];
            A400TileName = TRN_TILECO2_A400TileName[0];
            A407TileId = TRN_TILECO2_A407TileId[0];
            A330SG_ToPageName = TRN_TILECO2_A330SG_ToPageName[0];
            /*
               INSERT RECORD ON TABLE GXA0081

            */
            AV2TileId = A407TileId;
            AV3TileName = A400TileName;
            if ( TRN_TILECO2_n401TileIcon[0] )
            {
               AV4TileIcon = "";
               nV4TileIcon = false;
               nV4TileIcon = true;
            }
            else
            {
               AV4TileIcon = A401TileIcon;
               nV4TileIcon = false;
            }
            if ( TRN_TILECO2_n402TileBGColor[0] )
            {
               AV5TileBGColor = "";
               nV5TileBGColor = false;
               nV5TileBGColor = true;
            }
            else
            {
               AV5TileBGColor = A402TileBGColor;
               nV5TileBGColor = false;
            }
            if ( TRN_TILECO2_n403TileBGImageUrl[0] )
            {
               AV6TileBGImageUrl = "";
               nV6TileBGImageUrl = false;
               nV6TileBGImageUrl = true;
            }
            else
            {
               AV6TileBGImageUrl = A403TileBGImageUrl;
               nV6TileBGImageUrl = false;
            }
            AV7TileTextColor = A404TileTextColor;
            AV8TileTextAlignment = A405TileTextAlignment;
            AV9TileIconAlignment = A406TileIconAlignment;
            if ( TRN_TILECO2_n329SG_ToPageId[0] )
            {
               AV10SG_ToPageId = Guid.Empty;
            }
            else
            {
               AV10SG_ToPageId = A329SG_ToPageId;
            }
            if ( TRN_TILECO2_n330SG_ToPageName[0] )
            {
               AV11SG_ToPageName = " ";
            }
            else
            {
               AV11SG_ToPageName = A330SG_ToPageName;
            }
            AV12TileAction = A436TileAction;
            AV13TileIconColor = A438TileIconColor;
            AV14OrganisationId = A11OrganisationId;
            AV15LocationId = A29LocationId;
            /* Using cursor TRN_TILECO3 */
            pr_default.execute(1, new Object[] {AV2TileId, AV3TileName, nV4TileIcon, AV4TileIcon, nV5TileBGColor, AV5TileBGColor, nV6TileBGImageUrl, AV6TileBGImageUrl, AV7TileTextColor, AV8TileTextAlignment, AV9TileIconAlignment, AV10SG_ToPageId, AV11SG_ToPageName, AV12TileAction, AV13TileIconColor, AV14OrganisationId, AV15LocationId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0081");
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
         TRN_TILECO2_A29LocationId = new Guid[] {Guid.Empty} ;
         TRN_TILECO2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         TRN_TILECO2_A438TileIconColor = new string[] {""} ;
         TRN_TILECO2_A436TileAction = new string[] {""} ;
         TRN_TILECO2_A330SG_ToPageName = new string[] {""} ;
         TRN_TILECO2_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         TRN_TILECO2_n329SG_ToPageId = new bool[] {false} ;
         TRN_TILECO2_A406TileIconAlignment = new string[] {""} ;
         TRN_TILECO2_A405TileTextAlignment = new string[] {""} ;
         TRN_TILECO2_A404TileTextColor = new string[] {""} ;
         TRN_TILECO2_A403TileBGImageUrl = new string[] {""} ;
         TRN_TILECO2_n403TileBGImageUrl = new bool[] {false} ;
         TRN_TILECO2_A402TileBGColor = new string[] {""} ;
         TRN_TILECO2_n402TileBGColor = new bool[] {false} ;
         TRN_TILECO2_A401TileIcon = new string[] {""} ;
         TRN_TILECO2_n401TileIcon = new bool[] {false} ;
         TRN_TILECO2_A400TileName = new string[] {""} ;
         TRN_TILECO2_A407TileId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A438TileIconColor = "";
         A436TileAction = "";
         A330SG_ToPageName = "";
         A329SG_ToPageId = Guid.Empty;
         A406TileIconAlignment = "";
         A405TileTextAlignment = "";
         A404TileTextColor = "";
         A403TileBGImageUrl = "";
         A402TileBGColor = "";
         A401TileIcon = "";
         A400TileName = "";
         A407TileId = Guid.Empty;
         AV2TileId = Guid.Empty;
         AV3TileName = "";
         AV4TileIcon = "";
         AV5TileBGColor = "";
         AV6TileBGImageUrl = "";
         AV7TileTextColor = "";
         AV8TileTextAlignment = "";
         AV9TileIconAlignment = "";
         AV10SG_ToPageId = Guid.Empty;
         TRN_TILECO2_n330SG_ToPageName = new bool[] {false} ;
         AV11SG_ToPageName = "";
         AV12TileAction = "";
         AV13TileIconColor = "";
         AV14OrganisationId = Guid.Empty;
         AV15LocationId = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_tileconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_TILECO2_A29LocationId, TRN_TILECO2_A11OrganisationId, TRN_TILECO2_A438TileIconColor, TRN_TILECO2_A436TileAction, TRN_TILECO2_A330SG_ToPageName, TRN_TILECO2_A329SG_ToPageId, TRN_TILECO2_n329SG_ToPageId, TRN_TILECO2_A406TileIconAlignment, TRN_TILECO2_A405TileTextAlignment, TRN_TILECO2_A404TileTextColor,
               TRN_TILECO2_A403TileBGImageUrl, TRN_TILECO2_n403TileBGImageUrl, TRN_TILECO2_A402TileBGColor, TRN_TILECO2_n402TileBGColor, TRN_TILECO2_A401TileIcon, TRN_TILECO2_n401TileIcon, TRN_TILECO2_A400TileName, TRN_TILECO2_A407TileId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0081 ;
      private string A438TileIconColor ;
      private string A406TileIconAlignment ;
      private string A405TileTextAlignment ;
      private string A404TileTextColor ;
      private string A402TileBGColor ;
      private string A401TileIcon ;
      private string AV4TileIcon ;
      private string AV5TileBGColor ;
      private string AV7TileTextColor ;
      private string AV8TileTextAlignment ;
      private string AV9TileIconAlignment ;
      private string AV13TileIconColor ;
      private string Gx_emsg ;
      private bool n329SG_ToPageId ;
      private bool n403TileBGImageUrl ;
      private bool n402TileBGColor ;
      private bool n401TileIcon ;
      private bool nV4TileIcon ;
      private bool nV5TileBGColor ;
      private bool nV6TileBGImageUrl ;
      private string A436TileAction ;
      private string AV12TileAction ;
      private string A330SG_ToPageName ;
      private string A403TileBGImageUrl ;
      private string A400TileName ;
      private string AV3TileName ;
      private string AV6TileBGImageUrl ;
      private string AV11SG_ToPageName ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A329SG_ToPageId ;
      private Guid A407TileId ;
      private Guid AV2TileId ;
      private Guid AV10SG_ToPageId ;
      private Guid AV14OrganisationId ;
      private Guid AV15LocationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TRN_TILECO2_A29LocationId ;
      private Guid[] TRN_TILECO2_A11OrganisationId ;
      private string[] TRN_TILECO2_A438TileIconColor ;
      private string[] TRN_TILECO2_A436TileAction ;
      private string[] TRN_TILECO2_A330SG_ToPageName ;
      private Guid[] TRN_TILECO2_A329SG_ToPageId ;
      private bool[] TRN_TILECO2_n329SG_ToPageId ;
      private string[] TRN_TILECO2_A406TileIconAlignment ;
      private string[] TRN_TILECO2_A405TileTextAlignment ;
      private string[] TRN_TILECO2_A404TileTextColor ;
      private string[] TRN_TILECO2_A403TileBGImageUrl ;
      private bool[] TRN_TILECO2_n403TileBGImageUrl ;
      private string[] TRN_TILECO2_A402TileBGColor ;
      private bool[] TRN_TILECO2_n402TileBGColor ;
      private string[] TRN_TILECO2_A401TileIcon ;
      private bool[] TRN_TILECO2_n401TileIcon ;
      private string[] TRN_TILECO2_A400TileName ;
      private Guid[] TRN_TILECO2_A407TileId ;
      private bool[] TRN_TILECO2_n330SG_ToPageName ;
   }

   public class trn_tileconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTRN_TILECO2;
          prmTRN_TILECO2 = new Object[] {
          };
          Object[] prmTRN_TILECO3;
          prmTRN_TILECO3 = new Object[] {
          new ParDef("AV2TileId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3TileName",GXType.VarChar,100,0) ,
          new ParDef("AV4TileIcon",GXType.Char,20,0){Nullable=true} ,
          new ParDef("AV5TileBGColor",GXType.Char,20,0){Nullable=true} ,
          new ParDef("AV6TileBGImageUrl",GXType.VarChar,1000,0){Nullable=true} ,
          new ParDef("AV7TileTextColor",GXType.Char,20,0) ,
          new ParDef("AV8TileTextAlignment",GXType.Char,20,0) ,
          new ParDef("AV9TileIconAlignment",GXType.Char,20,0) ,
          new ParDef("AV10SG_ToPageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV11SG_ToPageName",GXType.VarChar,100,0) ,
          new ParDef("AV12TileAction",GXType.LongVarChar,2097152,0) ,
          new ParDef("AV13TileIconColor",GXType.Char,20,0) ,
          new ParDef("AV14OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV15LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TRN_TILECO2", "SELECT T1.LocationId, T1.OrganisationId, T1.TileIconColor, T1.TileAction, T2.Trn_PageName AS SG_ToPageName, T1.SG_ToPageId AS SG_ToPageId, T1.TileIconAlignment, T1.TileTextAlignment, T1.TileTextColor, T1.TileBGImageUrl, T1.TileBGColor, T1.TileIcon, T1.TileName, T1.TileId FROM (Trn_Tile T1 LEFT JOIN Trn_Page T2 ON T2.Trn_PageId = T1.SG_ToPageId) ORDER BY T1.TileId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_TILECO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_TILECO3", "INSERT INTO GXA0081(TileId, TileName, TileIcon, TileBGColor, TileBGImageUrl, TileTextColor, TileTextAlignment, TileIconAlignment, SG_ToPageId, SG_ToPageName, TileAction, TileIconColor, OrganisationId, LocationId) VALUES(:AV2TileId, :AV3TileName, :AV4TileIcon, :AV5TileBGColor, :AV6TileBGImageUrl, :AV7TileTextColor, :AV8TileTextAlignment, :AV9TileIconAlignment, :AV10SG_ToPageId, :AV11SG_ToPageName, :AV12TileAction, :AV13TileIconColor, :AV14OrganisationId, :AV15LocationId)", GxErrorMask.GX_NOMASK,prmTRN_TILECO3)
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 20);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((string[]) buf[14])[0] = rslt.getString(12, 20);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((string[]) buf[16])[0] = rslt.getVarchar(13);
                ((Guid[]) buf[17])[0] = rslt.getGuid(14);
                return;
       }
    }

 }

}
