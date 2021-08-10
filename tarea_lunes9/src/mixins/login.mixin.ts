import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export class loginMixin extends Vue {
    get isLoggin() {
        return this.$store.getters.isLogin;
    }
    switchLoginState(){
        this.$store.state.login = !this.$store.state.login;
    }
}