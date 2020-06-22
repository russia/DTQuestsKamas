using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.IO;
using Newtonsoft.Json.Linq;
using DTQuestsKamas.Helper;

namespace DTQuestsKamas
{
    class Program
    {
        static void Main(string[] args)
        {
            JObject Quest = JObject.Parse(File.ReadAllText("Quests.json"));
            JObject QuestSteps = JObject.Parse(File.ReadAllText("QuestSteps.json"));
            foreach (var ID in Quest)
            {
                var QuestsD = JsonConvert.DeserializeObject<Quest>(ID.Value.ToString());
                if (Constants.PlayerLvl > QuestsD.LevelMin)
                {
                    foreach(var ID2 in QuestSteps) {   
                        var QuestStepsD = JsonConvert.DeserializeObject<QuestSteps>(ID2.Value.ToString());
                        if(QuestStepsD.QuestId == QuestsD.Id)//alors on a ici une steps de la quete
                        {
                            Console.WriteLine(QuestsD.Id + " have a Step : " + QuestStepsD.QuestId);
                            Maths Math = new Maths();
                            var stepkamas = Math.MathsKamas(QuestStepsD.KamasScaleWithPlayerLevel, QuestStepsD.KamasRatio, QuestStepsD.Duration, QuestStepsD.OptimalLevel);
                            QuestsD.Total += stepkamas;
                        }
                    }
                    Console.WriteLine(QuestsD.Total);
                }


            }



        }
    }
}
