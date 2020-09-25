using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTQuestsKamas.Helper.Templates
{
    public class QuestInfos
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsRepeatable { get; set; }
        public int LevelMin { get; set; }
        public int LevelMax { get; set; }
        public long Kamas { get; set; }
        public long Exp { get; set; }
        public List<StepInfos> StepInfos { get; set; }

        public QuestInfos(long id, string nameId, long kamas, long exp, bool isRepeatable, int levelMin, int levelMax, List<StepInfos> steps)
        {
            Id = id;
            Name = nameId;
            IsRepeatable = isRepeatable;
            LevelMin = levelMin;
            LevelMax = levelMax;
            Kamas = kamas;
            Exp = exp;
            StepInfos = steps;
        }
        public QuestInfos(long id, string nameId, long kamas, long exp, bool isRepeatable, int levelMin, int levelMax)
        {
            Id = id;
            Name = nameId;
            IsRepeatable = isRepeatable;
            LevelMin = levelMin;
            LevelMax = levelMax;
            Kamas = kamas;
            Exp = exp;
        }
    }
    public class StepInfos
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public StepInfos(long id, string name, string desc)
        {
            Id = id;
            Name = name;
            Description = desc;
        }
    }
}