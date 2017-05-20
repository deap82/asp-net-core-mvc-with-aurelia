export function create(data: HomePersonModel) {
	return new HomePersonClientModel(data);
}

class HomePersonClientModel {
	data: HomePersonModel;
	currentYear: number;

	constructor(data: HomePersonModel) {
		this.data = data;
		this.currentYear = new Date().getFullYear();
	}
}

interface HomePersonModel {
	firstName: string;
	lastName: string;
	age: number;
}