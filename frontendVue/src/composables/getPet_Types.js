import { ref } from 'vue'
import axios from 'axios'
import { API_URL } from '../utils/api'

export async function getPet_Types() {
    const pet_types = ref(null)
    const error = ref(null)

    try {
      const response = await axios.get(API_URL + 'pet-types')
  
      if (!response.data) {
        throw Error('No data found')
      }
  
      pet_types.value = response.data
    } catch (err) {
      error.value = err.message
      console.error(error.value)
    }
  
    return { pet_types, error }
  }
