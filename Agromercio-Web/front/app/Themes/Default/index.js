import React from 'react';
import Header from './../../Components/Header';
import Footer from './../../Components/Footer';

export default (props) => {
	return(
		<div>
			<Header/>
			<div className="app-content">
				{props.children}
			</div>
			<Footer/>
		</div>
	)
}