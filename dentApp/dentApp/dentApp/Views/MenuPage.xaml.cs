using dentApp.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dentApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;

        public MenuPage()
        {
            InitializeComponent();
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Appointments, Title="Wizyty" },
                new HomeMenuItem {Id = MenuItemType.Menu, Title="Menu" }
            };
            
            ListViewMenu.ItemsSource = menuItems;

            //ListViewMenu.SelectedItem = menuItems[1];
            ListViewMenu.ItemTapped += async (sender, e) =>
            {

                if (e.Item == null)
                {
                    return;
                }

                var id = (int)((HomeMenuItem)e.Item).Id;
                await RootPage.NavigateFromMenu(id);
                ListViewMenu.SelectedItem = null;
            };
            //ListViewMenu.ItemSelected += async (sender, e) =>
            //{
            //    if (e.SelectedItem == null)
            //    {
            //        return;
            //    }

            //    var id = (int)((HomeMenuItem)e.SelectedItem).Id;
            //    await RootPage.NavigateFromMenu(id);
            //};
        }

       
    }
}