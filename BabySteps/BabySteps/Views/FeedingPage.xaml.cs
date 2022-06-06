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
    public partial class FeedingPage : ContentPage
    {
        public FeedingPage()
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
            feedingView.ItemsSource = await App.Database.GetFeedingAsync();
        }

        // Setting up needed variables
        public DateTime Feeding1 = DateTime.MinValue;
        public DateTime Feeding2 = DateTime.MinValue;
        public string FeedingD;
        public bool button1WasClicked = false;
        public bool button2WasClicked = false;
        public string Sfl = string.Empty;

        public void FeedingStartButton_Click(object sender, EventArgs e)
        {
            //Sets start date and time on button push and loads it in view window            
            Feeding1 = DateTime.Now;
            FeedingStartLabelD.Text = string.Format("{0:d}", Feeding1);
            FeedingStartLabelT.Text = string.Format("{0:t}", Feeding1);
            button1WasClicked = true;
        }

        public void FeedingStopButton_Click(object sender, EventArgs e)
        {
            
            //Verifies that start button has been clicked
            if (button1WasClicked == true)
            {
                //Sets stop date and time on button push and loads it in view window
                Feeding2 = DateTime.Now;
                FeedingStopLabelT.Text = string.Format("{0:t}", Feeding2);
                //Takes start time and subtracts it from end time to get duration
                TimeSpan Fd = Feeding2.Subtract(Feeding1);
                FeedingD = Fd.ToString(@"hh\:mm");
                FeedingDurationLabel.Text = FeedingD;
                //Resets button1 state and sets button2
                button1WasClicked = false;
                button2WasClicked = true;
                //If the end date is the same as the start, do not display end date
                if (string.Format("{0:d}", Feeding1) != string.Format("{0:d}", Feeding2))
                {
                    FeedingStopLabelD.Text = string.Format("{0:d}", Feeding2);
                    Sfl = string.Format("{0:d}", Feeding2);
                }
            }
        }

        public async void FeedingSaveButton_Clicked(object sender, EventArgs e)
        {
            //Setting up the type picker
            string ftp = (string)feedingtypePicker.SelectedItem;

            // FeedingStartLabelT is required to save data
            if (!string.IsNullOrWhiteSpace(FeedingStartLabelT.Text))
            { 
                await App.Database.SaveFeedingAsync(new FeedingModel
                {
                    // Saves data to the table coverting to the correct format
                    FeedingType = ftp,
                    FeedingOf = ofEntry.Text,
                    FeedingAmount = Convert.ToInt32(amountEntry.Text),
                    FeedingDuration = FeedingD,
                    FeedingBeginTime = String.Format("{0:t}", Feeding1),
                    FeedingBeginDate = String.Format("{0:d}", Feeding1),
                    FeedingEndTime = String.Format("{0:t}", Feeding2),
                    FeedingEndDate = Sfl,
                });

                //Sets labels back to empty
                feedingtypePicker.SelectedItem = null;
                amountEntry.Text = string.Empty;
                ofEntry.Text = string.Empty;
                FeedingStartLabelT.Text = string.Empty;
                FeedingStopLabelT.Text = string.Empty;
                FeedingStartLabelD.Text = string.Empty;
                FeedingStopLabelD.Text = string.Empty;
                FeedingDurationLabel.Text = string.Empty;

                //Reloads new state of database
                feedingView.ItemsSource = await App.Database.GetFeedingAsync();
            }
        }
    }
}