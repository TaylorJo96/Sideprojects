<template>
  <div id="page">

      <h1 id="name">Taylor Dupont</h1>
      <div id="title" class="container">
        <div class="word w1">Software Developer</div>
        <div class="word w2">Artist</div>
        <div class="word w3">Problem Solver</div>
        <div class="word w4">Leader</div>
        <div class="word w5">Mom</div>
      </div>
      <div id="topOfPage">
        <div id="statsAndImg">
          <div class="stats">
           
            <img id="perstats" src="../../src/assets/stats.png" />
          </div>
          <div id="sit">
            <Taylor />
            <Info />
          </div>
        </div>
     
      </div>

 
    </div>
  
</template>

<script>
import Taylor from "@/components/Taylor.vue";
import Info from "@/components/Info.vue"
export default {
  name: "HelloWorld",
  components: {
    Taylor,
    Info,
  },
  props: {
    msg: String,
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

@import url("https://fonts.googleapis.com/css?family=Poppins");
#name {
  font-size: 32pt;
  color: #de2cbd;
  font-family: Poppins, sans-serif;
  font-weight: bolder;
  margin: 0px;
}
#title {
  font-size: 20pt;

}

@import url("https://fonts.googleapis.com/css?family=Staatliches");
#sit{

  transform:translate(110px, -290px);
  
}

.word {
  font-weight: bold;

  font-family: "Staatliches", sans-serif;
}


#perstats {
  max-width:250px;
  padding-top:20px;
  transform: translate(-35px);
  display: flex;
  align-self: flex-start;
}

#statsAndImg{
  
 

  overflow-x: hidden;
height: 100vh;
  
 
}
#topOfPage{
    height: 100vh;
}

#page{
  height: 100vh;
}

.word {

  font-weight: bold;
  opacity: 0;
  position: relative;

  text-align: end;

  font-family: "Staatliches", sans-serif;
  max-height: 100px;
}
@keyframes w1anim {
  0% {
    opacity: 0;
  }
  8%,
  15% {
    opacity: 1;
  }
  20% {
    opacity: 0;
  }
}

@keyframes w2anim {
  20% {
    opacity: 0;
  }
  28%,
  35% {
    opacity: 1;
  }
  40% {
    opacity: 0;
  }
}

@keyframes w3anim {
  40% {
    opacity: 0;
  }
  48%,
  55% {
    opacity: 1;
  }
  60% {
    opacity: 0;
  }
}

@keyframes w4anim {
  60% {
    opacity: 0;
  }
  68%,
  75% {
    opacity: 1;
  }
  80% {
    opacity: 0;
  }
}

@keyframes w5anim {
  80% {
    opacity: 0;
  }
  88%,
  95% {
    opacity: 1;
  }
  100% {
    opacity: 0;
  }
}
.w1 {
  -webkit-animation: w1anim 20s infinite;
  animation: w1anim 20s infinite;
}

.w2 {
  -webkit-animation: w2anim 20s infinite;
  animation: w2anim 20s infinite;
  transform: translate(0, -33px);
}

.w3 {
  -webkit-animation: w3anim 20s infinite;
  animation: w3anim 20s infinite;
  transform: translate(0, -66px);
}

.w4 {
  -webkit-animation: w4anim 20s infinite;
  animation: w4anim 20s infinite;
  transform: translate(0, -99px);
}

.w5 {
  -webkit-animation: w5anim 20s infinite;
  animation: w5anim 20s infinite;
  transform: translate(0, -128px);
}
#title{
  height: 20px;
padding-right: 10px;
}

</style>
