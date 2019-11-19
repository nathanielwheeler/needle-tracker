<template>
	<div class="dashboard container">
		<header class="row">
			<h3 class="col-12 text-center">Hello {{user.username}}!</h3>
		</header>
		<main class="row">
			<div class="col-12 col-md-6">
				<div class="card">
					<div class="card-body">
						<h5 class="card-title">Entries</h5>
					</div>
				</div>
			</div>
		</main>
	</div>
</template>

<script>
// @ is an alias to /src

export default {
	name: "dashboard",
	components: {},
	computed: {
		user() {
			return this.$store.state.user;
		}
	}
};
</script>
