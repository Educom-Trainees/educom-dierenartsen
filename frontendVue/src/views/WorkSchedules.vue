<template>
  <TopNavigation />
  <button class="btn submit-btn mt-4" v-if="showKarel" @click="toggleDoctor">
    Karel Lant
  </button>
  <button class="btn submit-btn mt-4" v-else @click="toggleDoctor">
    Danique de Beer
  </button>

  <div
    id="datepicker-area"
    class="d-flex justify-content-center align-items-center"
  >
    <div class="datepicker-container">
      <label for="begin-date">Vanaf datum:</label>
      <input
        type="date"
        class="form-control datepicker"
        id="begin-date"
        v-model="startDate"
      />
    </div>
  </div>
  <h3>Klik je nieuwe werkschema aan:</h3>
  <div class="week">
    <div class="weekday">
      <h3>Maandag</h3>
      <button
        @click="toggleCustomClass('button1')"
        :class="{
          'button-selected': isCustomClassAdded['button1'],
          btn: true,
          'btn-light': true,
        }"
      >
        Ochtend</button
      ><button
        @click="toggleCustomClass('button2')"
        :class="{
          'button-selected': isCustomClassAdded['button2'],
          btn: true,
          'btn-light': true,
        }"
      >
        Middag
      </button>
    </div>
    <div class="weekday">
      <h3>Dinsdag</h3>
      <button
        @click="toggleCustomClass('button3')"
        :class="{
          'button-selected': isCustomClassAdded['button3'],
          btn: true,
          'btn-light': true,
        }"
      >
        Ochtend</button
      ><button
        @click="toggleCustomClass('button4')"
        :class="{
          'button-selected': isCustomClassAdded['button4'],
          btn: true,
          'btn-light': true,
        }"
      >
        Middag
      </button>
    </div>
    <div class="weekday">
      <h3>Woensdag</h3>
      <button
        @click="toggleCustomClass('button5')"
        :class="{
          'button-selected': isCustomClassAdded['button5'],
          btn: true,
          'btn-light': true,
        }"
      >
        Ochtend</button
      ><button
        @click="toggleCustomClass('button6')"
        :class="{
          'button-selected': isCustomClassAdded['button6'],
          btn: true,
          'btn-light': true,
        }"
      >
        Middag
      </button>
    </div>
    <div class="weekday">
      <h3>Donderdag</h3>
      <button
        @click="toggleCustomClass('button7')"
        :class="{
          'button-selected': isCustomClassAdded['button7'],
          btn: true,
          'btn-light': true,
        }"
      >
        Ochtend</button
      ><button
        @click="toggleCustomClass('button8')"
        :class="{
          'button-selected': isCustomClassAdded['button8'],
          btn: true,
          'btn-light': true,
        }"
      >
        Middag
      </button>
    </div>
    <div class="weekday">
      <h3>Vrijdag</h3>
      <button
        @click="toggleCustomClass('button9')"
        :class="{
          'button-selected': isCustomClassAdded['button9'],
          btn: true,
          'btn-light': true,
        }"
      >
        Ochtend</button
      ><button
        @click="toggleCustomClass('button10')"
        :class="{
          'button-selected': isCustomClassAdded['button10'],
          btn: true,
          'btn-light': true,
        }"
      >
        Middag
      </button>
    </div>
  </div>
  <button @click="openModal()" class="btn submit-btn mt-4 save-button">
    Opslaan
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
</template>

<script>
import AppointmentDateandTime from "../components/AppointmentDateandTime.vue";
import TopNavigation from "../components/TopNavigation.vue";
import { displayFullDate } from "../composables/datetime-utils.js";
import Modal from "../components/Modal.vue";

export default {
  name: "work-schedules",
  components: { TopNavigation, AppointmentDateandTime, Modal },
  data() {
    return {
      showKarel: true,
      startDate: new Date().toISOString().slice(0, 10),
      displayFullDate: displayFullDate,
      header: "Weet u het zeker?",
      text: "U staat op het punt het werkschema voor [dokter] aan te passen vanaf [datum]",
      showModal: false,
      acceptPropositionText: "Schema doorvoeren",
      declinePropositionText: "Terug",
      isCustomClassAdded: {
        button1: false,
        button2: true,
        button3: true,
        button4: true,
        button5: true,
        button6: true,
        button7: true,
        button8: true,
        button9: true,
        button10: true,
      },
      selectedDayparts: [
        {
          weekDay: 1,
          dayPart: 1,
        },
        {
          weekDay: 1,
          dayPart: 2,
        },
        {
          weekDay: 2,
          dayPart: 1,
        },
        {
          weekDay: 2,
          dayPart: 2,
        },
        {
          weekDay: 3,
          dayPart: 1,
        },
        {
          weekDay: 3,
          dayPart: 2,
        },
        {
          weekDay: 4,
          dayPart: 1,
        },
        {
          weekDay: 4,
          dayPart: 2,
        },
        {
          weekDay: 5,
          dayPart: 1,
        },
        {
          weekDay: 5,
          dayPart: 2,
        },
      ],
    };
  },
  methods: {
    toggleDoctor() {
      this.showKarel = !this.showKarel;
    },
    toggleCustomClass(buttonKey) {
      this.isCustomClassAdded[buttonKey] = !this.isCustomClassAdded[buttonKey];
    },
    openModal() {
      this.showModal = true;
    },
    closeModal() {
      this.showModal = false;
    },
  },
};
</script>

<style>
.datepicker {
  width: 40%;
  margin: auto;
  cursor: pointer;
}

.datepicker-container {
  width: 340px;
}

.week {
  display: flex;
  flex-direction: row;
  gap: 10px;
  padding: 0 10px;
  position: relative;
  width: 100%;
  height: 100%;

  @media only screen and (max-width: 600px) {
    flex-direction: column;
  }
}

.weekday {
  margin-top: 10px;
  display: flex;
  flex-direction: column;
  gap: 5px;
  width: 100%;
  height: 100%;
}

.button-selected {
  background-color: #52565a !important;
  color: white;
}

.save-button {
  margin-top: 40px !important;
}
</style>