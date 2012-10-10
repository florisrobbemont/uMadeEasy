// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Lucrasoft.uMadeEasy.Core.Serializers
{
    /// <summary>
    /// Helper methods for easy XML Serialization
    /// </summary>
    public static class XmlSerializers
    {
        /// <summary>
        /// Serializes an object to XML
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize</param>
        /// <returns>A MemoryStream containing the XML</returns>
        private static MemoryStream SerializeXmlObject(object objectToSerialize)
        {
            var serializer = new XmlSerializer(objectToSerialize.GetType());

            var stream = new MemoryStream();
            var writer = new XmlTextWriterFull(stream);

            try
            {
                serializer.Serialize(writer, objectToSerialize);
            }
            catch
            {
                return null;
            }

            return stream;
        }

        /// <summary>
        /// Deserializes a string to an object
        /// </summary>
        /// <typeparam name="T">The destination type</typeparam>
        /// <param name="stringToDeserialize">A string containing the XML</param>
        private static T DeserializeXmlObject<T>(string stringToDeserialize)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var stream = new StringReader(stringToDeserialize))
            {
                return (T)serializer.Deserialize(stream);
            }
        }

        /// <summary>
        /// Deserializes a string to an object
        /// </summary>
        /// <typeparam name="T">The destination type</typeparam>
        /// <param name="stringToDeserialize">A string containing the XML</param>
        /// <param name="type">Output parameter containing the deserialized object</param>
        private static T DeserializeXmlObject<T>(string stringToDeserialize, Type type)
        {
            var serializer = new XmlSerializer(type);

            using (var stream = new StringReader(stringToDeserialize))
            {
                return (T)serializer.Deserialize(stream);
            }
        }

        /// <summary>
        /// Serializes an object to XML
        /// </summary>
        /// <param name="obj">The object to be serialized</param>
        /// <returns>The object serialized to a string</returns>
        public static string SerializeClassToXml(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");

            var memoryStream = SerializeXmlObject(obj);

            if (memoryStream != null)
            {
                var streamReader = new StreamReader(memoryStream, System.Text.Encoding.UTF8);

                streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

                return streamReader.ReadToEnd();
            }

            return String.Empty;
        }

        /// <summary>
        /// Serializes an object to an XmlDocument
        /// </summary>
        /// <param name="obj">The object to be serialized</param>
        /// <returns>An XmlDocument containing the serialized object</returns>
        public static XmlDocument SerializeClassToXmlDocument(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");

            var xmlDocument = new XmlDocument();
            var serializer = new XmlSerializer(obj.GetType());

            using (var stream = new MemoryStream())
            {
                serializer.Serialize(stream, obj);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);

                xmlDocument.Load(stream);
            }

            return xmlDocument;
        }

        /// <summary>
        /// Deserializes XML to an object
        /// </summary>
        /// <typeparam name="T">The destination type</typeparam>
        /// <param name="stringToDeserialize">A string containing the XML</param>
        /// <returns>A new object of type <typeparamref name="T"/></returns>
        public static T SerializeXmlToClass<T>(string stringToDeserialize) where T : class
        {
            return DeserializeXmlObject<T>(stringToDeserialize);
        }

        /// <summary>
        /// Deserializes XML to an object
        /// </summary>
        /// <typeparam name="T">The destination type</typeparam>
        /// <param name="stringToDeserialize">A string containing the XML</param>
        /// <param name="typeToDeserialize">The destination type</param>
        /// <returns>A new object of type <typeparamref name="T"/></returns>
        public static T SerializeXmlToClass<T>(string stringToDeserialize, Type typeToDeserialize)
        {
            return DeserializeXmlObject<T>(stringToDeserialize, typeToDeserialize);
        }
    }
}