
$(document).ready(function () {

    var $editRoutineName = $("#edit-routine-name");

    $editRoutineName.click(function () {
        var $routineName = $("#routine-name");
        var $routineNameInput = $("#routine-name-input");

        if ($routineName.is(":visible")) {
            $(this).removeClass("fa-solid fa-pen")
                .addClass("fa-solid fa-arrow-up-right-from-square");

            $routineName.removeClass("d-inline").hide();

            $routineNameInput.prop("hidden", false).show();
        } else {
            $(this).removeClass("fa-solid fa-arrow-up-right-from-square")
                .addClass("fa-solid fa-pen");

            submitRoutineForm();
        }
    });

    function submitRoutineForm(name) {
        const URL = "https://localhost:44317/api/routines/";

        var $id = $("input[name='Routine.Id']").val();
        var $nameInput = $("input[name='Routine.Name']").val();
        var $name = $(name);

        $.ajax({
            url: URL + $id,
            type: "PUT",
            contentType: "application/json",
            data: JSON.stringify({ id: $id, name: $nameInput })
        })
            .done(function (data) {
                $nameInput.hide();
                $name.addClass("d-inline");
            });
    }



    //var $dayOfTraining = $(".select-day-exercise");

    //$dayOfTraining.click(function () {

    //    var $routineId = $('#Routine_Id').val();
    //    var $day = $(this).attr('name');

    //    var $dayDiv = $(`#${$day}`);

    //    //This is basically a new form to be inserted in the routine's detail page with default values.
    //    // It is also setting the corresponding value of the DayOfTraining property on the ExerciseModel.
    //    var inputs = `<form class="mt-3 mt-lg-4" novalidate="novalidate"> <div class="row"> <input type="hidden" name="RoutineId" value="${$routineId}"> <input data-val="true" data-val-required="The Training Day field is required." id="DayOfTraining" name="DayOfTraining" type="hidden" 	value="${$day}"><div class="col-3 position-relative"> <span class="field-validation-valid" data-valmsg-for="Name" data-valmsg-replace="true"></span> <input class="small exercise-inputs" data-val="true" data-val-required="The Name field is required." id="Name" name="Name" type="text" value=""> </div> <div class="col-3 position-relative"> <span class="field-validation-valid" data-valmsg-for="Weight" data-valmsg-replace="true"></span> <input class="small exercise-inputs" data-val="true" data-val-number="The field Weight must be a number." data-val-range="The field Weight must be between 1 and 2000." data-val-range-max="2000" data-val-range-min="1" data-val-required="The Weight field is required." id="Weight" name="Weight" size="3" type="text" value="0"> lbs </div> <div class="col-3 position-relative"> <span class="field-validation-valid" data-valmsg-for="Repetitions" data-valmsg-replace="true"></span> <input class="small exercise-inputs" data-val="true" data-val-number="The field Repetitions must be a number." data-val-required="The Repetitions field is required." id="Repetitions" name="Repetitions" size="3" type="text" value="0"> </div> <div class="col-3 position-relative"> <span class="field-validation-valid" data-valmsg-for="Sets" data-valmsg-replace="true"></span> <input class="small exercise-inputs" data-val="true" data-val-number="The field Sets must be a number." data-val-range="The field Sets must be between 1 and 10." data-val-range-max="10" data-val-range-min="1" data-val-required="The Sets field is required." id="Sets" name="Sets" size="3" type="text" value="0"> <span class="add"><i class="fa-solid fa-arrow-up-from-bracket"></i></span> </div> </div> </form>`;

    //    $dayDiv.append(inputs);

    //    var $add = $(".add");

    //    $add.click(function () {
    //        setUpToSubmit(this, "POST");
    //    });
    //});



    var $edit = $(".edit");

    $edit.click(function () {
        setUpToSubmit(this, "PUT");
    });
    

    function setUpToSubmit(target, httpVerb) {
        const $inputs = $(target).parent().parent().find("input");
        const $icon = $(target).children();

        if ($icon.hasClass("fa-pen-to-square")) {

            $inputs.prop("disabled", false);
            $icon.removeClass(["fa-regular", "fa-pen-to-square"]).addClass(["fa-solid", "fa-arrow-up-from-bracket"]);
        
        } else {
            submitExerciseInput(httpVerb, $inputs, $icon);
        }
    }

    function submitExerciseInput(httpVerb, inputs, icon) {

        const routineId = inputs.siblings("input[name='RoutineId']").val();
        const id = inputs.siblings("input[name='Id']").val();
        let URL = `https://localhost:44317/api/routines/${routineId}/exercises/${id}`;

        if (httpVerb === "POST") {
            URL = `https://localhost:44317/api/routines/${routineId}/exercises`;
        }

        $.ajax({
            url: URL,
            type: httpVerb,
            contentType: "application/json",
            data: urlEncodedToJSON(inputs.serialize())
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


