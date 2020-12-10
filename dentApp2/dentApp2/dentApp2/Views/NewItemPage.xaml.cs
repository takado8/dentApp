using dentApp2.Models;
using dentApp2.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dentApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        NewItemViewModel NewItemViewModel;
        bool EditMode = false;
        bool ButtonIsBusy = false; 

        public NewItemPage(Item.status status)
        {
            InitializeComponent();
            BindingContext = NewItemViewModel = new NewItemViewModel(status);
        }

        public NewItemPage(Item existing_item)
        {
            InitializeComponent();
            BindingContext = NewItemViewModel = new NewItemViewModel(existing_item);
            EditMode = true;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            if (ButtonIsBusy)
                return;
            ButtonIsBusy = true;

            if (EditMode)
            {
                NewItemViewModel.SaveEditedItem();
                // remove old ItemDetailPage from navigation stack.
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
            else
                NewItemViewModel.SaveNewItem();

            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            if (ButtonIsBusy)
                return;
            ButtonIsBusy = true;

            await Navigation.PopAsync();
        }
    }
}