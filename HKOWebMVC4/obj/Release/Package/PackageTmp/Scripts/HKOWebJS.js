function resetAjaxMessage() {
    $(".ajaxAlertMessageDiv").remove();
};

$(document).ready(function () {
    $('#zanimanjaStudijiTable').DataTable();
    $('#kompetencije').DataTable();
    $('#radnaMjesta').DataTable();
    $('#kljucniPoslovi').DataTable();
    $('#preporuceniTable').DataTable();
    $('#obavezniTable').DataTable();
    $('#izborniTable').DataTable();
    $('#studijskiProgramiTable').DataTable();
    $('#kandidatiTable').DataTable();
    $('#studentKompetencije').DataTable();
    $('#ishodiUcenjaTable').DataTable();

    $(".saveProffesionsChoice").click(function (event) {
        saveOdabranaZanimanja();
    });

    function saveOdabranaZanimanja() {
        resetAjaxMessage();
        var proffesionList = new Array();
        var forma = $('#odabirZanimanjaForm');
        var chosenProffesions = forma.find("li").has("input:checked")
        chosenProffesions.each(function () {
            var proffesion = {};
            proffesion['zanimanjeId'] = $(this).find('.zanimanjeId').val();
            proffesion['zanimanjeNaziv'] = $(this).find('.zanimanjeNaziv').text();
            proffesionList.push(proffesion);
        })
        var formData = JSON.stringify(proffesionList);
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "/User/SaveChosenProffesion",
            data: formData,
            dataType: "json",
            success: function (data) {
                if (data.type != 0) {
                    $("#_AjaxInfoMessage").prepend('<div class ="alert alert-danger ajaxAlertMessageDiv">' + data.message + "</div>")
                } else {
                    $("#_AjaxInfoMessage").prepend('<div class ="alert alert-success ajaxAlertMessageDiv">' + data.message + "</div>")
                }
            }
        });
    }
})