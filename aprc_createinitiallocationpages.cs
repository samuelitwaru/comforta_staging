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
   public class aprc_createinitiallocationpages : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_createinitiallocationpages().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         Guid aP0_LocationId = new Guid()  ;
         if ( 0 < args.Length )
         {
            aP0_LocationId=((Guid)(StringUtil.StrToGuid( (string)(args[0]))));
         }
         else
         {
            aP0_LocationId=Guid.Empty;
         }
         execute(aP0_LocationId);
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

      public aprc_createinitiallocationpages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_createinitiallocationpages( IGxContext context )
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
         AV13PredefinedPagesDictionary.set( "34f798f2-7b6c-4a8f-bdea-d14273b5a678",  "Home");
         AV13PredefinedPagesDictionary.set( "1e5d1be0-d9ef-4ff7-869d-1b1f3092155c",  "Reception");
         AV13PredefinedPagesDictionary.set( "784c2d18-622f-43f3-bde1-7b00035d6a07",  "Location");
         AV13PredefinedPagesDictionary.set( "5e200c35-16fe-4401-93c6-b106d14c89cc",  "Calendar");
         AV13PredefinedPagesDictionary.set( "e22b29bc-1982-414a-87cf-71a839806a75",  "Mailbox");
         new prc_logtofile(context ).execute(  AV8LocationId.ToString()) ;
         GXt_char1 = AV17UserName;
         new prc_getloggedinusername(context ).execute( out  GXt_char1) ;
         AV17UserName = GXt_char1;
         /* Using cursor P009P2 */
         pr_default.execute(0, new Object[] {AV17UserName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A25ManagerEmail = P009P2_A25ManagerEmail[0];
            A11OrganisationId = P009P2_A11OrganisationId[0];
            A21ManagerId = P009P2_A21ManagerId[0];
            AV9OrganisationId = A11OrganisationId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV20BC_Trn_Location.Load(AV8LocationId, AV9OrganisationId);
         AV22GXV1 = 1;
         while ( AV22GXV1 <= AV13PredefinedPagesDictionary.gxTpr_Keys.Count )
         {
            AV23Key = ((string)AV13PredefinedPagesDictionary.gxTpr_Keys.Item(AV22GXV1));
            AV15Value = AV13PredefinedPagesDictionary.get(AV23Key);
            AV12File = new GxFile(context.GetPhysicalPath());
            AV12File.Source = "Default"+AV15Value+".txt";
            AV16PageGJSJson = AV12File.ReadAllText("");
            /*
               INSERT RECORD ON TABLE Trn_Page

            */
            A310Trn_PageId = StringUtil.StrToGuid( AV23Key);
            A318Trn_PageName = AV15Value;
            A439PageIsContentPage = false;
            n439PageIsContentPage = false;
            A504PageIsPredefined = true;
            A29LocationId = AV8LocationId;
            A11OrganisationId = AV9OrganisationId;
            A433PageGJSJson = AV16PageGJSJson;
            n433PageGJSJson = false;
            A434PageIsPublished = false;
            n434PageIsPublished = false;
            /* Using cursor P009P3 */
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
            AV22GXV1 = (int)(AV22GXV1+1);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_createinitiallocationpages",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV13PredefinedPagesDictionary = new GeneXus.Core.genexus.common.SdtDictionary<string, string>();
         AV17UserName = "";
         GXt_char1 = "";
         P009P2_A25ManagerEmail = new string[] {""} ;
         P009P2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009P2_A21ManagerId = new Guid[] {Guid.Empty} ;
         A25ManagerEmail = "";
         A11OrganisationId = Guid.Empty;
         A21ManagerId = Guid.Empty;
         AV9OrganisationId = Guid.Empty;
         AV20BC_Trn_Location = new SdtTrn_Location(context);
         AV23Key = "";
         AV15Value = "";
         AV12File = new GxFile(context.GetPhysicalPath());
         AV16PageGJSJson = "";
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         A29LocationId = Guid.Empty;
         A433PageGJSJson = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_createinitiallocationpages__default(),
            new Object[][] {
                new Object[] {
               P009P2_A25ManagerEmail, P009P2_A11OrganisationId, P009P2_A21ManagerId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV22GXV1 ;
      private int GX_INS98 ;
      private string GXt_char1 ;
      private string Gx_emsg ;
      private bool A439PageIsContentPage ;
      private bool n439PageIsContentPage ;
      private bool A504PageIsPredefined ;
      private bool n433PageGJSJson ;
      private bool A434PageIsPublished ;
      private bool n434PageIsPublished ;
      private string AV16PageGJSJson ;
      private string A433PageGJSJson ;
      private string AV17UserName ;
      private string A25ManagerEmail ;
      private string AV23Key ;
      private string AV15Value ;
      private string A318Trn_PageName ;
      private Guid AV8LocationId ;
      private Guid A11OrganisationId ;
      private Guid A21ManagerId ;
      private Guid AV9OrganisationId ;
      private Guid A310Trn_PageId ;
      private Guid A29LocationId ;
      private GxFile AV12File ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Core.genexus.common.SdtDictionary<string, string> AV13PredefinedPagesDictionary ;
      private IDataStoreProvider pr_default ;
      private string[] P009P2_A25ManagerEmail ;
      private Guid[] P009P2_A11OrganisationId ;
      private Guid[] P009P2_A21ManagerId ;
      private SdtTrn_Location AV20BC_Trn_Location ;
   }

   public class aprc_createinitiallocationpages__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009P2;
          prmP009P2 = new Object[] {
          new ParDef("AV17UserName",GXType.VarChar,100,0)
          };
          Object[] prmP009P3;
          prmP009P3 = new Object[] {
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
              new CursorDef("P009P2", "SELECT ManagerEmail, OrganisationId, ManagerId FROM Trn_Manager WHERE ManagerEmail = ( RTRIM(LTRIM(:AV17UserName))) ORDER BY ManagerId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009P2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009P3", "SAVEPOINT gxupdate;INSERT INTO Trn_Page(Trn_PageId, Trn_PageName, LocationId, PageGJSJson, PageIsPublished, PageIsContentPage, OrganisationId, PageIsPredefined, PageJsonContent, PageGJSHtml, PageChildren, ProductServiceId) VALUES(:Trn_PageId, :Trn_PageName, :LocationId, :PageGJSJson, :PageIsPublished, :PageIsContentPage, :OrganisationId, :PageIsPredefined, '', '', '', '00000000-0000-0000-0000-000000000000');RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP009P3)
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
