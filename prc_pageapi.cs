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
                           out SdtSDT_MobilePage aP3_SDT_MobilePage )
      {
         this.AV11PageId = aP0_PageId;
         this.AV10LocationId = aP1_LocationId;
         this.AV9OrganisationId = aP2_OrganisationId;
         this.AV8SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         initialize();
         ExecuteImpl();
         aP3_SDT_MobilePage=this.AV8SDT_MobilePage;
      }

      public SdtSDT_MobilePage executeUdp( Guid aP0_PageId ,
                                           Guid aP1_LocationId ,
                                           Guid aP2_OrganisationId )
      {
         execute(aP0_PageId, aP1_LocationId, aP2_OrganisationId, out aP3_SDT_MobilePage);
         return AV8SDT_MobilePage ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId ,
                                 out SdtSDT_MobilePage aP3_SDT_MobilePage )
      {
         this.AV11PageId = aP0_PageId;
         this.AV10LocationId = aP1_LocationId;
         this.AV9OrganisationId = aP2_OrganisationId;
         this.AV8SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         SubmitImpl();
         aP3_SDT_MobilePage=this.AV8SDT_MobilePage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P009C2 */
         pr_default.execute(0, new Object[] {AV11PageId, AV10LocationId, AV9OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P009C2_A29LocationId[0];
            A11OrganisationId = P009C2_A11OrganisationId[0];
            A58ProductServiceId = P009C2_A58ProductServiceId[0];
            n58ProductServiceId = P009C2_n58ProductServiceId[0];
            A310Trn_PageId = P009C2_A310Trn_PageId[0];
            A431PageJsonContent = P009C2_A431PageJsonContent[0];
            n431PageJsonContent = P009C2_n431PageJsonContent[0];
            A318Trn_PageName = P009C2_A318Trn_PageName[0];
            A434PageIsPublished = P009C2_A434PageIsPublished[0];
            n434PageIsPublished = P009C2_n434PageIsPublished[0];
            A439PageIsContentPage = P009C2_A439PageIsContentPage[0];
            n439PageIsContentPage = P009C2_n439PageIsContentPage[0];
            AV8SDT_MobilePage = new SdtSDT_MobilePage(context);
            AV8SDT_MobilePage.FromJSonString(A431PageJsonContent, null);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A431PageJsonContent))) )
            {
               AV8SDT_MobilePage.gxTpr_Pageid = A310Trn_PageId;
               AV8SDT_MobilePage.gxTpr_Pagename = A318Trn_PageName;
               AV8SDT_MobilePage.gxTpr_Pageispublished = A434PageIsPublished;
               AV8SDT_MobilePage.gxTpr_Pageiscontentpage = A439PageIsContentPage;
            }
            AV15GXV1 = 1;
            while ( AV15GXV1 <= AV8SDT_MobilePage.gxTpr_Row.Count )
            {
               AV12SDT_Row = ((SdtSDT_Row)AV8SDT_MobilePage.gxTpr_Row.Item(AV15GXV1));
               AV16GXV2 = 1;
               while ( AV16GXV2 <= AV12SDT_Row.gxTpr_Col.Count )
               {
                  AV13SDT_Col = ((SdtSDT_Col)AV12SDT_Row.gxTpr_Col.Item(AV16GXV2));
                  if ( ( StringUtil.StartsWith( AV13SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objecttype, "Dynamic Forms") ) && ( ( StringUtil.StrCmp(AV13SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objecturl, "") == 0 ) ) )
                  {
                     /* Using cursor P009C3 */
                     pr_default.execute(1, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId, AV13SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objectid});
                     while ( (pr_default.getStatus(1) != 101) )
                     {
                        A395LocationDynamicFormId = P009C3_A395LocationDynamicFormId[0];
                        n395LocationDynamicFormId = P009C3_n395LocationDynamicFormId[0];
                        A206WWPFormId = P009C3_A206WWPFormId[0];
                        A207WWPFormVersionNumber = P009C3_A207WWPFormVersionNumber[0];
                        A367CallToActionId = P009C3_A367CallToActionId[0];
                        A208WWPFormReferenceName = P009C3_A208WWPFormReferenceName[0];
                        A206WWPFormId = P009C3_A206WWPFormId[0];
                        A207WWPFormVersionNumber = P009C3_A207WWPFormVersionNumber[0];
                        A208WWPFormReferenceName = P009C3_A208WWPFormReferenceName[0];
                        GXt_char1 = "";
                        GXt_char2 = "Form";
                        new prc_getcalltoactionformurl(context ).execute( ref  GXt_char2, ref  A208WWPFormReferenceName, out  GXt_char1) ;
                        AV13SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objecturl = GXt_char1;
                        pr_default.readNext(1);
                     }
                     pr_default.close(1);
                  }
                  AV16GXV2 = (int)(AV16GXV2+1);
               }
               AV15GXV1 = (int)(AV15GXV1+1);
            }
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
         AV8SDT_MobilePage = new SdtSDT_MobilePage(context);
         P009C2_A29LocationId = new Guid[] {Guid.Empty} ;
         P009C2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009C2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P009C2_n58ProductServiceId = new bool[] {false} ;
         P009C2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P009C2_A431PageJsonContent = new string[] {""} ;
         P009C2_n431PageJsonContent = new bool[] {false} ;
         P009C2_A318Trn_PageName = new string[] {""} ;
         P009C2_A434PageIsPublished = new bool[] {false} ;
         P009C2_n434PageIsPublished = new bool[] {false} ;
         P009C2_A439PageIsContentPage = new bool[] {false} ;
         P009C2_n439PageIsContentPage = new bool[] {false} ;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         A310Trn_PageId = Guid.Empty;
         A431PageJsonContent = "";
         A318Trn_PageName = "";
         AV12SDT_Row = new SdtSDT_Row(context);
         AV13SDT_Col = new SdtSDT_Col(context);
         P009C3_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         P009C3_n395LocationDynamicFormId = new bool[] {false} ;
         P009C3_A206WWPFormId = new short[1] ;
         P009C3_A207WWPFormVersionNumber = new short[1] ;
         P009C3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P009C3_n58ProductServiceId = new bool[] {false} ;
         P009C3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009C3_A29LocationId = new Guid[] {Guid.Empty} ;
         P009C3_A367CallToActionId = new Guid[] {Guid.Empty} ;
         P009C3_A208WWPFormReferenceName = new string[] {""} ;
         A395LocationDynamicFormId = Guid.Empty;
         A367CallToActionId = Guid.Empty;
         A208WWPFormReferenceName = "";
         GXt_char1 = "";
         GXt_char2 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_pageapi__default(),
            new Object[][] {
                new Object[] {
               P009C2_A29LocationId, P009C2_A11OrganisationId, P009C2_A58ProductServiceId, P009C2_n58ProductServiceId, P009C2_A310Trn_PageId, P009C2_A431PageJsonContent, P009C2_n431PageJsonContent, P009C2_A318Trn_PageName, P009C2_A434PageIsPublished, P009C2_n434PageIsPublished,
               P009C2_A439PageIsContentPage, P009C2_n439PageIsContentPage
               }
               , new Object[] {
               P009C3_A395LocationDynamicFormId, P009C3_n395LocationDynamicFormId, P009C3_A206WWPFormId, P009C3_A207WWPFormVersionNumber, P009C3_A58ProductServiceId, P009C3_A11OrganisationId, P009C3_A29LocationId, P009C3_A367CallToActionId, P009C3_A208WWPFormReferenceName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private int AV15GXV1 ;
      private int AV16GXV2 ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private bool n58ProductServiceId ;
      private bool n431PageJsonContent ;
      private bool A434PageIsPublished ;
      private bool n434PageIsPublished ;
      private bool A439PageIsContentPage ;
      private bool n439PageIsContentPage ;
      private bool n395LocationDynamicFormId ;
      private string A431PageJsonContent ;
      private string A318Trn_PageName ;
      private string A208WWPFormReferenceName ;
      private Guid AV11PageId ;
      private Guid AV10LocationId ;
      private Guid AV9OrganisationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A58ProductServiceId ;
      private Guid A310Trn_PageId ;
      private Guid A395LocationDynamicFormId ;
      private Guid A367CallToActionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_MobilePage AV8SDT_MobilePage ;
      private IDataStoreProvider pr_default ;
      private Guid[] P009C2_A29LocationId ;
      private Guid[] P009C2_A11OrganisationId ;
      private Guid[] P009C2_A58ProductServiceId ;
      private bool[] P009C2_n58ProductServiceId ;
      private Guid[] P009C2_A310Trn_PageId ;
      private string[] P009C2_A431PageJsonContent ;
      private bool[] P009C2_n431PageJsonContent ;
      private string[] P009C2_A318Trn_PageName ;
      private bool[] P009C2_A434PageIsPublished ;
      private bool[] P009C2_n434PageIsPublished ;
      private bool[] P009C2_A439PageIsContentPage ;
      private bool[] P009C2_n439PageIsContentPage ;
      private SdtSDT_Row AV12SDT_Row ;
      private SdtSDT_Col AV13SDT_Col ;
      private Guid[] P009C3_A395LocationDynamicFormId ;
      private bool[] P009C3_n395LocationDynamicFormId ;
      private short[] P009C3_A206WWPFormId ;
      private short[] P009C3_A207WWPFormVersionNumber ;
      private Guid[] P009C3_A58ProductServiceId ;
      private bool[] P009C3_n58ProductServiceId ;
      private Guid[] P009C3_A11OrganisationId ;
      private Guid[] P009C3_A29LocationId ;
      private Guid[] P009C3_A367CallToActionId ;
      private string[] P009C3_A208WWPFormReferenceName ;
      private SdtSDT_MobilePage aP3_SDT_MobilePage ;
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
          new ParDef("AV11PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP009C3;
          prmP009C3 = new Object[] {
          new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV13SDT__1Tile_1Tileaction_1O",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009C2", "SELECT LocationId, OrganisationId, ProductServiceId, Trn_PageId, PageJsonContent, Trn_PageName, PageIsPublished, PageIsContentPage FROM Trn_Page WHERE (Trn_PageId = :AV11PageId) AND (LocationId = :AV10LocationId) AND (OrganisationId = :AV9OrganisationId) ORDER BY Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009C2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009C3", "SELECT T1.LocationDynamicFormId, T2.WWPFormId, T2.WWPFormVersionNumber, T1.ProductServiceId, T1.OrganisationId, T1.LocationId, T1.CallToActionId, T3.WWPFormReferenceName FROM ((Trn_CallToAction T1 LEFT JOIN Trn_LocationDynamicForm T2 ON T2.LocationDynamicFormId = T1.LocationDynamicFormId AND T2.OrganisationId = T1.OrganisationId AND T2.LocationId = T1.LocationId) LEFT JOIN WWP_Form T3 ON T3.WWPFormId = T2.WWPFormId AND T3.WWPFormVersionNumber = T2.WWPFormVersionNumber) WHERE (T1.ProductServiceId = :ProductServiceId and T1.LocationId = :LocationId and T1.OrganisationId = :OrganisationId) AND (T1.CallToActionId = :AV13SDT__1Tile_1Tileaction_1O) ORDER BY T1.ProductServiceId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009C3,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.getBool(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((bool[]) buf[10])[0] = rslt.getBool(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                ((Guid[]) buf[5])[0] = rslt.getGuid(5);
                ((Guid[]) buf[6])[0] = rslt.getGuid(6);
                ((Guid[]) buf[7])[0] = rslt.getGuid(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                return;
       }
    }

 }

}
