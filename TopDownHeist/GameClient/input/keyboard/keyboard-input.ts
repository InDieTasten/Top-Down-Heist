import { ILinearInput, IAbsoluteLinearInput } from "../abstraction/linear-input";
import { IVectorInput } from "../abstraction/vector-input";

export class KeyInput implements IAbsoluteLinearInput {

    private keyCode: number;
    private pressedState: boolean;

    constructor(keyCode: number) {
        this.keyCode = keyCode;
        this.pressedState = false;

        window.addEventListener("keydown", this.keyDownEventHandler);
        window.addEventListener("keyup", this.keyUpEventHandler);
    }

    private keyDownEventHandler(event: KeyboardEvent): void {
        if (event.keyCode === this.keyCode) {
            this.pressedState = true;
        }
    }
    private keyUpEventHandler(event: KeyboardEvent): void {
        if (event.keyCode === this.keyCode) {
            this.pressedState = false;
        }
    }

    getValue(): number {
        // + converts boolean to 0 or 1 number
        return +this.pressedState;
    }
}
