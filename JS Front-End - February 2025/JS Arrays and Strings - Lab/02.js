function arrayOperations(n, inputArr) {
  let newArr = [];
  for (let i = 0; i < n; i++) {
    newArr[i] = inputArr[i];
  }

  newArr = newArr.reverse();
  let result = "";
  for (let i = 0; i < newArr.length; i++) {
    result += newArr[i] + " ";
  }
  console.log(result.trim());
}

arrayOperations(3, [10, 20, 30, 40, 50]);