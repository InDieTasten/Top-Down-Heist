import { IVectorInput } from "./abstraction/vector-input";
import { IHeadingInput } from "./abstraction/heading-input";
import { CombinedVectorInput, CombinedLinearInput, TwoPointDelegateHeadingInput } from "./combined-input";
import { KeyInput } from "./keyboard/key-input";
import { Vector2 } from "../helpers/vector";

export interface IPlayerInput {
    movement: Vector2;
    heading: number;
}

export class LocalPlayerInput implements IPlayerInput {

    movement: Vector2;
    heading: number;

    private movementInput: IVectorInput;
    private headingInput: IHeadingInput;

    constructor(interactionManager: PIXI.interaction.InteractionManager, target: PIXI.DisplayObject) {

        // WASD key movement
        this.movementInput = new CombinedVectorInput(
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
        this.headingInput = new TwoPointDelegateHeadingInput(
            () => target.getGlobalPosition(),
            () => interactionManager.mouse.global
        );
    }

    update(delta: number): void {
        this.movement = this.movementInput.getVector();
        this.heading = this.headingInput.getHeading();
    }

}
