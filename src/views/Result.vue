<template>
  <h1>Afspraak:</h1>
  <h3>afspraak nummer: {{ appointments.nummer }}</h3>
  <h3>naam:</h3>
  <h3>email:</h3>
  <h3>telefoonnummer:</h3>
  <h3>datum:</h3>
  <h3>tijd:</h3>
</template>

<script>
import { ref } from 'vue'
import getAppointments from '../composables/getAppointments'
export default {
  setup() {
    const {appointments, error, load} = getAppointments()
    load()

    const showAppointments = ref(true)
    console.log(appointments)
    return {
      appointments,
      error,
      showAppointments
    }
  }
}
</script>

<style>

</style>