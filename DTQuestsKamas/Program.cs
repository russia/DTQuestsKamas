using DTQuestsKamas.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace DTQuestsKamas
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            JObject Quest = JObject.Parse(File.ReadAllText("Quests.json"));
            JObject QuestSteps = JObject.Parse(File.ReadAllText("QuestSteps.json"));
            JObject CharacterExp = JObject.Parse(File.ReadAllText("CharactersExp.json"));
            foreach (var ID in Quest)
            {
                var QuestsD = JsonConvert.DeserializeObject<Quest>(ID.Value.ToString());
                if (Constants.PlayerLvl > QuestsD.LevelMin)
                {
                    foreach (var ID2 in QuestSteps)
                    {
                        var QuestStepsD = JsonConvert.DeserializeObject<QuestSteps>(ID2.Value.ToString());
                        if (QuestStepsD.QuestId == QuestsD.Id)//alors on a ici une steps de la quete
                        {
                            Console.WriteLine(QuestsD.Id + " have a Step : " + QuestStepsD.QuestId);
                            Maths Math = new Maths();
                            var stepkamas = Math.MathsKamas(QuestStepsD.KamasScaleWithPlayerLevel, QuestStepsD.KamasRatio, QuestStepsD.Duration, QuestStepsD.OptimalLevel);
                            Constants.TotalKamas += Convert.ToUInt64(stepkamas);
                            Console.WriteLine("Kamas gagnés : " + stepkamas);
                            foreach (var id in CharacterExp)
                            {
                                if (id.Key.ToString() == Constants.PlayerLvl.ToString())
                                {
                                    var ExpList = JsonConvert.DeserializeObject<CharacterExp>(id.Value.ToString());
                                    Maths MathXp = new Maths();
                                    var stepxp = MathXp.StepXp(QuestStepsD.OptimalLevel, Convert.ToDouble(QuestStepsD.Duration), Convert.ToDouble(QuestStepsD.XpRatio)) - 22;
                                    if(stepxp > 0) { 
                                        var requireafterstep = ExpList.require - stepxp;
                                        Console.WriteLine("Level " + id.Key.ToString() + " require " + ExpList.require + " / " + ExpList.total + " this quest would gave " + stepxp + " that's : " + requireafterstep + "xp left..");
                                    }

                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Kamas gagnés TOTAL : " + Constants.TotalKamas);
        }
    }
}