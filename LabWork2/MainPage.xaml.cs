using Microsoft.Maui.Controls;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace LabWork2.Views
{
    public partial class MainPage : ContentPage
    {
        private List<Student> xmlData;
        private XDocument xmlDoc;

        public MainPage()
        {
            InitializeComponent();
            xmlData = new List<Student>();
            xmlDoc = ConvertToXDocument(xmlData); // Ініціалізація xmlDoc в конструкторі
        }

        private XDocument ConvertToXDocument(List<Student> students)
        {
            return new XDocument(
                new XElement("Students",
                    students.Select(student =>
                        new XElement("Student",
                            new XElement("FullName", student.FullName),
                            new XElement("Faculty", student.Faculty),
                            new XElement("Department", student.Department),
                            new XElement("Course", student.Course),
                            new XElement("Room", student.Room),
                            new XElement("CheckIn", student.CheckIn),
                            new XElement("CheckOut", student.CheckOut)
                        )
                    )
                )
            );
        }

        public async Task HandleCloseRequestAsync()
        {
            bool answer = await DisplayAlert("Підтвердження виходу", "Чи дійсно ви хочете завершити роботу з програмою?", "Так", "Ні");
            if (answer)
            {
                Application.Current.Quit();
            }
        }

        private async void OnFindClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Результат", "Виконано пошук за критеріями", "OK");
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            NameEntry.Text = FacultyEntry.Text = CourseEntry.Text = DateEntry.Text = string.Empty;
        }
        private async void OnTransformToHtmlClicked(object sender, EventArgs e)
        {
            HtmlTransformer transformer = new HtmlTransformer();
            var htmlContent = transformer.TransformToHtml(xmlDoc); // Передаємо xmlData

            // Шлях до файлу, куди зберігати HTML
            string projectDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(projectDirectory, "output.html");

            // Записуємо в файл
            try
            {
                await File.WriteAllTextAsync(filePath, htmlContent);
                await DisplayAlert("Успіх", $"HTML файл збережено за адресою: {filePath}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Помилка", $"Не вдалося зберегти файл: {ex.Message}", "OK");
            }
        }

    }
}
