import axios from 'axios'

const baseUrlTimeslots = 'http://localhost:3000/time-slots'
const baseUrlTimeslotsByDate = 'http://localhost:3000/time-slots?date='

export async function GetAllTimeslots() {
    try {
        const response = await axios.get(baseUrlTimeslots)
        if (Array.isArray(response.data) && response.data.length === 0) {
            console.log('Timeslots not found.')
            return []
        } else {
            console.log('Timeslots found.')
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
            console.log('Timeslots not found.')
            return []
        } else {
            console.log('Timeslots found.')
            return response.data
        }
    }
    catch (error) {
        console.error('Error getting timeslots from database.')
        throw error
    }
}