using BabySteps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BabySteps.Services;
using System.Diagnostics;

namespace BabySteps.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetPage : ContentPage
    {
        public ResetPage()
        {
            InitializeComponent();
        }

        private async void ResetButton_Clicked(object sender, EventArgs e)
        {
            //When button is pressed message verifies deletion button press before completing action
            bool answer = await DisplayAlert("Question?", "This will delete all data in the database", "Delete", "Cancel");
            Debug.WriteLine("Answer: " + answer);
            
            if (answer == true)
            {
                //Clears data from all database tables
                await App.Database.DeleteBabyTableItems<BabyModel>();

                await App.Database.DeleteFeedingTableItems<FeedingModel>();

                await App.Database.DeleteDiaperTableItems<DiaperModel>();

                await App.Database.DeleteSleepTableItems<SleepModel>();

            }
        }

        //Program exit
        private void Exit_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}