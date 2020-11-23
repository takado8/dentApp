using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dentApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void Button_wizyty_Clicked(object sender, EventArgs e)
        {
            // Navigation.PushAsync(new ItemsPage());
            
            await RootPage.NavigateFromMenu(0);
        }
    }
}