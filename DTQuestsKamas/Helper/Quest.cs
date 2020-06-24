using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTQuestsKamas.Helper
{
    public class Quest
    {
        public int Id { get; set; }
        public string NameId { get; set; }
        public int CategoryId { get; set; }
        public bool IsRepeatable { get; set; }
        public int RepeatType { get; set; }
        public int RepeatLimit { get; set; }
        public bool IsDungeonQuest { get; set; }
        public int LevelMin { get; set; }
        public int LevelMax { get; set; }
        public string[] StepIds { get; set; }

        public decimal TotalKamas;
        public int TotalXp = 0;
    }
}
