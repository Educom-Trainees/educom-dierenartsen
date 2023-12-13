import axios from 'axios'
import { API_URL } from '../utils/api'


const baseUrlTimeslots = API_URL + 'time-slots'
const baseUrlTimeslotsByDate = baseUrlTimeslots + '?date='

export async function GetAllTimeslots() { // This function gets todays timeslots
    try {
        const response = await axios.get(baseUrlTimeslots)
        if (Array.isArray(response.data) && response.data.length === 0) {
            return []
        } else {
            return response.data
        }
    }
    catch (error) {
        console.error('Error getting timeslots from database.')
        throw error
    }
}

export async function GetTimeslotsByDate(date) {
    const url = baseUrlTimeslotsByDate + date
    try {
        const response = await axios.get(url)
        if (Array.isArray(response.data) && response.data.length === 0) {
            return []
        } else {
            return response.data
        }
    }
    catch (error) {
        console.error('Error getting timeslots from database.')
        throw error
    }
}