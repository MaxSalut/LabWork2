// LabWork2/Views/FindResultPage.xaml.cs

using Microsoft.Maui.Controls;
using System.Collections.Generic;
using LabWork2.XML_Manager;

namespace LabWork2.Views
{
    public partial class FindResultPage : ContentPage
    {
        public FindResultPage(IList<Person> searchResults)
        {
            InitializeComponent();

            // Прив'язка результатів пошуку до CollectionView
            ResultsCollectionView.ItemsSource = searchResults;
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Повернення на попередню сторінку
        }
    }
}
