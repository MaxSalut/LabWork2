// FileSelectionPage.xaml.cs
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace LabWork2.Views
{
    public partial class FileSelectionPage : ContentPage
    {
        public FileSelectionPage()
        {
            InitializeComponent();
        }

        private async void OnAddFileClicked(object sender, EventArgs e)
        {
            var file = await FilePicker.Default.PickAsync();
            if (file != null && file.FileName.EndsWith(".xml"))
            {
                FileStatusLabel.Text = $"Додано {file.FileName}";
                NextButton.IsEnabled = true;
            }
            else
            {
                await DisplayAlert("Помилка", "Будь ласка, оберіть XML файл", "OK");
            }
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
