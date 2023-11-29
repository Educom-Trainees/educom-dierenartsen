import { ref } from 'vue'
import { API_URL } from '../utils/api'

const getAppointments = async (number, date, time, duration, name, phone, email, type_animal, type_consult, name_animal, info_animal, preference, doctor, status) => {
    const appointments = ref([])
    const error = ref(null)
    const pets = []
    for (let i = 0; i < name_animal.length; i++) {
      console.log('loop')
      pets.push({name: name_animal[i], extra: info_animal[i]})
    }
    console.log(pets)
      try {
        let data = await fetch(API_URL + 'appointments', 
        {method: "POST", 
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({number: number, date: date, time: time, duration: duration, customer: name, phoneNumber: phone, email: email, petType: type_animal, type: type_consult,
          pets: pets, 
          preference: preference, doctor: doctor, status: status})})
        if(!data.ok){
          throw Error('not able to make appointment')
        }
        appointments.value = await data.json()
      }
      catch (err) {
        error.value = err.message
        console.log(error.value)
      }


    // return { appointments, error, load}
}

export default getAppointments