function excellentResult(input) {
  let grade = Number(input[0]);

  if (grade >= 5.50) {
    console.log('Excellent!')
  }
}
excellentResult(['6']); // 01

function greaterNumber(input) {
  let num1 = Number(input[0]);
  let num2 = Number(input[1]);

  if (num1 > num2) {
    console.log(num1);
  } else {
    console.log(num2);
  }
}
greaterNumber(['5', '8']); // 02

function evenOrOdd(input) {
  let number = Number(input[0]);

  if (number % 2 == 0) {
    console.log('even');
  } else {
    console.log('odd');
  }
}
evenOrOdd(['8']); // 03

function passwordGuess(input) {
  let password = input[0];

  if (password === "s3cr3t!P@ssw0rd") {
    console.log('Welcome!');
  } else {
    console.log('Wrong password!');
  }
}
passwordGuess("s3cr3t!P@ssw0rd"); // 04

function numberBetween100and200(input) {
  let number = Number(input[0]);

  if (number < 100) {
    console.log('Less than 100');
  } else if (number > 100, number < 200) {
    console.log('Between 100 and 200');
  } else if (number > 200) {
    console.log('Greater than 200');
  }
}
numberBetween100and200(['95']); // 05

function speedInfo(input) {
  let speed = Number(input[0]);

  if (speed <= 10) {
    console.log('slow');
  } else if (speed >= 10, speed <= 50) {
    console.log('average');
  } else if (speed >= 50, speed <= 150) {
    console.log('fast');
  } else if (speed >= 150, speed <= 1000) {
    console.log('ultra fast');
  } else if (speed > 1000) {
    console.log('extremely fast');
  }
}
speedInfo(['8']); // 06

function areaOfFigures(input) {
}
areaOfFigures();