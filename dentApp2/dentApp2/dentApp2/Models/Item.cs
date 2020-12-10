using System;
using SQLite;

namespace dentApp2.Models
{
    [Table("Items")]
    public class Item
    {
        public enum status
        {
            Appointment,
            Documentation
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string DentistName { get; set; }
        public string TreatmentType { get; set; }
        public string Description { get; set; }
        public string DateTimeString { get { return DateTime.ToString("dd'.'MM'.'yyyy - HH:mm"); } }
        public status Status { get; set; }

        public Item()
        {

        }

        public Item(Item existing_item)
        {
            DateTime = existing_item.DateTime;
            DentistName = existing_item.DentistName;
            TreatmentType = existing_item.TreatmentType;
            Description = existing_item.Description;
            Status = existing_item.Status;
        }
    }

}
