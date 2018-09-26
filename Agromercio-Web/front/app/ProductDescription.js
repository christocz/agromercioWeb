import React, { Component } from 'react';

class ProductDescription extends Component {
    constructor(props){
        super(props);
        this.state = {
            productName: '',
            category: '',
            quantity: '',
            price: ''
        };
    }

    componentDidMount() {
        fetch('api/products/5b29dddce3392139641da5e4')
            .then(res => res.json())
            .then(data => {
                console.log(data);
                this.setState({productName: data.productName, category: data.category, quantity: data.quantity, price: data.price});
            })
            .catch(err => console.error(err));
    }

    render() {
        return(
            <div className="product">
                <h4 className="productName">{this.state.productName}</h4>
                <p className="category">{this.state.category}</p>
                <p className="quantity">{this.state.quantity}</p>
                <p className="price">{this.state.price}</p>
            </div>
        )
    }
}

export default ProductDescription;