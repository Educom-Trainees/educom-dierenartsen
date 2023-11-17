<template>
    <div class="detail-box">
        <span class="close w-100">&times;</span>
        <div class="container">
            <div class="row">
                <div class="col-sm">
                    <span class="btn">{{ appointment.duration }} mins</span>
                </div>
                <div class="col-sm">
                    <span class="btn status-info">{{ appointment.status == 0? 'Actief' : 'Geannuleerd' }}</span>
                </div>
            </div>
            <div class="row">
                <div class="col-sm">
                    <span id="datetime-info" class="btn">{{ displayDate(appointment.date) }}</span>
                </div>
                <div class="col-sm">
                    <span id="datetime-info" class="btn">{{ displayTimeslot(appointment.date,appointment.time,appointment.duration) }}</span>
                </div>
            </div>
            <div class="row">
                <div class="col-sm">
                    <span class="btn btn-action action-move">Verplaatsen</span>
                </div>
                <div class="col-sm">
                    <span class="btn btn-action action-cancel" @click="deleteAppointment(appointment.id)">Annuleren</span>
                </div>
            </div>
            <div class="row">
                <div class="col-sm">
                    <h6 id="detail-label">Details</h6>
                </div>
            </div>
            <div v-for="(value,key) in customerDetails" class="row">
                <div class="col-sm">
                    <span class="details label">{{ key }}</span>
                </div>
                <div class="col-sm">
                    <span class="details output">{{ value }}</span>
                </div>
            </div>
            <div class="row">
                <div class="col-sm">
                    <span class="details label">Diersoort</span>
                </div>
                <div class="col-sm">
                    <span class="details output">{{ petType }}</span>
                </div>
            </div>
            <div v-for="name in petNames" class="row">
                <div class="col-sm">
                    <span class="details label">Huisdier</span>
                </div>
                <div class="col-sm">
                    <span class="details output">{{ name }}</span>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'
import { displayTimeslot, displayDate } from '../composables/datetime-utils.js'
import deleteAppointment from '../composables/deleteAppointment'

const baseUrlPetTypes = 'http://localhost:3000/pet-types'

export default {
    name: 'AppointmentDetail',
    props: ['appointment'],
    created() {
        this.getPetTypes()
    },
    data() {
        return {
            petTypes: [],
            displayDate: displayDate,
            displayTimeslot: displayTimeslot,
        }
    },
    methods: {
        getPetTypes() {
            axios.get(baseUrlPetTypes)
                .then(response => this.petTypes = response.data)
                .catch(error => console.log('Error getting pet-types:', error))
        },
        async deleteAppointment(id) {
            const {error, load} = deleteAppointment(id)
            await load()
            return error
        }
    },
    computed: {
        customerDetails() {
            return {
                'Afspraaknummer': this.appointment.id,
                'Klant': this.appointment.customer,
                'Telefoonnummer': this.appointment.phoneNumber,
                'Email': this.appointment.email,
            }
        },
        petType() {
            const type = this.petTypes.filter(pt => pt.id == this.appointment.petType)[0]
            return type? type.name : undefined
        },
        petNames() {
            return this.appointment.pets.map(p => p.name? p.name : '?')
        },
    }
}
</script>

<style>
.detail-box {
    background-color: #fefefe;
    margin: auto;
    border: 1px solid #888;
    padding: 4px;
    width: 100%;
    height: 100%;
    min-width: 300px;
    border-radius: 3px;
}
.detail-box .close {
    color: #aaaaaa;
    float: right;
    font-size: 24px;
    display: inline-flex;
    justify-content: end;
}
.detail-box .close:hover, .backdrop .close:focus {
  color: #000;
  text-decoration: none;
  cursor: pointer;
}
.detail-box .container .col-sm {
    width: 50% !important;
    margin: 2px 0;
    padding: 0;
}
.detail-box .btn {
    margin: 0 !important;
    display: inline-flex;
    align-items: center;
    justify-content: center;
    border-radius: 10px !important;
    font-size: 13px;
}
.detail-box .status-info {
    background-color: lightgreen !important;
    border-radius: 25px !important;
}
.detail-box #datetime-info {
    background-color: var(--lightGrey);
    width: 98% !important;
    padding: 0 10px !important;
}
.detail-box .btn-action {
    margin-top: 4px !important;
}
.detail-box .action-move {
    background-color: #5271FF;
}
.detail-box .action-cancel {
    background-color: #FF5757;
}
.detail-box #detail-label {
    margin: 8px 0 4px 0;
    font-weight: bolder;
}
.detail-box #detail-label .col-sm {
    margin: 0 !important;
}
.detail-box .details {
    font-size: 13px;
    word-wrap: break-word;
}
.detail-box .output {
    font-weight: bolder;
}
</style>