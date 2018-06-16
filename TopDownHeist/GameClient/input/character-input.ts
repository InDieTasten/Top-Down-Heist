import { IVectorInput } from "./abstraction/vector-input";
import { IHeadingInput } from "./abstraction/heading-input";
import { CombinedVectorInput, CombinedLinearInput } from "./combined-input";
import { KeyInput } from "./keyboard/keyboard-input";

export class CharacterInput {

    constructor() {

        // Arrow key movement
        this.movement = new CombinedVectorInput(
            new CombinedLinearInput(
                new KeyInput(39), //right
                new KeyInput(37) //left
            ),
            new CombinedLinearInput(
                new KeyInput(40), // down
                new KeyInput(39) // up
            )
        );

    }

    movement: IVectorInput;
    heading: IHeadingInput;

}
