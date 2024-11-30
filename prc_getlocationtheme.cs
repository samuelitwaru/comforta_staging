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

      public void execute( ref Guid aP0_LocationId ,
                           ref Guid aP1_OrganisationId ,
                           out SdtTrn_Theme aP2_Location_BC_Trn_Theme )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV9OrganisationId = aP1_OrganisationId;
         this.AV10Location_BC_Trn_Theme = new SdtTrn_Theme(context) ;
         initialize();
         ExecuteImpl();
         aP0_LocationId=this.AV8LocationId;
         aP1_OrganisationId=this.AV9OrganisationId;
         aP2_Location_BC_Trn_Theme=this.AV10Location_BC_Trn_Theme;
      }

      public SdtTrn_Theme executeUdp( ref Guid aP0_LocationId ,
                                      ref Guid aP1_OrganisationId )
      {
         execute(ref aP0_LocationId, ref aP1_OrganisationId, out aP2_Location_BC_Trn_Theme);
         return AV10Location_BC_Trn_Theme ;
      }

      public void executeSubmit( ref Guid aP0_LocationId ,
                                 ref Guid aP1_OrganisationId ,
                                 out SdtTrn_Theme aP2_Location_BC_Trn_Theme )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV9OrganisationId = aP1_OrganisationId;
         this.AV10Location_BC_Trn_Theme = new SdtTrn_Theme(context) ;
         SubmitImpl();
         aP0_LocationId=this.AV8LocationId;
         aP1_OrganisationId=this.AV9OrganisationId;
         aP2_Location_BC_Trn_Theme=this.AV10Location_BC_Trn_Theme;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P009G2 */
         pr_default.execute(0, new Object[] {AV8LocationId, AV9OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P009G2_A11OrganisationId[0];
            A29LocationId = P009G2_A29LocationId[0];
            A247Trn_ThemeId = P009G2_A247Trn_ThemeId[0];
            n247Trn_ThemeId = P009G2_n247Trn_ThemeId[0];
            AV10Location_BC_Trn_Theme.Load(A247Trn_ThemeId);
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV10Location_BC_Trn_Theme = new SdtTrn_Theme(context);
         P009G2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009G2_A29LocationId = new Guid[] {Guid.Empty} ;
         P009G2_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P009G2_n247Trn_ThemeId = new bool[] {false} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A247Trn_ThemeId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getlocationtheme__default(),
            new Object[][] {
                new Object[] {
               P009G2_A11OrganisationId, P009G2_A29LocationId, P009G2_A247Trn_ThemeId, P009G2_n247Trn_ThemeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n247Trn_ThemeId ;
      private Guid AV8LocationId ;
      private Guid AV9OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A247Trn_ThemeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP0_LocationId ;
      private Guid aP1_OrganisationId ;
      private SdtTrn_Theme AV10Location_BC_Trn_Theme ;
      private IDataStoreProvider pr_default ;
      private Guid[] P009G2_A11OrganisationId ;
      private Guid[] P009G2_A29LocationId ;
      private Guid[] P009G2_A247Trn_ThemeId ;
      private bool[] P009G2_n247Trn_ThemeId ;
      private SdtTrn_Theme aP2_Location_BC_Trn_Theme ;
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
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009G2", "SELECT OrganisationId, LocationId, Trn_ThemeId FROM Trn_Location WHERE LocationId = :AV8LocationId and OrganisationId = :AV9OrganisationId ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009G2,1, GxCacheFrequency.OFF ,true,true )
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
                return;
       }
    }

 }

}
