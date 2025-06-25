function sumDigits(number) {
  let numberString = String(number);
  let sum = 0;

  for (let char of numberString) {
    sum += Number(char);
  }

  console.log(sum);
}