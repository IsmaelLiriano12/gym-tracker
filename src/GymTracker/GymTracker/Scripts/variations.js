$(document).ready(function () {
    var $variations = $('#variations').text();
    const URL = `https://localhost:44317/api/wger/exercisebaseinfo/?variations=${$variations}`;

    var $glider = $(".glider");

    $.ajax(URL)
        .done(function (data) {
            $glider.html(template(data));

            new Glider(document.querySelector(".glider"), {
                slidesToShow: 5,
                slidesToScroll: 5,
                draggable: true,
                arrows: {
                    prev: '.glider-prev',
                    next: '.glider-next'
                }
            });

            addExercise();
        });

    function template(exerciseCollection) {

        let elements = ``;

        for (const exercise of exerciseCollection) {

            var exerciseName = getName(exercise.exercises);

            elements += `<div class="col-12 col-sm-4 col-lg-2 m-1">
                <div class="card">
                    <a href="https://localhost:44317/exerciseinfo/${exercise.id}"><img src="${getImage(exercise.images)}" class="card-img-top" style="height: 12rem;"></a>
                    <a href="https://localhost:44317/exerciseinfo/${exercise.id}">
                        <div class="card-body">
                            <h5 class="card-title fs-5 text-truncate">${exerciseName}</h5>
                            <p class="card-text fs-6"><span class="badge rounded-pill text-bg-primary">${exercise.category.name}</span></p>
                        </div>
                    </a>
                    <div class="card-footer">
                        <div class="dropdown m-0">
                            <button type="button" class="add-exercise btn btn-primary mb-3 dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false">
                                Add to routine
                            </button>
                            <ul class="dropdown-menu">
                                 <li><a name="${exerciseName}_${exercise.id}_First" class="dropdown-item select-day-exercise" href="#">First Day</a></li>
                                <li><a name="${exerciseName}_${exercise.id}_Second" class="dropdown-item select-day-exercise" href="#">Second Day</a></li>
                                <li><a name="${exerciseName}_${exercise.id}_Third" class="dropdown-item select-day-exercise" href="#">Third Day</a></li>
                                <li><a name="${exerciseName}_${exercise.id}_Fourth" class="dropdown-item select-day-exercise" href="#">Fourth Day</a></li>
                                <li><a name="${exerciseName}_${exercise.id}_Fifth" class="dropdown-item select-day-exercise" href="#">Fifth Day</a></li>
                                <li><a name="${exerciseName}_${exercise.id}_Sixth" class="dropdown-item select-day-exercise" href="#">Sixth Day</a></li>
                                <li><a name="${exerciseName}_${exercise.id}_Seventh" class="dropdown-item select-day-exercise" href="#">Seventh Day</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>`;
        }

        return elements;
    }


    function getImage(images) {

        if (images.length === 0) {
            return "https://localhost:44317/Content/Img/no-image.PNG";
        }

        let imageAddress = "";
        for (const image of images) {
            imageAddress = image['image'];
            break;
        }
        return imageAddress;
    }

    function getName(exercises) {
        let name = "";
        for (const exercise of exercises) {
            if (exercise.language === 2 || exercise.language === 4) {
                name = exercise.name;
                break;
            }
        }
        return name;
    }


    function addExercise() {
        $(".select-day-exercise").click(function () {

            $("div.alert-container").html(insertAlert());
            
            var values = $(this).attr("name").split("_");

            $.ajax({
                url: "https://localhost:44317/api/exercises",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({ name: values[0], exerciseBaseId: values[1], trainingDay: values[2] })
            });

        });
    }

    function insertAlert() {
        return '<div class="alert alert-primary alert-dismissible fade show" role="alert"><p> Exercise added successfully!</p ><button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div >';
    }
});