using System;

namespace Bakery.Core.Model
{
    public abstract class BunBase
    {
        private decimal _price;

        public decimal Price 
        { 
            get
            {
                int hoursElapsed = (DateTime.Now - SellUntil).Hours;

                return _price - hoursElapsed * _price * (Constants.ReductionPercentage / 100);
            }
            set
            {
                _price = value <= Constants.MaxPrice ? value : Constants.MaxPrice;
            }
        }

        public DateTime SellUntil { get; set; }

        public DateTime TargetSaleTime { get; set; }

        public DateTime BakeTime { get; set; }
    }
}
