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
                           out SdtSDT_Theme aP1_SDT_Theme )
      {
         this.AV8ThemeId = aP0_ThemeId;
         this.AV11SDT_Theme = new SdtSDT_Theme(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_Theme=this.AV11SDT_Theme;
      }

      public SdtSDT_Theme executeUdp( Guid aP0_ThemeId )
      {
         execute(aP0_ThemeId, out aP1_SDT_Theme);
         return AV11SDT_Theme ;
      }

      public void executeSubmit( Guid aP0_ThemeId ,
                                 out SdtSDT_Theme aP1_SDT_Theme )
      {
         this.AV8ThemeId = aP0_ThemeId;
         this.AV11SDT_Theme = new SdtSDT_Theme(context) ;
         SubmitImpl();
         aP1_SDT_Theme=this.AV11SDT_Theme;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prc_authenticatereceptionist(context ).execute( out  AV14UserName, ref  AV9LocationId, ref  AV10OrganisationId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV14UserName))) )
         {
            cleanup();
            if (true) return;
         }
         AV12BC_Trn_Location.Load(AV9LocationId, AV10OrganisationId);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12BC_Trn_Location.gxTpr_Locationname)) )
         {
            AV12BC_Trn_Location.gxTpr_Trn_themeid = AV8ThemeId;
            AV12BC_Trn_Location.Save();
            if ( AV12BC_Trn_Location.Success() )
            {
               context.CommitDataStores("prc_updatelocationtheme",pr_default);
               new prc_logtofile(context ).execute(  "Saved") ;
            }
            else
            {
               AV16GXV2 = 1;
               AV15GXV1 = AV12BC_Trn_Location.GetMessages();
               while ( AV16GXV2 <= AV15GXV1.Count )
               {
                  AV13Message = ((GeneXus.Utils.SdtMessages_Message)AV15GXV1.Item(AV16GXV2));
                  new prc_logtofile(context ).execute(  "Not saved: "+AV13Message.gxTpr_Description) ;
                  AV16GXV2 = (int)(AV16GXV2+1);
               }
            }
         }
         new prc_logtofile(context ).execute(  "Reached Prc_UpdateLocationTheme") ;
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
         AV14UserName = "";
         AV9LocationId = Guid.Empty;
         AV10OrganisationId = Guid.Empty;
         AV12BC_Trn_Location = new SdtTrn_Location(context);
         AV15GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
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

      private int AV16GXV2 ;
      private string AV14UserName ;
      private Guid AV8ThemeId ;
      private Guid AV9LocationId ;
      private Guid AV10OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Theme AV11SDT_Theme ;
      private SdtTrn_Location AV12BC_Trn_Location ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV15GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV13Message ;
      private SdtSDT_Theme aP1_SDT_Theme ;
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
