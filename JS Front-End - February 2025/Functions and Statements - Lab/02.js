function power(number, n) {
  value = number;
  for (let i = 1; i < n; i++) {
    number *= value;
  }

  console.log(number);
}

power(2, 8);