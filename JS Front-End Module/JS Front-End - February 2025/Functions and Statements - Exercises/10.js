function factorialDivision(n1, n2) {
  let firstFactorial = 1;
  for (let i = 1; i <= n1; i++) {
    firstFactorial *= i;
  }

  let secondFactorial = 1;
  for (let i = 1; i <= n2; i++) {
    secondFactorial *= i;
  }

  console.log((firstFactorial / secondFactorial).toFixed(2));
}

factorialDivision(5, 2);