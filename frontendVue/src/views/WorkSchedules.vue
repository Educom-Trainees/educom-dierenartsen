<template>
  <TopNavigation />
  <div class="button-container">
    <button
      :class="{
        'button-selected': selectedDoctor === 1,
        btn: true,
        'btn-light': true,
        'mt-4': true,
      }"
      @click="() => toggleDoctor(1)"
    >
      Karel Lant
    </button>
    <button
      :class="{
        'button-selected': selectedDoctor === 2,
        btn: true,
        'btn-light': true,
        'mt-4': true,
      }"
      @click="() => toggleDoctor(2)"
    >
      Danique de Beer
    </button>
  </div>
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
  <h3 class="mt-4 mb-4">Klik je nieuwe werkschema aan:</h3>
  <div class="week">
    <div class="weekday">
      <h3>Maandag</h3>
      <span class="select-day">
        <label for="works-on-monday">Werkt op maandag: </label>
        <input
          id="works-on-monday"
          v-model="workDays.monday.works"
          type="checkbox"
        />
      </span>
      <div class="timepicker-group" v-if="workDays.monday.works">
        <VueDatePicker
          v-model="workDays.monday.startTime"
          time-picker
          minutes-increment="15"
          locale="nl"
          cancelText="Terug"
          selectText="Bevestigen"
          :min-time="{ hours: 9, minutes: 0o0 }"
          :max-time="{ hours: 17, minutes: 30 }"
          :start-time="workDays.monday.startTime"
          placeholder="Starttijd"
        >
          <template #input-icon>
            <img class="input-slot-image" src="/clock.png" />
          </template>
        </VueDatePicker>
        <VueDatePicker
          v-model="workDays.monday.endTime"
          time-picker
          minutes-increment="15"
          locale="nl"
          cancelText="Terug"
          selectText="Bevestigen"
          :min-time="{ hours: 9, minutes: 0o0 }"
          :max-time="{ hours: 17, minutes: 30 }"
          :start-time="workDays.monday.endTime"
          placeholder="Eindtijd"
        >
          <template #input-icon>
            <img class="input-slot-image" src="/clock.png" />
          </template>
        </VueDatePicker>
      </div>
    </div>
    <div class="weekday">
      <h3>Dinsdag</h3>
      <span class="select-day">
        <label for="works-on-tuesday">Werkt op dinsdag: </label>
        <input
          id="works-on-tuesday"
          v-model="workDays.tuesday.works"
          type="checkbox"
        />
      </span>
      <div class="timepicker-group" v-if="workDays.tuesday.works">
        <VueDatePicker
          v-model="workDays.tuesday.startTime"
          time-picker
          minutes-increment="15"
          locale="nl"
          cancelText="Terug"
          selectText="Bevestigen"
          :min-time="{ hours: 9, minutes: 0o0 }"
          :max-time="{ hours: 17, minutes: 30 }"
          :start-time="workDays.tuesday.startTime"
          placeholder="Starttijd"
        >
          <template #input-icon>
            <img class="input-slot-image" src="/clock.png" />
          </template>
        </VueDatePicker>
        <VueDatePicker
          v-model="workDays.tuesday.endTime"
          time-picker
          minutes-increment="15"
          locale="nl"
          cancelText="Terug"
          selectText="Bevestigen"
          :min-time="{ hours: 9, minutes: 0o0 }"
          :max-time="{ hours: 17, minutes: 30 }"
          :start-time="workDays.tuesday.endTime"
          placeholder="Eindtijd"
        >
          <template #input-icon>
            <img class="input-slot-image" src="/clock.png" />
          </template>
        </VueDatePicker>
      </div>
    </div>
    <div class="weekday">
      <h3>Woensdag</h3>
      <span class="select-day">
        <label for="works-on-wednesday">Werkt op woensdag: </label>
        <input
          id="works-on-wednesday"
          v-model="workDays.wednesday.works"
          type="checkbox"
        />
      </span>
      <div class="timepicker-group" v-if="workDays.wednesday.works">
        <VueDatePicker
          v-model="workDays.wednesday.startTime"
          time-picker
          minutes-increment="15"
          locale="nl"
          cancelText="Terug"
          selectText="Bevestigen"
          :min-time="{ hours: 9, minutes: 0o0 }"
          :max-time="{ hours: 17, minutes: 30 }"
          :start-time="workDays.wednesday.startTime"
          placeholder="Starttijd"
        >
          <template #input-icon>
            <img class="input-slot-image" src="/clock.png" />
          </template>
        </VueDatePicker>
        <VueDatePicker
          v-model="workDays.wednesday.endTime"
          time-picker
          minutes-increment="15"
          locale="nl"
          cancelText="Terug"
          selectText="Bevestigen"
          :min-time="{ hours: 9, minutes: 0o0 }"
          :max-time="{ hours: 17, minutes: 30 }"
          :start-time="workDays.wednesday.endTime"
          placeholder="Eindtijd"
        >
          <template #input-icon>
            <img class="input-slot-image" src="/clock.png" />
          </template>
        </VueDatePicker>
      </div>
    </div>
    <div class="weekday">
      <h3>Donderdag</h3>
      <span class="select-day">
        <label for="works-on-thursday">Werkt op donderdag: </label>
        <input
          id="works-on-thursday"
          v-model="workDays.thursday.works"
          type="checkbox"
        />
      </span>
      <div class="timepicker-group" v-if="workDays.thursday.works">
        <VueDatePicker
          v-model="workDays.thursday.startTime"
          time-picker
          minutes-increment="15"
          locale="nl"
          cancelText="Terug"
          selectText="Bevestigen"
          :min-time="{ hours: 9, minutes: 0o0 }"
          :max-time="{ hours: 17, minutes: 30 }"
          :start-time="workDays.thursday.startTime"
          placeholder="Starttijd"
        >
          <template #input-icon>
            <img class="input-slot-image" src="/clock.png" />
          </template>
        </VueDatePicker>
        <VueDatePicker
          v-model="workDays.thursday.endTime"
          time-picker
          minutes-increment="15"
          locale="nl"
          cancelText="Terug"
          selectText="Bevestigen"
          :min-time="{ hours: 9, minutes: 0o0 }"
          :max-time="{ hours: 17, minutes: 30 }"
          :start-time="workDays.thursday.endTime"
          placeholder="Eindtijd"
        >
          <template #input-icon>
            <img class="input-slot-image" src="/clock.png" />
          </template>
        </VueDatePicker>
      </div>
    </div>
    <div class="weekday">
      <h3>Vrijdag</h3>
      <span class="select-day">
        <label for="works-on-friday">Werkt op vrijdag: </label>
        <input
          id="works-on-friday"
          v-model="workDays.friday.works"
          type="checkbox"
        />
      </span>
      <div class="timepicker-group" v-if="workDays.friday.works">
        <VueDatePicker
          v-model="workDays.friday.startTime"
          time-picker
          minutes-increment="15"
          locale="nl"
          cancelText="Terug"
          selectText="Bevestigen"
          :min-time="{ hours: 9, minutes: 0o0 }"
          :max-time="{ hours: 17, minutes: 30 }"
          :start-time="workDays.friday.startTime"
          placeholder="Starttijd"
        >
          <template #input-icon>
            <img class="input-slot-image" src="/clock.png" />
          </template>
        </VueDatePicker>
        <VueDatePicker
          v-model="workDays.friday.endTime"
          time-picker
          minutes-increment="15"
          locale="nl"
          cancelText="Terug"
          selectText="Bevestigen"
          :min-time="{ hours: 9, minutes: 0o0 }"
          :max-time="{ hours: 17, minutes: 30 }"
          :start-time="workDays.friday.endTime"
          placeholder="Eindtijd"
        >
          <template #input-icon>
            <img class="input-slot-image" src="/clock.png" />
          </template>
        </VueDatePicker>
      </div>
    </div>
  </div>
  <button @click="openModal()" class="btn submit-btn mt-4 save-button">
    Opslaan
  </button>
  <div v-if="showModal">
    <Modal
      :header="header"
      :text="`U staat op het punt het werkschema voor ${
        selectedDoctor === 1 ? 'Karel Lant' : 'Danique de Beer'
      } aan te passen
    vanaf ${startDate} `"
      :acceptPropositionText="acceptPropositionText"
      :declinePropositionText="declinePropositionText"
      @close="closeModal"
      @accept="confirmScheduleChange"
    />
  </div>
</template>

<script>
import AppointmentDateandTime from "../components/AppointmentDateandTime.vue";
import TopNavigation from "../components/TopNavigation.vue";
import { displayFullDate } from "../composables/datetime-utils.js";
import Modal from "../components/Modal.vue";
import { updateWorkSchedule } from "../composables/workScheduleManager";

import VueDatePicker from "@vuepic/vue-datepicker";
import "@vuepic/vue-datepicker/dist/main.css";

export default {
  name: "work-schedules",
  components: { TopNavigation, AppointmentDateandTime, Modal, VueDatePicker },
  data() {
    return {
      selectedDoctor: 1,
      startDate: new Date().toISOString().slice(0, 10),
      displayFullDate: displayFullDate,
      header: "Weet u het zeker?",
      showModal: false,
      acceptPropositionText: "Bevestigen",
      declinePropositionText: "Terug",
      workDays: {
        monday: {
          works: true,
          startTime: { hours: 9, minutes: 0o0 },
          endTime: { hours: 17, minutes: 30 },
        },
        tuesday: {
          works: true,
          startTime: { hours: 9, minutes: 0o0 },
          endTime: { hours: 17, minutes: 30 },
        },
        wednesday: {
          works: true,
          startTime: { hours: 9, minutes: 0o0 },
          endTime: { hours: 17, minutes: 30 },
        },
        thursday: {
          works: true,
          startTime: { hours: 9, minutes: 0o0 },
          endTime: { hours: 17, minutes: 30 },
        },
        friday: {
          works: true,
          startTime: { hours: 9, minutes: 0o0 },
          endTime: { hours: 17, minutes: 30 },
        },
      },
    };
  },
  methods: {
    toggleDoctor(number) {
      this.selectedDoctor = number;
    },
    openModal() {
      this.showModal = true;
    },
    closeModal() {
      this.showModal = false;
    },
    async confirmScheduleChange() {
      await updateWorkSchedule(
        this.selectedDoctor,
        this.startDate,
        this.workDays
      );
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
  width: auto;
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

.button-container {
  display: flex;
  flex-direction: row;
  gap: 10px;
  justify-content: center;
  align-items: center;
  margin: 0 0 10px 0;
}

.select-day {
  border: 1px solid #ddd;
  padding: 4px 0;
  border-radius: 4px;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-around;
  margin-left: 10px;
  width: 100%;
  height: 40px;
}

.select-day > label {
  font-weight: 200;
}

.timepicker-group {
  display: flex;
  flex-direction: column;
  gap: 5px;
}

.button-selected {
  background-color: #52565a !important;
  color: white;
}

.save-button {
  margin-top: 40px !important;
}

.input-slot-image {
  height: 12px;
  width: 12px;
  position: absolute;
  top: -5px;
  left: 18px;
}
</style>