(function ($) {

    function fnInitTracker(url,method) {
        fnGetCards(url, method, fnUpdateCards);

        setInterval(function () {
            fnGetCards(url, method, fnUpdateCards);
        }, 60000);
    }

    function fnGetCards(url, method) {
        $.ajax({
            url: url,
            method: method,
            async : true,
            success: function (data) {
                fnUpdateCards(data);
            }
        });
    }

    function fnUpdateCards(data) {
        let progress = document.getElementById("progressCard");
        let adherence = document.getElementById("adherenceCard");
        let conformity = document.getElementById("conformityCard");

        progress.innerHTML = (data["totalProgress"] * 100.0).toFixed(1) + "%";
        adherence.innerHTML = (data["totalAdherence"] * 100.0).toFixed(1) + "%";
        conformity.innerHTML = (data["totalConformity"] * 100.0).toFixed(1) + "%";
    }

    $(document).ready(function () {
        fnInitTracker("/Home/GetProgress/", "POST");

    });

} ( jQuery ))