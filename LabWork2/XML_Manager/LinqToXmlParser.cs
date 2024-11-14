// LabWork2/XML_Manager/LinqXmlParser.cs


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace LabWork2.XML_Manager
{
    /// <summary>
    /// Клас для парсингу XML за допомогою LINQ to XML
    /// </summary>
    public class LinqXmlParser : IXmlParser
    {
        private readonly List<Person> _people;

        public LinqXmlParser()
        {
            _people = new List<Person>();
        }

        /// <summary>
        /// Завантажує XML-документ з потоку, використовуючи LINQ to XML
        /// </summary>
        /// <param name="inputStream">Вхідний потік XML</param>
        /// <param name="settings">Налаштування XmlReader</param>
        /// <returns>True, якщо завантаження успішне, інакше False</returns>
        public bool Load(Stream inputStream, XmlReaderSettings settings)
        {
            _people.Clear(); // Очищення списку перед завантаженням нового документу

            try
            {
                using var reader = XmlReader.Create(inputStream, settings);
                var document = XDocument.Load(reader);

                if (document.Root == null)
                    return false;

                // Використовує LINQ для вибірки даних з XML та перетворення їх в об’єкти Person
                var result = from person in document.Descendants("Person")
                             select new Person
                             {
                                 Name = new Person.FullName
                                 {
                                     FirstName = person.Element("Name")?.Element("FirstName")?.Value ?? "",
                                     LastName = person.Element("Name")?.Element("LastName")?.Value ?? ""
                                 },
                                 Faculty = person.Element("Faculty")?.Value ?? "",
                                 Course = person.Element("Course")?.Value ?? "",
                                 Room = person.Element("Room")?.Value ?? "",
                        
                             };

                _people.AddRange(result);
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
