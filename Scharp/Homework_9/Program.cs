using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Homework_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Напишите приложение, конвертирующее произвольный JSON в XML. Используйте JsonDocument.

            JsonToXml("Example.json");
        }

        public static void JsonToXml(string fileName)
        {
            string json = File.ReadAllText(fileName);
            //JsonDocument jsonDocument = JsonDocument.Parse(File.ReadAllText(fileName));

            var xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader
                (Encoding.ASCII.GetBytes(json), new XmlDictionaryReaderQuotas()));

            XDocument xmlDocument = new XDocument(xml);

            Console.WriteLine(xmlDocument.ToString());

            using (var writer = XmlWriter.Create("Example.xml"))
                xmlDocument.WriteTo(writer);

        }
    }
}
