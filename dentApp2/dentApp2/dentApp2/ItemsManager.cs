using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace dentApp2
{
    public class Item
    {
        public string Date { get; set; }
        public string Description { get; set; }
    }

    public class ItemsManager
    {
        ObservableCollection<Item> _items;

        public ObservableCollection<Item> Items
        {
            get
            {
                return _items ?? (_items = new ObservableCollection<Item>());
            }
        }

        public ItemsManager()
        {
            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
            });

            var itm1 = new Item()
            {
                Date = "12.12.2020 - 15:30",
                Description = "Ekstrakcja"
            };
            var itm2 = new Item()
            {
                Date = "16.12.2020 - 16:00",
                Description = "Wypełnienie"
            };
            var itm3 = new Item()
            {
                Date = "18.12.2020 - 13:15",
                Description = "Kontrola"
            };

            Items.Add(itm1);
            Items.Add(itm2);
            Items.Add(itm3);
        }

    }
}
