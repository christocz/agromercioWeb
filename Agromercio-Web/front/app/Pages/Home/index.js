import React from 'react';

export default class extends React.Component {
	
	constructor(props) {
		super(props);
		this.state = {
			products:[],
			search: ''
		}

		this.onClickCard = this.onClickCard.bind(this);
	}

	onClickCard (id) {
		if (id >= this.state.products.length) {
			return;
		}

		window.open('/productdesc?id=' + this.state.products[id]._id, '_self');
	}

	componentDidMount() {
		fetch('api/products/')
			.then(res => res.json())
			.then(data => {
				console.log(data);
				this.setState({products: data});
			})
			.catch(err => console.error(err));
	}

	updateSearch(event) {
		this.setState({search: event.target.value.substr(0,20)});
	}

	render() {
		let filteredProducts = this.state.products.filter(
			(product) => {
				return product.productName.toLowerCase().indexOf(this.state.search.toLowerCase()) !== -1;
			}
		);

		return(
			<div className="home-page row">
				<input type="text" value={this.state.search} onChange={this.updateSearch.bind(this)} placeholder="Buscar Producto" />
				<div className="cards-container home">
					{
						filteredProducts.map((product, key) => (
							<div className="card home-card" key={key}>
								<div className="card-image waves-effect waves-block waves-light" onClick={this.onClickCard.bind(this,key)}>
									<img src={product.imgUrl} />
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