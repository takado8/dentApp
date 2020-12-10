using dentApp2.Models;
using dentApp2.Services;
using dentApp2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace dentApp2.Views
{
    public partial class MainPage : ContentPage
    {
        AppointmentsPage AppointmentsPage;
        DocumentationPage DocumentationPage;
        bool ButtonIsBusy = false;

        public MainPage()
        {
            InitializeComponent();
            DocumentationPage = new DocumentationPage();
        }

        private void Button_Appointments_Clicked(object sender, EventArgs e)
        {
            if (ButtonIsBusy)
                return;
            ButtonIsBusy = true;

            if (AppointmentsPage == null)
            {
                AppointmentsPage = new AppointmentsPage();
            }
            Navigation.PushAsync(AppointmentsPage);
        }

        private void Button_Documentation_Clicked(object sender, EventArgs e)
        {
            if (ButtonIsBusy)
                return;
            ButtonIsBusy = true;
            Navigation.PushAsync(DocumentationPage);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (ButtonIsBusy)
                ButtonIsBusy = false;
        }
    }

}
