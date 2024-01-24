import axios from 'axios'
import { API_URL } from '../utils/api'

const baseUrlScheduleChange = API_URL + 'change-schedule'

export async function updateWorkSchedule(doctorId, startDate, schedule) {
    const data = {
        doctorId,
        startDate,
        schedule
    }

    try {
        return await axios.post(baseUrlScheduleChange, data)
    } catch (e) {
        console.log(e)
    }

}