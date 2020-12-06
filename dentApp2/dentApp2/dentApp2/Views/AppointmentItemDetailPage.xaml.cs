using dentApp2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dentApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointmentItemDetailPage : ContentPage
    {
        public Item Item { get; set; }

        public AppointmentItemDetailPage(Item Item)
        {
            InitializeComponent();
            this.Item = Item;
            BindingContext = this;
        }

        async void ToolbarItem_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage(Item));
        }

        async void ToolbarItem_Delete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Uwaga!", "Usunąć wizytę?", "Tak", "Nie"))
            {
                MessagingCenter.Send(this, "DelAppointmentItem", Item);
                await Navigation.PopAsync();
            }
        }

        async void ToolbarItem_Archive_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Uwaga!", "Przenieść wizytę do dokumentacji?", "Tak", "Nie"))
            {
                // change item status
                Item.Status = Item.status.Documentation;
                // send item to documentation
                MessagingCenter.Send(this, "AddDocumentationItem", Item);
                // delete item from appointments
                MessagingCenter.Send(this, "DelAppointmentItem", Item);
                await Navigation.PopAsync();
            }
        }
    }
}