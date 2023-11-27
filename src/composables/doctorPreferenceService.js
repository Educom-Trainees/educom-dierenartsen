export function getPreferredDoctor(timeslotAppointments) {
    var sumDoctor1 = 0
    var sumDoctor2 = 0
    for (let i = 0; i < timeslotAppointments.length; i++) {
        if (timeslotAppointments[i].appointment && timeslotAppointments[i].doctor == 1) {
            sumDoctor1 += timeslotAppointments[i].appointment.duration
        }
        else if (timeslotAppointments[i].appointment && timeslotAppointments[i].doctor == 2) {
            sumDoctor2 += timeslotAppointments[i].appointment.duration
        }
    }
    return sumDoctor1 >= sumDoctor2? 2 : 1
}