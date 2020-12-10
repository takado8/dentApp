using dentApp2.Models;
using System;
using Xamarin.Forms;

namespace dentApp2.ViewModels
{
    public class NewItemViewModel
    {
        public TimeSpan SelectedTime { get; set; }
        public Item Item { get; set; }
        public Item OldItem;

        public NewItemViewModel(Item.status status)
        {
            Item = new Item()
            {
                DateTime = DateTime.Now,
                Status = status
            };
            SelectedTime = new TimeSpan(Item.DateTime.Hour, 0, 0);
        }

        public NewItemViewModel(Item existing_item)
        {
            OldItem = existing_item;
            Item = new Item(existing_item);
            SelectedTime = new TimeSpan(Item.DateTime.Hour, Item.DateTime.Minute, 0);
        }

        public void SaveNewItem()
        {
            Item.DateTime = new DateTime(Item.DateTime.Year, Item.DateTime.Month,
                Item.DateTime.Day, SelectedTime.Hours, SelectedTime.Minutes, 0);

            if (Item.Status == Item.status.Appointment)
                MessagingCenter.Send(this, "AddAppointmentItem", Item);
            else if (Item.Status == Item.status.Documentation)
                MessagingCenter.Send(this, "AddDocumentationItem", Item);
            else throw new NotImplementedException("Failed to save the Item, Item.status is null");

        }

        public void SaveEditedItem()
        {
            // delete old copy
            if (Item.Status == Item.status.Appointment)
                MessagingCenter.Send(this, "DelAppointmentItem", OldItem);
            else
                MessagingCenter.Send(this, "DelDocumentationItem", OldItem);
            SaveNewItem();
        }
    }
}