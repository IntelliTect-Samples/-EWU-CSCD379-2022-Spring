<template>
  <v-row>
    <v-col class="text-center">
      <img src="/v.png" alt="Vuetify.js" class="mb-5" />
      <blockquote class="blockquote">
        &#8220;First, solve the problem. Then, write the code.&#8221; 
        <footer>
          <small>         
            <em>&mdash;Random programmer no one has ever heard of</em>
          </small>
        </footer>
      </blockquote>
      <v-card>
        <v-card-title class="headline">
          Welcome to the start of the Next Big Thing™ 
        </v-card-title>
        <v-card-text>
          <div class="text-xs-right">
            <em><small>The world of real time competitive multiplayer Wordle is about to arrive...</small></em>
          </div>
          <hr class="my-3" />

        </v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn color="primary" nuxt to="/"> Return </v-btn>
        </v-card-actions>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
export default {
  name: 'InspirePage',
}
</script>
