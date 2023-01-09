$(document).ready(function () {

    var $exerciseId = $('#exerciseId').attr('name');
    var $routineId = $('#routineId').attr('name');

    const URL = `https://localhost:44317/api/routines/${$routineId}/exercises/${$exerciseId}/progresses`;
    
    const progressiveOverloads = [];

    $.ajax(URL)
        .done(function (data) {
            for (const progress of data) {
                progressiveOverloads.push(progress);
            }
            generateChart(progressiveOverloads);
        });


    function generateChart(progresses) {
        const ctx = document.getElementById('chart');

        new Chart(ctx, {
            type: 'line',
            data: {
                labels: getMonths(progresses),
                datasets: [
                    {
                        backgroundColor: '#2c7be5',
                        label: 'Last Weight Lifted (lbs)',
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