$(document).ready(function () {
    const URL = "https://localhost:44317/api/wger/ingredients/";

    addExerciseBehaviour();

    $("#total-calories").html("Calories: " + sum(".calories") + " kcal");

    resetChart();

    let timeout = null;

    $("input[name='name']").on('keyup', function () {
        clearTimeout(timeout);

        var currentInput = $(this);
        var value = $(this).val();
        var dropdownMenu = $(this).siblings();

        timeout = setTimeout(function () {
            $.ajax(URL + value)
                .done(function (data) {
                    getDropdownItems(dropdownMenu, data);
                    setInputValueOnClick(currentInput);
                });
        }, 1000);
    });

    function getDropdownItems(dropdownMenu, items) {
        $(dropdownMenu).html(template(items));
    }

    function template(items) {
        let elements = "";
        for (const item of items) {
            elements += `<li class="text-truncate"><a id="${item.data.id}" class="dropdown-item" href="#">${item.value}</a></li>`
        }
        return elements;
    }

    function setInputValueOnClick(input) {
        $(".dropdown-item").click(function () {
            $(input).val($(this).text());
            $(input).parent().siblings("input[name='wgerNutritionResultId']").val($(this).attr('id'));
        });
    }

    function addExerciseBehaviour() {
        $(".save-button").click(function () {

            var id = $(this).attr('id');

            var $form = $(`#${id}-form`);

            var addButtonId = `#add-${id}`;

            $.ajax({
                url: URL + window.location.search,
                type: "POST",
                contentType: "application/json",
                data: urlEncodedToJSON($form.serialize())
            }).done(function (data) {
                
                $(`${addButtonId}`).before(`<div class="row">
                                                <div class="col-10 row">
                                                    <div class="col-12">
                                                        <p>${data.name}</p>
                                                    </div>
                                                    <div class="col-12">
                                                        <p class="fw-lighter fs-6">${data.amount} g</p>
                                                    </div>
                                                </div>
                                                <div class="col-2">
                                                    <p class="calories">${data.nutritionFacts.energy} kcal</p> 
                                                </div>
                                            </div>
                                            <p class="d-none protein">${data.nutritionFacts.protein}</p>
                                            <p class="d-none carbs">${data.nutritionFacts.carbohydrates}</p>
                                            <p class="d-none fat">${data.nutritionFacts.fat}</p>`);

                
                resetChart();
            });
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

    function resetChart() {
        var ctx = document.getElementById("macros-chart");

        var proteinValues = $(".protein");
        var carbsValues = $(".carbs");
        var fatValues = $(".fat");

        new Chart(ctx, {
            type: 'pie',
            data: {
                labels: ['Protein', 'Carbohydrates', 'Fat'],
                datasets: [
                    {
                        label: "Macros",
                        data: [sum(proteinValues), sum(carbsValues), sum(fatValues)],
                        backgroundColor: [
                            '#2c7be5',
                            '#27bcfd',
                            '#00d27a'
                        ]
                    }
                ]
            }
        });
    }

   

    function sum(values) {
        let total = 0;

        $(values).each(function () {
            total += Number($(this).text());
        });

        return total;
    }
});