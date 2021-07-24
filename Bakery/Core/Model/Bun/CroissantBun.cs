using System;

namespace Bakery.Core.Model.Bun
{
    public class CroissantBun : Bun
    {
        public CroissantBun(Bun bun)
            : this(bun.BakeTime, bun.SellUntil, bun.TargetSaleTime, bun.OriginalPrice)
        {
        }

        public CroissantBun(DateTime bakeTime, DateTime sellUntil, DateTime targetSaleTime, decimal price)
            : base(bakeTime, sellUntil, targetSaleTime, price)
        {
            BunType = Enumerations.BunType.Croissant;
        }
    }
}
