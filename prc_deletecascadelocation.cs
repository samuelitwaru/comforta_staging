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
   public class prc_deletecascadelocation : GXProcedure
   {
      public prc_deletecascadelocation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadelocation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_Trn_ThemeId ,
                           Guid aP2_OrganisationId ,
                           bool aP3_isMain ,
                           ref bool aP4_isSuccessful ,
                           ref string aP5_Message )
      {
         this.AV12LocationId = aP0_LocationId;
         this.AV15Trn_ThemeId = aP1_Trn_ThemeId;
         this.AV14OrganisationId = aP2_OrganisationId;
         this.AV10isMain = aP3_isMain;
         this.AV11isSuccessful = aP4_isSuccessful;
         this.AV13Message = aP5_Message;
         initialize();
         ExecuteImpl();
         aP4_isSuccessful=this.AV11isSuccessful;
         aP5_Message=this.AV13Message;
      }

      public string executeUdp( Guid aP0_LocationId ,
                                Guid aP1_Trn_ThemeId ,
                                Guid aP2_OrganisationId ,
                                bool aP3_isMain ,
                                ref bool aP4_isSuccessful )
      {
         execute(aP0_LocationId, aP1_Trn_ThemeId, aP2_OrganisationId, aP3_isMain, ref aP4_isSuccessful, ref aP5_Message);
         return AV13Message ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_Trn_ThemeId ,
                                 Guid aP2_OrganisationId ,
                                 bool aP3_isMain ,
                                 ref bool aP4_isSuccessful ,
                                 ref string aP5_Message )
      {
         this.AV12LocationId = aP0_LocationId;
         this.AV15Trn_ThemeId = aP1_Trn_ThemeId;
         this.AV14OrganisationId = aP2_OrganisationId;
         this.AV10isMain = aP3_isMain;
         this.AV11isSuccessful = aP4_isSuccessful;
         this.AV13Message = aP5_Message;
         SubmitImpl();
         aP4_isSuccessful=this.AV11isSuccessful;
         aP5_Message=this.AV13Message;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV12LocationId ,
                                              AV14OrganisationId ,
                                              AV15Trn_ThemeId ,
                                              A29LocationId ,
                                              A11OrganisationId ,
                                              A247Trn_ThemeId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00C02 */
         pr_default.execute(0, new Object[] {AV12LocationId, AV14OrganisationId, AV15Trn_ThemeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTC02 = 0;
            A247Trn_ThemeId = P00C02_A247Trn_ThemeId[0];
            n247Trn_ThemeId = P00C02_n247Trn_ThemeId[0];
            A11OrganisationId = P00C02_A11OrganisationId[0];
            A29LocationId = P00C02_A29LocationId[0];
            new prc_deletecascadeproductservice(context ).execute(  Guid.Empty,  Guid.Empty,  A29LocationId,  A11OrganisationId) ;
            new prc_deletecascadelocationdynamicform(context ).execute(  Guid.Empty,  0,  A29LocationId,  A11OrganisationId) ;
            new prc_deletecascadepage(context ).execute(  Guid.Empty,  Guid.Empty,  A29LocationId,  A11OrganisationId) ;
            new prc_deletecascadeagendacalendar(context ).execute(  Guid.Empty,  A29LocationId,  A11OrganisationId) ;
            new prc_deletecascadereceptionist(context ).execute(  Guid.Empty,  A29LocationId,  A11OrganisationId) ;
            new prc_deletecascaderesident(context ).execute(  Guid.Empty,  A29LocationId,  A11OrganisationId) ;
            if ( AV10isMain )
            {
               AV8Trn_Location.Load(A29LocationId, A11OrganisationId);
               AV8Trn_Location.Delete();
               if ( AV8Trn_Location.Success() )
               {
                  AV11isSuccessful = true;
                  GXTC02 = 1;
                  CallWebObject(formatLink("trn_locationww.aspx") );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  AV18GXV2 = 1;
                  AV17GXV1 = AV8Trn_Location.GetMessages();
                  while ( AV18GXV2 <= AV17GXV1.Count )
                  {
                     AV9ErrorMessage = ((GeneXus.Utils.SdtMessages_Message)AV17GXV1.Item(AV18GXV2));
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13Message)) )
                     {
                        AV13Message = AV9ErrorMessage.gxTpr_Description;
                     }
                     else
                     {
                        AV13Message += ", " + AV9ErrorMessage.gxTpr_Description;
                     }
                     AV18GXV2 = (int)(AV18GXV2+1);
                  }
                  AV11isSuccessful = false;
               }
            }
            else
            {
               /* Using cursor P00C03 */
               pr_default.execute(1, new Object[] {A29LocationId, A11OrganisationId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
            }
            if ( GXTC02 == 1 )
            {
               context.CommitDataStores("prc_deletecascadelocation",pr_default);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletecascadelocation",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A247Trn_ThemeId = Guid.Empty;
         P00C02_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00C02_n247Trn_ThemeId = new bool[] {false} ;
         P00C02_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00C02_A29LocationId = new Guid[] {Guid.Empty} ;
         AV8Trn_Location = new SdtTrn_Location(context);
         AV17GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV9ErrorMessage = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadelocation__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadelocation__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadelocation__default(),
            new Object[][] {
                new Object[] {
               P00C02_A247Trn_ThemeId, P00C02_n247Trn_ThemeId, P00C02_A11OrganisationId, P00C02_A29LocationId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTC02 ;
      private int AV18GXV2 ;
      private string AV13Message ;
      private bool AV10isMain ;
      private bool AV11isSuccessful ;
      private bool n247Trn_ThemeId ;
      private Guid AV12LocationId ;
      private Guid AV15Trn_ThemeId ;
      private Guid AV14OrganisationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A247Trn_ThemeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private bool aP4_isSuccessful ;
      private string aP5_Message ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00C02_A247Trn_ThemeId ;
      private bool[] P00C02_n247Trn_ThemeId ;
      private Guid[] P00C02_A11OrganisationId ;
      private Guid[] P00C02_A29LocationId ;
      private SdtTrn_Location AV8Trn_Location ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV17GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV9ErrorMessage ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_deletecascadelocation__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_deletecascadelocation__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_deletecascadelocation__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_P00C02( IGxContext context ,
                                          Guid AV12LocationId ,
                                          Guid AV14OrganisationId ,
                                          Guid AV15Trn_ThemeId ,
                                          Guid A29LocationId ,
                                          Guid A11OrganisationId ,
                                          Guid A247Trn_ThemeId )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int1 = new short[3];
      Object[] GXv_Object2 = new Object[2];
      scmdbuf = "SELECT Trn_ThemeId, OrganisationId, LocationId FROM Trn_Location";
      if ( ! (Guid.Empty==AV12LocationId) )
      {
         AddWhere(sWhereString, "(LocationId = :AV12LocationId)");
      }
      else
      {
         GXv_int1[0] = 1;
      }
      if ( ! (Guid.Empty==AV14OrganisationId) )
      {
         AddWhere(sWhereString, "(OrganisationId = :AV14OrganisationId)");
      }
      else
      {
         GXv_int1[1] = 1;
      }
      if ( ! (Guid.Empty==AV15Trn_ThemeId) )
      {
         AddWhere(sWhereString, "(Trn_ThemeId = :AV15Trn_ThemeId)");
      }
      else
      {
         GXv_int1[2] = 1;
      }
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY LocationId, OrganisationId";
      scmdbuf += " FOR UPDATE OF Trn_Location";
      GXv_Object2[0] = scmdbuf;
      GXv_Object2[1] = GXv_int1;
      return GXv_Object2 ;
   }

   public override Object [] getDynamicStatement( int cursor ,
                                                  IGxContext context ,
                                                  Object [] dynConstraints )
   {
      switch ( cursor )
      {
            case 0 :
                  return conditional_P00C02(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] , (Guid)dynConstraints[4] , (Guid)dynConstraints[5] );
      }
      return base.getDynamicStatement(cursor, context, dynConstraints);
   }

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
       Object[] prmP00C03;
       prmP00C03 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00C02;
       prmP00C02 = new Object[] {
       new ParDef("AV12LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV14OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV15Trn_ThemeId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00C02", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C02,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00C03", "SAVEPOINT gxupdate;DELETE FROM Trn_Location  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00C03)
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
             ((bool[]) buf[1])[0] = rslt.wasNull(1);
             ((Guid[]) buf[2])[0] = rslt.getGuid(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             return;
    }
 }

}

}
