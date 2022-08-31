import { APISettings } from '../config';
import { Sensor } from '../models/Sensor';

export async function LoadAll(): Promise<Sensor[]> {
	const response = await fetch(APISettings.baseURL + '/sensors', {
		method: 'GET'
	});

	return (await response.json()).values as Sensor[];
}

export async function Load(id: number): Promise<Sensor> {
	const response = await fetch(APISettings.baseURL + '/sensors/' + id, {
		method: 'GET'
	});

	return (await response.json()).value as Sensor;
}

export async function Create(data: Sensor): Promise<Sensor> {
	const response = await fetch(APISettings.baseURL + '/sensors', {
		method: 'PUT',
		headers: {
			'Content-Type': 'application/json'
		},
		body: JSON.stringify(data)
	});

	return (await response.json()).value as Sensor;
}

export async function Update(data: Sensor): Promise<Sensor> {
	const response = await fetch(APISettings.baseURL + '/sensors', {
		method: 'POST',
		headers: {
			'Content-Type': 'application/json'
		},
		body: JSON.stringify(data)
	});

	return (await response.json()).value as Sensor;
}

export async function Delete(id: Number) {
	const response = await fetch(APISettings.baseURL + '/sensors/' + id, {
		method: 'DELETE'
	});

	//return (await response.json()).value as Sensor;
}
