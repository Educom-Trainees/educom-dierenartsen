<template>
  <form
    @submit.prevent="emitShowForm('showContactForm')"
    class="appointment_form"
  >
    <label>Kies een tijdstip </label><br />
    <div
      id="datepicker-area"
      class="d-flex justify-content-center align-items-center"
    >
      <div class="btn-group" role="group" aria-label="datepicker">
        <button
          @click="previousDate()"
          type="button"
          class="btn btn-secondary active"
        >
          &lt;
        </button>
        <button type="button" class="btn btn-secondary">
          {{ displayFullDate(date) }}
        </button>
        <button
          @click="nextDate()"
          type="button"
          class="btn btn-secondary active"
        >
          &gt;
        </button>
      </div>
    </div>
    <div v-if="closed">De praktijk is vandaag gesloten...</div>
    <div v-if="!closed">
      <label>Clinici</label><br />
      <button
        @click.prevent="changepreference(0)"
        type="button"
        value="0"
        id="block"
        :class="{ selectedblock: preference == 0 }"
      >
        geen voorkeur
      </button>
      <button
        @click.prevent="changepreference(1)"
        type="button"
        value="1"
        id="block"
        :class="{ selectedblock: preference == 1 }"
      >
        karel lant
      </button>
      <button
        @click.prevent="changepreference(2)"
        type="button"
        value="2"
        id="block"
        :class="{ selectedblock: preference == 2 }"
      >
        danique de beer</button
      ><br />
      <label>Ochtend</label><br />
      <div v-if="date">
        <div v-if="this.preference == 0">
          <button
            :class="{ selected_time: time == timeslot.time }"
            id="smallblock"
            @click.prevent="changetimeANDdoctor(timeslot.time, timeslot.doctor)"
            :value="timeslot"
            v-for="timeslot in freeTimeslots.filter((t) => t.time <= '14:00')"
            :key="timeslot.time"
          >
            <img class="time" src="/time.png" /> {{ timeslot.time }}
          </button>
        </div>
        <div v-if="this.preference == 1">
          <button
            :class="{ selected_time: time == timeslot.time }"
            id="smallblock"
            @click.prevent="changetimeANDdoctor(timeslot.time, timeslot.doctor)"
            :value="timeslot"
            v-for="timeslot in freeTimeslots.filter(
              (t) => t.doctor == 1 && t.time <= '14:00'
            )"
            :key="timeslot.time"
          >
            <img class="time" src="/time.png" /> {{ timeslot.time }}
          </button>
        </div>
        <div v-if="this.preference == 2">
          <button
            :class="{ selected_time: time == timeslot.time }"
            id="smallblock"
            @click.prevent="changetimeANDdoctor(timeslot.time, timeslot.doctor)"
            :value="timeslot"
            v-for="timeslot in freeTimeslots.filter(
              (t) => t.doctor == 2 && t.time <= '14:00'
            )"
            :key="timeslot.time"
          >
            <img class="time" src="/time.png" /> {{ timeslot.time }}
          </button>
        </div>
      </div>
      <label>Namiddag</label><br />
      <div v-if="date">
        <div v-if="this.preference == 0">
          <button
            :class="{ selected_time: time == timeslot.time }"
            id="smallblock"
            @click.prevent="changetimeANDdoctor(timeslot.time, timeslot.doctor)"
            :value="timeslot"
            v-for="timeslot in freeTimeslots.filter((t) => t.time >= '14:00')"
            :key="timeslot.time"
          >
            <img class="time" src="/time.png" /> {{ timeslot.time }}
          </button>
        </div>
        <div v-if="this.preference == 1">
          <button
            :class="{ selected_time: time == timeslot.time }"
            id="smallblock"
            @click.prevent="changetimeANDdoctor(timeslot.time, timeslot.doctor)"
            :value="timeslot"
            v-for="timeslot in freeTimeslots.filter(
              (t) => t.doctor == 1 && t.time >= '14:00'
            )"
            :key="timeslot.time"
          >
            <img class="time" src="/time.png" /> {{ timeslot.time }}
          </button>
        </div>
        <div v-if="this.preference == 2">
          <button
            :class="{ selected_time: time == timeslot.time }"
            id="smallblock"
            @click.prevent="changetimeANDdoctor(timeslot.time, timeslot.doctor)"
            :value="timeslot"
            v-for="timeslot in freeTimeslots.filter(
              (t) => t.doctor == 2 && t.time >= '14:00'
            )"
            :key="timeslot.time"
          >
            <img class="time" src="/time.png" /> {{ timeslot.time }}
          </button>
        </div>
      </div>
    </div>
    <div class="button-container">
      <button @click.prevent="emitShowForm('showForm')" class="back">
        vorige
      </button>
      <button class="submit">volgende</button>
    </div>
  </form>
</template>

<script>
import {
  displayFullDate,
  previousDate,
  nextDate,
} from "../composables/datetime-utils.js";
import { findFreeTimeslots } from "../composables/arrayTransfromer.js";
import { getTimeslotsByDate } from "../composables/timeslotManager.js";
import { SLOT_AVAILABILITY } from "../utils/slotAvailability.js";
export default {
  props: ["duration", "oldtime", "appointmentDate", "initialPreference"],
  data() {
    return {
      showForm: false,
      showdateForm: true,
      today: new Date(),
      maxdate: new Date(),
      preference: this.initialPreference,
      time: "",
      doctor: "",
      closed: false,
      date: this.appointmentDate,
      freeTimeslots: "",
      emitArray: [],
      displayFullDate: displayFullDate,
    };
  },
  watch: {
    date() {
      this.preparesetup();
    },
    preference() {
      this.preparesetup();
    },
  },
  created() {
    this.maxdate.setMonth(this.maxdate.getMonth() + 2);
    this.time = this.oldtime;
    this.preparesetup();
  },
  methods: {
    emitShowForm(form) {
      this.emitArray = [
        form,
        this.doctor,
        this.time,
        this.preference,
        this.date,
      ];
      this.$emit("showForm", this.emitArray);
    },
    changepreference(preference) {
      this.preference = preference;
    },
    changetimeANDdoctor(time, doctor) {
      this.time = time;
      this.doctor = doctor;
    },
    nextDate() {
      if (this.date < this.maxdate) {
        this.date = nextDate(this.date);
      }
    },
    previousDate() {
      if (this.date > this.today) {
        this.date = previousDate(this.date);
      }
    },
    RemoveDuplicate(array, prefDoctor) {
      const result = [];
      array.forEach((element, index) => {
        if (element == undefined) {
        } else if (
          (array[index + 1] != undefined &&
            element.time == array[index + 1].time) ||
          (array[index - 1] != undefined &&
            element.time == array[index - 1].time)
        ) {
          if (element.doctor != prefDoctor) {
          } else {
            result.push(element);
          }
        } else {
          result.push(element);
        }
      });
      return result;
    },
    async preparesetup() {
      this.freeTimeslots = [];

      const timeslots = await getTimeslotsByDate(this.date);

      this.closed = true;
      timeslots.forEach((t) => {
        if (t.available >= 1 && t.available <= 3) this.closed = false;
      });

      const freeTimeslots = findFreeTimeslots(timeslots);

      if (this.preference == 0) {
        var prefDoctor = 0;
        var sumdoctor1 = 0;
        var sumdoctor2 = 0;
        for (let i = 0; i < freeTimeslots.length; i++) {
          if (freeTimeslots[i] != undefined) {
            if (freeTimeslots[i].doctor == 1) {
              sumdoctor1++;
            } else if (freeTimeslots[i].doctor == 2) {
              sumdoctor2++;
            }
          }
        }
        if (sumdoctor1 >= sumdoctor2) {
          prefDoctor = 1;
        } else if (sumdoctor1 < sumdoctor2) {
          prefDoctor = 2;
        }

        var list = this.RemoveDuplicate(freeTimeslots, prefDoctor);
        this.freeTimeslots = list;
      } else {
        this.freeTimeslots = freeTimeslots;
      }

      // Filter freeTimeslots based on the duration
      if (this.duration) {
          let targetAvailability;
          if (this.duration === 45) {
              targetAvailability = [SLOT_AVAILABILITY.AVAILABLE_45];
          } else if (this.duration === 30) {
              targetAvailability = [SLOT_AVAILABILITY.AVAILABLE_30, SLOT_AVAILABILITY.AVAILABLE_45];
          } else if (this.duration === 15) {
              targetAvailability = [SLOT_AVAILABILITY.AVAILABLE_15, SLOT_AVAILABILITY.AVAILABLE_30, SLOT_AVAILABILITY.AVAILABLE_45];
          }
          this.freeTimeslots = this.freeTimeslots.filter(timeslot => targetAvailability.includes(timeslot.available));
      }
    },
  },
};
</script>

<style>
</style>