function solve(a, b, operation) {
  let operationsMap = {
    multiply: (a, b) => a * b,
    divide: (a, b) => a / b,
    add: (a, b) => a + b,
    subtract: (a, b) => a - b
  };

  let action = operationsMap[operation];

  console.log(action(a, b));
}