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
   public class prc_toolboxgetlocationtheme : GXProcedure
   {
      public prc_toolboxgetlocationtheme( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_toolboxgetlocationtheme( IGxContext context )
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
         this.AV10SDT_LocationTheme = new SdtSDT_LocationTheme(context) ;
         this.AV15Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP0_SDT_LocationTheme=this.AV10SDT_LocationTheme;
         aP1_Error=this.AV15Error;
      }

      public SdtSDT_Error executeUdp( out SdtSDT_LocationTheme aP0_SDT_LocationTheme )
      {
         execute(out aP0_SDT_LocationTheme, out aP1_Error);
         return AV15Error ;
      }

      public void executeSubmit( out SdtSDT_LocationTheme aP0_SDT_LocationTheme ,
                                 out SdtSDT_Error aP1_Error )
      {
         this.AV10SDT_LocationTheme = new SdtSDT_LocationTheme(context) ;
         this.AV15Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP0_SDT_LocationTheme=this.AV10SDT_LocationTheme;
         aP1_Error=this.AV15Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV15Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV15Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            AV17Udparg1 = new prc_getuserlocationid(context).executeUdp( );
            AV18Udparg2 = new prc_getuserorganisationid(context).executeUdp( );
            /* Using cursor P00AT2 */
            pr_default.execute(0, new Object[] {AV17Udparg1, AV18Udparg2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A11OrganisationId = P00AT2_A11OrganisationId[0];
               A29LocationId = P00AT2_A29LocationId[0];
               A247Trn_ThemeId = P00AT2_A247Trn_ThemeId[0];
               n247Trn_ThemeId = P00AT2_n247Trn_ThemeId[0];
               A248Trn_ThemeName = P00AT2_A248Trn_ThemeName[0];
               A260Trn_ThemeFontFamily = P00AT2_A260Trn_ThemeFontFamily[0];
               A399Trn_ThemeFontSize = P00AT2_A399Trn_ThemeFontSize[0];
               A248Trn_ThemeName = P00AT2_A248Trn_ThemeName[0];
               A260Trn_ThemeFontFamily = P00AT2_A260Trn_ThemeFontFamily[0];
               A399Trn_ThemeFontSize = P00AT2_A399Trn_ThemeFontSize[0];
               AV10SDT_LocationTheme = new SdtSDT_LocationTheme(context);
               AV10SDT_LocationTheme.gxTpr_Themeid = A247Trn_ThemeId;
               AV10SDT_LocationTheme.gxTpr_Themename = A248Trn_ThemeName;
               AV10SDT_LocationTheme.gxTpr_Themefontfamily = A260Trn_ThemeFontFamily;
               AV10SDT_LocationTheme.gxTpr_Themefontsize = A399Trn_ThemeFontSize;
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
         AV10SDT_LocationTheme = new SdtSDT_LocationTheme(context);
         AV15Error = new SdtSDT_Error(context);
         AV17Udparg1 = Guid.Empty;
         AV18Udparg2 = Guid.Empty;
         P00AT2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00AT2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00AT2_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00AT2_n247Trn_ThemeId = new bool[] {false} ;
         P00AT2_A248Trn_ThemeName = new string[] {""} ;
         P00AT2_A260Trn_ThemeFontFamily = new string[] {""} ;
         P00AT2_A399Trn_ThemeFontSize = new short[1] ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A247Trn_ThemeId = Guid.Empty;
         A248Trn_ThemeName = "";
         A260Trn_ThemeFontFamily = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_toolboxgetlocationtheme__default(),
            new Object[][] {
                new Object[] {
               P00AT2_A11OrganisationId, P00AT2_A29LocationId, P00AT2_A247Trn_ThemeId, P00AT2_n247Trn_ThemeId, P00AT2_A248Trn_ThemeName, P00AT2_A260Trn_ThemeFontFamily, P00AT2_A399Trn_ThemeFontSize
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A399Trn_ThemeFontSize ;
      private bool n247Trn_ThemeId ;
      private string A248Trn_ThemeName ;
      private string A260Trn_ThemeFontFamily ;
      private Guid AV17Udparg1 ;
      private Guid AV18Udparg2 ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A247Trn_ThemeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_LocationTheme AV10SDT_LocationTheme ;
      private SdtSDT_Error AV15Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00AT2_A11OrganisationId ;
      private Guid[] P00AT2_A29LocationId ;
      private Guid[] P00AT2_A247Trn_ThemeId ;
      private bool[] P00AT2_n247Trn_ThemeId ;
      private string[] P00AT2_A248Trn_ThemeName ;
      private string[] P00AT2_A260Trn_ThemeFontFamily ;
      private short[] P00AT2_A399Trn_ThemeFontSize ;
      private SdtSDT_LocationTheme aP0_SDT_LocationTheme ;
      private SdtSDT_Error aP1_Error ;
   }

   public class prc_toolboxgetlocationtheme__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AT2;
          prmP00AT2 = new Object[] {
          new ParDef("AV17Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18Udparg2",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AT2", "SELECT T1.OrganisationId, T1.LocationId, T1.Trn_ThemeId, T2.Trn_ThemeName, T2.Trn_ThemeFontFamily, T2.Trn_ThemeFontSize FROM (Trn_Location T1 LEFT JOIN Trn_Theme T2 ON T2.Trn_ThemeId = T1.Trn_ThemeId) WHERE T1.LocationId = :AV17Udparg1 and T1.OrganisationId = :AV18Udparg2 ORDER BY T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT2,1, GxCacheFrequency.OFF ,false,true )
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