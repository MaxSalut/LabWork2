using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork2.XML_Manager
{
    /// <summary>
    /// Інтерфейс для стратегій обробки XML-документів.
    /// </summary>
    public interface IXmlParser
    {
        /// <summary>
        /// Метод для аналізу XML-документу.
        /// </summary>
        /// <param name="filePath">Шлях до XML-файлу.</param>
        /// <returns>Результат аналізу у вигляді рядка або іншої структури, що представляє результати.</returns>
        string AnalyzeDocument(string filePath);
    }
}
