using dentApp2.Models;
using dentApp2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace dentApp2.ViewModels
{
    public class AppointmentsViewModel : ItemsBaseViewModel
    {
        public AppointmentsViewModel()
        {
            MessagingCenter.Subscribe<NewItemViewModel, Item>(this, "AddAppointmentItem", (obj, item) =>
            {
                var newItem = item as Item;
                InsertItem(newItem);
            });

            MessagingCenter.Subscribe<NewItemViewModel, Item>(this, "DelAppointmentItem", (obj, item) =>
            {
                var oldItem = item as Item;
                Items.Remove(oldItem);
            });

            MessagingCenter.Subscribe<AppointmentItemDetailPage, Item>(this, "DelAppointmentItem", (obj, item) =>
            {
                var oldItem = item as Item;
                Items.Remove(oldItem);
            });

            var itm1 = new Item()
            {
                DateTime = new DateTime(2020, 12, 22, 15, 30, 0),
                Description = "Dodatkowy opis.",
                DentistName = "Aleksandra Kasprzak",
                TreatmentType = "Ekstrakcja",
                Status = Item.status.Appointment
            };
            var itm2 = new Item()
            {
                DateTime = new DateTime(2020, 12, 18, 17, 45, 0),
                TreatmentType = "Wypełnienie",
                DentistName = "Aleksandra Kasprzak",
                Description = "Dodatkowy opis.",
                Status = Item.status.Appointment
            };
            var itm3 = new Item()
            {
                DateTime = new DateTime(2020, 12, 14, 13, 30, 0),
                TreatmentType = "Wypełnienie",
                DentistName = "Aleksandra Kasprzak",
                Description = "Dodatkowy opis.",
                Status = Item.status.Appointment
            };

            InsertItem(itm1);
            InsertItem(itm2);
            InsertItem(itm3);
        }

       
    }
}
