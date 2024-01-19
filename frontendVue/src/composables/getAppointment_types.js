import { ref } from 'vue'
import axios from 'axios'
import { API_URL } from '../utils/api'

export async function getAppointment_types() {
  const appointment_types = ref(null)
  const error = ref(null)

    try {
      const response = await axios.get(API_URL + 'appointment-types')

      if (!response.data) {
        throw Error('No data found')
      }

      appointment_types.value = response.data
    } catch (err) {
      error.value = err.message
      console.error(error.value)
    }

  return { appointment_types, error }
}


