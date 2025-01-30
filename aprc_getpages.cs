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

      public aprc_getpages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_getpages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ,
                           out SdtSDT_Error aP1_Error )
      {
         this.AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2") ;
         this.AV18Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP0_SDT_PageCollection=this.AV9SDT_PageCollection;
         aP1_Error=this.AV18Error;
      }

      public SdtSDT_Error executeUdp( out GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection )
      {
         execute(out aP0_SDT_PageCollection, out aP1_Error);
         return AV18Error ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ,
                                 out SdtSDT_Error aP1_Error )
      {
         this.AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2") ;
         this.AV18Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP0_SDT_PageCollection=this.AV9SDT_PageCollection;
         aP1_Error=this.AV18Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_guid1 = AV15LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV15LocationId = GXt_guid1;
         GXt_guid1 = AV16OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         AV16OrganisationId = GXt_guid1;
         AV20GXLvl5 = 0;
         /* Using cursor P008Y2 */
         pr_default.execute(0, new Object[] {AV15LocationId, AV16OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A318Trn_PageName = P008Y2_A318Trn_PageName[0];
            A11OrganisationId = P008Y2_A11OrganisationId[0];
            A29LocationId = P008Y2_A29LocationId[0];
            A310Trn_PageId = P008Y2_A310Trn_PageId[0];
            AV20GXLvl5 = 1;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV20GXLvl5 == 0 )
         {
            new prc_initlocationpages(context ).execute(  AV15LocationId,  AV16OrganisationId) ;
         }
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV18Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV18Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            /* Using cursor P008Y3 */
            pr_default.execute(1, new Object[] {AV15LocationId, AV16OrganisationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A11OrganisationId = P008Y3_A11OrganisationId[0];
               A29LocationId = P008Y3_A29LocationId[0];
               A310Trn_PageId = P008Y3_A310Trn_PageId[0];
               A318Trn_PageName = P008Y3_A318Trn_PageName[0];
               A431PageJsonContent = P008Y3_A431PageJsonContent[0];
               n431PageJsonContent = P008Y3_n431PageJsonContent[0];
               A432PageGJSHtml = P008Y3_A432PageGJSHtml[0];
               n432PageGJSHtml = P008Y3_n432PageGJSHtml[0];
               A433PageGJSJson = P008Y3_A433PageGJSJson[0];
               n433PageGJSJson = P008Y3_n433PageGJSJson[0];
               A439PageIsContentPage = P008Y3_A439PageIsContentPage[0];
               n439PageIsContentPage = P008Y3_n439PageIsContentPage[0];
               A434PageIsPublished = P008Y3_A434PageIsPublished[0];
               n434PageIsPublished = P008Y3_n434PageIsPublished[0];
               A504PageIsPredefined = P008Y3_A504PageIsPredefined[0];
               A437PageChildren = P008Y3_A437PageChildren[0];
               n437PageChildren = P008Y3_n437PageChildren[0];
               AV8SDT_Page = new SdtSDT_Page(context);
               AV8SDT_Page.gxTpr_Pageid = A310Trn_PageId;
               AV8SDT_Page.gxTpr_Pagename = A318Trn_PageName;
               AV8SDT_Page.gxTpr_Pagejsoncontent = A431PageJsonContent;
               AV8SDT_Page.gxTpr_Pagegjshtml = A432PageGJSHtml;
               AV8SDT_Page.gxTpr_Pagegjsjson = A433PageGJSJson;
               AV8SDT_Page.gxTpr_Pageiscontentpage = A439PageIsContentPage;
               AV8SDT_Page.gxTpr_Pageispublished = A434PageIsPublished;
               AV8SDT_Page.gxTpr_Pageispredefined = A504PageIsPredefined;
               AV8SDT_Page.gxTpr_Pagechildren.FromJSonString(A437PageChildren, null);
               AV9SDT_PageCollection.Add(AV8SDT_Page, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
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
         AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2");
         AV18Error = new SdtSDT_Error(context);
         AV15LocationId = Guid.Empty;
         AV16OrganisationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         P008Y2_A318Trn_PageName = new string[] {""} ;
         P008Y2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008Y2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008Y2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         A318Trn_PageName = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A310Trn_PageId = Guid.Empty;
         P008Y3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008Y3_A29LocationId = new Guid[] {Guid.Empty} ;
         P008Y3_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P008Y3_A318Trn_PageName = new string[] {""} ;
         P008Y3_A431PageJsonContent = new string[] {""} ;
         P008Y3_n431PageJsonContent = new bool[] {false} ;
         P008Y3_A432PageGJSHtml = new string[] {""} ;
         P008Y3_n432PageGJSHtml = new bool[] {false} ;
         P008Y3_A433PageGJSJson = new string[] {""} ;
         P008Y3_n433PageGJSJson = new bool[] {false} ;
         P008Y3_A439PageIsContentPage = new bool[] {false} ;
         P008Y3_n439PageIsContentPage = new bool[] {false} ;
         P008Y3_A434PageIsPublished = new bool[] {false} ;
         P008Y3_n434PageIsPublished = new bool[] {false} ;
         P008Y3_A504PageIsPredefined = new bool[] {false} ;
         P008Y3_A437PageChildren = new string[] {""} ;
         P008Y3_n437PageChildren = new bool[] {false} ;
         A431PageJsonContent = "";
         A432PageGJSHtml = "";
         A433PageGJSJson = "";
         A437PageChildren = "";
         AV8SDT_Page = new SdtSDT_Page(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_getpages__default(),
            new Object[][] {
                new Object[] {
               P008Y2_A318Trn_PageName, P008Y2_A11OrganisationId, P008Y2_A29LocationId, P008Y2_A310Trn_PageId
               }
               , new Object[] {
               P008Y3_A11OrganisationId, P008Y3_A29LocationId, P008Y3_A310Trn_PageId, P008Y3_A318Trn_PageName, P008Y3_A431PageJsonContent, P008Y3_n431PageJsonContent, P008Y3_A432PageGJSHtml, P008Y3_n432PageGJSHtml, P008Y3_A433PageGJSJson, P008Y3_n433PageGJSJson,
               P008Y3_A439PageIsContentPage, P008Y3_n439PageIsContentPage, P008Y3_A434PageIsPublished, P008Y3_n434PageIsPublished, P008Y3_A504PageIsPredefined, P008Y3_A437PageChildren, P008Y3_n437PageChildren
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20GXLvl5 ;
      private bool n431PageJsonContent ;
      private bool n432PageGJSHtml ;
      private bool n433PageGJSJson ;
      private bool A439PageIsContentPage ;
      private bool n439PageIsContentPage ;
      private bool A434PageIsPublished ;
      private bool n434PageIsPublished ;
      private bool A504PageIsPredefined ;
      private bool n437PageChildren ;
      private string A431PageJsonContent ;
      private string A432PageGJSHtml ;
      private string A433PageGJSJson ;
      private string A437PageChildren ;
      private string A318Trn_PageName ;
      private Guid AV15LocationId ;
      private Guid AV16OrganisationId ;
      private Guid GXt_guid1 ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A310Trn_PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_Page> AV9SDT_PageCollection ;
      private SdtSDT_Error AV18Error ;
      private IDataStoreProvider pr_default ;
      private string[] P008Y2_A318Trn_PageName ;
      private Guid[] P008Y2_A11OrganisationId ;
      private Guid[] P008Y2_A29LocationId ;
      private Guid[] P008Y2_A310Trn_PageId ;
      private Guid[] P008Y3_A11OrganisationId ;
      private Guid[] P008Y3_A29LocationId ;
      private Guid[] P008Y3_A310Trn_PageId ;
      private string[] P008Y3_A318Trn_PageName ;
      private string[] P008Y3_A431PageJsonContent ;
      private bool[] P008Y3_n431PageJsonContent ;
      private string[] P008Y3_A432PageGJSHtml ;
      private bool[] P008Y3_n432PageGJSHtml ;
      private string[] P008Y3_A433PageGJSJson ;
      private bool[] P008Y3_n433PageGJSJson ;
      private bool[] P008Y3_A439PageIsContentPage ;
      private bool[] P008Y3_n439PageIsContentPage ;
      private bool[] P008Y3_A434PageIsPublished ;
      private bool[] P008Y3_n434PageIsPublished ;
      private bool[] P008Y3_A504PageIsPredefined ;
      private string[] P008Y3_A437PageChildren ;
      private bool[] P008Y3_n437PageChildren ;
      private SdtSDT_Page AV8SDT_Page ;
      private GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ;
      private SdtSDT_Error aP1_Error ;
   }

   public class aprc_getpages__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
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
          Object[] prmP008Y3;
          prmP008Y3 = new Object[] {
          new ParDef("AV15LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV16OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008Y2", "SELECT Trn_PageName, OrganisationId, LocationId, Trn_PageId FROM Trn_Page WHERE (Trn_PageName = ( 'Home') and LocationId = :AV15LocationId) AND (OrganisationId = :AV16OrganisationId) ORDER BY Trn_PageName, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Y2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008Y3", "SELECT OrganisationId, LocationId, Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsContentPage, PageIsPublished, PageIsPredefined, PageChildren FROM Trn_Page WHERE (LocationId = :AV15LocationId) AND (OrganisationId = :AV16OrganisationId) ORDER BY Trn_PageId, Trn_PageName, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Y3,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((bool[]) buf[10])[0] = rslt.getBool(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((bool[]) buf[12])[0] = rslt.getBool(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((bool[]) buf[14])[0] = rslt.getBool(10);
                ((string[]) buf[15])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                return;
       }
    }

 }

}
