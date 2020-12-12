using dentApp2.Models;
using dentApp2.Services;
using dentApp2.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace dentApp2.ViewModels
{
    public class AppointmentsViewModel : ItemsBaseViewModel
    {
        public AppointmentsViewModel()
        {
            MessagingCenter.Subscribe<NewItemViewModel, Item>(this, "AddAppointmentItem", async (obj, item) =>
            {
                var newItem = item as Item;
                InsertItem(newItem);
                await SQLiteDataStorage.AddItemAsync(newItem);
            });

            MessagingCenter.Subscribe<NewItemViewModel, Item>(this, "DelAppointmentItem", async (obj, item) =>
            {
               await DeleteItem(item);
            });

            MessagingCenter.Subscribe<AppointmentItemDetailPage, Item>(this, "DelAppointmentItem", async (obj, item) =>
            {
               await DeleteItem(item);
            });

            var itemsTask = SQLiteDataStorage.GetItemsAsync(Item.status.Appointment);
            itemsTask.Wait();
            var items = itemsTask.Result;

            foreach (var item in items)
            {
                InsertItem(item);
            }
        }

        async Task DeleteItem(Item oldItem)
        {
            Items.Remove(oldItem);
            await SQLiteDataStorage.DelItemAsync(oldItem);
        }
    }
}
