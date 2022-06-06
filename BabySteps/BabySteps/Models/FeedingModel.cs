using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabySteps.Models
{
    public class FeedingModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FeedingType { get; set; }
        public string FeedingOf { get; set; }
        public int FeedingAmount { get; set; }
        public string FeedingBeginDate { get; set; }
        public string FeedingBeginTime { get; set; }
        public string FeedingEndTime { get; set; }
        public string FeedingEndDate { get; set; }
        public string FeedingDuration { get; set; }
    }
}
