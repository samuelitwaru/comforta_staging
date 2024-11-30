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
   public class prc_getuseridfromaccesstoken : GXProcedure
   {
      public prc_getuseridfromaccesstoken( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getuseridfromaccesstoken( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_access_token ,
                           out string aP1_ResidentGUID )
      {
         this.AV8access_token = aP0_access_token;
         this.AV9ResidentGUID = "" ;
         initialize();
         ExecuteImpl();
         aP1_ResidentGUID=this.AV9ResidentGUID;
      }

      public string executeUdp( string aP0_access_token )
      {
         execute(aP0_access_token, out aP1_ResidentGUID);
         return AV9ResidentGUID ;
      }

      public void executeSubmit( string aP0_access_token ,
                                 out string aP1_ResidentGUID )
      {
         this.AV8access_token = aP0_access_token;
         this.AV9ResidentGUID = "" ;
         SubmitImpl();
         aP1_ResidentGUID=this.AV9ResidentGUID;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9ResidentGUID = "";
         /* Using cursor P009K2 */
         pr_gam.execute(0, new Object[] {AV8access_token});
         while ( (pr_gam.getStatus(0) != 101) )
         {
            A460sestoken = P009K2_A460sestoken[0];
            A468userguid = P009K2_A468userguid[0];
            A469sesdate = P009K2_A469sesdate[0];
            A461repid = P009K2_A461repid[0];
            AV9ResidentGUID = StringUtil.Trim( A468userguid);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9ResidentGUID)) )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_gam.readNext(0);
         }
         pr_gam.close(0);
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
         AV9ResidentGUID = "";
         P009K2_A460sestoken = new string[] {""} ;
         P009K2_A468userguid = new string[] {""} ;
         P009K2_A469sesdate = new DateTime[] {DateTime.MinValue} ;
         P009K2_A461repid = new int[1] ;
         A460sestoken = "";
         A468userguid = "";
         A469sesdate = (DateTime)(DateTime.MinValue);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_getuseridfromaccesstoken__gam(),
            new Object[][] {
                new Object[] {
               P009K2_A460sestoken, P009K2_A468userguid, P009K2_A469sesdate, P009K2_A461repid
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A461repid ;
      private string A460sestoken ;
      private string A468userguid ;
      private DateTime A469sesdate ;
      private string AV8access_token ;
      private string AV9ResidentGUID ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_gam ;
      private string[] P009K2_A460sestoken ;
      private string[] P009K2_A468userguid ;
      private DateTime[] P009K2_A469sesdate ;
      private int[] P009K2_A461repid ;
      private string aP1_ResidentGUID ;
   }

   public class prc_getuseridfromaccesstoken__gam : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009K2;
          prmP009K2 = new Object[] {
          new ParDef("AV8access_token",GXType.LongVarChar,2097152,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009K2", "SELECT sestoken, userguid, sesdate, repid FROM gam.session WHERE sestoken = ( :AV8access_token) ORDER BY sesdate DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009K2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 120);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

}
