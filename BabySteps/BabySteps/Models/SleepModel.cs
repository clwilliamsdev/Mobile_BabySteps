using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BabySteps.Models
{
    public class SleepModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SleepBeginDate { get; set; }
        public string SleepBeginTime { get; set; }
        public string SleepEndDate { get; set; }
        public string SleepEndTime { get; set; }
        public string SleepDuration { get; set; }


    }
}
