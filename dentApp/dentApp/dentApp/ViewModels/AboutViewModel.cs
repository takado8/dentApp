using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace dentApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "       Menu";

            
        }

        public ICommand OpenWebCommand { get; }
    }
}