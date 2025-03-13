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
   public class prc_pageapi : GXProcedure
   {
      public prc_pageapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_pageapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_PageId ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId ,
                           string aP3_userId ,
                           out SdtSDT_MobilePage aP4_SDT_MobilePage )
      {
         this.AV11PageId = aP0_PageId;
         this.AV10LocationId = aP1_LocationId;
         this.AV9OrganisationId = aP2_OrganisationId;
         this.AV16userId = aP3_userId;
         this.AV8SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         initialize();
         ExecuteImpl();
         aP4_SDT_MobilePage=this.AV8SDT_MobilePage;
      }

      public SdtSDT_MobilePage executeUdp( Guid aP0_PageId ,
                                           Guid aP1_LocationId ,
                                           Guid aP2_OrganisationId ,
                                           string aP3_userId )
      {
         execute(aP0_PageId, aP1_LocationId, aP2_OrganisationId, aP3_userId, out aP4_SDT_MobilePage);
         return AV8SDT_MobilePage ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId ,
                                 string aP3_userId ,
                                 out SdtSDT_MobilePage aP4_SDT_MobilePage )
      {
         this.AV11PageId = aP0_PageId;
         this.AV10LocationId = aP1_LocationId;
         this.AV9OrganisationId = aP2_OrganisationId;
         this.AV16userId = aP3_userId;
         this.AV8SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         SubmitImpl();
         aP4_SDT_MobilePage=this.AV8SDT_MobilePage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV15AuthorizationValue = AV14httprequest.GetHeader(context.GetMessage( "Authorization", ""));
         new prc_logtoserver(context ).execute(  context.GetMessage( "Token: ", "")+AV15AuthorizationValue) ;
         AV19GXLvl5 = 0;
         /* Using cursor P009C2 */
         pr_default.execute(0, new Object[] {AV16userId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A62ResidentId = P009C2_A62ResidentId[0];
            A554ResidentPackageId = P009C2_A554ResidentPackageId[0];
            n554ResidentPackageId = P009C2_n554ResidentPackageId[0];
            A29LocationId = P009C2_A29LocationId[0];
            A11OrganisationId = P009C2_A11OrganisationId[0];
            AV19GXLvl5 = 1;
            AV17BC_Trn_ResidentPackage.Load(A554ResidentPackageId);
            AV18ModuleCollection.FromJSonString(AV17BC_Trn_ResidentPackage.gxTpr_Residentpackagemodules, null);
            new prc_logtofile(context ).execute(  AV18ModuleCollection.ToJSonString(false)) ;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV19GXLvl5 == 0 )
         {
            new prc_logtoserver(context ).execute(  context.GetMessage( "Error: Resident not found >> ", "")+AV16userId) ;
         }
         /* Using cursor P009C3 */
         pr_default.execute(1, new Object[] {AV11PageId, AV10LocationId, AV9OrganisationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A11OrganisationId = P009C3_A11OrganisationId[0];
            A29LocationId = P009C3_A29LocationId[0];
            A310Trn_PageId = P009C3_A310Trn_PageId[0];
            A431PageJsonContent = P009C3_A431PageJsonContent[0];
            n431PageJsonContent = P009C3_n431PageJsonContent[0];
            A318Trn_PageName = P009C3_A318Trn_PageName[0];
            A434PageIsPublished = P009C3_A434PageIsPublished[0];
            n434PageIsPublished = P009C3_n434PageIsPublished[0];
            A439PageIsContentPage = P009C3_A439PageIsContentPage[0];
            n439PageIsContentPage = P009C3_n439PageIsContentPage[0];
            AV8SDT_MobilePage = new SdtSDT_MobilePage(context);
            AV8SDT_MobilePage.FromJSonString(A431PageJsonContent, null);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A431PageJsonContent))) )
            {
               AV8SDT_MobilePage.gxTpr_Pageid = A310Trn_PageId;
               AV8SDT_MobilePage.gxTpr_Pagename = A318Trn_PageName;
               AV8SDT_MobilePage.gxTpr_Pageispublished = A434PageIsPublished;
               AV8SDT_MobilePage.gxTpr_Pageiscontentpage = A439PageIsContentPage;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
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
         AV8SDT_MobilePage = new SdtSDT_MobilePage(context);
         AV15AuthorizationValue = "";
         AV14httprequest = new GxHttpRequest( context);
         P009C2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P009C2_A554ResidentPackageId = new Guid[] {Guid.Empty} ;
         P009C2_n554ResidentPackageId = new bool[] {false} ;
         P009C2_A29LocationId = new Guid[] {Guid.Empty} ;
         P009C2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A62ResidentId = Guid.Empty;
         A554ResidentPackageId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV17BC_Trn_ResidentPackage = new SdtTrn_ResidentPackage(context);
         AV18ModuleCollection = new GxSimpleCollection<string>();
         P009C3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009C3_A29LocationId = new Guid[] {Guid.Empty} ;
         P009C3_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P009C3_A431PageJsonContent = new string[] {""} ;
         P009C3_n431PageJsonContent = new bool[] {false} ;
         P009C3_A318Trn_PageName = new string[] {""} ;
         P009C3_A434PageIsPublished = new bool[] {false} ;
         P009C3_n434PageIsPublished = new bool[] {false} ;
         P009C3_A439PageIsContentPage = new bool[] {false} ;
         P009C3_n439PageIsContentPage = new bool[] {false} ;
         A310Trn_PageId = Guid.Empty;
         A431PageJsonContent = "";
         A318Trn_PageName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_pageapi__default(),
            new Object[][] {
                new Object[] {
               P009C2_A62ResidentId, P009C2_A554ResidentPackageId, P009C2_n554ResidentPackageId, P009C2_A29LocationId, P009C2_A11OrganisationId
               }
               , new Object[] {
               P009C3_A11OrganisationId, P009C3_A29LocationId, P009C3_A310Trn_PageId, P009C3_A431PageJsonContent, P009C3_n431PageJsonContent, P009C3_A318Trn_PageName, P009C3_A434PageIsPublished, P009C3_n434PageIsPublished, P009C3_A439PageIsContentPage, P009C3_n439PageIsContentPage
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19GXLvl5 ;
      private bool n554ResidentPackageId ;
      private bool n431PageJsonContent ;
      private bool A434PageIsPublished ;
      private bool n434PageIsPublished ;
      private bool A439PageIsContentPage ;
      private bool n439PageIsContentPage ;
      private string A431PageJsonContent ;
      private string AV16userId ;
      private string AV15AuthorizationValue ;
      private string A318Trn_PageName ;
      private Guid AV11PageId ;
      private Guid AV10LocationId ;
      private Guid AV9OrganisationId ;
      private Guid A62ResidentId ;
      private Guid A554ResidentPackageId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A310Trn_PageId ;
      private GxHttpRequest AV14httprequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_MobilePage AV8SDT_MobilePage ;
      private IDataStoreProvider pr_default ;
      private Guid[] P009C2_A62ResidentId ;
      private Guid[] P009C2_A554ResidentPackageId ;
      private bool[] P009C2_n554ResidentPackageId ;
      private Guid[] P009C2_A29LocationId ;
      private Guid[] P009C2_A11OrganisationId ;
      private SdtTrn_ResidentPackage AV17BC_Trn_ResidentPackage ;
      private GxSimpleCollection<string> AV18ModuleCollection ;
      private Guid[] P009C3_A11OrganisationId ;
      private Guid[] P009C3_A29LocationId ;
      private Guid[] P009C3_A310Trn_PageId ;
      private string[] P009C3_A431PageJsonContent ;
      private bool[] P009C3_n431PageJsonContent ;
      private string[] P009C3_A318Trn_PageName ;
      private bool[] P009C3_A434PageIsPublished ;
      private bool[] P009C3_n434PageIsPublished ;
      private bool[] P009C3_A439PageIsContentPage ;
      private bool[] P009C3_n439PageIsContentPage ;
      private SdtSDT_MobilePage aP4_SDT_MobilePage ;
   }

   public class prc_pageapi__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009C2;
          prmP009C2 = new Object[] {
          new ParDef("AV16userId",GXType.VarChar,40,0)
          };
          Object[] prmP009C3;
          prmP009C3 = new Object[] {
          new ParDef("AV11PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009C2", "SELECT ResidentId, ResidentPackageId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentId = CASE WHEN (:AV16userId ~ ('[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}')) THEN RTRIM(:AV16userId) ELSE '00000000-0000-0000-0000-000000000000' END ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009C2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009C3", "SELECT OrganisationId, LocationId, Trn_PageId, PageJsonContent, Trn_PageName, PageIsPublished, PageIsContentPage FROM Trn_Page WHERE (Trn_PageId = :AV11PageId and LocationId = :AV10LocationId) AND (OrganisationId = :AV9OrganisationId) ORDER BY Trn_PageId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009C3,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.getBool(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((bool[]) buf[8])[0] = rslt.getBool(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
