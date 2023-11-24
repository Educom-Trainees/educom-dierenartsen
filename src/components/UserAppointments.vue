<template>
    <div class="row justify-content-center align-items-center register-row mb-4">
        <h2 v-if="appointments.length == 0">geen afspraken gevonden</h2>
        <div class="col-sm-3 col-md-5 col-10 change-area" v-for="appointment in appointments" :key="appointment.id">
            <h2 class="usertitle">afspraken</h2>
            <div class="row">
                <div class="col-sm-6 result">
                    <p>Afspraaknummer</p>
                    <p>Datum</p><br>
                    <p>Tijd</p>
                    <p>Afspraak type</p>
                    <p>Clinici</p>
                    <p v-if="appointment.pets[0].name != undefined">Huisdier</p>
                    <p v-if="appointment.pets[0].extra != undefined">Extra info</p>
                    <p v-if="appointment.pets[1].name != undefined">Tweede Huisdier</p>
                    <p v-if="appointment.pets[1].extra != undefined">Extra info</p>
                    <p v-if="appointment.pets[2].name != undefined">Derde Huisdier</p>
                    <p v-if="appointment.pets[2].extra != undefined">Extra info</p>
                    <p v-if="appointment.pets[3].name != undefined">Vierde Huisdier</p>
                    <p v-if="appointment.pets[3].extra != undefined">Extra info</p>
                </div>
                <div class="col-sm-6 result">
                    <p><b>{{ appointment.number }}</b></p>
                    <p><b>{{ displayFullDate(new Date(appointment.date)) }}</b></p>
                    <p><b>{{ appointment.time + ' - ' + addMinutes(appointment.time, appointment.duration) }}</b></p>
                    <div v-for="appointment_type in appointment_types" :key="appointment_type.id">
                        <b><p v-if="appointment_type.id == appointment.type">
                            {{ appointment_type.name }}
                        </p></b>
                    </div>
                    <b><p v-if="appointment.doctor == 1">karel lant</p></b>
                    <b><p v-if="appointment.doctor == 2">danique de beer</p></b>
                    <b><p v-if="appointment.pets[0].name != undefined">{{ appointment.pets[0].name }}</p></b>
                    <b><p v-if="appointment.pets[0].extra != undefined">{{ appointment.pets[0].extra }}</p></b>
                    <b><p v-if="appointment.pets[1].name != undefined">{{ appointment.pets[1].name }}</p></b>
                    <b><p v-if="appointment.pets[1].extra != undefined">{{ appointment.pets[1].extra }}</p></b>
                    <b><p v-if="appointment.pets[2].name != undefined">{{ appointment.pets[2].name }}</p></b>
                    <b><p v-if="appointment.pets[2].extra != undefined">{{ appointment.pets[2].extra }}</p></b>
                    <b><p v-if="appointment.pets[3].name != undefined">{{ appointment.pets[3].name }}</p></b>
                    <b><p v-if="appointment.pets[3].extra != undefined">{{ appointment.pets[3].extra }}</p></b>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { getUserDataFromSession } from '../composables/sessionManager.js'
import { getUserById } from '../composables/userManager.js'
import getAppointments from '../composables/getAppointments'
import { displayFullDate } from '../composables/datetime-utils.js'
import getAppointment_types from '../composables/getAppointment_types'
export default {
    data() {
      return {
          appointments: [],
          appointment_types: [],
          displayFullDate: displayFullDate
        }
    },
    async created() {
        const olduser = getUserDataFromSession()
        const userdata = getUserById(olduser.userId)
        const user = await userdata.then(function(result) {
            var email = result.email
            return {email}
        })

        const { appointments, error, load } = getAppointments()
        const { appointment_types, appointment_types_error } = getAppointment_types()
        await load()
        this.appointment_types = appointment_types
        this.appointments = appointments
        this.appointments = this.appointments.filter(a => a.email == user.email)

    },
    methods: {
        addMinutes(time, minsToAdd) {
            function D(J){ return (J<10? '0':'') + J;};
            var piece = time.split(':');
            var mins = piece[0]*60 + +piece[1] + +minsToAdd;

            return D(mins%(24*60)/60 | 0) + ':' + D(mins%60);  
        }
    }
}
</script>

<style>
.result{
    text-align: left;
}
</style>