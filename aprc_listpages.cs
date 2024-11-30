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
   public class aprc_listpages : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_listpages().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
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

      public aprc_listpages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_listpages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_OrganisationId ,
                           out GXBaseCollection<SdtSDT_PageStructure> aP2_SDT_PageCollection )
      {
         this.AV26LocationId = aP0_LocationId;
         this.AV27OrganisationId = aP1_OrganisationId;
         this.AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP2_SDT_PageCollection=this.AV9SDT_PageCollection;
      }

      public GXBaseCollection<SdtSDT_PageStructure> executeUdp( Guid aP0_LocationId ,
                                                                Guid aP1_OrganisationId )
      {
         execute(aP0_LocationId, aP1_OrganisationId, out aP2_SDT_PageCollection);
         return AV9SDT_PageCollection ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 out GXBaseCollection<SdtSDT_PageStructure> aP2_SDT_PageCollection )
      {
         this.AV26LocationId = aP0_LocationId;
         this.AV27OrganisationId = aP1_OrganisationId;
         this.AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2") ;
         SubmitImpl();
         aP2_SDT_PageCollection=this.AV9SDT_PageCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prc_logtofile(context ).execute(  AV26LocationId.ToString()) ;
         /* Using cursor P008W2 */
         pr_default.execute(0, new Object[] {AV26LocationId, AV27OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P008W2_A11OrganisationId[0];
            A29LocationId = P008W2_A29LocationId[0];
            A310Trn_PageId = P008W2_A310Trn_PageId[0];
            A318Trn_PageName = P008W2_A318Trn_PageName[0];
            A431PageJsonContent = P008W2_A431PageJsonContent[0];
            n431PageJsonContent = P008W2_n431PageJsonContent[0];
            AV15SDT_PageStructure = new SdtSDT_PageStructure(context);
            AV15SDT_PageStructure.gxTpr_Id = A310Trn_PageId;
            AV15SDT_PageStructure.gxTpr_Name = A318Trn_PageName;
            AV8SDT_Page = new SdtSDT_Page(context);
            AV8SDT_Page.FromJSonString(A431PageJsonContent, null);
            AV29GXV1 = 1;
            while ( AV29GXV1 <= AV8SDT_Page.gxTpr_Row.Count )
            {
               AV10SDT_Row = ((SdtSDT_Row)AV8SDT_Page.gxTpr_Row.Item(AV29GXV1));
               AV30GXV2 = 1;
               while ( AV30GXV2 <= AV10SDT_Row.gxTpr_Col.Count )
               {
                  AV11SDT_Col = ((SdtSDT_Col)AV10SDT_Row.gxTpr_Col.Item(AV30GXV2));
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objecttype))) )
                  {
                     AV25BC_Trn_Page = new SdtTrn_Page(context);
                     AV25BC_Trn_Page.Load(AV11SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objectid, AV11SDT_Col.gxTpr_Tile.gxTpr_Tilename, AV26LocationId);
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25BC_Trn_Page.gxTpr_Trn_pagename)) )
                     {
                        AV19SDT_PageChild = new SdtSDT_PageChildren(context);
                        AV19SDT_PageChild.gxTpr_Id = AV25BC_Trn_Page.gxTpr_Trn_pageid;
                        AV19SDT_PageChild.gxTpr_Name = AV25BC_Trn_Page.gxTpr_Trn_pagename;
                        AV15SDT_PageStructure.gxTpr_Children.Add(AV19SDT_PageChild, 0);
                     }
                  }
                  AV30GXV2 = (int)(AV30GXV2+1);
               }
               AV29GXV1 = (int)(AV29GXV1+1);
            }
            AV9SDT_PageCollection.Add(AV15SDT_PageStructure, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2");
         P008W2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008W2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008W2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P008W2_A318Trn_PageName = new string[] {""} ;
         P008W2_A431PageJsonContent = new string[] {""} ;
         P008W2_n431PageJsonContent = new bool[] {false} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         A431PageJsonContent = "";
         AV15SDT_PageStructure = new SdtSDT_PageStructure(context);
         AV8SDT_Page = new SdtSDT_Page(context);
         AV10SDT_Row = new SdtSDT_Row(context);
         AV11SDT_Col = new SdtSDT_Col(context);
         AV25BC_Trn_Page = new SdtTrn_Page(context);
         AV19SDT_PageChild = new SdtSDT_PageChildren(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_listpages__default(),
            new Object[][] {
                new Object[] {
               P008W2_A11OrganisationId, P008W2_A29LocationId, P008W2_A310Trn_PageId, P008W2_A318Trn_PageName, P008W2_A431PageJsonContent, P008W2_n431PageJsonContent
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV29GXV1 ;
      private int AV30GXV2 ;
      private bool n431PageJsonContent ;
      private string A431PageJsonContent ;
      private string A318Trn_PageName ;
      private Guid AV26LocationId ;
      private Guid AV27OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A310Trn_PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_PageStructure> AV9SDT_PageCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] P008W2_A11OrganisationId ;
      private Guid[] P008W2_A29LocationId ;
      private Guid[] P008W2_A310Trn_PageId ;
      private string[] P008W2_A318Trn_PageName ;
      private string[] P008W2_A431PageJsonContent ;
      private bool[] P008W2_n431PageJsonContent ;
      private SdtSDT_PageStructure AV15SDT_PageStructure ;
      private SdtSDT_Page AV8SDT_Page ;
      private SdtSDT_Row AV10SDT_Row ;
      private SdtSDT_Col AV11SDT_Col ;
      private SdtTrn_Page AV25BC_Trn_Page ;
      private SdtSDT_PageChildren AV19SDT_PageChild ;
      private GXBaseCollection<SdtSDT_PageStructure> aP2_SDT_PageCollection ;
   }

   public class aprc_listpages__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008W2;
          prmP008W2 = new Object[] {
          new ParDef("AV26LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV27OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008W2", "SELECT OrganisationId, LocationId, Trn_PageId, Trn_PageName, PageJsonContent FROM Trn_Page WHERE (LocationId = :AV26LocationId) AND (OrganisationId = :AV27OrganisationId) ORDER BY Trn_PageId, Trn_PageName, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008W2,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
