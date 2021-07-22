import { Component, OnInit } from  '@angular/Core'
import { BunService } from '../services/bun.service'
import { Bun } from '../models/bun'

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
}