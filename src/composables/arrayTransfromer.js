/**
 * Create new array by combining timeslots array with appointments array.
 * 
 * @param {Array} timeslots - The timeslots array.
 * @param {Array} appointments - The appointments array.
 * @returns Returns a new array.
 */
export function combineTimeslotAppointments(timeslots, appointments) {
    const array = timeslots.map(t => {
        const a = appointments.filter(a => a.time == t.time && a.doctor == t.doctor)
        return {...t, 'appointment': a? a[0] : undefined, 'show': true}
    })
    for (var i = 0; i < array.length; i++) { 
        if (array[i].appointment) {
            if (array[i].appointment.duration > 15) {
                const r = array[i].appointment.duration / 15
                for (var n = 1; n < r; n++) {
                    array[i+n].show = false
                }
            }
        }
    }
    return array
}

export function getFreeTimeslots(array, appointmentDuration) {
    const rowspan = appointmentDuration / 15
    var freeTimeslots = []

    switch (appointmentDuration) {
        case 15:
            for (var i = 0; i < array.length; i++) { 
                if (array[i].appointment === undefined && array[i].show === true) {
                    freeTimeslots.push(array[i])
                }
            }
            return freeTimeslots
        case 30:
            for (var i = 0; i < array.length; i++) { 
                if (array[i].appointment === undefined && array[i].show === true && 
                    array[i+1].appointment === undefined) {
                    freeTimeslots.push(array[i])
                }
            }
            return freeTimeslots
        case 45:
            for (var i = 0; i < array.length; i++) { 
                if (array[i].appointment === undefined && array[i].show === true &&
                    array[i+1].appointment === undefined && array[i+2].appointment === undefined) {
                    freeTimeslots.push(array[i])
                }
            }
    }
}