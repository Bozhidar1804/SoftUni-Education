function attachGradientEvents() {
    let resultEl = document.querySelector('#result');
    let gradientEl = document.querySelector('#gradient');

    gradientEl.addEventListener('mousemove', (e) => {
        const currentPos = e.offsetX;
        const elementWidth = e.currentTarget.clientWidth;

        const percent = Math.floor((currentPos / elementWidth) * 100);

        resultEl.textContent = percent + '%';
    });
}
