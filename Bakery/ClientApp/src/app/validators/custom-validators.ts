import { FormControl } from "@angular/forms";

export class CustomValidators {
    public PriceValidator(control: FormControl): {[x: string]: boolean}|null {
        if (Number(control.value) > 100 || Number(control.value <= 0) || isNaN(Number(control.value))) {
            return {"originalPrice": true};
        }

        return null;
    }

    public DateValidator(control: FormControl): {[x: string]: boolean}|null {
        if (new Date(control.value) <= new Date()) {
            return {"sellUntil": true, "targetSaleTime": true};
        }

        return null;
    }
}