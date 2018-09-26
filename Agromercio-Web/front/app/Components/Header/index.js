import React, { Component } from 'react';

class Header extends Component {

	componentDidMount() {
		$('.dropdown-trigger').dropdown({
			constrain_width: true
		});
	}

	render() {
		return(
			<nav className="header light-green darken-3">
				<div className="nav-wrapper">
					<a href="/"><img className="logo" src="/images/logo.svg"/></a>
					<a href="/" className="brand-logo">GROMERCIO</a>
					<ul className="right hide-on-med-and-down">
						<li><a className='dropdown-trigger' href="#" data-target='dropdown1'><i className="medium material-icons">add_circle</i></a></li>
						<li><a className='dropdown-trigger' href="#" data-target='dropdown2'><i className="medium material-icons">account_circle</i></a></li>
					</ul>
					<ul id='dropdown1' className='dropdown-content'>
						<li><a href="/register">Registrar Producto</a></li>
					</ul>
					<ul id='dropdown2' className='dropdown-content'>
						<li><a href="#!">Ingresar</a></li>
						<li><a href="#!">Registrarse</a></li>
					</ul>
				</div>
			</nav>
		)
	}
}

export default Header;