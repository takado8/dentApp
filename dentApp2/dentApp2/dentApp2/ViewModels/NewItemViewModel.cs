using dentApp2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dentApp2.ViewModels
{
    public class NewItemViewModel
    {
        public TimeSpan SelectedTime { get; set; }
        public Item Item { get; set; }
        public Item OldItem;

        public NewItemViewModel()
        {
            Item = new Item()
            {
                DateTime = DateTime.Now
            };
            SelectedTime = new TimeSpan(Item.DateTime.Hour, 0, 0);
        }

        public NewItemViewModel(Item existing_item)
        {
            OldItem = existing_item;
            Item = new Item(existing_item);
            SelectedTime = new TimeSpan(Item.DateTime.Hour, Item.DateTime.Minute, 0);
        }
    }
}
