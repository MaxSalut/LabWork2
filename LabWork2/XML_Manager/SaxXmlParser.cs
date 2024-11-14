// LabWork2/XML_Manager/SaxXmlParser.cs


using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace LabWork2.XML_Manager
{
    /// <summary>
    /// Клас для парсингу XML за допомогою SAX
    /// </summary>
    public class SaxXmlParser : IXmlParser
    {
        private readonly List<Person> _people;
        private Person _currentPerson;
        private string _currentElement;

        public SaxXmlParser()
        {
            _people = new List<Person>();
        }

        /// <summary>
        /// Завантажує XML-документ з потоку, використовуючи SAX-парсинг
        /// </summary>
        /// <param name="inputStream">Вхідний потік XML</param>
        /// <param name="settings">Налаштування XmlReader</param>
        /// <returns>True, якщо завантаження успішне, інакше False</returns>
        public bool Load(Stream inputStream, XmlReaderSettings settings)
        {
            _people.Clear(); // Очищення списку перед новим завантаженням

            try
            {
                using var reader = XmlReader.Create(inputStream, settings);
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == "Person")
                            {
                                _currentPerson = new Person(); // Створення нового об'єкта Person
                            }
                            else if (_currentPerson != null)
                            {
                                _currentElement = reader.Name; // Зберігаємо назву поточного елемента
                            }
                            break;

                        case XmlNodeType.Text:
                            if (_currentPerson != null && _currentElement != null)
                            {
                                SetPersonData(_currentElement, reader.Value);
                            }
                            break;

                        case XmlNodeType.EndElement:
                            if (reader.Name == "Person" && _currentPerson != null)
                            {
                                _people.Add(_currentPerson); // Додаємо об'єкт Person до списку після закриття тега
                                _currentPerson = null;
                            }
                            _currentElement = null;
                            break;
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

        /// <summary>
        /// Встановлює дані для поточного об'єкта Person на основі назви елемента
        /// </summary>
        private void SetPersonData(string elementName, string value)
        {
            switch (elementName)
            {
                case "FirstName":
                    _currentPerson.Name.FirstName = value;
                    break;
                case "LastName":
                    _currentPerson.Name.LastName = value;
                    break;
                case "Faculty":
                    _currentPerson.Faculty = value;
                    break;
                case "Course":
                    _currentPerson.Course = value;
                    break;
                case "Room":
                    _currentPerson.Room = value;
                    break;
                
            }
        }
    }
}
