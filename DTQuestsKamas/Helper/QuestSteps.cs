using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTQuestsKamas.Helper
{
    public class QuestSteps
    {
        public int Id { get; set; }
        public string NameId { get; set; }
        public string DescriptionId { get; set; }
        public int DialogId { get; set; }
        public int OptimalLevel { get; set; }
        public int Duration { get; set; }
        public bool KamasScaleWithPlayerLevel { get; set; }
        public decimal KamasRatio { get; set; }
        public decimal XpRatio { get; set; }
        public List<int> ObjectiveIds { get; set; }
        public List<int> RewardsIds { get; set; }

        public QuestSteps(int id, string nameid, string descriptionId, int dialogId, int optimalLevel, int duration, bool kamasscale, decimal kamasRatio, List<int> objectiveIds, List<int> rewardsIds)
        {
            Id = id;
            NameId = nameid;
            DescriptionId = descriptionId;
            DialogId = dialogId;
            OptimalLevel = optimalLevel;
            Duration = duration;
            KamasScaleWithPlayerLevel = kamasscale;
            KamasRatio = kamasRatio;
            ObjectiveIds = objectiveIds;
            RewardsIds = rewardsIds;
        }
    }
}
