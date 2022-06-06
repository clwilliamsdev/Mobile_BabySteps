using BabySteps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BabySteps.Services;


namespace BabySteps.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SleepPage : ContentPage
    {
        public SleepPage()
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
            sleepView.ItemsSource = await App.Database.GetSleepAsync();
        }

        // Setting up needed variables
        public DateTime Sleep1 = DateTime.MinValue;
        public DateTime Sleep2 = DateTime.MinValue;
        public String SleepD;
        public bool button1WasClicked = false;
        public bool button2WasClicked = false;
        public string Ssl = string.Empty;

        public void SleepStart_Click(object sender, EventArgs e)
        {
            //Sets start date and time on button push and loads it in view window            
            Sleep1 = DateTime.Now;
            SleepStartLabelD.Text = String.Format("{0:d}", Sleep1);
            SleepStartLabelT.Text = String.Format("{0:t}", Sleep1);
            //Sets button1 state to clicked
            button1WasClicked = true;
        }

        public void SleepStop_Click(object sender, EventArgs e)
        {

            //Verifies that start button has been clicked
            if (button1WasClicked == true)
            {
                //Sets stop date and time on button push and loads it in view window
                Sleep2 = DateTime.Now;                
                SleepStopLabelT.Text = String.Format("{0:t}", Sleep2);
                //Takes start time and subtracts it from end time to get duration
                TimeSpan Sd = Sleep2.Subtract(Sleep1);
                SleepD = Sd.ToString(@"hh\:mm");                               
                SleepDurationLabel.Text = SleepD;
                //Resets button1 state and sets button2
                button1WasClicked = false;
                button2WasClicked = true;
                //If the end date is the same as the start, do not display end date
                if(String.Format("{0:d}", Sleep1) != String.Format("{0:d}", Sleep2))
                {
                    SleepStopLabelD.Text = String.Format("{0:d}", Sleep2);
                    Ssl = String.Format("{0:d}", Sleep2);
                }
            }
        }

        public async void SleepSaveButton_Clicked(object sender, EventArgs e)
        {
            // SleepStartLabelT is required to save data
            if (!string.IsNullOrWhiteSpace(SleepStartLabelT.Text))
            {               

                await App.Database.SaveSleepAsync(new SleepModel
                {
                    // Saves data to the table converting to the correct format
                    SleepDuration = SleepD,
                    SleepBeginTime = String.Format("{0:t}", Sleep1),
                    SleepBeginDate = String.Format("{0:d}", Sleep1),
                    SleepEndTime = String.Format("{0:t}", Sleep2),
                    SleepEndDate = Ssl,

                });

                //Sets labels back to empty
                SleepStartLabelT.Text = string.Empty;
                SleepStopLabelT.Text = string.Empty;
                SleepStartLabelD.Text = string.Empty;
                SleepStopLabelD.Text = string.Empty;
                SleepDurationLabel.Text = string.Empty;

                //Reloads new state of database
                sleepView.ItemsSource = await App.Database.GetSleepAsync();
            }
        }
    }
}