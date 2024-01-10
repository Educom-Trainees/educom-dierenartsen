import axios from 'axios'
import { API_URL } from '../utils/api'

const baseUrlAppointment = API_URL + 'appointments'
const baseUrlActiveAppointmentsByDate = baseUrlAppointment + '?status=0&date='

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