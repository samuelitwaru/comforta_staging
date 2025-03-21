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
   public class prc_updateproductservicestructuredata : GXProcedure
   {
      public prc_updateproductservicestructuredata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updateproductservicestructuredata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ProductServiceId ,
                           SdtSDT_ContentPage aP1_SDT_ContentPage ,
                           out SdtSDT_ContentPage aP2_Update_SDT_ContentPage )
      {
         this.AV8ProductServiceId = aP0_ProductServiceId;
         this.AV9SDT_ContentPage = aP1_SDT_ContentPage;
         this.AV10Update_SDT_ContentPage = new SdtSDT_ContentPage(context) ;
         initialize();
         ExecuteImpl();
         aP2_Update_SDT_ContentPage=this.AV10Update_SDT_ContentPage;
      }

      public SdtSDT_ContentPage executeUdp( Guid aP0_ProductServiceId ,
                                            SdtSDT_ContentPage aP1_SDT_ContentPage )
      {
         execute(aP0_ProductServiceId, aP1_SDT_ContentPage, out aP2_Update_SDT_ContentPage);
         return AV10Update_SDT_ContentPage ;
      }

      public void executeSubmit( Guid aP0_ProductServiceId ,
                                 SdtSDT_ContentPage aP1_SDT_ContentPage ,
                                 out SdtSDT_ContentPage aP2_Update_SDT_ContentPage )
      {
         this.AV8ProductServiceId = aP0_ProductServiceId;
         this.AV9SDT_ContentPage = aP1_SDT_ContentPage;
         this.AV10Update_SDT_ContentPage = new SdtSDT_ContentPage(context) ;
         SubmitImpl();
         aP2_Update_SDT_ContentPage=this.AV10Update_SDT_ContentPage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Update_SDT_ContentPage.FromJSonString(AV9SDT_ContentPage.ToJSonString(false, true), null);
         /* Using cursor P00BX2 */
         pr_default.execute(0, new Object[] {AV8ProductServiceId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00BX2_A11OrganisationId[0];
            A29LocationId = P00BX2_A29LocationId[0];
            A58ProductServiceId = P00BX2_A58ProductServiceId[0];
            A40000ProductServiceImage_GXI = P00BX2_A40000ProductServiceImage_GXI[0];
            A60ProductServiceDescription = P00BX2_A60ProductServiceDescription[0];
            AV10Update_SDT_ContentPage.gxTpr_Content.Clear();
            AV14GXV1 = 1;
            while ( AV14GXV1 <= AV9SDT_ContentPage.gxTpr_Content.Count )
            {
               AV11ContentItem = ((SdtSDT_ContentPage_ContentItem)AV9SDT_ContentPage.gxTpr_Content.Item(AV14GXV1));
               AV11ContentItem.gxTpr_Contentid = new SdtRandomStringGenerator(context).generate(15);
               if ( StringUtil.StrCmp(AV11ContentItem.gxTpr_Contenttype, context.GetMessage( "Image", "")) == 0 )
               {
                  AV11ContentItem.gxTpr_Contentvalue = A40000ProductServiceImage_GXI;
               }
               else if ( StringUtil.StrCmp(AV11ContentItem.gxTpr_Contenttype, context.GetMessage( "Description", "")) == 0 )
               {
                  AV11ContentItem.gxTpr_Contentvalue = A60ProductServiceDescription;
               }
               else
               {
               }
               AV10Update_SDT_ContentPage.gxTpr_Content.Add(AV11ContentItem, 0);
               AV14GXV1 = (int)(AV14GXV1+1);
            }
            AV10Update_SDT_ContentPage.gxTpr_Cta.Clear();
            AV15GXV2 = 1;
            while ( AV15GXV2 <= AV9SDT_ContentPage.gxTpr_Cta.Count )
            {
               AV12CtaItem = ((SdtSDT_ContentPage_CtaItem)AV9SDT_ContentPage.gxTpr_Cta.Item(AV15GXV2));
               /* Using cursor P00BX3 */
               pr_default.execute(1, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId, AV12CtaItem.gxTpr_Ctaid});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A395LocationDynamicFormId = P00BX3_A395LocationDynamicFormId[0];
                  n395LocationDynamicFormId = P00BX3_n395LocationDynamicFormId[0];
                  A206WWPFormId = P00BX3_A206WWPFormId[0];
                  A207WWPFormVersionNumber = P00BX3_A207WWPFormVersionNumber[0];
                  A367CallToActionId = P00BX3_A367CallToActionId[0];
                  A368CallToActionType = P00BX3_A368CallToActionType[0];
                  A370CallToActionPhone = P00BX3_A370CallToActionPhone[0];
                  A208WWPFormReferenceName = P00BX3_A208WWPFormReferenceName[0];
                  A396CallToActionUrl = P00BX3_A396CallToActionUrl[0];
                  A369CallToActionEmail = P00BX3_A369CallToActionEmail[0];
                  A206WWPFormId = P00BX3_A206WWPFormId[0];
                  A207WWPFormVersionNumber = P00BX3_A207WWPFormVersionNumber[0];
                  A208WWPFormReferenceName = P00BX3_A208WWPFormReferenceName[0];
                  if ( StringUtil.StrCmp(A368CallToActionType, "Phone") == 0 )
                  {
                     AV12CtaItem.gxTpr_Ctaaction = A370CallToActionPhone;
                  }
                  else if ( StringUtil.StrCmp(A368CallToActionType, "Form") == 0 )
                  {
                     GXt_char1 = "";
                     GXt_char2 = context.GetMessage( "Form", "");
                     new prc_getcalltoactionformurl(context ).execute( ref  GXt_char2, ref  A208WWPFormReferenceName, out  GXt_char1) ;
                     AV12CtaItem.gxTpr_Ctaaction = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(A368CallToActionType, "SiteUrl") == 0 )
                  {
                     AV12CtaItem.gxTpr_Ctaaction = A396CallToActionUrl;
                  }
                  else if ( StringUtil.StrCmp(A368CallToActionType, "Email") == 0 )
                  {
                     AV12CtaItem.gxTpr_Ctaaction = A369CallToActionEmail;
                  }
                  else
                  {
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV10Update_SDT_ContentPage.gxTpr_Cta.Add(AV12CtaItem, 0);
               AV15GXV2 = (int)(AV15GXV2+1);
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
         AV10Update_SDT_ContentPage = new SdtSDT_ContentPage(context);
         P00BX2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00BX2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00BX2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00BX2_A40000ProductServiceImage_GXI = new string[] {""} ;
         P00BX2_A60ProductServiceDescription = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         A40000ProductServiceImage_GXI = "";
         A60ProductServiceDescription = "";
         AV11ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         AV12CtaItem = new SdtSDT_ContentPage_CtaItem(context);
         P00BX3_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         P00BX3_n395LocationDynamicFormId = new bool[] {false} ;
         P00BX3_A206WWPFormId = new short[1] ;
         P00BX3_A207WWPFormVersionNumber = new short[1] ;
         P00BX3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00BX3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00BX3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00BX3_A367CallToActionId = new Guid[] {Guid.Empty} ;
         P00BX3_A368CallToActionType = new string[] {""} ;
         P00BX3_A370CallToActionPhone = new string[] {""} ;
         P00BX3_A208WWPFormReferenceName = new string[] {""} ;
         P00BX3_A396CallToActionUrl = new string[] {""} ;
         P00BX3_A369CallToActionEmail = new string[] {""} ;
         A395LocationDynamicFormId = Guid.Empty;
         A367CallToActionId = Guid.Empty;
         A368CallToActionType = "";
         A370CallToActionPhone = "";
         A208WWPFormReferenceName = "";
         A396CallToActionUrl = "";
         A369CallToActionEmail = "";
         GXt_char1 = "";
         GXt_char2 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updateproductservicestructuredata__default(),
            new Object[][] {
                new Object[] {
               P00BX2_A11OrganisationId, P00BX2_A29LocationId, P00BX2_A58ProductServiceId, P00BX2_A40000ProductServiceImage_GXI, P00BX2_A60ProductServiceDescription
               }
               , new Object[] {
               P00BX3_A395LocationDynamicFormId, P00BX3_n395LocationDynamicFormId, P00BX3_A206WWPFormId, P00BX3_A207WWPFormVersionNumber, P00BX3_A58ProductServiceId, P00BX3_A29LocationId, P00BX3_A11OrganisationId, P00BX3_A367CallToActionId, P00BX3_A368CallToActionType, P00BX3_A370CallToActionPhone,
               P00BX3_A208WWPFormReferenceName, P00BX3_A396CallToActionUrl, P00BX3_A369CallToActionEmail
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private int AV14GXV1 ;
      private int AV15GXV2 ;
      private string A370CallToActionPhone ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private bool n395LocationDynamicFormId ;
      private string A60ProductServiceDescription ;
      private string A40000ProductServiceImage_GXI ;
      private string A368CallToActionType ;
      private string A208WWPFormReferenceName ;
      private string A396CallToActionUrl ;
      private string A369CallToActionEmail ;
      private Guid AV8ProductServiceId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A58ProductServiceId ;
      private Guid A395LocationDynamicFormId ;
      private Guid A367CallToActionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_ContentPage AV9SDT_ContentPage ;
      private SdtSDT_ContentPage AV10Update_SDT_ContentPage ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BX2_A11OrganisationId ;
      private Guid[] P00BX2_A29LocationId ;
      private Guid[] P00BX2_A58ProductServiceId ;
      private string[] P00BX2_A40000ProductServiceImage_GXI ;
      private string[] P00BX2_A60ProductServiceDescription ;
      private SdtSDT_ContentPage_ContentItem AV11ContentItem ;
      private SdtSDT_ContentPage_CtaItem AV12CtaItem ;
      private Guid[] P00BX3_A395LocationDynamicFormId ;
      private bool[] P00BX3_n395LocationDynamicFormId ;
      private short[] P00BX3_A206WWPFormId ;
      private short[] P00BX3_A207WWPFormVersionNumber ;
      private Guid[] P00BX3_A58ProductServiceId ;
      private Guid[] P00BX3_A29LocationId ;
      private Guid[] P00BX3_A11OrganisationId ;
      private Guid[] P00BX3_A367CallToActionId ;
      private string[] P00BX3_A368CallToActionType ;
      private string[] P00BX3_A370CallToActionPhone ;
      private string[] P00BX3_A208WWPFormReferenceName ;
      private string[] P00BX3_A396CallToActionUrl ;
      private string[] P00BX3_A369CallToActionEmail ;
      private SdtSDT_ContentPage aP2_Update_SDT_ContentPage ;
   }

   public class prc_updateproductservicestructuredata__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BX2;
          prmP00BX2 = new Object[] {
          new ParDef("AV8ProductServiceId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00BX3;
          prmP00BX3 = new Object[] {
          new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV12CtaItem__Ctaid",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BX2", "SELECT OrganisationId, LocationId, ProductServiceId, ProductServiceImage_GXI, ProductServiceDescription FROM Trn_ProductService WHERE ProductServiceId = :AV8ProductServiceId ORDER BY ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BX2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BX3", "SELECT T1.LocationDynamicFormId, T2.WWPFormId, T2.WWPFormVersionNumber, T1.ProductServiceId, T1.LocationId, T1.OrganisationId, T1.CallToActionId, T1.CallToActionType, T1.CallToActionPhone, T3.WWPFormReferenceName, T1.CallToActionUrl, T1.CallToActionEmail FROM ((Trn_CallToAction T1 LEFT JOIN Trn_LocationDynamicForm T2 ON T2.LocationDynamicFormId = T1.LocationDynamicFormId AND T2.OrganisationId = T1.OrganisationId AND T2.LocationId = T1.LocationId) LEFT JOIN WWP_Form T3 ON T3.WWPFormId = T2.WWPFormId AND T3.WWPFormVersionNumber = T2.WWPFormVersionNumber) WHERE (T1.ProductServiceId = :ProductServiceId and T1.LocationId = :LocationId and T1.OrganisationId = :OrganisationId) AND ((T1.CallToActionId) = ( :AV12CtaItem__Ctaid)) ORDER BY T1.ProductServiceId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BX3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
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
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                return;
       }
    }

 }

}
