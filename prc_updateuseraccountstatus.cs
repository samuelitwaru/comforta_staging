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
   public class prc_updateuseraccountstatus : GXProcedure
   {
      public prc_updateuseraccountstatus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updateuseraccountstatus( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserGUID )
      {
         this.AV14UserGUID = aP0_UserGUID;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_UserGUID )
      {
         this.AV14UserGUID = aP0_UserGUID;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8GAMUser.load( AV14UserGUID);
         if ( AV8GAMUser.checkrole("Organisation Manager") )
         {
            /* Optimized UPDATE. */
            /* Using cursor P007Z2 */
            pr_default.execute(0, new Object[] {AV8GAMUser.gxTpr_Email, AV8GAMUser.gxTpr_Guid});
            pr_default.close(0);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Manager");
            /* End optimized UPDATE. */
         }
         else
         {
            if ( AV8GAMUser.checkrole("Receptionist") )
            {
               /* Optimized UPDATE. */
               /* Using cursor P007Z3 */
               pr_default.execute(1, new Object[] {AV8GAMUser.gxTpr_Email, AV8GAMUser.gxTpr_Guid});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Receptionist");
               /* End optimized UPDATE. */
            }
         }
         new prc_logtofile(context ).execute(  context.GetMessage( "Commit is done. Account is activted", "")) ;
         AV8GAMUser.unblockaccess(out  AV16GAMErrorCollection);
         context.CommitDataStores("prc_updateuseraccountstatus",pr_default);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_updateuseraccountstatus",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV8GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV16GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updateuseraccountstatus__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updateuseraccountstatus__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updateuseraccountstatus__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV14UserGUID ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV8GAMUser ;
      private IDataStoreProvider pr_default ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV16GAMErrorCollection ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updateuseraccountstatus__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updateuseraccountstatus__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updateuseraccountstatus__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new UpdateCursor(def[0])
      ,new UpdateCursor(def[1])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP007Z2;
       prmP007Z2 = new Object[] {
       new ParDef("AV8GAMUser__Email",GXType.VarChar,100,0) ,
       new ParDef("AV8GAMUser__Guid",GXType.Char,40,0)
       };
       Object[] prmP007Z3;
       prmP007Z3 = new Object[] {
       new ParDef("AV8GAMUser__Email",GXType.VarChar,100,0) ,
       new ParDef("AV8GAMUser__Guid",GXType.Char,40,0)
       };
       def= new CursorDef[] {
           new CursorDef("P007Z2", "UPDATE Trn_Manager SET ManagerIsActive=TRUE  WHERE (LOWER(ManagerEmail) = ( :AV8GAMUser__Email)) AND (ManagerGAMGUID = ( :AV8GAMUser__Guid))", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007Z2)
          ,new CursorDef("P007Z3", "UPDATE Trn_Receptionist SET ReceptionistIsActive=TRUE  WHERE (LOWER(ReceptionistEmail) = ( :AV8GAMUser__Email)) AND (ReceptionistGAMGUID = ( :AV8GAMUser__Guid))", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007Z3)
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
