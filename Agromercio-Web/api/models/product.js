const ProductModel = require('./factoryClassModel');

const _schema = {
	productName: { type: String, required: true },
	category: { type: String, required: true },
	quantity: { type: Number, required: true },
	price: { type: Number, required: true },
	description: { type: String, required: true },
	creationDate: { type: Date, default: Date.now },
	imgUrl: { type: String, required: true}
};

class Product extends ProductModel('Product', _schema) {
	constructor() {
		super(...arguments);
	}

	deployContract() {

	}

	getContract() {

	}
}

module.exports = Product;