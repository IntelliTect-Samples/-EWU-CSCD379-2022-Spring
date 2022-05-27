<template>
  <v-card width="800" height="800">
    <v-container class="overflow-hidden" fluid>
      <v-row justify="center">
        <v-col>
          <a href="https://www.youtube.com/watch?v=waX5YJgc8Kc" target="_blank">
            <v-img src="ad.gif" />
          </a>
        </v-col>
      </v-row>
    </v-container>
  </v-card>
</template>

<script>
import Vue from 'vue'
import Component from 'vue-class-component'
@Component
export default class PrerollAd extends Vue {}
</script>