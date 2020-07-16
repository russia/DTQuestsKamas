using DTQuestsKamas.Helper;
using DTQuestsKamas.Helper.Templates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace DTQuestsKamas
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Character lvl ?");
            Dictionary<double, List<JObject>> Result = new Dictionary<double, List<JObject>>();
            JObject Quests = JObject.Parse(File.ReadAllText("Quests.json"));
            JObject QuestSteps = JObject.Parse(File.ReadAllText("QuestSteps.json"));
            JObject CharacterExp = JObject.Parse(File.ReadAllText("CharactersExp.json"));
            List<int> NeedToSkip = new List<int>();
            
            for (int PlayerLevel = 2; PlayerLevel <= 200; PlayerLevel++)
            {
                List<JObject> Listtest = new List<JObject>();
                //   Listtest.Clear();
                foreach (var Quest in Quests)
                {
                    var QuestDetails = JsonConvert.DeserializeObject<Quest>(Quest.Value.ToString());
                    if (!NeedToSkip.Contains(QuestDetails.Id) && (PlayerLevel >= QuestDetails.LevelMin))
                    {
                        foreach (var QuestStep in QuestSteps)
                        {
                            var QuestStepsDetails = JsonConvert.DeserializeObject<QuestSteps>(QuestStep.Value.ToString());
                            if (QuestStepsDetails.QuestId == QuestDetails.Id)
                            {
                                //Console.WriteLine(QuestDetails.Id + " have a Step : " + QuestStepsDetails.QuestId);
                                Maths Math = new Maths();
                                var stepkamas = Math.MathsKamas(QuestStepsDetails.KamasScaleWithPlayerLevel, QuestStepsDetails.KamasRatio, QuestStepsDetails.Duration, QuestStepsDetails.OptimalLevel, PlayerLevel);
                                Constants.TotalKamas += Convert.ToUInt64(stepkamas);
                                Console.ForegroundColor = ConsoleColor.Green;
                                //Console.WriteLine("Kamas gagnés : " + stepkamas);
                                Console.ForegroundColor = ConsoleColor.White;
                                QuestDetails.TotalKamas = stepkamas;
                                foreach (var id in CharacterExp)
                                {
                                    if (id.Key.ToString() == PlayerLevel.ToString())
                                    {
                                        var ExpList = JsonConvert.DeserializeObject<CharacterExp>(id.Value.ToString());
                                        double antidivdezeroissuelmao = ExpList.require;
                                        var value = antidivdezeroissuelmao / ExpList.total;
                                        var stepxp = Math.StepXp(QuestStepsDetails.OptimalLevel, Convert.ToDouble(QuestStepsDetails.Duration), Convert.ToDouble(QuestStepsDetails.XpRatio), value, PlayerLevel) - 22;
                                        if ((stepkamas > 0 && stepxp > 0) && (PlayerLevel >= QuestDetails.LevelMin))
                                        {
                                            var requireafterstep = ExpList.require - stepxp;
                                            Console.WriteLine("Level " + id.Key.ToString() + " require " + ExpList.require + " / " + ExpList.total + " this quest would gave " + stepxp + " that's : " + requireafterstep + "xp left..");
                                            QuestDetails.TotalXp = int.Parse(stepxp.ToString());
                                            StepsIds infos = new StepsIds(QuestStepsDetails.Id, QuestStepsDetails.NameId, QuestStepsDetails.DescriptionId, int.Parse(stepkamas.ToString()), int.Parse(stepxp.ToString()), QuestDetails.IsRepeatable, QuestDetails.IsDungeonQuest, QuestDetails.LevelMin, QuestDetails.LevelMax);

                                            string jsontest = JsonConvert.SerializeObject(infos);
                                            var test = JObject.Parse(jsontest);
                                            Listtest.Add(test);
                                            Console.WriteLine("Kamas gagnés : " + stepkamas);
                                        }
                                    }
                                }
                                NeedToSkip.Add(QuestDetails.Id);
                            }
                        }
                    }
                }
                Result.Add(PlayerLevel, Listtest);
            }

            string json = JsonConvert.SerializeObject(Result, Formatting.Indented);

            using (StreamWriter sw = File.AppendText("output.json"))
            {
                sw.WriteLine(json);
            }
            Console.WriteLine("Kamas gagnés TOTAL : " + Constants.TotalKamas);
        }
    }
}