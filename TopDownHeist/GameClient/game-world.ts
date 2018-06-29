import { Player } from "./player";

export class GameWorld extends PIXI.Container {

    private interactionManager: PIXI.interaction.InteractionManager;
    private localPlayer: Player;

    constructor(interactionManager: PIXI.interaction.InteractionManager) {
        super();

        this.interactionManager = interactionManager;

        // create local player
        this.localPlayer = new Player(interactionManager);
        this.addChild(this.localPlayer);
    }

    public update(delta: number) {
        this.localPlayer.update(delta);
    }

}
