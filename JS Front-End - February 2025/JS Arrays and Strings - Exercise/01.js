function rotation(inputArr, n) {
  let result = [];
  let currentArr = [];
  for (let i = 0; i < n; i++) {
    let firstNumber = inputArr[0];
    currentArr = [];
    for (let i = 1; i < inputArr.length; i++) {
      currentArr.push(inputArr[i]);
    }
    currentArr.push(firstNumber);
    inputArr = currentArr;
    if (i == n - 1) {
      result = inputArr;
    }
  }

  let print = '';
  for (let number of result) {
    print += number + " ";
  }
  console.log(print);
}

rotation([51, 47, 32, 61, 21], 2);

/*
function rotation(inputArr, n) {
  n = n % inputArr.length;  // Prevent unnecessary full rotations
  let rotatedArr = inputArr.slice(n).concat(inputArr.slice(0, n));
  
  console.log(rotatedArr.join(" "));
}
*/