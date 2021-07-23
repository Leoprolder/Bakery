import { FormControl } from "@angular/forms";

export class CustomValidators {
    public PriceValidator(control: FormControl): {[x: string]: boolean}|null {
        if (Number(control.value) > 100) {
            return {"originalPrice": true};
        }

        return null;
    }
}