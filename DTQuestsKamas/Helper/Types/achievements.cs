using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTQuestsKamas.Helper.Types
{
    public class achievements
    {
        public int id { get; set; }
        public string nameId { get; set; }
        public int categoryId { get; set; }
        public string descriptionId { get; set; }
        public int iconId { get; set; }
        public int points { get; set; }
        public int level { get; set; }
        public int order { get; set; }
        public List<int> objectiveIds { get; set; }
        public List<int> rewardIds { get; set; }
    }
}
