import { ref } from 'vue'
import axios from 'axios'
import { API_URL } from '../utils/api'

export async function getAppointment(id) {
  const appointment = ref(null)
  const error = ref(null)

  try {
    const response = await axios.get(API_URL + 'appointments/' + id)

    if (!response.data) {
      throw Error('No data found')
    }

    appointment.value = response.data
  } catch (err) {
    error.value = err.message
    console.error(error.value)
  }

  return { appointment, error }
}
