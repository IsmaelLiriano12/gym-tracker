
$(document).ready(function () {

    const URL = "https://localhost:44317/api/routines";

    getRoutines();

    function getRoutines() {
        const $dropDownMenu = $("#dropdown-menu");

        $.ajax(URL)
            .done(function (routines) {
                for (const routine of routines) {
                    $dropDownMenu.append(`<li><a class="nav-link" href="/Routine/Detail/${routine.id}">${routine.name}</a></li>`);
                }
                $dropDownMenu.append('<li><a class="nav-link" id="add-routine-button" href="#"><i class="fa-regular fa-plus"></i>Add Routine</a></li>');
                setButtonToAddRoutineOnClick();
            })
            .fail(function (error) {
                console.log(error);
            });
    }


    function setButtonToAddRoutineOnClick() {
        $('#add-routine-button').on('click', function () {
            $.ajax({
                url: URL,
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({ name: "Name", exercises: [] })
            })
                .done(function (routine) {
                    window.location.assign(`https://localhost:44317/Routine/Detail/${routine.id}`);
                });
        });
    }
});



