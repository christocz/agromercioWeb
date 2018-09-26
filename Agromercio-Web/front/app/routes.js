import React from 'react';
import { Switch, Route, BrowserRouter } from 'react-router-dom';
import DefaultTheme from './Themes/Default';
import HomePage from './Pages/Home';
import LoginPage from './Pages/Login';
import RegisterProductPage from './Pages/RegisterProduct';
import SingleProductPage from './Pages/SingleProduct';

function component(Content) {
	return (
		<DefaultTheme>
			<Content/>
		</DefaultTheme>
	);
}

export default (props) => {
	return (
		<BrowserRouter>
			<Switch>
				<Route exact path="/" component={() => component(HomePage)}/>
				<Route path="/login" component={() => component(LoginPage)}/>
				<Route path="/register" component={() => component(RegisterProductPage)}/>
				<Route path="/productdesc" component={() => component(SingleProductPage)}/>
			</Switch>
		</BrowserRouter>
	)
}