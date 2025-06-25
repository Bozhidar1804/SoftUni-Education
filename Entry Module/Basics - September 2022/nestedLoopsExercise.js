function sumPrimeNonPrime(input) {
  let index = 0;
  let command = input[index];
  let primeSum = 0;
  let nonPrimeSum = 0;
  let isPrime = true;

  while (command !== 'stop') {
    let currentNumber = Number(command);

    if (currentNumber < 0) {
      console.log(`Number is negative.`)
      index++;
      command = input[index];
      continue;
    }

    for (let i = 2; i < currentNumber; i++) {
      if (currentNumber % i == 0) {
        isPrime = false;
        break;
      }
    }

    if (isPrime) {
      primeSum += currentNumber;
    } else {
      nonPrimeSum += currentNumber;
    }

    isPrime = true;
    index++;
    command = input[index];
  }

  console.log(`Sum of all prime numbers is: ${primeSum}`);
  console.log(`Sum of all non prime numbers is: ${nonPrimeSum}`);
}
sumPrimeNonPrime(['30', "83", "33", "-1", "20", "stop"]); // 03

function trainTheTrainers(input) {
  let judges = Number(input[0]);
  let index = 1;
  let command = input[index];
  let presentationSum = 0;
  let counter = 0;

  while (command !== 'Finish') {
    let presentationName = command;
    let singlePresentationSum = 0;

    for (let i = 1; i <= judges; i++) {
      counter++;
      index++
      let grades = Number(input[index]);
      singlePresentationSum += grades;
    }

    presentationSum += singlePresentationSum;
    console.log(`${presentationName} - ${(singlePresentationSum / judges).toFixed(2)}.`);

    index++;
    command = input[index];
  }

  console.log(`Student's final assessment is ${(presentationSum / counter).toFixed(2)}.`)
}
trainTheTrainers(["2", "While-Loop", "6.00", "5.50", "For-Loop", "5.84", "5.66", "Finish"]); // 04

function specialNumbers(input) {
  let specialNumber = Number(input[0]);
  let output = '';

  for (let i = 1; i <= 9; i++) {
    for (let j = 1; j <= 9; j++) {
      for (let k = 1; k <= 9; k++) {
        for (let l = 1; l <= 9; l++) {
          if (specialNumber % i == 0 &&
            specialNumber % j == 0 &&
            specialNumber % k == 0 &&
            specialNumber % l == 0) {
            output += `${i}${j}${k}${l} `;
          }
        }
      }
    }
  }
  console.log(output);
}
specialNumbers(['3']); // 05

function cinemaTickets(input) {
  let index = 0;
  let command = input[index];
  let studentCounter = 0;
  let standardCounter = 0;
  let kidCounter = 0;
  let totalTickets = 0;

  while (command !== 'Finish') {
    let name = command;
    index++;
    let freeSpaces = Number(input[index]);
    index++;

    let ticketType = input[index];
    let ticketCounter = 0;

    while (ticketType !== 'End') {
      ticketCounter++;

      switch (ticketType) {
        case 'student': studentCounter++; break;
        case 'standard': standardCounter++; break;
        case 'kid': kidCounter++; break;
      }
      if (ticketCounter >= freeSpaces) {
        break;
      }
      ticketType = input[++index];
    }

    totalTickets += ticketCounter;

    let resultSingleFilm = ticketCounter / freeSpaces * 100;
    console.log(`${name} - ${(resultSingleFilm).toFixed(2)}% full.`)

    index++;
    command = input[index];
  }

  console.log(`Total tickets: ${totalTickets}`);
  console.log(`${(studentCounter / totalTickets * 100).toFixed(2)}% student tickets.`);
  console.log(`${(standardCounter / totalTickets * 100).toFixed(2)}% standard tickets.`);
  console.log(`${(kidCounter / totalTickets * 100).toFixed(2)}% kids tickets.`);
}
cinemaTickets(["Taxi", "10", "standard", "kid", "student", "student", "standard", "standard", "End", "Scary Movie", "6", "student", "student", "student", "student", "student", "student", "Finish"]);
// 06