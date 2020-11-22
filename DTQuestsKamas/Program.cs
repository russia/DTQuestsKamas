using DTQuestsKamas.Helper;
using DTQuestsKamas.Helper.Templates;
using DTQuestsKamas.Helper.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DTQuestsKamas
{
    internal class Program
    {
        public static short PlayerLevel = 0;
        public static Dictionary<string, CharacterExp> CharacterExp = JsonConvert.DeserializeObject<Dictionary<string, CharacterExp>>(File.ReadAllText("./data/CharactersExp.json"));

        private static void Main()
        {
        redo: Console.WriteLine("Character lvl ?");
            PlayerLevel = short.Parse(Console.ReadLine());
            if (PlayerLevel < 0 || PlayerLevel > 200)
                goto redo;
            DoRewards();
            DoQuests();
        }

        public static void DoRewards()
        {
            List<RewardInfos> List = new List<RewardInfos>();
            Dictionary<string, achievementRewards> Rewards = JsonConvert.DeserializeObject<Dictionary<string, achievementRewards>>(File.ReadAllText("./data/AchievementRewards.json"));
            Dictionary<string, achievements> Achievements = JsonConvert.DeserializeObject<Dictionary<string, achievements>>(File.ReadAllText("./data/Achievements.json"));
            var PlayerXPInfos = CharacterExp[PlayerLevel.ToString()];
            foreach (var Reward in Rewards)
            {
                achievementRewards RewardValues = Reward.Value;
                long KamasRewards = 0;
                if (!Achievements.TryGetValue(RewardValues.achievementId.ToString(), out achievements CurrentAchievement))
                    continue; // retard de mes couilles
                KamasRewards += (long)Maths.RewardMathsKamas(RewardValues.kamasScaleWithPlayerLevel, RewardValues.kamasRatio, CurrentAchievement.level, PlayerLevel);
                List.Add(new RewardInfos(CurrentAchievement.nameId, CurrentAchievement.descriptionId, CurrentAchievement.id, KamasRewards, 0, RewardValues.itemsReward, RewardValues.levelMin, RewardValues.levelMax, CurrentAchievement.rewardIds.Count()));
            }
            List = List.OrderByDescending(x => x.Kamas).ToList();
            if (!Directory.Exists("./output"))
                Directory.CreateDirectory("./output");

            File.WriteAllText($"./output/RewardsOutput_level_{PlayerLevel}.json", JsonConvert.SerializeObject(List, Formatting.Indented));
        }

        public static void DoQuests()
        {
            List<QuestInfos> Final = new List<QuestInfos>();
            Dictionary<string, Quest> Quests = JsonConvert.DeserializeObject<Dictionary<string, Quest>>(File.ReadAllText("./data/Quests.json"));
            Dictionary<string, QuestSteps> QuestSteps = JsonConvert.DeserializeObject<Dictionary<string, QuestSteps>>(File.ReadAllText("./data/QuestSteps.json"));
            var PlayerXPInfos = CharacterExp[PlayerLevel.ToString()];
            foreach (var quest in Quests.Values.Where(x => x.LevelMin <= PlayerLevel))
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
                    QuestXP += Maths.QuestStepXp(step.OptimalLevel, (double)step.Duration, (double)step.XpRatio, PlayerXPInfos.require / PlayerXPInfos.total, PlayerLevel);
                    QuestKamas += (long)Maths.QuestMathsKamas(step.KamasScaleWithPlayerLevel, step.KamasRatio, step.Duration, step.OptimalLevel, PlayerLevel);
                }
                Final.Add(new QuestInfos(quest.Id, quest.NameId, QuestKamas, (long)QuestXP, quest.IsRepeatable, quest.LevelMin, quest.LevelMax, steps.Select(x => new StepInfos(x.Id, x.NameId, x.DescriptionId)).ToList()));
            }
            Final = Final.OrderByDescending(x => x.Kamas).ToList();
            if (!Directory.Exists("./output"))
                Directory.CreateDirectory("./output");

            File.WriteAllText($"./output/QuestOutput_level_{PlayerLevel}.json", JsonConvert.SerializeObject(Final, Formatting.Indented));
        }
    }
}