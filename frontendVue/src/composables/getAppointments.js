import { ref } from 'vue'
import axios from 'axios'
import { API_URL } from '../utils/api'

export async function getAppointments(date = null, status = null, userId = null) {
  const appointments = ref(null)
  const error = ref(null)

  try {
    let url = (API_URL + 'appointments')

    if (date !== null) {
      url += `?date=${date}`
    }
    if (status !== null) {
        url += `?status=${status}`
    }
    if (userId !== null) {
        url += `?userId=${userId}`
    }

    const response = await axios.get(url)

    if (!response.data) {
      throw Error('No data found')
    }

    appointments.value = response.data
  } catch (err) {
    error.value = err.message
    console.error(error.value)
  }

  return { appointments, error}
}

