function nthElement(inputArr, n) {
  let resultArr = [];
  for (let i = 0; i < inputArr.length; i += n) {
    resultArr.push(inputArr[i]);
  }

  return resultArr;
}