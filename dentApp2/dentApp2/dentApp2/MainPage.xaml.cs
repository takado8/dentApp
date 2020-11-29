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
        AppointmentsPage appointmentsPage;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_wizyty_Clicked(object sender, EventArgs e)
        {
            if(appointmentsPage is null)
            {
                appointmentsPage = new AppointmentsPage();
            }
            Navigation.PushAsync(appointmentsPage);
        }
    }
}
