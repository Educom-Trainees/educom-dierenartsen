import { ref } from 'vue'

const deleteAppointment = (id) => {
  const error = ref(null)

    const load = async () => {
      try {
        let data = await fetch('http://localhost:3000/appointments/' + id, 
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