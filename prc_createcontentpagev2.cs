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
   public class prc_createcontentpagev2 : GXProcedure
   {
      public prc_createcontentpagev2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_createcontentpagev2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           string aP1_PageName ,
                           out SdtSDT_AppVersion_PagesItem aP2_PageItem ,
                           out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV13AppVersionId = aP0_AppVersionId;
         this.AV9PageName = aP1_PageName;
         this.AV20PageItem = new SdtSDT_AppVersion_PagesItem(context) ;
         this.AV12SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_PageItem=this.AV20PageItem;
         aP3_SDT_Error=this.AV12SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      string aP1_PageName ,
                                      out SdtSDT_AppVersion_PagesItem aP2_PageItem )
      {
         execute(aP0_AppVersionId, aP1_PageName, out aP2_PageItem, out aP3_SDT_Error);
         return AV12SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 string aP1_PageName ,
                                 out SdtSDT_AppVersion_PagesItem aP2_PageItem ,
                                 out SdtSDT_Error aP3_SDT_Error )
      {
         this.AV13AppVersionId = aP0_AppVersionId;
         this.AV9PageName = aP1_PageName;
         this.AV20PageItem = new SdtSDT_AppVersion_PagesItem(context) ;
         this.AV12SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_PageItem=this.AV20PageItem;
         aP3_SDT_Error=this.AV12SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prc_logtoserver(context ).execute(  context.GetMessage( "&AppVersionId: ", "")+AV13AppVersionId.ToString()) ;
         AV17BC_Trn_AppVersion.Load(AV13AppVersionId);
         new prc_logtoserver(context ).execute(  context.GetMessage( "&BC_Trn_AppVersion: ", "")+AV17BC_Trn_AppVersion.gxTpr_Appversionid.ToString()) ;
         AV21ContentItem.FromJSonString(context.GetMessage( "{ContentType:\"Image\", \"ContentValue\":\"https://images.pexels.com/photos/276267/pexels-photo-276267.jpeg?auto=compress&cs=tinysrgb&w=600\"}", ""), null);
         AV8SDT_ContentPage.gxTpr_Content.Add(AV21ContentItem, 0);
         AV21ContentItem.FromJSonString(context.GetMessage( "{ContentType:\"Description\", \"ContentValue\":\"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.\"}", ""), null);
         AV8SDT_ContentPage.gxTpr_Content.Add(AV21ContentItem, 0);
         AV21ContentItem.FromJSonString(context.GetMessage( "{ContentType:\"Image\", \"ContentValue\":\"https://images.pexels.com/photos/276267/pexels-photo-276267.jpeg?auto=compress&cs=tinysrgb&w=600\"}", ""), null);
         AV8SDT_ContentPage.gxTpr_Content.Add(AV21ContentItem, 0);
         if ( ! (Guid.Empty==AV17BC_Trn_AppVersion.gxTpr_Appversionid) )
         {
            AV18BC_Page.gxTpr_Pagename = AV9PageName;
            AV18BC_Page.gxTpr_Pagetype = "Content";
            AV18BC_Page.gxTpr_Pagestructure = AV8SDT_ContentPage.ToJSonString(false, true);
            AV17BC_Trn_AppVersion.gxTpr_Page.Add(AV18BC_Page, 0);
            AV17BC_Trn_AppVersion.Save();
            if ( AV17BC_Trn_AppVersion.Success() )
            {
               context.CommitDataStores("prc_createcontentpagev2",pr_default);
               AV20PageItem.FromJSonString(AV18BC_Page.ToJSonString(true, true), null);
               AV20PageItem.gxTpr_Pagecontentstructure = AV8SDT_ContentPage;
            }
            else
            {
               AV23GXV2 = 1;
               AV22GXV1 = AV17BC_Trn_AppVersion.GetMessages();
               while ( AV23GXV2 <= AV22GXV1.Count )
               {
                  AV19Message = ((GeneXus.Utils.SdtMessages_Message)AV22GXV1.Item(AV23GXV2));
                  AV12SDT_Error.gxTpr_Message = AV19Message.gxTpr_Description;
                  AV23GXV2 = (int)(AV23GXV2+1);
               }
            }
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
         AV20PageItem = new SdtSDT_AppVersion_PagesItem(context);
         AV12SDT_Error = new SdtSDT_Error(context);
         AV17BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV21ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         AV8SDT_ContentPage = new SdtSDT_ContentPage(context);
         AV18BC_Page = new SdtTrn_AppVersion_Page(context);
         AV22GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV19Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_createcontentpagev2__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_createcontentpagev2__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_createcontentpagev2__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV23GXV2 ;
      private string AV9PageName ;
      private Guid AV13AppVersionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_AppVersion_PagesItem AV20PageItem ;
      private SdtSDT_Error AV12SDT_Error ;
      private SdtTrn_AppVersion AV17BC_Trn_AppVersion ;
      private SdtSDT_ContentPage_ContentItem AV21ContentItem ;
      private SdtSDT_ContentPage AV8SDT_ContentPage ;
      private SdtTrn_AppVersion_Page AV18BC_Page ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV22GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV19Message ;
      private SdtSDT_AppVersion_PagesItem aP2_PageItem ;
      private SdtSDT_Error aP3_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_createcontentpagev2__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_createcontentpagev2__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_createcontentpagev2__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
