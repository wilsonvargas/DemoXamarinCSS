using DemoAppCSS.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoAppCSS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaingPage : ContentPage
    {
        public MaingPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}
