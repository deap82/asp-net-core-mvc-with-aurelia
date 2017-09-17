import { Aurelia } from 'aurelia-framework';
import * as aureliaEnhancerModule from './core/aurelia-enhancer';

export function configure(aurelia: Aurelia) {
	aurelia.use
		.standardConfiguration()
		.developmentLogging()
		.globalResources(
			['app/resources/elements/html-placeholder/html-placeholder']);

	aureliaEnhancerModule.init(aurelia);

	aurelia.start().then(() => aurelia.setRoot());
}