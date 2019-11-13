using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using WebApiBackendTeste.HateOAS;
using WebApiBackendTeste.Model;

namespace WebApiBackendTeste.Formatter
{
    public class HalJsonMediaTypeFormatter : BufferedMediaTypeFormatter
    {
        public HalJsonMediaTypeFormatter()
   : base()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue(
      "application/hal+xml"));
        }

        public override bool CanReadType(Type type)
        {
            return type.BaseType == typeof(ResourceCollection<>) || type.BaseType.GetGenericTypeDefinition() == typeof(Link);

        }

        public override bool CanWriteType(Type type)
        {
            return type.BaseType == typeof(ResourceCollection<>) || type.BaseType.GetGenericTypeDefinition() == typeof(Link);
        }

        public override void WriteToStream(Type type, object value,
  System.IO.Stream writeStream, System.Net.Http.HttpContent content)
        {
            var encoding = base.SelectCharacterEncoding(content.Headers);
            var settings = new XmlWriterSettings();
            settings.Encoding = encoding;
            var writer = XmlWriter.Create(writeStream, settings);
            var resource = (Link)value;
            if (resource is IEnumerable)
            {
                writer.WriteStartElement("resource");
                writer.WriteAttributeString("href", resource.Href);
                foreach (Link innerResource in (IEnumerable)resource)
                {
                    // Serializes the resource state and links recursively
                    SerializeInnerResource(writer, innerResource);
                }
                writer.WriteEndElement();
            }
            else
            {
                // Serializes a single linked resource
                SerializeInnerResource(writer, resource);
            }
            writer.Flush();
            writer.Close();
        }

        private void SerializeInnerResource(XmlWriter writer, Link innerResource)
        {
            throw new NotImplementedException();
        }

        public override object ReadFromStream(Type type,
          System.IO.Stream readStream, System.Net.Http.HttpContent content,
          IFormatterLogger formatterLogger)
        {
            if (type != typeof(Link))
                throw new ArgumentException(
                  "Only the LinkedResource type is supported", "type");
            var value = (Link)Activator.CreateInstance(type);
            var reader = XmlReader.Create(readStream);
            if (value is IEnumerable)
            {
                var collection = (ResourceCollection<Link>)value;
                reader.ReadStartElement("resource");
                value.Href = reader.GetAttribute("href");
                var innerType = type.BaseType.GetGenericArguments().First();
                while (reader.Read() && reader.LocalName == "resource")
                {
                    // Deserializes a linked resource recursively
                    var innerResource = DeserializeInnerResource(reader, innerType);
                    collection.Add(innerResource);
                }
            }
            else
            {
                // Deserializes a linked resource recursively
                value = DeserializeInnerResource(reader, type);
            }
            reader.Close();
            return value;
        }

        private Link DeserializeInnerResource(XmlReader reader, Type type)
        {
            throw new NotImplementedException();
        }
    }
}