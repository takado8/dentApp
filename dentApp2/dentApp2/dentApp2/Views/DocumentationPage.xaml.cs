using dentApp2.Models;
using dentApp2.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dentApp2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DocumentationPage : ContentPage
	{
        DocumentationViewModel DocumentationViewModel;

        public DocumentationPage ()
		{
			InitializeComponent ();
            BindingContext = DocumentationViewModel = new DocumentationViewModel();
        }

        async void ItemsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is Item item))
                return;

            await Navigation.PushAsync(new DocumentationItemDetailPage(item));
            // Manually deselect item.
            ItemsListView2.SelectedItem = null;
        }

        async void ToolbarItem_Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage(Item.status.Documentation));
        }
    }
}