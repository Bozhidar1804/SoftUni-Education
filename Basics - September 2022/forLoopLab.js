function numbersfrom1to100() {
  for (let i = 1; i <= 100; i++) {
    console.log(i);
  }
}
// 01

function numsNto1(input) {
  let n = Number(input[0]);
  for (let i = n; i > 0; i--)
    console.log(i)
}
numsNto1(['10']); // 02

function nums1toNstep3(input) {
  let n = Number(input[0]);
  for (let i = 1; i <= n; i += 3) {
    console.log(i);
  }
}
nums1toNstep3('1'); // 03

function evenPowersOf2(input) {
  let n = Number(input[0]);

  for (let power = 0; power <= n; power += 2) {
    console.log(Math.pow(2, power));
  }
}
evenPowersOf2(['10']); // 04

function characterSequence(input) {
  let word = input[0]
  for (i = 0; i < word.length; i++) {
    console.log(word[i]);
  }
}
characterSequence(['hello']); // 05

function vowelsSum(input) {
  let word = input[0]
  let totalValue = 0;

  for (let i = 0; i < word.length; i++) {
    let currentCharacter = word.charAt(i);
    switch (currentCharacter) {
      case 'a': totalValue += 1
        break;
      case 'e': totalValue += 2
        break;
      case 'i': totalValue += 3
        break;
      case 'o': totalValue += 4
        break;
      case 'u': totalValue += 5
        break;
      default: break;
    }
  }
  console.log(totalValue);
}
vowelsSum(['hello']); // 06

function sumOfNumbers(input) {
  let word = input[0];
  let totalValue = 0;

  for (let i = 0; i < word.length; i++) {
    let currentDigit = Number(word.charAt(i));
    totalValue += currentDigit;
  }
  console.log(`The sum of the digits is:${totalValue}`);
}
sumOfNumbers(['1234']); // 07

function numbersDivisibleByNine(input) {
  let start = Number(input[0]);
  let end = Number(input[1]);

  let sum = 0;
  let numbers = '';

  for (let i = start; i <= end; i++) {
    if (i % 9 == 0) {
      sum += i;
      numbers += (i + '\n');
    }
  }
  console.log(`The sum: ${sum}`);
  console.log(numbers);
}
numbersDivisibleByNine(['100', '200']); // 08