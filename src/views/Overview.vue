<template>
    <div class="container-fluid">
    <div class="row">
        <div class="col-12">
            <h1 class="text-lg text-left">Overzicht afspraken</h1>

            <div id="datepicker-area" class="d-flex justify-content-center align-items-center">
                <div class="btn-group" role="group" aria-label="datepicker">
                    <button @click="()=>{ if (date > today) { previousDate() } }" type="button" class="btn btn-secondary active">&lt;</button>
                    <button type="button" class="btn btn-secondary">{{ displayDate(date) }}</button>
                    <button @click="nextDate()" type="button" class="btn btn-secondary active">&gt;</button>
                </div>
            </div>
        </div>
    </div>
    <div class="row flex-column flex-lg-row">
        <div class="col-12 col-lg-6">
            <Calendar doctor='Karel Lant' doctorId="1" :timeslots="timeslots" :appointments="appointments" color="#38B6FF" />
        </div>
        <div class="col-12 col-lg-6">
            <Calendar doctor='Danique de Beer' doctorId="2" :timeslots="timeslots" :appointments="appointments" color="#C1FF72"/>
        </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import Calendar from '../components/Calendar.vue'

const testDate = '2023-11-10'
const today = new Date(testDate)
const baseUrlActiveAppointments = 'http://localhost:3000/appointments?status=0&date='
const timeslots = [
    "09:00","09:15","09:30","09:45","10:00","10:15","10:30","10:45","11:00",
    "11:15","11:30","11:45","12:00","12:15","12:30","12:45","13:00","13:15",
    "13:30","13:45","14:00","14:15","14:30","14:45","15:00","15:15","15:30",
    "15:45","16:00","16:15","16:30","16:45","17:00","17:15"
]

export default {
    name: 'Overview',
    components: {
        Calendar,
    },
    mounted() {
        this.getAppointments(this.toDateString(this.date))
    },
    data() {
        return {
            today: today,
            date: new Date(testDate),
            timeslots: timeslots,
            appointments: [],
        }
    },
    methods: {
        displayDate(date) {
            const weekdays = ['Zondag','Maandag','Dinsdag','Woensdag','Donderdag','Vrijdag','Zaterdag']
            const months = ['Januari','Februari','Maart','April','Mei','Juni','Juli','Augustus','September','Oktober','November','December']
            const weekday = weekdays[date.getDay()]
            const day = String(date.getDate()).padStart(2, '0')
            const month = months[date.getMonth()]
            const year = date.getFullYear()
            return `${weekday}, ${day} ${month} ${year}`

        },
        toDateString(date) {
            const year = date.getFullYear()
            const month = String(date.getMonth() + 1).padStart(2, '0')
            const day = String(date.getDate()).padStart(2, '0')
            return `${year}-${month}-${day}`
        },
        nextDate() {
            this.date = new Date(this.date)
            this.date.setDate(this.date.getDate() + 1)
        },
        previousDate() {
            this.date = new Date(this.date)
            this.date.setDate(this.date.getDate() - 1)
        }, 
        getAppointments(dateString) {
            const url = baseUrlActiveAppointments + dateString
            axios.get(url)
                .then(response => this.appointments = response.data)
                .catch(error => console.log('Error getting appointments:', error))
        },
    }, 
}
</script>

<style>
.container-fluid * {
    text-align: left;
}
.container-fluid h1 {
    padding: 8px;
}
.col-12 {
    padding: 0;
}
#datepicker-area {
    min-height: 70px;
    background-color: var(--darkGrey);
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