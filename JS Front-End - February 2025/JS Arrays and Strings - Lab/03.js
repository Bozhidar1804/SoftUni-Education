function evenOddNumbers(inputArr) {
  let evenNumbers = 0;
  let oddNumbers = 0;

  for (let i = 0; i < inputArr.length; i++) {
    if (inputArr[i] % 2 == 0) {
      evenNumbers += inputArr[i];
    } else {
      oddNumbers += inputArr[i];
    }
  }

  let result = evenNumbers - oddNumbers;
  console.log(result);
}