import { IVectorInput } from "./abstraction/vector-input";
import { IHeadingInput } from "./abstraction/heading-input";
import { CombinedVectorInput, CombinedLinearInput } from "./combined-input";
import { KeyInput } from "./keyboard/keyboard-input";

export class CharacterInput {

    constructor() {

        // WASD key movement
        this.movement = new CombinedVectorInput(
            new CombinedLinearInput(
                new KeyInput(68), //right
                new KeyInput(65) //left
            ),
            new CombinedLinearInput(
                new KeyInput(83), // down
                new KeyInput(87) // up
            )
        );

    }

    movement: IVectorInput;
    heading: IHeadingInput;

}
