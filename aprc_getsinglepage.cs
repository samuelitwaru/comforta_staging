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
   public class aprc_getsinglepage : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_getsinglepage().MainImpl(args); ;
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

      public aprc_getsinglepage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_getsinglepage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_pageId ,
                           out SdtSDT_Page aP1_SDT_Page )
      {
         this.AV15pageId = aP0_pageId;
         this.AV8SDT_Page = new SdtSDT_Page(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_Page=this.AV8SDT_Page;
      }

      public SdtSDT_Page executeUdp( Guid aP0_pageId )
      {
         execute(aP0_pageId, out aP1_SDT_Page);
         return AV8SDT_Page ;
      }

      public void executeSubmit( Guid aP0_pageId ,
                                 out SdtSDT_Page aP1_SDT_Page )
      {
         this.AV15pageId = aP0_pageId;
         this.AV8SDT_Page = new SdtSDT_Page(context) ;
         SubmitImpl();
         aP1_SDT_Page=this.AV8SDT_Page;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P009A2 */
         pr_default.execute(0, new Object[] {AV15pageId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A310Trn_PageId = P009A2_A310Trn_PageId[0];
            A318Trn_PageName = P009A2_A318Trn_PageName[0];
            A431PageJsonContent = P009A2_A431PageJsonContent[0];
            A432PageGJSHtml = P009A2_A432PageGJSHtml[0];
            A433PageGJSJson = P009A2_A433PageGJSJson[0];
            A439PageIsContentPage = P009A2_A439PageIsContentPage[0];
            A434PageIsPublished = P009A2_A434PageIsPublished[0];
            A437PageChildren = P009A2_A437PageChildren[0];
            n437PageChildren = P009A2_n437PageChildren[0];
            AV8SDT_Page = new SdtSDT_Page(context);
            AV8SDT_Page.gxTpr_Pageid = A310Trn_PageId;
            AV8SDT_Page.gxTpr_Pagename = A318Trn_PageName;
            AV8SDT_Page.gxTpr_Pagejsoncontent = A431PageJsonContent;
            AV8SDT_Page.gxTpr_Pagegjshtml = A432PageGJSHtml;
            AV8SDT_Page.gxTpr_Pagegjsjson = A433PageGJSJson;
            AV8SDT_Page.gxTpr_Pageiscontentpage = A439PageIsContentPage;
            AV8SDT_Page.gxTpr_Pageispublished = A434PageIsPublished;
            AV8SDT_Page.gxTpr_Pagechildren.FromJSonString(A437PageChildren, null);
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
         AV8SDT_Page = new SdtSDT_Page(context);
         P009A2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P009A2_A318Trn_PageName = new string[] {""} ;
         P009A2_A431PageJsonContent = new string[] {""} ;
         P009A2_A432PageGJSHtml = new string[] {""} ;
         P009A2_A433PageGJSJson = new string[] {""} ;
         P009A2_A439PageIsContentPage = new bool[] {false} ;
         P009A2_A434PageIsPublished = new bool[] {false} ;
         P009A2_A437PageChildren = new string[] {""} ;
         P009A2_n437PageChildren = new bool[] {false} ;
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         A431PageJsonContent = "";
         A432PageGJSHtml = "";
         A433PageGJSJson = "";
         A437PageChildren = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_getsinglepage__default(),
            new Object[][] {
                new Object[] {
               P009A2_A310Trn_PageId, P009A2_A318Trn_PageName, P009A2_A431PageJsonContent, P009A2_A432PageGJSHtml, P009A2_A433PageGJSJson, P009A2_A439PageIsContentPage, P009A2_A434PageIsPublished, P009A2_A437PageChildren, P009A2_n437PageChildren
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
      private Guid AV15pageId ;
      private Guid A310Trn_PageId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Page AV8SDT_Page ;
      private IDataStoreProvider pr_default ;
      private Guid[] P009A2_A310Trn_PageId ;
      private string[] P009A2_A318Trn_PageName ;
      private string[] P009A2_A431PageJsonContent ;
      private string[] P009A2_A432PageGJSHtml ;
      private string[] P009A2_A433PageGJSJson ;
      private bool[] P009A2_A439PageIsContentPage ;
      private bool[] P009A2_A434PageIsPublished ;
      private string[] P009A2_A437PageChildren ;
      private bool[] P009A2_n437PageChildren ;
      private SdtSDT_Page aP1_SDT_Page ;
   }

   public class aprc_getsinglepage__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009A2;
          prmP009A2 = new Object[] {
          new ParDef("AV15pageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009A2", "SELECT Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsContentPage, PageIsPublished, PageChildren FROM Trn_Page WHERE Trn_PageId = :AV15pageId ORDER BY Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009A2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
