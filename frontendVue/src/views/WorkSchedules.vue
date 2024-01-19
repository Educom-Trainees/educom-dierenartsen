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
      <button class="btn btn-secondary">Ochtend</button
      ><button class="btn btn-secondary">Middag</button>
    </div>
    <div class="weekday">
      <h3>Dinsdag</h3>
      <button class="btn btn-secondary">Ochtend</button
      ><button class="btn btn-secondary">Middag</button>
    </div>
    <div class="weekday">
      <h3>Woensdag</h3>
      <button class="btn btn-secondary">Ochtend</button
      ><button class="btn btn-secondary">Middag</button>
    </div>
    <div class="weekday">
      <h3>Donderdag</h3>
      <button class="btn btn-secondary">Ochtend</button
      ><button class="btn btn-secondary">Middag</button>
    </div>
    <div class="weekday">
      <h3>Vrijdag</h3>
      <button class="btn btn-secondary">Ochtend</button
      ><button class="btn btn-secondary">Middag</button>
    </div>
    <!-- <label>Ochtend</label><br />
    <div v-if="date">
      <div>
        <button
          :class="{ selected_time: time == timeslot.time }"
          id="smallblock"
          @click.prevent="changetimeANDdoctor(timeslot.time, timeslot.doctor)"
          :value="timeslot"
          v-for="timeslot in timeSlots.filter((t) => t.time <= '12:00')"
          :key="timeslot.time"
        >
          <img class="time" src="/time.png" /> {{ timeslot.time }}
        </button>
      </div>
    </div>
    <label>Namiddag</label><br />
    <div v-if="date">
      <div>
        <button
          :class="{ selected_time: time == timeslot.time }"
          id="smallblock"
          @click.prevent="changetimeANDdoctor(timeslot.time, timeslot.doctor)"
          :value="timeslot"
          v-for="timeslot in timeSlots.filter((t) => t.time >= '14:00')"
          :key="timeslot.time"
        >
          <img class="time" src="/time.png" /> {{ timeslot.time }}
        </button>
      </div>
    </div> -->
  </div>
</template>

<script>
import AppointmentDateandTime from "../components/AppointmentDateandTime.vue";
import TopNavigation from "../components/TopNavigation.vue";
import { displayFullDate } from "../composables/datetime-utils.js";

export default {
  name: "work-schedules",
  components: { TopNavigation, AppointmentDateandTime },
  data() {
    return {
      showKarel: true,
      startDate: new Date().toISOString().slice(0, 10),
      timeSlots: [
        {
          time: "09:00",
        },
        { time: "09:15" },
        { time: "09:30" },
        { time: "09:45" },
        {
          time: "10:00",
        },
        { time: "10:15" },
        { time: "10:30" },
        { time: "10:45" },
        {
          time: "11:00",
        },
        { time: "11:15" },
        { time: "11:30" },
        { time: "11:45" },
        {
          time: "12:00",
        },

        { time: "14:15" },
        { time: "14:30" },
        { time: "14:45" },
        {
          time: "15:00",
        },
        { time: "15:15" },
        { time: "15:30" },
        { time: "15:45" },
        {
          time: "16:00",
        },
        { time: "16:15" },
        { time: "16:30" },
        { time: "16:45" },
        {
          time: "17:00",
        },
        { time: "17:15" },
      ],
      displayFullDate: displayFullDate,
    };
  },
  methods: {
    toggleDoctor() {
      this.showKarel = !this.showKarel;
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
</style>