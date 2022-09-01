import { APISettings } from '../config';
import { ListResponse } from '../models/ListResponse';
import { ValueResponse } from '../models/ValueResponse';

export async function LoadAll<T>(): Promise<ListResponse<T>> {
	const response = await fetch(APISettings.baseURL + '/sensors', {
		method: 'GET'
	});

	return (await response.json()) as ListResponse<T>;
}

export async function Load<T>(id: number): Promise<ValueResponse<T>> {
	const response = await fetch(APISettings.baseURL + '/sensors/' + id, {
		method: 'GET'
	});

	return (await response.json()) as ValueResponse<T>;
}

export async function Create<T>(data: T): Promise<ValueResponse<T>> {
	const response = await fetch(APISettings.baseURL + '/sensors', {
		method: 'PUT',
		headers: {
			'Content-Type': 'application/json'
		},
		body: JSON.stringify(data)
	});

	return (await response.json()) as ValueResponse<T>;
}

export async function Update<T>(data: T): Promise<ValueResponse<T>> {
	const response = await fetch(APISettings.baseURL + '/sensors', {
		method: 'POST',
		headers: {
			'Content-Type': 'application/json'
		},
		body: JSON.stringify(data)
	});

	return (await response.json()) as ValueResponse<T>;
}

export async function Delete(id: Number) {
	const response = await fetch(APISettings.baseURL + '/sensors/' + id, {
		method: 'DELETE'
	});

	//return (await response.json()).value as Sensor;
}
