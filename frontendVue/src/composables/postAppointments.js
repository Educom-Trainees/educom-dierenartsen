import { ref } from 'vue'
import axios from 'axios'
import { API_URL } from '../utils/api'

export async function postAppointments(
  number,
  date,
  time,
  duration,
  name,
  phone,
  email,
  userid,
  type_animal,
  type_consult,
  name_animal,
  info_animal,
  amount,
  preference,
  doctor,
  status
) {
  const appointments = ref([])
  const error = ref(null)
  const pets = []
  for (let i = 0; i < name_animal.length; i++) {
    pets.push({ name: name_animal[i], extra: info_animal[i] })
  }
  try {
    const response = await axios.post(API_URL + 'appointments', {
      number: number,
      date: date,
      time: time,
      duration: duration,
      customer: name,
      phoneNumber: phone,
      email: email,
      userId: userid,
      petType: type_animal,
      type: type_consult,
      pets: pets,
      amount: amount,
      preference: preference,
      doctor: doctor,
      status: status,
    })

    if(!response.ok){
      throw Error('not able to make appointment')
    }
    
    appointments.value = response.data
  } catch (err) {
  error.value = err.message
  console.log(error.value)
  }
}