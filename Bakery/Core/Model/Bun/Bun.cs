using System;

namespace Bakery.Core.Model.Bun
{
    public class Bun : BunBase
    {
        public Bun()
        {
        }

        public Bun(Bun bun)
            : this(bun.BakeTime, bun.SellUntil, bun.TargetSaleTime, bun.OriginalPrice)
        {
        }

        public Bun(DateTime bakeTime, DateTime sellUntil, DateTime targetSaleTime, decimal price)
            : base(bakeTime, sellUntil, targetSaleTime, price)
        {
        }
    }
}
