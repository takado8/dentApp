using dentApp2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dentApp2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompendiumPage : ContentPage
	{
        CompendiumViewModel CompendiumViewModel;

		public CompendiumPage ()
		{
			InitializeComponent ();
            BindingContext = CompendiumViewModel = new CompendiumViewModel();
		}
	}
}