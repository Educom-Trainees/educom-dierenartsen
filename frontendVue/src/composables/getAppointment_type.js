import { ref } from 'vue'
import axios from 'axios'
import { API_URL } from '../utils/api'

export async function getAppointment_type(id) {
    const appointment_type = ref(null)
    const error = ref(null)

    try {
      const response = await axios.get(API_URL + 'appointment-types/' + id)

      if (!response.data) {
        throw Error('No data found')
      }

      appointment_type.value = response.data
    } catch (err) {
      error.value = err.message
      console.error(error.value)
    }

  return { appointment_type, error }
}