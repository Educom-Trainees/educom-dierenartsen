import axios from 'axios'

const baseUrlActiveAppointmentsByDate = 'http://localhost:3000/appointments?status=0&date='
const baseUrlAppointmentById = 'http://localhost:3000/appointments/'

/**
 * Get the active appointments for given date.
 * 
 * @param {String} date - The date for which to fetch appointments.
 * @returns Returns an array of appointments if found, otherwise empty array.
 */
export async function GetActiveAppointmentsByDate(date) {
    const url = baseUrlActiveAppointmentsByDate + date
    try {
        const response = await axios.get(url)
        if (Array.isArray(response.data) && response.data.length === 0) {
            console.log('Appointments not found.')
            return []
        } else {
            console.log('appointments found.')
            return response.data
        }
    }
    catch (error) {
        console.error('Error getting appointments from database.')
        throw error
    }
}
/**
 * Get the appointment for given Id.
 * 
 * @param {Number} id - The appointment Id.
 * @returns Returns the appointment if found, otherwise empty array.
 */
export async function getAppoinmentById(id) {
    const url = baseUrlAppointmentById + String(id)
    try {
        const response = await axios.get(url) 
        if (Array.isArray(response.data) && response.data.length === 0) {
            console.log('Appointment not found.')
            return []
        } else {
            console.log('appointment found.')
            return response.data
        }
    }
    catch (error) {
        console.error('Error getting appointment from database.')
        throw error
    }
}