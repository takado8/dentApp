using dentApp2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace dentApp2.ViewModels
{
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
                InsertItem(newItem);
            });

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "DelItem", (obj, item) =>
            {
                var oldItem = item as Item;
                Items.Remove(oldItem);
            });

            MessagingCenter.Subscribe<ItemDetailPage, Item>(this, "DelItem", (obj, item) =>
            {
                var oldItem = item as Item;
                Items.Remove(oldItem);
            });

            var itm1 = new Item()
            {
                DateTime = new DateTime(2020, 12, 22, 15, 30, 0),
                Description = "Dodatkowy opis.",
                DentistName = "Aleksandra Kasprzak",
                TreatmentType = "Ekstrakcja"
            };
            var itm2 = new Item()
            {
                DateTime = new DateTime(2020, 12, 18, 17, 45, 0),
                TreatmentType = "Wypełnienie",
                DentistName = "Aleksandra Kasprzak",
                Description = "Dodatkowy opis."
            };
            var itm3 = new Item()
            {
                DateTime = new DateTime(2020, 12, 14, 17, 45, 0),
                TreatmentType = "Wypełnienie",
                DentistName = "Aleksandra Kasprzak",
                Description = "Dodatkowy opis."
            };

            InsertItem(itm1);
            InsertItem(itm2);
            InsertItem(itm3);
        }

        void InsertItem(Item item)
        {
            int i = 0;
            for (i = 0; i < Items.Count; i++)
            {
                if (item.DateTime.CompareTo(Items[i].DateTime) < 0)
                {
                    break;
                }
            }
            Items.Insert(i, item);
        }

    }
}
