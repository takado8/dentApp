using dentApp2.Models;
using dentApp2.Services;
using dentApp2.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace dentApp2.ViewModels
{
    class DocumentationViewModel : ItemsBaseViewModel
    {
        public DocumentationViewModel()
        {
            MessagingCenter.Subscribe<NewItemViewModel, Item>(this, "AddDocumentationItem", async (obj, item) =>
            {
                await AddItem(item);
            });

            MessagingCenter.Subscribe<AppointmentItemDetailPage, Item>(this, "AddDocumentationItem", async (obj, item) =>
            {
                await AddItem(item);
            });

            MessagingCenter.Subscribe<NewItemViewModel, Item>(this, "DelDocumentationItem", async (obj, item) =>
            {
                await DeleteItem(item);
            });

            MessagingCenter.Subscribe<DocumentationItemDetailPage, Item>(this, "DelDocumentationItem", async (obj, item) =>
            {
                await DeleteItem(item);
            });

            var itemsTask = SQLiteDataStorage.GetItemsAsync(Item.status.Documentation);
            itemsTask.Wait();
            var items = itemsTask.Result;

            foreach (var item in items)
            {
                InsertItem(item);
            }
        }

        async Task AddItem(Item item)
        {
            var newItem = item as Item;
            InsertItem(newItem);
            await SQLiteDataStorage.AddItemAsync(newItem);
        }

        async Task DeleteItem(Item item)
        {
            Items.Remove(item);
            await SQLiteDataStorage.DelItemAsync(item);
        }
    }
}
