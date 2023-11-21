<template>
    <TopNavigation />
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <h1>{{ header }}</h1>
                <div class="subhead">{{ subHeaders[0] }}</div>

                <div class="chooseDate d-flex justify-content-around">
                    <div @click="previousDate" class="box d-flex justify-content-center align-items-center">
                        <button class="btn move-date">&lt;</button>
                    </div>
                    <div v-for="day in upcomingDates">
                        <DatePicker :date="day" /> 
                    </div>
                    <div @click="nextDate" class="box d-flex justify-content-center align-items-center">
                        <button class="btn move-date">&gt;</button>
                    </div>
                </div>

            </div>
        </div>
    </div>
</template>

<script>
import TopNavigation from '../components/TopNavigation.vue'
import DatePicker from '../components/DatePicker.vue'
import { getAppoinmentById, GetActiveAppointmentsByDate } from '../composables/appointmentManager.js'
import { GetAllTimeslots } from '../composables/timeslotManager.js'
import { previousDate, nextDate, addDays } from '../composables/datetime-utils.js'
import { combineTimeslotAppointments, getFreeTimeslots } from '../composables/arrayTransfromer.js'

export default {
    name: 'ChangeAppointment',
    components: {
        TopNavigation,
        DatePicker
    },
    created() {
        this.getAppointment(this.$route.params.id)
    },
    data() {
        return {
            header: 'Afspraak wijzigen',
            subHeaders: ['Kies een datum'],
            today: new Date(),
            date: new Date(),
            upcomingDates: [],
            appointment: [],
        }
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
        async getAppointment(id) {
            this.appointment = await getAppoinmentById(id)
        },
        getFreeTimeslots(date) {
            const timeslots = GetAllTimeslots()
            const timeslotsDoc1 = timeslots.filter(t => t.doctor == 1 || t.doctor == 3)
            const timeslotsDoc2 = timeslots.filter(t => t.doctor == 2 || t.doctor == 3)
            const appointments = GetActiveAppointmentsByDate(date)
            const appointmentsDoc1 = appointments.filter(a => a.doctor == 1 || a.doctor == 3)
            const appointmentsDoc2 = appointments.filter(a => a.doctor == 2 || a.doctor == 3)
            const newArrayDoc1 = combineTimeslotAppointments(timeslotsDoc1, appointmentsDoc1)
            const newArrayDoc2 = combineTimeslotAppointments(timeslotsDoc2, appointmentsDoc2)
            const freeTimeslotsDoc1 = getFreeTimeslots(newArrayDoc1, this.appointment.duration)
            const freeTimeslotsDoc2 = getFreeTimeslots(newArrayDoc2, this.appointment.duration)
        },
    },
    computed: {
        upcomingDates() {
            var nextFewDays = []
            for (let i = 0; i < 5; i++) {
                nextFewDays.push(addDays(this.date, i))
            }
            return nextFewDays
        },
        upcomingArrays() {
            var array = []
            for (let i = 0; i < 5; i++) {
                const newDate = addDays(this.date, i)
                array.push({
                    date: newDate,
                    availableTimeslots: this.getFreeTimeslots(newDate).length !== 0
                })
            }
        }
    }
}
</script>

<style>
.box {
    width: 90px;
    height: 90px;
    background-color: var(--lightGrey);
}
.move-date {
    font-size: 28px;
    font-weight: bolder;
}
</style>