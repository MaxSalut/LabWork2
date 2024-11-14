using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace LabWork2.XML_Manager
{
    /// <summary>
    /// Реалізація IXmlParser для обробки XML-документу за допомогою SAX API.
    /// </summary>
    public class SaxXmlParser : IXmlParser
    {
        /// <summary>
        /// Аналізує XML-документ за допомогою SAX API.
        /// </summary>
        /// <param name="filePath">Шлях до XML-файлу.</param>
        /// <returns>Результат аналізу у вигляді рядка.</returns>
        public string AnalyzeDocument(string filePath)
        {
            StringBuilder result = new StringBuilder();
            result.Append("Результат аналізу SAX:\n");

            try
            {
                using (XmlReader reader = XmlReader.Create(filePath))
                {
                    while (reader.Read())
                    {
                        // Перевіряємо, чи це початок елемента.
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "student")
                        {
                            string name = reader.GetAttribute("name") ?? "Без імені";
                            string room = reader.GetAttribute("room") ?? "Без кімнати";
                            result.AppendLine($"Ім'я: {name}, Кімната: {room}");
                        }
                    }
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
