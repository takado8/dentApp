using dentApp2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace dentApp2
{
    public partial class MainPage : ContentPage
    {
        AppointmentsPage AppointmentsPage;
        DocumentationPage DocumentationPage;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Appointments_Clicked(object sender, EventArgs e)
        {
            if(AppointmentsPage == null)
            {
                AppointmentsPage = new AppointmentsPage();
            }
            Navigation.PushAsync(AppointmentsPage);
        }

        private void Button_Documentation_Clicked(object sender, EventArgs e)
        {
            if (DocumentationPage == null)
            {
                DocumentationPage = new DocumentationPage();
            }
            Navigation.PushAsync(DocumentationPage);
        }
    }
}
