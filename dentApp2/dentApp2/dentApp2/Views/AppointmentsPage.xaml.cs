﻿using dentApp2.Models;
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
    public partial class AppointmentsPage : ContentPage
    {
        ItemsManager itemsManager = new ItemsManager();

        public AppointmentsPage()
        {
            InitializeComponent();
            BindingContext = itemsManager;
        }

        async void ItemsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is Item item))
                return;

            await Navigation.PushAsync(new ItemDetailPage(item));
            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void ToolbarItem_Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }
    }
}