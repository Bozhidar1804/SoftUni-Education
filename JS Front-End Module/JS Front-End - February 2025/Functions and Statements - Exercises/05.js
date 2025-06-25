function isPalindrome(inputArr) {

  for (let currentNumber of inputArr) {
    let reversedString = String(currentNumber)
      .split('')
      .reverse()
      .join('');

    let reversedNumber = Number(reversedString);

    console.log(currentNumber == reversedNumber ? "true" : "false");
  }
}

isPalindrome([123, 323, 421, 121]);