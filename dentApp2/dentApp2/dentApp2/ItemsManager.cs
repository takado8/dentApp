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
        public string DentistName { get; set; }
        public string TreatmentType { get; set; }
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
                Description = "Dodatkowy opis.",
                DentistName = "Aleksandra Kasprzak",
                TreatmentType = "Ekstrakcja"
            };
            var itm2 = new Item()
            {
                Date = "16.12.2020 - 16:00",
                TreatmentType = "Wypełnienie",
                DentistName = "Aleksandra Kasprzak",
                Description = "Dodatkowy opis."
            };
          
            Items.Add(itm1);
            Items.Add(itm2);
        }

    }
}
