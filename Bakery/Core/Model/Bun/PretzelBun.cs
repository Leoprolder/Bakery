using Bakery.Core.Model.Enumerations;
using System;

namespace Bakery.Core.Model.Bun
{
    public class PretzelBun : Bun
    {
        public PretzelBun(Bun bun)
            : this(bun.BakeTime, bun.SellUntil, bun.TargetSaleTime, bun.OriginalPrice)
        {
        }

        public PretzelBun(DateTime bakeTime, DateTime sellUntil, DateTime targetSaleTime, decimal price)
            : base(bakeTime, sellUntil, targetSaleTime, price)
        {
            BunType = BunType.Pretzel;
        }

        public override decimal CalculateNextPrice()
        {
            if (NextPriceChangeTime == SellUntil)
            {
                return 0;
            }
            if (DateTime.Now >= TargetSaleTime)
            {
                return CurrentPrice;
            }
            else
            {
                return OriginalPrice / 2;
            }
        }

        protected override decimal CalculateCurrentPrice()
        {
            if (NextPriceChangeTime == SellUntil)
            {
                return 0;
            }
            if (DateTime.Now >= TargetSaleTime)
            {
                return OriginalPrice / 2m;
            }

            return OriginalPrice;
        }

        protected override DateTime GetPriceChangeTime()
        {
            if (DateTime.Now < TargetSaleTime)
            {
                return TargetSaleTime;
            }
            else
            {
                return SellUntil;
            }
        }
    }
}
