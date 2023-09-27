function readText(input) {
  let index = 0;
  while (true) {
    if (input[index] === 'Stop') {
      break;
    }

    console.log(input[index]);
    index++;
  }
}
readText(['']); // 01

function password(input) {
  let username = input[0];
  let correctPassword = input[1];
  let index = 2;

  while (true) {
    let str = input[index];
    if (str == correctPassword) {
      console.log(`Welcome ${username}!`)
      break;
    }
  }
}
password(["Nakov", "1234", "Pass", "1324", "1234"]); // 02

function sumNumbers(input) {
  let firstNumber = Number(input[0]);
  let index = 1;
  let sum = 0;

  while (index < input.length) {
    sum = sum + Number(input[index]);
    if (sum >= firstNumber) {
      break;
    }

    index++
  }
  console.log(sum)
}
sumNumbers(["100", "10", "20", "30", "40"]); // 03

function sequence2kPlus1(input) {
  let num = Number(input[0]);
  let current = 1;
  while (true) {
    console.log(current);
    current = (current * 2) + 1;

    if (current > num) {
      break;
    }
  }
}
sequence2kPlus1(["31"]); // 04

function accountBalance(input) {
  let index = 0
  let command = input[index];
  let sum = 0;

  while (command !== 'NoMoreMoney') {
    let increase = Number(command);
    if (increase < 0) {
      console.log('Invalid operation!');
      break;
    }
    sum = sum + increase;
    console.log(`Increase: ${increase.toFixed(2)}`)
    index++;
    command = input[index];
  }
  console.log(`Total: ${sum.toFixed(2)}`);
}
accountBalance(["5.51", "69.42", "100", "NoMoreMoney"]); // 05

function maxNumber(input) {
  let index = 0;
  let command = input[index];
  let max = Number.MIN_SAFE_INTEGER;
  while (command !== 'Stop') {
    let value = Number(command);
    if (value > max) {
      max = value
    }

    command = input[index]
    index++;
  }
  console.log(max);
}
maxNumber(["100", "99", "80", "70", "Stop"]); // 06

function minNumber(input) {
  let index = 0;
  let command = input[index];
  let min = command;
  while (command !== 'Stop') {
    let value = Number(command);
    if (value < min) {
      min = value
    }

    command = input[index]
    index++;
  }
  console.log(min);
}
minNumber(["100", "99", "80", "70", "Stop"]); // 07

function graduation(input) {
  let name = input[0];
  let grades = 1;
  let sum = 0;
  let excluded = 0;
  let index = 0;
  while (grades <= 12) {
    index++;
    let grade = Number(input[index]);
    if (grade < 4.00) {
      excluded++;
      if (excluded > 1) {
        console.log(`${name} has been excluded at ${grades} grade`);
        break;
      }
      continue;
    }
    sum += grade;
    grades++;
  }
  let average = sum / 12;
  if (excluded < 1) {
    console.log(`${name} graduated. Average grade: ${average.toFixed(2)}`);
  }
}
graduation(["Mimi", "5", "6", "5", "6", "5", "6", "6", "2", "3"]);