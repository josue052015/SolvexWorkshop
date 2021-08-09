<template>
  <div>
    <template>
      <section>
        <b-field
          label="Username"
          type="is-success"
          message="This username is available"
        >
          <b-input value="johnsilver" maxlength="30"></b-input>
        </b-field>

        <b-field label="Password" type="is-success">
          <b-input value="123" type="is-success"></b-input>
        </b-field>

      </section>
    </template>
    <template>
      <section>
        <div class="buttons">
          <b-button tag="router-link" to="/Home" type="is-link">
            Aceptar
          </b-button>
          
          <router-view/>
        </div>
      </section>
    </template>
  </div>
</template>
<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

export default class Login extends Vue {}
</script>
