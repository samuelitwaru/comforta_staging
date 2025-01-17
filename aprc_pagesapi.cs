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
   public class aprc_pagesapi : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_pagesapi().MainImpl(args); ;
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

      public aprc_pagesapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_pagesapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_OrganisationId ,
                           out GXBaseCollection<SdtSDT_MobilePage> aP2_SDT_PageCollection )
      {
         this.AV16LocationId = aP0_LocationId;
         this.AV17OrganisationId = aP1_OrganisationId;
         this.AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP2_SDT_PageCollection=this.AV9SDT_PageCollection;
      }

      public GXBaseCollection<SdtSDT_MobilePage> executeUdp( Guid aP0_LocationId ,
                                                             Guid aP1_OrganisationId )
      {
         execute(aP0_LocationId, aP1_OrganisationId, out aP2_SDT_PageCollection);
         return AV9SDT_PageCollection ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 out GXBaseCollection<SdtSDT_MobilePage> aP2_SDT_PageCollection )
      {
         this.AV16LocationId = aP0_LocationId;
         this.AV17OrganisationId = aP1_OrganisationId;
         this.AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version2") ;
         SubmitImpl();
         aP2_SDT_PageCollection=this.AV9SDT_PageCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9SDT_PageCollection.Clear();
         /* Using cursor P007W2 */
         pr_default.execute(0, new Object[] {AV16LocationId, AV17OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A439PageIsContentPage = P007W2_A439PageIsContentPage[0];
            n439PageIsContentPage = P007W2_n439PageIsContentPage[0];
            A11OrganisationId = P007W2_A11OrganisationId[0];
            A29LocationId = P007W2_A29LocationId[0];
            A431PageJsonContent = P007W2_A431PageJsonContent[0];
            n431PageJsonContent = P007W2_n431PageJsonContent[0];
            A310Trn_PageId = P007W2_A310Trn_PageId[0];
            A318Trn_PageName = P007W2_A318Trn_PageName[0];
            AV8SDT_Page = new SdtSDT_MobilePage(context);
            AV8SDT_Page.FromJSonString(A431PageJsonContent, null);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV8SDT_Page.gxTpr_Pagename))) )
            {
               AV9SDT_PageCollection.Add(AV8SDT_Page, 0);
            }
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
         AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version2");
         P007W2_A439PageIsContentPage = new bool[] {false} ;
         P007W2_n439PageIsContentPage = new bool[] {false} ;
         P007W2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007W2_A29LocationId = new Guid[] {Guid.Empty} ;
         P007W2_A431PageJsonContent = new string[] {""} ;
         P007W2_n431PageJsonContent = new bool[] {false} ;
         P007W2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P007W2_A318Trn_PageName = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A431PageJsonContent = "";
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         AV8SDT_Page = new SdtSDT_MobilePage(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_pagesapi__default(),
            new Object[][] {
                new Object[] {
               P007W2_A439PageIsContentPage, P007W2_n439PageIsContentPage, P007W2_A11OrganisationId, P007W2_A29LocationId, P007W2_A431PageJsonContent, P007W2_n431PageJsonContent, P007W2_A310Trn_PageId, P007W2_A318Trn_PageName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool A439PageIsContentPage ;
      private bool n439PageIsContentPage ;
      private bool n431PageJsonContent ;
      private string A431PageJsonContent ;
      private string A318Trn_PageName ;
      private Guid AV16LocationId ;
      private Guid AV17OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A310Trn_PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_MobilePage> AV9SDT_PageCollection ;
      private IDataStoreProvider pr_default ;
      private bool[] P007W2_A439PageIsContentPage ;
      private bool[] P007W2_n439PageIsContentPage ;
      private Guid[] P007W2_A11OrganisationId ;
      private Guid[] P007W2_A29LocationId ;
      private string[] P007W2_A431PageJsonContent ;
      private bool[] P007W2_n431PageJsonContent ;
      private Guid[] P007W2_A310Trn_PageId ;
      private string[] P007W2_A318Trn_PageName ;
      private SdtSDT_MobilePage AV8SDT_Page ;
      private GXBaseCollection<SdtSDT_MobilePage> aP2_SDT_PageCollection ;
   }

   public class aprc_pagesapi__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007W2;
          prmP007W2 = new Object[] {
          new ParDef("AV16LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV17OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007W2", "SELECT PageIsContentPage, OrganisationId, LocationId, PageJsonContent, Trn_PageId, Trn_PageName FROM Trn_Page WHERE (LocationId = :AV16LocationId) AND (OrganisationId = :AV17OrganisationId) AND (PageIsContentPage = FALSE) ORDER BY Trn_PageId, Trn_PageName, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007W2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((Guid[]) buf[6])[0] = rslt.getGuid(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                return;
       }
    }

 }

}
