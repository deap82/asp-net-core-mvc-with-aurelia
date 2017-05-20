export function create() {
	return new HomePersonClientModel();
}

class HomePersonClientModel {
	currentYear: number;

	constructor() {
		this.currentYear = new Date().getFullYear();
	}
}