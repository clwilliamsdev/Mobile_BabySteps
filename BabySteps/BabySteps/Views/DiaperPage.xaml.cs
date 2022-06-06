using BabySteps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BabySteps.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiaperPage : ContentPage
    {
        public DiaperPage()
        {
            InitializeComponent();
        }

        //Program exit
        private void Exit_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        // Load data from database when page opens
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            diaperView.ItemsSource = await App.Database.GetDiaperAsync();
        }

        //Create empty string for radio button selection
        public string dpContent = "";        

        // Create empty string for date
        public string dpDate = "";

        //Create empty variable for date
        public DateTime date;

        async void DiaperSaveButton_Clicked(object sender, EventArgs e)
        {
            //Checks state of button
            if (PeeButton.IsChecked)
            {
                // Enter Data into empty string
                dpContent = "Pee";
                // Get current date and time
                DateTime date = DateTime.Now;

                await App.Database.SaveDiaperAsync(new DiaperModel
                {
                    // Saves data to the table converting to the correct format
                    Type = dpContent,
                    ChangeTime = String.Format("{0:t}", date),
                    ChangeDate = String.Format("{0:d}", date),

                });

                //Resets state of radio button
                PeeButton.IsChecked = false;                
            }
            //Checks state of button
            else if (PooButton.IsChecked)
            {
                // Enter Data into empty string
                dpContent = "Poo";
                // Get current date and time
                DateTime date = DateTime.Now;

                await App.Database.SaveDiaperAsync(new DiaperModel
                {
                    // Saves data to the table converting to the correct format
                    Type = dpContent,
                    ChangeTime = String.Format("{0:t}", date),
                    ChangeDate = String.Format("{0:d}", date),
                });

                //Resets state of radio button                
                PooButton.IsChecked = false;                
            }
            //Checks state of button
            else if (BothButton.IsChecked)
            {
                // Enter Data into empty string
                dpContent = "Both";
                // Get current date and time
                DateTime date = DateTime.Now;

                await App.Database.SaveDiaperAsync(new DiaperModel
                {
                    // Saves data to the table converting to the correct format
                    Type = dpContent,
                    ChangeTime = String.Format("{0:t}", date),
                    ChangeDate = String.Format("{0:d}", date),
                });

                //Resets state of radio button                 
                BothButton.IsChecked = false;
            }

            //Reloads new state of database
            diaperView.ItemsSource = await App.Database.GetDiaperAsync();
        }

    }
    
    
}