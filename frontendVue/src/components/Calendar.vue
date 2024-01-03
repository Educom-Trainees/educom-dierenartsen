<template>
    <table id="overview-calendar" class="table table-bordered table-responsive h-100">
        <tr>
            <th id="th-clock">
                <i class="fa fa-clock-o" aria-hidden="true"></i>
            </th>
            <th id="th-doc">
                <span id="doctor">{{ doctor }}</span>
                <span id="nr-appointment" class="me-2">{{ appointments.filter(a => a.doctor == doctorId || a.doctor == 3).length }}</span>
            </th>
        </tr>
        <tr v-for="(timeslot, index) in calculatedTimeslots" :data-id="timeslot.id" :key="timeslot.id">
            <td class="timeslot" v-if="index % 2 === 0">{{ timeslot.time }}</td>
            <td class="timeslot sr-only" v-else>&nbsp;</td>

            <td v-if="timeslot.appointment" class="has-event" :rowspan="timeslot.appointment.duration/15">
                <div class="dropdown">
                    <button class="btn btn-primary mx-auto text-center" 
                        type="button" 
                        id="dropdownMenuButton" 
                        data-toggle="dropdown" 
                        data-bs-toggle="dropdown" 
                        aria-haspopup="true" 
                        aria-expanded="false"
                        :style="{ 'width': '100%', 'height': (20 * (timeslot.appointment.duration/15)) + 'px', 'background-color': color + '!important' }">
                        <span class="appointment-info">{{ timeslot.appointment.customer }} &mdash; {{ timeslot.appointment.time }} - {{ 
                        calculateEndTime(timeslot.appointment.date,timeslot.appointment.time,timeslot.appointment.duration) }}</span>
                    </button>
                    <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                        <AppointmentDetail :appointment="timeslot.appointment" />
                    </div>
                </div>
            </td>
            <td v-else-if="timeslot.available === 0" :style="{ 'background-color': 'black' }"></td>
            <td v-else-if="timeslot.available === 3" :style="{ 'background-color': 'rgba(255, 0, 0, 0.5)' }"></td>
            <td v-else-if="timeslot.show" class="no-event" rowspan="1"></td>
        </tr>
    </table>
</template>

<script>
import AppointmentDetail from './AppointmentDetail.vue'
import { calculateEndTime } from '../composables/datetime-utils.js'
import { combineTimeslotAppointments } from '../composables/arrayTransfromer.js'
import { getTimeslotsByDate } from "../composables/timeslotManager.js";

export default {
    name: 'Calendar',
    components: {
        AppointmentDetail
    },
    props: ['doctor', 'doctorId', 'appointments', 'date', 'color'],
    data() {
        return {
            //tslot: TIMESLOTS.map(t => { return {'time': t, 'doctor': this.doctorId }}),
            timeslotsDoctor: [],
            calculateEndTime: calculateEndTime,
        }
    },
    methods: {
        async sortTimeslotsPerDoctor() {
            try {
                const allTimeSlots = await getTimeslotsByDate(this.date)
                this.timeslotsDoctor = allTimeSlots.filter(timeslot => timeslot.doctor == this.doctorId)
            } catch (error) {
                console.error('Error fetching timeslots: ', error);
            }
        }

    },
    watch: {
        date: {
            immediate: true,
            handler(newValue) {
                this.sortTimeslotsPerDoctor();
            },
        },
    },
    computed: {
        calculatedTimeslots() {
            const app = this.appointments.filter(a => (a.doctor == this.doctorId || a.doctor == 3))
            // console.log(app)
            // console.log('calculated' + combineTimeslotAppointments(this.timeslotsDoctor, app))
            console.log(combineTimeslotAppointments(this.timeslotsDoctor, app))
            return (combineTimeslotAppointments(this.timeslotsDoctor, app))
        }
    }
}
</script>

<style>
#overview-calendar {
    margin-bottom: 0 !important;
    border-collapse:collapse;
}
td {
    padding: 0;
    margin: 0;
}
.table #th-doc {
    background-color: var(--lightGrey);
    padding: 0;
    margin: 0;
}
.table #th-clock i {
  background-color: var(--darkGrey);
}
.table #th-clock {
  text-align: center;
  font-size: 2rem;
  border-right: 1px solid var(--bs-border-color);
  background-color: var(--darkGrey);
}
.table th #doctor {
  background-color: var(--lightGrey);
  float: left;
  padding: 8px;
}
.table th #nr-appointment {
  float: right;
  display: inline-flex;
  justify-content: center;
  align-items: center;
  border-radius: 50%;
  padding: 0;
  min-width: 40px;
  min-height: 40px;
  background-color: var(--happyPaw1);
  color: white;
}
.table .timeslot {
    border: none;
    border-right: 1px solid var(--bs-border-color);
    width: 5%;
    background-color: var(--darkGrey);
    text-align: center;
    font-weight: bold;
    padding: 5px;
}
.table .has-event .dropdown {
  padding: 0;
}
.table .has-event .dropdown-menu {
  padding: 0;
}
.table .has-event .btn {
  color: black !important;
  padding: 0 16px !important;
  margin: 0 6px;
  border-radius: 20px;
  min-height: 25px;
  border: none;
  width: 93%;
}
.table .appointment-info {
  padding: 8px;
}
#h-2 {
  min-height: 50px;
}
#h-3 {
  min-height: 75px;
}
#h-2 {
  min-height: px;
}
.col-lg-6 {
  padding: 0;
}
</style>