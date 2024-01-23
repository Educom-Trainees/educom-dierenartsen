<template>
  <div>
    <TopNavigation />
    <div class="container-fluid">
      <!-- Header Section -->
      <div class="row d-flex justify-content-center">
        <div class="col-12 col-lg-10 text-center">
          <h1 class="text-lg">Overzicht afspraken</h1>
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
        </div>
      </div>

      <!-- Calendar Section -->
      <div class="row d-flex justify-content-center pb-5">
        <div class="col-12 col-lg-5">
          <Calendar
            doctor="Karel Lant"
            doctorId="1"
            :appointments="appointments"
            :date="date"
            color="#A0E9FF"
          />
        </div>
        <div class="col-12 col-lg-5">
          <Calendar
            doctor="Danique de Beer"
            doctorId="2"
            :appointments="appointments"
            :date="date"
            color="#C1FF72"
          />
        </div>
      </div>
    </div>
  </div>
</template>
  

<script>
import TopNavigation from "../components/TopNavigation.vue";
import Calendar from "../components/Calendar.vue";
import {
  displayFullDate,
  toDateString,
  nextDate,
  previousDate,
} from "../composables/datetime-utils.js";
import { getActiveAppointmentsByDate } from "../composables/appointmentManager.js";
import { computed } from "vue";

export default {
  name: "Overview",
  components: {
    Calendar,
    TopNavigation,
  },
  async beforeRouteEnter(to, from, next) {
    //always send date to today for now, can use query in the future to send to correct date of change
    const date = to.query.date || toDateString(new Date());
    const appointments = await getActiveAppointmentsByDate(date);
    next(vm => {
      vm.appointments = appointments;
    });
  },
  mounted() {
    this.getAppointments(this.toDateString(this.date));
  },
  data() {
    return {
      today: new Date(),
      date: new Date(),
      appointments: [],
      displayFullDate: displayFullDate,
      toDateString: toDateString,
    };
  },
  watch: {
    date(newDate) {
      this.getAppointments(this.toDateString(newDate));
    },
  },
  methods: {
    nextDate() {
      this.date = nextDate(this.date);
    },
    previousDate() {
      if (this.date > this.today) {
        this.date = previousDate(this.date);
      }
    },
    async getAppointments(date) {
      this.appointments = await getActiveAppointmentsByDate(date);
    },
  },
  provide() {
    return {
      getAppointments: () => this.getAppointments(this.toDateString(this.date)),
      todayAppointments: computed(() => this.appointments),
    };
  },
};
</script>

<style>
.container-fluid {
  padding-left: 0;
}
.container-fluid * {
  text-align: left;
}
.container-fluid h1 {
  padding: 8px;
}
.container-fluid .row {
  margin-left: 0;
}
.col-12 {
  padding: 0;
}
#datepicker-area {
  min-height: 70px;
  background-color: var(--darkGrey);
}
#datepicker-area .btn-group {
  min-width: 325px;
}
#datepicker-area .btn-group,
#datepicker-area .btn-group .btn {
  background-color: var(--lightGrey);
  color: black;
  border: none;
  margin-bottom: 0;
}
#datepicker-area .active {
  font-weight: bold;
}
</style>