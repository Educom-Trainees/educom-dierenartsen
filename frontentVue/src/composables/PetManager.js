import axios from 'axios'
import { API_URL } from '../utils/api'

export async function getPetTypes() {
    try {
        const response = await axios.get(API_URL + "pet-types") 
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