using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTQuestsKamas.Helper;

namespace DTQuestsKamas.Helper
{
    public class Maths
    {
        public decimal MathsKamas(bool scale, decimal kamasRatio, decimal duration, decimal optimalLevel)
        {
            if(scale)
                return Math.Floor((Convert.ToDecimal(Math.Pow(Convert.ToDouble(Constants.PlayerLvl), 2)) + (20 * Constants.PlayerLvl) - 20) * kamasRatio * duration);
            else
                return Math.Floor((Convert.ToDecimal(Math.Pow(Convert.ToDouble(optimalLevel), 2)) + (20 * optimalLevel) - 20) * kamasRatio * duration);

        }
    }
}
