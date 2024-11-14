using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace LabWork2.XML_Manager
{
    // XML_Manager/TransformToHTML.cs

   
        /// <summary>
        /// Клас для перетворення XML-файлу в HTML за допомогою XSLT.
        /// </summary>
        public class XmlTransformer
        {
            /// <summary>
            /// Перетворює XML-документ у HTML-документ на основі XSL-документу.
            /// </summary>
            /// <param name="xmlFilePath">Шлях до XML-файлу.</param>
            /// <param name="xslFilePath">Шлях до XSL-файлу.</param>
            /// <param name="outputHtmlPath">Шлях для збереження результату у HTML-файл.</param>
            /// <returns>Повідомлення про успіх або помилку.</returns>
            public string TransformToHtml(string xmlFilePath, string xslFilePath, string outputHtmlPath)
            {
                try
                {
                    // Перевіряємо, чи існують вхідні файли XML та XSL
                    if (!File.Exists(xmlFilePath) || !File.Exists(xslFilePath))
                    {
                        return "Помилка: XML або XSL файл не знайдено.";
                    }

                    // Створюємо XslCompiledTransform для виконання трансформації
                    XslCompiledTransform xslTransform = new XslCompiledTransform();
                    xslTransform.Load(xslFilePath);  // Завантажуємо XSL

                    // Виконуємо трансформацію XML у HTML
                    using (FileStream outputFile = File.Create(outputHtmlPath))
                    using (XmlWriter writer = XmlWriter.Create(outputFile, xslTransform.OutputSettings))
                    {
                        xslTransform.Transform(xmlFilePath, writer);
                    }

                    return $"Успіх: HTML файл створено за шляхом {outputHtmlPath}";
                }
                catch (Exception ex)
                {
                    return $"Помилка при трансформації: {ex.Message}";
                }
            
        }
    }

}
