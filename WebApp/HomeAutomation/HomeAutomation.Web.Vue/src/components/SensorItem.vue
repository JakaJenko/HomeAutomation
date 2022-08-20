<script lang="ts" setup>
	import { defineEmits, defineProps, reactive, watch } from 'vue';
	import { Sensor } from '../api/models/Sensor';
	import { Load, Create, Update } from '../api/resources/SensorApi';

	const emit = defineEmits(['reLoad'])

	const props = defineProps({
		id: {
			type: Number, default: -1
		}
	});

	let data = reactive({ sensor: {} as Sensor });

	watch(() => props.id, async () =>
	{
		data.sensor = await Load(props.id);
		console.log(data.sensor);
	});

	async function submit() {
		console.log(data.sensor);

		if (data.sensor.id) {
			await Update(data.sensor);
		}
		else {
			await Create(data.sensor);
		}

		emit('reLoad');
	}
</script>

<template>
	<div>
		<input type="hidden" v-model="data.sensor.id" /><br />

		<label>Name</label>
		<input type="text" v-model="data.sensor.name" /><br />

		<label>SensorTypeId</label>
		<input type="text" v-model.number="data.sensor.sensorTypeID" /><br />

		<label>LocationId</label>
		<input type="text" v-model.number="data.sensor.locationID" /><br />

		<label>Code version</label>
		<input type="text" v-model.number="data.sensor.codeVersion" />

		<button @click="submit">Submit</button>
	</div>
</template>