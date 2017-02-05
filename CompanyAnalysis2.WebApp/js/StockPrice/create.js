$(document).ready(function () {
    $('#Date').datepicker({
        dateFormat: "yy-mm-dd",
        firstDay: 1,
        monthNamesShort: ["Jan", "Feb", "Mar", "Apr", "Maj", "Jun", "Jul", "Aug", "Sep", "Okt", "Nov", "Dec"],
        monthNames: ["Januari", "Februari", "Mars", "April", "Maj", "Juni", "Juli", "Augusti", "September", "Oktober", "November", "December"],
        showWeek: true,
        dayNames: ["Söndag", "Måndag", "Tisdag", "Onsdag", "Torsdag", "Fredag", "Lördag"],
        dayNamesMin: ["Sö", "Må", "Ti", "On", "To", "Fr", "Lö"],
        weekHeader: ""
    });
});