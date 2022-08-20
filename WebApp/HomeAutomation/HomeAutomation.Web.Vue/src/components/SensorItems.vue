<script lang="ts" setup>
	import { ref, reactive, onMounted } from 'vue';
	import SensorItem from './SensorItem.vue';

	import { LoadAll, Delete } from '../api/resources/SensorApi';
	import { Sensor } from '../api/models/Sensor';

	console.log('SensorItems');
	let currentPage = ref(1);
	let totalPages = ref(0);

	let sensors = reactive({ values: [] as Sensor[] });
	let id = ref(0);

	const loadSensors = async () => {
		sensors.values = await LoadAll();
	}

	const edit = (sensorId: number) => {
		id.value = sensorId;
	}

	const remove = async (sensorId: number) => {
		await Delete(sensorId);
		await loadSensors();
	}

	onMounted(async () => {
		await loadSensors();
	});

</script>

<template>
	<h1>Sensor List</h1>
	<SensorItem :id="id" @reLoad="loadSensors" />
	<VTable :data="sensors.values"
			:pageSize="10"
			v-model:currentPage="currentPage"
			@totalPagesChanged="totalPages = $event">
		<template #head>
			<tr>
				<th>Name</th>
				<th>SensorTypeID</th>
				<th>CodeVerison</th>
				<th>Edit</th>
				<th>Delete</th>
			</tr>
		</template>
		<template #body="{rows}">
			<tr v-for="row in rows" :key="row.id">
				<td>{{ row.name }}</td>
				<td>{{ row.sensorTypeID }}</td>
				<td>{{ row.codeVersion }}</td>
				<td><button @click="edit(row.id)">Edit</button></td>
				<td><button @click="remove(row.id)">Delete</button></td>
			</tr>
		</template>
	</VTable>
	<VTPagination v-model:currentPage="currentPage"
				:total-pages="totalPages"
				:boundary-links="true" />
</template>