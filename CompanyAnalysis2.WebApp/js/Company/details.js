
$(document).ready(function () {
    $(".chart-selector").change(function (e) {
        //Get Chart
        var chartNumber = this.id
        chartNumber = chartNumber.substring(chartNumber.length - 1);
        var chartUrl = "/company/_Chart?name=" + $(this).val() + "&companyId=" + $("#Id").val();
        chartUrl = encodeURI(chartUrl);
        $.ajax({
            url: chartUrl,
            cache: false,
            async: true
        }).done(function (data) {
            var divId = "#chart" + chartNumber;
            $(divId).html(data);
        });

        //Store UserSetting
        if ($("#Email").val() != "") {
            var settingUrl = "/account/setusersetting?email=" + $("#Email").val() + "&name=Chart" + chartNumber + "&value=" + $(this).val();
            $.ajax({
                url: settingUrl,
                cache: false,
                async: true
            })
        }
    });

    $('#NextReportDate').datepicker({
        dateFormat: "yy-mm-dd",
        firstDay: 1,
        monthNamesShort: ["Jan", "Feb", "Mar", "Apr", "Maj", "Jun", "Jul", "Aug", "Sep", "Okt", "Nov", "Dec"],
        monthNames: ["Januari", "Februari", "Mars", "April", "Maj", "Juni", "Juli", "Augusti", "September", "Oktober", "November", "December"],
        showWeek: true,
        dayNames: ["Söndag", "Måndag", "Tisdag", "Onsdag", "Torsdag", "Fredag", "Lördag"],
        dayNamesMin: ["Sö", "Må", "Ti", "On", "To", "Fr", "Lö"],
        weekHeader: ""
    });

    $('#NextReportDate').change(function () {
        if ($(this).val().length == 10 || $(this).val().length == 0) {
            var url = "/company/editnextreportdate?id=" + $("#Id").val() + "&nextReportDate=" + $(this).val();
            $.ajax({
                url: url,
                cache: false,
                async: true
            });
        }
    });

    $(window).resize(function () {
        $('.chart').each(function () {
            var chartName = $(this).children(":first").data('chart-name');
            var companyId = $(this).children(":first").data('company-id');
            var chartUrl = "/company/_Chart?name=" + chartName + "&companyId=" + companyId;
            chartUrl = encodeURI(chartUrl);
            $.ajax({
                url: chartUrl,
                cache: false,
                async: true
            }).done(function (data) {
                $(this).html(data);
            });
        });
    });
});
