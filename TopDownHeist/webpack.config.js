const path = require("path");

module.exports = {
    entry: './GameClient/main.ts',
    output: {
        path: path.resolve(__dirname, 'wwwroot/js/'),
        filename: 'game.bundle.js'
    },
    module: {
        rules: [
            { test: /\.ts$/, use: 'ts-loader' }
        ]
    }
}
