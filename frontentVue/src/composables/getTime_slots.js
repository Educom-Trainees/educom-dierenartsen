import { ref } from 'vue'
import { API_URL } from '../utils/api'
import { toDateString } from './datetime-utils'

const getTime_slots = (date) => {
    const time_slots = ref(null)
    const error = ref(null)

    const load = async () => {
      try {
        let data = await fetch(API_URL + 'time-slots?date=' + toDateString(date))
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