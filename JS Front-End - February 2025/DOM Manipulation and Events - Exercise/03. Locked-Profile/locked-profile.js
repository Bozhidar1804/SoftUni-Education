document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const allButtons = document.querySelectorAll('button');

    for (let button of allButtons) {
        let profileDiv = button.parentElement;
        const userUnlockBtn = profileDiv.querySelector('input[type="radio"][value="unlock"], input[id$="Unlock"]');
        const userHiddenInfo = profileDiv.querySelector('.hidden-fields');

        button.addEventListener('click', () => {
            if (userUnlockBtn.checked && button.textContent == 'Show more') {
                userHiddenInfo.classList.remove('hidden-fields', 'active');
                button.textContent = 'Show less';
            } else if (userUnlockBtn.checked && button.textContent == 'Show less') {
                userHiddenInfo.classList.add('hidden-fields', 'active');
                button.textContent = 'Show more';
            }
        })
    }
}