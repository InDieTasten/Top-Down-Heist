import { IVectorInput } from "./abstraction/vector-input";
import { IHeadingInput } from "./abstraction/heading-input";
import { CombinedVectorInput, CombinedLinearInput, TwoPointDelegateHeadingInput } from "./combined-input";
import { KeyInput } from "./keyboard/key-input";
import { MouseMoveInput } from "./mouse/move-input";
import { Vector2 } from "../helpers/vector";

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

        // Mouse pointer heading
        const mouseTracker = new MouseMoveInput();
        this.heading = new TwoPointDelegateHeadingInput(
            () => this.movement.getVector(),
            () => mouseTracker.getVector()
        );
    }

    movement: IVectorInput;
    heading: IHeadingInput;

}
