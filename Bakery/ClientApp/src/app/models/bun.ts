import { BunType } from "./bun-type";

export class Bun {
    constructor(
        public id: number,
        public bunType: BunType|number,
        public originalPrice: number,
        public currentPrice: number,
        public sellUntil: Date,
        public targetSaleTime: Date,
        public bakeTime: Date,
        public nextPriceChangeTime: Date,
        public nextPrice: number)
    {
    }
}