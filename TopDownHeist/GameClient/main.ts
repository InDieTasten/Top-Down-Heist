import * as PIXI from "pixi.js";
import * as playerTexture from './images/player-shotgun.png';
import { CharacterInput } from "./input/character-input";
import { MouseMoveInput } from "./input/mouse/move-input";


let type = "WebGL";

if (!PIXI.utils.isWebGLSupported()) {
    type = "canvas";
}

// Create a Pixi Application
let app = new PIXI.Application();

// Set display to fill browser window
app.renderer.view.style.position = "absolute";
app.renderer.view.style.display = "block";
app.renderer.autoResize = true;
app.renderer.resize(window.innerWidth, window.innerHeight);

// Add the canvas that Pixi automatically
// created for you to the HTML document
document.body.appendChild(app.view);

PIXI.loader.add(playerTexture).load(() => {

    const playerSprite = new PIXI.Sprite(
        PIXI.loader.resources[playerTexture].texture
    );

    playerSprite.pivot.set(playerSprite.width / 2, playerSprite.height / 2);

    const playerInput = new CharacterInput();

    app.stage.addChild(playerSprite);
    app.ticker.add(gameLoop);

    function gameLoop(delta: number) {
        const playerMovementVector = playerInput.movement.getVector();

        playerSprite.x += playerMovementVector.x * delta * 5;
        playerSprite.y += playerMovementVector.y * delta * 5;

        playerSprite.rotation = playerInput.heading.getHeading() + Math.PI/2;
    }
});

