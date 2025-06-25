document.addEventListener('DOMContentLoaded', focused);

function focused() {
    let allInputs = document.querySelectorAll('.panel input');

    for (let input of allInputs) {
        input.addEventListener('focus', () => {
            input.parentElement.classList.add('focused')
        });
        input.addEventListener('blur', () => {
            input.parentElement.classList.remove('focused');
        });
    }
}
