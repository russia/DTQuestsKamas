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
        public int QuestId { get; set; }
        public string NameId { get; set; }
        public string DescriptionId { get; set; }
        public int DialogId { get; set; }
        public int OptimalLevel { get; set; }
        public decimal Duration { get; set; }
        public bool KamasScaleWithPlayerLevel { get; set; }
        public decimal KamasRatio { get; set; }
        public decimal XpRatio { get; set; }
        public string[] ObjectiveIds { get; set; }
        public string[] RewardsIds { get; set; }
    }
}
