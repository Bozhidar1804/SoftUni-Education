function sameNumbers(input) {
  let convertedInput = String(input);
  let sum = 0;
  let isDigitSame = true;
  let previousChar = convertedInput[0];

  for (let char of convertedInput) {
    sum += Number(char);

    if (isDigitSame != false) {
      if (previousChar == char) {
        isDigitSame = true;
      } else {
        isDigitSame = false;
      }
    }
    previousChar = char;
  }

  if (isDigitSame) {
    console.log(isDigitSame);
    console.log(sum);
  } else {
    console.log(isDigitSame);
    console.log(sum);
  }
}