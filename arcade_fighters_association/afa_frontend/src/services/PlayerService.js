import axios from 'axios';

export default{

    getPlayers(){
    return axios.get('/players')
    },

    getPlayerById(playerId){
        return axios.get(`/player/${playerId}`)
    },
 

}