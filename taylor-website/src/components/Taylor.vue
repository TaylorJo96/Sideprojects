<template>
<div id="image">
    <img id="selfpsit" src="../../src/assets/selfport.png" />
</div>
<div id="leftHairArrow" class="arrow">
    &#60;
</div>
<div id="rightHairArrow" class="arrow">
   &#62;
</div>
<!-- lets make out list of hairstyles -->
<!-- <ul>
    <li></li>
    <li></li>
    <li></li>
</ul>    -->


<div id="leftClothesArrow" class="clothesArrow">
    &#60;
</div>
<div id="rightClothesArrow" class="clothesArrow" v-on:click="changeFit()" >
   &#62;
</div>

<!-- list of clothes -->
<ul>

<li class="clothing" id= "gD"><img id="grnDress" src="../../src/assets/grndress.png" /></li>
<li class="clothing" id = "gS"><img id="grnShirt" src="../../src/assets/grnshirt.png" /></li>
<li class="clothing" id="tS"><img id="tSweater" src="../../src/assets/tsweater.png" /></li>

<!-- <li></li>
<li></li> -->

</ul>

</template>
<script>



export default {
    name:"Taylor",
    props:{

    },
    methods:{
        changeFit: function(){
            sweater.style.display = none;
        }

    }


}
function changeFit(){

}
//  var clothes = new Array();
const greenDress = document.getElementById("gD");
const greenShirt = document.getElementById("gS");
const sweater = document.getElementById("tS");
// clothes[0] = greenDress;
// clothes[1] = greenShirt;
// clothes[2] = sweater;
 console.warn(sweater);

// sweater.style.display = 'none'
let startingFitIndex = Math.floor(Math.random() * (2 - 0 + 1) + 0);

// sweater.style.display = 'block';


// for(let i = 0; i < clothes.length-1; i++)
// {
// if(clothes[i]=== currentClothes)
// {
//     clothes[i].style.display = "block";
// }
// else
// {
//     clothes[i].style.display = "none";
// }

// }


// function changeFit(){


    
  
    
// }

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
    width: 61vw;
   
    font-family: Righteous;

 
    padding-top: 60px;



    font-size: 25px;
    font-weight: 100;
    color: rgba(235, 52, 137, 1);

    letter-spacing: 0px;
    text-shadow: 1px 1px 2px rgba(140, 0, 77, 1);



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

 
    padding-top: 200px;
}
#leftClothesArrow{
     text-align: left;
     transform: translate(60px);   
}
#rightClothesArrow{
        text-align: right;
        width: 270px;
        
       
        
}
</style>