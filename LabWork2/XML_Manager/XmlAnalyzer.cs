using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork2.XML_Manager
{
    // XML_Manager/XmlAnalyzer.cs

    
        /// <summary>
        /// Клас для аналізу XML-документів з можливістю вибору стратегії обробки.
        /// </summary>
        public class XmlAnalyzer
        {
            private IXmlParser _parser;

            /// <summary>
            /// Встановлює стратегію парсера для аналізу XML.
            /// </summary>
            /// <param name="parser">Реалізація IXmlParser (SAX, DOM, LINQ to XML).</param>
            public void SetParserStrategy(IXmlParser parser)
            {
                _parser = parser;
            }

            /// <summary>
            /// Виконує аналіз XML-документу за вибраною стратегією.
            /// </summary>
            /// <param name="filePath">Шлях до XML-файлу.</param>
            /// <returns>Результат аналізу у вигляді рядка.</returns>
            public string Analyze(string filePath)
            {
                if (_parser == null)
                {
                    return "Стратегія парсера не встановлена. Будь ласка, виберіть метод обробки.";
                }

                return _parser.AnalyzeDocument(filePath);
            }
        }
    }


