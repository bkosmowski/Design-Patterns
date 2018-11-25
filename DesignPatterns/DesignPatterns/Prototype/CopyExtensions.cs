using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace DesignPatterns.Prototype
{
    public static class CopyExtensions
    {
        /// <summary>
        ///Requires [Serializable] attribute for class
        /// </summary>
        public static T DeepCopy<T>(this T self)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, self);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return (T) binaryFormatter.Deserialize(memoryStream);
            }
        }
        /// <summary>
        /// Requires empty ctor
        /// </summary>
        public static T DeepCopyXml<T>(this T self)
        {
            using (var memoryStream = new MemoryStream())
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(memoryStream, self);
                memoryStream.Position = 0;
                return (T) xmlSerializer.Deserialize(memoryStream);
            }
        }
    }
}
