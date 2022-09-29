<template>
  <div class="about">
    <h1>This is an about page</h1>
    <Taylor/>
  </div>
</template>
<script>
import Taylor from '@/components/Taylor.vue'

export default {
  
    name:"AboutView",
    components:{
      Taylor
    },

    
  
};
</script>
<style scoped>
#about{
  overflow-x: hidden;
}
Taylor{
  overflow-x: hidden;
}
</style>

