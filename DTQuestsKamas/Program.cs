using DTQuestsKamas.Helper;
using DTQuestsKamas.Helper.Templates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DTQuestsKamas
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        redo: Console.WriteLine("Character lvl ?");
            short PlayerLevel = short.Parse(Console.ReadLine());
            if (PlayerLevel < 0 || PlayerLevel > 200)
                goto redo;
            List<QuestInfos> Final = new List<QuestInfos>();
            Dictionary<string, Quest> Quests = JsonConvert.DeserializeObject<Dictionary<string, Quest>>(File.ReadAllText("Quests.json"));
            Dictionary<string, QuestSteps> QuestSteps = JsonConvert.DeserializeObject<Dictionary<string, QuestSteps>>(File.ReadAllText("QuestSteps.json"));
            Dictionary<string, CharacterExp> CharacterExp = JsonConvert.DeserializeObject<Dictionary<string, CharacterExp>>(File.ReadAllText("CharactersExp.json"));
            var PlayerXPInfos = CharacterExp[PlayerLevel.ToString()];
            foreach (var quest in Quests.Values.Where(x=>x.LevelMin <= PlayerLevel))
            {
                var steps = QuestSteps.Values.Where(x => quest.StepIds.Contains(x.Id));
                if (!steps.Any())
                {
                    Final.Add(new QuestInfos(quest.Id, quest.NameId, 0, 0, quest.IsRepeatable, quest.LevelMin, quest.LevelMax));
                    continue;
                }
                double QuestXP = 0;
                long QuestKamas = 0;

                foreach (var step in steps)
                {
                    QuestXP += Maths.StepXp(step.OptimalLevel, (double)step.Duration, (double)step.XpRatio, PlayerXPInfos.require / PlayerXPInfos.total, PlayerLevel);
                    QuestKamas += (long)Maths.MathsKamas(step.KamasScaleWithPlayerLevel, step.KamasRatio, step.Duration, step.OptimalLevel, PlayerLevel);
                }
                Final.Add(new QuestInfos(quest.Id, quest.NameId, QuestKamas, (long)QuestXP, quest.IsRepeatable, quest.LevelMin, quest.LevelMax, steps.Select(x => new StepInfos(x.Id, x.NameId, x.DescriptionId)).ToList()));
            }
            Final = Final.OrderByDescending(x => x.Kamas).ToList();
            if (!Directory.Exists("./output"))
                Directory.CreateDirectory("./output");

            File.WriteAllText($"./output/output_level_{PlayerLevel}.json", JsonConvert.SerializeObject(Final, Formatting.Indented));

        }
    }
}