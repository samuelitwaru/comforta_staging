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
   public class prc_deletecascadetheme : GXProcedure
   {
      public prc_deletecascadetheme( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletecascadetheme( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ThemeId ,
                           Guid aP1_OrganisationId ,
                           ref bool aP2_isSuccessful ,
                           ref string aP3_Message )
      {
         this.AV12ThemeId = aP0_ThemeId;
         this.AV11OrganisationId = aP1_OrganisationId;
         this.AV9isSuccessful = aP2_isSuccessful;
         this.AV10Message = aP3_Message;
         initialize();
         ExecuteImpl();
         aP2_isSuccessful=this.AV9isSuccessful;
         aP3_Message=this.AV10Message;
      }

      public string executeUdp( Guid aP0_ThemeId ,
                                Guid aP1_OrganisationId ,
                                ref bool aP2_isSuccessful )
      {
         execute(aP0_ThemeId, aP1_OrganisationId, ref aP2_isSuccessful, ref aP3_Message);
         return AV10Message ;
      }

      public void executeSubmit( Guid aP0_ThemeId ,
                                 Guid aP1_OrganisationId ,
                                 ref bool aP2_isSuccessful ,
                                 ref string aP3_Message )
      {
         this.AV12ThemeId = aP0_ThemeId;
         this.AV11OrganisationId = aP1_OrganisationId;
         this.AV9isSuccessful = aP2_isSuccessful;
         this.AV10Message = aP3_Message;
         SubmitImpl();
         aP2_isSuccessful=this.AV9isSuccessful;
         aP3_Message=this.AV10Message;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11OrganisationId ,
                                              AV12ThemeId ,
                                              A11OrganisationId ,
                                              A247Trn_ThemeId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00CN2 */
         pr_default.execute(0, new Object[] {AV11OrganisationId, AV12ThemeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A247Trn_ThemeId = P00CN2_A247Trn_ThemeId[0];
            A11OrganisationId = P00CN2_A11OrganisationId[0];
            n11OrganisationId = P00CN2_n11OrganisationId[0];
            AV13Trn_Theme.Load(A247Trn_ThemeId);
            AV13Trn_Theme.Delete();
            if ( AV13Trn_Theme.Success() )
            {
               AV9isSuccessful = true;
               context.CommitDataStores("prc_deletecascadetheme",pr_default);
            }
            else
            {
               AV16GXV2 = 1;
               AV15GXV1 = AV13Trn_Theme.GetMessages();
               while ( AV16GXV2 <= AV15GXV1.Count )
               {
                  AV8ErrorMessage = ((GeneXus.Utils.SdtMessages_Message)AV15GXV1.Item(AV16GXV2));
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10Message)) )
                  {
                     AV10Message = AV8ErrorMessage.gxTpr_Description;
                  }
                  else
                  {
                     AV10Message += ", " + AV8ErrorMessage.gxTpr_Description;
                  }
                  AV16GXV2 = (int)(AV16GXV2+1);
               }
               AV9isSuccessful = false;
            }
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
         A11OrganisationId = Guid.Empty;
         A247Trn_ThemeId = Guid.Empty;
         P00CN2_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00CN2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00CN2_n11OrganisationId = new bool[] {false} ;
         AV13Trn_Theme = new SdtTrn_Theme(context);
         AV15GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV8ErrorMessage = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadetheme__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadetheme__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletecascadetheme__default(),
            new Object[][] {
                new Object[] {
               P00CN2_A247Trn_ThemeId, P00CN2_A11OrganisationId, P00CN2_n11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV16GXV2 ;
      private string AV10Message ;
      private bool AV9isSuccessful ;
      private bool n11OrganisationId ;
      private Guid AV12ThemeId ;
      private Guid AV11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A247Trn_ThemeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private bool aP2_isSuccessful ;
      private string aP3_Message ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00CN2_A247Trn_ThemeId ;
      private Guid[] P00CN2_A11OrganisationId ;
      private bool[] P00CN2_n11OrganisationId ;
      private SdtTrn_Theme AV13Trn_Theme ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV15GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV8ErrorMessage ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_deletecascadetheme__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_deletecascadetheme__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_deletecascadetheme__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_P00CN2( IGxContext context ,
                                          Guid AV11OrganisationId ,
                                          Guid AV12ThemeId ,
                                          Guid A11OrganisationId ,
                                          Guid A247Trn_ThemeId )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int1 = new short[2];
      Object[] GXv_Object2 = new Object[2];
      scmdbuf = "SELECT Trn_ThemeId, OrganisationId FROM Trn_Theme";
      if ( ! (Guid.Empty==AV11OrganisationId) )
      {
         AddWhere(sWhereString, "(OrganisationId = :AV11OrganisationId)");
      }
      else
      {
         GXv_int1[0] = 1;
      }
      if ( ! (Guid.Empty==AV12ThemeId) )
      {
         AddWhere(sWhereString, "(Trn_ThemeId = :AV12ThemeId)");
      }
      else
      {
         GXv_int1[1] = 1;
      }
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY Trn_ThemeId";
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
                  return conditional_P00CN2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
      }
      return base.getDynamicStatement(cursor, context, dynConstraints);
   }

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
       Object[] prmP00CN2;
       prmP00CN2 = new Object[] {
       new ParDef("AV11OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV12ThemeId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00CN2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CN2,100, GxCacheFrequency.OFF ,true,false )
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
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             return;
    }
 }

}

}
