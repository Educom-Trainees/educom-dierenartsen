<template>
  <TopNavigation />
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
        @click="
          () =>
            addOrRemoveSelectedDayParts(selectedDayparts, {
              weekDay: 1,
              dayPart: 1,
            })
        "
        :class="{
          'button-selected': alreadySelected({
            weekDay: 1,
            dayPart: 1,
          }),
          btn: true,
          'btn-light': true,
        }"
      >
        Ochtend</button
      ><button
        @click="
          () =>
            addOrRemoveSelectedDayParts(selectedDayparts, {
              weekDay: 1,
              dayPart: 2,
            })
        "
        :class="{
          'button-selected': alreadySelected({
            weekDay: 1,
            dayPart: 2,
          }),
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
        @click="
          () =>
            addOrRemoveSelectedDayParts(selectedDayparts, {
              weekDay: 2,
              dayPart: 1,
            })
        "
        :class="{
          'button-selected': alreadySelected({
            weekDay: 2,
            dayPart: 1,
          }),
          btn: true,
          'btn-light': true,
        }"
      >
        Ochtend</button
      ><button
        @click="
          () =>
            addOrRemoveSelectedDayParts(selectedDayparts, {
              weekDay: 2,
              dayPart: 2,
            })
        "
        :class="{
          'button-selected': alreadySelected({
            weekDay: 2,
            dayPart: 2,
          }),
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
        @click="
          () =>
            addOrRemoveSelectedDayParts(selectedDayparts, {
              weekDay: 3,
              dayPart: 1,
            })
        "
        :class="{
          'button-selected': alreadySelected({
            weekDay: 3,
            dayPart: 1,
          }),
          btn: true,
          'btn-light': true,
        }"
      >
        Ochtend</button
      ><button
        @click="
          () =>
            addOrRemoveSelectedDayParts(selectedDayparts, {
              weekDay: 3,
              dayPart: 2,
            })
        "
        :class="{
          'button-selected': alreadySelected({
            weekDay: 3,
            dayPart: 2,
          }),
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
        @click="
          () =>
            addOrRemoveSelectedDayParts(selectedDayparts, {
              weekDay: 4,
              dayPart: 1,
            })
        "
        :class="{
          'button-selected': alreadySelected({
            weekDay: 4,
            dayPart: 1,
          }),
          btn: true,
          'btn-light': true,
        }"
      >
        Ochtend</button
      ><button
        @click="
          () =>
            addOrRemoveSelectedDayParts(selectedDayparts, {
              weekDay: 4,
              dayPart: 2,
            })
        "
        :class="{
          'button-selected': alreadySelected({
            weekDay: 4,
            dayPart: 2,
          }),
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
        @click="
          () =>
            addOrRemoveSelectedDayParts(selectedDayparts, {
              weekDay: 5,
              dayPart: 1,
            })
        "
        :class="{
          'button-selected': alreadySelected({
            weekDay: 5,
            dayPart: 1,
          }),
          btn: true,
          'btn-light': true,
        }"
      >
        Ochtend</button
      ><button
        @click="
          () =>
            addOrRemoveSelectedDayParts(selectedDayparts, {
              weekDay: 5,
              dayPart: 2,
            })
        "
        :class="{
          'button-selected': alreadySelected({
            weekDay: 5,
            dayPart: 2,
          }),
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

export default {
  name: "work-schedules",
  components: { TopNavigation, AppointmentDateandTime, Modal },
  data() {
    return {
      selectedDoctor: 1,
      startDate: new Date().toISOString().slice(0, 10),
      displayFullDate: displayFullDate,
      header: "Weet u het zeker?",
      showModal: false,
      acceptPropositionText: "Bevestigen",
      declinePropositionText: "Terug",
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
        this.selectedDayparts
      );
    },
    alreadySelected(scheduleObject) {
      return this.selectedDayparts.some((obj) =>
        Object.keys(scheduleObject).every(
          (key) => obj[key] === scheduleObject[key]
        )
      );
    },
    addOrRemoveSelectedDayParts(array, scheduleObject) {
      // scheduleobject contains (weekDay & dayPart)

      //checks if the object already exists in array ()
      const existsInArray = array.some((obj) =>
        Object.keys(scheduleObject).every(
          (key) => obj[key] === scheduleObject[key]
        )
      );
      // if object doesn't exist -> add to array
      if (!existsInArray) {
        this.selectedDayparts.push({
          weekDay: scheduleObject.weekDay,
          dayPart: scheduleObject.dayPart,
        });
      } else {
        // remove object from array
        this.selectedDayparts = this.selectedDayparts.filter(
          (obj) =>
            obj.weekDay !== scheduleObject.weekDay &&
            obj.dayPart !== scheduleObject.dayPart
        );
      }
      console.log(this.selectedDayparts);
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