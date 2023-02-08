$(document).ready(function () {

    
    $(".accordion-collapse").each(function (index) {

        var $ids = $(this).attr("id").split('_');

        getExerciseInfo($ids[1]);
        getDataAndGenerateChart( $ids[0].substring(9) );
    });

    function getExerciseInfo(exerciseBaseId) {
        const URL = `https://localhost:44317/api/wger/exercisebaseinfo/${exerciseBaseId}`;

        $.ajax(URL)
            .done(function (data) {
                $(`#exercise-img-${exerciseBaseId}`).html(template(data));
            });
    }

    function template(exerciseBaseInfo) {
        return `<div class="p-2 mb-3">
                    <div class="container-fluid py-1">
                        <img src="${getImage(exerciseBaseInfo.images)}" alt="Exercise image" style="width: 75%;" />
                        <br />
                        <span class="badge rounded-pill text-bg-primary">${exerciseBaseInfo.category.name}</span>
                    </div>
                </div>`;
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

    function getDataAndGenerateChart(exerciseId) {
        const URL = `https://localhost:44317/api/exercises/${exerciseId}/progresses`;

        const progressiveOverloads = [];

        $.ajax(URL)
            .done(function (data) {
                for (const progress of data) {
                    progressiveOverloads.push(progress);
                }
                generateChart(progressiveOverloads, `chart-${exerciseId}`);
            });
    } 

    
    function generateChart(progresses, chartId) {
        const ctx = document.getElementById(chartId);

        new Chart(ctx, {
            type: 'line',
            data: {
                labels: getMonths(progresses),
                datasets: [
                    {
                        backgroundColor: '#2c7be5',
                        label: 'Weight lifted each month (lbs)',
                        data: getWeightsLifted(progresses),
                        borderColor: '#2c7be5'
                    }
                ]
            }
        });
    }


    function getWeightsLifted(progresses) {
        var weights = [];

        for (const progress of progresses) {
            weights.push(progress.weight);
        }

        return weights;
    }

    function getMonths(progresses) {

        const months = {
            0: "January", 1: "February", 2: "March", 3: "April", 4: "May", 5: "June",
            6: "July", 7: "August", 8: "September", 9: "October", 10: "November", 11: "December"
        };

        const monthsFromData = [];

        for (progress of progresses) {

            var date = new Date(progress.date);
            monthsFromData.push(months[date.getMonth()]);

        }

        return monthsFromData;
    }

});