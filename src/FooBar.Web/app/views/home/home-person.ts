import { inject } from 'aurelia-framework';
import { Router } from 'aurelia-router';
import { AureliaEnhanceMetaData } from '../../core/aurelia-enhancer';

let dataKey = 'HomePersonModel';

export function createMetaData(data: HomePersonModel): AureliaEnhanceMetaData {
	return new AureliaEnhanceMetaData(dataKey, HomePersonClientModel);
}

@inject(dataKey, Router)
class HomePersonClientModel {
	data: HomePersonModel;
	router: Router;
	currentYear: number;

	constructor(data: HomePersonModel, router: Router) {
		this.data = data;
		this.router = router;
		this.currentYear = new Date().getFullYear();
	}
}

interface HomePersonModel {
	firstName: string;
	lastName: string;
	age: number;
}