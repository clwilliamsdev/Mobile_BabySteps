using BabySteps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BabySteps.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BabyPage : ContentPage
    {
        public BabyPage()
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
            babyView.ItemsSource = await App.Database.GetBabyAsync();
        }

        async void babySaveButton_Clicked(object sender, EventArgs e)
        {
            // firstName is required to save data
            if (!string.IsNullOrWhiteSpace(firstName.Text))
            {
                // Takes user input and converts to correct format
                int weightL = Convert.ToInt32(weightLbs.Text);
                int weightO = Convert.ToInt32(weightOz.Text);
                int heightIn = Convert.ToInt32(height.Text);
                string dOB = String.Format("{0:d}", dob.Date);

                await App.Database.SaveBabyAsync(new BabyModel
                {
                    // Saves data to the table
                    FirstName = firstName.Text,
                    LastName = lastName.Text,
                    DOB = dOB,
                    WeightLbs = weightL,
                    WeightOz = weightO,
                    Height = heightIn
                }) ;

                //Sets labels back to empty
                firstName.Text = string.Empty;
                lastName.Text = string.Empty;                
                weightLbs.Text = string.Empty;
                weightOz.Text = string.Empty;
                height.Text = string.Empty;

                //Reloads new state of database
                babyView.ItemsSource = await App.Database.GetBabyAsync();
            }
        }
    }
}