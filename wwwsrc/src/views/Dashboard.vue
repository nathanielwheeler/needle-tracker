<template>
	<div class="dashboard container">
		<header class="row">
			<h3 class="col-12 text-center">Hello {{user.username}}!</h3>
		</header>
		<main class="row">
			<div class="col-12 col-md-6">
				<div class="card border-primary rounded-0">
					<div class="card-body">
						<h5 class="card-title">Record how many needles have come in and out.</h5>
						<button class="btn btn-primary">Make Entry</button>
					</div>
				</div>
			</div>
		</main>
	</div>
</template>

<script>
// @ is an alias to /src
import EntryModal from "../components/EntryModal.vue";

export default {
	name: "dashboard",
	components: { EntryModal },
	data() {
		return {
			isModalVisible: false
		};
	},
	computed: {
		user() {
			return this.$store.state.user;
		}
	},
	methods: {
		showModal() {
			this.isModalVisible = true;
		},
		closeModal() {
			this.isModalVisible = false;
		}
	}
};
</script>
