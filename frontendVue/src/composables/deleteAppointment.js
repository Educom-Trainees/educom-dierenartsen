import { ref } from 'vue'
import { API_URL } from '../utils/api'

export async function deleteAppointment(id) {
  const error = ref(null)

  try {
    const response = await axios.delete(API_URL + 'appointments/' + id)

    if (!response.data) {
      throw Error('No appointment found to be deleted')
    }
  } catch (err) {
    error.value = err.message
    console.error(error.value)
  }

  return { error }
}
