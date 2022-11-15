<template>

<div id= tournament>
    
    <h2>AFA #14 Super Street Fighter II Turbo with Randomizer Rules</h2>
    
    <div id="insideTournament">
    <div>
 
 
    </div>
    
    <div id="winner">
        
    <img id='winnerimg' src = '../assets/mrHoward.jpg'/>
    <h3 id="winnerNickname">Mr Howard</h3>
    </div>
    
    <div id="description">
           <img id='gameLogo' src='../assets/sf2t.png'/>
              <p id="date">September 18 2022</p>
        
    <p id="eventDescription">The Arcade Fighters Association returned to action this evening in one of the most chilled, laid back shows we have ever ran. Tonight was a blast! We had our first ever tie breaker between Jonny-Dude and Mr Howard.

After a night of random draws with some interesting match ups… we have a NEW AFA Champion!

The trophy will stay in Bellevue until November, as Level Up’s own Mr Alexander Howard takes home the big win with a 5-2 victory</p>
    </div>
    </div>
</div>
 
</template>
<script>
// import PlayerService from '../services/PlayerService.js';

export default {
 
    name:"previous-tournament"
}
</script>
<style scoped>
#winnerimg {
    max-width: 30vw;
    max-height: 40vh;
    padding:10px;
}
#gameLogo{
    max-height: 90px;
}
#tournament
{
    background: pink;
    margin:25px


}
#insideTournament
{
    display: flex;

    
}
#date{


}
#description{
    display: flex;
    align-items: center;
    flex-direction: column;
}
#eventDescription{
padding: 8px;


}
#winnerNickname{
    margin:0;
}
</style>
