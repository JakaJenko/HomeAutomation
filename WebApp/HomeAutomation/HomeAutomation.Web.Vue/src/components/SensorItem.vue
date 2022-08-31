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

	watch(() => props.id, async () => {
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
	<div class="row">
		<input type="hidden" v-model="data.sensor.id" />

		<div class="col">
			<label>Name</label>
			<input type="text" v-model="data.sensor.name" />
		</div>
		<div class="col">
			<label>SensorTypeId</label>
			<input type="text" v-model.number="data.sensor.sensorTypeID" />
		</div>
		<div class="col">
			<label>LocationId</label>
			<input type="text" v-model.number="data.sensor.locationID" />
		</div>
		<div class="col">
			<label>Code version</label>
			<input type="text" v-model.number="data.sensor.codeVersion" />
		</div>
		<div class="col">
			<button @click="submit">Submit</button>
		</div>
	</div>
</template>