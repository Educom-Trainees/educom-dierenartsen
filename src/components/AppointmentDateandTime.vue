<template>
  <form @submit.prevent="emitShowForm('showContactForm')" class="appointment_form">
      <label>Kies een tijdstip </label><br>
        <div id="datepicker-area" class="d-flex justify-content-center align-items-center">
            <div class="btn-group" role="group" aria-label="datepicker">
                <button @click="()=>{ if (date > today) { previousDate() } }" type="button" class="btn btn-secondary active">&lt;</button>
                <button type="button" class="btn btn-secondary">{{ displayFullDate(date) }}</button>
                <button @click="nextDate()" type="button" class="btn btn-secondary active">&gt;</button>
            </div>
        </div>
      <label>Clinici</label><br>
        <button @click.prevent="changepreference(0)" type="button" value="0" id="block" :class="{selectedblock: preference == 0}">geen voorkeur</button>
        <button @click.prevent="changepreference(1)" type="button" value="1" id="block" :class="{selectedblock: preference == 1}">karel lant</button>
        <button @click.prevent="changepreference(2)" type="button" value="2" id="block" :class="{selectedblock: preference == 2}">danique de beer</button><br>
      <label>Ochtend</label><br>
        <div v-if="date">
            <div v-if="this.preference == 0">
                <button :class="{selected_time: time == timeslot.time}" id="smallblock" @click.prevent="changetimeANDdoctor(timeslot.time, timeslot.doctor)" :value="timeslot" v-for="timeslot in freeTimeslots.filter(t => t.time <= '14:00')" :key="timeslot.time">
                  <img class="time" src="../assets/time.png"> {{ timeslot.time }}
                </button> 
            </div>
            <div v-if="this.preference == 1">
                <button :class="{selected_time: time == timeslot.time}" id="smallblock" @click.prevent="changetimeANDdoctor(timeslot.time, timeslot.doctor)" :value="timeslot" v-for="timeslot in freeTimeslots.filter(t => t.doctor == 1 && t.time <= '14:00')" :key="timeslot.time">
                  <img class="time" src="../assets/time.png"> {{ timeslot.time }}
                </button>
            </div>
            <div v-if="this.preference == 2">
                <button :class="{selected_time: time == timeslot.time}" id="smallblock" @click.prevent="changetimeANDdoctor(timeslot.time, timeslot.doctor)" :value="timeslot" v-for="timeslot in freeTimeslots.filter(t => t.doctor == 2 && t.time <= '14:00')" :key="timeslot.time">
                  <img class="time" src="../assets/time.png"> {{ timeslot.time }}
                </button> 
            </div>
        </div>
      <label>Namiddag</label><br>
        <div v-if="date">
            <div v-if="this.preference == 0">
                <button :class="{selected_time: time == timeslot.time}" id="smallblock" @click.prevent="changetimeANDdoctor(timeslot.time, timeslot.doctor)" :value="timeslot" v-for="timeslot in freeTimeslots.filter(t => t.time >= '14:00')" :key="timeslot.time">
                  <img class="time" src="../assets/time.png"> {{ timeslot.time }}
                </button> 
            </div>
            <div v-if="this.preference == 1">
                <button :class="{selected_time: time == timeslot.time}" id="smallblock" @click.prevent="changetimeANDdoctor(timeslot.time, timeslot.doctor)" :value="timeslot" v-for="timeslot in freeTimeslots.filter(t => t.doctor == 1 && t.time >= '14:00')" :key="timeslot.time">
                  <img class="time" src="../assets/time.png"> {{ timeslot.time }}
                </button>
            </div>
            <div v-if="this.preference == 2">
                <button :class="{selected_time: time == timeslot.time}" id="smallblock" @click.prevent="changetimeANDdoctor(timeslot.time, timeslot.doctor)" :value="timeslot" v-for="timeslot in freeTimeslots.filter(t => t.doctor == 2 && t.time >= '14:00')" :key="timeslot.time">
                  <img class="time" src="../assets/time.png"> {{ timeslot.time }}
                </button> 
            </div>
        </div>
      <button @click.prevent="emitShowForm('showForm')" class="back">vorige</button>
      <button class="submit">volgende</button>
    </form>
</template>

<script>
import { displayFullDate, toDateString, skipSundayAndMonday, previousDate, nextDate } from '../composables/datetime-utils.js'
import { combineTimeslotAppointments } from '../composables/arrayTransfromer.js'
import getTime_slots from '../composables/getTime_slots'
import getAppointments from '../composables/getAppointments'
export default {
    props: [
        'duration',
        'oldtime'
    ],
    data() {
        return {
            showForm: false,
            showdateForm: true,
            today: new Date(),
            maxdate: new Date(),
            preference: 0,
            time: '',
            doctor: '',
            date: new Date(),
            freeTimeslots: '',
            emitArray: [],
            displayFullDate: displayFullDate,
        }
    },
    watch: {
      date() {
        this.preparesetup()
      },
      preference() {
        this.preparesetup()
      }
    },
    created() {
        this.maxdate = new Date(this.today.setMonth(this.today.getMonth()+2)),
        this.time = this.oldtime
        this.preparesetup()
    },
    methods: {
        emitShowForm(form) {
            this.emitArray = [form, this.doctor, this.time, this.preference]
            this.$emit('showForm', this.emitArray)
        },
        // handledateSubmit() {
        //     this.$emit('showForm', ['showContactForm', this.doctor, this.time, this.preference])
        // },
        // backtoform(){
        //     this.$emit('showForm', ['showForm', this.doctor, this.time, this.preference])
        //     this.$emit('showdateForm', false)
        // },
        changepreference(preference){
            this.preference = preference
        },
        changetimeANDdoctor(time, doctor){
            this.time = time
            this.doctor = doctor
        },
        nextDate() {
            if(this.date < this.maxdate){
                this.date = nextDate(this.date)
            }
        },
        previousDate() {
            this.date = previousDate(this.date)
        }, 
        getFreeSlots(time_slots, duration){
            const result = []
            time_slots.forEach((element, index) => {
            if(element.show == true && time_slots[index].appointment == undefined){
                if(duration == 15){
                    result.push(element)
                }else if(duration == 30 && time_slots[index + 1] != undefined){
                if(time_slots[index + 1].show == true && time_slots[index + 1].appointment == undefined){
                    result.push(element)
                }
                }else if(duration == 45 && time_slots[index+2] != undefined){
                if(time_slots[index + 2].show == true && time_slots[index + 2].appointment == undefined){
                    result.push(element)
                }
                }
            }
            });
            return result
        },
        RemoveDuplicate(array, prefDoctor){
            const result = []
            array.forEach((element, index) => {
            if(element == undefined){}
                else if(array[index + 1] != undefined && element.time == array[index + 1].time || 
                array[index - 1] != undefined && element.time == array[index - 1].time ){
                if(element.doctor != prefDoctor){
                }else {
                    result.push(element)
                }
                }else {
                result.push(element)
                }
            });
            return result
        },
        async gettimeslots(){
            const { time_slots, error, load } = getTime_slots()
            await load()
            return { time_slots, error }
        },
        async getappointments(){
            const { appointments, error, load } = getAppointments()
            await load()
            return { appointments, error }
        },
        async preparesetup() {
            console.log('setup')
            this.freeTimeslots = []

            const { time_slots, timeslot_error } = await this.gettimeslots()
            const { appointments, appointments_error } = await this.getappointments()


            this.date = skipSundayAndMonday(this.date)
            const filteredapp = appointments.value.filter(a => a.date == toDateString(this.date))
            var newTimeslot = combineTimeslotAppointments(time_slots.value, filteredapp)
            var maxdate = new Date(this.today.setMonth(this.today.getMonth()+2));
            console.log(maxdate)
            var filteredTimeslot = newTimeslot.filter(n => n.date < maxdate)
            console.log(newTimeslot)
            var freeTimeslots = this.getFreeSlots(newTimeslot, this.duration)

            if(this.preference == 0){
                var prefDoctor = 0
                var sumdoctor1 = 0
                var sumdoctor2 = 0
                for (let i = 0; i < freeTimeslots.length; i++) {
                    if(freeTimeslots[i] != undefined){
                        if(freeTimeslots[i].doctor == 1){
                            sumdoctor1++
                        }else if(freeTimeslots[i].doctor == 2){
                            sumdoctor2++
                        }
                    }
                }
                if(sumdoctor1 >= sumdoctor2){
                    prefDoctor = 1
                }else if(sumdoctor1 < sumdoctor2){
                    prefDoctor = 2
                }
                

                var list = this.RemoveDuplicate(freeTimeslots, prefDoctor)


                this.freeTimeslots = list
            }else {
                this.freeTimeslots = freeTimeslots
            }
            console.log('einde setup')
        }
    }
}
</script>

<style>

</style>