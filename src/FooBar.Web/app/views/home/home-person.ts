export function create(data: any) {
	return new HomePersonClientModel(data);
}

class HomePersonClientModel {
	data: any;
	currentYear: number;

	constructor(data: any) {
		this.data = data;
		this.currentYear = new Date().getFullYear();
	}
}