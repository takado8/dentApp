using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dentApp2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewItemPage : ContentPage
	{
        public DateTime DateTime { get; set; } = DateTime.Now;
        public TimeSpan SelectedTime { get; set; } = new TimeSpan(15, 0, 0);
        public Item Item { get; set; } = new Item();
       
		public NewItemPage ()
		{      
			InitializeComponent ();
            BindingContext = this;
		}

        async void Save_Clicked(object sender, EventArgs e)
        {
            Item.Date = DateTime.ToString("dd'.'MM'.'yyyy") + " - " + SelectedTime.ToString(@"hh\:mm");
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

       
    }
}