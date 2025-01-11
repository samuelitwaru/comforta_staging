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
   public class prc_getlocationtheme : GXProcedure
   {
      public prc_getlocationtheme( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getlocationtheme( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out SdtSDT_LocationTheme aP0_SDT_LocationTheme ,
                           out SdtSDT_Error aP1_Error )
      {
         this.AV11SDT_LocationTheme = new SdtSDT_LocationTheme(context) ;
         this.AV16Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP0_SDT_LocationTheme=this.AV11SDT_LocationTheme;
         aP1_Error=this.AV16Error;
      }

      public SdtSDT_Error executeUdp( out SdtSDT_LocationTheme aP0_SDT_LocationTheme )
      {
         execute(out aP0_SDT_LocationTheme, out aP1_Error);
         return AV16Error ;
      }

      public void executeSubmit( out SdtSDT_LocationTheme aP0_SDT_LocationTheme ,
                                 out SdtSDT_Error aP1_Error )
      {
         this.AV11SDT_LocationTheme = new SdtSDT_LocationTheme(context) ;
         this.AV16Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP0_SDT_LocationTheme=this.AV11SDT_LocationTheme;
         aP1_Error=this.AV16Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV16Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV16Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            AV18Udparg1 = new prc_getuserlocationid(context).executeUdp( );
            AV19Udparg2 = new prc_getuserorganisationid(context).executeUdp( );
            /* Using cursor P009G2 */
            pr_default.execute(0, new Object[] {AV18Udparg1, AV19Udparg2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A11OrganisationId = P009G2_A11OrganisationId[0];
               A29LocationId = P009G2_A29LocationId[0];
               A247Trn_ThemeId = P009G2_A247Trn_ThemeId[0];
               n247Trn_ThemeId = P009G2_n247Trn_ThemeId[0];
               A248Trn_ThemeName = P009G2_A248Trn_ThemeName[0];
               A260Trn_ThemeFontFamily = P009G2_A260Trn_ThemeFontFamily[0];
               A399Trn_ThemeFontSize = P009G2_A399Trn_ThemeFontSize[0];
               A248Trn_ThemeName = P009G2_A248Trn_ThemeName[0];
               A260Trn_ThemeFontFamily = P009G2_A260Trn_ThemeFontFamily[0];
               A399Trn_ThemeFontSize = P009G2_A399Trn_ThemeFontSize[0];
               AV11SDT_LocationTheme = new SdtSDT_LocationTheme(context);
               AV11SDT_LocationTheme.gxTpr_Themeid = A247Trn_ThemeId;
               AV11SDT_LocationTheme.gxTpr_Themename = A248Trn_ThemeName;
               AV11SDT_LocationTheme.gxTpr_Themefontfamily = A260Trn_ThemeFontFamily;
               AV11SDT_LocationTheme.gxTpr_Themefontsize = A399Trn_ThemeFontSize;
               /* Exiting from a For First loop. */
               if (true) break;
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
         AV11SDT_LocationTheme = new SdtSDT_LocationTheme(context);
         AV16Error = new SdtSDT_Error(context);
         AV18Udparg1 = Guid.Empty;
         AV19Udparg2 = Guid.Empty;
         P009G2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009G2_A29LocationId = new Guid[] {Guid.Empty} ;
         P009G2_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P009G2_n247Trn_ThemeId = new bool[] {false} ;
         P009G2_A248Trn_ThemeName = new string[] {""} ;
         P009G2_A260Trn_ThemeFontFamily = new string[] {""} ;
         P009G2_A399Trn_ThemeFontSize = new short[1] ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A247Trn_ThemeId = Guid.Empty;
         A248Trn_ThemeName = "";
         A260Trn_ThemeFontFamily = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getlocationtheme__default(),
            new Object[][] {
                new Object[] {
               P009G2_A11OrganisationId, P009G2_A29LocationId, P009G2_A247Trn_ThemeId, P009G2_n247Trn_ThemeId, P009G2_A248Trn_ThemeName, P009G2_A260Trn_ThemeFontFamily, P009G2_A399Trn_ThemeFontSize
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A399Trn_ThemeFontSize ;
      private bool n247Trn_ThemeId ;
      private string A248Trn_ThemeName ;
      private string A260Trn_ThemeFontFamily ;
      private Guid AV18Udparg1 ;
      private Guid AV19Udparg2 ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A247Trn_ThemeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_LocationTheme AV11SDT_LocationTheme ;
      private SdtSDT_Error AV16Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P009G2_A11OrganisationId ;
      private Guid[] P009G2_A29LocationId ;
      private Guid[] P009G2_A247Trn_ThemeId ;
      private bool[] P009G2_n247Trn_ThemeId ;
      private string[] P009G2_A248Trn_ThemeName ;
      private string[] P009G2_A260Trn_ThemeFontFamily ;
      private short[] P009G2_A399Trn_ThemeFontSize ;
      private SdtSDT_LocationTheme aP0_SDT_LocationTheme ;
      private SdtSDT_Error aP1_Error ;
   }

   public class prc_getlocationtheme__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009G2;
          prmP009G2 = new Object[] {
          new ParDef("AV18Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19Udparg2",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009G2", "SELECT T1.OrganisationId, T1.LocationId, T1.Trn_ThemeId, T2.Trn_ThemeName, T2.Trn_ThemeFontFamily, T2.Trn_ThemeFontSize FROM (Trn_Location T1 LEFT JOIN Trn_Theme T2 ON T2.Trn_ThemeId = T1.Trn_ThemeId) WHERE T1.LocationId = :AV18Udparg1 and T1.OrganisationId = :AV19Udparg2 ORDER BY T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009G2,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
