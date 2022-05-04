import axios from "axios";

function postScore(player: string, time: number){
  axios.post("insert-wordle-api-link-here", {
    name: player,
    score: time
  })
    .then((response) => {
      console.log(response);
    });
}

function getScores() {
  axios({
    method: 'get',
    url: 'insert-wordle-api-link-here'
  })
    .then((response) => {
      console.log(response);
      return response.data
    })
    .catch(function (error) {
      console.log(error);
    });
}
