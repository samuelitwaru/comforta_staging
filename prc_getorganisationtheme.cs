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
   public class prc_getorganisationtheme : GXProcedure
   {
      public prc_getorganisationtheme( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getorganisationtheme( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationId ,
                           out GXBCCollection<SdtTrn_Theme> aP1_BC_Trn_ThemeCollection )
      {
         this.AV8OrganisationId = aP0_OrganisationId;
         this.AV26BC_Trn_ThemeCollection = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP1_BC_Trn_ThemeCollection=this.AV26BC_Trn_ThemeCollection;
      }

      public GXBCCollection<SdtTrn_Theme> executeUdp( Guid aP0_OrganisationId )
      {
         execute(aP0_OrganisationId, out aP1_BC_Trn_ThemeCollection);
         return AV26BC_Trn_ThemeCollection ;
      }

      public void executeSubmit( Guid aP0_OrganisationId ,
                                 out GXBCCollection<SdtTrn_Theme> aP1_BC_Trn_ThemeCollection )
      {
         this.AV8OrganisationId = aP0_OrganisationId;
         this.AV26BC_Trn_ThemeCollection = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2") ;
         SubmitImpl();
         aP1_BC_Trn_ThemeCollection=this.AV26BC_Trn_ThemeCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00BY2 */
         pr_default.execute(0, new Object[] {AV8OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00BY2_A11OrganisationId[0];
            n11OrganisationId = P00BY2_n11OrganisationId[0];
            A248Trn_ThemeName = P00BY2_A248Trn_ThemeName[0];
            A247Trn_ThemeId = P00BY2_A247Trn_ThemeId[0];
            AV25BC_Trn_Theme = new SdtTrn_Theme(context);
            AV25BC_Trn_Theme.Load(A247Trn_ThemeId);
            AV25BC_Trn_Theme.gxTpr_Color.Sort("ColorName");
            AV26BC_Trn_ThemeCollection.Add(AV25BC_Trn_Theme, 0);
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
         AV26BC_Trn_ThemeCollection = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2");
         P00BY2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00BY2_n11OrganisationId = new bool[] {false} ;
         P00BY2_A248Trn_ThemeName = new string[] {""} ;
         P00BY2_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A248Trn_ThemeName = "";
         A247Trn_ThemeId = Guid.Empty;
         AV25BC_Trn_Theme = new SdtTrn_Theme(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getorganisationtheme__default(),
            new Object[][] {
                new Object[] {
               P00BY2_A11OrganisationId, P00BY2_n11OrganisationId, P00BY2_A248Trn_ThemeName, P00BY2_A247Trn_ThemeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n11OrganisationId ;
      private string A248Trn_ThemeName ;
      private Guid AV8OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A247Trn_ThemeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBCCollection<SdtTrn_Theme> AV26BC_Trn_ThemeCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BY2_A11OrganisationId ;
      private bool[] P00BY2_n11OrganisationId ;
      private string[] P00BY2_A248Trn_ThemeName ;
      private Guid[] P00BY2_A247Trn_ThemeId ;
      private SdtTrn_Theme AV25BC_Trn_Theme ;
      private GXBCCollection<SdtTrn_Theme> aP1_BC_Trn_ThemeCollection ;
   }

   public class prc_getorganisationtheme__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BY2;
          prmP00BY2 = new Object[] {
          new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BY2", "SELECT OrganisationId, Trn_ThemeName, Trn_ThemeId FROM Trn_Theme WHERE (Not (char_length(trim(trailing ' ' from RTRIM(LTRIM(Trn_ThemeName))))=0)) AND (OrganisationId IS NULL or OrganisationId = :AV8OrganisationId) ORDER BY Trn_ThemeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BY2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
