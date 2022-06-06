using BabySteps.Services;
using Xamarin.Forms;
using System.IO;
using System;

namespace BabySteps
{
    public partial class App : Application
    {
        private static Database database;

        public static Database Database
        {
            get
            {
                //IF there is no database, create one
                if(database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "babysteps.db3"));
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
