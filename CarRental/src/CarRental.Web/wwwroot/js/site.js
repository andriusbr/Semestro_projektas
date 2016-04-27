function orderTime(firstDate, secondDate) {
    var startDay = new Date(firstDate.value);
    startDay.setHours(00, 00, 0, 0);
    var endDay = new Date(secondDate.value);
    endDay.setHours(00, 00, 0, 0);
    var millisecondsPerDay = 1000 * 60 * 60 * 24;
    var millisBetween = endDay.getTime() - startDay.getTime();
    var days = millisBetween / millisecondsPerDay;
    if (days > -1)
        $('#duration').val(days);
}
