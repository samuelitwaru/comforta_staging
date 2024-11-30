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
   public class prc_loadwwpcontext : GXProcedure
   {
      public prc_loadwwpcontext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_loadwwpcontext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref GeneXus.Programs.wwpbaseobjects.SdtWWPContext aP0_WWPContext )
      {
         this.AV18WWPContext = aP0_WWPContext;
         initialize();
         ExecuteImpl();
         aP0_WWPContext=this.AV18WWPContext;
      }

      public GeneXus.Programs.wwpbaseobjects.SdtWWPContext executeUdp( )
      {
         execute(ref aP0_WWPContext);
         return AV18WWPContext ;
      }

      public void executeSubmit( ref GeneXus.Programs.wwpbaseobjects.SdtWWPContext aP0_WWPContext )
      {
         this.AV18WWPContext = aP0_WWPContext;
         SubmitImpl();
         aP0_WWPContext=this.AV18WWPContext;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV16GAMErrors);
         AV9GAMUser = AV8GAMSession.gxTpr_User;
         AV18WWPContext.gxTpr_Gamuserguid = AV9GAMUser.gxTpr_Guid;
         AV18WWPContext.gxTpr_Gamusername = AV9GAMUser.gxTpr_Name;
         AV18WWPContext.gxTpr_Gamuserfirstname = AV9GAMUser.gxTpr_Firstname;
         AV18WWPContext.gxTpr_Gamuserlastname = AV9GAMUser.gxTpr_Lastname;
         AV18WWPContext.gxTpr_Gamuseremail = AV9GAMUser.gxTpr_Email;
         if ( AV9GAMUser.checkrole("Comforta Admin") )
         {
            AV11UserRoleName = "Comforta Admin";
            AV18WWPContext.gxTpr_Iscomfortaadmin = true;
         }
         if ( AV9GAMUser.checkrole("Resident") )
         {
            AV11UserRoleName = "Resident";
            AV18WWPContext.gxTpr_Isresident = true;
            /* Using cursor P00932 */
            pr_default.execute(0, new Object[] {AV9GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A71ResidentGUID = P00932_A71ResidentGUID[0];
               A11OrganisationId = P00932_A11OrganisationId[0];
               A29LocationId = P00932_A29LocationId[0];
               A62ResidentId = P00932_A62ResidentId[0];
               AV17OrganisationId = A11OrganisationId;
               AV10LocationId = A29LocationId;
               AV18WWPContext.gxTpr_Residentid = A62ResidentId;
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         if ( AV9GAMUser.checkrole("Root Admin") )
         {
            AV18WWPContext.gxTpr_Isrootadmin = true;
         }
         if ( AV9GAMUser.checkrole("Organisation Manager") )
         {
            AV11UserRoleName = "Organisation Manager";
            AV18WWPContext.gxTpr_Isorganisationmanager = true;
            /* Using cursor P00933 */
            pr_default.execute(1, new Object[] {AV9GAMUser.gxTpr_Email, AV9GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A25ManagerEmail = P00933_A25ManagerEmail[0];
               A28ManagerGAMGUID = P00933_A28ManagerGAMGUID[0];
               A11OrganisationId = P00933_A11OrganisationId[0];
               A21ManagerId = P00933_A21ManagerId[0];
               A360ManagerIsMainManager = P00933_A360ManagerIsMainManager[0];
               A394ManagerIsActive = P00933_A394ManagerIsActive[0];
               AV17OrganisationId = A11OrganisationId;
               AV10LocationId = A29LocationId;
               AV18WWPContext.gxTpr_Managerid = A21ManagerId;
               AV18WWPContext.gxTpr_Managerismainmanager = A360ManagerIsMainManager;
               AV18WWPContext.gxTpr_Managerisactive = A394ManagerIsActive;
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         if ( AV9GAMUser.checkrole("Receptionist") )
         {
            AV11UserRoleName = "Receptionist";
            AV18WWPContext.gxTpr_Isreceptionist = true;
            /* Using cursor P00934 */
            pr_default.execute(2, new Object[] {AV9GAMUser.gxTpr_Email, AV9GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A93ReceptionistEmail = P00934_A93ReceptionistEmail[0];
               A95ReceptionistGAMGUID = P00934_A95ReceptionistGAMGUID[0];
               A11OrganisationId = P00934_A11OrganisationId[0];
               A29LocationId = P00934_A29LocationId[0];
               A89ReceptionistId = P00934_A89ReceptionistId[0];
               AV17OrganisationId = A11OrganisationId;
               AV10LocationId = A29LocationId;
               AV18WWPContext.gxTpr_Receptionistid = A89ReceptionistId;
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         /* Using cursor P00935 */
         pr_default.execute(3, new Object[] {AV17OrganisationId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A11OrganisationId = P00935_A11OrganisationId[0];
            A13OrganisationName = P00935_A13OrganisationName[0];
            AV18WWPContext.gxTpr_Organisationid = A11OrganisationId;
            AV18WWPContext.gxTpr_Organisationname = A13OrganisationName;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         /* Using cursor P00936 */
         pr_default.execute(4, new Object[] {AV10LocationId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A29LocationId = P00936_A29LocationId[0];
            A31LocationName = P00936_A31LocationName[0];
            A11OrganisationId = P00936_A11OrganisationId[0];
            AV18WWPContext.gxTpr_Locationid = A29LocationId;
            AV18WWPContext.gxTpr_Locationname = A31LocationName;
            pr_default.readNext(4);
         }
         pr_default.close(4);
         AV24GXLvl74 = 0;
         /* Using cursor P00937 */
         pr_default.execute(5, new Object[] {AV17OrganisationId});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A11OrganisationId = P00937_A11OrganisationId[0];
            A40000OrganisationSettingLogo_GXI = P00937_A40000OrganisationSettingLogo_GXI[0];
            A40001OrganisationSettingFavicon_GXI = P00937_A40001OrganisationSettingFavicon_GXI[0];
            A100OrganisationSettingid = P00937_A100OrganisationSettingid[0];
            A103OrganisationSettingBaseColor = P00937_A103OrganisationSettingBaseColor[0];
            A104OrganisationSettingFontSize = P00937_A104OrganisationSettingFontSize[0];
            A105OrganisationSettingLanguage = P00937_A105OrganisationSettingLanguage[0];
            A101OrganisationSettingLogo = P00937_A101OrganisationSettingLogo[0];
            A102OrganisationSettingFavicon = P00937_A102OrganisationSettingFavicon[0];
            AV24GXLvl74 = 1;
            AV18WWPContext.gxTpr_Organisationsettingid = A100OrganisationSettingid;
            AV18WWPContext.gxTpr_Organisationsettinglogo = A101OrganisationSettingLogo;
            AV18WWPContext.gxTpr_Organisationsettinglogo_gxi = A40000OrganisationSettingLogo_GXI;
            AV18WWPContext.gxTpr_Organisationsettingfavicon = A102OrganisationSettingFavicon;
            AV18WWPContext.gxTpr_Organisationsettingfavicon_gxi = A40001OrganisationSettingFavicon_GXI;
            AV18WWPContext.gxTpr_Organisationsettingbasecolor = A103OrganisationSettingBaseColor;
            AV18WWPContext.gxTpr_Organisationsettingfontsize = A104OrganisationSettingFontSize;
            AV18WWPContext.gxTpr_Organisationsettinglanguage = A105OrganisationSettingLanguage;
            AV18WWPContext.gxTpr_Organisationsettingtrnmode = "UPD";
            pr_default.readNext(5);
         }
         pr_default.close(5);
         if ( AV24GXLvl74 == 0 )
         {
            AV18WWPContext.gxTpr_Organisationsettingbasecolor = "Teal";
            AV18WWPContext.gxTpr_Organisationsettingfontsize = "Medium";
            AV18WWPContext.gxTpr_Organisationsettingtrnmode = "INS";
         }
         GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem1 = AV13DashboardItems;
         new dp_getdashboarditems(context ).execute( out  GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem1) ;
         AV13DashboardItems = GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem1;
         AV25GXV1 = 1;
         while ( AV25GXV1 <= AV13DashboardItems.Count )
         {
            AV12DashboardItem = ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)AV13DashboardItems.Item(AV25GXV1));
            if ( StringUtil.StrCmp(AV11UserRoleName, AV12DashboardItem.gxTpr_Rolename) == 0 )
            {
               AV14FilteredDashboardItems.Add(AV12DashboardItem, 0);
            }
            else
            {
               if ( ( String.IsNullOrEmpty(StringUtil.RTrim( AV12DashboardItem.gxTpr_Rolename)) || ( StringUtil.StrCmp(AV12DashboardItem.gxTpr_Rolename, "All") == 0 ) ) && ( StringUtil.StrCmp(AV11UserRoleName, "Comforta Admin") != 0 ) )
               {
                  AV14FilteredDashboardItems.Add(AV12DashboardItem, 0);
               }
            }
            AV25GXV1 = (int)(AV25GXV1+1);
         }
         AV18WWPContext.gxTpr_Filtereddashboarditems = AV14FilteredDashboardItems;
         AV15FooterText = context.GetMessage( "Comforta Software", "");
         if ( AV18WWPContext.gxTpr_Isorganisationmanager )
         {
            AV15FooterText = AV18WWPContext.gxTpr_Organisationname;
         }
         else
         {
            if ( AV18WWPContext.gxTpr_Isreceptionist )
            {
               AV15FooterText = AV18WWPContext.gxTpr_Organisationname + " : " + AV18WWPContext.gxTpr_Locationname;
            }
         }
         AV18WWPContext.gxTpr_Footertext = AV15FooterText;
         AV18WWPContext.gxTpr_Iscontextset = true;
         new GeneXus.Programs.wwpbaseobjects.setwwpcontext(context ).execute(  AV18WWPContext) ;
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
         AV8GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV16GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV11UserRoleName = "";
         P00932_A71ResidentGUID = new string[] {""} ;
         P00932_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00932_A29LocationId = new Guid[] {Guid.Empty} ;
         P00932_A62ResidentId = new Guid[] {Guid.Empty} ;
         A71ResidentGUID = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         AV17OrganisationId = Guid.Empty;
         AV10LocationId = Guid.Empty;
         P00933_A25ManagerEmail = new string[] {""} ;
         P00933_A28ManagerGAMGUID = new string[] {""} ;
         P00933_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00933_A21ManagerId = new Guid[] {Guid.Empty} ;
         P00933_A360ManagerIsMainManager = new bool[] {false} ;
         P00933_A394ManagerIsActive = new bool[] {false} ;
         A25ManagerEmail = "";
         A28ManagerGAMGUID = "";
         A21ManagerId = Guid.Empty;
         P00934_A93ReceptionistEmail = new string[] {""} ;
         P00934_A95ReceptionistGAMGUID = new string[] {""} ;
         P00934_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00934_A29LocationId = new Guid[] {Guid.Empty} ;
         P00934_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         A93ReceptionistEmail = "";
         A95ReceptionistGAMGUID = "";
         A89ReceptionistId = Guid.Empty;
         P00935_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00935_A13OrganisationName = new string[] {""} ;
         A13OrganisationName = "";
         P00936_A29LocationId = new Guid[] {Guid.Empty} ;
         P00936_A31LocationName = new string[] {""} ;
         P00936_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A31LocationName = "";
         P00937_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00937_A40000OrganisationSettingLogo_GXI = new string[] {""} ;
         P00937_A40001OrganisationSettingFavicon_GXI = new string[] {""} ;
         P00937_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         P00937_A103OrganisationSettingBaseColor = new string[] {""} ;
         P00937_A104OrganisationSettingFontSize = new string[] {""} ;
         P00937_A105OrganisationSettingLanguage = new string[] {""} ;
         P00937_A101OrganisationSettingLogo = new string[] {""} ;
         P00937_A102OrganisationSettingFavicon = new string[] {""} ;
         A40000OrganisationSettingLogo_GXI = "";
         A40001OrganisationSettingFavicon_GXI = "";
         A100OrganisationSettingid = Guid.Empty;
         A103OrganisationSettingBaseColor = "";
         A104OrganisationSettingFontSize = "";
         A105OrganisationSettingLanguage = "";
         A101OrganisationSettingLogo = "";
         A102OrganisationSettingFavicon = "";
         AV13DashboardItems = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Comforta_version2");
         GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Comforta_version2");
         AV12DashboardItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         AV14FilteredDashboardItems = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Comforta_version2");
         AV15FooterText = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_loadwwpcontext__default(),
            new Object[][] {
                new Object[] {
               P00932_A71ResidentGUID, P00932_A11OrganisationId, P00932_A29LocationId, P00932_A62ResidentId
               }
               , new Object[] {
               P00933_A25ManagerEmail, P00933_A28ManagerGAMGUID, P00933_A11OrganisationId, P00933_A21ManagerId, P00933_A360ManagerIsMainManager, P00933_A394ManagerIsActive
               }
               , new Object[] {
               P00934_A93ReceptionistEmail, P00934_A95ReceptionistGAMGUID, P00934_A11OrganisationId, P00934_A29LocationId, P00934_A89ReceptionistId
               }
               , new Object[] {
               P00935_A11OrganisationId, P00935_A13OrganisationName
               }
               , new Object[] {
               P00936_A29LocationId, P00936_A31LocationName, P00936_A11OrganisationId
               }
               , new Object[] {
               P00937_A11OrganisationId, P00937_A40000OrganisationSettingLogo_GXI, P00937_A40001OrganisationSettingFavicon_GXI, P00937_A100OrganisationSettingid, P00937_A103OrganisationSettingBaseColor, P00937_A104OrganisationSettingFontSize, P00937_A105OrganisationSettingLanguage, P00937_A101OrganisationSettingLogo, P00937_A102OrganisationSettingFavicon
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24GXLvl74 ;
      private int AV25GXV1 ;
      private bool A360ManagerIsMainManager ;
      private bool A394ManagerIsActive ;
      private string A105OrganisationSettingLanguage ;
      private string AV11UserRoleName ;
      private string A71ResidentGUID ;
      private string A25ManagerEmail ;
      private string A28ManagerGAMGUID ;
      private string A93ReceptionistEmail ;
      private string A95ReceptionistGAMGUID ;
      private string A13OrganisationName ;
      private string A31LocationName ;
      private string A40000OrganisationSettingLogo_GXI ;
      private string A40001OrganisationSettingFavicon_GXI ;
      private string A103OrganisationSettingBaseColor ;
      private string A104OrganisationSettingFontSize ;
      private string AV15FooterText ;
      private string A101OrganisationSettingLogo ;
      private string A102OrganisationSettingFavicon ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private Guid AV17OrganisationId ;
      private Guid AV10LocationId ;
      private Guid A21ManagerId ;
      private Guid A89ReceptionistId ;
      private Guid A100OrganisationSettingid ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV18WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext aP0_WWPContext ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV8GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV16GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private IDataStoreProvider pr_default ;
      private string[] P00932_A71ResidentGUID ;
      private Guid[] P00932_A11OrganisationId ;
      private Guid[] P00932_A29LocationId ;
      private Guid[] P00932_A62ResidentId ;
      private string[] P00933_A25ManagerEmail ;
      private string[] P00933_A28ManagerGAMGUID ;
      private Guid[] P00933_A11OrganisationId ;
      private Guid[] P00933_A21ManagerId ;
      private bool[] P00933_A360ManagerIsMainManager ;
      private bool[] P00933_A394ManagerIsActive ;
      private string[] P00934_A93ReceptionistEmail ;
      private string[] P00934_A95ReceptionistGAMGUID ;
      private Guid[] P00934_A11OrganisationId ;
      private Guid[] P00934_A29LocationId ;
      private Guid[] P00934_A89ReceptionistId ;
      private Guid[] P00935_A11OrganisationId ;
      private string[] P00935_A13OrganisationName ;
      private Guid[] P00936_A29LocationId ;
      private string[] P00936_A31LocationName ;
      private Guid[] P00936_A11OrganisationId ;
      private Guid[] P00937_A11OrganisationId ;
      private string[] P00937_A40000OrganisationSettingLogo_GXI ;
      private string[] P00937_A40001OrganisationSettingFavicon_GXI ;
      private Guid[] P00937_A100OrganisationSettingid ;
      private string[] P00937_A103OrganisationSettingBaseColor ;
      private string[] P00937_A104OrganisationSettingFontSize ;
      private string[] P00937_A105OrganisationSettingLanguage ;
      private string[] P00937_A101OrganisationSettingLogo ;
      private string[] P00937_A102OrganisationSettingFavicon ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> AV13DashboardItems ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem AV12DashboardItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> AV14FilteredDashboardItems ;
   }

   public class prc_loadwwpcontext__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00932;
          prmP00932 = new Object[] {
          new ParDef("AV9GAMUser__Guid",GXType.Char,40,0)
          };
          Object[] prmP00933;
          prmP00933 = new Object[] {
          new ParDef("AV9GAMUser__Email",GXType.VarChar,100,0) ,
          new ParDef("AV9GAMUser__Guid",GXType.Char,40,0)
          };
          Object[] prmP00934;
          prmP00934 = new Object[] {
          new ParDef("AV9GAMUser__Email",GXType.VarChar,100,0) ,
          new ParDef("AV9GAMUser__Guid",GXType.Char,40,0)
          };
          Object[] prmP00935;
          prmP00935 = new Object[] {
          new ParDef("AV17OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00936;
          prmP00936 = new Object[] {
          new ParDef("AV10LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00937;
          prmP00937 = new Object[] {
          new ParDef("AV17OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00932", "SELECT ResidentGUID, OrganisationId, LocationId, ResidentId FROM Trn_Resident WHERE ResidentGUID = ( :AV9GAMUser__Guid) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00932,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00933", "SELECT ManagerEmail, ManagerGAMGUID, OrganisationId, ManagerId, ManagerIsMainManager, ManagerIsActive FROM Trn_Manager WHERE (LOWER(ManagerEmail) = ( :AV9GAMUser__Email)) AND (ManagerGAMGUID = ( :AV9GAMUser__Guid)) ORDER BY ManagerId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00933,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00934", "SELECT ReceptionistEmail, ReceptionistGAMGUID, OrganisationId, LocationId, ReceptionistId FROM Trn_Receptionist WHERE (LOWER(ReceptionistEmail) = ( :AV9GAMUser__Email)) AND (ReceptionistGAMGUID = ( :AV9GAMUser__Guid)) ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00934,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00935", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation WHERE OrganisationId = :AV17OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00935,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00936", "SELECT LocationId, LocationName, OrganisationId FROM Trn_Location WHERE LocationId = :AV10LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00936,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00937", "SELECT OrganisationId, OrganisationSettingLogo_GXI, OrganisationSettingFavicon_GXI, OrganisationSettingid, OrganisationSettingBaseColor, OrganisationSettingFontSize, OrganisationSettingLanguage, OrganisationSettingLogo, OrganisationSettingFavicon FROM Trn_OrganisationSetting WHERE OrganisationId = :AV17OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00937,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(2));
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(3));
                return;
       }
    }

 }

}
