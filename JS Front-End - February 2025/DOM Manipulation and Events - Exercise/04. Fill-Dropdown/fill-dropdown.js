document.addEventListener('DOMContentLoaded', solve);

function solve() {
    let button = document.querySelector('input[type="submit"]');

    button.addEventListener('click', addOption);

    function addOption(ev) {
        ev.preventDefault();

        let text = document.getElementById('newItemText').value;
        let value = document.getElementById('newItemValue').value;

        let optionEl = document.createElement('option');
        optionEl.textContent = text;
        optionEl.value = value;

        let menuEl = document.getElementById('menu');
        menuEl.appendChild(optionEl);

        document.getElementById('newItemText').value = '';
        document.getElementById('newItemValue').value = '';
    }
}