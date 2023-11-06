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
  .blue {
    color: #39A7FF;
  }
  .blue-l {
    color: #67C4FF;
  }
</style>
