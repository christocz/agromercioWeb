const express = require('express');
const morgan = require('morgan');
const path = require('path');

const { mongoose } = require('./api/database');

const app = express();

// Settings
app.set('port', process.env.PORT || 3123);


// Middlewares
app.use(morgan('dev'));
app.use(express.json());

// Routes
app.use('/api/products', require('./api/routes/product.routes'));
//app.use('/api/*', require('./routes/product.routes')); // 404 api/*

// Static files
app.use(express.static(path.join(__dirname, '/front/public')));

// Redirect to index 
app.get('*', (req, res) => res.sendFile(path.join(__dirname, '/front/public/index.html')))

// Starting server
app.listen(app.get('port'), () => {
    console.log(`Server on port ${app.get('port')}`);
});