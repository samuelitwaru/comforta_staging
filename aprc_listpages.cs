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
                           out GXBaseCollection<SdtSDT_PageStructure> aP2_SDT_PageStructureCollection )
      {
         this.AV26LocationId = aP0_LocationId;
         this.AV27OrganisationId = aP1_OrganisationId;
         this.AV29SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP2_SDT_PageStructureCollection=this.AV29SDT_PageStructureCollection;
      }

      public GXBaseCollection<SdtSDT_PageStructure> executeUdp( Guid aP0_LocationId ,
                                                                Guid aP1_OrganisationId )
      {
         execute(aP0_LocationId, aP1_OrganisationId, out aP2_SDT_PageStructureCollection);
         return AV29SDT_PageStructureCollection ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 out GXBaseCollection<SdtSDT_PageStructure> aP2_SDT_PageStructureCollection )
      {
         this.AV26LocationId = aP0_LocationId;
         this.AV27OrganisationId = aP1_OrganisationId;
         this.AV29SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2") ;
         SubmitImpl();
         aP2_SDT_PageStructureCollection=this.AV29SDT_PageStructureCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prc_authenticatereceptionist(context ).execute( out  AV30UserName, ref  AV26LocationId, ref  AV27OrganisationId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV30UserName))) )
         {
            cleanup();
            if (true) return;
         }
         /* Using cursor P008W2 */
         pr_default.execute(0, new Object[] {AV26LocationId, AV27OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A318Trn_PageName = P008W2_A318Trn_PageName[0];
            A11OrganisationId = P008W2_A11OrganisationId[0];
            A29LocationId = P008W2_A29LocationId[0];
            A431PageJsonContent = P008W2_A431PageJsonContent[0];
            n431PageJsonContent = P008W2_n431PageJsonContent[0];
            A310Trn_PageId = P008W2_A310Trn_PageId[0];
            AV8SDT_Page = new SdtSDT_Page(context);
            AV8SDT_Page.FromJSonString(A431PageJsonContent, null);
            AV32GXV1 = 1;
            while ( AV32GXV1 <= AV8SDT_Page.gxTpr_Row.Count )
            {
               AV10SDT_Row = ((SdtSDT_Row)AV8SDT_Page.gxTpr_Row.Item(AV32GXV1));
               AV33GXV2 = 1;
               while ( AV33GXV2 <= AV10SDT_Row.gxTpr_Col.Count )
               {
                  AV11SDT_Col = ((SdtSDT_Col)AV10SDT_Row.gxTpr_Col.Item(AV33GXV2));
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objecttype))) )
                  {
                     AV25BC_Trn_Page = new SdtTrn_Page(context);
                     AV25BC_Trn_Page.Load(AV11SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objectid, AV11SDT_Col.gxTpr_Tile.gxTpr_Tilename, AV26LocationId);
                     if ( ! (Guid.Empty==AV25BC_Trn_Page.gxTpr_Trn_pageid) )
                     {
                        AV15SDT_PageStructure = new SdtSDT_PageStructure(context);
                        AV15SDT_PageStructure.gxTpr_Id = AV25BC_Trn_Page.gxTpr_Trn_pageid;
                        AV15SDT_PageStructure.gxTpr_Name = AV25BC_Trn_Page.gxTpr_Trn_pagename;
                        if ( ! AV25BC_Trn_Page.gxTpr_Pageiscontentpage )
                        {
                           AV8SDT_Page = new SdtSDT_Page(context);
                           AV8SDT_Page.FromJSonString(AV25BC_Trn_Page.gxTpr_Pagejsoncontent, null);
                           AV34GXV3 = 1;
                           while ( AV34GXV3 <= AV8SDT_Page.gxTpr_Row.Count )
                           {
                              AV10SDT_Row = ((SdtSDT_Row)AV8SDT_Page.gxTpr_Row.Item(AV34GXV3));
                              AV35GXV4 = 1;
                              while ( AV35GXV4 <= AV10SDT_Row.gxTpr_Col.Count )
                              {
                                 AV11SDT_Col = ((SdtSDT_Col)AV10SDT_Row.gxTpr_Col.Item(AV35GXV4));
                                 if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objecttype))) )
                                 {
                                    AV25BC_Trn_Page = new SdtTrn_Page(context);
                                    AV25BC_Trn_Page.Load(AV11SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objectid, AV11SDT_Col.gxTpr_Tile.gxTpr_Tilename, AV26LocationId);
                                    if ( ! (Guid.Empty==AV25BC_Trn_Page.gxTpr_Trn_pageid) )
                                    {
                                       AV19SDT_PageChild = new SdtSDT_PageStructure_ChildrenItem(context);
                                       AV19SDT_PageChild.gxTpr_Id = AV25BC_Trn_Page.gxTpr_Trn_pageid;
                                       AV19SDT_PageChild.gxTpr_Name = AV25BC_Trn_Page.gxTpr_Trn_pagename;
                                       AV15SDT_PageStructure.gxTpr_Children.Add(AV19SDT_PageChild, 0);
                                    }
                                 }
                                 AV35GXV4 = (int)(AV35GXV4+1);
                              }
                              AV34GXV3 = (int)(AV34GXV3+1);
                           }
                        }
                        AV29SDT_PageStructureCollection.Add(AV15SDT_PageStructure, 0);
                     }
                  }
                  AV33GXV2 = (int)(AV33GXV2+1);
               }
               AV32GXV1 = (int)(AV32GXV1+1);
            }
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV29SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2");
         AV30UserName = "";
         P008W2_A318Trn_PageName = new string[] {""} ;
         P008W2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008W2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008W2_A431PageJsonContent = new string[] {""} ;
         P008W2_n431PageJsonContent = new bool[] {false} ;
         P008W2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         A318Trn_PageName = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A431PageJsonContent = "";
         A310Trn_PageId = Guid.Empty;
         AV8SDT_Page = new SdtSDT_Page(context);
         AV10SDT_Row = new SdtSDT_Row(context);
         AV11SDT_Col = new SdtSDT_Col(context);
         AV25BC_Trn_Page = new SdtTrn_Page(context);
         AV15SDT_PageStructure = new SdtSDT_PageStructure(context);
         AV19SDT_PageChild = new SdtSDT_PageStructure_ChildrenItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_listpages__default(),
            new Object[][] {
                new Object[] {
               P008W2_A318Trn_PageName, P008W2_A11OrganisationId, P008W2_A29LocationId, P008W2_A431PageJsonContent, P008W2_n431PageJsonContent, P008W2_A310Trn_PageId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV32GXV1 ;
      private int AV33GXV2 ;
      private int AV34GXV3 ;
      private int AV35GXV4 ;
      private bool n431PageJsonContent ;
      private string A431PageJsonContent ;
      private string AV30UserName ;
      private string A318Trn_PageName ;
      private Guid AV26LocationId ;
      private Guid AV27OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A310Trn_PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_PageStructure> AV29SDT_PageStructureCollection ;
      private IDataStoreProvider pr_default ;
      private string[] P008W2_A318Trn_PageName ;
      private Guid[] P008W2_A11OrganisationId ;
      private Guid[] P008W2_A29LocationId ;
      private string[] P008W2_A431PageJsonContent ;
      private bool[] P008W2_n431PageJsonContent ;
      private Guid[] P008W2_A310Trn_PageId ;
      private SdtSDT_Page AV8SDT_Page ;
      private SdtSDT_Row AV10SDT_Row ;
      private SdtSDT_Col AV11SDT_Col ;
      private SdtTrn_Page AV25BC_Trn_Page ;
      private SdtSDT_PageStructure AV15SDT_PageStructure ;
      private SdtSDT_PageStructure_ChildrenItem AV19SDT_PageChild ;
      private GXBaseCollection<SdtSDT_PageStructure> aP2_SDT_PageStructureCollection ;
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
              new CursorDef("P008W2", "SELECT Trn_PageName, OrganisationId, LocationId, PageJsonContent, Trn_PageId FROM Trn_Page WHERE (Trn_PageName = ( 'Home') and LocationId = :AV26LocationId) AND (OrganisationId = :AV27OrganisationId) ORDER BY Trn_PageName, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008W2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((Guid[]) buf[5])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
