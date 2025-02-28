using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class trn_pageconversion : GXProcedure
   {
      public trn_pageconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_pageconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor TRN_PAGECO2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = TRN_PAGECO2_A11OrganisationId[0];
            A58ProductServiceId = TRN_PAGECO2_A58ProductServiceId[0];
            n58ProductServiceId = TRN_PAGECO2_n58ProductServiceId[0];
            A437PageChildren = TRN_PAGECO2_A437PageChildren[0];
            n437PageChildren = TRN_PAGECO2_n437PageChildren[0];
            A519PageIsWebLinkPage = TRN_PAGECO2_A519PageIsWebLinkPage[0];
            A514PageIsDynamicForm = TRN_PAGECO2_A514PageIsDynamicForm[0];
            A439PageIsContentPage = TRN_PAGECO2_A439PageIsContentPage[0];
            n439PageIsContentPage = TRN_PAGECO2_n439PageIsContentPage[0];
            A504PageIsPredefined = TRN_PAGECO2_A504PageIsPredefined[0];
            A434PageIsPublished = TRN_PAGECO2_A434PageIsPublished[0];
            n434PageIsPublished = TRN_PAGECO2_n434PageIsPublished[0];
            A433PageGJSJson = TRN_PAGECO2_A433PageGJSJson[0];
            n433PageGJSJson = TRN_PAGECO2_n433PageGJSJson[0];
            A432PageGJSHtml = TRN_PAGECO2_A432PageGJSHtml[0];
            n432PageGJSHtml = TRN_PAGECO2_n432PageGJSHtml[0];
            A431PageJsonContent = TRN_PAGECO2_A431PageJsonContent[0];
            n431PageJsonContent = TRN_PAGECO2_n431PageJsonContent[0];
            A318Trn_PageName = TRN_PAGECO2_A318Trn_PageName[0];
            A29LocationId = TRN_PAGECO2_A29LocationId[0];
            A310Trn_PageId = TRN_PAGECO2_A310Trn_PageId[0];
            /*
               INSERT RECORD ON TABLE GXA0100

            */
            AV2Trn_PageId = A310Trn_PageId;
            AV3LocationId = A29LocationId;
            AV4Trn_PageName = A318Trn_PageName;
            if ( TRN_PAGECO2_n431PageJsonContent[0] )
            {
               AV5PageJsonContent = "";
               nV5PageJsonContent = false;
               nV5PageJsonContent = true;
            }
            else
            {
               AV5PageJsonContent = A431PageJsonContent;
               nV5PageJsonContent = false;
            }
            if ( TRN_PAGECO2_n432PageGJSHtml[0] )
            {
               AV6PageGJSHtml = "";
               nV6PageGJSHtml = false;
               nV6PageGJSHtml = true;
            }
            else
            {
               AV6PageGJSHtml = A432PageGJSHtml;
               nV6PageGJSHtml = false;
            }
            if ( TRN_PAGECO2_n433PageGJSJson[0] )
            {
               AV7PageGJSJson = "";
               nV7PageGJSJson = false;
               nV7PageGJSJson = true;
            }
            else
            {
               AV7PageGJSJson = A433PageGJSJson;
               nV7PageGJSJson = false;
            }
            if ( TRN_PAGECO2_n434PageIsPublished[0] )
            {
               AV8PageIsPublished = false;
               nV8PageIsPublished = false;
               nV8PageIsPublished = true;
            }
            else
            {
               AV8PageIsPublished = A434PageIsPublished;
               nV8PageIsPublished = false;
            }
            AV9PageIsPredefined = A504PageIsPredefined;
            if ( TRN_PAGECO2_n439PageIsContentPage[0] )
            {
               AV10PageIsContentPage = false;
               nV10PageIsContentPage = false;
               nV10PageIsContentPage = true;
            }
            else
            {
               AV10PageIsContentPage = A439PageIsContentPage;
               nV10PageIsContentPage = false;
            }
            AV11PageIsDynamicForm = A514PageIsDynamicForm;
            AV12PageIsWebLinkPage = A519PageIsWebLinkPage;
            if ( TRN_PAGECO2_n437PageChildren[0] )
            {
               AV13PageChildren = "";
               nV13PageChildren = false;
               nV13PageChildren = true;
            }
            else
            {
               AV13PageChildren = A437PageChildren;
               nV13PageChildren = false;
            }
            if ( TRN_PAGECO2_n58ProductServiceId[0] )
            {
               AV14ProductServiceId = Guid.Empty;
               nV14ProductServiceId = false;
               nV14ProductServiceId = true;
            }
            else
            {
               AV14ProductServiceId = A58ProductServiceId;
               nV14ProductServiceId = false;
            }
            AV15OrganisationId = A11OrganisationId;
            /* Using cursor TRN_PAGECO3 */
            pr_default.execute(1, new Object[] {AV2Trn_PageId, AV3LocationId});
            if ( (pr_default.getStatus(1) != 101) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
               /* Using cursor TRN_PAGECO4 */
               pr_default.execute(2, new Object[] {AV2Trn_PageId, AV3LocationId, AV4Trn_PageName, nV5PageJsonContent, AV5PageJsonContent, nV6PageGJSHtml, AV6PageGJSHtml, nV7PageGJSJson, AV7PageGJSJson, nV8PageIsPublished, AV8PageIsPublished, AV9PageIsPredefined, nV10PageIsContentPage, AV10PageIsContentPage, AV11PageIsDynamicForm, AV12PageIsWebLinkPage, nV13PageChildren, AV13PageChildren, nV14ProductServiceId, AV14ProductServiceId, AV15OrganisationId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("GXA0100");
            }
            /* End Insert */
            pr_default.close(1);
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
         TRN_PAGECO2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         TRN_PAGECO2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         TRN_PAGECO2_n58ProductServiceId = new bool[] {false} ;
         TRN_PAGECO2_A437PageChildren = new string[] {""} ;
         TRN_PAGECO2_n437PageChildren = new bool[] {false} ;
         TRN_PAGECO2_A519PageIsWebLinkPage = new bool[] {false} ;
         TRN_PAGECO2_A514PageIsDynamicForm = new bool[] {false} ;
         TRN_PAGECO2_A439PageIsContentPage = new bool[] {false} ;
         TRN_PAGECO2_n439PageIsContentPage = new bool[] {false} ;
         TRN_PAGECO2_A504PageIsPredefined = new bool[] {false} ;
         TRN_PAGECO2_A434PageIsPublished = new bool[] {false} ;
         TRN_PAGECO2_n434PageIsPublished = new bool[] {false} ;
         TRN_PAGECO2_A433PageGJSJson = new string[] {""} ;
         TRN_PAGECO2_n433PageGJSJson = new bool[] {false} ;
         TRN_PAGECO2_A432PageGJSHtml = new string[] {""} ;
         TRN_PAGECO2_n432PageGJSHtml = new bool[] {false} ;
         TRN_PAGECO2_A431PageJsonContent = new string[] {""} ;
         TRN_PAGECO2_n431PageJsonContent = new bool[] {false} ;
         TRN_PAGECO2_A318Trn_PageName = new string[] {""} ;
         TRN_PAGECO2_A29LocationId = new Guid[] {Guid.Empty} ;
         TRN_PAGECO2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         A437PageChildren = "";
         A433PageGJSJson = "";
         A432PageGJSHtml = "";
         A431PageJsonContent = "";
         A318Trn_PageName = "";
         A29LocationId = Guid.Empty;
         A310Trn_PageId = Guid.Empty;
         AV2Trn_PageId = Guid.Empty;
         AV3LocationId = Guid.Empty;
         AV4Trn_PageName = "";
         AV5PageJsonContent = "";
         AV6PageGJSHtml = "";
         AV7PageGJSJson = "";
         AV13PageChildren = "";
         AV14ProductServiceId = Guid.Empty;
         AV15OrganisationId = Guid.Empty;
         TRN_PAGECO3_AV2Trn_PageId = new Guid[] {Guid.Empty} ;
         TRN_PAGECO3_AV3LocationId = new Guid[] {Guid.Empty} ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_pageconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_PAGECO2_A11OrganisationId, TRN_PAGECO2_A58ProductServiceId, TRN_PAGECO2_n58ProductServiceId, TRN_PAGECO2_A437PageChildren, TRN_PAGECO2_n437PageChildren, TRN_PAGECO2_A519PageIsWebLinkPage, TRN_PAGECO2_A514PageIsDynamicForm, TRN_PAGECO2_A439PageIsContentPage, TRN_PAGECO2_n439PageIsContentPage, TRN_PAGECO2_A504PageIsPredefined,
               TRN_PAGECO2_A434PageIsPublished, TRN_PAGECO2_n434PageIsPublished, TRN_PAGECO2_A433PageGJSJson, TRN_PAGECO2_n433PageGJSJson, TRN_PAGECO2_A432PageGJSHtml, TRN_PAGECO2_n432PageGJSHtml, TRN_PAGECO2_A431PageJsonContent, TRN_PAGECO2_n431PageJsonContent, TRN_PAGECO2_A318Trn_PageName, TRN_PAGECO2_A29LocationId,
               TRN_PAGECO2_A310Trn_PageId
               }
               , new Object[] {
               TRN_PAGECO3_AV2Trn_PageId, TRN_PAGECO3_AV3LocationId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0100 ;
      private string Gx_emsg ;
      private bool n58ProductServiceId ;
      private bool n437PageChildren ;
      private bool A519PageIsWebLinkPage ;
      private bool A514PageIsDynamicForm ;
      private bool A439PageIsContentPage ;
      private bool n439PageIsContentPage ;
      private bool A504PageIsPredefined ;
      private bool A434PageIsPublished ;
      private bool n434PageIsPublished ;
      private bool n433PageGJSJson ;
      private bool n432PageGJSHtml ;
      private bool n431PageJsonContent ;
      private bool nV5PageJsonContent ;
      private bool nV6PageGJSHtml ;
      private bool nV7PageGJSJson ;
      private bool AV8PageIsPublished ;
      private bool nV8PageIsPublished ;
      private bool AV9PageIsPredefined ;
      private bool AV10PageIsContentPage ;
      private bool nV10PageIsContentPage ;
      private bool AV11PageIsDynamicForm ;
      private bool AV12PageIsWebLinkPage ;
      private bool nV13PageChildren ;
      private bool nV14ProductServiceId ;
      private string A437PageChildren ;
      private string A433PageGJSJson ;
      private string A432PageGJSHtml ;
      private string A431PageJsonContent ;
      private string AV5PageJsonContent ;
      private string AV6PageGJSHtml ;
      private string AV7PageGJSJson ;
      private string AV13PageChildren ;
      private string A318Trn_PageName ;
      private string AV4Trn_PageName ;
      private Guid A11OrganisationId ;
      private Guid A58ProductServiceId ;
      private Guid A29LocationId ;
      private Guid A310Trn_PageId ;
      private Guid AV2Trn_PageId ;
      private Guid AV3LocationId ;
      private Guid AV14ProductServiceId ;
      private Guid AV15OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TRN_PAGECO2_A11OrganisationId ;
      private Guid[] TRN_PAGECO2_A58ProductServiceId ;
      private bool[] TRN_PAGECO2_n58ProductServiceId ;
      private string[] TRN_PAGECO2_A437PageChildren ;
      private bool[] TRN_PAGECO2_n437PageChildren ;
      private bool[] TRN_PAGECO2_A519PageIsWebLinkPage ;
      private bool[] TRN_PAGECO2_A514PageIsDynamicForm ;
      private bool[] TRN_PAGECO2_A439PageIsContentPage ;
      private bool[] TRN_PAGECO2_n439PageIsContentPage ;
      private bool[] TRN_PAGECO2_A504PageIsPredefined ;
      private bool[] TRN_PAGECO2_A434PageIsPublished ;
      private bool[] TRN_PAGECO2_n434PageIsPublished ;
      private string[] TRN_PAGECO2_A433PageGJSJson ;
      private bool[] TRN_PAGECO2_n433PageGJSJson ;
      private string[] TRN_PAGECO2_A432PageGJSHtml ;
      private bool[] TRN_PAGECO2_n432PageGJSHtml ;
      private string[] TRN_PAGECO2_A431PageJsonContent ;
      private bool[] TRN_PAGECO2_n431PageJsonContent ;
      private string[] TRN_PAGECO2_A318Trn_PageName ;
      private Guid[] TRN_PAGECO2_A29LocationId ;
      private Guid[] TRN_PAGECO2_A310Trn_PageId ;
      private Guid[] TRN_PAGECO3_AV2Trn_PageId ;
      private Guid[] TRN_PAGECO3_AV3LocationId ;
   }

   public class trn_pageconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTRN_PAGECO2;
          prmTRN_PAGECO2 = new Object[] {
          };
          Object[] prmTRN_PAGECO3;
          prmTRN_PAGECO3 = new Object[] {
          new ParDef("AV2Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmTRN_PAGECO4;
          prmTRN_PAGECO4 = new Object[] {
          new ParDef("AV2Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV4Trn_PageName",GXType.VarChar,100,0) ,
          new ParDef("AV5PageJsonContent",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("AV6PageGJSHtml",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("AV7PageGJSJson",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("AV8PageIsPublished",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("AV9PageIsPredefined",GXType.Boolean,4,0) ,
          new ParDef("AV10PageIsContentPage",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("AV11PageIsDynamicForm",GXType.Boolean,4,0) ,
          new ParDef("AV12PageIsWebLinkPage",GXType.Boolean,4,0) ,
          new ParDef("AV13PageChildren",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("AV14ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV15OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TRN_PAGECO2", "SELECT OrganisationId, ProductServiceId, PageChildren, PageIsWebLinkPage, PageIsDynamicForm, PageIsContentPage, PageIsPredefined, PageIsPublished, PageGJSJson, PageGJSHtml, PageJsonContent, Trn_PageName, LocationId, Trn_PageId FROM Trn_Page ORDER BY Trn_PageId, Trn_PageName, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_PAGECO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_PAGECO3", "SELECT Trn_PageId, LocationId FROM GXA0100 WHERE Trn_PageId = :AV2Trn_PageId AND LocationId = :AV3LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_PAGECO3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_PAGECO4", "INSERT INTO GXA0100(Trn_PageId, LocationId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsPredefined, PageIsContentPage, PageIsDynamicForm, PageIsWebLinkPage, PageChildren, ProductServiceId, OrganisationId) VALUES(:AV2Trn_PageId, :AV3LocationId, :AV4Trn_PageName, :AV5PageJsonContent, :AV6PageGJSHtml, :AV7PageGJSJson, :AV8PageIsPublished, :AV9PageIsPredefined, :AV10PageIsContentPage, :AV11PageIsDynamicForm, :AV12PageIsWebLinkPage, :AV13PageChildren, :AV14ProductServiceId, :AV15OrganisationId)", GxErrorMask.GX_NOMASK,prmTRN_PAGECO4)
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
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.getBool(5);
                ((bool[]) buf[7])[0] = rslt.getBool(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((bool[]) buf[9])[0] = rslt.getBool(7);
                ((bool[]) buf[10])[0] = rslt.getBool(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((string[]) buf[12])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((string[]) buf[14])[0] = rslt.getLongVarchar(10);
                ((bool[]) buf[15])[0] = rslt.wasNull(10);
                ((string[]) buf[16])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[17])[0] = rslt.wasNull(11);
                ((string[]) buf[18])[0] = rslt.getVarchar(12);
                ((Guid[]) buf[19])[0] = rslt.getGuid(13);
                ((Guid[]) buf[20])[0] = rslt.getGuid(14);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
       }
    }

 }

}
