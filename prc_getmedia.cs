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
   public class prc_getmedia : GXProcedure
   {
      public prc_getmedia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getmedia( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDT_Media> aP0_SDT_MediaCollection )
      {
         this.AV9SDT_MediaCollection = new GXBaseCollection<SdtSDT_Media>( context, "SDT_Media", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_SDT_MediaCollection=this.AV9SDT_MediaCollection;
      }

      public GXBaseCollection<SdtSDT_Media> executeUdp( )
      {
         execute(out aP0_SDT_MediaCollection);
         return AV9SDT_MediaCollection ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_Media> aP0_SDT_MediaCollection )
      {
         this.AV9SDT_MediaCollection = new GXBaseCollection<SdtSDT_Media>( context, "SDT_Media", "Comforta_version2") ;
         SubmitImpl();
         aP0_SDT_MediaCollection=this.AV9SDT_MediaCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV10UserName;
         new prc_getloggedinusername(context ).execute( out  GXt_char1) ;
         AV10UserName = GXt_char1;
         /* Using cursor P009Y2 */
         pr_default.execute(0, new Object[] {AV10UserName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A93ReceptionistEmail = P009Y2_A93ReceptionistEmail[0];
            A29LocationId = P009Y2_A29LocationId[0];
            A11OrganisationId = P009Y2_A11OrganisationId[0];
            A89ReceptionistId = P009Y2_A89ReceptionistId[0];
            AV11LocationId = A29LocationId;
            AV12OrganisationId = A11OrganisationId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P009Y3 */
         pr_default.execute(1, new Object[] {AV11LocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A29LocationId = P009Y3_A29LocationId[0];
            A40000MediaImage_GXI = P009Y3_A40000MediaImage_GXI[0];
            n40000MediaImage_GXI = P009Y3_n40000MediaImage_GXI[0];
            A409MediaId = P009Y3_A409MediaId[0];
            A410MediaName = P009Y3_A410MediaName[0];
            A413MediaSize = P009Y3_A413MediaSize[0];
            A414MediaType = P009Y3_A414MediaType[0];
            A412MediaUrl = P009Y3_A412MediaUrl[0];
            A411MediaImage = P009Y3_A411MediaImage[0];
            n411MediaImage = P009Y3_n411MediaImage[0];
            AV8SDT_Media = new SdtSDT_Media(context);
            AV8SDT_Media.gxTpr_Mediaid = A409MediaId;
            AV8SDT_Media.gxTpr_Medianame = A410MediaName;
            AV8SDT_Media.gxTpr_Mediaimage = A411MediaImage;
            AV8SDT_Media.gxTpr_Mediaimage_gxi = A40000MediaImage_GXI;
            AV8SDT_Media.gxTpr_Mediasize = A413MediaSize;
            AV8SDT_Media.gxTpr_Mediatype = A414MediaType;
            AV8SDT_Media.gxTpr_Mediaurl = A412MediaUrl;
            AV9SDT_MediaCollection.Add(AV8SDT_Media, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         AV9SDT_MediaCollection = new GXBaseCollection<SdtSDT_Media>( context, "SDT_Media", "Comforta_version2");
         AV10UserName = "";
         GXt_char1 = "";
         P009Y2_A93ReceptionistEmail = new string[] {""} ;
         P009Y2_A29LocationId = new Guid[] {Guid.Empty} ;
         P009Y2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P009Y2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         A93ReceptionistEmail = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         AV11LocationId = Guid.Empty;
         AV12OrganisationId = Guid.Empty;
         P009Y3_A29LocationId = new Guid[] {Guid.Empty} ;
         P009Y3_A40000MediaImage_GXI = new string[] {""} ;
         P009Y3_n40000MediaImage_GXI = new bool[] {false} ;
         P009Y3_A409MediaId = new Guid[] {Guid.Empty} ;
         P009Y3_A410MediaName = new string[] {""} ;
         P009Y3_A413MediaSize = new int[1] ;
         P009Y3_A414MediaType = new string[] {""} ;
         P009Y3_A412MediaUrl = new string[] {""} ;
         P009Y3_A411MediaImage = new string[] {""} ;
         P009Y3_n411MediaImage = new bool[] {false} ;
         A40000MediaImage_GXI = "";
         A409MediaId = Guid.Empty;
         A410MediaName = "";
         A414MediaType = "";
         A412MediaUrl = "";
         A411MediaImage = "";
         AV8SDT_Media = new SdtSDT_Media(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getmedia__default(),
            new Object[][] {
                new Object[] {
               P009Y2_A93ReceptionistEmail, P009Y2_A29LocationId, P009Y2_A11OrganisationId, P009Y2_A89ReceptionistId
               }
               , new Object[] {
               P009Y3_A29LocationId, P009Y3_A40000MediaImage_GXI, P009Y3_n40000MediaImage_GXI, P009Y3_A409MediaId, P009Y3_A410MediaName, P009Y3_A413MediaSize, P009Y3_A414MediaType, P009Y3_A412MediaUrl, P009Y3_A411MediaImage, P009Y3_n411MediaImage
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A413MediaSize ;
      private string GXt_char1 ;
      private string A414MediaType ;
      private bool n40000MediaImage_GXI ;
      private bool n411MediaImage ;
      private string AV10UserName ;
      private string A93ReceptionistEmail ;
      private string A40000MediaImage_GXI ;
      private string A410MediaName ;
      private string A412MediaUrl ;
      private string A411MediaImage ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A89ReceptionistId ;
      private Guid AV11LocationId ;
      private Guid AV12OrganisationId ;
      private Guid A409MediaId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_Media> AV9SDT_MediaCollection ;
      private IDataStoreProvider pr_default ;
      private string[] P009Y2_A93ReceptionistEmail ;
      private Guid[] P009Y2_A29LocationId ;
      private Guid[] P009Y2_A11OrganisationId ;
      private Guid[] P009Y2_A89ReceptionistId ;
      private Guid[] P009Y3_A29LocationId ;
      private string[] P009Y3_A40000MediaImage_GXI ;
      private bool[] P009Y3_n40000MediaImage_GXI ;
      private Guid[] P009Y3_A409MediaId ;
      private string[] P009Y3_A410MediaName ;
      private int[] P009Y3_A413MediaSize ;
      private string[] P009Y3_A414MediaType ;
      private string[] P009Y3_A412MediaUrl ;
      private string[] P009Y3_A411MediaImage ;
      private bool[] P009Y3_n411MediaImage ;
      private SdtSDT_Media AV8SDT_Media ;
      private GXBaseCollection<SdtSDT_Media> aP0_SDT_MediaCollection ;
   }

   public class prc_getmedia__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009Y2;
          prmP009Y2 = new Object[] {
          new ParDef("AV10UserName",GXType.VarChar,100,0)
          };
          Object[] prmP009Y3;
          prmP009Y3 = new Object[] {
          new ParDef("AV11LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009Y2", "SELECT ReceptionistEmail, LocationId, OrganisationId, ReceptionistId FROM Trn_Receptionist WHERE ReceptionistEmail = ( RTRIM(LTRIM(:AV10UserName))) ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Y2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009Y3", "SELECT LocationId, MediaImage_GXI, MediaId, MediaName, MediaSize, MediaType, MediaUrl, MediaImage FROM Trn_Media WHERE LocationId = :AV11LocationId ORDER BY MediaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Y3,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(2));
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
