<template>
  <div id="carouselExample" class="carousel slide">
    <div class="carousel-inner">
      <div class="carousel-item active">
        <img :src="slide3" class="d-block w-100" alt="..." />
      </div>
      <div class="carousel-item">
        <img :src="slide2" class="d-block w-100" alt="..." />
      </div>
      <div class="carousel-item">
        <img :src="slide1" class="d-block w-100" alt="..." />
      </div>
    </div>
    <button
      class="carousel-control-prev"
      type="button"
      data-bs-target="#carouselExample"
      data-bs-slide="prev"
    >
      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Previous</span>
    </button>
    <button
      class="carousel-control-next"
      type="button"
      data-bs-target="#carouselExample"
      data-bs-slide="next"
    >
      <span class="carousel-control-next-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Next</span>
    </button>
  </div>
</template>
<script>
export default {
  name: "Carousel",
  props: ["slide1", "slide2", "slide3"],
  // data() {
  //   return {
  //     slide1: this.slide1,
  //     slide2: this.slide2,
  //     slide3: this.slide3,
  //   };
  // },
};
</script>

<style>
.carousel-item img {
  max-height: 400px;
}
</style>