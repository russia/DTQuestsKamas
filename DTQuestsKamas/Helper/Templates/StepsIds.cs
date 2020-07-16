using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DTQuestsKamas.Helper.Templates
{
    public class StepsIds
    {
        public long Id { get; set; }


        public string NameId { get; set; }
        public bool IsRepeatable { get; set; }
        public bool IsDungeonQuest { get; set; }
        public int LevelMin { get; set; }
        public int LevelMax { get; set; }
        public string DescriptionId { get; set; }
        public int Kamas { get; set; }

        public int Exp { get; set; }
        public StepsIds(long id, string nameId, string descriptionId, int kamas, int exp, bool isRepeatable, bool isDungeonQuest, int levelMin, int levelMax)
        {
            Id = id;
            NameId = nameId;
            DescriptionId = descriptionId;
            IsRepeatable = isRepeatable;
            IsDungeonQuest = isDungeonQuest;
            LevelMin = levelMin;
            LevelMax = levelMax;
            Kamas = kamas;
            Exp = exp;
        }
    }
}