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
        public List<int> StepIds { get; set; }

        public Quest(int id, string nameid, int category, bool isrepeatble, int repeatlimit, bool isdungeonquest, int levelmin, int levelmax, List<int> stepsids)
        {
            Id = id;
            NameId = nameid;
            CategoryId = category;
            IsRepeatable = isrepeatble;
            RepeatLimit = repeatlimit;
            IsDungeonQuest = isdungeonquest;
            LevelMin = levelmin;
            LevelMax = levelmax;
            StepIds = stepsids;
        }
    }
}
