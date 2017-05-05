import { Aurelia } from 'aurelia-framework';
import * as aureliaEnhancerModule from 'app/core/aurelia-enhancer';

export function configure(aurelia: Aurelia) {
	aurelia.use
		.standardConfiguration()
		.developmentLogging();

	aureliaEnhancerModule.init(aurelia);

	aurelia.start().then(() => aurelia.setRoot());
}