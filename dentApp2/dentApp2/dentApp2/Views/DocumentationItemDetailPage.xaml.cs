using dentApp2.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dentApp2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DocumentationItemDetailPage : ContentPage
	{
        public Item Item { get; set; }
        bool ButtonIsBusy = false;

        public DocumentationItemDetailPage(Item Item)
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
            if (ButtonIsBusy)
                return;
            ButtonIsBusy = true;

            if (await DisplayAlert("Uwaga!", "Usunąć wizytę?", "Tak", "Nie"))
            {
                MessagingCenter.Send(this, "DelDocumentationItem", Item);
                await Navigation.PopAsync();
            }
            ButtonIsBusy = false;
        }
    }
}