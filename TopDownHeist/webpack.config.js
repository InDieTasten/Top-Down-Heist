const path = require("path");

module.exports = {
    entry: './GameClient/main.ts',
    output: {
        path: path.resolve(__dirname, 'wwwroot/'),
        filename: 'js/game.bundle.js'
    },
    module: {
        rules: [
            { test: /\.ts$/, use: 'ts-loader' },
            {
                test: /\.(png|jpg|gif)$/,
                use: [
                    {
                        loader: 'file-loader',
                        options: {
                            name: 'images/[name].[ext]'
                        }
                    }
                ]
            }
        ]
    }
}
