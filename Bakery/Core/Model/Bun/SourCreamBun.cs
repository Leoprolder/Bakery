using Bakery.Core.Model.Enumerations;
using System;

namespace Bakery.Core.Model.Bun
{
    public class SourCreamBun : Bun
    {
        public SourCreamBun(Bun bun)
            : this(bun.BakeTime, bun.SellUntil, bun.TargetSaleTime, bun.OriginalPrice)
        {
        }

        public SourCreamBun(DateTime bakeTime, DateTime sellUntil, DateTime targetSaleTime, decimal price)
            : base(bakeTime, sellUntil, targetSaleTime, price)
        {
            BunType = BunType.SourCream;
        }

        public override decimal CalculateNextPrice()
        {
            if (NextPriceChangeTime == SellUntil)
            {
                return 0;
            }
            return CurrentPrice - OriginalPrice * (Constants.ReductionPercentage / 100m) * 2m;
        }

        protected override decimal CalculateCurrentPrice()
        {
            if (NextPriceChangeTime == SellUntil)
            {
                return 0;
            }
            return DateTime.Now >= TargetSaleTime
                ? OriginalPrice - (DateTime.Now - TargetSaleTime).Hours * OriginalPrice * (Constants.ReductionPercentage / 100m) * 2m
                : OriginalPrice;
        }
    }
}
