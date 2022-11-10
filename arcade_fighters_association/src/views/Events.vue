<template>
  <div class="events">
    <div id="upcomingBox">
      <iframe  id="upcoming" src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23F6BF26&ctz=America%2FNew_York&mode=AGENDA&showNav=0&showDate=0&showCalendars=0&showTz=0&showTabs=0&showPrint=0&showTitle=0&src=MjI0NzE1MDdkMTBkZThjMWEwMzhmNzA4MTI3ZDI0YjQ5ZWM3ZTI0NDE0Y2NhOThjMDJjNGFkYTA2N2U4ZDE3ZUBncm91cC5jYWxlbmRhci5nb29nbGUuY29t&color=%23795548" style="border-width:0px" width="800" height="600" frameborder="0" scrolling="no"></iframe>
    </div>
    <div id="calendarBox">
    <Calendar/>
    
        <iframe id="calendar" src="https://calendar.google.com/calendar/embed?height=600&wkst=1&bgcolor=%23F6BF26&ctz=America%2FNew_York&mode=MONTH&showNav=1&showDate=1&showCalendars=0&showTz=0&showTabs=0&showPrint=0&src=MjI0NzE1MDdkMTBkZThjMWEwMzhmNzA4MTI3ZDI0YjQ5ZWM3ZTI0NDE0Y2NhOThjMDJjNGFkYTA2N2U4ZDE3ZUBncm91cC5jYWxlbmRhci5nb29nbGUuY29t&color=%23795548" style="border-width:0;"  width="800" height="600" frameborder="0" scrolling="no"></iframe>
    </div> 




    
  </div>

</template>

<script>

import Calendar from '@/components/calendar.vue'


export default {
  name: 'events',
  components: {
    Calendar
  }
}

</script>
   
<style scoped>
.events{
    display: flex;
justify-content: space-between;    
}
#upcomingBox{
    display: flex;
    justify-content: start;
margin: 10px;
}
#upcoming{
    width: 35vw;
    height: 30vh;
}

#calendar{
    width:60vw;
    padding-right:10px;
}


</style>