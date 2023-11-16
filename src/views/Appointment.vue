<template>
  <TopNavigation />
  <div class="planning">
    <h1 class="appointment_header">Afspraak maken</h1>
    <div class="test" v-if="showForm">
      <h2><img src="../assets/balk1.png"></h2>
      <form @submit.prevent="handleSubmit" v-if="showForm" class="appointment_form">
        <!-- <div class="test"> -->
        <h4 class="appointment_header_2">Afspraak voorkeuren</h4>
        <label>Selecteer diersoort* </label><br>
          <button v-if="type_animal != 1 && type_animal != 8 && type_animal != 9" @click="changetype_animal(1)" type="button" id="big" value="1" :class="{selected_animal: type_animal == 1}"><img src="../assets/dog.png"><br>hond</button>
          <button @click="changetype_animal(2)" type="button" id="big" value="2" :class="{selected_animal: type_animal == 2}"><img src="../assets/black-cat.png"><br>kat</button>
          <button @click="changetype_animal(3)" type="button" id="big" value="3" :class="{selected_animal: type_animal == 3}"><img src="../assets/rabbit.png"><br>konijn</button>
          <button @click="changetype_animal(4)" type="button" id="big" value="4" :class="{selected_animal: type_animal == 4}"><img src="../assets/guinea-pig.png"><br>cavia</button>
          <button @click="changetype_animal(5)" type="button" id="big" value="5" :class="{selected_animal: type_animal == 5}"><img src="../assets/hamster.png"><br>hamster</button>
          <button @click="changetype_animal(6)" type="button" id="big" value="6" :class="{selected_animal: type_animal == 6}"><img src="../assets/rat.png"><br>rat</button>
          <button @click="changetype_animal(7)" type="button" id="big" value="7" :class="{selected_animal: type_animal == 7}"><img src="../assets/muis.png"><br>muis</button>
          <br>
          <div v-if="type_animal == 1 || type_animal == 8 || type_animal == 9">
            <button @click="changetype_animal(8)" type="button" id="big" value="8" :class="{selected_animal: type_animal == 8}"><img src="../assets/dog.png"><br>kleine hond</button>
            <button @click="changetype_animal(9)" type="button" id="big" value="9" :class="{selected_animal: type_animal == 9}"><img src="../assets/dog.png"><br>grote hond</button>
          </div>
        <label>Aantal huisdieren* </label><br>
          <button @click="changeamount(1)" type="button" value="1" id="small" :class="{selected: amount == 1}">1</button>
          <button @click="changeamount(2)" type="button" value="2" id="small" :class="{selected: amount == 2}">2</button>
          <button @click="changeamount(3)" type="button" value="3" id="small" :class="{selected: amount == 3}">3</button>
          <button @click="changeamount(4)" type="button" value="4" id="small" :class="{selected: amount == 4}">4</button>
        <br>
        <div v-if="name_animalError" class="error">{{ name_animalError }}</div>
          <select required v-model="type_consult" id="type_select">
            <option hidden value="">Selecteer type afspraak*</option>
            <option value="1">consult</option>
            <option value="2">eerste consult</option>
            <option value="3">vaccinatie</option>
            <option value="4">anaal klieren legen</option>
            <option value="5">nagels knippen</option>
            <option value="6">bloed onderzoek</option>
            <option value="7">urine onderzoek</option>
            <option value="8">gebitscontrole</option>
            <option value="9">postoperatieve controle</option>
            <option value="10">herhaal recept bestellen</option>
          </select><br>
            <button v-if="type_animal != 1" class="submit">volgende</button>
        <!-- </div> -->
    </form>
    
    </div>
    <div class="button_div" v-if="showForm">
      <h2 id="removetext">.</h2>
    </div>
    <div class="test" v-if="showdateForm">
    <h2><img src="../assets/balk2.png"></h2>
    <form @submit.prevent="handledateSubmit" v-if="showdateForm" class="appointment_form">
      <label>Clinici</label><br>
        <button @click="changepreference(0)" type="button" value="0" id="block" :class="{selectedblock: preference == 0}">geen voorkeur</button>
        <button @click="changepreference(1)" type="button" value="1" id="block" :class="{selectedblock: preference == 1}">karel lant</button>
        <button @click="changepreference(2)" type="button" value="2" id="block" :class="{selectedblock: preference == 2}">danique de beer</button><br>
      <label>Datum: </label><br>
        <input type="date" required v-model="date"><br>
      <label>Tijd:</label><br>
        <div v-if="date">
            <div v-if="this.preference == 0">
                <button :class="{selected_time: time == timeslot.time}" id="smallblock" @click="changetimeANDdoctor(timeslot.time, timeslot.doctor)" :value="timeslot" v-for="timeslot in freeTimeslots" :key="timeslot.time">
                  <img class="time" src="../assets/time.png"> {{ timeslot.time }}
                </button> 
            </div>
            <div v-if="this.preference == 1">
                <button :class="{selected_time: time == timeslot.time}" id="smallblock" @click="changetimeANDdoctor(timeslot.time, timeslot.doctor)" :value="timeslot" v-for="timeslot in freeTimeslots.filter(t => t.doctor == 1)" :key="timeslot.time">
                  <img class="time" src="../assets/time.png"> {{ timeslot.time }}
                </button>
            </div>
            <div v-if="this.preference == 2">
                <button :class="{selected_time: time == timeslot.time}" id="smallblock" @click="changetimeANDdoctor(timeslot.time, timeslot.doctor)" :value="timeslot" v-for="timeslot in freeTimeslots.filter(t => t.doctor == 2)" :key="timeslot.time">
                  <img class="time" src="../assets/time.png"> {{ timeslot.time }}
                </button> 
            </div>
        </div>
      <button @click="backtoform" class="back">vorige</button>
      <button class="submit">volgende</button>
    </form>
    </div>
    <div class="button_div" v-if="showdateForm">
      <h2 id="removetext">test</h2>
    </div>
    <div class="test" v-if="showcontactForm">
      <h2><img src="../assets/balk3.png"></h2>
      <h3>{{ date }} {{ time }}</h3>
    <form @submit.prevent="Result" v-if="showcontactForm" class="appointment_form">
      <h4>Persoonlijke gegevens</h4>
      <label>Uw contactgegevens</label><br>
      <input type="email" required v-model="email" placeholder="Email adres*"><br>
      <div v-if="emailError" class="error">{{ emailError }}</div>
      <input type="text" required v-model="phone" placeholder="Mobiel nummer*"><br>
      <div v-if="phoneError" class="error">{{ phoneError }}</div>
      <label>Uw naam</label><br>
      <input type="text" required v-model="name" placeholder="Naam*"><br>
      <div v-if="nameError" class="error">{{ nameError }}</div>
      <label>Gegevens huisdieren </label>
        <div v-if="amount == 1">
          <input type="text" v-model="name_animal[0]" placeholder="Naam huisdier"><br>
        </div>
        <div v-if="amount != 1">
          <input type="text" v-model="name_animal[0]" placeholder="Naam eerste huisdier"><br>
          <input type="text" v-model="name_animal[1]" placeholder="Naam tweede huisdier">
        </div>
        <div v-if="amount != 1 && amount != 2">
          <input type="text" v-model="name_animal[2]" placeholder="Naam derde huisdier">
        </div>
        <div v-if="amount == 4">
          <input type="text" v-model="name_animal[3]" placeholder="Naam vierde huisdier">
        </div>
      <button @click="backtodateform" class="back">vorige</button>
      <button class="submit">bevestig afspraak</button>
    </form>
  </div>
  </div>
  <div class="button_div" v-if="showcontactForm">
    <h2 id="removetext">test</h2>
  </div>
</template>

<script>
  import { toDateString } from '../composables/datetime-utils.js'
import TopNavigation from '../components/TopNavigation.vue'
import getTime_slots from '../composables/getTime_slots'
import getAppointments from '../composables/getAppointments'
import getAppointment_type from '../composables/getAppointment_type'
  import { combineTimeslotAppointments } from '../composables/arrayTransfromer.js'
import postAppointments from '../composables/postAppointments'

export default {
  name: 'app',
  components: {
    TopNavigation
  },
  data() {
      return {
          name: '',
          email: '',
          phone: '',
          type_animal: '',
          amount: 1,
          name_animal: [],
          type_consult: '',
          showForm: true,
          showdateForm: false,
          showcontactForm: false,
          duration: 0,
          preference: 0,
          status: 0,
          number: 0,
          appointments: '',
            freeTimeslots: '',
            time_slots: '',
            timeslotdata: '',
            time: '',
            doctor: '',
            date: toDateString(new Date()),
            name_animalError: '',
            nameError: '',
            emailError: '',
            phoneError: '',
            animal_nameError: ''
        }
    },
    watch: {
      date() {
        this.handleSubmit()
      },
      preference() {
        this.handleSubmit()
      }
    },
    methods: {
      changeamount(amount){
        this.amount = amount
      },
      changetype_animal(animal){
        this.type_animal = animal
      },
      changepreference(preference){
        this.preference = preference
      },
      changetimeANDdoctor(time, doctor){
        this.time = time
        this.doctor = doctor
      },
      backtoform(){
        this.showForm = true
        this.showdateForm = false
      },
      backtodateform(){
        this.showdateForm = true
        this.showcontactForm = false
      },
      async handleSubmit() {
        // for (let i = 0; i < 4;) { 
        //   console.log(this.name_animal[i].length)
        //   this.name_animalError = this.name_animal[i].length < 90 ?
        //   '' : 'je huisdiernaam mag niet langer zijn dan 90 letters'
        //   i++
        // }

      // console.log(this.name_animal[0].length)
      // if(this.name_animalError){
      //   return {
      //     name_animalError
      //   }
      // }
      const { appointment_type, error, load } = getAppointment_type(this.type_consult)
      await load()
      for(let i=0; i < appointment_type.value.calculation.length; i++){
        const app_type = appointment_type.value.calculation[i];
        if (app_type.count && app_type.count != this.amount) { 
          continue
        }
        if(app_type.type && app_type.type != this.type_animal){
          continue
        }
        this.duration = app_type.duration
        break
      }
      console.log(this.duration)

        const { time_slots, timeslot_error } = await this.gettimeslots()
        const { appointments, appointments_error } = await this.getappointments()

        const filteredapp = appointments.value.filter(a => a.date == this.date)
        var newTimeslot = combineTimeslotAppointments(time_slots.value, filteredapp)
        var freeTimeslots = this.getFreeSlots(newTimeslot, this.duration)

        console.log('uit de loop')
        console.log(freeTimeslots)

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

          console.log('sum1')
          console.log(sumdoctor1)

          console.log('sum2')
          console.log(sumdoctor2)

          console.log('voordat hij dubbele verwijdert')
          console.log(freeTimeslots)

          var list = this.RemoveDuplicate(freeTimeslots, prefDoctor)

          console.log('nadat hij dubble verwijdert')
          console.log(list)

          this.freeTimeslots = list
        }else {
          this.freeTimeslots = freeTimeslots
        }

        this.showForm = false
        this.showdateForm = true
        return { 
          appointment_type, 
          freeTimeslots, 
          error
        }
      },
      async handledateSubmit() {
        this.showdateForm = false
        this.showcontactForm = true
      },
      async Result() {
        const { appointments, error, load } = getAppointments()
        await load()
        this.appointments = appointments


      this.nameError = this.name.length < 30 ?
      '' : 'je naam mag niet langer zijn dan 30 letters'
      this.emailError = this.email.length < 75 ?
      '' : 'je email mag niet langer zijn dan 75 letters'

      // dit werkt niet met de -
      // const validationPhone = /^\d{10}$/;

      // this.phoneError = this.phone.match(validationPhone) ?
      // '' : 'je telefoonnummer moet bestaan uit 10 nummers'

      if(!this.nameError && !this.emailError){
        const lastappointment = this.appointments[this.appointments.length - 1]
        this.number = lastappointment.id
        this.number++

        await postAppointments(this.number, this.date, this.time, this.duration, this.name, this.phone, 
        this.email, this.type_animal, this.type_consult, this.name_animal, this.preference, this.doctor, this.status)

        console.log('de afspraak is gepost')
        this.$router.push('/result/' + this.number)
      }
    },
      RemoveDuplicate(array, prefDoctor){
        console.log('array:')
        console.log(array)
        console.log('voorkeur:')
        console.log(prefDoctor)
        const result = []
        array.forEach((element, index) => {
          if(element == undefined){}
            else if(array[index + 1] != undefined && element.time == array[index + 1].time || 
               array[index - 1] != undefined && element.time == array[index - 1].time ){
              if(element.doctor != prefDoctor){
                console.log('deze worden geskipt')
                console.log(element)
              }else {
                console.log('de voorkeur dokter')
                console.log(element)
                result.push(element)
              }
            }else {
              console.log('de enige tijd')
              console.log(element)
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
    }
  }
}
</script>
<style>
.appointment_header{
  text-align: left;
  margin-left: 50px;
}
.appointment_header_2{
  text-align: left;
  margin-left: 10px;
}
.appointment_form{
  text-align: left;
  background-color: whitesmoke;
  margin-left: 20px;
}
.appointment_result {
  background-color: white;
  flex: 25%;
}
.appointment_result_pic {
  background-color: white;
  flex: 50%;
}
.row {
  margin-left: 20px;
  display: flex;
}
.submit {
  float: right;
  border-radius: 12px;
  width: 150px;
  background-color: var(--happyPaw4);
  color: white;
  margin-right: 10px;
  margin-bottom: 10px;
}
.back {
  float: left;
  border-radius: 12px;
  width: 150px;
  background-color: var(--happyPaw4);
  color: white;
  margin-left: 10px;
  margin-bottom: 10px;
}
.test {
  margin-left: 50px;
  background-color: lightgrey;
  margin-right: 200px;
}
.button_div {
  margin-left: 50px;
  background-color: lightgrey;
  margin-right: 200px;
}
.time {
  width: 20%;
}
select{
  /* float: left; */
  background-color: white;
  border-radius: 12px;
}
button.selected {
  color: white;
  background-color: var(--happyPaw4);
  border-radius: 12px;
  width: 50px;
  margin-right: 5px;
  margin-left: 10px;
}
button.selectedblock {
  color: white;
  background-color: var(--happyPaw4);
  height: 40px;
  width: 150px;
  margin-left: 40px;
}
button.selected_animal {
  color: white;
  background-color: var(--happyPaw4);
  border-radius: 12px;
  height: 70px;
  width: 100px;
  margin-right: 5px;
  margin-left: 10px;
}
button.selected_time {
  color: white;
  background-color: var(--happyPaw4);
  height: 40px;
  width: 110px;
  margin-left: 40px;
}
#small {
  border-radius: 12px;
  width: 50px;
  margin-right: 5px;
  margin-left: 10px;
}
#big {
  border-radius: 12px;
  height: 70px;
  width: 100px;
  margin-right: 5px;
  margin-left: 10px;
}
#smallblock {
  height: 40px;
  width: 110px;
  margin-left: 40px;
}
#block {
  height: 40px;
  width: 150px;
  margin-left: 40px;
}
#type_select {
  width: 250px;
  margin-left: 10px;
  margin-bottom: 50px;
  margin-top: 5px;
}
#removetext {
  color: lightgrey;
}
button {
  background-color: white;
  margin-bottom: 10px;
}
input {
  border-radius: 12px;
  margin-left: 10px;
  margin-bottom: 5px;
}
label {
  margin-left: 10px;
  margin-bottom: 10px;
  margin-top: 5px;
  font-weight: bold;
}
img {
  height: 50%;
  width: 40%;
}
h4 {
  margin-left: 10px;
}
</style>