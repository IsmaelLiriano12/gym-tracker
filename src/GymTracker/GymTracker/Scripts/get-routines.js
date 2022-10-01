
$(document).ready(function () {
    const $dropDownMenu = $("#dropdown-menu");

    const URL = "https://localhost:44317/api/routines";

    $.ajax(URL)
        .done(function (routines) {
            for (const routine of routines) {
                $dropDownMenu.append(`<li><a class="nav-link" href="/Routine/Detail/${routine.id}">${routine.name}</a></li>`);
            }
        })
        .fail(function (error) {
            console.log(error);
        });
});



