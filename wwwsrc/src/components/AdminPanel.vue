<template>
	<div class="admin-panel col-12">
		<div class="card">
			<div class="card-body">
				<h5 class="card-title">Administrator's Panel</h5>
				<div class="container-fluid">
					<label for="start">Start date:</label>

					<input
						type="date"
						id="start"
						name="trip-start"
						value="2018-07-22"
						min="2018-01-01"
						max="2018-12-31"
					/>
				</div>
			</div>
		</div>
	</div>
</template>


<script>
export default {
	name: "admin-panel",
	data() {
		return {};
	},
	computed: {},
	methods: {},
	components: {}
};
</script>


<style scoped>
</style>