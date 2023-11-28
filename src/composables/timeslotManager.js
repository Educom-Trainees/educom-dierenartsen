import axios from 'axios'

const baseUrlTimeslots = 'http://localhost:5226/timeslots'
const baseUrlTimeslotsByDate = 'http://localhost:5226/timeslots?date='

export async function GetAllTimeslots() {
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