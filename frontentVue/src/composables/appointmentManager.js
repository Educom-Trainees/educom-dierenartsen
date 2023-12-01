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

export async function cancelAppointmentByDoctor(appointment) {
    const url = baseUrlAppointmentById + String(appointment.id)
    const cancelledAppointment = {...appointment, 'status': 1}
    try {
        const response = await axios.put(url, cancelledAppointment) 
    }
    catch (error) {
        throw error
    }
}

export async function updateAppoinment(updatedAppointment) {
    const url = baseUrlAppointmentById + String(updatedAppointment.id)
    try {
        const response = await axios.put(url, updatedAppointment) 
    }
    catch (error) {
        throw error
    }
}