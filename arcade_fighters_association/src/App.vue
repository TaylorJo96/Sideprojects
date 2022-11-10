<template>
  <div id="app">
    <div id="nav">
      <router-link to="/info" class="tab" >Info </router-link>
    
      <router-link to="/Events" class="tab" >Events </router-link>
    
      <router-link to="/home"><img id="afa_logo" src="../src/assets/afa.png"/> </router-link>
      <router-link to="/about" class="tab" >About </router-link>
      <router-link to="/history" class="tab" >History</router-link>
    
    </div>
    <router-view/>
  <div>
 
  </div>
  </div>
</template>

<style>
 @import url('https://fonts.googleapis.com/css?family=Arvo&display=swap');


#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
background-color: #64aba3;
display: flex;
flex-direction: column;
height: -webkit-fill-available;


}

#nav {
  
  display: flex;
  justify-content: space-around;
  align-items: center;
 
  

}

#nav a {
  font-weight: bold;
  color: 

#86968c;
width: 15%;
 border-radius: 5px;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
#afa_logo{
 width: 100%;
 
}
.tab{
  text-decoration: none;
  width: 15%;
padding: 15px;
background-color:
#f0cd7d;
font-size: 25px;
font-weight: bold;
font-family: Arvo;
}

</style>
