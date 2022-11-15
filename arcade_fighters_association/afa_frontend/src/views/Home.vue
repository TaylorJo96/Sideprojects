<template>
  <div class="home">
    hello

    <p v-for="player in Players" v-bind:key="player.playerId">
{player.firstName}
    </p>
    <HelloWorld />
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'
import PlayerService from "../services/PlayerService.js"
export default {
  
  name: 'Home',
  components: {
    HelloWorld
  },
  data(){
return{
players:[]


}

},
  
  

created(){
PlayerService.getPlayers()
.then((response)=>{
  this.player = response.data;
})
}
}
</script>
<style scoped>
.home{
  background-color: orange;

}
</style>
