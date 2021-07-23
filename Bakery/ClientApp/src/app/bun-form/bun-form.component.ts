import { Component, OnInit } from '@angular/core'
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { Bun } from '../models/bun';
import { BunType } from '../models/bun-type';
import { BunService } from '../services/bun.service';
import { CustomValidators } from '../validators/validators';

@Component({
    selector: 'bun-form',
    templateUrl: './bun-form.component.html',
    providers: [BunService, CustomValidators]
})

export class BunFormComponent implements OnInit {
    public bunForm: FormGroup;
    public bunTypes: string[] = [];
    private _bunService: BunService;
    private _customValidators: CustomValidators;

    constructor(bunService: BunService, customValidators: CustomValidators)
    {
        this._bunService = bunService;
        this._customValidators = customValidators;
    }

    public ngOnInit() {
        let enumLength = Object.keys(BunType).length / 2;
        for(let i = 0; i < enumLength; i++) {
            if (BunType.Unknown != i) {
                this.bunTypes.push(BunType[i]);
            }
        }

        this.bunForm = new FormGroup({
            "bunType": new FormControl("", Validators.required),
            "originalPrice": new FormControl("", [Validators.pattern("[0-9]{1,3}"), this._customValidators.PriceValidator]),
            "sellUntil": new FormControl("", Validators.required),
            "targetSaleTime": new FormControl("", Validators.required)
        });
    }

    public Submit()
    {
        let bun: Bun = new Bun(
            this.bunForm.controls["bunType"].value,
            this.bunForm.controls["originalPrice"].value,
            this.bunForm.controls["originalPrice"].value,
            this.bunForm.controls["sellUntil"].value,
            this.bunForm.controls["targetSaleTime"].value,
            new Date())

        this._bunService.Create(bun);
    }
}