using System;

namespace DTQuestsKamas.Helper
{
    public class Maths
    {
        public decimal MathsKamas(bool scale, decimal kamasRatio, decimal duration, decimal optimalLevel, double PlayerLevel)
        {
            if (scale)
                return Math.Floor((Convert.ToDecimal(Math.Pow(PlayerLevel, 2)) + (20 * Convert.ToDecimal(PlayerLevel)) - 20) * kamasRatio * duration);
            else
                return Math.Floor((Convert.ToDecimal(Math.Pow(Convert.ToDouble(optimalLevel), 2)) + (20 * optimalLevel) - 20) * kamasRatio * duration);
        }

        public double StepXp(double optimalLevel, double duration, double xpRatio, double value, double PlayerLevel)
        {
            var REWARD_SCALE_CAP = 1.5;
            var REWARD_REDUCED_SCALE = 0.7;
            var playerLevel = PlayerLevel;
            var experienceFactor = value; 

            if (playerLevel > optimalLevel)
            {
                var rewLevel = Math.Floor(Math.Min(playerLevel, (optimalLevel * REWARD_SCALE_CAP)));

                var step1 = (1 - REWARD_REDUCED_SCALE) * GetFixedExperienceReward(optimalLevel, duration, xpRatio);
                var step2 = REWARD_REDUCED_SCALE * GetFixedExperienceReward(rewLevel, duration, xpRatio);
                return Math.Floor((step1 + step2) * experienceFactor);
            }
            return Math.Floor(GetFixedExperienceReward(playerLevel, duration, xpRatio) * experienceFactor);
        }

        public double GetFixedExperienceReward(double playerlvl, double duration, double xpRatio)
        {
            return Math.Floor((playerlvl * Math.Pow(100 + (2 * playerlvl), 2) / 20) * duration * xpRatio);
        }
    }
}