using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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