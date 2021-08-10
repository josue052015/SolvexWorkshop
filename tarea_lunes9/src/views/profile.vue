<template>
    <div>
        <h1>Profile</h1>
    </div>
</template>
<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

import { mixins } from "vue-class-component";
import { loginMixin } from "@/mixins";

export default class profile extends mixins(loginMixin) {}
//export default class profile extends Vue {}
</script>