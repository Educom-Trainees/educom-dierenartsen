import { ref } from 'vue'

const getPet_Types = () => {
    const pet_types = ref(null)
    const error = ref(null)

    const load = async () => {
      try {
        let data = await fetch('http://localhost:3000/pet-types')
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