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
            return GAMSecurityLevel.SecurityLow ;
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

      public void execute( out GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ,
                           out SdtSDT_Error aP1_Error )
      {
         this.AV29SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2") ;
         this.AV31Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP0_SDT_PageStructureCollection=this.AV29SDT_PageStructureCollection;
         aP1_Error=this.AV31Error;
      }

      public SdtSDT_Error executeUdp( out GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection )
      {
         execute(out aP0_SDT_PageStructureCollection, out aP1_Error);
         return AV31Error ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ,
                                 out SdtSDT_Error aP1_Error )
      {
         this.AV29SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2") ;
         this.AV31Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP0_SDT_PageStructureCollection=this.AV29SDT_PageStructureCollection;
         aP1_Error=this.AV31Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV31Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV31Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            AV33Udparg1 = new prc_getuserlocationid(context).executeUdp( );
            AV34Udparg2 = new prc_getuserorganisationid(context).executeUdp( );
            /* Using cursor P008W2 */
            pr_default.execute(0, new Object[] {AV33Udparg1, AV34Udparg2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A318Trn_PageName = P008W2_A318Trn_PageName[0];
               A11OrganisationId = P008W2_A11OrganisationId[0];
               A29LocationId = P008W2_A29LocationId[0];
               A431PageJsonContent = P008W2_A431PageJsonContent[0];
               n431PageJsonContent = P008W2_n431PageJsonContent[0];
               A310Trn_PageId = P008W2_A310Trn_PageId[0];
               if ( StringUtil.StrCmp(A318Trn_PageName, context.GetMessage( "Home", "")) == 0 )
               {
                  AV8SDT_Page = new SdtSDT_Page(context);
                  AV8SDT_Page.FromJSonString(A431PageJsonContent, null);
                  AV35GXV1 = 1;
                  while ( AV35GXV1 <= AV8SDT_Page.gxTpr_Row.Count )
                  {
                     AV10SDT_Row = ((SdtSDT_Row)AV8SDT_Page.gxTpr_Row.Item(AV35GXV1));
                     AV36GXV2 = 1;
                     while ( AV36GXV2 <= AV10SDT_Row.gxTpr_Col.Count )
                     {
                        AV11SDT_Col = ((SdtSDT_Col)AV10SDT_Row.gxTpr_Col.Item(AV36GXV2));
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objecttype))) )
                        {
                           AV25BC_Trn_Page = new SdtTrn_Page(context);
                           AV25BC_Trn_Page.Load(AV11SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objectid, AV11SDT_Col.gxTpr_Tile.gxTpr_Tilename, new prc_getuserlocationid(context).executeUdp( ));
                           if ( ! (Guid.Empty==AV25BC_Trn_Page.gxTpr_Trn_pageid) )
                           {
                              AV15SDT_PageStructure = new SdtSDT_PageStructure(context);
                              AV15SDT_PageStructure.gxTpr_Id = AV25BC_Trn_Page.gxTpr_Trn_pageid;
                              AV15SDT_PageStructure.gxTpr_Name = AV25BC_Trn_Page.gxTpr_Trn_pagename;
                              if ( ! AV25BC_Trn_Page.gxTpr_Pageiscontentpage )
                              {
                                 AV8SDT_Page = new SdtSDT_Page(context);
                                 AV8SDT_Page.FromJSonString(AV25BC_Trn_Page.gxTpr_Pagejsoncontent, null);
                                 AV37GXV3 = 1;
                                 while ( AV37GXV3 <= AV8SDT_Page.gxTpr_Row.Count )
                                 {
                                    AV10SDT_Row = ((SdtSDT_Row)AV8SDT_Page.gxTpr_Row.Item(AV37GXV3));
                                    AV38GXV4 = 1;
                                    while ( AV38GXV4 <= AV10SDT_Row.gxTpr_Col.Count )
                                    {
                                       AV11SDT_Col = ((SdtSDT_Col)AV10SDT_Row.gxTpr_Col.Item(AV38GXV4));
                                       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objecttype))) )
                                       {
                                          AV25BC_Trn_Page = new SdtTrn_Page(context);
                                          AV25BC_Trn_Page.Load(AV11SDT_Col.gxTpr_Tile.gxTpr_Tileaction.gxTpr_Objectid, AV11SDT_Col.gxTpr_Tile.gxTpr_Tilename, new prc_getuserlocationid(context).executeUdp( ));
                                          if ( ! (Guid.Empty==AV25BC_Trn_Page.gxTpr_Trn_pageid) )
                                          {
                                             AV19SDT_PageChild = new SdtSDT_PageStructure_ChildrenItem(context);
                                             AV19SDT_PageChild.gxTpr_Id = AV25BC_Trn_Page.gxTpr_Trn_pageid;
                                             AV19SDT_PageChild.gxTpr_Name = AV25BC_Trn_Page.gxTpr_Trn_pagename;
                                             AV15SDT_PageStructure.gxTpr_Children.Add(AV19SDT_PageChild, 0);
                                          }
                                       }
                                       AV38GXV4 = (int)(AV38GXV4+1);
                                    }
                                    AV37GXV3 = (int)(AV37GXV3+1);
                                 }
                              }
                              AV29SDT_PageStructureCollection.Add(AV15SDT_PageStructure, 0);
                           }
                        }
                        AV36GXV2 = (int)(AV36GXV2+1);
                     }
                     AV35GXV1 = (int)(AV35GXV1+1);
                  }
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
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
         AV29SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2");
         AV31Error = new SdtSDT_Error(context);
         AV33Udparg1 = Guid.Empty;
         AV34Udparg2 = Guid.Empty;
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

      private int AV35GXV1 ;
      private int AV36GXV2 ;
      private int AV37GXV3 ;
      private int AV38GXV4 ;
      private bool n431PageJsonContent ;
      private string A431PageJsonContent ;
      private string A318Trn_PageName ;
      private Guid AV33Udparg1 ;
      private Guid AV34Udparg2 ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A310Trn_PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_PageStructure> AV29SDT_PageStructureCollection ;
      private SdtSDT_Error AV31Error ;
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
      private GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ;
      private SdtSDT_Error aP1_Error ;
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
          new ParDef("AV33Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV34Udparg2",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008W2", "SELECT Trn_PageName, OrganisationId, LocationId, PageJsonContent, Trn_PageId FROM Trn_Page WHERE (LocationId = :AV33Udparg1) AND (OrganisationId = :AV34Udparg2) ORDER BY Trn_PageId, Trn_PageName, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008W2,100, GxCacheFrequency.OFF ,true,false )
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
