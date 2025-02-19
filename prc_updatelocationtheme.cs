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
   public class prc_updatelocationtheme : GXProcedure
   {
      public prc_updatelocationtheme( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updatelocationtheme( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ThemeId ,
                           out SdtSDT_Theme aP1_SDT_Theme ,
                           out SdtSDT_Error aP2_Error )
      {
         this.AV8ThemeId = aP0_ThemeId;
         this.AV11SDT_Theme = new SdtSDT_Theme(context) ;
         this.AV18Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_Theme=this.AV11SDT_Theme;
         aP2_Error=this.AV18Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_ThemeId ,
                                      out SdtSDT_Theme aP1_SDT_Theme )
      {
         execute(aP0_ThemeId, out aP1_SDT_Theme, out aP2_Error);
         return AV18Error ;
      }

      public void executeSubmit( Guid aP0_ThemeId ,
                                 out SdtSDT_Theme aP1_SDT_Theme ,
                                 out SdtSDT_Error aP2_Error )
      {
         this.AV8ThemeId = aP0_ThemeId;
         this.AV11SDT_Theme = new SdtSDT_Theme(context) ;
         this.AV18Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_SDT_Theme=this.AV11SDT_Theme;
         aP2_Error=this.AV18Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV18Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV18Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            AV12BC_Trn_Location.Load(new prc_getuserlocationid(context).executeUdp( ), new prc_getuserorganisationid(context).executeUdp( ));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12BC_Trn_Location.gxTpr_Locationname)) )
            {
               AV12BC_Trn_Location.gxTpr_Trn_themeid = AV8ThemeId;
               AV12BC_Trn_Location.Save();
               if ( AV12BC_Trn_Location.Success() )
               {
                  context.CommitDataStores("prc_updatelocationtheme",pr_default);
                  AV19websession.Remove(context.GetMessage( "NotificationMessage", ""));
                  new prc_logtofile(context ).execute(  context.GetMessage( "Saved", "")) ;
               }
               else
               {
                  AV21GXV2 = 1;
                  AV20GXV1 = AV12BC_Trn_Location.GetMessages();
                  while ( AV21GXV2 <= AV20GXV1.Count )
                  {
                     AV13Message = ((GeneXus.Utils.SdtMessages_Message)AV20GXV1.Item(AV21GXV2));
                     new prc_logtofile(context ).execute(  context.GetMessage( "Not saved: ", "")+AV13Message.gxTpr_Description) ;
                     AV21GXV2 = (int)(AV21GXV2+1);
                  }
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
         AV11SDT_Theme = new SdtSDT_Theme(context);
         AV18Error = new SdtSDT_Error(context);
         AV12BC_Trn_Location = new SdtTrn_Location(context);
         AV19websession = context.GetSession();
         AV20GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV13Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updatelocationtheme__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updatelocationtheme__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updatelocationtheme__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV21GXV2 ;
      private Guid AV8ThemeId ;
      private IGxSession AV19websession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Theme AV11SDT_Theme ;
      private SdtSDT_Error AV18Error ;
      private SdtTrn_Location AV12BC_Trn_Location ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV20GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV13Message ;
      private SdtSDT_Theme aP1_SDT_Theme ;
      private SdtSDT_Error aP2_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updatelocationtheme__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updatelocationtheme__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updatelocationtheme__default : DataStoreHelperBase, IDataStoreHelper
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
