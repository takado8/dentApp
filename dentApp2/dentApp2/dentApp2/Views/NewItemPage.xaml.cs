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

namespace dentApp2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        bool edit_mode = false;
        NewItemViewModel NewItemViewModel;


        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = NewItemViewModel = new NewItemViewModel();
        }

        public NewItemPage(Item existing_item)
        {
            InitializeComponent();
            BindingContext = NewItemViewModel = new NewItemViewModel(existing_item);
            edit_mode = true;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            NewItemViewModel.Item.DateTime = new DateTime(NewItemViewModel.Item.DateTime.Year,
                NewItemViewModel.Item.DateTime.Month, NewItemViewModel.Item.DateTime.Day,
                NewItemViewModel.SelectedTime.Hours, NewItemViewModel.SelectedTime.Minutes, 0);

            if (edit_mode)
            {
                // delete old copy
                MessagingCenter.Send(this, "DelItem", NewItemViewModel.OldItem);
                // remove old ItemDetailPage
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
            MessagingCenter.Send(this, "AddItem", NewItemViewModel.Item);
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


    }
}