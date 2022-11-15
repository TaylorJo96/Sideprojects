<template>
  <div class="history">
    <h2>Display All the Previous tournaments in order from newest to oldest</h2>

 <previous-tournament/>
 <previous-tournament/>
  <previous-tournament/>
   <previous-tournament/>
  </div>
</template>
<script>

import PreviousTournament from '@/components/PreviousTournament.vue'



export default {
  name: 'events',
  components: {
 
    PreviousTournament
 
  }
}


</script>

    PreviousTournament