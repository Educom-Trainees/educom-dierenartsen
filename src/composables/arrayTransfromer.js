export function combineTimeslotAppointments(timeslots, appointments) {
    console.log('test')
    const array = timeslots.map(t => {
        const a = appointments.filter(a => a.time == t.time)
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