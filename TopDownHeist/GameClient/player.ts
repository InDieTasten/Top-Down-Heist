import { PlayerInput } from "./input/player-input";

import * as playerTexture from './images/player-shotgun.png';

export class Player extends PIXI.Container {

    private sprite: PIXI.Sprite;
    private input: PlayerInput;

    constructor(interactionManager: PIXI.interaction.InteractionManager) {
        super();

        this.sprite = new PIXI.Sprite(PIXI.loader.resources[playerTexture].texture);
        this.addChild(this.sprite);

        this.input = new PlayerInput(interactionManager, this);

        this.pivot.set(this.width / 2, this.height / 2);
    }

    public update(delta: number): void {
        const playerMovementVector = this.input.movement.getVector();

        this.x += playerMovementVector.x * delta * 10;
        this.y += playerMovementVector.y * delta * 10;

        this.rotation = this.input.heading.getHeading() + Math.PI / 2;
    }
}
