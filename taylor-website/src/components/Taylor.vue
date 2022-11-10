<template>
<div id="image">
    <!-- <img id="selfpsit" src="../../src/assets/selfport.png" /> -->
</div>
<div id="leftHairArrow" class="grow, arrow" v-on:click="hairForward">
  <span id="grow">  &#60;</span>
</div>
<div id="rightHairArrow" class="grow, arrow" v-on:click="hairBack">
   &#62;
</div>

 

<!-- lets make out list of hairstyles -->
<ul>
    <li class="hairListItem"><img  src="../../src/assets/hair1.png" class="hair" id="hair1" v-if="hairNumber=='1'" /></li>
     <li class="hairListItem"><img   src="../../src/assets/hair2.png" class ="hair" id="hair2"  v-if="hairNumber=='2'" /></li>
     <li class="hairListItem"><img  src="../../src/assets/hair3.png" class="hair" id="hair3"  v-if="hairNumber=='3'" /></li>
      <li class="hairListItem"><img  src="../../src/assets/hair4.png" class="hair" id="hair4" v-if="hairNumber=='4'"  /></li>
       <li class="hairListItem"><img  src="../../src/assets/hair5.png" class="hair" id="hair5"  v-if="hairNumber=='5'" /></li>


    <li class="accesory, hairListItem"><img id="glasses" class="accessories" src ="../../src/assets/glasses.png" /> </li>
     <li class="accesory, hairListItem"><img id="lip1" class="accessories" src ="../../src/assets/lip1.png" /> </li>
 <li class="accesory, hairListItem"><img id="lip2" class="accessories" src ="../../src/assets/lip2.png" /> </li>
 <li class="accesory, hairListItem"><img id="lip3" class="accessories" src ="../../src/assets/lip3.png" /> </li>
 <li class="accesory, hairListItem"><img id="lip4" class="accessories" src ="../../src/assets/lip4.png" /> </li>
 
 <li class="accesory, hairListItem"><img id="makeup1" class="accessories" src ="../../src/assets/makeup1.png" /> </li>
 <li class="accesory, hairListItem"><img id="makeup2" class="accessories" src ="../../src/assets/makeup2.png" /> </li>



</ul>   


<div id="leftClothesArrow" class="grow, clothesArrow"  v-on:click="outfitBack">
    &#60;
</div>
<div id="rightClothesArrow" class="grow, clothesArrow" v-on:click="outfitForward">
   &#62;
</div>

<!-- list of clothes -->
<ul id="listOfClothes">

<li class="clothing" id= "gD" ><img id="grnDress" v-if="fitNumber=='1'" src="../../src/assets/outfit1.png" /></li>
<li class="clothing" id = "gS" ><img id="grnShirt" v-if="fitNumber=='2'" src="../../src/assets/outfit2.png" /></li>
<li class="clothing" id="tS" ><img id="tSweater" v-if="fitNumber=='3'" src="../../src/assets/outfit3.png" /></li>
<li class="clothing" id="tS" ><img id="tSweater" v-if="fitNumber=='4'" src="../../src/assets/outfit4.png" /></li>

</ul>

</template>
<script>



export default {
  
    name:"Taylor",
    props:{
   
    },
    created(){
        
    },
    data(){
   
        return{
           fitNumber:1,
           hairNumber:1
            
      
                 
        }
//Math.floor(Math.random() * (2 - 0 + 1) + 0)

    },
     methods:{
    outfitForward: function(event){

        console.log(this.fitNumber)
        if(this.fitNumber>=4)
        {
            this.fitNumber=1
        }
        else{
        this.fitNumber += 1
        }
    },
       outfitBack:function(event){
           if(this.fitNumber<=1)
           {
               this.fitNumber = 4;
           }
           else{
               this.fitNumber-=1
           }

       },
          
             
         
         hairForward:function(event){
             console.log(this.hairNumber)
            if(this.hairNumber <=4)
            {
                this.hairNumber+=1;
            }
            else{
                this.hairNumber = 1;
            }

         },
         hairBack:function(event){
             if(this.hairNumber>=2)
             {this.hairNumber-=1}
             else{
                 this.hairNumber= 5;
             }
         }

     

     
     }



}
// let startingFitIndex = Math.floor(Math.random() * (2 - 0 + 1) + 0);
// const rightClothesBtn = document.getElementById('rightClothesArrow');
// const sweaterOutfit= document.getElementById('ts');
// rightClothesBtn.addEventListener('click', () =>{

// sweaterOutfit.style.display = 'none';
// })
//rightClothesBtn.onclick(changeFit);


</script>
<style >

@import url('https://fonts.googleapis.com/css?family=Righteous');



.clothing{
    list-style: none;
     position: absolute;
}

#grnDress{
max-width: 322px;
   
    z-index: 1;
  transform: translate(-40px);
  align-content: flex-start;

}
#grnShirt{
    max-width: 322px;
   
    z-index: 1;
  transform: translate(-40px);
  align-content: flex-start;
}
#tSweater{
     max-width: 322px;
   
    z-index: 1;
  transform: translate(-40px);
  align-content: flex-start;
  

}
#selfpsit {
max-width: 322px;
z-index: -5;



}
#image{
    position: absolute;
    height: max-content;
}
.arrow{
    position:absolute;
    width: 2vw;
   
    font-family: Righteous;

 
    margin-top: 60px;



    font-size: 25px;
    font-weight: 100;
    color: rgba(235, 52, 137, 1);

    letter-spacing: 0px;
    text-shadow: 1px 1px 2px rgba(140, 0, 77, 1);
    z-index: 10;
    height: 10px;



}
#leftHairArrow{
 text-align: left;   
 transform: translate(86px);

}
#rightHairArrow{
    text-align: right;
    width: 220px;
}
.clothesArrow{
     position:absolute;
    width: 00px;
    font-size: 20pt;
 
    font-family: Righteous;
    

    font-size: 25px;
    font-weight: 100;
    color: rgba(235, 52, 137, 1);

    letter-spacing: 0px;
    text-shadow: 1px 1px 2px rgba(140, 0, 77, 1);

 
    margin-top: 200px;
    z-index: 10;
}
#leftClothesArrow{
     text-align: left;
     transform: translate(60px);   
      z-index: 11;
}
#rightClothesArrow{
        text-align: right;
        width: 10px;
        margin-left: 250px;
        position: absolute;
        height: 10px;
        
       
        
}
#rightHairArrow{
margin-left: 200px;
width: 15px;
}
.hairListItem{
    list-style: none;
         position: absolute;
}
.hair{
        list-style: none;
        
        position: absolute;
         max-width: 322px;
        z-index: 2;
             align-content: flex-start;
     transform:translate(-40px)
        
        
}

.hide {
  display: none;
}
.accessories{ 
    position: absolute;
    height: max-content;

        z-index: 1;

         max-width: 322px;
   

  transform: translate(-40px);
  align-content: flex-start;
        
}
.grow{
    transition: all .2s ease-in-out;
}
.grow:hover{
    transform:scale(1.1);
    font-size: 50pt;
}
</style>