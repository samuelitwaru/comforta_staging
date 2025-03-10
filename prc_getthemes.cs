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
   public class prc_getthemes : GXProcedure
   {
      public prc_getthemes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getthemes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDT_Theme> aP0_SDT_ThemeCollection ,
                           out SdtSDT_Error aP1_SDT_Error )
      {
         this.AV10SDT_ThemeCollection = new GXBaseCollection<SdtSDT_Theme>( context, "SDT_Theme", "Comforta_version2") ;
         this.AV12SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP0_SDT_ThemeCollection=this.AV10SDT_ThemeCollection;
         aP1_SDT_Error=this.AV12SDT_Error;
      }

      public SdtSDT_Error executeUdp( out GXBaseCollection<SdtSDT_Theme> aP0_SDT_ThemeCollection )
      {
         execute(out aP0_SDT_ThemeCollection, out aP1_SDT_Error);
         return AV12SDT_Error ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_Theme> aP0_SDT_ThemeCollection ,
                                 out SdtSDT_Error aP1_SDT_Error )
      {
         this.AV10SDT_ThemeCollection = new GXBaseCollection<SdtSDT_Theme>( context, "SDT_Theme", "Comforta_version2") ;
         this.AV12SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP0_SDT_ThemeCollection=this.AV10SDT_ThemeCollection;
         aP1_SDT_Error=this.AV12SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV12SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV12SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            /* Using cursor P00BF2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A247Trn_ThemeId = P00BF2_A247Trn_ThemeId[0];
               A248Trn_ThemeName = P00BF2_A248Trn_ThemeName[0];
               A260Trn_ThemeFontFamily = P00BF2_A260Trn_ThemeFontFamily[0];
               A399Trn_ThemeFontSize = P00BF2_A399Trn_ThemeFontSize[0];
               AV11SDT_Theme = new SdtSDT_Theme(context);
               AV11SDT_Theme.gxTpr_Themeid = A247Trn_ThemeId;
               AV11SDT_Theme.gxTpr_Themename = A248Trn_ThemeName;
               AV11SDT_Theme.gxTpr_Themefontfamily = A260Trn_ThemeFontFamily;
               AV11SDT_Theme.gxTpr_Themefontsize = A399Trn_ThemeFontSize;
               /* Using cursor P00BF3 */
               pr_default.execute(1, new Object[] {A247Trn_ThemeId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A249ColorId = P00BF3_A249ColorId[0];
                  A251ColorCode = P00BF3_A251ColorCode[0];
                  A250ColorName = P00BF3_A250ColorName[0];
                  AV13SDT_ThemeColor = new SdtSDT_Theme_ColorsItem(context);
                  AV13SDT_ThemeColor.gxTpr_Colorid = A249ColorId;
                  AV13SDT_ThemeColor.gxTpr_Colorname = A250ColorName;
                  AV13SDT_ThemeColor.gxTpr_Colorcode = A251ColorCode;
                  AV11SDT_Theme.gxTpr_Colors.Add(AV13SDT_ThemeColor, 0);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               /* Using cursor P00BF4 */
               pr_default.execute(2, new Object[] {A247Trn_ThemeId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A261IconId = P00BF4_A261IconId[0];
                  A262IconName = P00BF4_A262IconName[0];
                  A263IconSVG = P00BF4_A263IconSVG[0];
                  A443IconCategory = P00BF4_A443IconCategory[0];
                  AV14SDT_ThemeIcon = new SdtSDT_Theme_IconsItem(context);
                  AV14SDT_ThemeIcon.gxTpr_Iconid = A261IconId;
                  AV14SDT_ThemeIcon.gxTpr_Iconname = A262IconName;
                  AV14SDT_ThemeIcon.gxTpr_Iconsvg = A263IconSVG;
                  AV14SDT_ThemeIcon.gxTpr_Iconcategory = A443IconCategory;
                  AV11SDT_Theme.gxTpr_Icons.Add(AV14SDT_ThemeIcon, 0);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               AV10SDT_ThemeCollection.Add(AV11SDT_Theme, 0);
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
         AV10SDT_ThemeCollection = new GXBaseCollection<SdtSDT_Theme>( context, "SDT_Theme", "Comforta_version2");
         AV12SDT_Error = new SdtSDT_Error(context);
         P00BF2_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00BF2_A248Trn_ThemeName = new string[] {""} ;
         P00BF2_A260Trn_ThemeFontFamily = new string[] {""} ;
         P00BF2_A399Trn_ThemeFontSize = new short[1] ;
         A247Trn_ThemeId = Guid.Empty;
         A248Trn_ThemeName = "";
         A260Trn_ThemeFontFamily = "";
         AV11SDT_Theme = new SdtSDT_Theme(context);
         P00BF3_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00BF3_A249ColorId = new Guid[] {Guid.Empty} ;
         P00BF3_A251ColorCode = new string[] {""} ;
         P00BF3_A250ColorName = new string[] {""} ;
         A249ColorId = Guid.Empty;
         A251ColorCode = "";
         A250ColorName = "";
         AV13SDT_ThemeColor = new SdtSDT_Theme_ColorsItem(context);
         P00BF4_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00BF4_A261IconId = new Guid[] {Guid.Empty} ;
         P00BF4_A262IconName = new string[] {""} ;
         P00BF4_A263IconSVG = new string[] {""} ;
         P00BF4_A443IconCategory = new string[] {""} ;
         A261IconId = Guid.Empty;
         A262IconName = "";
         A263IconSVG = "";
         A443IconCategory = "";
         AV14SDT_ThemeIcon = new SdtSDT_Theme_IconsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getthemes__default(),
            new Object[][] {
                new Object[] {
               P00BF2_A247Trn_ThemeId, P00BF2_A248Trn_ThemeName, P00BF2_A260Trn_ThemeFontFamily, P00BF2_A399Trn_ThemeFontSize
               }
               , new Object[] {
               P00BF3_A247Trn_ThemeId, P00BF3_A249ColorId, P00BF3_A251ColorCode, P00BF3_A250ColorName
               }
               , new Object[] {
               P00BF4_A247Trn_ThemeId, P00BF4_A261IconId, P00BF4_A262IconName, P00BF4_A263IconSVG, P00BF4_A443IconCategory
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A399Trn_ThemeFontSize ;
      private string A263IconSVG ;
      private string A248Trn_ThemeName ;
      private string A260Trn_ThemeFontFamily ;
      private string A251ColorCode ;
      private string A250ColorName ;
      private string A262IconName ;
      private string A443IconCategory ;
      private Guid A247Trn_ThemeId ;
      private Guid A249ColorId ;
      private Guid A261IconId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_Theme> AV10SDT_ThemeCollection ;
      private SdtSDT_Error AV12SDT_Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BF2_A247Trn_ThemeId ;
      private string[] P00BF2_A248Trn_ThemeName ;
      private string[] P00BF2_A260Trn_ThemeFontFamily ;
      private short[] P00BF2_A399Trn_ThemeFontSize ;
      private SdtSDT_Theme AV11SDT_Theme ;
      private Guid[] P00BF3_A247Trn_ThemeId ;
      private Guid[] P00BF3_A249ColorId ;
      private string[] P00BF3_A251ColorCode ;
      private string[] P00BF3_A250ColorName ;
      private SdtSDT_Theme_ColorsItem AV13SDT_ThemeColor ;
      private Guid[] P00BF4_A247Trn_ThemeId ;
      private Guid[] P00BF4_A261IconId ;
      private string[] P00BF4_A262IconName ;
      private string[] P00BF4_A263IconSVG ;
      private string[] P00BF4_A443IconCategory ;
      private SdtSDT_Theme_IconsItem AV14SDT_ThemeIcon ;
      private GXBaseCollection<SdtSDT_Theme> aP0_SDT_ThemeCollection ;
      private SdtSDT_Error aP1_SDT_Error ;
   }

   public class prc_getthemes__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BF2;
          prmP00BF2 = new Object[] {
          };
          Object[] prmP00BF3;
          prmP00BF3 = new Object[] {
          new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00BF4;
          prmP00BF4 = new Object[] {
          new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BF2", "SELECT Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize FROM Trn_Theme WHERE Not (char_length(trim(trailing ' ' from RTRIM(LTRIM(Trn_ThemeName))))=0) ORDER BY Trn_ThemeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BF2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BF3", "SELECT Trn_ThemeId, ColorId, ColorCode, ColorName FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId, ColorName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BF3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BF4", "SELECT Trn_ThemeId, IconId, IconName, IconSVG, IconCategory FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BF4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
