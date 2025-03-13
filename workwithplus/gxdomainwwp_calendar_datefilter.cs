using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs.workwithplus {
   public class gxdomainwwp_calendar_datefilter
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainwwp_calendar_datefilter ()
      {
         domain[(short)1] = "WWP_Calendar_All";
         domain[(short)2] = "WWP_Calendar_Past";
         domain[(short)3] = "WWP_Calendar_Future";
         domain[(short)4] = "WWP_Calendar_FromDate";
         domain[(short)5] = "WWP_Calendar_Range";
      }

      public static string getDescription( IGxContext context ,
                                           short key )
      {
         string value;
         value = (string)(domain[key]==null?"":domain[key]);
         return ((context!=null) ? context.GetMessage( value, "") : value) ;
      }

      public static GxSimpleCollection<short> getValues( )
      {
         GxSimpleCollection<short> value = new GxSimpleCollection<short>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (short key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      public static short getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["All"] = (short)1;
            domainMap["Past"] = (short)2;
            domainMap["Future"] = (short)3;
            domainMap["FromDate"] = (short)4;
            domainMap["Range"] = (short)5;
         }
         return (short)domainMap[key] ;
      }

   }

}
