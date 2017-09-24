import { Aurelia, TemplatingEngine, View, EnhanceInstruction } from 'aurelia-framework';

let aurelia: Aurelia;

export function init(au: Aurelia): void {
	aurelia = au;
}

export class AureliaEnhanceMetaData {
    /**
     * @param dataTypeName The name used to name the instance in Aurelia DI, as a convention use the name of the interface that the data object implements.
     * @param clientModelType The type that should be created through Aurelia DI and used as client side model for the enhanced markup.
     */
	constructor(public dataTypeName: string, public clientModelType: Function) {
	}
}

export function createViewModel(metaData: AureliaEnhanceMetaData, data?: any): any {
	if (data) {
		aurelia.container.unregister(metaData.dataTypeName);
		aurelia.use.instance(metaData.dataTypeName, data);
	}

	aurelia.use.transient(metaData.clientModelType);
	let viewModel = aurelia.container.get(metaData.clientModelType);
	return viewModel;
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