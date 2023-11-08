<template>
  <h1>Afspraak:</h1>
  <h3>afspraak nummer: {{ appointment.number }}</h3>
  <h3>naam: {{ appointment.customer }}</h3>
  <h3>email: {{ appointment.email }}</h3>
  <h3>telefoonnummer: {{ appointment.phoneNumber }}</h3>
  <h3>datum: {{ appointment.date }}</h3>
  <h3>tijd: {{ appointment.time }}</h3>
  <h3 v-if="appointment.doctor == 1">dokter: karel lant</h3>
  <h3 v-if="appointment.doctor == 2">dokter: danique de beer</h3>
  <p>we hopen u dan te zien (: </p>
</template>

<script>
import { ref } from 'vue'
import getAppointment from '../composables/getAppointment'
export default {
  props: ['id'],
  setup(props) {
    const { appointment, error, load } = getAppointment(props.id)

    load()

    return { appointment, error }
  }
  // setup() {

  //   const showAppointments = ref(true)
  //   return {
  //     appointments,
  //     error,
  //     showAppointments
  //   }
  // }
}
</script>

<style>

</style>