<template>
  <div class="row justify-content-center align-items-center register-row mb-4">
    <h2 v-if="appointments.length == 0">geen afspraken gevonden</h2>
    <div
      class="col-sm-3 col-md-5 col-10 change-area"
      v-for="appointment in appointments"
      :key="appointment.id"
    >
      <h2 class="usertitle">Afspraken</h2>
      <div class="row">
        <div class="col-sm-6 result">
          <p>Afspraaknummer</p>
          <p>Datum</p>
          <br />
          <p>Tijd</p>
          <p>Afspraak type</p>
          <p>Clinici</p>
          <p
            v-if="appointment.pets[0] && appointment.pets[0].name != undefined"
          >
            Huisdier
          </p>
          <p
            v-if="appointment.pets[0] && appointment.pets[0].extra != undefined"
          >
            Extra info
          </p>
          <p
            v-if="appointment.pets[1] && appointment.pets[1].name != undefined"
          >
            Tweede Huisdier
          </p>
          <p
            v-if="appointment.pets[1] && appointment.pets[1].extra != undefined"
          >
            Extra info
          </p>
          <p
            v-if="appointment.pets[2] && appointment.pets[2].name != undefined"
          >
            Derde Huisdier
          </p>
          <p
            v-if="appointment.pets[2] && appointment.pets[2].extra != undefined"
          >
            Extra info
          </p>
          <p
            v-if="appointment.pets[3] && appointment.pets[3].name != undefined"
          >
            Vierde Huisdier
          </p>
          <p
            v-if="appointment.pets[3] && appointment.pets[3].extra != undefined"
          >
            Extra info
          </p>
        </div>
        <div class="col-sm-6 result">
          <p>
            <b>{{ appointment.number }}</b>
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
          <div
            v-for="appointment_type in appointment_types"
            :key="appointment_type.id"
          >
            <b
              ><p v-if="appointment_type.id == appointment.type">
                {{ appointment_type.name }}
              </p></b
            >
          </div>
          <b><p v-if="appointment.doctor == 1">karel lant</p></b>
          <b><p v-if="appointment.doctor == 2">danique de beer</p></b>
          <template v-for="index in 4">
            <div
              :key="index"
              v-if="shouldRenderPet(appointment.pets[index - 1])"
            >
              <p v-if="appointment.pets[index - 1].name !== undefined">
                {{ appointment.pets[index - 1].name }}
              </p>
              <p v-if="appointment.pets[index - 1].extra !== undefined">
                {{ appointment.pets[index - 1].extra }}
              </p>
            </div>
          </template>
        </div>
      </div>
      <button
        v-if="appointment.status === 0"
        class="btn submit-btn mt-4 appointment-button"
        @click="openModal(appointment)"
      >
        Afspraak annuleren
      </button>
      <button
        v-if="appointment.status !== 0"
        class="btn submit-btn mt-4 text-danger cancelled-text"
        disabled="true"
      >
        Afspraak is geannuleerd
      </button>
      <div v-if="showModal">
        <Modal
          :header="header"
          :text="text"
          :acceptPropositionText="acceptPropositionText"
          :declinePropositionText="declinePropositionText"
          @close="closeModal"
          @accept="cancelAppointment()"
        />
      </div>
    </div>
  </div>
</template>

<script>
import { getUserDataFromSession } from "../composables/sessionManager.js";
import getAppointments from "../composables/getAppointments";
import { displayFullDate } from "../composables/datetime-utils.js";
import getAppointment_types from "../composables/getAppointment_types";
import { updateAppoinment } from "../composables/appointmentManager";
import Modal from "./Modal.vue";
export default {
  components: { Modal },
  data() {
    return {
      header: "Weet u zeker dat u deze afspraak wil annuleren?",
      text: "U kunt de afspraak nu nog kosteloos annuleren. Dit kan tot 24 uur vantevoren.",
      showModal: false,
      acceptPropositionText: "Afspraak annuleren",
      declinePropositionText: "Terug",
      appointments: [],
      appointment_types: [],
      selectedAppointment: null,
      displayFullDate: displayFullDate,
    };
  },
  async created() {
    const { appointment_types, appointment_types_error } =
      getAppointment_types();

    await this.loadAppointments();

    this.appointment_types = appointment_types;
  },
  methods: {
    async loadAppointments() {
      const olduser = getUserDataFromSession();

      const { appointments, _error, load } = getAppointments(
        null,
        null,
        olduser.userId
      );
      await load();

      this.appointments = appointments;
      this.appointments = this.sortAndFilterAppointments(this.appointments);

      // this.appointments = this.appointments.sort((a, b) => {
      //   return a.date < b.date ? 1 : -1;
      // });
    },
    addMinutes(time, minsToAdd) {
      function D(J) {
        return (J < 10 ? "0" : "") + J;
      }
      var piece = time.split(":");
      var mins = piece[0] * 60 + +piece[1] + +minsToAdd;

      return D(((mins % (24 * 60)) / 60) | 0) + ":" + D(mins % 60);
    },
    shouldRenderPet(pet) {
      return pet && pet.name !== undefined;
    },
    async cancelAppointment() {
      const selectedAppointment = this.selectedAppointment;

      if (selectedAppointment) {
        const updatedAppointment = {
          ...selectedAppointment,
          status: 2,
          lateStatus: this.isLateCancellation(selectedAppointment.date)
            ? 1 // is LATE
            : 0, // is NOT_LATE
        };

        await updateAppoinment(updatedAppointment);
        this.loadAppointments();
      }

      this.closeModal();
    },
    openModal(appointment) {
      this.selectedAppointment = appointment;
      if (this.isLateCancellation(appointment.date)) {
        this.text =
          "Er zullen kosten in rekening gebracht worden, omdat deze afspraak binnen 24 uur zou plaatsvinden.";
      } else {
        this.text =
          "U kunt de afspraak nu nog kosteloos annuleren. Dit kan tot 24 uur vantevoren.";
      }
      this.showModal = true;
    },
    closeModal() {
      this.selectedAppointment = null;
      this.showModal = false;
    },
    isLateCancellation(appointmentDate) {
      const date = new Date(appointmentDate);
      const tomorrow = new Date(new Date().setDate(new Date().getDate() + 1));

      return date < tomorrow;
    },
    sortAndFilterAppointments(appointments) {
      const oneYearAgo = new Date(
        new Date().setFullYear(new Date().getFullYear() - 1)
      );

      const filteredAppointments = appointments.filter((appointment) => {
        return new Date(appointment.date) >= oneYearAgo;
        //als deze conditie true returned, dan stopt filter hem in de nieuwe array. Als false, dan weggefilterd.
      });

      return filteredAppointments.sort((a, b) => {
        return a.date < b.date ? 1 : -1;
      });
    },
  },
};
</script>

<style>
.result {
  text-align: left;
}

.appointment-button {
  min-width: 100px;
}

.cancelled-text {
  min-width: 250px;
}
</style>