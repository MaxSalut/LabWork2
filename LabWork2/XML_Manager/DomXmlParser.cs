// LabWork2/XML_Manager/DomXmlParser.cs

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace LabWork2.XML_Manager
{
    /// <summary>
    /// Клас для парсингу XML за допомогою DOM
    /// </summary>
    public class DomXmlParser : IXmlParser
    {
        private readonly List<Person> _people;

        public DomXmlParser()
        {
            _people = new List<Person>();
        }

        /// <summary>
        /// Завантажує XML-документ з потоку, використовуючи DOM-парсинг
        /// </summary>
        /// <param name="inputStream">Вхідний потік XML</param>
        /// <param name="settings">Налаштування XmlReader</param>
        /// <returns>True, якщо завантаження успішне, інакше False</returns>
        public bool Load(Stream inputStream, XmlReaderSettings settings)
        {
            _people.Clear(); // Очищення списку на випадок повторного завантаження

            var document = new XmlDocument();
            try
            {
                using var reader = XmlReader.Create(inputStream, settings);
                document.Load(reader);

                if (document.DocumentElement == null)
                    return false;

                var serializer = new XmlSerializer(typeof(Person));
                foreach (XmlNode childNode in document.DocumentElement.ChildNodes)
                {
                    if (serializer.Deserialize(new StringReader(childNode.OuterXml)) is Person person)
                    {
                        _people.Add(person);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Здійснює пошук у завантаженому документі за заданими фільтрами
        /// </summary>
        /// <param name="filters">Фільтри для пошуку</param>
        /// <returns>Список об'єктів Person, що відповідають критеріям пошуку</returns>
        public IList<Person> Find(Filters filters)
        {
            // Повертає список об'єктів, що відповідають критеріям фільтрації
            return _people.FindAll(person => filters.ValidatePerson(person));
        }
    }
}
