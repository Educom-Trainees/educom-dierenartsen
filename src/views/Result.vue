<template>
<h1 class="appointment_header">Afspraak maken</h1>
<div class="test">
  <h2 class="">hier komt de balk</h2>
  <div v-if="appointment" class="appointment_form">
    <h3>Afspraak bevestiging</h3>
    <div class="row">
      <div class="appointment_result">
        <p>Afspraak nummer</p>
        <p>Klant</p>
        <p>Mobiel nummer</p>
        <p>Email adres</p>
        <p>Diersoort</p>
        <p>Afspraak type</p>
        <p>Datum</p>
        <p>Tijd</p>
        <p v-if="appointment.doctor == 1"></p>
        <p v-if="appointment.doctor == 2"></p>
      </div>
      <div class="appointment_result">
        <p>{{ appointment.number }}</p>
        <p>{{ appointment.customer }}</p>
        <p>{{ appointment.phoneNumber }}</p>
        <p>{{ appointment.email }}</p>
        <p>{{ appointment.type_animal }}</p>
        <p>{{ appointment.type }}</p>
        <p>{{ appointment.date }}</p>
        <p>{{ appointment.time }}</p>
        <p v-if="appointment.doctor == 1">dokter: karel lant</p>
        <p v-if="appointment.doctor == 2">dokter: danique de beer</p>
      </div>
      <div class="appointment_result_pic">
        <img src="../assets/dog-computer.jpg">
      </div>
    </div>
  </div>
</div>
</template>

<script>
import getAppointment from '../composables/getAppointment'
export default {
  props: ['id'],
  setup(props) {
    const { appointment, error, load } = getAppointment(props.id)

    load()

    return { appointment, error }
  }
}
</script>

<style>

</style>