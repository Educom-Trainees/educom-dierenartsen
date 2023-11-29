import axios from 'axios'

const baseUrlVacations = 'http://localhost:3000/vacations'

// export async function getVacations() {
//     try {
//         const response = await axios.get(baseUrlVacations)
//         if (Array.isArray(response.data) && response.data.length === 0) {
//             console.log('No vacations found.')
//             return []
//         } else {
//             console.log('Vacations found.')
//             return response.data
//         }
//     }
//     catch (error) {
//         console.log('Error getting vacations from database.')
//         throw error
//     }
// }

export async function postNewVacation(newVacation) {
    try {
        const response = await axios.post(baseUrlVacations, newVacation)
        console.log('Vacation posted successful.')
        return true
    }
    catch(error) {
        console.error('Error posting new vacation.')
        throw error
    }
}