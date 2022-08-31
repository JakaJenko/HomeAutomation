import { Box, Button, TextField } from '@mui/material';
import React, { useEffect, useState } from 'react';
import { Sensor } from '../api/models/Sensor';
import { Create, Load, Update } from '../api/resources/SensorApi';

type SensorItemProps =
{
	sensorId: number
	updateSensors: () => Promise<void>
}

function SensorItem({ sensorId, updateSensors }: SensorItemProps) {
	const [sensor, setSensor] = useState<Sensor>({} as Sensor);

	async function submit() {
		if (sensor.id) {
			await Update(sensor);
		}
		else {
			await Create(sensor);
		}

		await updateSensors();
	}

	async function loadSensor(sensorId: number) {
		if (sensorId > 0) {
			setSensor(await Load(sensorId));
		}
	}


	useEffect(() => {
		loadSensor(sensorId);
	}, [sensorId]);

	return (
		<Box
			component="form"
			sx={{
				'& .MuiTextField-root': { m: 1, width: '25ch' },
			}}
			noValidate
			autoComplete="off"
		>
			<div>
				<TextField
					required
					InputLabelProps={{ shrink: true }}
					id="outlined-required"
					label="Name"
					value={sensor?.name ?? ""}
					onChange={(e) => setSensor(prevState => {
						return {
							...prevState,
							name: e.target.value
						};
					})}
				/>
				<TextField
					required
					InputLabelProps={{ shrink: true }}
					id="outlined-required"
					label="SensorTypeID"
					type="number"
					value={sensor?.sensorTypeID ?? ""}
					onChange={(e) => setSensor(prevState => {
						return {
							...prevState,
							sensorTypeID: Number(e.target.value)
						};
					})}
				/>
				<TextField
					required
					InputLabelProps={{ shrink: true }}
					id="outlined-required"
					label="LocationId"
					type="number"
					value={sensor?.locationID ?? ""}
					onChange={(e) => setSensor(prevState => {
						return {
							...prevState,
							locationID: Number(e.target.value)
						};
					})}
				/>
				<TextField
					required
					InputLabelProps={{ shrink: true }}
					id="outlined-required"
					label="CodeVersion"
					type="number"
					value={sensor?.codeVersion ?? ""}
					onChange={(e) => setSensor(prevState => {
						return {
							...prevState,
							codeVersion: Number(e.target.value)
						};
					})}
				/>
				<Button variant="outlined" onClick={submit}>Submit</Button>
			</div>
		</Box>
	);
}

export default SensorItem;