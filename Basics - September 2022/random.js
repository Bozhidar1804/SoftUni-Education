function minNumber(input) {
  let totalNumbers = Number(input[0]);
  let minNumber = 0;

  for (let i = 1; i <= totalNumbers; i++) {
    let currentNumber = Number(input[i]);

    if (minNumber > currentNumber) {
      minNumber = currentNumber;
    }
  }
  console.log(minNumber);
}
minNumber(["3", "-10", "-20", "30"])