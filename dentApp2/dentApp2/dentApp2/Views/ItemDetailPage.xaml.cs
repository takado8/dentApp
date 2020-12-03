using dentApp2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dentApp2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        public Item Item { get; set; }

        public ItemDetailPage(Item Item)
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
            bool answer = await DisplayAlert("Uwaga!", "Usunąć wizytę?", "Tak", "Nie");
            if (answer)
            {
                MessagingCenter.Send(this, "DelItem", Item);
                await Navigation.PopAsync();
            }
        }

        async void ToolbarItem_Archive_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Uwaga!", "Przenieść wizytę do archiwum?", "Tak", "Nie");
            if (answer)
            {
            }
        }
    }
}