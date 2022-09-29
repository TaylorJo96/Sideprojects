<template>
  <nav>
    <router-link to="/">Home</router-link> |
    <router-link to="/about">About</router-link>
  </nav>
  <router-view/>
</template>

<style>

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}



nav a {
 
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #6e1285;
}
body{
  height: 100vh;
   overflow-x: hidden;
   margin:0px;
}
#app{
  height: 100vh;
  overflow-x: hidden;
}
</style>
