using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [Serializable]
   public class SdtAlert : GxUserType, IGxExternalObject
   {
      public SdtAlert( )
      {
         /* Constructor for serialization */
      }

      public SdtAlert( IGxContext context )
      {
         this.context = context;
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void doalert( ref string gxTp_word )
      {
         if ( Alert_externalReference == null )
         {
            Alert_externalReference = new Alert();
         }
         Alert_externalReference.doAlert(ref gxTp_word);
         return  ;
      }

      public Object ExternalInstance
      {
         get {
            if ( Alert_externalReference == null )
            {
               Alert_externalReference = new Alert();
            }
            return Alert_externalReference ;
         }

         set {
            Alert_externalReference = (Alert)(value);
         }

      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         return  ;
      }

      protected Alert Alert_externalReference=null ;
   }

}
