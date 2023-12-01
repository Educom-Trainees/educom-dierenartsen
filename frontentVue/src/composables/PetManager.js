import axios from 'axios'

const baseUrlPetTypes = 'http://localhost:3000/pet-types'

export async function getPetTypes() {
    try {
        const response = await axios.get(baseUrlPetTypes) 
        if (Array.isArray(response.data) && response.data.length === 0) {
            return []
        } else {
            return response.data
        }
    }
    catch (error) {
        console.error('Error getting pet-types from database.')
        throw error
    }
}