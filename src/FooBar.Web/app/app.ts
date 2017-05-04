import { Router, RouterConfiguration } from 'aurelia-router';

export class App {
	configureRouter(config: RouterConfiguration, router: Router) {
		config.map(
		[
			{ route: '', redirect: 'Home/Start' },
			{
				name: 'MvcRoute',
				route: ':mvcController/:mvcAction/:id?',
				moduleId: 'app/routing/mvc-route-navigation/mvc-route'
			}
		]);
	}
}