$(document).ready(function () {

    $(".star").click(function () {
        var companyId = this.id.split("-")[1];
        var url = "/company/starunstarcompany?email=" + $("#Email").val() + "&companyId=" + companyId;
        url = encodeURI(url);
        $.ajax({
            url: url,
            cache: false,
            async: true,
            success: function (e) {
                var star = $("#star-" + companyId);
                if (star.attr("src") == "/images/star-yellow16.png") {
                    star.attr("src", "/images/star-silver16.png");
                }
                else {
                    star.attr("src", "/images/star-yellow16.png");
                }
            }
        });

    });

    $("#filter").change(function () {
        //Store UserSetting
        if ($("#Email").val() != "") {
            var settingUrl = "/account/setusersetting?email=" + $("#Email").val() + "&name=CompanyListFilter&value=" + $(this).val();
            $.ajax({
                url: settingUrl,
                cache: false,
                async: true,
                success: function(){
                    window.location.reload();
                }
            })
        }
    });

    //$('.nextReportDate').datepicker({
    //    dateFormat: "yy-mm-dd",
    //    firstDay: 1,
    //    monthNamesShort: ["Jan", "Feb", "Mar", "Apr", "Maj", "Jun", "Jul", "Aug", "Sep", "Okt", "Nov", "Dec"],
    //    monthNames: ["Januari", "Februari", "Mars", "April", "Maj", "Juni", "Juli", "Augusti", "September", "Oktober", "November", "December"],
    //    showWeek: true,
    //    dayNames: ["Söndag", "Måndag", "Tisdag", "Onsdag", "Torsdag", "Fredag", "Lördag"],
    //    dayNamesMin: ["Sö", "Må", "Ti", "On", "To", "Fr", "Lö"],
    //    weekHeader: ""
    //});

    //$('.nextReportDate').change(function () {
    //    var companyId = this.id.split("-")[1];
    //    if ($(this).val().length == 10 || $(this).val().length == 0) {
    //        var url = "/company/editnextreportdate?id=" + companyId + "&nextReportDate=" + $(this).val();
    //        $.ajax({
    //            url: url,
    //            cache: false,
    //            async: true
    //        });
    //    }
    //});

});