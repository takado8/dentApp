using dentApp2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace dentApp2
{
    public partial class App : Application
    {
        /*  <ResourceDictionary>
            <Color x:Key="Primary">#9CE349</Color>
            <Style TargetType="NavigationPage">
                <Setter Property="BarBackgroundColor" Value="{StaticResource Primary}" />
                <Setter Property="BarTextColor" Value="WhiteSmoke" />
            </Style>
        </ResourceDictionary> // changes navigation bar color in xaml */ 

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
