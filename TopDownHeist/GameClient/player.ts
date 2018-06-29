import { LocalPlayerInput } from "./input/player-input";

import * as playerTexture from './images/player-shotgun.png';

export class Player extends PIXI.Container {

    private sprite: PIXI.Sprite;
    private input: LocalPlayerInput;

    constructor(interactionManager: PIXI.interaction.InteractionManager) {
        super();

        this.sprite = new PIXI.Sprite(PIXI.loader.resources[playerTexture].texture);
        this.addChild(this.sprite);

        this.input = new LocalPlayerInput(interactionManager, this);

        this.pivot.set(this.width / 2, this.height / 2);
    }

    public update(delta: number): void {

        this.input.update(delta);

        this.x += this.input.movement.x * delta * 10;
        this.y += this.input.movement.y * delta * 10;
        this.rotation = this.input.heading + Math.PI / 2;
    }
}
