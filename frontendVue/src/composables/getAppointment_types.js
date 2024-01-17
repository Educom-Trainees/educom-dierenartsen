// import { ref } from 'vue'
// import { API_URL } from '../utils/api'

// const getAppointment_types = () => {
//     const appointment_types = ref(null)
//     const error = ref(null)

//     const load = async () => {
//       try {
//         let data = await fetch(API_URL + 'appointment-types')
//         if(!data.ok){
//           throw Error('no data found')
//         }
//         appointment_types.value = await data.json()
//         console.log(appointment_types)
//         console.log(appointment_types.value)
//       }
//       catch (err) {
//         error.value = err.message
//         console.log(error.value)
//       }
//     }
//     load()
//     return { appointment_types, error}
// }

// export default getAppointment_types

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


