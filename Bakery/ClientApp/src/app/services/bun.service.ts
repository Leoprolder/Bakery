import { Injectable, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { Bun } from '../models/bun'
import { Observable } from 'rxjs'
import { map } from 'rxjs/operators'

@Injectable()
export class BunService {
    constructor(private _httpClient: HttpClient, @Inject('BASE_URL') private _baseUrl: string)
    {
    }

    public GetAll(): Observable<Bun[]> {
        return this._httpClient.get(this._baseUrl + 'api/bun/getAll').pipe(
            map((data: any) => {
                return data.map(bun => new Bun(
                    bun.bunType,
                    bun.originalPrice,
                    bun.currentPrice,
                    bun.sellUntil,
                    bun.targetSaleTime,
                    bun.bakeTime));
            })
        );
    }

    public Create(bun: Bun) {
        return this._httpClient.post(this._baseUrl + 'api/bun/create', JSON.parse(JSON.stringify(bun)));
    }
}