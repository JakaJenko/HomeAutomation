<script lang="ts" setup>
	import SensorItems from './components/SensorItems.vue';

	console.log('App');
</script>

<template>
	<img alt="Vue logo" src="./assets/logo.png">

	<div id="app">
		<SensorItems />
	</div>
</template>

<style>
	#app {
		font-family: Avenir, Helvetica, Arial, sans-serif;
		-webkit-font-smoothing: antialiased;
		-moz-osx-font-smoothing: grayscale;
		text-align: center;
		color: #2c3e50;
		margin-top: 60px;
	}
</style>
