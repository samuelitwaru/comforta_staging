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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_createevents : GXProcedure
   {
      public wwp_createevents( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_createevents( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_KBPackageName )
      {
         this.AV22KBPackageName = aP0_KBPackageName;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_KBPackageName )
      {
         this.AV22KBPackageName = aP0_KBPackageName;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12GAMEvents = "user-insert";
         /* Execute user subroutine: 'CREATEGAMEVENTS' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV12GAMEvents = "user-update";
         /* Execute user subroutine: 'CREATEGAMEVENTS' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV12GAMEvents = "user-delete";
         /* Execute user subroutine: 'CREATEGAMEVENTS' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'EXISTGAMEVENT' Routine */
         returnInSub = false;
         AV23ExistGAMEvent = false;
         AV21GAMEventSubscriptionFilter.gxTpr_Event = AV12GAMEvents;
         AV21GAMEventSubscriptionFilter.gxTpr_Descripction = context.GetMessage( "GAM Sync", "");
         AV18GAMEventSubscriptionCollection = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).geteventsubscriptions(AV21GAMEventSubscriptionFilter, out  AV11GAMErrorCollection);
         if ( AV18GAMEventSubscriptionCollection.Count > 0 )
         {
            AV23ExistGAMEvent = true;
         }
      }

      protected void S121( )
      {
         /* 'CREATEGAMEVENTS' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'EXISTGAMEVENT' */
         S111 ();
         if (returnInSub) return;
         if ( ! AV23ExistGAMEvent )
         {
            AV13GAMEventSubscription = new GeneXus.Programs.genexussecurity.SdtGAMEventSubscription(context);
            AV13GAMEventSubscription.gxTpr_Description = context.GetMessage( "GAM Sync", "");
            AV13GAMEventSubscription.gxTpr_Event = AV12GAMEvents;
            /* User Code */
             AV9FileName = "wwpbaseobjects.awwp_synchandler.dll";
            /* User Code */
             AV8ClassName = "GeneXus.Programs.wwpbaseobjects.awwp_synchandler";
            AV13GAMEventSubscription.gxTpr_Filename = AV9FileName;
            AV13GAMEventSubscription.gxTpr_Classname = AV8ClassName;
            AV13GAMEventSubscription.gxTpr_Methodname = "execute";
            AV13GAMEventSubscription.save();
            if ( AV13GAMEventSubscription.success() )
            {
               context.CommitDataStores("wwpbaseobjects.wwp_createevents",pr_default);
               AV17Ok = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).subscribeevent(AV13GAMEventSubscription.gxTpr_Id, out  AV11GAMErrorCollection);
               if ( AV17Ok )
               {
                  /* Execute user subroutine: 'CONVERTGAMERRORTOMESSAGES' */
                  S131 ();
                  if (returnInSub) return;
                  context.CommitDataStores("wwpbaseobjects.wwp_createevents",pr_default);
               }
               else
               {
                  new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  StringUtil.Format( "GAMEvents: %1 - %2, Fail to activate event: %3", AV12GAMEvents, GeneXus.Programs.genexussecuritycommon.gxdomaingamevents.getDescription(context,AV12GAMEvents), AV15Messages.ToJSonString(false), "", "", "", "", "", ""),  AV24Pgmname) ;
               }
            }
            else
            {
               AV11GAMErrorCollection = AV13GAMEventSubscription.geterrors();
               /* Execute user subroutine: 'CONVERTGAMERRORTOMESSAGES' */
               S131 ();
               if (returnInSub) return;
               new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  StringUtil.Format( "GAMEvents: %1 - %2, Fail to subscribe: %3", AV12GAMEvents, GeneXus.Programs.genexussecuritycommon.gxdomaingamevents.getDescription(context,AV12GAMEvents), AV15Messages.ToJSonString(false), "", "", "", "", "", ""),  AV24Pgmname) ;
            }
         }
      }

      protected void S131( )
      {
         /* 'CONVERTGAMERRORTOMESSAGES' Routine */
         returnInSub = false;
         AV25GXV1 = 1;
         while ( AV25GXV1 <= AV11GAMErrorCollection.Count )
         {
            AV10GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11GAMErrorCollection.Item(AV25GXV1));
            AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
            AV14Message.gxTpr_Type = 1;
            AV14Message.gxTpr_Description = AV10GAMError.gxTpr_Message;
            AV14Message.gxTpr_Id = StringUtil.Format( "GAM%2", StringUtil.LTrimStr( (decimal)(AV10GAMError.gxTpr_Code), 12, 0), "", "", "", "", "", "", "", "");
            AV15Messages.Add(AV14Message, 0);
            AV25GXV1 = (int)(AV25GXV1+1);
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
         AV12GAMEvents = "";
         AV21GAMEventSubscriptionFilter = new GeneXus.Programs.genexussecurity.SdtGAMEventSubscriptionFilter(context);
         AV18GAMEventSubscriptionCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMEventSubscription>( context, "GeneXus.Programs.genexussecurity.SdtGAMEventSubscription", "GeneXus.Programs");
         AV11GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV13GAMEventSubscription = new GeneXus.Programs.genexussecurity.SdtGAMEventSubscription(context);
         AV9FileName = "";
         AV8ClassName = "";
         AV15Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV24Pgmname = "";
         AV10GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_createevents__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_createevents__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_createevents__default(),
            new Object[][] {
            }
         );
         AV24Pgmname = "WWPBaseObjects.WWP_CreateEvents";
         /* GeneXus formulas. */
         AV24Pgmname = "WWPBaseObjects.WWP_CreateEvents";
      }

      private int AV25GXV1 ;
      private string AV12GAMEvents ;
      private string AV24Pgmname ;
      private bool returnInSub ;
      private bool AV23ExistGAMEvent ;
      private bool AV17Ok ;
      private string AV22KBPackageName ;
      private string AV9FileName ;
      private string AV8ClassName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMEventSubscriptionFilter AV21GAMEventSubscriptionFilter ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMEventSubscription> AV18GAMEventSubscriptionCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMEventSubscription AV13GAMEventSubscription ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV15Messages ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV10GAMError ;
      private GeneXus.Utils.SdtMessages_Message AV14Message ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_createevents__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_createevents__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_createevents__default : DataStoreHelperBase, IDataStoreHelper
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
