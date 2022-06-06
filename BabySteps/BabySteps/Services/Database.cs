using System;
using BabySteps.Models;
using SQLite;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.Services
{
    public class Database
    {
        public readonly SQLiteAsyncConnection db;

        public Database(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);

            //Creating Tables in Database
            db.CreateTableAsync<SleepModel>().Wait();

            db.CreateTableAsync<DiaperModel>().Wait();

            db.CreateTableAsync<BabyModel>().Wait();

            db.CreateTableAsync<FeedingModel>().Wait();

            
        }
        //-------------------------------------------------------------------//
        // Database Query, Save, Update, and Delete Controls For Baby Table

        public Task<List<BabyModel>> GetBabyAsync()
        {
            //Runs query for all data in BabyModel table in descending order
            return db.QueryAsync<BabyModel>("SELECT * from BabyModel ORDER BY Id DESC");
        }

        public Task<List<BabyModel>> GetBabyList()
        {
            //Runs query for last entered data in BabyModel table
            return db.QueryAsync<BabyModel>("SELECT * from BabyModel ORDER BY Id DESC LIMIT 1");
        }

        // Save or Update data into the BabyModel Table
        public Task<int> SaveBabyAsync(BabyModel baby)
        {
            if (baby.Id != 0)
            {
                return db.UpdateAsync(baby);
            }
            else
            {
                return db.InsertAsync(baby);
            }            
        }

        //Deletes entry from BabyModel Table
        public Task<int> DeleteItemAsync(BabyModel baby)
        {
            return db.DeleteAsync(baby);
        }

        //Clears ALL data from the BabyModel Table
        public Task<int> DeleteBabyTableItems<t>()
        {
            return db.DeleteAllAsync<BabyModel>();
        }

        //-------------------------------------------------------------------//
        // Database Query, Save, Update, and Delete Controls For FeedingModel
        public Task<List<FeedingModel>> GetFeedingAsync()
        {
            //Runs query for all data in FeedingModel table in descending order
            return db.QueryAsync<FeedingModel>("SELECT * from FeedingModel ORDER BY Id DESC");
        }

        public Task<List<FeedingModel>> GetFeedingList()
        {
            //Runs query for last entered data in FeedingModel table
            return db.QueryAsync<FeedingModel>("SELECT * from FeedingModel ORDER BY Id DESC LIMIT 1");
        }

        // Save or Update data into the FeedingModel Table
        public Task<int> SaveFeedingAsync(FeedingModel feeding)
        {
            if (feeding.Id != 0)
            {
                return db.UpdateAsync(feeding);
            }
            else
            {
                return db.InsertAsync(feeding);
            }
        }

        //Deletes entry from FeedingModel Table
        public Task<int> DeleteItemAsync(FeedingModel feeding)
        {
            return db.DeleteAsync(feeding);
        }

        //Clears ALL data from the DiaperModel Table
        public Task<int> DeleteFeedingTableItems<t>()
        {
            return db.DeleteAllAsync<FeedingModel>();
        }

        //-------------------------------------------------------------------//
        // Database Query, Save, Update, and Delete Controls For Sleep Table

        public Task<List<SleepModel>> GetSleepAsync()
        {
            //Runs query for all data in SleepModel table in descending order
            return db.QueryAsync<SleepModel>("SELECT * from SleepModel ORDER BY Id DESC");
        }

        public Task<List<SleepModel>> GetSleepList()
        {
            //Runs query for last entered data in SleepModel table
            return db.QueryAsync<SleepModel>("SELECT * from SleepModel ORDER BY Id DESC LIMIT 1");
        }

        // Save or Update date into the SleepModel Table
        public Task<int> SaveSleepAsync(SleepModel sleep)
        {
            if (sleep.Id != 0)
            {
                return db.UpdateAsync(sleep);
            }
            else
            {
                return db.InsertAsync(sleep);
            }
        }

        //Deletes entry from SleepModel Table
        public Task<int> DeleteItemAsync(SleepModel sleep)
        {
            return db.DeleteAsync(sleep);
        }

        //Clears ALL data from the SleepModel Table
        public Task<int> DeleteSleepTableItems<t>()
        {
            return db.DeleteAllAsync<SleepModel>();
        }

        //-------------------------------------------------------------------//
        // Database Query, Save, Update, and Delete Controls For Diaper Table

        public Task<List<DiaperModel>> GetDiaperAsync()
        {
            //Runs query for all data in DiaperModel table in descending order
            return db.QueryAsync<DiaperModel>("SELECT * from DiaperModel ORDER BY Id DESC");
        }

        public Task<List<DiaperModel>> GetDiaperList()
        {
            //Runs query for last entered data in SleepModel table
            return db.QueryAsync<DiaperModel>("SELECT * from DiaperModel ORDER BY Id DESC LIMIT 1");
        }

        // Save or Update data into the DiaperModel Table
        public Task<int> SaveDiaperAsync(DiaperModel diaper)
        {
            if (diaper.Id != 0)
            {
                return db.UpdateAsync(diaper);
            }
            else
            {
                return db.InsertAsync(diaper);
            }
        }

        //Deletes entry from DiaperModel Table
        public Task<int> DeleteItemAsync(DiaperModel diaper)
        {
            return db.DeleteAsync(diaper);
        }

        //Clears ALL data from the DiaperModel Table
        public Task<int> DeleteDiaperTableItems<t>()
        {
            return db.DeleteAllAsync<DiaperModel>();
        }
    }
}
