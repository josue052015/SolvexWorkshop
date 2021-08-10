import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    sidebarReduced:false,
    login: false
  },
  getters: {
    isSidebarReduced(state){
      return state.sidebarReduced;
    },
    isLogin(state){
      return state.login;
    }
  },
  mutations: {
    
  },
  actions: {
    
  },
  modules: {
  }
})
