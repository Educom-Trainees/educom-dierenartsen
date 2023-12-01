import axios from 'axios'

const baseUrlVacations = 'http://localhost:5226/vacations'

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