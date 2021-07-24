using Bakery.Core.Data;
using Bakery.Core.Model.Enumerations;
using System;

namespace Bakery.Core.Model.Bun
{
    public abstract class BunBase
    {
        protected DateTime _nextPriceChangeTime;

        public int Id { get; set; }

        public BunType BunType { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal CurrentPrice => CalculateCurrentPrice();

        public DateTime SellUntil { get; set; }

        public DateTime TargetSaleTime { get; set; }

        public DateTime BakeTime { get; set; }

        public DateTime NextPriceChangeTime => GetPriceChangeTime();

        public decimal NextPrice => CalculateNextPrice();

        public BunBase()
        {
        }

        public BunBase(DateTime bakeTime, DateTime sellUntil, DateTime targetSaleTime, decimal price)
        {
            BakeTime = bakeTime;
            SellUntil = sellUntil;
            TargetSaleTime = targetSaleTime;
            OriginalPrice = price;
        }

        public virtual decimal CalculateNextPrice()
        {
            if (NextPriceChangeTime == SellUntil)
            {
                return 0;
            }

            return CurrentPrice - OriginalPrice * (Constants.ReductionPercentage / 100m);
        }

        protected virtual decimal CalculateCurrentPrice()
        {
            if (NextPriceChangeTime == SellUntil)
            {
                return 0;
            }

            return DateTime.Now >= TargetSaleTime
                ? OriginalPrice - (DateTime.Now - TargetSaleTime).Hours * OriginalPrice * (Constants.ReductionPercentage / 100m)
                : OriginalPrice;
        }

        protected virtual DateTime GetPriceChangeTime()
        {
            if (DateTime.Now < TargetSaleTime) // Before target sale time
            {
                _nextPriceChangeTime = TargetSaleTime;
            }
            else if (DateTime.Now < TargetSaleTime && _nextPriceChangeTime == DateTime.MinValue)
            {
                _nextPriceChangeTime = TargetSaleTime.AddHours(1);
            }
            else if (DateTime.Now > TargetSaleTime && DateTime.Now < _nextPriceChangeTime) // After target sale time but befor change
            {
                return _nextPriceChangeTime;
            }
            else if (DateTime.Now >= _nextPriceChangeTime) // After change
            {
                _nextPriceChangeTime = _nextPriceChangeTime.AddHours(1);
            }
            else if (_nextPriceChangeTime >= SellUntil)
            {
                _nextPriceChangeTime = SellUntil;
            }

            return _nextPriceChangeTime;
        }
    }
}
