<template>
  <v-row>
    <v-col class="text-center">
        <footer>
          Welcome to our Wonderfully Written Wordle Game!! <v-spacer/>
          Still in progress at the moment but we have big plans for it and shall be continunally updating it until completion.
            <v-spacer />
          Kudos to Meg, one of the greatest programmers this world has ever seen 
          and who also just so happens to be the person grading this website.
        </footer>      
        <v-card-actions justify="center"> 
                <v-spacer/>
                
          <v-btn color="primary" nuxt to="/game"> Back to the Game </v-btn>
        </v-card-actions>
    </v-col>
  </v-row>
</template>

<script>
export default {
  name: 'AboutPage',
}
</script>
