$(document).ready(function () {
    $('.delete-link').click(function(){
        var reportId = $(this).data('report-id');
        var reportName = $(this).data('report-name');
        $('#modal-report-name').text(reportName);
        $('#modal-report-id').val(reportId);
    });
});