<template>
	<div class="modal-backdrop">
		<div class="modal" role="dialog">
			<header class="modal-header">
				<button @click="close()" type="button" class="btn btn-danger">X</button>
			</header>
			<section class="modal-body container card">
				<div class="row card-body d-flex justify-content-around">
					<h3 class="card-title">Needles In/Out</h3>
					<p class="col-12">
						<strong>Note:</strong> Timestamp is created automatically when entry is submitted.
					</p>
					<!-- Form -->
					<form @submit.prevent="makeEntry(needlesIn,needlesOut)" class="form-group col-12">
						<div class="row">
							<div class="col-6">
								<label for="needles-in">Needles In</label>
								<input
									type="number"
									class="form-control"
									placeholder="0"
									name="needles-in"
									v-model="needlesIn"
								/>
							</div>
							<div class="col-6">
								<label for="needles-out">Needles Out</label>
								<input
									type="number"
									class="form-control"
									placeholder="0"
									name="needles-out"
									v-model="needlesOut"
								/>
							</div>
						</div>
						<br />
						<div class="input-group-append row">
							<button class="btn btn-primary btn-block" type="submit">Submit</button>
						</div>
					</form>
				</div>
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
		makeEntry(needlesIn, needlesOut) {
			let newEntry = {};
			if (needlesIn.isInteger() || needlesOut.isInteger()) {
				newEntry.needlesIn = needlesIn;
				newEntry.needlesOut = needlesOut;

				this.$store.dispatch("makeEntry", newEntry);
			}
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
	border-bottom: 1px solid #be862c00;
	justify-content: flex-end;
}
.modal-footer {
	border-top: 1px solid #be862c00;
	justify-content: space-around;
}
.modal-body {
	position: relative;
	padding: 20px 10px;
}
.no-margin {
	margin: 0;
}
.half-width {
	width: 50%;
}
</style>