import { ref } from 'vue'
import { API_URL } from '../utils/api'

const deleteAppointment = (id) => {
  const error = ref(null)

    const load = async () => {
      try {
        let data = await fetch(API_URL + 'appointments/' + id, 
        {method: "DELETE", 
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        }
      }
    )
    if(!data.ok){
      throw Error('no appointment found to be deleted')
    }}
      catch (err) {
        error.value = err.message
        console.log(error.value)
      }
    }

  return { error, load}
}

export default deleteAppointment