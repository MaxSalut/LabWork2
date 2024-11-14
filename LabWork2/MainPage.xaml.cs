// LabWork2/MainPage.xaml.cs

using Microsoft.Maui.Controls;
using System;
using LabWork2.XML_Manager;
using System.Xml;

namespace LabWork2.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly string _filePath;
        private IXmlParser _currentParser;

        public MainPage(string filePath)
        {
            InitializeComponent();
            _filePath = filePath;
            ParserPicker.SelectedIndexChanged += OnParserPickerChanged;
        }

        private void OnParserPickerChanged(object sender, EventArgs e)
        {
            // Ініціалізація парсера на основі вибраного типу
            switch (ParserPicker.SelectedItem.ToString())
            {
                case "DOM":
                    _currentParser = new DomXmlParser();
                    break;
                case "LINQ to XML":
                    _currentParser = new LinqXmlParser();
                    break;
                case "SAX":
                    _currentParser = new SaxXmlParser();
                    break;
            }

            // Завантаження файлу з обраним парсером
            if (_currentParser != null)
            {
                var settings = new XmlReaderSettings { DtdProcessing = DtdProcessing.Ignore };
                using var stream = File.OpenRead(_filePath);
                if (_currentParser.Load(stream, settings))
                {
                    Console.WriteLine("Файл завантажено успішно.");
                }
                else
                {
                    Console.WriteLine("Помилка завантаження файлу.");
                }
            }

        }
        private async void OnFindClicked(object sender, EventArgs e)
        {
            if (_currentParser == null)
            {
                Console.WriteLine("Парсер не обрано.");
                return;
            }

            // Створення фільтрів на основі полів введення і чекбоксів
            var filters = new Filters
            {
                Name = NameCheckBox.IsChecked == true ? NameEntry.Text : "",
                Faculty = FacultyCheckBox.IsChecked == true ? FacultyEntry.Text : "",
                Course = CourseCheckBox.IsChecked == true ? CourseEntry.Text : "",
                Room = RoomCheckBox.IsChecked == true ? RoomEntry.Text : ""
            };

            // Виконання пошуку з використанням парсера
            IList<Person> results = _currentParser.Find(filters);

            // Перехід на сторінку з результатами, якщо знайдено хоча б один результат

            if (results.Count > 0)
            {
                await Navigation.PushAsync(new FindResultPage(results));
            }
            else
            {
                await DisplayAlert("Результати пошуку", "Результатів не знайдено.", "OK");
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            //тут має відбуватися очистка всіх критеріїв пошуку
            NameEntry.Text = FacultyEntry.Text = CourseEntry.Text = RoomEntry.Text = string.Empty;
        }
        private async void OnTransformToHtmlClicked(object sender, EventArgs e)
        {
            // тут має бути реалізація кнопки, тобто при її натисканні має виконуватися трансформація заданого xml файлу в FileSelectionPage.xaml.cs to HTML.
            //Вхідні дані для аналізу та трансформації надаються у вигляді файлу - прикладу *.xml. Трансформація документу в HTML-код виконується на основі XSLдокумента *.xsl
        }
    }
}
