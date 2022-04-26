<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="6">
      <v-card>
        <v-card-title class="headline"> Leaderboard </v-card-title>
        <v-card-text>
          <v-simple-table>
            <thead>
              <tr>
                <th>Name</th>
                <th>Average</th>
                <th>Number of Games</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(score, index) in scores" :key="index">
                <td>{{ score.name }}</td>
                <td>{{ score.average }}</td>
                <td>{{ score.gameCount }}</td>
              </tr>
            </tbody>
          </v-simple-table>
        </v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn color="secondary" :loading="isLoading" @click="refresh">
            Refresh
          </v-btn>
          <v-btn color="secondary" :loading="isLoading" @click="createUser">
            Create User
          </v-btn>
          <v-btn color="secondary" :loading="isLoading" @click="getToken">
            Get Token
          </v-btn>
        </v-card-actions>
      </v-card>
      <v-card>
        <v-card-title>Add Score</v-card-title>
        <v-card-text>
          <v-text-field v-model="name" label="Name"></v-text-field>
          <v-text-field v-model="score" label="Score"></v-text-field>
        </v-card-text>
        <v-card-actions>
          <v-btn
            color="primary"
            :loading="isLoading"
            :disabled="token == ''"
            @click="addScore"
          >
            Add Score
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-col>
  </v-row>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
import { AxiosResponse } from 'axios'

import { Score } from '@/scripts/score'

@Component
export default class IndexPage extends Vue {
  isLoading: boolean = false
  scores: Score[] = []
  token: string = ''
  name: string = 'Bubba'
  score: number = 3

  created() {
    this.refresh()
  }

  config() {
    return {
      headers: { Authorization: `Bearer ${this.token}` },
    }
  }

  refresh() {
    this.$axios.get('/leaderboard').then((response: AxiosResponse) => {
      this.scores = response.data
    })
  }

  addScore() {
    this.$axios
      .post(
        '/leaderboard/submitscore',
        {
          name: this.name,
          numberOfAttempts: this.score,
        },
        this.config()
      )
      .then((response: AxiosResponse) => {
        console.log(`Added a Score: ${JSON.stringify(response.data)}`)
        this.refresh()
      })
      .catch((error) => {
        console.log(JSON.stringify(error))
      })
  }

  getToken() {
    this.$axios
      .post('/token/GetToken', {
        email: 'test@test.com',
        password: 'Password#1',
      })
      .then((response: AxiosResponse) => {
        this.token = response.data.token
        console.log(`Got a Token: ${this.token}`)
      })
      .catch((error) => {
        console.log(JSON.stringify(error))
      })
  }

  createUser() {
    this.$axios
      .post('/token/CreateUser', {
        email: 'test@test.com',
        userName: 'Test',
        password: 'Password#1',
      })
      .catch((error) => {
        console.log(JSON.stringify(error))
      })
  }
}
</script>
