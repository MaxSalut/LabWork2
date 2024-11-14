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
        public MainPage()
        {
            InitializeComponent();
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
            NameEntry.Text = FacultyEntry.Text = CourseEntry.Text = RoomEntry.Text = string.Empty;
        }
        private async void OnTransformToHtmlClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Результат", "Виконано!", "OK");
        }

    }
}
