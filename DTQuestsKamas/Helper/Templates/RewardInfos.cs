using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTQuestsKamas.Helper.Templates
{
    public class RewardInfos
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long Id { get; set; }
        public int LevelMin { get; set; }
        public int LevelMax { get; set; }
        public List<object> itemsReward { get; set; }
        public int itemsQuantityReward { get; set; }

        public long Kamas { get; set; }
        public long Exp { get; set; }

        public RewardInfos(string name, string desc, long id, long kamas, long exp, List<object> ItemsReward, int levelMin, int levelMax, int ItemsQuantityReward)
        {
            Name = name;
            Description = desc;
            Id = id;
            itemsReward = ItemsReward;
            itemsQuantityReward = ItemsQuantityReward;
            LevelMax = levelMax;
            LevelMin = levelMin;
            Kamas = kamas;
            Exp = exp;
        }
    }

}
