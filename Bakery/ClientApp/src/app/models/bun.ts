export class Bun {
    public id: number;

    constructor(
        public originalPrice: number,
        public currentPrice: number,
        public sellUntil: Date,
        public targetSaleTime: Date,
        public bakeTime: Date)
    {
    }
}