<template>
  <div id="page">
    <div class="background">
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <span></span>
      <h1 id="name">Taylor Dupont</h1>
      <div id="title" class="container">
        <div class="word w1">Software Developer</div>
        <div class="word w2">Artist</div>
        <div class="word w3">Problem Solver</div>
        <div class="word w4">Leader</div>
        <div class="word w5">Mom</div>
      </div>
      <div id="topOfPage">
        <div class="stats">
          <div id= "statBack">
             </div>
          <img id="perstats" src="../../src/assets/stats.png" />
          </div>
       
        <div class="hello">
          <h2 id="creator">meet the creator!</h2>
          <img id="selfpsit" src="../../src/assets/taylortrans.png" />
        </div>
        <div>
          "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
          eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad
          minim veniam, quis nostrud exercitation ullamco laboris nisi ut
          aliquip ex ea commodo consequat. Duis aute irure dolor in
          reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
          pariatur. Excepteur sint occaecat cupidatat non proident, sunt in
          culpa qui officia deserunt mollit anim id est laborum."
        </div>
        <div id="description">
          "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
          eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad
          minim veniam, quis nostrud exercitation ullamco laboris nisi ut
          aliquip ex ea commodo consequat. Duis aute irure dolor in
          reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
          pariatur. Excepteur sint occaecat cupidatat non proident, sunt in
          culpa qui officia deserunt mollit anim id est laborum."
        </div>
      </div>
      <div>
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod
        tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim
        veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea
        commodo consequat. Duis aute irure dolor in reprehenderit in voluptate
        velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint
        occaecat cupidatat non proident, sunt in culpa qui officia deserunt
        mollit anim id est laborum."
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "HelloWorld",
  props: {
    msg: String,
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#statBack{
  border: 4px dashed rgba(28, 100, 141, 0.767);
  z-index: -1;
position:absolute;
  height:42.7vh;
  width:28.7vh;
  margin-left:70px;
}

#page {
  height: 95vh;
}
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
#selfpsit {
  height: 70vh;
  margin-top:-50px;
  
}
#topOfPage {
  display: flex;
}
#creator{
    transform: translate(-100px, -25px);
  font-size:30pt;
  text-transform: capitalize;
}

@keyframes move {
  100% {
    transform: translate3d(0, 0, 1px) rotate(360deg);
  }
}

.background {
  position: fixed;
  width: 100vw;
  height: 100vh;
  top: 0;
  left: 0;
  background: #fdfcfd;
  overflow: hidden;
  z-index: -1;
}

.background span {
  width: 40vmin;
  height: 40vmin;
  border-radius: 40vmin;
  backface-visibility: hidden;
  position: absolute;
  animation: move;
  animation-duration: 19;
  animation-timing-function: linear;
  animation-iteration-count: infinite;
  z-index: -1;
}

.background span:nth-child(0) {
  color: #f8e8f0;
  top: 25%;
  left: 73%;
  animation-duration: 105s;
  animation-delay: -158s;
  transform-origin: -22vw 16vh;
  box-shadow: -80vmin 0 10.876550821440038vmin currentColor;
  z-index: -1;
}
.background span:nth-child(1) {
  color: #fde2d3;
  top: 41%;
  left: 53%;
  animation-duration: 192s;
  animation-delay: -15s;
  transform-origin: 7vw 22vh;
  box-shadow: 80vmin 0 10.032152923651285vmin currentColor;
  z-index: -1;
}
.background span:nth-child(2) {
  color: #f8e8f0;
  top: 38%;
  left: 70%;
  animation-duration: 308s;
  animation-delay: -284s;
  transform-origin: -1vw 20vh;
  box-shadow: 80vmin 0 10.565876843191289vmin currentColor;
  z-index: -1;
}
.background span:nth-child(3) {
  color: #fde2d3;
  top: 7%;
  left: 59%;
  animation-duration: 151s;
  animation-delay: -26s;
  transform-origin: 21vw -19vh;
  box-shadow: -80vmin 0 10.909547820396691vmin currentColor;
  z-index: -1;
}
.background span:nth-child(4) {
  color: #f8e8f0;
  top: 8%;
  left: 48%;
  animation-duration: 302s;
  animation-delay: -309s;
  transform-origin: 6vw 7vh;
  box-shadow: 80vmin 0 10.61574502201222vmin currentColor;
  z-index: -1;
}
.background span:nth-child(5) {
  color: #fcb6db;
  top: 2%;
  left: 60%;
  animation-duration: 254s;
  animation-delay: -283s;
  transform-origin: -8vw 16vh;
  box-shadow: -80vmin 0 10.646741358113312vmin currentColor;
  z-index: -1;
}
.background span:nth-child(6) {
  color: #f8e8f0;
  top: 49%;
  left: 11%;
  animation-duration: 70s;
  animation-delay: -234s;
  transform-origin: 20vw -15vh;
  box-shadow: -80vmin 0 10.42466088790027vmin currentColor;
  z-index: -1;
}
.background span:nth-child(7) {
  color: #c6ddda;
  top: 48%;
  left: 62%;
  animation-duration: 125s;
  animation-delay: -185s;
  transform-origin: -22vw -9vh;
  box-shadow: 80vmin 0 10.332969437277058vmin currentColor;
  z-index: -1;
}
.background span:nth-child(8) {
  color: #c6ddda;
  top: 71%;
  left: 52%;
  animation-duration: 229s;
  animation-delay: -226s;
  transform-origin: 19vw -18vh;
  box-shadow: -80vmin 0 10.026949521231655vmin currentColor;
  z-index: -1;
}
.background span:nth-child(9) {
  color: #fcb6db;
  top: 29%;
  left: 56%;
  animation-duration: 270s;
  animation-delay: -53s;
  transform-origin: -3vw -14vh;
  box-shadow: 80vmin 0 10.31331051287447vmin currentColor;
  z-index: -1;
}
.background span:nth-child(10) {
  color: #f8e8f0;
  top: 64%;
  left: 82%;
  animation-duration: 53s;
  animation-delay: -29s;
  transform-origin: -16vw 7vh;
  box-shadow: -80vmin 0 10.399687984896902vmin currentColor;
  z-index: -1;
}
.background span:nth-child(11) {
  color: #fde2d3;
  top: 69%;
  left: 82%;
  animation-duration: 172s;
  animation-delay: -224s;
  transform-origin: 4vw -10vh;
  box-shadow: -80vmin 0 10.37005765515602vmin currentColor;
  z-index: -1;
}
.background span:nth-child(12) {
  color: #fcb6db;
  top: 9%;
  left: 8%;
  animation-duration: 228s;
  animation-delay: -39s;
  transform-origin: -1vw 20vh;
  box-shadow: 80vmin 0 10.765713972082331vmin currentColor;
  z-index: -1;
}
.background span:nth-child(13) {
  color: #f8e8f0;
  top: 56%;
  left: 50%;
  animation-duration: 71s;
  animation-delay: -70s;
  transform-origin: 5vw 1vh;
  z-index: -1;
  box-shadow: 80vmin 0 10.462454965566767vmin currentColor;
}
.background span:nth-child(14) {
  color: #ccfff9;
  top: 76%;
  left: 28%;
  animation-duration: 52s;
  animation-delay: -125s;
  transform-origin: 21vw 24vh;
  box-shadow: 80vmin 0 10.019167435449694vmin currentColor;
  z-index: -1;
}
@import url("https://fonts.googleapis.com/css?family=Poppins");
#name {
  text-align: end;
  margin: 0px;
  margin-top: 40px;
  font-size: 46pt;
  color: #de2cbd;
  font-family: Poppins, sans-serif;
  font-weight: bolder;
}
#title {
  text-align: end;
  margin: 0px;
  margin-bottom: 20px;
  font-size: 20pt;
  margin-right: 10px;
  margin-top: -5px;
}

.container {
  position: relative;

  text-align: end;

  margin: 20px auto;

  border-radius: 6px;
  color: rgb(83, 70, 128);
  padding-bottom: 20px;

  font-family: "Times New Roman", Times, serif;
}
@import url("https://fonts.googleapis.com/css?family=Staatliches");

.word {
  font-weight: bold;
  opacity: 0;
  position: absolute;
  width: 100%;
  text-align: end;

  font-family: "Staatliches", sans-serif;
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
}

.w3 {
  -webkit-animation: w3anim 20s infinite;
  animation: w3anim 20s infinite;
}

.w4 {
  -webkit-animation: w4anim 20s infinite;
  animation: w4anim 20s infinite;
}

.w5 {
  -webkit-animation: w5anim 20s infinite;
  animation: w5anim 20s infinite;
}
#creator {
  margin-top: -40px;
}
#description {
  margin-right: 20px;
}
#perstats {
  width: 45vh;
}
.stats {
 margin:0px;
 margin-right:-80px;
margin-left: -40px;
margin-top:30px;
}
</style>
