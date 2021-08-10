<template>
  <b-navbar id="navbar" :class="{'navbar-on-sidebar-reduced':isSidebarReduced, 'navbar-on-sidebar-not-reduced':!isSidebarReduced}">
    <template #brand>
      
       <b-button type="isSidebarReduced ? is-primary : is-danger "
                  @click="switchSidebarReduce" 
                  >
                {{isSidebarReduced ? '>>':'X'}}
            </b-button>
    </template>
    <template #end>
       <b-navbar-dropdown label="User">
        <b-navbar-item tag="router-link"
              :to="{ path: '/profile' }"     > Profile </b-navbar-item>
        <b-navbar-item tag="router-link"
              :to="{ path: '/profile' }"  > My workshops </b-navbar-item>
      </b-navbar-dropdown>
      <b-navbar-item tag="div">
        <div class="buttons">
          <a class="button is-light" @click="confirmDelete"> Log out </a>
        </div>
      </b-navbar-item>
       
    </template>
  </b-navbar>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import { mixins } from "vue-class-component";
import { SidebarMixin } from "@/mixins";
@Component
export default class navbar extends mixins(SidebarMixin) {
  $buefy: any;
  $router: any;
  $store: any;

  confirmDelete(){
    this.$buefy.dialog.confirm({
      title: "Cerrar sección",
      message: "Seguro de que desea salir?",
      confirmText: "Log out",
      type: "is-danger",
      hasIcon: true,
      onConfirm: () => {
        this.$buefy.toast.open("Has cerrado la sección"),
        this.$router.push("/"),
         this.$store.state.login = !this.$store.state.login;
      }
    });
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
#navbar{
 position: absolute;
  right: 0;
}
.navbar-on-sidebar-not-reduced{
  width: calc(100% - 260px);
}
.navbar-on-sidebar-reduced{
  width: calc(100% - 90px);
}
</style>
