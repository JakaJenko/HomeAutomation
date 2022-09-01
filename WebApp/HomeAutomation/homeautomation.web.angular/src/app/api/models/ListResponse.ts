export interface ListResponse<T> {
	returnCode: number;
	returnMsg: string;
	value: T[]
}