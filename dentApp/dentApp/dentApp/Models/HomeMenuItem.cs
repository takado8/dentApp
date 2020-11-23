using System;
using System.Collections.Generic;
using System.Text;

namespace dentApp.Models
{
    public enum MenuItemType
    {
        Appointments,
        Menu
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
