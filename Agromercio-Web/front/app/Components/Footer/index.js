import React, { Component } from 'react';

class Footer extends Component {
	render() {
		return(
			<footer className="page-footer light-green darken-3">
				<div className="container">
					<div className="row">
						<div className="col s12">
							<h5 className="white-text">Agromercio</h5>
						</div>
					</div>
				</div>
				<div className="footer-copyright">
					<div className="container">
						© 2018 Copyright Agromercio
					</div>
				</div>
			</footer>
		)
	}
}

export default Footer;