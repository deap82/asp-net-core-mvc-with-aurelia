import 'whatwg-fetch';
import { autoinject } from 'aurelia-framework';
import { HttpClient } from 'aurelia-fetch-client';

@autoinject
export class MvcRoute {
	html: string;
	
	constructor(private httpClient: HttpClient) {
	}

	activate(params: any) {
		let url = this.resolveMvcUrl(params);
		this.loadHtml(url).then(html => {
			this.html = html;
		});
	}

	private resolveMvcUrl(params: any): string {
		let url = `/${params.mvcController}/${params.mvcAction}/${(params.id || '')}`;
		delete params.mvcController;
		delete params.mvcAction;
		delete params.id;
		var queryString = $.param(params);
		if (queryString) {
			url += `?${queryString}`;
		}
		return url;
	}

	private loadHtml(mvcRoute: string): Promise<string> {
		const result = this.httpClient.fetch(mvcRoute).then(response => response.text());
		return result;
	}
}