import { ref } from 'vue'

const getAppointments = async (date, name, phone, email, type_animal, name_animal, preference, status) => {
    const appointments = ref([])
    const error = ref(null)
      try {
        let data = await fetch('http://localhost:3000/appointments', 
        {method: "POST", 
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({date: date, customer: name, phoneNumber: phone, email: email, petType: type_animal, 
          pets: [{name: name_animal[0]}, {name: name_animal[1]}], 
          preference: preference, status: status})})
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