using System;
using System.IO;
using System.Threading.Tasks;
using dentApp2.Models;
using SQLite;

namespace dentApp2.Services
{
    public class SQLiteDataStorage
    {
        const string DataBaseName = "dbdapp1tab";
        string DataBasePath = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData), DataBaseName);

        SQLiteAsyncConnection Connection;

        public SQLiteDataStorage()
        {
            Connection = new SQLiteAsyncConnection(DataBasePath);
            Connection.CreateTableAsync<Item>();
        }

        public Task<Item[]> GetItemsAsync(Item.status status)
        {
            var items = from item in Connection.Table<Item>()
                        where item.Status == status
                        select item;
            return items.ToArrayAsync();
        }

        public async Task AddItemAsync(Item item)
        {
            await Connection.InsertAsync(item);
        }

        public async Task DelItemAsync(Item item)
        {
            await Connection.DeleteAsync(item);
        }
    }
}
