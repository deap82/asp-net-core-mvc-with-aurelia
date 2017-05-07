export function create() {
	return new HomeAboutClientModel();
}

class HomeAboutClientModel {
	showMessage() {
		alert('Hello World!');
	}
}