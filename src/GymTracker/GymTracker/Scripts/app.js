const button = document.getElementById('show-history');
const progressHistory = document.querySelector('.progress-history');

button.addEventListener('click', () => {
    if (progressHistory.style.opacity === '0') {
        progressHistory.style.opacity = '1';
        progressHistory.style.fontSize = 'inherit';
        progressHistory.style.transition = 'opacity 1s 0s, width 1s 0s, font-size 1s 0s';
        button.textContent = 'Collapse History';
    } else {
        button.textContent = 'Show History';
        progressHistory.style.opacity = '0';
        progressHistory.style.fontSize = '0.1rem';
        progressHistory.style.transition = 'opacity 1s 0s, width 1s 0s, font-size 1s 0s';
    }
});
