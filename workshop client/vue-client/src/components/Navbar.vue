<template>
  <div class="Navbar">
    <template>
      <b-navbar>
        <template #brand>
          <b-navbar-item tag="router-link" :to="{ path: '/' }">
            <img
              src="https://media.giphy.com/media/CRR2Q9ppqx0Eo/giphy.gif"
              alt="Lightweight UI components for Vue.js based on Bulma"
            />
          </b-navbar-item>
        </template>
        <template #start>
          <b-navbar-item href="/WorkShop"> WorkShop </b-navbar-item>
          <b-navbar-item href="/Member"> Member </b-navbar-item>

          <b-navbar-dropdown label="Info">
            <b-navbar-item href="/About"> About </b-navbar-item>
          </b-navbar-dropdown>
        </template>

        <template #end>
          <b-navbar-item tag="div">
            <section>
              <div class="buttons">
                <b-button tag="router-link" to="/Register" type="is-link">
                  Register
                </b-button>
                <b-button tag="router-link" to="/Login" type="is-link">
                  Log in
                </b-button>
              </div>
            </section>
          </b-navbar-item>
        </template>
      </b-navbar>
    </template>
    <router-view />
  </div>
</template>
 

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component({
  components: {},
})
export default class Navbar extends Vue {}
</script>
