<template>
    <TopNavigation />
    <div class="container-fluid">
    <div class="row">
        <div class="col-12">
            <h1 class="text-lg text-left">Overzicht afspraken</h1>

            <div id="datepicker-area" class="d-flex justify-content-center align-items-center">
                <div class="btn-group" role="group" aria-label="datepicker">
                    <button @click="previousDate()" type="button" class="btn btn-secondary active">&lt;</button>
                    <button type="button" class="btn btn-secondary">{{ displayFullDate(date) }}</button>
                    <button @click="nextDate()" type="button" class="btn btn-secondary active">&gt;</button>
                </div>
            </div>
        </div>
    </div>
    <div class="row flex-column flex-lg-row">
        <div class="col-12 col-lg-6">
            <Calendar doctor='Karel Lant' doctorId="1" :appointments="appointments" color="#A0E9FF" />
        </div>
        <div class="col-12 col-lg-6">
            <Calendar doctor='Danique de Beer' doctorId="2" :appointments="appointments" color="#C1FF72" />
        </div>
    </div>
  </div>
</template>

<script>
import TopNavigation from '../components/TopNavigation.vue'
import Calendar from '../components/Calendar.vue'
import { displayFullDate, toDateString, nextDate, previousDate } from '../composables/datetime-utils.js'
import { GetActiveAppointmentsByDate } from '../composables/appointmentManager.js'

export default {
    name: 'Overview',
    components: {
        Calendar, 
        TopNavigation
    },
    mounted() {
        this.getAppointments(this.toDateString(this.date))
    },
    data() {
        return {
            today: new Date(),
            date: new Date(),
            appointments: [],
            displayFullDate: displayFullDate,
            toDateString: toDateString,
        }
    },
    watch: {
        date(newDate) {
            this.getAppointments(this.toDateString(newDate))
        },
    },
    methods: {
        nextDate() {
            this.date = nextDate(this.date)
        },
        previousDate() {
            if (this.date > this.today) {
                this.date = previousDate(this.date)
            }
        }, 
        async getAppointments(date) {
            this.appointments = await GetActiveAppointmentsByDate(date)
        },
    }, 
}
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
#datepicker-area .btn-group, #datepicker-area .btn-group .btn {
    background-color: var(--lightGrey);
    color: black;
    border: none;
    margin-bottom: 0;
}
#datepicker-area .active {
    font-weight: bold;
}
</style>