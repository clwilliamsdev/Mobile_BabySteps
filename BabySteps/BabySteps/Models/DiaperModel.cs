using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabySteps.Models
{
    public class DiaperModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Type { get; set; }
        public string ChangeTime { get; set; }
        public string ChangeDate { get; set; }
    }
}
