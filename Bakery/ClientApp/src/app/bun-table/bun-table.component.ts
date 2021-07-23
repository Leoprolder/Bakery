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

    onChange(buns: any) {
        this._bunService.GetAll().subscribe((data: Bun[]) => this.buns = data);
    }
}