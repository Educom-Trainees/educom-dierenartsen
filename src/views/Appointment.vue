<template>
  <div class="planning">
    <h1 class="appointment_header">Afspraak maken</h1>
    <div class="test" v-if="showForm">
      <h2>hier komt de balk</h2>
      <form @submit.prevent="handleSubmit" v-if="showForm" class="appointment_form">
        <!-- <div class="test"> -->
        <h4 class="appointment_header_2">Afspraak voorkeuren</h4>
        <label>Selecteer diersoort* </label><br>
          <!-- <select>
            <option value="8">kleine hond</option>
            <option value="1">gemiddelde hond</option>
            <option value="9">grote hond</option>
          </select> -->
          <button @click="changetype_animal(1)" type="button" id="big" value="1" :class="{selected_animal: type_animal == 1}"><img src="../assets/dog.png"><br>hond</button>
          <button @click="changetype_animal(2)" type="button" id="big" value="2" :class="{selected_animal: type_animal == 2}"><img src="../assets/black-cat.png"><br>kat</button>
          <button @click="changetype_animal(3)" type="button" id="big" value="3" :class="{selected_animal: type_animal == 3}"><img src="../assets/rabbit.png"><br>konijn</button>
          <button @click="changetype_animal(4)" type="button" id="big" value="4" :class="{selected_animal: type_animal == 4}"><img src="../assets/guinea-pig.png"><br>cavia</button>
          <button @click="changetype_animal(5)" type="button" id="big" value="5" :class="{selected_animal: type_animal == 5}"><img src="../assets/hamster.png"><br>hamster</button>
          <button @click="changetype_animal(6)" type="button" id="big" value="6" :class="{selected_animal: type_animal == 6}"><img src="../assets/rat.png"><br>rat</button>
          <button @click="changetype_animal(7)" type="button" id="big" value="7" :class="{selected_animal: type_animal == 7}"><img src="../assets/muis.png"><br>muis</button>
          <!-- <button @click="changetype_animal(8)" type="button" id="big" value="8" :class="{selected_animal: type_animal == 8}">kleine hond</button>
          <button @click="changetype_animal(9)" type="button" id="big" value="9" :class="{selected_animal: type_animal == 9}">grote hond</button> -->
          <br>
        <label>Aantal huisdieren* </label><br>
          <button @click="changeamount(1)" type="button" value="1" id="small" :class="{selected: amount == 1}">1</button>
          <button @click="changeamount(2)" type="button" value="2" id="small" :class="{selected: amount == 2}">2</button>
          <button @click="changeamount(3)" type="button" value="3" id="small" :class="{selected: amount == 3}">3</button>
          <button @click="changeamount(4)" type="button" value="4" id="small" :class="{selected: amount == 4}">4</button>
        <br>
        <label v-if="amount == 1">Naam huisdier </label>
        <label v-if="amount != 1">Naam eerste huisdier </label>
        <input type="text" v-model="name_animal[0]"><br>
        <div v-if="amount != 1">
          <label>Naam tweede huisdier </label>
          <input type="text" v-model="name_animal[1]">
        </div>
        <div v-if="amount != 1 && amount != 2">
          <label>Naam derde huisdier </label>
          <input type="text" v-model="name_animal[2]">
        </div>
        <div v-if="amount == 4">
          <label>Naam vierde huisdier </label>
          <input type="text" v-model="name_animal[3]">
        </div>
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
            <button class="back">vorige</button>
            <button class="submit">volgende</button>
        <!-- </div> -->
    </form>
    
    </div>
    <div class="test" v-if="showForm">
      <h2>test</h2>
    </div>
    <div class="test" v-if="showdateForm">
    <h2>hier komt de balk</h2>
    <form @submit.prevent="handledateSubmit" v-if="showdateForm" class="appointment_form">
      <label>Clinici</label><br>
        <button @click="changepreference(0)" type="button" value="0" id="block" :class="{selectedblock: preference == 0}">geen voorkeur</button>
        <button @click="changepreference(1)" type="button" value="1" id="block" :class="{selectedblock: preference == 1}">karel lant</button>
        <button @click="changepreference(2)" type="button" value="2" id="block" :class="{selectedblock: preference == 2}">danique de beer</button><br>
      <label>Datum: </label><br>
        <input type="date" required v-model="date"><br>
      <label>Tijd:</label><br>
        <div v-if="time_slots.length">
            <select required v-model="timeslotdata" v-if="this.preference == 0">
                <option :value="timeslot" v-for="timeslot in time_slots" :key="timeslot.time">
                  <div v-if="timeslot.doctor == 1">
                    tijd: {{ timeslot.time }} dokter: karel lant
                  </div>
                  <div v-if="timeslot.doctor == 2">
                    tijd: {{ timeslot.time }} dokter: danique de beer
                  </div>
                </option>
            </select>
            <select required v-model="timeslotdata" v-if="this.preference == 1">
                <option :value="timeslot" v-for="timeslot in time_slots.filter(t => t.doctor == 1)" :key="timeslot.time">
                    tijd: {{ timeslot.time }} dokter: karel lant
                </option>
            </select>
            <select required v-model="timeslotdata" v-if="this.preference == 2">
                <option :value="timeslot" v-for="timeslot in time_slots.filter(t => t.doctor == 2)" :key="timeslot.time">
                    tijd: {{ timeslot.time }} dokter: danique de beer
                </option>
            </select>
        </div>
      <button class="back">vorige</button>
      <button class="submit">volgende</button>
    </form>
    </div>
    <div class="test" v-if="showdateForm">
      <h2>test</h2>
    </div>
    <div class="test" v-if="showcontactForm">
      <h2>hier komt de balk</h2>
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
      <button class="back">vorige</button>
      <button class="submit">bevestig afspraak</button>
    </form>
  </div>
  </div>
  <div class="test" v-if="showcontactForm">
    <h2>test</h2>
  </div>
</template>

<script>
  import getTime_slots from '../composables/getTime_slots'
  import getAppointments from '../composables/getAppointments'
  import getAppointment_type from '../composables/getAppointment_type'
  import postAppointments from '../composables/postAppointments'



  export default {
    name: 'app',
    components: {},
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
            time_slots: '',
            timeslotdata: '',
            time: '',
            doctor: '',
            date: '',
            name_animalError: '',
            nameError: '',
            emailError: '',
            phoneError: '',
            animal_nameError: ''
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

        this.time_slots = time_slots

        this.showForm = false
        this.showdateForm = true
        return { 
          appointment_type, 
          time_slots, 
          error, 
          timeslot_error 
        }
      },
      handledateSubmit() {
        this.time = this.timeslotdata.time
        this.doctor = this.timeslotdata.doctor
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
      async gettimeslots(){
        const { time_slots, error, load } = getTime_slots()
        await load()
        return { time_slots, error }
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
  /* margin-left: 50px; */
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
  display: flex;
}
.submit {
  float: right;
  border-radius: 12px;
  width: 150px;
  background-color: blue;
  color: white;
  margin-right: 10px;
  margin-bottom: 10px;
}
.back {
  float: left;
  border-radius: 12px;
  width: 150px;
  background-color: blue;
  color: white;
  margin-left: 10px;
  margin-bottom: 10px;
}
.test {
  margin-left: 50px;
  background-color: lightgrey;
  margin-right: 200px;
}
select{
  /* float: left; */
  background-color: white;
  border-radius: 12px;
}
button.selected {
  color: white;
  background-color: blue;
  border-radius: 12px;
  width: 50px;
  margin-right: 5px;
  margin-left: 10px;
}
button.selectedblock {
  color: white;
  background-color: blue;
  height: 40px;
  width: 150px;
  margin-left: 40px;
}
button.selected_animal {
  color: white;
  background-color: blue;
  border-radius: 12px;
  height: 70px;
  width: 90px;
  margin-right: 5px;
  margin-left: 10px;
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
  width: 90px;
  margin-right: 5px;
  margin-left: 10px;
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
button {
  background-color: white;
  margin-bottom: 10px;
}
input {
  border-radius: 12px;
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
</style>