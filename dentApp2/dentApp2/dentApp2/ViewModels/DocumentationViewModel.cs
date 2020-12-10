using dentApp2.Models;
using dentApp2.Services;
using dentApp2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace dentApp2.ViewModels
{
    class DocumentationViewModel : ItemsBaseViewModel
    {
        public DocumentationViewModel()
        {
            MessagingCenter.Subscribe<NewItemViewModel, Item>(this, "AddDocumentationItem", async (obj, item) =>
            {
                var newItem = item as Item;
                InsertItem(newItem);
                await SQLiteDataStorage.AddItemAsync(newItem);
            });

            MessagingCenter.Subscribe<AppointmentItemDetailPage, Item>(this, "AddDocumentationItem", async (obj, item) =>
            {
                var newItem = item as Item;
                InsertItem(newItem);
                await SQLiteDataStorage.AddItemAsync(newItem);
            });

            MessagingCenter.Subscribe<NewItemViewModel, Item>(this, "DelDocumentationItem", async (obj, item) =>
            {
                var oldItem = item as Item;
                Items.Remove(oldItem);
                await SQLiteDataStorage.DelItemAsync(oldItem);
            });

            MessagingCenter.Subscribe<DocumentationItemDetailPage, Item>(this, "DelDocumentationItem", async (obj, item) =>
            {
                var oldItem = item as Item;
                Items.Remove(oldItem);
                await SQLiteDataStorage.DelItemAsync(oldItem);
            });

            var itemsTask = SQLiteDataStorage.GetItemsAsync(Item.status.Documentation);
            itemsTask.Wait();
            var items = itemsTask.Result;

            foreach (var item in items)
            {
                InsertItem(item);
            }
        }
    }
}
