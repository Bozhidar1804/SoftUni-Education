document.addEventListener('DOMContentLoaded', solve);

function solve() {
    let inputEl = document.querySelector('#email');

    const regex = /^[a-z0-9]+@[a-z0-9]+\.[a-z]{2,}$/;

    inputEl.addEventListener('change', () => {
        let email = inputEl.value;
        if (!regex.test(email)) {
            inputEl.classList.add('error');
        } else {
            inputEl.classList.remove('error');
        }
    });
}
