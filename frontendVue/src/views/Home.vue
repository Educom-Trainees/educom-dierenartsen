<template>
  <div>
    <TopNavigation />
    <Carousel />
    <div class="container">
      <div class="row">
        <div class="col-10 col-md-8">
          <h1 class="text-lg">Topzorg voor uw huisdier, dat krijgt u bij ons!</h1>
          <h2 class="text-md mb-4">Uw huisdier is bij ons in goede handen</h2>
          <p class="text-sm">
            Als dierenarts dragen wij de verantwoordelijkheid voor de gezondheid
            van uw huisdier. Wij willen er samen met u voor zorgen dat uw hond,
            kat, konijn of welk ander huisdier dan ook in optimale gezondheid van
            zijn of haar leven kan genieten. Om daarvoor te zorgen zetten wij
            alles op alles. Onze kliniek heeft twee ervaren dierenartsen die uw
            huisdier optimaal kunnen verzorgen. Van het schoonmaken van de tanden
            of het knippen van de nagels tot het castreren of steriliseren van uw
            huisdier. Maak gerust een afspraak, dan kunnen we de beste zorg bieden
            voor uw huisdier
          </p>
          <p class="text-sm">
            U bent van harte welkom, Tot ziens in Dierenkliniek HappyPaws Zeist
          </p>
        </div>
        <div class="col-10 col-md-4">
          <img src="/flyer-HappyPaw.png" class="d-block w-100 h-100" alt="" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import TopNavigation from "../components/TopNavigation.vue";
import Carousel from "../components/Carousel.vue";

export default {
  name: "Home",
  components: {
    Carousel,
    TopNavigation,
  },
};
</script>

<style>
.container * {
  text-align: left;
}
.container {
  margin-top: 20px;
  margin-bottom: 20px;
}
</style>