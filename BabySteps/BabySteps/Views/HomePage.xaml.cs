using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BabySteps.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        //Loads the most recent entry of all tables data for the collection view
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            sleepView.ItemsSource = await App.Database.GetSleepList();
            feedingView.ItemsSource = await App.Database.GetFeedingList();
            babyView.ItemsSource = await App.Database.GetBabyList();
            diaperView.ItemsSource = await App.Database.GetDiaperList();
        }

        //Program exit
        private void Exit_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

    }
}