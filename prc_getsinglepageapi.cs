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
   public class prc_getsinglepageapi : GXProcedure
   {
      public prc_getsinglepageapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getsinglepageapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_pageId ,
                           out SdtSDT_Page aP1_SDT_Page ,
                           out SdtSDT_Error aP2_Error )
      {
         this.AV15pageId = aP0_pageId;
         this.AV8SDT_Page = new SdtSDT_Page(context) ;
         this.AV19Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_Page=this.AV8SDT_Page;
         aP2_Error=this.AV19Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_pageId ,
                                      out SdtSDT_Page aP1_SDT_Page )
      {
         execute(aP0_pageId, out aP1_SDT_Page, out aP2_Error);
         return AV19Error ;
      }

      public void executeSubmit( Guid aP0_pageId ,
                                 out SdtSDT_Page aP1_SDT_Page ,
                                 out SdtSDT_Error aP2_Error )
      {
         this.AV15pageId = aP0_pageId;
         this.AV8SDT_Page = new SdtSDT_Page(context) ;
         this.AV19Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_SDT_Page=this.AV8SDT_Page;
         aP2_Error=this.AV19Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV19Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV19Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            /* Using cursor P009D2 */
            pr_default.execute(0, new Object[] {AV15pageId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A310Trn_PageId = P009D2_A310Trn_PageId[0];
               A318Trn_PageName = P009D2_A318Trn_PageName[0];
               A431PageJsonContent = P009D2_A431PageJsonContent[0];
               n431PageJsonContent = P009D2_n431PageJsonContent[0];
               A432PageGJSHtml = P009D2_A432PageGJSHtml[0];
               n432PageGJSHtml = P009D2_n432PageGJSHtml[0];
               A433PageGJSJson = P009D2_A433PageGJSJson[0];
               n433PageGJSJson = P009D2_n433PageGJSJson[0];
               A439PageIsContentPage = P009D2_A439PageIsContentPage[0];
               n439PageIsContentPage = P009D2_n439PageIsContentPage[0];
               A434PageIsPublished = P009D2_A434PageIsPublished[0];
               n434PageIsPublished = P009D2_n434PageIsPublished[0];
               A437PageChildren = P009D2_A437PageChildren[0];
               n437PageChildren = P009D2_n437PageChildren[0];
               A29LocationId = P009D2_A29LocationId[0];
               AV8SDT_Page = new SdtSDT_Page(context);
               AV8SDT_Page.gxTpr_Pageid = A310Trn_PageId;
               AV8SDT_Page.gxTpr_Pagename = A318Trn_PageName;
               AV8SDT_Page.gxTpr_Pagejsoncontent = A431PageJsonContent;
               AV8SDT_Page.gxTpr_Pagegjshtml = A432PageGJSHtml;
               AV8SDT_Page.gxTpr_Pagegjsjson = A433PageGJSJson;
               AV8SDT_Page.gxTpr_Pageiscontentpage = A439PageIsContentPage;
               AV8SDT_Page.gxTpr_Pageispublished = A434PageIsPublished;
               AV8SDT_Page.gxTpr_Pagechildren.FromJSonString(A437PageChildren, null);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            new prc_logtofile(context ).execute(  context.GetMessage( "Checking here: ", "")+AV15pageId.ToString()) ;
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
         AV8SDT_Page = new SdtSDT_Page(context);
         AV19Error = new SdtSDT_Error(context);
         P009D2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P009D2_A318Trn_PageName = new string[] {""} ;
         P009D2_A431PageJsonContent = new string[] {""} ;
         P009D2_n431PageJsonContent = new bool[] {false} ;
         P009D2_A432PageGJSHtml = new string[] {""} ;
         P009D2_n432PageGJSHtml = new bool[] {false} ;
         P009D2_A433PageGJSJson = new string[] {""} ;
         P009D2_n433PageGJSJson = new bool[] {false} ;
         P009D2_A439PageIsContentPage = new bool[] {false} ;
         P009D2_n439PageIsContentPage = new bool[] {false} ;
         P009D2_A434PageIsPublished = new bool[] {false} ;
         P009D2_n434PageIsPublished = new bool[] {false} ;
         P009D2_A437PageChildren = new string[] {""} ;
         P009D2_n437PageChildren = new bool[] {false} ;
         P009D2_A29LocationId = new Guid[] {Guid.Empty} ;
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         A431PageJsonContent = "";
         A432PageGJSHtml = "";
         A433PageGJSJson = "";
         A437PageChildren = "";
         A29LocationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getsinglepageapi__default(),
            new Object[][] {
                new Object[] {
               P009D2_A310Trn_PageId, P009D2_A318Trn_PageName, P009D2_A431PageJsonContent, P009D2_n431PageJsonContent, P009D2_A432PageGJSHtml, P009D2_n432PageGJSHtml, P009D2_A433PageGJSJson, P009D2_n433PageGJSJson, P009D2_A439PageIsContentPage, P009D2_n439PageIsContentPage,
               P009D2_A434PageIsPublished, P009D2_n434PageIsPublished, P009D2_A437PageChildren, P009D2_n437PageChildren, P009D2_A29LocationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n431PageJsonContent ;
      private bool n432PageGJSHtml ;
      private bool n433PageGJSJson ;
      private bool A439PageIsContentPage ;
      private bool n439PageIsContentPage ;
      private bool A434PageIsPublished ;
      private bool n434PageIsPublished ;
      private bool n437PageChildren ;
      private string A431PageJsonContent ;
      private string A432PageGJSHtml ;
      private string A433PageGJSJson ;
      private string A437PageChildren ;
      private string A318Trn_PageName ;
      private Guid AV15pageId ;
      private Guid A310Trn_PageId ;
      private Guid A29LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Page AV8SDT_Page ;
      private SdtSDT_Error AV19Error ;
      private IDataStoreProvider pr_default ;
      private Guid[] P009D2_A310Trn_PageId ;
      private string[] P009D2_A318Trn_PageName ;
      private string[] P009D2_A431PageJsonContent ;
      private bool[] P009D2_n431PageJsonContent ;
      private string[] P009D2_A432PageGJSHtml ;
      private bool[] P009D2_n432PageGJSHtml ;
      private string[] P009D2_A433PageGJSJson ;
      private bool[] P009D2_n433PageGJSJson ;
      private bool[] P009D2_A439PageIsContentPage ;
      private bool[] P009D2_n439PageIsContentPage ;
      private bool[] P009D2_A434PageIsPublished ;
      private bool[] P009D2_n434PageIsPublished ;
      private string[] P009D2_A437PageChildren ;
      private bool[] P009D2_n437PageChildren ;
      private Guid[] P009D2_A29LocationId ;
      private SdtSDT_Page aP1_SDT_Page ;
      private SdtSDT_Error aP2_Error ;
   }

   public class prc_getsinglepageapi__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009D2;
          prmP009D2 = new Object[] {
          new ParDef("AV15pageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009D2", "SELECT Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsContentPage, PageIsPublished, PageChildren, LocationId FROM Trn_Page WHERE Trn_PageId = :AV15pageId ORDER BY Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009D2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((bool[]) buf[10])[0] = rslt.getBool(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((Guid[]) buf[14])[0] = rslt.getGuid(9);
                return;
       }
    }

 }

}
