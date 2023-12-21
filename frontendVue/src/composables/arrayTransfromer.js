/**
 * Create new array by combining timeslots array with appointments array.
 * 
 * @param {Array} timeslots - The timeslots array.
 * @param {Array} appointments - The appointments array.
 * @returns Returns a new array.
 */
export function combineTimeslotAppointments(timeslots, appointments) {
    const result = timeslots.map(t => {
        const a = appointments.filter(a => a.time == t.time && (a.doctor == t.doctor || a.doctor == 3))
        return {...t, 'appointment': a? a[0] : undefined, 'show': true}
    })
    for (var i = 0; i < result.length - 1; i++) { 
        if (result[i].appointment) {
            if (result[i].appointment.duration > 15) {
                const r = result[i].appointment.duration / 15
                for (var n = 1; n < r; n++) {
                    result[i+(n*2)].show = false
                }
            }
        }
    }
    return result
}
/**
 * Get the timeslotAppointments with no appointments.
 * 
 * @param {Array} timeslotAppointments - The array of timeslotAppointment objects.
 * @param {*} appointmentDuration - The appointment duration.
 * @returns Returns the free timeslots.
 */

export function findFreeTimeslots(timeslots) {
    return timeslots.filter(timeslot => timeslot.available === 1);
}

// export function findFreeTimeslots(timeslotAppointments, appointmentDuration) {
//     var freeTimeslots = []

//     switch (appointmentDuration) {
//         case 15:
//             for (var i = 0; i < timeslotAppointments.length; i++) { 
//                 if (!timeslotAppointments[i].appointment && timeslotAppointments[i].show) {
//                     freeTimeslots.push(timeslotAppointments[i])
//                 }
//             }
//             return freeTimeslots
//         case 30:
//             for (var i = 0; i < timeslotAppointments.length; i++) { 
//                 if ((!timeslotAppointments[i].appointment && timeslotAppointments[i].show) && 
//                     (timeslotAppointments[i+1] && !timeslotAppointments[i+1].appointment && timeslotAppointments[i+1].show)) {
//                         freeTimeslots.push(timeslotAppointments[i])
//                 }
//             }
//             return freeTimeslots
//         case 45:
//             for (var i = 0; i < timeslotAppointments.length; i++) { 
//                 if ((timeslotAppointments[i].appointment === undefined && timeslotAppointments[i].show === true) &&
//                     (timeslotAppointments[i+1] && !timeslotAppointments[i+1].appointment && timeslotAppointments[i+1].show) && 
//                     (timeslotAppointments[i+2] && !timeslotAppointments[i+2].appointment && timeslotAppointments[i+2].show)) {
//                         freeTimeslots.push(timeslotAppointments[i])
//                 }
//             }
//     }
// }
/**
 * Remove the duplicate timeslots.
 * 
 * @param {Array} freeTimeslots - The free timeslots.
 * @param {Number} doctor - The chosen doctor.
 * @returns Returns the unique free timeslots for chosen doctor.
 */
export function RemoveDuplicates(freeTimeslots, doctor) {
    const result = []
    var skip = false
    for (var i = 0; i < freeTimeslots.length; i++) {
        if (!skip) {
            if (freeTimeslots[i+1] != undefined && freeTimeslots[i].time == freeTimeslots[i+1].time) {
                skip = true
                freeTimeslots[1].doctor == doctor? result.push(freeTimeslots[i]) : result.push(freeTimeslots[i+1])
            }
            else {
                skip = false
                result.push(freeTimeslots[i])
            }
        }
        else {
            skip = false
        }
    }
    return result
}
/**
 * Sort the timeslots array by doctor (ascending).
 * 
 * @param {Array} timeslots - The timeslots of the two doctors.
 * @returns Returns the timeslots array sorted by doctor.
 */
export function sortTimeslots(timeslots) {
    var result = []
    return result.concat(
        timeslots.filter(t => t.doctor == 1),
        timeslots.filter(t => t.doctor == 2)
    )
}