<template>
  <div>
    <TopNavigation />
    <div>{{ JSON.stringify(hallo, null, 2) }}</div>
  </div>
</template>

<script>
import TopNavigation from "../components/TopNavigation.vue";
import getAppointments from "../composables/getAppointments.js";
export default {
  name: "CanceledAppointments",
  components: {
    TopNavigation,
  },
  created() {
    const { appointments, error, load } = getAppointments();
    load().then((this.hallo = appointments));
  },
  data() {
    return {
      hallo: [],
    };
  },
  methods: {},
};
</script>

<style>
</style>


//Ik moet hier toegang hebben tot de property isLateCancellation. Die zit in elk appointment object. Die wil ik hier kunnen ophalen. 
als isLateCancellation = true, laat dan de naam? zien. 