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
   public class prc_createservicepage : GXProcedure
   {
      public prc_createservicepage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_createservicepage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           Guid aP1_ProductServiceId ,
                           out SdtSDT_AppVersion_PagesItem aP2_PageItem ,
                           out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV9AppVersionId = aP0_AppVersionId;
         this.AV10ProductServiceId = aP1_ProductServiceId;
         this.AV26PageItem = new SdtSDT_AppVersion_PagesItem(context) ;
         this.AV24SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_PageItem=this.AV26PageItem;
         aP3_SDT_Error=this.AV24SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      Guid aP1_ProductServiceId ,
                                      out SdtSDT_AppVersion_PagesItem aP2_PageItem )
      {
         execute(aP0_AppVersionId, aP1_ProductServiceId, out aP2_PageItem, out aP3_SDT_Error);
         return AV24SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 Guid aP1_ProductServiceId ,
                                 out SdtSDT_AppVersion_PagesItem aP2_PageItem ,
                                 out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV9AppVersionId = aP0_AppVersionId;
         this.AV10ProductServiceId = aP1_ProductServiceId;
         this.AV26PageItem = new SdtSDT_AppVersion_PagesItem(context) ;
         this.AV24SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_PageItem=this.AV26PageItem;
         aP3_SDT_Error=this.AV24SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV24SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV24SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         GXt_guid1 = AV13LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV13LocationId = GXt_guid1;
         GXt_guid1 = AV14OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         AV14OrganisationId = GXt_guid1;
         AV12BC_Trn_ProductService.Load(AV10ProductServiceId, AV13LocationId, AV14OrganisationId);
         AV23BC_Trn_AppVersion.Load(AV9AppVersionId);
         /* Using cursor P00BR2 */
         pr_default.execute(0, new Object[] {AV9AppVersionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A543AppVersionId = P00BR2_A543AppVersionId[0];
            AV28GXLvl18 = 0;
            /* Using cursor P00BR3 */
            pr_default.execute(1, new Object[] {A543AppVersionId, AV10ProductServiceId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A521PageId = P00BR3_A521PageId[0];
               A523PageStructure = P00BR3_A523PageStructure[0];
               AV28GXLvl18 = 1;
               AV22BC_Page.gxTpr_Pageid = AV10ProductServiceId;
               AV22BC_Page.gxTpr_Pagename = AV12BC_Trn_ProductService.gxTpr_Productservicename;
               AV22BC_Page.gxTpr_Pagetype = "Content";
               AV22BC_Page.gxTpr_Pagestructure = A523PageStructure;
               AV8SDT_ContentPage.FromJSonString(A523PageStructure, null);
               AV26PageItem.FromJSonString(AV22BC_Page.ToJSonString(true, true), null);
               AV26PageItem.gxTpr_Pagecontentstructure = AV8SDT_ContentPage;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( AV28GXLvl18 == 0 )
            {
               /* Execute user subroutine: 'CREATENEWSERVICEPAGE' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      protected void S111( )
      {
         /* 'CREATENEWSERVICEPAGE' Routine */
         returnInSub = false;
         AV22BC_Page.gxTpr_Pageid = AV12BC_Trn_ProductService.gxTpr_Productserviceid;
         AV22BC_Page.gxTpr_Pagename = AV12BC_Trn_ProductService.gxTpr_Productservicename;
         AV22BC_Page.gxTpr_Pagetype = "Content";
         AV16ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         AV16ContentItem.gxTpr_Contenttype = context.GetMessage( "Image", "");
         AV16ContentItem.gxTpr_Contentvalue = AV12BC_Trn_ProductService.gxTpr_Productserviceimage_gxi;
         AV8SDT_ContentPage.gxTpr_Content.Add(AV16ContentItem, 0);
         AV16ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         AV16ContentItem.gxTpr_Contenttype = context.GetMessage( "Description", "");
         AV16ContentItem.gxTpr_Contentvalue = AV12BC_Trn_ProductService.gxTpr_Productservicedescription;
         AV8SDT_ContentPage.gxTpr_Content.Add(AV16ContentItem, 0);
         /* Using cursor P00BR4 */
         pr_default.execute(2, new Object[] {AV12BC_Trn_ProductService.gxTpr_Productserviceid});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A395LocationDynamicFormId = P00BR4_A395LocationDynamicFormId[0];
            n395LocationDynamicFormId = P00BR4_n395LocationDynamicFormId[0];
            A11OrganisationId = P00BR4_A11OrganisationId[0];
            A29LocationId = P00BR4_A29LocationId[0];
            A206WWPFormId = P00BR4_A206WWPFormId[0];
            A207WWPFormVersionNumber = P00BR4_A207WWPFormVersionNumber[0];
            A58ProductServiceId = P00BR4_A58ProductServiceId[0];
            A367CallToActionId = P00BR4_A367CallToActionId[0];
            A397CallToActionName = P00BR4_A397CallToActionName[0];
            A368CallToActionType = P00BR4_A368CallToActionType[0];
            A370CallToActionPhone = P00BR4_A370CallToActionPhone[0];
            A208WWPFormReferenceName = P00BR4_A208WWPFormReferenceName[0];
            A396CallToActionUrl = P00BR4_A396CallToActionUrl[0];
            A369CallToActionEmail = P00BR4_A369CallToActionEmail[0];
            A206WWPFormId = P00BR4_A206WWPFormId[0];
            A207WWPFormVersionNumber = P00BR4_A207WWPFormVersionNumber[0];
            A208WWPFormReferenceName = P00BR4_A208WWPFormReferenceName[0];
            AV17CtaItem = new SdtSDT_ContentPage_CtaItem(context);
            AV17CtaItem.gxTpr_Ctaid = A367CallToActionId;
            AV17CtaItem.gxTpr_Ctalabel = A397CallToActionName;
            AV17CtaItem.gxTpr_Ctatype = A368CallToActionType;
            AV17CtaItem.gxTpr_Ctabuttontype = "Round";
            if ( StringUtil.StrCmp(A368CallToActionType, "Phone") == 0 )
            {
               AV17CtaItem.gxTpr_Ctaaction = A370CallToActionPhone;
            }
            else if ( StringUtil.StrCmp(A368CallToActionType, "Form") == 0 )
            {
               GXt_char2 = "";
               GXt_char3 = context.GetMessage( "Form", "");
               new prc_getcalltoactionformurl(context ).execute( ref  GXt_char3, ref  A208WWPFormReferenceName, out  GXt_char2) ;
               AV17CtaItem.gxTpr_Ctaaction = GXt_char2;
            }
            else if ( StringUtil.StrCmp(A368CallToActionType, "SiteUrl") == 0 )
            {
               AV17CtaItem.gxTpr_Ctaaction = A396CallToActionUrl;
            }
            else if ( StringUtil.StrCmp(A368CallToActionType, "Email") == 0 )
            {
               AV17CtaItem.gxTpr_Ctaaction = A369CallToActionEmail;
            }
            else
            {
            }
            AV8SDT_ContentPage.gxTpr_Cta.Add(AV17CtaItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV22BC_Page.gxTpr_Pagestructure = AV8SDT_ContentPage.ToJSonString(false, true);
         AV23BC_Trn_AppVersion.gxTpr_Page.Add(AV22BC_Page, 0);
         AV23BC_Trn_AppVersion.Save();
         if ( AV23BC_Trn_AppVersion.Success() )
         {
            context.CommitDataStores("prc_createservicepage",pr_default);
            AV26PageItem.FromJSonString(AV22BC_Page.ToJSonString(true, true), null);
            AV26PageItem.gxTpr_Pagecontentstructure = AV8SDT_ContentPage;
         }
         else
         {
            AV31GXV2 = 1;
            AV30GXV1 = AV23BC_Trn_AppVersion.GetMessages();
            while ( AV31GXV2 <= AV30GXV1.Count )
            {
               AV25Message = ((GeneXus.Utils.SdtMessages_Message)AV30GXV1.Item(AV31GXV2));
               AV24SDT_Error.gxTpr_Message = AV25Message.gxTpr_Description;
               AV31GXV2 = (int)(AV31GXV2+1);
            }
         }
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
         AV26PageItem = new SdtSDT_AppVersion_PagesItem(context);
         AV24SDT_Error = new SdtSDT_Error(context);
         AV13LocationId = Guid.Empty;
         AV14OrganisationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         AV12BC_Trn_ProductService = new SdtTrn_ProductService(context);
         AV23BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         P00BR2_A543AppVersionId = new Guid[] {Guid.Empty} ;
         A543AppVersionId = Guid.Empty;
         P00BR3_A543AppVersionId = new Guid[] {Guid.Empty} ;
         P00BR3_A521PageId = new Guid[] {Guid.Empty} ;
         P00BR3_A523PageStructure = new string[] {""} ;
         A521PageId = Guid.Empty;
         A523PageStructure = "";
         AV22BC_Page = new SdtTrn_AppVersion_Page(context);
         AV8SDT_ContentPage = new SdtSDT_ContentPage(context);
         AV16ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         P00BR4_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         P00BR4_n395LocationDynamicFormId = new bool[] {false} ;
         P00BR4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00BR4_A29LocationId = new Guid[] {Guid.Empty} ;
         P00BR4_A206WWPFormId = new short[1] ;
         P00BR4_A207WWPFormVersionNumber = new short[1] ;
         P00BR4_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00BR4_A367CallToActionId = new Guid[] {Guid.Empty} ;
         P00BR4_A397CallToActionName = new string[] {""} ;
         P00BR4_A368CallToActionType = new string[] {""} ;
         P00BR4_A370CallToActionPhone = new string[] {""} ;
         P00BR4_A208WWPFormReferenceName = new string[] {""} ;
         P00BR4_A396CallToActionUrl = new string[] {""} ;
         P00BR4_A369CallToActionEmail = new string[] {""} ;
         A395LocationDynamicFormId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         A367CallToActionId = Guid.Empty;
         A397CallToActionName = "";
         A368CallToActionType = "";
         A370CallToActionPhone = "";
         A208WWPFormReferenceName = "";
         A396CallToActionUrl = "";
         A369CallToActionEmail = "";
         AV17CtaItem = new SdtSDT_ContentPage_CtaItem(context);
         GXt_char2 = "";
         GXt_char3 = "";
         AV30GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV25Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_createservicepage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_createservicepage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_createservicepage__default(),
            new Object[][] {
                new Object[] {
               P00BR2_A543AppVersionId
               }
               , new Object[] {
               P00BR3_A543AppVersionId, P00BR3_A521PageId, P00BR3_A523PageStructure
               }
               , new Object[] {
               P00BR4_A395LocationDynamicFormId, P00BR4_n395LocationDynamicFormId, P00BR4_A11OrganisationId, P00BR4_A29LocationId, P00BR4_A206WWPFormId, P00BR4_A207WWPFormVersionNumber, P00BR4_A58ProductServiceId, P00BR4_A367CallToActionId, P00BR4_A397CallToActionName, P00BR4_A368CallToActionType,
               P00BR4_A370CallToActionPhone, P00BR4_A208WWPFormReferenceName, P00BR4_A396CallToActionUrl, P00BR4_A369CallToActionEmail
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28GXLvl18 ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private int AV31GXV2 ;
      private string A370CallToActionPhone ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private bool returnInSub ;
      private bool n395LocationDynamicFormId ;
      private string A523PageStructure ;
      private string A397CallToActionName ;
      private string A368CallToActionType ;
      private string A208WWPFormReferenceName ;
      private string A396CallToActionUrl ;
      private string A369CallToActionEmail ;
      private Guid AV9AppVersionId ;
      private Guid AV10ProductServiceId ;
      private Guid AV13LocationId ;
      private Guid AV14OrganisationId ;
      private Guid GXt_guid1 ;
      private Guid A543AppVersionId ;
      private Guid A521PageId ;
      private Guid A395LocationDynamicFormId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A58ProductServiceId ;
      private Guid A367CallToActionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppVersion_PagesItem AV26PageItem ;
      private SdtSDT_Error AV24SDT_Error ;
      private SdtTrn_ProductService AV12BC_Trn_ProductService ;
      private SdtTrn_AppVersion AV23BC_Trn_AppVersion ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BR2_A543AppVersionId ;
      private Guid[] P00BR3_A543AppVersionId ;
      private Guid[] P00BR3_A521PageId ;
      private string[] P00BR3_A523PageStructure ;
      private SdtTrn_AppVersion_Page AV22BC_Page ;
      private SdtSDT_ContentPage AV8SDT_ContentPage ;
      private SdtSDT_ContentPage_ContentItem AV16ContentItem ;
      private Guid[] P00BR4_A395LocationDynamicFormId ;
      private bool[] P00BR4_n395LocationDynamicFormId ;
      private Guid[] P00BR4_A11OrganisationId ;
      private Guid[] P00BR4_A29LocationId ;
      private short[] P00BR4_A206WWPFormId ;
      private short[] P00BR4_A207WWPFormVersionNumber ;
      private Guid[] P00BR4_A58ProductServiceId ;
      private Guid[] P00BR4_A367CallToActionId ;
      private string[] P00BR4_A397CallToActionName ;
      private string[] P00BR4_A368CallToActionType ;
      private string[] P00BR4_A370CallToActionPhone ;
      private string[] P00BR4_A208WWPFormReferenceName ;
      private string[] P00BR4_A396CallToActionUrl ;
      private string[] P00BR4_A369CallToActionEmail ;
      private SdtSDT_ContentPage_CtaItem AV17CtaItem ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV30GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV25Message ;
      private SdtSDT_AppVersion_PagesItem aP2_PageItem ;
      private SdtSDT_Error aP3_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_createservicepage__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class prc_createservicepage__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class prc_createservicepage__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00BR2;
       prmP00BR2 = new Object[] {
       new ParDef("AV9AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BR3;
       prmP00BR3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV10ProductServiceId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BR4;
       prmP00BR4 = new Object[] {
       new ParDef("AV12BC_T_1Productserviceid",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00BR2", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :AV9AppVersionId ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BR2,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00BR3", "SELECT AppVersionId, PageId, PageStructure FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId and PageId = :AV10ProductServiceId ORDER BY AppVersionId, PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BR3,1, GxCacheFrequency.OFF ,false,true )
          ,new CursorDef("P00BR4", "SELECT T1.LocationDynamicFormId, T1.OrganisationId, T1.LocationId, T2.WWPFormId, T2.WWPFormVersionNumber, T1.ProductServiceId, T1.CallToActionId, T1.CallToActionName, T1.CallToActionType, T1.CallToActionPhone, T3.WWPFormReferenceName, T1.CallToActionUrl, T1.CallToActionEmail FROM ((Trn_CallToAction T1 LEFT JOIN Trn_LocationDynamicForm T2 ON T2.LocationDynamicFormId = T1.LocationDynamicFormId AND T2.OrganisationId = T1.OrganisationId AND T2.LocationId = T1.LocationId) LEFT JOIN WWP_Form T3 ON T3.WWPFormId = T2.WWPFormId AND T3.WWPFormVersionNumber = T2.WWPFormVersionNumber) WHERE T1.ProductServiceId = :AV12BC_T_1Productserviceid ORDER BY T1.ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BR4,100, GxCacheFrequency.OFF ,true,false )
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
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((bool[]) buf[1])[0] = rslt.wasNull(1);
             ((Guid[]) buf[2])[0] = rslt.getGuid(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             ((short[]) buf[4])[0] = rslt.getShort(4);
             ((short[]) buf[5])[0] = rslt.getShort(5);
             ((Guid[]) buf[6])[0] = rslt.getGuid(6);
             ((Guid[]) buf[7])[0] = rslt.getGuid(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((string[]) buf[9])[0] = rslt.getVarchar(9);
             ((string[]) buf[10])[0] = rslt.getString(10, 20);
             ((string[]) buf[11])[0] = rslt.getVarchar(11);
             ((string[]) buf[12])[0] = rslt.getVarchar(12);
             ((string[]) buf[13])[0] = rslt.getVarchar(13);
             return;
    }
 }

}

}
