using Bakery.Core.Data;
using System;

namespace Bakery.Core.Model.Bun
{
    public abstract class BunBase
    {
        public decimal OriginalPrice { get; set; }

        public decimal CurrentPrice => CalculateCurrentPrice();

        public DateTime SellUntil { get; set; }

        public DateTime TargetSaleTime { get; set; }

        public DateTime BakeTime { get; set; }

        public BunBase(DateTime bakeTime, DateTime sellUntil, DateTime targetSaleTime, decimal price)
        {
            BakeTime = bakeTime;
            SellUntil = sellUntil;
            TargetSaleTime = targetSaleTime;
            OriginalPrice = price;
        }

        protected decimal CalculateCurrentPrice()
        {
            int hoursElapsed = (DateTime.Now - SellUntil).Hours;

            return OriginalPrice - hoursElapsed * OriginalPrice * (Constants.ReductionPercentage / 100);
        }
    }
}
