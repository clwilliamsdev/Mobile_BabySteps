using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabySteps.Models
{
    public class BabyModel
    {        
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public int Height { get; set; }
        public int WeightLbs { get; set; }
        public int WeightOz { get; set; }
    }
}
