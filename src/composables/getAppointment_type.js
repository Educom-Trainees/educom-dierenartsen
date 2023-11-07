import { ref } from 'vue'

const getAppointment_type = (id) => {
    const appointment_type = ref(null)
    const error = ref(null)

    const load = async () => {
      try {
        let data = await fetch('http://localhost:3000/appointment-types/' + id)
        if(!data.ok){
          throw Error('no data found')
        }
        appointment_type.value = await data.json()
      }
      catch (err) {
        error.value = err.message
      }
    }

    return { appointment_type, error, load}
}

export default getAppointment_type