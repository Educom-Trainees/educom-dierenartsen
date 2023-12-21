<template>
  <TopNavigation />
  <div class="container-fluid update-appo">
    <div class="row">
      <div class="col-12">
        <h1>{{ header }}</h1>
      </div>
      <div v-if="showGenericError" class="error text-md">
        <span>{{ genericError }}</span>
      </div>
      <div class="col-12 col-lg-9 ml-2">
        <div class="chooseDate choose-group">
          <h2 class="subhead">{{ subHeaders[0] }}</h2>
          <div class="d-flex justify-content-between choose">
            <div class="d-flex justify-content-around dates-box">
              <div
                @click="previousDate"
                class="box d-flex justify-content-center align-items-center"
              >
                <button class="btn btn-gt-lt">&lt;</button>
              </div>
              <div
                v-for="day in upcomingDays"
                @click="changeDate(day)"
                :class="{ select: date == day }"
              >
                <DatePicker :day="day" :date="date" />
              </div>
              <div
                @click="nextDate"
                class="box d-flex justify-content-center align-items-center"
              >
                <button class="btn btn-gt-lt">&gt;</button>
              </div>
            </div>
            <div class="agenda-box d-flex align-items-center">
              <AgendaBox />
            </div>
          </div>
        </div>
        <!---->
        <div class="chooseDoctor choose-group">
          <h2 class="subhead">{{ subHeaders[1] }}</h2>
          <div class="choose">
            <button
              @click="changeDoctorPreference(0)"
              type="button"
              :class="{ select: preference == 0 }"
            >
              Geen voorkeur
            </button>
            <button
              @click="changeDoctorPreference(1)"
              type="button"
              :class="{ select: preference == 1 }"
            >
              Karel Lant
            </button>
            <button
              @click="changeDoctorPreference(2)"
              type="button"
              :class="{ select: preference == 2 }"
            >
              Danique de Beer
            </button>
          </div>
        </div>
        <!---->
        <div class="chooseTime choose-group">
          <h3 class="subhead">{{ subHeaders[2] }}</h3>
          <div class="choose">
            <div class="w-70 d-flex flex-wrap">
              <button
                v-for="timeslot in freeTimeslots.filter(
                  (t) => t.time < '14:00'
                )"
                :class="{ select: time == timeslot.time }"
                @click="changeTimeslot(timeslot.time, timeslot.doctor)"
              >
                <img style="width: 20%" src="/time.png" />
                {{ timeslot.time }}
              </button>
            </div>
          </div>
          <h3 class="subhead">{{ subHeaders[3] }}</h3>
          <div class="choose">
            <div class="w-70 d-flex flex-wrap">
              <button
                v-for="timeslot in freeTimeslots.filter(
                  (t) => t.time >= '14:00'
                )"
                :class="{ select: time == timeslot.time }"
                @click="changeTimeslot(timeslot.time, timeslot.doctor)"
              >
                <img style="width: 20%" src="/time.png" /> {{ timeslot.time }}
              </button>
            </div>
          </div>
          <div class="d-flex justify-content-end align-items-center p-2">
            <div class="button-group">
              <button @click="backToOverview" class="btn">Terug</button>
              <button @click="saveChanges" class="btn">Opslaan</button>
            </div>
          </div>
        </div>
        <!---->
      </div>
    </div>
  </div>
</template>

<script>
import router from "../router/index.js";
import TopNavigation from "../components/TopNavigation.vue";
import DatePicker from "../components/DatePicker.vue";
import AgendaBox from "../components/AgendaBox.vue";
import {
  getAppoinmentById,
  GetActiveAppointmentsByDate,
  updateAppoinment,
} from "../composables/appointmentManager.js";
import { GetTimeslotsByDate } from "../composables/timeslotManager.js";
import {
  previousDate,
  nextDate,
  addDays,
  skipSundayAndMonday,
  skipMondayAndSunday,
  toDateString,
} from "../composables/datetime-utils.js";
import {
  combineTimeslotAppointments,
  findFreeTimeslots,
  RemoveDuplicates,
} from "../composables/arrayTransfromer.js";
import { getPreferredDoctor } from "../composables/doctorPreferenceService.js";

export default {
  name: "ChangeAppointment",
  components: {
    TopNavigation,
    DatePicker,
    AgendaBox,
  },
  created() {
    this.getAppointment(this.$route.params.id);
    this.getFreeTimeslots(this.date);
  },
  watch: {
    date() {
      this.getFreeTimeslots(this.date);
    },
    preference() {
      this.getFreeTimeslots(this.date);
    },
  },
  data() {
    return {
      showGenericError: false,
      genericError: "Er is iets fout gegaan. Probeer het later opnieuw",
      header: "Afspraak wijzigen",
      subHeaders: ["Kies een datum", "Clinici", "Ochtend", "Namiddag"],
      today: new Date(),
      date: new Date(),
      scrollDate: new Date(),
      time: undefined,
      doctor: undefined,
      preference: 0,
      freeTimeslots: [],
      upcomingDates: [],
      appointment: [],
    };
  },
  methods: {
    saveChanges() {
      try {
        const updatedAppointment = {
          ...this.appointment,
          preference: this.preference,
          doctor: this.doctor,
          date: toDateString(this.date),
          time: this.time,
        };
        updateAppoinment(updatedAppointment);
        router.push("/overview");
      } catch (error) {
        this.showGenericError = true;
        console.error(error);
      }
    },
    backToOverview() {
      try {
        router.push("/overview");
      } catch (error) {
        this.showGenericError = true;
        console.error(error);
      }
    },
    changeDate(date) {
      this.date = date;
    },
    nextDate() {
      this.scrollDate = skipSundayAndMonday(nextDate(this.scrollDate));
    },
    previousDate() {
      if (this.scrollDate > this.today) {
        this.scrollDate = skipMondayAndSunday(previousDate(this.scrollDate));
      }
    },
    async getAppointment(id) {
      try {
        this.appointment = await getAppoinmentById(id);
        this.preference = this.appointment.preference;
        this.doctor = this.appointment.doctor;
        this.time = this.appointment.time;
        this.date = new Date(this.appointment.date);
      } catch (error) {
        this.showGenericError = true;
        console.error(error);
      }
    },
    changeDoctorPreference(preference) {
      this.preference = preference;
    },
    changeTimeslot(time, doctor) {
      this.time = time;
      this.doctor = doctor;
    },

    async getFreeTimeslots() {
      try {
        // Transform date to correct format for backend (YYYY-MM-DD)
        const year = this.date.getFullYear();
        const month = String(this.date.getMonth() + 1).padStart(2, "0");
        const day = String(this.date.getDate()).padStart(2, "0");
        const formattedDate = `${year}-${month}-${day}`;

        const timeslots = await GetTimeslotsByDate(formattedDate);
        const nextValidDate = toDateString(skipSundayAndMonday(this.date));
        const allFreeTimeslots = findFreeTimeslots(timeslots);

        //dit zorgt ervoor dat als het dezelfde dag is als de appointment die je wilt verplaatsen je dan die tijd erbij doet
        if (this.appointment.date == nextValidDate) {
          const currentAppointment = {
            time: this.time,
            appointment: undefined,
            doctor: this.doctor,
            show: true,
          };
          allFreeTimeslots.push(currentAppointment);
          allFreeTimeslots.sort((a, b) => a.time.localeCompare(b.time));
        }

        this.preference === 0
          ? (this.freeTimeslots = RemoveDuplicates(
              allFreeTimeslots,
              getPreferredDoctor(timeslotAppointments)
            ))
          : (this.freeTimeslots = allFreeTimeslots.filter(
              (t) => t.doctor == this.preference
            ));
      } catch (error) {
        this.showGenericError = true;
        console.error(error);
      }
    },
  },
  computed: {
    upcomingDays() {
      var upcomingDates = [];
      var skip = 0;
      for (var i = 0; i < 5; i++) {
        var newDate = addDays(this.scrollDate, i + skip);
        if (newDate.getDay() == 0) {
          skip = 2;
          newDate = addDays(newDate, skip);
        } else if (newDate.getDay() == 1) {
          skip = 1;
          newDate = addDays(newDate, skip);
        }
        upcomingDates.push(newDate);
      }
      return upcomingDates;
    },
  },
};
</script>

<style>
.update-appo button {
  margin-bottom: 0;
}
.subhead {
  padding: 0.5rem;
  margin-bottom: 0;
}
.choose {
  background-color: var(--darkGrey);
  padding: 1rem;
}
.dates-box {
  width: 700px;
  margin-left: 40px;
}
.agenda-box {
  margin-left: 50px;
}
.choose-group {
  padding: 8px;
}
.chooseDate .btn-gt-lt {
  background-color: white;
}
.chooseDate,
.chooseDoctor,
.chooseTime {
  background-color: var(--lightGrey);
}
.chooseDate button,
.chooseDoctor button,
.chooseTime button {
  font-weight: bolder;
}
.chooseDate #box {
  width: 90px;
  height: 90px;
  background-color: white;
}
.chooseDate button {
  font-size: 28px;
}
.chooseDoctor button {
  height: 40px;
  width: 150px;
  margin-left: 40px;
  border: none;
  text-align: center;
}
.select {
  color: white;
  background-color: var(--happyPaw4) !important;
}
.chooseTime button {
  height: 40px;
  width: 110px;
  margin-left: 40px;
}
.chooseTime .w-70 {
  width: 70%;
  row-gap: 16px;
}
.update-appo .button-group {
  margin-right: 160px;
}
.update-appo .button-group .btn {
  background-color: var(--happyPaw2);
  color: white;
  text-align: center;
}
</style>