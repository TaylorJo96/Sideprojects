import axios from 'axios';

export default{

    getTournaments(){
    return axios.get('/tournaments')
    },

    getTournament(tournamentId){
        return axios.get(`/tournaments/${tournamentId}`)
    },
    getRecentTournament(){
        return axios.get(`/tournaments/recent`)
    }
 

}