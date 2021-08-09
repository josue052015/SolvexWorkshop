<template>
  <div>
    <template>
      <section>
        <b-field label="Name">
          <b-input ></b-input>
        </b-field>
       <b-field label="LastName">
          <b-input ></b-input>
        </b-field>
        
      </section>
    </template>
  </div>
</template>
<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

export default class Register extends Vue {}
</script>
