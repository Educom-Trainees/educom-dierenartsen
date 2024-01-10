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
            <td class="timeslot hidden" v-else>{{ timeslot.time }}</td>

            <td v-if="timeslot.appointment" class="has-event" :rowspan="timeslot.appointment.duration/15">
                <OverviewAppointment :id="timeslot.appointment.id" 
                    draggable="true" @dragstart="drag" 
                    @dragover="allowDrop" @drop="drop"
                    :appointment="timeslot.appointment" :doctorId="doctorId" :color="color"/>
            </td>
            <td v-else-if="timeslot.available === 0" :style="{ 'background-color': 'black' }"></td>
            <td v-else-if="timeslot.available === 3" :style="{ 'background-color': 'rgba(255, 0, 0, 0.5)' }"></td>
            <td v-else-if="timeslot.show" @dragover="allowDrop" @drop="drop" class="no-event" rowspan="1"></td>
        </tr>
    </table>
</template>

<script>
import AppointmentDetail from './AppointmentDetail.vue'
import OverviewAppointment from './OverviewAppointment.vue'
import { calculateEndTime } from '../composables/datetime-utils.js'
import { combineTimeslotAppointments } from '../composables/arrayTransfromer.js'
import { getTimeslotsByDate } from "../composables/timeslotManager.js";
import { getAppoinmentById, updateAppoinment } from '../composables/appointmentManager.js'
import router from '@/router'

export default {
    name: 'Calendar',
    components: {
        AppointmentDetail, OverviewAppointment
    },
    props: ['doctor', 'doctorId', 'appointments', 'date', 'color'],
    data() {
        return {
            //tslot: TIMESLOTS.map(t => { return {'time': t, 'doctor': this.doctorId }}),
            timeslotsDoctor: [],
            calculateEndTime: calculateEndTime,
            lastDraggedAppointmentId: 0,
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
        },
        drag(event) {
            event.target.closest('td').rowSpan = 1
            event.dataTransfer.setData('text', event.target.id)
            this.lastDraggedAppointmentId = event.target.id
        },
        allowDrop(event) {
            event.preventDefault()
        },
        async drop(event) {
            event.preventDefault()

            const data = event.dataTransfer.getData('text')
            event.target.append(document.getElementById(data))

            event.target.classList.remove('no-event')
            event.target.classList.add('has-event')

            await this.dragAndDropAppointment(event)
            
            router.go(0)
        },
        async dragAndDropAppointment(event) {
            var appointment = await getAppoinmentById(this.lastDraggedAppointmentId)
            const newStartTime = event.target.closest('tr').getElementsByClassName('timeslot')[0].innerHTML
            appointment.time = newStartTime

            await updateAppoinment(appointment)
        },
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
            return combineTimeslotAppointments(this.timeslotsDoctor, app)
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
.table .hidden {
    color: transparent;
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