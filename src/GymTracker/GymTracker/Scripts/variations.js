$(document).ready(function () {
    var $variations = $('#variations').text();
    const URL = `https://localhost:44317/api/wger/exercisebaseinfo/?variations=${$variations}`;

    var $glider = $(".glider");

    $.ajax(URL)
        .done(function (data) {
            $glider.html(template(data));

            new Glider(document.querySelector(".glider"), {
                slidesToShow: "auto",
                slidesToScroll: 5,
                itemWidth: 200,
                draggable: true,
                arrows: {
                    prev: '.glider-prev',
                    next: '.glider-next'
                }
            });
        });

    function template(exerciseCollection) {

        let elements = ``;

        for (const exercise of exerciseCollection) {
            elements += `<div class="card m-1 h-50">
                   <a href="https://localhost:44317/exerciseinfo/${exercise.id}">
                   <img src="${getImage(exercise.images)}" class="card-img-top" style="width: 10rem; height: 12rem;">
                   <div class="card-body">
                      <h5 class="card-title fs-5">${getName(exercise.exercises)}</h5>
                      <p class="card-text fs-6"><span class="badge rounded-pill text-bg-primary">${exercise.category.name}</span></p>
                      <div class="text-center"><a href="#" class="btn btn-primary w-50 m-auto" style="font-size: 60%;">Add</a></div>
                   </div>
                   </a>
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
});