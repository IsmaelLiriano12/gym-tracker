$(document).ready(function () {
    const URL = 'https://wger.de/api/v2/exercisebaseinfo/?offset=30&limit=7'; 
    const $listOfExercises = $('#exercises');


    $.ajax(URL)
        .done(function (data) {
            appendExercises(data.results);
        });
   
    function appendExercises(exercises) {

        for (const exercise of exercises) {
            $listOfExercises.append(`<div class="card mb-2 col-lg-2" style="width: 16rem;">
            <img src="${getImage(exercise.images)}" class="card-img-top" style="max-height: 14rem">
            <div class="card-body">
            <h3 class="card-title">${getName(exercise.exercises)}</h3>
            <div class="card-subtitle">${getMuscles(exercise.muscles)}</div>
            </div>
            </div>`);
        }
        
    }

    function getImage(images) {
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

    function getMuscles(muscles) {
        let elements = "";
        for (const muscle of muscles) {
            elements += `<span class="rounded-pill">${muscle.name_en} </span>`;
        }
        return elements;
    }
})