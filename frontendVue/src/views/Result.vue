<template>
  <div>
  <TopNavigation />
    <h1 class="appointment_header">Afspraak maken</h1>
    <div class="test">
      <h2><img src="/balk4.png" /></h2>
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
            <div v-for="pet_type in pet_types" :key="pet_type.id">
              <p v-if="pet_type.id == appointment.petType">
                {{ pet_type.name }}
              </p>
            </div>
            <div
              v-for="appointment_type in appointment_types"
              :key="appointment_type.id"
            >
              <p v-if="appointment_type.id == appointment.type">
                {{ appointment_type.name }}
              </p>
            </div>
            <p>{{ displayFullDate(new Date(appointment.date)) }}</p>
            <p>{{ appointment.time }}</p>
            <p v-if="appointment.doctor == 1">karel lant</p>
            <p v-if="appointment.doctor == 2">danique de beer</p>
          </div>
          <div class="appointment_result_pic">
            <img id="computer" src="/dog-computer.jpg" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import TopNavigation from "../components/TopNavigation.vue";
import getAppointment from "../composables/getAppointment";
import getPet_Types from "../composables/getPet_Types";
import getAppointment_types from "../composables/getAppointment_types";
import { displayFullDate } from "../composables/datetime-utils.js";

export default {
  name: "Result",
  components: {
    TopNavigation,
  },
  data() {
    return {
      displayFullDate: displayFullDate,
    };
  },
  props: ["id"],
  setup(props) {
    const { appointment, error, load } = getAppointment(props.id);
    const { pet_types, pet_types_error } = getPet_Types();
    const { appointment_types, appointment_types_error } =
      getAppointment_types();

    load();

    return {
      appointment,
      error,
      pet_types,
      pet_types_error,
      appointment_types,
      appointment_types_error,
    };
  },
};
</script>

<style>
.appointment_result {
  font-size: 1.25rem;
  background-color: white;
  flex: 35%;
}
.appointment_result_pic {
  background-color: white;
  flex: 30%;
}
#computer {
  margin-top: 40%;
  border-radius: 30%;
  height: 60%;
  width: 100%;
}
</style>