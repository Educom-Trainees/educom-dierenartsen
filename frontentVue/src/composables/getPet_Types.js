import { ref } from 'vue'
import { API_URL } from '../utils/api'

const getPet_Types = () => {
    const pet_types = ref(null)
    const error = ref(null)

    const load = async () => {
      try {
        let data = await fetch(API_URL + 'pet-types')
        if(!data.ok){
          throw Error('no data found')
        }
        pet_types.value = await data.json()
      }
      catch (err) {
        error.value = err.message
        console.log(error.value)
      }
    }
    load()
    return { pet_types, error}
}

export default getPet_Types