import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './Authservice'
import { generateKeyPairSync } from 'crypto'


Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? 'https://localhost:5001/' : '/'

let api = Axios.create({
	baseURL: baseUrl + "api/",
	timeout: 3000,
	withCredentials: true
})

export default new Vuex.Store({
	state: {
		user: {},
		entries: [],
	},
	mutations: {
		setUser(state, user) {
			state.user = user
		},
		resetState(state) {
			//clear state object of user data
			state.user = {}
		},
		setEntries(state, entries) {
			state.entries = entries
		}
	},
	actions: {
		// #region Auth

		async register({ commit, dispatch }, creds) {
			try {
				let user = await AuthService.Register(creds)
				commit('setUser', user)
				router.push({ name: "dashboard" })
			} catch (e) {
				console.warn(e.message)
			}
		},
		async login({ commit, dispatch }, creds) {
			try {
				let user = await AuthService.Login(creds)
				commit('setUser', user)
				router.push({ name: "dashboard" })
			} catch (e) {
				console.warn(e.message)
			}
		},
		async logout({ commit, dispatch }) {
			try {
				let success = await AuthService.Logout()
				if (!success) { }
				commit('resetState')
				router.push({ name: "login" })
			} catch (e) {
				console.warn(e.message)
			}
		},

		// #endregion

		async getEntries({ commit, dispatch }) {
			console.log("Getting entries...");

			try {
				let res = await api.get('entries')
				commit('setEntries', res.data)
			} catch (error) { console.error(error) }
		},

		async makeEntry({ commit, dispatch }, newEntry) {
			console.log(newEntry);

			try {
				await api.post('entries', newEntry)
				dispatch('getEntries')
			} catch (error) { console.error(error) }
		}
	},
	modules: {
	}
})
