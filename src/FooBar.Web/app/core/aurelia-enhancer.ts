import { Aurelia, TemplatingEngine, View, EnhanceInstruction } from 'aurelia-framework';

let aurelia: Aurelia;

export function init(au: Aurelia): void {
	aurelia = au;
}

export function enhance(clientModel: any, element: HTMLElement): void {
	let enhanceInstruction: EnhanceInstruction = {
		container: aurelia.container,
		resources: aurelia.resources,
		bindingContext: clientModel,
		element: element
	};
	let templatingEngine: TemplatingEngine = aurelia.container.get(TemplatingEngine);
	let view: View = templatingEngine.enhance(enhanceInstruction);
}