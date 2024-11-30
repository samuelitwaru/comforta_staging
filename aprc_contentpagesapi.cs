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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aprc_contentpagesapi : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_contentpagesapi().MainImpl(args); ;
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

      public aprc_contentpagesapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_contentpagesapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_OrganisationId ,
                           out GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection )
      {
         this.AV20LocationId = aP0_LocationId;
         this.AV19OrganisationId = aP1_OrganisationId;
         this.AV17SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>( context, "SDT_ContentPage", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP2_SDT_ContentPageCollection=this.AV17SDT_ContentPageCollection;
      }

      public GXBaseCollection<SdtSDT_ContentPage> executeUdp( Guid aP0_LocationId ,
                                                              Guid aP1_OrganisationId )
      {
         execute(aP0_LocationId, aP1_OrganisationId, out aP2_SDT_ContentPageCollection);
         return AV17SDT_ContentPageCollection ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 out GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection )
      {
         this.AV20LocationId = aP0_LocationId;
         this.AV19OrganisationId = aP1_OrganisationId;
         this.AV17SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>( context, "SDT_ContentPage", "Comforta_version2") ;
         SubmitImpl();
         aP2_SDT_ContentPageCollection=this.AV17SDT_ContentPageCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00902 */
         pr_default.execute(0, new Object[] {AV20LocationId, AV19OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A439PageIsContentPage = P00902_A439PageIsContentPage[0];
            n439PageIsContentPage = P00902_n439PageIsContentPage[0];
            A11OrganisationId = P00902_A11OrganisationId[0];
            A29LocationId = P00902_A29LocationId[0];
            A310Trn_PageId = P00902_A310Trn_PageId[0];
            A318Trn_PageName = P00902_A318Trn_PageName[0];
            A431PageJsonContent = P00902_A431PageJsonContent[0];
            n431PageJsonContent = P00902_n431PageJsonContent[0];
            AV16SDT_ContentPage = new SdtSDT_ContentPage(context);
            AV16SDT_ContentPage.gxTpr_Pageid = A310Trn_PageId;
            AV16SDT_ContentPage.gxTpr_Pagename = A318Trn_PageName;
            AV16SDT_ContentPage.FromJSonString(A431PageJsonContent, null);
            AV17SDT_ContentPageCollection.Add(AV16SDT_ContentPage, 0);
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
         AV17SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>( context, "SDT_ContentPage", "Comforta_version2");
         P00902_A439PageIsContentPage = new bool[] {false} ;
         P00902_n439PageIsContentPage = new bool[] {false} ;
         P00902_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00902_A29LocationId = new Guid[] {Guid.Empty} ;
         P00902_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P00902_A318Trn_PageName = new string[] {""} ;
         P00902_A431PageJsonContent = new string[] {""} ;
         P00902_n431PageJsonContent = new bool[] {false} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         A431PageJsonContent = "";
         AV16SDT_ContentPage = new SdtSDT_ContentPage(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_contentpagesapi__default(),
            new Object[][] {
                new Object[] {
               P00902_A439PageIsContentPage, P00902_n439PageIsContentPage, P00902_A11OrganisationId, P00902_A29LocationId, P00902_A310Trn_PageId, P00902_A318Trn_PageName, P00902_A431PageJsonContent, P00902_n431PageJsonContent
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
      private Guid AV20LocationId ;
      private Guid AV19OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A310Trn_PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_ContentPage> AV17SDT_ContentPageCollection ;
      private IDataStoreProvider pr_default ;
      private bool[] P00902_A439PageIsContentPage ;
      private bool[] P00902_n439PageIsContentPage ;
      private Guid[] P00902_A11OrganisationId ;
      private Guid[] P00902_A29LocationId ;
      private Guid[] P00902_A310Trn_PageId ;
      private string[] P00902_A318Trn_PageName ;
      private string[] P00902_A431PageJsonContent ;
      private bool[] P00902_n431PageJsonContent ;
      private SdtSDT_ContentPage AV16SDT_ContentPage ;
      private GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection ;
   }

   public class aprc_contentpagesapi__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00902;
          prmP00902 = new Object[] {
          new ParDef("AV20LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00902", "SELECT PageIsContentPage, OrganisationId, LocationId, Trn_PageId, Trn_PageName, PageJsonContent FROM Trn_Page WHERE (LocationId = :AV20LocationId) AND (OrganisationId = :AV19OrganisationId) AND (PageIsContentPage = TRUE) ORDER BY Trn_PageId, Trn_PageName, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00902,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
