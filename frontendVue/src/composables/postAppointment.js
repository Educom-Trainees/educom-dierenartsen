import { ref } from 'vue'
import axios from 'axios'
import { API_URL } from '../utils/api'

export async function postAppointment(
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
  const appointment = ref([])
  const error = ref(null)
  const pets = []
  for (let i = 0; i < name_animal.length; i++) {
    pets.push({ name: name_animal[i], extra: info_animal[i] })
  }
  try {
    const response = await axios.post(API_URL + 'appointments', {
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

    if(!response.data){
      throw Error('not able to make appointment')
    }
    
    const appointmentNumber = response.data.number

    appointment.value = response.data

    return appointmentNumber
  } catch (err) {
  error.value = err.message
  console.log(error.value)
  }
}