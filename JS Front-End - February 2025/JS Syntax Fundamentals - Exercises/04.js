function calculate(start, end) {
  let sum = 0;
  let printNumbers = ``;
  for (let i = start; i <= end; i++) {
    printNumbers += i + ` `;
    sum += i;
  }
  console.log(printNumbers.trim());
  console.log(`Sum: ${sum}`);
}