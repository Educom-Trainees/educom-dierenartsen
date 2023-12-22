import axios from 'axios'
import { API_URL } from '../utils/api'
import { toDateString } from './datetime-utils'


const baseUrlTimeslots = API_URL + 'time-slots'
const baseUrlTimeslotsByDate = baseUrlTimeslots + '?date='

export async function getAllTimeslots() { // This function gets todays timeslots
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

export async function getTimeslotsByDate(date) {
    const url = baseUrlTimeslotsByDate + toDateString(date)
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