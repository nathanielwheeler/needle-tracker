<template>
	<div class="navbar">
		<router-link to="/">Needle Tracker</router-link>
		<a @click="logout" href="#">Logout</a>
	</div>
</template>


<script>
export default {
	name: "navbar",
	data() {
		return {};
	},
	computed: {
		user() {
			return this.$store.state.user;
		}
	},
	methods: {
		logout() {
			this.$store.dispatch("logout");
		}
	},
	components: {}
};
</script>


<style scoped>
</style>