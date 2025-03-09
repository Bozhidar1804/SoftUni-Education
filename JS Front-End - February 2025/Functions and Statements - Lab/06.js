function solve(n1, n2, n3) {
  let inputArr = [n1, n2, n3];
  let negativeNumbersCount = 0;

  for (let n of inputArr) {
    if (String(n).startsWith("-")) {
      negativeNumbersCount++;
    }
  }

  if (negativeNumbersCount == 1 || negativeNumbersCount == 3) {
    console.log("Negative");
  } else {
    console.log("Positive");
  }
}

solve(5, 12, -15);