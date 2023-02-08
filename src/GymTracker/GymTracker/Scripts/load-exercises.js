$(document).ready(function () {
    const URL = 'https://localhost:44317/api/wger/exercisebaseinfo';
    var $dataContainer = $('#exercises');

    getPagination("");

    $('form').submit(function (e) {
        e.preventDefault();

        $('body').css("cursor", "progress");

        var $exerciseNameTried = $('input').val();

        getPagination(`/suggestions/${$exerciseNameTried}`);
    });


    function getPagination(uri) {
        $('#pagination').pagination({
            dataSource: function (done) {
                $.ajax({
                    type: 'GET',
                    url: URL + uri,
                    success: function (response) {
                        $('body').css("cursor", "default");
                        done(response);
                    }
                });
            },
            callback: function (data, pagination) {
                var html = template(data);
                $dataContainer.html(html);
            }

        });
    }


    function template(exerciseCollection) {

        let elements = ``;

        for (const exercise of exerciseCollection) {
            elements += `<div class="col-12 col-sm-4 col-lg-2 m-2"><a href="https://localhost:44317/exerciseinfo/${exercise.id}"><div class="card">
            <img src="${getImage(exercise.images)}" class="card-img-top" style="height: 12rem;>
            <div class="card-body">
            <h5 class="card-title fs-5">${getName(exercise.exercises)}</h5>
            <p class="card-text fs-6"><span class="badge rounded-pill text-bg-primary">${exercise.category.name}</span></p>
            <a href="#" class="btn btn-primary w-50 m-auto" style="font-size: 60%;">Add</a>
            </div>
            </div></a></div>`;
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

})