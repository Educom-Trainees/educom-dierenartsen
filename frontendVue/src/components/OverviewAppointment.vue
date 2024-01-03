<template>
    <div class="dropdown">
        <button class="btn btn-primary mx-auto text-center" 
            type="button" 
            id="dropdownMenuButton" 
            data-toggle="dropdown" 
            data-bs-toggle="dropdown" 
            aria-haspopup="true" 
            aria-expanded="false"
            :style="{ 
                'width': '100%', 
                'height': (20 * (appointment.duration/15)) + 'px', 
                'background-color': color + '!important',
                'border-top-right-radius': (appointment.doctor === 3 && doctorId == 1)? 0 : 20 + 'px',
                'border-bottom-right-radius': (appointment.doctor === 3 && doctorId == 1)? 0 : 20 + 'px',
                'border-top-left-radius': (appointment.doctor === 3 && doctorId == 2)? 0 : 20 + 'px',
                'border-bottom-left-radius': (appointment.doctor === 3 && doctorId == 2)? 0 : 20 + 'px'
            }">
            <span class="appointment-info">{{ appointment.customer }} &mdash; {{ appointment.time }} - {{ 
                calculateEndTime(appointment.date, appointment.time, appointment.duration) }}</span>
        </button>
        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <AppointmentDetail :appointment="appointment" />
        </div>
    </div>
</template>

<script>
import AppointmentDetail from './AppointmentDetail.vue';
import { calculateEndTime } from '../composables/datetime-utils.js';

export default {
    name: 'OverviewAppointment',
    components: { 
        AppointmentDetail,
    },
    props: ['appointment', 'doctorId', 'color'],
    data() {
        return {
            calculateEndTime: calculateEndTime,
        }
    }
}
</script>