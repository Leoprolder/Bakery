import { Component, OnInit } from  '@angular/core'
import { BunService } from '../services/bun.service'
import { Bun } from '../models/bun'
import { BunType } from '../models/bun-type'

@Component({
    selector: 'bun-table',
    templateUrl: './bun-table.component.html',
    providers: [BunService]
})

export class BunTableComponent implements OnInit {
    public buns: Bun[] = [];

    constructor(private _bunService: BunService)
    {
    }
    
    ngOnInit() {
        this._bunService.GetAll().subscribe((data: Bun[]) => this.buns = data);
    }

    public MapBunTypeToHumanReadable(bunType: number): string {
        return BunType[bunType];
    }

    public onChange(buns: any) {
        this._bunService.GetAll().subscribe((data: Bun[]) => this.buns = data);
    }

    public GetNextPriceChangeTimeLeft(date: string): string {
        let timeLeftMs = new Date(date).getTime() - new Date().getTime();
        let hours = Math.floor(timeLeftMs / (1000 * 60 * 60));
        timeLeftMs -= hours * (1000 * 60 * 60);

        let mins = Math.floor(timeLeftMs / (1000 * 60));

        let output = hours > 0 
            ? hours + " hours, " + mins + " minutes"
            : mins + " minutes"
        return output;
    }

    public DeleteBun(bun: Bun): void {
        this._bunService.Delete(bun);
    }
}