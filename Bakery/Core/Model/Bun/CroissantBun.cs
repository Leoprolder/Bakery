using System;

namespace Bakery.Core.Model.Bun
{
    public class CroissantBun : BunBase
    {
        public CroissantBun(DateTime bakeTime, DateTime sellUntil, DateTime targetSaleTime, decimal price)
            : base(bakeTime, sellUntil, targetSaleTime, price)
        {
        }
    }
}
