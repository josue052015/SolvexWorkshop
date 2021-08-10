// mixins.js
import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export class SidebarMixin extends Vue {
    get isSidebarReduced() {
        return this.$store.getters.isSidebarReduced;
    }
    switchSidebarReduce(){
        this.$store.state.sidebarReduced = !this.$store.state.sidebarReduced;
    }
}