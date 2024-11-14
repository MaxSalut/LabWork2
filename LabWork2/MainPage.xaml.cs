using Microsoft.Maui.Controls;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using LabWork2.XML_Manager;

namespace LabWork2.Views
{
    public partial class MainPage : ContentPage
    {
        private string _filePath;
        public MainPage(string filePath)
        {
            InitializeComponent();
            _filePath = filePath;
        }


        private async void OnFindClicked(object sender, EventArgs e)
        {
            // тут має бути реалізація кнопки find яка буде шукати використовуючи те що я виберу через picker тобто шукати за домогою LINQ SaX DOM і буде шукати за критеріями нижче. У мене є <entry> - туди я ввожу що я хочу шукати а зліва коло entry стоїть checkbox. Якщо Checkbox горить то за критерієм справа я хочу шукати
            
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
