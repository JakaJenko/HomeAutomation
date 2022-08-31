import React, { useEffect, useState } from 'react';
import { render } from 'react-dom';
import { Sensor } from '../api/models/Sensor';
import { Delete, LoadAll } from '../api/resources/SensorApi';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import SensorItem from './SensorItem';

function SensorItems() {
	const [sensors, setSensors] = useState<Sensor[]>([]);
	const [sensorId, setSensorId] = useState<number>(-1);

	const loadSensors = async () => {
		setSensors(await LoadAll());
	}

	const remove = async (sensorId: number) => {
		await Delete(sensorId);
		await loadSensors();
	}

	useEffect(() => { loadSensors(); }, []);

	return (
		<div>
			<SensorItem sensorId={sensorId} updateSensors={loadSensors} />
			<TableContainer component={Paper}>
				<Table sx={{ minWidth: 650 }} aria-label="simple table">
					<TableHead>
						<TableRow>
							<TableCell>Name</TableCell>
							<TableCell>Sensor type ID</TableCell>
							<TableCell>Code version</TableCell>
							<TableCell>Edit</TableCell>
							<TableCell>Delete</TableCell>
						</TableRow>
					</TableHead>
					<TableBody>
						{sensors.map((row) => (
							<TableRow
								key={row.id}
								sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
							>
								<TableCell component="th" scope="row">
									{row.name}
								</TableCell>
								<TableCell align="right">{row.sensorTypeID}</TableCell>
								<TableCell align="right">{row.codeVersion}</TableCell>
								<TableCell align="right"><button onClick={() => { setSensorId(row.id) }}>Edit</button></TableCell>
								<TableCell align="right"><button onClick={() => { remove(row.id) }}>Delete</button></TableCell>
							</TableRow>
						))}
					</TableBody>
				</Table>
			</TableContainer>
		</div>
	);


}

export default SensorItems;