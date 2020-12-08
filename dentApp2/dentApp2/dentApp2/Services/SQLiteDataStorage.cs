using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using dentApp2.Models;
using SQLite;
using Xamarin;

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

        public async Task<string> AddItemAsync(Item item)
        {
            string result = "";
            try
            {
                await Connection.InsertAsync(item);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }

        public async Task<string> DelItemAsync(Item item)
        {
            string result = "";
            try
            {
                await Connection.DeleteAsync(item);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }
    }
}
