const weekdays = ['Zondag', 'Maandag', 'Dinsdag', 'Woensdag', 'Donderdag', 'Vrijdag', 'Zaterdag']
const months = ['Januari', 'Februari', 'Maart', 'April', 'Mei', 'Juni', 'Juli', 'Augustus', 'September', 'Oktober', 'November', 'December']
const shortWeekdays = ['Zon', 'Maa', 'Din', 'Woe', 'Don', 'Vrij', 'Zat']
const shortMonthts = ['Jan', 'Feb', 'Mar', 'Apr', 'Mei', 'Jun', 'Jul', 'Aug', 'Sep', 'Okt', 'Nov', 'Dec']

/**
 * Get the end-time as a string, based on start-time and duration.
 * 
 * @param {string} date - The date.
 * @param {string} time - The time.
 * @param {number} duration - The time-duration.
 * @returns Returns the end-time.
 * @example calculateEndTime('2023-11-20', '9:30', 30) => '10:00'
 */
export function calculateEndTime(date, time, duration) {
    const ts = new Date([date, time]
        .join(' '))
    ts.setMinutes(ts.getMinutes() + duration)
    return toTimeString(ts)
}
/**
 * Get the time as a string in 'HH:MM' format.
 * 
 * @param {date} datetime - The datetime object including time.
 * @returns Returns the formatted time-string.
 * @example 12:30
 */
export function toTimeString(datetime) {
    return [String(datetime.getHours()).padStart(2, '0'), String(datetime.getMinutes()).padStart(2, '0')]
        .join(':')
}
/**
 * Get the date, time and duration as a formatted string.
 * 
 * @param {string} date - The date.
 * @param {string} time - The start-time.
 * @param {number} duration - The time-duration.
 * @returns Returns the formatted datetime-string.
 * @example 9:30 am - 10:00 am
 */
export function displayTimeslot(date, time, duration) {
    const endtime = calculateEndTime(date, time, duration)
    return `${time} - ${endtime}`
}
/**
 * Get the date as a string in 'dd-MM-yyyy' format.
 * 
 * @param {Date} date - The date to format.
 * @returns Returns the formatted date-string.
 * @example 16-Apr-2023
 */
export function displayDate(date) {
    const ts = new Date(date)
    const day = String(ts.getDate()).padStart(2, '0')
    const month = shortMonthts[ts.getMonth()]
    const year = String(ts.getFullYear())
    return [day, month, year].join('-')
}
/**
 * Get the date as a string in 'day, dd MM yyyy' format.
 * 
 * @param {Date} date - The date to format.
 * @returns {string} Returns the formatted date-string.
 * @example Zondag, 11 Juni 2023
 */
export function displayFullDate(date) {
    const weekday = weekdays[date.getDay()]
    const day = String(date.getDate()).padStart(2, '0')
    const month = months[date.getMonth()]
    const year = date.getFullYear()
    return `${weekday}, ${day} ${month} ${year}`
}
/**
 * Get the date as a string in 'yyyy-mm-dd' format.
 * 
 * @param {Date} date - The date to format.
 * @returns {string} Returns the formatted date-string.
 * @example 2023-11-27
 */
export function toDateString(date) {
    const year = date.getFullYear()
    const month = String(date.getMonth() + 1).padStart(2, '0')
    const day = String(date.getDate()).padStart(2, '0')
    return `${year}-${month}-${day}`
}
/**
 * Get the next date.
 * 
 * @param {Date} date - The current date.
 * @returns {Date} Returns the next date.
 */
export function nextDate(date) {
    var newDate = new Date(date)
    newDate.setDate(newDate.getDate() + 1)
    return newDate
}
/**
 * Get the previous date.
 * 
 * @param {Date} date - The current date.
 * @returns {Date} Returns the previous date.
 */
export function previousDate(date) {
    var newDate = new Date(date)
    newDate.setDate(newDate.getDate() - 1)
    return newDate
}
/**
 * Get next valid date if date is Sunday or Monday.
 * 
 * @param {Date} date - The current date object.
 * @returns Returns the next valid date.
 */
export function skipSundayAndMonday(date) {
    if (date.getDay() == 0) {
        date.setDate(date.getDate() + 2)
    }
    if (date.getDay() == 1) {
        date.setDate(date.getDate() + 1)
    }
    return date
}
/**
 * Get previous valid date if date is Sunday or Monday.
 * 
 * @param {Date} date - The current date object.
 * @returns Returns the previous valid date.
 */
export function skipMondayAndSunday(date) {
    if (date.getDay() == 0) {
        date.setDate(date.getDate() - 1)
    }
    if (date.getDay() == 1) {
        date.setDate(date.getDate() - 2)
    }
    return date
}
/**
 * Add days to a date.
 * 
 * @param {Date} date - the current date object.
 * @param {Number} day - The number of days to add to date.
 * @returns Returns the new date.
 */
export function addDays(date, day) {
    var newDate = new Date(date)
    newDate.setDate(newDate.getDate() + day)
    return newDate
}
/**
 * Get the date as a string in 'day mm dd' format.
 * 
 * @param {Date} date - The current date object.
 * @returns Returns the formatted date.
 * @example 'Maa Nov 08'
 */
export function shortDateDisplay(date) {
    const weekday = shortWeekdays[date.getDay()]
    const month = shortMonthts[date.getMonth()]
    const day = String(date.getDate()).padStart(2, '0')
    return [weekday, month, day].join(' ')
}

export function displayDateTime(datetime) {
    const ts = new Date(datetime)
    const day = String(ts.getDate()).padStart(2, '0')
    const month = shortMonthts[ts.getMonth()]
    const year = String(ts.getFullYear())
    const hour = String(ts.getHours()).padStart(2, '0')
    const min = String(ts.getMinutes()).padStart(2, '0')
    const am_pm = ts.getHours() < 12 ? 'am' : 'pm'
    return `${day} ${month} ${year}, ${hour}:${min} ${am_pm}`
}