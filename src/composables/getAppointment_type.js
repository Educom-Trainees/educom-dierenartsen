import { ref } from 'vue'

const getAppointment_type = (id) => {
    const appointment_type = ref([])
    const error = ref(null)
    console.log('test')
    log('test')

    const load = async () => {
      console.log('test')
      log('test')
      try {
        log('test')
        console.log('test')
        let data = await fetch('http://localhost:3000/appointment-types/' + id)
        if(!data.ok){
          console.log('test')
          log('test')
          throw Error('no data found')
        }
        appointment_type.value = await data.json()
        console.log('test')
        console.log(appointment_type.value)
        //throw Error('test')
        log('test')
      }
      catch (err) {
        error.value = err.message
        console.log(error.value)
      }
    }

    return { appointment_type, error, load}
}

export default getAppointment_type