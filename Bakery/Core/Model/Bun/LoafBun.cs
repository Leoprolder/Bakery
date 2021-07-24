using System;

namespace Bakery.Core.Model.Bun
{
    public class LoafBun : Bun
    {
        public LoafBun(Bun bun)
            : this(bun.BakeTime, bun.SellUntil, bun.TargetSaleTime, bun.OriginalPrice)
        {
        }

        public LoafBun(DateTime bakeTime, DateTime sellUntil, DateTime targetSaleTime, decimal price)
            : base(bakeTime, sellUntil, targetSaleTime, price)
        {
            BunType = Enumerations.BunType.Loaf;
        }
    }
}
