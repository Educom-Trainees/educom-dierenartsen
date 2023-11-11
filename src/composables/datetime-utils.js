function calculateEndTime(date, time, duration) {
    const ts = new Date([date, time]
        .join(' '))
    ts.setMinutes(ts.getMinutes() + duration)
    return toTimeString(ts)
}
function toTimeString(datetime) {
    return [String(datetime.getHours()).padStart(2, '0'), String(datetime.getMinutes()).padStart(2, '0')]
        .join(':')
}
module.exports = {
    calculateEndTime,
  };