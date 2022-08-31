export interface ValueResponse<T> {
	returnCode: number;
	returnMsg: string;
	value: T
}