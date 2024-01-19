<template>
  <div>
    <TopNavigation />
    <div
      class="row justify-content-center align-items-center register-row mb-4"
    >
      <h1>Te laat geannuleerde afspraken</h1>
      <div
        class="col-sm-3 col-md-5 col-10 change-area appointment-card"
        v-for="appointment in appointments"
        :key="appointment.id"
      >
        <div>
          <h3 class="canceled">Geannuleerde afspraak</h3>
          <div class="row">
            <div class="col-sm-6 result">
              <p>Afspraaknummer</p>
              <p>Klant</p>
              <p>Datum</p>
              <p>Tijd</p>
            </div>
            <div class="col-sm-6 result">
              <p>
                <b>{{ appointment.number }}</b>
              </p>
              <p>
                <b>{{ appointment.customer }}</b>
              </p>
              <p>
                <b>{{ displayFullDate(new Date(appointment.date)) }}</b>
              </p>
              <p>
                <b>{{
                  appointment.time +
                  " - " +
                  addMinutes(appointment.time, appointment.duration)
                }}</b>
              </p>
            </div>
            <button
              class="btn submit-btn mt-4 cancel-button"
              @click="removeHandledAppointment(appointment)"
            >
              Afspraak verwijderen
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import TopNavigation from "../components/TopNavigation.vue";
import { getAppointments } from "../composables/getAppointments.js";
import { displayFullDate } from "../composables/datetime-utils.js";
import { updateAppoinment } from "../composables/appointmentManager";

export default {
  name: "CanceledAppointments",
  components: {
    TopNavigation,
  },
  async created() {
    const { appointments, error } = await getAppointments();

    this.appointments = appointments?.value.filter((appointment) => {
      return appointment.lateStatus === 1;
    });
  },
  data() {
    return {
      appointments: [],
      displayFullDate: displayFullDate,
    };
  },
  methods: {
    addMinutes(time, minsToAdd) {
      function D(J) {
        return (J < 10 ? "0" : "") + J;
      }
      var piece = time.split(":");
      var mins = piece[0] * 60 + +piece[1] + +minsToAdd;

      return D(((mins % (24 * 60)) / 60) | 0) + ":" + D(mins % 60);
    },
    async removeHandledAppointment(appointment) {
      const updatedAppointment = {
        ...appointment,
        lateStatus: 2,
      };

      await updateAppoinment(updatedAppointment);
      const { appointments, error } = await getAppointments();

      this.appointments = appointments?.value.filter((appointment) => {
        return appointment.lateStatus === 1;
      });
    },
  },
};
</script>

<style>
.canceled {
  color: red;
  padding: 10px;
}

.cancel-button {
  min-width: 200px;
  margin-left: auto;
  margin-right: auto;
}

.appointment-card {
  margin: 20px;
}

h1 {
  padding-top: 20px;
}
</style>
