import { ref } from 'vue'

const getAppointments = () => {
    const appointments = ref([])
    const error = ref(null)

    const load = async () => {
      try {
        let data = await fetch('http://localhost:3000/appointments')
        if(!data.ok){
          throw Error('no data found')
        }
        appointments.value = await data.json()
      }
      catch (err) {
        error.value = err.message
        console.log(error.value)
      }
    }

    return { appointments, error, load}
}

export default getAppointments