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
        }

        private void Button_Appointments_Clicked(object sender, EventArgs e)
        {
            if (ButtonIsBusy)
                return;
            ButtonIsBusy = true;

            Navigation.PushAsync(AppointmentsPage ?? (AppointmentsPage = new AppointmentsPage()));
            if (DocumentationPage == null)
            {
                DocumentationPage = new DocumentationPage();
            }
        }

        private void Button_Documentation_Clicked(object sender, EventArgs e)
        {
            if (ButtonIsBusy)
                return;
            ButtonIsBusy = true;

            Navigation.PushAsync(DocumentationPage ?? (DocumentationPage = new DocumentationPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (ButtonIsBusy)
                ButtonIsBusy = false;
        }
    }

}
