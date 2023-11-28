import { ref } from 'vue'

const getAppointment_types = () => {
    const appointment_types = ref(null)
    const error = ref(null)

    const load = async () => {
      try {
        let data = await fetch('http://localhost:3000/appointment-types')
        if(!data.ok){
          throw Error('no data found')
        }
        appointment_types.value = await data.json()
      }
      catch (err) {
        error.value = err.message
        console.log(error.value)
      }
    }
    load()
    return { appointment_types, error}
}

export default getAppointment_types