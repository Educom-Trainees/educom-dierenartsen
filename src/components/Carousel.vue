<template>
    <div id="carouselExample" class="carousel slide">
        <div class="carousel-inner">
        <div class="carousel-item active">
            <img src="../assets/slide-3.jpg" class="d-block w-100" alt="...">
        </div>
        <div class="carousel-item">
            <img src="../assets/slide-2.jpg" class="d-block w-100" alt="...">
        </div>
        <div class="carousel-item">
            <img src="../assets/slide-1.jpg" class="d-block w-100" alt="...">
        </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
        </button>
    </div>
</template>
<script>
//dit was voor het automatisering van de carousel maar het breekt elke pagina behalve de de homepagina en het ziet er niet zo mooi 
//uit als normaal maar misschien kunnen jullie hier nog iets mee

// document.addEventListener("DOMContentLoaded", function() {
//     let i = 0;
//     showSlides();

//     function showSlides() {
//         if(i == 3){
//             i = 0
//         }
//         let slides = document.getElementsByClassName("carousel-item");
//         slides[i].className = slides[i].className.replace(" active", "")

//         if(i+1 == 3){
//             slides[0].className += " active"
//         }else{
//             slides[i+1].className += " active"
//         }
//         i++
//         setTimeout(showSlides, 5000); // Change image every 3 seconds
//     }
// });
</script>

<style>
    .carousel-item img {
        max-height: 400px;
    }
</style>