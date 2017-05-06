import { customElement, bindable } from 'aurelia-framework';

@customElement('au-html-placeholder')
export class HtmlPlaceholder {
	@bindable html: string;
	private placeholder: HTMLElement;

	attached(): void {
		this.performAppend();
	}

	private htmlChanged(newValue: string, oldValue: string): void {
		if (newValue === oldValue) {
			return;
		}
		this.performAppend();
	}

	private performAppend(): void {
		$(this.placeholder).empty().append(this.html);
	}
}