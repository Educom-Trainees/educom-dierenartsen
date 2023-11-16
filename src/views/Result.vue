<template>
  <TopNavigation />
  <h1 class="appointment_header">Afspraak maken</h1>
  <div class="test">
    <h2><img src="../assets/balk4.png"></h2>
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
          <p>Dokter</p>
        </div>
        <div class="appointment_result">
          <p>{{ appointment.number }}</p>
          <p>{{ appointment.customer }}</p>
          <p>{{ appointment.phoneNumber }}</p>
          <p>{{ appointment.email }}</p>
          <p v-if="appointment.petType == 1">Hond</p>
          <p v-if="appointment.petType == 2">Kat</p>
          <p v-if="appointment.petType == 3">Konijn</p>
          <p v-if="appointment.petType == 4">Cavia</p>
          <p v-if="appointment.petType == 5">Hamster</p>
          <p v-if="appointment.petType == 6">Rat</p>
          <p v-if="appointment.petType == 7">Muis</p>
        <p v-if="appointment.petType == 8">Kleine hond</p>
        <p v-if="appointment.petType == 9">Grote hond</p>
          <p v-if="appointment.type == 1">Consult</p>
          <p v-if="appointment.type == 2">Eerste consult</p>
          <p v-if="appointment.type == 3">Vaccinatie</p>
          <p v-if="appointment.type == 4">Anaal klieren legen</p>
          <p v-if="appointment.type == 5">Nagels knippen</p>
          <p v-if="appointment.type == 6">Bloed onderzoek</p>
          <p v-if="appointment.type == 7">Urine onderzoek</p>
          <p v-if="appointment.type == 8">Gebitscontrole</p>
          <p v-if="appointment.type == 9">Postoperatieve controle</p>
          <p v-if="appointment.type == 10">Herhaal recept bestellen</p>
          <p>{{ appointment.date }}</p>
          <p>{{ appointment.time }}</p>
          <p v-if="appointment.doctor == 1">karel lant</p>
          <p v-if="appointment.doctor == 2">danique de beer</p>
        </div>
        <div class="appointment_result_pic">
          <img id="computer" src="../assets/dog-computer.jpg">
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import TopNavigation from '../components/TopNavigation.vue'
import getAppointment from '../composables/getAppointment'

export default {
  name: 'Result',
  components: {
    TopNavigation
  },
  props: ['id'],
  setup(props) {
    const { appointment, error, load } = getAppointment(props.id)

    load()

    return { appointment, error }
  }
}
</script>

<style>
#computer{
  height: 100%;
  width: 100%;
}
</style>