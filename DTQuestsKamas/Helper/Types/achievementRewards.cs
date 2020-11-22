using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTQuestsKamas.Helper.Types
{
    public class achievementRewards
    {
        public int id { get; set; }
        public int achievementId { get; set; }
        public int levelMin { get; set; }
        public int levelMax { get; set; }
        public List<object> itemsReward { get; set; }
        public List<object> itemsQuantityReward { get; set; }
        public List<object> emotesReward { get; set; }
        public List<object> spellsReward { get; set; }
        public List<object> titlesReward { get; set; }
        public List<object> ornamentsReward { get; set; }
        public double kamasRatio { get; set; }
        public double experienceRatio { get; set; }
        public bool kamasScaleWithPlayerLevel { get; set; }
        public bool isLinkedToAccount { get; set; }
    }
}
