function oddAndEvenSum(num) {
  let inputArr = String(num).split('');

  let oddSum = 0;
  let evenSum = 0;
  for (let n of inputArr) {
    let currentNumber = Number(n);
    if (currentNumber % 2 == 0) {
      evenSum += currentNumber;
    } else {
      oddSum += currentNumber;
    }
  }

  console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

oddAndEvenSum(1000435);