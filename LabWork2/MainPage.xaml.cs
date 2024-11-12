// MainPage.xaml.cs
using Microsoft.Maui.Controls;

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
                // Закрити програму
                Application.Current.Quit();
            }
            // Інакше нічого не робимо, тобто закриття вікна буде скасовано
        }

        private async void OnFindClicked(object sender, EventArgs e)
        {
            // Виконання пошуку за критеріями
            await DisplayAlert("Результат", "Виконано пошук за критеріями", "OK");
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            // Очищення полів для нових параметрів
            NameEntry.Text = FacultyEntry.Text = CourseEntry.Text = DateEntry.Text = string.Empty;
        }

        private async void OnTransformToHtmlClicked(object sender, EventArgs e)
        {
            // Трансформація в HTML
            await DisplayAlert("Повідомлення", "Трансформація виконана успішно", "OK");
        }
    }
}
