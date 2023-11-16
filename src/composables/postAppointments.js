import { ref } from 'vue'

const getAppointments = async (number, date, time, duration, name, phone, email, type_animal, type_consult, name_animal, info_animal, preference, doctor, status) => {
    const appointments = ref([])
    const error = ref(null)
      try {
        let data = await fetch('http://localhost:3000/appointments', 
        {method: "POST", 
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({number: number, date: date, time: time, duration: duration, customer: name, phoneNumber: phone, email: email, petType: type_animal, type: type_consult,
          pets: [{name: name_animal[0], extra: info_animal[0]}, {name: name_animal[1], extra: info_animal[1]}, 
          {name: name_animal[2], extra: info_animal[2]}, {name: name_animal[3], extra: info_animal[3]}], 
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