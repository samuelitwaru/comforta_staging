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
   public class prc_initlocationpages : GXProcedure
   {
      public prc_initlocationpages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_initlocationpages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId )
      {
         this.AV8LocationId = aP0_LocationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_LocationId )
      {
         this.AV8LocationId = aP0_LocationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9PredefinedPagesDictionary.set( "34f798f2-7b6c-4a8f-bdea-d14273b5a678",  "Home");
         AV9PredefinedPagesDictionary.set( "1e5d1be0-d9ef-4ff7-869d-1b1f3092155c",  "Reception");
         AV9PredefinedPagesDictionary.set( "784c2d18-622f-43f3-bde1-7b00035d6a07",  "Location");
         AV9PredefinedPagesDictionary.set( "5e200c35-16fe-4401-93c6-b106d14c89cc",  "Calendar");
         AV9PredefinedPagesDictionary.set( "e22b29bc-1982-414a-87cf-71a839806a75",  "Mailbox");
         new prc_logtofile(context ).execute(  AV8LocationId.ToString()) ;
         GXt_char1 = AV10UserName;
         new prc_getloggedinusername(context ).execute( out  GXt_char1) ;
         AV10UserName = GXt_char1;
         /* Using cursor P00A42 */
         pr_default.execute(0, new Object[] {AV10UserName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A25ManagerEmail = P00A42_A25ManagerEmail[0];
            A11OrganisationId = P00A42_A11OrganisationId[0];
            A21ManagerId = P00A42_A21ManagerId[0];
            AV12OrganisationId = A11OrganisationId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV14BC_Trn_Location.Load(AV8LocationId, AV12OrganisationId);
         AV18GXV1 = 1;
         while ( AV18GXV1 <= AV9PredefinedPagesDictionary.gxTpr_Keys.Count )
         {
            AV11Key = ((string)AV9PredefinedPagesDictionary.gxTpr_Keys.Item(AV18GXV1));
            AV16Value = AV9PredefinedPagesDictionary.get(AV11Key);
            AV15File = new GxFile(context.GetPhysicalPath());
            AV15File.Source = "Default"+AV16Value+".txt";
            AV13PageGJSJson = AV15File.ReadAllText("");
            /*
               INSERT RECORD ON TABLE Trn_Page

            */
            A310Trn_PageId = StringUtil.StrToGuid( AV11Key);
            A318Trn_PageName = AV16Value;
            A439PageIsContentPage = false;
            n439PageIsContentPage = false;
            A504PageIsPredefined = true;
            A29LocationId = AV8LocationId;
            A11OrganisationId = AV12OrganisationId;
            A433PageGJSJson = AV13PageGJSJson;
            n433PageGJSJson = false;
            A434PageIsPublished = false;
            n434PageIsPublished = false;
            /* Using cursor P00A43 */
            pr_default.execute(1, new Object[] {A310Trn_PageId, A318Trn_PageName, A29LocationId, n433PageGJSJson, A433PageGJSJson, n434PageIsPublished, A434PageIsPublished, n439PageIsContentPage, A439PageIsContentPage, A11OrganisationId, A504PageIsPredefined});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            AV18GXV1 = (int)(AV18GXV1+1);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_initlocationpages",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9PredefinedPagesDictionary = new GeneXus.Core.genexus.common.SdtDictionary<string, string>();
         AV10UserName = "";
         GXt_char1 = "";
         P00A42_A25ManagerEmail = new string[] {""} ;
         P00A42_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00A42_A21ManagerId = new Guid[] {Guid.Empty} ;
         A25ManagerEmail = "";
         A11OrganisationId = Guid.Empty;
         A21ManagerId = Guid.Empty;
         AV12OrganisationId = Guid.Empty;
         AV14BC_Trn_Location = new SdtTrn_Location(context);
         AV11Key = "";
         AV16Value = "";
         AV15File = new GxFile(context.GetPhysicalPath());
         AV13PageGJSJson = "";
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         A29LocationId = Guid.Empty;
         A433PageGJSJson = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_initlocationpages__default(),
            new Object[][] {
                new Object[] {
               P00A42_A25ManagerEmail, P00A42_A11OrganisationId, P00A42_A21ManagerId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV18GXV1 ;
      private int GX_INS98 ;
      private string GXt_char1 ;
      private string Gx_emsg ;
      private bool A439PageIsContentPage ;
      private bool n439PageIsContentPage ;
      private bool A504PageIsPredefined ;
      private bool n433PageGJSJson ;
      private bool A434PageIsPublished ;
      private bool n434PageIsPublished ;
      private string AV13PageGJSJson ;
      private string A433PageGJSJson ;
      private string AV10UserName ;
      private string A25ManagerEmail ;
      private string AV11Key ;
      private string AV16Value ;
      private string A318Trn_PageName ;
      private Guid AV8LocationId ;
      private Guid A11OrganisationId ;
      private Guid A21ManagerId ;
      private Guid AV12OrganisationId ;
      private Guid A310Trn_PageId ;
      private Guid A29LocationId ;
      private GxFile AV15File ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Core.genexus.common.SdtDictionary<string, string> AV9PredefinedPagesDictionary ;
      private IDataStoreProvider pr_default ;
      private string[] P00A42_A25ManagerEmail ;
      private Guid[] P00A42_A11OrganisationId ;
      private Guid[] P00A42_A21ManagerId ;
      private SdtTrn_Location AV14BC_Trn_Location ;
   }

   public class prc_initlocationpages__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00A42;
          prmP00A42 = new Object[] {
          new ParDef("AV10UserName",GXType.VarChar,100,0)
          };
          Object[] prmP00A43;
          prmP00A43 = new Object[] {
          new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("PageGJSJson",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("PageIsPublished",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("PageIsContentPage",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("PageIsPredefined",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A42", "SELECT ManagerEmail, OrganisationId, ManagerId FROM Trn_Manager WHERE ManagerEmail = ( RTRIM(LTRIM(:AV10UserName))) ORDER BY ManagerId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A42,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00A43", "SAVEPOINT gxupdate;INSERT INTO Trn_Page(Trn_PageId, Trn_PageName, LocationId, PageGJSJson, PageIsPublished, PageIsContentPage, OrganisationId, PageIsPredefined, PageJsonContent, PageGJSHtml, PageChildren, ProductServiceId) VALUES(:Trn_PageId, :Trn_PageName, :LocationId, :PageGJSJson, :PageIsPublished, :PageIsContentPage, :OrganisationId, :PageIsPredefined, '', '', '', '00000000-0000-0000-0000-000000000000');RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00A43)
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
