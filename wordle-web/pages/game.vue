<template>
<v-row justify="center" align="center">
    <v-card>
        <v-card-title class="headline">
            Game Page!
        </v-card-title>
        <v-card-text>
            <p>
                Hello World
            </p>

        </v-card-text>
    </v-card>
    <v-card>
        <v-btn @click="goToHome()" color="primary">
            Go Home
        </v-btn>
    </v-card>
</v-row>
</template>

<script lang="ts">
import Vue from "vue"
import Component from "vue-class-component"

@Component
export default class Game extends Vue {
    goToHome() {
        this.$router.push('/');
    }
}
</script>
