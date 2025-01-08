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
   public class aprc_createpermissions : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_createpermissions().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         execute();
         return GX.GXRuntime.ExitCode ;
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public aprc_createpermissions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_createpermissions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9RoleNameCollection.Add(context.GetMessage( "Resident", ""), 0);
         AV22GAMUser = AV11GAMRepository.getuserbylogin(context.GetMessage( "local", ""), context.GetMessage( "admin", ""), out  AV12GAMErrorCollection);
         AV23GAMPermissionFilter.gxTpr_Applicationid = 2;
         AV28GAMPermissionCollection = AV22GAMUser.getallpermissions(AV23GAMPermissionFilter, out  AV12GAMErrorCollection);
         AV30GXV1 = 1;
         while ( AV30GXV1 <= AV9RoleNameCollection.Count )
         {
            AV17RoleName = ((string)AV9RoleNameCollection.Item(AV30GXV1));
            AV18PermNameCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV19PermFile.Source = context.GetMessage( "perms/", "")+AV17RoleName+context.GetMessage( ".json", "");
            AV21PermJSON = AV19PermFile.ReadAllText("");
            AV18PermNameCollection.FromJSonString(AV21PermJSON, null);
            AV10GAMRole = AV10GAMRole.getbyname(AV17RoleName, out  AV12GAMErrorCollection);
            new prc_logtofile(context ).execute(  ">>> "+AV10GAMRole.gxTpr_Name) ;
            AV31GXV2 = 1;
            while ( AV31GXV2 <= AV28GAMPermissionCollection.Count )
            {
               AV24GAMPermission = ((GeneXus.Programs.genexussecurity.SdtGAMPermission)AV28GAMPermissionCollection.Item(AV31GXV2));
               AV25Name = StringUtil.Trim( AV24GAMPermission.gxTpr_Name);
               if ( (AV18PermNameCollection.IndexOf(StringUtil.RTrim( AV25Name))>0) )
               {
                  AV29isok = AV10GAMRole.addpermission(AV24GAMPermission, out  AV12GAMErrorCollection);
                  if ( AV29isok )
                  {
                     new prc_logtofile(context ).execute(  "          >>> "+AV25Name) ;
                     context.CommitDataStores("prc_createpermissions",pr_default);
                  }
               }
               AV31GXV2 = (int)(AV31GXV2+1);
            }
            AV30GXV1 = (int)(AV30GXV1+1);
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
         AV9RoleNameCollection = new GxSimpleCollection<string>();
         AV22GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV12GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV23GAMPermissionFilter = new GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter(context);
         AV28GAMPermissionCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission>( context, "GeneXus.Programs.genexussecurity.SdtGAMPermission", "GeneXus.Programs");
         AV17RoleName = "";
         AV18PermNameCollection = new GxSimpleCollection<string>();
         AV19PermFile = new GxFile(context.GetPhysicalPath());
         AV21PermJSON = "";
         AV10GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV24GAMPermission = new GeneXus.Programs.genexussecurity.SdtGAMPermission(context);
         AV25Name = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aprc_createpermissions__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.aprc_createpermissions__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_createpermissions__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV30GXV1 ;
      private int AV31GXV2 ;
      private bool AV29isok ;
      private string AV21PermJSON ;
      private string AV17RoleName ;
      private string AV25Name ;
      private GxFile AV19PermFile ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV9RoleNameCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV22GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV12GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV11GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter AV23GAMPermissionFilter ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission> AV28GAMPermissionCollection ;
      private GxSimpleCollection<string> AV18PermNameCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV10GAMRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermission AV24GAMPermission ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class aprc_createpermissions__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class aprc_createpermissions__gam : DataStoreHelperBase, IDataStoreHelper
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

public class aprc_createpermissions__default : DataStoreHelperBase, IDataStoreHelper
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
