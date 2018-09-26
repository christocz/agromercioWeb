import React, {Component} from 'react';
import Product from './Product';
import LoadingProducts from '../loaders/ProductList';

class ProductList extends Component {
    constructor(props){
        super(props);
        this.state = {
            products:[]
        };
    }
    
    componentDidMount() {
        fetch('api/products')
            .then(res => res.json())
            .then(data => {
                console.log(data);
                this.setState({products: data});
            })
            .catch(err => console.error(err));
    }

    render() {

        return(
                <div className="row">
                    <div id="toggle-container" className="col s12 cards-container">
                        {
                            this.state.products.map((product, key) => (
                                <div className="card" key={key}>
                                    <div className="card-image waves-effect waves-block waves-light">
                                        <img src="https://assets-cdn.github.com/images/modules/open_graph/github-mark.png" />
                                    </div>
                                    <div className="card-content">
                                        <span className="card-title grey-text text-darken-4">{product.productName}</span>
                                        <p>Categoría: {product.category}</p>
                                        <p>Cantidad: {product.quantity}</p>
                                        <p>Precio: {product.price}</p>
                                    </div>
                                </div>
                            ))
                        }
                    </div>
                </div>
        )
    }
}

export default ProductList;