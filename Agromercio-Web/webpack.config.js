module.exports = {
    entry: './front/app/index.js',
    output: {
        path: __dirname + '/front/public',
        filename: 'bundle.js'
    },
    module: {
        rules: [
            {
                use: 'babel-loader',
                test: /\.js$/,
                exclude: /node_modules/
            }
        ]
    }    
};