using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dentApp2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
    {
        public Item Item { get; set; }

        public ItemDetailPage(Item Item)
        {
            InitializeComponent();

            Title = Item.Date;
            this.Item = Item;
            BindingContext = this;
		}
	}
}