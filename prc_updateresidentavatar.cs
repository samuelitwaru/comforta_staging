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
   public class prc_updateresidentavatar : GXProcedure
   {
      public prc_updateresidentavatar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updateresidentavatar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_base64Image ,
                           string aP1_ResidentGUID ,
                           out string aP2_response )
      {
         this.AV8base64Image = aP0_base64Image;
         this.AV11ResidentGUID = aP1_ResidentGUID;
         this.AV14response = "" ;
         initialize();
         ExecuteImpl();
         aP2_response=this.AV14response;
      }

      public string executeUdp( string aP0_base64Image ,
                                string aP1_ResidentGUID )
      {
         execute(aP0_base64Image, aP1_ResidentGUID, out aP2_response);
         return AV14response ;
      }

      public void executeSubmit( string aP0_base64Image ,
                                 string aP1_ResidentGUID ,
                                 out string aP2_response )
      {
         this.AV8base64Image = aP0_base64Image;
         this.AV11ResidentGUID = aP1_ResidentGUID;
         this.AV14response = "" ;
         SubmitImpl();
         aP2_response=this.AV14response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8base64Image)) )
         {
            AV12base64String = GxRegex.Split(AV8base64Image,",").GetString(2);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12base64String)) )
         {
            AV10Blob=context.FileFromBase64( AV8base64Image) ;
         }
         else
         {
            AV10Blob=context.FileFromBase64( AV12base64String) ;
         }
         /* Using cursor P00A22 */
         pr_default.execute(0, new Object[] {AV11ResidentGUID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A71ResidentGUID = P00A22_A71ResidentGUID[0];
            A40000ResidentImage_GXI = P00A22_A40000ResidentImage_GXI[0];
            n40000ResidentImage_GXI = P00A22_n40000ResidentImage_GXI[0];
            A11OrganisationId = P00A22_A11OrganisationId[0];
            A29LocationId = P00A22_A29LocationId[0];
            A62ResidentId = P00A22_A62ResidentId[0];
            A457ResidentImage = P00A22_A457ResidentImage[0];
            n457ResidentImage = P00A22_n457ResidentImage[0];
            A457ResidentImage = AV10Blob;
            n457ResidentImage = false;
            A40000ResidentImage_GXI = GXDbFile.GetUriFromFile( "", "", AV10Blob);
            n40000ResidentImage_GXI = false;
            AV13Trn_Resident.Load(A62ResidentId, A29LocationId, A11OrganisationId);
            /* Using cursor P00A23 */
            pr_default.execute(1, new Object[] {n457ResidentImage, A457ResidentImage, n40000ResidentImage_GXI, A40000ResidentImage_GXI, A62ResidentId, A29LocationId, A11OrganisationId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV13Trn_Resident.gxTpr_Residentimage = AV10Blob;
         AV13Trn_Resident.gxTpr_Residentimage_gxi = GXDbFile.GetUriFromFile( "", "", AV10Blob);
         AV13Trn_Resident.Save();
         if ( AV13Trn_Resident.Success() )
         {
            context.CommitDataStores("prc_updateresidentavatar",pr_default);
            AV15WWP_UserExtended.Load(AV11ResidentGUID);
            AV15WWP_UserExtended.gxTpr_Wwpuserextendedphoto = AV10Blob;
            AV15WWP_UserExtended.gxTpr_Wwpuserextendedphoto_gxi = GXDbFile.GetUriFromFile( "", "", AV10Blob);
            AV15WWP_UserExtended.Save();
            if ( AV15WWP_UserExtended.Success() )
            {
               context.CommitDataStores("prc_updateresidentavatar",pr_default);
               AV14response = "Profile updated sucessfully";
            }
         }
         else
         {
            AV14response = "Profile could not be updated: Error: " + ((GeneXus.Utils.SdtMessages_Message)AV13Trn_Resident.GetMessages().Item(1)).gxTpr_Description;
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_updateresidentavatar",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV14response = "";
         AV12base64String = "";
         AV10Blob = "";
         P00A22_A71ResidentGUID = new string[] {""} ;
         P00A22_A40000ResidentImage_GXI = new string[] {""} ;
         P00A22_n40000ResidentImage_GXI = new bool[] {false} ;
         P00A22_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00A22_A29LocationId = new Guid[] {Guid.Empty} ;
         P00A22_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00A22_A457ResidentImage = new string[] {""} ;
         P00A22_n457ResidentImage = new bool[] {false} ;
         A71ResidentGUID = "";
         A40000ResidentImage_GXI = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A457ResidentImage = "";
         AV13Trn_Resident = new SdtTrn_Resident(context);
         AV15WWP_UserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updateresidentavatar__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updateresidentavatar__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updateresidentavatar__default(),
            new Object[][] {
                new Object[] {
               P00A22_A71ResidentGUID, P00A22_A40000ResidentImage_GXI, P00A22_n40000ResidentImage_GXI, P00A22_A11OrganisationId, P00A22_A29LocationId, P00A22_A62ResidentId, P00A22_A457ResidentImage, P00A22_n457ResidentImage
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n40000ResidentImage_GXI ;
      private bool n457ResidentImage ;
      private string AV8base64Image ;
      private string AV12base64String ;
      private string AV11ResidentGUID ;
      private string AV14response ;
      private string A71ResidentGUID ;
      private string A40000ResidentImage_GXI ;
      private string A457ResidentImage ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private string AV10Blob ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00A22_A71ResidentGUID ;
      private string[] P00A22_A40000ResidentImage_GXI ;
      private bool[] P00A22_n40000ResidentImage_GXI ;
      private Guid[] P00A22_A11OrganisationId ;
      private Guid[] P00A22_A29LocationId ;
      private Guid[] P00A22_A62ResidentId ;
      private string[] P00A22_A457ResidentImage ;
      private bool[] P00A22_n457ResidentImage ;
      private SdtTrn_Resident AV13Trn_Resident ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended AV15WWP_UserExtended ;
      private string aP2_response ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updateresidentavatar__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updateresidentavatar__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updateresidentavatar__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new UpdateCursor(def[1])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00A22;
       prmP00A22 = new Object[] {
       new ParDef("AV11ResidentGUID",GXType.VarChar,100,60)
       };
       Object[] prmP00A23;
       prmP00A23 = new Object[] {
       new ParDef("ResidentImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("ResidentImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Trn_Resident", Fld="ResidentImage"} ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00A22", "SELECT ResidentGUID, ResidentImage_GXI, OrganisationId, LocationId, ResidentId, ResidentImage FROM Trn_Resident WHERE ResidentGUID = ( :AV11ResidentGUID) ORDER BY ResidentId, LocationId, OrganisationId  FOR UPDATE OF Trn_Resident",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A22,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00A23", "SAVEPOINT gxupdate;UPDATE Trn_Resident SET ResidentImage=:ResidentImage, ResidentImage_GXI=:ResidentImage_GXI  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00A23)
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
             ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             ((Guid[]) buf[4])[0] = rslt.getGuid(4);
             ((Guid[]) buf[5])[0] = rslt.getGuid(5);
             ((string[]) buf[6])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(2));
             ((bool[]) buf[7])[0] = rslt.wasNull(6);
             return;
    }
 }

}

}