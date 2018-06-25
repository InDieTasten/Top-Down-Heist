import { IVectorInput } from "./abstraction/vector-input";
import { IHeadingInput } from "./abstraction/heading-input";
import { CombinedVectorInput, CombinedLinearInput, TwoPointDelegateHeadingInput } from "./combined-input";
import { KeyInput } from "./keyboard/key-input";
import { Vector2 } from "../helpers/vector";

export class PlayerInput {

    constructor(interactionManager: PIXI.interaction.InteractionManager, target: PIXI.DisplayObject) {

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
        this.heading = new TwoPointDelegateHeadingInput(
            () => target.getGlobalPosition(),
            () => interactionManager.mouse.global
        );
    }

    movement: IVectorInput;
    heading: IHeadingInput;

}
