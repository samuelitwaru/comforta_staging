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
   public class prc_initlocationpages : GXProcedure
   {
      public prc_initlocationpages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_initlocationpages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_OrganisationId )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV12OrganisationId = aP1_OrganisationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV12OrganisationId = aP1_OrganisationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9PredefinedPagesDictionary.set( "Home",  Guid.NewGuid( ).ToString());
         AV9PredefinedPagesDictionary.set( "Reception",  Guid.NewGuid( ).ToString());
         AV9PredefinedPagesDictionary.set( "Location",  Guid.NewGuid( ).ToString());
         AV9PredefinedPagesDictionary.set( "Calendar",  Guid.NewGuid( ).ToString());
         AV9PredefinedPagesDictionary.set( "Mailbox",  Guid.NewGuid( ).ToString());
         AV14BC_Trn_Location.Load(AV8LocationId, AV12OrganisationId);
         AV23GXV1 = 1;
         while ( AV23GXV1 <= AV9PredefinedPagesDictionary.gxTpr_Keys.Count )
         {
            AV11Key = ((string)AV9PredefinedPagesDictionary.gxTpr_Keys.Item(AV23GXV1));
            AV16Value = AV9PredefinedPagesDictionary.get(AV11Key);
            AV15File = new GxFile(context.GetPhysicalPath());
            AV15File.Source = context.GetMessage( "Resources/UCGrapes1/PredefinedPages/Default", "")+AV11Key+context.GetMessage( ".json", "");
            AV13PageGJSJson = AV15File.ReadAllText("");
            AV15File = new GxFile(context.GetPhysicalPath());
            AV15File.Source = context.GetMessage( "PredefinedPages/Published", "")+AV11Key+context.GetMessage( ".json", "");
            AV22PageJsonContent = AV15File.ReadAllText("");
            AV20PageIsContentPage = false;
            if ( ( StringUtil.StrCmp(AV11Key, "Location") == 0 ) || ( StringUtil.StrCmp(AV11Key, "Reception") == 0 ) )
            {
               AV20PageIsContentPage = true;
            }
            if ( StringUtil.StrCmp(AV11Key, "Location") == 0 )
            {
               AV22PageJsonContent = StringUtil.StringReplace( AV22PageJsonContent, "{{LocationImage}}", AV14BC_Trn_Location.gxTpr_Locationimage_gxi);
               AV22PageJsonContent = StringUtil.StringReplace( AV22PageJsonContent, "{{LocationDescription}}", StringUtil.Trim( AV14BC_Trn_Location.gxTpr_Locationdescription));
               AV22PageJsonContent = StringUtil.StringReplace( AV22PageJsonContent, "{{LocationTelephone}}", AV14BC_Trn_Location.gxTpr_Locationphone);
               AV22PageJsonContent = StringUtil.StringReplace( AV22PageJsonContent, "{{LocationEmail}}", AV14BC_Trn_Location.gxTpr_Locationemail);
            }
            if ( StringUtil.StrCmp(AV11Key, "Home") == 0 )
            {
               AV22PageJsonContent = StringUtil.StringReplace( AV22PageJsonContent, context.GetMessage( "{{LocationPageId}}", ""), AV9PredefinedPagesDictionary.get(context.GetMessage( "Location", "")));
               AV22PageJsonContent = StringUtil.StringReplace( AV22PageJsonContent, context.GetMessage( "{{ReceptionPageId}}", ""), AV9PredefinedPagesDictionary.get(context.GetMessage( "Reception", "")));
               AV22PageJsonContent = StringUtil.StringReplace( AV22PageJsonContent, context.GetMessage( "{{CalendarPageId}}", ""), AV9PredefinedPagesDictionary.get(context.GetMessage( "Calendar", "")));
               AV22PageJsonContent = StringUtil.StringReplace( AV22PageJsonContent, context.GetMessage( "{{MailboxPageId}}", ""), AV9PredefinedPagesDictionary.get(context.GetMessage( "Mailbox", "")));
               AV13PageGJSJson = StringUtil.StringReplace( AV13PageGJSJson, context.GetMessage( "{{LocationPageId}}", ""), AV9PredefinedPagesDictionary.get(context.GetMessage( "Location", "")));
               AV13PageGJSJson = StringUtil.StringReplace( AV13PageGJSJson, context.GetMessage( "{{ReceptionPageId}}", ""), AV9PredefinedPagesDictionary.get(context.GetMessage( "Reception", "")));
               AV13PageGJSJson = StringUtil.StringReplace( AV13PageGJSJson, context.GetMessage( "{{CalendarPageId}}", ""), AV9PredefinedPagesDictionary.get(context.GetMessage( "Calendar", "")));
               AV13PageGJSJson = StringUtil.StringReplace( AV13PageGJSJson, context.GetMessage( "{{MailboxPageId}}", ""), AV9PredefinedPagesDictionary.get(context.GetMessage( "Mailbox", "")));
            }
            AV18BC_Trn_Page = new SdtTrn_Page(context);
            AV18BC_Trn_Page.gxTpr_Trn_pageid = StringUtil.StrToGuid( AV16Value);
            AV18BC_Trn_Page.gxTpr_Trn_pagename = AV11Key;
            AV18BC_Trn_Page.gxTpr_Pageiscontentpage = AV20PageIsContentPage;
            AV18BC_Trn_Page.gxTpr_Pageispredefined = true;
            AV18BC_Trn_Page.gxTpr_Locationid = AV14BC_Trn_Location.gxTpr_Locationid;
            AV18BC_Trn_Page.gxTpr_Organisationid = AV14BC_Trn_Location.gxTpr_Organisationid;
            AV18BC_Trn_Page.gxTpr_Pagegjsjson = AV13PageGJSJson;
            AV18BC_Trn_Page.gxTpr_Pagejsoncontent = AV22PageJsonContent;
            AV18BC_Trn_Page.gxTpr_Pageispublished = true;
            AV18BC_Trn_Page.Save();
            if ( AV18BC_Trn_Page.Success() )
            {
               context.CommitDataStores("prc_initlocationpages",pr_default);
            }
            else
            {
               AV25GXV3 = 1;
               AV24GXV2 = AV18BC_Trn_Page.GetMessages();
               while ( AV25GXV3 <= AV24GXV2.Count )
               {
                  AV19Message = ((GeneXus.Utils.SdtMessages_Message)AV24GXV2.Item(AV25GXV3));
                  new prc_logtofile(context ).execute(  AV19Message.gxTpr_Description) ;
                  AV25GXV3 = (int)(AV25GXV3+1);
               }
            }
            AV23GXV1 = (int)(AV23GXV1+1);
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
         AV9PredefinedPagesDictionary = new GeneXus.Core.genexus.common.SdtDictionary<string, string>();
         AV14BC_Trn_Location = new SdtTrn_Location(context);
         AV11Key = "";
         AV16Value = "";
         AV15File = new GxFile(context.GetPhysicalPath());
         AV13PageGJSJson = "";
         AV22PageJsonContent = "";
         AV20PageIsContentPage = false;
         AV18BC_Trn_Page = new SdtTrn_Page(context);
         AV24GXV2 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV19Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_initlocationpages__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_initlocationpages__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_initlocationpages__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV23GXV1 ;
      private int AV25GXV3 ;
      private bool AV20PageIsContentPage ;
      private string AV13PageGJSJson ;
      private string AV22PageJsonContent ;
      private string AV11Key ;
      private string AV16Value ;
      private Guid AV8LocationId ;
      private Guid AV12OrganisationId ;
      private GxFile AV15File ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Core.genexus.common.SdtDictionary<string, string> AV9PredefinedPagesDictionary ;
      private SdtTrn_Location AV14BC_Trn_Location ;
      private SdtTrn_Page AV18BC_Trn_Page ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV24GXV2 ;
      private GeneXus.Utils.SdtMessages_Message AV19Message ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_initlocationpages__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_initlocationpages__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_initlocationpages__default : DataStoreHelperBase, IDataStoreHelper
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
