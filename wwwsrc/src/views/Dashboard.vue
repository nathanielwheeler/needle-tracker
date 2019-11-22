<template>
	<div class="dashboard container">
		<header class="row">
			<h3 class="col-12 text-center">Hello {{user.username}}!</h3>
		</header>
		<main class="row d-flex justify-content-around">
			<div class="col-12 col-md-6">
				<div class="card border-secondary">
					<h5 class="card-header">Recent Entries</h5>
					<ul class="list-group list-group-flush">
						<!-- Insert Entries -->
						<li v-for="entry in entries" :entryProp="entry" :key="entry.id" class="list-group-item">
							<strong>{{entry.timeStamp}}</strong>
							: +({{entry.needlesIn}}) -({{entry.needlesOut}})
						</li>
					</ul>
				</div>
			</div>
			<div class="col-12 col-md-6">
				<div class="card border-primary">
					<div class="card-body">
						<h5 class="card-title">Record how many needles have come in and out.</h5>
						<button @click="showModal()" class="btn btn-primary">Make Entry</button>
						<entry-modal v-show="isModalVisible" @close="closeModal" />
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
	mounted() {
		console.log("Getting entries...");
		this.$store.dispatch("getEntries");
	},
	computed: {
		user() {
			return this.$store.state.user;
		},
		entries() {
			return this.$store.state.entries;
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
