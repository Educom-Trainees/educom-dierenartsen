import { ref } from 'vue'
import { API_URL } from '../utils/api'

const getAppointments = (date = null, status = null, userId = null) => {
    const appointments = ref(null)
    const error = ref(null)

    const load = async () => {
      try {
        let url = API_URL + 'appointments'
        // let data = await fetch(API_URL + 'appointments')

        if (date !== null) {
          url += `?date=${date}`
        }
        if (status !== null) {
            url += `?status=${status}`
        }
        if (userId !== null) {
            url += `?userId=${userId}`
        }

        let data = await fetch(url)
        
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