function toggle() {
    let buttonCurrentValue = document.getElementsByClassName('button')[0].textContent;
    let extraText = document.getElementById('extra');

    if (buttonCurrentValue == "More") {
        extraText.style.display = 'block';
        document.getElementsByClassName('button')[0].textContent = "Less"
    } if (buttonCurrentValue == "Less") {
        extraText.style.display = 'none';
        document.getElementsByClassName('button')[0].textContent = "More";
    }
}