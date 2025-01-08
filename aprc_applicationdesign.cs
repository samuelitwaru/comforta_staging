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
   public class aprc_applicationdesign : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_applicationdesign().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
         return GX.GXRuntime.ExitCode ;
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public aprc_applicationdesign( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_applicationdesign( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Trn_PageName ,
                           out SdtSDT_Page aP1_SDT_Page ,
                           out GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection )
      {
         this.AV21Trn_PageName = aP0_Trn_PageName;
         this.AV11SDT_Page = new SdtSDT_Page(context) ;
         this.AV18SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP1_SDT_Page=this.AV11SDT_Page;
         aP2_SDT_PageCollection=this.AV18SDT_PageCollection;
      }

      public GXBaseCollection<SdtSDT_Page> executeUdp( string aP0_Trn_PageName ,
                                                       out SdtSDT_Page aP1_SDT_Page )
      {
         execute(aP0_Trn_PageName, out aP1_SDT_Page, out aP2_SDT_PageCollection);
         return AV18SDT_PageCollection ;
      }

      public void executeSubmit( string aP0_Trn_PageName ,
                                 out SdtSDT_Page aP1_SDT_Page ,
                                 out GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection )
      {
         this.AV21Trn_PageName = aP0_Trn_PageName;
         this.AV11SDT_Page = new SdtSDT_Page(context) ;
         this.AV18SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2") ;
         SubmitImpl();
         aP1_SDT_Page=this.AV11SDT_Page;
         aP2_SDT_PageCollection=this.AV18SDT_PageCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prc_logtofile(context ).execute(  context.GetMessage( "Hello world", "")) ;
         /* Using cursor P00712 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A318Trn_PageName = P00712_A318Trn_PageName[0];
            A310Trn_PageId = P00712_A310Trn_PageId[0];
            A29LocationId = P00712_A29LocationId[0];
            new prc_logtofile(context ).execute(  A318Trn_PageName) ;
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
         AV11SDT_Page = new SdtSDT_Page(context);
         AV18SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2");
         P00712_A318Trn_PageName = new string[] {""} ;
         P00712_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P00712_A29LocationId = new Guid[] {Guid.Empty} ;
         A318Trn_PageName = "";
         A310Trn_PageId = Guid.Empty;
         A29LocationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_applicationdesign__default(),
            new Object[][] {
                new Object[] {
               P00712_A318Trn_PageName, P00712_A310Trn_PageId, P00712_A29LocationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV21Trn_PageName ;
      private string A318Trn_PageName ;
      private Guid A310Trn_PageId ;
      private Guid A29LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Page AV11SDT_Page ;
      private GXBaseCollection<SdtSDT_Page> AV18SDT_PageCollection ;
      private IDataStoreProvider pr_default ;
      private string[] P00712_A318Trn_PageName ;
      private Guid[] P00712_A310Trn_PageId ;
      private Guid[] P00712_A29LocationId ;
      private SdtSDT_Page aP1_SDT_Page ;
      private GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection ;
   }

   public class aprc_applicationdesign__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00712;
          prmP00712 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00712", "SELECT Trn_PageName, Trn_PageId, LocationId FROM Trn_Page ORDER BY Trn_PageId, Trn_PageName, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00712,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
