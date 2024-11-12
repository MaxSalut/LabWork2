// App.xaml.cs
using Microsoft.Maui.Controls;
using System;
namespace LabWork2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.FileSelectionPage());
        }

        
    }

}



