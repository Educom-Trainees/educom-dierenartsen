export function calculateEndTime(date, time, duration) {
    const ts = new Date([date, time]
        .join(' '))
    ts.setMinutes(ts.getMinutes() + duration)
    return toTimeString(ts)
}
export function toTimeString(datetime) {
    return [String(datetime.getHours()).padStart(2, '0'), String(datetime.getMinutes()).padStart(2, '0')]
        .join(':')
}
export function displayTimeslot(date, time, duration) {
    const am_pm_start = new Date([date,time].join(' ')).getDate() < 12? 'am' : 'pm'
    const endtime = calculateEndTime(date,time,duration)
    const am_pm_end = new Date([date,endtime].join(' ')).getDate() < 12? 'am' : 'pm'
    return `${time}${am_pm_start} - ${endtime}${am_pm_end}`
}
export function displayDate(date) {
    const ts = new Date(date)
    const day = String(ts.getDate()).padStart(2, '0')
    const months = ['Jan','Feb','Mar','Apr','Mei','Jun','Jul','Aug','Sep','Okt','Nov','Dec']
    const month = months[ts.getMonth()]
    const year = String(ts.getFullYear())
    return [day,month,year].join('-')
}
export function displayFullDate(date) {
    const weekdays = ['Zondag','Maandag','Dinsdag','Woensdag','Donderdag','Vrijdag','Zaterdag']
    const months = ['Januari','Februari','Maart','April','Mei','Juni','Juli','Augustus','September','Oktober','November','December']
    const weekday = weekdays[date.getDay()]
    const day = String(date.getDate()).padStart(2, '0')
    const month = months[date.getMonth()]
    const year = date.getFullYear()
    return `${weekday}, ${day} ${month} ${year}`
}
export function toDateString(date) {
    const year = date.getFullYear()
    const month = String(date.getMonth() + 1).padStart(2, '0')
    const day = String(date.getDate()).padStart(2, '0')
    return `${year}-${month}-${day}`
}
export function nextDate(date) {
    var newDate = new Date(date)
    newDate.setDate(newDate.getDate() + 1)
    return newDate
}
export function previousDate(date) {
    var newDate = new Date(date)
    newDate.setDate(newDate.getDate() - 1)
    return newDate
}

export function skipSundayandMonday(date) {
    if(date.getDay() == 0){
        date.setDate(date.getDate() + 2)
    }
    if(date.getDay() == 1){
        date.setDate(date.getDate() + 1)
    }
    return date
}