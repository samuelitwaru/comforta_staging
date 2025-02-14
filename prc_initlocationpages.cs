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
         AV25Folder = context.GetMessage( "Resources/UCGrapes1/PredefinedPages/", "");
         AV14BC_Trn_Location.Load(AV8LocationId, AV12OrganisationId);
         new prc_logtofile(context ).execute(  context.GetMessage( "starting", "")) ;
         new prc_logtoserver(context ).execute(  context.GetMessage( "starting", "")) ;
         /* Execute user subroutine: 'CREATERECEPTIONPAGE' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CREATECALENDARPAGE' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CREATELOCATIONPAGE' */
         S141 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CREATEMAILBOXPAGE' */
         S151 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CREATEHOMEPAGE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'CREATEHOMEPAGE' Routine */
         returnInSub = false;
         AV30GXLvl17 = 0;
         /* Using cursor P00A42 */
         pr_default.execute(0, new Object[] {AV8LocationId, AV12OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A318Trn_PageName = P00A42_A318Trn_PageName[0];
            A504PageIsPredefined = P00A42_A504PageIsPredefined[0];
            A11OrganisationId = P00A42_A11OrganisationId[0];
            A29LocationId = P00A42_A29LocationId[0];
            A310Trn_PageId = P00A42_A310Trn_PageId[0];
            if ( StringUtil.StrCmp(A318Trn_PageName, context.GetMessage( "Home", "")) == 0 )
            {
               AV30GXLvl17 = 1;
               AV28HomePageId = A310Trn_PageId;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV30GXLvl17 == 0 )
         {
            new prc_logtofile(context ).execute(  context.GetMessage( "creating home page..", "")) ;
            AV15File = new GxFile(context.GetPhysicalPath());
            AV15File.Source = AV25Folder+context.GetMessage( "DefaultHome.json", "");
            AV13PageGJSJson = AV15File.ReadAllText("");
            AV15File = new GxFile(context.GetPhysicalPath());
            AV15File.Source = AV25Folder+context.GetMessage( "PublishedHome.json", "");
            AV22PageJsonContent = AV15File.ReadAllText("");
            AV22PageJsonContent = StringUtil.StringReplace( AV22PageJsonContent, context.GetMessage( "{{LocationPageId}}", ""), AV26LocationPageId.ToString());
            AV22PageJsonContent = StringUtil.StringReplace( AV22PageJsonContent, context.GetMessage( "{{ReceptionPageId}}", ""), AV23ReceptionPageId.ToString());
            AV22PageJsonContent = StringUtil.StringReplace( AV22PageJsonContent, context.GetMessage( "{{CalendarPageId}}", ""), AV24CalendarPageId.ToString());
            AV22PageJsonContent = StringUtil.StringReplace( AV22PageJsonContent, context.GetMessage( "{{MailboxPageId}}", ""), AV27MailboxPageId.ToString());
            AV13PageGJSJson = StringUtil.StringReplace( AV13PageGJSJson, context.GetMessage( "{{LocationPageId}}", ""), AV26LocationPageId.ToString());
            AV13PageGJSJson = StringUtil.StringReplace( AV13PageGJSJson, context.GetMessage( "{{ReceptionPageId}}", ""), AV23ReceptionPageId.ToString());
            AV13PageGJSJson = StringUtil.StringReplace( AV13PageGJSJson, context.GetMessage( "{{CalendarPageId}}", ""), AV24CalendarPageId.ToString());
            AV13PageGJSJson = StringUtil.StringReplace( AV13PageGJSJson, context.GetMessage( "{{MailboxPageId}}", ""), AV27MailboxPageId.ToString());
            AV18BC_Trn_Page = new SdtTrn_Page(context);
            AV18BC_Trn_Page.gxTpr_Trn_pageid = Guid.NewGuid( );
            AV18BC_Trn_Page.gxTpr_Trn_pagename = context.GetMessage( "Home", "");
            AV18BC_Trn_Page.gxTpr_Pageiscontentpage = false;
            AV18BC_Trn_Page.gxTpr_Pageispredefined = true;
            AV18BC_Trn_Page.gxTpr_Locationid = AV14BC_Trn_Location.gxTpr_Locationid;
            AV18BC_Trn_Page.gxTpr_Organisationid = AV14BC_Trn_Location.gxTpr_Organisationid;
            AV18BC_Trn_Page.gxTpr_Pagegjsjson = AV13PageGJSJson;
            AV18BC_Trn_Page.gxTpr_Pagejsoncontent = AV22PageJsonContent;
            AV18BC_Trn_Page.gxTpr_Pageispublished = true;
            AV18BC_Trn_Page.Save();
            AV28HomePageId = AV18BC_Trn_Page.gxTpr_Trn_pageid;
            if ( AV18BC_Trn_Page.Success() )
            {
               context.CommitDataStores("prc_initlocationpages",pr_default);
            }
            else
            {
               AV32GXV2 = 1;
               AV31GXV1 = AV18BC_Trn_Page.GetMessages();
               while ( AV32GXV2 <= AV31GXV1.Count )
               {
                  AV19Message = ((GeneXus.Utils.SdtMessages_Message)AV31GXV1.Item(AV32GXV2));
                  new prc_logtofile(context ).execute(  ">>>"+AV19Message.gxTpr_Description) ;
                  AV32GXV2 = (int)(AV32GXV2+1);
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'CREATERECEPTIONPAGE' Routine */
         returnInSub = false;
         AV33GXLvl67 = 0;
         /* Using cursor P00A43 */
         pr_default.execute(1, new Object[] {AV8LocationId, AV12OrganisationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A318Trn_PageName = P00A43_A318Trn_PageName[0];
            A504PageIsPredefined = P00A43_A504PageIsPredefined[0];
            A11OrganisationId = P00A43_A11OrganisationId[0];
            A29LocationId = P00A43_A29LocationId[0];
            A310Trn_PageId = P00A43_A310Trn_PageId[0];
            if ( StringUtil.StrCmp(A318Trn_PageName, context.GetMessage( "Reception", "")) == 0 )
            {
               AV33GXLvl67 = 1;
               AV23ReceptionPageId = A310Trn_PageId;
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( AV33GXLvl67 == 0 )
         {
            new prc_logtofile(context ).execute(  context.GetMessage( "Creating reception...", "")) ;
            AV15File = new GxFile(context.GetPhysicalPath());
            AV15File.Source = AV25Folder+context.GetMessage( "DefaultReception.json", "");
            AV13PageGJSJson = AV15File.ReadAllText("");
            AV15File = new GxFile(context.GetPhysicalPath());
            AV15File.Source = AV25Folder+context.GetMessage( "PublishedReception.json", "");
            AV22PageJsonContent = AV15File.ReadAllText("");
            AV18BC_Trn_Page = new SdtTrn_Page(context);
            AV18BC_Trn_Page.gxTpr_Trn_pageid = Guid.NewGuid( );
            AV18BC_Trn_Page.gxTpr_Trn_pagename = context.GetMessage( "Reception", "");
            AV18BC_Trn_Page.gxTpr_Pageiscontentpage = true;
            AV18BC_Trn_Page.gxTpr_Pageispredefined = true;
            AV18BC_Trn_Page.gxTpr_Locationid = AV8LocationId;
            AV18BC_Trn_Page.gxTpr_Organisationid = AV12OrganisationId;
            AV18BC_Trn_Page.gxTpr_Pagegjsjson = AV13PageGJSJson;
            AV18BC_Trn_Page.gxTpr_Pagejsoncontent = AV22PageJsonContent;
            AV18BC_Trn_Page.Save();
            AV18BC_Trn_Page.gxTpr_Pageispublished = true;
            if ( AV18BC_Trn_Page.Success() )
            {
               new prc_logtofile(context ).execute(  context.GetMessage( "created reception", "")) ;
               new prc_logtofile(context ).execute(  AV18BC_Trn_Page.ToJSonString(true, true)) ;
               context.CommitDataStores("prc_initlocationpages",pr_default);
               AV23ReceptionPageId = AV18BC_Trn_Page.gxTpr_Trn_pageid;
            }
            else
            {
               AV35GXV4 = 1;
               AV34GXV3 = AV18BC_Trn_Page.GetMessages();
               while ( AV35GXV4 <= AV34GXV3.Count )
               {
                  AV19Message = ((GeneXus.Utils.SdtMessages_Message)AV34GXV3.Item(AV35GXV4));
                  new prc_logtofile(context ).execute(  AV19Message.gxTpr_Description) ;
                  AV35GXV4 = (int)(AV35GXV4+1);
               }
            }
         }
      }

      protected void S131( )
      {
         /* 'CREATECALENDARPAGE' Routine */
         returnInSub = false;
         AV36GXLvl108 = 0;
         /* Using cursor P00A44 */
         pr_default.execute(2, new Object[] {AV8LocationId, AV12OrganisationId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A318Trn_PageName = P00A44_A318Trn_PageName[0];
            A504PageIsPredefined = P00A44_A504PageIsPredefined[0];
            A11OrganisationId = P00A44_A11OrganisationId[0];
            A29LocationId = P00A44_A29LocationId[0];
            A310Trn_PageId = P00A44_A310Trn_PageId[0];
            if ( StringUtil.StrCmp(A318Trn_PageName, context.GetMessage( "Calendar", "")) == 0 )
            {
               AV36GXLvl108 = 1;
               AV24CalendarPageId = A310Trn_PageId;
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( AV36GXLvl108 == 0 )
         {
            new prc_logtofile(context ).execute(  context.GetMessage( "Creating calendar...", "")) ;
            AV15File = new GxFile(context.GetPhysicalPath());
            AV15File.Source = AV25Folder+context.GetMessage( "DefaultCalendar.json", "");
            AV13PageGJSJson = AV15File.ReadAllText("");
            AV15File = new GxFile(context.GetPhysicalPath());
            AV15File.Source = AV25Folder+context.GetMessage( "PublishedCalendar.json", "");
            AV22PageJsonContent = AV15File.ReadAllText("");
            AV18BC_Trn_Page = new SdtTrn_Page(context);
            AV18BC_Trn_Page.gxTpr_Trn_pageid = Guid.NewGuid( );
            AV18BC_Trn_Page.gxTpr_Trn_pagename = context.GetMessage( "Calendar", "");
            AV18BC_Trn_Page.gxTpr_Pageiscontentpage = true;
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
               new prc_logtofile(context ).execute(  context.GetMessage( "created calendar", "")) ;
               AV24CalendarPageId = AV18BC_Trn_Page.gxTpr_Trn_pageid;
            }
            else
            {
               AV38GXV6 = 1;
               AV37GXV5 = AV18BC_Trn_Page.GetMessages();
               while ( AV38GXV6 <= AV37GXV5.Count )
               {
                  AV19Message = ((GeneXus.Utils.SdtMessages_Message)AV37GXV5.Item(AV38GXV6));
                  new prc_logtofile(context ).execute(  AV19Message.gxTpr_Description) ;
                  AV38GXV6 = (int)(AV38GXV6+1);
               }
            }
         }
      }

      protected void S141( )
      {
         /* 'CREATELOCATIONPAGE' Routine */
         returnInSub = false;
         AV39GXLvl148 = 0;
         /* Using cursor P00A45 */
         pr_default.execute(3, new Object[] {AV8LocationId, AV12OrganisationId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A318Trn_PageName = P00A45_A318Trn_PageName[0];
            A504PageIsPredefined = P00A45_A504PageIsPredefined[0];
            A11OrganisationId = P00A45_A11OrganisationId[0];
            A29LocationId = P00A45_A29LocationId[0];
            A310Trn_PageId = P00A45_A310Trn_PageId[0];
            if ( StringUtil.StrCmp(A318Trn_PageName, context.GetMessage( "Location", "")) == 0 )
            {
               AV39GXLvl148 = 1;
               AV26LocationPageId = A310Trn_PageId;
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( AV39GXLvl148 == 0 )
         {
            new prc_logtofile(context ).execute(  context.GetMessage( "Creating location...", "")) ;
            AV15File = new GxFile(context.GetPhysicalPath());
            AV15File.Source = AV25Folder+context.GetMessage( "DefaultLocation.json", "");
            AV13PageGJSJson = AV15File.ReadAllText("");
            AV15File = new GxFile(context.GetPhysicalPath());
            AV15File.Source = AV25Folder+context.GetMessage( "PublishedLocation.json", "");
            AV22PageJsonContent = AV15File.ReadAllText("");
            AV18BC_Trn_Page = new SdtTrn_Page(context);
            AV18BC_Trn_Page.gxTpr_Trn_pageid = Guid.NewGuid( );
            AV18BC_Trn_Page.gxTpr_Trn_pagename = context.GetMessage( "Location", "");
            AV18BC_Trn_Page.gxTpr_Pageiscontentpage = true;
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
               AV26LocationPageId = AV18BC_Trn_Page.gxTpr_Trn_pageid;
            }
            else
            {
               AV41GXV8 = 1;
               AV40GXV7 = AV18BC_Trn_Page.GetMessages();
               while ( AV41GXV8 <= AV40GXV7.Count )
               {
                  AV19Message = ((GeneXus.Utils.SdtMessages_Message)AV40GXV7.Item(AV41GXV8));
                  new prc_logtofile(context ).execute(  AV19Message.gxTpr_Description) ;
                  AV41GXV8 = (int)(AV41GXV8+1);
               }
            }
         }
      }

      protected void S151( )
      {
         /* 'CREATEMAILBOXPAGE' Routine */
         returnInSub = false;
         AV42GXLvl187 = 0;
         /* Using cursor P00A46 */
         pr_default.execute(4, new Object[] {AV8LocationId, AV12OrganisationId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A318Trn_PageName = P00A46_A318Trn_PageName[0];
            A504PageIsPredefined = P00A46_A504PageIsPredefined[0];
            A11OrganisationId = P00A46_A11OrganisationId[0];
            A29LocationId = P00A46_A29LocationId[0];
            A310Trn_PageId = P00A46_A310Trn_PageId[0];
            if ( StringUtil.StrCmp(A318Trn_PageName, context.GetMessage( "Mailbox", "")) == 0 )
            {
               AV42GXLvl187 = 1;
               AV24CalendarPageId = A310Trn_PageId;
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
         if ( AV42GXLvl187 == 0 )
         {
            new prc_logtofile(context ).execute(  context.GetMessage( "Creating mailbox...", "")) ;
            AV15File = new GxFile(context.GetPhysicalPath());
            AV15File.Source = AV25Folder+context.GetMessage( "DefaultMailbox.json", "");
            AV13PageGJSJson = AV15File.ReadAllText("");
            AV15File = new GxFile(context.GetPhysicalPath());
            AV15File.Source = AV25Folder+context.GetMessage( "PublishedMailbox.json", "");
            AV22PageJsonContent = AV15File.ReadAllText("");
            AV18BC_Trn_Page = new SdtTrn_Page(context);
            AV18BC_Trn_Page.gxTpr_Trn_pageid = Guid.NewGuid( );
            AV18BC_Trn_Page.gxTpr_Trn_pagename = context.GetMessage( "Mailbox", "");
            AV18BC_Trn_Page.gxTpr_Pageiscontentpage = true;
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
               new prc_logtofile(context ).execute(  context.GetMessage( "created mailbox", "")) ;
               AV27MailboxPageId = AV18BC_Trn_Page.gxTpr_Trn_pageid;
            }
            else
            {
               AV44GXV10 = 1;
               AV43GXV9 = AV18BC_Trn_Page.GetMessages();
               while ( AV44GXV10 <= AV43GXV9.Count )
               {
                  AV19Message = ((GeneXus.Utils.SdtMessages_Message)AV43GXV9.Item(AV44GXV10));
                  new prc_logtofile(context ).execute(  AV19Message.gxTpr_Description) ;
                  AV44GXV10 = (int)(AV44GXV10+1);
               }
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
         AV25Folder = "";
         AV14BC_Trn_Location = new SdtTrn_Location(context);
         P00A42_A318Trn_PageName = new string[] {""} ;
         P00A42_A504PageIsPredefined = new bool[] {false} ;
         P00A42_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00A42_A29LocationId = new Guid[] {Guid.Empty} ;
         P00A42_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         A318Trn_PageName = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A310Trn_PageId = Guid.Empty;
         AV28HomePageId = Guid.Empty;
         AV15File = new GxFile(context.GetPhysicalPath());
         AV13PageGJSJson = "";
         AV22PageJsonContent = "";
         AV26LocationPageId = Guid.Empty;
         AV23ReceptionPageId = Guid.Empty;
         AV24CalendarPageId = Guid.Empty;
         AV27MailboxPageId = Guid.Empty;
         AV18BC_Trn_Page = new SdtTrn_Page(context);
         AV31GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV19Message = new GeneXus.Utils.SdtMessages_Message(context);
         P00A43_A318Trn_PageName = new string[] {""} ;
         P00A43_A504PageIsPredefined = new bool[] {false} ;
         P00A43_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00A43_A29LocationId = new Guid[] {Guid.Empty} ;
         P00A43_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         AV34GXV3 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P00A44_A318Trn_PageName = new string[] {""} ;
         P00A44_A504PageIsPredefined = new bool[] {false} ;
         P00A44_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00A44_A29LocationId = new Guid[] {Guid.Empty} ;
         P00A44_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         AV37GXV5 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P00A45_A318Trn_PageName = new string[] {""} ;
         P00A45_A504PageIsPredefined = new bool[] {false} ;
         P00A45_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00A45_A29LocationId = new Guid[] {Guid.Empty} ;
         P00A45_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         AV40GXV7 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P00A46_A318Trn_PageName = new string[] {""} ;
         P00A46_A504PageIsPredefined = new bool[] {false} ;
         P00A46_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00A46_A29LocationId = new Guid[] {Guid.Empty} ;
         P00A46_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         AV43GXV9 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
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
                new Object[] {
               P00A42_A318Trn_PageName, P00A42_A504PageIsPredefined, P00A42_A11OrganisationId, P00A42_A29LocationId, P00A42_A310Trn_PageId
               }
               , new Object[] {
               P00A43_A318Trn_PageName, P00A43_A504PageIsPredefined, P00A43_A11OrganisationId, P00A43_A29LocationId, P00A43_A310Trn_PageId
               }
               , new Object[] {
               P00A44_A318Trn_PageName, P00A44_A504PageIsPredefined, P00A44_A11OrganisationId, P00A44_A29LocationId, P00A44_A310Trn_PageId
               }
               , new Object[] {
               P00A45_A318Trn_PageName, P00A45_A504PageIsPredefined, P00A45_A11OrganisationId, P00A45_A29LocationId, P00A45_A310Trn_PageId
               }
               , new Object[] {
               P00A46_A318Trn_PageName, P00A46_A504PageIsPredefined, P00A46_A11OrganisationId, P00A46_A29LocationId, P00A46_A310Trn_PageId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV30GXLvl17 ;
      private short AV33GXLvl67 ;
      private short AV36GXLvl108 ;
      private short AV39GXLvl148 ;
      private short AV42GXLvl187 ;
      private int AV32GXV2 ;
      private int AV35GXV4 ;
      private int AV38GXV6 ;
      private int AV41GXV8 ;
      private int AV44GXV10 ;
      private bool returnInSub ;
      private bool A504PageIsPredefined ;
      private string AV13PageGJSJson ;
      private string AV22PageJsonContent ;
      private string AV25Folder ;
      private string A318Trn_PageName ;
      private Guid AV8LocationId ;
      private Guid AV12OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A310Trn_PageId ;
      private Guid AV28HomePageId ;
      private Guid AV26LocationPageId ;
      private Guid AV23ReceptionPageId ;
      private Guid AV24CalendarPageId ;
      private Guid AV27MailboxPageId ;
      private GxFile AV15File ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_Location AV14BC_Trn_Location ;
      private IDataStoreProvider pr_default ;
      private string[] P00A42_A318Trn_PageName ;
      private bool[] P00A42_A504PageIsPredefined ;
      private Guid[] P00A42_A11OrganisationId ;
      private Guid[] P00A42_A29LocationId ;
      private Guid[] P00A42_A310Trn_PageId ;
      private SdtTrn_Page AV18BC_Trn_Page ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV31GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV19Message ;
      private string[] P00A43_A318Trn_PageName ;
      private bool[] P00A43_A504PageIsPredefined ;
      private Guid[] P00A43_A11OrganisationId ;
      private Guid[] P00A43_A29LocationId ;
      private Guid[] P00A43_A310Trn_PageId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV34GXV3 ;
      private string[] P00A44_A318Trn_PageName ;
      private bool[] P00A44_A504PageIsPredefined ;
      private Guid[] P00A44_A11OrganisationId ;
      private Guid[] P00A44_A29LocationId ;
      private Guid[] P00A44_A310Trn_PageId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV37GXV5 ;
      private string[] P00A45_A318Trn_PageName ;
      private bool[] P00A45_A504PageIsPredefined ;
      private Guid[] P00A45_A11OrganisationId ;
      private Guid[] P00A45_A29LocationId ;
      private Guid[] P00A45_A310Trn_PageId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV40GXV7 ;
      private string[] P00A46_A318Trn_PageName ;
      private bool[] P00A46_A504PageIsPredefined ;
      private Guid[] P00A46_A11OrganisationId ;
      private Guid[] P00A46_A29LocationId ;
      private Guid[] P00A46_A310Trn_PageId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV43GXV9 ;
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
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new ForEachCursor(def[4])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00A42;
       prmP00A42 = new Object[] {
       new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV12OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00A43;
       prmP00A43 = new Object[] {
       new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV12OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00A44;
       prmP00A44 = new Object[] {
       new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV12OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00A45;
       prmP00A45 = new Object[] {
       new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV12OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00A46;
       prmP00A46 = new Object[] {
       new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV12OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00A42", "SELECT Trn_PageName, PageIsPredefined, OrganisationId, LocationId, Trn_PageId FROM Trn_Page WHERE (LocationId = :AV8LocationId) AND (OrganisationId = :AV12OrganisationId) AND (PageIsPredefined = TRUE) ORDER BY Trn_PageId, Trn_PageName, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A42,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("P00A43", "SELECT Trn_PageName, PageIsPredefined, OrganisationId, LocationId, Trn_PageId FROM Trn_Page WHERE (LocationId = :AV8LocationId) AND (OrganisationId = :AV12OrganisationId) AND (PageIsPredefined = TRUE) ORDER BY Trn_PageId, Trn_PageName, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A43,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("P00A44", "SELECT Trn_PageName, PageIsPredefined, OrganisationId, LocationId, Trn_PageId FROM Trn_Page WHERE (LocationId = :AV8LocationId) AND (OrganisationId = :AV12OrganisationId) AND (PageIsPredefined = TRUE) ORDER BY Trn_PageId, Trn_PageName, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A44,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("P00A45", "SELECT Trn_PageName, PageIsPredefined, OrganisationId, LocationId, Trn_PageId FROM Trn_Page WHERE (LocationId = :AV8LocationId) AND (OrganisationId = :AV12OrganisationId) AND (PageIsPredefined = TRUE) ORDER BY Trn_PageId, Trn_PageName, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A45,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("P00A46", "SELECT Trn_PageName, PageIsPredefined, OrganisationId, LocationId, Trn_PageId FROM Trn_Page WHERE (LocationId = :AV8LocationId) AND (OrganisationId = :AV12OrganisationId) AND (PageIsPredefined = TRUE) ORDER BY Trn_PageId, Trn_PageName, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A46,100, GxCacheFrequency.OFF ,false,false )
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
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((bool[]) buf[1])[0] = rslt.getBool(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((bool[]) buf[1])[0] = rslt.getBool(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((bool[]) buf[1])[0] = rslt.getBool(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((bool[]) buf[1])[0] = rslt.getBool(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((bool[]) buf[1])[0] = rslt.getBool(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
    }
 }

}

}
