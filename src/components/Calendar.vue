<template>
    <table id="overview-calendar" class="table table-bordered table-responsive h-100">
        <tr>
            <th id="th-clock">
                <i class="fa fa-clock-o" aria-hidden="true"></i>
            </th>
            <th id="th-doc">
                <span id="doctor">{{ doctor }}</span>
                <span id="nr-appointment">{{ appointments.filter(a => a.doctor == doctorId || a.doctor == 3).length }}</span>
            </th>
        </tr>
        <tr v-for="item in calculatedTimeslots">
            <td class="timeslot">{{ item.time }}</td>
            <td v-if="item.appointment" class="has-event" :rowspan="item.appointment.duration/15">
                <div class="dropdown">
                    <button class="btn btn-primary" 
                    type="button" id="dropdownMenuButton" data-toggle="dropdown" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false"
                    :style="{ 'height': (25 * (item.appointment.duration/15)) + 'px', 'background-color': color + '!important' }">
                        <span class="appointment-info">{{ item.appointment.customer }} &mdash; {{ item.appointment.time }} - {{ 
                        calculateEndTime(item.appointment.date,item.appointment.time,item.appointment.duration) }}</span>
                    </button>
                    <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                        <AppointmentDetail :appointment="item.appointment" />
                    </div>
                </div>
            </td>
            <td v-else-if="item.show" class="no-event" rowspan="1"></td>
        </tr>
    </table>
</template>

<script>
import AppointmentDetail from './AppointmentDetail.vue'
import { calculateEndTime } from '../composables/datetime-utils.js'
import { combineTimeslotAppointments } from '../composables/arrayTransfromer.js'

export default {
    name: 'Calendar',
    components: {
        AppointmentDetail
    },
    props: ['doctor', 'doctorId', 'timeslots', 'appointments', 'color'],
    data() {
        return {
            tslot: this.timeslots.map(t => { return {'time': t, 'doctor': this.doctorId }}),
            calculateEndTime: calculateEndTime,
        }
    },
    computed: {
        calculatedTimeslots() {
            const app = this.appointments.filter(a => (a.doctor == this.doctorId || a.doctor == 3))
            return combineTimeslotAppointments(this.tslot, app)

        }
        // old computed method, deprecated: 13-11-2023
        // calculatedTimeslots() {
        //     const array = this.timeslots.map(t => {
        //         const a = this.appointments.filter(a => a.time == t && (a.doctor == this.doctorId || a.doctor == 3))
        //         return {
        //             "timeslot": t,
        //             "doctor": this.doctorId,
        //             "appointment": a? a[0] : undefined,
        //             "show": true,
        //         }
        //     })
        //     for (var i = 0; i < array.length; i++) { 
        //         if (array[i].appointment) {
        //             if (array[i].appointment.duration > 15) {
        //                 const r = array[i].appointment.duration / 15
        //                 for (var n = 1; n < r; n++) {
        //                     array[i+n].show = false
        //                 }
        //             }
        //         }
        //     }
        //     return array
        // }
    }
}
</script>

<style>
#overview-calendar {
    margin-bottom: 0 !important;
}
.table #th-doc {
    background-color: var(--lightGrey);
    padding: 0 20px;
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
    width: 10%;
    background-color: var(--darkGrey);
    text-align: center;
    padding: 2px;
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