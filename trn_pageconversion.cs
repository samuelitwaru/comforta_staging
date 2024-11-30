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
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_pageconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
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
            A29LocationId = TRN_PAGECO2_A29LocationId[0];
            A11OrganisationId = TRN_PAGECO2_A11OrganisationId[0];
            A58ProductServiceId = TRN_PAGECO2_A58ProductServiceId[0];
            n58ProductServiceId = TRN_PAGECO2_n58ProductServiceId[0];
            A437PageChildren = TRN_PAGECO2_A437PageChildren[0];
            n437PageChildren = TRN_PAGECO2_n437PageChildren[0];
            A439PageIsContentPage = TRN_PAGECO2_A439PageIsContentPage[0];
            n439PageIsContentPage = TRN_PAGECO2_n439PageIsContentPage[0];
            A434PageIsPublished = TRN_PAGECO2_A434PageIsPublished[0];
            n434PageIsPublished = TRN_PAGECO2_n434PageIsPublished[0];
            A433PageGJSJson = TRN_PAGECO2_A433PageGJSJson[0];
            n433PageGJSJson = TRN_PAGECO2_n433PageGJSJson[0];
            A432PageGJSHtml = TRN_PAGECO2_A432PageGJSHtml[0];
            n432PageGJSHtml = TRN_PAGECO2_n432PageGJSHtml[0];
            A431PageJsonContent = TRN_PAGECO2_A431PageJsonContent[0];
            n431PageJsonContent = TRN_PAGECO2_n431PageJsonContent[0];
            A318Trn_PageName = TRN_PAGECO2_A318Trn_PageName[0];
            A310Trn_PageId = TRN_PAGECO2_A310Trn_PageId[0];
            /*
               INSERT RECORD ON TABLE GXA0092

            */
            AV2Trn_PageId = A310Trn_PageId;
            AV3Trn_PageName = A318Trn_PageName;
            if ( TRN_PAGECO2_n431PageJsonContent[0] )
            {
               AV4PageJsonContent = "";
               nV4PageJsonContent = false;
               nV4PageJsonContent = true;
            }
            else
            {
               AV4PageJsonContent = A431PageJsonContent;
               nV4PageJsonContent = false;
            }
            if ( TRN_PAGECO2_n432PageGJSHtml[0] )
            {
               AV5PageGJSHtml = "";
               nV5PageGJSHtml = false;
               nV5PageGJSHtml = true;
            }
            else
            {
               AV5PageGJSHtml = A432PageGJSHtml;
               nV5PageGJSHtml = false;
            }
            if ( TRN_PAGECO2_n433PageGJSJson[0] )
            {
               AV6PageGJSJson = "";
               nV6PageGJSJson = false;
               nV6PageGJSJson = true;
            }
            else
            {
               AV6PageGJSJson = A433PageGJSJson;
               nV6PageGJSJson = false;
            }
            if ( TRN_PAGECO2_n434PageIsPublished[0] )
            {
               AV7PageIsPublished = false;
               nV7PageIsPublished = false;
               nV7PageIsPublished = true;
            }
            else
            {
               AV7PageIsPublished = A434PageIsPublished;
               nV7PageIsPublished = false;
            }
            if ( TRN_PAGECO2_n439PageIsContentPage[0] )
            {
               AV8PageIsContentPage = false;
               nV8PageIsContentPage = false;
               nV8PageIsContentPage = true;
            }
            else
            {
               AV8PageIsContentPage = A439PageIsContentPage;
               nV8PageIsContentPage = false;
            }
            if ( TRN_PAGECO2_n437PageChildren[0] )
            {
               AV9PageChildren = "";
               nV9PageChildren = false;
               nV9PageChildren = true;
            }
            else
            {
               AV9PageChildren = A437PageChildren;
               nV9PageChildren = false;
            }
            if ( TRN_PAGECO2_n58ProductServiceId[0] )
            {
               AV10ProductServiceId = Guid.Empty;
               nV10ProductServiceId = false;
               nV10ProductServiceId = true;
            }
            else
            {
               AV10ProductServiceId = A58ProductServiceId;
               nV10ProductServiceId = false;
            }
            AV11OrganisationId = A11OrganisationId;
            AV12LocationId = A29LocationId;
            /* Using cursor TRN_PAGECO3 */
            pr_default.execute(1, new Object[] {AV2Trn_PageId});
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
               pr_default.execute(2, new Object[] {AV2Trn_PageId, AV3Trn_PageName, nV4PageJsonContent, AV4PageJsonContent, nV5PageGJSHtml, AV5PageGJSHtml, nV6PageGJSJson, AV6PageGJSJson, nV7PageIsPublished, AV7PageIsPublished, nV8PageIsContentPage, AV8PageIsContentPage, nV9PageChildren, AV9PageChildren, nV10ProductServiceId, AV10ProductServiceId, AV11OrganisationId, AV12LocationId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("GXA0092");
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
         TRN_PAGECO2_A29LocationId = new Guid[] {Guid.Empty} ;
         TRN_PAGECO2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         TRN_PAGECO2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         TRN_PAGECO2_n58ProductServiceId = new bool[] {false} ;
         TRN_PAGECO2_A437PageChildren = new string[] {""} ;
         TRN_PAGECO2_n437PageChildren = new bool[] {false} ;
         TRN_PAGECO2_A439PageIsContentPage = new bool[] {false} ;
         TRN_PAGECO2_n439PageIsContentPage = new bool[] {false} ;
         TRN_PAGECO2_A434PageIsPublished = new bool[] {false} ;
         TRN_PAGECO2_n434PageIsPublished = new bool[] {false} ;
         TRN_PAGECO2_A433PageGJSJson = new string[] {""} ;
         TRN_PAGECO2_n433PageGJSJson = new bool[] {false} ;
         TRN_PAGECO2_A432PageGJSHtml = new string[] {""} ;
         TRN_PAGECO2_n432PageGJSHtml = new bool[] {false} ;
         TRN_PAGECO2_A431PageJsonContent = new string[] {""} ;
         TRN_PAGECO2_n431PageJsonContent = new bool[] {false} ;
         TRN_PAGECO2_A318Trn_PageName = new string[] {""} ;
         TRN_PAGECO2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         A437PageChildren = "";
         A433PageGJSJson = "";
         A432PageGJSHtml = "";
         A431PageJsonContent = "";
         A318Trn_PageName = "";
         A310Trn_PageId = Guid.Empty;
         AV2Trn_PageId = Guid.Empty;
         AV3Trn_PageName = "";
         AV4PageJsonContent = "";
         AV5PageGJSHtml = "";
         AV6PageGJSJson = "";
         AV9PageChildren = "";
         AV10ProductServiceId = Guid.Empty;
         AV11OrganisationId = Guid.Empty;
         AV12LocationId = Guid.Empty;
         TRN_PAGECO3_AV2Trn_PageId = new Guid[] {Guid.Empty} ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_pageconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_PAGECO2_A29LocationId, TRN_PAGECO2_A11OrganisationId, TRN_PAGECO2_A58ProductServiceId, TRN_PAGECO2_n58ProductServiceId, TRN_PAGECO2_A437PageChildren, TRN_PAGECO2_n437PageChildren, TRN_PAGECO2_A439PageIsContentPage, TRN_PAGECO2_n439PageIsContentPage, TRN_PAGECO2_A434PageIsPublished, TRN_PAGECO2_n434PageIsPublished,
               TRN_PAGECO2_A433PageGJSJson, TRN_PAGECO2_n433PageGJSJson, TRN_PAGECO2_A432PageGJSHtml, TRN_PAGECO2_n432PageGJSHtml, TRN_PAGECO2_A431PageJsonContent, TRN_PAGECO2_n431PageJsonContent, TRN_PAGECO2_A318Trn_PageName, TRN_PAGECO2_A310Trn_PageId
               }
               , new Object[] {
               TRN_PAGECO3_AV2Trn_PageId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0092 ;
      private string Gx_emsg ;
      private bool n58ProductServiceId ;
      private bool n437PageChildren ;
      private bool A439PageIsContentPage ;
      private bool n439PageIsContentPage ;
      private bool A434PageIsPublished ;
      private bool n434PageIsPublished ;
      private bool n433PageGJSJson ;
      private bool n432PageGJSHtml ;
      private bool n431PageJsonContent ;
      private bool nV4PageJsonContent ;
      private bool nV5PageGJSHtml ;
      private bool nV6PageGJSJson ;
      private bool AV7PageIsPublished ;
      private bool nV7PageIsPublished ;
      private bool AV8PageIsContentPage ;
      private bool nV8PageIsContentPage ;
      private bool nV9PageChildren ;
      private bool nV10ProductServiceId ;
      private string A437PageChildren ;
      private string A433PageGJSJson ;
      private string A432PageGJSHtml ;
      private string A431PageJsonContent ;
      private string AV4PageJsonContent ;
      private string AV5PageGJSHtml ;
      private string AV6PageGJSJson ;
      private string AV9PageChildren ;
      private string A318Trn_PageName ;
      private string AV3Trn_PageName ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A58ProductServiceId ;
      private Guid A310Trn_PageId ;
      private Guid AV2Trn_PageId ;
      private Guid AV10ProductServiceId ;
      private Guid AV11OrganisationId ;
      private Guid AV12LocationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TRN_PAGECO2_A29LocationId ;
      private Guid[] TRN_PAGECO2_A11OrganisationId ;
      private Guid[] TRN_PAGECO2_A58ProductServiceId ;
      private bool[] TRN_PAGECO2_n58ProductServiceId ;
      private string[] TRN_PAGECO2_A437PageChildren ;
      private bool[] TRN_PAGECO2_n437PageChildren ;
      private bool[] TRN_PAGECO2_A439PageIsContentPage ;
      private bool[] TRN_PAGECO2_n439PageIsContentPage ;
      private bool[] TRN_PAGECO2_A434PageIsPublished ;
      private bool[] TRN_PAGECO2_n434PageIsPublished ;
      private string[] TRN_PAGECO2_A433PageGJSJson ;
      private bool[] TRN_PAGECO2_n433PageGJSJson ;
      private string[] TRN_PAGECO2_A432PageGJSHtml ;
      private bool[] TRN_PAGECO2_n432PageGJSHtml ;
      private string[] TRN_PAGECO2_A431PageJsonContent ;
      private bool[] TRN_PAGECO2_n431PageJsonContent ;
      private string[] TRN_PAGECO2_A318Trn_PageName ;
      private Guid[] TRN_PAGECO2_A310Trn_PageId ;
      private Guid[] TRN_PAGECO3_AV2Trn_PageId ;
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
          new ParDef("AV2Trn_PageId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmTRN_PAGECO4;
          prmTRN_PAGECO4 = new Object[] {
          new ParDef("AV2Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3Trn_PageName",GXType.VarChar,100,0) ,
          new ParDef("AV4PageJsonContent",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("AV5PageGJSHtml",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("AV6PageGJSJson",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("AV7PageIsPublished",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("AV8PageIsContentPage",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("AV9PageChildren",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("AV10ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV11OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV12LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TRN_PAGECO2", "SELECT LocationId, OrganisationId, ProductServiceId, PageChildren, PageIsContentPage, PageIsPublished, PageGJSJson, PageGJSHtml, PageJsonContent, Trn_PageName, Trn_PageId FROM Trn_Page ORDER BY Trn_PageId, Trn_PageName, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_PAGECO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_PAGECO3", "SELECT Trn_PageId FROM GXA0092 WHERE Trn_PageId = :AV2Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_PAGECO3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_PAGECO4", "INSERT INTO GXA0092(Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsContentPage, PageChildren, ProductServiceId, OrganisationId, LocationId) VALUES(:AV2Trn_PageId, :AV3Trn_PageName, :AV4PageJsonContent, :AV5PageGJSHtml, :AV6PageGJSJson, :AV7PageIsPublished, :AV8PageIsContentPage, :AV9PageChildren, :AV10ProductServiceId, :AV11OrganisationId, :AV12LocationId)", GxErrorMask.GX_NOMASK,prmTRN_PAGECO4)
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
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((bool[]) buf[6])[0] = rslt.getBool(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((string[]) buf[14])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((string[]) buf[16])[0] = rslt.getVarchar(10);
                ((Guid[]) buf[17])[0] = rslt.getGuid(11);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
