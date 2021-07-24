import { Component, OnInit, Output, EventEmitter } from '@angular/core'
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { Bun } from '../models/bun';
import { BunType } from '../models/bun-type';
import { BunService } from '../services/bun.service';
import { CustomValidators } from '../validators/custom-validators';

@Component({
    selector: 'bun-form',
    templateUrl: './bun-form.component.html',
    providers: [BunService, CustomValidators]
})

export class BunFormComponent implements OnInit {
    @Output() public onSubmit = new EventEmitter();
    public bunForm: FormGroup;
    public bunTypes: string[] = [];
    public defaultSellUntil: string = JSON.stringify(new Date(new Date().getTime() + 4 * 3600000)).replace('\"', '');
    public defaultTargetSellTime: string = JSON.stringify(new Date(new Date().getTime() + 2 * 3600000)).replace('\"', '');
    private _bunService: BunService;
    private _customValidators: CustomValidators;

    constructor(bunService: BunService, customValidators: CustomValidators)
    {
        this._bunService = bunService;
        this._customValidators = customValidators;
    }

    public ngOnInit() {
        this.bunTypes = this.GetBunTypes();

        this.bunForm = new FormGroup({
            "bunType": new FormControl("", Validators.required),
            "originalPrice": new FormControl("", [Validators.required, this._customValidators.PriceValidator]),
            "sellUntil": new FormControl("", [Validators.required, this._customValidators.DateValidator]),
            "targetSaleTime": new FormControl("", [Validators.required, this._customValidators.DateValidator])
        });
    }

    public Submit()
    {
        let bunTypes = this.GetBunTypes(false);
        let bun: Bun = new Bun(
            0,
            Number(bunTypes.indexOf(this.bunForm.controls["bunType"].value)),
            Number(this.bunForm.controls["originalPrice"].value),
            Number(this.bunForm.controls["originalPrice"].value),
            new Date(this.bunForm.controls["sellUntil"].value),
            new Date(this.bunForm.controls["targetSaleTime"].value),
            new Date(),
            new Date(this.bunForm.controls["targetSaleTime"].value),
            0);

        this._bunService.Create(bun).subscribe(
            (data: any) => this.onSubmit.emit(),
                error => console.error(error)
        );
    }

    private GetBunTypes(skipUnknown: boolean = true): string[]
    {
        let bunTypes: string[] = [];
        let enumLength = Object.keys(BunType).length / 2;
        
        for(let i = 0; i < enumLength; i++) {
            if (BunType.Unknown != i || !skipUnknown) {
                bunTypes.push(BunType[i]);
            }
        }

        return bunTypes;
    }
}