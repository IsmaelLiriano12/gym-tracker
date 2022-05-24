const button = document.getElementById('show-history');
const progressHistory = document.querySelector('.progress-history');

button.addEventListener('click', () => {
    if (progressHistory.style.opacity === '0') {
        progressHistory.style.opacity = '1';
        progressHistory.style.transform = 'scale(1)';
        progressHistory.style.transition = 'opacity 1s 0s, transform 1s 0s';
        button.textContent = 'Collapse History';
    } else {
        button.textContent = 'Show History';
        progressHistory.style.opacity = '0';
        progressHistory.style.transform = 'scale(0.1)';
        progressHistory.style.transition = 'opacity 1s 0s, transform 1s 0s';
    }
});
