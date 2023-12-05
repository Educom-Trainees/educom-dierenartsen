import axios from 'axios'
import { API_URL } from '../utils/api'

const baseUrlPets = API_URL + 'user-pets'

export async function addPet(newPet) {
        try {
            const response = await axios.post(baseUrlPets, newPet)
            return true
        }
        catch(error) {
            console.error('Error posting new pet.')
            throw error
        }
}