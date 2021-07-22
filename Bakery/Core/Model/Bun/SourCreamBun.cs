using Bakery.Core.Data;
using System;

namespace Bakery.Core.Model.Bun
{
    public class SourCreamBun : Bun
    {
        public SourCreamBun(DateTime bakeTime, DateTime sellUntil, DateTime targetSaleTime, decimal price)
            : base(bakeTime, sellUntil, targetSaleTime, price)
        {
            BunType = Enumerations.BunType.SourCream;
        }

        protected new decimal CalculateCurrentPrice()
        {
            int hoursElapsed = (DateTime.Now - SellUntil).Hours;

            return OriginalPrice - hoursElapsed * OriginalPrice * (Constants.ReductionPercentage / 100) * 2;
        }
    }
}
