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
   public class aprc_getpages : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_getpages().MainImpl(args); ;
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

      public aprc_getpages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_getpages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_OrganisationId ,
                           out GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection )
      {
         this.AV15LocationId = aP0_LocationId;
         this.AV16OrganisationId = aP1_OrganisationId;
         this.AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP2_SDT_PageCollection=this.AV9SDT_PageCollection;
      }

      public GXBaseCollection<SdtSDT_Page> executeUdp( Guid aP0_LocationId ,
                                                       Guid aP1_OrganisationId )
      {
         execute(aP0_LocationId, aP1_OrganisationId, out aP2_SDT_PageCollection);
         return AV9SDT_PageCollection ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 out GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection )
      {
         this.AV15LocationId = aP0_LocationId;
         this.AV16OrganisationId = aP1_OrganisationId;
         this.AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2") ;
         SubmitImpl();
         aP2_SDT_PageCollection=this.AV9SDT_PageCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P008Y2 */
         pr_default.execute(0, new Object[] {AV15LocationId, AV16OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P008Y2_A11OrganisationId[0];
            A29LocationId = P008Y2_A29LocationId[0];
            A310Trn_PageId = P008Y2_A310Trn_PageId[0];
            A318Trn_PageName = P008Y2_A318Trn_PageName[0];
            A431PageJsonContent = P008Y2_A431PageJsonContent[0];
            A432PageGJSHtml = P008Y2_A432PageGJSHtml[0];
            A433PageGJSJson = P008Y2_A433PageGJSJson[0];
            A439PageIsContentPage = P008Y2_A439PageIsContentPage[0];
            A434PageIsPublished = P008Y2_A434PageIsPublished[0];
            A437PageChildren = P008Y2_A437PageChildren[0];
            n437PageChildren = P008Y2_n437PageChildren[0];
            AV8SDT_Page = new SdtSDT_Page(context);
            AV8SDT_Page.gxTpr_Pageid = A310Trn_PageId;
            AV8SDT_Page.gxTpr_Pagename = A318Trn_PageName;
            AV8SDT_Page.gxTpr_Pagejsoncontent = A431PageJsonContent;
            AV8SDT_Page.gxTpr_Pagegjshtml = A432PageGJSHtml;
            AV8SDT_Page.gxTpr_Pagegjsjson = A433PageGJSJson;
            AV8SDT_Page.gxTpr_Pageiscontentpage = A439PageIsContentPage;
            AV8SDT_Page.gxTpr_Pageispublished = A434PageIsPublished;
            AV8SDT_Page.gxTpr_Pagechildren.FromJSonString(A437PageChildren, null);
            AV9SDT_PageCollection.Add(AV8SDT_Page, 0);
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
         AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2");
         P008Y2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008Y2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008Y2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P008Y2_A318Trn_PageName = new string[] {""} ;
         P008Y2_A431PageJsonContent = new string[] {""} ;
         P008Y2_A432PageGJSHtml = new string[] {""} ;
         P008Y2_A433PageGJSJson = new string[] {""} ;
         P008Y2_A439PageIsContentPage = new bool[] {false} ;
         P008Y2_A434PageIsPublished = new bool[] {false} ;
         P008Y2_A437PageChildren = new string[] {""} ;
         P008Y2_n437PageChildren = new bool[] {false} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         A431PageJsonContent = "";
         A432PageGJSHtml = "";
         A433PageGJSJson = "";
         A437PageChildren = "";
         AV8SDT_Page = new SdtSDT_Page(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_getpages__default(),
            new Object[][] {
                new Object[] {
               P008Y2_A11OrganisationId, P008Y2_A29LocationId, P008Y2_A310Trn_PageId, P008Y2_A318Trn_PageName, P008Y2_A431PageJsonContent, P008Y2_A432PageGJSHtml, P008Y2_A433PageGJSJson, P008Y2_A439PageIsContentPage, P008Y2_A434PageIsPublished, P008Y2_A437PageChildren,
               P008Y2_n437PageChildren
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool A439PageIsContentPage ;
      private bool A434PageIsPublished ;
      private bool n437PageChildren ;
      private string A431PageJsonContent ;
      private string A432PageGJSHtml ;
      private string A433PageGJSJson ;
      private string A437PageChildren ;
      private string A318Trn_PageName ;
      private Guid AV15LocationId ;
      private Guid AV16OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A310Trn_PageId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_Page> AV9SDT_PageCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] P008Y2_A11OrganisationId ;
      private Guid[] P008Y2_A29LocationId ;
      private Guid[] P008Y2_A310Trn_PageId ;
      private string[] P008Y2_A318Trn_PageName ;
      private string[] P008Y2_A431PageJsonContent ;
      private string[] P008Y2_A432PageGJSHtml ;
      private string[] P008Y2_A433PageGJSJson ;
      private bool[] P008Y2_A439PageIsContentPage ;
      private bool[] P008Y2_A434PageIsPublished ;
      private string[] P008Y2_A437PageChildren ;
      private bool[] P008Y2_n437PageChildren ;
      private SdtSDT_Page AV8SDT_Page ;
      private GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection ;
   }

   public class aprc_getpages__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008Y2;
          prmP008Y2 = new Object[] {
          new ParDef("AV15LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV16OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008Y2", "SELECT OrganisationId, LocationId, Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsContentPage, PageIsPublished, PageChildren FROM Trn_Page WHERE (LocationId = :AV15LocationId) AND (OrganisationId = :AV16OrganisationId) ORDER BY Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Y2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((bool[]) buf[8])[0] = rslt.getBool(9);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
