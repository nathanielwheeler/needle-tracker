import Vue from 'vue'
// @ts-ignore
import App from './App.vue'
import router from './router'
import store from './store'
import AuthService from './Authservice'

// Vue.config.productionTip = false

async function init() {
  let user = await AuthService.Authenticate()
  if (user) { store.commit("setUser", user) }
  else { router.push({ name: 'login' }) }
  new Vue({
    router,
    store,
    render: h => h(App)
  }).$mount('#app')
}
init()