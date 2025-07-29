function add(a, b) {
  return a + b;
}

function subtract(a, b) {
  return a - b;
}

function multiply(a, b) {
  return a * b;
}

function calculateAndDisplay(fn) {
  const rawA = document.getElementById('a').value;
  const rawB = document.getElementById('b').value;

  if (rawA === '' || rawB === '') {
    document.getElementById('result').textContent = 'Please fill both inputs';
    return;
  }

  const a = Number(rawA);
  const b = Number(rawB);
  document.getElementById('result').textContent = fn(a, b);
}

document.getElementById('btn-add')
  .addEventListener('click', () => calculateAndDisplay(add));

document.getElementById('btn-subtract')
  .addEventListener('click', () => calculateAndDisplay(subtract));

document.getElementById('btn-multiply')
  .addEventListener('click', () => calculateAndDisplay(multiply));
