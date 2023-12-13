import { ref } from 'vue'
import { API_URL } from '../utils/api'

const getAppointment = (id) => {
    const appointment = ref(null)
    const error = ref(null)

    const load = async () => {
      try {
        let data = await fetch(API_URL + 'appointments/' + id)
        if(!data.ok){
          throw Error('no data found')
        }
        appointment.value = await data.json()
      }
      catch (err) {
        error.value = err.message
        console.log(error.value)
      }
    }

    return { appointment, error, load}
}

export default getAppointment