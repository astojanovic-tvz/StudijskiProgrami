// region Document.ready
$(document).ready(function () {
    $("#kompetencije-shower").click(function (e) {
        var occupationsArray = findCheckedCheckboxes();
        initiateControllerAction(occupationsArray);
    });

    function findCheckedCheckboxes() {
        var checkboxDiv = $(".zanimanja-div");
        var occupationsArray = new Array();
        occupationsArray = checkboxDiv.find("input:checkbox:checked").map(function () {
            var occupationObject = {};
            occupationObject.IdZanimanja = $(this).val();

            //occupationObject.NameZanimanja = $(this).prev().context.labels[0].innerHTML;
            occupationObject.NameZanimanja = $(this).prev().context.nextElementSibling.firstChild.nodeValue;

            return occupationObject;
        }).get();
        return occupationsArray;
    }

    function initiateControllerAction(occupationsArray) {
        $(".ajaxAlertMessageDiv").remove();
        $("#kompetencijeDynamicDiv").remove();
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "/Kompetencije/_GetOccupationsForCompetencyArray",
            data: JSON.stringify(occupationsArray),
            dataType: "json",
            success: function (data) {
                if (data.type == 2) {
                    $("#_AjaxInfoMessage").prepend('<div class ="alert alert-warning ajaxAlertMessageDiv">' + data.message + "</div>");
                }
                if (data.type == 0) {
                    $("#_KompetencijeTabbedResult").prepend('<div id="kompetencijeDynamicDiv">' + data.message + "</div>");
                }
                if (data.type == 1) {
                    $("#_AjaxInfoMessage").prepend('<div class ="alert alert-danger ajaxAlertMessageDiv">' + data.message + "</div>");
                }
                $('.kompetencije-table').DataTable({
                    "bAutoWidth": false
                });
            },
            error: function (xhr, err, data) {
                alert("readyState: " + xhr.readyState + "\nstatus: " + xhr.status);
                alert("responseText: " + xhr.responseText);
                $("#_AjaxInfoMessage").prepend('<div class ="alert alert-danger ajaxAlertMessageDiv">' + data.message + "</div>")
            }
        });
    }
});