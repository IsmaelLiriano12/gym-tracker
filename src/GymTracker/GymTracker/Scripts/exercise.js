
$(document).ready(function () {
    const $edit = $(".edit");

    $edit.click(function () {

        const $inputs = $(this).parent().parent().find("input");
        const $icon = $(this).children();

        if ($icon.hasClass("fa-pen-to-square")) {

            $inputs.prop("disabled", false);
            $icon.removeClass(["fa-regular", "fa-pen-to-square"]).addClass(["fa-solid", "fa-arrow-up-from-bracket"]);
        } else {

            const id = $inputs.val();
            const URL = `https://localhost:44317/api/exercises/${id}`;

            submit(URL, $inputs, $icon);
        }

    });




    function submit(url, inputs, icon) {
        $.ajax({
            url: url,
            type: "PUT",
            contentType: "application/json;charset=utf-8",
            data: urlEncodedToJSON(inputs.serialize().replaceAll("exercise.", ""))
        })
        .done(function () {
            inputs.prop("disabled", true);
            icon.removeClass(["fa-solid", "fa-arrow-up-from-bracket"]).addClass(["fa-regular", "fa-pen-to-square"]);
        });
    }

    function urlEncodedToJSON(urlEncoded) {
        const pairs = urlEncoded.split("&");
        const result = {};

        pairs.forEach(function (pair) {
            pair = pair.split("=");
            result[pair[0]] = decodeURIComponent(pair[1] || "");
        });

        return JSON.stringify(result);
    }

});


