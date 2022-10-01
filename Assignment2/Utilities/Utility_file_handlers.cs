using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Animal_Park
{
    class Utility_file_handlers
    {
        /// <summary>
        /// Serializes to a binary file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="FileName"></param>
        public static void Serialize_bin<T>(T obj, string FileName)
        {
            using (FileStream fileStream = new FileStream(FileName, FileMode.Create))
            {
                BinaryFormatter b = new BinaryFormatter(); 
                b.Serialize(fileStream, obj);
            }

        }
        /// <summary>
        /// DeSerializes from a binary file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static T Deserialize_bin<T>(string FileName)
        {
            using (FileStream fileStream = new FileStream(FileName, FileMode.Open))
            {
                BinaryFormatter binSerializer = new BinaryFormatter();
                return (T)binSerializer.Deserialize(fileStream);
            }

        }
        /// <summary>
        /// Serializes to an XML file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="FileName"></param>
        public static void Serialize_xml<T>(T obj,string FileName)
        {
            using (FileStream fileStream = new FileStream(FileName, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(fileStream,obj);
            }

        }
        /// <summary>
        /// De-Serializes from an XML file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static T Deserialize_xml<T>(string FileName)
        {
            using (FileStream fileStream = new FileStream(FileName, FileMode.Open))
            {  
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(fileStream);
            }

        }
    }

}
