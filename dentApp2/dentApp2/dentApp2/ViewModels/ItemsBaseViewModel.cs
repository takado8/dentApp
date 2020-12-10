using dentApp2.Models;
using dentApp2.Services;
using System.Collections.ObjectModel;

namespace dentApp2.ViewModels
{
    public class ItemsBaseViewModel
    {
        ObservableCollection<Item> _items;
        static SQLiteDataStorage _SQLiteDataStorage;
       
        public SQLiteDataStorage SQLiteDataStorage
        {
            get
            {
                return _SQLiteDataStorage ?? (_SQLiteDataStorage = new SQLiteDataStorage());
            }
        }

        public ObservableCollection<Item> Items
        {
            get
            {
                return _items ?? (_items = new ObservableCollection<Item>());
            }
        }

        public void InsertItem(Item item)
        {
            int i;
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
