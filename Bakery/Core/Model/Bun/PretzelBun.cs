using Bakery.Core.Model.Enumerations;
using System;

namespace Bakery.Core.Model.Bun
{
    public class PretzelBun : Bun
    {
        public PretzelBun(DateTime bakeTime, DateTime sellUntil, DateTime targetSaleTime, decimal price)
            : base(bakeTime, sellUntil, targetSaleTime, price)
        {
            BunType = BunType.Pretzel;
        }

        protected new decimal CalculateCurrentPrice()
        {
            if (DateTime.Now >= TargetSaleTime)
            {
                return OriginalPrice / 2;
            }

            int hoursElapsed = (DateTime.Now - SellUntil).Hours;

            return OriginalPrice - hoursElapsed * OriginalPrice * (Constants.ReductionPercentage / 100);
        }
    }
}
