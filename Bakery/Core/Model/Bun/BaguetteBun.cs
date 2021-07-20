using System;

namespace Bakery.Core.Model.Bun
{
    public class BaguetteBun : BunBase
    {
        public BaguetteBun(DateTime bakeTime, DateTime sellUntil, DateTime targetSaleTime, decimal price)
            : base(bakeTime, sellUntil, targetSaleTime, price)
        {
        }
    }
}
