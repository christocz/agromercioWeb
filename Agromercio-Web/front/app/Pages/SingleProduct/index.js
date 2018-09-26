import React from 'react';

export default class extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			products:[]
		}
	}

	getProductId(name, url) {
		if (!url) url = window.location.href;
		name = name.replace(/[\[\]]/g, "\\$&");
		var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
			results = regex.exec(url);
		if (!results) return null;
		if (!results[2]) return '';
		return decodeURIComponent(results[2].replace(/\+/g, " "));
	}

	componentDidMount() {
		const productId = this.getProductId('id');
		fetch('api/products/'+ productId)
			.then(res => res.json())
			.then(data => {
				console.log(data);
				this.setState({products: data});
			})
			.catch(err => console.error(err));
	}

	render() {
		return (
			<div className="col s12 m5">
				<div className="card horizontal">
					<div className="card-image">
						<img src={this.state.products.imgUrl} />
					</div>
					<div className="card-stacked">
						<div className="card-content">
							<h2>{this.state.products.productName}</h2>
							<p>{this.state.products.description}</p>
							<p>Cantidad: {this.state.products.quantity}</p>
							<p>Precio: {this.state.products.price}</p>
						</div>
						<div className="card-action">
							<a>Comprar Producto</a>
						</div>
					</div>
				</div>				
			</div>
		)
	}
}