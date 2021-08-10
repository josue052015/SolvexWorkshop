<template>
  <div v-if="!isLoggin">
    <template>
      <section >
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
          <b-button  @click="switchLoginState" 
                to="/WorkShop"
            >
            Aceptar
          </b-button>
        </div>
      </section>
    </template>
  </div>
</template>
<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { mixins } from "vue-class-component";
import { loginMixin } from "@/mixins";
@Component
export default class login extends mixins(loginMixin) {}
</script>
