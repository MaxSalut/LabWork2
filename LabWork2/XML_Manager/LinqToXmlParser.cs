using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace LabWork2.XML_Manager
{
    /// <summary>
    /// Реалізація IXmlParser для обробки XML-документу за допомогою LINQ to XML.
    /// </summary>
    public class LinqToXmlParser : IXmlParser
    {
        /// <summary>
        /// Аналізує XML-документ за допомогою LINQ to XML.
        /// </summary>
        /// <param name="filePath">Шлях до XML-файлу.</param>
        /// <returns>Результат аналізу у вигляді рядка.</returns>
        public string AnalyzeDocument(string filePath)
        {
            StringBuilder result = new StringBuilder();
            result.Append("Результат аналізу LINQ to XML:\n");

            try
            {
                XDocument doc = XDocument.Load(filePath);

                // Припускаємо, що документ має елементи <student> з атрибутами "name" та "room".
                var students = doc.Descendants("student")
                                  .Select(x => new
                                  {
                                      Name = x.Attribute("name")?.Value ?? "Без імені",
                                      Room = x.Attribute("room")?.Value ?? "Без кімнати"
                                  });

                foreach (var student in students)
                {
                    result.AppendLine($"Ім'я: {student.Name}, Кімната: {student.Room}");
                }

                return result.ToString();
            }
            catch (Exception ex)
            {
                return $"Помилка при аналізі документа: {ex.Message}";
            }
        }
    }
}
