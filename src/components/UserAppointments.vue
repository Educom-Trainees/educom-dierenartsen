<template>
    <div class="row justify-content-center align-items-center register-row mb-4">
        <h2 v-if="appointments.length == 0">geen afspraken gevonden</h2>
        <div class="col-sm-3 col-md-5 col-10 change-area" v-for="appointment in appointments" :key="appointment.id">
            <h2 class="usertitle">afspraken</h2>
            <div class="row">
                <div class="col-sm-6 result">
                    <p>Afspraaknummer</p>
                    <p>Datum</p>
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
                    <p><b>{{ appointment.date }}</b></p>
                    <p><b>{{ appointment.time }}</b></p>
                    <p><b v-if="appointment.type == 1">Consult</b></p>
                    <p><b v-if="appointment.type == 2">Eerste consult</b></p>
                    <p><b v-if="appointment.type == 3">Vaccinatie</b></p>
                    <p><b v-if="appointment.type == 4">Anaal klieren legen</b></p>
                    <p><b v-if="appointment.type == 5">Nagels knippen</b></p>
                    <p><b v-if="appointment.type == 6">Bloed onderzoek</b></p>
                    <p><b v-if="appointment.type == 7">Urine onderzoek</b></p>
                    <p><b v-if="appointment.type == 8">Gebitscontrole</b></p>
                    <p><b v-if="appointment.type == 9">Postoperatieve controle</b></p>
                    <p><b v-if="appointment.type == 10">Herhaal recept bestellen</b></p>
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
export default {
    data() {
      return {
          appointments: []
        }
    },
    async created() {
        const olduser = getUserDataFromSession()
        var userdata = getUserById(olduser.userId)
        const { appointments, error, load } = getAppointments()
        await load()
        this.appointments = appointments
        this.appointments = this.appointments.filter(a => a.email == olduser.userEmail)
    }
}
</script>

<style>
.result{
    text-align: left;
}
</style>