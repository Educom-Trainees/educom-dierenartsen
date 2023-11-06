<template>
  <TopNavigation />
  <router-view/>
</template>

<script>
  import TopNavigation from './components/TopNavigation.vue'

  export default {
    components: {
      TopNavigation
    },
}
</script>

<style>
  #app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }
  body {
    margin: 0;
  }
  :root {
    --happyPaw1: #E6BCB2;
    --happyPaw2: #DE9281;
    --happyPaw3: #59371D;
    --happyPaw4: #8F542E;
    --darkGrey: #DDDDDD;
    --lightGrey: #EEEEEE;
  }
  /* .blue {
    color: #39A7FF;
  }
  .blue-l {
    color: #67C4FF;
  } */
  h1 {
    color: var(--happyPaw3)
  }
  h2 {
    color: var(--happyPaw4);
  }
</style>
