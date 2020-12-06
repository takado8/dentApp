using dentApp2.Models;
using dentApp2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace dentApp2.ViewModels
{
    class DocumentationViewModel : ItemsBaseViewModel
    {
        public DocumentationViewModel()
        {
            MessagingCenter.Subscribe<NewItemViewModel, Item>(this, "AddDocumentationItem", (obj, item) =>
            {
                var newItem = item as Item;
                InsertItem(newItem);
            });

            MessagingCenter.Subscribe<AppointmentItemDetailPage, Item>(this, "AddDocumentationItem", (obj, item) =>
            {
                var newItem = item as Item;
                InsertItem(newItem);
            });

            MessagingCenter.Subscribe<NewItemViewModel, Item>(this, "DelDocumentationItem", (obj, item) =>
            {
                var oldItem = item as Item;
                Items.Remove(oldItem);
            });

            MessagingCenter.Subscribe<DocumentationItemDetailPage, Item>(this, "DelDocumentationItem", (obj, item) =>
            {
                var oldItem = item as Item;
                Items.Remove(oldItem);
            });

            var itm1 = new Item()
            {
                DateTime = new DateTime(2020, 4, 22, 15, 30, 0),
                Description = "Dodatkowy opis.",
                DentistName = "Aleksandra Kasprzak",
                TreatmentType = "Ekstrakcja",
                Status = Item.status.Documentation
            };
            var itm2 = new Item()
            {
                DateTime = new DateTime(2020, 4, 18, 17, 45, 0),
                TreatmentType = "Wypełnienie",
                DentistName = "Aleksandra Kasprzak",
                Description = "Dodatkowy opis.",
                Status = Item.status.Documentation
            };
            var itm3 = new Item()
            {
                DateTime = new DateTime(2020, 4, 14, 13, 30, 0),
                TreatmentType = "Wypełnienie",
                DentistName = "Aleksandra Kasprzak",
                Description = "Dodatkowy opis.",
                Status = Item.status.Documentation
            };
            InsertItem(itm1);
            InsertItem(itm2);
            InsertItem(itm3);
        }
    }
}
