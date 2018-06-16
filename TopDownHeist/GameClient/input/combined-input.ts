import { ILinearInput, IAbsoluteLinearInput } from "./abstraction/linear-input";
import { IVectorInput } from "./abstraction/vector-input";
import { Vector2 } from "../helpers/vector";
import { IHeadingInput } from "./abstraction/heading-input";

export class CombinedLinearInput implements ILinearInput {

    private input: IAbsoluteLinearInput;
    private inverseInput: IAbsoluteLinearInput;

    constructor(input: IAbsoluteLinearInput, inverseInput: IAbsoluteLinearInput) {
        this.input = input;
        this.inverseInput = inverseInput;
    }

    getValue(): number {
        return this.input.getValue() - this.inverseInput.getValue();
    }

}

export class CombinedVectorInput implements IVectorInput {

    private xInput: ILinearInput;
    private yInput: ILinearInput;

    constructor(xInput: ILinearInput, yInput: ILinearInput) {
        this.xInput = xInput;
        this.yInput = yInput;
    }

    getVector(): Vector2 {
        return new Vector2(
            this.xInput.getValue(),
            this.yInput.getValue()
        );
    }

}

export class TwoPointDelegateHeadingInput implements IHeadingInput {

    pointADelegate: () => Vector2;
    pointBDelegate: () => Vector2;

    constructor(pointADelegate: () => Vector2, pointBDelegate: () => Vector2) {
        this.pointADelegate = pointADelegate;
        this.pointBDelegate = pointBDelegate;
    }

    getHeading(): number {

        const diff = this.pointADelegate().subtract(this.pointBDelegate());

        const theta = Math.atan2(diff.y, diff.x);

        return theta + Math.PI/2;
    }

}

