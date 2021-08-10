<template>
  <div id="app">
    <div v-if="isLoggin" class="checkLogin">
      <navbar />
      <sidebar />
    </div>
    <div class="main-content">
      <router-view />
    </div>
  </div>
</template>
<script lang="ts">
import { mixins } from "vue-class-component";
import { loginMixin } from "@/mixins";

export default class App extends mixins(loginMixin) {}
</script>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
