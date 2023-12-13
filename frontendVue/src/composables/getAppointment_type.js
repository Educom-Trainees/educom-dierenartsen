import { ref } from 'vue'
import { API_URL } from '../utils/api'

const getAppointment_type = (id) => {
    const appointment_type = ref(null)
    const error = ref(null)

    const load = async () => {
      try {
        let data = await fetch(API_URL + 'appointment-types/' + id)
        if(!data.ok){
          throw Error('no data found')
        }
        appointment_type.value = await data.json()
      }
      catch (err) {
        error.value = err.message
      }
    }

    return { appointment_type, error, load}
}

export default getAppointment_type