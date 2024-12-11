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
   public class prc_getdefaulttheme : GXProcedure
   {
      public prc_getdefaulttheme( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getdefaulttheme( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out Guid aP0_ThemeId )
      {
         this.AV8ThemeId = Guid.Empty ;
         initialize();
         ExecuteImpl();
         aP0_ThemeId=this.AV8ThemeId;
      }

      public Guid executeUdp( )
      {
         execute(out aP0_ThemeId);
         return AV8ThemeId ;
      }

      public void executeSubmit( out Guid aP0_ThemeId )
      {
         this.AV8ThemeId = Guid.Empty ;
         SubmitImpl();
         aP0_ThemeId=this.AV8ThemeId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00A72 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A247Trn_ThemeId = P00A72_A247Trn_ThemeId[0];
            AV8ThemeId = A247Trn_ThemeId;
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
         AV8ThemeId = Guid.Empty;
         P00A72_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A247Trn_ThemeId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getdefaulttheme__default(),
            new Object[][] {
                new Object[] {
               P00A72_A247Trn_ThemeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private Guid AV8ThemeId ;
      private Guid A247Trn_ThemeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00A72_A247Trn_ThemeId ;
      private Guid aP0_ThemeId ;
   }

   public class prc_getdefaulttheme__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00A72;
          prmP00A72 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00A72", "SELECT Trn_ThemeId FROM Trn_Theme ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A72,100, GxCacheFrequency.OFF ,false,false )
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
                return;
       }
    }

 }

}
