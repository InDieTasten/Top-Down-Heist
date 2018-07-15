import { Player } from "./player";
import { NetworkDispatcher } from "./network/network-dispatcher";

export class GameWorld extends PIXI.Container {

    private interactionManager: PIXI.interaction.InteractionManager;
    private localPlayer: Player;
    private network: NetworkDispatcher;

    constructor(interactionManager: PIXI.interaction.InteractionManager) {
        super();

        this.interactionManager = interactionManager;
        this.network = new NetworkDispatcher();
        this.network.connect();

        // create local player
        this.localPlayer = new Player(interactionManager);
        this.addChild(this.localPlayer);
    }

    public update(delta: number) {
        this.localPlayer.update(delta);
    }

}
