using dentApp2.Models;
using dentApp2.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dentApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        bool edit_mode = false;
        NewItemViewModel NewItemViewModel;


        public NewItemPage(Item.status status)
        {
            InitializeComponent();
            BindingContext = NewItemViewModel = new NewItemViewModel(status);
        }

        public NewItemPage(Item existing_item)
        {
            InitializeComponent();
            BindingContext = NewItemViewModel = new NewItemViewModel(existing_item);
            edit_mode = true;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            if (edit_mode)
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
            await Navigation.PopAsync();
        }
    }
}