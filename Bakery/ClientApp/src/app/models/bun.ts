import { BunType } from "./bun-type";

export class Bun {
    public id: number;

    constructor(
        public bunType: BunType|number,
        public originalPrice: number,
        public currentPrice: number,
        public sellUntil: Date,
        public targetSaleTime: Date,
        public bakeTime: Date)
    {
    }
}