import axios from 'axios'
import { API_URL } from '../utils/api'

const baseUrlVacations = API_URL + 'vacations'

export async function bookNewVacation(newVacation) {
    try {
        const response = await axios.post(baseUrlVacations, newVacation)
        return true
    }
    catch(error) {
        console.error('Error posting new vacation.')
        throw error
    }
}