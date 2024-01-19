import axios from 'axios'
import { ref } from 'vue'
import { API_URL } from '../utils/api'

const baseUrlAppointment = API_URL + 'appointments'
const baseUrlActiveAppointmentsByDate = baseUrlAppointment + '?status=0&date='
const baseUrlAppointmentByNumber = baseUrlAppointment + '?number='

/**
 * Get the active appointments for given date.
 * 
 * @param {String} date - The date for which to fetch appointments.
 * @returns Returns an array of appointments if found, otherwise empty array.
 */
export async function getActiveAppointmentsByDate(date) {
    const url = baseUrlActiveAppointmentsByDate + date
    try {
        const response = await axios.get(url)
        if (Array.isArray(response.data) && response.data.length === 0) {
            return []
        } else {
            return response.data
        }
    }
    catch (error) {
        console.error('Error getting appointments from database.')
        throw error
    }
}
/**
 * Get the appointment for given appointment number.
 * 
 * @param {Number} number - The appointment number.
 * @returns Returns the appointment if found, otherwise empty array.
 */
export async function getAppointmentByNumber(number) {
    const appointment = ref(null)
    const error = ref(null)
  
    try {
      const response = await axios.get(baseUrlAppointmentByNumber + number)
  
      if (!response.data) {
        throw Error('No data found')
      }
  
      appointment.value = response.data[0]
    } catch (err) {
      error.value = err.message
      console.error(error.value)
    }
  
    return { appointment, error }
  }
/**
 * Get the appointment for given Id.
 * 
 * @param {Number} id - The appointment Id.
 * @returns Returns the appointment if found, otherwise empty array.
 */
export async function getAppoinmentById(id) {
    const url = baseUrlAppointment + "/" + String(id)
    try {
        const response = await axios.get(url) 
        if (Array.isArray(response.data) && response.data.length === 0) {
            return []
        } else {
            return response.data
        }
    }
    catch (error) {
        console.error('Error getting appointment from database.')
        throw error
    }
}

/**
 * Cancel the appointment.
 * 
 * @param {Object} appointment 
 */
export async function cancelAppointmentByDoctor(appointment) {
    const url = baseUrlAppointment + "/ " + String(appointment.id)
    const cancelledAppointment = {...appointment, 'status': 1}
    try {
        const response = await axios.put(url, cancelledAppointment) 
    }
    catch (error) {
        console.error('Error cancelling appointment.')
        throw error
    }
}

/**
 * Update the appointment.
 * 
 * @param {Object} updatedAppointment 
 */
export async function updateAppoinment(updatedAppointment) {
    const url = baseUrlAppointment + "/" + String(updatedAppointment.id)
    try {
        const response = await axios.put(url, updatedAppointment) 
    }
    catch (error) {
        console.error('Error updating appointment.')
        throw error
    }
}

/**
 * Get all the appointment types.
 * 
 * @returns Returns the appointment-types if found, otherwise empty array.
 */
export async function getAppointmentTypes() {
    const url = API_URL + 'appointment-types'
    try {
        const response = await axios.get(url) 
        if (Array.isArray(response.data) && response.data.length === 0) {
            return []
        } else {
            return response.data
        }
    }
    catch (error) {
        console.error('Error getting appointment types from database.')
        throw error
    }
}