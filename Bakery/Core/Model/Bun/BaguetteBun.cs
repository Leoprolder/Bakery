using System;

namespace Bakery.Core.Model.Bun
{
    public class BaguetteBun : Bun
    {
        public BaguetteBun(Bun bun)
            : this(bun.BakeTime, bun.SellUntil, bun.TargetSaleTime, bun.OriginalPrice)
        {
        }

        public BaguetteBun(DateTime bakeTime, DateTime sellUntil, DateTime targetSaleTime, decimal price)
            : base(bakeTime, sellUntil, targetSaleTime, price)
        {
            BunType = Enumerations.BunType.Baguette;
        }
    }
}
