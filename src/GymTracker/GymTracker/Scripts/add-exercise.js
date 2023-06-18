$(document).ready(function () {
    const URL = "https://localhost:44317/api/exercises"

    $(".select-day-exercise").click(function () {

        console.log("clicked");
        var values = $(this).attr("name").split("-");

        $.ajax({
            url: URL,
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ name: removeUnderscore(values[0]), exerciseBaseId: values[1], trainingDay: values[2] })
        });
    });

    function removeUnderscore(name) {
        return name.replaceAll("_", " ");
    }
})