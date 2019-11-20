<template>
	<div class="modal-backdrop">
		<div class="modal" role="dialog">
			<header class="modal-header">
				<!-- FIXME Add dates to entries -->
				<h1></h1>
				<button @click="close()" type="button" class="btn btn-outline">X</button>
			</header>
			<section class="modal-body">
				<!-- Form -->
				<form @submit.prevent="makeEntry" class="form-group">
					<input
						type="number"
						class="form-control"
						placeholder="Needles In"
						name="needles-in"
						v-model="needlesIn"
					/>
					<input
						type="number"
						class="form-control"
						placeholder="Needles Out"
						name="needles-out"
						v-model="needlesOut"
					/>
					<p>
						<strong>Note:</strong> Timestamp is created automatically when entry is submitted.
					</p>
					<div class="input-group-append">
						<button class="btn btn-primary" type="submit">Submit</button>
					</div>
				</form>
			</section>
			<footer class="modal-footer">
				<!-- Submission Button -->
			</footer>
		</div>
	</div>
</template>


<script>
export default {
	name: "entry-modal",
	data() {
		return {
			needlesIn: 0,
			needlesOut: 0
		};
	},
	computed: {
		entries() {
			return this.$store.state.entries;
		}
	},
	props: [],
	methods: {
		close() {
			this.$emit("close");
		},
		makeEntry(entryId) {
			let newEntry = {};
			this.$store.dispatch("makeEntry", newEntry);
		}
	},
	components: {}
};
</script>


<style scoped>
.modal-backdrop {
	position: fixed;
	top: 0;
	bottom: 0;
	left: 0;
	right: 0;
	background-color: rgba(0, 0, 0, 0.3);
	display: flex;
	justify-content: center;
	align-items: center;
}
.modal {
	background: #201d19;
	box-shadow: 2px 2px 20px 1px;
	overflow-x: auto;
	overflow-y: auto;
	display: flex;
	flex-direction: column;
}
.modal-header,
.modal-footer {
	padding: 15px;
	display: flex;
}
.modal-header {
	border-bottom: 1px solid #be862c;
	color: #f9d094;
	justify-content: space-between;
}
.modal-footer {
	border-top: 1px solid #be862c;
	justify-content: space-around;
}
.modal-body {
	position: relative;
	padding: 20px 10px;
}
.modal-image {
	max-height: 60vh;
	width: auto;
}
.no-margin {
	margin: 0;
}
.half-width {
	width: 50%;
}
.custom-select {
	background: #2e2a24;
}
</style>