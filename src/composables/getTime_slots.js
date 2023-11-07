import { ref } from 'vue'

const getTime_slots = () => {
    const time_slots = ref([])
    const error = ref(null)

    const load = async () => {
      try {
        let data = await fetch('http://localhost:3000/time-slots')
        if(!data.ok){
          throw Error('no data found')
        }
        time_slots.value = await data.json()
      }
      catch (err) {
        error.value = err.message
        console.log(error.value)
      }
    }

    return { time_slots, error, load}
}

export default getTime_slots