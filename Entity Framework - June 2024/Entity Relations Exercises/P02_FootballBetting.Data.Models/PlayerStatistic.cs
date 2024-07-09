using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        // Here we have Composite PK --> We will use FluentAPI to config it
        public int GameId { get; set; }
        public int PlayerId { get; set; }

        //Warning: Judge may not like ''byte'' data type
        public byte ScoredGoals { get; set; }
        public byte Assists { get; set; }
        public byte MinutesPlayed { get; set; }

    }
}
