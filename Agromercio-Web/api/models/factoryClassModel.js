const mongoose = require('mongoose');
const { Schema } = mongoose;

function factoryClassModel(table, schema) {
	return mongoose.model(table, new Schema(schema));
}

module.exports = factoryClassModel;