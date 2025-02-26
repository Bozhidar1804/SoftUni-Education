function sortNumbers(inputArr) {
  let descendingArr = [...inputArr].sort((a, b) => b - a);
  let ascendingArr = [...inputArr].sort((a, b) => a - b);

  let resultArr = [];
  let length = inputArr.length;

  for (let i = 0; i < Math.floor(length / 2); i++) {
    resultArr.push(ascendingArr[i]);
    resultArr.push(descendingArr[i]);
  }

  if (length % 2 !== 0) {
    resultArr.push(ascendingArr[Math.floor(length / 2)]);
  }

  return resultArr;
}

sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);
// [-3, 65, 1, 63, 3, 56, 18, 52, 31, 48]