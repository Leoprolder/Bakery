using System;

namespace Bakery.Core.Model.Bun
{
    public class LoafBun : Bun
    {
        public LoafBun(DateTime bakeTime, DateTime sellUntil, DateTime targetSaleTime, decimal price)
            : base(bakeTime, sellUntil, targetSaleTime, price)
        {
            BunType = Enumerations.BunType.Loaf;
        }
    }
}
