using dentApp2.Models;
using dentApp2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace dentApp2.ViewModels
{
    public class ItemsBaseViewModel
    {
        ObservableCollection<Item> _items;
        public SQLiteDataStorage SQLiteDataStorage = new SQLiteDataStorage();


        public ObservableCollection<Item> Items
        {
            get
            {
                return _items ?? (_items = new ObservableCollection<Item>());
            }
        }

        public void InsertItem(Item item)
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
