const express = require('express');
const router = express.Router();

const Product = require('../models/product');

router.get('/', async (req, res) => {
     const products = await Product.find();     
     res.json(products);
});

router.get('/:id', async (req, res) => {
    const product = await Product.findById(req.params.id);
    res.json(product);
});

router.post('/', async (req, res) => {
    const { productName, category, quantity, price, description, imgUrl } = req.body;
    const product = new Product({ productName, category, quantity, price, description, imgUrl });
    await product.save();
    res.json({ status: 'Product Saved'});
});

router.delete('/:id', async (req, res) => {
    await Product.findByIdAndRemove(req.params.id);
    res.json({ status: 'Product Deleted'});
});

module.exports = router;