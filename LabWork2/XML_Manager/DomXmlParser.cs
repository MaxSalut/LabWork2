using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LabWork2.XML_Manager
{
    /// <summary>
    /// Реалізація IXmlParser для обробки XML-документу за допомогою DOM API.
    /// </summary>
    public class DomXmlParser : IXmlParser
    {
        /// <summary>
        /// Аналізує XML-документ за допомогою DOM API.
        /// </summary>
        /// <param name="filePath">Шлях до XML-файлу.</param>
        /// <returns>Результат аналізу у вигляді рядка.</returns>
        public string AnalyzeDocument(string filePath)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);

                // Створимо приклад аналізу — отримаємо всі вузли певного типу, наприклад, "student".
                XmlNodeList nodes = doc.GetElementsByTagName("student");
                string result = $"Знайдено {nodes.Count} студентів:\n";

                foreach (XmlNode node in nodes)
                {
                    // Отримаємо дані атрибутів або текстових елементів.
                    string name = node.Attributes["name"]?.InnerText ?? "Без імені";
                    string room = node.Attributes["room"]?.InnerText ?? "Без кімнати";
                    result += $"Ім'я: {name}, Кімната: {room}\n";
                }

                return result;
            }
            catch (Exception ex)
            {
                return $"Помилка при аналізі документа: {ex.Message}";
            }
        }
    }
}
