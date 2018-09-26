import React, { Component } from 'react';

class ProductRegistration extends Component {

    constructor(props) {
        super(props);
        this.state = {
            productName: '',
            category: '',
            quantity: '',
            price: '',
            description: ''
        };
        this.addProduct = this.addProduct.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    addProduct(e) {
        fetch('api/products', {
            method: 'POST',
            body: JSON.stringify(this.state),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        })
            .then(res => res.json())
            .then(data => {
                console.log(data);
                M.toast({html: 'Producto Registrado'});
                this.setState({productName: '', category: '', quantity: '', price: '', description: ''});
            })
            .catch(err => console.error(err));

        e.preventDefault();
    }

    handleChange(e) {
        const { name, value } = e.target;
        this.setState( {
            [name]: value
        });
    }

    render() {
        return (
            <div>                
                <div className="container">
                    <div className="row">
                        <div className="col s3">
                        </div>
                        <div className="col s6">
                            <div className="card">
                                <div className="card-content">
                                    <form onSubmit={this.addProduct}>
                                        <h5 className="center-align">
                                            Registrar Producto
                                        </h5>
                                        <div className="row">
                                            <div className="input-field col s12">
                                                <input id="productNameId" name="productName" onChange={this.handleChange} type="text" value={this.state.productName} />
                                                <label htmlFor="productNameId">Nombre</label>
                                            </div>
                                        </div>
                                        <div className="row">
                                            <div className="input-field col s12">
                                                <select id="categoryId" name="category" onChange={this.handleChange} value={this.state.category}>
                                                    <option value="" selected disabled>Elija una opción</option>
                                                    <option value="cereal">Cereales</option>
                                                    <option value="tuberculo">Tubérculos</option>
                                                    <option value="legumbre">Legumbres</option>
                                                    <option value="hortaliza">Hortalizas</option>
                                                    <option value="fruta">Frutas</option>
                                                </select>
                                                <label>Categoría</label>
                                            </div>
                                        </div>
                                        <div className="row">
                                            <div className="input-field col s6">
                                                <input id="quantityId" name="quantity" onChange={this.handleChange} type="text" value={this.state.quantity} />
                                                <label htmlFor="quantityId">Cantidad</label>
                                            </div>
                                            <div className="input-field col s6">
                                                <input id="priceId" name="price" onChange={this.handleChange} type="text" value={this.state.price} />
                                                <label htmlFor="priceId">Precio</label>
                                            </div>
                                        </div>
                                        <div className="row">
                                            <div className="input-field col s12">
                                                <textarea id="descriptionId" name="description" onChange={this.handleChange} value={this.state.description} className="materialize-textarea"></textarea>
                                                <label htmlFor="descriptionId">Descripción</label>
                                            </div>
                                        </div>
                                        <div className="row center-align">
                                            <button type="submit" className="btn waves-effect waves-light light-green darken-3">
                                                Registrar
                                            </button>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

export default ProductRegistration;