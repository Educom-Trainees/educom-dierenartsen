import { ref } from 'vue'

const putAppointment = async (id, date, time) => {
  const appointment = ref(null)
  const error = ref(null)
      try {
        let data = await fetch('http://localhost:3000/appointments/' + id, 
        {method: "PUT", 
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({number: id, date: date, time: time}
        )})
        if(!data.ok){
          throw Error('not able to change appointment')
        }
        appointment.value = await data.json()
      }
      catch (err) {
        error.value = err.message
        console.log(error.value)
      }
}

export default putAppointment