﻿import * as PIXI from "pixi.js";
import * as playerTexture from './images/player-shotgun.png';


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

    let playerSprite = new PIXI.Sprite(
        PIXI.loader.resources[playerTexture].texture
    );

    app.stage.addChild(playerSprite);
});